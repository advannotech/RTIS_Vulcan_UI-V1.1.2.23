namespace RTIS_Vulcan_UI.Forms
{
    partial class frmCloseMix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCloseMix));
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.meReason = new DevExpress.XtraEditors.MemoEdit();
            this.btnCloseMix = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.meReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseForeColor = true;
            this.labelControl11.Appearance.Options.UseTextOptions = true;
            this.labelControl11.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(12, 12);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(503, 35);
            this.labelControl11.TabIndex = 44;
            this.labelControl11.Text = "Please enter a reason for closing the mix:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 240);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(503, 147);
            this.labelControl1.TabIndex = 45;
            this.labelControl1.Text = "Please note that by closing the job you will be invalidating the current tank inf" +
    "ormation for the rest of the CATScan system";
            // 
            // meReason
            // 
            this.meReason.Location = new System.Drawing.Point(12, 54);
            this.meReason.Name = "meReason";
            this.meReason.Size = new System.Drawing.Size(503, 180);
            this.meReason.TabIndex = 46;
            // 
            // btnCloseMix
            // 
            this.btnCloseMix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseMix.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCloseMix.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnCloseMix.Appearance.Options.UseBackColor = true;
            this.btnCloseMix.Appearance.Options.UseFont = true;
            this.btnCloseMix.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseMix.Image")));
            this.btnCloseMix.Location = new System.Drawing.Point(358, 399);
            this.btnCloseMix.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCloseMix.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCloseMix.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseMix.Name = "btnCloseMix";
            this.btnCloseMix.Size = new System.Drawing.Size(156, 49);
            this.btnCloseMix.TabIndex = 93;
            this.btnCloseMix.Text = "Close Mix";
            this.btnCloseMix.Click += new System.EventHandler(this.btnCloseMix_Click);
            // 
            // frmCloseMix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 461);
            this.Controls.Add(this.btnCloseMix);
            this.Controls.Add(this.meReason);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCloseMix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Close Mix";
            this.Load += new System.EventHandler(this.frmCloseMix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meReason.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit meReason;
        private DevExpress.XtraEditors.SimpleButton btnCloseMix;
    }
}