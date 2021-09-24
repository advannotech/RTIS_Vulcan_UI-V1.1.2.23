using RTIS_Vulcan_UI.Classes;
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

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.PO_Rec
{
    public partial class frmPOReprintlostlbl : Form
    {
        public string printQty { get; set; }
        public string qtyPerLabel { get; set; }

        string code = string.Empty;
        string desc = string.Empty;
        string lot = string.Empty;
        string qty = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public frmPOReprintlostlbl(string _code, string _desc, string _lot,string _qty)
        {
            InitializeComponent();
            code = _code;
            desc = _desc;
            lot = _lot;
            qty=_qty;
        }

        private void frmPOReprintlostlbl_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblDesc.Text = desc;
            lblLot.Text = lot;
            txtPrintQty.Focus();
            txtQty.Text = qty;
            txtQty.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrintQty.Text != string.Empty && txtQty.Text != string.Empty)
                {
                    printQty = txtPrintQty.Text;
                    qtyPerLabel = txtQty.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtPrintQty.Text == string.Empty)
                    {
                        blanks += " - No print quantity was supplied" + Environment.NewLine;
                    }
                    if (txtQty.Text == string.Empty)
                    {
                        blanks += " - No quantity per label was supplied" + Environment.NewLine;
                    }
                    msg = new frmMsg("Cannot reprint item", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }

        }
    }
}
