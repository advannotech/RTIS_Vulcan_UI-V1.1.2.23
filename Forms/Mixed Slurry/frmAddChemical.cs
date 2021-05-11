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
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Controls.Manufacturing.Mixed_Slurry;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.Mixed_Slurry
{
    public partial class frmAddChemical : Form
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        public frmAddChemical()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    SplashScreenManager.ShowForm(typeof(frmWait));
                    string chemLines = Client.AddMSChemical(txtName.Text);
                    if (!string.IsNullOrWhiteSpace(chemLines))
                    {
                        string returnCode = chemLines.Split('*')[0];
                        string returnData = chemLines.Split('*')[1];
                        switch (returnCode)
                        {
                            case "1":
                                SplashScreenManager.CloseForm();
                                using (frmMsg succ = new frmMsg("Success", "The chemical has been added successfully",
                                    GlobalVars.msgState.Success))
                                {
                                    succ.ShowDialog();
                                    this.DialogResult = DialogResult.OK;
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
                else
                {
                    using (frmMsg msg = new frmMsg("Cannot Add Chemical", "Please enter a chemical name",
                        GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
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
    }
}