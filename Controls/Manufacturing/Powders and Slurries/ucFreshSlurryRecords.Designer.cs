namespace RTIS_Vulcan_UI.Controls
{
    partial class ucFreshSlurryRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFreshSlurryRecords));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTrolley = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDryWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSolidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEntered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserEntered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateSol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserSol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTransferred = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateTrans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.lblHeader.Size = new System.Drawing.Size(301, 44);
            this.lblHeader.TabIndex = 34;
            this.lblHeader.Text = "Fresh Slurry Records";
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
            this.pnlBack.TabIndex = 35;
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(6, 153);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1301, 574);
            this.dgItems.TabIndex = 6;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTrolley,
            this.gcCode,
            this.gcDesc,
            this.gcLotNumber,
            this.gcWetWeight,
            this.gcDryWeight,
            this.gcSolidity,
            this.gcDateEntered,
            this.gcUserEntered,
            this.gcDateSol,
            this.gcUserSol,
            this.gcDateManuf,
            this.gcUserManuf,
            this.gcTransferred,
            this.gcDateTrans,
            this.gcRec,
            this.gcDateRec,
            this.gcUserRec});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcTrolley
            // 
            this.gcTrolley.Caption = "Trolley";
            this.gcTrolley.FieldName = "gcTrolley";
            this.gcTrolley.Name = "gcTrolley";
            this.gcTrolley.OptionsColumn.AllowEdit = false;
            this.gcTrolley.Visible = true;
            this.gcTrolley.VisibleIndex = 0;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowEdit = false;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 1;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowEdit = false;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 2;
            // 
            // gcLotNumber
            // 
            this.gcLotNumber.Caption = "Lot Number";
            this.gcLotNumber.FieldName = "gcLotNumber";
            this.gcLotNumber.Name = "gcLotNumber";
            this.gcLotNumber.OptionsColumn.AllowEdit = false;
            this.gcLotNumber.Visible = true;
            this.gcLotNumber.VisibleIndex = 3;
            // 
            // gcWetWeight
            // 
            this.gcWetWeight.Caption = "Wet Weight";
            this.gcWetWeight.FieldName = "gcWetWeight";
            this.gcWetWeight.Name = "gcWetWeight";
            this.gcWetWeight.OptionsColumn.AllowEdit = false;
            this.gcWetWeight.Visible = true;
            this.gcWetWeight.VisibleIndex = 4;
            // 
            // gcDryWeight
            // 
            this.gcDryWeight.Caption = "Dry Weight";
            this.gcDryWeight.FieldName = "gcDryWeight";
            this.gcDryWeight.Name = "gcDryWeight";
            this.gcDryWeight.OptionsColumn.AllowEdit = false;
            this.gcDryWeight.Visible = true;
            this.gcDryWeight.VisibleIndex = 5;
            // 
            // gcSolidity
            // 
            this.gcSolidity.Caption = "Solidity";
            this.gcSolidity.FieldName = "gcSolidity";
            this.gcSolidity.Name = "gcSolidity";
            this.gcSolidity.OptionsColumn.AllowEdit = false;
            this.gcSolidity.Visible = true;
            this.gcSolidity.VisibleIndex = 6;
            // 
            // gcDateEntered
            // 
            this.gcDateEntered.Caption = "Date Entered";
            this.gcDateEntered.FieldName = "gcDateEntered";
            this.gcDateEntered.Name = "gcDateEntered";
            this.gcDateEntered.OptionsColumn.AllowEdit = false;
            this.gcDateEntered.Visible = true;
            this.gcDateEntered.VisibleIndex = 7;
            // 
            // gcUserEntered
            // 
            this.gcUserEntered.Caption = "User Entered";
            this.gcUserEntered.FieldName = "gcUserEntered";
            this.gcUserEntered.Name = "gcUserEntered";
            this.gcUserEntered.OptionsColumn.AllowEdit = false;
            // 
            // gcDateSol
            // 
            this.gcDateSol.Caption = "Solidity Date";
            this.gcDateSol.FieldName = "gcDateSol";
            this.gcDateSol.Name = "gcDateSol";
            // 
            // gcUserSol
            // 
            this.gcUserSol.Caption = "Solidtity Set By";
            this.gcUserSol.FieldName = "gcUserSol";
            this.gcUserSol.Name = "gcUserSol";
            this.gcUserSol.OptionsColumn.AllowEdit = false;
            // 
            // gcDateManuf
            // 
            this.gcDateManuf.Caption = "Manufacture Date";
            this.gcDateManuf.FieldName = "gcDateManuf";
            this.gcDateManuf.Name = "gcDateManuf";
            this.gcDateManuf.OptionsColumn.AllowEdit = false;
            // 
            // gcUserManuf
            // 
            this.gcUserManuf.Caption = "Manufactured By";
            this.gcUserManuf.FieldName = "gcUserManuf";
            this.gcUserManuf.Name = "gcUserManuf";
            this.gcUserManuf.OptionsColumn.AllowEdit = false;
            // 
            // gcTransferred
            // 
            this.gcTransferred.Caption = "Transferred";
            this.gcTransferred.FieldName = "gcTransferred";
            this.gcTransferred.Name = "gcTransferred";
            this.gcTransferred.OptionsColumn.AllowEdit = false;
            this.gcTransferred.Visible = true;
            this.gcTransferred.VisibleIndex = 8;
            // 
            // gcDateTrans
            // 
            this.gcDateTrans.Caption = "Transfer Date";
            this.gcDateTrans.FieldName = "gcDateTrans";
            this.gcDateTrans.Name = "gcDateTrans";
            this.gcDateTrans.OptionsColumn.AllowEdit = false;
            // 
            // gcRec
            // 
            this.gcRec.Caption = "Received";
            this.gcRec.FieldName = "gcRec";
            this.gcRec.Name = "gcRec";
            this.gcRec.OptionsColumn.AllowEdit = false;
            this.gcRec.Visible = true;
            this.gcRec.VisibleIndex = 9;
            // 
            // gcDateRec
            // 
            this.gcDateRec.Caption = "Date Received";
            this.gcDateRec.FieldName = "gcDateRec";
            this.gcDateRec.Name = "gcDateRec";
            this.gcDateRec.OptionsColumn.AllowEdit = false;
            // 
            // gcUserRec
            // 
            this.gcUserRec.Caption = "Received By";
            this.gcUserRec.FieldName = "gcUserRec";
            this.gcUserRec.Name = "gcUserRec";
            this.gcUserRec.OptionsColumn.AllowEdit = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1302, 142);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Search Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 100);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Entered";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(23, 68);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(132, 23);
            this.dtpStartDate.TabIndex = 43;
            this.dtpStartDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 30, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(19, 35);
            this.lblDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(91, 23);
            this.lblDateFrom.TabIndex = 44;
            this.lblDateFrom.Text = "Date From";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(195, 35);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 46;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(199, 68);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 45;
            this.dtpEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSearch.Location = new System.Drawing.Point(373, 66);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 52);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.ToolTip = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(4, 4);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 783);
            this.ppnlWait.TabIndex = 37;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // ucFreshSlurryRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucFreshSlurryRecords";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucFreshSlurryRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrolley;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcWetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcDryWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcSolidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEntered;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserEntered;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateSol;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserSol;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcTransferred;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateTrans;
        private DevExpress.XtraGrid.Columns.GridColumn gcRec;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateRec;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserRec;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}
