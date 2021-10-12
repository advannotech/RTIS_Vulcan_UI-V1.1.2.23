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
    public partial class ucAWJobs : UserControl
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

        public ucAWJobs()
        {
            InitializeComponent();
        }
        private void ucAWJobs_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dtpStartDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = DateTime.Now;
            dtpEndDate.MinDate = dtpStartDate.Value;
            dtpEndDate.MaxDate = dtpStartDate.Value;
            
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcID", typeof(string));
            dtItems.Columns.Add("gcJob", typeof(string));
            dtItems.Columns.Add("gcItemCode", typeof(string));
            dtItems.Columns.Add("gcLot", typeof(string));
            dtItems.Columns.Add("gcPGM", typeof(string));
            dtItems.Columns.Add("gcPGMLot", typeof(string));
            dtItems.Columns.Add("gcJobQty", typeof(string));
            dtItems.Columns.Add("gcManufQty", typeof(string));
            dtItems.Columns.Add("gcStarted", typeof(string));
            dtItems.Columns.Add("gcUserStarted", typeof(string));
            dtItems.Columns.Add("gcClosed", typeof(string));
            dtItems.Columns.Add("gcUserClosed", typeof(string));
            dtItems.Columns.Add("gcReopened", typeof(string));
            dtItems.Columns.Add("gcUserReopened", typeof(string));
            dtItems.Columns.Add("gcRunning", typeof(bool));
        }      
        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshItems();
        }
        public void refreshItems()
        {
            ppnlWait.Visible = true;
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getAWJobs);
            thread.Start();
            ppnlWait.Visible = false;
        }
            
        public void getAWJobs()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

                dataLines = Client.getAWJobs(StartDate + "|" + EndDate);
                if (!dataLines.Equals(string.Empty))
                {
                    ppnlWait.Visible = false;
                }

                dataPulled = true;
                ppnlWait.Visible = false;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setAWJobs()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();
                    string awJobs = dataLines;
                    if (awJobs != string.Empty)
                    {
                        switch (awJobs.Split('*')[0])
                        {
                            case "1":
                                dtItems.Rows.Clear();
                                awJobs = awJobs.Remove(0, 2);
                                string[] allAwJobs = awJobs.Split('~');
                                foreach (string job in allAwJobs)
                                {
                                    if (job != string.Empty)
                                    {
                                        dtItems.Rows.Add(job.Split('|'));
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
                                awJobs = awJobs.Remove(0, 3);
                                errMsg = awJobs.Split('|')[0];
                                errInfo = awJobs.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                awJobs = awJobs.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", awJobs, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving A&W jobs";
                                errInfo = "Unexpected error while retreiving A&W jobs" + Environment.NewLine + "Data Returned:" + Environment.NewLine + awJobs;
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
            setAWJobs();
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtGenInfo = new DataTable();
            dtGenInfo.Columns.Add("gcName");
            dtGenInfo.Columns.Add("gcValue");

            //string id = "Job ID|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcID").ToString();
            //dtGenInfo.Rows.Add(id.Split('|'));
            string jobCode = "Job Code|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcJob").ToString();
            dtGenInfo.Rows.Add(jobCode.Split('|'));
            string itemCode = "Item Code|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemCode").ToString();
            dtGenInfo.Rows.Add(itemCode.Split('|'));
            string lotNumber = "Lot Number|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLot").ToString();
            dtGenInfo.Rows.Add(lotNumber.Split('|'));
            string pgm = "PGM Used|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcPGM").ToString();
            dtGenInfo.Rows.Add(pgm.Split('|'));
            string pgmLot = "PGM Lot|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcPGMLot").ToString();
            dtGenInfo.Rows.Add(pgmLot.Split('|'));
            string jobQty = "Job Qty|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcJobQty").ToString();
            dtGenInfo.Rows.Add(jobQty.Split('|'));
            string manufQty = "Manufactured Qty|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcManufQty").ToString();
            dtGenInfo.Rows.Add(manufQty.Split('|'));
            string started = "Date Started|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStarted").ToString();
            dtGenInfo.Rows.Add(started.Split('|'));
            string userStarted = "Started By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserStarted").ToString();
            dtGenInfo.Rows.Add(userStarted.Split('|'));
            string stopped = "Date Stopped|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcClosed").ToString();
            dtGenInfo.Rows.Add(stopped.Split('|'));
            string userStopped = "Stopped By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserClosed").ToString();
            dtGenInfo.Rows.Add(userStopped.Split('|'));
            string reopened = "Date Reopened|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcReopened").ToString();
            dtGenInfo.Rows.Add(reopened.Split('|'));
            string userReopened = "Reopened By|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserReopened").ToString();
            dtGenInfo.Rows.Add(userReopened.Split('|'));
            string running = "Job Running|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRunning").ToString();
            dtGenInfo.Rows.Add(running.Split('|'));

            string idParam = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcID").ToString();
            string jobCodeParam = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcJob").ToString();

            frmAWJobInfo jobInfo = new frmAWJobInfo(idParam, jobCodeParam, dtGenInfo, lotNumber.Split('|')[1], Convert.ToBoolean(running.Split('|')[1]));
            jobInfo.ShowDialog();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }
    }
}
