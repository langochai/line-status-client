using ClosedXML.Excel;
using DevExpress.Utils.Extensions;
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
using LineStatusClient.Forms;
using LineStatusClient.Forms.Email;
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

        public FormMain()
        {
            InitializeComponent();
            InitializeCheckStartUp();
            InitializeTimer();
        }

        private async void FormMain_Shown(object sender, EventArgs e)
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                Settings.ReadSQLConnectionString();
                LoadData();
                Task.Run(() => ListenToQueue());
            });
            await task1;
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
                    int status = SQLUtilities.ToInt(gridView.GetRowCellValue(i, "status"));

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
                string[] parts = time.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);

                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours++;
                }

                return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
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
                        new string[] { },
                        new object[] { });

                    grdMain.DataSource = data;
                }));
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private void ListenToQueue()
        {
            while (true)
            {
                try
                {
                    using (var connection = new SqlConnection(Settings.connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand("WAITFOR (RECEIVE TOP(1) conversation_handle FROM dbo.DataChangeQueue)", connection))
                        {
                            command.CommandTimeout = 60; // Tránh treo vĩnh viễn

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string conversationHandle = reader["conversation_handle"].ToString();
                                    LoadData(); // Gọi hàm cập nhật dữ liệu

                                    // Kết thúc hội thoại để dọn dẹp Queue
                                    using (var endConvCommand = new SqlCommand("END CONVERSATION @handle", connection))
                                    {
                                        endConvCommand.Parameters.AddWithValue("@handle", conversationHandle);
                                        endConvCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    ErrorLogger.SaveLog("SQL Error in ListenToQueue: ", sqlEx.Message);
                    Thread.Sleep(5000); // Nếu lỗi SQL, chờ 5 giây trước khi thử lại
                }
                catch (Exception ex)
                {
                    ErrorLogger.SaveLog("Error in ListenToQueue: ", ex.Message);
                }
            }
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
            flyoutPanel1.HideBeakForm();
            frmHistory frm = new frmHistory();
            frm.ShowDialog();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            flyoutPanel1.HideBeakForm();
            frmEmail frm = new frmEmail();
            frm.ShowDialog();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            flyoutPanel1.HideBeakForm();
            frmEnterPassword frmPass = new frmEnterPassword();
            if (frmPass.ShowDialog() != DialogResult.OK) return;

            frmShift frm = new frmShift();
            frm.ShowDialog();
        }
        #endregion
    }
}