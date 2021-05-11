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
using DevExpress.XtraGrid.Views.Base;

namespace RTIS_Vulcan_UI
{
    public partial class ucRecTransferManagement : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        string dataLines = string.Empty;
        bool dataPulled = false;
        public string procName = string.Empty;

        DataTable dtProcs = new DataTable();
        DataTable dtWhses = new DataTable();

        public ucRecTransferManagement()
        {
            InitializeComponent();
        }
        private void ucRecTransferManagement_Load(object sender, EventArgs e)
        {
            setUpDatatables();
            getProcesses();
        }
        public void setUpDatatables()
        {
            dtProcs.Columns.Add("DisplayName", typeof(string));
            dtProcs.Columns.Add("ProcName", typeof(string));

            dtWhses.Columns.Add("gcWhseID", typeof(string));
            dtWhses.Columns.Add("gcWhseName", typeof(string));
            dtWhses.Columns.Add("gcSelected", typeof(bool));
        }
        public void getProcesses()
        {
            try
            {
                string processes = Client.getWhtProcsRec();
                if (processes != string.Empty)
                {
                    switch (processes.Split('*')[0])
                    {
                        case "1":
                            processes = processes.Remove(0, 2);
                            string[] allProcesses = processes.Split('~');
                            foreach (string proc in allProcesses)
                            {
                                if (proc != string.Empty)
                                {
                                    cmbProcess.Properties.Items.Add(proc.Split('|')[0]);
                                    dtProcs.Rows.Add(proc.Split('|'));
                                }
                            }
                            break;
                        case "0":
                            cmbProcess.Properties.Items.Clear();
                            msg = new frmMsg("The following server side issue was encountered:", processes, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            processes = processes.Remove(0, 3);
                            errMsg = processes.Split('|')[0];
                            errInfo = processes.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            processes = processes.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", processes, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving warehouse transfer processes";
                            errInfo = "Unexpected error while retreiving warehouse transfer processes" + Environment.NewLine + "Data Returned:" + Environment.NewLine + processes;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
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
            refreshWhses();
        }
        public void refreshWhses()
        {
            try
            {
                if (cmbProcess.Text != string.Empty)
                {
                    foreach (DataRow dr in dtProcs.Rows)
                    {
                        if (dr["DisplayName"].ToString() == cmbProcess.Text)
                        {
                            procName = dr["ProcName"].ToString();
                        }
                    }

                    ppnlWait.BringToFront();
                    dataPulled = false;
                    Application.DoEvents();
                    tmrItems.Start();
                    Thread thread = new Thread(getData);
                    thread.Start();
                }
                else
                {
                    msg = new frmMsg("The following server issue was encountered:", "No process was selected" + Environment.NewLine + "Please select a warehouse transfer process", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getData()
        {
            try
            {
                dataLines = Client.GetWhtProcLookupsRec(procName);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setData()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();
                    string whseLines = dataLines;
                    if (whseLines != string.Empty)
                    {
                        switch (whseLines.Split('*')[0])
                        {
                            case "1":
                                dtWhses.Rows.Clear();
                                whseLines = whseLines.Remove(0, 2);
                                string[] allWhseLines = whseLines.Split('~');
                                foreach (string whse in allWhseLines)
                                {
                                    if (whse != string.Empty)
                                    {
                                        dtWhses.Rows.Add(whse.Split('|'));
                                    }
                                }
                                dgWhses.DataSource = dtWhses;
                                dgWhses.MainView.GridControl.DataSource = dtWhses;
                                dgWhses.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtWhses.Rows.Clear();
                                dgWhses.DataSource = dtWhses;
                                dgWhses.MainView.GridControl.DataSource = dtWhses;
                                dgWhses.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                whseLines = whseLines.Remove(0, 3);
                                errMsg = whseLines.Split('|')[0];
                                errInfo = whseLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                whseLines = whseLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", whseLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving process lookups";
                                errInfo = "Unexpected error while retreiving process lookups" + Environment.NewLine + "Data Returned:" + Environment.NewLine + whseLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setData();
        }

        private void gvWhses_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = dgWhses.FocusedView as ColumnView;
                if (view.UpdateCurrentRow())
                {
                    string whseID = Convert.ToString(gvWhses.GetRowCellValue(gvWhses.FocusedRowHandle, "gcWhseID"));
                    string whseSelected = Convert.ToString(gvWhses.GetRowCellValue(gvWhses.FocusedRowHandle, "gcSelected"));

                    string updated = Client.setWhseLookupEnabledRec(procName + "|" + whseID + "|" + whseSelected);
                    if (updated != string.Empty)
                    {
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                refreshWhses();
                                break;
                            case "0":
                                cmbProcess.Properties.Items.Clear();
                                msg = new frmMsg("The following server side issue was encountered:", updated, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                updated = updated.Remove(0, 3);
                                errMsg = updated.Split('|')[0];
                                errInfo = updated.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                updated = updated.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", updated, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while updating warehouse lookups";
                                errInfo = "Unexpected error while updating warehouse lookups" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
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
