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

namespace RTIS_Vulcan_UI.Forms.Fresh_Slurries
{
    public partial class frmFreshSlurryRaws : Form
    {
        DataTable dt = new DataTable();

        DataTable dtRaw = new DataTable();

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public string itemCode { get; set; }
        public string itemDesc { get; set; }
        public frmFreshSlurryRaws(string _itemCode, string _itemDesc)
        {
            InitializeComponent();
            itemCode = _itemCode;
            itemDesc = _itemDesc;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnRemove = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnRemove.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnRemove });
            ribtnRemove.Click += RibtnRemove_Click;
            gcRemove.ColumnEdit = ribtnRemove;
            gcRemove.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnRemove.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnAdd = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnAdd.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnAdd });
            ribtnAdd.Click += RibtnAdd_Click;   
            gcAdd.ColumnEdit = ribtnAdd;
            gcAdd.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnAdd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string rmCode = gvRaws.GetRowCellValue(gvRaws.FocusedRowHandle, "gcRMCode").ToString();
                string rmDesc = gvRaws.GetRowCellValue(gvRaws.FocusedRowHandle, "gcRMDesc").ToString();
                string added = Client.addFreshSlurryLink(itemCode + "|" + rmCode + "|" + rmDesc + "|" + GlobalVars.userName);
                if (added != string.Empty)
                {
                    switch (added.Split('*')[0])
                    {
                        case "1":
                            getCurrentRaws();
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
                            msgStr = "Unexpected error while retreiving purchase order items";
                            errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
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
        private void RibtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string rmCode = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                string deleted = Client.removeFreshSlurryLink(itemCode + "|" + rmCode);
                if (deleted.Split('*')[0] != string.Empty)
                {
                    switch (deleted.Split('*')[0])
                    {
                        case "1":
                            getCurrentRaws();
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
                            msgStr = "Unexpected error while retreiving purchase order items";
                            errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
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
        private void frmFreshSlurryRaws_Load(object sender, EventArgs e)
        {
            lblCode.Text = itemCode;
            lblDesc.Text = itemDesc;
            lblRawCode.Text = itemCode;
            lblRawDesc.Text = itemDesc;
            setupDataTable();
            getCurrentRaws();
            pnlAvailable.BringToFront();
        }
        public void setupDataTable()
        {
            try
            {
                dt.Columns.Add("gcCode", typeof(string));
                dt.Columns.Add("gcDesc", typeof(string));
                dt.Columns.Add("gcRemove", typeof(string));

                dtRaw.Columns.Add("gcRMCode", typeof(string));
                dtRaw.Columns.Add("gcRMDesc", typeof(string));
                dtRaw.Columns.Add("gcAdd", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getCurrentRaws()
        {
            try
            {
                string itemRaws = Client.GetFreshSlurriesRMs(itemCode);
                if (itemRaws != string.Empty)
                {
                    switch (itemRaws.Split('*')[0])
                    {
                        case "1":
                            dt.Rows.Clear();
                            itemRaws = itemRaws.Remove(0, 2);
                            string[] ItemArray = itemRaws.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dt.Rows.Add(item.Split('|'));
                                }
                            }
                            dgItems.DataSource = dt;
                            dgItems.MainView.GridControl.DataSource = dgItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            pnlAvailable.BringToFront();
                            break;
                        case "0":
                            //itemRaws = itemRaws.Remove(0, 2);
                            //msg = new frmMsg("The following server side issue was encountered:", itemRaws, GlobalVars.msgState.Error);
                            //msg.ShowDialog();
                            break;
                        case "-1":
                            itemRaws = itemRaws.Remove(0, 3);
                            errMsg = itemRaws.Split('|')[0];
                            errInfo = itemRaws.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            itemRaws = itemRaws.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemRaws, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving purchase order items";
                            errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemRaws;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dtRaw.Rows.Clear();
                GetFreshSlurryRMs();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void GetFreshSlurryRMs()
        {
            string itemRaws = Client.GetAllFreshSlurriesRMs();
                if (itemRaws != string.Empty)
                {
                    switch (itemRaws.Split('*')[0])
                    {
                        case "1":
                            itemRaws = itemRaws.Remove(0, 2);
                            string[] ItemArray = itemRaws.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtRaw.Rows.Add(item.Split('|'));
                                }
                            }
                            dgRMs.DataSource = dtRaw;
                            dgRMs.MainView.GridControl.DataSource = dgRMs;
                            dgRMs.MainView.GridControl.EndUpdate();
                            pnlAddRMs.BringToFront();
                            break;
                        case "0":
                            itemRaws = itemRaws.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", itemRaws, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            itemRaws = itemRaws.Remove(0, 3);
                            errMsg = itemRaws.Split('|')[0];
                            errInfo = itemRaws.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            itemRaws = itemRaws.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemRaws, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving purchase order items";
                            errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemRaws;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlAvailable.BringToFront();
        }
    }
}
