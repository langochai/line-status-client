namespace LineStatusClient.Forms.Email
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
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
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cb_IsActive = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsActive)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1115, 64);
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
            this.btnAddEmail.Size = new System.Drawing.Size(104, 56);
            this.btnAddEmail.Text = "Thêm email";
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
            this.btnEditEmail.Size = new System.Drawing.Size(92, 56);
            this.btnEditEmail.Text = "Sửa email";
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
            this.btnDeleteEmail.Size = new System.Drawing.Size(92, 56);
            this.btnDeleteEmail.Text = "Xóa email";
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
            this.grdData.Size = new System.Drawing.Size(1115, 537);
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
            this.colName,
            this.colEmail,
            this.colIsActive});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsFilter.AllowFilterEditor = false;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
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
            // colName
            // 
            this.colName.Caption = "Tên";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 412;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 2;
            this.colEmail.Width = 383;
            // 
            // colIsActive
            // 
            this.colIsActive.Caption = "Trạng thái";
            this.colIsActive.ColumnEdit = this.cb_IsActive;
            this.colIsActive.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 3;
            this.colIsActive.Width = 251;
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
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 601);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::LineStatusClient.Properties.Resources.line;
            this.Name = "frmEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email";
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cb_IsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
    }
}