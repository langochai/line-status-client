using DevExpress.XtraEditors;
using LineStatusClient.Common;
using LineStatusClient.Forms.Shift;
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

namespace LineStatusClient.Forms.Email
{
    public partial class frmShift : XtraForm
    {

        private bool IsShowEnterPass = false;
        public frmShift()
        {
            InitializeComponent();
        }

        private void frmShift_Load(object sender, EventArgs e)
        {
            loadShift();
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadLineShift();
        }

        #region CURD WORK SHIFT

        private void loadShift()
        {
            List<WorkShift> ls = SQLHelper<WorkShift>.FindAll();
            grdData.DataSource = ls;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmShiftDetail frm = new frmShiftDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadShift();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;
            WorkShift model = SQLHelper<WorkShift>.FindByID(id);
            frmShiftDetail frm = new frmShiftDetail();
            frm.shiftModel = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadShift();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
            string name = SQLUtilities.ToString(grvData.GetFocusedRowCellValue(colShiftName));
            if (id <= 0) return;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa ca: '{name}' không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                WorkShift shiftModel = SQLHelper<WorkShift>.FindByID(id);
                if (shiftModel.ID > 0)
                {
                    SQLHelper<WorkShift>.DeleteModelByID(shiftModel.ID);
                    SQLHelper<LineShift>.DeleteByAttribute("WorkShiftID", shiftModel.ID);
                    grvData.DeleteSelectedRows();
                    loadShift();
                }
            }
        }
        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        #endregion

        #region CURD LINE SHIFT
        private void btnSelectListLine_Click(object sender, EventArgs e)
        {
            frmLineShiftDetail frm = new frmLineShiftDetail();
            int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;
            WorkShift model = SQLHelper<WorkShift>.FindByID(id);
            frm.workShiftModel = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadLineShift();
            }
        }

        private void loadLineShift()
        {
            try
            {
                int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id <= 0) return;
                List<LineShiftDTO> lsLine = SQLHelper<LineShiftDTO>.SqlToList($"select ls.*, lm.Line_nm from [LineShift] ls " +
                    $"inner join Line_mst lm on lm.Line_c = ls.LineCode " +
                    $"where ls.WorkShiftID = {id} " +
                    $"order by lm.sort asc");
                grdLineShift.DataSource = lsLine;
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        private void btnUnCheckLine_Click(object sender, EventArgs e)
        {
            try
            {
               
                List<int> list_unCheckID = new List<int>();
                int[] selectedRowHandles = grvLineShift.GetSelectedRows();
                foreach (int rowHandle in selectedRowHandles)
                {
                    if (rowHandle >= 0)
                    {
                        int id = SQLUtilities.ToInt(grvLineShift.GetRowCellValue(rowHandle, "ID"));
                        list_unCheckID.Add(id);
                    }
                }

                if (list_unCheckID.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dây chuyền để bỏ chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show($"Bạn có muốn bỏ chọn {list_unCheckID.Count} dây chuyền hay không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }

                foreach (int lineCode in list_unCheckID)
                {
                    SQLHelper<LineShift>.DeleteModelByID(lineCode);
                }

                loadLineShift();
                MessageBox.Show($"Đã bỏ {list_unCheckID.Count} dây chuyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorLogger.Write(ex);
            }
        }

        #endregion

        #region OTHERS

        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = grvData.GetRowHandle(e.ListSourceRowIndex) + 1;
            }
        }

        private void grvLineShift_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = grvLineShift.GetRowHandle(e.ListSourceRowIndex) + 1;
            }
        }


        #endregion

    }
}
