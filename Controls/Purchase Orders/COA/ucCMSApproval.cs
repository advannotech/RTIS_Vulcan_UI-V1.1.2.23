using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraGrid.Columns;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Purchase_Orders;

namespace RTIS_Vulcan_UI.Controls.Purchase_Orders
{
    public partial class ucCMSApproval : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public bool dataPulled = false;
        public string dataLines = string.Empty;
        DataTable dtItems = new DataTable();

        public ucCMSApproval()
        {
            InitializeComponent();
        }

        private void ucCMSApproval_Load(object sender, EventArgs e)
        {
            setupItemDataTable();
            refreshRecords();
        }
        private void setupItemDataTable()
        {
            try
            {
                dtItems.Columns.Add("gcCode", typeof(string));
                dtItems.Columns.Add("gcDesc", typeof(string));
                dtItems.Columns.Add("gcStatus", typeof(string));
                dtItems.Columns.Add("gcStockLink", typeof(string));
                dtItems.Columns.Add("gcID", typeof(string));
                dtItems.Columns.Add("gcVersion", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshRecords()
        {
            try
            {
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getCMSHeaders);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void getCMSHeaders()
        {
            try
            {
                dataLines = Client.GetCMSApprovals();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setCMSHeaders();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void setCMSHeaders()
        {
            try
            {
                string itemLines = dataLines;
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            dtItems.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtItems.Rows.Add(item.Split('|'));
                                }
                            }
                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();


                            foreach (GridColumn item in gvItems.Columns)
                            {
                                item.BestFit();                                
                            }

                            ppnlWait.SendToBack();
                            break;
                        case "0":
                            dtItems.Rows.Clear();
                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("CMS Approval", "No CMS documents are currently awaiting approval", GlobalVars.msgState.Info))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshRecords();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvItems.FocusedRowHandle > -1)
                {
                    string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcID)).ToString();
                    string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcCode)).ToString();
                    string desc = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcDesc)).ToString();
                    string lineID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcID)).ToString();
                    string stockLink = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcStockLink)).ToString();
                    string version = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcVersion)).ToString();
                    using (frmApproveCMS appr = new frmApproveCMS(id, code, desc, lineID, stockLink, version))
                    {
                        appr.ShowDialog();
                        if (appr.DialogResult == DialogResult.OK)
                        {
                            refreshRecords();
                        }
                    }
                }
                else
                {
                    using (msg = new frmMsg("Cannot Approve CMS Document", "Please select a CMS document to approve", GlobalVars.msgState.Error))
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
    }
}
