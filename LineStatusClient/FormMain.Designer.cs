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
            this.chkRunOnStartUp = new System.Windows.Forms.CheckBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlSettings = new DevExpress.XtraEditors.PanelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.dtpDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblDateEnd = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateStart = new DevExpress.XtraEditors.DateEdit();
            this.lblDateStart = new DevExpress.XtraEditors.LabelControl();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLinecode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductcount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnitemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            this.menuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.chkRunOnStartUp);
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1198, 30);
            this.pnlHeader.TabIndex = 0;
            // 
            // chkRunOnStartUp
            // 
            this.chkRunOnStartUp.AutoSize = true;
            this.chkRunOnStartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRunOnStartUp.Location = new System.Drawing.Point(4, 4);
            this.chkRunOnStartUp.Name = "chkRunOnStartUp";
            this.chkRunOnStartUp.Size = new System.Drawing.Size(158, 22);
            this.chkRunOnStartUp.TabIndex = 6;
            this.chkRunOnStartUp.Text = "Chạy cùng hệ thống";
            this.chkRunOnStartUp.UseVisualStyleBackColor = true;
            this.chkRunOnStartUp.CheckedChanged += new System.EventHandler(this.chkRunOnStartUp_CheckedChanged);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(1120, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 23);
            this.btnMinimize.TabIndex = 7;
            this.btnMinimize.Text = "Ẩn";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlSettings.Appearance.Options.UseBackColor = true;
            this.pnlSettings.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSettings.Controls.Add(this.btnExport);
            this.pnlSettings.Controls.Add(this.btnSearch);
            this.pnlSettings.Controls.Add(this.txtSearch);
            this.pnlSettings.Controls.Add(this.dtpDateEnd);
            this.pnlSettings.Controls.Add(this.lblDateEnd);
            this.pnlSettings.Controls.Add(this.dtpDateStart);
            this.pnlSettings.Controls.Add(this.lblDateStart);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(0, 30);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1198, 100);
            this.pnlSettings.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExport.ImageOptions.SvgImage")));
            this.btnExport.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnExport.Location = new System.Drawing.Point(1081, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(105, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Xuất excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnSearch.Location = new System.Drawing.Point(488, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(231, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Size = new System.Drawing.Size(241, 24);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.EditValue = null;
            this.dtpDateEnd.Location = new System.Drawing.Point(56, 46);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateEnd.Size = new System.Drawing.Size(136, 24);
            this.dtpDateEnd.TabIndex = 3;
            this.dtpDateEnd.EditValueChanged += new System.EventHandler(this.Datepicker_EditValueChanged);
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateEnd.Appearance.Options.UseFont = true;
            this.lblDateEnd.Location = new System.Drawing.Point(20, 48);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(26, 18);
            this.lblDateEnd.TabIndex = 2;
            this.lblDateEnd.Text = "Đến";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.EditValue = null;
            this.dtpDateStart.Location = new System.Drawing.Point(56, 16);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateStart.Properties.Appearance.Options.UseFont = true;
            this.dtpDateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateStart.Size = new System.Drawing.Size(136, 24);
            this.dtpDateStart.TabIndex = 1;
            this.dtpDateStart.EditValueChanged += new System.EventHandler(this.Datepicker_EditValueChanged);
            // 
            // lblDateStart
            // 
            this.lblDateStart.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateStart.Appearance.Options.UseFont = true;
            this.lblDateStart.Location = new System.Drawing.Point(20, 18);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(19, 18);
            this.lblDateStart.TabIndex = 0;
            this.lblDateStart.Text = "Từ";
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 130);
            this.grdMain.MainView = this.grvMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(1198, 488);
            this.grdMain.TabIndex = 1;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvMain.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.Row.Options.UseFont = true;
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLinecode,
            this.colTimestamp,
            this.colStatusText,
            this.colProductcount,
            this.colStatus});
            this.grvMain.GridControl = this.grdMain;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsView.ShowFooter = true;
            this.grvMain.OptionsView.ShowGroupPanel = false;
            this.grvMain.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvMain_RowCellStyle);
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
            this.colLinecode.VisibleIndex = 0;
            // 
            // colTimestamp
            // 
            this.colTimestamp.AppearanceCell.Options.UseTextOptions = true;
            this.colTimestamp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimestamp.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTimestamp.Caption = "Thời gian";
            this.colTimestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimestamp.FieldName = "timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.OptionsColumn.ReadOnly = true;
            this.colTimestamp.Visible = true;
            this.colTimestamp.VisibleIndex = 1;
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
            this.colStatusText.VisibleIndex = 2;
            // 
            // colProductcount
            // 
            this.colProductcount.AppearanceCell.Options.UseTextOptions = true;
            this.colProductcount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductcount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProductcount.Caption = "SL sản phẩm";
            this.colProductcount.FieldName = "product_count";
            this.colProductcount.Name = "colProductcount";
            this.colProductcount.OptionsColumn.ReadOnly = true;
            this.colProductcount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "product_count", "Tổng = {0:0.##}")});
            this.colProductcount.Visible = true;
            this.colProductcount.VisibleIndex = 3;
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
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "status_text";
            this.colStatus.Name = "colStatus";
            // 
            // FormMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 618);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlHeader);
            this.IconOptions.Image = global::LineStatusClient.Properties.Resources.line;
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trạng thái dây chuyền";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSettings)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.menuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.PanelControl pnlSettings;
        private DevExpress.XtraGrid.GridControl grdMain;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private System.Windows.Forms.CheckBox chkRunOnStartUp;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem mnitemShow;
        private System.Windows.Forms.ToolStripMenuItem mnitemExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colLinecode;
        private DevExpress.XtraGrid.Columns.GridColumn colTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn colProductcount;
        private DevExpress.XtraEditors.LabelControl lblDateStart;
        private DevExpress.XtraEditors.DateEdit dtpDateStart;
        private DevExpress.XtraEditors.DateEdit dtpDateEnd;
        private DevExpress.XtraEditors.LabelControl lblDateEnd;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}

