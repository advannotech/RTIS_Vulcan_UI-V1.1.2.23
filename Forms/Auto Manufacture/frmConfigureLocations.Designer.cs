namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    partial class frmConfigureLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigureLocations));
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnEditNpl = new DevExpress.XtraEditors.SimpleButton();
            this.dgChem = new DevExpress.XtraGrid.GridControl();
            this.gvChem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.btnEditMS = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgChem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChem)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgItems
            // 
            this.dgItems.Location = new System.Drawing.Point(4, 136);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(663, 302);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProcess,
            this.gcSource,
            this.gcDest});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.DoubleClick += new System.EventHandler(this.gvItems_DoubleClick);
            // 
            // gcProcess
            // 
            this.gcProcess.Caption = "Process";
            this.gcProcess.FieldName = "gcProcess";
            this.gcProcess.Name = "gcProcess";
            this.gcProcess.OptionsColumn.AllowEdit = false;
            this.gcProcess.Visible = true;
            this.gcProcess.VisibleIndex = 0;
            // 
            // gcSource
            // 
            this.gcSource.Caption = "Source";
            this.gcSource.FieldName = "gcSource";
            this.gcSource.Name = "gcSource";
            this.gcSource.OptionsColumn.AllowEdit = false;
            this.gcSource.Visible = true;
            this.gcSource.VisibleIndex = 1;
            // 
            // gcDest
            // 
            this.gcDest.Caption = "Destination";
            this.gcDest.FieldName = "gcDest";
            this.gcDest.Name = "gcDest";
            this.gcDest.OptionsColumn.AllowEdit = false;
            this.gcDest.Visible = true;
            this.gcDest.VisibleIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.Appearance.Options.UseForeColor = true;
            this.lblHeader.Appearance.Options.UseTextOptions = true;
            this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Location = new System.Drawing.Point(4, 4);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(663, 125);
            this.lblHeader.TabIndex = 93;
            this.lblHeader.Text = "This form configures the manufacture locations for the CATscan system, if you do " +
    "not know what this is, do not change anything.";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(499, 445);
            this.btnEdit.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(168, 49);
            this.btnEdit.TabIndex = 94;
            this.btnEdit.Text = "Edit";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(13, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(678, 532);
            this.xtraTabControl1.TabIndex = 95;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.lblHeader);
            this.xtraTabPage1.Controls.Add(this.btnEdit);
            this.xtraTabPage1.Controls.Add(this.dgItems);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(671, 498);
            this.xtraTabPage1.Text = "Manufacture Locations";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.btnEditNpl);
            this.xtraTabPage2.Controls.Add(this.dgChem);
            this.xtraTabPage2.Controls.Add(this.labelControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(671, 498);
            this.xtraTabPage2.Text = "NPL Percentages";
            // 
            // btnEditNpl
            // 
            this.btnEditNpl.Image = ((System.Drawing.Image)(resources.GetObject("btnEditNpl.Image")));
            this.btnEditNpl.Location = new System.Drawing.Point(499, 445);
            this.btnEditNpl.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEditNpl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEditNpl.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditNpl.Name = "btnEditNpl";
            this.btnEditNpl.Size = new System.Drawing.Size(168, 49);
            this.btnEditNpl.TabIndex = 96;
            this.btnEditNpl.Text = "Edit";
            this.btnEditNpl.Click += new System.EventHandler(this.btnEditNpl_Click);
            // 
            // dgChem
            // 
            this.dgChem.Location = new System.Drawing.Point(4, 137);
            this.dgChem.MainView = this.gvChem;
            this.dgChem.Name = "dgChem";
            this.dgChem.Size = new System.Drawing.Size(663, 301);
            this.dgChem.TabIndex = 95;
            this.dgChem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChem});
            // 
            // gvChem
            // 
            this.gvChem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcPercentage});
            this.gvChem.GridControl = this.dgChem;
            this.gvChem.Name = "gvChem";
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcPercentage
            // 
            this.gcPercentage.Caption = "Percentage";
            this.gcPercentage.FieldName = "Percentage";
            this.gcPercentage.Name = "gcPercentage";
            this.gcPercentage.OptionsColumn.ReadOnly = true;
            this.gcPercentage.Visible = true;
            this.gcPercentage.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(663, 125);
            this.labelControl1.TabIndex = 94;
            this.labelControl1.Text = "This form configures the NPL percentages for mixed slurry manufacture, if you do " +
    "not know what this is, do not change anything.";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.txtID);
            this.xtraTabPage3.Controls.Add(this.labelControl3);
            this.xtraTabPage3.Controls.Add(this.labelControl2);
            this.xtraTabPage3.Controls.Add(this.btnEditMS);
            this.xtraTabPage3.Controls.Add(this.btnSave);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(671, 498);
            this.xtraTabPage3.Text = "Journal Config";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(4, 4);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(663, 125);
            this.labelControl2.TabIndex = 95;
            this.labelControl2.Text = "This form configures the Journal ID for mixed slurry manufacturing, if you do not" +
    " know what this is, do not change anything.\r\n";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(210, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(236, 28);
            this.labelControl3.TabIndex = 98;
            this.labelControl3.Text = "Mixed Slurry Journal ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(210, 171);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Size = new System.Drawing.Size(236, 34);
            this.txtID.TabIndex = 99;
            // 
            // btnEditMS
            // 
            this.btnEditMS.Image = ((System.Drawing.Image)(resources.GetObject("btnEditMS.Image")));
            this.btnEditMS.Location = new System.Drawing.Point(235, 212);
            this.btnEditMS.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEditMS.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEditMS.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditMS.Name = "btnEditMS";
            this.btnEditMS.Size = new System.Drawing.Size(168, 49);
            this.btnEditMS.TabIndex = 100;
            this.btnEditMS.Text = "Edit";
            this.btnEditMS.Click += new System.EventHandler(this.btnEditMS_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(235, 212);
            this.btnSave.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(168, 49);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmConfigureLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 556);
            this.Controls.Add(this.xtraTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigureLocations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Source and Destination Locations for Manufacturing";
            this.Load += new System.EventHandler(this.frmConfigureLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgChem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChem)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gcSource;
        private DevExpress.XtraGrid.Columns.GridColumn gcDest;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        internal DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dgChem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChem;
        internal DevExpress.XtraEditors.SimpleButton btnEditNpl;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcPercentage;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        internal DevExpress.XtraEditors.SimpleButton btnEditMS;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.SimpleButton btnSave;
    }
}