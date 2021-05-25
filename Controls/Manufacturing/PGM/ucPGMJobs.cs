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
using System.Threading;

namespace RTIS_Vulcan_UI.Controls.Manufacturing.PGM
{
    public partial class ucPGMJobs : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtPGMLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public string LineID = string.Empty;
        public ucPGMJobs()
        {
            InitializeComponent();
        }

        private void ucPGMJobs_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            setupPGMDataTable();
            refreshPGMItems();
        }

        #region Load PGM Jobs
        public void setupPGMDataTable()
        {
            try
            {
                dtPGMLines.Columns.Add("gcCode", typeof(string));
                dtPGMLines.Columns.Add("gcLot", typeof(string));
                dtPGMLines.Columns.Add("gcLocation", typeof(string));
                dtPGMLines.Columns.Add("gcIn", typeof(string));
                dtPGMLines.Columns.Add("gcOut", typeof(string));
                dtPGMLines.Columns.Add("gcBal", typeof(string));
                dtPGMLines.Columns.Add("gcConcentration", typeof(string));
                dtPGMLines.Columns.Add("gcDate", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshPGMItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getPGMLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getPGMLines()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01"; //.Split(' ')[0]
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59"; //.Split(' ')[0]

                dataLines = Client.GetPGMJobsByDate(StartDate + "|" + EndDate);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }
        public void setLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();
                    string itemLines = string.Empty;

                    #region PGM

                    itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dtPGMLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtPGMLines.Rows.Add(item.Split('|'));
                                    }
                                }
                                dgItems.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtPGMLines.Rows.Clear();
                                dgItems.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("PGM Manufacture", "No Manufacturing Remaining For PGM...", GlobalVars.msgState.Success);
                                msg.ShowDialog();
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
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }

                    #endregion

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
            setLines();
        }
        #endregion

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                string lot = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLot").ToString();
                frmPGMContainers pgmConts = new frmPGMContainers(code, lot);
                pgmConts.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }      
        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshPGMItems();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }
    }
}
