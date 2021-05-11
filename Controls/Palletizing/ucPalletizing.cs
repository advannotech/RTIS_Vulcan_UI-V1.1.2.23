using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Controls.Manufacturing.PGM;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Main;
using RTIS_Vulcan_UI.Forms.Palletizing;
using RTIS_Vulcan_UI.Reports;

namespace RTIS_Vulcan_UI.Controls.Palletizing
{
    public partial class ucPalletizing : UserControl
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        public ucPalletizing()
        {
            InitializeComponent();
        }
        private void ucPalletizing_Load(object sender, EventArgs e)
        {
            GetItemCodes();
            dtpFrom.DateTime = DateTime.Now;
            dtpTo.DateTime = DateTime.Now;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnOpen =
                new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnOpen.Buttons[0].Width = 85;
            dgPallets.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnOpen});
            ribtnOpen.Click += RibtnOpen_Click;
            gcOpen.ColumnEdit = ribtnOpen;
            gcOpen.Width = 93;
            gcOpen.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnOpen.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            pnlMain.BringToFront();
        }
        private void GetItemCodes()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string allItemCodes = Client.GetItemCodes_Palletizing();
                if (!string.IsNullOrWhiteSpace(allItemCodes))
                {
                    string returnCode = allItemCodes.Split('*')[0];
                    string returnData = allItemCodes.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            string[] AllItemCodes = returnData.Split('~');
                            foreach (string itemCode in AllItemCodes)
                            {
                                if (!string.IsNullOrWhiteSpace(itemCode))
                                {
                                    cmbItemCode.Properties.Items.Add(itemCode);
                                }
                            }

                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
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
        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cmbItemCode.Text))
                {
                    GetItemLots();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void GetItemLots()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string allItemLots = Client.GetItemLots_Palletizing(cmbItemCode.Text);
                if (!string.IsNullOrWhiteSpace(allItemLots))
                {
                    string returnCode = allItemLots.Split('*')[0];
                    string returnData = allItemLots.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            string[] AllItemLots = returnData.Split('~');
                            foreach (string lotNumber in AllItemLots)
                            {
                                if (!string.IsNullOrWhiteSpace(lotNumber))
                                {
                                    cmbLotNumbers.Properties.Items.Add(lotNumber);
                                }
                            }

                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
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
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string palletLines = string.Empty;
                if (!string.IsNullOrWhiteSpace(cmbLotNumbers.Text))
                {
                    //Search by lot
                    palletLines = Client.GetPalletsByLot(cmbItemCode.Text, cmbLotNumbers.Text, cbDate.Checked.ToString(),
                        dtpFrom.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 00:00:01",
                        dtpTo.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 23:59:59");
                }
                else if (!string.IsNullOrWhiteSpace(cmbItemCode.Text))
                {
                    //Search by item
                    palletLines = Client.GetPalletsByItem(cmbItemCode.Text, cbDate.Checked.ToString(),
                        dtpFrom.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 00:00:01",
                        dtpTo.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 23:59:59");
                }
                else
                {
                    //Search by All
                    palletLines = Client.GetPallets( cbDate.Checked.ToString(),
                        dtpFrom.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 00:00:01",
                        dtpTo.DateTime.ToString("yyyy-MM-dd").Replace("/", "-") + " 23:59:59");
                }

                if (!string.IsNullOrWhiteSpace(palletLines))
                {
                    string returnCode = palletLines.Split('*')[0];
                    string returnData = palletLines.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllPallets = new List<Pallet>();
                            string[] returnLines = returnData.Split('~');
                            foreach (string returnLine in returnLines)
                            {
                                if (!string.IsNullOrWhiteSpace(returnLine))
                                {
                                    string[] lineData = returnLine.Split('|');
                                    AllPallets.Add(new Pallet(lineData));
                                }
                            }

                            dgPallets.DataSource = AllPallets;
                            gvPallets.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
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
                    //Ignore
                }
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedPallet = gvPallets.GetFocusedRow() as  Pallet;
                if (SelectedPallet != null)
                {
                    lblItemCode.Text = SelectedPallet.ItemCode;
                    lblPrinted.Text = SelectedPallet.Printed;
                    GetPalletContents();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void GetPalletContents()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string palletContents = Client.GetPalletLines(SelectedPallet.Id);
                if (!string.IsNullOrWhiteSpace(palletContents))
                {
                    string returnCode = palletContents.Split('*')[0];
                    string returnData = palletContents.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllLines = new List<PalletLine>();
                            string[] returnLines = returnData.Split('~');
                            foreach (string returnLine in returnLines)
                            {
                                if (!string.IsNullOrWhiteSpace(returnLine))
                                {
                                    string[] lineData = returnLine.Split('|');
                                    AllLines.Add(new PalletLine(lineData));
                                }
                            }

                            dgContents.DataSource = AllLines;
                            gvConents.RefreshData();
                            pnlPallet.BringToFront();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
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
                    //Ignore
                }
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnPrintSettings_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmPalletPrintSettings settings = new frmPalletPrintSettings())
                {
                    settings.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                pnlMain.BringToFront();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt2 = new DataTable();
                dt2.TableName = "Query";
                dt2.Columns.Add("vUnqBarcode");
                dt2.Columns.Add("bOnPallet");

                rptPalletLines rpt = new rptPalletLines();
                foreach (PalletLine palletLine in AllLines)
                {
                    dt2.Rows.Add(new string[2]{palletLine.LotNumber, palletLine.OnPallet.ToString()});
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt2);

                #region Parameters

                if (!string.IsNullOrWhiteSpace(cmbItemCode.Text))
                {
                    rpt.ItemCode.Value = cmbItemCode.Text;
                }
                else
                {
                    rpt.ItemCode.Value = "N/A";
                }

                if (cbDate.Checked)
                {
                    rpt.DateFrom.Value = dtpFrom.DateTime.ToString();
                    rpt.DateTo.Value = dtpTo.DateTime.ToString();
                }
                else
                {
                    rpt.DateFrom.Value = "N/A";
                    rpt.DateTo.Value = "N/A";
                }

                rpt.DataSource = ds;
                rpt.DataMember = "Query";
                ReportPrintTool printTool = new ReportPrintTool(rpt);
                printTool.ShowPreview();
                #endregion
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string labelPrinted = Client.ReprintPalletLabel(SelectedPallet.PalletNumber);
                if (!string.IsNullOrWhiteSpace(labelPrinted))
                {
                    string returnCode = labelPrinted.Split('*')[0];
                    string returnData = labelPrinted.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("Success",
                                "the pallet label has been reprinted.",
                                GlobalVars.msgState.Success))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
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
                    //Ignore
                }
                ExHandler.showErrorEx(ex);
            }
        }
        public class Pallet
        {
            public Pallet(string[] args)
            {
                Id = args[0];
                PalletNumber = args[1];
                ItemCode = args[2];
                Printed = args[3];
                LotNumbers = args[4];
            }

            public string Id { get; set; }
            public string PalletNumber { get; set; }
            public string ItemCode { get; set; }
            public string Printed { get; set; }
            public string LotNumbers { get; set; }
        }
        private List<Pallet> AllPallets = new List<Pallet>();
        private Pallet SelectedPallet;

        public class PalletLine
        {
            public PalletLine(string[] args)
            {
                LotNumber = args[0];
                OnPallet = Convert.ToBoolean(args[1]);
            }

            public string LotNumber { get; set; }
            public bool OnPallet { get; set; }
        }
        private List<PalletLine> AllLines = new List<PalletLine>();

        
    }
}
