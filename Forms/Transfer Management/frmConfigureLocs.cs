using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms.Transfer_Management
{
    public partial class frmConfigureLocs : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtOut = new DataTable();
        DataTable dtOutNew = new DataTable();
        DataTable dtRec = new DataTable();
        DataTable dtRecNew = new DataTable();
        string dataLines = string.Empty;
        bool recPageLoaded = false;

        string process { get; set; }
        public frmConfigureLocs(string _process)
        {
            InitializeComponent();
            process = _process;
        }
        public void setupDatatables()
        {
            dtOut.Columns.Add("gcID", typeof(string));
            dtOut.Columns.Add("gcWarehouse", typeof(string));
            dtOut.Columns.Add("gcRemove", typeof(string));
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnRemoveOut = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnRemoveOut.Buttons[0].Width = 85;
            dgOut.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnRemoveOut });
            ribtnRemoveOut.Click += RibtnRemoveOut_Click;
            gcRemove.ColumnEdit = ribtnRemoveOut;
            gcRemove.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnRemoveOut.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dtOutNew.Columns.Add("gcIDON", typeof(string));
            dtOutNew.Columns.Add("gcWarehouseON", typeof(string));
            dtOutNew.Columns.Add("gcAddON", typeof(string));
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnAdd = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnAdd.Buttons[0].Width = 85;
            dgOutNew.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnAdd });
            ribtnAdd.Click += RibtnAdd_Click;
            gcAddOn.ColumnEdit = ribtnAdd;
            gcAddOn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnAdd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dtRec.Columns.Add("gcIDRec", typeof(string));
            dtRec.Columns.Add("gcWarehouseRec", typeof(string));
            dtRec.Columns.Add("gcRemoveRec", typeof(string));
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnRemoveRec = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnRemoveRec.Buttons[0].Width = 85;
            dgRec.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnRemoveRec });
            ribtnRemoveRec.Click += RibtnRemoveRec_Click;
            gcRemoveRec.ColumnEdit = ribtnRemoveRec;
            gcRemoveRec.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnRemoveRec.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dtRecNew.Columns.Add("gcIDRA", typeof(string));
            dtRecNew.Columns.Add("gcWarehouseRA", typeof(string));
            dtRecNew.Columns.Add("gcAddRA", typeof(string));
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnAddRec = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnAddRec.Buttons[0].Width = 85;
            dgRecAdd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnAddRec });
            ribtnAddRec.Click += RibtnAddRec_Click;
            gcAddRA.ColumnEdit = ribtnAddRec;
            gcAddRA.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnAddRec.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnRemoveRec_Click(object sender, EventArgs e)
        {
            try
            {
                string whse = gvRec.GetRowCellValue(gvRec.FocusedRowHandle, "gcIDRec").ToString();
                string removed = Client.deleteWhseProcRef(process + "|" + whse + "|" + Convert.ToString(true));
                switch (removed.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "The warehouse reference has been removed sucessfully!", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        resfreshRec();
                        break;
                    case "0":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("Cannot remove Warehouse", removed, GlobalVars.msgState.Info);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        removed = removed.Remove(0, 3);
                        errMsg = removed.Split('|')[0];
                        errInfo = removed.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving PGM Manufacture items";
                        errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnAddRec_Click(object sender, EventArgs e)
        {
            try
            {
                string whse = gvRecAdd.GetRowCellValue(gvRecAdd.FocusedRowHandle, "gcIDRA").ToString();
                string added = Client.addWhseProcRef(process + "|" + whse + "|" + Convert.ToString(true));
                switch (added.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "The warehouse reference has been added sucessfully!", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        resfreshRec();
                        break;
                    case "0":
                        added = added.Remove(0, 2);
                        msg = new frmMsg("Cannot add Warehouse", added, GlobalVars.msgState.Info);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        added = added.Remove(0, 3);
                        errMsg = added.Split('|')[0];
                        errInfo = added.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        added = added.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", added, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving PGM Manufacture items";
                        errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnRemoveOut_Click(object sender, EventArgs e)
        {
            try
            {
                string whse = gvOut.GetRowCellValue(gvOut.FocusedRowHandle, "gcID").ToString();
                string removed = Client.deleteWhseProcRef(process + "|" + whse + "|" + Convert.ToString(false));
                switch (removed.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "The warehouse reference has been removed sucessfully!", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        resfreshOut();
                        break;
                    case "0":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("Cannot remove Warehouse", removed, GlobalVars.msgState.Info);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        removed = removed.Remove(0, 3);
                        errMsg = removed.Split('|')[0];
                        errInfo = removed.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving PGM Manufacture items";
                        errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string whse = gvOutNew.GetRowCellValue(gvOutNew.FocusedRowHandle, "gcIDON").ToString();
                string added = Client.addWhseProcRef(process + "|" + whse + "|" + Convert.ToString(false));
                switch (added.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "The warehouse reference has been added sucessfully!", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        resfreshOut();
                        break;
                    case "0":
                        added = added.Remove(0, 2);
                        msg = new frmMsg("Cannot add Warehouse", added, GlobalVars.msgState.Info);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        added = added.Remove(0, 3);
                        errMsg = added.Split('|')[0];
                        errInfo = added.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        added = added.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", added, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving PGM Manufacture items";
                        errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void frmConfigureLocs_Load(object sender, EventArgs e)
        {
            lblProcess.Text = process;
            setupDatatables();
            resfreshOut();
        }
        public void getOutWhses()
        {
            try
            {
                dataLines = Client.getAllProcWhses(process);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        fillDataGrid(dgOut, gvOut, dtOut);
                    });
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ExHandler.showErrorEx(ex);
                    });
                }
            }
        }
        public void resfreshOut()
        {
            btnBackOut.SendToBack();
            Thread t = new Thread(getOutWhses);
            t.Start();
        }
        private void btnOutAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (process == "Powder Prep" || process == "Fresh Slurry")
                {
                    if (dtOut.Rows.Count == 0)
                    {
                        refreshOutAdd();
                    }
                    else
                    {
                        using (msg = new frmMsg("Cannot add warehouse", "Only one warehouse may be selected for the chosen process", GlobalVars.msgState.Error))
                        {
                            msg.ShowDialog();
                        }
                    }
                }
                else
                {
                    refreshOutAdd();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshOutAdd()
        {
            try
            {
                btnOutAdd.SendToBack();
                Thread t = new Thread(getEvoWhses);
                t.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getEvoWhses()
        {
            try
            {
                dataLines = Client.getAllWhsesForConfig();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        fillDataGrid(dgOutNew, gvOutNew, dtOutNew);
                    });
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ExHandler.showErrorEx(ex);
                    });
                }
            }
        }
        private void btnBackOut_Click(object sender, EventArgs e)
        {
            resfreshOut();
        }
        private void xtcLocs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtcLocs.SelectedTabPage == xtpRec && !recPageLoaded)
            {
                resfreshRec();
            }
        }
        public void resfreshRec()
        {
            btnBackRec.SendToBack();
            Thread t = new Thread(getRecWhses);
            t.Start();
        }
        public void getRecWhses()
        {
            try
            {
                dataLines = Client.getAllProcWhsesRec(process);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        fillDataGrid(dgRec, gvRec, dtRec);
                    });
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ExHandler.showErrorEx(ex);
                    });
                }
            }
        }
        private void btnAddRec_Click(object sender, EventArgs e)
        {
            refreshRecAdd();
        }
        public void refreshRecAdd()
        {
            btnAddRec.SendToBack();
            Thread t = new Thread(getEvoWhsesRec);
            t.Start();
        }
        public void getEvoWhsesRec()
        {
            try
            {
                dataLines = Client.getAllWhsesForConfig();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        fillDataGrid(dgRecAdd, gvRecAdd, dtRecNew);
                    });
                }
            }
            catch (Exception ex)
            {
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        ExHandler.showErrorEx(ex);
                    });
                }
            }
        }
        public void fillDataGrid(GridControl dg, GridView gv, DataTable dt)
        {
            try
            {
                if (dataLines != string.Empty)
                {
                    switch (dataLines.Split('*')[0])
                    {
                        case "1":
                            dt.Rows.Clear();
                            dataLines = dataLines.Remove(0, 2);
                            foreach (string item in dataLines.Split('~'))
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dt.Rows.Add(item.Split('|'));
                                }
                            }
                            dg.DataSource = dt;
                            dg.MainView.GridControl.DataSource = dt;
                            dg.MainView.GridControl.EndUpdate();
                            gv.RefreshData();
                            dg.BringToFront();
                            break;
                        case "0":
                            dataLines = dataLines.Remove(0, 2);
                            msg = new frmMsg("Warehouse Transfer Admin", "No warehouse are configured for this process...", GlobalVars.msgState.Info);
                            msg.ShowDialog();

                            dt.Rows.Clear();
                            dg.DataSource = dt;
                            dg.MainView.GridControl.DataSource = dt;
                            dg.MainView.GridControl.EndUpdate();
                            gv.RefreshData();
                            dg.BringToFront();
                            break;
                        case "-1":
                            dataLines = dataLines.Remove(0, 3);
                            errMsg = dataLines.Split('|')[0];
                            errInfo = dataLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            dataLines = dataLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", dataLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + dataLines;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
                dataLines = string.Empty;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
