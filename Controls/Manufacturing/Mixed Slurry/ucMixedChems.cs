using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Auto_Manufacture;
using RTIS_Vulcan_UI.Forms.Main;
using RTIS_Vulcan_UI.Forms.Mixed_Slurry;

namespace RTIS_Vulcan_UI.Controls.Manufacturing.Mixed_Slurry
{
    public partial class ucMixedChems : UserControl
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        public ucMixedChems()
        {
            InitializeComponent();
        }

        private void ucMixedChems_Load(object sender, EventArgs e)
        {
            GetChemicals();
        }

        private void GetChemicals()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string chemLines = Client.GetAllMSChemicals();
                if (!string.IsNullOrWhiteSpace(chemLines))
                {
                    string returnCode = chemLines.Split('*')[0];
                    string returnData = chemLines.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllChems = new List<Chemicals>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    AllChems.Add(new Chemicals(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgChems.DataSource = AllChems;
                            dgChems.MainView.GridControl.DataSource = AllChems;
                            dgChems.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            AllChems = new List<Chemicals>();
                            dgChems.DataSource = AllChems;
                            dgChems.MainView.GridControl.DataSource = AllChems;
                            dgChems.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmAddChemical addChem = new frmAddChemical())
                {
                    addChem.ShowDialog();
                    if (addChem.DialogResult == DialogResult.OK)
                    {
                        GetChemicals();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Chemicals selected = gvChem.GetRow(gvChem.FocusedRowHandle) as Chemicals;
                if (selected != null)
                {
                    using (frmMsg quest = new frmMsg("", $"Are you sure you wish to delete {selected.Name}?",
                        GlobalVars.msgState.Question))
                    {
                        quest.ShowDialog();
                        if (quest.DialogResult == DialogResult.Yes)
                        {
                            SplashScreenManager.ShowForm(typeof(frmWait));
                            string chemLines = Client.RemoveMSChemical(selected.ID);
                            if (!string.IsNullOrWhiteSpace(chemLines))
                            {
                                string returnCode = chemLines.Split('*')[0];
                                string returnData = chemLines.Split('*')[1];
                                switch (returnCode)
                                {
                                    case "1":
                                        SplashScreenManager.CloseForm();
                                        using (frmMsg succ = new frmMsg("Success",
                                            "The chemical has been removed successfully",
                                            GlobalVars.msgState.Success))
                                        {
                                            succ.ShowDialog();
                                            GetChemicals();
                                        }

                                        break;
                                    case "0":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("Server Error", chemLines.Remove(0, 2),
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    case "-1":
                                        SplashScreenManager.CloseForm();
                                        errMsg = returnData.Split('|')[0];
                                        errInfo = returnData.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("A client side connection error has occured",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    default:
                                        SplashScreenManager.CloseForm();
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred";
                                        errInfo = "An unexpected error occurred" + Environment.NewLine +
                                                  "Data Returned:" +
                                                  Environment.NewLine + returnData;
                                        ExHandler.showErrorST(st, msgStr, errInfo);
                                        break;
                                }
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                msg = new frmMsg("A connection level error has occured",
                                    "No data was returned from the server",
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        private class Chemicals
        {
            public Chemicals(string[] args)
            {
                ID = args[0];
                Name = args[1];
            }

            public string ID { get; set; }
            public string Name { get; set; }
        }

        private List<Chemicals> AllChems = new List<Chemicals>();
    }
}