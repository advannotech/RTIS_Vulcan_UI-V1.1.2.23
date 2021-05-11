using RTIS_Vulcan_UI.Classes;
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

namespace RTIS_Vulcan_UI.Forms
{
    public partial class frmCloseMix : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public string id { get; set; }
        public string tankType { get; set; }
        public frmCloseMix(string _tankType, string _id)
        {
            InitializeComponent();
            id = _id;
            tankType = _tankType;
        }

        private void frmCloseMix_Load(object sender, EventArgs e)
        {

        }

        private void btnCloseMix_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tankType)
                {
                    case "TNK":
                        string tankClosed = Client.closeMixedSlurryTank(id + "|" + meReason.Text + "|" + GlobalVars.userName);
                        if (tankClosed != string.Empty)
                        {
                            switch (tankClosed.Split('*')[0])
                            {
                                case "1":
                                    msg = new frmMsg("Success", "The tank has been closed successfully", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    break;
                                case "0":
                                    tankClosed = tankClosed.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", tankClosed, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    tankClosed = tankClosed.Remove(0, 3);
                                    errMsg = tankClosed.Split('|')[0];
                                    errInfo = tankClosed.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    tankClosed = tankClosed.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", tankClosed, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tankClosed;
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }                        
                        break;
                    case "MTNK":
                        string mobileTankClosed = Client.closeMixedSlurryMobileTank(id + "|" + meReason.Text + "|" + GlobalVars.userName);
                        if (mobileTankClosed != string.Empty)
                        {
                            switch (mobileTankClosed.Split('*')[0])
                            {
                                case "1":
                                    msg = new frmMsg("Success", "The tank has been closed successfully", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    break;
                                case "0":
                                    mobileTankClosed = mobileTankClosed.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", mobileTankClosed, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    mobileTankClosed = mobileTankClosed.Remove(0, 3);
                                    errMsg = mobileTankClosed.Split('|')[0];
                                    errInfo = mobileTankClosed.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    mobileTankClosed = mobileTankClosed.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", mobileTankClosed, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + mobileTankClosed;
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
