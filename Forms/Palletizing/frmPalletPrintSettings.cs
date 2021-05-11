using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.Palletizing
{
    public partial class frmPalletPrintSettings : Form
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        public frmPalletPrintSettings()
        {
            InitializeComponent();
        }

        private void frmPalletPrintSettings_Load(object sender, EventArgs e)
        {
            GetAvailablePrinters();
            GetPalletLabels();
            GetPrintSettings();
        }

        private void GetAvailablePrinters()
        {
            try
            {
                var server = new PrintServer();
                Console.WriteLine("Listing Shared Printers");
                var queues = server.GetPrintQueues(new[]
                    {EnumeratedPrintQueueTypes.Shared, EnumeratedPrintQueueTypes.Connections});
                foreach (var item in queues)
                {
                    cmbPrinters.Properties.Items.Add(item);
                }

                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cmbPrinters.Properties.Items.Add(printer);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void GetPalletLabels()
        {
            try
            {
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.RSCFolder + @"\Labels\");
                FileInfo[] labels = labelList.GetFiles("*.repx");
                foreach (FileInfo label in labels)
                {
                    if (label != null)
                    {
                        if (label.Name.Contains("_"))
                        {
                            string[] labelInfo = new string[3];
                            string prefix = label.Name.Split('_')[0];
                            if (prefix == "RM Pallet")
                            {
                                cmbLabel.Properties.Items.Add(label.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void GetPrintSettings()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string printInfo = Client.GetPalletPrintSettings();
                if (!string.IsNullOrWhiteSpace(printInfo))
                {
                    string returnCode = printInfo.Split('*')[0];
                    string returnData = printInfo.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            string[] returnLines = returnData.Split('~');
                            foreach (string returnLine in returnLines)
                            {
                                if (!string.IsNullOrWhiteSpace(returnLine))
                                {
                                    string[] data = returnLine.Split('|');

                                    if (data[0] == "Pallet Printer")
                                    {
                                        cmbPrinters.Text = data[1];
                                    }

                                    if (data[0] == "Pallet Label")
                                    {
                                        cmbLabel.Text = data[1];
                                    }
                                }
                            }

                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("Server Error", returnData.Remove(0, 2),
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cmbPrinters.Text) && !string.IsNullOrWhiteSpace(cmbLabel.Text))
                {
                    SplashScreenManager.ShowForm(typeof(frmWait));
                    string settingsUpdated = Client.UpdatePalletPrintSettings(cmbPrinters.Text, cmbLabel.Text);
                    if (!string.IsNullOrWhiteSpace(settingsUpdated))
                    {
                        string returnCode = settingsUpdated.Split('*')[0];
                        string returnData = settingsUpdated.Split('*')[1];
                        switch (returnCode)
                        {
                            case "1":
                                string labelCopied =
                                    Client.SendPalletLabelToServer(GlobalVars.RSCFolder + @"\Labels\" + cmbLabel.Text,
                                        cmbLabel.Text);
                                if (!string.IsNullOrWhiteSpace(labelCopied))
                                {
                                    returnCode = settingsUpdated.Split('*')[0];
                                    returnData = settingsUpdated.Split('*')[1];
                                    switch (returnCode)
                                    {
                                        case "1":
                                            SplashScreenManager.CloseForm();
                                            using (msg = new frmMsg("Success",
                                                "Pallet print settings have been successfully updated",
                                                GlobalVars.msgState.Success))
                                            {
                                                msg.ShowDialog();
                                            }
                                            break;
                                        case "0":
                                            SplashScreenManager.CloseForm();
                                            using (msg = new frmMsg("Server Error", returnData.Remove(0, 2),
                                                GlobalVars.msgState.Error))
                                            {
                                                msg.ShowDialog();
                                            }
                                            break;
                                        case "-1":
                                            SplashScreenManager.CloseForm();
                                            errMsg = returnData.Split('|')[0];
                                            errInfo = returnData.Split('|')[1];
                                            ExHandler.showErrorStr(errMsg, errInfo);
                                            break;
                                        case "-2":
                                            SplashScreenManager.CloseForm();
                                            using (msg = new frmMsg("A client side connection error has occured",
                                                returnData,
                                                GlobalVars.msgState.Error))
                                            {
                                                msg.ShowDialog();
                                            }

                                            break;
                                        default:
                                            SplashScreenManager.CloseForm();
                                            st = new StackTrace(0, true);
                                            msgStr = "An unexpected error occurred";
                                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                                      "Data Returned:" +
                                                      Environment.NewLine + returnData;
                                            ExHandler.showErrorST(st, msgStr, errInfo);
                                            break;
                                    }
                                }
                                else
                                {
                                    using (msg = new frmMsg("A connection level error has occured",
                                        "No data was returned from the server",
                                        GlobalVars.msgState.Error))
                                    {
                                        msg.ShowDialog();
                                    }
                                }
                                break;
                            case "0":
                                SplashScreenManager.CloseForm();
                                using (msg = new frmMsg("Server Error", returnData.Remove(0, 2),
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            case "-1":
                                SplashScreenManager.CloseForm();
                                errMsg = returnData.Split('|')[0];
                                errInfo = returnData.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                SplashScreenManager.CloseForm();
                                using (msg = new frmMsg("A client side connection error has occured",
                                    returnData,
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }

                                break;
                            default:
                                SplashScreenManager.CloseForm();
                                st = new StackTrace(0, true);
                                msgStr = "An unexpected error occurred";
                                errInfo = "An unexpected error occurred" + Environment.NewLine +
                                          "Data Returned:" +
                                          Environment.NewLine + returnData;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm();
                        msg = new frmMsg("A connection level error has occured",
                            "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("Cannot update print settings",
                        "Please select a printer and label design",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }
    }
}