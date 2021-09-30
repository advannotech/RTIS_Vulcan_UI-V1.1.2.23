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
        public string Qtyrec = string.Empty;
        string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public string poVendor;
        public string PO { get; set; }
        public string itemCode { get; set; }
        public string lotnumber { get; set; }
  

        public string qtyPerLabel { get; set; }
        public string lastLabelQty { get; set; }

        public string ReprintQty { get; set; }


        public string descrip { get; set; }

        public bool lotReprintItem = false;
        public bool labelsPrinted = false;
        public bool labelsReprinted = false;
        public string labelReprintInfo = string.Empty;
        public string labelInfo = string.Empty;
        public frmPOReprintlostlbl(string _qtyRec, string _itemCode, string _PO,string _descrip, string _lotnumber)
        {
            InitializeComponent();
            Qtyrec = _qtyRec;
            itemCode = _itemCode;
            PO = _PO;
            descrip = _descrip;
            lotnumber = _lotnumber;
        }
        private void frmPOReprintlostlbl_Load(object sender, EventArgs e)
        {
            lblCode.Text = itemCode;
            lblDesc.Text = descrip;
            lblLotNumber.Text = lotnumber;
            txtqtyrec.Text = Qtyrec;
        }

        private void txtQtyPerLabel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQtyPerLabel.Text != string.Empty)
                {
                    double qtyPer = Convert.ToDouble(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep));
                    double dPrintQty = Convert.ToDouble(Qtyrec.Replace(",", sep).Replace(".", sep));
                    double remainder = dPrintQty % qtyPer;
                    txtLastLabelQty.Text = Convert.ToString(remainder);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void saveReprint()
        {

            if (lotReprintItem == true)
            {
                string sendString = PO + "|" + itemCode + "|" + lotnumber + "|" + ReprintQty + "|" + GlobalVars.userName + "|" + qtyPerLabel;
                labelReprintInfo = Client.reprintPOLabelLot(sendString);
                labelsReprinted = true;
            }
            else
            {
                string sendString = PO + "|" + itemCode + "|" + ReprintQty + "|" + GlobalVars.userName + "|" + qtyPerLabel;
                labelReprintInfo = Client.reprintPOLabelNoLot(sendString);
                labelsReprinted = true;
            }
        }
        private void tmrReprint_Tick(object sender, EventArgs e)
        {
            reprintLabels();
        }



        public void startReprint()
        {
            try
            {
                labelsReprinted = false;
                Application.DoEvents();
                tmrReprint.Start();
                Thread thread = new Thread(saveReprint);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }


        public void reprintLabels()
        {
            try
            {
                if (labelsReprinted == true)
                {
                    tmrReprint.Stop();
                    //string poNumber = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                    //string code = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode").ToString();
                    //string desc = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcDesc").ToString();
                    //string lot = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotNum").ToString();
                    //bool isLot = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
                    if (lotReprintItem == true)
                    {
                        #region Lot Items
                        string lotPrinted = labelReprintInfo;
                        switch (lotPrinted.Split('*')[0])
                        {
                            case "1":
                                lotPrinted = lotPrinted.Remove(0, 2);
                                string itemInfo = Client.getLabelPrintInfo(itemCode);
                                switch (itemInfo.Split('*')[0])
                                {
                                    case "1":
                                        string[] allLabels = lotPrinted.Split('~');
                                        foreach (string label in allLabels)
                                        {
                                            if (label != string.Empty)
                                            {
                                                XtraReport printLabel = GlobalVars.POLabel;
                                                printLabel.Parameters["_ItemCode"].Value = itemCode;
                                                printLabel.Parameters["_Lot"].Value = lotnumber;
                                                printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                                printLabel.Parameters["_RT2D"].Value = label;

                                                printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                                printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                                printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                                printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                                printLabel.Parameters["_OrderNum"].Value = PO;
                                                printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                                printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                                printLabel.Parameters["_Supplier"].Value = poVendor;
                                                printLabel.CreateDocument();
                                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                prtTool.Print(GlobalVars.POPrinter);
                                            }
                                        }

                                        break;
                                    case "-1":

                                        itemInfo = itemInfo.Remove(0, 3);
                                        errMsg = itemInfo.Split('|')[0];
                                        errInfo = itemInfo.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":

                                        itemInfo = itemInfo.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:

                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while removing invalid labels";
                                        errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemInfo;
                                        break;
                                }
                                break;
                            case "-1":

                                lotPrinted = lotPrinted.Remove(0, 3);
                                errMsg = lotPrinted.Split('|')[0];
                                errInfo = lotPrinted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":

                                lotPrinted = lotPrinted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", lotPrinted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:

                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while removing invalid labels";
                                errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lotPrinted;
                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Non Lot Items
                        string lotPrinted = labelReprintInfo;
                        switch (lotPrinted.Split('*')[0])
                        {
                            case "1":
                                lotPrinted = lotPrinted.Remove(0, 2);
                                string itemInfo = Client.getLabelPrintInfo(itemCode);
                                switch (itemInfo.Split('*')[0])
                                {
                                    case "1":
                                        string[] allLabels = lotPrinted.Split('~');
                                        foreach (string label in allLabels)
                                        {
                                            if (label != string.Empty)
                                            {
                                                XtraReport printLabel = GlobalVars.POLabel;
                                                printLabel.Parameters["_ItemCode"].Value = itemCode;
                                                printLabel.Parameters["_Lot"].Value = "NA";
                                                printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                                printLabel.Parameters["_RT2D"].Value = label;

                                                printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                                printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                                printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                                printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                                printLabel.Parameters["_OrderNum"].Value = PO;
                                                printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                                printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                                printLabel.Parameters["_Supplier"].Value = poVendor;
                                                printLabel.CreateDocument();
                                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                prtTool.Print(GlobalVars.POPrinter);
                                            }
                                        }

                                        break;
                                    case "-1":

                                        itemInfo = itemInfo.Remove(0, 3);
                                        errMsg = itemInfo.Split('|')[0];
                                        errInfo = itemInfo.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":

                                        itemInfo = itemInfo.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:

                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while removing invalid labels";
                                        errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemInfo;
                                        break;
                                }
                                break;
                            case "-1":

                                lotPrinted = lotPrinted.Remove(0, 3);
                                errMsg = lotPrinted.Split('|')[0];
                                errInfo = lotPrinted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":

                                lotPrinted = lotPrinted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", lotPrinted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:

                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while removing invalid labels";
                                errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lotPrinted;
                                break;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                tmrReprint.Stop();
                ExHandler.showErrorEx(ex);
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQtyPerLabel.Text != string.Empty && txtqtyrec.Text != string.Empty)
                {
                    double qtyPer = Convert.ToDouble(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep));
                    double dPrintQty = Convert.ToDouble(Qtyrec.Replace(",", sep).Replace(".", sep));
                    double qtyOfLabels = dPrintQty / qtyPer;
                    qtyOfLabels = Math.Ceiling(qtyOfLabels);
                    double remainder = dPrintQty % qtyPer;
                    qtyOfLabels = Math.Ceiling(qtyOfLabels);

                    frmConfirmPOPrint conf = new frmConfirmPOPrint(itemCode, lblLotNumber.Text, Convert.ToString(qtyOfLabels), Convert.ToString(qtyPer), Convert.ToString(remainder));
                    conf.ShowDialog();
                    DialogResult res = conf.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        ReprintQty = conf._qty;
                        qtyPerLabel = conf._per;
                        lotReprintItem = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        string blanks = string.Empty;
                        if (txtQtyPerLabel.Text == string.Empty)
                        {
                            blanks += " - No print quantity was supplied" + Environment.NewLine;
                        }
                        if (txtqtyrec.Text == string.Empty)
                        {
                            blanks += " - No quantity per label was supplied" + Environment.NewLine;
                        }
                        msg = new frmMsg("Cannot reprint item", blanks, GlobalVars.msgState.Error);
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
