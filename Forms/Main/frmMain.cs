using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Controls;
using RTIS_Vulcan_UI.Controls.Administration;
using RTIS_Vulcan_UI.Controls.Administration.Transfer_Management;
using RTIS_Vulcan_UI.Controls.Manufacturing;
using RTIS_Vulcan_UI.Controls.Manufacturing.Canning;
using RTIS_Vulcan_UI.Controls.Manufacturing.PGM;
using RTIS_Vulcan_UI.Controls.Stock_Management.Stock_Takes;
using RTIS_Vulcan_UI.Controls.Transfer_Management;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Controls.Manufacturing.Mixed_Slurry;
using RTIS_Vulcan_UI.Controls.Palletizing;
using RTIS_Vulcan_UI.Controls.Purchase_Orders;
using RTIS_Vulcan_UI.Controls.Purchase_Orders.COA;
using static RTIS_Vulcan_UI.Classes.GlobalVars;
using RTIS_Vulcan_UI.Controls.Purchase_Orders.PO_Rec;

namespace RTIS_Vulcan_UI
{
    public partial class frmMain : Form
    {
        string userName = string.Empty;
        string _modules = string.Empty;
        frmLogin login = new frmLogin();
        public TreeNode trAdmin = new TreeNode("Administration");
        public bool logOff = false;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public void resizeObjects()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (dpMenu.Visibility == DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
                {
                    xtcMain.Size = new Size(this.Width - 58, this.Height - 107);
                    //1206, 660
                    //this.Width - 48, this.Height - 54);
                    xtcMain.Location = new Point(40, 30);
                    foreach (XtraTabPage xPage in xtcMain.TabPages)
                    {
                        xPage.Height = 690;
                        xPage.Width = 1335;
                        foreach (Control cntrl in xPage.Controls)
                        {
                            if (cntrl.Name.Contains("uc"))
                            {
                                cntrl.Width = xPage.Width - 10;
                                cntrl.Height = xPage.Height - 20;
                                Position.CenterHorizontally(cntrl);
                                Position.CenterVertically(cntrl);
                            }
                        }
                    }
                }
                else
                {
                    xtcMain.Size = new Size(this.Width - 221, this.Height - 107);
                    xtcMain.Location = new Point(206, 30);
                    foreach (XtraTabPage xPage in xtcMain.TabPages)
                    {
                        xPage.Height = 690;
                        xPage.Width = 1160;
                        foreach (Control cntrl in xPage.Controls)
                        {
                            if (cntrl.Name.Contains("uc"))
                            {
                                cntrl.Width = xPage.Width - 10;
                                cntrl.Height = xPage.Height - 20;
                                Position.CenterHorizontally(cntrl);
                                Position.CenterVertically(cntrl);
                            }
                        }
                    }
                }
            }
            else
            {
                if (dpMenu.Visibility == DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
                {
                    //xtcMain.Size = new Size(this.Width - 48, this.Height - 54);
                    xtcMain.Size = new Size(this.Width - 48, this.Height - 107);
                    xtcMain.Location = new Point(30, 30);
                    foreach (XtraTabPage xPage in xtcMain.TabPages)
                    {
                        xPage.Height = this.Height - 54;//606;
                        xPage.Width = this.Width - 48;//1160;
                        foreach (Control cntrl in xPage.Controls)
                        {
                            if (cntrl.Name.Contains("uc"))
                            {
                                cntrl.Width = xPage.Width - 10;
                                cntrl.Height = xPage.Height - 20;
                                Position.CenterHorizontally(cntrl);
                                Position.CenterVertically(cntrl); ;
                                Position.CenterVertically(cntrl);
                            }
                        }
                    }
                }
                else
                {
                    //xtcMain.Size = new Size(this.Width - 221, this.Height - 54);
                    xtcMain.Size = new Size(this.Width - 221, this.Height - 107);
                    xtcMain.Location = new Point(206, 30);
                    foreach (XtraTabPage xPage in xtcMain.TabPages)
                    {
                        xPage.Height = 690;
                        xPage.Width = 1160;
                        foreach (Control cntrl in xPage.Controls)
                        {
                            if (cntrl.Name.Contains("uc"))
                            {
                                cntrl.Width = xPage.Width - 10;
                                cntrl.Height = xPage.Height - 20;
                                Position.CenterHorizontally(cntrl);
                                Position.CenterVertically(cntrl);
                            }
                        }
                    }
                }
            }
        }
        public void setUpServiceUser()
        {
            TreeNode trChild = new TreeNode("Connections");
            trAdmin.Nodes.Add(trChild);
            tvMain.Nodes.Add(trAdmin);
            //bbtnLogOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public string getModules()
        {
            try
            {
                string modules = Client.GetActiveModules();
                if (modules != string.Empty)
                {
                    switch (modules.Split('*')[0])
                    {
                        case "1":
                            tvMain.Nodes.Clear();
                            modules = modules.Remove(0, 2);
                            _modules = modules;
                            string[] allModules = modules.Split('~');
                            foreach (string module in allModules)
                            {
                                if (module != string.Empty)
                                {
                                    if (module.Split('|')[1] == "Label Designing")
                                    {
                                        //Setup Label Printing Modules
                                    }
                                    else
                                    {
                                        TreeNode trMain = new TreeNode(module.Split('|')[1]);
                                        tvMain.Nodes.Add(trMain);
                                    }
                                }
                            }
                            return "1";
                        case "0":
                            modules = modules.Remove(0, 2);
                            msg = new frmMsg("The following issue was encountered:", modules, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            return "-1";
                        case "-1":
                            modules = modules.Remove(0, 3);
                            errMsg = modules.Split('|')[0];
                            errInfo = modules.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            return "-1";
                        case "-2":
                            msg = new frmMsg("A connection level error has occured", modules, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            return "-1";
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving modules";
                            errInfo = "Unexpected error while retreiving modules";
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            return "-1";
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                return "-1";
            }
        }
        public void getPermissions()
        {
            try
            {
                string[] allModules = _modules.Split('~');
                foreach (string module in allModules)
                {
                    if (module != string.Empty)
                    {
                        string moduleID = module.Split('|')[0];
                        string moduleName = module.Split('|')[1];
                        string activeModulePermissions = Client.GetActiveModuleUserPerms(userName + "|" + moduleID);
                        switch (activeModulePermissions.Split('*')[0])
                        {
                            case "1":
                                activeModulePermissions = activeModulePermissions.Remove(0, 2);
                                string[] allPermissions = activeModulePermissions.Split('~');
                                foreach (string permission in allPermissions)
                                {
                                    if (permission != string.Empty && permission.Contains("ZECT Supervisor") == false)
                                    {
                                        string permName = permission.Split('|')[0];
                                        string permNest = permission.Split('|')[1];
                                        foreach (TreeNode tn in tvMain.Nodes)
                                        {
                                            if (tn.Text == moduleName)
                                            {
                                                if (permNest == string.Empty)
                                                {
                                                    tn.Nodes.Add(permName);
                                                    GlobalVars.userPerms.Add(permName);
                                                }
                                                else
                                                {
                                                    bool found = false;
                                                    foreach (TreeNode tnNest in tn.Nodes)
                                                    {
                                                        if (tnNest.Text == permNest)
                                                        {
                                                            tnNest.Nodes.Add(permName);
                                                            GlobalVars.userPerms.Add(permName);
                                                            found = true;
                                                        }
                                                    }

                                                    if (found == false)
                                                    {
                                                        TreeNode tnNewNest = new TreeNode(permNest);
                                                        tnNewNest.Nodes.Add(permName);
                                                        tn.Nodes.Add(tnNewNest);
                                                        GlobalVars.userPerms.Add(permName);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case "0":
                                activeModulePermissions = activeModulePermissions.Remove(0, 2);
                                msg = new frmMsg("The following issue was encountered:", activeModulePermissions, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                activeModulePermissions = activeModulePermissions.Remove(0, 3);
                                errMsg = activeModulePermissions.Split('|')[0];
                                errInfo = activeModulePermissions.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                activeModulePermissions = activeModulePermissions.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", activeModulePermissions, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected checking module permissions";
                                infoStr = "Unexpected checking module permissions for module :" + Environment.NewLine + module + Environment.NewLine + "Data returned: " + Environment.NewLine + activeModulePermissions;
                                ExHandler.showErrorST(st, msgStr, infoStr);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void treeviewCleanUp()
        {
            TreeNode tnST = new TreeNode(); ;
            List<TreeNode> remList = new List<TreeNode>();
            List<TreeNode> remST = new List<TreeNode>();

            foreach (TreeNode tn in tvMain.Nodes)
            {
                if (tn != null)
                {
                    if (tn.Text == "Stock Takes")
                    {
                        tnST = tn;
                        foreach (TreeNode tn2 in tn.Nodes)
                        {
                            if (tn2 != null)
                            {
                                if (tn2.Nodes.Count == 0)
                                {
                                    remST.Add(tn2);
                                }
                            }
                        }
                    }

                    if (tn.Text == "Label Printing")
                    {
                        tvMain.Nodes.Remove(tn);
                    }
                }
            }

            foreach (TreeNode item in remST)
            {
                if (item != null)
                {
                    tnST.Nodes.Remove(item);
                }
            }

            foreach (TreeNode tn in tvMain.Nodes)
            {
                if (tn.Nodes.Count == 0)
                {
                    remList.Add(tn);
                }
            }

            foreach (TreeNode item in remList)
            {
                if (item != null)
                {
                    tvMain.Nodes.Remove(item);
                }
            }

            foreach (TreeNode tn in trAdmin.Nodes)
            {
                if (tn != null)
                {
                    if (tn.Text == "User Tracking" && tn.Nodes.Count == 0)
                    {
                        tvMain.Nodes.Remove(tn);
                    }
                }
            }
        }
        public void setUpLabelPrinting()
        {
            try
            {
                foreach (string permName in GlobalVars.userPerms)
                {
                    if (permName == "New Label")
                    {
                        bbtnNewLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (permName == "Edit Label")
                    {
                        bbtnExistingLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }

                if (bbtnNewLabel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never && bbtnExistingLabel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    bbtnLabels.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setupLabelTypes()
        {
            try
            {
                string activeLabels = Client.GetActiveLabelTypes(userName);
                if (activeLabels != string.Empty)
                {
                    switch (activeLabels.Split('*')[0])
                    {
                        case "1":
                            activeLabels = activeLabels.Remove(0, 2);
                            string[] allLabelTypes = activeLabels.Split('~');
                            foreach (string label in allLabelTypes)
                            {
                                switch (label)
                                {
                                    case "Stock":
                                        bbtnStkLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "Zect":
                                        bbtnZectLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "ZECT Config Tag":
                                        btnZectConfigTag.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "A&W":
                                        bbtnAWLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "A&W Config Tag":
                                        btnAWConfig.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "Canning":
                                        bbtnCanningLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "FG Box":
                                        bbtnFGBox.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    case "FG Pallet":
                                        bbtnFGPallet.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case "0":
                            activeLabels = activeLabels.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", activeLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            activeLabels = activeLabels.Remove(0, 3);
                            errMsg = activeLabels.Split('|')[0];
                            errInfo = activeLabels.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            activeLabels = activeLabels.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", activeLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while created the user";
                            errInfo = "Unexpected error while created the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + activeLabels;
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
        public void setUpUser()
        {
            try
            {
                string modulesLoaded = getModules();
                if (modulesLoaded == "1")
                {
                    getPermissions();
                    treeviewCleanUp();
                }
                else
                {
                    tvMain.Nodes.Clear();
                    setUpServiceUser();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setupLogin()
        {
            try
            {
                switch (userName)
                {
                    case "Service User":
                        tvMain.Nodes.Clear();
                        setUpServiceUser();
                        break;
                    case "Reltech":
                        tvMain.Nodes.Clear();
                        setUpServiceUser();
                        break;
                    default:
                        tvMain.Nodes.Clear();
                        setUpUser();
                        setUpLabelPrinting();
                        setupLabelTypes();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public frmMain(string _userName, frmLogin _login)
        {
            InitializeComponent();
            userName = _userName;
            login = _login;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            setupLogin();

        }
        public void showErrorEx(Exception exc)
        {
            try
            {
                string msg = exc.Message;
                string info = string.Empty;
                StackTrace st = new StackTrace(exc, true);
                StackFrame frame = st.GetFrame(0);
                string line = frame.GetFileLineNumber().ToString();
                string name = frame.GetFileName().ToString();
                string meth = frame.GetMethod().ToString();
                info = exc.ToString() + Environment.NewLine + Environment.NewLine + "Method:" + Environment.NewLine + meth + Environment.NewLine + Environment.NewLine + "File: " + Environment.NewLine + name + Environment.NewLine + Environment.NewLine + "Line Number: " + Environment.NewLine + line;
                frmError err = new frmError(msg, info);
                err.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RTIS Vulcan Error log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logOff == false)
            {
                Application.Exit();
            }
        }
        private void dpMenu_DockChanged(object sender, EventArgs e)
        {
            resizeObjects();
        }
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            resizeObjects();
        }
        private void tvMain_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            XtraTabPage xp = new XtraTabPage();
            bool found = false;
            switch (e.Node.Text)
            {
                case "PO Reprinting":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "PO Reprinting")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "PO Reprinting";
                        ucPOReprinting ucCntrl = new ucPOReprinting();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }

                    break;

                case "Receiving Admin":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Receiving Admin")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Receiving Admin";
                        ucPOAdmin ucCntrl = new ucPOAdmin();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;

                case "PO Printing":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "PO Printing")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "PO Printing";
                        ucPOPrinting ucCntrl = new ucPOPrinting();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;

<<<<<<< HEAD
               
=======

>>>>>>> 4109af29ce94747bc728d1dd0641d55d3120f098

                case "CMS Admin":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "CMS Admin")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "CMS Admin";
                        ucCMSAdmin ucCntrl = new ucCMSAdmin();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "CMS Management":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "CMS Management")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "CMS Management";
                        ucCMSManagement ucCntrl = new ucCMSManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "CMS Approvals":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "CMS Approvals")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "CMS Approvals";
                        ucCMSApproval ucCntrl = new ucCMSApproval();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "CMS Archive":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "CMS Archive")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "CMS Archive";
                        ucCMSArchive ucCntrl = new ucCMSArchive();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        //resizeObjects();
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "RM Manufacture":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "RM Manufacture")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "RM Manufacture";
                        ucPrepManufacture ucCntrl = new ucPrepManufacture();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Production Planning":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Production Planning")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Production Planning";
                        ucProductionPlanning ucCntrl = new ucProductionPlanning();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "PGM Planning":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "PGM Planning")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "PGM Planning";
                        ucPGMPlanning ucCntrl = new ucPGMPlanning();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "FG Manufacture":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "FG Manufacture")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "FG Manufacture";
                        ucFGManufacture ucCntrl = new ucFGManufacture();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "PGM Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "PGM Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "PGM Records";
                        ucPGMJobs ucCntrl = new ucPGMJobs();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Powder Prep Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Powder Prep Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Powder Prep Records";
                        ucPowderPrepRecords ucCntrl = new ucPowderPrepRecords();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Fresh Slurry Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Fresh Slurry Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Fresh Slurry Records";
                        ucFreshSlurryRecords ucCntrl = new ucFreshSlurryRecords();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Auto Manufacture":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Auto Manufacture")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Auto Manufacture";
                        ucPGMManufacture ucCntrl = new ucPGMManufacture();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "ZECT RMs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "ZECT RMs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "ZECT RMs";
                        ucZectRawMaterials ucCntrl = new ucZectRawMaterials();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Fresh Slurry RMs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Fresh Slurry RMs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Fresh Slurry RMs";
                        ucFreshSlurry ucCntrl = new ucFreshSlurry();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Mixed Slurry Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Mixed Slurry Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Mixed Slurry Records";
                        ucMixedSlurry ucCntrl = new ucMixedSlurry();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Mixed Slurry Chemicals":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Mixed Slurry Chemicals")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Mixed Slurry Chemicals";
                        ucMixedChems ucCntrl = new ucMixedChems();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Role Management":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Role Management")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Role Management";
                        ucRoleManagement ucCntrl = new ucRoleManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "User Management":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "User Management")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "User Management";
                        ucUserManagement ucCntrl = new ucUserManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Warehouse Transfers":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Warehouse Transfers")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Warehouse Transfers";
                        ucTransferManagement ucCntrl = new ucTransferManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "FG Warehouse Transfers":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "FG Warehouse Transfers")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "FG Warehouse Transfers";
                        ucTransferRequests ucCntrl = new ucTransferRequests();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "FG Transfer Reports":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "FG Transfer Reports")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "FG Transfer Reports";
                        ucTransferReports ucCntrl = new ucTransferReports();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Connections":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Connections")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Connections";
                        ucSettings ucCntrl = new ucSettings();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Module Configuration":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Module Configuration")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Module Configuration";
                        ucModuleSettings ucCntrl = new ucModuleSettings();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Warehouse Admin":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Warehouse Admin")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Warehouse Admin";
                        ucWhseLocManagement ucCntrl = new ucWhseLocManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Receiving Warehouses":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Receiving Warehouses")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Receiving Warehouses";
                        ucRecTransferManagement ucCntrl = new ucRecTransferManagement();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "AW RMs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "AW RMs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "AW RMs";
                        ucAWRawMaterials ucCntrl = new ucAWRawMaterials();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "ZECT Jobs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "ZECT Jobs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "ZECT Jobs";
                        ucZectOutput ucCntrl = new ucZectOutput();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "AW Jobs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "AW Jobs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "AW Jobs";
                        ucAWJobs ucCntrl = new ucAWJobs();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Canning RMs":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Canning RMs")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Canning RMs";
                        ucCanningRawMaterials ucCntrl = new ucCanningRawMaterials();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Canning Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Canning Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Canning Records";
                        ucCanningRecords ucCntrl = new ucCanningRecords();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Manufacture Records":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Manufacture Records")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Manufacture Records";
                        ucAutoManuf ucCntrl = new ucAutoManuf();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "FG Printing":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "FG Printing")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "FG Printing";
                        ucFGPrinting ucCntrl = new ucFGPrinting();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Dispatch Barcodes":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Dispatch Barcodes")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }

                    if (found == false)
                    {
                        xp.Text = "Dispatch Barcodes";
                        ucDispatchBarcodes ucCntrl = new ucDispatchBarcodes();
                        xp.Controls.Add(ucCntrl);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Open Stock Takes":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Open Stock Takes")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }
                    if (found == false)
                    {
                        xp.Text = "Open Stock Takes";
                        ucOpenStockTakes cntrlOpenStockTakes = new ucOpenStockTakes();
                        xp.Controls.Add(cntrlOpenStockTakes);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Archive Stock Takes":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Archive Stock Takes")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }
                    if (found == false)
                    {
                        xp.Text = "Archive Stock Takes";
                        ucArchiveStockTake cntrlOpenStockTakes = new ucArchiveStockTake();
                        xp.Controls.Add(cntrlOpenStockTakes);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                case "Palletizing":
                    found = false;
                    foreach (XtraTabPage page in xtcMain.TabPages)
                    {
                        if (page.Text == "Palletizing")
                        {
                            found = true;
                            xtcMain.SelectedTabPage = page;
                        }
                    }
                    if (found == false)
                    {
                        xp.Text = "Palletizing";
                        ucPalletizing cntrlOpenStockTakes = new ucPalletizing();
                        xp.Controls.Add(cntrlOpenStockTakes);
                        xtcMain.TabPages.Add(xp);
                        xtcMain.SelectedTabPage = xp;
                    }
                    break;
                default:
                    break;

            }
            resizeObjects();
        }
        private void xtcMain_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).PageVisible = false;
            (arg.Page as XtraTabPage).Dispose();
        }
        private void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            XRDesignPanel panel = (XRDesignPanel)sender;
            panel.AddCommandHandler(new SaveCommandHandler(panel));
        }

        private void bbtnExistingLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabels frm_labels = new frmLabels();
                frm_labels.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
        private void bbtnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GlobalVars.userPerms.Clear();
            GlobalVars.userName = string.Empty;
            logOff = true;
            login.WindowState = FormWindowState.Normal;
            login.ShowInTaskbar = true;
            this.Close();
        }

        #region Label Designer
        private void bbtnStkLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "Stock";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntStkLabel custLbl = new prntStkLabel();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;


                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New Stock Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnZectLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "Zect";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntZectLabel custLbl = new prntZectLabel();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;


                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New Zect Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnAWLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "A&W";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntAWLabel custLbl = new prntAWLabel();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;


                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New A&W Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnZectConfigTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "Zect Config";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntZectConfig custLbl = new prntZectConfig();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    custLbl.ShowPrintMarginsWarning = false;

                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "Zect Config Tag";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAWConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "AW Config";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntAWConfig custLbl = new prntAWConfig();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    custLbl.ShowPrintMarginsWarning = false;

                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "AW Config Tag";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnCanningLabel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "Canning";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntCanning custLbl = new prntCanning();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;



                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New Canning Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnFGBox_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "FG Box";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntFGBox custLbl = new prntFGBox();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;



                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New FG Box Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnFGPallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLabelInit nameLabel = new frmLabelInit();
                DialogResult result = nameLabel.ShowDialog();
                if (result == DialogResult.OK)
                {
                    GlobalVars.labelTypeCode = "FG Pallet";
                    GlobalVars.labelName = nameLabel._name;
                    int width = Convert.ToInt32(nameLabel._width);
                    int height = Convert.ToInt32(nameLabel._height);

                    prntFGPallet custLbl = new prntFGPallet();
                    custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                    custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                    custLbl.PageHeight = height * 10;
                    custLbl.PageWidth = width * 10;
                    custLbl.Detail.HeightF = height * 10;
                    custLbl.DisplayName = GlobalVars.labelName;
                    //custLbl.TopMargin.HeightF = 0;
                    //custLbl.BottomMargin.HeightF = 0;                  
                    custLbl.ShowPrintMarginsWarning = false;



                    XRDesignForm repNew = new XRDesignForm();
                    repNew.Text = "New FG Pallet Label";
                    XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                    XRDesignMdiController mdiController = repNew.DesignMdiController;
                    mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                    mdiController.OpenReport(custLbl);
                    repNew.ShowDialog();
                    if (mdiController.ActiveDesignPanel != null)
                    {
                        mdiController.ActiveDesignPanel.CloseReport();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void bbtnRMPallet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLabelInit nameLabel = new frmLabelInit();
            DialogResult result = nameLabel.ShowDialog();
            if (result == DialogResult.OK)
            {
                GlobalVars.labelTypeCode = "RM Pallet";
                GlobalVars.labelName = nameLabel._name;
                int width = Convert.ToInt32(nameLabel._width);
                int height = Convert.ToInt32(nameLabel._height);

                prntRMPallet custLbl = new prntRMPallet();
                custLbl.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                custLbl.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
                custLbl.PageHeight = height * 10;
                custLbl.PageWidth = width * 10;
                custLbl.Detail.HeightF = height * 10;
                custLbl.DisplayName = GlobalVars.labelName;
                custLbl.ShowPrintMarginsWarning = false;

                XRDesignForm repNew = new XRDesignForm();
                repNew.Text = "New RM Pallet Label";
                XRDesignPanel desPnl = repNew.ActiveDesignPanel;
                XRDesignMdiController mdiController = repNew.DesignMdiController;
                mdiController.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
                mdiController.OpenReport(custLbl);
                repNew.ShowDialog();
                if (mdiController.ActiveDesignPanel != null)
                {
                    mdiController.ActiveDesignPanel.CloseReport();
                }
            }
        }


        #endregion


    }
}
