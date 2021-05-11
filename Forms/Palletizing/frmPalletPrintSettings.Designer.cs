namespace RTIS_Vulcan_UI.Forms.Palletizing
{
    partial class frmPalletPrintSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPalletPrintSettings));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLabel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPrinters = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConfrim = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrinters.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Pallet Label";
            // 
            // cmbLabel
            // 
            this.cmbLabel.Location = new System.Drawing.Point(13, 36);
            this.cmbLabel.Name = "cmbLabel";
            this.cmbLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLabel.Size = new System.Drawing.Size(291, 22);
            this.cmbLabel.TabIndex = 1;
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Location = new System.Drawing.Point(13, 89);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrinters.Size = new System.Drawing.Size(291, 22);
            this.cmbPrinters.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Label Printer";
            // 
            // btnConfrim
            // 
            this.btnConfrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfrim.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnConfrim.Appearance.Options.UseBackColor = true;
            this.btnConfrim.Image = ((System.Drawing.Image)(resources.GetObject("btnConfrim.Image")));
            this.btnConfrim.Location = new System.Drawing.Point(138, 131);
            this.btnConfrim.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnConfrim.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConfrim.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfrim.Name = "btnConfrim";
            this.btnConfrim.Size = new System.Drawing.Size(168, 49);
            this.btnConfrim.TabIndex = 28;
            this.btnConfrim.Text = "Confirm";
            this.btnConfrim.Click += new System.EventHandler(this.btnConfrim_Click);
            // 
            // frmPalletPrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(319, 193);
            this.Controls.Add(this.btnConfrim);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cmbLabel);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPalletPrintSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pallet Print Settings";
            this.Load += new System.EventHandler(this.frmPalletPrintSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrinters.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLabel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPrinters;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfrim;
    }
}