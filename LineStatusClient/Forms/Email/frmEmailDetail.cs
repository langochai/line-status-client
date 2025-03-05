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
    public partial class frmEmailDetail : XtraForm
    {
        public LineEmailConfig emailModel = new LineEmailConfig();
        public frmEmailDetail()
        {
            InitializeComponent();
        }
        private void frmEmailDetail_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (emailModel.ID > 0)
            {
                txtName.Text = SQLUtilities.ToString(emailModel.Name);
                txtEmail.Text = SQLUtilities.ToString(emailModel.Email);
                ck_IsAtive.Checked = SQLUtilities.ToBoolean(emailModel.IsActive);
            }
        }

        private bool SaveData()
        {
            if (!ValidateForm()) return false;
            emailModel.Name = txtName.Text.Trim();
            emailModel.Email = txtEmail.Text.Trim();
            emailModel.IsActive = SQLUtilities.ToBoolean(ck_IsAtive.Checked);

            if (emailModel.ID > 0)
            {
                SQLHelper<LineEmailConfig>.UpdateModel(emailModel);
            }
            else
            {
                SQLHelper<LineEmailConfig>.Insert(emailModel);
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
                emailModel = new LineEmailConfig();
                txtName.Text = "";
                txtEmail.Text = "";
                ck_IsAtive.Checked = false;
            }
        }

        private bool ValidateForm()
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Xin hãy điền Tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show("Xin hãy điền Email !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                List<LineEmailConfig> checkModel = SQLHelper<LineEmailConfig>.SqlToList($"SELECT * FROM LineEmailConfig WHERE Email = '{txtEmail.Text.Trim()}' AND ID <> {emailModel.ID};");
                if (checkModel != null && checkModel.Count > 0)
                {
                    MessageBox.Show("Email này đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
    }
}
