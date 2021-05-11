namespace RTIS_Vulcan_UI.Forms
{
    partial class frmPGMContainers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPGMContainers));
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCont = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManufactured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateManuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserManufactured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUserEdited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDateEdited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReason = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(284, 44);
            this.lblHeader.TabIndex = 33;
            this.lblHeader.Text = "All PGM Containers";
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(13, 65);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1222, 522);
            this.dgItems.TabIndex = 34;
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
            this.gcManufactured,
            this.gcDateManuf,
            this.gcUserManufactured,
            this.gcUserEdited,
            this.gcDateEdited,
            this.gcReason});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvItems_ShowingEditor);
            // 
            // gcCont
            // 
            this.gcCont.Caption = "Container";
            this.gcCont.FieldName = "gcCont";
            this.gcCont.Name = "gcCont";
            this.gcCont.OptionsColumn.ReadOnly = true;
            this.gcCont.Visible = true;
            this.gcCont.VisibleIndex = 0;
            // 
            // gcWeight
            // 
            this.gcWeight.Caption = "Weight";
            this.gcWeight.FieldName = "gcWeight";
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.OptionsColumn.ReadOnly = true;
            this.gcWeight.Visible = true;
            this.gcWeight.VisibleIndex = 1;
            // 
            // gcUserAdded
            // 
            this.gcUserAdded.Caption = "User Added";
            this.gcUserAdded.FieldName = "gcUserAdded";
            this.gcUserAdded.Name = "gcUserAdded";
            this.gcUserAdded.OptionsColumn.ReadOnly = true;
            this.gcUserAdded.Visible = true;
            this.gcUserAdded.VisibleIndex = 2;
            // 
            // gcDateAdded
            // 
            this.gcDateAdded.Caption = "Date Added";
            this.gcDateAdded.FieldName = "gcDateAdded";
            this.gcDateAdded.Name = "gcDateAdded";
            this.gcDateAdded.OptionsColumn.ReadOnly = true;
            this.gcDateAdded.Visible = true;
            this.gcDateAdded.VisibleIndex = 3;
            // 
            // gcManufactured
            // 
            this.gcManufactured.Caption = "Manufactured";
            this.gcManufactured.FieldName = "gcManufactured";
            this.gcManufactured.Name = "gcManufactured";
            this.gcManufactured.OptionsColumn.AllowEdit = false;
            this.gcManufactured.Visible = true;
            this.gcManufactured.VisibleIndex = 4;
            // 
            // gcDateManuf
            // 
            this.gcDateManuf.Caption = "Date Manufactured";
            this.gcDateManuf.FieldName = "gcDateManuf";
            this.gcDateManuf.Name = "gcDateManuf";
            this.gcDateManuf.OptionsColumn.ReadOnly = true;
            this.gcDateManuf.Visible = true;
            this.gcDateManuf.VisibleIndex = 5;
            // 
            // gcUserManufactured
            // 
            this.gcUserManufactured.Caption = "User Manufactured";
            this.gcUserManufactured.FieldName = "gcUserManufactured";
            this.gcUserManufactured.Name = "gcUserManufactured";
            this.gcUserManufactured.OptionsColumn.ReadOnly = true;
            this.gcUserManufactured.Visible = true;
            this.gcUserManufactured.VisibleIndex = 6;
            // 
            // gcUserEdited
            // 
            this.gcUserEdited.Caption = "User Edited";
            this.gcUserEdited.FieldName = "gcUserEdited";
            this.gcUserEdited.Name = "gcUserEdited";
            this.gcUserEdited.OptionsColumn.ReadOnly = true;
            this.gcUserEdited.Visible = true;
            this.gcUserEdited.VisibleIndex = 7;
            // 
            // gcDateEdited
            // 
            this.gcDateEdited.Caption = "Date Edited";
            this.gcDateEdited.FieldName = "gcDateEdited";
            this.gcDateEdited.Name = "gcDateEdited";
            this.gcDateEdited.OptionsColumn.ReadOnly = true;
            this.gcDateEdited.Visible = true;
            this.gcDateEdited.VisibleIndex = 8;
            // 
            // gcReason
            // 
            this.gcReason.Caption = "Reason for Edit";
            this.gcReason.FieldName = "gcReason";
            this.gcReason.Name = "gcReason";
            this.gcReason.OptionsColumn.ReadOnly = true;
            this.gcReason.Visible = true;
            this.gcReason.VisibleIndex = 9;
            // 
            // frmPGMContainers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1247, 599);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPGMContainers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGM Job Containers";
            this.Load += new System.EventHandler(this.frmPGMContainers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gcManufactured;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateManuf;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserManufactured;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserEdited;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateEdited;
        private DevExpress.XtraGrid.Columns.GridColumn gcReason;
    }
}