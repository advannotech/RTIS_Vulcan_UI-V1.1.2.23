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
    public partial class ucPGMPlanning : UserControl
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
        DataTable dtSelectCSP = new DataTable();
        DataTable dtSelectPGM = new DataTable();

        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public bool Adding = false;
        string AddProcess = string.Empty;
        string CSPCataylst = string.Empty;
        string CSPSlurry = string.Empty;
        string CSPPowder = string.Empty;

        string PGMCode = string.Empty;

        public bool Editing = false;
        string EditID = string.Empty;

        #region Process Data Tables

        public void setupProcessDataTable()
        {
            try
            {
                dtProcessLines.Columns.Add("gcID", typeof(string));
                dtProcessLines.Columns.Add("gcCatalystCode", typeof(string));
                dtProcessLines.Columns.Add("gcSlurryCode", typeof(string));
                dtProcessLines.Columns.Add("gcPowderCode", typeof(string));
                dtProcessLines.Columns.Add("gcPGMCode", typeof(string));
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
                if (GlobalVars.RMProcess == "VW")
                {
                    dataLines = Client.GetVWPGMPlanningLines();
                }
                else if (GlobalVars.RMProcess == "TOYOTAFS")
                {
                    dataLines = Client.GetTOYOTAFSPlanningLines();
                }
                else if (GlobalVars.RMProcess == "TOYOTAPP")
                {
                    dataLines = Client.GetTOYOTAPPPlanningLines();
                }
                else if (GlobalVars.RMProcess == "TOYOTAAW")
                {
                    dataLines = Client.GetTOYOTAAWPlanningLines();
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

        #region Select Catalyst/Slurry/Powder Data Tables - SELECTCSP

        public void setupSelectCSPDataTable()
        {
            try
            {
                dtSelectCSP.Columns.Add("gcEvoID", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoCatalystCode", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoCatalystDesc", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoSlurryCode", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoSlurryDesc", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoPowderCodeCSP", typeof(string));
                dtSelectCSP.Columns.Add("gcEvoPowderDescCSP", typeof(string));
                dtSelectCSP.Columns.Add("gcSelected", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshSelectCSPItems()
        {
            try
            {
                AddProcess = "CSP";
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getSelectCSPLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getSelectCSPLines()
        {
            try
            {
                dataLines = Client.GetSelectCSPPGMPlanningLines();
                dataPulled = true;
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Select PGM Code Data Tables - SELECTPGM

        public void setupSelectPGMDataTable()
        {
            try
            {
                dtSelectPGM.Columns.Add("gcEvoIDPGM", typeof(string));
                dtSelectPGM.Columns.Add("gcEvoPGMCode", typeof(string));
                dtSelectPGM.Columns.Add("gcEvoPGMDesc", typeof(string));
                dtSelectPGM.Columns.Add("gcSelectedPGM", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshSelectPGMItems()
        {
            try
            {
                AddProcess = "PGM";
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(getSelectPGMLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getSelectPGMLines()
        {
            try
            {
                dataLines = Client.GetSelectPGMPlanningLines();
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
                        if (AddProcess == "CSP")
                        {
                            #region SelectCSP Gridview

                            string itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtSelectCSP.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                if (GlobalVars.RMProcess == "VW")
                                                {
                                                    if (itemS[1] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectCSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "TOYOTAFS")
                                                {
                                                    if (itemS[1] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectCSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "TOYOTAPP")
                                                {
                                                    if (itemS[1] == "" && itemS[3] == "")
                                                    {
                                                        dtSelectCSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                                else if (GlobalVars.RMProcess == "TOYOTAAW")
                                                {
                                                    if (itemS[3] == "" && itemS[5] == "")
                                                    {
                                                        dtSelectCSP.Rows.Add(item.Split('|'));
                                                    }
                                                }
                                            }
                                        }
                                        dgSelectCSP.DataSource = dtSelectCSP;
                                        dgSelectCSP.MainView.GridControl.DataSource = dtSelectCSP;
                                        dgSelectCSP.MainView.GridControl.EndUpdate();
                                        gvSelectCSP.RefreshData();


                                        if (GlobalVars.RMProcess == "VW")
                                        {
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = -1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = -1;

                                            gcEvoPowderCodeCSP.Visible = true;
                                            gcEvoPowderCodeCSP.VisibleIndex = -1;
                                            gcEvoPowderDescCSP.Visible = true;
                                            gcEvoPowderDescCSP.VisibleIndex = -1;

                                            gcEvoSlurryCode.Visible = true;
                                            gcEvoSlurryCode.VisibleIndex = 1;
                                            gcEvoSlurryDesc.Visible = true;
                                            gcEvoSlurryDesc.VisibleIndex = 2;

                                            lblHeader.Text = "PGM Planning - Select A Slurry Code";

                                        }
                                        else if (GlobalVars.RMProcess == "TOYOTAFS")
                                        {
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = -1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = -1;

                                            gcEvoPowderCodeCSP.Visible = true;
                                            gcEvoPowderCodeCSP.VisibleIndex = -1;
                                            gcEvoPowderDescCSP.Visible = true;
                                            gcEvoPowderDescCSP.VisibleIndex = -1;

                                            gcEvoSlurryCode.Visible = true;
                                            gcEvoSlurryCode.VisibleIndex = 1;
                                            gcEvoSlurryDesc.Visible = true;
                                            gcEvoSlurryDesc.VisibleIndex = 2;

                                            lblHeader.Text = "PGM Planning - Select A Slurry Code";

                                        }
                                        else if (GlobalVars.RMProcess == "TOYOTAPP")
                                        {
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = -1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = -1;

                                            gcEvoPowderCodeCSP.Visible = true;
                                            gcEvoPowderCodeCSP.VisibleIndex = 1;
                                            gcEvoPowderDescCSP.Visible = true;
                                            gcEvoPowderDescCSP.VisibleIndex = 2;

                                            gcEvoSlurryCode.Visible = true;
                                            gcEvoSlurryCode.VisibleIndex = -1;
                                            gcEvoSlurryDesc.Visible = true;
                                            gcEvoSlurryDesc.VisibleIndex = -1;

                                            lblHeader.Text = "PGM Planning - Select A Powder Code";

                                        }
                                        else if (GlobalVars.RMProcess == "TOYOTAAW")
                                        {
                                            gcEvoCatalystCode.Visible = false;
                                            gcEvoCatalystCode.VisibleIndex = 1;
                                            gcEvoCatalystDesc.Visible = false;
                                            gcEvoCatalystDesc.VisibleIndex = 2;

                                            gcEvoPowderCodeCSP.Visible = true;
                                            gcEvoPowderCodeCSP.VisibleIndex = -1;
                                            gcEvoPowderDescCSP.Visible = true;
                                            gcEvoPowderDescCSP.VisibleIndex = -1;

                                            gcEvoSlurryCode.Visible = true;
                                            gcEvoSlurryCode.VisibleIndex = -1;
                                            gcEvoSlurryDesc.Visible = true;
                                            gcEvoSlurryDesc.VisibleIndex = -1;

                                            lblHeader.Text = "PGM Planning - Select A Catalyst Code";

                                        }

                                        dgProcess.SendToBack();
                                        gbSearch.SendToBack();
                                        dgProcess.Visible = false;
                                        gbSearch.Visible = false;
                                        dgSelectPGM.Visible = false;

                                        dgSelectCSP.BringToFront();
                                        dgSelectCSP.Visible = true;

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
                            #region SelectPGM Gridview

                            string itemLines = dataLines;
                            if (itemLines != string.Empty)
                            {
                                switch (itemLines.Split('*')[0])
                                {
                                    case "1":
                                        dtSelectPGM.Rows.Clear();
                                        itemLines = itemLines.Remove(0, 2);
                                        string[] ItemArray = itemLines.Split('~');
                                        foreach (string item in ItemArray)
                                        {
                                            if (item != "")
                                            {
                                                string[] itemS = item.Split('|');
                                                dtSelectPGM.Rows.Add(item.Split('|'));
                                            }
                                        }
                                        dgSelectPGM.DataSource = dtSelectPGM;
                                        dgSelectPGM.MainView.GridControl.DataSource = dtSelectPGM;
                                        dgSelectPGM.MainView.GridControl.EndUpdate();
                                        gvSelectPGM.RefreshData();


                                        lblHeader.Text = "PGM Planning - Select A PGM Code";
                                        dgSelectPGM.Enabled = true;

                                        dgSelectCSP.SendToBack();
                                        dgSelectCSP.Visible = false;
                                        
                                        dgSelectPGM.BringToFront();
                                        dgSelectPGM.Visible = true;
                                        
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
                                        msg = new frmMsg("PPGM Planning", "No PGM Codes in Evolution...", GlobalVars.msgState.Success);
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
                        #region SelectPGM Gridview

                        string itemLines = dataLines;
                        if (itemLines != string.Empty)
                        {
                            switch (itemLines.Split('*')[0])
                            {
                                case "1":
                                    dtSelectPGM.Rows.Clear();
                                    itemLines = itemLines.Remove(0, 2);
                                    string[] ItemArray = itemLines.Split('~');
                                    foreach (string item in ItemArray)
                                    {
                                        if (item != "")
                                        {
                                            string[] itemS = item.Split('|');
                                            dtSelectPGM.Rows.Add(item.Split('|'));
                                        }
                                    }
                                    dgSelectPGM.DataSource = dtSelectPGM;
                                    dgSelectPGM.MainView.GridControl.DataSource = dtSelectPGM;
                                    dgSelectPGM.MainView.GridControl.EndUpdate();
                                    gvSelectPGM.RefreshData();


                                    lblHeader.Text = "PGM Planning - Select A PGM Code";
                                    dgSelectPGM.Enabled = true;

                                    dgSelectCSP.SendToBack();
                                    dgSelectCSP.Visible = false;

                                    dgSelectPGM.BringToFront();
                                    dgSelectPGM.Visible = true;

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
                                    msg = new frmMsg("PPGM Planning", "No PGM Codes in Evolution...", GlobalVars.msgState.Success);
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

                                    dgSelectPGM.Visible = false;
                                    dgSelectCSP.Visible = false;

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
                                    msg = new frmMsg("PGM Planning", "No Data Stored For The Selected Process...", GlobalVars.msgState.Info);
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

        public ucPGMPlanning()
        {
            InitializeComponent();
        }
        private void ucPGMPlanning_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelectcs = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSelectcs.Buttons[0].Width = 85;
            dgSelectCSP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnSelectcs });
            btnSelectcs.Click += BtnSelectcs_Click;
            gcSelectedCS.ColumnEdit = btnSelectcs;
            gcSelectedCS.Width = 93;
            gcSelectedCS.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            btnSelectcs.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSelectsp = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnSelectsp.Buttons[0].Width = 85;
            dgSelectPGM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnSelectsp });
            btnSelectsp.Click += BtnSelectsp_Click;
            gcSelectedPGM.ColumnEdit = btnSelectsp;
            gcSelectedPGM.Width = 93;
            gcSelectedPGM.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            btnSelectsp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dgProcess.BringToFront();
            gbSearch.BringToFront();
            dgProcess.Visible = true;
            gbSearch.Visible = true;

            dgProcess.Enabled = false;

            dgSelectCSP.Visible = false;
            dgSelectPGM.Visible = false;

            setupProcessDataTable();
            setupSelectCSPDataTable();
            setupSelectPGMDataTable();
            setProcesses();
        }

        #region Search Options

        public void setProcesses()
        {
            try
            {
                cmbProcess.Properties.Items.Clear();

                cmbProcess.Properties.Items.Add("VW PGM");
                cmbProcess.Properties.Items.Add("TOYOTA PGM - FRESH SLURRY");
                cmbProcess.Properties.Items.Add("TOYOTA PGM - POWDER PREP");
                cmbProcess.Properties.Items.Add("TOYOTA PGM - A&W");

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
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;

                dtProcessLines.Rows.Clear();
                dgProcess.DataSource = dtProcessLines;
                dgProcess.MainView.GridControl.DataSource = dtProcessLines;
                dgProcess.MainView.GridControl.EndUpdate();
                gvProcess.RefreshData();

                if (cmbProcess.Text == "VW PGM")
                {
                    GlobalVars.RMProcess = "VW";
                    gcCatalystCode.Visible = false;
                    gcCatalystCode.VisibleIndex = -1;
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;

                    gcSlurryCode.Visible = true;
                    gcSlurryCode.VisibleIndex = 0;
                }
                else if (cmbProcess.Text == "TOYOTA PGM - FRESH SLURRY")
                {
                    GlobalVars.RMProcess = "TOYOTAFS";
                    gcCatalystCode.Visible = false;
                    gcCatalystCode.VisibleIndex = -1;
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;

                    gcSlurryCode.Visible = true;
                    gcSlurryCode.VisibleIndex = 0;
                }
                else if (cmbProcess.Text == "TOYOTA PGM - POWDER PREP")
                {
                    GlobalVars.RMProcess = "TOYOTAPP";
                    gcCatalystCode.Visible = false;
                    gcCatalystCode.VisibleIndex = -1;
                    gcSlurryCode.Visible = false;
                    gcSlurryCode.VisibleIndex = -1;

                    gcPowderCode.Visible = true;
                    gcPowderCode.VisibleIndex = 0;
                }
                else if (cmbProcess.Text == "TOYOTA PGM - A&W")
                {
                    GlobalVars.RMProcess = "TOYOTAAW";
                    gcSlurryCode.Visible = false;
                    gcSlurryCode.VisibleIndex = -1;
                    gcPowderCode.Visible = false;
                    gcPowderCode.VisibleIndex = -1;

                    gcCatalystCode.Visible = true;
                    gcCatalystCode.VisibleIndex = 0;
                }
                else
                {
                    GlobalVars.RMProcess = "";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RMProcess == "VW")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "TOYOTAFS")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "TOYOTAPP")
            {
                refreshProcessItems();
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
            }
            else if (GlobalVars.RMProcess == "TOYOTAAW")
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
            refreshSelectCSPItems();
        }
        private void dgProcess_Click(object sender, EventArgs e)
        {
            try
            {
                EditID = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcID"));
                CSPCataylst = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcCatalystCode"));
                CSPSlurry = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcSlurryCode"));
                CSPPowder = Convert.ToString(gvProcess.GetRowCellValue(gvProcess.FocusedRowHandle, "gcPowderCode"));
                
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
            refreshSelectPGMItems();
        }

        #region Select Catalyst/Slurry/Powder - SelectCSP

        private void BtnSelectcs_Click(object sender, EventArgs e)
        {
            try
            {
                CSPCataylst = Convert.ToString(gvSelectCSP.GetRowCellValue(gvSelectCSP.FocusedRowHandle, "gcEvoCatalystCode"));
                CSPSlurry = Convert.ToString(gvSelectCSP.GetRowCellValue(gvSelectCSP.FocusedRowHandle, "gcEvoSlurryCode"));
                CSPPowder = Convert.ToString(gvSelectCSP.GetRowCellValue(gvSelectCSP.FocusedRowHandle, "gcEvoPowderCodeCSP"));
                refreshSelectPGMItems();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Select PGM Code - SelectPGM

        private void BtnSelectsp_Click(object sender, EventArgs e)
        {
            try
            {
                PGMCode = Convert.ToString(gvSelectPGM.GetRowCellValue(gvSelectPGM.FocusedRowHandle, "gcEvoPGMCode"));
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

        public void InsertRTIS()
        {
            string InsertLine = string.Empty;
            if (GlobalVars.RMProcess == "VW")
            {
                InsertLine = CSPSlurry + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                string ServerInsert = Client.InsertVWPlanning(InsertLine);
                switch (ServerInsert.Split('*')[0])
                {
                    case "1":
                        Adding = false;

                        lblHeader.Text = "PGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAFS")
            {
                InsertLine = CSPSlurry + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                string ServerInsert = Client.InsertTFSPlanning(InsertLine);
                switch (ServerInsert.Split('*')[0])
                {
                    case "1":
                        Adding = false;

                        lblHeader.Text = "PGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAPP")
            {
                InsertLine = CSPPowder + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                string ServerInsert = Client.InsertTPPPlanning(InsertLine);
                switch (ServerInsert.Split('*')[0])
                {
                    case "1":
                        Adding = false;

                        lblHeader.Text = "PGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAAW")
            {
                InsertLine = CSPCataylst + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName;
                string ServerInsert = Client.InsertTAWPlanning(InsertLine);
                switch (ServerInsert.Split('*')[0])
                {
                    case "1":
                        Adding = false;

                        lblHeader.Text = "PGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }

        }

        public void UpdateRTIS()
        {
            string UpdateLine = string.Empty;
            if (GlobalVars.RMProcess == "VW")
            {
                UpdateLine = CSPSlurry + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                string ServerUpdate = Client.UpdateVWPlanning(UpdateLine);
                switch (ServerUpdate.Split('*')[0])
                {
                    case "1":
                        Editing = false;

                        lblHeader.Text = "PPGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAFS")
            {
                UpdateLine = CSPSlurry + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                string ServerUpdate = Client.UpdateTFSPlanning(UpdateLine);
                switch (ServerUpdate.Split('*')[0])
                {
                    case "1":
                        Editing = false;

                        lblHeader.Text = "PPGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAPP")
            {
                UpdateLine = CSPPowder + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                string ServerUpdate = Client.UpdateTPPPlanning(UpdateLine);
                switch (ServerUpdate.Split('*')[0])
                {
                    case "1":
                        Editing = false;

                        lblHeader.Text = "PPGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }
            else if (GlobalVars.RMProcess == "TOYOTAAW")
            {
                UpdateLine = CSPCataylst + "|" + PGMCode + "|" + Convert.ToString(DateTime.Now) + "|" + GlobalVars.userName + "|" + EditID;
                string ServerUpdate = Client.UpdateTAWPlanning(UpdateLine);
                switch (ServerUpdate.Split('*')[0])
                {
                    case "1":
                        Editing = false;

                        lblHeader.Text = "PPGM Planning";

                        dgProcess.BringToFront();
                        gbSearch.BringToFront();
                        dgProcess.Visible = true;
                        gbSearch.Visible = true;

                        dgProcess.Enabled = false;

                        dgSelectCSP.Visible = false;
                        dgSelectPGM.Visible = false;

                        refreshProcessItems();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnEdit.Enabled = false;

                        break;
                    default:
                        break;
                }
            }

        }

        #endregion
        
    }
}

