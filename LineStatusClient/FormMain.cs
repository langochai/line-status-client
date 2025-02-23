﻿using ClosedXML.Excel;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.Excel;
using LineStatusClient.Common;
using LineStatusClient.DTOs;
using LineStatusClient.Froms;
using LineStatusClient.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineStatusClient
{
    public partial class FormMain : XtraForm
    {
        private System.Windows.Forms.Timer timerRunAndDown;
        private frmHistory frmHistoryShow = null;
        public FormMain()
        {
            InitializeComponent();
            InitializeCheckStartUp();
            InitializeTimer();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Settings.ReadSQLConnectionString();
            LoadData();
            new Thread(SynchData) { IsBackground = true }.Start();
        }

        #region Count running and stopping time

        private void InitializeTimer()
        {
            timerRunAndDown = new System.Windows.Forms.Timer();
            timerRunAndDown.Interval = 1000; // Mỗi giây
            timerRunAndDown.Tick += Timer_Tick;
            timerRunAndDown.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                GridView gridView = grvMain;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    int status = Convert.ToInt32(gridView.GetRowCellValue(i, "status"));

                    if (status == 1) // Cộng vào TotalRunningTime
                    {
                        string time = gridView.GetRowCellValue(i, "TotalRunningTime").ToString();
                        gridView.SetRowCellValue(i, "TotalRunningTime", AddOneSecond(time));
                    }
                    else if (status == 3) // Cộng vào TotalDowntime
                    {
                        string time = gridView.GetRowCellValue(i, "TotalDowntime").ToString();
                        gridView.SetRowCellValue(i, "TotalDowntime", AddOneSecond(time));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private string AddOneSecond(string time)
        {
            try
            {
                TimeSpan ts = TimeSpan.Parse(time);
                ts = ts.Add(TimeSpan.FromSeconds(1));
                return ts.ToString(@"hh\:mm\:ss");
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
                return "00:00:00";
            }
        }

        private string AddElapsedTime(string currentTime, TimeSpan elapsedTime)
        {
            try
            {
                TimeSpan ts = TimeSpan.Parse(currentTime);
                ts = ts.Add(elapsedTime);
                return ts.ToString(@"hh\:mm\:ss");
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
                return "00:00:00";
            }
        }

        #endregion

        #region Minimize to tray
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void mnitemShow_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void mnitemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowForm()
        {
            notifyIcon.Visible = false;
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        #endregion Minimize to tray

        #region Run on start up
        private void btnRunAtStartup_Click(object sender, EventArgs e)
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
            if (key != null)
            {
                object value = key.GetValue("LineStatusClient");
                if (value != null) RemoveFromStartup();
                else AddToStartup();
            }
            else AddToStartup();
        }

        public void InitializeCheckStartUp()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
                if (key != null)
                {
                    object value = key.GetValue("LineStatusClient");
                    if (value != null)
                        btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.LimeGreen;
                    else 
                        btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.Silver;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking startup registry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddToStartup()
        {
            try
            {
                string appName = "LineStatusClient";
                string appPath = Application.ExecutablePath;

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(appName, "\"" + appPath + "\"");
                btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveFromStartup()
        {
            try
            {
                string appName = "LineStatusClient";

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue(appName, false);
                btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.Silver;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing from startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Run on start up

        #region LOAD DATA

        private void LoadData()
        {
            try
            {
                grdMain.BeginInvoke(new Action(() =>
                {
                    var dateStart = DateTime.Now;
                    var data = SQLHelper<Line_downtime_history_DTO>.ProcedureToList("spGetLineStatus",
                        //new string[] { "@DateStart", "@DateEnd", "@TextFilter" },
                        //new object[] { dateStart, dateEnd, textFilter });
                        new string[] { },
                        new object[] { });

                    foreach (Line_downtime_history_DTO row in data)
                    {
                        if (row.WorkDate != null)
                        {
                            DateTime workDate = row.WorkDate;
                            TimeSpan elapsedTime = DateTime.Now - workDate; // Thời gian đã trôi qua từ WorkDate

                            if (row.status == 1) // Nếu đang chạy
                                row.TotalRunningTime = AddElapsedTime(row.TotalRunningTime, elapsedTime);
                            else if (row.status == 3) // Nếu đang dừng
                                row.TotalDowntime = AddElapsedTime(row.TotalDowntime, elapsedTime);
                        }
                    }

                    grdMain.DataSource = data;
                }));
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private void SynchData()
        {
            // Note: Identity of sqldenpendency MUST be unique across all apps, check DB if you're not sure which to use.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Settings.connectionString);
            string dbName = builder.InitialCatalog;
            var dependency = new SqlDependencyEx(Settings.connectionString, dbName, "Line_downtime_history", identity: 2);
            dependency.TableChanged += (sender, e) => { LoadData(); };
            dependency.Start();
        }

        private void Datepicker_EditValueChanged(object sender, EventArgs e)
        {
            var datepicker = sender as DateEdit;
            if (datepicker.EditValue == null) datepicker.EditValue = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }
        #endregion

        #region OTHERS

        //tự sinh STT
        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = grvMain.GetRowHandle(e.ListSourceRowIndex) + 1;
            }
        }

        //Đổ màu row theo status
        private void grvMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // Kiểm tra có phải là hàng hợp lệ không
            {
                int status = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "status"));
                switch (status)
                {
                    case 0: // Không chạy
                        e.Appearance.BackColor = System.Drawing.Color.White;
                        e.Appearance.ForeColor = System.Drawing.Color.Black;
                        break;
                    case 1: // Chạy
                        e.Appearance.BackColor = System.Drawing.Color.ForestGreen;
                        e.Appearance.ForeColor = System.Drawing.Color.White;
                        break;
                    case 2: // Nghỉ trưa
                        e.Appearance.BackColor = System.Drawing.Color.Yellow;
                        e.Appearance.ForeColor = System.Drawing.Color.Black;
                        break;
                    case 3:  // Dừng
                        e.Appearance.BackColor = System.Drawing.Color.OrangeRed;
                        e.Appearance.ForeColor = System.Drawing.Color.White;
                        break;
                    default:
                        e.Appearance.BackColor = System.Drawing.Color.White;
                        e.Appearance.ForeColor = System.Drawing.Color.Black;
                        break;
                }
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            flyoutPanel1.ShowBeakForm();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (frmHistoryShow == null || frmHistoryShow.IsDisposed)
            {
                frmHistoryShow = new frmHistory();
                frmHistoryShow.Show();
            }
            else
            {
                if (frmHistoryShow.WindowState == FormWindowState.Minimized)
                    frmHistoryShow.WindowState = FormWindowState.Maximized;
                frmHistoryShow.TopMost = true;  // Đảm bảo form hiển thị trên cùng
                frmHistoryShow.TopMost = false; // Trả về trạng thái bình thường
                frmHistoryShow.BringToFront();
                frmHistoryShow.Activate();
            }
            
        }

        #endregion
    }
}