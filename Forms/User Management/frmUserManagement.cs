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
    public partial class frmUserManagement : Form
    {
        public string id = string.Empty;
        public string type = string.Empty;
        public string name = string.Empty;
        public string username = string.Empty;
        public string role = string.Empty;
        public string pin = string.Empty;
        public string password = string.Empty;
        public bool agent = false;
        public string evoAgent = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public void getActiveRoles()
        {
            try
            {
                string activeRoles = Client.GetActiveRoles();
                if (activeRoles != string.Empty)
                {
                    switch (activeRoles.Split('*')[0])
                    {
                        case "1":
                            activeRoles = activeRoles.Remove(0, 2);
                            cmbRoles.Properties.Items.Clear();
                            foreach (string role in activeRoles.Split('~'))
                            {
                                if (role != "")
                                {
                                    cmbRoles.Properties.Items.Add(role);
                                }
                            }
                            break;
                        case "0":
                            activeRoles = activeRoles.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", activeRoles, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            activeRoles = activeRoles.Remove(0, 3);
                            errMsg = activeRoles.Split('|')[0];
                            errInfo = activeRoles.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            activeRoles = activeRoles.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", activeRoles, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving active roles";
                            errInfo = "Unexpected error while retreiving active roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + activeRoles;
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
                ExHandler.returnErrorEX(ex);
            }
        }
        public void getRolePermissions()
        {
            try
            {
                if (cmbRoles.Text != string.Empty)
                {
                    string permissions = Client.GetRolePermisssions(cmbRoles.Text);
                    if (permissions != string.Empty)
                    {
                        switch (permissions.Split('*')[0])
                        {
                            case "1":
                                permissions = permissions.Remove(0, 2);
                                txtPerms.Text = string.Empty;
                                foreach (string permission in permissions.Split('~'))
                                {
                                    txtPerms.Text = txtPerms.Text + permission + Environment.NewLine;
                                }
                                break;
                            case "0":
                                permissions = permissions.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", permissions, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                permissions = permissions.Remove(0, 3);
                                errMsg = permissions.Split('|')[0];
                                errInfo = permissions.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                permissions = permissions.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", permissions, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving active role permissions";
                                errInfo = "Unexpected error while retreiving active role permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + permissions;
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }               
            }
            catch (Exception ex)
            {
                ExHandler.returnErrorEX(ex);
            }
        }
        public void getEvoAgents()
        {
            try
            {
                string agentNames = Client.GetEvoAgents();
                if (agentNames != string.Empty)
                {
                    switch (agentNames.Split('*')[0])
                    {
                        case "1":
                            agentNames = agentNames.Remove(0, 2);
                            cmbAgentName.Properties.Items.Clear();
                            foreach (string agent in agentNames.Split('~'))
                            {
                                if (agent != "")
                                {
                                    cmbAgentName.Properties.Items.Add(agent);
                                }
                            }
                            break;
                        case "0":
                            agentNames = agentNames.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", agentNames, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            agentNames = agentNames.Remove(0, 3);
                            errMsg = agentNames.Split('|')[0];
                            errInfo = agentNames.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            agentNames = agentNames.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", agentNames, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving evolution agents";
                            errInfo = "Unexpected error while retreiving active evolution agents" + Environment.NewLine + "Data Returned:" + Environment.NewLine + agentNames;
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
                ExHandler.returnErrorEX(ex);
            }
        }
        public void addUser()
        {
            try
            {
                if (txtName.Text != string.Empty && cmbRoles.Text != string.Empty && txtPin.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    string sendString = string.Empty;
                    if (cbHasAgent.Checked == true)
                    {
                        sendString = txtName.Text + "|" + txtUsername.Text + "|" + txtPin.Text + "|" + txtPassword.Text + "|" + cmbRoles.Text + "|1|" + cmbAgentName.Text;
                    }
                    else
                    {
                        sendString = txtName.Text + "|" + txtUsername.Text + "|" + txtPin.Text + "|" + txtPassword.Text + "|" + cmbRoles.Text + "|0|";
                    }

                    string added = Client.AddUser(sendString);
                    if (added != string.Empty)
                    {
                        switch (added.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success!", "User " + txtName.Text + " has been added", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                break;
                            case "0":
                                added = added.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", added, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                added = added.Remove(0, 3);
                                errMsg = added.Split('|')[0];
                                errInfo = added.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                added = added.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", added, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while created the user";
                                errInfo = "Unexpected error while created the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtName.Text == string.Empty)
                    {
                        blanks = blanks + " - No name was supplied" + Environment.NewLine;
                    }
                    if (cmbRoles.Text == string.Empty)
                    {
                        blanks = blanks + " - No role was selected" + Environment.NewLine;
                    }
                    if (txtPin.Text == string.Empty)
                    {
                        blanks = blanks + " - No PIN was supplied" + Environment.NewLine;
                    }
                    if (txtUsername.Text == string.Empty)
                    {
                        blanks = blanks + " - No username was supplied" + Environment.NewLine;
                    }
                    if (txtPassword.Text == string.Empty)
                    {
                        blanks = blanks + " - No password was supplied" + Environment.NewLine;
                    }
                    msg = new frmMsg("The user cannot be created for the following reasons:", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.returnErrorEX(ex);
            }
        }
        public void editUser()
        {
            try
            {
                if (txtName.Text != string.Empty && cmbRoles.Text != string.Empty && txtPin.Text != string.Empty && txtUsername.Text != string.Empty && txtPassword.Text != string.Empty)
                {
                    string sendString = string.Empty;
                    if (cbHasAgent.Checked == true)
                    {
                        sendString = id + "|" + txtName.Text + "|" + txtUsername.Text + "|" + txtPin.Text + "|" + txtPassword.Text + "|" + cmbRoles.Text + "|1|" + cmbAgentName.Text;
                    }
                    else
                    {
                        sendString = id + "|" + txtName.Text + "|" + txtUsername.Text + "|" + txtPin.Text + "|" + txtPassword.Text + "|" + cmbRoles.Text + "|0|";
                    }

                    string updated = Client.UpdateUser(sendString);
                    if (updated != string.Empty)
                    {
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success!", "User " + txtName.Text + " has been updated", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                break;
                            case "0":
                                updated = updated.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", updated, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                updated = updated.Remove(0, 3);
                                errMsg = updated.Split('|')[0];
                                errInfo = updated.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                updated = updated.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", updated, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while updating the user";
                                errInfo = "Unexpected error while updating the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }                    
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtName.Text == string.Empty)
                    {
                        blanks = blanks + " - No name was supplied" + Environment.NewLine;
                    }
                    if (cmbRoles.Text == string.Empty)
                    {
                        blanks = blanks + " - No role was selected" + Environment.NewLine;
                    }
                    if (txtPin.Text == string.Empty)
                    {
                        blanks = blanks + " - No PIN was supplied" + Environment.NewLine;
                    }
                    if (txtUsername.Text == string.Empty)
                    {
                        blanks = blanks + " - No username was supplied" + Environment.NewLine;
                    }
                    if (txtPassword.Text == string.Empty)
                    {
                        blanks = blanks + " - No password was supplied" + Environment.NewLine;
                    }
                    msg = new frmMsg("The user cannot be updated for the following reasons:", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.returnErrorEX(ex);
            }
        }
        public frmUserManagement(string _id, string _type, string _name, string _username, string _role, string _pin, string _password, bool _agent, string _evoAgent)
        {
            InitializeComponent();
            id = _id;
            type = _type;
            name = _name;
            username = _username;
            role = _role;
            pin = _pin;
            password = _password;
            agent = _agent;
            evoAgent = _evoAgent;
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            getActiveRoles();
            getEvoAgents();
            txtName.Text = name;
            txtUsername.Text = username;
            txtPin.Text = pin;
            cbHasAgent.Checked = agent;
            cmbAgentName.Text = evoAgent;
            cmbRoles.Text = role;
        }
        private void cmbRoles_TextChanged(object sender, EventArgs e)
        {
            getRolePermissions();
        }
        private void cbHasAgent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbHasAgent.Checked == true)
                {
                    cmbAgentName.Enabled = true;
                }
                else
                {
                    cmbAgentName.Text = string.Empty;
                    cmbAgentName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExHandler.returnErrorEX(ex);
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "Add")
                {
                    addUser();
                }
                else if (type == "Edit")
                {
                    editUser();
                }
            }
            catch (Exception ex)
            {
                ExHandler.returnErrorEX(ex);
            }
        }
    }
}
