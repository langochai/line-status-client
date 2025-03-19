using LineStatusClient.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LineStatusClient.Models;
using DevExpress.XtraEditors;
using System.IO;
using ClosedXML.Excel;
using LineStatusClient.DTOs;
using DocumentFormat.OpenXml.Spreadsheet;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

namespace LineStatusClient.Froms
{
    public partial class frmHistory : XtraForm
    {
        List<LineShiftDT0_W> list_LineShift = new List<LineShiftDT0_W>();
        public frmHistory()
        {
            InitializeComponent();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            dtpDateTime.EditValue = DateTime.Now;
            LoadLine();
        }

        #region LOAD DATA

        private void LoadLine()
        {
            try
            {
                var listLines = SQLHelper<Line_mst>.SqlToList("select * from Line_mst order by sort asc");
                cb_Line.Properties.DataSource = listLines;
                cb_Line.Properties.DisplayMember = "Line_nm";
                cb_Line.Properties.ValueMember = "Line_c";
            }
            catch (Exception)
            {
            }
        }

        private void loadData()
        {
            try
            {
                DateTime date = Convert.ToDateTime(dtpDateTime.EditValue).Date;
                string lineCode = SQLUtilities.ToString(cb_Line.EditValue);
                int shift = SQLUtilities.ToInt(cb_Shift.EditValue);
                if (shift <= 0 || lineCode == "") return;

                LineShiftDT0_W shiftModel = list_LineShift.FirstOrDefault(x => x.ShiftCode == shift) ?? new LineShiftDT0_W();

                TimeSpan startSpan = TimeSpan.Parse(shiftModel.StartTime);
                TimeSpan endSpan = TimeSpan.Parse(shiftModel.EndTime);
                DateTime dateStart = date + startSpan;
                DateTime dateEnd = (startSpan > endSpan) ? date.AddDays(1) + endSpan : date + endSpan;
                string strDateStart = dateStart.ToString("yyyy-MM-dd HH:mm:ss");
                string strDateEnd = dateEnd.ToString("yyyy-MM-dd HH:mm:ss");

                var allLineStatus = SQLHelper<Line_downtime_history_DTO>.ProcedureToList("spGetLineStatusChangeTime",
                new string[] { "@DateStart", "@DateEnd", "@LineCode", "@Shift" },
                new object[] { dateStart, dateEnd, lineCode, shift });
                grdData.DataSource = allLineStatus;
            }
            catch (Exception)
            {
            }
        }

        private void loadWorkShift()
        {
            try
            {
                string lineCode = cb_Line.EditValue.ToString().Trim();
                if (lineCode == "") return;

                list_LineShift = SQLHelper<LineShiftDT0_W>.SqlToList($"select ls.*, ws.ShiftCode, ws.ShiftName, ws.StartTime, ws.EndTime from [LineShift] ls " +
                    $"inner join WorkShift ws on ws.ID = ls.WorkShiftID " +
                    $"where ls.LineCode = {lineCode}").ToList();

                if (list_LineShift.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy ca làm việc của chuyền [{lineCode}]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cb_Shift.Properties.DataSource = list_LineShift;
                cb_Shift.Properties.DisplayMember = "ShiftName";
                cb_Shift.Properties.ValueMember = "ShiftCode";
                cb_Shift.EditValue = "";
            }
            catch (Exception ex)
            {
                ErrorLogger.SaveLog("cb_Line_EditValueChanged", ex.Message);
            }
        }
        #endregion

        #region EXPORT EXCEL

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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<Line_downtime_history_DTO> data = (List<Line_downtime_history_DTO>)grdData.DataSource;
            if (data.Count <= 0) return;
            var dateTime = Convert.ToDateTime(dtpDateTime.EditValue).Date;
            int shift = SQLUtilities.ToInt(cb_Shift.EditValue);
            var savePath = OpenSaveFileForm($"Lịch sử trạng thái dây chuyền {cb_Line.Text}_{dateTime.ToString("ddMMyyyy")}");
            if (string.IsNullOrEmpty(savePath)) return;
            Task.Run(() =>
            {
                try
                {
                    var groupedStatusData = data
                        .Select((item, index) => new { Item = item, Index = index }) // Thêm chỉ mục để theo dõi vị trí
                        .Where((x, i) => i == 0 || x.Item.status != data[i - 1].status) // Chỉ giữ dòng đầu mỗi nhóm liên tiếp
                        .Select(x => x.Item) // Lấy lại đối tượng gốc
                        .ToList();
                    var groupedProductData = data
                        .Select((item, index) => new { Item = item, Index = index }) // Thêm chỉ mục
                        .GroupBy(x => new { x.Item.product_count, GroupKey = GetGroupKey(data, x.Index) }) // Nhóm theo product_count & vị trí liên tiếp
                        .Select(g => g.Last().Item) // Lấy phần tử cuối mỗi nhóm
                        .ToList();


                    btnExportExcel.BeginInvoke(new Action(() => { btnExportExcel.Enabled = false; }));
                    string excelFilename = $"template.xlsx";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "" + excelFilename);
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var template = workbook.Worksheet(1);
                        using (var newWorkbook = new XLWorkbook())
                        {
                            var newSheet = template.CopyTo(newWorkbook, "1");
                            newSheet.Cell(1, 1).Value = $"Bảng quản lý sản xuất dây chuyền: {data[0].line_code}   ngày: {dateTime.Date}";

                            /// tính theo status
                            int col = 2;
                            foreach (var result in groupedStatusData)
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
                            // tính theo product_count
                            int rowStart = 8;
                            foreach (var result in groupedProductData)
                            {
                                newSheet.Cell(rowStart, 1).Value = result.timestamp.ToString("HH:mm:ss");
                                newSheet.Cell(rowStart, 2).Value = result.product_count;
                                rowStart += 1;
                            }

                            // tính tổng Thời gian dừng, chạy
                            // Sắp xếp dữ liệu theo timestamp
                            data = data.OrderBy(d => d.timestamp).ToList();
                            TimeSpan totalRunTime = TimeSpan.Zero;
                            TimeSpan totalDowntime = TimeSpan.Zero;
                            for (int i = 0; i < data.Count - 1; i++)
                            {
                                var current = data[i];
                                var next = data[i + 1];

                                TimeSpan duration = next.timestamp - current.timestamp;

                                if (current.status == 1)  // Thời gian chạy
                                {
                                    totalRunTime += duration;
                                }
                                else if (current.status == 3) // Thời gian dừng
                                {
                                    totalDowntime += duration;
                                }
                            }
                            string formattedRunTime = $"{(int)totalRunTime.TotalHours:D2}:{totalRunTime.Minutes:D2}:{totalRunTime.Seconds:D2}";
                            string formattedDowntime = $"{(int)totalDowntime.TotalHours:D2}:{totalDowntime.Minutes:D2}:{totalDowntime.Seconds:D2}";
                            newSheet.Cell(8, 6).Value = formattedRunTime;
                            newSheet.Cell(8, 7).Value = formattedDowntime;

                            newWorkbook.SaveAs(savePath);
                        }
                    };
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                finally
                {
                    btnExportExcel.BeginInvoke(new Action(() => { btnExportExcel.Enabled = true; }));
                }
            });
        }

        #endregion

        #region OTHERS

        private static int GetGroupKey(List<Line_downtime_history_DTO> data, int index)
        {
            if (index == 0) return 0;

            int key = 0;
            for (int i = 1; i <= index; i++)
            {
                if (data[i].product_count != data[i - 1].product_count)
                    key++; // Tăng key khi thay đổi product_count
            }
            return key;
        }

        private void cb_Line_EditValueChanged(object sender, EventArgs e)
        {
            loadWorkShift();
        }

        private void cb_Shift_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = grvData.GetRowHandle(e.ListSourceRowIndex) + 1;
            }
        }
        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
