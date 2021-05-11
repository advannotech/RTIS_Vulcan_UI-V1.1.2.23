namespace RTIS_Vulcan_UI.Controls.Purchase_Orders
{
    partial class ucCMSAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCMSAdmin));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDeleteItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRefreshItems = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddUOM = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dgUOM = new DevExpress.XtraGrid.GridControl();
            this.gvUOM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcUOMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUOMValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDeleteUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUOM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.labelControl13);
            this.panelControl1.Controls.Add(this.btnAddItem);
            this.panelControl1.Controls.Add(this.dgItems);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(650, 670);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Appearance.Options.UseForeColor = true;
            this.labelControl13.Location = new System.Drawing.Point(6, 6);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(157, 44);
            this.labelControl13.TabIndex = 34;
            this.labelControl13.Text = "CMS Items";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(476, 6);
            this.btnAddItem.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnAddItem.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddItem.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(168, 49);
            this.btnAddItem.TabIndex = 45;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(5, 66);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(639, 599);
            this.dgItems.TabIndex = 0;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcItemID,
            this.gcItemValue,
            this.gcDeleteItem});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            // 
            // gcItemID
            // 
            this.gcItemID.Caption = "ID";
            this.gcItemID.FieldName = "gcItemID";
            this.gcItemID.Name = "gcItemID";
            // 
            // gcItemValue
            // 
            this.gcItemValue.Caption = "Value";
            this.gcItemValue.FieldName = "gcItemValue";
            this.gcItemValue.Name = "gcItemValue";
            this.gcItemValue.OptionsColumn.ReadOnly = true;
            this.gcItemValue.Visible = true;
            this.gcItemValue.VisibleIndex = 0;
            // 
            // gcDeleteItem
            // 
            this.gcDeleteItem.Caption = "Remove Item";
            this.gcDeleteItem.Name = "gcDeleteItem";
            this.gcDeleteItem.Visible = true;
            this.gcDeleteItem.VisibleIndex = 1;
            // 
            // btnRefreshItems
            // 
            this.btnRefreshItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshItems.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshItems.Image")));
            this.btnRefreshItems.Location = new System.Drawing.Point(1145, 738);
            this.btnRefreshItems.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnRefreshItems.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefreshItems.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefreshItems.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshItems.Name = "btnRefreshItems";
            this.btnRefreshItems.Size = new System.Drawing.Size(168, 49);
            this.btnRefreshItems.TabIndex = 46;
            this.btnRefreshItems.Text = "Refresh";
            this.btnRefreshItems.Click += new System.EventHandler(this.btnRefreshItems_Click);
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
            this.labelControl1.Size = new System.Drawing.Size(293, 44);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "CMS Administration";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1312, 676);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.btnAddUOM);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.dgUOM);
            this.panelControl2.Location = new System.Drawing.Point(659, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(650, 670);
            this.panelControl2.TabIndex = 1;
            // 
            // btnAddUOM
            // 
            this.btnAddUOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUOM.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUOM.Image")));
            this.btnAddUOM.Location = new System.Drawing.Point(476, 6);
            this.btnAddUOM.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnAddUOM.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddUOM.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddUOM.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUOM.Name = "btnAddUOM";
            this.btnAddUOM.Size = new System.Drawing.Size(168, 49);
            this.btnAddUOM.TabIndex = 49;
            this.btnAddUOM.Text = "Add UOM";
            this.btnAddUOM.Click += new System.EventHandler(this.btnAddUOM_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 6);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(167, 44);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "CMS UOMs";
            // 
            // dgUOM
            // 
            this.dgUOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUOM.Location = new System.Drawing.Point(5, 66);
            this.dgUOM.MainView = this.gvUOM;
            this.dgUOM.Name = "dgUOM";
            this.dgUOM.Size = new System.Drawing.Size(639, 599);
            this.dgUOM.TabIndex = 0;
            this.dgUOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUOM});
            // 
            // gvUOM
            // 
            this.gvUOM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcUOMID,
            this.gcUOMValue,
            this.gcDeleteUOM});
            this.gvUOM.GridControl = this.dgUOM;
            this.gvUOM.Name = "gvUOM";
            this.gvUOM.OptionsFind.AlwaysVisible = true;
            // 
            // gcUOMID
            // 
            this.gcUOMID.Caption = "ID";
            this.gcUOMID.FieldName = "gcUOMID";
            this.gcUOMID.Name = "gcUOMID";
            // 
            // gcUOMValue
            // 
            this.gcUOMValue.Caption = "UOM";
            this.gcUOMValue.FieldName = "gcUOMValue";
            this.gcUOMValue.Name = "gcUOMValue";
            this.gcUOMValue.OptionsColumn.ReadOnly = true;
            this.gcUOMValue.Visible = true;
            this.gcUOMValue.VisibleIndex = 0;
            // 
            // gcDeleteUOM
            // 
            this.gcDeleteUOM.Caption = "Remove";
            this.gcDeleteUOM.Name = "gcDeleteUOM";
            this.gcDeleteUOM.Visible = true;
            this.gcDeleteUOM.VisibleIndex = 1;
            // 
            // ucCMSAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRefreshItems);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucCMSAdmin";
            this.Size = new System.Drawing.Size(1319, 791);
            this.Load += new System.EventHandler(this.ucCMSAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.SimpleButton btnRefreshItems;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemID;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeleteItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddUOM;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl dgUOM;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUOM;
        private DevExpress.XtraGrid.Columns.GridColumn gcUOMID;
        private DevExpress.XtraGrid.Columns.GridColumn gcUOMValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeleteUOM;
    }
}
