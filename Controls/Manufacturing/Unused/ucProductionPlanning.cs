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
    public partial class ucProductionPlanning : UserControl
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        DataTable dtProcessLines = new DataTable();
        DataTable dtSelectCS = new DataTable();
        DataTable dtSelectSP = new DataTable();

        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public bool Adding = false;
        string AddProcess = string.Empty;
        string CSCataylst = string.Empty;
        string CSSlurry = string.Empty;
        string CSAW = string.Empty;

        string SPPowder = string.Empty;
        string SPSlurry = string.Empty;
        string SPCatalyst = string.Empty;

        string SPCoat = string.Empty;

        public bool Editing = false;
        string EditID = string.Empty;

        #region Process Data Tables

        public void setupProcessDataTable()
        {
            try
            {
                dtProcessLines.Columns.Add("gcID", typeof(string));
                dtProcessLines.Columns.Add("gcAWCode", typeof(string));
                dtProcessLines.Columns.Add("gcCatalystCode", typeof(string));
                dtProcessLines.Columns.Add("gcSlurryCode", typeof(string));
                dtProcessLines.Columns.Add("gcPowderCode", typeof(string));
                dtProcessLines.Columns.Add("gcCoatNum", typeof(string));
                dtProcessLines.Columns.Add("gcDateAdd", typeof(string));                
                dtProcessLines.Columns.Add("gcUserAdd", typeof(string));
                dtProcessLines.Columns.Add("gcDateEdit", typeof(string));
                dtProcessLines.Columns.Add("gcUserEdit", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshProcessItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getProcessLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getProcessLines()
        {
            try
            {
                if (GlobalVars.RMProcess == "PP")
                {
                    dataLines = Client.GetPowderPlanningLines();
                }
                else if (GlobalVars.RMProcess == "ZECT1")
                {
                    dataLines = Client.GetZECT1PlanningLines();
                }
                else if (GlobalVars.RMProcess == "ZECT2")
                {
                    dataLines = Client.GetZECT2PlanningLines();
                }
                else if (GlobalVars.RMProcess == "A&W")
                {
                    dataLines = Client.GetAWPlanningLines();
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

        #region Select Catalyst/Slurry Data Tables - SELECTCS

        public void setupSelectCSDataTable()
        {
            try
            {
                dtSelectCS.Columns.Add("gcEvoID", typeof(string));
                dtSelectCS.Columns.Add("gcEvoCatalystCode", typeof(string));
                dtSelectCS.Columns.Add("gcEvoCatalystDesc", typeof(string));
                dtSelectCS.Columns.Add("gcEvoSlurryCode", typeof(string));
                dtSelectCS.Columns.Add("gcEvoSlurryDesc", typeof(string));
                dtSelectCS.Columns.Add("gcEvoAWCode", typeof(string));
                dtSelectCS.Columns.Add("gcEvoAWDesc", typeof(string));
                dtSelectCS.Columns.Add("gcSelected", typeof(string));
            }

            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshSelectCSItems()
        {
            try
            {
                AddProcess = "CS";
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getSelectCSLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getSelectCSLines()
        {
            try
            {
                dataLines = Client.GetSelectCSPlanningLines();
                dataPulled = true;
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Select Slurry/Powder Data Tables - SELECTSP

        public void setupSelectSPDataTable()
        {
            try
            {
                dtSelectSP.Columns.Add("gcEvoIDSP", typeof(string));
                dtSelectSP.Columns.Add("gcEvoSlurryCodeSP", typeof(string));
                dtSelectSP.Columns.Add("gcEvoSlurryDescSP", typeof(string));
                dtSelectSP.Columns.Add("gcEvoPowderCode", typeof(string));
                dtSelectSP.Columns.Add("gcEvoPowderDesc", typeof(string));
                dtSelectSP.Columns.Add("gcEvoAWCatalystCode", typeof(string));
                dtSelectSP.Columns.Add("gcEvoAWCatalystDesc", typeof(string));
                dtSelectSP.Columns.Add("gcSelectedSP", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshSelectSPItems()
        {
            try
            {
                AddProcess = "SP";
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getSelectSPLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getSelectSPLines()
        {
            try
            {
                dataLines = Client.GetSelectSPPlanningLines();
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
                    if (Adding == true)
                    {
                        if (AddProcess == "CS")
                        {
                            #region SelectCS Gridview

                            string itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtSelectCS.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                if (GlobalVars.RMProcess == "PP")
                                                {
                                                    if (itemS[1] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectCS.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                                {
                                                    if (itemS[3] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectCS.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if(GlobalVars.RMProcess == "A&W")
                                                {
                                                    if (itemS[4] == "" && itemS[5] != "")
                                                    {
                                                        dtSelectCS.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                            }
                                        }
                                        dgSelectCS.DataSource = dtSelectCS;
                                        dgSelectCS.MainView.GridControl.DataSource = dtSelectCS;
                                        dgSelectCS.MainView.GridControl.EndUpdate();
                                        gvSelectCS.RefreshData();

                                        if (GlobalVars.RMProcess == "PP")
                                        {
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = -1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = -1;
                                            gcEvoAWCode.Visible = false;
                                            gcEvoAWCode.VisibleIndex = -1;
                                            gcEvoAWDesc.Visible = false;
                                            gcEvoAWDesc.VisibleIndex = -1;

                                            gcEvoSlurryCode.Visible = true;
                                            gcEvoSlurryCode.VisibleIndex = 1;
                                            gcEvoSlurryDesc.Visible = true;
                                            gcEvoSlurryDesc.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select A Slurry Code";

                                        }
                                        else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                        {
                                            gcEvoSlurryCode.Visible = false;
                                            gcEvoSlurryCode.VisibleIndex = -1;
                                            gcEvoSlurryDesc.Visible = false;
                                            gcEvoSlurryDesc.VisibleIndex = -1;
                                            gcEvoAWCode.Visible = false;
                                            gcEvoAWCode.VisibleIndex = -1;
                                            gcEvoAWDesc.Visible = false;
                                            gcEvoAWDesc.VisibleIndex = -1;

                                            gcEvoCatalystCode.Visible = true;
                                            gcEvoCatalystCode.VisibleIndex = 1;
                                            gcEvoCatalystDesc.Visible = true;
                                            gcEvoCatalystDesc.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select A Catalyst Code";
                                        }
                                        else if(GlobalVars.RMProcess == "A&W")
                                        {
                                            gcEvoSlurryCode.Visible = false;
                                            gcEvoSlurryCode.VisibleIndex = -1;
                                            gcEvoSlurryDesc.Visible = false;
                                            gcEvoSlurryDesc.VisibleIndex = -1;
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = -1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = -1;

                                            gcEvoAWCode.Visible = true;
                                            gcEvoAWCode.VisibleIndex = 1;
                                            gcEvoAWDesc.Visible = true;
                                            gcEvoAWDesc.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select An A&W Catalyst Code";
                                        }

                                        dgProcess.SendToBack();
                                        gbSearch.SendToBack();
                                        dgProcess.Visible = false;
                                        gbSearch.Visible = false;
                                        dgSelectSP.Visible = false;
                                        pnlOptions.Visible = false;

                                        dgSelectCS.BringToFront();
                                        dgSelectCS.Visible = true;

                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtProcessLines.Rows.Clear();
                                        dgProcess.DataSource = dtProcessLines;
                                        dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                                        dgProcess.MainView.GridControl.EndUpdate();
                                        gvProcess.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("Production Planning", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving items";
                                        errInfo = "Unexpected error while retreiving items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                        else
                        {
                            #region SelectSP Gridview

                            string itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtSelectSP.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                if (GlobalVars.RMProcess == "PP")
                                                {
                                                    if (itemS[1] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                                {
                                                    if (itemS[3] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "A&W")
                                                {
                                                    if (itemS[4] == "" && itemS[5] != "")
                                                    {
                                                        dtSelectSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                            }
                                        }
                                        dgSelectSP.DataSource = dtSelectSP;
                                        dgSelectSP.MainView.GridControl.DataSource = dtSelectSP;
                                        dgSelectSP.MainView.GridControl.EndUpdate();
                                        gvSelectSP.RefreshData();


                                        if (GlobalVars.RMProcess == "PP")
                                        {
                                            gcEvoSlurryCodeSP.Visible = false;
                                            gcEvoSlurryCodeSP.VisibleIndex = -1;
                                            gcEvoSlurryDescSP.Visible = false;
                                            gcEvoSlurryDescSP.VisibleIndex = -1;

                                            gcEvoAWCatalystCode.Visible = false;
                                            gcEvoAWCatalystCode.VisibleIndex = -1;
                                            gcEvoAWCatalystDesc.Visible = false;
                                            gcEvoAWCatalystDesc.VisibleIndex = -1;

                                            gcEvoPowderCode.Visible = true;
                                            gcEvoPowderCode.VisibleIndex = 1;
                                            gcEvoPowderDesc.Visible = true;
                                            gcEvoPowderDesc.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select A Powder Code";
                                            pnlOptions.Visible = true;
                                            pnlOptions.Enabled = false;
                                            dgSelectSP.Enabled = true;
                                        }
                                        else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                        {
                                            gcEvoPowderCode.Visible = false;
                                            gcEvoPowderCode.VisibleIndex = -1;
                                            gcEvoPowderDesc.Visible = false;
                                            gcEvoPowderDesc.VisibleIndex = -1;

                                            gcEvoAWCatalystCode.Visible = false;
                                            gcEvoAWCatalystCode.VisibleIndex = -1;
                                            gcEvoAWCatalystDesc.Visible = false;
                                            gcEvoAWCatalystDesc.VisibleIndex = -1;

                                            gcEvoSlurryCodeSP.Visible = true;
                                            gcEvoSlurryCodeSP.VisibleIndex = 1;
                                            gcEvoSlurryDescSP.Visible = true;
                                            gcEvoSlurryDescSP.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select A Slurry Code";
                                            pnlOptions.Visible = true;
                                            pnlOptions.Enabled = true;
                                            dgSelectSP.Enabled = false;
                                        }
                                        else if(GlobalVars.RMProcess == "A&W")
                                        {
                                            gcEvoSlurryCodeSP.Visible = false;
                                            gcEvoSlurryCodeSP.VisibleIndex = -1;
                                            gcEvoSlurryDescSP.Visible = false;
                                            gcEvoSlurryDescSP.VisibleIndex = -1;

                                            gcEvoPowderCode.Visible = false;
                                            gcEvoPowderCode.VisibleIndex = -1;
                                            gcEvoPowderDesc.Visible = false;
                                            gcEvoPowderDesc.VisibleIndex = -1;

                                            gcEvoAWCatalystCode.Visible = true;
                                            gcEvoAWCatalystCode.VisibleIndex = 1;
                                            gcEvoAWCatalystDesc.Visible = true;
                                            gcEvoAWCatalystDesc.VisibleIndex = 2;

                                            lblHeader.Text = "Production Planning - Select A Catalyst Code";
                                            pnlOptions.Visible = true;
                                            pnlOptions.Enabled = false;
                                            dgSelectSP.Enabled = true;
                                        }

                                        dgSelectCS.SendToBack();
                                        dgSelectCS.Visible = false;
                                        
                                        pnlOptions.BringToFront();
                                        dgSelectSP.BringToFront();
                                        dgSelectSP.Visible = true;
                                        
                                        ppnlWait.SendToBack();
                                        dataPulled = false;
                                        break;
                                    case "0":
                                        dtProcessLines.Rows.Clear();
                                        dgProcess.DataSource = dtProcessLines;
                                        dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                                        dgProcess.MainView.GridControl.EndUpdate();
                                        gvProcess.RefreshData();

                                        ppnlWait.SendToBack();
                                        itemLines = itemLines.Remove(0, 2);
                                        msg = new frmMsg("Production Planning", "No Evolution Codes Found...", GlobalVars.msgState.Success);
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
                                        msgStr = "Unexpected error while retreiving items";
                                        errInfo = "Unexpected error while retreiving items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                    else if (Editing == true)
                    {
                        #region SelectSP Gridview

                        string itemLines = dataLines;
                        if (itemLines != string.Empty)
                        {
                            switch (itemLines.Split('*')[0])
                            {
                                case "1":
                                    dtSelectSP.Rows.Clear();
                                    itemLines = itemLines.Remove(0, 2);
                                    string[] ItemArray = itemLines.Split('~');
                                    foreach (string item in ItemArray)
                                    {
                                        if (item != "")
                                        {
                                            string[] itemS = item.Split('|');
                                            if (GlobalVars.RMProcess == "PP")
                                            {
                                                if (itemS[1] == "" && itemS[5] == "")
                                                {
                                                    dtSelectSP.Rows.Add(item.Split('|'));
                                                }
                                            }
                                            else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                            {
                                                if (itemS[3] == "" && itemS[5] == "")
                                                {
                                                    dtSelectSP.Rows.Add(item.Split('|'));
                                                }
                                            }
                                            else if (GlobalVars.RMProcess == "A&W")
                                            {
                                                if (itemS[4] == "" && itemS[5] != "")
                                                {
                                                    dtSelectSP.Rows.Add(item.Split('|'));
                                                }
                                            }
                                        }
                                    }
                                    dgSelectSP.DataSource = dtSelectSP;
                                    dgSelectSP.MainView.GridControl.DataSource = dtSelectSP;
                                    dgSelectSP.MainView.GridControl.EndUpdate();
                                    gvSelectSP.RefreshData();


                                    if (GlobalVars.RMProcess == "PP")
                                    {
                                        gcEvoSlurryCodeSP.Visible = false;
                                        gcEvoSlurryCodeSP.VisibleIndex = -1;
                                        gcEvoSlurryDescSP.Visible = false;
                                        gcEvoSlurryDescSP.VisibleIndex = -1;

                                        gcEvoAWCatalystCode.Visible = false;
                                        gcEvoAWCatalystCode.VisibleIndex = -1;
                                        gcEvoAWCatalystDesc.Visible = false;
                                        gcEvoAWCatalystDesc.VisibleIndex = -1;

                                        gcEvoPowderCode.Visible = true;
                                        gcEvoPowderCode.VisibleIndex = 1;
                                        gcEvoPowderDesc.Visible = true;
                                        gcEvoPowderDesc.VisibleIndex = 2;

                                        lblHeader.Text = "Production Planning - Select A Powder Code";
                                        pnlOptions.Visible = true;
                                        pnlOptions.Enabled = false;
                                        dgSelectSP.Enabled = true;
                                    }
                                    else if (GlobalVars.RMProcess == "ZECT1" || GlobalVars.RMProcess == "ZECT2")
                                    {
                                        gcEvoPowderCode.Visible = false;
                                        gcEvoPowderCode.VisibleIndex = -1;
                                        gcEvoPowderDesc.Visible = false;
                                        gcEvoPowderDesc.VisibleIndex = -1;

                                        gcEvoAWCatalystCode.Visible = false;
                                        gcEvoAWCatalystCode.VisibleIndex = -1;
                                        gcEvoAWCatalystDesc.Visible = false;
                                        gcEvoAWCatalystDesc.VisibleIndex = -1;

                                        gcEvoSlurryCodeSP.Visible = true;
                                        gcEvoSlurryCodeSP.VisibleIndex = 1;
                                        gcEvoSlurryDescSP.Visible = true;
                                        gcEvoSlurryDescSP.VisibleIndex = 2;

                                        lblHeader.Text = "Production Planning - Select A Slurry Code";
                                        pnlOptions.Visible = true;
                                        pnlOptions.Enabled = true;
                                        dgSelectSP.Enabled = false;
                                    }
                                    else if (GlobalVars.RMProcess == "A&W")
                                    {
                                        gcEvoSlurryCodeSP.Visible = false;
                                        gcEvoSlurryCodeSP.VisibleIndex = -1;
                                        gcEvoSlurryDescSP.Visible = false;
                                        gcEvoSlurryDescSP.VisibleIndex = -1;

                                        gcEvoPowderCode.Visible = false;
                                        gcEvoPowderCode.VisibleIndex = -1;
                                        gcEvoPowderDesc.Visible = false;
                                        gcEvoPowderDesc.VisibleIndex = -1;

                                        gcEvoAWCatalystCode.Visible = true;
                                        gcEvoAWCatalystCode.VisibleIndex = 1;
                                        gcEvoAWCatalystDesc.Visible = true;
                                        gcEvoAWCatalystDesc.VisibleIndex = 2;

                                        lblHeader.Text = "Production Planning - Select A Catalyst Code";
                                        pnlOptions.Visible = true;
                                        pnlOptions.Enabled = false;
                                        dgSelectSP.Enabled = true;
                                    }

                                    dgSelectCS.SendToBack();
                                    dgSelectCS.Visible = false;

                                    pnlOptions.BringToFront();
                                    dgSelectSP.BringToFront();
                                    dgSelectSP.Visible = true;

                                    ppnlWait.SendToBack();
                                    dataPulled = false;
                                    break;
                                case "0":
                                    dtProcessLines.Rows.Clear();
                                    dgProcess.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.EndUpdate();
                                    gvProcess.RefreshData();

                                    ppnlWait.SendToBack();
                                    itemLines = itemLines.Remove(0, 2);
                                    msg = new frmMsg("Production Planning", "No Manufacturing Remaining For The Process...", GlobalVars.msgState.Success);
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
                                    msgStr = "Unexpected error while retreiving items";
                                    errInfo = "Unexpected error while retreiving items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                    else
                    {
                        #region Process Gridview

                        string itemLines = dataLines;
                        if (itemLines != string.Empty)
                        {
                            switch (itemLines.Split('*')[0])
                            {
                                case "1":
                                    dtProcessLines.Rows.Clear();
                                    itemLines = itemLines.Remove(0, 2);
                                    string[] ItemArray = itemLines.Split('~');
                                    foreach (string item in ItemArray)
                                    {
                                        if (item != "")
                                        {
                                            string[] itemS = item.Split('|');
                                            dtProcessLines.Rows.Add(item.Split('|'));
                                        }
                                    }
                                    dgProcess.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.EndUpdate();
                                    gvProcess.RefreshData();

                                    dgSelectSP.Visible = false;
                                    dgSelectCS.Visible = false;
                                    pnlOptions.Visible = false;

                                    dgProcess.Enabled = true;

                                    ppnlWait.SendToBack();
                                    dataPulled = false;
                                    break;
                                case "0":
                                    dtProcessLines.Rows.Clear();
                                    dgProcess.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                                    dgProcess.MainView.GridControl.EndUpdate();
                                    gvProcess.RefreshData();

                                    ppnlWait.SendToBack();
                                    itemLines = itemLines.Remove(0, 2);
                                    msg = new frmMsg("Production Planning", "No Data Stored For The Selected Process...", GlobalVars.msgState.Info);
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
                                    msgStr = "Unexpected error while retreiving items";
                                    errInfo = "Unexpected error while retreiving items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        public ucProductionPlanning()
        {
            InitializeComponent();
        }
        private void ucProductionPlanning_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelectcs = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSelectcs.Buttons[0].Width = 85;
            dgSelectCS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnSelectcs });
            btnSelectcs.Click += BtnSelectcs_Click;
            gcSelectedCS.ColumnEdit = btnSelectcs;
            gcSelectedCS.Width = 93;
            gcSelectedCS.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            btnSelectcs.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelectsp = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSelectsp.Buttons[0].Width = 85;
            dgSelectSP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnSelectsp });
            btnSelectsp.Click += BtnSelectsp_Click;
            gcSelectedSP.ColumnEdit = btnSelectsp;
            gcSelectedSP.Width = 93;
            gcSelectedSP.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            btnSelectsp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dgProcess.BringToFront();
            gbSearch.BringToFront();
            dgProcess.Visible = true;
            gbSearch.Visible = true;

            dgProcess.Enabled = false;

            dgSelectCS.Visible = false;
            dgSelectSP.Visible = false;
            pnlOptions.Visible = false;

            setupProcessDataTable();
            setupSelectCSDataTable();
            setupSelectSPDataTable();
            setProcesses();
            setToPowderPrep();
        }

        #region Search Options

        public void setProcesses()
        {
            try
            {
                cmbProcess.Properties.Items.Clear();

                cmbProcess.Properties.Items.Add("POWDER PREP");
                //cmbProcess.Properties.Items.Add("ZECT 1");
                //cmbProcess.Properties.Items.Add("ZECT 2");
                //cmbProcess.Properties.Items.Add("A&W");

                cmbProcess.Text = "POWDER PREP";
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void setToPowderPrep()
        {
            try
            {
                GlobalVars.RMProcess = "PP";
                gcCatalystCode.Visible = false;
                gcCatalystCode.VisibleIndex = -1;
                gcCoatNum.Visible = false;
                gcCoatNum.VisibleIndex = -1;
                gcAWCode.Visible = false;
                gcAWCode.VisibleIndex = -1;

                gcSlurryCode.Visible = true;
                gcSlurryCode.VisibleIndex = 0;

                gcPowderCode.Visible = true;
                gcPowderCode.VisibleIndex = 1;

                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
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
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;

                dtProcessLines.Rows.Clear();
                dgProcess.DataSource = dtProcessLines;
                dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                dgProcess.MainView.GridControl.EndUpdate();
                gvProcess.RefreshData();

                if (cmbProcess.Text == "POWDER PREP")
                {
                    GlobalVars.RMProcess = "PP";
                    gcCatalystCode.Visible = false;
                    gcCatalystCode.VisibleIndex = -1;
                    gcCoatNum.Visible = false;
                    gcCoatNum.VisibleIndex = -1;
                    gcAWCode.Visible = false;
                    gcAWCode.VisibleIndex = -1;

                    gcSlurryCode.Visible = true;
                    gcSlurryCode.VisibleIndex = 0;

                    gcPowderCode.Visible = true;
                    gcPowderCode.VisibleIndex = 1;          
                }
                else if (cmbProcess.Text == "ZECT 1")
                {
                    GlobalVars.RMProcess = "ZECT1";
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;
                    gcAWCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;

                    gcCatalystCode.Visible = true;
                    gcCatalystCode.VisibleIndex = 0;

                    gcSlurryCode.Visible = true;
                    gcSlurryCode.VisibleIndex = 1;

                    gcCoatNum.Visible = true;
                    gcCoatNum.VisibleIndex = 3;
                }
                else if (cmbProcess.Text == "ZECT 2")
                {
                    GlobalVars.RMProcess = "ZECT2";
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;
                    gcAWCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;

                    gcCatalystCode.Visible = true;
                    gcCatalystCode.VisibleIndex = 0;

                    gcSlurryCode.Visible = true;
                    gcSlurryCode.VisibleIndex = 1;

                    gcCoatNum.Visible = true;
                    gcCoatNum.VisibleIndex = 3;
                }
                else if (cmbProcess.Text == "A&W")
                {
                    GlobalVars.RMProcess = "A&W";
                    gcSlurryCode.Visible = false;
                    gcSlurryCode.VisibleIndex = -1;
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;
                    gcCoatNum.Visible = false;
                    gcCoatNum.VisibleIndex = -1;

                    gcAWCode.Visible = false;
                    gcAWCode.VisibleIndex = 0;

                    gcCatalystCode.Visible = true;
                    gcCatalystCode.VisibleIndex = 1;
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
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "ZECT1")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "ZECT2")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "A&W")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else
            {
                msg = new Forms.frmMsg("Production Planning", "Please select a valid process...", GlobalVars.msgState.Info);
                msg.ShowDialog();
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Adding = true;
            refreshSelectCSItems();
        }
        private void dgProcess_Click(object sender, EventArgs e)
        {
            try
            {
                EditID = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcID"));
                CSCataylst = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcCatalystCode"));
                CSSlurry = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcSlurryCode"));
                SPCoat = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcCoatNum"));
                CSAW = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcAWCode"));
                btnEdit.Enabled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editing = true;
            refreshSelectSPItems();
        }

        #region Select Catalyst/Slurry - SelectCS

        private void BtnSelectcs_Click(object sender, EventArgs e)
        {
            try
            {
                CSCataylst = Convert.ToString(gvSelectCS.GetRowCellValue(gvSelectCS.FocusedRowHandle, "gcEvoCatalystCode"));
                CSSlurry = Convert.ToString(gvSelectCS.GetRowCellValue(gvSelectCS.FocusedRowHandle, "gcEvoSlurryCode"));
                CSAW = Convert.ToString(gvSelectCS.GetRowCellValue(gvSelectCS.FocusedRowHandle, "gcEvoAWCode"));
                refreshSelectSPItems();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Select Slurry/Powder - SelectSP

        private void BtnSelectsp_Click(object sender, EventArgs e)
        {
            try
            {
                SPPowder = Convert.ToString(gvSelectSP.GetRowCellValue(gvSelectSP.FocusedRowHandle, "gcEvoPowderCode"));
                SPSlurry = Convert.ToString(gvSelectSP.GetRowCellValue(gvSelectSP.FocusedRowHandle, "gcEvoSlurryCodeSP"));
                SPCatalyst = Convert.ToString(gvSelectSP.GetRowCellValue(gvSelectSP.FocusedRowHandle, "gcEvoAWCatalystCode"));
                if (Adding == true)
                {
                    InsertRTIS();
                }
                else if (Editing == true)
                {
                    UpdateRTIS();
                }
                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        
        private void radFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (radFirst.Checked == true)
            {
                SPCoat = "1st";
                pnlOptions.Enabled = false;
                dgSelectSP.Enabled = true;
            }

        }

        private void radSecond_CheckedChanged(object sender, EventArgs e)
        {
            if (radSecond.Checked == true)
            {
                SPCoat = "2nd";
                pnlOptions.Enabled = false;
                dgSelectSP.Enabled = true;
            }
        }

        private void radThird_CheckedChanged(object sender, EventArgs e)
        {
            if (radThird.Checked == true)
            {
                SPCoat = "3rd";
                pnlOptions.Enabled = false;
                dgSelectSP.Enabled = true;
            }
        }

        private void radFourth_CheckedChanged(object sender, EventArgs e)
        {
            if (radFourth.Checked == true)
            {
                SPCoat = "4th";
                pnlOptions.Enabled = false;
                dgSelectSP.Enabled = true;
            }
        }

        public void InsertRTIS()
        {
            string InsertLine = string.Empty;
            switch (GlobalVars.RMProcess)
            {
                case "PP":
                    #region Powder Prep
                    InsertLine = CSSlurry + "|" + SPPowder + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                    string ServerInsert = Client.InsertPowderPlanning(InsertLine);
                    switch (ServerInsert.Split('*')[0])
                    {
                        case "1":
                            Adding = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                case "ZECT1":
                    #region Zect 1
                    InsertLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess;
                    string ServerInsertZ1 = Client.InsertZectPlanning(InsertLine);
                    switch (ServerInsertZ1.Split('*')[0])
                    {
                        case "1":
                            Adding = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                case "ZECT2":
                    #region Zect 2
                    InsertLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess;
                    string ServerInsertZ2 = Client.InsertZectPlanning(InsertLine);
                    switch (ServerInsertZ2.Split('*')[0])
                    {
                        case "1":
                            Adding = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                case "A&W":
                    #region A&W
                    InsertLine = CSAW + "|" + SPCatalyst + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                    string ServerInsertAW = Client.InsertAWPlanning(InsertLine);
                    switch (ServerInsertAW.Split('*')[0])
                    {
                        case "1":
                            Adding = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                    #endregion
                default:
                    break;
            }

            #region Old
            //if (GlobalVars.RMProcess != "PP")//Zect
            //{
            //    InsertLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess;
            //    string ServerInsert = Client.InsertZectPlanning(InsertLine);
            //    switch (ServerInsert.Split('*')[0])
            //    {
            //        case "1":
            //            Adding = false;

            //            lblHeader.Text = "Production Planning";

            //            radFirst.Checked = false;
            //            radSecond.Checked = false;
            //            radThird.Checked = false;
            //            radFourth.Checked = false;

            //            dgProcess.BringToFront();
            //            gbSearch.BringToFront();
            //            dgProcess.Visible = true;
            //            gbSearch.Visible = true;

            //            dgProcess.Enabled = false;

            //            dgSelectCS.Visible = false;
            //            dgSelectSP.Visible = false;
            //            pnlOptions.Visible = false;

            //            if (GlobalVars.RMProcess == "PP")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT1")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT2")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //else//Powder Prep
            //{
            //    InsertLine = CSSlurry + "|" + SPPowder + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
            //    string ServerInsert = Client.InsertPowderPlanning(InsertLine);
            //    switch (ServerInsert.Split('*')[0])
            //    {
            //        case "1":
            //            Adding = false;

            //            lblHeader.Text = "Production Planning";

            //            radFirst.Checked = false;
            //            radSecond.Checked = false;
            //            radThird.Checked = false;
            //            radFourth.Checked = false;

            //            dgProcess.BringToFront();
            //            gbSearch.BringToFront();
            //            dgProcess.Visible = true;
            //            gbSearch.Visible = true;

            //            dgProcess.Enabled = false;

            //            dgSelectCS.Visible = false;
            //            dgSelectSP.Visible = false;
            //            pnlOptions.Visible = false;

            //            if (GlobalVars.RMProcess == "PP")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT1")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT2")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            #endregion
        }

        public void UpdateRTIS()
        {
            string UpdateLine = string.Empty;
            switch (GlobalVars.RMProcess)
            {
                case "PP":
                    #region Powder Prep
                    UpdateLine = CSSlurry + "|" + SPPowder + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                    string ServerUpdate = Client.UpdatePowderPlanning(UpdateLine);
                    switch (ServerUpdate.Split('*')[0])
                    {
                        case "1":
                            Editing = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
                case "ZECT1":
                    #region Zect 1
                    UpdateLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess + "|" + EditID;
                    string ServerUpdateZ1 = Client.UpdateZectPlanning(UpdateLine);
                    switch (ServerUpdateZ1.Split('*')[0])
                    {
                        case "1":
                            Editing = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                case "ZECT2":
                    #region Zect 2
                    UpdateLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess + "|" + EditID;
                    string ServerUpdateZ2 = Client.UpdateZectPlanning(UpdateLine);
                    switch (ServerUpdateZ2.Split('*')[0])
                    {
                        case "1":
                            Editing = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                    #endregion
                    break;
                case "A&W":
                    #region A&W
                    UpdateLine = CSAW + "|" + SPCatalyst + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                    string ServerUpdateAW = Client.UpdateAWPlanning(UpdateLine);
                    switch (ServerUpdateAW.Split('*')[0])
                    {
                        case "1":
                            Editing = false;

                            lblHeader.Text = "Production Planning";

                            radFirst.Checked = false;
                            radSecond.Checked = false;
                            radThird.Checked = false;
                            radFourth.Checked = false;

                            dgProcess.BringToFront();
                            gbSearch.BringToFront();
                            dgProcess.Visible = true;
                            gbSearch.Visible = true;

                            dgProcess.Enabled = false;

                            dgSelectCS.Visible = false;
                            dgSelectSP.Visible = false;
                            pnlOptions.Visible = false;

                            if (GlobalVars.RMProcess == "PP")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT1")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "ZECT2")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            else if (GlobalVars.RMProcess == "A&W")
                            {
                                refreshProcessItems();
                                btnAdd.Visible = true;
                                btnEdit.Visible = true;
                                btnEdit.Enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
                default:
                    break;
            }

            #region Old
            //if (GlobalVars.RMProcess != "PP")//Zect
            //{
            //    UpdateLine = CSCataylst + "|" + SPSlurry + "|" + SPCoat + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + GlobalVars.RMProcess + "|" + EditID;
            //    string ServerUpdate = Client.UpdateZectPlanning(UpdateLine);
            //    switch (ServerUpdate.Split('*')[0])
            //    {
            //        case "1":
            //            Editing = false;

            //            lblHeader.Text = "Production Planning";

            //            radFirst.Checked = false;
            //            radSecond.Checked = false;
            //            radThird.Checked = false;
            //            radFourth.Checked = false;

            //            dgProcess.BringToFront();
            //            gbSearch.BringToFront();
            //            dgProcess.Visible = true;
            //            gbSearch.Visible = true;

            //            dgProcess.Enabled = false;

            //            dgSelectCS.Visible = false;
            //            dgSelectSP.Visible = false;
            //            pnlOptions.Visible = false;

            //            if (GlobalVars.RMProcess == "PP")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT1")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT2")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //else//Powder Prep
            //{
            //    UpdateLine = CSSlurry + "|" + SPPowder + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
            //    string ServerUpdate = Client.UpdatePowderPlanning(UpdateLine);
            //    switch (ServerUpdate.Split('*')[0])
            //    {
            //        case "1":
            //            Editing = false;

            //            lblHeader.Text = "Production Planning";

            //            radFirst.Checked = false;
            //            radSecond.Checked = false;
            //            radThird.Checked = false;
            //            radFourth.Checked = false;

            //            dgProcess.BringToFront();
            //            gbSearch.BringToFront();
            //            dgProcess.Visible = true;
            //            gbSearch.Visible = true;

            //            dgProcess.Enabled = false;

            //            dgSelectCS.Visible = false;
            //            dgSelectSP.Visible = false;
            //            pnlOptions.Visible = false;

            //            if (GlobalVars.RMProcess == "PP")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT1")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            else if (GlobalVars.RMProcess == "ZECT2")
            //            {
            //                refreshProcessItems();
            //                btnAdd.Visible = true;
            //                btnEdit.Visible = true;
            //                btnEdit.Enabled = false;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            #endregion
        }

        #endregion

    }
}

