namespace RTIS_Vulcan_UI.Controls.Palletizing
{
    partial class ucPalletizing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPalletizing));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrintSettings = new DevExpress.XtraEditors.SimpleButton();
            this.dgPallets = new DevExpress.XtraGrid.GridControl();
            this.gvPallets = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLots = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbHeader = new DevExpress.XtraEditors.GroupControl();
            this.cmbLotNumbers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbDate = new DevExpress.XtraEditors.CheckEdit();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbItemCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlPallet = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnReprint = new DevExpress.XtraEditors.SimpleButton();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.dgContents = new DevExpress.XtraGrid.GridControl();
            this.gvConents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOnPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
            this.lblPrinted = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPallets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPallets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbHeader)).BeginInit();
            this.gbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLotNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPallet)).BeginInit();
            this.pnlPallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
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
            this.lblHeader.Size = new System.Drawing.Size(148, 44);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Palletizing";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.groupControl1);
            this.pnlMain.Controls.Add(this.dgPallets);
            this.pnlMain.Controls.Add(this.gbHeader);
            this.pnlMain.Location = new System.Drawing.Point(4, 56);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1312, 628);
            this.pnlMain.TabIndex = 12;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnPrintSettings);
            this.groupControl1.Location = new System.Drawing.Point(1117, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(190, 92);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Settings";
            // 
            // btnPrintSettings
            // 
            this.btnPrintSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSettings.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnPrintSettings.Appearance.Options.UseBackColor = true;
            this.btnPrintSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSettings.Image")));
            this.btnPrintSettings.Location = new System.Drawing.Point(16, 33);
            this.btnPrintSettings.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnPrintSettings.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrintSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSettings.Name = "btnPrintSettings";
            this.btnPrintSettings.Size = new System.Drawing.Size(168, 49);
            this.btnPrintSettings.TabIndex = 27;
            this.btnPrintSettings.Text = "Print Settings";
            this.btnPrintSettings.Click += new System.EventHandler(this.btnPrintSettings_Click);
            // 
            // dgPallets
            // 
            this.dgPallets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPallets.Location = new System.Drawing.Point(6, 103);
            this.dgPallets.MainView = this.gvPallets;
            this.dgPallets.Name = "dgPallets";
            this.dgPallets.Size = new System.Drawing.Size(1301, 520);
            this.dgPallets.TabIndex = 27;
            this.dgPallets.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPallets});
            // 
            // gvPallets
            // 
            this.gvPallets.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcItemCode,
            this.gcLots,
            this.gcPrinted,
            this.gcOpen});
            this.gvPallets.GridControl = this.dgPallets;
            this.gvPallets.Name = "gvPallets";
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "Id";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.ReadOnly = true;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcItemCode
            // 
            this.gcItemCode.Caption = "Item";
            this.gcItemCode.FieldName = "ItemCode";
            this.gcItemCode.Name = "gcItemCode";
            this.gcItemCode.OptionsColumn.ReadOnly = true;
            this.gcItemCode.Visible = true;
            this.gcItemCode.VisibleIndex = 1;
            // 
            // gcLots
            // 
            this.gcLots.Caption = "Lot Numbers";
            this.gcLots.FieldName = "LotNumbers";
            this.gcLots.Name = "gcLots";
            this.gcLots.OptionsColumn.ReadOnly = true;
            this.gcLots.Visible = true;
            this.gcLots.VisibleIndex = 2;
            // 
            // gcPrinted
            // 
            this.gcPrinted.Caption = "Printed";
            this.gcPrinted.FieldName = "Printed";
            this.gcPrinted.Name = "gcPrinted";
            this.gcPrinted.OptionsColumn.ReadOnly = true;
            this.gcPrinted.Visible = true;
            this.gcPrinted.VisibleIndex = 3;
            // 
            // gcOpen
            // 
            this.gcOpen.Caption = "Open";
            this.gcOpen.Name = "gcOpen";
            this.gcOpen.Visible = true;
            this.gcOpen.VisibleIndex = 4;
            // 
            // gbHeader
            // 
            this.gbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeader.Controls.Add(this.cmbLotNumbers);
            this.gbHeader.Controls.Add(this.labelControl3);
            this.gbHeader.Controls.Add(this.cbDate);
            this.gbHeader.Controls.Add(this.dtpTo);
            this.gbHeader.Controls.Add(this.labelControl2);
            this.gbHeader.Controls.Add(this.cmbItemCode);
            this.gbHeader.Controls.Add(this.btnSearch);
            this.gbHeader.Controls.Add(this.dtpFrom);
            this.gbHeader.Controls.Add(this.labelControl5);
            this.gbHeader.Controls.Add(this.labelControl1);
            this.gbHeader.Location = new System.Drawing.Point(5, 5);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(1106, 91);
            this.gbHeader.TabIndex = 26;
            this.gbHeader.Text = "Search Options";
            // 
            // cmbLotNumbers
            // 
            this.cmbLotNumbers.Location = new System.Drawing.Point(318, 57);
            this.cmbLotNumbers.Name = "cmbLotNumbers";
            this.cmbLotNumbers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLotNumbers.Size = new System.Drawing.Size(331, 22);
            this.cmbLotNumbers.TabIndex = 32;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(318, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 16);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "Lot Number :";
            // 
            // cbDate
            // 
            this.cbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDate.EditValue = true;
            this.cbDate.Location = new System.Drawing.Point(960, 0);
            this.cbDate.Name = "cbDate";
            this.cbDate.Properties.AutoWidth = true;
            this.cbDate.Properties.Caption = "Seacrh By Date";
            this.cbDate.Size = new System.Drawing.Size(109, 20);
            this.cbDate.TabIndex = 30;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.EditValue = null;
            this.dtpTo.Location = new System.Drawing.Point(742, 60);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Size = new System.Drawing.Size(183, 22);
            this.dtpTo.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(658, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Date To :";
            // 
            // cmbItemCode
            // 
            this.cmbItemCode.Location = new System.Drawing.Point(15, 57);
            this.cmbItemCode.Name = "cmbItemCode";
            this.cmbItemCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbItemCode.Size = new System.Drawing.Size(297, 22);
            this.cmbItemCode.TabIndex = 27;
            this.cmbItemCode.SelectedIndexChanged += new System.EventHandler(this.cmbItemCode_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(932, 36);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 49);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.EditValue = null;
            this.dtpFrom.Location = new System.Drawing.Point(742, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Size = new System.Drawing.Size(183, 22);
            this.dtpFrom.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(15, 35);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(68, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Item Code :";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(658, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Date From :";
            // 
            // pnlPallet
            // 
            this.pnlPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPallet.Controls.Add(this.btnBack);
            this.pnlPallet.Controls.Add(this.btnReprint);
            this.pnlPallet.Controls.Add(this.btnReport);
            this.pnlPallet.Controls.Add(this.groupControl3);
            this.pnlPallet.Controls.Add(this.groupControl2);
            this.pnlPallet.Location = new System.Drawing.Point(4, 56);
            this.pnlPallet.Name = "pnlPallet";
            this.pnlPallet.Size = new System.Drawing.Size(1312, 628);
            this.pnlPallet.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(787, 571);
            this.btnBack.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnBack.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(168, 49);
            this.btnBack.TabIndex = 97;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnReprint.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnReprint.Appearance.Options.UseBackColor = true;
            this.btnReprint.Appearance.Options.UseFont = true;
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.Location = new System.Drawing.Point(963, 571);
            this.btnReprint.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReprint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(168, 49);
            this.btnReprint.TabIndex = 96;
            this.btnReprint.Text = "Reprint Label";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnReport.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(1139, 571);
            this.btnReport.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(168, 49);
            this.btnReport.TabIndex = 95;
            this.btnReport.Text = "Print Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.dgContents);
            this.groupControl3.Location = new System.Drawing.Point(5, 114);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1302, 452);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Pallet Contents";
            // 
            // dgContents
            // 
            this.dgContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgContents.Location = new System.Drawing.Point(2, 25);
            this.dgContents.MainView = this.gvConents;
            this.dgContents.Name = "dgContents";
            this.dgContents.Size = new System.Drawing.Size(1298, 425);
            this.dgContents.TabIndex = 0;
            this.dgContents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConents});
            // 
            // gvConents
            // 
            this.gvConents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLotNumber,
            this.gcOnPallet});
            this.gvConents.GridControl = this.dgContents;
            this.gvConents.Name = "gvConents";
            this.gvConents.OptionsView.ColumnAutoWidth = false;
            // 
            // gcLotNumber
            // 
            this.gcLotNumber.Caption = "Lot Number";
            this.gcLotNumber.FieldName = "LotNumber";
            this.gcLotNumber.Name = "gcLotNumber";
            this.gcLotNumber.OptionsColumn.ReadOnly = true;
            this.gcLotNumber.Visible = true;
            this.gcLotNumber.VisibleIndex = 0;
            this.gcLotNumber.Width = 173;
            // 
            // gcOnPallet
            // 
            this.gcOnPallet.Caption = "On Pallet";
            this.gcOnPallet.FieldName = "OnPallet";
            this.gcOnPallet.Name = "gcOnPallet";
            this.gcOnPallet.OptionsColumn.ReadOnly = true;
            this.gcOnPallet.Visible = true;
            this.gcOnPallet.VisibleIndex = 1;
            this.gcOnPallet.Width = 108;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.lblItemCode);
            this.groupControl2.Controls.Add(this.lblPrinted);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(5, 7);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1302, 100);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Pallet Info";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Location = new System.Drawing.Point(112, 38);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(36, 16);
            this.lblItemCode.TabIndex = 3;
            this.lblItemCode.Text = "[Item]";
            // 
            // lblPrinted
            // 
            this.lblPrinted.Location = new System.Drawing.Point(112, 64);
            this.lblPrinted.Name = "lblPrinted";
            this.lblPrinted.Size = new System.Drawing.Size(50, 16);
            this.lblPrinted.TabIndex = 2;
            this.lblPrinted.Text = "[Printed]";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 64);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(79, 16);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Date Printed :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Item :";
            // 
            // ucPalletizing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pnlPallet);
            this.Controls.Add(this.pnlMain);
            this.Name = "ucPalletizing";
            this.Size = new System.Drawing.Size(1319, 687);
            this.Load += new System.EventHandler(this.ucPalletizing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPallets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPallets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbHeader)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLotNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPallet)).EndInit();
            this.pnlPallet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrintSettings;
        private DevExpress.XtraGrid.GridControl dgPallets;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPallets;
        private DevExpress.XtraEditors.GroupControl gbHeader;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLotNumbers;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit cbDate;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbItemCode;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcLots;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrinted;
        private DevExpress.XtraEditors.PanelControl pnlPallet;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl dgContents;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConents;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcOnPallet;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblItemCode;
        private DevExpress.XtraEditors.LabelControl lblPrinted;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnReprint;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraGrid.Columns.GridColumn gcOpen;
        private DevExpress.XtraEditors.SimpleButton btnBack;
    }
}
