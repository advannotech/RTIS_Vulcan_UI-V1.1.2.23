namespace RTIS_Vulcan_UI
{
    partial class ucFGManufacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFGManufacture));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.gbOptions = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.dgFGManufacture = new DevExpress.XtraGrid.GridControl();
            this.gvFGManufacture = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEvoManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            this.gcCoat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPrinted = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).BeginInit();
            this.gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGManufacture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFGManufacture)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(191, 36);
            this.lblHeader.TabIndex = 31;
            this.lblHeader.Text = "FG Manufacture";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.pnlSearch);
            this.panelControl1.Controls.Add(this.dgFGManufacture);
            this.panelControl1.Controls.Add(this.ppnlWait);
            this.panelControl1.Location = new System.Drawing.Point(4, 46);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(982, 594);
            this.panelControl1.TabIndex = 32;
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
            // dgFGManufacture
            // 
            this.dgFGManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFGManufacture.Location = new System.Drawing.Point(6, 86);
            this.dgFGManufacture.MainView = this.gvFGManufacture;
            this.dgFGManufacture.Name = "dgFGManufacture";
            this.dgFGManufacture.Size = new System.Drawing.Size(971, 503);
            this.dgFGManufacture.TabIndex = 0;
            this.dgFGManufacture.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFGManufacture});
            // 
            // gvFGManufacture
            // 
            this.gvFGManufacture.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcItemCode,
            this.gcDesc,
            this.gcLotNum,
            this.gcCoat,
            this.gcSlurry,
            this.gcQty,
            this.gcDateA,
            this.gcUserA,
            this.gcPrinted,
            this.gcEvoManufacture});
            this.gvFGManufacture.GridControl = this.dgFGManufacture;
            this.gvFGManufacture.Name = "gvFGManufacture";
            this.gvFGManufacture.OptionsFind.AlwaysVisible = true;
            this.gvFGManufacture.OptionsView.ColumnAutoWidth = false;
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
            this.gcItemCode.Width = 130;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.AllowEdit = false;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            this.gcDesc.Width = 150;
            // 
            // gcLotNum
            // 
            this.gcLotNum.Caption = "Lot Number";
            this.gcLotNum.FieldName = "gcLotNum";
            this.gcLotNum.Name = "gcLotNum";
            this.gcLotNum.OptionsColumn.AllowEdit = false;
            this.gcLotNum.Visible = true;
            this.gcLotNum.VisibleIndex = 2;
            this.gcLotNum.Width = 130;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty Produced";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 5;
            this.gcQty.Width = 90;
            // 
            // gcDateA
            // 
            this.gcDateA.Caption = "Date Produced";
            this.gcDateA.FieldName = "gcDateA";
            this.gcDateA.Name = "gcDateA";
            this.gcDateA.OptionsColumn.AllowEdit = false;
            this.gcDateA.Visible = true;
            this.gcDateA.VisibleIndex = 6;
            this.gcDateA.Width = 120;
            // 
            // gcEvoManufacture
            // 
            this.gcEvoManufacture.Caption = "Evolution Manufactured";
            this.gcEvoManufacture.FieldName = "gcEvoManufacture";
            this.gcEvoManufacture.Name = "gcEvoManufacture";
            this.gcEvoManufacture.Visible = true;
            this.gcEvoManufacture.VisibleIndex = 9;
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
            // gcCoat
            // 
            this.gcCoat.Caption = "Coat Number";
            this.gcCoat.FieldName = "gcCoat";
            this.gcCoat.Name = "gcCoat";
            this.gcCoat.OptionsColumn.AllowEdit = false;
            this.gcCoat.Visible = true;
            this.gcCoat.VisibleIndex = 3;
            this.gcCoat.Width = 90;
            // 
            // gcSlurry
            // 
            this.gcSlurry.Caption = "Slurry Used";
            this.gcSlurry.FieldName = "gcSlurry";
            this.gcSlurry.Name = "gcSlurry";
            this.gcSlurry.OptionsColumn.AllowEdit = false;
            this.gcSlurry.Visible = true;
            this.gcSlurry.VisibleIndex = 4;
            this.gcSlurry.Width = 100;
            // 
            // gcUserA
            // 
            this.gcUserA.Caption = "User Produced";
            this.gcUserA.FieldName = "gcUserA";
            this.gcUserA.Name = "gcUserA";
            this.gcUserA.OptionsColumn.AllowEdit = false;
            this.gcUserA.Visible = true;
            this.gcUserA.VisibleIndex = 7;
            this.gcUserA.Width = 100;
            // 
            // gcPrinted
            // 
            this.gcPrinted.Caption = "Tag Printed";
            this.gcPrinted.FieldName = "gcPrinted";
            this.gcPrinted.Name = "gcPrinted";
            this.gcPrinted.OptionsColumn.AllowEdit = false;
            this.gcPrinted.Visible = true;
            this.gcPrinted.VisibleIndex = 8;
            this.gcPrinted.Width = 80;
            // 
            // ucFGManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblHeader);
            this.Name = "ucFGManufacture";
            this.Size = new System.Drawing.Size(989, 643);
            this.Load += new System.EventHandler(this.ucFGManufacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbOptions)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGManufacture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFGManufacture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgFGManufacture;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFGManufacture;
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
        private DevExpress.XtraGrid.Columns.GridColumn gcDateA;
        private DevExpress.XtraGrid.Columns.GridColumn gcCoat;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurry;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserA;
        private DevExpress.XtraGrid.Columns.GridColumn gcPrinted;
    }
}
