namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    partial class frmAWManufacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAWManufacture));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.btnManufacture = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
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
            this.lblHeader.Location = new System.Drawing.Point(13, 13);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(356, 44);
            this.lblHeader.TabIndex = 93;
            this.lblHeader.Text = "Manufacture AW Pallets";
            // 
            // btnManufacture
            // 
            this.btnManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManufacture.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnManufacture.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnManufacture.Appearance.Options.UseBackColor = true;
            this.btnManufacture.Appearance.Options.UseFont = true;
            this.btnManufacture.Image = ((System.Drawing.Image)(resources.GetObject("btnManufacture.Image")));
            this.btnManufacture.Location = new System.Drawing.Point(790, 8);
            this.btnManufacture.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnManufacture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnManufacture.Margin = new System.Windows.Forms.Padding(4);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(207, 49);
            this.btnManufacture.TabIndex = 94;
            this.btnManufacture.Text = "Manufacture All";
            this.btnManufacture.Click += new System.EventHandler(this.btnManufacture_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(13, 65);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(984, 535);
            this.dgItems.TabIndex = 95;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcPalletCode,
            this.gcPalletNo,
            this.gcQty,
            this.gcDate,
            this.gcUserAdded,
            this.gcManuf});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
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
            // gcPalletCode
            // 
            this.gcPalletCode.Caption = "Pallet Code";
            this.gcPalletCode.FieldName = "gcPalletCode";
            this.gcPalletCode.Name = "gcPalletCode";
            this.gcPalletCode.OptionsColumn.AllowEdit = false;
            // 
            // gcPalletNo
            // 
            this.gcPalletNo.Caption = "Pallet Number";
            this.gcPalletNo.FieldName = "gcPalletNo";
            this.gcPalletNo.Name = "gcPalletNo";
            this.gcPalletNo.OptionsColumn.AllowEdit = false;
            this.gcPalletNo.Visible = true;
            this.gcPalletNo.VisibleIndex = 1;
            // 
            // gcQty
            // 
            this.gcQty.Caption = "Quantity";
            this.gcQty.FieldName = "gcQty";
            this.gcQty.Name = "gcQty";
            this.gcQty.OptionsColumn.AllowEdit = false;
            this.gcQty.Visible = true;
            this.gcQty.VisibleIndex = 2;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Date Produced";
            this.gcDate.FieldName = "gcDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowEdit = false;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 3;
            // 
            // gcUserAdded
            // 
            this.gcUserAdded.Caption = "Produced By";
            this.gcUserAdded.FieldName = "gcUserAdded";
            this.gcUserAdded.Name = "gcUserAdded";
            this.gcUserAdded.OptionsColumn.AllowEdit = false;
            this.gcUserAdded.Visible = true;
            this.gcUserAdded.VisibleIndex = 4;
            // 
            // gcManuf
            // 
            this.gcManuf.Caption = "Manufacture Pallet";
            this.gcManuf.FieldName = "gcManuf";
            this.gcManuf.Name = "gcManuf";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Description = "Retreiving Containers ...";
            this.ppnlWait.Location = new System.Drawing.Point(13, 0);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(985, 613);
            this.ppnlWait.TabIndex = 96;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(575, 8);
            this.btnClose.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(207, 49);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Manually Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAWManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 612);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.btnManufacture);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAWManufacture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manufacture AW Pallets";
            this.Load += new System.EventHandler(this.frmAWManufacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.SimpleButton btnManufacture;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcManuf;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}