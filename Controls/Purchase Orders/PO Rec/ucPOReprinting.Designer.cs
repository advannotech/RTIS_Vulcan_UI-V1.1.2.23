namespace RTIS_Vulcan_UI.Controls.Purchase_Orders.PO_Rec
{
    partial class ucPOReprinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPOReprinting));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnReprintReciept = new DevExpress.XtraEditors.SimpleButton();
            this.btnReprint = new DevExpress.XtraEditors.SimpleButton();
            this.hyperReprintLabel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbOptions = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cbAllLines = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPOs = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSuppliers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPO = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dgPOItems = new DevExpress.XtraGrid.GridControl();
            this.gvPOItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReceive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBack1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBack2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRecQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcViewable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTLastOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTRecQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTLastRecQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTPrintQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRTLastPrintQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValidated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcScanned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBack3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            this.ppnlPrint = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrPrint = new System.Windows.Forms.Timer(this.components);
            this.tmrReprint = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).BeginInit();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSuppliers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPOItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPOItems)).BeginInit();
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
            this.labelControl13.Location = new System.Drawing.Point(4, 4);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(390, 44);
            this.labelControl13.TabIndex = 31;
            this.labelControl13.Text = "Purchase Order Reprinting";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnReprintReciept);
            this.panelControl1.Controls.Add(this.btnReprint);
            this.panelControl1.Controls.Add(this.hyperReprintLabel);
            this.panelControl1.Controls.Add(this.pnlSearch);
            this.panelControl1.Controls.Add(this.dgPOItems);
            this.panelControl1.Controls.Add(this.ppnlWait);
            this.panelControl1.Location = new System.Drawing.Point(5, 57);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1309, 905);
            this.panelControl1.TabIndex = 32;
            // 
            // btnReprintReciept
            // 
            this.btnReprintReciept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprintReciept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReprintReciept.ImageOptions.Image")));
            this.btnReprintReciept.Location = new System.Drawing.Point(1131, 850);
            this.btnReprintReciept.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnReprintReciept.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReprintReciept.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReprintReciept.Margin = new System.Windows.Forms.Padding(4);
            this.btnReprintReciept.Name = "btnReprintReciept";
            this.btnReprintReciept.Size = new System.Drawing.Size(168, 49);
            this.btnReprintReciept.TabIndex = 49;
            this.btnReprintReciept.Text = "Reprint Receipt";
            this.btnReprintReciept.Click += new System.EventHandler(this.btnReprintReciept_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.ImageOptions.Image")));
            this.btnReprint.Location = new System.Drawing.Point(912, 850);
            this.btnReprint.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnReprint.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnReprint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(168, 49);
            this.btnReprint.TabIndex = 48;
            this.btnReprint.Text = "Reprint Label";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // hyperReprintLabel
            // 
            this.hyperReprintLabel.Location = new System.Drawing.Point(0, 0);
            this.hyperReprintLabel.Name = "hyperReprintLabel";
            this.hyperReprintLabel.Size = new System.Drawing.Size(0, 0);
            this.hyperReprintLabel.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.gbOptions);
            this.pnlSearch.Location = new System.Drawing.Point(8, 6);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1295, 92);
            this.pnlSearch.TabIndex = 20;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.btnSearch);
            this.gbOptions.Controls.Add(this.cbAllLines);
            this.gbOptions.Controls.Add(this.labelControl1);
            this.gbOptions.Controls.Add(this.cmbPOs);
            this.gbOptions.Controls.Add(this.cmbSuppliers);
            this.gbOptions.Controls.Add(this.lblPO);
            this.gbOptions.Controls.Add(this.labelControl9);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(0, 0);
            this.gbOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(1295, 92);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1232, 32);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 49);
            this.btnSearch.TabIndex = 90;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbAllLines
            // 
            this.cbAllLines.Enabled = false;
            this.cbAllLines.Location = new System.Drawing.Point(635, 52);
            this.cbAllLines.Margin = new System.Windows.Forms.Padding(4);
            this.cbAllLines.Name = "cbAllLines";
            this.cbAllLines.Properties.Caption = "Show all lines";
            this.cbAllLines.Size = new System.Drawing.Size(141, 24);
            this.cbAllLines.TabIndex = 89;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(307, 28);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 88;
            this.labelControl1.Text = "Select PO:";
            // 
            // cmbPOs
            // 
            this.cmbPOs.Location = new System.Drawing.Point(307, 53);
            this.cmbPOs.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPOs.Name = "cmbPOs";
            this.cmbPOs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPOs.Size = new System.Drawing.Size(320, 22);
            this.cmbPOs.TabIndex = 42;
            this.cmbPOs.SelectedIndexChanged += new System.EventHandler(this.cmbPOs_SelectedIndexChanged_1);
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.Location = new System.Drawing.Point(7, 52);
            this.cmbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSuppliers.Size = new System.Drawing.Size(292, 22);
            this.cmbSuppliers.TabIndex = 40;
            this.cmbSuppliers.SelectedIndexChanged += new System.EventHandler(this.cmbSuppliers_SelectedIndexChanged_1);
            // 
            // lblPO
            // 
            this.lblPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPO.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblPO.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPO.Appearance.Options.UseBackColor = true;
            this.lblPO.Appearance.Options.UseFont = true;
            this.lblPO.Appearance.Options.UseTextOptions = true;
            this.lblPO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPO.Location = new System.Drawing.Point(819, 32);
            this.lblPO.Margin = new System.Windows.Forms.Padding(4);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(402, 47);
            this.lblPO.TabIndex = 41;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(7, 28);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(91, 16);
            this.labelControl9.TabIndex = 39;
            this.labelControl9.Text = "Select Supplier:";
            // 
            // dgPOItems
            // 
            this.dgPOItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPOItems.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgPOItems.Location = new System.Drawing.Point(8, 106);
            this.dgPOItems.MainView = this.gvPOItems;
            this.dgPOItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgPOItems.Name = "dgPOItems";
            this.dgPOItems.Size = new System.Drawing.Size(1295, 739);
            this.dgPOItems.TabIndex = 0;
            this.dgPOItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPOItems});
            // 
            // gvPOItems
            // 
            this.gvPOItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcDesc,
            this.gcDesc2,
            this.gcLotNum,
            this.gcOrderQty,
            this.gcReceive,
            this.gcBack1,
            this.gcPrint,
            this.gcBack2,
            this.gcRecQty,
            this.gcLotLine,
            this.gcViewable,
            this.gcRTOrderQty,
            this.gcRTLastOrderQty,
            this.gcRTRecQty,
            this.gcRTLastRecQty,
            this.gcRTPrintQty,
            this.gcRTLastPrintQty,
            this.gcValidated,
            this.gcScanned,
            this.gcBack3});
            this.gvPOItems.GridControl = this.dgPOItems;
            this.gvPOItems.Name = "gvPOItems";
            this.gvPOItems.OptionsFind.AlwaysVisible = true;
            this.gvPOItems.OptionsView.ColumnAutoWidth = false;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Item Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.AllowEdit = false;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
            this.gcCode.Width = 106;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowEdit = false;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            this.gcDesc.Width = 165;
            // 
            // gcDesc2
            // 
            this.gcDesc2.Caption = "Description 2";
            this.gcDesc2.FieldName = "gcDesc2";
            this.gcDesc2.Name = "gcDesc2";
            this.gcDesc2.OptionsColumn.AllowEdit = false;
            this.gcDesc2.Visible = true;
            this.gcDesc2.VisibleIndex = 2;
            this.gcDesc2.Width = 145;
            // 
            // gcLotNum
            // 
            this.gcLotNum.Caption = "Lot Number";
            this.gcLotNum.FieldName = "gcLotNum";
            this.gcLotNum.Name = "gcLotNum";
            this.gcLotNum.OptionsColumn.AllowEdit = false;
            this.gcLotNum.Visible = true;
            this.gcLotNum.VisibleIndex = 3;
            this.gcLotNum.Width = 163;
            // 
            // gcOrderQty
            // 
            this.gcOrderQty.Caption = "Order Qty";
            this.gcOrderQty.FieldName = "gcOrderQty";
            this.gcOrderQty.Name = "gcOrderQty";
            this.gcOrderQty.OptionsColumn.AllowEdit = false;
            this.gcOrderQty.Visible = true;
            this.gcOrderQty.VisibleIndex = 4;
            this.gcOrderQty.Width = 132;
            // 
            // gcReceive
            // 
            this.gcReceive.Caption = "Receive";
            this.gcReceive.FieldName = "gcReceive";
            this.gcReceive.Name = "gcReceive";
            // 
            // gcBack1
            // 
            this.gcBack1.Caption = "Qty to receive";
            this.gcBack1.FieldName = "gcBack1";
            this.gcBack1.Name = "gcBack1";
            // 
            // gcPrint
            // 
            this.gcPrint.Caption = "Print";
            this.gcPrint.FieldName = "gcPrint";
            this.gcPrint.Name = "gcPrint";
            // 
            // gcBack2
            // 
            this.gcBack2.Caption = "Qty Received";
            this.gcBack2.FieldName = "gcBack2";
            this.gcBack2.Name = "gcBack2";
            this.gcBack2.OptionsColumn.AllowEdit = false;
            this.gcBack2.Width = 108;
            // 
            // gcRecQty
            // 
            this.gcRecQty.Caption = "Evo Received Qty";
            this.gcRecQty.FieldName = "gcRecQty";
            this.gcRecQty.Name = "gcRecQty";
            // 
            // gcLotLine
            // 
            this.gcLotLine.Caption = "Lot item";
            this.gcLotLine.FieldName = "gcLotLine";
            this.gcLotLine.Name = "gcLotLine";
            this.gcLotLine.OptionsColumn.AllowEdit = false;
            this.gcLotLine.Width = 145;
            // 
            // gcViewable
            // 
            this.gcViewable.Caption = "Viewable";
            this.gcViewable.FieldName = "gcViewable";
            this.gcViewable.Name = "gcViewable";
            // 
            // gcRTOrderQty
            // 
            this.gcRTOrderQty.Caption = "RT Order Qty";
            this.gcRTOrderQty.FieldName = "gcRTOrderQty";
            this.gcRTOrderQty.Name = "gcRTOrderQty";
            // 
            // gcRTLastOrderQty
            // 
            this.gcRTLastOrderQty.Caption = "RT Last Order Qty";
            this.gcRTLastOrderQty.FieldName = "gcRTLastOrderQty";
            this.gcRTLastOrderQty.Name = "gcRTLastOrderQty";
            // 
            // gcRTRecQty
            // 
            this.gcRTRecQty.Caption = "RT Rec Qty";
            this.gcRTRecQty.FieldName = "gcRTRecQty";
            this.gcRTRecQty.Name = "gcRTRecQty";
            // 
            // gcRTLastRecQty
            // 
            this.gcRTLastRecQty.Caption = "RT Last Rec Qty";
            this.gcRTLastRecQty.FieldName = "gcRTLastRecQty";
            this.gcRTLastRecQty.Name = "gcRTLastRecQty";
            // 
            // gcRTPrintQty
            // 
            this.gcRTPrintQty.Caption = "Print Qty";
            this.gcRTPrintQty.FieldName = "gcRTPrintQty";
            this.gcRTPrintQty.Name = "gcRTPrintQty";
            // 
            // gcRTLastPrintQty
            // 
            this.gcRTLastPrintQty.Caption = "Last Print Qty";
            this.gcRTLastPrintQty.FieldName = "gcRTLastPrintQty";
            this.gcRTLastPrintQty.Name = "gcRTLastPrintQty";
            // 
            // gcValidated
            // 
            this.gcValidated.Caption = "Validated";
            this.gcValidated.FieldName = "gcValidated";
            this.gcValidated.Name = "gcValidated";
            // 
            // gcScanned
            // 
            this.gcScanned.Caption = "Scanned";
            this.gcScanned.FieldName = "gcScanned";
            this.gcScanned.Name = "gcScanned";
            // 
            // gcBack3
            // 
            this.gcBack3.Caption = "Back 3";
            this.gcBack3.FieldName = "gcBack3";
            this.gcBack3.Name = "gcBack3";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(8, 6);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1295, 893);
            this.ppnlWait.TabIndex = 33;
            this.ppnlWait.Text = "progressPanel1";
            this.ppnlWait.Click += new System.EventHandler(this.ppnlWait_Click);
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ppnlPrint
            // 
            this.ppnlPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlPrint.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ppnlPrint.Appearance.Options.UseBackColor = true;
            this.ppnlPrint.Description = "Preparing to print ...";
            this.ppnlPrint.Location = new System.Drawing.Point(4, 56);
            this.ppnlPrint.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlPrint.Name = "ppnlPrint";
            this.ppnlPrint.Size = new System.Drawing.Size(1311, 905);
            this.ppnlPrint.TabIndex = 34;
            this.ppnlPrint.Text = "progressPanel1";
            // 
            // tmrReprint
            // 
            this.tmrReprint.Tick += new System.EventHandler(this.tmrReprint_Tick);
            // 
            // ucPOReprinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlPrint);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucPOReprinting";
            this.Size = new System.Drawing.Size(1319, 965);
            this.Load += new System.EventHandler(this.ucPOReprinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSuppliers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPOItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPOItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel pnlSearch;
        private DevExpress.XtraEditors.GroupControl gbOptions;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPOs;
        private DevExpress.XtraEditors.LabelControl lblPO;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSuppliers;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit cbAllLines;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlPrint;
        private System.Windows.Forms.Timer tmrPrint;
        private System.Windows.Forms.Timer tmrReprint;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperReprintLabel;
        private DevExpress.XtraGrid.GridControl dgPOItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPOItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc2;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceive;
        private DevExpress.XtraGrid.Columns.GridColumn gcBack1;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrint;
        private DevExpress.XtraGrid.Columns.GridColumn gcBack2;
        private DevExpress.XtraGrid.Columns.GridColumn gcRecQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotLine;
        private DevExpress.XtraGrid.Columns.GridColumn gcViewable;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTLastOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTRecQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTLastRecQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTPrintQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcRTLastPrintQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcValidated;
        private DevExpress.XtraGrid.Columns.GridColumn gcScanned;
        private DevExpress.XtraGrid.Columns.GridColumn gcBack3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnReprint;
        private DevExpress.XtraEditors.SimpleButton btnReprintReciept;
    }
}

