using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms
{
    public partial class frmPrintNoLot : Form
    {
        public string printedQty = string.Empty;
        string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public string itemCode { get; set; }
        public int printQty { get; set; }
        public string qtyPerLabel { get; set; }
        public string lastLabelQty { get; set; }
        public frmPrintNoLot(string _printQty, string _itemCode)
        {
            InitializeComponent();
            printedQty = _printQty;
            itemCode = _itemCode;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                double qtyPer = Convert.ToDouble(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep));
                double dPrintQty = Convert.ToDouble(printedQty.Replace(",", sep).Replace(".", sep));
                double qtyOfLabels = dPrintQty / qtyPer;
                qtyOfLabels = Math.Ceiling(qtyOfLabels);
                double remainder = dPrintQty % qtyPer;

                frmConfirmPOPrint conf = new frmConfirmPOPrint(itemCode, "NA", Convert.ToString(qtyOfLabels), Convert.ToString(qtyPer), Convert.ToString(remainder));
                conf.ShowDialog();
                DialogResult res = conf.DialogResult;
                if (res == DialogResult.OK)
                {
                    if (Convert.ToDecimal(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep)) <= Convert.ToDecimal(printedQty.Replace(",", sep).Replace(".", sep)))
                    {
                        qtyPerLabel = txtQtyPerLabel.Text;
                        lastLabelQty = txtLastLabelQty.Text;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        msg = new frmMsg("Cannot print label", "The quantity per label is larger than the quantity to reveive", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }                           
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void txtQtyPerLabel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQtyPerLabel.Text != string.Empty)
                {
                    double qtyPer = Convert.ToDouble(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep));
                    double dPrintQty = Convert.ToDouble(printedQty.Replace(",", sep).Replace(".", sep));
                    double remainder = dPrintQty % qtyPer;
                    txtLastLabelQty.Text = Convert.ToString(remainder);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
