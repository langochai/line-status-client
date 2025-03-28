﻿using DevExpress.XtraEditors;
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
    public partial class frmEmail : XtraForm
    {

        public frmEmail()
        {
            InitializeComponent();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            Settings.LoadConfig();
            loadCbIsActive();
            loadEmail();
            nmTimeEmail.Value = Settings.TimeSendEmail;
        }


        private void loadEmail()
        {
            List<LineEmailConfig> ls = SQLHelper<LineEmailConfig>.FindAll();
            grdData.DataSource = ls;
        }

        private void loadCbIsActive()
        {
            var listActiveStatus = new List<object>
            {
                new { IsActive = true, ActiveName = "Hoạt động" },
                new { IsActive = false, ActiveName = "Không hoạt động" }
            };
            cb_IsAtive.DataSource = listActiveStatus;
            cb_IsAtive.DisplayMember = "ActiveName";
            cb_IsAtive.ValueMember = "IsActive";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmailDetail frm = new frmEmailDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadEmail();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;
            LineEmailConfig model = SQLHelper<LineEmailConfig>.FindByID(id);
            frmEmailDetail frm = new frmEmailDetail();
            frm.emailModel = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadEmail();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = SQLUtilities.ToInt(grvData.GetFocusedRowCellValue(colID));
            string email = SQLUtilities.ToString(grvData.GetFocusedRowCellValue(colEmail));
            if (id <= 0) return;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa Email: '{email}' không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SQLHelper<LineEmailConfig>.DeleteModelByID(id);
                grvData.DeleteSelectedRows();
                loadEmail();
            }
        }

        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = grvData.GetRowHandle(e.ListSourceRowIndex) + 1;
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnSaveTimeSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSettings model = SQLHelper<SystemSettings>.FindByID(Settings.ConfigID) ?? new SystemSettings();
                model.ConfigValue = SQLUtilities.ToInt(nmTimeEmail.Value);
                if (model.ID > 0)
                {
                    if (!SQLHelper<SystemSettings>.UpdateModel(model).IsSuccess)
                    {
                        MessageBox.Show("Đã có lỗi sảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    };
                    Settings.TimeSendEmail = model.ConfigValue;
                    MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
