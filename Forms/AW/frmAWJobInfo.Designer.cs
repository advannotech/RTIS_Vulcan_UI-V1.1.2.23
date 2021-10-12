namespace RTIS_Vulcan_UI.Forms
{
    partial class frmAWJobInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAWJobInfo));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.dgInfo = new DevExpress.XtraGrid.GridControl();
            this.gvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.dgInputs = new DevExpress.XtraGrid.GridControl();
            this.gvInputs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCatalyst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCatalystLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.dgOutputs = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPalletNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrInputs = new System.Windows.Forms.Timer(this.components);
            this.tmrOutputs = new System.Windows.Forms.Timer(this.components);
            this.btnManuallyClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInputs)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.labelControl13.Size = new System.Drawing.Size(318, 44);
            this.labelControl13.TabIndex = 36;
            this.labelControl13.Text = "A&&W Job Information";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Location = new System.Drawing.Point(13, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1123, 402);
            this.panelControl1.TabIndex = 37;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(6, 6);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1112, 391);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.dgInfo);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1110, 361);
            this.xtraTabPage1.Text = "General Information";
            // 
            // dgInfo
            // 
            this.dgInfo.Location = new System.Drawing.Point(4, 4);
            this.dgInfo.MainView = this.gvInfo;
            this.dgInfo.Name = "dgInfo";
            this.dgInfo.Size = new System.Drawing.Size(1098, 350);
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
            this.gvInfo.OptionsView.ShowGroupPanel = false;
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "gcName";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcValue
            // 
            this.gcValue.Caption = "Value";
            this.gcValue.FieldName = "gcValue";
            this.gcValue.Name = "gcValue";
            this.gcValue.OptionsColumn.ReadOnly = true;
            this.gcValue.Visible = true;
            this.gcValue.VisibleIndex = 1;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.labelControl19);
            this.xtraTabPage2.Controls.Add(this.dgInputs);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1110, 361);
            this.xtraTabPage2.Text = "Inputs";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Appearance.Options.UseForeColor = true;
            this.labelControl19.Location = new System.Drawing.Point(3, 2);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(171, 33);
            this.labelControl19.TabIndex = 45;
            this.labelControl19.Text = "ZECT Job Inputs";
            // 
            // dgInputs
            // 
            this.dgInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgInputs.Location = new System.Drawing.Point(3, 41);
            this.dgInputs.MainView = this.gvInputs;
            this.dgInputs.Name = "dgInputs";
            this.dgInputs.Size = new System.Drawing.Size(1099, 313);
            this.dgInputs.TabIndex = 44;
            this.dgInputs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInputs});
            // 
            // gvInputs
            // 
            this.gvInputs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCatalyst,
            this.gcCatalystLot,
            this.gcQty,
            this.gcDate,
            this.gcUser});
            this.gvInputs.GridControl = this.dgInputs;
            this.gvInputs.Name = "gvInputs";
            // 
            // gcCatalyst
            // 
            this.gcCatalyst.Caption = "Catalyst";
            this.gcCatalyst.FieldName = "gcCatalyst";
            this.gcCatalyst.Name = "gcCatalyst";
            this.gcCatalyst.OptionsColumn.AllowEdit = false;
            this.gcCatalyst.Visible = true;
            this.gcCatalyst.VisibleIndex = 0;
            // 
            // gcCatalystLot
            // 
            this.gcCatalystLot.Caption = "Catalyst Lot";
            this.gcCatalystLot.FieldName = "gcCatalystLot";
            this.gcCatalystLot.Name = "gcCatalystLot";
            this.gcCatalystLot.OptionsColumn.AllowEdit = false;
            this.gcCatalystLot.Visible = true;
            this.gcCatalystLot.VisibleIndex = 1;
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
            // gcDate
            // 
            this.gcDate.Caption = "Date";
            this.gcDate.FieldName = "gcDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.OptionsColumn.AllowEdit = false;
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 3;
            // 
            // gcUser
            // 
            this.gcUser.Caption = "User";
            this.gcUser.FieldName = "gcUser";
            this.gcUser.Name = "gcUser";
            this.gcUser.OptionsColumn.AllowEdit = false;
            this.gcUser.Visible = true;
            this.gcUser.VisibleIndex = 4;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.dgOutputs);
            this.xtraTabPage3.Controls.Add(this.labelControl1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1110, 361);
            this.xtraTabPage3.Text = "Outputs";
            // 
            // dgOutputs
            // 
            this.dgOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOutputs.Location = new System.Drawing.Point(2, 41);
            this.dgOutputs.MainView = this.gridView2;
            this.dgOutputs.Name = "dgOutputs";
            this.dgOutputs.Size = new System.Drawing.Size(1100, 313);
            this.dgOutputs.TabIndex = 47;
            this.dgOutputs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcPalletNumber,
            this.gcPalletQty,
            this.gcPalletUser,
            this.gcPalletDate,
            this.gcManuf,
            this.gcDateManuf,
            this.gcUserManuf});
            this.gridView2.GridControl = this.dgOutputs;
            this.gridView2.Name = "gridView2";
            // 
            // gcPalletNumber
            // 
            this.gcPalletNumber.Caption = "Pallet Number";
            this.gcPalletNumber.FieldName = "gcPalletNumber";
            this.gcPalletNumber.Name = "gcPalletNumber";
            this.gcPalletNumber.OptionsColumn.AllowEdit = false;
            this.gcPalletNumber.Visible = true;
            this.gcPalletNumber.VisibleIndex = 0;
            // 
            // gcPalletQty
            // 
            this.gcPalletQty.Caption = "Pallet Qty";
            this.gcPalletQty.FieldName = "gcPalletQty";
            this.gcPalletQty.Name = "gcPalletQty";
            this.gcPalletQty.OptionsColumn.AllowEdit = false;
            this.gcPalletQty.Visible = true;
            this.gcPalletQty.VisibleIndex = 1;
            // 
            // gcPalletUser
            // 
            this.gcPalletUser.Caption = "User Printed";
            this.gcPalletUser.FieldName = "gcPalletUser";
            this.gcPalletUser.Name = "gcPalletUser";
            this.gcPalletUser.OptionsColumn.AllowEdit = false;
            this.gcPalletUser.Visible = true;
            this.gcPalletUser.VisibleIndex = 2;
            // 
            // gcPalletDate
            // 
            this.gcPalletDate.Caption = "Date Printed";
            this.gcPalletDate.FieldName = "gcPalletDate";
            this.gcPalletDate.Name = "gcPalletDate";
            this.gcPalletDate.OptionsColumn.AllowEdit = false;
            this.gcPalletDate.Visible = true;
            this.gcPalletDate.VisibleIndex = 3;
            // 
            // gcManuf
            // 
            this.gcManuf.Caption = "Manufactured";
            this.gcManuf.FieldName = "gcManuf";
            this.gcManuf.Name = "gcManuf";
            this.gcManuf.OptionsColumn.AllowEdit = false;
            this.gcManuf.Visible = true;
            this.gcManuf.VisibleIndex = 4;
            // 
            // gcDateManuf
            // 
            this.gcDateManuf.Caption = "Date Manufactured";
            this.gcDateManuf.FieldName = "gcDateManuf";
            this.gcDateManuf.Name = "gcDateManuf";
            this.gcDateManuf.OptionsColumn.AllowEdit = false;
            this.gcDateManuf.Visible = true;
            this.gcDateManuf.VisibleIndex = 5;
            // 
            // gcUserManuf
            // 
            this.gcUserManuf.Caption = "Manufactured By";
            this.gcUserManuf.FieldName = "gcUserManuf";
            this.gcUserManuf.Name = "gcUserManuf";
            this.gcUserManuf.OptionsColumn.AllowEdit = false;
            this.gcUserManuf.Visible = true;
            this.gcUserManuf.VisibleIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(182, 33);
            this.labelControl1.TabIndex = 46;
            this.labelControl1.Text = "ZECT Job Ouputs";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.Location = new System.Drawing.Point(13, 3);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1123, 473);
            this.ppnlWait.TabIndex = 39;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrInputs
            // 
            this.tmrInputs.Tick += new System.EventHandler(this.tmrInputs_Tick);
            // 
            // tmrOutputs
            // 
            this.tmrOutputs.Tick += new System.EventHandler(this.tmrOutputs_Tick);
            // 
            // btnManuallyClose
            // 
            this.btnManuallyClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManuallyClose.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnManuallyClose.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnManuallyClose.Appearance.Options.UseBackColor = true;
            this.btnManuallyClose.Appearance.Options.UseFont = true;
            this.btnManuallyClose.Enabled = false;
            this.btnManuallyClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnManuallyClose.ImageOptions.Image")));
            this.btnManuallyClose.Location = new System.Drawing.Point(924, 9);
            this.btnManuallyClose.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnManuallyClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnManuallyClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnManuallyClose.Name = "btnManuallyClose";
            this.btnManuallyClose.Size = new System.Drawing.Size(207, 49);
            this.btnManuallyClose.TabIndex = 104;
            this.btnManuallyClose.Text = "Manually Close";
            this.btnManuallyClose.Click += new System.EventHandler(this.btnManuallyClose_Click);
            // 
            // frmAWJobInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1148, 479);
            this.Controls.Add(this.btnManuallyClose);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAWJobInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A&W Job Information";
            this.Load += new System.EventHandler(this.frmAWJobInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInputs)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl dgInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcValue;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrInputs;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraGrid.GridControl dgInputs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInputs;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatalyst;
        private DevExpress.XtraGrid.Columns.GridColumn gcCatalystLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser;
        private System.Windows.Forms.Timer tmrOutputs;
        private DevExpress.XtraGrid.GridControl dgOutputs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserManuf;
        private DevExpress.XtraEditors.SimpleButton btnManuallyClose;
    }
}