namespace RTIS_Vulcan_UI.Forms.PGM
{
    partial class frmPGMManufacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPGMManufacture));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCont = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManufacture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnManufacture = new DevExpress.XtraEditors.SimpleButton();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCont = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblRem = new DevExpress.XtraEditors.LabelControl();
            this.lblMan = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.lblHeader.Size = new System.Drawing.Size(438, 44);
            this.lblHeader.TabIndex = 34;
            this.lblHeader.Text = "Manufacture PGM Containers";
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(12, 64);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(985, 444);
            this.dgItems.TabIndex = 35;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCont,
            this.gcWeight,
            this.gcUserAdded,
            this.gcDateAdded,
            this.gcManufacture,
            this.gcEdit});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            // 
            // gcCont
            // 
            this.gcCont.Caption = "Container";
            this.gcCont.FieldName = "gcCont";
            this.gcCont.Name = "gcCont";
            this.gcCont.OptionsColumn.AllowEdit = false;
            this.gcCont.Visible = true;
            this.gcCont.VisibleIndex = 0;
            // 
            // gcWeight
            // 
            this.gcWeight.Caption = "Weight";
            this.gcWeight.FieldName = "gcWeight";
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.OptionsColumn.AllowEdit = false;
            this.gcWeight.Visible = true;
            this.gcWeight.VisibleIndex = 1;
            // 
            // gcUserAdded
            // 
            this.gcUserAdded.Caption = "User Added";
            this.gcUserAdded.FieldName = "gcUserAdded";
            this.gcUserAdded.Name = "gcUserAdded";
            this.gcUserAdded.OptionsColumn.AllowEdit = false;
            this.gcUserAdded.Visible = true;
            this.gcUserAdded.VisibleIndex = 2;
            // 
            // gcDateAdded
            // 
            this.gcDateAdded.Caption = "Date Added";
            this.gcDateAdded.FieldName = "gcDateAdded";
            this.gcDateAdded.Name = "gcDateAdded";
            this.gcDateAdded.OptionsColumn.AllowEdit = false;
            this.gcDateAdded.Visible = true;
            this.gcDateAdded.VisibleIndex = 3;
            // 
            // gcManufacture
            // 
            this.gcManufacture.Caption = "Manufacture Container";
            this.gcManufacture.FieldName = "gcManufacture";
            this.gcManufacture.Name = "gcManufacture";
            // 
            // gcEdit
            // 
            this.gcEdit.Caption = "Edit Container";
            this.gcEdit.FieldName = "gcEdit";
            this.gcEdit.Name = "gcEdit";
            // 
            // btnManufacture
            // 
            this.btnManufacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManufacture.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnManufacture.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnManufacture.Appearance.Options.UseBackColor = true;
            this.btnManufacture.Appearance.Options.UseFont = true;
            this.btnManufacture.Image = ((System.Drawing.Image)(resources.GetObject("btnManufacture.Image")));
            this.btnManufacture.Location = new System.Drawing.Point(790, 586);
            this.btnManufacture.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnManufacture.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnManufacture.Margin = new System.Windows.Forms.Padding(4);
            this.btnManufacture.Name = "btnManufacture";
            this.btnManufacture.Size = new System.Drawing.Size(207, 49);
            this.btnManufacture.TabIndex = 91;
            this.btnManufacture.Text = "Manufacture Batch";
            this.btnManufacture.Click += new System.EventHandler(this.btnManufacture_Click);
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
            this.ppnlWait.Location = new System.Drawing.Point(9, -1);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1003, 547);
            this.ppnlWait.TabIndex = 92;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(174, 33);
            this.labelControl1.TabIndex = 93;
            this.labelControl1.Text = "Container Total:";
            // 
            // lblCont
            // 
            this.lblCont.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCont.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCont.Appearance.Options.UseFont = true;
            this.lblCont.Appearance.Options.UseForeColor = true;
            this.lblCont.Location = new System.Drawing.Point(279, 4);
            this.lblCont.Margin = new System.Windows.Forms.Padding(4);
            this.lblCont.Name = "lblCont";
            this.lblCont.Size = new System.Drawing.Size(122, 33);
            this.lblCont.TabIndex = 94;
            this.lblCont.Text = "[ContTotal]";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(4, 39);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(126, 33);
            this.labelControl3.TabIndex = 95;
            this.labelControl3.Text = "Remainder:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(4, 80);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(209, 33);
            this.labelControl4.TabIndex = 96;
            this.labelControl4.Text = "Manufacture Total:";
            // 
            // lblRem
            // 
            this.lblRem.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRem.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRem.Appearance.Options.UseFont = true;
            this.lblRem.Appearance.Options.UseForeColor = true;
            this.lblRem.Location = new System.Drawing.Point(279, 39);
            this.lblRem.Margin = new System.Windows.Forms.Padding(4);
            this.lblRem.Name = "lblRem";
            this.lblRem.Size = new System.Drawing.Size(121, 33);
            this.lblRem.TabIndex = 97;
            this.lblRem.Text = "[RemTotal]";
            // 
            // lblMan
            // 
            this.lblMan.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMan.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMan.Appearance.Options.UseFont = true;
            this.lblMan.Appearance.Options.UseForeColor = true;
            this.lblMan.Location = new System.Drawing.Point(279, 80);
            this.lblMan.Margin = new System.Windows.Forms.Padding(4);
            this.lblMan.Name = "lblMan";
            this.lblMan.Size = new System.Drawing.Size(121, 33);
            this.lblMan.TabIndex = 98;
            this.lblMan.Text = "[ManTotal]";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(4, 45);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(404, 33);
            this.labelControl7.TabIndex = 99;
            this.labelControl7.Text = "_______________________________";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lblMan);
            this.panel1.Controls.Add(this.lblCont);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.lblRem);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl7);
            this.panel1.Location = new System.Drawing.Point(12, 515);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 120);
            this.panel1.TabIndex = 100;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnEdit.Appearance.Options.UseBackColor = true;
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(790, 520);
            this.btnEdit.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(207, 49);
            this.btnEdit.TabIndex = 101;
            this.btnEdit.Text = "Edit Remainder";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(790, 8);
            this.btnClose.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(207, 49);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "Manually Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPGMManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1010, 645);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.btnManufacture);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPGMManufacture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGM Manufacture";
            this.Load += new System.EventHandler(this.frmPGMManufacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcCont;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcManufacture;
        private DevExpress.XtraEditors.SimpleButton btnManufacture;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
        private DevExpress.XtraGrid.Columns.GridColumn gcEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblCont;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblRem;
        private DevExpress.XtraEditors.LabelControl lblMan;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}