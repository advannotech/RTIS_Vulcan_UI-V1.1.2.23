using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RTIS_Vulcan_UI.Forms;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RTIS_Vulcan_UI
{
    public partial class frmSplash : Form
    {
        public string returnString { get; set; }
        public string errMsg = string.Empty;
        public string errInfo = string.Empty;
        public frmMsg msg;
        public void loadSettings()
        {
            try
            {
                pnlMessage.SendToBack();
                pnlMessage.Visible = false;
                GlobalVars.RSCFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\RSC";
                GlobalVars.SettingsDB = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\RSC\\SettingDB.db3";
                string init = SQLite.InitSettingsDB();
                switch (init.Split('*')[0])
                {
                    case "1":
                        string users = Client.GetUsernames();
                        switch (users.Split('*')[0])
                        {
                            case "1":
                                users = users.Remove(0, 2);
                                GlobalVars.allUsers = users.Split('~').ToList<string>();
                                returnString = "1";
                                this.Close();
                                break;                            
                            case "0":
                                this.Width = 0;
                                returnString = "0";
                                users = users.Remove(0, 2);
                                msg = new frmMsg("A server side error occured: ", users, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                this.Close();
                                Application.Exit();
                                break;
                            case "-1":
                                this.Width = 0;
                                users = users.Split('*')[1];
                                errMsg = users.Split('|')[0];
                                errInfo = users.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                Application.Exit();
                                break;
                            case "-2":
                                this.Width = 0;
                                returnString = "0";
                                users = users.Remove(0, 3);
                                msg = new frmMsg("A connection level error has occured" + Environment.NewLine + "You will now be logged in as a service user!", users, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            default:
                                this.Width = 0;
                                StackTrace st1 = new StackTrace(0, true);
                                string msgStr1 = "Unexpected error getting usernames";
                                string infoStr1 = "Unexpected error getting usernames";
                                ExHandler.showErrorST(st1, msgStr1, infoStr1);
                                Application.Exit();
                                break;
                        }
                        break;
                    case "0":
                        this.Width = 0;
                        returnString = "0";
                        msg = new frmMsg(string.Empty, string.Empty, GlobalVars.msgState.First);
                        msg.ShowDialog();
                        this.Close();                        
                        break;
                    case "-1":
                        this.Width = 0;
                        returnString = "-1";
                        init = init.Split('*')[1];
                        errMsg = init.Split('|')[0];
                        errInfo = init.Split('|')[1];
                        showErrorStr(errMsg, errInfo);
                        Application.Exit();
                        break;
                    default:
                        this.Width = 0;
                        returnString = "-1";
                        StackTrace st = new StackTrace(0, true);
                        string msgStr = "Unexpected error initializing db";
                        string infoStr = "Unexpected error initializing db";
                        showErrorST(st, msgStr, infoStr);
                        Application.Exit();
                        break;
                }
            }
            catch (Exception ex)
            {
                this.Width = 0;
                returnString = "-1";
                showErrorEx(ex);
                Application.Exit();
            }
        }
        public frmSplash()
        {
            InitializeComponent();
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            pnlLoad.BringToFront();
            Thread thread = new Thread(loadSettings);
            thread.Start();
        }
        public void showErrorEx(Exception exc)
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
        public void showErrorST(StackTrace st, string msgStr, string infoStr)
        {
            StackFrame sf = new StackFrame();
            sf = st.GetFrame(0);
            string file = sf.GetFileName();
            string line = sf.GetFileLineNumber().ToString();
            string name = sf.GetFileName().ToString();
            string meth = sf.GetMethod().ToString();
            infoStr += Environment.NewLine + Environment.NewLine + "Method:" + Environment.NewLine + meth + Environment.NewLine + Environment.NewLine + "File: " + Environment.NewLine + name + Environment.NewLine + Environment.NewLine + "Line Number: " + Environment.NewLine + line;
            frmError err = new frmError(msgStr, infoStr);
            err.ShowDialog();
        }
        public void showErrorStr(string msg, string info)
        {
            frmError err = new frmError(msg, info);
            err.ShowDialog();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                showErrorEx(ex);
            }
        }
    }
}
