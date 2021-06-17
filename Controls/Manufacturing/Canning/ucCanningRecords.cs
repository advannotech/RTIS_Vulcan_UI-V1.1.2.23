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
using RTIS_Vulcan_UI.Forms.Canning;

namespace RTIS_Vulcan_UI.Controls.Manufacturing.Canning
{
    public partial class ucCanningRecords : UserControl
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

        public ucCanningRecords()
        {
            InitializeComponent();
        }

        private void ucCanningRecords_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcItem", typeof(string));
            dtItems.Columns.Add("gcDesc", typeof(string));
            dtItems.Columns.Add("gcQty", typeof(string));
            dtItems.Columns.Add("gcRItem", typeof(string));
            dtItems.Columns.Add("gcRDesc", typeof(string));
            dtItems.Columns.Add("gcRQty", typeof(string));
            dtItems.Columns.Add("gcLot", typeof(string));
            dtItems.Columns.Add("gcJob", typeof(string));
            dtItems.Columns.Add("gcPallet", typeof(string));
            dtItems.Columns.Add("gcUser", typeof(string));
            dtItems.Columns.Add("gcDate", typeof(string));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshItems();
        }
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getCanningRecords);
            thread.Start();
        }
        public void getCanningRecords() 
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01"; //.Split(' ')[0]
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59"; //.Split(' ')[0]

                dataLines = Client.getCanningRecords(StartDate + "|" + EndDate);
                dataPulled = true;
                ppnlWait.Visible = false;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setCanningRecords()
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
            setCanningRecords();
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRecord = new DataTable();
                dtRecord.Columns.Add("gcName", typeof(string));
                dtRecord.Columns.Add("gcValue", typeof(string));
                string itemCode = gcItem.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItem").ToString();
                string itemDesc = gcDesc.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc").ToString();
                string itemQty = gcQty.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcQty").ToString();
                string rItemCode = gcRItem.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRItem").ToString();
                string rItemDesc = gcRDesc.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRDesc").ToString();
                string rItemQty = gcRQty.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRQty").ToString();
                string lotNumber = gcLot.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLot").ToString();
                string jobNo = gcJob.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcJob").ToString();
                string palletNo = gcPallet.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcPallet").ToString();
                string userName = gcUser.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUser").ToString();
                string dateAdded = gcDate.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDate").ToString();

                dtRecord.Rows.Add(itemCode.Split('|'));
                dtRecord.Rows.Add(itemDesc.Split('|'));
                dtRecord.Rows.Add(itemQty.Split('|'));
                dtRecord.Rows.Add(rItemCode.Split('|'));
                dtRecord.Rows.Add(rItemDesc.Split('|'));
                dtRecord.Rows.Add(rItemQty.Split('|'));
                dtRecord.Rows.Add(lotNumber.Split('|'));
                dtRecord.Rows.Add(jobNo.Split('|'));
                dtRecord.Rows.Add(palletNo.Split('|'));
                dtRecord.Rows.Add(userName.Split('|'));
                dtRecord.Rows.Add(dateAdded.Split('|'));

                frmCanningJobInfo jobInfo = new frmCanningJobInfo(dtRecord);
                jobInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }

        private void pnlBack_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ppnlWait_Click(object sender, EventArgs e)
        {

        }
    }
}
