namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Management
{
    partial class frmEditCMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditCMS));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(612, 458);
            this.btnSave.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 49);
            this.btnSave.TabIndex = 101;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgItems
            // 
            this.dgItems.Location = new System.Drawing.Point(13, 142);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(775, 309);
            this.dgItems.TabIndex = 100;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcItem,
            this.gcUOM,
            this.gcType,
            this.gcVal1,
            this.gcVal2,
            this.gcInspection,
            this.gcDelete});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvItems.OptionsCustomization.AllowColumnMoving = false;
            this.gvItems.OptionsCustomization.AllowGroup = false;
            this.gvItems.OptionsDetail.EnableMasterViewMode = false;
            this.gvItems.OptionsView.ColumnAutoWidth = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;
            this.gvItems.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvItems_RowCellStyle);
            this.gvItems.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvItems_RowStyle);
            this.gvItems.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvItems_ShowingEditor);
            this.gvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvItems_CellValueChanged);
            this.gvItems.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvItems_ValidateRow);
            // 
            // gcItem
            // 
            this.gcItem.Caption = "Item";
            this.gcItem.FieldName = "gcItem";
            this.gcItem.Name = "gcItem";
            this.gcItem.Visible = true;
            this.gcItem.VisibleIndex = 0;
            // 
            // gcUOM
            // 
            this.gcUOM.Caption = "Unit";
            this.gcUOM.FieldName = "gcUOM";
            this.gcUOM.Name = "gcUOM";
            this.gcUOM.Visible = true;
            this.gcUOM.VisibleIndex = 1;
            // 
            // gcType
            // 
            this.gcType.Caption = "Variance Type";
            this.gcType.FieldName = "gcType";
            this.gcType.Name = "gcType";
            this.gcType.Visible = true;
            this.gcType.VisibleIndex = 2;
            // 
            // gcVal1
            // 
            this.gcVal1.Caption = "Value 1";
            this.gcVal1.FieldName = "gcVal1";
            this.gcVal1.Name = "gcVal1";
            this.gcVal1.Visible = true;
            this.gcVal1.VisibleIndex = 3;
            // 
            // gcVal2
            // 
            this.gcVal2.Caption = "Value 2";
            this.gcVal2.FieldName = "gcVal2";
            this.gcVal2.Name = "gcVal2";
            this.gcVal2.Visible = true;
            this.gcVal2.VisibleIndex = 4;
            // 
            // gcInspection
            // 
            this.gcInspection.Caption = "Inspection";
            this.gcInspection.FieldName = "gcInspection";
            this.gcInspection.Name = "gcInspection";
            this.gcInspection.Visible = true;
            this.gcInspection.VisibleIndex = 5;
            // 
            // gcDelete
            // 
            this.gcDelete.Caption = "Delete";
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.Visible = true;
            this.gcDelete.VisibleIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(12, 102);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(265, 33);
            this.labelControl2.TabIndex = 99;
            this.labelControl2.Text = "CMS Specifications";
            // 
            // lblDesc
            // 
            this.lblDesc.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDesc.Appearance.Options.UseFont = true;
            this.lblDesc.Appearance.Options.UseForeColor = true;
            this.lblDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDesc.Location = new System.Drawing.Point(283, 51);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(505, 33);
            this.lblDesc.TabIndex = 98;
            this.lblDesc.Text = "[ItemDesc]";
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Appearance.Options.UseForeColor = true;
            this.lblCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCode.Location = new System.Drawing.Point(283, 12);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(505, 33);
            this.lblCode.TabIndex = 97;
            this.lblCode.Text = "[ItemCode]";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(265, 33);
            this.labelControl1.TabIndex = 96;
            this.labelControl1.Text = "Item Description : ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(265, 33);
            this.labelControl3.TabIndex = 95;
            this.labelControl3.Text = "Item Code : ";
            // 
            // frmEditCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditCMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit CMS Document";
            this.Load += new System.EventHandler(this.frmEditCMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcUOM;
        private DevExpress.XtraGrid.Columns.GridColumn gcType;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal1;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal2;
        private DevExpress.XtraGrid.Columns.GridColumn gcInspection;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblDesc;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gcDelete;
    }
}