namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    partial class frmMixedSlurryManuf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixedSlurryManuf));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.grpTankInfo = new DevExpress.XtraEditors.GroupControl();
            this.dgInfo = new DevExpress.XtraGrid.GridControl();
            this.gvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgInput = new DevExpress.XtraGrid.GridControl();
            this.gvInput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTrolley = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSlurryLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnManufacture = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pntTnk = new System.Windows.Forms.Panel();
            this.grpZAC = new DevExpress.XtraEditors.GroupControl();
            this.dgChem = new DevExpress.XtraGrid.GridControl();
            this.gvChem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpDecant = new DevExpress.XtraEditors.GroupControl();
            this.dgDecant = new DevExpress.XtraGrid.GridControl();
            this.gvDecant = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTankNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSolidity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDryWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpTankInfo)).BeginInit();
            this.grpTankInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInput)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pntTnk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpZAC)).BeginInit();
            this.grpZAC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDecant)).BeginInit();
            this.grpDecant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDecant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDecant)).BeginInit();
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
            this.labelControl13.Size = new System.Drawing.Size(385, 44);
            this.labelControl13.TabIndex = 35;
            this.labelControl13.Text = "Mixed Slurry Manufacture";
            // 
            // grpTankInfo
            // 
            this.grpTankInfo.Controls.Add(this.dgInfo);
            this.grpTankInfo.Location = new System.Drawing.Point(13, 65);
            this.grpTankInfo.Name = "grpTankInfo";
            this.grpTankInfo.Size = new System.Drawing.Size(1273, 306);
            this.grpTankInfo.TabIndex = 36;
            this.grpTankInfo.Text = "Mixed Slurry Infomation";
            // 
            // dgInfo
            // 
            this.dgInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInfo.Location = new System.Drawing.Point(2, 25);
            this.dgInfo.MainView = this.gvInfo;
            this.dgInfo.Name = "dgInfo";
            this.dgInfo.Size = new System.Drawing.Size(1269, 279);
            this.dgInfo.TabIndex = 0;
            this.dgInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInfo});
            // 
            // gvInfo
            // 
            this.gvInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcValue});
            this.gvInfo.GridControl = this.dgInfo;
            this.gvInfo.Name = "gvInfo";
            this.gvInfo.OptionsView.ShowColumnHeaders = false;
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "InfoName";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcValue
            // 
            this.gcValue.Caption = "Value";
            this.gcValue.FieldName = "InfoValue";
            this.gcValue.Name = "gcValue";
            this.gcValue.OptionsColumn.ReadOnly = true;
            this.gcValue.Visible = true;
            this.gcValue.VisibleIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgInput);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(630, 300);
            this.groupControl2.TabIndex = 37;
            this.groupControl2.Text = "Fresh Slurries Used";
            // 
            // dgInput
            // 
            this.dgInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInput.Location = new System.Drawing.Point(2, 25);
            this.dgInput.MainView = this.gvInput;
            this.dgInput.Name = "dgInput";
            this.dgInput.Size = new System.Drawing.Size(626, 273);
            this.dgInput.TabIndex = 0;
            this.dgInput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInput});
            // 
            // gvInput
            // 
            this.gvInput.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTrolley,
            this.gcSlurryCode,
            this.gcSlurryDesc,
            this.gcSlurryLot,
            this.gcWeight});
            this.gvInput.GridControl = this.dgInput;
            this.gvInput.Name = "gvInput";
            // 
            // gcTrolley
            // 
            this.gcTrolley.Caption = "Trolley";
            this.gcTrolley.FieldName = "TrolleyCode";
            this.gcTrolley.Name = "gcTrolley";
            this.gcTrolley.OptionsColumn.ReadOnly = true;
            this.gcTrolley.Visible = true;
            this.gcTrolley.VisibleIndex = 0;
            // 
            // gcSlurryCode
            // 
            this.gcSlurryCode.Caption = "Slurry Code";
            this.gcSlurryCode.FieldName = "ItemCode";
            this.gcSlurryCode.Name = "gcSlurryCode";
            this.gcSlurryCode.OptionsColumn.ReadOnly = true;
            this.gcSlurryCode.Visible = true;
            this.gcSlurryCode.VisibleIndex = 1;
            // 
            // gcSlurryDesc
            // 
            this.gcSlurryDesc.Caption = "Slurry Description";
            this.gcSlurryDesc.FieldName = "ItemDesc";
            this.gcSlurryDesc.Name = "gcSlurryDesc";
            this.gcSlurryDesc.OptionsColumn.ReadOnly = true;
            this.gcSlurryDesc.Visible = true;
            this.gcSlurryDesc.VisibleIndex = 2;
            // 
            // gcSlurryLot
            // 
            this.gcSlurryLot.Caption = "Slurry Lot";
            this.gcSlurryLot.FieldName = "LotNumber";
            this.gcSlurryLot.Name = "gcSlurryLot";
            this.gcSlurryLot.OptionsColumn.ReadOnly = true;
            this.gcSlurryLot.Visible = true;
            this.gcSlurryLot.VisibleIndex = 3;
            // 
            // gcWeight
            // 
            this.gcWeight.Caption = "Weight";
            this.gcWeight.FieldName = "Weight";
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.OptionsColumn.ReadOnly = true;
            this.gcWeight.Visible = true;
            this.gcWeight.VisibleIndex = 4;
            // 
            // btnManufacture
            // 
            this.btnManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManufacture.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnManufacture.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnManufacture.Appearance.Options.UseBackColor = true;
            this.btnManufacture.Appearance.Options.UseFont = true;
            this.btnManufacture.Image = ((System.Drawing.Image)(resources.GetObject("btnManufacture.Image")));
            this.btnManufacture.Location = new System.Drawing.Point(1118, 691);
            this.btnManufacture.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnManufacture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnManufacture.Margin = new System.Windows.Forms.Padding(4);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(168, 49);
            this.btnManufacture.TabIndex = 92;
            this.btnManufacture.Text = "Manufacture";
            this.btnManufacture.Click += new System.EventHandler(this.btnManufacture_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pntTnk, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 378);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1273, 306);
            this.tableLayoutPanel1.TabIndex = 93;
            // 
            // pntTnk
            // 
            this.pntTnk.Controls.Add(this.grpZAC);
            this.pntTnk.Controls.Add(this.grpDecant);
            this.pntTnk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pntTnk.Location = new System.Drawing.Point(639, 3);
            this.pntTnk.Name = "pntTnk";
            this.pntTnk.Size = new System.Drawing.Size(631, 300);
            this.pntTnk.TabIndex = 38;
            // 
            // grpZAC
            // 
            this.grpZAC.Controls.Add(this.dgChem);
            this.grpZAC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpZAC.Location = new System.Drawing.Point(0, 0);
            this.grpZAC.Name = "grpZAC";
            this.grpZAC.Size = new System.Drawing.Size(631, 300);
            this.grpZAC.TabIndex = 38;
            this.grpZAC.Text = "Zonen and Charging";
            // 
            // dgChem
            // 
            this.dgChem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgChem.Location = new System.Drawing.Point(2, 25);
            this.dgChem.MainView = this.gvChem;
            this.dgChem.Name = "dgChem";
            this.dgChem.Size = new System.Drawing.Size(627, 273);
            this.dgChem.TabIndex = 0;
            this.dgChem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChem});
            // 
            // gvChem
            // 
            this.gvChem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcChem,
            this.gcQty});
            this.gvChem.GridControl = this.dgChem;
            this.gvChem.Name = "gvChem";
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.ReadOnly = true;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcChem
            // 
            this.gcChem.Caption = "Chemical";
            this.gcChem.FieldName = "ChemName";
            this.gcChem.Name = "gcChem";
            this.gcChem.OptionsColumn.ReadOnly = true;
            this.gcChem.Visible = true;
            this.gcChem.VisibleIndex = 1;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Qty";
            this.gcQty.FieldName = "Qty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.ReadOnly = true;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 2;
            // 
            // grpDecant
            // 
            this.grpDecant.Controls.Add(this.dgDecant);
            this.grpDecant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDecant.Location = new System.Drawing.Point(0, 0);
            this.grpDecant.Name = "grpDecant";
            this.grpDecant.Size = new System.Drawing.Size(631, 300);
            this.grpDecant.TabIndex = 39;
            this.grpDecant.Text = "Decanted Slurries";
            // 
            // dgDecant
            // 
            this.dgDecant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDecant.Location = new System.Drawing.Point(2, 25);
            this.dgDecant.MainView = this.gvDecant;
            this.dgDecant.Name = "dgDecant";
            this.dgDecant.Size = new System.Drawing.Size(627, 273);
            this.dgDecant.TabIndex = 0;
            this.dgDecant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDecant});
            // 
            // gvDecant
            // 
            this.gvDecant.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTankNumber,
            this.gcWetWeight,
            this.gcSolidity,
            this.gcDryWeight});
            this.gvDecant.GridControl = this.dgDecant;
            this.gvDecant.Name = "gvDecant";
            // 
            // gcTankNumber
            // 
            this.gcTankNumber.Caption = "Tank Number";
            this.gcTankNumber.FieldName = "TankNumber";
            this.gcTankNumber.Name = "gcTankNumber";
            this.gcTankNumber.OptionsColumn.AllowEdit = false;
            this.gcTankNumber.Visible = true;
            this.gcTankNumber.VisibleIndex = 0;
            // 
            // gcWetWeight
            // 
            this.gcWetWeight.Caption = "Wet Weight";
            this.gcWetWeight.FieldName = "WetWeight";
            this.gcWetWeight.Name = "gcWetWeight";
            this.gcWetWeight.OptionsColumn.AllowEdit = false;
            this.gcWetWeight.Visible = true;
            this.gcWetWeight.VisibleIndex = 1;
            // 
            // gcSolidity
            // 
            this.gcSolidity.Caption = "Solidity";
            this.gcSolidity.FieldName = "Solidity";
            this.gcSolidity.Name = "gcSolidity";
            this.gcSolidity.OptionsColumn.AllowEdit = false;
            this.gcSolidity.Visible = true;
            this.gcSolidity.VisibleIndex = 2;
            // 
            // gcDryWeight
            // 
            this.gcDryWeight.Caption = "Dry Weight";
            this.gcDryWeight.FieldName = "DryWeight";
            this.gcDryWeight.Name = "gcDryWeight";
            this.gcDryWeight.OptionsColumn.AllowEdit = false;
            this.gcDryWeight.Visible = true;
            this.gcDryWeight.VisibleIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(942, 691);
            this.btnClose.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(168, 49);
            this.btnClose.TabIndex = 94;
            this.btnClose.Text = "Manually Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMixedSlurryManuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 753);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnManufacture);
            this.Controls.Add(this.grpTankInfo);
            this.Controls.Add(this.labelControl13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMixedSlurryManuf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mixed Slurry Manufacture";
            this.Load += new System.EventHandler(this.frmMixedSlurryManuf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpTankInfo)).EndInit();
            this.grpTankInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInput)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pntTnk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpZAC)).EndInit();
            this.grpZAC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDecant)).EndInit();
            this.grpDecant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDecant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDecant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.GroupControl grpTankInfo;
        private DevExpress.XtraGrid.GridControl dgInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInfo;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgInput;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInput;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcValue;
        private DevExpress.XtraEditors.SimpleButton btnManufacture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl grpZAC;
        private DevExpress.XtraGrid.GridControl dgChem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChem;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrolley;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcSlurryLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcChem;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Panel pntTnk;
        private DevExpress.XtraEditors.GroupControl grpDecant;
        private DevExpress.XtraGrid.GridControl dgDecant;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDecant;
        private DevExpress.XtraGrid.Columns.GridColumn gcTankNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcWetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcSolidity;
        private DevExpress.XtraGrid.Columns.GridColumn gcDryWeight;
    }
}