namespace RTIS_Vulcan_UI.Forms.Transfer_Management
{
    partial class frmConfigureLocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigureLocs));
            this.xtcLocs = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dgOutNew = new DevExpress.XtraGrid.GridControl();
            this.gvOutNew = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIDON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWarehouseON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAddOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBackOut = new DevExpress.XtraEditors.SimpleButton();
            this.dgOut = new DevExpress.XtraGrid.GridControl();
            this.gvOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWarehouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOutAdd = new DevExpress.XtraEditors.SimpleButton();
            this.xtpRec = new DevExpress.XtraTab.XtraTabPage();
            this.dgRecAdd = new DevExpress.XtraGrid.GridControl();
            this.gvRecAdd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIDRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWarehouseRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAddRA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBackRec = new DevExpress.XtraEditors.SimpleButton();
            this.dgRec = new DevExpress.XtraGrid.GridControl();
            this.gvRec = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIDRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWarehouseRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemoveRec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddRec = new DevExpress.XtraEditors.SimpleButton();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtcLocs)).BeginInit();
            this.xtcLocs.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOut)).BeginInit();
            this.xtpRec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRec)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcLocs
            // 
            this.xtcLocs.Location = new System.Drawing.Point(13, 52);
            this.xtcLocs.Name = "xtcLocs";
            this.xtcLocs.SelectedTabPage = this.xtraTabPage1;
            this.xtcLocs.Size = new System.Drawing.Size(775, 569);
            this.xtcLocs.TabIndex = 0;
            this.xtcLocs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtpRec});
            this.xtcLocs.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtcLocs_SelectedPageChanged);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.dgOutNew);
            this.xtraTabPage1.Controls.Add(this.dgOut);
            this.xtraTabPage1.Controls.Add(this.btnOutAdd);
            this.xtraTabPage1.Controls.Add(this.btnBackOut);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(768, 535);
            this.xtraTabPage1.Text = "Outgoing Locations";
            // 
            // dgOutNew
            // 
            this.dgOutNew.Location = new System.Drawing.Point(3, 3);
            this.dgOutNew.MainView = this.gvOutNew;
            this.dgOutNew.Name = "dgOutNew";
            this.dgOutNew.Size = new System.Drawing.Size(762, 471);
            this.dgOutNew.TabIndex = 1;
            this.dgOutNew.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOutNew});
            // 
            // gvOutNew
            // 
            this.gvOutNew.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIDON,
            this.gcWarehouseON,
            this.gcAddOn});
            this.gvOutNew.GridControl = this.dgOutNew;
            this.gvOutNew.Name = "gvOutNew";
            // 
            // gcIDON
            // 
            this.gcIDON.Caption = "ID";
            this.gcIDON.FieldName = "gcIDON";
            this.gcIDON.Name = "gcIDON";
            this.gcIDON.Visible = true;
            this.gcIDON.VisibleIndex = 0;
            // 
            // gcWarehouseON
            // 
            this.gcWarehouseON.Caption = "Warehouse";
            this.gcWarehouseON.FieldName = "gcWarehouseON";
            this.gcWarehouseON.Name = "gcWarehouseON";
            this.gcWarehouseON.Visible = true;
            this.gcWarehouseON.VisibleIndex = 1;
            // 
            // gcAddOn
            // 
            this.gcAddOn.Caption = "Add";
            this.gcAddOn.FieldName = "gcAddOn";
            this.gcAddOn.Name = "gcAddOn";
            this.gcAddOn.Visible = true;
            this.gcAddOn.VisibleIndex = 2;
            // 
            // btnBackOut
            // 
            this.btnBackOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackOut.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnBackOut.Appearance.Options.UseBackColor = true;
            this.btnBackOut.Image = ((System.Drawing.Image)(resources.GetObject("btnBackOut.Image")));
            this.btnBackOut.Location = new System.Drawing.Point(590, 480);
            this.btnBackOut.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnBackOut.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBackOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackOut.Name = "btnBackOut";
            this.btnBackOut.Size = new System.Drawing.Size(175, 49);
            this.btnBackOut.TabIndex = 72;
            this.btnBackOut.Text = "Back";
            this.btnBackOut.Click += new System.EventHandler(this.btnBackOut_Click);
            // 
            // dgOut
            // 
            this.dgOut.Location = new System.Drawing.Point(4, 3);
            this.dgOut.MainView = this.gvOut;
            this.dgOut.Name = "dgOut";
            this.dgOut.Size = new System.Drawing.Size(761, 470);
            this.dgOut.TabIndex = 0;
            this.dgOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOut});
            // 
            // gvOut
            // 
            this.gvOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcWarehouse,
            this.gcRemove});
            this.gvOut.GridControl = this.dgOut;
            this.gvOut.Name = "gvOut";
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcWarehouse
            // 
            this.gcWarehouse.Caption = "Warehouse";
            this.gcWarehouse.FieldName = "gcWarehouse";
            this.gcWarehouse.Name = "gcWarehouse";
            this.gcWarehouse.OptionsColumn.AllowEdit = false;
            this.gcWarehouse.Visible = true;
            this.gcWarehouse.VisibleIndex = 1;
            // 
            // gcRemove
            // 
            this.gcRemove.Caption = "Remove";
            this.gcRemove.FieldName = "gcRemove";
            this.gcRemove.Name = "gcRemove";
            this.gcRemove.Visible = true;
            this.gcRemove.VisibleIndex = 2;
            // 
            // btnOutAdd
            // 
            this.btnOutAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutAdd.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnOutAdd.Appearance.Options.UseBackColor = true;
            this.btnOutAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnOutAdd.Image")));
            this.btnOutAdd.Location = new System.Drawing.Point(590, 480);
            this.btnOutAdd.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnOutAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOutAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutAdd.Name = "btnOutAdd";
            this.btnOutAdd.Size = new System.Drawing.Size(175, 49);
            this.btnOutAdd.TabIndex = 71;
            this.btnOutAdd.Text = "Add";
            this.btnOutAdd.Click += new System.EventHandler(this.btnOutAdd_Click);
            // 
            // xtpRec
            // 
            this.xtpRec.Controls.Add(this.dgRecAdd);
            this.xtpRec.Controls.Add(this.btnBackRec);
            this.xtpRec.Controls.Add(this.dgRec);
            this.xtpRec.Controls.Add(this.btnAddRec);
            this.xtpRec.Name = "xtpRec";
            this.xtpRec.Size = new System.Drawing.Size(768, 535);
            this.xtpRec.Text = "Incomming Locations";
            // 
            // dgRecAdd
            // 
            this.dgRecAdd.Location = new System.Drawing.Point(3, 4);
            this.dgRecAdd.MainView = this.gvRecAdd;
            this.dgRecAdd.Name = "dgRecAdd";
            this.dgRecAdd.Size = new System.Drawing.Size(762, 471);
            this.dgRecAdd.TabIndex = 74;
            this.dgRecAdd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecAdd});
            // 
            // gvRecAdd
            // 
            this.gvRecAdd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIDRA,
            this.gcWarehouseRA,
            this.gcAddRA});
            this.gvRecAdd.GridControl = this.dgRecAdd;
            this.gvRecAdd.Name = "gvRecAdd";
            // 
            // gcIDRA
            // 
            this.gcIDRA.Caption = "ID";
            this.gcIDRA.FieldName = "gcIDRA";
            this.gcIDRA.Name = "gcIDRA";
            this.gcIDRA.Visible = true;
            this.gcIDRA.VisibleIndex = 0;
            // 
            // gcWarehouseRA
            // 
            this.gcWarehouseRA.Caption = "Warehouse";
            this.gcWarehouseRA.FieldName = "gcWarehouseRA";
            this.gcWarehouseRA.Name = "gcWarehouseRA";
            this.gcWarehouseRA.Visible = true;
            this.gcWarehouseRA.VisibleIndex = 1;
            // 
            // gcAddRA
            // 
            this.gcAddRA.Caption = "Add";
            this.gcAddRA.FieldName = "gcAddRA";
            this.gcAddRA.Name = "gcAddRA";
            this.gcAddRA.Visible = true;
            this.gcAddRA.VisibleIndex = 2;
            // 
            // btnBackRec
            // 
            this.btnBackRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackRec.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnBackRec.Appearance.Options.UseBackColor = true;
            this.btnBackRec.Image = ((System.Drawing.Image)(resources.GetObject("btnBackRec.Image")));
            this.btnBackRec.Location = new System.Drawing.Point(590, 481);
            this.btnBackRec.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnBackRec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBackRec.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackRec.Name = "btnBackRec";
            this.btnBackRec.Size = new System.Drawing.Size(175, 49);
            this.btnBackRec.TabIndex = 75;
            this.btnBackRec.Text = "Back";
            // 
            // dgRec
            // 
            this.dgRec.Location = new System.Drawing.Point(4, 4);
            this.dgRec.MainView = this.gvRec;
            this.dgRec.Name = "dgRec";
            this.dgRec.Size = new System.Drawing.Size(761, 470);
            this.dgRec.TabIndex = 72;
            this.dgRec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRec});
            // 
            // gvRec
            // 
            this.gvRec.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIDRec,
            this.gcWarehouseRec,
            this.gcRemoveRec});
            this.gvRec.GridControl = this.dgRec;
            this.gvRec.Name = "gvRec";
            // 
            // gcIDRec
            // 
            this.gcIDRec.Caption = "ID";
            this.gcIDRec.FieldName = "gcIDRec";
            this.gcIDRec.Name = "gcIDRec";
            this.gcIDRec.OptionsColumn.AllowEdit = false;
            this.gcIDRec.Visible = true;
            this.gcIDRec.VisibleIndex = 0;
            // 
            // gcWarehouseRec
            // 
            this.gcWarehouseRec.Caption = "Warehouse";
            this.gcWarehouseRec.FieldName = "gcWarehouseRec";
            this.gcWarehouseRec.Name = "gcWarehouseRec";
            this.gcWarehouseRec.OptionsColumn.AllowEdit = false;
            this.gcWarehouseRec.Visible = true;
            this.gcWarehouseRec.VisibleIndex = 1;
            // 
            // gcRemoveRec
            // 
            this.gcRemoveRec.Caption = "Remove";
            this.gcRemoveRec.FieldName = "gcRemoveRec";
            this.gcRemoveRec.Name = "gcRemoveRec";
            this.gcRemoveRec.Visible = true;
            this.gcRemoveRec.VisibleIndex = 2;
            // 
            // btnAddRec
            // 
            this.btnAddRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRec.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAddRec.Appearance.Options.UseBackColor = true;
            this.btnAddRec.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRec.Image")));
            this.btnAddRec.Location = new System.Drawing.Point(590, 481);
            this.btnAddRec.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddRec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddRec.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRec.Name = "btnAddRec";
            this.btnAddRec.Size = new System.Drawing.Size(175, 49);
            this.btnAddRec.TabIndex = 73;
            this.btnAddRec.Text = "Add";
            this.btnAddRec.Click += new System.EventHandler(this.btnAddRec_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcess.Appearance.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProcess.Appearance.Options.UseFont = true;
            this.lblProcess.Appearance.Options.UseForeColor = true;
            this.lblProcess.Location = new System.Drawing.Point(13, 13);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(4);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(85, 28);
            this.lblProcess.TabIndex = 72;
            this.lblProcess.Text = "[Process]";
            // 
            // frmConfigureLocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 633);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.xtcLocs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigureLocs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Transfer Locations";
            this.Load += new System.EventHandler(this.frmConfigureLocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcLocs)).EndInit();
            this.xtcLocs.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOutNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOutNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOut)).EndInit();
            this.xtpRec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcLocs;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtpRec;
        private DevExpress.XtraGrid.GridControl dgOut;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOut;
        private DevExpress.XtraEditors.SimpleButton btnOutAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemove;
        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraGrid.GridControl dgOutNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOutNew;
        private DevExpress.XtraGrid.Columns.GridColumn gcIDON;
        private DevExpress.XtraGrid.Columns.GridColumn gcWarehouseON;
        private DevExpress.XtraGrid.Columns.GridColumn gcAddOn;
        private DevExpress.XtraEditors.SimpleButton btnBackOut;
        private DevExpress.XtraGrid.GridControl dgRec;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRec;
        private DevExpress.XtraGrid.Columns.GridColumn gcIDRec;
        private DevExpress.XtraGrid.Columns.GridColumn gcWarehouseRec;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemoveRec;
        private DevExpress.XtraEditors.SimpleButton btnAddRec;
        private DevExpress.XtraGrid.GridControl dgRecAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRecAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gcIDRA;
        private DevExpress.XtraGrid.Columns.GridColumn gcWarehouseRA;
        private DevExpress.XtraGrid.Columns.GridColumn gcAddRA;
        private DevExpress.XtraEditors.SimpleButton btnBackRec;
    }
}