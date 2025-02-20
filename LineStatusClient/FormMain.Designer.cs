namespace LineStatusClient
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.label5 = new System.Windows.Forms.Label();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinecode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRunningTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDowntime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductcount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnitemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSetting = new DevExpress.XtraEditors.SimpleButton();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRunAtStartup = new DevExpress.XtraEditors.SimpleButton();
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            this.menuNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1198, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1198, 60);
            this.label5.TabIndex = 0;
            this.label5.Text = "HỆ THÔNG QUẢN LÝ DÂY CHUYỀN (SEB)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 60);
            this.grdMain.MainView = this.grvMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(1198, 513);
            this.grdMain.TabIndex = 1;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.grvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvMain.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.Row.Options.UseFont = true;
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colLinecode,
            this.colTotalRunningTime,
            this.colTotalDowntime,
            this.colStatusText,
            this.colProductcount,
            this.colStatus,
            this.colShift});
            this.grvMain.GridControl = this.grdMain;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsBehavior.Editable = false;
            this.grvMain.OptionsFilter.AllowFilterEditor = false;
            this.grvMain.OptionsView.ShowFooter = true;
            this.grvMain.OptionsView.ShowGroupPanel = false;
            this.grvMain.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvMain_RowCellStyle);
            this.grvMain.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvData_CustomUnboundColumnData);
            // 
            // colNo
            // 
            this.colNo.AppearanceCell.Options.UseTextOptions = true;
            this.colNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNo.Caption = "STT";
            this.colNo.DisplayFormat.FormatString = "n0";
            this.colNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "No", "{0}")});
            this.colNo.UnboundDataType = typeof(int);
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 44;
            // 
            // colLinecode
            // 
            this.colLinecode.AppearanceCell.Options.UseTextOptions = true;
            this.colLinecode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLinecode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLinecode.Caption = "Dây chuyền";
            this.colLinecode.FieldName = "line_nm";
            this.colLinecode.Name = "colLinecode";
            this.colLinecode.OptionsColumn.ReadOnly = true;
            this.colLinecode.Visible = true;
            this.colLinecode.VisibleIndex = 1;
            this.colLinecode.Width = 264;
            // 
            // colTotalRunningTime
            // 
            this.colTotalRunningTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalRunningTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalRunningTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalRunningTime.Caption = "Thời gian chạy";
            this.colTotalRunningTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTotalRunningTime.FieldName = "TotalRunningTime";
            this.colTotalRunningTime.Name = "colTotalRunningTime";
            this.colTotalRunningTime.OptionsColumn.ReadOnly = true;
            this.colTotalRunningTime.Visible = true;
            this.colTotalRunningTime.VisibleIndex = 2;
            this.colTotalRunningTime.Width = 175;
            // 
            // colTotalDowntime
            // 
            this.colTotalDowntime.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalDowntime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalDowntime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalDowntime.Caption = "Thời gian dừng";
            this.colTotalDowntime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTotalDowntime.FieldName = "TotalDowntime";
            this.colTotalDowntime.Name = "colTotalDowntime";
            this.colTotalDowntime.OptionsColumn.AllowEdit = false;
            this.colTotalDowntime.Visible = true;
            this.colTotalDowntime.VisibleIndex = 3;
            this.colTotalDowntime.Width = 175;
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.Caption = "Trạng thái";
            this.colStatusText.FieldName = "status_text";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.ReadOnly = true;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 4;
            this.colStatusText.Width = 198;
            // 
            // colProductcount
            // 
            this.colProductcount.AppearanceCell.Options.UseTextOptions = true;
            this.colProductcount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductcount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProductcount.Caption = "Số lượng sản phẩm";
            this.colProductcount.FieldName = "product_count";
            this.colProductcount.Name = "colProductcount";
            this.colProductcount.OptionsColumn.ReadOnly = true;
            this.colProductcount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "product_count", "Tổng = {0:0.##}")});
            this.colProductcount.Visible = true;
            this.colProductcount.VisibleIndex = 5;
            this.colProductcount.Width = 207;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "status_text";
            this.colStatus.Name = "colStatus";
            // 
            // colShift
            // 
            this.colShift.AppearanceCell.Options.UseTextOptions = true;
            this.colShift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShift.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShift.Caption = "Ca làm";
            this.colShift.FieldName = "shift";
            this.colShift.Name = "colShift";
            this.colShift.OptionsColumn.AllowEdit = false;
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 6;
            this.colShift.Width = 110;
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnitemShow,
            this.mnitemExit});
            this.menuNotify.Name = "notifyIconMenu";
            this.menuNotify.Size = new System.Drawing.Size(117, 48);
            // 
            // mnitemShow
            // 
            this.mnitemShow.Name = "mnitemShow";
            this.mnitemShow.Size = new System.Drawing.Size(116, 22);
            this.mnitemShow.Text = "Hiển thị";
            this.mnitemShow.Click += new System.EventHandler(this.mnitemShow_Click);
            // 
            // mnitemExit
            // 
            this.mnitemExit.Name = "mnitemExit";
            this.mnitemExit.Size = new System.Drawing.Size(116, 22);
            this.mnitemExit.Text = "Thoát";
            this.mnitemExit.Click += new System.EventHandler(this.mnitemExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Trạng thái dây chuyền";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Appearance.Options.UseBackColor = true;
            this.pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Controls.Add(this.textBox4);
            this.pnlFooter.Controls.Add(this.label3);
            this.pnlFooter.Controls.Add(this.textBox3);
            this.pnlFooter.Controls.Add(this.label2);
            this.pnlFooter.Controls.Add(this.textBox2);
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Controls.Add(this.textBox1);
            this.pnlFooter.Controls.Add(this.btnSetting);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 573);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1198, 45);
            this.pnlFooter.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1131, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Dừng";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox4.BackColor = System.Drawing.Color.OrangeRed;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(1092, 8);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(35, 30);
            this.textBox4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(985, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nghỉ trưa";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox3.BackColor = System.Drawing.Color.Yellow;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(946, 8);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(35, 30);
            this.textBox3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(871, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chạy";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox2.BackColor = System.Drawing.Color.SpringGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(832, 8);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(35, 30);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(663, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Không hoạt động";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(624, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(35, 30);
            this.textBox1.TabIndex = 1;
            // 
            // btnSetting
            // 
            this.btnSetting.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Appearance.Options.UseForeColor = true;
            this.btnSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.ImageOptions.Image")));
            this.btnSetting.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetting.Location = new System.Drawing.Point(12, 4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(38, 36);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.flyoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flyoutPanel1.Controls.Add(this.btnExportExcel);
            this.flyoutPanel1.Controls.Add(this.btnRunAtStartup);
            this.flyoutPanel1.Controls.Add(this.btnHide);
            this.flyoutPanel1.Location = new System.Drawing.Point(73, 409);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 100;
            this.flyoutPanel1.OwnerControl = this.btnSetting;
            this.flyoutPanel1.Size = new System.Drawing.Size(221, 145);
            this.flyoutPanel1.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.Location = new System.Drawing.Point(4, 98);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(211, 41);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Xuất excel";
            // 
            // btnRunAtStartup
            // 
            this.btnRunAtStartup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAtStartup.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnRunAtStartup.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAtStartup.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRunAtStartup.Appearance.Options.UseBackColor = true;
            this.btnRunAtStartup.Appearance.Options.UseFont = true;
            this.btnRunAtStartup.Appearance.Options.UseForeColor = true;
            this.btnRunAtStartup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRunAtStartup.ImageOptions.Image")));
            this.btnRunAtStartup.Location = new System.Drawing.Point(4, 51);
            this.btnRunAtStartup.Name = "btnRunAtStartup";
            this.btnRunAtStartup.Size = new System.Drawing.Size(211, 41);
            this.btnRunAtStartup.TabIndex = 3;
            this.btnRunAtStartup.Text = "Chạy cùng hệ thống";
            this.btnRunAtStartup.Click += new System.EventHandler(this.btnRunAtStartup_Click);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Appearance.Options.UseFont = true;
            this.btnHide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.ImageOptions.Image")));
            this.btnHide.Location = new System.Drawing.Point(4, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(211, 41);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "Ẩn";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // FormMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 618);
            this.Controls.Add(this.flyoutPanel1);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.IconOptions.Image = global::LineStatusClient.Properties.Resources.line;
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trạng thái dây chuyền";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.menuNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem mnitemShow;
        private System.Windows.Forms.ToolStripMenuItem mnitemExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colLinecode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRunningTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn colProductcount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.SimpleButton btnRunAtStartup;
        private DevExpress.XtraEditors.SimpleButton btnHide;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDowntime;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
    }
}

