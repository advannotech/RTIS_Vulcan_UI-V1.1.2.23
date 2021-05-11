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
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucSettings : UserControl
    {
        public frmMsg msg;
        public string errMsg;
        public string errInfo;
        public void getSettings()
        {
            try
            {
                try
                {
                    txtIP.Text = GlobalVars.ServerIP.Split('.')[0];
                    txtIP2.Text = GlobalVars.ServerIP.Split('.')[1];
                    txtIP3.Text = GlobalVars.ServerIP.Split('.')[2];
                    txtIP4.Text = GlobalVars.ServerIP.Split('.')[3];
                }
                catch (Exception)
                { }
                txtPort.Text = GlobalVars.ServerPort;

                txtServer.Text = GlobalVars.SQLServer;
                cmbDatabases.Text = GlobalVars.RTDB;
                cmbEvolutionDBs.Text = GlobalVars.EvoDB;
                cmbXpdtDBs.Text = GlobalVars.XperDB;
                if (GlobalVars.SqlAuth == true)
                {
                    pnlSQL.Enabled = true;
                    rbSQLAuth.Checked = true;
                    txtUsername.Text = GlobalVars.SqlUser;
                    txtPassword.Text = GlobalVars.SqlPass;

                }
                else
                {
                    pnlSQL.Enabled = false;
                    rbWAuth.Checked = true;
                }
            }
            catch (Exception ex)
            {
               ExHandler.showErrorEx(ex);
            }
        }
        public ucSettings()
        {
            InitializeComponent();
        }
        private void ucSettings_Load(object sender, EventArgs e)
        {
            getSettings();
        }
        private void rbWAuth_Click(object sender, EventArgs e)
        {
            pnlSQL.Enabled = false;
        }
        private void rbSQLAuth_Click(object sender, EventArgs e)
        {
            pnlSQL.Enabled = true;
        }
        private void cmbDatabases_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSQLAuth.Checked == true)
                {
                    #region SQL Auth
                    if (cmbDatabases.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesSQLAuth(txtServer.Text, txtUsername.Text, txtPassword.Text);                           
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbDatabases.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbDatabases.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbDatabases.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching databases with SQL authentication";
                                    string infoStr = "Unexpected fetching databases with SQL authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            if (txtUsername.Text == string.Empty)
                            {
                                blanks += " - No user was supplied" + Environment.NewLine;
                            }
                            if (txtPassword.Text == string.Empty)
                            {
                                blanks += " - No password was supplied" + Environment.NewLine;
                            }                          
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):", blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Windows Auth
                    if (cmbDatabases.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesWinAuth(txtServer.Text);
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbDatabases.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbDatabases.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbDatabases.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching databases with windows authentication";
                                    string infoStr = "Unexpected fetching databases with windows authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):" , blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ExHandler.showErrorEx(ex);
            }
        }
        private void cmbEvolutionDBs_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSQLAuth.Checked == true)
                {
                    #region SQL Auth
                    if (cmbEvolutionDBs.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesSQLAuth(txtServer.Text, txtUsername.Text, txtPassword.Text);
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbEvolutionDBs.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbEvolutionDBs.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbEvolutionDBs.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive evolution databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching evolution databases with SQL authentication";
                                    string infoStr = "Unexpected fetching evolution databases with SQL authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            if (txtUsername.Text == string.Empty)
                            {
                                blanks += " - No user was supplied" + Environment.NewLine;
                            }
                            if (txtPassword.Text == string.Empty)
                            {
                                blanks += " - No password was supplied" + Environment.NewLine;
                            }
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):", blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Windows Auth
                    if (cmbEvolutionDBs.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesWinAuth(txtServer.Text);
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbEvolutionDBs.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbEvolutionDBs.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbEvolutionDBs.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive evolution databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching evolution databases with windows authentication";
                                    string infoStr = "Unexpected fetching evolution databases with windows authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):", blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ExHandler.showErrorEx(ex);
            }
        }
        private void cmbXpdtDBs_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbSQLAuth.Checked == true)
                {
                    #region SQL Auth
                    if (cmbXpdtDBs.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesSQLAuth(txtServer.Text, txtUsername.Text, txtPassword.Text);
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbXpdtDBs.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbXpdtDBs.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbXpdtDBs.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive xperdyte databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching xperdyte databases with SQL authentication";
                                    string infoStr = "Unexpected fetching xperdyte databases with SQL authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            if (txtUsername.Text == string.Empty)
                            {
                                blanks += " - No user was supplied" + Environment.NewLine;
                            }
                            if (txtPassword.Text == string.Empty)
                            {
                                blanks += " - No password was supplied" + Environment.NewLine;
                            }
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):", blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Windows Auth
                    if (cmbXpdtDBs.Properties.Items.Count == 0)
                    {
                        if (txtServer.Text != string.Empty)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string databases = DirectQueries.getDatabasesWinAuth(txtServer.Text);
                            switch (databases.Split('*')[0])
                            {
                                case "1":
                                    databases = databases.Remove(0, 2);
                                    cmbXpdtDBs.Properties.Items.Clear();
                                    string[] allDatabases = databases.Split('~');
                                    foreach (string database in allDatabases)
                                    {
                                        if (database != string.Empty)
                                        {
                                            cmbXpdtDBs.Properties.Items.Add(database);
                                        }
                                    }
                                    cmbXpdtDBs.ShowPopup();
                                    break;
                                case "0":
                                    Cursor.Current = Cursors.Default;
                                    msg = new frmMsg("Cannot retreive xperdyte databases", databases.Split('*')[1], GlobalVars.msgState.Error);
                                    msg.Show();
                                    break;
                                case "-1":
                                    Cursor.Current = Cursors.Default;
                                    databases = databases.Remove(0, 3);
                                    string _msg = databases.Split('|')[0];
                                    string _info = databases.Split('|')[1];
                                    ExHandler.showErrorStr(_msg, _info);
                                    break;
                                default:
                                    Cursor.Current = Cursors.Default;
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected fetching xperdyte databases with windows authentication";
                                    string infoStr = "Unexpected fetching xperdyte databases with windows authentication";
                                    ExHandler.showErrorST(st, msgStr, infoStr);
                                    break;
                            }
                        }
                        else
                        {
                            string blanks = string.Empty;
                            if (txtServer.Text == string.Empty)
                            {
                                blanks += " - No server was supplied" + Environment.NewLine;
                            }
                            Cursor.Current = Cursors.Default;
                            msg = new frmMsg("Databases cannot be retreived for the following reason(s):", blanks, GlobalVars.msgState.Error);
                            msg.Show();
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                ExHandler.showErrorEx(ex);
            }
        }
        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            if (txtIP.Text.Length == 3)
            {
                txtIP2.Focus();
            }
        }
        private void txtIP2_TextChanged(object sender, EventArgs e)
        {
            if (txtIP2.Text.Length == 3)
            {
                txtIP2.Focus();
            }
        }
        private void txtIP3_TextChanged(object sender, EventArgs e)
        {
            if (txtIP3.Text.Length == 3)
            {
                txtIP4.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServer.Text != string.Empty && cmbDatabases.Text != string.Empty && cmbEvolutionDBs.Text != string.Empty && cmbXpdtDBs.Text != string.Empty
                    && txtIP.Text != string.Empty && txtIP2.Text != string.Empty && txtIP3.Text != string.Empty && txtIP4.Text != string.Empty
                    && txtPort.Text != string.Empty && (rbSQLAuth.Checked == true || rbWAuth.Checked == true))
                {
                    if (rbSQLAuth.Checked == true)
                    {
                        string encrypted = Cypher.Encrypt(txtPassword.Text);
                        switch (encrypted.Split('*')[0])
                        {
                            case "1":
                                encrypted = encrypted.Remove(0, 2);
                                string updateCommand = string.Empty;
                                string serverIP = txtIP.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtServer.Text + "' WHERE [SettingName] = 'SQLServer';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + Convert.ToString(true) + "' WHERE [SettingName] = 'SQLAuth';";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbDatabases.Text + "' WHERE [SettingName] = 'SQLDatabase'; ";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbEvolutionDBs.Text + "' WHERE [SettingName] = 'EvoDatabase'; ";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbXpdtDBs.Text + "' WHERE [SettingName] = 'XperDatabase'; ";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + txtUsername.Text + "' WHERE [SettingName] = 'SQLUser'; ";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + encrypted + "' WHERE [SettingName] = 'SQLPassword'; ";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + serverIP + "' WHERE [SettingName] = 'ServerIP';";
                                updateCommand += "UPDATE [Settings] SET [Value] = '" + txtPort.Text + "' WHERE [SettingName] = 'ServerPort';";
                                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                                switch (updated.Split('*')[0])
                                {
                                    case "1":
                                        msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        break;
                                    case "-1":
                                        updated = updated.Remove(0, 3);
                                        errMsg = updated.Split('|')[0];
                                        errInfo = updated.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    default:
                                        Cursor.Current = Cursors.Default;
                                        StackTrace st1 = new StackTrace(0, true);
                                        string msgStr1 = "Unexpected saving settings";
                                        string infoStr1 = "Unexpected saving setting";
                                        ExHandler.showErrorST(st1, msgStr1, infoStr1);
                                        break;
                                }
                                break;
                            case "-1":
                                encrypted = encrypted.Remove(0, 3);
                                errMsg = encrypted.Split('|')[0];
                                errInfo = encrypted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                Cursor.Current = Cursors.Default;
                                StackTrace st = new StackTrace(0, true);
                                string msgStr = "Unexpected encryption error";
                                string infoStr = "Unexpected encryption error";
                                ExHandler.showErrorST(st, msgStr, infoStr);
                                break;
                        }
                        
                    }
                    else
                    {
                        string updateCommand = string.Empty;
                        string serverIP = txtIP.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                        updateCommand += "UPDATE [Settings] SET [Value] ='" + txtServer.Text + "' WHERE [SettingName] = 'SQLServer';";
                        updateCommand += "UPDATE [Settings] SET [Value] ='" + Convert.ToString(false) + "' WHERE [SettingName] = 'SQLAuth';";
                        updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbDatabases.Text + "' WHERE [SettingName] = 'SQLDatabase'; ";
                        updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbEvolutionDBs.Text + "' WHERE [SettingName] = 'EvoDatabase'; ";
                        updateCommand += "UPDATE [Settings] SET [Value] = '" + cmbXpdtDBs.Text + "' WHERE [SettingName] = 'XperDatabase'; ";
                        updateCommand += "UPDATE [Settings] SET [Value] = '-Enter Username-' WHERE [SettingName] = 'SQLUser'; ";
                        updateCommand += "UPDATE [Settings] SET [Value] = '-Enter Password-' WHERE [SettingName] = 'SQLPassword'; ";
                        updateCommand += "UPDATE [Settings] SET [Value] ='" + serverIP + "' WHERE [SettingName] = 'ServerIP';";
                        updateCommand += "UPDATE [Settings] SET [Value] = '" + txtPort.Text + "' WHERE [SettingName] = 'ServerPort';";
                        string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                updated = updated.Remove(0, 3);
                                errMsg = updated.Split('|')[0];
                                errInfo = updated.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                Cursor.Current = Cursors.Default;
                                StackTrace st1 = new StackTrace(0, true);
                                string msgStr1 = "Unexpected saving settings";
                                string infoStr1 = "Unexpected saving setting";
                                ExHandler.showErrorST(st1, msgStr1, infoStr1);
                                break;
                        }
                    }
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtServer.Text == string.Empty)
                    {
                        blanks += " - No server was supplied" + Environment.NewLine;
                    }
                    if (cmbDatabases.Text == string.Empty)
                    {
                        blanks += " - No RTIS database was selected" + Environment.NewLine;
                    }
                    if (cmbEvolutionDBs.Text == string.Empty)
                    {
                        blanks += " - No Evolution database was selected" + Environment.NewLine;
                    }
                    if (cmbXpdtDBs.Text == string.Empty)
                    {
                        blanks += " - No Xperdyte database was selected" + Environment.NewLine;
                    }
                    if (txtIP.Text == string.Empty || txtIP2.Text == string.Empty || txtIP3.Text == string.Empty || txtIP4.Text == string.Empty)
                    {
                        blanks += " - A valid IP address was not entered" + Environment.NewLine;
                    }
                    if (txtPort.Text == string.Empty)
                    {
                        blanks += " - No port number was specified" + Environment.NewLine;
                    }
                    msg = new frmMsg("Cannot save settings for the following reason(s):", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnDBTest_Click(object sender, EventArgs e)
        {
            try
            {
                string test = string.Empty;
                if (rbSQLAuth.Checked == true)
                {
                    test = DirectQueries.testConnSQLAuth(txtServer.Text, cmbDatabases.Text, txtUsername.Text, txtPassword.Text);
                    if (test == "1")
                    {
                        lblDBTest.Text = "--Success--";
                        lblDBTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBTest.Text = "--Failed--";
                        lblDBTest.ForeColor = Color.Red;
                    }
                }
                else
                {
                    test = DirectQueries.testConnWinAuth(txtServer.Text);
                    if (test == "1")
                    {
                        lblDBTest.Text = "--Success--";
                        lblDBTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBTest.Text = "--Failed--";
                        lblDBTest.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }   
        }
        private void btnDBEvoTest_Click(object sender, EventArgs e)
        {
            try
            {
                string test = string.Empty;
                if (rbSQLAuth.Checked == true)
                {
                    test = DirectQueries.testConnSQLAuth(txtServer.Text, cmbEvolutionDBs.Text, txtUsername.Text, txtPassword.Text);
                    if (test == "1")
                    {
                        lblDBEvoTest.Text = "--Success--";
                        lblDBEvoTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBEvoTest.Text = "--Failed--";
                        lblDBEvoTest.ForeColor = Color.Red;
                    }
                }
                else
                {
                    test = DirectQueries.testConnWinAuth(txtServer.Text);
                    if (test == "1")
                    {
                        lblDBTest.Text = "--Success--";
                        lblDBTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBTest.Text = "--Failed--";
                        lblDBTest.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnDBXpTest_Click(object sender, EventArgs e)
        {
            try
            {
                string test = string.Empty;
                if (rbSQLAuth.Checked == true)
                {
                    test = DirectQueries.testConnSQLAuth(txtServer.Text, cmbXpdtDBs.Text, txtUsername.Text, txtPassword.Text);
                    if (test == "1")
                    {
                        lblDBXpTest.Text = "--Success--";
                        lblDBXpTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBXpTest.Text = "--Failed--";
                        lblDBXpTest.ForeColor = Color.Red;
                    }
                }
                else
                {
                    test = DirectQueries.testConnWinAuth(txtServer.Text);
                    if (test == "1")
                    {
                        lblDBTest.Text = "--Success--";
                        lblDBTest.ForeColor = Color.Green;
                    }
                    else
                    {

                        lblDBTest.Text = "--Failed--";
                        lblDBTest.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnServerTest_Click(object sender, EventArgs e)
        {
            try
            {
                string serverIP = txtIP.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                string test = Client.TestConn(serverIP, txtPort.Text);
                if (test == "1")
                {
                    lblServerTest.Text = "--Success--";
                    lblServerTest.ForeColor = Color.Green;
                }
                else
                {
                    lblServerTest.Text = "--Failed--";
                    lblServerTest.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
