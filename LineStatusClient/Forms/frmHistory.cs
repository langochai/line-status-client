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

namespace LineStatusClient.Froms
{
    public partial class frmHistory : XtraForm
    {
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
                DateTime dateStart = date.AddHours(8); // Bắt đầu từ 06:00:00 hôm nay
                DateTime dateEnd = date.AddDays(1).AddHours(7).AddMinutes(59).AddSeconds(59); // Kết thúc lúc 05:59:59 ngày mai

                string strDateStart = dateStart.ToString("yyyy-MM-dd HH:mm:ss");
                string strDateEnd = dateEnd.ToString("yyyy-MM-dd HH:mm:ss");

                var lineCode = SQLUtilities.ToString(cb_Line.EditValue);
                var shift = SQLUtilities.ToInt(cb_Shift.SelectedIndex) + 1;

                var allLineStatus = SQLHelper<Line_downtime_history_DTO>.ProcedureToList("spGetLineStatusChangeTime",
                new string[] { "@DateStart", "@DateEnd", "@LineCode", "@Shift" },
                new object[] { dateStart, dateEnd, lineCode, shift });
                grdData.DataSource = allLineStatus;
            }
            catch (Exception)
            {
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
            List<Line_downtime_history_DTO> listLineStatus = (List<Line_downtime_history_DTO>)grdData.DataSource;
            if (listLineStatus.Count <= 0) return;
            var dateTime = Convert.ToDateTime(dtpDateTime.EditValue).Date;
            int shift = cb_Shift.SelectedIndex + 1;
            var savePath = OpenSaveFileForm($"Lịch sử trạng thái dây chuyền {cb_Line.Text}_{dateTime.ToString("ddMMyyyy")}");
            if (string.IsNullOrEmpty(savePath)) return;
            Task.Run(() =>
            {
                try
                {
                    btnExportExcel.BeginInvoke(new Action(() => { btnExportExcel.Enabled = false; }));
                    var data = listLineStatus
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
                                //newSheet.Cell(1, 1).Value = $"Bảng quản lý sản xuất dây chuyền: {data[i].line_code}   ngày: {data[i].Date}";

                                int col = 2;
                                foreach (var result in data[i].Items)
                                {
                                    newSheet.Cell(1, 1).Value = $"Bảng quản lý sản xuất dây chuyền: {result.line_nm}   ngày: {data[i].Date}";
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

                                //var query = $@"
                                //        select * from Line_downtime_history
                                //        where [timestamp] between '{dateStart:yyyy-MM-dd HH:mm:ss:fff}' and '{dateEnd:yyyy-MM-dd HH:mm:ss:fff}'
                                //        and line_code = '{data[i].line_code}'
                                //        and shift = {shift}";
                                //var productList = SQLHelper<Line_downtime_history>.SqlToList(query);
                                int row = 8;
                                foreach (var item in listLineStatus)
                                {
                                    newSheet.Cell(row, 1).Value = item.timestamp.ToString("yyyy/MM/dd HH:mm:ss");
                                    newSheet.Cell(row, 2).Value = item.product_count;
                                    row++;
                                }
                            }
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

        private void cb_Line_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cb_Shift_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dtpDateTime_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        #endregion
    }
}
