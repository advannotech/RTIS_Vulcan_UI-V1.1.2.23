namespace RTIS_Vulcan_UI
{
    partial class ucPrepManufacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrepManufacture));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgSlurry = new DevExpress.XtraGrid.GridControl();
            this.gvSlurry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTrolley = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSLotNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQtyWet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSolidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQtyDry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSDateE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSEvoManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbOptions = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dgPowderPrep = new DevExpress.XtraGrid.GridControl();
            this.gvPowderPrep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSlurry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlurry)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).BeginInit();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPowderPrep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowderPrep)).BeginInit();
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
            this.lblHeader.Location = new System.Drawing.Point(3, 3);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(201, 36);
            this.lblHeader.TabIndex = 31;
            this.lblHeader.Text = "RM Manufacture";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.dgSlurry);
            this.panelControl1.Controls.Add(this.pnlSearch);
            this.panelControl1.Controls.Add(this.dgPowderPrep);
            this.panelControl1.Controls.Add(this.ppnlWait);
            this.panelControl1.Location = new System.Drawing.Point(4, 46);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(982, 594);
            this.panelControl1.TabIndex = 32;
            // 
            // dgSlurry
            // 
            this.dgSlurry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSlurry.Location = new System.Drawing.Point(6, 86);
            this.dgSlurry.MainView = this.gvSlurry;
            this.dgSlurry.Name = "dgSlurry";
            this.dgSlurry.Size = new System.Drawing.Size(971, 503);
            this.dgSlurry.TabIndex = 42;
            this.dgSlurry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSlurry});
            this.dgSlurry.Visible = false;
            // 
            // gvSlurry
            // 
            this.gvSlurry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSID,
            this.gcTrolley,
            this.gcTank,
            this.gcSItemCode,
            this.gcSDesc,
            this.gcSLotNum,
            this.gcQtyWet,
            this.gcSolidity,
            this.gcQtyDry,
            this.gcSDateE,
            this.gcSEvoManufacture});
            this.gvSlurry.GridControl = this.dgSlurry;
            this.gvSlurry.Name = "gvSlurry";
            this.gvSlurry.OptionsFind.AlwaysVisible = true;
            this.gvSlurry.OptionsView.ColumnAutoWidth = false;
            // 
            // gcSID
            // 
            this.gcSID.Caption = "ID";
            this.gcSID.FieldName = "gcSID";
            this.gcSID.Name = "gcSID";
            this.gcSID.OptionsColumn.AllowEdit = false;
            this.gcSID.Width = 60;
            // 
            // gcTrolley
            // 
            this.gcTrolley.Caption = "Slurry Trolley";
            this.gcTrolley.FieldName = "gcTrolley";
            this.gcTrolley.Name = "gcTrolley";
            this.gcTrolley.OptionsColumn.AllowEdit = false;
            this.gcTrolley.Visible = true;
            this.gcTrolley.VisibleIndex = 0;
            this.gcTrolley.Width = 100;
            // 
            // gcTank
            // 
            this.gcTank.Caption = "Slurry Tank";
            this.gcTank.FieldName = "gcTank";
            this.gcTank.Name = "gcTank";
            this.gcTank.OptionsColumn.AllowEdit = false;
            this.gcTank.Width = 100;
            // 
            // gcSItemCode
            // 
            this.gcSItemCode.Caption = "Item Code";
            this.gcSItemCode.FieldName = "gcSItemCode";
            this.gcSItemCode.Name = "gcSItemCode";
            this.gcSItemCode.OptionsColumn.AllowEdit = false;
            this.gcSItemCode.Visible = true;
            this.gcSItemCode.VisibleIndex = 1;
            this.gcSItemCode.Width = 130;
            // 
            // gcSDesc
            // 
            this.gcSDesc.Caption = "Description";
            this.gcSDesc.FieldName = "gcSDesc";
            this.gcSDesc.Name = "gcSDesc";
            this.gcSDesc.OptionsColumn.AllowEdit = false;
            this.gcSDesc.Visible = true;
            this.gcSDesc.VisibleIndex = 2;
            this.gcSDesc.Width = 130;
            // 
            // gcSLotNum
            // 
            this.gcSLotNum.Caption = "Lot Number";
            this.gcSLotNum.FieldName = "gcSLotNum";
            this.gcSLotNum.Name = "gcSLotNum";
            this.gcSLotNum.OptionsColumn.AllowEdit = false;
            this.gcSLotNum.Visible = true;
            this.gcSLotNum.VisibleIndex = 3;
            this.gcSLotNum.Width = 110;
            // 
            // gcQtyWet
            // 
            this.gcQtyWet.Caption = "Wet Weight";
            this.gcQtyWet.FieldName = "gcQtyWet";
            this.gcQtyWet.Name = "gcQtyWet";
            this.gcQtyWet.OptionsColumn.AllowEdit = false;
            this.gcQtyWet.Visible = true;
            this.gcQtyWet.VisibleIndex = 4;
            this.gcQtyWet.Width = 100;
            // 
            // gcSolidity
            // 
            this.gcSolidity.Caption = "Solidity";
            this.gcSolidity.FieldName = "gcSolidity";
            this.gcSolidity.Name = "gcSolidity";
            this.gcSolidity.OptionsColumn.AllowEdit = false;
            this.gcSolidity.Visible = true;
            this.gcSolidity.VisibleIndex = 5;
            this.gcSolidity.Width = 100;
            // 
            // gcQtyDry
            // 
            this.gcQtyDry.Caption = "Dry Weight";
            this.gcQtyDry.FieldName = "gcQtyDry";
            this.gcQtyDry.Name = "gcQtyDry";
            this.gcQtyDry.OptionsColumn.AllowEdit = false;
            this.gcQtyDry.Visible = true;
            this.gcQtyDry.VisibleIndex = 6;
            this.gcQtyDry.Width = 100;
            // 
            // gcSDateE
            // 
            this.gcSDateE.Caption = "Date Produced";
            this.gcSDateE.FieldName = "gcSDateE";
            this.gcSDateE.Name = "gcSDateE";
            this.gcSDateE.OptionsColumn.AllowEdit = false;
            this.gcSDateE.Visible = true;
            this.gcSDateE.VisibleIndex = 7;
            this.gcSDateE.Width = 100;
            // 
            // gcSEvoManufacture
            // 
            this.gcSEvoManufacture.Caption = "Evolution Manufactured";
            this.gcSEvoManufacture.FieldName = "gcSEvoManufacture";
            this.gcSEvoManufacture.Name = "gcSEvoManufacture";
            this.gcSEvoManufacture.Visible = true;
            this.gcSEvoManufacture.VisibleIndex = 8;
            this.gcSEvoManufacture.Width = 140;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.gbOptions);
            this.pnlSearch.Location = new System.Drawing.Point(6, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(971, 75);
            this.pnlSearch.TabIndex = 20;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.btnSearch);
            this.gbOptions.Controls.Add(this.cmbProcess);
            this.gbOptions.Controls.Add(this.labelControl9);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(0, 0);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(971, 75);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(922, 24);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 40);
            this.btnSearch.TabIndex = 87;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbProcess
            // 
            this.cmbProcess.Location = new System.Drawing.Point(13, 42);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProcess.Size = new System.Drawing.Size(219, 20);
            this.cmbProcess.TabIndex = 40;
            this.cmbProcess.SelectedIndexChanged += new System.EventHandler(this.cmbProcess_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(13, 23);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(73, 13);
            this.labelControl9.TabIndex = 39;
            this.labelControl9.Text = "Select Process:";
            // 
            // dgPowderPrep
            // 
            this.dgPowderPrep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPowderPrep.Location = new System.Drawing.Point(6, 86);
            this.dgPowderPrep.MainView = this.gvPowderPrep;
            this.dgPowderPrep.Name = "dgPowderPrep";
            this.dgPowderPrep.Size = new System.Drawing.Size(971, 503);
            this.dgPowderPrep.TabIndex = 0;
            this.dgPowderPrep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPowderPrep});
            // 
            // gvPowderPrep
            // 
            this.gvPowderPrep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcItemCode,
            this.gcDesc,
            this.gcLotNum,
            this.gcQty,
            this.gcDateE,
            this.gcEvoManufacture});
            this.gvPowderPrep.GridControl = this.dgPowderPrep;
            this.gvPowderPrep.Name = "gvPowderPrep";
            this.gvPowderPrep.OptionsFind.AlwaysVisible = true;
            this.gvPowderPrep.OptionsView.ColumnAutoWidth = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.Width = 60;
            // 
            // gcItemCode
            // 
            this.gcItemCode.Caption = "Item Code";
            this.gcItemCode.FieldName = "gcItemCode";
            this.gcItemCode.Name = "gcItemCode";
            this.gcItemCode.OptionsColumn.AllowEdit = false;
            this.gcItemCode.Visible = true;
            this.gcItemCode.VisibleIndex = 0;
            this.gcItemCode.Width = 150;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowEdit = false;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            this.gcDesc.Width = 180;
            // 
            // gcLotNum
            // 
            this.gcLotNum.Caption = "Lot Number";
            this.gcLotNum.FieldName = "gcLotNum";
            this.gcLotNum.Name = "gcLotNum";
            this.gcLotNum.OptionsColumn.AllowEdit = false;
            this.gcLotNum.Visible = true;
            this.gcLotNum.VisibleIndex = 2;
            this.gcLotNum.Width = 150;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty Produced";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 3;
            this.gcQty.Width = 120;
            // 
            // gcDateE
            // 
            this.gcDateE.Caption = "Date Produced";
            this.gcDateE.FieldName = "gcDateE";
            this.gcDateE.Name = "gcDateE";
            this.gcDateE.Visible = true;
            this.gcDateE.VisibleIndex = 4;
            this.gcDateE.Width = 140;
            // 
            // gcEvoManufacture
            // 
            this.gcEvoManufacture.Caption = "Evolution Manufactured";
            this.gcEvoManufacture.FieldName = "gcEvoManufacture";
            this.gcEvoManufacture.Name = "gcEvoManufacture";
            this.gcEvoManufacture.Visible = true;
            this.gcEvoManufacture.VisibleIndex = 5;
            this.gcEvoManufacture.Width = 140;
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(6, 5);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(971, 584);
            this.ppnlWait.TabIndex = 33;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucPrepManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblHeader);
            this.Name = "ucPrepManufacture";
            this.Size = new System.Drawing.Size(989, 643);
            this.Load += new System.EventHandler(this.ucPrepManufacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSlurry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSlurry)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPowderPrep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowderPrep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgPowderPrep;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPowderPrep;
        private System.Windows.Forms.Panel pnlSearch;
        private DevExpress.XtraEditors.GroupControl gbOptions;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProcess;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoManufacture;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateE;
        private DevExpress.XtraGrid.GridControl dgSlurry;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSlurry;
        private DevExpress.XtraGrid.Columns.GridColumn gcSID;
        private DevExpress.XtraGrid.Columns.GridColumn gcSItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcSDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSLotNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcQtyWet;
        private DevExpress.XtraGrid.Columns.GridColumn gcSDateE;
        private DevExpress.XtraGrid.Columns.GridColumn gcSEvoManufacture;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrolley;
        private DevExpress.XtraGrid.Columns.GridColumn gcTank;
        private DevExpress.XtraGrid.Columns.GridColumn gcSolidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcQtyDry;
    }
}
