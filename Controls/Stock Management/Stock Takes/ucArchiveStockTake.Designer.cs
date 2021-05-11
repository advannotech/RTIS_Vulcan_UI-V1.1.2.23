﻿namespace RTIS_Vulcan_UI.Controls.Stock_Management.Stock_Takes
{
    partial class ucArchiveStockTake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucArchiveStockTake));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTickets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCounted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCounted2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVarience = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWhseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSerials = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsCounted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWhseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOnST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbStockTakes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBack.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStockTakes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(307, 44);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Archived Stock Takes";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.btnRemove);
            this.pnlBack.Controls.Add(this.btnExport);
            this.pnlBack.Controls.Add(this.btnRefresh);
            this.pnlBack.Controls.Add(this.btnReport);
            this.pnlBack.Controls.Add(this.panel1);
            this.pnlBack.Location = new System.Drawing.Point(4, 56);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1312, 628);
            this.pnlBack.TabIndex = 10;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRemove.Appearance.Options.UseBackColor = true;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(1138, 573);
            this.btnRemove.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRemove.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(168, 49);
            this.btnRemove.TabIndex = 27;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(610, 573);
            this.btnExport.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(168, 49);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "Export CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(962, 573);
            this.btnRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(168, 49);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(786, 573);
            this.btnReport.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(168, 49);
            this.btnReport.TabIndex = 24;
            this.btnReport.Text = "Print Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgItems);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.cmbStockTakes);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 562);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(957, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 99);
            this.panel2.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Unlisted item";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Yellow;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(187, 22);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(19, 18);
            this.panel7.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Legend";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Unequal scanner qtys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Equal to system qty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Above system qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Below system qty";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumPurple;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(5, 75);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(19, 18);
            this.panel5.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(5, 57);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(19, 18);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(5, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 18);
            this.panel3.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Salmon;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(5, 22);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(19, 18);
            this.panel6.TabIndex = 10;
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(3, 54);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1294, 503);
            this.dgItems.TabIndex = 12;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems,
            this.gridView1});
            // 
            // gvItems
            // 
            this.gvItems.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTickets,
            this.gclineID,
            this.gcItemCode,
            this.gcBarcode,
            this.gcItemDesc,
            this.gcBin,
            this.gcLot,
            this.gcCounted,
            this.gcCounted2,
            this.gcSystem,
            this.gcVarience,
            this.gcWhseCode,
            this.gcSerials,
            this.gcIsCounted,
            this.gcWhseName,
            this.gcOnST});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            this.gvItems.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvItems_RowStyle);
            // 
            // gcTickets
            // 
            this.gcTickets.Caption = "Tickets";
            this.gcTickets.FieldName = "gcTickets";
            this.gcTickets.Name = "gcTickets";
            this.gcTickets.Visible = true;
            this.gcTickets.VisibleIndex = 0;
            // 
            // gclineID
            // 
            this.gclineID.Caption = "ID";
            this.gclineID.FieldName = "gclineID";
            this.gclineID.Name = "gclineID";
            // 
            // gcItemCode
            // 
            this.gcItemCode.Caption = "Item Code";
            this.gcItemCode.FieldName = "gcItemCode";
            this.gcItemCode.Name = "gcItemCode";
            this.gcItemCode.OptionsColumn.ReadOnly = true;
            this.gcItemCode.Visible = true;
            this.gcItemCode.VisibleIndex = 1;
            // 
            // gcBarcode
            // 
            this.gcBarcode.Caption = "Barcode";
            this.gcBarcode.FieldName = "gcBarcode";
            this.gcBarcode.Name = "gcBarcode";
            this.gcBarcode.OptionsColumn.ReadOnly = true;
            // 
            // gcItemDesc
            // 
            this.gcItemDesc.Caption = "Description";
            this.gcItemDesc.FieldName = "gcItemDesc";
            this.gcItemDesc.Name = "gcItemDesc";
            this.gcItemDesc.OptionsColumn.ReadOnly = true;
            this.gcItemDesc.Visible = true;
            this.gcItemDesc.VisibleIndex = 2;
            // 
            // gcBin
            // 
            this.gcBin.Caption = "Bin";
            this.gcBin.FieldName = "gcBin";
            this.gcBin.Name = "gcBin";
            this.gcBin.OptionsColumn.ReadOnly = true;
            // 
            // gcLot
            // 
            this.gcLot.Caption = "Lot Number";
            this.gcLot.FieldName = "gcLot";
            this.gcLot.Name = "gcLot";
            this.gcLot.OptionsColumn.ReadOnly = true;
            this.gcLot.Visible = true;
            this.gcLot.VisibleIndex = 3;
            // 
            // gcCounted
            // 
            this.gcCounted.Caption = "Counted Qty";
            this.gcCounted.FieldName = "gcCounted";
            this.gcCounted.Name = "gcCounted";
            this.gcCounted.OptionsColumn.ReadOnly = true;
            this.gcCounted.Visible = true;
            this.gcCounted.VisibleIndex = 4;
            // 
            // gcCounted2
            // 
            this.gcCounted2.Caption = "Counted Qty 2";
            this.gcCounted2.FieldName = "gcCounted2";
            this.gcCounted2.Name = "gcCounted2";
            this.gcCounted2.OptionsColumn.ReadOnly = true;
            this.gcCounted2.Visible = true;
            this.gcCounted2.VisibleIndex = 5;
            // 
            // gcSystem
            // 
            this.gcSystem.Caption = "System Qty";
            this.gcSystem.FieldName = "gcSystem";
            this.gcSystem.Name = "gcSystem";
            this.gcSystem.OptionsColumn.ReadOnly = true;
            this.gcSystem.Visible = true;
            this.gcSystem.VisibleIndex = 6;
            // 
            // gcVarience
            // 
            this.gcVarience.Caption = "Varience";
            this.gcVarience.FieldName = "gcVarience";
            this.gcVarience.Name = "gcVarience";
            this.gcVarience.OptionsColumn.ReadOnly = true;
            this.gcVarience.Visible = true;
            this.gcVarience.VisibleIndex = 7;
            // 
            // gcWhseCode
            // 
            this.gcWhseCode.Caption = "Whse Code";
            this.gcWhseCode.FieldName = "gcWhseCode";
            this.gcWhseCode.Name = "gcWhseCode";
            this.gcWhseCode.OptionsColumn.ReadOnly = true;
            this.gcWhseCode.Visible = true;
            this.gcWhseCode.VisibleIndex = 8;
            // 
            // gcSerials
            // 
            this.gcSerials.Caption = "Serials";
            this.gcSerials.FieldName = "gcSerials";
            this.gcSerials.Name = "gcSerials";
            // 
            // gcIsCounted
            // 
            this.gcIsCounted.Caption = "Is Counted";
            this.gcIsCounted.FieldName = "gcIsCounted";
            this.gcIsCounted.Name = "gcIsCounted";
            // 
            // gcWhseName
            // 
            this.gcWhseName.Caption = "Warehouse Name";
            this.gcWhseName.FieldName = "gcWhseName";
            this.gcWhseName.Name = "gcWhseName";
            // 
            // gcOnST
            // 
            this.gcOnST.Caption = "OnST";
            this.gcOnST.FieldName = "gcOnST";
            this.gcOnST.Name = "gcOnST";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 5);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 16);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Select Stock Take...";
            // 
            // cmbStockTakes
            // 
            this.cmbStockTakes.Location = new System.Drawing.Point(20, 25);
            this.cmbStockTakes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStockTakes.Name = "cmbStockTakes";
            this.cmbStockTakes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStockTakes.Size = new System.Drawing.Size(468, 22);
            this.cmbStockTakes.TabIndex = 9;
            this.cmbStockTakes.TextChanged += new System.EventHandler(this.cmbStockTakes_TextChanged);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.AnimationToTextDistance = 10;
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ppnlWait.Description = "Loading stock take, this may take a few minutes...";
            this.ppnlWait.Location = new System.Drawing.Point(4, 4);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 679);
            this.ppnlWait.TabIndex = 11;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgItems;
            this.gridView1.Name = "gridView1";
            // 
            // ucArchiveStockTake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucArchiveStockTake";
            this.Size = new System.Drawing.Size(1319, 687);
            this.Load += new System.EventHandler(this.ucArchiveStockTake_Load);
            this.pnlBack.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStockTakes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel pnlBack;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcTickets;
        private DevExpress.XtraGrid.Columns.GridColumn gclineID;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcBin;
        private DevExpress.XtraGrid.Columns.GridColumn gcLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcCounted;
        private DevExpress.XtraGrid.Columns.GridColumn gcCounted2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSystem;
        private DevExpress.XtraGrid.Columns.GridColumn gcVarience;
        private DevExpress.XtraGrid.Columns.GridColumn gcWhseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcSerials;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsCounted;
        private DevExpress.XtraGrid.Columns.GridColumn gcWhseName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStockTakes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraGrid.Columns.GridColumn gcOnST;
    }
}
