namespace RTIS_Vulcan_UI.Forms.AW
{
    partial class frmAWRaws
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAWRaws));
            this.pnlAvailable = new DevExpress.XtraEditors.PanelControl();
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.pnlAddRMs = new DevExpress.XtraEditors.PanelControl();
            this.lblRawDesc = new DevExpress.XtraEditors.LabelControl();
            this.lblRawCode = new DevExpress.XtraEditors.LabelControl();
            this.dgRMs = new DevExpress.XtraGrid.GridControl();
            this.gvRaws = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRMDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAvailable)).BeginInit();
            this.pnlAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAddRMs)).BeginInit();
            this.pnlAddRMs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaws)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAvailable
            // 
            this.pnlAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvailable.Controls.Add(this.lblDesc);
            this.pnlAvailable.Controls.Add(this.lblCode);
            this.pnlAvailable.Controls.Add(this.dgItems);
            this.pnlAvailable.Controls.Add(this.btnAdd);
            this.pnlAvailable.Location = new System.Drawing.Point(13, 13);
            this.pnlAvailable.Name = "pnlAvailable";
            this.pnlAvailable.Size = new System.Drawing.Size(727, 498);
            this.pnlAvailable.TabIndex = 0;
            // 
            // lblDesc
            // 
            this.lblDesc.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDesc.Appearance.Options.UseFont = true;
            this.lblDesc.Appearance.Options.UseForeColor = true;
            this.lblDesc.Location = new System.Drawing.Point(6, 58);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(159, 44);
            this.lblDesc.TabIndex = 68;
            this.lblDesc.Text = "[ItemDesc]";
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.Appearance.Options.UseForeColor = true;
            this.lblCode.Location = new System.Drawing.Point(6, 6);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(165, 44);
            this.lblCode.TabIndex = 67;
            this.lblCode.Text = "[ItemCode]";
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(6, 110);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(716, 326);
            this.dgItems.TabIndex = 66;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCode,
            this.gcDesc,
            this.gcRemove});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            // 
            // gcCode
            // 
            this.gcCode.Caption = "Code";
            this.gcCode.FieldName = "gcCode";
            this.gcCode.Name = "gcCode";
            this.gcCode.OptionsColumn.ReadOnly = true;
            this.gcCode.Visible = true;
            this.gcCode.VisibleIndex = 0;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Description";
            this.gcDesc.FieldName = "gcDesc";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            // 
            // gcRemove
            // 
            this.gcRemove.Caption = "Click to Remove";
            this.gcRemove.FieldName = "gcRemove";
            this.gcRemove.Name = "gcRemove";
            this.gcRemove.Visible = true;
            this.gcRemove.VisibleIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(553, 443);
            this.btnAdd.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(168, 49);
            this.btnAdd.TabIndex = 65;
            this.btnAdd.Text = "Add RM";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlAddRMs
            // 
            this.pnlAddRMs.Controls.Add(this.lblRawDesc);
            this.pnlAddRMs.Controls.Add(this.lblRawCode);
            this.pnlAddRMs.Controls.Add(this.dgRMs);
            this.pnlAddRMs.Controls.Add(this.btnBack);
            this.pnlAddRMs.Location = new System.Drawing.Point(13, 13);
            this.pnlAddRMs.Name = "pnlAddRMs";
            this.pnlAddRMs.Size = new System.Drawing.Size(727, 498);
            this.pnlAddRMs.TabIndex = 67;
            // 
            // lblRawDesc
            // 
            this.lblRawDesc.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawDesc.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRawDesc.Appearance.Options.UseFont = true;
            this.lblRawDesc.Appearance.Options.UseForeColor = true;
            this.lblRawDesc.Location = new System.Drawing.Point(6, 58);
            this.lblRawDesc.Margin = new System.Windows.Forms.Padding(4);
            this.lblRawDesc.Name = "lblRawDesc";
            this.lblRawDesc.Size = new System.Drawing.Size(159, 44);
            this.lblRawDesc.TabIndex = 69;
            this.lblRawDesc.Text = "[ItemDesc]";
            // 
            // lblRawCode
            // 
            this.lblRawCode.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRawCode.Appearance.Options.UseFont = true;
            this.lblRawCode.Appearance.Options.UseForeColor = true;
            this.lblRawCode.Location = new System.Drawing.Point(6, 6);
            this.lblRawCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblRawCode.Name = "lblRawCode";
            this.lblRawCode.Size = new System.Drawing.Size(165, 44);
            this.lblRawCode.TabIndex = 68;
            this.lblRawCode.Text = "[ItemCode]";
            // 
            // dgRMs
            // 
            this.dgRMs.Location = new System.Drawing.Point(6, 110);
            this.dgRMs.MainView = this.gvRaws;
            this.dgRMs.Name = "dgRMs";
            this.dgRMs.Size = new System.Drawing.Size(715, 327);
            this.dgRMs.TabIndex = 67;
            this.dgRMs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRaws});
            // 
            // gvRaws
            // 
            this.gvRaws.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRMCode,
            this.gcRMDesc,
            this.gcAdd});
            this.gvRaws.GridControl = this.dgRMs;
            this.gvRaws.Name = "gvRaws";
            this.gvRaws.OptionsFind.AlwaysVisible = true;
            // 
            // gcRMCode
            // 
            this.gcRMCode.Caption = "Code";
            this.gcRMCode.FieldName = "gcRMCode";
            this.gcRMCode.Name = "gcRMCode";
            this.gcRMCode.Visible = true;
            this.gcRMCode.VisibleIndex = 0;
            // 
            // gcRMDesc
            // 
            this.gcRMDesc.Caption = "Description";
            this.gcRMDesc.FieldName = "gcRMDesc";
            this.gcRMDesc.Name = "gcRMDesc";
            this.gcRMDesc.Visible = true;
            this.gcRMDesc.VisibleIndex = 1;
            // 
            // gcAdd
            // 
            this.gcAdd.Caption = "Add";
            this.gcAdd.FieldName = "gcAdd";
            this.gcAdd.Name = "gcAdd";
            this.gcAdd.Visible = true;
            this.gcAdd.VisibleIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(553, 444);
            this.btnBack.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnBack.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(168, 49);
            this.btnBack.TabIndex = 66;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmAWRaws
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 523);
            this.Controls.Add(this.pnlAddRMs);
            this.Controls.Add(this.pnlAvailable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAWRaws";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Available Raw Materials";
            this.Load += new System.EventHandler(this.frmAWRaws_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAvailable)).EndInit();
            this.pnlAvailable.ResumeLayout(false);
            this.pnlAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAddRMs)).EndInit();
            this.pnlAddRMs.ResumeLayout(false);
            this.pnlAddRMs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaws)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlAvailable;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemove;
        private DevExpress.XtraEditors.PanelControl pnlAddRMs;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraGrid.GridControl dgRMs;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRaws;
        private DevExpress.XtraGrid.Columns.GridColumn gcRMCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcRMDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcAdd;
        private DevExpress.XtraEditors.LabelControl lblDesc;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblRawDesc;
        private DevExpress.XtraEditors.LabelControl lblRawCode;
    }
}