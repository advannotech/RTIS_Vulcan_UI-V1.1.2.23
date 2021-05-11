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
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using RTIS_Vulcan_UI.Reports;
using DevExpress.DataAccess.ConnectionParameters;

namespace RTIS_Vulcan_UI
{
    public partial class ucPrepManufacture : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtPPLines = new DataTable();
        DataTable dtSlurryLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public string LineID = string.Empty;

        #region Powder Prep Data Tables

        public void setupPPDataTable()
        {
            try
            {
                dtPPLines.Columns.Add("gcID", typeof(string));
                dtPPLines.Columns.Add("gcItemCode", typeof(string));
                dtPPLines.Columns.Add("gcDesc", typeof(string));
                dtPPLines.Columns.Add("gcLotNum", typeof(string));
                dtPPLines.Columns.Add("gcQty", typeof(string));
                dtPPLines.Columns.Add("gcDateE", typeof(string));
                dtPPLines.Columns.Add("gcEvoManufacture", typeof(bool));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshPPItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getPPLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getPPLines()
        {
            try
            {
                dataLines = Client.GetPPLines();
                dataPulled = true;
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Slurry Data Tables

        public void setupSlurryDataTable()
        {
            try
            {
                dtSlurryLines.Columns.Add("gcSID", typeof(string));
                dtSlurryLines.Columns.Add("gcTrolley", typeof(string));
                dtSlurryLines.Columns.Add("gcTank", typeof(string));
                dtSlurryLines.Columns.Add("gcSItemCode", typeof(string));
                dtSlurryLines.Columns.Add("gcSDesc", typeof(string));
                dtSlurryLines.Columns.Add("gcSLotNum", typeof(string));
                dtSlurryLines.Columns.Add("gcQtyWet", typeof(string));
                dtSlurryLines.Columns.Add("gcSolidity", typeof(string));
                dtSlurryLines.Columns.Add("gcQtyDry", typeof(string));
                dtSlurryLines.Columns.Add("gcSDateE", typeof(string));
                dtSlurryLines.Columns.Add("gcSEvoManufacture", typeof(bool));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshSlurryItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getSlurryLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getSlurryLines()
        {
            try
            {
                dataLines = Client.GetFSlurryLines();
                dataPulled = true;
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }
        #endregion

        #region All Data Tables

        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setLines();
        }

        public void setLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();

                    switch (GlobalVars.RMProcess)
                    {
                        case "PP":
                            #region Powder Prep

                            string itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtPPLines.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtPPLines.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgPowderPrep.DataSource = dtPPLines;
                                        dgPowderPrep.MainView.GridControl.DataSource = dtPPLines;
                                        dgPowderPrep.MainView.GridControl.EndUpdate();
                                        gvPowderPrep.RefreshData();

                                        dgSlurry.Visible = false;
                                        dgPowderPrep.Visible = true;
                                        dgSlurry.Enabled = false;
                                        dgPowderPrep.Enabled = true;

                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtPPLines.Rows.Clear();
                                        dgPowderPrep.DataSource = dtPPLines;
                                        dgPowderPrep.MainView.GridControl.DataSource = dtPPLines;
                                        dgPowderPrep.MainView.GridControl.EndUpdate();
                                        gvPowderPrep.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("RM Manufacture", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving powder prep items";
                                        errInfo = "Unexpected error while retreiving powder prep items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                            break;
                        case "FS":
                            #region Fresh Slurry

                            string sitemLines = dataLines;
                            if (sitemLines != string.Empty)
                            {
                                switch (sitemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtSlurryLines.Rows.Clear();
                                        itemLines = sitemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtSlurryLines.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgSlurry.DataSource = dtSlurryLines;
                                        dgSlurry.MainView.GridControl.DataSource = dtSlurryLines;
                                        dgSlurry.MainView.GridControl.EndUpdate();
                                        gvSlurry.RefreshData();

                                        gcTank.Visible = false;
                                        gcTank.VisibleIndex = -1;
                                        gcTrolley.Visible = true;
                                        gcTrolley.VisibleIndex = 0;

                                        dgPowderPrep.Visible = false;
                                        dgSlurry.Visible = true;
                                        dgPowderPrep.Enabled = false;
                                        dgSlurry.Enabled = true;


                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtSlurryLines.Rows.Clear();
                                        dgSlurry.DataSource = dtSlurryLines;
                                        dgSlurry.MainView.GridControl.DataSource = dtSlurryLines;
                                        dgSlurry.MainView.GridControl.EndUpdate();
                                        gvSlurry.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = sitemLines.Remove(0, 2);
                                        msg = new frmMsg("RM Manufacture", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        break;
                                    case "-1":
                                        ppnlWait.SendToBack();
                                        itemLines = sitemLines.Remove(0, 3);
                                        errMsg = itemLines.Split('|')[0];
                                        errInfo = itemLines.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        ppnlWait.SendToBack();
                                        itemLines = sitemLines.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        ppnlWait.SendToBack();
                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while retreiving fresh slurry items";
                                        errInfo = "Unexpected error while retreiving fresh slurry items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + sitemLines;
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
                            break;
                        default:
                            ppnlWait.SendToBack();
                            msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        public ucPrepManufacture()
        {
            InitializeComponent();
        }
        private void ucPrepManufacture_Load(object sender, EventArgs e)
        {
            setupPPDataTable();
            setupSlurryDataTable();

            dgPowderPrep.Enabled = false;
            dgSlurry.Enabled = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEvoManu = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            dgPowderPrep.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { chkEvoManu });
            chkEvoManu.CheckedChanged += ChkEvoManu_CheckedChanged;
            gcEvoManufacture.ColumnEdit = chkEvoManu;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSEvoManu = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            dgSlurry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { chkSEvoManu });
            chkSEvoManu.CheckedChanged += ChkSEvoManu_CheckedChanged;
            gcSEvoManufacture.ColumnEdit = chkSEvoManu;

            setProcesses();
        }
        
        #region Search Options

        public void setProcesses()
        {
            try
            {
                cmbProcess.Properties.Items.Clear();

                cmbProcess.Properties.Items.Add("Powder Prep");
                cmbProcess.Properties.Items.Add("Fresh Slurry");
                cmbProcess.Text = "-SELECT PROCESS-";
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void cmbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProcess.SelectedIndex != -1)
            {
                if (cmbProcess.Text == "Powder Prep")
                {
                    GlobalVars.RMProcess = "PP";
                }
                else if(cmbProcess.Text == "Fresh Slurry")
                {
                    GlobalVars.RMProcess = "FS";
                }
                else if(cmbProcess.Text == "Mixed Slurry")
                {
                    GlobalVars.RMProcess = "MS";
                }
                else
                {
                    GlobalVars.RMProcess = "";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RMProcess == "PP")
            {
                refreshPPItems();
            }
            else if (GlobalVars.RMProcess == "FS")
            {
                refreshSlurryItems();
            }
            else
            {
                msg = new Forms.frmMsg("RM Manufacture", "Please select a valid process...", GlobalVars.msgState.Info);
                msg.ShowDialog();
            }
        }

        #endregion

        private void ChkEvoManu_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {
                LineID = Convert.ToString(gvPowderPrep.GetRowCellValue(gvPowderPrep.FocusedRowHandle, "gcID"));
                string Itemcode = Convert.ToString(gvPowderPrep.GetRowCellValue(gvPowderPrep.FocusedRowHandle, "gcItemCode"));
                string Lot = Convert.ToString(gvPowderPrep.GetRowCellValue(gvPowderPrep.FocusedRowHandle, "gcLotNum"));
                string qty = Convert.ToString(gvPowderPrep.GetRowCellValue(gvPowderPrep.FocusedRowHandle, "gcQty"));

                msg = new Forms.frmMsg("RM Manufacture", "Are you sure you have completed the manufacturing of " + Environment.NewLine + "Item: " + Itemcode + Environment.NewLine + "Lot: " + Lot + Environment.NewLine + "Quantity: " + qty + Environment.NewLine + " in Evolution?", GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    //Update RTIS Manufactured Date|User|True
                    ppnlWait.BringToFront();
                    tmrItems.Start();
                    dataPulled = false;
                    Application.DoEvents();
                    Thread thread = new Thread(UpdateRTIS);
                    thread.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        public void UpdateRTIS()
        {
            string Updated = string.Empty;
            if (GlobalVars.RMProcess == "PP")
            {
                Updated = Client.UpdatePPManufacture(LineID, GlobalVars.userName);
                switch (Updated.Split('*')[0])
                {
                    case "1":
                            getPPLines();
                        break;
                    default:
                        Updated = Updated.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", Updated, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        ppnlWait.SendToBack();
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "FS")
            {
                Updated = Client.UpdateFSManufacture(LineID, GlobalVars.userName);
                switch (Updated.Split('*')[0])
                {
                    case "1":
                            refreshSlurryItems();
                        break;
                    default:
                        Updated = Updated.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", Updated, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        ppnlWait.SendToBack();
                        break;
                }
            }                      
        }

        private void ChkSEvoManu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LineID = Convert.ToString(gvSlurry.GetRowCellValue(gvSlurry.FocusedRowHandle, "gcSID"));
                string Itemcode = Convert.ToString(gvSlurry.GetRowCellValue(gvSlurry.FocusedRowHandle, "gcSItemCode"));
                string Lot = Convert.ToString(gvSlurry.GetRowCellValue(gvSlurry.FocusedRowHandle, "gcSLotNum"));
                string qty = Convert.ToString(gvSlurry.GetRowCellValue(gvSlurry.FocusedRowHandle, "gcQtyDry"));

                msg = new Forms.frmMsg("RM Manufacture", "Are you sure you have completed the manufacturing of " + Environment.NewLine + "Item: " + Itemcode + Environment.NewLine + "Lot: " + Lot + Environment.NewLine + "Quantity: " + qty + Environment.NewLine + " in Evolution?", GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    //Update RTIS Manufactured Date|User|True
                    ppnlWait.BringToFront();
                    tmrItems.Start();
                    dataPulled = false;
                    Application.DoEvents();
                    Thread thread = new Thread(UpdateRTIS);
                    thread.Start();
                }
            }
            catch (Exception)
            {
            }
        }


    }
}
