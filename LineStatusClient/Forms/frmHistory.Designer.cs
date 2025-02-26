namespace LineStatusClient.Froms
{
    partial class frmHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            this.panl_Header = new DevExpress.XtraEditors.PanelControl();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.cb_Shift = new System.Windows.Forms.ComboBox();
            this.cb_Line = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCb_Line = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTime = new DevExpress.XtraEditors.DateEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colline_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colline_nm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus_text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproduct_count = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panl_Header)).BeginInit();
            this.panl_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Line.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCb_Line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panl_Header
            // 
            this.panl_Header.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panl_Header.Appearance.Options.UseBackColor = true;
            this.panl_Header.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panl_Header.Controls.Add(this.btnExportExcel);
            this.panl_Header.Controls.Add(this.cb_Shift);
            this.panl_Header.Controls.Add(this.cb_Line);
            this.panl_Header.Controls.Add(this.label3);
            this.panl_Header.Controls.Add(this.label2);
            this.panl_Header.Controls.Add(this.label1);
            this.panl_Header.Controls.Add(this.dtpDateTime);
            this.panl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panl_Header.Location = new System.Drawing.Point(0, 0);
            this.panl_Header.Name = "panl_Header";
            this.panl_Header.Size = new System.Drawing.Size(1013, 52);
            this.panl_Header.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.Location = new System.Drawing.Point(869, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(136, 40);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // cb_Shift
            // 
            this.cb_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Shift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_Shift.FormattingEnabled = true;
            this.cb_Shift.Items.AddRange(new object[] {
            "Ngày",
            "Đêm"});
            this.cb_Shift.Location = new System.Drawing.Point(568, 12);
            this.cb_Shift.Name = "cb_Shift";
            this.cb_Shift.Size = new System.Drawing.Size(121, 28);
            this.cb_Shift.TabIndex = 3;
            this.cb_Shift.SelectedIndexChanged += new System.EventHandler(this.cb_Shift_SelectedIndexChanged);
            // 
            // cb_Line
            // 
            this.cb_Line.Location = new System.Drawing.Point(276, 13);
            this.cb_Line.Name = "cb_Line";
            this.cb_Line.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cb_Line.Properties.Appearance.Options.UseFont = true;
            this.cb_Line.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Line.Properties.NullText = "";
            this.cb_Line.Properties.PopupView = this.grvCb_Line;
            this.cb_Line.Size = new System.Drawing.Size(213, 26);
            this.cb_Line.TabIndex = 2;
            this.cb_Line.EditValueChanged += new System.EventHandler(this.cb_Line_EditValueChanged);
            // 
            // grvCb_Line
            // 
            this.grvCb_Line.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.grvCb_Line.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvCb_Line.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCb_Line.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvCb_Line.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCb_Line.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCb_Line.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCb_Line.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvCb_Line.Appearance.Row.Options.UseFont = true;
            this.grvCb_Line.Appearance.Row.Options.UseTextOptions = true;
            this.grvCb_Line.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCb_Line.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineCode,
            this.colLineName});
            this.grvCb_Line.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCb_Line.Name = "grvCb_Line";
            this.grvCb_Line.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCb_Line.OptionsView.ShowGroupPanel = false;
            // 
            // colLineCode
            // 
            this.colLineCode.Caption = "Mã dây chuyền";
            this.colLineCode.FieldName = "Line_c";
            this.colLineCode.Name = "colLineCode";
            this.colLineCode.Visible = true;
            this.colLineCode.VisibleIndex = 0;
            this.colLineCode.Width = 566;
            // 
            // colLineName
            // 
            this.colLineName.Caption = "Tên dây chuyền";
            this.colLineName.FieldName = "Line_nm";
            this.colLineName.Name = "colLineName";
            this.colLineName.Visible = true;
            this.colLineName.VisibleIndex = 1;
            this.colLineName.Width = 1049;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(508, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ca làm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(182, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dây chuyền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày";
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.EditValue = new System.DateTime(2025, 2, 21, 9, 40, 40, 20);
            this.dtpDateTime.Location = new System.Drawing.Point(59, 13);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Properties.AllowFocused = false;
            this.dtpDateTime.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDateTime.Properties.Appearance.Options.UseFont = true;
            this.dtpDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateTime.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTime.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTime.Properties.CalendarTimeProperties.UseMaskAsDisplayFormat = true;
            this.dtpDateTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateTime.Properties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm:ss");
            this.dtpDateTime.Properties.MaxValue = new System.DateTime(9999, 12, 31, 23, 59, 59, 0);
            this.dtpDateTime.Properties.UseMaskAsDisplayFormat = true;
            this.dtpDateTime.Size = new System.Drawing.Size(104, 26);
            this.dtpDateTime.TabIndex = 0;
            this.dtpDateTime.EditValueChanged += new System.EventHandler(this.dtpDateTime_EditValueChanged);
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 52);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1013, 459);
            this.grdData.TabIndex = 2;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.grvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.grvData.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvData.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvData.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvData.Appearance.Row.Options.UseFont = true;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colShift,
            this.colline_code,
            this.colline_nm,
            this.coltimestamp,
            this.colstatus_text,
            this.colproduct_count});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsFilter.AllowFilterEditor = false;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvData_CustomUnboundColumnData);
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
            this.colNo.MaxWidth = 44;
            this.colNo.MinWidth = 44;
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
            // colShift
            // 
            this.colShift.AppearanceCell.Options.UseTextOptions = true;
            this.colShift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShift.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colShift.Caption = "Ca làm";
            this.colShift.FieldName = "shift_text";
            this.colShift.Name = "colShift";
            this.colShift.OptionsColumn.AllowEdit = false;
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 5;
            this.colShift.Width = 145;
            // 
            // colline_code
            // 
            this.colline_code.Caption = "line_code";
            this.colline_code.FieldName = "line_code";
            this.colline_code.Name = "colline_code";
            // 
            // colline_nm
            // 
            this.colline_nm.Caption = "Tên dây chuyền";
            this.colline_nm.FieldName = "line_nm";
            this.colline_nm.Name = "colline_nm";
            this.colline_nm.Visible = true;
            this.colline_nm.VisibleIndex = 1;
            this.colline_nm.Width = 385;
            // 
            // coltimestamp
            // 
            this.coltimestamp.AppearanceCell.Options.UseTextOptions = true;
            this.coltimestamp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltimestamp.Caption = "Thời gian";
            this.coltimestamp.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            this.coltimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coltimestamp.FieldName = "timestamp";
            this.coltimestamp.Name = "coltimestamp";
            this.coltimestamp.Visible = true;
            this.coltimestamp.VisibleIndex = 2;
            this.coltimestamp.Width = 221;
            // 
            // colstatus_text
            // 
            this.colstatus_text.AppearanceCell.Options.UseTextOptions = true;
            this.colstatus_text.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colstatus_text.Caption = "Trạng thái";
            this.colstatus_text.FieldName = "status_text";
            this.colstatus_text.Name = "colstatus_text";
            this.colstatus_text.Visible = true;
            this.colstatus_text.VisibleIndex = 3;
            this.colstatus_text.Width = 135;
            // 
            // colproduct_count
            // 
            this.colproduct_count.AppearanceCell.Options.UseTextOptions = true;
            this.colproduct_count.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colproduct_count.Caption = "Số lượng sản phẩm";
            this.colproduct_count.FieldName = "product_count";
            this.colproduct_count.Name = "colproduct_count";
            this.colproduct_count.Visible = true;
            this.colproduct_count.VisibleIndex = 4;
            this.colproduct_count.Width = 178;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 511);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.panl_Header);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LỊCH SỬ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panl_Header)).EndInit();
            this.panl_Header.ResumeLayout(false);
            this.panl_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Line.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCb_Line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panl_Header;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpDateTime;
        private System.Windows.Forms.ComboBox cb_Shift;
        private DevExpress.XtraEditors.SearchLookUpEdit cb_Line;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCb_Line;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
        private DevExpress.XtraGrid.Columns.GridColumn colLineCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLineName;
        private DevExpress.XtraGrid.Columns.GridColumn colline_code;
        private DevExpress.XtraGrid.Columns.GridColumn colline_nm;
        private DevExpress.XtraGrid.Columns.GridColumn coltimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus_text;
        private DevExpress.XtraGrid.Columns.GridColumn colproduct_count;
    }
}