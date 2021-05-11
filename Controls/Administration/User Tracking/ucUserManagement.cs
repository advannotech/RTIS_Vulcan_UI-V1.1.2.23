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
using System.Threading;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucUserManagement : UserControl
    {
        DataTable dt = new DataTable();
        string dataLines = string.Empty;
        bool recordsPulled = false;

        public string id = string.Empty;
        public string name = string.Empty;
        public string username = string.Empty;
        public string role = string.Empty;
        public string pin = string.Empty;
        public string password = string.Empty;
        public bool hasAgent = false;
        public string evoAgent = string.Empty;

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
                dt.Columns.Add(new DataColumn("gcUsername", typeof(string)));
                dt.Columns.Add(new DataColumn("gcPin", typeof(string)));
                dt.Columns.Add(new DataColumn("gcPassword", typeof(string)));
                dt.Columns.Add(new DataColumn("gcRole", typeof(string)));
                dt.Columns.Add(new DataColumn("gcActive", typeof(bool)));
                dt.Columns.Add(new DataColumn("gcHasAgent", typeof(bool)));
                dt.Columns.Add(new DataColumn("gcAgent", typeof(string)));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }         
        }
        public void bindDataGrid()
        {
            dgUsers.DataSource = dt;
            dgUsers.MainView.GridControl.DataSource = dt;
            dgUsers.MainView.GridControl.EndUpdate();
        }
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            recordsPulled = false;
            Application.DoEvents();
            tmrItems.Start();
            Thread thread = new Thread(getDataLines);
            thread.Start();
        }
        public void getDataLines()
        {
            try
            {
                dataLines = Client.getAllUsers();
                recordsPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setDataLines()
        {
            try
            {
                if (recordsPulled == true)
                {
                    tmrItems.Stop();
                    if (dataLines != string.Empty)
                    {
                        switch (dataLines.Split('*')[0])
                        {
                            case "1":
                                dt.Rows.Clear();
                                dataLines = dataLines.Remove(0, 2);
                                string[] allLines = dataLines.Split('~');
                                foreach (string line in allLines)
                                {
                                    if (line != string.Empty)
                                    {
                                        dt.Rows.Add(line.Split('|'));
                                    }
                                }
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dt.Rows.Clear();
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                dataLines = dataLines.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", dataLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                dt.Rows.Clear();
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                dataLines = dataLines.Remove(0, 3);
                                errMsg = dataLines.Split('|')[0];
                                errInfo = dataLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                dt.Rows.Clear();
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                dataLines = dataLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", dataLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                dt.Rows.Clear();
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "An unexpected error occurred while deleting the role";
                                errInfo = "An unexpected error occurred while deleting the role" + Environment.NewLine + "Data Returned:" + Environment.NewLine + dataLines;
                                break;
                        }
                    }
                    else
                    {
                        dt.Rows.Clear();
                        bindDataGrid();
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                dt.Rows.Clear();
                bindDataGrid();
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        public ucUserManagement()
        {
            InitializeComponent();
        }
        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setDataLines();
        }
        private void ucUserManagement_Load(object sender, EventArgs e)
        {
            setupTable();
            refreshItems();
        }
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserManagement frmUm = new frmUserManagement(string.Empty, "Add", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, false, string.Empty);
                DialogResult dr = frmUm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    refreshItems();
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
                frmUserManagement frmUm = new frmUserManagement(id, "Edit", name, username, role, pin, password, hasAgent, evoAgent);
                DialogResult dr = frmUm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    refreshItems();
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
                if (gvUsers.SelectedRowsCount > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure tou wish to remove the user " + name, "RTIS Ares - User Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string deleted = Client.RemoveUser(id);
                        if (deleted != string.Empty)
                        {
                            switch (deleted.Split('*')[0])
                            {
                                case "1":
                                    msg = new frmMsg("Success!", "User " + name + " has been removed", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    refreshItems();                          
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
                                    msgStr = "Unexpected error while updating the user";
                                    errInfo = "Unexpected error while updating the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
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
                else
                {
                    msg = new frmMsg("Cannot delete user", "Please select a user to delete", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
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
                if (gvUsers.SelectedRowsCount > 0)
                {
                    bool activity = Convert.ToBoolean(gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcActive"));
                    switch (activity)
                    {
                        case true:
                            DialogResult resultD = MessageBox.Show("Are you sure tou wish to deactivate the user " + username, "RTIS Vulcan - User Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultD == DialogResult.Yes)
                            {
                                string deactivated = Client.ToggleUserActive(id + "|" + Convert.ToString(activity));
                                if (deactivated != string.Empty)
                                {
                                    switch (deactivated.Split('*')[0])
                                    {
                                        case "1":
                                            msg = new frmMsg("Success!", "User " + name + " has been deactivated", GlobalVars.msgState.Success);
                                            msg.ShowDialog();
                                            refreshItems();
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
                                            msgStr = "Unexpected error while updating the user";
                                            errInfo = "Unexpected error while updating the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deactivated;
                                            break;
                                    }
                                }
                                else
                                {
                                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                }
                            }
                            break;
                        case false:
                            DialogResult resultA = MessageBox.Show("Are you sure tou wish to activate the user " + username, "RTIS Vulcan - User Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultA == DialogResult.Yes)
                            {
                                string activated = Client.ToggleUserActive(id + "|" + Convert.ToString(activity));
                                if (activated != string.Empty)
                                {
                                    switch (activated.Split('*')[0])
                                    {
                                        case "1":
                                            msg = new frmMsg("Success!", "User " + name + " has been activated", GlobalVars.msgState.Success);
                                            msg.ShowDialog();
                                            refreshItems();
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
                                            msgStr = "Unexpected error while updating the user";
                                            errInfo = "Unexpected error while updating the user" + Environment.NewLine + "Data Returned:" + Environment.NewLine + activated;
                                            break;
                                    }
                                }
                                else
                                {
                                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                }
                            }
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot change user activity", "Please select a user to alter", GlobalVars.msgState.Error);
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
            refreshItems();
        }
        private void dgUsers_Click(object sender, EventArgs e)
        {
            try
            {
                id = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcID").ToString();
                name = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcName").ToString();
                username = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcUsername").ToString();
                role = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcRole").ToString();
                pin = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcPin").ToString();
                password = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcPassword").ToString();
                hasAgent = Convert.ToBoolean(gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcHasAgent").ToString());
                evoAgent = gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "gcAgent").ToString();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
