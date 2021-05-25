namespace RTIS_Vulcan_UI.Controls.Manufacturing.PGM
{
    partial class ucPGMJobs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPGMJobs));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConcentration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
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
            this.lblHeader.Location = new System.Drawing.Point(10, 4);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(199, 44);
            this.lblHeader.TabIndex = 32;
            this.lblHeader.Text = "PGM Records";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.dgItems);
            this.panelControl1.Location = new System.Drawing.Point(4, 55);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1312, 733);
            this.panelControl1.TabIndex = 33;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Location = new System.Drawing.Point(6, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1301, 163);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSearch.Location = new System.Drawing.Point(379, 63);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 52);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.ToolTip = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(6, 174);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1301, 554);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcLot,
            this.gcLocation,
            this.gcIn,
            this.gcOut,
            this.gcBal,
            this.gcConcentration,
            this.gcDate});
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
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.ReadOnly = true;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 1;
            // 
            // gcLocation
            // 
            this.gcLocation.Caption = "Location";
            this.gcLocation.FieldName = "gcLocation";
            this.gcLocation.Name = "gcLocation";
            this.gcLocation.OptionsColumn.AllowEdit = false;
            this.gcLocation.Visible = true;
            this.gcLocation.VisibleIndex = 2;
            // 
            // gcIn
            // 
            this.gcIn.Caption = "In";
            this.gcIn.FieldName = "gcIn";
            this.gcIn.Name = "gcIn";
            this.gcIn.OptionsColumn.AllowEdit = false;
            this.gcIn.Visible = true;
            this.gcIn.VisibleIndex = 3;
            // 
            // gcOut
            // 
            this.gcOut.Caption = "Out";
            this.gcOut.FieldName = "gcOut";
            this.gcOut.Name = "gcOut";
            this.gcOut.OptionsColumn.AllowEdit = false;
            this.gcOut.Visible = true;
            this.gcOut.VisibleIndex = 4;
            // 
            // gcBal
            // 
            this.gcBal.Caption = "Balance";
            this.gcBal.FieldName = "gcBal";
            this.gcBal.Name = "gcBal";
            this.gcBal.OptionsColumn.AllowEdit = false;
            this.gcBal.Visible = true;
            this.gcBal.VisibleIndex = 5;
            // 
            // gcConcentration
            // 
            this.gcConcentration.Caption = "Concentration";
            this.gcConcentration.FieldName = "gcConcentration";
            this.gcConcentration.Name = "gcConcentration";
            this.gcConcentration.OptionsColumn.AllowEdit = false;
            this.gcConcentration.Visible = true;
            this.gcConcentration.VisibleIndex = 6;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Date Started";
            this.gcDate.FieldName = "gcDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowEdit = false;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 7;
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
            this.ppnlWait.TabIndex = 34;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
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
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Transferred";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(11, 65);
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
            this.lblDateFrom.Location = new System.Drawing.Point(7, 32);
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
            this.lblDateTo.Location = new System.Drawing.Point(195, 32);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 46;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(199, 65);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(132, 23);
            this.dtpEndDate.TabIndex = 45;
            this.dtpEndDate.Value = new System.DateTime(2017, 10, 23, 13, 27, 52, 0);
            // 
            // ucPGMJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucPGMJobs";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucPGMJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gcIn;
        private DevExpress.XtraGrid.Columns.GridColumn gcOut;
        private DevExpress.XtraGrid.Columns.GridColumn gcBal;
        private DevExpress.XtraGrid.Columns.GridColumn gcConcentration;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}
