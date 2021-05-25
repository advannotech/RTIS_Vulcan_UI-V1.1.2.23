namespace RTIS_Vulcan_UI
{
    partial class frmSTReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSTReport));
            this.cbNeg = new DevExpress.XtraEditors.CheckEdit();
            this.cbPos = new DevExpress.XtraEditors.CheckEdit();
            this.cbUnc = new DevExpress.XtraEditors.CheckEdit();
            this.cbMatch = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cbNonMatch = new DevExpress.XtraEditors.CheckEdit();
            this.cbNonST = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNeg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNonMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNonST.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNeg
            // 
            this.cbNeg.Location = new System.Drawing.Point(16, 49);
            this.cbNeg.Margin = new System.Windows.Forms.Padding(4);
            this.cbNeg.Name = "cbNeg";
            this.cbNeg.Properties.Caption = "Negative Variances";
            this.cbNeg.Size = new System.Drawing.Size(165, 24);
            this.cbNeg.TabIndex = 0;
            this.cbNeg.CheckedChanged += new System.EventHandler(this.cbNeg_CheckedChanged);
            // 
            // cbPos
            // 
            this.cbPos.Location = new System.Drawing.Point(189, 49);
            this.cbPos.Margin = new System.Windows.Forms.Padding(4);
            this.cbPos.Name = "cbPos";
            this.cbPos.Properties.Caption = "Positive Variances";
            this.cbPos.Size = new System.Drawing.Size(173, 24);
            this.cbPos.TabIndex = 1;
            this.cbPos.CheckedChanged += new System.EventHandler(this.cbPos_CheckedChanged);
            // 
            // cbUnc
            // 
            this.cbUnc.Location = new System.Drawing.Point(16, 101);
            this.cbUnc.Margin = new System.Windows.Forms.Padding(4);
            this.cbUnc.Name = "cbUnc";
            this.cbUnc.Properties.Caption = "Uncounted Items";
            this.cbUnc.Size = new System.Drawing.Size(165, 24);
            this.cbUnc.TabIndex = 2;
            this.cbUnc.CheckedChanged += new System.EventHandler(this.cbUnc_CheckedChanged);
            // 
            // cbMatch
            // 
            this.cbMatch.Location = new System.Drawing.Point(189, 101);
            this.cbMatch.Margin = new System.Windows.Forms.Padding(4);
            this.cbMatch.Name = "cbMatch";
            this.cbMatch.Properties.Caption = "Matching Items";
            this.cbMatch.Size = new System.Drawing.Size(173, 24);
            this.cbMatch.TabIndex = 3;
            this.cbMatch.CheckedChanged += new System.EventHandler(this.cbMatch_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(296, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Which parts of the stock take would you like to see?";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(179, 197);
            this.btnOk.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.btnOk.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnOk.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(168, 49);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbNonMatch
            // 
            this.cbNonMatch.Location = new System.Drawing.Point(16, 153);
            this.cbNonMatch.Margin = new System.Windows.Forms.Padding(4);
            this.cbNonMatch.Name = "cbNonMatch";
            this.cbNonMatch.Properties.Caption = "Scanner Variances";
            this.cbNonMatch.Size = new System.Drawing.Size(165, 24);
            this.cbNonMatch.TabIndex = 6;
            this.cbNonMatch.CheckedChanged += new System.EventHandler(this.cbNonMatch_CheckedChanged);
            // 
            // cbNonST
            // 
            this.cbNonST.Location = new System.Drawing.Point(189, 153);
            this.cbNonST.Margin = new System.Windows.Forms.Padding(4);
            this.cbNonST.Name = "cbNonST";
            this.cbNonST.Properties.Caption = "Non Stock Take";
            this.cbNonST.Size = new System.Drawing.Size(173, 24);
            this.cbNonST.TabIndex = 7;
            this.cbNonST.CheckedChanged += new System.EventHandler(this.cbNonST_CheckedChanged);
            // 
            // frmSTReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 261);
            this.Controls.Add(this.cbNonST);
            this.Controls.Add(this.cbNonMatch);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbMatch);
            this.Controls.Add(this.cbUnc);
            this.Controls.Add(this.cbPos);
            this.Controls.Add(this.cbNeg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSTReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock take report";
            ((System.ComponentModel.ISupportInitialize)(this.cbNeg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNonMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNonST.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit cbNeg;
        private DevExpress.XtraEditors.CheckEdit cbPos;
        private DevExpress.XtraEditors.CheckEdit cbUnc;
        private DevExpress.XtraEditors.CheckEdit cbMatch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.CheckEdit cbNonMatch;
        private DevExpress.XtraEditors.CheckEdit cbNonST;
    }
}