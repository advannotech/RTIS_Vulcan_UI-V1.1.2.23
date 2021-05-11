namespace RTIS_Vulcan_UI.Forms
{
    partial class frmUserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManagement));
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.txtPerms = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cmbAgentName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbHasAgent = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRoles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtConPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPin = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHasAgent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnDone.Appearance.Options.UseBackColor = true;
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.Location = new System.Drawing.Point(320, 264);
            this.btnDone.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnDone.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(126, 40);
            this.btnDone.TabIndex = 86;
            this.btnDone.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtPerms
            // 
            this.txtPerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerms.Location = new System.Drawing.Point(236, 153);
            this.txtPerms.Name = "txtPerms";
            this.txtPerms.Properties.ReadOnly = true;
            this.txtPerms.Size = new System.Drawing.Size(210, 105);
            this.txtPerms.TabIndex = 85;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(236, 135);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(108, 13);
            this.labelControl8.TabIndex = 84;
            this.labelControl8.Text = "User Role Permissions:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cmbAgentName);
            this.groupControl2.Controls.Add(this.cbHasAgent);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Location = new System.Drawing.Point(20, 135);
            this.groupControl2.LookAndFeel.SkinName = "Office 2013";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(210, 123);
            this.groupControl2.TabIndex = 83;
            this.groupControl2.Text = "Agent Settings";
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.Location = new System.Drawing.Point(5, 81);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAgentName.Size = new System.Drawing.Size(200, 20);
            this.cmbAgentName.TabIndex = 38;
            // 
            // cbHasAgent
            // 
            this.cbHasAgent.EditValue = true;
            this.cbHasAgent.Location = new System.Drawing.Point(5, 24);
            this.cbHasAgent.Name = "cbHasAgent";
            this.cbHasAgent.Properties.Caption = "User has Agent";
            this.cbHasAgent.Size = new System.Drawing.Size(189, 19);
            this.cbHasAgent.TabIndex = 37;
            this.cbHasAgent.CheckedChanged += new System.EventHandler(this.cbHasAgent_CheckedChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(5, 62);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(63, 13);
            this.labelControl9.TabIndex = 34;
            this.labelControl9.Text = "Agent Name:";
            // 
            // cmbRoles
            // 
            this.cmbRoles.Location = new System.Drawing.Point(20, 69);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRoles.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbRoles.Size = new System.Drawing.Size(210, 20);
            this.cmbRoles.TabIndex = 82;
            this.cmbRoles.TextChanged += new System.EventHandler(this.cmbRoles_TextChanged);
            // 
            // txtConPassword
            // 
            this.txtConPassword.Location = new System.Drawing.Point(236, 109);
            this.txtConPassword.Name = "txtConPassword";
            this.txtConPassword.Properties.PasswordChar = '*';
            this.txtConPassword.Size = new System.Drawing.Size(210, 20);
            this.txtConPassword.TabIndex = 81;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(236, 95);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(90, 13);
            this.labelControl7.TabIndex = 80;
            this.labelControl7.Text = "Confirm Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(236, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(210, 20);
            this.txtPassword.TabIndex = 79;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(236, 53);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(50, 13);
            this.labelControl6.TabIndex = 78;
            this.labelControl6.Text = "Password:";
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(20, 109);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(210, 20);
            this.txtPin.TabIndex = 77;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(236, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(210, 20);
            this.txtUsername.TabIndex = 76;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(20, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 20);
            this.txtName.TabIndex = 75;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 13);
            this.labelControl4.TabIndex = 73;
            this.labelControl4.Text = "Name:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(236, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 74;
            this.labelControl5.Text = "Username:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(18, 13);
            this.labelControl3.TabIndex = 72;
            this.labelControl3.Text = "Pin:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 71;
            this.labelControl2.Text = "Role:";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 315);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtPerms);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.txtConPassword);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPerms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHasAgent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDone;
        private DevExpress.XtraEditors.MemoEdit txtPerms;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAgentName;
        private DevExpress.XtraEditors.CheckEdit cbHasAgent;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRoles;
        private DevExpress.XtraEditors.TextEdit txtConPassword;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPin;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}