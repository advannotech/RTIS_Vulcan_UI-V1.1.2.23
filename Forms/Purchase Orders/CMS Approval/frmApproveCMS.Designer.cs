namespace RTIS_Vulcan_UI.Forms.Purchase_Orders
{
    partial class frmApproveCMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApproveCMS));
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVarType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInspec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.pnlVeiw = new System.Windows.Forms.Panel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlReg = new System.Windows.Forms.Panel();
            this.btnRejDone = new DevExpress.XtraEditors.SimpleButton();
            this.btnRejBack = new DevExpress.XtraEditors.SimpleButton();
            this.txtReasons = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblRejCode = new DevExpress.XtraEditors.LabelControl();
            this.lblRejDesc = new DevExpress.XtraEditors.LabelControl();
            this.dgReject = new DevExpress.XtraGrid.GridControl();
            this.gvReject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRejItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejVarType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejVal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejVal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRejInspec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlApprove = new System.Windows.Forms.Panel();
            this.pbxSign = new System.Windows.Forms.PictureBox();
            this.btnAprSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnAprBack = new DevExpress.XtraEditors.SimpleButton();
            this.lblSignature = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblAprCode = new DevExpress.XtraEditors.LabelControl();
            this.lblAprDesc = new DevExpress.XtraEditors.LabelControl();
            this.dgApprove = new DevExpress.XtraGrid.GridControl();
            this.gvApprove = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.pnlVeiw.SuspendLayout();
            this.pnlReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasons.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReject)).BeginInit();
            this.pnlApprove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgApprove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvApprove)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesc
            // 
            this.lblDesc.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDesc.Appearance.Options.UseFont = true;
            this.lblDesc.Appearance.Options.UseForeColor = true;
            this.lblDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDesc.Location = new System.Drawing.Point(269, 42);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(505, 33);
            this.lblDesc.TabIndex = 48;
            this.lblDesc.Text = "[ItemDesc]";
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Appearance.Options.UseForeColor = true;
            this.lblCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCode.Location = new System.Drawing.Point(269, 3);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(505, 33);
            this.lblCode.TabIndex = 47;
            this.lblCode.Text = "[ItemCode]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(265, 33);
            this.labelControl1.TabIndex = 46;
            this.labelControl1.Text = "Item Description : ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(265, 33);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "Item Code : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(3, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(265, 33);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "CMS Specifications";
            // 
            // dgItems
            // 
            this.dgItems.Location = new System.Drawing.Point(3, 120);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(771, 456);
            this.dgItems.TabIndex = 50;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcItem,
            this.gcUnit,
            this.gcVarType,
            this.gcVal1,
            this.gcVal2,
            this.gcInspec});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            // 
            // gcItem
            // 
            this.gcItem.Caption = "Item";
            this.gcItem.FieldName = "gcItem";
            this.gcItem.Name = "gcItem";
            this.gcItem.Visible = true;
            this.gcItem.VisibleIndex = 0;
            // 
            // gcUnit
            // 
            this.gcUnit.Caption = "Unit";
            this.gcUnit.FieldName = "gcUnit";
            this.gcUnit.Name = "gcUnit";
            this.gcUnit.Visible = true;
            this.gcUnit.VisibleIndex = 1;
            // 
            // gcVarType
            // 
            this.gcVarType.Caption = "Variance Type";
            this.gcVarType.FieldName = "gcVarType";
            this.gcVarType.Name = "gcVarType";
            this.gcVarType.Visible = true;
            this.gcVarType.VisibleIndex = 2;
            // 
            // gcVal1
            // 
            this.gcVal1.Caption = "Value 1";
            this.gcVal1.FieldName = "gcVal1";
            this.gcVal1.Name = "gcVal1";
            this.gcVal1.Visible = true;
            this.gcVal1.VisibleIndex = 3;
            // 
            // gcVal2
            // 
            this.gcVal2.Caption = "Value 2";
            this.gcVal2.FieldName = "gcVal2";
            this.gcVal2.Name = "gcVal2";
            this.gcVal2.Visible = true;
            this.gcVal2.VisibleIndex = 4;
            // 
            // gcInspec
            // 
            this.gcInspec.Caption = "Inspection";
            this.gcInspec.FieldName = "gcInspec";
            this.gcInspec.Name = "gcInspec";
            this.gcInspec.Visible = true;
            this.gcInspec.VisibleIndex = 5;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnApprove.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnApprove.Appearance.Options.UseBackColor = true;
            this.btnApprove.Appearance.Options.UseFont = true;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.Location = new System.Drawing.Point(599, 585);
            this.btnApprove.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnApprove.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(176, 49);
            this.btnApprove.TabIndex = 95;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnReject.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnReject.Appearance.Options.UseBackColor = true;
            this.btnReject.Appearance.Options.UseFont = true;
            this.btnReject.Image = ((System.Drawing.Image)(resources.GetObject("btnReject.Image")));
            this.btnReject.Location = new System.Drawing.Point(415, 585);
            this.btnReject.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(176, 49);
            this.btnReject.TabIndex = 98;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(3, 3);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(794, 665);
            this.ppnlWait.TabIndex = 99;
            this.ppnlWait.Text = "progressPanel1";
            this.ppnlWait.Visible = false;
            // 
            // pnlVeiw
            // 
            this.pnlVeiw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVeiw.Controls.Add(this.labelControl3);
            this.pnlVeiw.Controls.Add(this.btnApprove);
            this.pnlVeiw.Controls.Add(this.btnReject);
            this.pnlVeiw.Controls.Add(this.labelControl1);
            this.pnlVeiw.Controls.Add(this.labelControl2);
            this.pnlVeiw.Controls.Add(this.lblCode);
            this.pnlVeiw.Controls.Add(this.lblDesc);
            this.pnlVeiw.Controls.Add(this.dgItems);
            this.pnlVeiw.Location = new System.Drawing.Point(12, 12);
            this.pnlVeiw.Name = "pnlVeiw";
            this.pnlVeiw.Size = new System.Drawing.Size(779, 642);
            this.pnlVeiw.TabIndex = 100;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 5;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // pnlReg
            // 
            this.pnlReg.Controls.Add(this.btnRejDone);
            this.pnlReg.Controls.Add(this.btnRejBack);
            this.pnlReg.Controls.Add(this.txtReasons);
            this.pnlReg.Controls.Add(this.labelControl9);
            this.pnlReg.Controls.Add(this.labelControl4);
            this.pnlReg.Controls.Add(this.labelControl5);
            this.pnlReg.Controls.Add(this.labelControl6);
            this.pnlReg.Controls.Add(this.lblRejCode);
            this.pnlReg.Controls.Add(this.lblRejDesc);
            this.pnlReg.Controls.Add(this.dgReject);
            this.pnlReg.Location = new System.Drawing.Point(12, 12);
            this.pnlReg.Name = "pnlReg";
            this.pnlReg.Size = new System.Drawing.Size(779, 642);
            this.pnlReg.TabIndex = 99;
            this.pnlReg.Visible = false;
            // 
            // btnRejDone
            // 
            this.btnRejDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRejDone.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRejDone.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRejDone.Appearance.Options.UseBackColor = true;
            this.btnRejDone.Appearance.Options.UseFont = true;
            this.btnRejDone.Image = ((System.Drawing.Image)(resources.GetObject("btnRejDone.Image")));
            this.btnRejDone.Location = new System.Drawing.Point(598, 583);
            this.btnRejDone.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRejDone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRejDone.Margin = new System.Windows.Forms.Padding(4);
            this.btnRejDone.Name = "btnRejDone";
            this.btnRejDone.Size = new System.Drawing.Size(176, 49);
            this.btnRejDone.TabIndex = 99;
            this.btnRejDone.Text = "Done";
            this.btnRejDone.Click += new System.EventHandler(this.btnRejDone_Click);
            // 
            // btnRejBack
            // 
            this.btnRejBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRejBack.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRejBack.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRejBack.Appearance.Options.UseBackColor = true;
            this.btnRejBack.Appearance.Options.UseFont = true;
            this.btnRejBack.Image = ((System.Drawing.Image)(resources.GetObject("btnRejBack.Image")));
            this.btnRejBack.Location = new System.Drawing.Point(414, 583);
            this.btnRejBack.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRejBack.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRejBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnRejBack.Name = "btnRejBack";
            this.btnRejBack.Size = new System.Drawing.Size(176, 49);
            this.btnRejBack.TabIndex = 100;
            this.btnRejBack.Text = "Back";
            this.btnRejBack.Click += new System.EventHandler(this.btnRejBack_Click);
            // 
            // txtReasons
            // 
            this.txtReasons.Location = new System.Drawing.Point(4, 411);
            this.txtReasons.Name = "txtReasons";
            this.txtReasons.Size = new System.Drawing.Size(770, 165);
            this.txtReasons.TabIndex = 58;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(3, 371);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(265, 33);
            this.labelControl9.TabIndex = 57;
            this.labelControl9.Text = "Rejection reasons: ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(265, 33);
            this.labelControl4.TabIndex = 51;
            this.labelControl4.Text = "Item Code : ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(3, 42);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(265, 33);
            this.labelControl5.TabIndex = 52;
            this.labelControl5.Text = "Item Description : ";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(3, 81);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(265, 33);
            this.labelControl6.TabIndex = 55;
            this.labelControl6.Text = "CMS Specifications";
            // 
            // lblRejCode
            // 
            this.lblRejCode.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRejCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRejCode.Appearance.Options.UseFont = true;
            this.lblRejCode.Appearance.Options.UseForeColor = true;
            this.lblRejCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRejCode.Location = new System.Drawing.Point(269, 3);
            this.lblRejCode.Name = "lblRejCode";
            this.lblRejCode.Size = new System.Drawing.Size(505, 33);
            this.lblRejCode.TabIndex = 53;
            this.lblRejCode.Text = "[ItemCode]";
            // 
            // lblRejDesc
            // 
            this.lblRejDesc.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRejDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRejDesc.Appearance.Options.UseFont = true;
            this.lblRejDesc.Appearance.Options.UseForeColor = true;
            this.lblRejDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRejDesc.Location = new System.Drawing.Point(269, 42);
            this.lblRejDesc.Name = "lblRejDesc";
            this.lblRejDesc.Size = new System.Drawing.Size(505, 33);
            this.lblRejDesc.TabIndex = 54;
            this.lblRejDesc.Text = "[ItemDesc]";
            // 
            // dgReject
            // 
            this.dgReject.Location = new System.Drawing.Point(3, 120);
            this.dgReject.MainView = this.gvReject;
            this.dgReject.Name = "dgReject";
            this.dgReject.Size = new System.Drawing.Size(771, 245);
            this.dgReject.TabIndex = 56;
            this.dgReject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReject});
            // 
            // gvReject
            // 
            this.gvReject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRejItem,
            this.gcRejUnit,
            this.gcRejVarType,
            this.gcRejVal1,
            this.gcRejVal2,
            this.gcRejInspec});
            this.gvReject.GridControl = this.dgReject;
            this.gvReject.Name = "gvReject";
            // 
            // gcRejItem
            // 
            this.gcRejItem.Caption = "Item";
            this.gcRejItem.FieldName = "gcItem";
            this.gcRejItem.Name = "gcRejItem";
            this.gcRejItem.Visible = true;
            this.gcRejItem.VisibleIndex = 0;
            // 
            // gcRejUnit
            // 
            this.gcRejUnit.Caption = "Unit";
            this.gcRejUnit.FieldName = "gcUnit";
            this.gcRejUnit.Name = "gcRejUnit";
            this.gcRejUnit.Visible = true;
            this.gcRejUnit.VisibleIndex = 1;
            // 
            // gcRejVarType
            // 
            this.gcRejVarType.Caption = "Variance Type";
            this.gcRejVarType.FieldName = "gcVarType";
            this.gcRejVarType.Name = "gcRejVarType";
            this.gcRejVarType.Visible = true;
            this.gcRejVarType.VisibleIndex = 2;
            // 
            // gcRejVal1
            // 
            this.gcRejVal1.Caption = "Value 1";
            this.gcRejVal1.FieldName = "gcVal1";
            this.gcRejVal1.Name = "gcRejVal1";
            this.gcRejVal1.Visible = true;
            this.gcRejVal1.VisibleIndex = 3;
            // 
            // gcRejVal2
            // 
            this.gcRejVal2.Caption = "Value 2";
            this.gcRejVal2.FieldName = "gcVal2";
            this.gcRejVal2.Name = "gcRejVal2";
            this.gcRejVal2.Visible = true;
            this.gcRejVal2.VisibleIndex = 4;
            // 
            // gcRejInspec
            // 
            this.gcRejInspec.Caption = "Inspection";
            this.gcRejInspec.FieldName = "gcInspec";
            this.gcRejInspec.Name = "gcRejInspec";
            this.gcRejInspec.Visible = true;
            this.gcRejInspec.VisibleIndex = 5;
            // 
            // pnlApprove
            // 
            this.pnlApprove.Controls.Add(this.pbxSign);
            this.pnlApprove.Controls.Add(this.btnAprSave);
            this.pnlApprove.Controls.Add(this.btnAprBack);
            this.pnlApprove.Controls.Add(this.lblSignature);
            this.pnlApprove.Controls.Add(this.labelControl11);
            this.pnlApprove.Controls.Add(this.labelControl12);
            this.pnlApprove.Controls.Add(this.labelControl13);
            this.pnlApprove.Controls.Add(this.lblAprCode);
            this.pnlApprove.Controls.Add(this.lblAprDesc);
            this.pnlApprove.Controls.Add(this.dgApprove);
            this.pnlApprove.Controls.Add(this.panel1);
            this.pnlApprove.Location = new System.Drawing.Point(12, 12);
            this.pnlApprove.Name = "pnlApprove";
            this.pnlApprove.Size = new System.Drawing.Size(779, 642);
            this.pnlApprove.TabIndex = 101;
            this.pnlApprove.Visible = false;
            // 
            // pbxSign
            // 
            this.pbxSign.Location = new System.Drawing.Point(46, 412);
            this.pbxSign.Margin = new System.Windows.Forms.Padding(4);
            this.pbxSign.Name = "pbxSign";
            this.pbxSign.Size = new System.Drawing.Size(72, 70);
            this.pbxSign.TabIndex = 3;
            this.pbxSign.TabStop = false;
            // 
            // btnAprSave
            // 
            this.btnAprSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprSave.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAprSave.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnAprSave.Appearance.Options.UseBackColor = true;
            this.btnAprSave.Appearance.Options.UseFont = true;
            this.btnAprSave.Image = ((System.Drawing.Image)(resources.GetObject("btnAprSave.Image")));
            this.btnAprSave.Location = new System.Drawing.Point(598, 583);
            this.btnAprSave.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAprSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAprSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnAprSave.Name = "btnAprSave";
            this.btnAprSave.Size = new System.Drawing.Size(176, 49);
            this.btnAprSave.TabIndex = 99;
            this.btnAprSave.Text = "Done";
            this.btnAprSave.Click += new System.EventHandler(this.btnAprSave_Click);
            // 
            // btnAprBack
            // 
            this.btnAprBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprBack.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAprBack.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnAprBack.Appearance.Options.UseBackColor = true;
            this.btnAprBack.Appearance.Options.UseFont = true;
            this.btnAprBack.Image = ((System.Drawing.Image)(resources.GetObject("btnAprBack.Image")));
            this.btnAprBack.Location = new System.Drawing.Point(414, 583);
            this.btnAprBack.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAprBack.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAprBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnAprBack.Name = "btnAprBack";
            this.btnAprBack.Size = new System.Drawing.Size(176, 49);
            this.btnAprBack.TabIndex = 100;
            this.btnAprBack.Text = "Back";
            this.btnAprBack.Click += new System.EventHandler(this.btnAprBack_Click);
            // 
            // lblSignature
            // 
            this.lblSignature.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignature.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSignature.Appearance.Options.UseFont = true;
            this.lblSignature.Appearance.Options.UseForeColor = true;
            this.lblSignature.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSignature.Location = new System.Drawing.Point(4, 332);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(265, 33);
            this.lblSignature.TabIndex = 57;
            this.lblSignature.Text = "Signature:";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(3, 3);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(265, 33);
            this.labelControl11.TabIndex = 51;
            this.labelControl11.Text = "Item Code : ";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Appearance.Options.UseForeColor = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(3, 42);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(265, 33);
            this.labelControl12.TabIndex = 52;
            this.labelControl12.Text = "Item Description : ";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.Location = new System.Drawing.Point(3, 81);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(265, 33);
            this.labelControl13.TabIndex = 55;
            this.labelControl13.Text = "CMS Specifications";
            // 
            // lblAprCode
            // 
            this.lblAprCode.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAprCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAprCode.Appearance.Options.UseFont = true;
            this.lblAprCode.Appearance.Options.UseForeColor = true;
            this.lblAprCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAprCode.Location = new System.Drawing.Point(269, 3);
            this.lblAprCode.Name = "lblAprCode";
            this.lblAprCode.Size = new System.Drawing.Size(505, 33);
            this.lblAprCode.TabIndex = 53;
            this.lblAprCode.Text = "[ItemCode]";
            // 
            // lblAprDesc
            // 
            this.lblAprDesc.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAprDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAprDesc.Appearance.Options.UseFont = true;
            this.lblAprDesc.Appearance.Options.UseForeColor = true;
            this.lblAprDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAprDesc.Location = new System.Drawing.Point(269, 42);
            this.lblAprDesc.Name = "lblAprDesc";
            this.lblAprDesc.Size = new System.Drawing.Size(505, 33);
            this.lblAprDesc.TabIndex = 54;
            this.lblAprDesc.Text = "[ItemDesc]";
            // 
            // dgApprove
            // 
            this.dgApprove.Location = new System.Drawing.Point(3, 120);
            this.dgApprove.MainView = this.gvApprove;
            this.dgApprove.Name = "dgApprove";
            this.dgApprove.Size = new System.Drawing.Size(771, 209);
            this.dgApprove.TabIndex = 56;
            this.dgApprove.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvApprove});
            // 
            // gvApprove
            // 
            this.gvApprove.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvApprove.GridControl = this.dgApprove;
            this.gvApprove.Name = "gvApprove";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Item";
            this.gridColumn1.FieldName = "gcItem";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Unit";
            this.gridColumn2.FieldName = "gcUnit";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Variance Type";
            this.gridColumn3.FieldName = "gcVarType";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Value 1";
            this.gridColumn4.FieldName = "gcVal1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Value 2";
            this.gridColumn5.FieldName = "gcVal2";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Inspection";
            this.gridColumn6.FieldName = "gcInspec";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(4, 372);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 204);
            this.panel1.TabIndex = 101;
            // 
            // frmApproveCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.Controls.Add(this.pnlApprove);
            this.Controls.Add(this.pnlReg);
            this.Controls.Add(this.ppnlWait);
            this.Controls.Add(this.pnlVeiw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApproveCMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve CMS Data";
            this.Load += new System.EventHandler(this.frmApproveCMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.pnlVeiw.ResumeLayout(false);
            this.pnlReg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReasons.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReject)).EndInit();
            this.pnlApprove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgApprove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvApprove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDesc;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraGrid.Columns.GridColumn gcItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gcVarType;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal1;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal2;
        private DevExpress.XtraGrid.Columns.GridColumn gcInspec;
        private DevExpress.XtraEditors.SimpleButton btnReject;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Panel pnlVeiw;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Panel pnlReg;
        private DevExpress.XtraEditors.MemoEdit txtReasons;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblRejCode;
        private DevExpress.XtraEditors.LabelControl lblRejDesc;
        private DevExpress.XtraGrid.GridControl dgReject;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReject;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejVarType;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejVal1;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejVal2;
        private DevExpress.XtraGrid.Columns.GridColumn gcRejInspec;
        private DevExpress.XtraEditors.SimpleButton btnRejDone;
        private DevExpress.XtraEditors.SimpleButton btnRejBack;
        private System.Windows.Forms.Panel pnlApprove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxSign;
        private DevExpress.XtraEditors.SimpleButton btnAprSave;
        private DevExpress.XtraEditors.SimpleButton btnAprBack;
        private DevExpress.XtraEditors.LabelControl lblSignature;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblAprCode;
        private DevExpress.XtraEditors.LabelControl lblAprDesc;
        private DevExpress.XtraGrid.GridControl dgApprove;
        private DevExpress.XtraGrid.Views.Grid.GridView gvApprove;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}