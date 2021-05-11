namespace RTIS_Vulcan_UI.Controls.Purchase_Orders
{
    partial class ucCMSManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCMSManagement));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapture = new DevExpress.XtraEditors.SimpleButton();
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
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gcUserRejected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateRejected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejectReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.labelControl1.Size = new System.Drawing.Size(272, 44);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "CMS Management";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnCapture);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.dgItems);
            this.panelControl1.Location = new System.Drawing.Point(4, 56);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1312, 732);
            this.panelControl1.TabIndex = 37;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(726, 677);
            this.btnEdit.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 49);
            this.btnEdit.TabIndex = 93;
            this.btnEdit.Text = "Edit CMS Data";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapture.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCapture.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnCapture.Appearance.Options.UseBackColor = true;
            this.btnCapture.Appearance.Options.UseFont = true;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.Location = new System.Drawing.Point(922, 677);
            this.btnCapture.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCapture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(188, 49);
            this.btnCapture.TabIndex = 92;
            this.btnCapture.Text = "Capture CMS Data";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
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
            this.btnRefresh.TabIndex = 91;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(6, 6);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1300, 664);
            this.dgItems.TabIndex = 0;
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
            this.gcVersion,
            this.gcUserRejected,
            this.gcDateRejected,
            this.gcRejectReason});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvItems_RowStyle);
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
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 4;
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
            this.gcUserCaptured.VisibleIndex = 5;
            this.gcUserCaptured.Width = 125;
            // 
            // gcDateCaptured
            // 
            this.gcDateCaptured.Caption = "Date Captured";
            this.gcDateCaptured.FieldName = "gcDateCaptured";
            this.gcDateCaptured.Name = "gcDateCaptured";
            this.gcDateCaptured.OptionsColumn.ReadOnly = true;
            this.gcDateCaptured.Visible = true;
            this.gcDateCaptured.VisibleIndex = 6;
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
            this.gcVersion.VisibleIndex = 7;
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(0, 0);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1319, 791);
            this.ppnlWait.TabIndex = 38;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // gcUserRejected
            // 
            this.gcUserRejected.Caption = "User Rejected";
            this.gcUserRejected.FieldName = "gcUserRejected";
            this.gcUserRejected.Name = "gcUserRejected";
            // 
            // gcDateRejected
            // 
            this.gcDateRejected.Caption = "Date Rejected";
            this.gcDateRejected.FieldName = "gcDateRejected";
            this.gcDateRejected.Name = "gcDateRejected";
            // 
            // gcRejectReason
            // 
            this.gcRejectReason.Caption = "Rejection Reasons";
            this.gcRejectReason.FieldName = "gcRejectReason";
            this.gcRejectReason.Name = "gcRejectReason";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(530, 677);
            this.btnDelete.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 49);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete CMS Data";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucCMSManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucCMSManagement";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucCMSManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnCapture;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraGrid.Columns.GridColumn gcStockLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcVeiw;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateCaptured;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gcCMSId;
        private DevExpress.XtraGrid.Columns.GridColumn gcVersion;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserRejected;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateRejected;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejectReason;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
