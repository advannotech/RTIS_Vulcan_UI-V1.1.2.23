namespace RTIS_Vulcan_UI.Controls.Transfer_Management
{
    partial class ucTransferReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransferReports));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgTransfers = new DevExpress.XtraGrid.GridControl();
            this.gvTransfers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateTrans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(4, 4);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(471, 44);
            this.labelControl13.TabIndex = 34;
            this.labelControl13.Text = "FG Warehouse Transfer Reports";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.dgTransfers);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Location = new System.Drawing.Point(4, 56);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1312, 732);
            this.panelControl1.TabIndex = 35;
            // 
            // dgTransfers
            // 
            this.dgTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransfers.Location = new System.Drawing.Point(5, 102);
            this.dgTransfers.MainView = this.gvTransfers;
            this.dgTransfers.Name = "dgTransfers";
            this.dgTransfers.Size = new System.Drawing.Size(1302, 625);
            this.dgTransfers.TabIndex = 97;
            this.dgTransfers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTransfers});
            // 
            // gvTransfers
            // 
            this.gvTransfers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcCode,
            this.gcLot,
            this.gcFrom,
            this.gcTo,
            this.gcQty,
            this.gcDateReq,
            this.gcUserReq,
            this.gcDateTrans,
            this.gcUser,
            this.gcProcess,
            this.gcStatus});
            this.gvTransfers.GridControl = this.dgTransfers;
            this.gvTransfers.Name = "gvTransfers";
            this.gvTransfers.OptionsFind.AlwaysVisible = true;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.ReadOnly = true;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.ReadOnly = true;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 1;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.ReadOnly = true;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 2;
            // 
            // gcFrom
            // 
            this.gcFrom.Caption = "Warehouse From";
            this.gcFrom.FieldName = "gcFrom";
            this.gcFrom.Name = "gcFrom";
            this.gcFrom.OptionsColumn.ReadOnly = true;
            this.gcFrom.Visible = true;
            this.gcFrom.VisibleIndex = 3;
            // 
            // gcTo
            // 
            this.gcTo.Caption = "Warehouse To";
            this.gcTo.FieldName = "gcTo";
            this.gcTo.Name = "gcTo";
            this.gcTo.OptionsColumn.ReadOnly = true;
            this.gcTo.Visible = true;
            this.gcTo.VisibleIndex = 4;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty Transferred";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.ReadOnly = true;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 5;
            // 
            // gcDateReq
            // 
            this.gcDateReq.Caption = "Date Requested";
            this.gcDateReq.FieldName = "gcDateReq";
            this.gcDateReq.Name = "gcDateReq";
            this.gcDateReq.OptionsColumn.ReadOnly = true;
            this.gcDateReq.Visible = true;
            this.gcDateReq.VisibleIndex = 6;
            // 
            // gcUserReq
            // 
            this.gcUserReq.Caption = "Requested By";
            this.gcUserReq.FieldName = "gcUserReq";
            this.gcUserReq.Name = "gcUserReq";
            this.gcUserReq.OptionsColumn.ReadOnly = true;
            this.gcUserReq.Visible = true;
            this.gcUserReq.VisibleIndex = 7;
            // 
            // gcDateTrans
            // 
            this.gcDateTrans.Caption = "Date Transferred";
            this.gcDateTrans.FieldName = "gcDateTrans";
            this.gcDateTrans.Name = "gcDateTrans";
            this.gcDateTrans.OptionsColumn.ReadOnly = true;
            this.gcDateTrans.Visible = true;
            this.gcDateTrans.VisibleIndex = 8;
            // 
            // gcUser
            // 
            this.gcUser.Caption = "Transferred By";
            this.gcUser.FieldName = "gcUser";
            this.gcUser.Name = "gcUser";
            this.gcUser.OptionsColumn.ReadOnly = true;
            this.gcUser.Visible = true;
            this.gcUser.VisibleIndex = 9;
            // 
            // gcProcess
            // 
            this.gcProcess.Caption = "Process";
            this.gcProcess.FieldName = "gcProcess";
            this.gcProcess.Name = "gcProcess";
            this.gcProcess.OptionsColumn.ReadOnly = true;
            this.gcProcess.Visible = true;
            this.gcProcess.VisibleIndex = 10;
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Transfer Status";
            this.gcStatus.FieldName = "gcStatus";
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.OptionsColumn.ReadOnly = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.dtpStartDate);
            this.groupControl1.Controls.Add(this.lblDateFrom);
            this.groupControl1.Controls.Add(this.lblDateTo);
            this.groupControl1.Controls.Add(this.dtpEndDate);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1302, 90);
            this.groupControl1.TabIndex = 96;
            this.groupControl1.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSearch.Location = new System.Drawing.Point(303, 29);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 52);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.ToolTip = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(10, 58);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(132, 23);
            this.dtpStartDate.TabIndex = 39;
            this.dtpStartDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 30, 0);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(6, 25);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(91, 23);
            this.lblDateFrom.TabIndex = 40;
            this.lblDateFrom.Text = "Date From";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(159, 25);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 42;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(163, 58);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 41;
            this.dtpEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(4, 2);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 787);
            this.ppnlWait.TabIndex = 37;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // ucTransferReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucTransferReports";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucTransferReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgTransfers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTransfers;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gcTo;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserReq;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateTrans;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
    }
}
