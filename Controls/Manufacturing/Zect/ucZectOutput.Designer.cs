namespace RTIS_Vulcan_UI.Controls.Manufacturing
{
    partial class ucZectOutput
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
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManufQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStarted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRunning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserStarted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStopped = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserStopped = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReopened = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserReopened = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.labelControl13.Size = new System.Drawing.Size(198, 44);
            this.labelControl13.TabIndex = 34;
            this.labelControl13.Text = "ZECT Records";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(0, 0);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 787);
            this.ppnlWait.TabIndex = 37;
            this.ppnlWait.Text = "progressPanel1";
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
            this.panelControl1.Size = new System.Drawing.Size(1304, 728);
            this.panelControl1.TabIndex = 38;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1294, 140);
            this.groupControl1.TabIndex = 2;
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
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Started";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(11, 62);
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
            this.lblDateFrom.Location = new System.Drawing.Point(7, 29);
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
            this.lblDateTo.Location = new System.Drawing.Point(199, 29);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 46;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(203, 62);
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
            this.btnSearch.Location = new System.Drawing.Point(375, 64);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 52);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.Text = "Search";
            this.btnSearch.ToolTip = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 151);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1294, 596);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcCode,
            this.gcItemCode,
            this.gcLot,
            this.gcQty,
            this.gcManufQty,
            this.gcStarted,
            this.gcLine,
            this.gcRunning,
            this.gcUserStarted,
            this.gcStopped,
            this.gcUserStopped,
            this.gcReopened,
            this.gcUserReopened});
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
            // gcCode
            // 
            this.gcCode.Caption = "Job Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowEdit = false;
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
            // gcQty
            // 
            this.gcQty.Caption = "Job Qty";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 2;
            // 
            // gcManufQty
            // 
            this.gcManufQty.Caption = "Manufactured Qty";
            this.gcManufQty.FieldName = "gcManufQty";
            this.gcManufQty.Name = "gcManufQty";
            this.gcManufQty.OptionsColumn.AllowEdit = false;
            this.gcManufQty.Visible = true;
            this.gcManufQty.VisibleIndex = 3;
            // 
            // gcStarted
            // 
            this.gcStarted.Caption = "Started";
            this.gcStarted.FieldName = "gcStarted";
            this.gcStarted.Name = "gcStarted";
            this.gcStarted.OptionsColumn.AllowEdit = false;
            this.gcStarted.Visible = true;
            this.gcStarted.VisibleIndex = 4;
            // 
            // gcLine
            // 
            this.gcLine.Caption = "Line";
            this.gcLine.FieldName = "gcLine";
            this.gcLine.Name = "gcLine";
            this.gcLine.OptionsColumn.AllowEdit = false;
            this.gcLine.Visible = true;
            this.gcLine.VisibleIndex = 5;
            // 
            // gcRunning
            // 
            this.gcRunning.Caption = "Job Running";
            this.gcRunning.FieldName = "gcRunning";
            this.gcRunning.Name = "gcRunning";
            this.gcRunning.OptionsColumn.AllowEdit = false;
            this.gcRunning.Visible = true;
            this.gcRunning.VisibleIndex = 6;
            // 
            // gcUserStarted
            // 
            this.gcUserStarted.Caption = "User Started";
            this.gcUserStarted.FieldName = "gcUserStarted";
            this.gcUserStarted.Name = "gcUserStarted";
            // 
            // gcStopped
            // 
            this.gcStopped.Caption = "Stopped";
            this.gcStopped.FieldName = "gcStopped";
            this.gcStopped.Name = "gcStopped";
            // 
            // gcUserStopped
            // 
            this.gcUserStopped.Caption = "Stopped";
            this.gcUserStopped.FieldName = "gcUserStopped";
            this.gcUserStopped.Name = "gcUserStopped";
            // 
            // gcReopened
            // 
            this.gcReopened.Caption = "Reopened";
            this.gcReopened.FieldName = "gcReopened";
            this.gcReopened.Name = "gcReopened";
            // 
            // gcUserReopened
            // 
            this.gcUserReopened.Caption = "User Reopened";
            this.gcUserReopened.FieldName = "gcUserReopened";
            this.gcUserReopened.Name = "gcUserReopened";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucZectOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucZectOutput";
            this.Size = new System.Drawing.Size(1311, 787);
            this.Load += new System.EventHandler(this.ucZectOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcManufQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcStarted;
        private DevExpress.XtraGrid.Columns.GridColumn gcLine;
        private DevExpress.XtraGrid.Columns.GridColumn gcRunning;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserStarted;
        private DevExpress.XtraGrid.Columns.GridColumn gcStopped;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserStopped;
        private DevExpress.XtraGrid.Columns.GridColumn gcReopened;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserReopened;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}
