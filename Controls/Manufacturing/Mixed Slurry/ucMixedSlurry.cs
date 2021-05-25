using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RTIS_Vulcan_UI.Classes;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucMixedSlurry : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtItems = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;

        public ucMixedSlurry()
        {
            InitializeComponent();
        }
        private void ucMixedSlurry_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcID", typeof(string));
            dtItems.Columns.Add("gcTank", typeof(string));
            dtItems.Columns.Add("gcItemCode", typeof(string));
            dtItems.Columns.Add("gcItemDesc", typeof(string));
            dtItems.Columns.Add("gcLotNumber", typeof(string));
            dtItems.Columns.Add("gcSlurryCount", typeof(string));
            dtItems.Columns.Add("gcDate", typeof(string));
            dtItems.Columns.Add("gcTrans", typeof(bool));
            dtItems.Columns.Add("gcRec", typeof(bool));
            dtItems.Columns.Add("gcClosed", typeof(bool));
        }
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getMixedSlurryLines);
            thread.Start();
        }
        public void getMixedSlurryLines()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01";
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                dataLines = Client.getMixedSlurryLines(StartDate + "|" + EndDate);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setMixedSlurryLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();
                    string whseTransferLines = dataLines;
                    if (whseTransferLines != string.Empty)
                    {
                        switch (whseTransferLines.Split('*')[0])
                        {
                            case "1":
                                dtItems.Rows.Clear();
                                whseTransferLines = whseTransferLines.Remove(0, 2);
                                string[] allTransferLines = whseTransferLines.Split('~');
                                foreach (string transferLine in allTransferLines)
                                {
                                    if (transferLine != string.Empty)
                                    {
                                        dtItems.Rows.Add(transferLine.Split('|'));
                                    }
                                }

                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtItems.Rows.Clear();
                                ppnlWait.SendToBack();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                whseTransferLines = whseTransferLines.Remove(0, 3);
                                errMsg = whseTransferLines.Split('|')[0];
                                errInfo = whseTransferLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                whseTransferLines = whseTransferLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", whseTransferLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving mixed slurries";
                                errInfo = "Unexpected error while retreiving mixed slurries" + Environment.NewLine + "Data Returned:" + Environment.NewLine + whseTransferLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setMixedSlurryLines();
        }
        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcID").ToString();
                string tankNum = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcTank").ToString();
                string itemCode = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemCode").ToString();
                string LotNUmber = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLotNumber").ToString();
                string tankType = tankNum.Split('_')[0];
                switch (tankType)
                {
                    case "TNK":
                        string tankInformation = Client.getMixxedSlurryTankInformation(id);
                        if (tankInformation != string.Empty)
                        {
                            switch (tankInformation.Split('*')[0])
                            {
                                case "1":
                                    tankInformation = tankInformation.Remove(0, 2);
                                    string tank = tankInformation.Split('|')[0];
                                    string slurry = tankInformation.Split('|')[1];
                                    string description = tankInformation.Split('|')[2];
                                    string lot = tankInformation.Split('|')[3];
                                    string amount = tankInformation.Split('|')[4];
                                    string zac = tankInformation.Split('|')[5];
                                    string rem = tankInformation.Split('|')[6];
                                    string rec = tankInformation.Split('|')[7];                                    
                                    string bClosed = tankInformation.Split('|')[8];
                                    string userClosed = tankInformation.Split('|')[9];
                                    string dateClosed = tankInformation.Split('|')[10];
                                    string reasonClosed = tankInformation.Split('|')[11];
                                    string wetWeight = tankInformation.Split('|')[12];
                                    string dryWeight = tankInformation.Split('|')[13];
                                    string solidity = tankInformation.Split('|')[14];

                                    frmMixedSlurryViewer msv = new frmMixedSlurryViewer(id, id, tank, slurry, description, lot, amount, zac, rem, rec, bClosed, userClosed, dateClosed, reasonClosed, tankType, wetWeight, dryWeight, solidity);
                                    msv.ShowDialog();
                                    break;
                                case "0":
                                    tankInformation = tankInformation.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", tankInformation, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    tankInformation = tankInformation.Remove(0, 3);
                                    errMsg = tankInformation.Split('|')[0];
                                    errInfo = tankInformation.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    tankInformation = tankInformation.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", tankInformation, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tankInformation;
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                        break;
                    case "MTNK":
                        string tankInfo = Client.getMixedSlurryMobileTankInformation(id);
                        if (tankInfo != string.Empty)
                        {
                            switch (tankInfo.Split('*')[0])
                            {
                                case "1":
                                    tankInfo = tankInfo.Remove(0, 2);
                                    string Hid = tankInfo.Split('|')[0];
                                    string tank = tankInfo.Split('|')[1];
                                    string slurry = tankInfo.Split('|')[2];
                                    string description = tankInfo.Split('|')[3];
                                    string lot = tankInfo.Split('|')[4];
                                    string amount = tankInfo.Split('|')[5];
                                    string zac = tankInfo.Split('|')[6];
                                    string rem = tankInfo.Split('|')[7];
                                    string rec = tankInfo.Split('|')[8];
                                    string bClosed = tankInfo.Split('|')[9];
                                    string userClosed = tankInfo.Split('|')[10];
                                    string dateClosed = tankInfo.Split('|')[11];
                                    string reasonClosed = tankInfo.Split('|')[12];
                                    string wetWeight = tankInfo.Split('|')[13];
                                    string dryWeight = tankInfo.Split('|')[14];
                                    string solidity = tankInfo.Split('|')[15];

                                    frmMixedSlurryViewer msv = new frmMixedSlurryViewer(id, Hid, tank, slurry, description, lot, amount, zac, rem, rec, bClosed, userClosed, dateClosed, reasonClosed, tankType, wetWeight, dryWeight, solidity);
                                    msv.ShowDialog();
                                    break;
                                case "0":
                                    tankInfo = tankInfo.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", tankInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    tankInfo = tankInfo.Remove(0, 3);
                                    errMsg = tankInfo.Split('|')[0];
                                    errInfo = tankInfo.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    tankInfo = tankInfo.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", tankInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tankInfo;
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }

                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshItems();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }

        private void dtpStartDate_ValueChanged_1(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }
    }
}
