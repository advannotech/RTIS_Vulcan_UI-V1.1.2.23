namespace RTIS_Vulcan_UI
{
    partial class ucPGMPlanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPGMPlanning));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dgProcess = new DevExpress.XtraGrid.GridControl();
            this.gvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCatalystCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPowderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPGMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.dgSelectPGM = new DevExpress.XtraGrid.GridControl();
            this.gvSelectPGM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEvoIDPGM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPGMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPGMDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelectedPGM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgSelectCSP = new DevExpress.XtraGrid.GridControl();
            this.gvSelectCSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEvoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoCatalystCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoCatalystDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPowderCodeCSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPowderDescCSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelectedCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectPGM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectPGM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectCSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectCSP)).BeginInit();
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
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(132, 44);
            this.lblHeader.TabIndex = 31;
            this.lblHeader.Text = "PGM RM";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.pnlSearch);
            this.panelControl1.Controls.Add(this.dgProcess);
            this.panelControl1.Controls.Add(this.ppnlWait);
            this.panelControl1.Controls.Add(this.dgSelectPGM);
            this.panelControl1.Controls.Add(this.dgSelectCSP);
            this.panelControl1.Location = new System.Drawing.Point(5, 57);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1475, 734);
            this.panelControl1.TabIndex = 32;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.gbSearch);
            this.pnlSearch.Location = new System.Drawing.Point(8, 6);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1452, 92);
            this.pnlSearch.TabIndex = 20;
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.Controls.Add(this.btnAdd);
            this.gbSearch.Controls.Add(this.btnEdit);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.cmbProcess);
            this.gbSearch.Controls.Add(this.labelControl9);
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1452, 92);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.Text = "Search Options";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(1035, 30);
            this.btnAdd.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(168, 49);
            this.btnAdd.TabIndex = 88;
            this.btnAdd.Text = "Add New";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(1211, 30);
            this.btnEdit.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(168, 49);
            this.btnEdit.TabIndex = 89;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1387, 30);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 49);
            this.btnSearch.TabIndex = 87;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbProcess
            // 
            this.cmbProcess.Location = new System.Drawing.Point(17, 52);
            this.cmbProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProcess.Size = new System.Drawing.Size(292, 22);
            this.cmbProcess.TabIndex = 40;
            this.cmbProcess.SelectedIndexChanged += new System.EventHandler(this.cmbProcess_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(17, 28);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(117, 16);
            this.labelControl9.TabIndex = 39;
            this.labelControl9.Text = "Select PGM Process:";
            // 
            // dgProcess
            // 
            this.dgProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProcess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgProcess.Location = new System.Drawing.Point(8, 106);
            this.dgProcess.MainView = this.gvProcess;
            this.dgProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgProcess.Name = "dgProcess";
            this.dgProcess.Size = new System.Drawing.Size(1460, 622);
            this.dgProcess.TabIndex = 0;
            this.dgProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProcess});
            this.dgProcess.Click += new System.EventHandler(this.dgProcess_Click);
            // 
            // gvProcess
            // 
            this.gvProcess.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcCatalystCode,
            this.gcSlurryCode,
            this.gcPowderCode,
            this.gcPGMCode,
            this.gcDateAdd,
            this.gcUserAdd,
            this.gcDateEdit,
            this.gcUserEdit});
            this.gvProcess.DetailHeight = 431;
            this.gvProcess.GridControl = this.dgProcess;
            this.gvProcess.Name = "gvProcess";
            this.gvProcess.OptionsFind.AlwaysVisible = true;
            this.gvProcess.OptionsView.ColumnAutoWidth = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.MinWidth = 27;
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.Width = 80;
            // 
            // gcCatalystCode
            // 
            this.gcCatalystCode.Caption = "Catalyst Code";
            this.gcCatalystCode.FieldName = "gcCatalystCode";
            this.gcCatalystCode.MinWidth = 27;
            this.gcCatalystCode.Name = "gcCatalystCode";
            this.gcCatalystCode.OptionsColumn.AllowEdit = false;
            this.gcCatalystCode.Visible = true;
            this.gcCatalystCode.VisibleIndex = 0;
            this.gcCatalystCode.Width = 200;
            // 
            // gcSlurryCode
            // 
            this.gcSlurryCode.Caption = "Slurry Code";
            this.gcSlurryCode.FieldName = "gcSlurryCode";
            this.gcSlurryCode.MinWidth = 27;
            this.gcSlurryCode.Name = "gcSlurryCode";
            this.gcSlurryCode.OptionsColumn.AllowEdit = false;
            this.gcSlurryCode.Visible = true;
            this.gcSlurryCode.VisibleIndex = 1;
            this.gcSlurryCode.Width = 160;
            // 
            // gcPowderCode
            // 
            this.gcPowderCode.Caption = "Powder Code";
            this.gcPowderCode.FieldName = "gcPowderCode";
            this.gcPowderCode.MinWidth = 27;
            this.gcPowderCode.Name = "gcPowderCode";
            this.gcPowderCode.OptionsColumn.AllowEdit = false;
            this.gcPowderCode.Visible = true;
            this.gcPowderCode.VisibleIndex = 2;
            this.gcPowderCode.Width = 200;
            // 
            // gcPGMCode
            // 
            this.gcPGMCode.Caption = "PGM Code";
            this.gcPGMCode.FieldName = "gcPGMCode";
            this.gcPGMCode.MinWidth = 27;
            this.gcPGMCode.Name = "gcPGMCode";
            this.gcPGMCode.OptionsColumn.AllowEdit = false;
            this.gcPGMCode.Visible = true;
            this.gcPGMCode.VisibleIndex = 3;
            this.gcPGMCode.Width = 133;
            // 
            // gcDateAdd
            // 
            this.gcDateAdd.Caption = "Date Added";
            this.gcDateAdd.FieldName = "gcDateAdd";
            this.gcDateAdd.MinWidth = 27;
            this.gcDateAdd.Name = "gcDateAdd";
            this.gcDateAdd.OptionsColumn.AllowEdit = false;
            this.gcDateAdd.Visible = true;
            this.gcDateAdd.VisibleIndex = 4;
            this.gcDateAdd.Width = 187;
            // 
            // gcUserAdd
            // 
            this.gcUserAdd.Caption = "User Added";
            this.gcUserAdd.FieldName = "gcUserAdd";
            this.gcUserAdd.MinWidth = 27;
            this.gcUserAdd.Name = "gcUserAdd";
            this.gcUserAdd.OptionsColumn.AllowEdit = false;
            this.gcUserAdd.Visible = true;
            this.gcUserAdd.VisibleIndex = 5;
            this.gcUserAdd.Width = 160;
            // 
            // gcDateEdit
            // 
            this.gcDateEdit.Caption = "Date Edited";
            this.gcDateEdit.FieldName = "gcDateEdit";
            this.gcDateEdit.MinWidth = 27;
            this.gcDateEdit.Name = "gcDateEdit";
            this.gcDateEdit.OptionsColumn.AllowEdit = false;
            this.gcDateEdit.Visible = true;
            this.gcDateEdit.VisibleIndex = 6;
            this.gcDateEdit.Width = 187;
            // 
            // gcUserEdit
            // 
            this.gcUserEdit.Caption = "User Edited";
            this.gcUserEdit.FieldName = "gcUserEdit";
            this.gcUserEdit.MinWidth = 27;
            this.gcUserEdit.Name = "gcUserEdit";
            this.gcUserEdit.OptionsColumn.AllowEdit = false;
            this.gcUserEdit.Visible = true;
            this.gcUserEdit.VisibleIndex = 7;
            this.gcUserEdit.Width = 160;
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Appearance.Options.UseTextOptions = true;
            this.ppnlWait.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ppnlWait.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ppnlWait.AppearanceCaption.Options.UseTextOptions = true;
            this.ppnlWait.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ppnlWait.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ppnlWait.AppearanceDescription.Options.UseTextOptions = true;
            this.ppnlWait.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ppnlWait.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ppnlWait.Location = new System.Drawing.Point(8, 6);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1460, 721);
            this.ppnlWait.TabIndex = 33;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // dgSelectPGM
            // 
            this.dgSelectPGM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelectPGM.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgSelectPGM.Location = new System.Drawing.Point(7, 10);
            this.dgSelectPGM.MainView = this.gvSelectPGM;
            this.dgSelectPGM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgSelectPGM.Name = "dgSelectPGM";
            this.dgSelectPGM.Size = new System.Drawing.Size(1460, 718);
            this.dgSelectPGM.TabIndex = 43;
            this.dgSelectPGM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectPGM});
            this.dgSelectPGM.Visible = false;
            // 
            // gvSelectPGM
            // 
            this.gvSelectPGM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEvoIDPGM,
            this.gcEvoPGMCode,
            this.gcEvoPGMDesc,
            this.gcSelectedPGM});
            this.gvSelectPGM.DetailHeight = 431;
            this.gvSelectPGM.GridControl = this.dgSelectPGM;
            this.gvSelectPGM.Name = "gvSelectPGM";
            this.gvSelectPGM.OptionsFind.AlwaysVisible = true;
            this.gvSelectPGM.OptionsView.ColumnAutoWidth = false;
            // 
            // gcEvoIDPGM
            // 
            this.gcEvoIDPGM.Caption = "ID";
            this.gcEvoIDPGM.FieldName = "gcEvoIDPGM";
            this.gcEvoIDPGM.MinWidth = 27;
            this.gcEvoIDPGM.Name = "gcEvoIDPGM";
            this.gcEvoIDPGM.OptionsColumn.AllowEdit = false;
            this.gcEvoIDPGM.Visible = true;
            this.gcEvoIDPGM.VisibleIndex = 0;
            this.gcEvoIDPGM.Width = 80;
            // 
            // gcEvoPGMCode
            // 
            this.gcEvoPGMCode.Caption = "PGM Code";
            this.gcEvoPGMCode.FieldName = "gcEvoPGMCode";
            this.gcEvoPGMCode.MinWidth = 27;
            this.gcEvoPGMCode.Name = "gcEvoPGMCode";
            this.gcEvoPGMCode.OptionsColumn.AllowEdit = false;
            this.gcEvoPGMCode.Visible = true;
            this.gcEvoPGMCode.VisibleIndex = 1;
            this.gcEvoPGMCode.Width = 240;
            // 
            // gcEvoPGMDesc
            // 
            this.gcEvoPGMDesc.Caption = "PGM Description";
            this.gcEvoPGMDesc.FieldName = "gcEvoPGMDesc";
            this.gcEvoPGMDesc.MinWidth = 27;
            this.gcEvoPGMDesc.Name = "gcEvoPGMDesc";
            this.gcEvoPGMDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoPGMDesc.Visible = true;
            this.gcEvoPGMDesc.VisibleIndex = 2;
            this.gcEvoPGMDesc.Width = 293;
            // 
            // gcSelectedPGM
            // 
            this.gcSelectedPGM.Caption = "Select";
            this.gcSelectedPGM.FieldName = "gcSelectedPGM";
            this.gcSelectedPGM.MinWidth = 27;
            this.gcSelectedPGM.Name = "gcSelectedPGM";
            this.gcSelectedPGM.Visible = true;
            this.gcSelectedPGM.VisibleIndex = 3;
            this.gcSelectedPGM.Width = 160;
            // 
            // dgSelectCSP
            // 
            this.dgSelectCSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelectCSP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgSelectCSP.Location = new System.Drawing.Point(8, 7);
            this.dgSelectCSP.MainView = this.gvSelectCSP;
            this.dgSelectCSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgSelectCSP.Name = "dgSelectCSP";
            this.dgSelectCSP.Size = new System.Drawing.Size(1457, 726);
            this.dgSelectCSP.TabIndex = 42;
            this.dgSelectCSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectCSP});
            this.dgSelectCSP.Visible = false;
            // 
            // gvSelectCSP
            // 
            this.gvSelectCSP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEvoID,
            this.gcEvoCatalystCode,
            this.gcEvoCatalystDesc,
            this.gcEvoSlurryCode,
            this.gcEvoSlurryDesc,
            this.gcEvoPowderCodeCSP,
            this.gcEvoPowderDescCSP,
            this.gcSelectedCS});
            this.gvSelectCSP.DetailHeight = 431;
            this.gvSelectCSP.GridControl = this.dgSelectCSP;
            this.gvSelectCSP.Name = "gvSelectCSP";
            this.gvSelectCSP.OptionsFind.AlwaysVisible = true;
            this.gvSelectCSP.OptionsView.ColumnAutoWidth = false;
            // 
            // gcEvoID
            // 
            this.gcEvoID.Caption = "ID";
            this.gcEvoID.FieldName = "gcEvoID";
            this.gcEvoID.MinWidth = 27;
            this.gcEvoID.Name = "gcEvoID";
            this.gcEvoID.OptionsColumn.AllowEdit = false;
            this.gcEvoID.Visible = true;
            this.gcEvoID.VisibleIndex = 0;
            this.gcEvoID.Width = 80;
            // 
            // gcEvoCatalystCode
            // 
            this.gcEvoCatalystCode.Caption = "Catalyst Code";
            this.gcEvoCatalystCode.FieldName = "gcEvoCatalystCode";
            this.gcEvoCatalystCode.MinWidth = 27;
            this.gcEvoCatalystCode.Name = "gcEvoCatalystCode";
            this.gcEvoCatalystCode.OptionsColumn.AllowEdit = false;
            this.gcEvoCatalystCode.Visible = true;
            this.gcEvoCatalystCode.VisibleIndex = 1;
            this.gcEvoCatalystCode.Width = 240;
            // 
            // gcEvoCatalystDesc
            // 
            this.gcEvoCatalystDesc.Caption = "Catalyst Description";
            this.gcEvoCatalystDesc.FieldName = "gcEvoCatalystDesc";
            this.gcEvoCatalystDesc.MinWidth = 27;
            this.gcEvoCatalystDesc.Name = "gcEvoCatalystDesc";
            this.gcEvoCatalystDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoCatalystDesc.Visible = true;
            this.gcEvoCatalystDesc.VisibleIndex = 2;
            this.gcEvoCatalystDesc.Width = 293;
            // 
            // gcEvoSlurryCode
            // 
            this.gcEvoSlurryCode.Caption = "Slurry Code";
            this.gcEvoSlurryCode.FieldName = "gcEvoSlurryCode";
            this.gcEvoSlurryCode.MinWidth = 27;
            this.gcEvoSlurryCode.Name = "gcEvoSlurryCode";
            this.gcEvoSlurryCode.OptionsColumn.AllowEdit = false;
            this.gcEvoSlurryCode.Visible = true;
            this.gcEvoSlurryCode.VisibleIndex = 3;
            this.gcEvoSlurryCode.Width = 240;
            // 
            // gcEvoSlurryDesc
            // 
            this.gcEvoSlurryDesc.Caption = "Slurry Description";
            this.gcEvoSlurryDesc.FieldName = "gcEvoSlurryDesc";
            this.gcEvoSlurryDesc.MinWidth = 27;
            this.gcEvoSlurryDesc.Name = "gcEvoSlurryDesc";
            this.gcEvoSlurryDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoSlurryDesc.Visible = true;
            this.gcEvoSlurryDesc.VisibleIndex = 4;
            this.gcEvoSlurryDesc.Width = 293;
            // 
            // gcEvoPowderCodeCSP
            // 
            this.gcEvoPowderCodeCSP.Caption = "Powder Code";
            this.gcEvoPowderCodeCSP.FieldName = "gcEvoPowderCodeCSP";
            this.gcEvoPowderCodeCSP.MinWidth = 27;
            this.gcEvoPowderCodeCSP.Name = "gcEvoPowderCodeCSP";
            this.gcEvoPowderCodeCSP.Visible = true;
            this.gcEvoPowderCodeCSP.VisibleIndex = 5;
            this.gcEvoPowderCodeCSP.Width = 240;
            // 
            // gcEvoPowderDescCSP
            // 
            this.gcEvoPowderDescCSP.Caption = "Powder Description";
            this.gcEvoPowderDescCSP.FieldName = "gcEvoPowderDescCSP";
            this.gcEvoPowderDescCSP.MinWidth = 27;
            this.gcEvoPowderDescCSP.Name = "gcEvoPowderDescCSP";
            this.gcEvoPowderDescCSP.Visible = true;
            this.gcEvoPowderDescCSP.VisibleIndex = 6;
            this.gcEvoPowderDescCSP.Width = 293;
            // 
            // gcSelectedCS
            // 
            this.gcSelectedCS.Caption = "Select";
            this.gcSelectedCS.FieldName = "gcSelectedCS";
            this.gcSelectedCS.MinWidth = 27;
            this.gcSelectedCS.Name = "gcSelectedCS";
            this.gcSelectedCS.Visible = true;
            this.gcSelectedCS.VisibleIndex = 7;
            this.gcSelectedCS.Width = 160;
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucPGMPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucPGMPlanning";
            this.Size = new System.Drawing.Size(1484, 794);
            this.Load += new System.EventHandler(this.ucPGMPlanning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectPGM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectPGM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectCSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectCSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProcess;
        private System.Windows.Forms.Panel pnlSearch;
        private DevExpress.XtraEditors.GroupControl gbSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProcess;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPowderCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateAdd;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcPGMCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEdit;
        private DevExpress.XtraGrid.GridControl dgSelectCSP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectCSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoID;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectedCS;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoCatalystCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoCatalystDesc;
        private DevExpress.XtraGrid.GridControl dgSelectPGM;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectPGM;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoIDPGM;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPGMCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPGMDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectedPGM;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatalystCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPowderCodeCSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPowderDescCSP;
    }
}
