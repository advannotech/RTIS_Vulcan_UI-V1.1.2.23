namespace RTIS_Vulcan_UI.Controls
{
    partial class ucPowderPrepRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPowderPrepRecords));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTransferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateTransferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserTransferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserEdited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEdited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEditReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOldQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.Appearance.Options.UseForeColor = true;
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(317, 44);
            this.lblHeader.TabIndex = 33;
            this.lblHeader.Text = "Powder Prep Records";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.dgItems);
            this.pnlBack.Controls.Add(this.groupControl1);
            this.pnlBack.Location = new System.Drawing.Point(4, 56);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1312, 732);
            this.pnlBack.TabIndex = 34;
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 102);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1301, 625);
            this.dgItems.TabIndex = 5;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcDesc,
            this.gcLot,
            this.gcQty,
            this.gcUserAdded,
            this.gcDateAdded,
            this.gcManuf,
            this.gcDateManuf,
            this.gcUserManuf,
            this.gcTransferred,
            this.gcDateTransferred,
            this.gcUserTransferred,
            this.gcReceived,
            this.gcDateReceived,
            this.gcUserReceived,
            this.gcUserEdited,
            this.gcDateEdited,
            this.gcEditReason,
            this.gcOldQty});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowEdit = false;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowEdit = false;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.AllowEdit = false;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 2;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Quantity";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 3;
            // 
            // gcUserAdded
            // 
            this.gcUserAdded.Caption = "Prepped By";
            this.gcUserAdded.FieldName = "gcUserAdded";
            this.gcUserAdded.Name = "gcUserAdded";
            this.gcUserAdded.OptionsColumn.AllowEdit = false;
            this.gcUserAdded.Visible = true;
            this.gcUserAdded.VisibleIndex = 4;
            // 
            // gcDateAdded
            // 
            this.gcDateAdded.Caption = "Date Prepped";
            this.gcDateAdded.FieldName = "gcDateAdded";
            this.gcDateAdded.Name = "gcDateAdded";
            this.gcDateAdded.OptionsColumn.AllowEdit = false;
            this.gcDateAdded.Visible = true;
            this.gcDateAdded.VisibleIndex = 5;
            // 
            // gcManuf
            // 
            this.gcManuf.Caption = "Manufactured";
            this.gcManuf.FieldName = "gcManuf";
            this.gcManuf.Name = "gcManuf";
            this.gcManuf.OptionsColumn.AllowEdit = false;
            this.gcManuf.Visible = true;
            this.gcManuf.VisibleIndex = 6;
            // 
            // gcDateManuf
            // 
            this.gcDateManuf.Caption = "Date Manufactured";
            this.gcDateManuf.FieldName = "gcDateManuf";
            this.gcDateManuf.Name = "gcDateManuf";
            // 
            // gcUserManuf
            // 
            this.gcUserManuf.Caption = "User Manufactured";
            this.gcUserManuf.FieldName = "gcUserManuf";
            this.gcUserManuf.Name = "gcUserManuf";
            // 
            // gcTransferred
            // 
            this.gcTransferred.Caption = "Transferred";
            this.gcTransferred.FieldName = "gcTransferred";
            this.gcTransferred.Name = "gcTransferred";
            this.gcTransferred.OptionsColumn.AllowEdit = false;
            this.gcTransferred.Visible = true;
            this.gcTransferred.VisibleIndex = 7;
            // 
            // gcDateTransferred
            // 
            this.gcDateTransferred.Caption = "Date Transferred";
            this.gcDateTransferred.FieldName = "gcDateTransferred";
            this.gcDateTransferred.Name = "gcDateTransferred";
            // 
            // gcUserTransferred
            // 
            this.gcUserTransferred.Caption = "Transferred By";
            this.gcUserTransferred.FieldName = "gcUserTransferred";
            this.gcUserTransferred.Name = "gcUserTransferred";
            // 
            // gcReceived
            // 
            this.gcReceived.Caption = "Received";
            this.gcReceived.FieldName = "gcReceived";
            this.gcReceived.Name = "gcReceived";
            this.gcReceived.OptionsColumn.AllowEdit = false;
            this.gcReceived.Visible = true;
            this.gcReceived.VisibleIndex = 8;
            // 
            // gcDateReceived
            // 
            this.gcDateReceived.Caption = "Date Received";
            this.gcDateReceived.FieldName = "gcDateReceived";
            this.gcDateReceived.Name = "gcDateReceived";
            // 
            // gcUserReceived
            // 
            this.gcUserReceived.Caption = "Received By";
            this.gcUserReceived.FieldName = "gcUserReceived";
            this.gcUserReceived.Name = "gcUserReceived";
            // 
            // gcUserEdited
            // 
            this.gcUserEdited.Caption = "Edited By";
            this.gcUserEdited.FieldName = "gcUserEdited";
            this.gcUserEdited.Name = "gcUserEdited";
            // 
            // gcDateEdited
            // 
            this.gcDateEdited.Caption = "Date Edited";
            this.gcDateEdited.FieldName = "gcDateEdited";
            this.gcDateEdited.Name = "gcDateEdited";
            // 
            // gcEditReason
            // 
            this.gcEditReason.Caption = "Edit Reason";
            this.gcEditReason.FieldName = "gcEditReason";
            this.gcEditReason.Name = "gcEditReason";
            // 
            // gcOldQty
            // 
            this.gcOldQty.Caption = "Old Quantity";
            this.gcOldQty.FieldName = "gcOldQty";
            this.gcOldQty.Name = "gcOldQty";
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
            this.groupControl1.Size = new System.Drawing.Size(1301, 90);
            this.groupControl1.TabIndex = 4;
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
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(4, 4);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 783);
            this.ppnlWait.TabIndex = 36;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // ucPowderPrepRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucPowderPrepRecords";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucPowderPrepRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcTransferred;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateTransferred;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserTransferred;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceived;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateReceived;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserReceived;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserEdited;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEdited;
        private DevExpress.XtraGrid.Columns.GridColumn gcEditReason;
        private DevExpress.XtraGrid.Columns.GridColumn gcOldQty;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
    }
}
