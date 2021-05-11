namespace RTIS_Vulcan_UI.Controls.Manufacturing.PGM
{
    partial class ucPGMManufacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPGMManufacture));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConcentration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.xtcManuf = new DevExpress.XtraTab.XtraTabControl();
            this.xtpPGM = new DevExpress.XtraTab.XtraTabPage();
            this.xtpPowder = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefreshP = new DevExpress.XtraEditors.SimpleButton();
            this.dgPowders = new DevExpress.XtraGrid.GridControl();
            this.gvPowders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPowderClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtpFS = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dgFS = new DevExpress.XtraGrid.GridControl();
            this.gvFS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcFSId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSTrol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSolidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDryWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFSEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRefreshFS = new DevExpress.XtraEditors.SimpleButton();
            this.xtpMS = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dgMixed = new DevExpress.XtraGrid.GridControl();
            this.gvMixed = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMSManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSTank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSSlurries = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMSDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtpZect = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnZRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.dgZect = new DevExpress.XtraGrid.GridControl();
            this.gvZect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcZID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCoat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZRun = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcZDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtpAW = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.dgAW = new DevExpress.XtraGrid.GridControl();
            this.gvAW = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcAID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAJobCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcACode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcALot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAProc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcADate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAUserProduced = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcARun = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnARefresh = new DevExpress.XtraEditors.SimpleButton();
            this.xtpCanning = new DevExpress.XtraTab.XtraTabPage();
            this.btnCRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.dgCanning = new DevExpress.XtraGrid.GridControl();
            this.gvCanning = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConfigure = new DevExpress.XtraEditors.SimpleButton();
            this.gcCanClose = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcManuf)).BeginInit();
            this.xtcManuf.SuspendLayout();
            this.xtpPGM.SuspendLayout();
            this.xtpPowder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPowders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowders)).BeginInit();
            this.xtpFS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFS)).BeginInit();
            this.xtpMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMixed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMixed)).BeginInit();
            this.xtpZect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgZect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZect)).BeginInit();
            this.xtpAW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAW)).BeginInit();
            this.xtpCanning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCanning)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(320, 44);
            this.lblHeader.TabIndex = 33;
            this.lblHeader.Text = "Items to Manufacture";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnProcess);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.dgItems);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1299, 692);
            this.panelControl1.TabIndex = 34;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnProcess.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnProcess.Appearance.Options.UseBackColor = true;
            this.btnProcess.Appearance.Options.UseFont = true;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(949, 637);
            this.btnProcess.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnProcess.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(168, 49);
            this.btnProcess.TabIndex = 91;
            this.btnProcess.Text = "Process Records";
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1125, 637);
            this.btnRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(168, 49);
            this.btnRefresh.TabIndex = 90;
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
            this.dgItems.Size = new System.Drawing.Size(1288, 624);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcLotNumber,
            this.gcLocation,
            this.gcConcentration,
            this.gcQty,
            this.gcRemCap,
            this.gcRem});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Item Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowEdit = false;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
            // 
            // gcLotNumber
            // 
            this.gcLotNumber.Caption = "Lot Number";
            this.gcLotNumber.FieldName = "gcLotNumber";
            this.gcLotNumber.Name = "gcLotNumber";
            this.gcLotNumber.OptionsColumn.AllowEdit = false;
            this.gcLotNumber.Visible = true;
            this.gcLotNumber.VisibleIndex = 1;
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
            // gcConcentration
            // 
            this.gcConcentration.Caption = "Concentration";
            this.gcConcentration.FieldName = "gcConcentration";
            this.gcConcentration.Name = "gcConcentration";
            this.gcConcentration.OptionsColumn.AllowEdit = false;
            this.gcConcentration.Visible = true;
            this.gcConcentration.VisibleIndex = 3;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Quantity Waiting";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 4;
            // 
            // gcRemCap
            // 
            this.gcRemCap.Caption = "Remainder Captured";
            this.gcRemCap.FieldName = "gcRemCap";
            this.gcRemCap.Name = "gcRemCap";
            this.gcRemCap.Visible = true;
            this.gcRemCap.VisibleIndex = 5;
            // 
            // gcRem
            // 
            this.gcRem.Caption = "Remainder";
            this.gcRem.FieldName = "gcRem";
            this.gcRem.Name = "gcRem";
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
            this.ppnlWait.TabIndex = 35;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // xtcManuf
            // 
            this.xtcManuf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtcManuf.Location = new System.Drawing.Point(4, 55);
            this.xtcManuf.Name = "xtcManuf";
            this.xtcManuf.SelectedTabPage = this.xtpPGM;
            this.xtcManuf.Size = new System.Drawing.Size(1312, 732);
            this.xtcManuf.TabIndex = 36;
            this.xtcManuf.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpPGM,
            this.xtpPowder,
            this.xtpFS,
            this.xtpMS,
            this.xtpZect,
            this.xtpAW,
            this.xtpCanning});
            this.xtcManuf.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtcManuf_SelectedPageChanged);
            // 
            // xtpPGM
            // 
            this.xtpPGM.Controls.Add(this.panelControl1);
            this.xtpPGM.Name = "xtpPGM";
            this.xtpPGM.Size = new System.Drawing.Size(1305, 698);
            this.xtpPGM.Text = "PGM Manufacture";
            // 
            // xtpPowder
            // 
            this.xtpPowder.Controls.Add(this.panelControl2);
            this.xtpPowder.Name = "xtpPowder";
            this.xtpPowder.Size = new System.Drawing.Size(1305, 698);
            this.xtpPowder.Text = "Powder Manufacture";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.btnRefreshP);
            this.panelControl2.Controls.Add(this.dgPowders);
            this.panelControl2.Location = new System.Drawing.Point(4, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1298, 691);
            this.panelControl2.TabIndex = 0;
            // 
            // btnRefreshP
            // 
            this.btnRefreshP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshP.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefreshP.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefreshP.Appearance.Options.UseBackColor = true;
            this.btnRefreshP.Appearance.Options.UseFont = true;
            this.btnRefreshP.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshP.Image")));
            this.btnRefreshP.Location = new System.Drawing.Point(1124, 636);
            this.btnRefreshP.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefreshP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefreshP.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshP.Name = "btnRefreshP";
            this.btnRefreshP.Size = new System.Drawing.Size(168, 49);
            this.btnRefreshP.TabIndex = 91;
            this.btnRefreshP.Text = "Refresh";
            this.btnRefreshP.Click += new System.EventHandler(this.btnRefreshP_Click);
            // 
            // dgPowders
            // 
            this.dgPowders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPowders.Location = new System.Drawing.Point(6, 6);
            this.dgPowders.MainView = this.gvPowders;
            this.dgPowders.Name = "dgPowders";
            this.dgPowders.Size = new System.Drawing.Size(1287, 623);
            this.dgPowders.TabIndex = 0;
            this.dgPowders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPowders});
            // 
            // gvPowders
            // 
            this.gvPowders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcPCode,
            this.gcPDesc,
            this.gcPLot,
            this.gcPQty,
            this.gcPAdded,
            this.gcPDate,
            this.gcPManuf,
            this.gcPEdit,
            this.gcPowderClose});
            this.gvPowders.GridControl = this.dgPowders;
            this.gvPowders.Name = "gvPowders";
            this.gvPowders.OptionsFind.AlwaysVisible = true;
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
            // gcPCode
            // 
            this.gcPCode.Caption = "Code";
            this.gcPCode.FieldName = "gcPCode";
            this.gcPCode.Name = "gcPCode";
            this.gcPCode.OptionsColumn.ReadOnly = true;
            this.gcPCode.Visible = true;
            this.gcPCode.VisibleIndex = 1;
            // 
            // gcPDesc
            // 
            this.gcPDesc.Caption = "Description";
            this.gcPDesc.FieldName = "gcPDesc";
            this.gcPDesc.Name = "gcPDesc";
            this.gcPDesc.OptionsColumn.ReadOnly = true;
            this.gcPDesc.Visible = true;
            this.gcPDesc.VisibleIndex = 2;
            // 
            // gcPLot
            // 
            this.gcPLot.Caption = "Lot Number";
            this.gcPLot.FieldName = "gcPLot";
            this.gcPLot.Name = "gcPLot";
            this.gcPLot.OptionsColumn.ReadOnly = true;
            this.gcPLot.Visible = true;
            this.gcPLot.VisibleIndex = 3;
            // 
            // gcPQty
            // 
            this.gcPQty.Caption = "Quantity";
            this.gcPQty.FieldName = "gcPQty";
            this.gcPQty.Name = "gcPQty";
            this.gcPQty.OptionsColumn.ReadOnly = true;
            this.gcPQty.Visible = true;
            this.gcPQty.VisibleIndex = 4;
            // 
            // gcPAdded
            // 
            this.gcPAdded.Caption = "Prepped By";
            this.gcPAdded.FieldName = "gcPAdded";
            this.gcPAdded.Name = "gcPAdded";
            this.gcPAdded.OptionsColumn.ReadOnly = true;
            this.gcPAdded.Visible = true;
            this.gcPAdded.VisibleIndex = 5;
            // 
            // gcPDate
            // 
            this.gcPDate.Caption = "Date Prepped";
            this.gcPDate.FieldName = "gcPDate";
            this.gcPDate.Name = "gcPDate";
            this.gcPDate.OptionsColumn.ReadOnly = true;
            this.gcPDate.Visible = true;
            this.gcPDate.VisibleIndex = 6;
            // 
            // gcPManuf
            // 
            this.gcPManuf.Caption = "Manufacture";
            this.gcPManuf.FieldName = "gcPManuf";
            this.gcPManuf.Name = "gcPManuf";
            this.gcPManuf.Visible = true;
            this.gcPManuf.VisibleIndex = 7;
            // 
            // gcPEdit
            // 
            this.gcPEdit.Caption = "Edit";
            this.gcPEdit.FieldName = "gcPEdit";
            this.gcPEdit.Name = "gcPEdit";
            // 
            // gcPowderClose
            // 
            this.gcPowderClose.Caption = "Manually Close";
            this.gcPowderClose.FieldName = "gcPowderClose";
            this.gcPowderClose.Name = "gcPowderClose";
            this.gcPowderClose.Visible = true;
            this.gcPowderClose.VisibleIndex = 8;
            // 
            // xtpFS
            // 
            this.xtpFS.Controls.Add(this.panelControl3);
            this.xtpFS.Name = "xtpFS";
            this.xtpFS.Size = new System.Drawing.Size(1305, 698);
            this.xtpFS.Text = "Fresh Slurry Manufacture";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.dgFS);
            this.panelControl3.Controls.Add(this.btnRefreshFS);
            this.panelControl3.Location = new System.Drawing.Point(4, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1298, 691);
            this.panelControl3.TabIndex = 0;
            // 
            // dgFS
            // 
            this.dgFS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFS.Location = new System.Drawing.Point(6, 6);
            this.dgFS.MainView = this.gvFS;
            this.dgFS.Name = "dgFS";
            this.dgFS.Size = new System.Drawing.Size(1287, 623);
            this.dgFS.TabIndex = 93;
            this.dgFS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFS});
            // 
            // gvFS
            // 
            this.gvFS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcFSId,
            this.gcFSTrol,
            this.gcFSCode,
            this.gcFSLot,
            this.gcWetWeight,
            this.gcSolidity,
            this.gcDryWeight,
            this.gcFSUser,
            this.gcFSDate,
            this.gcFSManuf,
            this.gcFSEdit,
            this.gcClose});
            this.gvFS.GridControl = this.dgFS;
            this.gvFS.Name = "gvFS";
            this.gvFS.OptionsFind.AlwaysVisible = true;
            // 
            // gcFSId
            // 
            this.gcFSId.Caption = "ID";
            this.gcFSId.FieldName = "gcFSId";
            this.gcFSId.Name = "gcFSId";
            this.gcFSId.OptionsColumn.ReadOnly = true;
            this.gcFSId.Visible = true;
            this.gcFSId.VisibleIndex = 0;
            // 
            // gcFSTrol
            // 
            this.gcFSTrol.Caption = "Trolley";
            this.gcFSTrol.FieldName = "gcFSTrol";
            this.gcFSTrol.Name = "gcFSTrol";
            this.gcFSTrol.OptionsColumn.ReadOnly = true;
            this.gcFSTrol.Visible = true;
            this.gcFSTrol.VisibleIndex = 1;
            // 
            // gcFSCode
            // 
            this.gcFSCode.Caption = "Code";
            this.gcFSCode.FieldName = "gcFSCode";
            this.gcFSCode.Name = "gcFSCode";
            this.gcFSCode.OptionsColumn.ReadOnly = true;
            this.gcFSCode.Visible = true;
            this.gcFSCode.VisibleIndex = 2;
            // 
            // gcFSLot
            // 
            this.gcFSLot.Caption = "Lot Number";
            this.gcFSLot.FieldName = "gcFSLot";
            this.gcFSLot.Name = "gcFSLot";
            this.gcFSLot.OptionsColumn.ReadOnly = true;
            this.gcFSLot.Visible = true;
            this.gcFSLot.VisibleIndex = 3;
            // 
            // gcWetWeight
            // 
            this.gcWetWeight.Caption = "Wet Weight";
            this.gcWetWeight.FieldName = "gcWetWeight";
            this.gcWetWeight.Name = "gcWetWeight";
            this.gcWetWeight.OptionsColumn.ReadOnly = true;
            this.gcWetWeight.Visible = true;
            this.gcWetWeight.VisibleIndex = 4;
            // 
            // gcSolidity
            // 
            this.gcSolidity.Caption = "Solidity";
            this.gcSolidity.FieldName = "gcSolidity";
            this.gcSolidity.Name = "gcSolidity";
            this.gcSolidity.OptionsColumn.ReadOnly = true;
            this.gcSolidity.Visible = true;
            this.gcSolidity.VisibleIndex = 5;
            // 
            // gcDryWeight
            // 
            this.gcDryWeight.Caption = "Dry Weight";
            this.gcDryWeight.FieldName = "gcDryWeight";
            this.gcDryWeight.Name = "gcDryWeight";
            this.gcDryWeight.OptionsColumn.ReadOnly = true;
            this.gcDryWeight.Visible = true;
            this.gcDryWeight.VisibleIndex = 6;
            // 
            // gcFSUser
            // 
            this.gcFSUser.Caption = "Added By";
            this.gcFSUser.FieldName = "gcFSUser";
            this.gcFSUser.Name = "gcFSUser";
            this.gcFSUser.OptionsColumn.ReadOnly = true;
            this.gcFSUser.Visible = true;
            this.gcFSUser.VisibleIndex = 7;
            // 
            // gcFSDate
            // 
            this.gcFSDate.Caption = "Date Added";
            this.gcFSDate.FieldName = "gcFSDate";
            this.gcFSDate.Name = "gcFSDate";
            this.gcFSDate.OptionsColumn.ReadOnly = true;
            this.gcFSDate.Visible = true;
            this.gcFSDate.VisibleIndex = 8;
            // 
            // gcFSManuf
            // 
            this.gcFSManuf.Caption = "Manufacture";
            this.gcFSManuf.FieldName = "gcFSManuf";
            this.gcFSManuf.Name = "gcFSManuf";
            this.gcFSManuf.Visible = true;
            this.gcFSManuf.VisibleIndex = 9;
            // 
            // gcFSEdit
            // 
            this.gcFSEdit.Caption = "Edit";
            this.gcFSEdit.FieldName = "gcFSEdit";
            this.gcFSEdit.Name = "gcFSEdit";
            // 
            // gcClose
            // 
            this.gcClose.Caption = "Close";
            this.gcClose.FieldName = "gcClose";
            this.gcClose.Name = "gcClose";
            this.gcClose.Visible = true;
            this.gcClose.VisibleIndex = 10;
            // 
            // btnRefreshFS
            // 
            this.btnRefreshFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshFS.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefreshFS.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefreshFS.Appearance.Options.UseBackColor = true;
            this.btnRefreshFS.Appearance.Options.UseFont = true;
            this.btnRefreshFS.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshFS.Image")));
            this.btnRefreshFS.Location = new System.Drawing.Point(1124, 636);
            this.btnRefreshFS.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefreshFS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefreshFS.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshFS.Name = "btnRefreshFS";
            this.btnRefreshFS.Size = new System.Drawing.Size(168, 49);
            this.btnRefreshFS.TabIndex = 92;
            this.btnRefreshFS.Text = "Refresh";
            this.btnRefreshFS.Click += new System.EventHandler(this.btnRefreshFS_Click);
            // 
            // xtpMS
            // 
            this.xtpMS.Controls.Add(this.simpleButton1);
            this.xtpMS.Controls.Add(this.dgMixed);
            this.xtpMS.Name = "xtpMS";
            this.xtpMS.Size = new System.Drawing.Size(1305, 698);
            this.xtpMS.Text = "Mixed Slurry";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1133, 645);
            this.simpleButton1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(168, 49);
            this.simpleButton1.TabIndex = 93;
            this.simpleButton1.Text = "Refresh";
            // 
            // dgMixed
            // 
            this.dgMixed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMixed.Location = new System.Drawing.Point(4, 4);
            this.dgMixed.MainView = this.gvMixed;
            this.dgMixed.Name = "dgMixed";
            this.dgMixed.Size = new System.Drawing.Size(1297, 634);
            this.dgMixed.TabIndex = 0;
            this.dgMixed.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMixed});
            // 
            // gvMixed
            // 
            this.gvMixed.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMSManuf,
            this.gcMSID,
            this.gcMSTank,
            this.gcMSItem,
            this.gcMSDesc,
            this.gcMSLot,
            this.gcMSSlurries,
            this.gcMSDate});
            this.gvMixed.GridControl = this.dgMixed;
            this.gvMixed.Name = "gvMixed";
            this.gvMixed.OptionsFind.AlwaysVisible = true;
            // 
            // gcMSManuf
            // 
            this.gcMSManuf.Caption = "Manufacture";
            this.gcMSManuf.Name = "gcMSManuf";
            this.gcMSManuf.Visible = true;
            this.gcMSManuf.VisibleIndex = 0;
            // 
            // gcMSID
            // 
            this.gcMSID.Caption = "ID";
            this.gcMSID.FieldName = "MSID";
            this.gcMSID.Name = "gcMSID";
            this.gcMSID.OptionsColumn.ReadOnly = true;
            this.gcMSID.Visible = true;
            this.gcMSID.VisibleIndex = 1;
            // 
            // gcMSTank
            // 
            this.gcMSTank.Caption = "Tank";
            this.gcMSTank.FieldName = "MSTank";
            this.gcMSTank.Name = "gcMSTank";
            this.gcMSTank.OptionsColumn.ReadOnly = true;
            this.gcMSTank.Visible = true;
            this.gcMSTank.VisibleIndex = 2;
            // 
            // gcMSItem
            // 
            this.gcMSItem.Caption = "Item Code";
            this.gcMSItem.FieldName = "MSItem";
            this.gcMSItem.Name = "gcMSItem";
            this.gcMSItem.OptionsColumn.ReadOnly = true;
            this.gcMSItem.Visible = true;
            this.gcMSItem.VisibleIndex = 3;
            // 
            // gcMSDesc
            // 
            this.gcMSDesc.Caption = "Description";
            this.gcMSDesc.FieldName = "MSDesc";
            this.gcMSDesc.Name = "gcMSDesc";
            this.gcMSDesc.OptionsColumn.ReadOnly = true;
            this.gcMSDesc.Visible = true;
            this.gcMSDesc.VisibleIndex = 4;
            // 
            // gcMSLot
            // 
            this.gcMSLot.Caption = "Lot Number";
            this.gcMSLot.FieldName = "MSLot";
            this.gcMSLot.Name = "gcMSLot";
            this.gcMSLot.OptionsColumn.ReadOnly = true;
            this.gcMSLot.Visible = true;
            this.gcMSLot.VisibleIndex = 5;
            // 
            // gcMSSlurries
            // 
            this.gcMSSlurries.Caption = "Slurries Added";
            this.gcMSSlurries.FieldName = "MSSlurries";
            this.gcMSSlurries.Name = "gcMSSlurries";
            this.gcMSSlurries.OptionsColumn.ReadOnly = true;
            this.gcMSSlurries.Visible = true;
            this.gcMSSlurries.VisibleIndex = 6;
            // 
            // gcMSDate
            // 
            this.gcMSDate.Caption = "Date";
            this.gcMSDate.FieldName = "MSDate";
            this.gcMSDate.Name = "gcMSDate";
            this.gcMSDate.OptionsColumn.ReadOnly = true;
            this.gcMSDate.Visible = true;
            this.gcMSDate.VisibleIndex = 7;
            // 
            // xtpZect
            // 
            this.xtpZect.Controls.Add(this.panelControl4);
            this.xtpZect.Name = "xtpZect";
            this.xtpZect.Size = new System.Drawing.Size(1305, 698);
            this.xtpZect.Text = "ZECT Manufacture";
            // 
            // panelControl4
            // 
            this.panelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl4.Controls.Add(this.btnZRefresh);
            this.panelControl4.Controls.Add(this.dgZect);
            this.panelControl4.Location = new System.Drawing.Point(4, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1298, 691);
            this.panelControl4.TabIndex = 0;
            // 
            // btnZRefresh
            // 
            this.btnZRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnZRefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnZRefresh.Appearance.Options.UseBackColor = true;
            this.btnZRefresh.Appearance.Options.UseFont = true;
            this.btnZRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnZRefresh.Image")));
            this.btnZRefresh.Location = new System.Drawing.Point(1124, 636);
            this.btnZRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnZRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnZRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnZRefresh.Name = "btnZRefresh";
            this.btnZRefresh.Size = new System.Drawing.Size(168, 49);
            this.btnZRefresh.TabIndex = 93;
            this.btnZRefresh.Text = "Refresh";
            this.btnZRefresh.Click += new System.EventHandler(this.btnZRefresh_Click);
            // 
            // dgZect
            // 
            this.dgZect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgZect.Location = new System.Drawing.Point(6, 6);
            this.dgZect.MainView = this.gvZect;
            this.dgZect.Name = "dgZect";
            this.dgZect.Size = new System.Drawing.Size(1287, 623);
            this.dgZect.TabIndex = 0;
            this.dgZect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZect});
            // 
            // gvZect
            // 
            this.gvZect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcZID,
            this.gcJob,
            this.gcZCode,
            this.gcZLot,
            this.gcZQty,
            this.gcZProd,
            this.gcZManuf,
            this.gcCoat,
            this.gcZLine,
            this.gcZRun,
            this.gcZDate});
            this.gvZect.GridControl = this.dgZect;
            this.gvZect.Name = "gvZect";
            this.gvZect.OptionsFind.AlwaysVisible = true;
            this.gvZect.DoubleClick += new System.EventHandler(this.gvZect_DoubleClick);
            // 
            // gcZID
            // 
            this.gcZID.Caption = "ID";
            this.gcZID.FieldName = "gcZID";
            this.gcZID.Name = "gcZID";
            this.gcZID.OptionsColumn.AllowEdit = false;
            this.gcZID.Visible = true;
            this.gcZID.VisibleIndex = 0;
            // 
            // gcJob
            // 
            this.gcJob.Caption = "Job Code";
            this.gcJob.FieldName = "gcJob";
            this.gcJob.Name = "gcJob";
            this.gcJob.OptionsColumn.AllowEdit = false;
            // 
            // gcZCode
            // 
            this.gcZCode.Caption = "Item Code";
            this.gcZCode.FieldName = "gcZCode";
            this.gcZCode.Name = "gcZCode";
            this.gcZCode.OptionsColumn.AllowEdit = false;
            this.gcZCode.Visible = true;
            this.gcZCode.VisibleIndex = 1;
            // 
            // gcZLot
            // 
            this.gcZLot.Caption = "Lot Number";
            this.gcZLot.FieldName = "gcZLot";
            this.gcZLot.Name = "gcZLot";
            this.gcZLot.OptionsColumn.AllowEdit = false;
            this.gcZLot.Visible = true;
            this.gcZLot.VisibleIndex = 2;
            // 
            // gcZQty
            // 
            this.gcZQty.Caption = "Job Quantity";
            this.gcZQty.FieldName = "gcZQty";
            this.gcZQty.Name = "gcZQty";
            this.gcZQty.OptionsColumn.AllowEdit = false;
            this.gcZQty.Visible = true;
            this.gcZQty.VisibleIndex = 3;
            // 
            // gcZProd
            // 
            this.gcZProd.Caption = "Quantity Produced";
            this.gcZProd.FieldName = "gcZProd";
            this.gcZProd.Name = "gcZProd";
            this.gcZProd.OptionsColumn.AllowEdit = false;
            this.gcZProd.Visible = true;
            this.gcZProd.VisibleIndex = 4;
            // 
            // gcZManuf
            // 
            this.gcZManuf.Caption = "Quantity to Manufacture";
            this.gcZManuf.FieldName = "gcZManuf";
            this.gcZManuf.Name = "gcZManuf";
            this.gcZManuf.OptionsColumn.AllowEdit = false;
            this.gcZManuf.Visible = true;
            this.gcZManuf.VisibleIndex = 5;
            // 
            // gcCoat
            // 
            this.gcCoat.Caption = "Coat";
            this.gcCoat.FieldName = "gcCoat";
            this.gcCoat.Name = "gcCoat";
            this.gcCoat.OptionsColumn.AllowEdit = false;
            this.gcCoat.Visible = true;
            this.gcCoat.VisibleIndex = 6;
            // 
            // gcZLine
            // 
            this.gcZLine.Caption = "Zect Line";
            this.gcZLine.FieldName = "gcZLine";
            this.gcZLine.Name = "gcZLine";
            this.gcZLine.OptionsColumn.AllowEdit = false;
            this.gcZLine.Visible = true;
            this.gcZLine.VisibleIndex = 7;
            // 
            // gcZRun
            // 
            this.gcZRun.Caption = "Job Running";
            this.gcZRun.FieldName = "gcZRun";
            this.gcZRun.Name = "gcZRun";
            this.gcZRun.OptionsColumn.AllowEdit = false;
            this.gcZRun.Visible = true;
            this.gcZRun.VisibleIndex = 8;
            // 
            // gcZDate
            // 
            this.gcZDate.Caption = "Date Started";
            this.gcZDate.FieldName = "gcZDate";
            this.gcZDate.Name = "gcZDate";
            this.gcZDate.OptionsColumn.AllowFocus = false;
            this.gcZDate.Visible = true;
            this.gcZDate.VisibleIndex = 9;
            // 
            // xtpAW
            // 
            this.xtpAW.Controls.Add(this.panelControl5);
            this.xtpAW.Name = "xtpAW";
            this.xtpAW.Size = new System.Drawing.Size(1305, 698);
            this.xtpAW.Text = "AW Manufacturing";
            // 
            // panelControl5
            // 
            this.panelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl5.Controls.Add(this.dgAW);
            this.panelControl5.Controls.Add(this.btnARefresh);
            this.panelControl5.Location = new System.Drawing.Point(3, 4);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(1299, 691);
            this.panelControl5.TabIndex = 0;
            // 
            // dgAW
            // 
            this.dgAW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAW.Location = new System.Drawing.Point(6, 6);
            this.dgAW.MainView = this.gvAW;
            this.dgAW.Name = "dgAW";
            this.dgAW.Size = new System.Drawing.Size(1287, 623);
            this.dgAW.TabIndex = 95;
            this.dgAW.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAW});
            // 
            // gvAW
            // 
            this.gvAW.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcAID,
            this.gcAJobCode,
            this.gcACode,
            this.gcALot,
            this.gcAQty,
            this.gcAProc,
            this.gcAManuf,
            this.gcADate,
            this.gcAUserProduced,
            this.gcARun});
            this.gvAW.GridControl = this.dgAW;
            this.gvAW.Name = "gvAW";
            this.gvAW.OptionsFind.AlwaysVisible = true;
            this.gvAW.DoubleClick += new System.EventHandler(this.gvAW_DoubleClick);
            // 
            // gcAID
            // 
            this.gcAID.Caption = "ID";
            this.gcAID.FieldName = "gcAID";
            this.gcAID.Name = "gcAID";
            this.gcAID.OptionsColumn.AllowEdit = false;
            this.gcAID.Visible = true;
            this.gcAID.VisibleIndex = 0;
            // 
            // gcAJobCode
            // 
            this.gcAJobCode.Caption = "Job Code";
            this.gcAJobCode.FieldName = "gcAJobCode";
            this.gcAJobCode.Name = "gcAJobCode";
            this.gcAJobCode.OptionsColumn.AllowEdit = false;
            this.gcAJobCode.Visible = true;
            this.gcAJobCode.VisibleIndex = 1;
            // 
            // gcACode
            // 
            this.gcACode.Caption = "Item Code";
            this.gcACode.FieldName = "gcACode";
            this.gcACode.Name = "gcACode";
            this.gcACode.OptionsColumn.AllowEdit = false;
            this.gcACode.Visible = true;
            this.gcACode.VisibleIndex = 2;
            // 
            // gcALot
            // 
            this.gcALot.Caption = "Lot Number";
            this.gcALot.FieldName = "gcALot";
            this.gcALot.Name = "gcALot";
            this.gcALot.OptionsColumn.AllowEdit = false;
            this.gcALot.Visible = true;
            this.gcALot.VisibleIndex = 3;
            // 
            // gcAQty
            // 
            this.gcAQty.Caption = "Job Quantity";
            this.gcAQty.FieldName = "gcAQty";
            this.gcAQty.Name = "gcAQty";
            this.gcAQty.OptionsColumn.AllowEdit = false;
            this.gcAQty.Visible = true;
            this.gcAQty.VisibleIndex = 4;
            // 
            // gcAProc
            // 
            this.gcAProc.Caption = "Quantity Produced";
            this.gcAProc.FieldName = "gcAProc";
            this.gcAProc.Name = "gcAProc";
            this.gcAProc.OptionsColumn.AllowEdit = false;
            this.gcAProc.Visible = true;
            this.gcAProc.VisibleIndex = 5;
            // 
            // gcAManuf
            // 
            this.gcAManuf.Caption = "Quantity to Manufacture";
            this.gcAManuf.FieldName = "gcAManuf";
            this.gcAManuf.Name = "gcAManuf";
            this.gcAManuf.OptionsColumn.AllowEdit = false;
            this.gcAManuf.Visible = true;
            this.gcAManuf.VisibleIndex = 6;
            // 
            // gcADate
            // 
            this.gcADate.Caption = "Date Produced";
            this.gcADate.FieldName = "gcADate";
            this.gcADate.Name = "gcADate";
            this.gcADate.OptionsColumn.AllowEdit = false;
            this.gcADate.Visible = true;
            this.gcADate.VisibleIndex = 7;
            // 
            // gcAUserProduced
            // 
            this.gcAUserProduced.Caption = "Produced By";
            this.gcAUserProduced.FieldName = "gcAUserProduced";
            this.gcAUserProduced.Name = "gcAUserProduced";
            this.gcAUserProduced.OptionsColumn.AllowEdit = false;
            this.gcAUserProduced.Visible = true;
            this.gcAUserProduced.VisibleIndex = 8;
            // 
            // gcARun
            // 
            this.gcARun.Caption = "Job Running";
            this.gcARun.FieldName = "gcARun";
            this.gcARun.Name = "gcARun";
            this.gcARun.OptionsColumn.AllowEdit = false;
            this.gcARun.Visible = true;
            this.gcARun.VisibleIndex = 9;
            // 
            // btnARefresh
            // 
            this.btnARefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnARefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnARefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnARefresh.Appearance.Options.UseBackColor = true;
            this.btnARefresh.Appearance.Options.UseFont = true;
            this.btnARefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnARefresh.Image")));
            this.btnARefresh.Location = new System.Drawing.Point(1125, 636);
            this.btnARefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnARefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnARefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnARefresh.Name = "btnARefresh";
            this.btnARefresh.Size = new System.Drawing.Size(168, 49);
            this.btnARefresh.TabIndex = 94;
            this.btnARefresh.Text = "Refresh";
            this.btnARefresh.Click += new System.EventHandler(this.btnARefresh_Click);
            // 
            // xtpCanning
            // 
            this.xtpCanning.Controls.Add(this.btnCRefresh);
            this.xtpCanning.Controls.Add(this.panelControl6);
            this.xtpCanning.Name = "xtpCanning";
            this.xtpCanning.Size = new System.Drawing.Size(1305, 698);
            this.xtpCanning.Text = "Canning Manufacture";
            // 
            // btnCRefresh
            // 
            this.btnCRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCRefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnCRefresh.Appearance.Options.UseBackColor = true;
            this.btnCRefresh.Appearance.Options.UseFont = true;
            this.btnCRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnCRefresh.Image")));
            this.btnCRefresh.Location = new System.Drawing.Point(1133, 645);
            this.btnCRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnCRefresh.Name = "btnCRefresh";
            this.btnCRefresh.Size = new System.Drawing.Size(168, 49);
            this.btnCRefresh.TabIndex = 95;
            this.btnCRefresh.Text = "Refresh";
            this.btnCRefresh.Click += new System.EventHandler(this.btnCRefresh_Click);
            // 
            // panelControl6
            // 
            this.panelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl6.Controls.Add(this.dgCanning);
            this.panelControl6.Location = new System.Drawing.Point(4, 4);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(1297, 634);
            this.panelControl6.TabIndex = 0;
            // 
            // dgCanning
            // 
            this.dgCanning.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCanning.Location = new System.Drawing.Point(6, 6);
            this.dgCanning.MainView = this.gvCanning;
            this.dgCanning.Name = "dgCanning";
            this.dgCanning.Size = new System.Drawing.Size(1286, 623);
            this.dgCanning.TabIndex = 0;
            this.dgCanning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCanning});
            // 
            // gvCanning
            // 
            this.gvCanning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCID,
            this.gcCCode,
            this.gcCDesc,
            this.gcCLot,
            this.gcCQty,
            this.gcCUser,
            this.gcCDate,
            this.gcCManuf,
            this.gcCanClose});
            this.gvCanning.GridControl = this.dgCanning;
            this.gvCanning.Name = "gvCanning";
            this.gvCanning.OptionsFind.AlwaysVisible = true;
            // 
            // gcCID
            // 
            this.gcCID.Caption = "ID";
            this.gcCID.FieldName = "gcCID";
            this.gcCID.Name = "gcCID";
            this.gcCID.OptionsColumn.AllowEdit = false;
            this.gcCID.Visible = true;
            this.gcCID.VisibleIndex = 0;
            // 
            // gcCCode
            // 
            this.gcCCode.Caption = "Code";
            this.gcCCode.FieldName = "gcCCode";
            this.gcCCode.Name = "gcCCode";
            this.gcCCode.OptionsColumn.AllowEdit = false;
            this.gcCCode.Visible = true;
            this.gcCCode.VisibleIndex = 1;
            // 
            // gcCDesc
            // 
            this.gcCDesc.Caption = "Description";
            this.gcCDesc.FieldName = "gcCDesc";
            this.gcCDesc.Name = "gcCDesc";
            this.gcCDesc.OptionsColumn.AllowEdit = false;
            this.gcCDesc.Visible = true;
            this.gcCDesc.VisibleIndex = 2;
            // 
            // gcCLot
            // 
            this.gcCLot.Caption = "Lot Number";
            this.gcCLot.FieldName = "gcCLot";
            this.gcCLot.Name = "gcCLot";
            this.gcCLot.OptionsColumn.AllowEdit = false;
            this.gcCLot.Visible = true;
            this.gcCLot.VisibleIndex = 3;
            // 
            // gcCQty
            // 
            this.gcCQty.Caption = "Quantity";
            this.gcCQty.FieldName = "gcCQty";
            this.gcCQty.Name = "gcCQty";
            this.gcCQty.OptionsColumn.AllowEdit = false;
            this.gcCQty.Visible = true;
            this.gcCQty.VisibleIndex = 4;
            // 
            // gcCUser
            // 
            this.gcCUser.Caption = "Added By";
            this.gcCUser.FieldName = "gcCUser";
            this.gcCUser.Name = "gcCUser";
            this.gcCUser.OptionsColumn.AllowEdit = false;
            this.gcCUser.Visible = true;
            this.gcCUser.VisibleIndex = 5;
            // 
            // gcCDate
            // 
            this.gcCDate.Caption = "Date Added";
            this.gcCDate.FieldName = "gcCDate";
            this.gcCDate.Name = "gcCDate";
            this.gcCDate.OptionsColumn.AllowEdit = false;
            this.gcCDate.Visible = true;
            this.gcCDate.VisibleIndex = 6;
            // 
            // gcCManuf
            // 
            this.gcCManuf.Caption = "Manufacture";
            this.gcCManuf.FieldName = "gcCManuf";
            this.gcCManuf.Name = "gcCManuf";
            this.gcCManuf.Visible = true;
            this.gcCManuf.VisibleIndex = 7;
            // 
            // btnConfigure
            // 
            this.btnConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigure.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnConfigure.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnConfigure.Appearance.Options.UseBackColor = true;
            this.btnConfigure.Appearance.Options.UseFont = true;
            this.btnConfigure.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigure.Image")));
            this.btnConfigure.Location = new System.Drawing.Point(1112, 4);
            this.btnConfigure.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnConfigure.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(203, 49);
            this.btnConfigure.TabIndex = 92;
            this.btnConfigure.Text = "Configure Locations";
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // gcCanClose
            // 
            this.gcCanClose.Caption = "Manually Close";
            this.gcCanClose.FieldName = "gcCanClose";
            this.gcCanClose.Name = "gcCanClose";
            this.gcCanClose.Visible = true;
            this.gcCanClose.VisibleIndex = 8;
            // 
            // ucPGMManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.xtcManuf);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucPGMManufacture";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucPGMManufacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcManuf)).EndInit();
            this.xtcManuf.ResumeLayout(false);
            this.xtpPGM.ResumeLayout(false);
            this.xtpPowder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPowders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowders)).EndInit();
            this.xtpFS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFS)).EndInit();
            this.xtpMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMixed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMixed)).EndInit();
            this.xtpZect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgZect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZect)).EndInit();
            this.xtpAW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAW)).EndInit();
            this.xtpCanning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCanning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gcConcentration;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraTab.XtraTabControl xtcManuf;
        private DevExpress.XtraTab.XtraTabPage xtpPGM;
        private DevExpress.XtraTab.XtraTabPage xtpPowder;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRefreshP;
        private DevExpress.XtraGrid.GridControl dgPowders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPowders;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcPCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcPLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcPQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcPAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcPDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcPEdit;
        private DevExpress.XtraTab.XtraTabPage xtpFS;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dgFS;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFS;
        private DevExpress.XtraEditors.SimpleButton btnRefreshFS;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSId;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSTrol;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcWetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcSolidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcDryWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcFSEdit;
        private DevExpress.XtraTab.XtraTabPage xtpZect;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnZRefresh;
        private DevExpress.XtraGrid.GridControl dgZect;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZect;
        private DevExpress.XtraGrid.Columns.GridColumn gcJob;
        private DevExpress.XtraGrid.Columns.GridColumn gcZCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcZLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcZQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcZProd;
        private DevExpress.XtraGrid.Columns.GridColumn gcZManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcCoat;
        private DevExpress.XtraGrid.Columns.GridColumn gcZLine;
        private DevExpress.XtraGrid.Columns.GridColumn gcZRun;
        private DevExpress.XtraGrid.Columns.GridColumn gcZDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcZID;
        private DevExpress.XtraTab.XtraTabPage xtpAW;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraGrid.GridControl dgAW;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAW;
        private DevExpress.XtraEditors.SimpleButton btnARefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gcAID;
        private DevExpress.XtraGrid.Columns.GridColumn gcAJobCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcACode;
        private DevExpress.XtraGrid.Columns.GridColumn gcALot;
        private DevExpress.XtraGrid.Columns.GridColumn gcAQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcAProc;
        private DevExpress.XtraGrid.Columns.GridColumn gcAManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcADate;
        private DevExpress.XtraGrid.Columns.GridColumn gcAUserProduced;
        private DevExpress.XtraGrid.Columns.GridColumn gcARun;
        private DevExpress.XtraTab.XtraTabPage xtpCanning;
        private DevExpress.XtraEditors.SimpleButton btnCRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraGrid.GridControl dgCanning;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCanning;
        private DevExpress.XtraGrid.Columns.GridColumn gcCID;
        private DevExpress.XtraGrid.Columns.GridColumn gcCCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcCDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcCLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcCQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcCUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcCDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcClose;
        private DevExpress.XtraEditors.SimpleButton btnConfigure;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemCap;
        private DevExpress.XtraGrid.Columns.GridColumn gcRem;
        private DevExpress.XtraTab.XtraTabPage xtpMS;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl dgMixed;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMixed;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSID;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSTank;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSSlurries;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcMSManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcPowderClose;
        private DevExpress.XtraGrid.Columns.GridColumn gcCanClose;
    }
}
