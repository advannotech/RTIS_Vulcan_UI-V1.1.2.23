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
using System.Threading;
using RTIS_Vulcan_UI.Classes;

namespace RTIS_Vulcan_UI.Controls.Manufacturing
{
    public partial class ucZectOutput : UserControl
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

        public ucZectOutput()
        {
            InitializeComponent();
        }
        private void ucZectOutput_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcID", typeof(string));
            dtItems.Columns.Add("gcCode", typeof(string));
            dtItems.Columns.Add("gcItemCode", typeof(string));
            dtItems.Columns.Add("gcLot", typeof(string));
            dtItems.Columns.Add("gcQty", typeof(string));
            dtItems.Columns.Add("gcManufQty", typeof(string));
            dtItems.Columns.Add("gcStarted", typeof(string));
            dtItems.Columns.Add("gcLine", typeof(string));
            dtItems.Columns.Add("gcRunning", typeof(bool));

            dtItems.Columns.Add("gcUserStarted", typeof(string));
            dtItems.Columns.Add("gcStopped", typeof(string));
            dtItems.Columns.Add("gcUserStopped", typeof(string));
            dtItems.Columns.Add("gcReopened", typeof(string));
            dtItems.Columns.Add("gcUserReopened", typeof(string));
        }
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getZectJobs);
            thread.Start();
        }
        public void getZectJobs()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01"; 
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59"; 

                dataLines = Client.getZectJobs(StartDate + "|" + EndDate);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setZectJobLines()
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
                                msgStr = "Unexpected error while retreiving ZECT jobs";
                                errInfo = "Unexpected error while retreiving ZECT jobs" + Environment.NewLine + "Data Returned:" + Environment.NewLine + whseTransferLines;
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
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }

        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setZectJobLines();
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGenInfo = new DataTable();
                dtGenInfo.Columns.Add("gcName");
                dtGenInfo.Columns.Add("gcValue");

                string idParam = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcID").ToString();
                string jobCodeParam = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();

                string itemCode = "Item Code|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemCode").ToString();
                dtGenInfo.Rows.Add(itemCode.Split('|'));
                string lotNumber = "Lot Number|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLot").ToString();
                dtGenInfo.Rows.Add(lotNumber.Split('|'));
                string jobQty = "Job Qty|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcQty").ToString();
                dtGenInfo.Rows.Add(jobQty.Split('|'));
                string manufQty = "Manufactured Qty|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcManufQty").ToString();
                dtGenInfo.Rows.Add(manufQty.Split('|'));
                string line = "ZECT Line|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLine").ToString();
                dtGenInfo.Rows.Add(line.Split('|'));
                string running = "Job Running|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRunning").ToString();
                dtGenInfo.Rows.Add(running.Split('|'));
                string started = "Date Started|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStarted").ToString();
                dtGenInfo.Rows.Add(started.Split('|'));
                string userStarted = "Started By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserStarted").ToString();
                dtGenInfo.Rows.Add(userStarted.Split('|'));
                string stopped = "Date Stopped|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStopped").ToString();
                dtGenInfo.Rows.Add(stopped.Split('|'));
                string userStopped = "Stopped By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserStopped").ToString();
                dtGenInfo.Rows.Add(userStopped.Split('|'));
                string reopened = "Date Reopened|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcReopened").ToString();
                dtGenInfo.Rows.Add(reopened.Split('|'));
                string userReopened = "Reopened By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserReopened").ToString();
                dtGenInfo.Rows.Add(userReopened.Split('|'));

                //itemCode, lotNumber, jobQty, manufQty, line, running, started, userStarted, stopped, userStopped, reopened, userReopened

                frmZECTJobInfo ji = new frmZECTJobInfo(idParam, jobCodeParam, dtGenInfo);
                ji.ShowDialog();

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

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }
    }
}
