namespace RTIS_Vulcan_UI
{
    partial class ucProductionPlanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProductionPlanning));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.radFourth = new System.Windows.Forms.RadioButton();
            this.radThird = new System.Windows.Forms.RadioButton();
            this.radSecond = new System.Windows.Forms.RadioButton();
            this.radFirst = new System.Windows.Forms.RadioButton();
            this.lblOptionsHeader = new DevExpress.XtraEditors.LabelControl();
            this.dgProcess = new DevExpress.XtraGrid.GridControl();
            this.gvProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAWCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCatalystCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPowderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCoatNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.dgSelectSP = new DevExpress.XtraGrid.GridControl();
            this.gvSelectSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEvoIDSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryCodeSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryDescSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPowderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoPowderDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoAWCatalystCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoAWCatalystDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelectedSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgSelectCS = new DevExpress.XtraGrid.GridControl();
            this.gvSelectCS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcEvoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoCatalystCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoCatalystDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoSlurryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoAWCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoAWDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelectedCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectCS)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(221, 44);
            this.lblHeader.TabIndex = 31;
            this.lblHeader.Text = "Production RM";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.pnlSearch);
            this.panelControl1.Controls.Add(this.pnlOptions);
            this.panelControl1.Controls.Add(this.dgProcess);
            this.panelControl1.Controls.Add(this.ppnlWait);
            this.panelControl1.Controls.Add(this.dgSelectSP);
            this.panelControl1.Controls.Add(this.dgSelectCS);
            this.panelControl1.Location = new System.Drawing.Point(5, 57);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
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
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
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
            this.gbSearch.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 49);
            this.btnSearch.TabIndex = 87;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbProcess
            // 
            this.cmbProcess.Location = new System.Drawing.Point(17, 52);
            this.cmbProcess.Margin = new System.Windows.Forms.Padding(4);
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
            this.labelControl9.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(152, 16);
            this.labelControl9.TabIndex = 39;
            this.labelControl9.Text = "Select Production Process:";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.Controls.Add(this.radFourth);
            this.pnlOptions.Controls.Add(this.radThird);
            this.pnlOptions.Controls.Add(this.radSecond);
            this.pnlOptions.Controls.Add(this.radFirst);
            this.pnlOptions.Controls.Add(this.lblOptionsHeader);
            this.pnlOptions.Location = new System.Drawing.Point(8, 6);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1452, 92);
            this.pnlOptions.TabIndex = 44;
            // 
            // radFourth
            // 
            this.radFourth.AutoSize = true;
            this.radFourth.Location = new System.Drawing.Point(829, 62);
            this.radFourth.Margin = new System.Windows.Forms.Padding(4);
            this.radFourth.Name = "radFourth";
            this.radFourth.Size = new System.Drawing.Size(83, 21);
            this.radFourth.TabIndex = 36;
            this.radFourth.TabStop = true;
            this.radFourth.Text = "4th Coat";
            this.radFourth.UseVisualStyleBackColor = true;
            this.radFourth.CheckedChanged += new System.EventHandler(this.radFourth_CheckedChanged);
            // 
            // radThird
            // 
            this.radThird.AutoSize = true;
            this.radThird.Location = new System.Drawing.Point(548, 62);
            this.radThird.Margin = new System.Windows.Forms.Padding(4);
            this.radThird.Name = "radThird";
            this.radThird.Size = new System.Drawing.Size(83, 21);
            this.radThird.TabIndex = 35;
            this.radThird.TabStop = true;
            this.radThird.Text = "3rd Coat";
            this.radThird.UseVisualStyleBackColor = true;
            this.radThird.CheckedChanged += new System.EventHandler(this.radThird_CheckedChanged);
            // 
            // radSecond
            // 
            this.radSecond.AutoSize = true;
            this.radSecond.Location = new System.Drawing.Point(829, 37);
            this.radSecond.Margin = new System.Windows.Forms.Padding(4);
            this.radSecond.Name = "radSecond";
            this.radSecond.Size = new System.Drawing.Size(86, 21);
            this.radSecond.TabIndex = 34;
            this.radSecond.TabStop = true;
            this.radSecond.Text = "2nd Coat";
            this.radSecond.UseVisualStyleBackColor = true;
            this.radSecond.CheckedChanged += new System.EventHandler(this.radSecond_CheckedChanged);
            // 
            // radFirst
            // 
            this.radFirst.AutoSize = true;
            this.radFirst.Location = new System.Drawing.Point(548, 37);
            this.radFirst.Margin = new System.Windows.Forms.Padding(4);
            this.radFirst.Name = "radFirst";
            this.radFirst.Size = new System.Drawing.Size(81, 21);
            this.radFirst.TabIndex = 33;
            this.radFirst.TabStop = true;
            this.radFirst.Text = "1st Coat";
            this.radFirst.UseVisualStyleBackColor = true;
            this.radFirst.CheckedChanged += new System.EventHandler(this.radFirst_CheckedChanged);
            // 
            // lblOptionsHeader
            // 
            this.lblOptionsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOptionsHeader.Appearance.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionsHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblOptionsHeader.Appearance.Options.UseFont = true;
            this.lblOptionsHeader.Appearance.Options.UseForeColor = true;
            this.lblOptionsHeader.Location = new System.Drawing.Point(475, 4);
            this.lblOptionsHeader.Margin = new System.Windows.Forms.Padding(4);
            this.lblOptionsHeader.Name = "lblOptionsHeader";
            this.lblOptionsHeader.Size = new System.Drawing.Size(483, 28);
            this.lblOptionsHeader.TabIndex = 32;
            this.lblOptionsHeader.Text = "ZECT Manufacture - Please select a production coat:";
            // 
            // dgProcess
            // 
            this.dgProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProcess.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgProcess.Location = new System.Drawing.Point(8, 106);
            this.dgProcess.MainView = this.gvProcess;
            this.dgProcess.Margin = new System.Windows.Forms.Padding(4);
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
            this.gcAWCode,
            this.gcCatalystCode,
            this.gcSlurryCode,
            this.gcPowderCode,
            this.gcCoatNum,
            this.gcDateAdd,
            this.gcUserAdd,
            this.gcDateEdit,
            this.gcUserEdit});
            this.gvProcess.GridControl = this.dgProcess;
            this.gvProcess.Name = "gvProcess";
            this.gvProcess.OptionsFind.AlwaysVisible = true;
            this.gvProcess.OptionsView.ColumnAutoWidth = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.Width = 60;
            // 
            // gcAWCode
            // 
            this.gcAWCode.Caption = "A&W Code";
            this.gcAWCode.FieldName = "gcAWCode";
            this.gcAWCode.Name = "gcAWCode";
            this.gcAWCode.OptionsColumn.AllowEdit = false;
            this.gcAWCode.Visible = true;
            this.gcAWCode.VisibleIndex = 8;
            // 
            // gcCatalystCode
            // 
            this.gcCatalystCode.Caption = "Catalyst Code";
            this.gcCatalystCode.FieldName = "gcCatalystCode";
            this.gcCatalystCode.Name = "gcCatalystCode";
            this.gcCatalystCode.OptionsColumn.AllowEdit = false;
            this.gcCatalystCode.Visible = true;
            this.gcCatalystCode.VisibleIndex = 0;
            this.gcCatalystCode.Width = 150;
            // 
            // gcSlurryCode
            // 
            this.gcSlurryCode.Caption = "Slurry Code";
            this.gcSlurryCode.FieldName = "gcSlurryCode";
            this.gcSlurryCode.Name = "gcSlurryCode";
            this.gcSlurryCode.OptionsColumn.AllowEdit = false;
            this.gcSlurryCode.Visible = true;
            this.gcSlurryCode.VisibleIndex = 1;
            this.gcSlurryCode.Width = 120;
            // 
            // gcPowderCode
            // 
            this.gcPowderCode.Caption = "Powder Code";
            this.gcPowderCode.FieldName = "gcPowderCode";
            this.gcPowderCode.Name = "gcPowderCode";
            this.gcPowderCode.OptionsColumn.AllowEdit = false;
            this.gcPowderCode.Visible = true;
            this.gcPowderCode.VisibleIndex = 2;
            this.gcPowderCode.Width = 150;
            // 
            // gcCoatNum
            // 
            this.gcCoatNum.Caption = "Coat Num";
            this.gcCoatNum.FieldName = "gcCoatNum";
            this.gcCoatNum.Name = "gcCoatNum";
            this.gcCoatNum.OptionsColumn.AllowEdit = false;
            this.gcCoatNum.Visible = true;
            this.gcCoatNum.VisibleIndex = 3;
            this.gcCoatNum.Width = 100;
            // 
            // gcDateAdd
            // 
            this.gcDateAdd.Caption = "Date Added";
            this.gcDateAdd.FieldName = "gcDateAdd";
            this.gcDateAdd.Name = "gcDateAdd";
            this.gcDateAdd.OptionsColumn.AllowEdit = false;
            this.gcDateAdd.Visible = true;
            this.gcDateAdd.VisibleIndex = 4;
            this.gcDateAdd.Width = 140;
            // 
            // gcUserAdd
            // 
            this.gcUserAdd.Caption = "User Added";
            this.gcUserAdd.FieldName = "gcUserAdd";
            this.gcUserAdd.Name = "gcUserAdd";
            this.gcUserAdd.OptionsColumn.AllowEdit = false;
            this.gcUserAdd.Visible = true;
            this.gcUserAdd.VisibleIndex = 5;
            this.gcUserAdd.Width = 120;
            // 
            // gcDateEdit
            // 
            this.gcDateEdit.Caption = "Date Edited";
            this.gcDateEdit.FieldName = "gcDateEdit";
            this.gcDateEdit.Name = "gcDateEdit";
            this.gcDateEdit.OptionsColumn.AllowEdit = false;
            this.gcDateEdit.Visible = true;
            this.gcDateEdit.VisibleIndex = 6;
            this.gcDateEdit.Width = 140;
            // 
            // gcUserEdit
            // 
            this.gcUserEdit.Caption = "User Edited";
            this.gcUserEdit.FieldName = "gcUserEdit";
            this.gcUserEdit.Name = "gcUserEdit";
            this.gcUserEdit.OptionsColumn.AllowEdit = false;
            this.gcUserEdit.Visible = true;
            this.gcUserEdit.VisibleIndex = 7;
            this.gcUserEdit.Width = 120;
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
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1460, 721);
            this.ppnlWait.TabIndex = 33;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // dgSelectSP
            // 
            this.dgSelectSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelectSP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgSelectSP.Location = new System.Drawing.Point(7, 106);
            this.dgSelectSP.MainView = this.gvSelectSP;
            this.dgSelectSP.Margin = new System.Windows.Forms.Padding(4);
            this.dgSelectSP.Name = "dgSelectSP";
            this.dgSelectSP.Size = new System.Drawing.Size(1460, 622);
            this.dgSelectSP.TabIndex = 43;
            this.dgSelectSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectSP});
            this.dgSelectSP.Visible = false;
            // 
            // gvSelectSP
            // 
            this.gvSelectSP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEvoIDSP,
            this.gcEvoSlurryCodeSP,
            this.gcEvoSlurryDescSP,
            this.gcEvoPowderCode,
            this.gcEvoPowderDesc,
            this.gcEvoAWCatalystCode,
            this.gcEvoAWCatalystDesc,
            this.gcSelectedSP});
            this.gvSelectSP.GridControl = this.dgSelectSP;
            this.gvSelectSP.Name = "gvSelectSP";
            this.gvSelectSP.OptionsFind.AlwaysVisible = true;
            this.gvSelectSP.OptionsView.ColumnAutoWidth = false;
            // 
            // gcEvoIDSP
            // 
            this.gcEvoIDSP.Caption = "ID";
            this.gcEvoIDSP.FieldName = "gcEvoIDSP";
            this.gcEvoIDSP.Name = "gcEvoIDSP";
            this.gcEvoIDSP.OptionsColumn.AllowEdit = false;
            this.gcEvoIDSP.Visible = true;
            this.gcEvoIDSP.VisibleIndex = 0;
            this.gcEvoIDSP.Width = 60;
            // 
            // gcEvoSlurryCodeSP
            // 
            this.gcEvoSlurryCodeSP.Caption = "Slurry Code";
            this.gcEvoSlurryCodeSP.FieldName = "gcEvoSlurryCodeSP";
            this.gcEvoSlurryCodeSP.Name = "gcEvoSlurryCodeSP";
            this.gcEvoSlurryCodeSP.Visible = true;
            this.gcEvoSlurryCodeSP.VisibleIndex = 1;
            this.gcEvoSlurryCodeSP.Width = 180;
            // 
            // gcEvoSlurryDescSP
            // 
            this.gcEvoSlurryDescSP.Caption = "Slurry Description";
            this.gcEvoSlurryDescSP.FieldName = "gcEvoSlurryDescSP";
            this.gcEvoSlurryDescSP.Name = "gcEvoSlurryDescSP";
            this.gcEvoSlurryDescSP.Visible = true;
            this.gcEvoSlurryDescSP.VisibleIndex = 2;
            this.gcEvoSlurryDescSP.Width = 220;
            // 
            // gcEvoPowderCode
            // 
            this.gcEvoPowderCode.Caption = "Powder Code";
            this.gcEvoPowderCode.FieldName = "gcEvoPowderCode";
            this.gcEvoPowderCode.Name = "gcEvoPowderCode";
            this.gcEvoPowderCode.OptionsColumn.AllowEdit = false;
            this.gcEvoPowderCode.Visible = true;
            this.gcEvoPowderCode.VisibleIndex = 3;
            this.gcEvoPowderCode.Width = 180;
            // 
            // gcEvoPowderDesc
            // 
            this.gcEvoPowderDesc.Caption = "Powder Description";
            this.gcEvoPowderDesc.FieldName = "gcEvoPowderDesc";
            this.gcEvoPowderDesc.Name = "gcEvoPowderDesc";
            this.gcEvoPowderDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoPowderDesc.Visible = true;
            this.gcEvoPowderDesc.VisibleIndex = 4;
            this.gcEvoPowderDesc.Width = 220;
            // 
            // gcEvoAWCatalystCode
            // 
            this.gcEvoAWCatalystCode.Caption = "Catalyst Code";
            this.gcEvoAWCatalystCode.FieldName = "gcEvoAWCatalystCode";
            this.gcEvoAWCatalystCode.Name = "gcEvoAWCatalystCode";
            this.gcEvoAWCatalystCode.Visible = true;
            this.gcEvoAWCatalystCode.VisibleIndex = 5;
            // 
            // gcEvoAWCatalystDesc
            // 
            this.gcEvoAWCatalystDesc.Caption = "Catalyst Description";
            this.gcEvoAWCatalystDesc.FieldName = "gcEvoAWCatalystDesc";
            this.gcEvoAWCatalystDesc.Name = "gcEvoAWCatalystDesc";
            this.gcEvoAWCatalystDesc.Visible = true;
            this.gcEvoAWCatalystDesc.VisibleIndex = 6;
            // 
            // gcSelectedSP
            // 
            this.gcSelectedSP.Caption = "Select";
            this.gcSelectedSP.FieldName = "gcSelectedSP";
            this.gcSelectedSP.Name = "gcSelectedSP";
            this.gcSelectedSP.Visible = true;
            this.gcSelectedSP.VisibleIndex = 7;
            this.gcSelectedSP.Width = 120;
            // 
            // dgSelectCS
            // 
            this.dgSelectCS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelectCS.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgSelectCS.Location = new System.Drawing.Point(8, 7);
            this.dgSelectCS.MainView = this.gvSelectCS;
            this.dgSelectCS.Margin = new System.Windows.Forms.Padding(4);
            this.dgSelectCS.Name = "dgSelectCS";
            this.dgSelectCS.Size = new System.Drawing.Size(1457, 726);
            this.dgSelectCS.TabIndex = 42;
            this.dgSelectCS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelectCS});
            this.dgSelectCS.Visible = false;
            // 
            // gvSelectCS
            // 
            this.gvSelectCS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcEvoID,
            this.gcEvoCatalystCode,
            this.gcEvoCatalystDesc,
            this.gcEvoSlurryCode,
            this.gcEvoSlurryDesc,
            this.gcEvoAWCode,
            this.gcEvoAWDesc,
            this.gcSelectedCS});
            this.gvSelectCS.GridControl = this.dgSelectCS;
            this.gvSelectCS.Name = "gvSelectCS";
            this.gvSelectCS.OptionsFind.AlwaysVisible = true;
            this.gvSelectCS.OptionsView.ColumnAutoWidth = false;
            // 
            // gcEvoID
            // 
            this.gcEvoID.Caption = "ID";
            this.gcEvoID.FieldName = "gcEvoID";
            this.gcEvoID.Name = "gcEvoID";
            this.gcEvoID.OptionsColumn.AllowEdit = false;
            this.gcEvoID.Visible = true;
            this.gcEvoID.VisibleIndex = 0;
            this.gcEvoID.Width = 60;
            // 
            // gcEvoCatalystCode
            // 
            this.gcEvoCatalystCode.Caption = "Catalyst Code";
            this.gcEvoCatalystCode.FieldName = "gcEvoCatalystCode";
            this.gcEvoCatalystCode.Name = "gcEvoCatalystCode";
            this.gcEvoCatalystCode.OptionsColumn.AllowEdit = false;
            this.gcEvoCatalystCode.Visible = true;
            this.gcEvoCatalystCode.VisibleIndex = 1;
            this.gcEvoCatalystCode.Width = 180;
            // 
            // gcEvoCatalystDesc
            // 
            this.gcEvoCatalystDesc.Caption = "Catalyst Description";
            this.gcEvoCatalystDesc.FieldName = "gcEvoCatalystDesc";
            this.gcEvoCatalystDesc.Name = "gcEvoCatalystDesc";
            this.gcEvoCatalystDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoCatalystDesc.Visible = true;
            this.gcEvoCatalystDesc.VisibleIndex = 2;
            this.gcEvoCatalystDesc.Width = 220;
            // 
            // gcEvoSlurryCode
            // 
            this.gcEvoSlurryCode.Caption = "Slurry Code";
            this.gcEvoSlurryCode.FieldName = "gcEvoSlurryCode";
            this.gcEvoSlurryCode.Name = "gcEvoSlurryCode";
            this.gcEvoSlurryCode.OptionsColumn.AllowEdit = false;
            this.gcEvoSlurryCode.Visible = true;
            this.gcEvoSlurryCode.VisibleIndex = 3;
            this.gcEvoSlurryCode.Width = 180;
            // 
            // gcEvoSlurryDesc
            // 
            this.gcEvoSlurryDesc.Caption = "Slurry Description";
            this.gcEvoSlurryDesc.FieldName = "gcEvoSlurryDesc";
            this.gcEvoSlurryDesc.Name = "gcEvoSlurryDesc";
            this.gcEvoSlurryDesc.OptionsColumn.AllowEdit = false;
            this.gcEvoSlurryDesc.Visible = true;
            this.gcEvoSlurryDesc.VisibleIndex = 4;
            this.gcEvoSlurryDesc.Width = 220;
            // 
            // gcEvoAWCode
            // 
            this.gcEvoAWCode.Caption = "AW Code";
            this.gcEvoAWCode.FieldName = "gcEvoAWCode";
            this.gcEvoAWCode.Name = "gcEvoAWCode";
            this.gcEvoAWCode.Visible = true;
            this.gcEvoAWCode.VisibleIndex = 5;
            // 
            // gcEvoAWDesc
            // 
            this.gcEvoAWDesc.Caption = "AW Description";
            this.gcEvoAWDesc.FieldName = "gcEvoAWDesc";
            this.gcEvoAWDesc.Name = "gcEvoAWDesc";
            this.gcEvoAWDesc.Visible = true;
            this.gcEvoAWDesc.VisibleIndex = 6;
            this.gcEvoAWDesc.Width = 181;
            // 
            // gcSelectedCS
            // 
            this.gcSelectedCS.Caption = "Select";
            this.gcSelectedCS.FieldName = "gcSelectedCS";
            this.gcSelectedCS.Name = "gcSelectedCS";
            this.gcSelectedCS.Visible = true;
            this.gcSelectedCS.VisibleIndex = 7;
            this.gcSelectedCS.Width = 120;
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucProductionPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucProductionPlanning";
            this.Size = new System.Drawing.Size(1484, 794);
            this.Load += new System.EventHandler(this.ucProductionPlanning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSelectCS)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gcCoatNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEdit;
        private DevExpress.XtraGrid.GridControl dgSelectCS;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectCS;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoID;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectedCS;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoCatalystCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoCatalystDesc;
        private System.Windows.Forms.Panel pnlOptions;
        private DevExpress.XtraGrid.GridControl dgSelectSP;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelectSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoIDSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryCodeSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoSlurryDescSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPowderCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoPowderDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectedSP;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatalystCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.RadioButton radFourth;
        private System.Windows.Forms.RadioButton radThird;
        private System.Windows.Forms.RadioButton radSecond;
        private System.Windows.Forms.RadioButton radFirst;
        private DevExpress.XtraEditors.LabelControl lblOptionsHeader;
        private DevExpress.XtraGrid.Columns.GridColumn gcAWCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoAWCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoAWDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoAWCatalystCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcEvoAWCatalystDesc;
    }
}
