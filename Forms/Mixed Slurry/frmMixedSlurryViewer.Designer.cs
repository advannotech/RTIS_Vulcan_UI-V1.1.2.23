namespace RTIS_Vulcan_UI.Forms
{
    partial class frmMixedSlurryViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixedSlurryViewer));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.pnlTank = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.lblSol = new DevExpress.XtraEditors.LabelControl();
            this.lblDry = new DevExpress.XtraEditors.LabelControl();
            this.lblWet = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblRec = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblRem = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblLot = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblSlurry = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblTank = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTrolley = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.xtpChems = new DevExpress.XtraTab.XtraTabPage();
            this.dgChems = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xtcManual = new DevExpress.XtraTab.XtraTabPage();
            this.meCloseReason = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.lblDateClosed = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lblClosedBy = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmritems = new System.Windows.Forms.Timer(this.components);
            this.tmrChems = new System.Windows.Forms.Timer(this.components);
            this.btnCloseMix = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTank)).BeginInit();
            this.pnlTank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtpChems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtcManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meCloseReason.Properties)).BeginInit();
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
            this.labelControl13.Location = new System.Drawing.Point(13, 13);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(266, 44);
            this.labelControl13.TabIndex = 34;
            this.labelControl13.Text = "Mixed Slurry View";
            // 
            // pnlTank
            // 
            this.pnlTank.Controls.Add(this.xtraTabControl1);
            this.pnlTank.Location = new System.Drawing.Point(13, 65);
            this.pnlTank.Name = "pnlTank";
            this.pnlTank.Size = new System.Drawing.Size(888, 411);
            this.pnlTank.TabIndex = 35;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(878, 401);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtpChems,
            this.xtcManual});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.tableLayoutPanel1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(871, 367);
            this.xtraTabPage1.Text = "Mixed Slurry Information";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(14, 22);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(221, 33);
            this.labelControl9.TabIndex = 41;
            this.labelControl9.Text = "General Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 61);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 303);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelControl12);
            this.panel2.Controls.Add(this.labelControl15);
            this.panel2.Controls.Add(this.labelControl17);
            this.panel2.Controls.Add(this.lblSol);
            this.panel2.Controls.Add(this.lblDry);
            this.panel2.Controls.Add(this.lblWet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(515, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 297);
            this.panel2.TabIndex = 93;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(15, 12);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(157, 33);
            this.labelControl12.TabIndex = 47;
            this.labelControl12.Text = "Wet Weight :";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.Location = new System.Drawing.Point(15, 51);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(157, 33);
            this.labelControl15.TabIndex = 45;
            this.labelControl15.Text = "Dry Weight :";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl17.Appearance.Options.UseFont = true;
            this.labelControl17.Appearance.Options.UseForeColor = true;
            this.labelControl17.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl17.Location = new System.Drawing.Point(14, 90);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(158, 33);
            this.labelControl17.TabIndex = 46;
            this.labelControl17.Text = "Solidity :";
            // 
            // lblSol
            // 
            this.lblSol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSol.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSol.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSol.Appearance.Options.UseFont = true;
            this.lblSol.Appearance.Options.UseForeColor = true;
            this.lblSol.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSol.Location = new System.Drawing.Point(212, 90);
            this.lblSol.Name = "lblSol";
            this.lblSol.Size = new System.Drawing.Size(121, 33);
            this.lblSol.TabIndex = 50;
            this.lblSol.Text = "N/A";
            // 
            // lblDry
            // 
            this.lblDry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDry.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDry.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDry.Appearance.Options.UseFont = true;
            this.lblDry.Appearance.Options.UseForeColor = true;
            this.lblDry.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDry.Location = new System.Drawing.Point(212, 51);
            this.lblDry.Name = "lblDry";
            this.lblDry.Size = new System.Drawing.Size(121, 33);
            this.lblDry.TabIndex = 49;
            this.lblDry.Text = "N/A";
            // 
            // lblWet
            // 
            this.lblWet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWet.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWet.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblWet.Appearance.Options.UseFont = true;
            this.lblWet.Appearance.Options.UseForeColor = true;
            this.lblWet.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWet.Location = new System.Drawing.Point(212, 12);
            this.lblWet.Name = "lblWet";
            this.lblWet.Size = new System.Drawing.Size(121, 33);
            this.lblWet.TabIndex = 48;
            this.lblWet.Text = "N/A";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.lblRec);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lblRem);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.lblLot);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.labelControl7);
            this.panel1.Controls.Add(this.lblSlurry);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.lblTank);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 297);
            this.panel1.TabIndex = 51;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(13, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(292, 33);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Tank :";
            // 
            // lblRec
            // 
            this.lblRec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRec.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRec.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRec.Appearance.Options.UseFont = true;
            this.lblRec.Appearance.Options.UseForeColor = true;
            this.lblRec.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRec.Location = new System.Drawing.Point(310, 246);
            this.lblRec.Name = "lblRec";
            this.lblRec.Size = new System.Drawing.Size(412, 33);
            this.lblRec.TabIndex = 49;
            this.lblRec.Text = "[RecWeight]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(13, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(246, 33);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Slurry Code :";
            // 
            // lblRem
            // 
            this.lblRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRem.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRem.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRem.Appearance.Options.UseFont = true;
            this.lblRem.Appearance.Options.UseForeColor = true;
            this.lblRem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRem.Location = new System.Drawing.Point(311, 207);
            this.lblRem.Name = "lblRem";
            this.lblRem.Size = new System.Drawing.Size(412, 33);
            this.lblRem.TabIndex = 48;
            this.lblRem.Text = "[RemWeight]";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(12, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(247, 33);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Description :";
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAmount.Appearance.Options.UseFont = true;
            this.lblAmount.Appearance.Options.UseForeColor = true;
            this.lblAmount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAmount.Location = new System.Drawing.Point(311, 168);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(412, 33);
            this.lblAmount.TabIndex = 46;
            this.lblAmount.Text = "[AmountOfSlurries]";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(12, 129);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(293, 33);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Lot Number :";
            // 
            // lblLot
            // 
            this.lblLot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLot.Appearance.Options.UseFont = true;
            this.lblLot.Appearance.Options.UseForeColor = true;
            this.lblLot.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLot.Location = new System.Drawing.Point(311, 129);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(412, 33);
            this.lblLot.TabIndex = 45;
            this.lblLot.Text = "[LotNumber]";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(12, 168);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(293, 33);
            this.labelControl5.TabIndex = 37;
            this.labelControl5.Text = "Amount of Slurries :";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDescription.Appearance.Options.UseFont = true;
            this.lblDescription.Appearance.Options.UseForeColor = true;
            this.lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescription.Location = new System.Drawing.Point(311, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(412, 33);
            this.lblDescription.TabIndex = 44;
            this.lblDescription.Text = "[Description]";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(12, 207);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(292, 33);
            this.labelControl7.TabIndex = 39;
            this.labelControl7.Text = "Remainder Weight :";
            // 
            // lblSlurry
            // 
            this.lblSlurry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlurry.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlurry.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSlurry.Appearance.Options.UseFont = true;
            this.lblSlurry.Appearance.Options.UseForeColor = true;
            this.lblSlurry.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSlurry.Location = new System.Drawing.Point(311, 51);
            this.lblSlurry.Name = "lblSlurry";
            this.lblSlurry.Size = new System.Drawing.Size(412, 33);
            this.lblSlurry.TabIndex = 43;
            this.lblSlurry.Text = "[SlurryCode]";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(11, 246);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(293, 33);
            this.labelControl8.TabIndex = 40;
            this.labelControl8.Text = "Recovered Weight :";
            // 
            // lblTank
            // 
            this.lblTank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTank.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTank.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTank.Appearance.Options.UseFont = true;
            this.lblTank.Appearance.Options.UseForeColor = true;
            this.lblTank.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTank.Location = new System.Drawing.Point(311, 12);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(412, 33);
            this.lblTank.TabIndex = 42;
            this.lblTank.Text = "[Tank]";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.dgItems);
            this.xtraTabPage2.Controls.Add(this.labelControl19);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(871, 367);
            this.xtraTabPage2.Text = "Mixed Slurry Inputs";
            // 
            // dgItems
            // 
            this.dgItems.Location = new System.Drawing.Point(14, 51);
            this.dgItems.MainView = this.gridView1;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(843, 302);
            this.dgItems.TabIndex = 43;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTrolley,
            this.gcSlurryCode,
            this.gcSlurryDesc,
            this.gcSlurryLot,
            this.gcWeight});
            this.gridView1.GridControl = this.dgItems;
            this.gridView1.Name = "gridView1";
            // 
            // gcTrolley
            // 
            this.gcTrolley.Caption = "Trolley";
            this.gcTrolley.FieldName = "gcTrolley";
            this.gcTrolley.Name = "gcTrolley";
            this.gcTrolley.Visible = true;
            this.gcTrolley.VisibleIndex = 0;
            // 
            // gcSlurryCode
            // 
            this.gcSlurryCode.Caption = "Slurry Code";
            this.gcSlurryCode.FieldName = "gcSlurryCode";
            this.gcSlurryCode.Name = "gcSlurryCode";
            this.gcSlurryCode.OptionsColumn.ReadOnly = true;
            this.gcSlurryCode.Visible = true;
            this.gcSlurryCode.VisibleIndex = 1;
            // 
            // gcSlurryDesc
            // 
            this.gcSlurryDesc.Caption = "Slurry Description";
            this.gcSlurryDesc.FieldName = "gcSlurryDesc";
            this.gcSlurryDesc.Name = "gcSlurryDesc";
            this.gcSlurryDesc.OptionsColumn.ReadOnly = true;
            this.gcSlurryDesc.Visible = true;
            this.gcSlurryDesc.VisibleIndex = 2;
            // 
            // gcSlurryLot
            // 
            this.gcSlurryLot.Caption = "Lot Number";
            this.gcSlurryLot.FieldName = "gcSlurryLot";
            this.gcSlurryLot.Name = "gcSlurryLot";
            this.gcSlurryLot.OptionsColumn.ReadOnly = true;
            this.gcSlurryLot.Visible = true;
            this.gcSlurryLot.VisibleIndex = 3;
            // 
            // gcWeight
            // 
            this.gcWeight.Caption = "Weight";
            this.gcWeight.FieldName = "gcWeight";
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.OptionsColumn.ReadOnly = true;
            this.gcWeight.Visible = true;
            this.gcWeight.VisibleIndex = 4;
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.Location = new System.Drawing.Point(14, 12);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(202, 33);
            this.labelControl19.TabIndex = 42;
            this.labelControl19.Text = "Fresh Slurry Inputs";
            // 
            // xtpChems
            // 
            this.xtpChems.Controls.Add(this.dgChems);
            this.xtpChems.Controls.Add(this.labelControl6);
            this.xtpChems.Name = "xtpChems";
            this.xtpChems.Size = new System.Drawing.Size(871, 367);
            this.xtpChems.Text = "Zonen and Charging Information";
            this.xtpChems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.xtpChems_MouseClick);
            // 
            // dgChems
            // 
            this.dgChems.Location = new System.Drawing.Point(14, 51);
            this.dgChems.MainView = this.gridView2;
            this.dgChems.Name = "dgChems";
            this.dgChems.Size = new System.Drawing.Size(843, 302);
            this.dgChems.TabIndex = 44;
            this.dgChems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcChem,
            this.gcQty});
            this.gridView2.GridControl = this.dgChems;
            this.gridView2.Name = "gridView2";
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
            // gcChem
            // 
            this.gcChem.Caption = "Chemical";
            this.gcChem.FieldName = "gcChem";
            this.gcChem.Name = "gcChem";
            this.gcChem.OptionsColumn.AllowEdit = false;
            this.gcChem.Visible = true;
            this.gcChem.VisibleIndex = 1;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(14, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(353, 33);
            this.labelControl6.TabIndex = 43;
            this.labelControl6.Text = "Zonen and Charging Information";
            // 
            // xtcManual
            // 
            this.xtcManual.Controls.Add(this.meCloseReason);
            this.xtcManual.Controls.Add(this.labelControl16);
            this.xtcManual.Controls.Add(this.lblDateClosed);
            this.xtcManual.Controls.Add(this.labelControl14);
            this.xtcManual.Controls.Add(this.lblClosedBy);
            this.xtcManual.Controls.Add(this.labelControl11);
            this.xtcManual.Controls.Add(this.labelControl10);
            this.xtcManual.Name = "xtcManual";
            this.xtcManual.Size = new System.Drawing.Size(871, 367);
            this.xtcManual.Text = "Manual Close Information";
            // 
            // meCloseReason
            // 
            this.meCloseReason.Location = new System.Drawing.Point(14, 184);
            this.meCloseReason.Name = "meCloseReason";
            this.meCloseReason.Properties.ReadOnly = true;
            this.meCloseReason.Size = new System.Drawing.Size(840, 180);
            this.meCloseReason.TabIndex = 48;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl16.Appearance.Options.UseFont = true;
            this.labelControl16.Appearance.Options.UseForeColor = true;
            this.labelControl16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl16.Location = new System.Drawing.Point(14, 144);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(498, 33);
            this.labelControl16.TabIndex = 47;
            this.labelControl16.Text = "Reason Closed:";
            // 
            // lblDateClosed
            // 
            this.lblDateClosed.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateClosed.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDateClosed.Appearance.Options.UseFont = true;
            this.lblDateClosed.Appearance.Options.UseForeColor = true;
            this.lblDateClosed.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDateClosed.Location = new System.Drawing.Point(266, 105);
            this.lblDateClosed.Name = "lblDateClosed";
            this.lblDateClosed.Size = new System.Drawing.Size(246, 33);
            this.lblDateClosed.TabIndex = 46;
            this.lblDateClosed.Text = "[DateClosed]";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(14, 105);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(246, 33);
            this.labelControl14.TabIndex = 45;
            this.labelControl14.Text = "Date Closed :";
            // 
            // lblClosedBy
            // 
            this.lblClosedBy.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosedBy.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblClosedBy.Appearance.Options.UseFont = true;
            this.lblClosedBy.Appearance.Options.UseForeColor = true;
            this.lblClosedBy.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblClosedBy.Location = new System.Drawing.Point(266, 66);
            this.lblClosedBy.Name = "lblClosedBy";
            this.lblClosedBy.Size = new System.Drawing.Size(246, 33);
            this.lblClosedBy.TabIndex = 44;
            this.lblClosedBy.Text = "[ClosedBy]";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(14, 66);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(246, 33);
            this.labelControl11.TabIndex = 43;
            this.labelControl11.Text = "Closed By:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(14, 14);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(283, 33);
            this.labelControl10.TabIndex = 42;
            this.labelControl10.Text = "Manual Close Information";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(13, 13);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(888, 466);
            this.ppnlWait.TabIndex = 37;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmritems
            // 
            this.tmritems.Tick += new System.EventHandler(this.tmritems_Tick);
            // 
            // tmrChems
            // 
            this.tmrChems.Tick += new System.EventHandler(this.tmrChems_Tick);
            // 
            // btnCloseMix
            // 
            this.btnCloseMix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseMix.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCloseMix.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnCloseMix.Appearance.Options.UseBackColor = true;
            this.btnCloseMix.Appearance.Options.UseFont = true;
            this.btnCloseMix.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseMix.Image")));
            this.btnCloseMix.Location = new System.Drawing.Point(745, 8);
            this.btnCloseMix.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCloseMix.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCloseMix.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseMix.Name = "btnCloseMix";
            this.btnCloseMix.Size = new System.Drawing.Size(156, 49);
            this.btnCloseMix.TabIndex = 92;
            this.btnCloseMix.Text = "Close Mix";
            this.btnCloseMix.Click += new System.EventHandler(this.btnCloseMix_Click);
            // 
            // frmMixedSlurryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 492);
            this.Controls.Add(this.btnCloseMix);
            this.Controls.Add(this.pnlTank);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMixedSlurryViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mixed Slurry Viewer";
            this.Load += new System.EventHandler(this.frmMixedSlurryViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTank)).EndInit();
            this.pnlTank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtpChems.ResumeLayout(false);
            this.xtpChems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtcManual.ResumeLayout(false);
            this.xtcManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meCloseReason.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl pnlTank;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblRec;
        private DevExpress.XtraEditors.LabelControl lblRem;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.LabelControl lblLot;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.LabelControl lblSlurry;
        private DevExpress.XtraEditors.LabelControl lblTank;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeight;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmritems;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrolley;
        private DevExpress.XtraTab.XtraTabPage xtpChems;
        private DevExpress.XtraGrid.GridControl dgChems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcChem;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Timer tmrChems;
        private DevExpress.XtraTab.XtraTabPage xtcManual;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl lblClosedBy;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.MemoEdit meCloseReason;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl lblDateClosed;
        private DevExpress.XtraEditors.SimpleButton btnCloseMix;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl lblSol;
        private DevExpress.XtraEditors.LabelControl lblDry;
        private DevExpress.XtraEditors.LabelControl lblWet;
    }
}