using ClosedXML.Excel;
using DevExpress.XtraEditors;
using DocumentFormat.OpenXml.Office2010.Excel;
using LineStatusClient.Common;
using LineStatusClient.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineStatusClient
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
            dtpDateStart.EditValue = dtpDateEnd.EditValue = DateTime.Now;
            InitializeCheckStartUp();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Settings.ReadSQLConnectionString();
            LoadData();
            new Thread(SynchData) { IsBackground = true }.Start();
        }

        #region Minimize to tray

        private void btnMinimize_Click(object sender, EventArgs e)
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

        private void chkRunOnStartUp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRunOnStartUp.Checked) AddToStartup();
            else RemoveFromStartup();
        }

        public void InitializeCheckStartUp()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
                if (key != null)
                {
                    object value = key.GetValue("LineStatusClient");
                    chkRunOnStartUp.Checked = value != null;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing from startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Run on start up

        private void LoadData()
        {
            grdMain.BeginInvoke(new Action(() =>
            {
                var dateStart = dtpDateStart.EditValue;
                var dateEnd = dtpDateEnd.EditValue;
                var textFilter = txtSearch.Text.Trim();
                var data = SQLHelper<Line_downtime_history>.ProcedureToList("spGetLineStatus",
                    new string[] { "@DateStart", "@DateEnd", "@TextFilter" },
                    new object[] { dateStart, dateEnd, textFilter });
                grdMain.DataSource = data;
            }));
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            var savePath = OpenSaveFileForm("Lịch sử trạng thái dây chuyền");
            if (string.IsNullOrEmpty(savePath)) return;
            Task.Run(() =>
            {
                try
                {
                    btnExport.BeginInvoke(new Action(() => { btnExport.Enabled = false; }));
                    var (dateStart, dateEnd) = (Convert.ToDateTime(dtpDateStart.EditValue).Date, Convert.ToDateTime(dtpDateEnd.EditValue).Date.AddDays(1).AddMilliseconds(-3));
                    var textFilter = txtSearch.Text.Trim();
                    var allLineStatus = SQLHelper<Line_downtime_history>.ProcedureToList("spGetLineStatusChangeTime",
                    new string[] { "@DateStart", "@DateEnd", "@LineCode" },
                    new object[] { dateStart, dateEnd, textFilter });
                    var data = allLineStatus
                        .GroupBy(d => new { d.line_code, d.timestamp.Date })
                        .Select(d => new
                        {
                            d.Key.line_code,
                            d.Key.Date,
                            Items = d.ToList()
                        }).ToList();
                    string excelFilename = $"template.xlsx";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "refs\\" + excelFilename);
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var template = workbook.Worksheet(1);
                        using (var newWorkbook = new XLWorkbook())
                        {
                            for (var i = 0; i <= data.Count - 1; i++)
                            {
                                var newSheet = template.CopyTo(newWorkbook, i.ToString());
                                newSheet.Cell(1, 1).Value = $"Bảng quản lý sản xuất dây chuyền {data[i].line_code}   ngày: {data[i].Date}";

                                int col = 2;
                                foreach(var result in data[i].Items)
                                {
                                    newSheet.Cell(3, col).Value = result.timestamp.ToString("HH:mm:ss");
                                    switch (result.status)
                                    {
                                        case 0:
                                            newSheet.Cell(2, col).Value = "Không chạy";
                                            newSheet.Cell(2, col).Style.Font.FontColor = XLColor.WhiteSmoke;
                                            newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                                            break;
                                        case 1:
                                            newSheet.Cell(2, col).Value = "Chạy";
                                            newSheet.Cell(2, col).Style.Font.FontColor = XLColor.Green;
                                            newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.Green;
                                            break;
                                        case 2:
                                            newSheet.Cell(2, col).Value = "Nghỉ trưa";
                                            newSheet.Cell(2, col).Style.Font.FontColor = XLColor.Yellow;
                                            newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.Yellow;
                                            break;
                                        case 3:
                                            newSheet.Cell(2, col).Value = "Dừng";
                                            newSheet.Cell(2, col).Style.Font.FontColor = XLColor.OrangeRed;
                                            newSheet.Cell(2, col).Style.Fill.BackgroundColor = XLColor.OrangeRed;
                                            break;
                                        default:
                                            break;
                                    }
                                    col += 1;
                                }

                                var query = $@"
                                    select * from Line_downtime_history
                                    where [timestamp] between '{dateStart:yyyy-MM-dd HH:mm:ss:fff}' and '{dateEnd:yyyy-MM-dd HH:mm:ss:fff}'
                                    and line_code = '{data[i].line_code}'";
                                var productList = SQLHelper<Line_downtime_history>.SqlToList(query);
                                int row = 8;
                                foreach (var item in productList)
                                {
                                    newSheet.Cell(row, 1).Value = item.timestamp.ToString("yyyy/MM/dd HH:mm:ss");
                                    newSheet.Cell(row, 2).Value = item.product_count;
                                    row++;
                                }
                            }
                            newWorkbook.SaveAs(savePath);
                        }
                    };
                    this.BeginInvoke(new Action(() => { 
                        MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }));
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() => { 
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }));
                }
                finally
                {
                    btnExport.BeginInvoke(new Action(() => { btnExport.Enabled = true; }));
                }
            });
        }
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
    }
}