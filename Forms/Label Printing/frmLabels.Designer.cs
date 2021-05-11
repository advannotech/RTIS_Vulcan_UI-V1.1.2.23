namespace RTIS_Vulcan_UI.Forms
{
    partial class frmLabels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabels));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgLabels = new DevExpress.XtraGrid.GridControl();
            this.gvLabels = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribeCbSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCLose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeCbSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(7, 6);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 24);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Select a Label";
            // 
            // dgLabels
            // 
            this.dgLabels.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgLabels.Location = new System.Drawing.Point(7, 37);
            this.dgLabels.MainView = this.gvLabels;
            this.dgLabels.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgLabels.Name = "dgLabels";
            this.dgLabels.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ribeCbSelect});
            this.dgLabels.Size = new System.Drawing.Size(517, 258);
            this.dgLabels.TabIndex = 9;
            this.dgLabels.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLabels});
            // 
            // gvLabels
            // 
            this.gvLabels.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcType,
            this.gcSelected});
            this.gvLabels.GridControl = this.dgLabels;
            this.gvLabels.Name = "gvLabels";
            this.gvLabels.OptionsView.ShowGroupPanel = false;
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "gcName";
            this.gcName.Name = "gcName";
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            // 
            // gcType
            // 
            this.gcType.Caption = "Type";
            this.gcType.FieldName = "gcType";
            this.gcType.Name = "gcType";
            this.gcType.Visible = true;
            this.gcType.VisibleIndex = 1;
            // 
            // gcSelected
            // 
            this.gcSelected.Caption = "Selected";
            this.gcSelected.ColumnEdit = this.ribeCbSelect;
            this.gcSelected.FieldName = "gcSelected";
            this.gcSelected.Name = "gcSelected";
            this.gcSelected.Visible = true;
            this.gcSelected.VisibleIndex = 2;
            // 
            // ribeCbSelect
            // 
            this.ribeCbSelect.AutoHeight = false;
            this.ribeCbSelect.Name = "ribeCbSelect";
            this.ribeCbSelect.CheckedChanged += new System.EventHandler(this.ribeCbSelect_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(532, 37);
            this.btnOk.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnOk.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(168, 49);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Open";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(532, 94);
            this.btnDelete.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnDelete.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(168, 49);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLose.Image = ((System.Drawing.Image)(resources.GetObject("btnCLose.Image")));
            this.btnCLose.Location = new System.Drawing.Point(532, 246);
            this.btnCLose.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnCLose.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCLose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCLose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(168, 49);
            this.btnCLose.TabIndex = 19;
            this.btnCLose.Text = "Close";
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Controls.Add(this.btnCLose);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.dgLabels);
            this.panelControl1.Location = new System.Drawing.Point(16, 15);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(707, 304);
            this.panelControl1.TabIndex = 20;
            // 
            // frmLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 335);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLabels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existing Labels";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLabels_FormClosing);
            this.Load += new System.EventHandler(this.frmLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeCbSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dgLabels;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLabels;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcType;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ribeCbSelect;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCLose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}