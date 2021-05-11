namespace RTIS_Vulcan_UI.Controls
{
    partial class ucUserManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserManagement));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack = new DevExpress.XtraEditors.PanelControl();
            this.dgUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHasAgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnToggleActive = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddRole = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.tmrItems = new System.Windows.Forms.Timer(this.components);
            this.ppnlWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).BeginInit();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(219, 36);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "User Management";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.dgUsers);
            this.pnlBack.Controls.Add(this.btnToggleActive);
            this.pnlBack.Controls.Add(this.btnRefresh);
            this.pnlBack.Controls.Add(this.btnRemove);
            this.pnlBack.Controls.Add(this.btnAddRole);
            this.pnlBack.Controls.Add(this.btnUpdate);
            this.pnlBack.Location = new System.Drawing.Point(4, 46);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(982, 594);
            this.pnlBack.TabIndex = 18;
            // 
            // dgUsers
            // 
            this.dgUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUsers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUsers.Location = new System.Drawing.Point(5, 52);
            this.dgUsers.MainView = this.gvUsers;
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.Size = new System.Drawing.Size(972, 537);
            this.dgUsers.TabIndex = 65;
            this.dgUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
            this.dgUsers.Click += new System.EventHandler(this.dgUsers_Click);
            // 
            // gvUsers
            // 
            this.gvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcName,
            this.gcUsername,
            this.gcPin,
            this.gcPassword,
            this.gcRole,
            this.gcActive,
            this.gcHasAgent,
            this.gcAgent});
            this.gvUsers.GridControl = this.dgUsers;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.OptionsView.ColumnAutoWidth = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "User ID";
            this.gcID.FieldName = "gcID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.OptionsColumn.ReadOnly = true;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcName
            // 
            this.gcName.Caption = "Name";
            this.gcName.FieldName = "gcName";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            this.gcName.Width = 148;
            // 
            // gcUsername
            // 
            this.gcUsername.Caption = "Username";
            this.gcUsername.FieldName = "gcUsername";
            this.gcUsername.Name = "gcUsername";
            this.gcUsername.OptionsColumn.AllowEdit = false;
            this.gcUsername.OptionsColumn.ReadOnly = true;
            this.gcUsername.Visible = true;
            this.gcUsername.VisibleIndex = 2;
            this.gcUsername.Width = 149;
            // 
            // gcPin
            // 
            this.gcPin.Caption = "Pin";
            this.gcPin.FieldName = "gcPin";
            this.gcPin.Name = "gcPin";
            this.gcPin.OptionsColumn.AllowEdit = false;
            this.gcPin.OptionsColumn.ReadOnly = true;
            this.gcPin.Visible = true;
            this.gcPin.VisibleIndex = 3;
            // 
            // gcPassword
            // 
            this.gcPassword.Caption = "Password";
            this.gcPassword.FieldName = "gcPassword";
            this.gcPassword.Name = "gcPassword";
            this.gcPassword.OptionsColumn.AllowEdit = false;
            this.gcPassword.OptionsColumn.ReadOnly = true;
            this.gcPassword.Visible = true;
            this.gcPassword.VisibleIndex = 4;
            // 
            // gcRole
            // 
            this.gcRole.Caption = "Role";
            this.gcRole.FieldName = "gcRole";
            this.gcRole.Name = "gcRole";
            this.gcRole.OptionsColumn.AllowEdit = false;
            this.gcRole.OptionsColumn.ReadOnly = true;
            this.gcRole.Visible = true;
            this.gcRole.VisibleIndex = 5;
            this.gcRole.Width = 120;
            // 
            // gcActive
            // 
            this.gcActive.Caption = "Active";
            this.gcActive.FieldName = "gcActive";
            this.gcActive.Name = "gcActive";
            this.gcActive.OptionsColumn.AllowEdit = false;
            this.gcActive.OptionsColumn.ReadOnly = true;
            this.gcActive.Visible = true;
            this.gcActive.VisibleIndex = 6;
            // 
            // gcHasAgent
            // 
            this.gcHasAgent.Caption = "Has Agent";
            this.gcHasAgent.FieldName = "gcHasAgent";
            this.gcHasAgent.Name = "gcHasAgent";
            this.gcHasAgent.OptionsColumn.AllowEdit = false;
            this.gcHasAgent.OptionsColumn.ReadOnly = true;
            this.gcHasAgent.Visible = true;
            this.gcHasAgent.VisibleIndex = 7;
            // 
            // gcAgent
            // 
            this.gcAgent.Caption = "Agent";
            this.gcAgent.FieldName = "gcAgent";
            this.gcAgent.Name = "gcAgent";
            this.gcAgent.OptionsColumn.AllowEdit = false;
            this.gcAgent.OptionsColumn.ReadOnly = true;
            this.gcAgent.Visible = true;
            this.gcAgent.VisibleIndex = 8;
            this.gcAgent.Width = 130;
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleActive.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnToggleActive.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnToggleActive.Appearance.Options.UseBackColor = true;
            this.btnToggleActive.Appearance.Options.UseFont = true;
            this.btnToggleActive.Image = ((System.Drawing.Image)(resources.GetObject("btnToggleActive.Image")));
            this.btnToggleActive.Location = new System.Drawing.Point(587, 5);
            this.btnToggleActive.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnToggleActive.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(126, 40);
            this.btnToggleActive.TabIndex = 62;
            this.btnToggleActive.Text = "Toggle Active";
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(851, 5);
            this.btnRefresh.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(126, 40);
            this.btnRefresh.TabIndex = 61;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnRemove.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRemove.Appearance.Options.UseBackColor = true;
            this.btnRemove.Appearance.Options.UseFont = true;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(719, 5);
            this.btnRemove.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnRemove.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(126, 40);
            this.btnRemove.TabIndex = 60;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnAddRole.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnAddRole.Appearance.Options.UseBackColor = true;
            this.btnAddRole.Appearance.Options.UseFont = true;
            this.btnAddRole.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRole.Image")));
            this.btnAddRole.Location = new System.Drawing.Point(323, 5);
            this.btnAddRole.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnAddRole.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(126, 40);
            this.btnAddRole.TabIndex = 63;
            this.btnAddRole.Text = "Add New";
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(455, 5);
            this.btnUpdate.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(126, 40);
            this.btnUpdate.TabIndex = 64;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tmrItems
            // 
            this.tmrItems.Tick += new System.EventHandler(this.tmrItems_Tick);
            // 
            // ppnlWait
            // 
            this.ppnlWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppnlWait.AnimationToTextDistance = 10;
            this.ppnlWait.Appearance.BackColor = System.Drawing.Color.White;
            this.ppnlWait.Appearance.Options.UseBackColor = true;
            this.ppnlWait.BarAnimationElementThickness = 2;
            this.ppnlWait.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ppnlWait.Description = "Loading data, this may take a few minutes...";
            this.ppnlWait.Location = new System.Drawing.Point(4, 3);
            this.ppnlWait.Name = "ppnlWait";
            this.ppnlWait.Size = new System.Drawing.Size(982, 640);
            this.ppnlWait.TabIndex = 22;
            this.ppnlWait.Text = "progressPanel1";
            // 
            // ucUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ppnlWait);
            this.Name = "ucUserManagement";
            this.Size = new System.Drawing.Size(989, 643);
            this.Load += new System.EventHandler(this.ucUserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBack)).EndInit();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlBack;
        private DevExpress.XtraEditors.SimpleButton btnToggleActive;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnAddRole;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraGrid.GridControl dgUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsername;
        private DevExpress.XtraGrid.Columns.GridColumn gcPin;
        private DevExpress.XtraGrid.Columns.GridColumn gcPassword;
        private DevExpress.XtraGrid.Columns.GridColumn gcRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcActive;
        private DevExpress.XtraGrid.Columns.GridColumn gcHasAgent;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgent;
        private System.Windows.Forms.Timer tmrItems;
        private DevExpress.XtraWaitForm.ProgressPanel ppnlWait;
    }
}
