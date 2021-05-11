namespace RTIS_Vulcan_UI.Forms.Purchase_Orders
{
    partial class frmAddItemCMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddItemCMS));
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gcInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
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
            this.labelControl3.TabIndex = 36;
            this.labelControl3.Text = "Item Code : ";
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
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "Item Description : ";
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
            this.lblCode.TabIndex = 43;
            this.lblCode.Text = "[ItemCode]";
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
            this.lblDesc.TabIndex = 44;
            this.lblDesc.Text = "[ItemDesc]";
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
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "CMS Specifications";
            // 
            // dgItems
            // 
            this.dgItems.Location = new System.Drawing.Point(13, 142);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(775, 309);
            this.dgItems.TabIndex = 46;
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
            this.gcInspection});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvItems.OptionsCustomization.AllowColumnMoving = false;
            this.gvItems.OptionsCustomization.AllowGroup = false;
            this.gvItems.OptionsDetail.EnableMasterViewMode = false;
            this.gvItems.OptionsView.ColumnAutoWidth = false;
            this.gvItems.OptionsView.ShowGroupPanel = false;
            this.gvItems.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvItems_RowCellStyle);
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
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.Location = new System.Drawing.Point(12, 12);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(776, 495);
            this.ppnlWait.TabIndex = 95;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // gcInspection
            // 
            this.gcInspection.Caption = "Inspection";
            this.gcInspection.FieldName = "gcInspection";
            this.gcInspection.Name = "gcInspection";
            this.gcInspection.Visible = true;
            this.gcInspection.VisibleIndex = 5;
            // 
            // frmAddItemCMS
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
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddItemCMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture CMS Data";
            this.Load += new System.EventHandler(this.frmAddItemCMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblDesc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gcItem;
        private DevExpress.XtraGrid.Columns.GridColumn gcUOM;
        private DevExpress.XtraGrid.Columns.GridColumn gcType;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal1;
        private DevExpress.XtraGrid.Columns.GridColumn gcVal2;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraGrid.Columns.GridColumn gcInspection;
    }
}