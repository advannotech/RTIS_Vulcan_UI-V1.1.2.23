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
    public partial class frmRoleManagement : Form
    {
        public string id = string.Empty;
        public string type = string.Empty;
        public string name = string.Empty;
        public string desc = string.Empty;
        public string permissions = string.Empty;
        public string _modules = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public void getAvailablePermissions()
        {
            try
            {
                string available = Client.GetAvailablePermissions();
                if (available != string.Empty)
                {
                    switch (available.Split('*')[0])
                    {
                        case "1":
                            lbAvailable.Items.Clear();
                            available = available.Remove(0, 2);
                            string[] arrPerms = available.Split('~');
                            foreach (string perm in arrPerms)
                            {
                                if (perm != "")
                                {
                                    lbAvailable.Items.Add(perm);
                                }
                            }
                            break;
                        case "0":
                            available = available.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", available, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            available = available.Remove(0, 3);
                            errMsg = available.Split('|')[0];
                            errInfo = available.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            available = available.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", available, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving active permissions";
                            errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + available;
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
        public void setCurrentPermissions()
        {
            try
            {
                if (permissions != string.Empty)
                {
                    foreach (string item in permissions.Split(','))
                    {
                        if (item != string.Empty)
                        {
                            lbSelected.Items.Add(item);
                            lbAvailable.Items.Remove(item);
                        }                    
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshPage()
        {
            txtName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            getAvailablePermissions();
            lbSelected.Items.Clear();
        }
        public frmRoleManagement(string _id, string _type, string _name, string _desc, string _permissions)
        {
            InitializeComponent();
            id = _id;
            type = _type;
            name = _name;
            desc = _desc;
            permissions = _permissions;
        }
        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            refreshPage();
            txtName.Text = name;
            txtDesc.Text = desc;
            setCurrentPermissions();
        }
        private void btnAddPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbAvailable.SelectedItems.Count > 0)
                {
                    object selected = lbAvailable.SelectedItem;
                    lbSelected.Items.Add(selected);
                    lbAvailable.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnRemovePerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSelected.SelectedItems.Count > 0)
                {
                    object selected = lbSelected.SelectedItem;
                    lbAvailable.Items.Add(selected);
                    lbSelected.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAddAllPerms_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> itemList = new List<string>();
                foreach (string item in lbAvailable.Items)
                {
                    itemList.Add(item);
                }

                foreach (string item in itemList)
                {
                    lbSelected.Items.Add(item);
                    lbAvailable.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void addRole()
        {
            try
            {
                if (txtName.Text != string.Empty && txtDesc.Text != string.Empty && lbSelected.Items.Count > 0)
                {
                    string permissions = "";
                    foreach (string item in lbSelected.Items)
                    {
                        permissions = permissions + "," + item;
                    }

                    string added = Client.AddRole(txtName.Text + "|" + txtDesc.Text + "|" + permissions);
                    if (added != string.Empty)
                    {
                        switch (added.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success!", "Role " + txtName.Text + " has been added", GlobalVars.msgState.Success);
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
                                msgStr = "An unexpected error occurred while creating the role";
                                errInfo = "An unexpected error occurred while creating the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
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
                        blanks += " - No role name was supplied";
                    }
                    if (txtDesc.Text == string.Empty)
                    {
                        blanks += " - No role description was supplied";
                    }
                    if (lbSelected.Items.Count < 1)
                    {
                        blanks += " - A role requires atleast one permission";
                    }
                    msg = new frmMsg("The role cannot be created for the following reasons:", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void editRole()
        {
            try
            {
                if (txtName.Text != string.Empty && txtDesc.Text != string.Empty && lbSelected.Items.Count > 0)
                {
                    string permissions = "";
                    foreach (string item in lbSelected.Items)
                    {
                        permissions = permissions + "," + item;
                    }
                    string updated = Client.UpdateRole(id + "|" + txtName.Text + "|" + txtDesc.Text + "|" + permissions);
                    switch (updated.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Success!", "Role " + txtName.Text + " has been updated", GlobalVars.msgState.Success);
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
                            msgStr = "An unexpected error occurred while updating the role";
                            errInfo = "An unexpected error occurred while updating the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                            break;
                    }
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtName.Text == string.Empty)
                    {
                        blanks += " - No role name was supplied";
                    }
                    if (txtDesc.Text == string.Empty)
                    {
                        blanks += " - No role description was supplied";
                    }
                    if (lbSelected.Items.Count < 1)
                    {
                        blanks += " - A role requires atleast one permission";
                    }
                    msg = new frmMsg("The role cannot be created for the following reasons:", blanks, GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == "Add")
                {
                    addRole();
                }
                else if (type == "Edit")
                {
                    editRole();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
