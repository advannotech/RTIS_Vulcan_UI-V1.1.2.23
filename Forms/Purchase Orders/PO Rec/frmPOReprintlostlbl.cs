using DevExpress.XtraReports.UI;
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

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.PO_Rec
{
    public partial class frmPOReprintlostlbl : Form
    {
        string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public string printQty { get; set; }
        public string qtyPerLabel { get; set; }

        public string lastLabelQty { get; set; }

        public string lot { get; set; }

        string code = string.Empty;
        string desc = string.Empty;
        double qtyrec = 0;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        
        #endregion
        public frmPOReprintlostlbl(string _code, string _desc, string _lot, double _qtyrec)
        {
            InitializeComponent();
            code = _code;
            desc = _desc;
            lot = _lot;
            qtyrec = _qtyrec;
            lastLabelQty = txtLastLabelQty.Text;

        }
        private void frmPOReprintlostlbl_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblDesc.Text = desc;
            lblLot.Text = lot;
            txtqtyreceived.Text =Convert.ToDouble(qtyrec).ToString();
            lastLabelQty = txtLastLabelQty.Text;
            txtPrintQty.Focus();
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrintQty.Text != string.Empty && txtQty.Text != string.Empty)
                {

                    double qtyPer = Convert.ToDouble(txtQty.Text.Replace(",", sep).Replace(".", sep));
                    double dPrintQty = qtyrec;
                    double qtyOfLabels = dPrintQty / qtyPer;
                    qtyOfLabels = Math.Ceiling(qtyOfLabels);
                    double remainder = dPrintQty % qtyPer;

                    frmConfirmPOPrint conf = new frmConfirmPOPrint(lblCode.Text, lblLot.Text, Convert.ToString(qtyOfLabels), Convert.ToString(qtyPer), Convert.ToString(remainder));
                    conf.ShowDialog();
                    DialogResult res = conf.DialogResult;
                    if (res == DialogResult.OK)
                    {

                        printQty = txtPrintQty.Text;
                        qtyPerLabel = txtQty.Text;
                        lastLabelQty = Convert.ToDouble(remainder).ToString();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
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

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtQty.Text != string.Empty)
                {


                    double qtyPer = Convert.ToDouble(txtQty.Text.Replace(",", sep).Replace(".", sep));
                    double dPrintQty = Convert.ToDouble(qtyrec);
                    double remainder = dPrintQty % qtyPer;
     
                    double qtyOfLabels = dPrintQty / qtyPer;
                    qtyOfLabels = Math.Ceiling(qtyOfLabels);

                    txtPrintQty.Text = Convert.ToString(qtyOfLabels);
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



    

