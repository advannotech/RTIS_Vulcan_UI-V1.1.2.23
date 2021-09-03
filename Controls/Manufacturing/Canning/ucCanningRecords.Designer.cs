namespace RTIS_Vulcan_UI.Controls.Manufacturing.Canning
{
    partial class ucCanningRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCanningRecords));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.labelControl13.Size = new System.Drawing.Size(244, 44);
            this.labelControl13.TabIndex = 36;
            this.labelControl13.Text = "Canning Records";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.dgItems);
            this.pnlBack.Controls.Add(this.groupControl1);
            this.pnlBack.Location = new System.Drawing.Point(4, 55);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1304, 729);
            this.pnlBack.TabIndex = 37;
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 150);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1294, 537);
            this.dgItems.TabIndex = 3;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcItem,
            this.gcDesc,
            this.gcLot,
            this.gcQty,
            this.gcDate,
            this.gcRItem,
            this.gcRDesc,
            this.gcRQty,
            this.gcJob,
            this.gcPallet,
            this.gcUser});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcItem
            // 
            this.gcItem.Caption = "Item Code";
            this.gcItem.FieldName = "gcItem";
            this.gcItem.Name = "gcItem";
            this.gcItem.OptionsColumn.AllowEdit = false;
            this.gcItem.OptionsColumn.ReadOnly = true;
            this.gcItem.Visible = true;
            this.gcItem.VisibleIndex = 0;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowIncrementalSearch = false;
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.AllowIncrementalSearch = false;
            this.gcLot.OptionsColumn.ReadOnly = true;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 2;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Quantity";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowIncrementalSearch = false;
            this.gcQty.OptionsColumn.ReadOnly = true;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 3;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Date Added";
            this.gcDate.FieldName = "gcDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowIncrementalSearch = false;
            this.gcDate.OptionsColumn.ReadOnly = true;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 4;
            // 
            // gcRItem
            // 
            this.gcRItem.Caption = "Raw Item Code";
            this.gcRItem.FieldName = "gcRItem";
            this.gcRItem.Name = "gcRItem";
            // 
            // gcRDesc
            // 
            this.gcRDesc.Caption = "Raw Item Description";
            this.gcRDesc.FieldName = "gcRDesc";
            this.gcRDesc.Name = "gcRDesc";
            // 
            // gcRQty
            // 
            this.gcRQty.Caption = "Raw Item Qty";
            this.gcRQty.FieldName = "gcRQty";
            this.gcRQty.Name = "gcRQty";
            // 
            // gcJob
            // 
            this.gcJob.Caption = "Job Number";
            this.gcJob.FieldName = "gcJob";
            this.gcJob.Name = "gcJob";
            // 
            // gcPallet
            // 
            this.gcPallet.Caption = "PalletNumber";
            this.gcPallet.FieldName = "gcPallet";
            this.gcPallet.Name = "gcPallet";
            // 
            // gcUser
            // 
            this.gcUser.Caption = "User Added";
            this.gcUser.FieldName = "gcUser";
            this.gcUser.Name = "gcUser";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1294, 139);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Search Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.lblDateFrom);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(5, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 100);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Added";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(11, 69);
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
            this.lblDateFrom.Location = new System.Drawing.Point(7, 36);
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
            this.lblDateTo.Location = new System.Drawing.Point(199, 36);
            this.lblDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(67, 23);
            this.lblDateTo.TabIndex = 46;
            this.lblDateTo.Text = "Date To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(203, 69);
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
            this.btnSearch.Location = new System.Drawing.Point(374, 68);
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
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(0, 0);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 795);
            this.ppnlWait.TabIndex = 39;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucCanningRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucCanningRecords";
            this.Size = new System.Drawing.Size(1311, 787);
            this.Load += new System.EventHandler(this.ucCanningRecords_Load);
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

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraGrid.Columns.GridColumn gcRItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcRDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcRQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcJob;
        private DevExpress.XtraGrid.Columns.GridColumn gcPallet;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}
