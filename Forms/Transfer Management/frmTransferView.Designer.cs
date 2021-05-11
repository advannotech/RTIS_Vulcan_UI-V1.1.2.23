namespace RTIS_Vulcan_UI.Forms
{
    partial class frmTransferView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpInfo = new DevExpress.XtraTab.XtraTabPage();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lblQty = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblLot = new DevExpress.XtraEditors.LabelControl();
            this.xtpFailed = new DevExpress.XtraTab.XtraTabPage();
            this.meFailure = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.lblFailed = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpInfo.SuspendLayout();
            this.xtpFailed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meFailure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(120, 143);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(193, 28);
            this.labelControl1.TabIndex = 54;
            this.labelControl1.Text = "Transfer Information";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 191);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpInfo;
            this.xtraTabControl1.Size = new System.Drawing.Size(415, 263);
            this.xtraTabControl1.TabIndex = 60;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpInfo,
            this.xtpFailed});
            // 
            // xtpInfo
            // 
            this.xtpInfo.Controls.Add(this.lblProcess);
            this.xtpInfo.Controls.Add(this.labelControl17);
            this.xtpInfo.Controls.Add(this.lblStatus);
            this.xtpInfo.Controls.Add(this.labelControl15);
            this.xtpInfo.Controls.Add(this.lblUser);
            this.xtpInfo.Controls.Add(this.labelControl13);
            this.xtpInfo.Controls.Add(this.lblDate);
            this.xtpInfo.Controls.Add(this.labelControl11);
            this.xtpInfo.Controls.Add(this.lblQty);
            this.xtpInfo.Controls.Add(this.lblTo);
            this.xtpInfo.Controls.Add(this.labelControl8);
            this.xtpInfo.Controls.Add(this.labelControl6);
            this.xtpInfo.Controls.Add(this.lblFrom);
            this.xtpInfo.Controls.Add(this.labelControl4);
            this.xtpInfo.Controls.Add(this.labelControl3);
            this.xtpInfo.Controls.Add(this.labelControl2);
            this.xtpInfo.Controls.Add(this.lblCode);
            this.xtpInfo.Controls.Add(this.lblLot);
            this.xtpInfo.Name = "xtpInfo";
            this.xtpInfo.Size = new System.Drawing.Size(408, 229);
            this.xtpInfo.Text = "Transfer Information";
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(135, 206);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(4);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(54, 16);
            this.lblProcess.TabIndex = 32;
            this.lblProcess.Text = "[Process]";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(17, 206);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(49, 16);
            this.labelControl17.TabIndex = 31;
            this.labelControl17.Text = "Process:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(135, 182);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 16);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "[Status]";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(17, 182);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(41, 16);
            this.labelControl15.TabIndex = 29;
            this.labelControl15.Text = "Status:";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(135, 158);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(36, 16);
            this.lblUser.TabIndex = 28;
            this.lblUser.Text = "[User]";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(17, 158);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 16);
            this.labelControl13.TabIndex = 27;
            this.labelControl13.Text = "User:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(135, 134);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 16);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "[Date]";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(17, 134);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(31, 16);
            this.labelControl11.TabIndex = 25;
            this.labelControl11.Text = "Date:";
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(135, 62);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(57, 16);
            this.lblQty.TabIndex = 24;
            this.lblQty.Text = "[Quantity]";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(135, 110);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(94, 16);
            this.lblTo.TabIndex = 23;
            this.lblTo.Text = "[Warehouse To]";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(17, 110);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(89, 16);
            this.labelControl8.TabIndex = 22;
            this.labelControl8.Text = "Warehouse To:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(17, 86);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(104, 16);
            this.labelControl6.TabIndex = 21;
            this.labelControl6.Text = "Warehouse From:";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(135, 86);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(109, 16);
            this.lblFrom.TabIndex = 20;
            this.lblFrom.Text = "[Warehouse From]";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 62);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 16);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Quantity:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.Location = new System.Drawing.Point(17, 14);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 16);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Item Code:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 38);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Lot Number:";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(135, 14);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(65, 16);
            this.lblCode.TabIndex = 16;
            this.lblCode.Text = "[ItemCode]";
            // 
            // lblLot
            // 
            this.lblLot.Location = new System.Drawing.Point(135, 38);
            this.lblLot.Margin = new System.Windows.Forms.Padding(4);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(53, 16);
            this.lblLot.TabIndex = 18;
            this.lblLot.Text = "[LotNum]";
            // 
            // xtpFailed
            // 
            this.xtpFailed.Controls.Add(this.meFailure);
            this.xtpFailed.Controls.Add(this.labelControl21);
            this.xtpFailed.Controls.Add(this.lblFailed);
            this.xtpFailed.Controls.Add(this.labelControl20);
            this.xtpFailed.Name = "xtpFailed";
            this.xtpFailed.Size = new System.Drawing.Size(408, 229);
            this.xtpFailed.Text = "Failure Information";
            // 
            // meFailure
            // 
            this.meFailure.Location = new System.Drawing.Point(16, 83);
            this.meFailure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.meFailure.Name = "meFailure";
            this.meFailure.Properties.ReadOnly = true;
            this.meFailure.Size = new System.Drawing.Size(378, 170);
            this.meFailure.TabIndex = 38;
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(16, 59);
            this.labelControl21.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(47, 16);
            this.labelControl21.TabIndex = 29;
            this.labelControl21.Text = "Reason:";
            // 
            // lblFailed
            // 
            this.lblFailed.Location = new System.Drawing.Point(134, 25);
            this.lblFailed.Margin = new System.Windows.Forms.Padding(4);
            this.lblFailed.Name = "lblFailed";
            this.lblFailed.Size = new System.Drawing.Size(36, 16);
            this.lblFailed.TabIndex = 28;
            this.lblFailed.Text = "[Date]";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(16, 25);
            this.labelControl20.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(31, 16);
            this.labelControl20.TabIndex = 27;
            this.labelControl20.Text = "Date:";
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit2.EditValue = global::RTIS_Vulcan_UI.Properties.Resources.CAT_SCAN_LOGO_300dpi_TRANSPARENT;
            this.pictureEdit2.Location = new System.Drawing.Point(58, 26);
            this.pictureEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit2.Size = new System.Drawing.Size(320, 98);
            this.pictureEdit2.TabIndex = 61;
            // 
            // frmTransferView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 462);
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer View";
            this.Load += new System.EventHandler(this.frmTransferView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpInfo.ResumeLayout(false);
            this.xtpInfo.PerformLayout();
            this.xtpFailed.ResumeLayout(false);
            this.xtpFailed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meFailure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lblQty;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblLot;
        private DevExpress.XtraTab.XtraTabPage xtpFailed;
        private DevExpress.XtraTab.XtraTabPage xtpInfo;
        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl lblFailed;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.MemoEdit meFailure;
    }
}