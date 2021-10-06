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
    public partial class frmPrint : Form
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

        public string PO { get; set; }
        public string itemCode { get; set; }
        public string lotNum { get; set; }
        //public int printQty { get; set; }
        public string qtyPerLabel { get; set; }
        public string lastLabelQty { get; set; }
        public frmPrint(string _printQty, string _itemCode, string _PO)
        {
            InitializeComponent();
            printedQty = _printQty;
            itemCode = _itemCode;
            PO = _PO;
        }
        private void frmPrint_Load(object sender, EventArgs e)
        {
            if (GlobalVars.LastPOLotRemebered == PO)
            {
                cbRemember.Checked = GlobalVars.RememberPOLot;
                if (cbRemember.Checked == true)
                {
                    txtLot.Text = GlobalVars.LastPOLot;
                }
                else
                {
                    txtLot.Text = string.Empty;
                }
            }
            else
            {
                cbRemember.Checked = false;
                txtLot.Text = string.Empty;
            }

            //txtLot.Text = GlobalVars.LastPOLot;
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
              
                frmConfirmPOPrint conf = new frmConfirmPOPrint(itemCode, txtLot.Text, Convert.ToString(qtyOfLabels), Convert.ToString(qtyPer), Convert.ToString(remainder));
                conf.ShowDialog();
                DialogResult res = conf.DialogResult;
                if (res == DialogResult.OK)
                {
                    if (Convert.ToDecimal(txtQtyPerLabel.Text.Replace(",", sep).Replace(".", sep)) <= Convert.ToDecimal(printedQty.Replace(",", sep).Replace(".", sep)))
                    {
                        bool rememberPOLot = cbRemember.Checked;
                        string lotNumber = txtLot.Text;
                        string updateCommand = string.Empty;
                        string updated = string.Empty;
                        if (rememberPOLot == true)
                        {

                            updateCommand += "UPDATE [Settings] SET [Value] ='" + Convert.ToString(cbRemember.Checked) + "' WHERE [SettingName] = 'RememberPOLot';";
                            updateCommand += "UPDATE [Settings] SET [Value] ='" + txtLot.Text + "' WHERE [SettingName] = 'LastPOLot';";
                            updateCommand += "UPDATE [Settings] SET [Value] ='" + PO + "' WHERE [SettingName] = 'LastPOLotRemembered';";
                            updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        }
                        else
                        {
                            updateCommand += "UPDATE [Settings] SET [Value] ='" + Convert.ToString(cbRemember.Checked) + "' WHERE [SettingName] = 'RememberPOLot';";
                            updateCommand += "UPDATE [Settings] SET [Value] ='" + string.Empty + "' WHERE [SettingName] = 'LastPOLot';";
                            updateCommand += "UPDATE [Settings] SET [Value] ='" + string.Empty + "' WHERE [SettingName] = 'LastPOLotRemembered';";
                            updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        }

                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                if (rememberPOLot == true)
                                {
                                    GlobalVars.RememberPOLot = cbRemember.Checked;
                                    GlobalVars.LastPOLot = txtLot.Text;
                                    GlobalVars.LastPOLotRemebered = PO;
                                }
                                else
                                {
                                    GlobalVars.RememberPOLot = cbRemember.Checked;
                                    GlobalVars.LastPOLot = string.Empty;
                                    GlobalVars.LastPOLotRemebered = string.Empty;
                                }
                                    
                                if (txtQtyPerLabel.Text != string.Empty)
                                {
                                    lotNum = txtLot.Text;
                                    qtyPerLabel = txtQtyPerLabel.Text;
                                    lastLabelQty = txtLastLabelQty.Text;
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    msg = new frmMsg("Cannot print label", "Please supply a quantity per label", GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                }
                                #region Unused
                                string lotValid = "1*Success";
                                if (lotValid != string.Empty)
                                {
                                    switch (lotValid.Split('*')[0])
                                    {
                                        case "1":

                                            break;
                                        case "0":
                                            lotValid = lotValid.Remove(0, 2);
                                            msg = new frmMsg("The following server side issue was encountered:", lotValid, GlobalVars.msgState.Error);
                                            msg.ShowDialog();
                                            break;
                                        case "-1":
                                            lotValid = lotValid.Remove(0, 3);
                                            errMsg = lotValid.Split('|')[0];
                                            errInfo = lotValid.Split('|')[1];
                                            ExHandler.showErrorStr(errMsg, errInfo);
                                            break;
                                        case "-2":
                                            lotValid = lotValid.Remove(0, 2);
                                            msg = new frmMsg("A connection level error has occured", lotValid, GlobalVars.msgState.Error);
                                            msg.ShowDialog();
                                            break;
                                        default:
                                            st = new StackTrace(0, true);
                                            msgStr = "Unexpected error while retreiving purchase order items";
                                            errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lotValid;
                                            break;
                                    }
                                }
                                else
                                {

                                }
                                #endregion
                                break;
                            case "-1":
                                updated = updated.Remove(0, 3);
                                errMsg = updated.Split('|')[0];
                                errInfo = updated.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                Cursor.Current = Cursors.Default;
                                StackTrace st1 = new StackTrace(0, true);
                                string msgStr1 = "Unexpected saving settings";
                                string infoStr1 = "Unexpected saving setting";
                                ExHandler.showErrorST(st1, msgStr1, infoStr1);
                                break;
                        }
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
