using DevExpress.XtraEditors;
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

        private string passwordFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Password.txt");
        public frmEnterPassword()
        {
            InitializeComponent();
        }

        private void EnsurePasswordFileExists()
        {
            if (!File.Exists(passwordFilePath))
            {
                File.WriteAllText(passwordFilePath, "1"); // Tạo file với pass mặc định là "1"
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            EnsurePasswordFileExists();
            string storedPassword = File.ReadAllText(passwordFilePath).Trim();

            if (txtPassword.Text.Trim() == storedPassword)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm_Click(sender, e); // Gọi sự kiện nút xác nhận khi nhấn Enter
            }
        }
    }
}
