namespace RTIS_Vulcan_UI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.bmMain = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbtnLabels = new DevExpress.XtraBars.BarButtonItem();
            this.pmLlbOptions = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbtnNewLabel = new DevExpress.XtraBars.BarButtonItem();
            this.pmLabelTypes = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbtnStkLabel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnZectLabel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnAWLabel = new DevExpress.XtraBars.BarButtonItem();
            this.btnZectConfigTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnAWConfig = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnCanningLabel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnFGBox = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnFGPallet = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnExistingLabel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnLogOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dmMain = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.xtcMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtnRMPallet = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmLlbOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmLabelTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmMain)).BeginInit();
            this.dpMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).BeginInit();
            this.xtcMain.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bmMain
            // 
            this.bmMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar4});
            this.bmMain.DockControls.Add(this.barDockControlTop);
            this.bmMain.DockControls.Add(this.barDockControlBottom);
            this.bmMain.DockControls.Add(this.barDockControlLeft);
            this.bmMain.DockControls.Add(this.barDockControlRight);
            this.bmMain.DockManager = this.dmMain;
            this.bmMain.Form = this;
            this.bmMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtnLabels,
            this.bbtnLogOut,
            this.bbtnExit,
            this.bbtnNewLabel,
            this.bbtnExistingLabel,
            this.bbtnStkLabel,
            this.barButtonItem2,
            this.bbtnZectLabel,
            this.bbtnAWLabel,
            this.btnZectConfigTag,
            this.btnAWConfig,
            this.bbtnCanningLabel,
            this.bbtnFGBox,
            this.bbtnFGPallet,
            this.bbtnRMPallet});
            this.bmMain.MainMenu = this.bar1;
            this.bmMain.MaxItemId = 18;
            this.bmMain.StatusBar = this.bar4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnLabels),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnLogOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExit)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // bbtnLabels
            // 
            this.bbtnLabels.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnLabels.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbtnLabels.Caption = "Label Designs";
            this.bbtnLabels.DropDownControl = this.pmLlbOptions;
            this.bbtnLabels.Id = 3;
            this.bbtnLabels.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnLabels.ImageOptions.Image")));
            this.bbtnLabels.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnLabels.ImageOptions.LargeImage")));
            this.bbtnLabels.Name = "bbtnLabels";
            this.bbtnLabels.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // pmLlbOptions
            // 
            this.pmLlbOptions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnNewLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExistingLabel)});
            this.pmLlbOptions.Manager = this.bmMain;
            this.pmLlbOptions.Name = "pmLlbOptions";
            // 
            // bbtnNewLabel
            // 
            this.bbtnNewLabel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbtnNewLabel.Caption = "New Label";
            this.bbtnNewLabel.DropDownControl = this.pmLabelTypes;
            this.bbtnNewLabel.Id = 6;
            this.bbtnNewLabel.Name = "bbtnNewLabel";
            this.bbtnNewLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // pmLabelTypes
            // 
            this.pmLabelTypes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnStkLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnZectLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnAWLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZectConfigTag),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAWConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnCanningLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnFGBox),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnFGPallet),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnRMPallet)});
            this.pmLabelTypes.Manager = this.bmMain;
            this.pmLabelTypes.Name = "pmLabelTypes";
            // 
            // bbtnStkLabel
            // 
            this.bbtnStkLabel.Caption = "Receiving Label";
            this.bbtnStkLabel.Id = 8;
            this.bbtnStkLabel.Name = "bbtnStkLabel";
            this.bbtnStkLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnStkLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnStkLabel_ItemClick);
            // 
            // bbtnZectLabel
            // 
            this.bbtnZectLabel.Caption = "Zect Label";
            this.bbtnZectLabel.Id = 10;
            this.bbtnZectLabel.Name = "bbtnZectLabel";
            this.bbtnZectLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnZectLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnZectLabel_ItemClick);
            // 
            // bbtnAWLabel
            // 
            this.bbtnAWLabel.Caption = "AW Label";
            this.bbtnAWLabel.Id = 11;
            this.bbtnAWLabel.Name = "bbtnAWLabel";
            this.bbtnAWLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnAWLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnAWLabel_ItemClick);
            // 
            // btnZectConfigTag
            // 
            this.btnZectConfigTag.Caption = "ZECT Config Tag";
            this.btnZectConfigTag.Id = 12;
            this.btnZectConfigTag.Name = "btnZectConfigTag";
            this.btnZectConfigTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZectConfigTag_ItemClick);
            // 
            // btnAWConfig
            // 
            this.btnAWConfig.Caption = "A&W Config Tag";
            this.btnAWConfig.Id = 13;
            this.btnAWConfig.Name = "btnAWConfig";
            this.btnAWConfig.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAWConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAWConfig_ItemClick);
            // 
            // bbtnCanningLabel
            // 
            this.bbtnCanningLabel.Caption = "Canning Label";
            this.bbtnCanningLabel.Id = 14;
            this.bbtnCanningLabel.Name = "bbtnCanningLabel";
            this.bbtnCanningLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnCanningLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnCanningLabel_ItemClick);
            // 
            // bbtnFGBox
            // 
            this.bbtnFGBox.Caption = "FG Box Label";
            this.bbtnFGBox.Id = 15;
            this.bbtnFGBox.Name = "bbtnFGBox";
            this.bbtnFGBox.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnFGBox.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnFGBox_ItemClick);
            // 
            // bbtnFGPallet
            // 
            this.bbtnFGPallet.Caption = "FG Pallet Label";
            this.bbtnFGPallet.Id = 16;
            this.bbtnFGPallet.Name = "bbtnFGPallet";
            this.bbtnFGPallet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnFGPallet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnFGPallet_ItemClick);
            // 
            // bbtnExistingLabel
            // 
            this.bbtnExistingLabel.Caption = "Existing Label";
            this.bbtnExistingLabel.Id = 7;
            this.bbtnExistingLabel.Name = "bbtnExistingLabel";
            this.bbtnExistingLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbtnExistingLabel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnExistingLabel_ItemClick);
            // 
            // bbtnLogOut
            // 
            this.bbtnLogOut.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnLogOut.Caption = "Log Out";
            this.bbtnLogOut.Id = 4;
            this.bbtnLogOut.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnLogOut.ImageOptions.Image")));
            this.bbtnLogOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnLogOut.ImageOptions.LargeImage")));
            this.bbtnLogOut.Name = "bbtnLogOut";
            this.bbtnLogOut.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnLogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnLogOut_ItemClick);
            // 
            // bbtnExit
            // 
            this.bbtnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnExit.Caption = "Exit";
            this.bbtnExit.Id = 5;
            this.bbtnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnExit.ImageOptions.Image")));
            this.bbtnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnExit.ImageOptions.LargeImage")));
            this.bbtnExit.Name = "bbtnExit";
            this.bbtnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnExit_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 3";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Custom 3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bmMain;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1587, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 739);
            this.barDockControlBottom.Manager = this.bmMain;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1587, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.bmMain;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 709);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1587, 30);
            this.barDockControlRight.Manager = this.bmMain;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 709);
            // 
            // dmMain
            // 
            this.dmMain.Form = this;
            this.dmMain.MenuManager = this.bmMain;
            this.dmMain.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpMenu});
            this.dmMain.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dpMenu
            // 
            this.dpMenu.Appearance.BackColor = System.Drawing.Color.White;
            this.dpMenu.Appearance.Options.UseBackColor = true;
            this.dpMenu.Controls.Add(this.dockPanel1_Container);
            this.dpMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpMenu.ID = new System.Guid("8d955d76-90ce-43aa-8874-55b0e9441635");
            this.dpMenu.Location = new System.Drawing.Point(0, 30);
            this.dpMenu.Margin = new System.Windows.Forms.Padding(4);
            this.dpMenu.Name = "dpMenu";
            this.dpMenu.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpMenu.Size = new System.Drawing.Size(200, 709);
            this.dpMenu.Text = "User Menu";
            this.dpMenu.DockChanged += new System.EventHandler(this.dpMenu_DockChanged);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.pictureEdit2);
            this.dockPanel1_Container.Controls.Add(this.tvMain);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 27);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(188, 677);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit2.EditValue = global::RTIS_Vulcan_UI.Properties.Resources.CAT_SCAN_LOGO_300dpi_TRANSPARENT;
            this.pictureEdit2.Location = new System.Drawing.Point(8, 4);
            this.pictureEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit2.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit2.Size = new System.Drawing.Size(176, 112);
            this.pictureEdit2.TabIndex = 14;
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvMain.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMain.Location = new System.Drawing.Point(4, 123);
            this.tvMain.Margin = new System.Windows.Forms.Padding(4);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(180, 550);
            this.tvMain.TabIndex = 13;
            this.tvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMain_NodeMouseClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // xtcMain
            // 
            this.xtcMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtcMain.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.xtcMain.Location = new System.Drawing.Point(208, 43);
            this.xtcMain.Margin = new System.Windows.Forms.Padding(4);
            this.xtcMain.Name = "xtcMain";
            this.xtcMain.SelectedTabPage = this.xtraTabPage1;
            this.xtcMain.Size = new System.Drawing.Size(1376, 693);
            this.xtcMain.TabIndex = 6;
            this.xtcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.xtcMain.CloseButtonClick += new System.EventHandler(this.xtcMain_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1369, 659);
            this.xtraTabPage1.Text = "Welcome";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(516, 289);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(389, 44);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "RTIS Front End Application";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1471, 32);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1363, 32);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1255, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtnRMPallet
            // 
            this.bbtnRMPallet.Caption = "RM Pallet Label";
            this.bbtnRMPallet.Id = 17;
            this.bbtnRMPallet.Name = "bbtnRMPallet";
            this.bbtnRMPallet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnRMPallet_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1587, 764);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.xtcMain);
            this.Controls.Add(this.dpMenu);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTIS Vulcan UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmLlbOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmLabelTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dmMain)).EndInit();
            this.dpMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMain)).EndInit();
            this.xtcMain.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bmMain;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dmMain;
        private DevExpress.XtraBars.Docking.DockPanel dpMenu;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        public DevExpress.XtraTab.XtraTabControl xtcMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraBars.PopupMenu pmLlbOptions;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bbtnLabels;
        private DevExpress.XtraBars.BarButtonItem bbtnLogOut;
        private DevExpress.XtraBars.BarButtonItem bbtnExit;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarButtonItem bbtnNewLabel;
        private DevExpress.XtraBars.BarButtonItem bbtnExistingLabel;
        private DevExpress.XtraBars.BarButtonItem bbtnStkLabel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu pmLabelTypes;
        private DevExpress.XtraBars.BarButtonItem bbtnZectLabel;
        private DevExpress.XtraBars.BarButtonItem bbtnAWLabel;
        private DevExpress.XtraBars.BarButtonItem btnZectConfigTag;
        private DevExpress.XtraBars.BarButtonItem btnAWConfig;
        private DevExpress.XtraBars.BarButtonItem bbtnCanningLabel;
        private DevExpress.XtraBars.BarButtonItem bbtnFGBox;
        private DevExpress.XtraBars.BarButtonItem bbtnFGPallet;
        private DevExpress.XtraBars.BarButtonItem bbtnRMPallet;
    }
}

