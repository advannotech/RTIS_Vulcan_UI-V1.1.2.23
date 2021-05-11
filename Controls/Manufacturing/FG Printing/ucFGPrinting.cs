using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using RTIS_Vulcan_UI.Classes;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_UI.Controls.Manufacturing
{
    public partial class ucFGPrinting : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtBoxes = new DataTable();

        string code { get; set; }
        string lot { get; set; }
        string qty { get; set; }
        string unq { get; set; }

        public ucFGPrinting()
        {
            InitializeComponent();
        }
        private void ucFGPrinting_Load(object sender, EventArgs e)
        {
            dtBoxes.Columns.Add("gcBoxNo", typeof(string));
            dtBoxes.Columns.Add("gcQty", typeof(string));

            cmbCompany.Properties.Items.Add("Toyota");
            cmbCompany.Properties.Items.Add("VW");
        }
        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtItem.Text != string.Empty)
                    {
                        code = Barcodes.GetItemCode(txtItem.Text);
                        lot = Barcodes.GetItemLot(txtItem.Text);
                        qty = Barcodes.GetItemQty(txtItem.Text);
                        unq = Barcodes.GetUniqCode(txtItem.Text);

                        txtItem.Enabled = false;
                        txtPerBox.Enabled = true;
                        cmbCompany.Enabled = true;
                        txtBoxQty.Enabled = true;
                        txtBoxQty.Focus();

                        lblItemCode.Text = code;
                        lblLot.Text = lot;
                        lblQty.Text = qty;

                        btnConfirm.Enabled = true;
                    }
                    else
                    {
                        msg = new frmMsg("Cannot Continue", "Please scan a valid pallet tag barcode!", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtItem.Enabled = true;
                txtItem.Focus();
                txtBoxQty.Enabled = false;
                txtPerBox.Enabled = false;
                cmbCompany.Enabled = false;

                lblItemCode.Text = string.Empty;
                lblLot.Text = string.Empty;
                lblQty.Text = string.Empty;

                btnConfirm.Enabled = false;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 1;
                int remQty = Convert.ToInt32(qty);
                int boxQty = Convert.ToInt32(txtPerBox.Text);
                int qtyToPrint = Convert.ToInt32(txtBoxQty.Text);

                int numBoxes = remQty / boxQty;

                if (numBoxes == qtyToPrint || numBoxes == qtyToPrint - 1)
                {
                    for (int i = 0; i < qtyToPrint; i++)
                    {
                        if (remQty >= boxQty)
                        {
                            string boxNo = Convert.ToString(counter).PadLeft(3, '0');
                            dtBoxes.Rows.Add(boxNo, txtPerBox.Text);
                            remQty = remQty - boxQty;
                            counter++;
                        }
                    }

                    if (remQty <= boxQty)
                    {
                        if (remQty != 0)
                        {
                            string boxNo = Convert.ToString(counter).PadLeft(3, '0');
                            dtBoxes.Rows.Add(boxNo, Convert.ToString(remQty));
                        }

                        dgItems.DataSource = dtBoxes;
                        dgItems.MainView.GridControl.DataSource = dtBoxes;
                        dgItems.MainView.GridControl.EndUpdate();
                        gvItems.RefreshData();

                        grpInfo.Enabled = false;
                        pnlPrint.Enabled = true;
                    }
                    else
                    {
                        msg = new frmMsg("Cannot Continue", "The remaining quantity would be above the per box qty please enter a larger amount of boxes or a larger box quantity!", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot Continue", "The quantity per box supplied cannot be diveded into the number of boxes required!", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void clearFields()
        {
            try
            {
                txtItem.Text = string.Empty;
                txtBoxQty.Text = string.Empty;
                txtPerBox.Text = string.Empty;
                cmbCompany.Text = string.Empty;

                lblItemCode.Text = string.Empty;
                lblLot.Text = string.Empty;
                lblQty.Text = string.Empty;

                txtItem.Enabled = true;
                txtBoxQty.Enabled = false;
                txtPerBox.Enabled = false;
                cmbCompany.Enabled = false;

                grpInfo.Enabled = true;
                pnlPrint.Enabled = false;

                dtBoxes.Rows.Clear();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItem.Text != string.Empty && txtPerBox.Text != string.Empty && txtBoxQty.Text != string.Empty && cmbCompany.Text != string.Empty)
                {
                    XtraReport boxLabel = new XtraReport();
                    XtraReport palletLabel = new XtraReport();
                    string boxPrinter = string.Empty;
                    string palletPrinter = string.Empty;
                    switch (cmbCompany.Text)
                    {
                        case "Toyota":
                            boxLabel = GlobalVars.boxLabel_Toyota;
                            palletLabel = GlobalVars.palletLabel_Toyota;
                            boxPrinter = GlobalVars.boxPrinter_Toyota;
                            palletPrinter = GlobalVars.palletPrinter_Toyota;
                            break;
                        case "VW":
                            boxLabel = GlobalVars.boxLabel_VW;
                            palletLabel = GlobalVars.palletLabel_VW;
                            boxPrinter = GlobalVars.boxPrinter_VW;
                            palletPrinter = GlobalVars.palletPrinter_VW;
                            break;
                    }

                    decimal total = 0;
                    string boxInformation = string.Empty;
                    for (int i = 0; i < dtBoxes.Rows.Count; i++)
                    {
                        string boxNo = gvItems.GetRowCellValue(i, "gcBoxNo").ToString();
                        string boxQty = gvItems.GetRowCellValue(i, "gcQty").ToString();
                        decimal dQty = Convert.ToDecimal(boxQty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep));
                        total = total + dQty;
                        boxInformation += boxNo + "|" + boxQty + "~";
                    }

                    if (total == Convert.ToDecimal(qty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)))
                    {
                        boxInformation = boxInformation.Substring(0, boxInformation.Length - 1);
                        string sendString = code + "|" + lot + "|" + qty + "|" + unq + "*" + boxInformation;
                        string barcodeInfo = Client.getFGLabelInfo(code);
                        if (barcodeInfo != string.Empty)
                        {
                            switch (barcodeInfo.Split('*')[0])
                            {
                                case "1":
                                    barcodeInfo = barcodeInfo.Remove(0, 2);
                                    string barcode = barcodeInfo.Split('|')[0];
                                    string simpleCode = barcodeInfo.Split('|')[1];
                                    string binLocation = barcodeInfo.Split('|')[2];
                                    string description1 = barcodeInfo.Split('|')[3];
                                    string description2 = barcodeInfo.Split('|')[4];
                                    string description3 = barcodeInfo.Split('|')[5];
                                    string group = barcodeInfo.Split('|')[6];

                                    string unqs = Client.saveFGLabels(sendString);
                                    if (unqs != string.Empty)
                                    {
                                        switch (unqs.Split('*')[0])
                                        {
                                            case "1":
                                                unqs = unqs.Remove(0, 2);
                                                string palletBarcode = unqs.Split('*')[0];
                                                string boxBarcodes = unqs.Split('*')[1];

                                                foreach (string boxBarcode in boxBarcodes.Split('~'))
                                                {
                                                    string rt2d = Barcodes.GetUniqCode(boxBarcode);
                                                    string boxNo = rt2d.Split('_')[1];
                                                    string boxQty = Barcodes.GetItemQty(boxBarcode);
                                                    boxLabel.Parameters["_ItemCode"].Value = code;
                                                    boxLabel.Parameters["_Lot"].Value = lot;
                                                    boxLabel.Parameters["_Qty"].Value = boxQty;
                                                    boxLabel.Parameters["_RT2D"].Value = boxBarcode;
                                                    boxLabel.Parameters["_barcode"].Value = barcode;
                                                    boxLabel.Parameters["_bin"].Value = binLocation;
                                                    boxLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                    boxLabel.Parameters["_Description1"].Value = description1;
                                                    boxLabel.Parameters["_Description2"].Value = description2;
                                                    boxLabel.Parameters["_Description3"].Value = description3;
                                                    boxLabel.Parameters["_Group"].Value = group;
                                                    boxLabel.Parameters["_SimpleCode"].Value = simpleCode;
                                                    boxLabel.Parameters["_BoxNumber"].Value = boxNo;
                                                    boxLabel.CreateDocument();
                                                    ReportPrintTool prtTool = new ReportPrintTool(boxLabel);
                                                    prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                    prtTool.Print(boxPrinter);
                                                }

                                                palletLabel.Parameters["_ItemCode"].Value = code;
                                                palletLabel.Parameters["_Lot"].Value = lot;
                                                palletLabel.Parameters["_Qty"].Value = qty;
                                                palletLabel.Parameters["_RT2D"].Value = palletBarcode;
                                                palletLabel.Parameters["_barcode"].Value = barcode;
                                                palletLabel.Parameters["_bin"].Value = binLocation;
                                                palletLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                palletLabel.Parameters["_Description1"].Value = description1;
                                                palletLabel.Parameters["_Description2"].Value = description2;
                                                palletLabel.Parameters["_Description3"].Value = description3;
                                                palletLabel.Parameters["_Group"].Value = group;
                                                palletLabel.Parameters["_SimpleCode"].Value = simpleCode;

                                                palletLabel.CreateDocument();
                                                ReportPrintTool prtToolPal = new ReportPrintTool(palletLabel);
                                                prtToolPal.PrinterSettings.Copies = Convert.ToInt16(GlobalVars.palletLabelQty);
                                                prtToolPal.Print(palletPrinter);
                                                clearFields();
                                                break;
                                            case "0":
                                                unqs = unqs.Remove(0, 2);
                                                msg = new frmMsg("The following server side issue was encountered:", unqs, GlobalVars.msgState.Error);
                                                msg.ShowDialog();
                                                break;
                                            case "-1":
                                                unqs = unqs.Remove(0, 3);
                                                errMsg = unqs.Split('|')[0];
                                                errInfo = unqs.Split('|')[1];
                                                ExHandler.showErrorStr(errMsg, errInfo);
                                                break;
                                            case "-2":
                                                unqs = unqs.Remove(0, 2);
                                                msg = new frmMsg("A connection level error has occured", unqs, GlobalVars.msgState.Error);
                                                msg.ShowDialog();
                                                break;
                                            default:
                                                st = new StackTrace(0, true);
                                                msgStr = "Unexpected error while retreiving linked suppliers";
                                                errInfo = "Unexpected error while retreiving linked suppliers" + Environment.NewLine + "Data Returned:" + Environment.NewLine + unqs;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                    }
                                    break;
                                case "0":
                                    barcodeInfo = barcodeInfo.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", barcodeInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    barcodeInfo = barcodeInfo.Remove(0, 3);
                                    errMsg = barcodeInfo.Split('|')[0];
                                    errInfo = barcodeInfo.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    barcodeInfo = barcodeInfo.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", barcodeInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving linked suppliers";
                                    errInfo = "Unexpected error while retreiving linked suppliers" + Environment.NewLine + "Data Returned:" + Environment.NewLine + barcodeInfo;
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        msg = new frmMsg("Invalid Quantities", "The quantities entered for the boxes do not add up to the total pallet quantity", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Empty Fields Detected", "Please scan a valid tag and enter all of the required information to continue!", GlobalVars.msgState.Error);
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
