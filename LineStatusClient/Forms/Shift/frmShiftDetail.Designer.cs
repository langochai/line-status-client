namespace LineStatusClient.Forms.Email
{
    partial class frmShiftDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShiftName = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date_StartTime = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.date_EndTime = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.nmShiftCode = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftName.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmShiftCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(28, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã ca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(28, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên ca";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(112, 131);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtShiftName.Properties.Appearance.Options.UseFont = true;
            this.txtShiftName.Size = new System.Drawing.Size(242, 26);
            this.txtShiftName.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator4,
            this.btnSaveNew,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(397, 63);
            this.toolStrip1.TabIndex = 236;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 55);
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 63);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(147, 55);
            this.btnSaveNew.Text = "Lưu && Thêm mới";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 63);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(28, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(28, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kết thúc";
            // 
            // date_StartTime
            // 
            this.date_StartTime.EditValue = new System.DateTime(2025, 3, 13, 14, 13, 9, 958);
            this.date_StartTime.Location = new System.Drawing.Point(112, 176);
            this.date_StartTime.Name = "date_StartTime";
            this.date_StartTime.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.date_StartTime.Properties.Appearance.Options.UseFont = true;
            this.date_StartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_StartTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.date_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.date_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_StartTime.Properties.MaskSettings.Set("mask", "HH:mm:ss");
            this.date_StartTime.Properties.UseMaskAsDisplayFormat = true;
            this.date_StartTime.Properties.XlsxFormatString = "HH:mm:ss";
            this.date_StartTime.Size = new System.Drawing.Size(242, 26);
            this.date_StartTime.TabIndex = 237;
            this.date_StartTime.EditValueChanged += new System.EventHandler(this.date_StartTime_EditValueChanged);
            // 
            // date_EndTime
            // 
            this.date_EndTime.EditValue = new System.DateTime(2025, 3, 13, 14, 13, 9, 958);
            this.date_EndTime.Location = new System.Drawing.Point(112, 220);
            this.date_EndTime.Name = "date_EndTime";
            this.date_EndTime.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.date_EndTime.Properties.Appearance.Options.UseFont = true;
            this.date_EndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_EndTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.date_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.date_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.date_EndTime.Properties.MaskSettings.Set("mask", "HH:mm:ss");
            this.date_EndTime.Properties.UseMaskAsDisplayFormat = true;
            this.date_EndTime.Properties.XlsxFormatString = "HH:mm:ss";
            this.date_EndTime.Size = new System.Drawing.Size(242, 26);
            this.date_EndTime.TabIndex = 237;
            // 
            // nmShiftCode
            // 
            this.nmShiftCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nmShiftCode.Location = new System.Drawing.Point(112, 89);
            this.nmShiftCode.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nmShiftCode.Name = "nmShiftCode";
            this.nmShiftCode.Size = new System.Drawing.Size(242, 26);
            this.nmShiftCode.TabIndex = 238;
            // 
            // frmShiftDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 285);
            this.Controls.Add(this.nmShiftCode);
            this.Controls.Add(this.date_EndTime);
            this.Controls.Add(this.date_StartTime);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IconOptions.Image = global::LineStatusClient.Properties.Resources.line;
            this.Name = "frmShiftDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết ca";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmailDetail_FormClosed);
            this.Load += new System.EventHandler(this.frmEmailDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtShiftName.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_StartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_EndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmShiftCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtShiftName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSaveNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateTimeOffsetEdit date_StartTime;
        private DevExpress.XtraEditors.DateTimeOffsetEdit date_EndTime;
        private System.Windows.Forms.NumericUpDown nmShiftCode;
    }
}