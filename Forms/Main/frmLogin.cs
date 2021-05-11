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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI
{
    public partial class frmLogin : Form
    {
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        public frmMain mainShow;
        public string loginSuccess = "0";
        public void startUp()
        {
            try
            {
                frmSplash splash = new frmSplash();
                splash.ShowDialog();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                string returned = splash.returnString;
                switch (returned.Split('*')[0])
                {
                    case "1":
                        List<string> allUsers = GlobalVars.allUsers;
                        foreach (string user in allUsers)
                        {
                            if (user != string.Empty)
                            {
                                cmbUsers.Properties.Items.Add(user);
                            }                            
                        }
                        if (cmbUsers.Properties.Items.Count != 0)
                        {
                            cmbUsers.Text = cmbUsers.Properties.Items[0].ToString();
                        }
                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                        break;
                    case "0":
                        frmMain main = new frmMain("Service User", this);
                        main.Show();
                        this.WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                        break;
                    case "-1":
                        Application.Exit();
                        break;
                }
            }
            catch (Exception ex)
            {
                showErrorEx(ex);
            }
        }
        public void startLogin()
        {
            try
            {
                Thread.Sleep(1000);
                if (cmbUsers.Text == GlobalVars.RTUser && txtPassword.Text == GlobalVars.RTPass)
                {
                    GlobalVars.userName = "Reltech";
                    frmMain main = new frmMain("Reltech", this);
                    main.Show();
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else
                {
                    string userInfo = Client.UserLogin(cmbUsers.Text + "|" + txtPassword.Text);
                    switch (userInfo.Split('*')[0])
                    {
                        case "1":
                            GlobalVars.userName = cmbUsers.Text;
                            userInfo = userInfo.Remove(0, 2);
                            frmMain main = new frmMain(userInfo, this);
                            mainShow = main;
                            loginSuccess = "1";
                            break;
                        case "0":
                            userInfo = userInfo.Remove(0, 2);
                            msg = new frmMsg("The following issue was encountered:", userInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            loginSuccess = "-1";
                            break;
                        case "-1":
                            userInfo = userInfo.Remove(0, 3);
                            errMsg = userInfo.Split('|')[0];
                            errInfo = userInfo.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            loginSuccess = "-1";
                            break;
                        case "-2":
                            this.Width = 0;
                            userInfo = userInfo.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured" , userInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            this.Close();
                            break;
                        default:
                            StackTrace st1 = new StackTrace(0, true);
                            string msgStr1 = "Unexpected error while attempting login";
                            string infoStr1 = "Unexpected error while attempting login";
                            ExHandler.showErrorST(st1, msgStr1, infoStr1);
                            loginSuccess = "-1";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                showErrorEx(ex);
                loginSuccess = "-1";
            }
        }
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            startUp();
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ppnlWait.Visible = true;
            tmrLogin.Start();
            Thread t = new Thread(startLogin);
            t.Start();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tmrLogin_Tick(object sender, EventArgs e)
        {
            if (loginSuccess == "1")
            {
                tmrLogin.Stop();
                loginSuccess = "0";
                ppnlWait.Visible = false;

                txtPassword.Text = string.Empty;
                mainShow.Show();

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else if (loginSuccess == "-1")
            {
                tmrLogin.Stop();
                loginSuccess = "0";
                ppnlWait.Visible = false;
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ppnlWait.Visible = true;
                tmrLogin.Start();
                Thread t = new Thread(startLogin);
                t.Start();
            }
        }
    }
}
