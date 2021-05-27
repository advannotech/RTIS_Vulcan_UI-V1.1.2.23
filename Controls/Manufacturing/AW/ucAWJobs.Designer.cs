namespace RTIS_Vulcan_UI.Controls.Manufacturing
{
    partial class ucAWJobs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAWJobs));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPGM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPGMLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJobQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManufQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStarted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserStarted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReopened = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserReopened = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRunning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
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
            this.labelControl13.Size = new System.Drawing.Size(149, 44);
            this.labelControl13.TabIndex = 35;
            this.labelControl13.Text = "A&&W Jobs";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.dgItems);
            this.panelControl1.Location = new System.Drawing.Point(4, 56);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1304, 731);
            this.panelControl1.TabIndex = 36;
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
            this.groupControl1.Size = new System.Drawing.Size(1294, 90);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
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
            this.dtpStartDate.Location = new System.Drawing.Point(10, 51);
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
            this.dtpEndDate.Location = new System.Drawing.Point(163, 51);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 41;
            this.dtpEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 101);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1294, 641);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcJob,
            this.gcItemCode,
            this.gcLot,
            this.gcPGM,
            this.gcPGMLot,
            this.gcJobQty,
            this.gcManufQty,
            this.gcStarted,
            this.gcUserStarted,
            this.gcClosed,
            this.gcUserClosed,
            this.gcReopened,
            this.gcUserReopened,
            this.gcRunning});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            // 
            // gcJob
            // 
            this.gcJob.Caption = "Job Code";
            this.gcJob.FieldName = "gcJob";
            this.gcJob.Name = "gcJob";
            this.gcJob.OptionsColumn.AllowEdit = false;
            // 
            // gcItemCode
            // 
            this.gcItemCode.Caption = "Item Code";
            this.gcItemCode.FieldName = "gcItemCode";
            this.gcItemCode.Name = "gcItemCode";
            this.gcItemCode.OptionsColumn.AllowEdit = false;
            this.gcItemCode.Visible = true;
            this.gcItemCode.VisibleIndex = 0;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.AllowEdit = false;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 1;
            // 
            // gcPGM
            // 
            this.gcPGM.Caption = "PGM Used";
            this.gcPGM.FieldName = "gcPGM";
            this.gcPGM.Name = "gcPGM";
            this.gcPGM.OptionsColumn.AllowEdit = false;
            this.gcPGM.Visible = true;
            this.gcPGM.VisibleIndex = 2;
            // 
            // gcPGMLot
            // 
            this.gcPGMLot.Caption = "PGM Lot";
            this.gcPGMLot.FieldName = "gcPGMLot";
            this.gcPGMLot.Name = "gcPGMLot";
            this.gcPGMLot.OptionsColumn.AllowEdit = false;
            this.gcPGMLot.Visible = true;
            this.gcPGMLot.VisibleIndex = 3;
            // 
            // gcJobQty
            // 
            this.gcJobQty.Caption = "Job Qty";
            this.gcJobQty.FieldName = "gcJobQty";
            this.gcJobQty.Name = "gcJobQty";
            this.gcJobQty.OptionsColumn.AllowEdit = false;
            this.gcJobQty.Visible = true;
            this.gcJobQty.VisibleIndex = 4;
            // 
            // gcManufQty
            // 
            this.gcManufQty.Caption = "Manufactured Qty";
            this.gcManufQty.FieldName = "gcManufQty";
            this.gcManufQty.Name = "gcManufQty";
            this.gcManufQty.OptionsColumn.AllowEdit = false;
            this.gcManufQty.Visible = true;
            this.gcManufQty.VisibleIndex = 5;
            // 
            // gcStarted
            // 
            this.gcStarted.Caption = "Date Started";
            this.gcStarted.FieldName = "gcStarted";
            this.gcStarted.Name = "gcStarted";
            this.gcStarted.OptionsColumn.AllowEdit = false;
            this.gcStarted.Visible = true;
            this.gcStarted.VisibleIndex = 6;
            // 
            // gcUserStarted
            // 
            this.gcUserStarted.Caption = "User Started";
            this.gcUserStarted.FieldName = "gcUserStarted";
            this.gcUserStarted.Name = "gcUserStarted";
            this.gcUserStarted.OptionsColumn.AllowEdit = false;
            // 
            // gcClosed
            // 
            this.gcClosed.Caption = "Closed";
            this.gcClosed.FieldName = "gcClosed";
            this.gcClosed.Name = "gcClosed";
            this.gcClosed.OptionsColumn.AllowEdit = false;
            // 
            // gcUserClosed
            // 
            this.gcUserClosed.Caption = "User Closed";
            this.gcUserClosed.FieldName = "gcUserClosed";
            this.gcUserClosed.Name = "gcUserClosed";
            this.gcUserClosed.OptionsColumn.AllowEdit = false;
            // 
            // gcReopened
            // 
            this.gcReopened.Caption = "Reopened";
            this.gcReopened.FieldName = "gcReopened";
            this.gcReopened.Name = "gcReopened";
            this.gcReopened.OptionsColumn.AllowEdit = false;
            // 
            // gcUserReopened
            // 
            this.gcUserReopened.Caption = "User Reopened";
            this.gcUserReopened.FieldName = "gcUserReopened";
            this.gcUserReopened.Name = "gcUserReopened";
            this.gcUserReopened.OptionsColumn.AllowEdit = false;
            // 
            // gcRunning
            // 
            this.gcRunning.Caption = "Job Running";
            this.gcRunning.FieldName = "gcRunning";
            this.gcRunning.Name = "gcRunning";
            this.gcRunning.OptionsColumn.AllowEdit = false;
            this.gcRunning.Visible = true;
            this.gcRunning.VisibleIndex = 7;
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(0, 0);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 787);
            this.ppnlWait.TabIndex = 38;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucAWJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucAWJobs";
            this.Size = new System.Drawing.Size(1311, 787);
            this.Load += new System.EventHandler(this.ucAWJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcJob;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcPGM;
        private DevExpress.XtraGrid.Columns.GridColumn gcPGMLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcJobQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcManufQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcStarted;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserStarted;
        private DevExpress.XtraGrid.Columns.GridColumn gcClosed;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserClosed;
        private DevExpress.XtraGrid.Columns.GridColumn gcReopened;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserReopened;
        private DevExpress.XtraGrid.Columns.GridColumn gcRunning;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}
