namespace LineStatusClient.Forms.Email
{
    partial class frmShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShift));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cb_IsActive = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdLineShift = new DevExpress.XtraGrid.GridControl();
            this.grvLineShift = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTTLineShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WorkShiftID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinShiftID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSelectListLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUnCheckLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLineShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLineShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddEmail,
            this.toolStripSeparator4,
            this.btnEditEmail,
            this.toolStripSeparator6,
            this.btnDeleteEmail,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(771, 64);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmail.Image")));
            this.btnAddEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(100, 56);
            this.btnAddEmail.Text = "Thêm Shift";
            this.btnAddEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddEmail.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 64);
            // 
            // btnEditEmail
            // 
            this.btnEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEditEmail.Image")));
            this.btnEditEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditEmail.Name = "btnEditEmail";
            this.btnEditEmail.Size = new System.Drawing.Size(88, 56);
            this.btnEditEmail.Text = "Sửa Shift";
            this.btnEditEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditEmail.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 64);
            // 
            // btnDeleteEmail
            // 
            this.btnDeleteEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteEmail.Image")));
            this.btnDeleteEmail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEmail.Name = "btnDeleteEmail";
            this.btnDeleteEmail.Size = new System.Drawing.Size(88, 56);
            this.btnDeleteEmail.Text = "Xóa Shift";
            this.btnDeleteEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteEmail.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 64);
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdData.Location = new System.Drawing.Point(0, 64);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cb_IsActive});
            this.grdData.Size = new System.Drawing.Size(771, 536);
            this.grdData.TabIndex = 3;
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
            this.colID,
            this.colNo,
            this.colShiftCode,
            this.colShiftName,
            this.colStartTime,
            this.colEndTime});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsFilter.AllowFilterEditor = false;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvData_FocusedRowChanged);
            this.grvData.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvData_CustomUnboundColumnData);
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
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
            // colShiftCode
            // 
            this.colShiftCode.Caption = "Mã ca";
            this.colShiftCode.FieldName = "ShiftCode";
            this.colShiftCode.Name = "colShiftCode";
            this.colShiftCode.Visible = true;
            this.colShiftCode.VisibleIndex = 1;
            this.colShiftCode.Width = 74;
            // 
            // colShiftName
            // 
            this.colShiftName.Caption = "Tên ca";
            this.colShiftName.FieldName = "ShiftName";
            this.colShiftName.Name = "colShiftName";
            this.colShiftName.Visible = true;
            this.colShiftName.VisibleIndex = 2;
            this.colShiftName.Width = 133;
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.colStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStartTime.Caption = "Bắt đầu ca";
            this.colStartTime.DisplayFormat.FormatString = "dd-MM-yyyy hh:mm:ss";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 3;
            this.colStartTime.Width = 163;
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.colEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEndTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colEndTime.Caption = "Kết thúc ca";
            this.colEndTime.DisplayFormat.FormatString = "dd-MM-yyyy hh:mm:ss";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 4;
            this.colEndTime.Width = 164;
            // 
            // cb_IsActive
            // 
            this.cb_IsActive.AutoHeight = false;
            this.cb_IsActive.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_IsActive.Items.AddRange(new object[] {
            "Không hoạt động",
            "Hoạt động"});
            this.cb_IsActive.Name = "cb_IsActive";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdData);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdLineShift);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(1393, 600);
            this.splitContainer1.SplitterDistance = 771;
            this.splitContainer1.TabIndex = 4;
            // 
            // grdLineShift
            // 
            this.grdLineShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLineShift.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdLineShift.Location = new System.Drawing.Point(0, 64);
            this.grdLineShift.MainView = this.grvLineShift;
            this.grdLineShift.Name = "grdLineShift";
            this.grdLineShift.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.grdLineShift.Size = new System.Drawing.Size(618, 536);
            this.grdLineShift.TabIndex = 4;
            this.grdLineShift.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLineShift});
            // 
            // grvLineShift
            // 
            this.grvLineShift.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.grvLineShift.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.grvLineShift.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLineShift.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLineShift.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLineShift.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvLineShift.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLineShift.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLineShift.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvLineShift.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvLineShift.Appearance.Row.Options.UseFont = true;
            this.grvLineShift.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTTLineShift,
            this.colLineCode,
            this.colLineName,
            this.WorkShiftID,
            this.colLinShiftID});
            this.grvLineShift.GridControl = this.grdLineShift;
            this.grvLineShift.Name = "grvLineShift";
            this.grvLineShift.OptionsBehavior.Editable = false;
            this.grvLineShift.OptionsFilter.AllowFilterEditor = false;
            this.grvLineShift.OptionsFind.AlwaysVisible = true;
            this.grvLineShift.OptionsFind.ShowFindButton = false;
            this.grvLineShift.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
            this.grvLineShift.OptionsSelection.MultiSelect = true;
            this.grvLineShift.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvLineShift.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.grvLineShift.OptionsView.ShowFooter = true;
            this.grvLineShift.OptionsView.ShowGroupPanel = false;
            this.grvLineShift.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvLineShift_SelectionChanged);
            this.grvLineShift.ColumnFilterChanged += new System.EventHandler(this.grvLineShift_ColumnFilterChanged);
            this.grvLineShift.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvLineShift_CustomUnboundColumnData);
            // 
            // colSTTLineShift
            // 
            this.colSTTLineShift.AppearanceCell.Options.UseTextOptions = true;
            this.colSTTLineShift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTTLineShift.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSTTLineShift.Caption = "STT";
            this.colSTTLineShift.DisplayFormat.FormatString = "n0";
            this.colSTTLineShift.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSTTLineShift.FieldName = "No";
            this.colSTTLineShift.MaxWidth = 44;
            this.colSTTLineShift.MinWidth = 44;
            this.colSTTLineShift.Name = "colSTTLineShift";
            this.colSTTLineShift.OptionsColumn.AllowEdit = false;
            this.colSTTLineShift.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSTTLineShift.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "No", "{0}")});
            this.colSTTLineShift.UnboundDataType = typeof(int);
            this.colSTTLineShift.Visible = true;
            this.colSTTLineShift.VisibleIndex = 1;
            this.colSTTLineShift.Width = 44;
            // 
            // colLineCode
            // 
            this.colLineCode.Caption = "Mã chuyền";
            this.colLineCode.FieldName = "LineCode";
            this.colLineCode.Name = "colLineCode";
            this.colLineCode.Visible = true;
            this.colLineCode.VisibleIndex = 2;
            this.colLineCode.Width = 191;
            // 
            // colLineName
            // 
            this.colLineName.Caption = "Tên chuyền";
            this.colLineName.FieldName = "Line_nm";
            this.colLineName.Name = "colLineName";
            this.colLineName.Visible = true;
            this.colLineName.VisibleIndex = 3;
            this.colLineName.Width = 318;
            // 
            // WorkShiftID
            // 
            this.WorkShiftID.FieldName = "WorkShiftID";
            this.WorkShiftID.Name = "WorkShiftID";
            // 
            // colLinShiftID
            // 
            this.colLinShiftID.Caption = "ID";
            this.colLinShiftID.FieldName = "ID";
            this.colLinShiftID.Name = "colLinShiftID";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Không hoạt động",
            "Hoạt động"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectListLine,
            this.toolStripSeparator1,
            this.btnUnCheckLine,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(618, 64);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSelectListLine
            // 
            this.btnSelectListLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSelectListLine.Image = global::LineStatusClient.Properties.Resources.select32;
            this.btnSelectListLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectListLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelectListLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectListLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectListLine.Name = "btnSelectListLine";
            this.btnSelectListLine.Size = new System.Drawing.Size(150, 56);
            this.btnSelectListLine.Text = "Chọn dây chuyền";
            this.btnSelectListLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelectListLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectListLine.Click += new System.EventHandler(this.btnSelectListLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 64);
            // 
            // btnUnCheckLine
            // 
            this.btnUnCheckLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUnCheckLine.Image = global::LineStatusClient.Properties.Resources.deleteview32;
            this.btnUnCheckLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUnCheckLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnCheckLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnCheckLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnCheckLine.Name = "btnUnCheckLine";
            this.btnUnCheckLine.Size = new System.Drawing.Size(174, 56);
            this.btnUnCheckLine.Text = "Bỏ chọn dây chuyền";
            this.btnUnCheckLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUnCheckLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUnCheckLine.Click += new System.EventHandler(this.btnUnCheckLine_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 64);
            // 
            // frmShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 600);
            this.Controls.Add(this.splitContainer1);
            this.IconOptions.Image = global::LineStatusClient.Properties.Resources.line;
            this.Name = "frmShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift";
            this.Load += new System.EventHandler(this.frmShift_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsActive)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLineShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLineShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnEditEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnDeleteEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cb_IsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdLineShift;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLineShift;
        private DevExpress.XtraGrid.Columns.GridColumn colSTTLineShift;
        private DevExpress.XtraGrid.Columns.GridColumn colLineCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSelectListLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUnCheckLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLineName;
        private DevExpress.XtraGrid.Columns.GridColumn WorkShiftID;
        private DevExpress.XtraGrid.Columns.GridColumn colLinShiftID;
    }
}