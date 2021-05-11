namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Approval
{
    partial class frmCMSSign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMSSign));
            this.SuspendLayout();
            // 
            // frmCMSSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCMSSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please sign to approve the cms document";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCMSSign_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCMSSign_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmCMSSign_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}