namespace RTIS_Vulcan_UI.Controls.Purchase_Orders.COA
{
    partial class ucCMSArchive
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCMSArchive));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCaptured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStockLink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserCaptured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateCaptured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVeiw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCMSId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(346, 44);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "CMS Document Archive";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.dgItems);
            this.pnlBack.Controls.Add(this.btnRefresh);
            this.pnlBack.Location = new System.Drawing.Point(4, 56);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1312, 732);
            this.pnlBack.TabIndex = 39;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1118, 677);
            this.btnRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(188, 49);
            this.btnRefresh.TabIndex = 92;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 5);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1301, 665);
            this.dgItems.TabIndex = 93;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcDesc,
            this.gcCaptured,
            this.gcStatus,
            this.gcStockLink,
            this.gcUserCaptured,
            this.gcDateCaptured,
            this.gcUserApproved,
            this.gcDateApproved,
            this.gcVeiw,
            this.gcCMSId,
            this.gcVersion});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Item Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.ReadOnly = true;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 1;
            this.gcCode.Width = 128;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Item Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 2;
            this.gcDesc.Width = 125;
            // 
            // gcCaptured
            // 
            this.gcCaptured.Caption = "CMS Spec Captured";
            this.gcCaptured.FieldName = "gcCaptured";
            this.gcCaptured.Name = "gcCaptured";
            this.gcCaptured.OptionsColumn.AllowEdit = false;
            this.gcCaptured.Visible = true;
            this.gcCaptured.VisibleIndex = 3;
            this.gcCaptured.Width = 125;
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Status";
            this.gcStatus.FieldName = "gcStatus";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.OptionsColumn.AllowEdit = false;
            this.gcStatus.Width = 125;
            // 
            // gcStockLink
            // 
            this.gcStockLink.Caption = "Stock Link";
            this.gcStockLink.FieldName = "gcStockLink";
            this.gcStockLink.Name = "gcStockLink";
            this.gcStockLink.Width = 125;
            // 
            // gcUserCaptured
            // 
            this.gcUserCaptured.Caption = "User Captured";
            this.gcUserCaptured.FieldName = "gcUserCaptured";
            this.gcUserCaptured.Name = "gcUserCaptured";
            this.gcUserCaptured.OptionsColumn.ReadOnly = true;
            this.gcUserCaptured.Visible = true;
            this.gcUserCaptured.VisibleIndex = 4;
            this.gcUserCaptured.Width = 125;
            // 
            // gcDateCaptured
            // 
            this.gcDateCaptured.Caption = "Date Captured";
            this.gcDateCaptured.FieldName = "gcDateCaptured";
            this.gcDateCaptured.Name = "gcDateCaptured";
            this.gcDateCaptured.OptionsColumn.ReadOnly = true;
            this.gcDateCaptured.Visible = true;
            this.gcDateCaptured.VisibleIndex = 5;
            this.gcDateCaptured.Width = 125;
            // 
            // gcUserApproved
            // 
            this.gcUserApproved.Caption = "User Approved";
            this.gcUserApproved.FieldName = "gcUserApproved";
            this.gcUserApproved.Name = "gcUserApproved";
            this.gcUserApproved.OptionsColumn.ReadOnly = true;
            this.gcUserApproved.Width = 125;
            // 
            // gcDateApproved
            // 
            this.gcDateApproved.Caption = "Date Approved";
            this.gcDateApproved.FieldName = "gcDateApproved";
            this.gcDateApproved.Name = "gcDateApproved";
            this.gcDateApproved.OptionsColumn.ReadOnly = true;
            this.gcDateApproved.Width = 128;
            // 
            // gcVeiw
            // 
            this.gcVeiw.Caption = "Veiw CMS Information";
            this.gcVeiw.Name = "gcVeiw";
            this.gcVeiw.Visible = true;
            this.gcVeiw.VisibleIndex = 0;
            this.gcVeiw.Width = 149;
            // 
            // gcCMSId
            // 
            this.gcCMSId.Caption = "CMD ID";
            this.gcCMSId.FieldName = "gcCMSId";
            this.gcCMSId.Name = "gcCMSId";
            // 
            // gcVersion
            // 
            this.gcVersion.Caption = "Document Version";
            this.gcVersion.FieldName = "gcVersion";
            this.gcVersion.Name = "gcVersion";
            this.gcVersion.OptionsColumn.ReadOnly = true;
            this.gcVersion.Visible = true;
            this.gcVersion.VisibleIndex = 6;
            // 
            // ucCMSArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucCMSArchive";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucCMSArchive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcStockLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gcVeiw;
        private DevExpress.XtraGrid.Columns.GridColumn gcCMSId;
        private DevExpress.XtraGrid.Columns.GridColumn gcVersion;
    }
}
