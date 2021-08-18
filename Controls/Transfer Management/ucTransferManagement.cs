using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Classes;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using System.Threading;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucTransferManagement : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtProcs = new DataTable();
        DataTable dtTransfers = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;
        public string procName = string.Empty;

        bool linesProcessed = false;
        public string linesProcessedMsg = string.Empty;

        DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbStatuses;
        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSave;
        DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtLot;
        DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtQty;

        public string id = string.Empty;
        public string lotNumber = string.Empty;
        public string qty = string.Empty;
        public string status = string.Empty;
        
        public ucTransferManagement()
        {
            InitializeComponent();
        }
        private void ucTransferManagement_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = DateTime.Now;
            dtpEndDate.MinDate = dtpStartDate.Value;
            dtpEndDate.MaxDate = DateTime.Now;

            //dtpStartDate.Value = DateTime.Now;
            dtpFailedStartDate.Value = DateTime.Now;
            //dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            dtpFailedStartDate.MaxDate = DateTime.Now;
            dtpFailedEndDate.MinDate = dtpFailedStartDate.Value;
            dtpFailedEndDate.MaxDate = DateTime.Now;
            dateTransferredStatus();
            dateFailedStatus();
            setUpDatatables();
            loadStatuses();
            getProcesses();
            txtRows.Text = "1000";

            ricmbStatuses = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            dgTransfers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricmbStatuses });
            ricmbStatuses.Click += RicmbStatuses_Click;
            //ricmbStatuses.EditValueChanged += RicmbStatuses_EditValueChanged;
            gcStatus.ColumnEdit = ricmbStatuses;

            btnSave = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            dgTransfers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnSave });
            btnSave.Click += BtnSave_Click;
            btnSave.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gcSave.ColumnEdit = btnSave;
           
            cmbStatus.Text = "Failed";
            refreshTransferItems();
        }

        public void setUpDatatables()
        {
            dtProcs.Columns.Add("DisplayName", typeof(string));
            dtProcs.Columns.Add("ProcName", typeof(string));

            dtTransfers.Columns.Add("gcID", typeof(string));
            dtTransfers.Columns.Add("gcCode", typeof(string));
            dtTransfers.Columns.Add("gcLot", typeof(string));
            dtTransfers.Columns.Add("gcFrom", typeof(string));
            dtTransfers.Columns.Add("gcTo", typeof(string));
            dtTransfers.Columns.Add("gcQty", typeof(string));
            dtTransfers.Columns.Add("gcDateTrans", typeof(string));
            dtTransfers.Columns.Add("gcUsername", typeof(string));
            dtTransfers.Columns.Add("gcProcess", typeof(string));
            dtTransfers.Columns.Add("gcTransferDesc", typeof(string));
            dtTransfers.Columns.Add("gcSave", typeof(string));
            dtTransfers.Columns.Add("gcStatus", typeof(string));
            dtTransfers.Columns.Add("gcFailureReason", typeof(string));
            dtTransfers.Columns.Add("gcDateFailed", typeof(string));
            dtTransfers.Columns.Add("gcChanged", typeof(bool));
        }
        public void loadStatuses()
        {
            try
            {
                cmbStatus.Properties.Items.Add("All");
                cmbStatus.Properties.Items.Add("Pending");
                cmbStatus.Properties.Items.Add("Failed");
                cmbStatus.Properties.Items.Add("Ignored");
                cmbStatus.Properties.Items.Add("Posted");
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getProcesses()
        {
            try
            {
                string processes = Client.getAllWhtProcs();
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
      
        private void RicmbStatuses_Click(object sender, EventArgs e)
        {
            try
            {
                status = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcStatus").ToString();
                ColumnView view = dgTransfers.FocusedView as ColumnView;
                if (view.UpdateCurrentRow())
                {
                    switch (status)
                    {
                        case "Pending":
                            this.ricmbStatuses.Items.Clear();
                            this.ricmbStatuses.Items.Add("Ignored");
                            
                            break;
                        case "Failed":
                            this.ricmbStatuses.Items.Clear();
                            this.ricmbStatuses.Items.Add("Pending");
                            this.ricmbStatuses.Items.Add("Ignored");
                            
                            break;
                        case "Ignored":
                            this.ricmbStatuses.Items.Clear();
                            this.ricmbStatuses.Items.Add("Pending");
                            
                            break;
                        case "Posted":
                            this.ricmbStatuses.Items.Clear();
                            break;
                        default:
                            break;
                    }
                }
                view.ShowEditor();
                (view.ActiveEditor as ComboBoxEdit).ShowPopup();

            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cmbStatus.Text)
            {
                case "Failed":
                    btnPending.Enabled = true;
                    btnPending.Visible = true;

                    btnUnlock.Enabled = true;
                    btnUnlock.Visible = true;
                    break;
                case "Ignored":
                    btnPending.Enabled = false;
                    btnPending.Visible = false;

                    btnUnlock.Enabled = true;
                    btnUnlock.Visible = true;
                    break;
                case "Pending":
                    btnPending.Enabled = false;
                    btnPending.Visible = false;

                    btnUnlock.Enabled = true;
                    btnUnlock.Visible = true;
                    break;
                case "Posted":
                    btnPending.Enabled = false;
                    btnPending.Visible = false;

                    btnUnlock.Enabled = false;
                    btnUnlock.Visible = false;
                    break;
                default:
                    break;
            }
            refreshTransferItems();
        }
        public void refreshTransferItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getWhseTransferLines);
            thread.Start();
        }
        public void getWhseTransferLines()
        {
            try
            {
                string startDateTransferred = tglDateTransferred.IsOn == true ? "|t" + dtpStartDate.Value.ToString("yyyy-MM-dd") : null;
                string endDateTransferred = tglDateTransferred.IsOn == true ? "|" + dtpEndDate.Value.ToString("yyyy-MM-dd") : null;
                string startDateFailed = tglDateFailed.IsOn == true ? "|f" + dtpFailedStartDate.Value.ToString("yyyy-MM-dd") : null;
                string endDateFailed = tglDateFailed.IsOn == true ? "|" + dtpFailedEndDate.Value.ToString("yyyy-MM-dd") : null;
                int comboStatusIndex = cmbStatus.SelectedIndex;
                string comboStatus = cmbStatus.Properties.Items[comboStatusIndex].ToString();

                foreach (DataRow dr in dtProcs.Rows)
                {
                    if (dr["DisplayName"].ToString() == cmbProcess.Text)
                    {
                        procName = dr["ProcName"].ToString();
                    }
                }

                if (comboStatus == "Posted")
                {
                    dataLines = Client.getWhseTransferLinesPosted(string.Format("{0}|{1}{2}{3}{4}{5}", procName, txtRows.Text, startDateTransferred, endDateTransferred, startDateFailed, endDateFailed));
                    dataPulled = true;
                }
                else if (comboStatus == "All")
                {
                    dataLines = Client.getWhseTransferLinesAll(string.Format("{0}|{1}{2}{3}{4}{5}", procName, txtRows.Text, startDateTransferred, endDateTransferred, startDateFailed, endDateFailed));
                    dataPulled = true;
                }
                else
                {
                    dataLines = Client.getWhseTransferLines(string.Format("{0}|{1}|{2}{3}{4}{5}{6}", comboStatus, procName , txtRows.Text, startDateTransferred, endDateTransferred, startDateFailed, endDateFailed));
                    dataPulled = true;
                }               
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }    
        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setWhseTransferLines();
        }
        public void setWhseTransferLines()
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
                                dtTransfers.Rows.Clear();
                                whseTransferLines = whseTransferLines.Remove(0, 2);
                                string[] allTransferLines = whseTransferLines.Split('~');
                                foreach (string transferLine in allTransferLines)
                                {
                                    if (transferLine != string.Empty)
                                    {
                                        dtTransfers.Rows.Add(transferLine.Split('|'));
                                    }
                                }

                                dgTransfers.DataSource = dtTransfers;
                                dgTransfers.MainView.GridControl.DataSource = dtTransfers;
                                dgTransfers.MainView.GridControl.EndUpdate();
                                btnUnlock.Enabled = true;
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtTransfers.Rows.Clear();
                                ppnlWait.SendToBack();
                                //whseTransferLines = whseTransferLines.Remove(0, 2);
                                //msg = new frmMsg("The following server side issue was encountered:", whseTransferLines, GlobalVars.msgState.Error);
                                //msg.ShowDialog();
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
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + whseTransferLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }
  
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                frmOverride over = new frmOverride();
                DialogResult res = over.ShowDialog();
                if (res == DialogResult.OK)
                {
                    gcLot.OptionsColumn.AllowEdit = true;
                    gcLot.OptionsColumn.ReadOnly = false;

                    gcQty.OptionsColumn.AllowEdit = true;
                    gcQty.OptionsColumn.ReadOnly = false;

                    btnUnlock.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                id = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcID").ToString();
                lotNumber = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcLot").ToString();
                qty = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcQty").ToString();
                status = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcStatus").ToString();
                string updated = Client.updateWhseTransferLine(lotNumber + "|" + qty + "|" + status + "|" + id);
                if (updated != string.Empty)
                {
                    switch (updated.Split('*')[0])
                    {
                        case "1":
                            gvTransfers.SetRowCellValue(gvTransfers.FocusedRowHandle, "gcChanged", false);
                            //refreshTransferItems();
                            break;
                        case "0":
                            updated = updated.Remove(0, 2);
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
                            ppnlWait.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving roles";
                            errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnPending_Click(object sender, EventArgs e)
        {
            msg = new frmMsg("Confirm", "Are you sure you wish to set all failed lines to pending?", GlobalVars.msgState.Question);
            msg.ShowDialog();
            DialogResult res = msg.DialogResult;
            if (res == DialogResult.Yes)
            {
                string updated = Client.updateWhseTransferLinesPending();
                if (updated != string.Empty)
                {
                    switch (updated.Split('*')[0])
                    {
                        case "1":
                            refreshTransferItems();
                            break;
                        case "0":
                            updated = updated.Remove(0, 2);
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
                            ppnlWait.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while updating failed lines";
                            errInfo = "Unexpected error while updating failed lines" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }

            
        }
        private void gvTransfers_Click(object sender, EventArgs e)
        {
            try
            {
                //status = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcStatus").ToString();
                //if (gvTransfers.FocusedRowHandle != -1)
                //{
                //    string newID = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcID").ToString();                 
                //    if (id != newID)
                //    {
                //        string lastEdited = gvTransfers.GetRowCellValue(Convert.ToInt32(id), "gcChanged").ToString();
                //        if (Convert.ToBoolean(lastEdited) == true)
                //        {
                //            msg = new frmMsg("Unsaved changes", "you have unsaved changes, do you wish to discard them?", GlobalVars.msgState.Question);
                //            DialogResult res = msg.DialogResult;
                //            if (res == DialogResult.Yes)
                //            {

                //            }
                //        }
                //        else
                //        {
                            
                //        }
                //    }
                //    else
                //    {
                //        status = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcStatus").ToString();
                //    }
                    
                //}
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void gvTransfers_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = dgTransfers.FocusedView as ColumnView;
                if (e.Column.FieldName != "gcChanged")
                {
                    gvTransfers.SetRowCellValue(gvTransfers.FocusedRowHandle, "gcChanged", true);
                }               
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void gvTransfers_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string changed = gvTransfers.GetRowCellValue(e.RowHandle, View.Columns["gcChanged"]).ToString();
                    if (Convert.ToBoolean(changed) == true)
                    {
                        e.Appearance.BackColor = Color.LightBlue;
                        e.Appearance.BackColor2 = Color.LightBlue;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        #region "Unused"
        //txtLot = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        //dgTransfers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { txtLot });
        //txtLot.EditValueChanged += TxtLot_EditValueChanged;
        //gcLot.ColumnEdit = txtLot;

        //txtQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        //dgTransfers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { txtQty });
        //txtQty.EditValueChanged += TxtQty_EditValueChanged;
        //gcQty.ColumnEdit = txtQty;

        //private void TxtLot_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ColumnView view = dgTransfers.FocusedView as ColumnView;
        //        if (view.UpdateCurrentRow())
        //        {
        //            gvTransfers.SetRowCellValue(view.FocusedRowHandle, "gcChanged", true);
        //            //gvTransfers.SetRowCellValue(view.FocusedRowHandle, "gcLot", txtLot.value);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExHandler.showErrorEx(ex);
        //    }
        //}
        //private void TxtQty_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ColumnView view = dgTransfers.FocusedView as ColumnView;
        //        if (view.UpdateCurrentRow())
        //        {
        //            gvTransfers.SetRowCellValue(view.FocusedRowHandle, "gcChanged", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExHandler.showErrorEx(ex);
        //    }
        //}
        //private void RicmbStatuses_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ColumnView view = dgTransfers.FocusedView as ColumnView;
        //        if (view.UpdateCurrentRow())
        //        {
        //            gvTransfers.SetRowCellValue(view.FocusedRowHandle, "gcChanged", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExHandler.showErrorEx(ex);
        //    }
        //}
        #endregion

        private void gvTransfers_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                string code = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcCode").ToString();
                string lot = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcLot").ToString();
                string qty = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcQty").ToString();
                string from = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcFrom").ToString();
                string to = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcTo").ToString();
                string date = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcDateTrans").ToString();
                string user = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcUsername").ToString();
                string status = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcStatus").ToString();
                string process = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcProcess").ToString();
                string failureDate = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcDateFailed").ToString();
                string reason = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcFailureReason").ToString();
                frmTransferView _view = new frmTransferView(code, lot, qty, from, to, date, user, status, process, failureDate, reason);
                _view.Show();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                processLines();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void processLines()
        {
            try
            {
                ppnlWait.BringToFront();
                btnProcess.Enabled = false;
                linesProcessed = false;
                Application.DoEvents();
                tmrProcess.Start();
                Thread thread = new Thread(processPendingWTs);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void processPendingWTs()
        {
            try
            {
                linesProcessedMsg = Client.processPendingLines();
                linesProcessed = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            showProcessMessage();
        }
        public void showProcessMessage()
        {
            try
            {
                if (linesProcessed == true)
                {
                    tmrProcess.Stop();
                    string pendingProcessed = linesProcessedMsg;
                    if (pendingProcessed != string.Empty)
                    {
                        switch (pendingProcessed.Split('*')[0])
                        {
                            case "1":
                                ppnlWait.SendToBack();
                                msg = new frmMsg("Success", "All entries processed successfully", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                refreshTransferItems();
                                btnProcess.Enabled = true;
                                break;
                            case "0":
                                ppnlWait.SendToBack();
                                pendingProcessed = pendingProcessed.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", pendingProcessed, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                pendingProcessed = pendingProcessed.Remove(0, 3);
                                errMsg = pendingProcessed.Split('|')[0];
                                errInfo = pendingProcessed.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                pendingProcessed = pendingProcessed.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", pendingProcessed, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while updating failed lines";
                                errInfo = "Unexpected error while updating failed lines" + Environment.NewLine + "Data Returned:" + Environment.NewLine + pendingProcessed;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                tmrProcess.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }

        private void dtpStartDate_ValueChanged_1(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void dtpFailedStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpFailedEndDate.MinDate = dtpFailedStartDate.Value;
        }

        private void tglDateTransferred_Toggled(object sender, EventArgs e)
        {
            dateTransferredStatus();
        }

        public void dateTransferredStatus()
        {
            if (tglDateTransferred.IsOn == true)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
        }

        public void dateFailedStatus()
        {
            if (tglDateFailed.IsOn == true)
            {
                dtpFailedStartDate.Enabled = true;
                dtpFailedEndDate.Enabled = true;
            }
            else
            {
                dtpFailedStartDate.Enabled = false;
                dtpFailedEndDate.Enabled = false;
            }
        }

        private void tglDateFailed_Toggled(object sender, EventArgs e)
        {
            dateFailedStatus();
        }
    }
}
