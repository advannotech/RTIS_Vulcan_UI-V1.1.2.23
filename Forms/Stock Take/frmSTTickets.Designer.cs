namespace RTIS_Vulcan_UI.Forms.Stock_Take
{
    partial class frmSTTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSTTickets));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgItems = new DevExpress.XtraGrid.GridControl();
            this.gvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTicket = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQty2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBarcodeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRecount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemoveTicket = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblItemCode = new DevExpress.XtraEditors.LabelControl();
            this.lblLotNumber = new DevExpress.XtraEditors.LabelControl();
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(135, 37);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Item Code:";
            // 
            // dgItems
            // 
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.Location = new System.Drawing.Point(13, 118);
            this.dgItems.MainView = this.gvItems;
            this.dgItems.Name = "dgItems";
            this.dgItems.Size = new System.Drawing.Size(1185, 517);
            this.dgItems.TabIndex = 10;
            this.dgItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItems});
            // 
            // gvItems
            // 
            this.gvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcTicket,
            this.gcQty1,
            this.gcUser1,
            this.gcDate1,
            this.gcQty2,
            this.gcUser2,
            this.gcDate2,
            this.gcBarcodeType,
            this.gcValid,
            this.gcRecount,
            this.gcRemoveTicket});
            this.gvItems.GridControl = this.dgItems;
            this.gvItems.Name = "gvItems";
            this.gvItems.OptionsFind.AlwaysVisible = true;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            // 
            // gcTicket
            // 
            this.gcTicket.Caption = "Ticket No";
            this.gcTicket.FieldName = "gcTicket";
            this.gcTicket.Name = "gcTicket";
            this.gcTicket.Visible = true;
            this.gcTicket.VisibleIndex = 0;
            this.gcTicket.Width = 116;
            // 
            // gcQty1
            // 
            this.gcQty1.Caption = "Qty 1";
            this.gcQty1.FieldName = "gcQty1";
            this.gcQty1.Name = "gcQty1";
            this.gcQty1.Visible = true;
            this.gcQty1.VisibleIndex = 1;
            this.gcQty1.Width = 80;
            // 
            // gcUser1
            // 
            this.gcUser1.Caption = "User 1";
            this.gcUser1.FieldName = "gcUser1";
            this.gcUser1.Name = "gcUser1";
            this.gcUser1.Visible = true;
            this.gcUser1.VisibleIndex = 2;
            this.gcUser1.Width = 120;
            // 
            // gcDate1
            // 
            this.gcDate1.Caption = "Date Counted 1";
            this.gcDate1.FieldName = "gcDate1";
            this.gcDate1.Name = "gcDate1";
            this.gcDate1.Visible = true;
            this.gcDate1.VisibleIndex = 3;
            this.gcDate1.Width = 120;
            // 
            // gcQty2
            // 
            this.gcQty2.Caption = "Qty 2";
            this.gcQty2.FieldName = "gcQty2";
            this.gcQty2.Name = "gcQty2";
            this.gcQty2.Visible = true;
            this.gcQty2.VisibleIndex = 4;
            this.gcQty2.Width = 72;
            // 
            // gcUser2
            // 
            this.gcUser2.Caption = "User 2";
            this.gcUser2.FieldName = "gcUser2";
            this.gcUser2.Name = "gcUser2";
            this.gcUser2.Visible = true;
            this.gcUser2.VisibleIndex = 5;
            this.gcUser2.Width = 129;
            // 
            // gcDate2
            // 
            this.gcDate2.Caption = "Date Counted 2";
            this.gcDate2.FieldName = "gcDate2";
            this.gcDate2.Name = "gcDate2";
            this.gcDate2.Visible = true;
            this.gcDate2.VisibleIndex = 6;
            this.gcDate2.Width = 129;
            // 
            // gcBarcodeType
            // 
            this.gcBarcodeType.Caption = "Barcode Type";
            this.gcBarcodeType.FieldName = "gcBarcodeType";
            this.gcBarcodeType.Name = "gcBarcodeType";
            this.gcBarcodeType.Visible = true;
            this.gcBarcodeType.VisibleIndex = 7;
            this.gcBarcodeType.Width = 129;
            // 
            // gcValid
            // 
            this.gcValid.Caption = "Is Count Valid";
            this.gcValid.FieldName = "gcValid";
            this.gcValid.Name = "gcValid";
            // 
            // gcRecount
            // 
            this.gcRecount.Caption = "Recount Ticket";
            this.gcRecount.FieldName = "gcRecount";
            this.gcRecount.Name = "gcRecount";
            this.gcRecount.Visible = true;
            this.gcRecount.VisibleIndex = 8;
            this.gcRecount.Width = 104;
            // 
            // gcRemoveTicket
            // 
            this.gcRemoveTicket.Caption = "Remove Ticket";
            this.gcRemoveTicket.FieldName = "gcRemoveTicket";
            this.gcRemoveTicket.Name = "gcRemoveTicket";
            this.gcRemoveTicket.Visible = true;
            this.gcRemoveTicket.VisibleIndex = 9;
            this.gcRemoveTicket.Width = 166;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(13, 58);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(154, 37);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Lot Number:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemCode.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblItemCode.Appearance.Options.UseFont = true;
            this.lblItemCode.Appearance.Options.UseForeColor = true;
            this.lblItemCode.Location = new System.Drawing.Point(194, 13);
            this.lblItemCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(138, 37);
            this.lblItemCode.TabIndex = 12;
            this.lblItemCode.Text = "[ItemCode]";
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLotNumber.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNumber.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLotNumber.Appearance.Options.UseFont = true;
            this.lblLotNumber.Appearance.Options.UseForeColor = true;
            this.lblLotNumber.Location = new System.Drawing.Point(194, 58);
            this.lblLotNumber.Margin = new System.Windows.Forms.Padding(4);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(157, 37);
            this.lblLotNumber.TabIndex = 13;
            this.lblLotNumber.Text = "[LotNumber]";
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.AnimationToTextDistance = 10;
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ppnlWait.Description = "Loading tickets, this may take a few minutes...";
            this.ppnlWait.Location = new System.Drawing.Point(4, 5);
            this.ppnlWait.Margin = new System.Windows.Forms.Padding(4);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(1204, 640);
            this.ppnlWait.TabIndex = 14;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // frmSTTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 647);
            this.Controls.Add(this.lblLotNumber);
            this.Controls.Add(this.lblItemCode);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ppnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSTTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Stock Take Tickets";
            this.Load += new System.EventHandler(this.frmSTTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl dgItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItems;
        private DevExpress.XtraGrid.Columns.GridColumn gcTicket;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty1;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser1;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate1;
        private DevExpress.XtraGrid.Columns.GridColumn gcQty2;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser2;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate2;
        private DevExpress.XtraGrid.Columns.GridColumn gcBarcodeType;
        private DevExpress.XtraGrid.Columns.GridColumn gcValid;
        private DevExpress.XtraGrid.Columns.GridColumn gcRecount;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemoveTicket;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblItemCode;
        private DevExpress.XtraEditors.LabelControl lblLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
    }
}