using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Classes;
using DevExpress.XtraGrid.Columns;
using System.Threading;

namespace RTIS_Vulcan_UI.Controls.Transfer_Management
{
    public partial class ucTransferReports : UserControl
    {
        DataTable dtTransfers = new DataTable();
        string dataLines = string.Empty;
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public ucTransferReports()
        {
            InitializeComponent();
        }
        private void ucTransferReports_Load(object sender, EventArgs e)
        {
            setUpDatatables();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(1);
        }
        public void setUpDatatables()
        {
            dtTransfers.Columns.Add("gcID", typeof(string));
            dtTransfers.Columns.Add("gcCode", typeof(string));
            dtTransfers.Columns.Add("gcLot", typeof(string));
            dtTransfers.Columns.Add("gcFrom", typeof(string));
            dtTransfers.Columns.Add("gcTo", typeof(string));
            dtTransfers.Columns.Add("gcQty", typeof(string));
            dtTransfers.Columns.Add("gcDateReq", typeof(string));
            dtTransfers.Columns.Add("gcUserReq", typeof(string));
            dtTransfers.Columns.Add("gcDateTrans", typeof(string));
            dtTransfers.Columns.Add("gcUser", typeof(string));
            dtTransfers.Columns.Add("gcProcess", typeof(string));
            dtTransfers.Columns.Add("gcStatus", typeof(string));
        }
        public void refreshRecords()
        {
            try
            {
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getWhseTransferLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getWhseTransferLines()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01";
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                dataLines = Client.getFGtransferReportLines(StartDate + "|" + EndDate);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setWhseTransferLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setWhseTransferLines()
        {
            try
            {
                string itemLines = dataLines;
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            dtTransfers.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtTransfers.Rows.Add(item.Split('|'));
                                }
                            }
                            dgTransfers.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.EndUpdate();
                            gvTransfers.RefreshData();


                            foreach (GridColumn item in gvTransfers.Columns)
                            {
                                item.BestFit();
                            }

                            ppnlWait.SendToBack();
                            break;
                        case "0":
                            dtTransfers.Rows.Clear();
                            dgTransfers.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.EndUpdate();
                            gvTransfers.RefreshData();
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("FG Transfer reports", "No transfer requests were found for the given date range", GlobalVars.msgState.Info))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        case "-1":
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 3);
                            errMsg = itemLines.Split('|')[0];
                            errInfo = itemLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            ppnlWait.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    ppnlWait.SendToBack();
                    using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshRecords();
        }
    }
}
