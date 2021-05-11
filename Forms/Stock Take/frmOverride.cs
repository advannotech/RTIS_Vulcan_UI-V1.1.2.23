using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
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

namespace RTIS_Vulcan_UI
{
    public partial class frmOverride : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public string overridePass = string.Empty;
        public void getGridOverride()
        {
            try
            {
                string gridOverride = Client.GetGridOverride();
                if (gridOverride != string.Empty)
                {
                    switch (gridOverride.Split('*')[0])
                    {
                        case "1":
                            overridePass = gridOverride.Remove(0, 2);
                            break;
                        case "0":
                            msg = new frmMsg("The following server side issue was encountered:", gridOverride, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            gridOverride = gridOverride.Remove(0, 3);
                            errMsg = gridOverride.Split('|')[0];
                            errInfo = gridOverride.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving override password";
                            errInfo = "Unexpected error while retreiving override password" + Environment.NewLine + "Data Returned:" + Environment.NewLine + overridePass;
                            break;
                    }
                }
                else
                {
                    st = new StackTrace(0, true);
                    msgStr = "Unexpected error while retreiving warehouse transfer processes";
                    errInfo = "Unexpected error while retreiving warehouse transfer processes" + Environment.NewLine + "Data Returned:" + Environment.NewLine + overridePass;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public frmOverride()
        {
            InitializeComponent();
        }
        private void frmOverride_Load(object sender, EventArgs e)
        {
            getGridOverride();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != string.Empty)
                {
                    if (txtPassword.Text == overridePass)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        msg = new frmMsg("Cannot unlock grid", "The password you have entered is incorrect", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        txtPassword.Text = string.Empty;
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot unlock grid", "Please enter the override password", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
                    
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
