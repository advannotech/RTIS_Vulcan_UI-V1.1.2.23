namespace RTIS_Vulcan_UI.Forms
{
    partial class frmRoleManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoleManagement));
            this.label6 = new System.Windows.Forms.Label();
            this.xtcRoles = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtDesc = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.lbSelected = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAddAllPerms = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemovePerm = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddPerm = new DevExpress.XtraEditors.SimpleButton();
            this.lbAvailable = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtcRoles)).BeginInit();
            this.xtcRoles.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 23);
            this.label6.TabIndex = 50;
            this.label6.Text = "Role Administration";
            // 
            // xtcRoles
            // 
            this.xtcRoles.Location = new System.Drawing.Point(16, 38);
            this.xtcRoles.Margin = new System.Windows.Forms.Padding(4);
            this.xtcRoles.Name = "xtcRoles";
            this.xtcRoles.SelectedTabPage = this.xtraTabPage1;
            this.xtcRoles.Size = new System.Drawing.Size(589, 407);
            this.xtcRoles.TabIndex = 49;
            this.xtcRoles.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtDesc);
            this.xtraTabPage1.Controls.Add(this.label3);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Controls.Add(this.txtName);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(587, 377);
            this.xtraTabPage1.Text = "General";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(16, 91);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDesc.Properties.NullValuePrompt = "Enter a role description";
            this.txtDesc.Size = new System.Drawing.Size(551, 268);
            this.txtDesc.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 54;
            this.label3.Text = "Role Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 53;
            this.label2.Text = "Role Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(16, 37);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName.Properties.NullValuePrompt = "Enter a role name";
            this.txtName.Size = new System.Drawing.Size(551, 22);
            this.txtName.TabIndex = 52;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.label5);
            this.xtraTabPage2.Controls.Add(this.label4);
            this.xtraTabPage2.Controls.Add(this.btnDone);
            this.xtraTabPage2.Controls.Add(this.lbSelected);
            this.xtraTabPage2.Controls.Add(this.btnAddAllPerms);
            this.xtraTabPage2.Controls.Add(this.btnRemovePerm);
            this.xtraTabPage2.Controls.Add(this.btnAddPerm);
            this.xtraTabPage2.Controls.Add(this.lbAvailable);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(587, 377);
            this.xtraTabPage2.Text = "Permissions";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "Available Permissions";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "Selected Permissions";
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnDone.Appearance.Options.UseBackColor = true;
            this.btnDone.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.ImageOptions.Image")));
            this.btnDone.Location = new System.Drawing.Point(409, 320);
            this.btnDone.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnDone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDone.Margin = new System.Windows.Forms.Padding(4);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(168, 49);
            this.btnDone.TabIndex = 69;
            this.btnDone.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lbSelected
            // 
            this.lbSelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSelected.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbSelected.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbSelected.Location = new System.Drawing.Point(3, 27);
            this.lbSelected.Margin = new System.Windows.Forms.Padding(4);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(229, 286);
            this.lbSelected.TabIndex = 66;
            // 
            // btnAddAllPerms
            // 
            this.btnAddAllPerms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddAllPerms.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAllPerms.ImageOptions.Image")));
            this.btnAddAllPerms.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddAllPerms.Location = new System.Drawing.Point(252, 223);
            this.btnAddAllPerms.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddAllPerms.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddAllPerms.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAllPerms.Name = "btnAddAllPerms";
            this.btnAddAllPerms.Size = new System.Drawing.Size(67, 49);
            this.btnAddAllPerms.TabIndex = 65;
            this.btnAddAllPerms.Click += new System.EventHandler(this.btnAddAllPerms_Click);
            // 
            // btnRemovePerm
            // 
            this.btnRemovePerm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemovePerm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemovePerm.ImageOptions.Image")));
            this.btnRemovePerm.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRemovePerm.Location = new System.Drawing.Point(252, 166);
            this.btnRemovePerm.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRemovePerm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemovePerm.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePerm.Name = "btnRemovePerm";
            this.btnRemovePerm.Size = new System.Drawing.Size(67, 49);
            this.btnRemovePerm.TabIndex = 64;
            this.btnRemovePerm.Click += new System.EventHandler(this.btnRemovePerm_Click);
            // 
            // btnAddPerm
            // 
            this.btnAddPerm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddPerm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerm.ImageOptions.Image")));
            this.btnAddPerm.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddPerm.Location = new System.Drawing.Point(252, 110);
            this.btnAddPerm.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddPerm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddPerm.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerm.Name = "btnAddPerm";
            this.btnAddPerm.Size = new System.Drawing.Size(67, 49);
            this.btnAddPerm.TabIndex = 63;
            this.btnAddPerm.Click += new System.EventHandler(this.btnAddPerm_Click);
            // 
            // lbAvailable
            // 
            this.lbAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbAvailable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbAvailable.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbAvailable.Location = new System.Drawing.Point(335, 27);
            this.lbAvailable.Margin = new System.Windows.Forms.Padding(4);
            this.lbAvailable.Name = "lbAvailable";
            this.lbAvailable.Size = new System.Drawing.Size(243, 286);
            this.lbAvailable.TabIndex = 62;
            // 
            // frmRoleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 454);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.xtcRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Role Management";
            this.Load += new System.EventHandler(this.frmRoleManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcRoles)).EndInit();
            this.xtcRoles.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private DevExpress.XtraTab.XtraTabControl xtcRoles;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.MemoEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ListBoxControl lbSelected;
        private DevExpress.XtraEditors.SimpleButton btnAddAllPerms;
        private DevExpress.XtraEditors.SimpleButton btnRemovePerm;
        private DevExpress.XtraEditors.SimpleButton btnAddPerm;
        private DevExpress.XtraEditors.ListBoxControl lbAvailable;
        private DevExpress.XtraEditors.SimpleButton btnDone;
    }
}