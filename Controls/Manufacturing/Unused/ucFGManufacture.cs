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
    public partial class ucFGManufacture : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtFGLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public string LineID = string.Empty;

        #region FG Data Tables

        public void setupFGDataTable()
        {
            try
            {
                dtFGLines.Columns.Add("gcID", typeof(string));
                dtFGLines.Columns.Add("gcItemCode", typeof(string));
                dtFGLines.Columns.Add("gcDesc", typeof(string));
                dtFGLines.Columns.Add("gcLotNum", typeof(string));
                dtFGLines.Columns.Add("gcCoat", typeof(string));
                dtFGLines.Columns.Add("gcSlurry", typeof(string));
                dtFGLines.Columns.Add("gcQty", typeof(string));
                dtFGLines.Columns.Add("gcDateA", typeof(string));
                dtFGLines.Columns.Add("gcUserA", typeof(string));
                dtFGLines.Columns.Add("gcPrinted", typeof(bool));
                dtFGLines.Columns.Add("gcEvoManufacture", typeof(bool));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshFGItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getFGLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getFGLines()
        {
            try
            {
                if (GlobalVars.RMProcess == "ZECT1")
                {
                    dataLines = Client.GetZECT1FGLines();
                }
                else if (GlobalVars.RMProcess == "ZECT2")
                {
                    dataLines = Client.GetZECT2FGLines();
                }
                else//A&W
                {
                    dataLines = Client.GetAWFGLines();
                }
                
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
                    string itemLines = string.Empty;

                    switch (GlobalVars.RMProcess)
                    {
                        case "AW":
                            #region A&W - To Be Modified Later

                            itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtFGLines.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtFGLines.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        dgFGManufacture.Visible = true;
                                        dgFGManufacture.Enabled = true;

                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtFGLines.Rows.Clear();
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("FG Manufacture", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving FG Manufacture items";
                                        errInfo = "Unexpected error while retreiving  FG Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                        case "ZECT1":
                            #region ZECT

                             itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtFGLines.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtFGLines.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        dgFGManufacture.Visible = true;
                                        dgFGManufacture.Enabled = true;

                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtFGLines.Rows.Clear();
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("FG Manufacture", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving FG Manufacture items";
                                        errInfo = "Unexpected error while retreiving  FG Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                        case "ZECT2":
                            #region ZECT

                            itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtFGLines.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtFGLines.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        dgFGManufacture.Visible = true;
                                        dgFGManufacture.Enabled = true;

                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtFGLines.Rows.Clear();
                                        dgFGManufacture.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.DataSource = dtFGLines;
                                        dgFGManufacture.MainView.GridControl.EndUpdate();
                                        gvFGManufacture.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("FG Manufacture", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving FG Manufacture items";
                                        errInfo = "Unexpected error while retreiving  FG Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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

        public ucFGManufacture()
        {
            InitializeComponent();
        }
        private void ucFGManufacture_Load(object sender, EventArgs e)
        {
            setupFGDataTable();

            dgFGManufacture.Enabled = false;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEvoManu = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            dgFGManufacture.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { chkEvoManu });
            chkEvoManu.CheckedChanged += ChkEvoManu_CheckedChanged;
            gcEvoManufacture.ColumnEdit = chkEvoManu;

            setProcesses();
        }
        
        #region Search Options

        public void setProcesses()
        {
            try
            {
                cmbProcess.Properties.Items.Clear();

                cmbProcess.Properties.Items.Add("ZECT Line 1");
                cmbProcess.Properties.Items.Add("ZECT Line 2");
                cmbProcess.Properties.Items.Add("A&W Line");

                cmbProcess.Text = "-SELECT FG PROCESS-";
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
                if (cmbProcess.Text == "ZECT Line 1")
                {
                    GlobalVars.RMProcess = "ZECT1";
                    gcCoat.Visible = true;
                    gcSlurry.Visible = true;
                    gcItemCode.VisibleIndex = 0;
                    gcDesc.VisibleIndex = 1;
                    gcLotNum.VisibleIndex = 2;
                    gcCoat.VisibleIndex = 3;
                    gcSlurry.VisibleIndex = 4;
                    gcQty.VisibleIndex = 5;
                    gcDateA.VisibleIndex = 6;
                    gcUserA.VisibleIndex = 7;
                    gcPrinted.VisibleIndex = 8;
                    gcEvoManufacture.VisibleIndex = 9;

                    dtFGLines.Rows.Clear();
                    dgFGManufacture.Enabled = false;
                }
                else if(cmbProcess.Text == "ZECT Line 2")
                {
                    GlobalVars.RMProcess = "ZECT2";
                    gcCoat.Visible = true;
                    gcSlurry.Visible = true;
                    gcItemCode.VisibleIndex = 0;
                    gcDesc.VisibleIndex = 1;
                    gcLotNum.VisibleIndex = 2;
                    gcCoat.VisibleIndex = 3;
                    gcSlurry.VisibleIndex = 4;
                    gcQty.VisibleIndex = 5;
                    gcDateA.VisibleIndex = 6;
                    gcUserA.VisibleIndex = 7;
                    gcPrinted.VisibleIndex = 8;
                    gcEvoManufacture.VisibleIndex = 9;

                    dtFGLines.Rows.Clear();
                    dgFGManufacture.Enabled = false;
                }
                else if(cmbProcess.Text == "A&W Line")
                {
                    GlobalVars.RMProcess = "AW";
                    gcCoat.Visible = false;
                    gcCoat.VisibleIndex = -1;
                    gcSlurry.Visible = false;
                    gcSlurry.VisibleIndex = -1;

                    gcItemCode.VisibleIndex = 0;
                    gcDesc.VisibleIndex = 1;
                    gcLotNum.VisibleIndex = 2;
                    gcQty.VisibleIndex = 3;
                    gcDateA.VisibleIndex = 4;
                    gcUserA.VisibleIndex = 5;
                    gcPrinted.VisibleIndex = 6;
                    gcEvoManufacture.VisibleIndex = 7;

                    dtFGLines.Rows.Clear();
                    dgFGManufacture.Enabled = false;
                }
                else
                {
                    GlobalVars.RMProcess = "";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RMProcess != "")
            {
                refreshFGItems();
            }
            else
            {
                msg = new Forms.frmMsg("FG Manufacture", "Please select a valid process...", GlobalVars.msgState.Info);
                msg.ShowDialog();
            }
        }

        #endregion

        private void ChkEvoManu_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {
                LineID = Convert.ToString(gvFGManufacture.GetRowCellValue(gvFGManufacture.FocusedRowHandle, "gcID"));
                string Itemcode = Convert.ToString(gvFGManufacture.GetRowCellValue(gvFGManufacture.FocusedRowHandle, "gcItemCode"));
                string Lot = Convert.ToString(gvFGManufacture.GetRowCellValue(gvFGManufacture.FocusedRowHandle, "gcLotNum"));
                string qty = Convert.ToString(gvFGManufacture.GetRowCellValue(gvFGManufacture.FocusedRowHandle, "gcQty"));

                msg = new Forms.frmMsg("FG Manufacture", "Are you sure you have completed the manufacturing of " + Environment.NewLine + "Item: " + Itemcode + Environment.NewLine + "Lot: " + Lot + Environment.NewLine + "Quantity: " + qty + Environment.NewLine + " in Evolution?", GlobalVars.msgState.Question);
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
            if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
            {
                Updated = Client.UpdateZECTALLFGManufacture(LineID, GlobalVars.userName);
                switch (Updated.Split('*')[0])
                {
                    case "1":
                            getFGLines();
                        break;
                    default:
                        Updated = Updated.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", Updated, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        ppnlWait.SendToBack();
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "AW")
            {
                Updated = Client.UpdateAWFGManufacture(LineID, GlobalVars.userName);
                switch (Updated.Split('*')[0])
                {
                    case "1":
                            refreshFGItems();
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
        

    }
}
