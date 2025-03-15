using DevExpress.Utils.Text;
using DevExpress.XtraEditors;
using LineStatusClient.Common;
using LineStatusClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineStatusClient.Forms.Shift
{
    public partial class frmLineShiftDetail : XtraForm
    {
        public WorkShift workShiftModel = new WorkShift();
        public frmLineShiftDetail()
        {
            InitializeComponent();
        }

        private void frmLineShiftDetail_Load(object sender, EventArgs e)
        {
            loadLine_mst();
        }

        private void loadLine_mst()
        {
            try
            {
                if (workShiftModel.ID > 0)
                {
                    List<Line_mst> ls = SQLHelper<Line_mst>.SqlToList($"SELECT lm.* FROM [Line_mst] lm " +
                        $"LEFT JOIN [LineShift] ls ON lm.[Line_c] = ls.[LineCode] " +
                        $"WHERE ls.[LineCode] IS NULL OR ls.[WorkShiftID] <> {workShiftModel.ID}" +
                        $"order by lm.sort asc");
                    grdData.DataSource = ls;
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> selectedLines = new List<string>();
                int[] selectedRowHandles = grvData.GetSelectedRows();
                foreach (int rowHandle in selectedRowHandles)
                {
                    if (rowHandle >= 0)
                    {
                        string lineCode = grvData.GetRowCellValue(rowHandle, "Line_c").ToString();
                        selectedLines.Add(lineCode);
                    }
                }

                if (selectedLines.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int countLine = 0;
                foreach (string lineCode in selectedLines)
                {
                    LineShift model = new LineShift();
                    var checkLineShift = SQLHelper<LineShift>.FindByExpression(new Expression("LineCode", lineCode)
                                                        .And(new Expression("WorkShiftID", workShiftModel.ID))).ToList();
                    if (checkLineShift.Count == 0)
                    {
                        model.LineCode = lineCode;
                        model.WorkShiftID = workShiftModel.ID;
                        SQLHelper<LineShift>.Insert(model, "");
                        countLine++;
                    }
                }

                loadLine_mst();
                MessageBox.Show($"Đã thêm {countLine} dây chuyên ca {workShiftModel.ShiftName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private void frmLineShiftDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
