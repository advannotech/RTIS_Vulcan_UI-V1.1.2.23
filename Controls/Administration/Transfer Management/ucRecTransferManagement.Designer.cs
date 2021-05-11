namespace RTIS_Vulcan_UI
{
    partial class ucRecTransferManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecTransferManagement));
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.dgWhses = new DevExpress.XtraGrid.GridControl();
            this.gvWhses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcWhseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWhseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cmbProcess = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWhses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).BeginInit();
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
            this.labelControl13.Size = new System.Drawing.Size(420, 44);
            this.labelControl13.TabIndex = 33;
            this.labelControl13.Text = "Receiving Warehouse Admin";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.dgWhses);
            this.pnlBack.Controls.Add(this.groupControl1);
            this.pnlBack.Location = new System.Drawing.Point(4, 56);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1312, 732);
            this.pnlBack.TabIndex = 34;
            // 
            // dgWhses
            // 
            this.dgWhses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgWhses.Location = new System.Drawing.Point(5, 100);
            this.dgWhses.MainView = this.gvWhses;
            this.dgWhses.Name = "dgWhses";
            this.dgWhses.Size = new System.Drawing.Size(1301, 627);
            this.dgWhses.TabIndex = 2;
            this.dgWhses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWhses});
            // 
            // gvWhses
            // 
            this.gvWhses.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcWhseID,
            this.gcWhseName,
            this.gcSelected});
            this.gvWhses.GridControl = this.dgWhses;
            this.gvWhses.Name = "gvWhses";
            this.gvWhses.OptionsFind.AlwaysVisible = true;
            this.gvWhses.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvWhses_CellValueChanged);
            // 
            // gcWhseID
            // 
            this.gcWhseID.Caption = "Warehouse ID";
            this.gcWhseID.FieldName = "gcWhseID";
            this.gcWhseID.Name = "gcWhseID";
            this.gcWhseID.Visible = true;
            this.gcWhseID.VisibleIndex = 0;
            // 
            // gcWhseName
            // 
            this.gcWhseName.Caption = "Warehouse Name";
            this.gcWhseName.FieldName = "gcWhseName";
            this.gcWhseName.Name = "gcWhseName";
            this.gcWhseName.Visible = true;
            this.gcWhseName.VisibleIndex = 1;
            // 
            // gcSelected
            // 
            this.gcSelected.Caption = "Selected";
            this.gcSelected.FieldName = "gcSelected";
            this.gcSelected.Name = "gcSelected";
            this.gcSelected.Visible = true;
            this.gcSelected.VisibleIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.cmbProcess);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1301, 88);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1245, 29);
            this.btnSearch.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 49);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(6, 29);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(88, 16);
            this.labelControl9.TabIndex = 42;
            this.labelControl9.Text = "Select Process:";
            // 
            // cmbProcess
            // 
            this.cmbProcess.Location = new System.Drawing.Point(6, 53);
            this.cmbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProcess.Name = "cmbProcess";
            this.cmbProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProcess.Size = new System.Drawing.Size(408, 22);
            this.cmbProcess.TabIndex = 41;
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(4, 2);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1311, 787);
            this.ppnlWait.TabIndex = 35;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ucRecTransferManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucRecTransferManagement";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucRecTransferManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWhses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWhses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcess.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProcess;
        private DevExpress.XtraGrid.GridControl dgWhses;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWhses;
        private DevExpress.XtraGrid.Columns.GridColumn gcWhseID;
        private DevExpress.XtraGrid.Columns.GridColumn gcWhseName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelected;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private System.Windows.Forms.Timer tmrItems;
    }
}
