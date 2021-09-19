
namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.PO_Rec
{
    partial class frmLinkPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinkPurchaseOrder));
            this.xtcRoles = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.listLinkedPOs = new DevExpress.XtraEditors.ListBoxControl();
            this.txtSelectedSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLink = new DevExpress.XtraEditors.SimpleButton();
            this.lbSelected = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAddAllPOs = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemovePO = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddPO = new DevExpress.XtraEditors.SimpleButton();
            this.lbAvailable = new DevExpress.XtraEditors.ListBoxControl();
            this.lblSupplier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xtcRoles)).BeginInit();
            this.xtcRoles.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLinkedPOs)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // xtcRoles
            // 
            this.xtcRoles.Location = new System.Drawing.Point(7, 44);
            this.xtcRoles.Margin = new System.Windows.Forms.Padding(4);
            this.xtcRoles.Name = "xtcRoles";
            this.xtcRoles.SelectedTabPage = this.xtraTabPage1;
            this.xtcRoles.Size = new System.Drawing.Size(709, 429);
            this.xtcRoles.TabIndex = 50;
            this.xtcRoles.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.listLinkedPOs);
            this.xtraTabPage1.Controls.Add(this.txtSelectedSupplier);
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(707, 399);
            this.xtraTabPage1.Text = "Supplier Info";
            // 
            // listLinkedPOs
            // 
            this.listLinkedPOs.Enabled = false;
            this.listLinkedPOs.Location = new System.Drawing.Point(16, 117);
            this.listLinkedPOs.Name = "listLinkedPOs";
            this.listLinkedPOs.Size = new System.Drawing.Size(551, 268);
            this.listLinkedPOs.TabIndex = 59;
            // 
            // txtSelectedSupplier
            // 
            this.txtSelectedSupplier.Enabled = false;
            this.txtSelectedSupplier.Location = new System.Drawing.Point(16, 65);
            this.txtSelectedSupplier.Name = "txtSelectedSupplier";
            this.txtSelectedSupplier.Size = new System.Drawing.Size(551, 23);
            this.txtSelectedSupplier.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 23);
            this.label3.TabIndex = 54;
            this.label3.Text = "Already Linked Standing Order(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 53;
            this.label2.Text = "Supplier Name";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.label5);
            this.xtraTabPage2.Controls.Add(this.label4);
            this.xtraTabPage2.Controls.Add(this.btnLink);
            this.xtraTabPage2.Controls.Add(this.lbSelected);
            this.xtraTabPage2.Controls.Add(this.btnAddAllPOs);
            this.xtraTabPage2.Controls.Add(this.btnRemovePO);
            this.xtraTabPage2.Controls.Add(this.btnAddPO);
            this.xtraTabPage2.Controls.Add(this.lbAvailable);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(707, 399);
            this.xtraTabPage2.Text = "Link Standing Purchase Order";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(391, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "Available Standing Purchase Order(s)";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "Selected Standing Purchase Order";
            // 
            // btnLink
            // 
            this.btnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLink.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnLink.Appearance.Options.UseBackColor = true;
            this.btnLink.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLink.ImageOptions.Image")));
            this.btnLink.Location = new System.Drawing.Point(529, 343);
            this.btnLink.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnLink.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLink.Margin = new System.Windows.Forms.Padding(4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(168, 49);
            this.btnLink.TabIndex = 69;
            this.btnLink.Text = "Link";
            // 
            // lbSelected
            // 
            this.lbSelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSelected.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbSelected.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbSelected.Location = new System.Drawing.Point(24, 49);
            this.lbSelected.Margin = new System.Windows.Forms.Padding(4);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(268, 287);
            this.lbSelected.TabIndex = 66;
            // 
            // btnAddAllPOs
            // 
            this.btnAddAllPOs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddAllPOs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAllPOs.ImageOptions.Image")));
            this.btnAddAllPOs.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddAllPOs.Location = new System.Drawing.Point(312, 242);
            this.btnAddAllPOs.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddAllPOs.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddAllPOs.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAllPOs.Name = "btnAddAllPOs";
            this.btnAddAllPOs.Size = new System.Drawing.Size(67, 49);
            this.btnAddAllPOs.TabIndex = 65;
            this.btnAddAllPOs.Click += new System.EventHandler(this.btnAddAllPOs_Click);
            // 
            // btnRemovePO
            // 
            this.btnRemovePO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemovePO.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemovePO.ImageOptions.Image")));
            this.btnRemovePO.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemovePO.Location = new System.Drawing.Point(312, 185);
            this.btnRemovePO.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRemovePO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemovePO.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePO.Name = "btnRemovePO";
            this.btnRemovePO.Size = new System.Drawing.Size(67, 49);
            this.btnRemovePO.TabIndex = 64;
            this.btnRemovePO.Click += new System.EventHandler(this.btnRemovePO_Click);
            // 
            // btnAddPO
            // 
            this.btnAddPO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddPO.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPO.ImageOptions.Image")));
            this.btnAddPO.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddPO.Location = new System.Drawing.Point(312, 129);
            this.btnAddPO.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddPO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddPO.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPO.Name = "btnAddPO";
            this.btnAddPO.Size = new System.Drawing.Size(67, 49);
            this.btnAddPO.TabIndex = 63;
            this.btnAddPO.Click += new System.EventHandler(this.btnAddPO_Click);
            // 
            // lbAvailable
            // 
            this.lbAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbAvailable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbAvailable.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbAvailable.Location = new System.Drawing.Point(395, 50);
            this.lbAvailable.Margin = new System.Windows.Forms.Padding(4);
            this.lbAvailable.Name = "lbAvailable";
            this.lbAvailable.Size = new System.Drawing.Size(302, 286);
            this.lbAvailable.TabIndex = 62;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(4, 9);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(76, 23);
            this.lblSupplier.TabIndex = 51;
            this.lblSupplier.Text = "Supplier";
            // 
            // frmLinkPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(722, 486);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.xtcRoles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinkPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link Standing Purchase Order";
            this.Load += new System.EventHandler(this.frmLinkPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcRoles)).EndInit();
            this.xtcRoles.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLinkedPOs)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcRoles;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnLink;
        private DevExpress.XtraEditors.ListBoxControl lbSelected;
        private DevExpress.XtraEditors.SimpleButton btnAddAllPOs;
        private DevExpress.XtraEditors.SimpleButton btnRemovePO;
        private DevExpress.XtraEditors.SimpleButton btnAddPO;
        private DevExpress.XtraEditors.ListBoxControl lbAvailable;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSelectedSupplier;
        private DevExpress.XtraEditors.ListBoxControl listLinkedPOs;
    }
}