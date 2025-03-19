using DevExpress.XtraEditors;
using LineStatusClient.Common;
using LineStatusClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineStatusClient.Forms
{
    public partial class frmEnterPassword : XtraForm
    {

        private bool isChangePass = false;
        public frmEnterPassword()
        {
            InitializeComponent();
        }

        string RePassword = "";
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (isChangePass)
                {
                    string newPass = SQLUtilities.ToString(txtPassword.Text.Trim());
                    if (RePassword == "")
                    {
                        RePassword = newPass;
                        lb_Title.Text = "NHẬP LẠI MẬT KHẨU MỚI";
                        txtPassword.Text = "";
                        return;
                    }
                    if (RePassword != newPass)
                    {
                        MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RePassword = "";
                        txtPassword.Text = "";
                        lb_Title.Text = "NHẬP MẬT KHẨU MỚI";
                        return;
                    }
                    SystemSettings model = SQLHelper<SystemSettings>.FindByID(Settings.ConfigID) ?? new SystemSettings();
                    model.Password = SQLUtilities.ToString(txtPassword.Text.Trim());
                    if (model.ID > 0)
                    {
                        if (!SQLHelper<SystemSettings>.UpdateModel(model).IsSuccess)
                        {
                            MessageBox.Show("Đã có lỗi sảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnChangePass_Click(null, null);
                            return;
                        }
                    }
                    MessageBox.Show("Hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Settings.Password = model.Password;
                    RePassword = "";
                    txtPassword.Text = "";
                    lb_Title.Text = "NHẬP MẬT KHẨU";
                    isChangePass = false;
                }
                else
                {
                    if (txtPassword.Text.Trim() == Settings.Password)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e); // Gọi sự kiện nút xác nhận khi nhấn Enter
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (!isChangePass)
            {
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (txtPassword.Text.Trim() == Settings.Password)
                {
                    isChangePass = true;
                    btnChangePass.Text = "Đóng";
                    lb_Title.Text = "NHẬP MẬT KHẨU MỚI";
                    txtPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                isChangePass = false;
                btnChangePass.Text = "Đổi mật khẩu";
                lb_Title.Text = "NHẬP MẬT KHẨU";
                RePassword = "";
            }
        }

        private void frmEnterPassword_Load(object sender, EventArgs e)
        {
            Settings.LoadConfig();
        }
    }
}
