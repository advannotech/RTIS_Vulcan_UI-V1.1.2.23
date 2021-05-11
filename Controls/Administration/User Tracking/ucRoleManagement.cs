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
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucRoleManagement : UserControl
    {
        DataTable dt = new DataTable();
        public string id = string.Empty;
        public string roleName = string.Empty;
        public string roleDesc = string.Empty;
        public string rolePerms = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        
        public void setupTable()
        {
            try
            {
                dt.Columns.Add(new DataColumn("gcID", typeof(string)));
                dt.Columns.Add(new DataColumn("gcName", typeof(string)));
                dt.Columns.Add(new DataColumn("gcDesc", typeof(string)));
                dt.Columns.Add(new DataColumn("gcPerm", typeof(string)));
                dt.Columns.Add(new DataColumn("gcActive", typeof(bool)));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
            
        }
        public void getRoles()
        {
            try
            {
                string allRoles = Client.GetAllRoles();
                if (allRoles != string.Empty)
                {
                    switch (allRoles.Split('*')[0])
                    {
                        case "1":
                            dt.Rows.Clear();
                            allRoles = allRoles.Remove(0, 2);
                            string[] rolesArray = allRoles.Split('~');
                            foreach (string role in rolesArray)
                            {
                                if (role != "")
                                {
                                    string roleLines = role.Replace(",", "," + Environment.NewLine);
                                    dt.Rows.Add(roleLines.Split('|'));
                                }
                            }
                            dgRoles.DataSource = dt;
                            dgRoles.MainView.GridControl.DataSource = dt;
                            dgRoles.MainView.GridControl.EndUpdate();
                            break;
                        case "0":
                            allRoles = allRoles.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", allRoles, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            allRoles = allRoles.Remove(0, 3);
                            errMsg = allRoles.Split('|')[0];
                            errInfo = allRoles.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            allRoles = allRoles.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", allRoles, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving roles";
                            errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + allRoles;
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
        public ucRoleManagement()
        {
            InitializeComponent();
        }
        private void ucRoleManagement_Load(object sender, EventArgs e)
        {
            setupTable();
            getRoles();
        }
        private void dgRoles_Click(object sender, EventArgs e)
        {
            try
            {
                id = gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcID").ToString();
                roleName = gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcName").ToString();
                roleDesc = gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcDesc").ToString();
                rolePerms = string.Empty;
                foreach (string permission in gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcPerm").ToString().Replace(Environment.NewLine, string.Empty).Split(','))
                {
                    if (permission != "")
                    {
                        rolePerms = rolePerms + "," + permission;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoleManagement frmRm = new frmRoleManagement(string.Empty, "Add", string.Empty, string.Empty, string.Empty);
                DialogResult dr = frmRm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getRoles();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoleManagement frmRm = new frmRoleManagement(id, "Edit", roleName, roleDesc, rolePerms);
                DialogResult dr = frmRm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getRoles();
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
                if (gvRoles.SelectedRowsCount > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure tou wish to remove the role " + roleName, "RTIS Ares - Role Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string deleted = Client.RemoveRole(id);
                        switch (deleted.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success!", "Role " + roleName + " has been updated", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                getRoles();
                                break;
                            case "0":
                                deleted = deleted.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", deleted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                deleted = deleted.Remove(0, 3);
                                errMsg = deleted.Split('|')[0];
                                errInfo = deleted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                deleted = deleted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", deleted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "An unexpected error occurred while deleting the role";
                                errInfo = "An unexpected error occurred while deleting the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
                                break;
                        }
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot delete role", "Please select a role to delete", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                getRoles();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvRoles.SelectedRowsCount > 0)
                {
                    bool activity = Convert.ToBoolean(gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcActive"));
                    switch (activity)
                    {
                        case true:
                            DialogResult resultD = MessageBox.Show("Are you sure tou wish to deactivate the role " + roleName, "RTIS Ares - Role Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultD == DialogResult.Yes)
                            {
                                string deactivated = Client.ToggleRoleActivity(id + "|" + Convert.ToString(gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcActive")));
                                switch (deactivated.Split('*')[0])
                                {
                                    case "1":
                                        msg = new frmMsg("Success!", "Role " + roleName + " has been deactivated", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        getRoles();
                                        break;
                                    case "0":
                                        deactivated = deactivated.Remove(0, 2);
                                        msg = new frmMsg("The following server side issue was encountered:", deactivated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    case "-1":
                                        deactivated = deactivated.Remove(0, 3);
                                        errMsg = deactivated.Split('|')[0];
                                        errInfo = deactivated.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        deactivated = deactivated.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", deactivated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred while deactivating the role";
                                        errInfo = "An unexpected error occurred while deactivating the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deactivated;
                                        break;
                                }
                            }
                            break;
                        case false:
                            DialogResult resultA = MessageBox.Show("Are you sure tou wish to activate the role " + roleName, "RTIS Ares - Role Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultA == DialogResult.Yes)
                            {
                                string activated = Client.ToggleRoleActivity(id + "|" + Convert.ToString(gvRoles.GetRowCellValue(gvRoles.FocusedRowHandle, "gcActive")));
                                switch (activated.Split('*')[0])
                                {
                                    case "1":
                                        msg = new frmMsg("Success!", "Role " + roleName + " has been activated", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        getRoles();
                                        break;
                                    case "0":
                                        activated = activated.Remove(0, 2);
                                        msg = new frmMsg("The following server side issue was encountered:", activated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    case "-1":
                                        activated = activated.Remove(0, 3);
                                        errMsg = activated.Split('|')[0];
                                        errInfo = activated.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        activated = activated.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", activated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred while activating the role";
                                        errInfo = "An unexpected error occurred while activating the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + activated;
                                        break;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot change role activity", "Please select a role", GlobalVars.msgState.Error);
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
