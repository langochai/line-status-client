using ClosedXML.Excel;
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
        private bool _isRunOnStartUp = false;
        private System.Windows.Forms.Timer timer;
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
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Mỗi giây
            timer.Tick += Timer_Tick;
            timer.Start();
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
            if (_isRunOnStartUp) RemoveFromStartup();
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
                    _isRunOnStartUp = value != null;
                    if (_isRunOnStartUp) btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.LimeGreen;
                    else btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.Silver;
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
                _isRunOnStartUp = true;
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
                _isRunOnStartUp = false;
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

        #region EXPORT EXCEL

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    var savePath = OpenSaveFileForm("Lịch sử trạng thái dây chuyền");
        //    if (string.IsNullOrEmpty(savePath)) return;
        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            btnExport.BeginInvoke(new Action(() => { btnExport.Enabled = false; }));
        //            var (dateStart, dateEnd) = (Convert.ToDateTime(dtpDateStart.EditValue).Date, Convert.ToDateTime(dtpDateEnd.EditValue).Date.AddDays(1).AddMilliseconds(-3));
        //            var textFilter = txtSearch.Text.Trim();
        //            var allLineStatus = SQLHelper<Line_downtime_history>.ProcedureToList("spGetLineStatusChangeTime",
        //            new string[] { "@DateStart", "@DateEnd", "@LineCode" },
        //            new object[] { dateStart, dateEnd, textFilter });
        //            var data = allLineStatus
        //                .GroupBy(d => new { d.line_code, d.timestamp.Date })
        //                .Select(d => new
        //                {
        //                    d.Key.line_code,
        //                    d.Key.Date,
        //                    Items = d.ToList()
        //                }).ToList();
        //            string excelFilename = $"template.xlsx";
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "refs\\" + excelFilename);
        //            using (var workbook = new XLWorkbook(filePath))
        //            {
        //                var template = workbook.Worksheet(1);
        //                using (var newWorkbook = new XLWorkbook())
        //                {
        //                    for (var i = 0; i <= data.Count - 1; i++)
        //                    {
        //                        var newSheet = template.CopyTo(newWorkbook, i.ToString());
        //                        newSheet.Cell(1, 1).Value = $"Bảng quản lý sản xuất dây chuyền {data[i].line_code}   ngày: {data[i].Date}";

        //                        int col = 2;
        //                        foreach (var result in data[i].Items)
        //                        {
        //                            newSheet.Cell(3, col).Value = result.timestamp.ToString("HH:mm:ss");
        //                            switch (result.status)
        //                            {
        //                                case 0:
        //                                    newSheet.Cell(2, col).Value = "Không chạy";
        //                                    newSheet.Cell(2, col).Style.Font.FontColor = XLColor.WhiteSmoke;
        //                                    newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
        //                                    break;
        //                                case 1:
        //                                    newSheet.Cell(2, col).Value = "Chạy";
        //                                    newSheet.Cell(2, col).Style.Font.FontColor = XLColor.Green;
        //                                    newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.Green;
        //                                    break;
        //                                case 2:
        //                                    newSheet.Cell(2, col).Value = "Nghỉ trưa";
        //                                    newSheet.Cell(2, col).Style.Font.FontColor = XLColor.Yellow;
        //                                    newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.Yellow;
        //                                    break;
        //                                case 3:
        //                                    newSheet.Cell(2, col).Value = "Dừng";
        //                                    newSheet.Cell(2, col).Style.Font.FontColor = XLColor.OrangeRed;
        //                                    newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.OrangeRed;
        //                                    break;
        //                                default:
        //                                    break;
        //                            }
        //                            col += 1;
        //                        }

        //                        var query = $@"
        //                            select * from Line_downtime_history
        //                            where [timestamp] between '{dateStart:yyyy-MM-dd HH:mm:ss:fff}' and '{dateEnd:yyyy-MM-dd HH:mm:ss:fff}'
        //                            and line_code = '{data[i].line_code}'";
        //                        var productList = SQLHelper<Line_downtime_history>.SqlToList(query);
        //                        int row = 8;
        //                        foreach (var item in productList)
        //                        {
        //                            newSheet.Cell(row, 1).Value = item.timestamp.ToString("yyyy/MM/dd HH:mm:ss");
        //                            newSheet.Cell(row, 2).Value = item.product_count;
        //                            row++;
        //                        }
        //                    }
        //                    newWorkbook.SaveAs(savePath);
        //                }
        //            };
        //            this.BeginInvoke(new Action(() =>
        //            {
        //                MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }));
        //        }
        //        catch (Exception ex)
        //        {
        //            this.BeginInvoke(new Action(() =>
        //            {
        //                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }));
        //        }
        //        finally
        //        {
        //            btnExport.BeginInvoke(new Action(() => { btnExport.Enabled = true; }));
        //        }
        //    });
        //}
        private string OpenSaveFileForm(string fileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file excel";
                saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                else return "";
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

        #endregion

    }
}