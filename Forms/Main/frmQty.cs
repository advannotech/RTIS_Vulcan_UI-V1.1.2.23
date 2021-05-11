using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Classes;

namespace RTIS_Vulcan_UI.Forms.Main
{
    public partial class frmQty : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        private string qty1 { get; set; }
        private string qty2 { get; set; }
        public decimal qty { get; set; }

        public frmQty(string _qty1, string _qty2)
        {
            InitializeComponent();
            qty1 = _qty1;
            qty2 = _qty2;
        }
        private void frmQty_Load(object sender, EventArgs e)
        {
            txtQty1.Text = qty1;
            txtQty2.Text = qty2;
            txtQty1.Focus();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtQty1.Text) && !string.IsNullOrWhiteSpace(txtQty2.Text))
                {
                    string sQty = txtQty1.Text + GlobalVars.sep + txtQty2.Text;
                    qty = Convert.ToDecimal(sQty);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    using (msg = new frmMsg("Invalid values specified", "Please enter a valid numeric value", GlobalVars.msgState.Info))
                    {
                        msg.ShowDialog();
                    }  
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        
    }
}
