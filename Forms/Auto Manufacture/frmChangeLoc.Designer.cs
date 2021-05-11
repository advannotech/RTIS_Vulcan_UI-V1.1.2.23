namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    partial class frmChangeLoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeLoc));
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSrc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDest = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSrc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(13, 13);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(4);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(54, 16);
            this.lblProcess.TabIndex = 16;
            this.lblProcess.Text = "[Process]";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 48);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 16);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Source : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 84);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 16);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Destination : ";
            // 
            // cmbSrc
            // 
            this.cmbSrc.Location = new System.Drawing.Point(96, 45);
            this.cmbSrc.Name = "cmbSrc";
            this.cmbSrc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSrc.Size = new System.Drawing.Size(253, 22);
            this.cmbSrc.TabIndex = 19;
            // 
            // cmbDest
            // 
            this.cmbDest.Location = new System.Drawing.Point(96, 81);
            this.cmbDest.Name = "cmbDest";
            this.cmbDest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDest.Size = new System.Drawing.Size(253, 22);
            this.cmbDest.TabIndex = 20;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(181, 114);
            this.btnEdit.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnEdit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(168, 49);
            this.btnEdit.TabIndex = 95;
            this.btnEdit.Text = "Save";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmChangeLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 176);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cmbDest);
            this.Controls.Add(this.cmbSrc);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeLoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure Process Locations";
            this.Load += new System.EventHandler(this.frmChangeLoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSrc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDest.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl lblProcess;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSrc;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDest;
        internal DevExpress.XtraEditors.SimpleButton btnEdit;
    }
}