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

namespace LineStatusClient.Forms.Email
{
    public partial class frmShiftDetail : XtraForm
    {
        public WorkShift shiftModel = new WorkShift();
        public frmShiftDetail()
        {
            InitializeComponent();
        }
        private void frmEmailDetail_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (shiftModel.ID > 0)
            {
                nmShiftCode.Text = SQLUtilities.ToString(shiftModel.ShiftCode);
                txtShiftName.Text = shiftModel.ShiftName;
                date_StartTime.EditValue = SQLUtilities.ToDateTimeOffset(shiftModel.StartTime);
                date_EndTime.EditValue = SQLUtilities.ToDateTimeOffset(shiftModel.EndTime);
            }
        }

        private bool SaveData()
        {
            if (!ValidateForm()) return false;
            shiftModel.ShiftCode = SQLUtilities.ToInt(nmShiftCode.Value);
            shiftModel.ShiftName = txtShiftName.Text.Trim();
            shiftModel.StartTime = SQLUtilities.DateTimeOffsetToTimeString(date_StartTime.EditValue);
            shiftModel.EndTime = SQLUtilities.DateTimeOffsetToTimeString(date_EndTime.EditValue);

            if (shiftModel.ID > 0)
            {
                SQLHelper<WorkShift>.UpdateModel(shiftModel);
            }
            else
            {
                SQLHelper<WorkShift>.Insert(shiftModel);
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                shiftModel = new WorkShift();
                nmShiftCode.Value = 0;
                txtShiftName.Text = "";
                date_StartTime.EditValue = DateTimeOffset.Now;
                date_EndTime.EditValue = DateTimeOffset.Now;
            }
        }

        private bool ValidateForm()
        {
            try
            {
                if (nmShiftCode.Value <= 0)
                {
                    MessageBox.Show("Xin hãy điền mã ca !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (txtShiftName.Text.Trim() == "")
                {
                    MessageBox.Show("Xin hãy điền tên ca !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                List<WorkShift> checkModel = SQLHelper<WorkShift>.SqlToList($"SELECT * FROM WorkShift where ShiftCode = {nmShiftCode.Text.Trim()} AND ID <> {shiftModel.ID};");
                if (checkModel != null && checkModel.Count > 0)
                {
                    MessageBox.Show("Mã ca này đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void frmEmailDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void date_StartTime_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
