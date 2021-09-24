namespace RTIS_Vulcan_UI.Controls
{
    partial class ucPOAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPOAdmin));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgLink = new DevExpress.XtraGrid.GridControl();
            this.gvLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLinkPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPOs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricbOrders = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ppnlWaitLink = new DevExpress.XtraWaitForm.ProgressPanel();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.pnlVendors = new System.Windows.Forms.Panel();
            this.dgVendors = new DevExpress.XtraGrid.GridControl();
            this.gvVendors = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcViewable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pplWaitVendors = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrVendors = new System.Windows.Forms.Timer(this.components);
            this.tmrLinks = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbOrders)).BeginInit();
            this.pnlVendors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelected)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl13, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlVendors, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1309, 783);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgLink);
            this.panel1.Controls.Add(this.ppnlWaitLink);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 448);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 331);
            this.panel1.TabIndex = 1;
            // 
            // dgLink
            // 
            this.dgLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLink.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgLink.Location = new System.Drawing.Point(0, 0);
            this.dgLink.MainView = this.gvLink;
            this.dgLink.Margin = new System.Windows.Forms.Padding(4);
            this.dgLink.Name = "dgLink";
            this.dgLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ricbOrders});
            this.dgLink.Size = new System.Drawing.Size(1301, 331);
            this.dgLink.TabIndex = 36;
            this.dgLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLink});
            // 
            // gvLink
            // 
            this.gvLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLinkID,
            this.gcSupplier,
            this.gcPO,
            this.gcLinkPO,
            this.gcDate,
            this.gcPOs});
            this.gvLink.GridControl = this.dgLink;
            this.gvLink.Name = "gvLink";
            this.gvLink.OptionsFind.AlwaysVisible = true;
            this.gvLink.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvLink_RowStyle);
            this.gvLink.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvLink_CellValueChanged);
            // 
            // gcLinkID
            // 
            this.gcLinkID.Caption = "ID";
            this.gcLinkID.FieldName = "gcLinkID";
            this.gcLinkID.Name = "gcLinkID";
            // 
            // gcSupplier
            // 
            this.gcSupplier.Caption = "Supplier";
            this.gcSupplier.FieldName = "gcSupplier";
            this.gcSupplier.Name = "gcSupplier";
            this.gcSupplier.Visible = true;
            this.gcSupplier.VisibleIndex = 0;
            // 
            // gcPO
            // 
            this.gcPO.Caption = "Standing Purchase Order";
            this.gcPO.FieldName = "gcPO";
            this.gcPO.Name = "gcPO";
            this.gcPO.Visible = true;
            this.gcPO.VisibleIndex = 1;
            // 
            // gcLinkPO
            // 
            this.gcLinkPO.Caption = "Update Link Line";
            this.gcLinkPO.FieldName = "gcLinkPO";
            this.gcLinkPO.MinWidth = 25;
            this.gcLinkPO.Name = "gcLinkPO";
            this.gcLinkPO.Visible = true;
            this.gcLinkPO.VisibleIndex = 2;
            this.gcLinkPO.Width = 94;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Date Updated";
            this.gcDate.FieldName = "gcDate";
            this.gcDate.Name = "gcDate";
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 3;
            // 
            // gcPOs
            // 
            this.gcPOs.Caption = "Purchase Orders";
            this.gcPOs.FieldName = "gcPOs";
            this.gcPOs.Name = "gcPOs";
            // 
            // ricbOrders
            // 
            this.ricbOrders.AutoHeight = false;
            this.ricbOrders.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ricbOrders.Name = "ricbOrders";
            // 
            // ppnlWaitLink
            // 
            this.ppnlWaitLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWaitLink.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWaitLink.Appearance.Options.UseBackColor = true;
            this.ppnlWaitLink.Location = new System.Drawing.Point(4, 4);
            this.ppnlWaitLink.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWaitLink.Name = "ppnlWaitLink";
            this.ppnlWaitLink.Size = new System.Drawing.Size(1293, 324);
            this.ppnlWaitLink.TabIndex = 37;
            this.ppnlWaitLink.Text = "progressPanel1";
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
            this.labelControl13.Size = new System.Drawing.Size(372, 44);
            this.labelControl13.TabIndex = 62;
            this.labelControl13.Text = "Select Standard Suppliers";
            // 
            // pnlVendors
            // 
            this.pnlVendors.Controls.Add(this.dgVendors);
            this.pnlVendors.Controls.Add(this.pplWaitVendors);
            this.pnlVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVendors.Location = new System.Drawing.Point(4, 58);
            this.pnlVendors.Margin = new System.Windows.Forms.Padding(4);
            this.pnlVendors.Name = "pnlVendors";
            this.pnlVendors.Size = new System.Drawing.Size(1301, 328);
            this.pnlVendors.TabIndex = 1;
            // 
            // dgVendors
            // 
            this.dgVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVendors.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.dgVendors.Location = new System.Drawing.Point(0, 0);
            this.dgVendors.MainView = this.gvVendors;
            this.dgVendors.Margin = new System.Windows.Forms.Padding(4);
            this.dgVendors.Name = "dgVendors";
            this.dgVendors.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceSelected});
            this.dgVendors.Size = new System.Drawing.Size(1301, 328);
            this.dgVendors.TabIndex = 35;
            this.dgVendors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVendors});
            // 
            // gvVendors
            // 
            this.gvVendors.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcName,
            this.gcViewable,
            this.gcID});
            this.gvVendors.GridControl = this.dgVendors;
            this.gvVendors.Name = "gvVendors";
            this.gvVendors.OptionsFind.AlwaysVisible = true;
            this.gvVendors.OptionsView.ColumnAutoWidth = false;
            this.gvVendors.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvVendors_CellValueChanged);
            // 
            // gcName
            // 
            this.gcName.Caption = "Supplier Name";
            this.gcName.FieldName = "gcName";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 0;
            this.gcName.Width = 777;
            // 
            // gcViewable
            // 
            this.gcViewable.Caption = "Viewable";
            this.gcViewable.ColumnEdit = this.riceSelected;
            this.gcViewable.FieldName = "gcViewable";
            this.gcViewable.Name = "gcViewable";
            this.gcViewable.Visible = true;
            this.gcViewable.VisibleIndex = 1;
            // 
            // riceSelected
            // 
            this.riceSelected.AutoHeight = false;
            this.riceSelected.Name = "riceSelected";
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            // 
            // pplWaitVendors
            // 
            this.pplWaitVendors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pplWaitVendors.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pplWaitVendors.Appearance.Options.UseBackColor = true;
            this.pplWaitVendors.Location = new System.Drawing.Point(4, 4);
            this.pplWaitVendors.Margin = new System.Windows.Forms.Padding(4);
            this.pplWaitVendors.Name = "pplWaitVendors";
            this.pplWaitVendors.Size = new System.Drawing.Size(1293, 320);
            this.pplWaitVendors.TabIndex = 0;
            this.pplWaitVendors.Text = "progressPanel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1303, 48);
            this.panel2.TabIndex = 63;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1256, 4);
            this.btnRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(43, 41);
            this.btnRefresh.TabIndex = 89;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 45);
            this.label1.TabIndex = 64;
            this.label1.Text = "Link Standing Purchase Orders";
            // 
            // tmrVendors
            // 
            this.tmrVendors.Tick += new System.EventHandler(this.tmrVendors_Tick);
            // 
            // tmrLinks
            // 
            this.tmrLinks.Tick += new System.EventHandler(this.tmrLinks_Tick);
            // 
            // ucPOAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucPOAdmin";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucPOAdmin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricbOrders)).EndInit();
            this.pnlVendors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelected)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl dgVendors;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVendors;
        private DevExpress.XtraGrid.GridControl dgLink;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcViewable;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private System.Windows.Forms.Panel pnlVendors;
        private DevExpress.XtraWaitForm.ProgressPanel pplWaitVendors;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private System.Windows.Forms.Timer tmrVendors;
        private DevExpress.XtraGrid.Columns.GridColumn gcLinkID;
        private DevExpress.XtraGrid.Columns.GridColumn gcSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn gcPO;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcPOs;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWaitLink;
        private System.Windows.Forms.Timer tmrLinks;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricbOrders;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gcLinkPO;
    }
}
