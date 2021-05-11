using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Purchase_Orders;

namespace RTIS_Vulcan_UI.Controls.Purchase_Orders
{
    public partial class ucCMSAdmin : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public bool dataPulled = false;
        public string dataLines = string.Empty;
        public ucCMSAdmin()
        {
            InitializeComponent();
        }
        private void ucCMSAdmin_Load(object sender, EventArgs e)
        {
            setupItemDataTable();
            setupUOMDataTable();
            refreshItems();
        }

        DataTable dtItems = new DataTable();
        private void setupItemDataTable()
        {
            try
            {
                dtItems.Columns.Add("gcItemID", typeof(string));
                dtItems.Columns.Add("gcItemValue", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnDeleteItem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnDeleteItem.Buttons[0].Width = 85;
                dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnDeleteItem });
                ribtnDeleteItem.Click += RibtnDeleteItem_Click;
                gcDeleteItem.ColumnEdit = ribtnDeleteItem;
                gcDeleteItem.Width = 93;
                gcDeleteItem.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnDeleteItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void refreshItems()
        {
            Application.DoEvents();
            Thread thread = new Thread(getItemLines);
            thread.Start();
        }
        private void getItemLines()
        {
            try
            {
                dataLines = Client.GetCMSItems();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setItemLine();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void setItemLine()
        {
            try
            {
                if (dataPulled == true)
                {
                    //tmrItems.Stop();
                    string itemLines = string.Empty;
                    itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dtItems.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|'); //.Replace(Convert.ToString((char)194), string.Empty)
                                        dtItems.Rows.Add(itemS);
                                    }
                                }
                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                dataPulled = false;
                                refreshUOMs();
                                break;
                            case "0":
                                dtItems.Rows.Clear();
                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                refreshUOMs();
                                break;
                            case "-1":
                                itemLines = itemLines.Remove(0, 3);
                                errMsg = itemLines.Split('|')[0];
                                errInfo = itemLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                itemLines = itemLines.Remove(0, 2);
                                using (msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retrieving data";
                                errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                ExHandler.showErrorST(st, msgStr, errInfo);
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
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCMSAdd add = new  frmCMSAdd(GlobalVars.cmsType.Item))
                {
                    add.ShowDialog();
                    if (add.DialogResult == DialogResult.OK)
                    {
                        refreshItems();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemID").ToString();
                string value = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemValue").ToString();
                using (msg = new frmMsg("", $"Are you sure you wish to delete {value}?", GlobalVars.msgState.Question))
                {
                    msg.ShowDialog();
                    if (msg.DialogResult == DialogResult.Yes)
                    {
                        string deleted = Client.DeleteCMSValue(id); //string.Join("~", test)
                    if (!string.IsNullOrWhiteSpace(deleted))
                    {
                        switch (deleted.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The cms item has been added", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                refreshItems();
                                break;
                            case "0":
                                deleted = deleted.Remove(0, 2);
                                using (msg = new frmMsg("The following server side issue was encountered:", deleted, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            case "-1":
                                deleted = deleted.Remove(0, 3);
                                errMsg = deleted.Split('|')[0];
                                errInfo = deleted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                deleted = deleted.Remove(0, 2);
                                using (msg = new frmMsg("A connection level error has occured", deleted, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retrieving data";
                                errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        using (msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error))
                        {
                            msg.ShowDialog();
                        }
                    }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        DataTable dtUOM = new DataTable();
        private void setupUOMDataTable()
        {
            try
            {
                dtUOM.Columns.Add("gcUOMID", typeof(string));
                dtUOM.Columns.Add("gcUOMValue", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnDeleteUOM = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnDeleteUOM.Buttons[0].Width = 85;
                dgUOM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnDeleteUOM });
                ribtnDeleteUOM.Click += RibtnDeleteUOM_Click;
                gcDeleteUOM.ColumnEdit = ribtnDeleteUOM;
                gcDeleteUOM.Width = 93;
                gcDeleteUOM.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnDeleteUOM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void refreshUOMs()
        {
            Application.DoEvents();
            Thread thread = new Thread(getUOMLines);
            thread.Start();
        }
        private void getUOMLines()
        {
            try
            {
                dataLines = Client.GetCMSUOMs();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setUOMLine();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void setUOMLine()
        {
            try
            {
                if (dataPulled == true)
                {
                    //tmrItems.Stop();
                    string itemLines = string.Empty;
                    itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dtUOM.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|'); //.Replace(Convert.ToString((char)194), string.Empty)
                                        dtUOM.Rows.Add(itemS);
                                    }
                                }
                                dgUOM.DataSource = dtUOM;
                                dgUOM.MainView.GridControl.DataSource = dtUOM;
                                dgUOM.MainView.GridControl.EndUpdate();
                                gvUOM.RefreshData();

                                dataPulled = false;
                                break;
                            case "0":
                                dtUOM.Rows.Clear();
                                dgUOM.DataSource = dtUOM;
                                dgUOM.MainView.GridControl.DataSource = dtUOM;
                                dgUOM.MainView.GridControl.EndUpdate();
                                gvUOM.RefreshData();

                                break;
                            case "-1":
                                itemLines = itemLines.Remove(0, 3);
                                errMsg = itemLines.Split('|')[0];
                                errInfo = itemLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                itemLines = itemLines.Remove(0, 2);
                                using (msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retrieving data";
                                errInfo = "Unexpected error while retrieving  data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
                        {
                            msg.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAddUOM_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCMSAdd add = new  frmCMSAdd(GlobalVars.cmsType.UOM))
                {
                    add.ShowDialog();
                    if (add.DialogResult == DialogResult.OK)
                    {
                        refreshItems();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnDeleteUOM_Click(object sender, EventArgs e)
        {
            try
            {
                string id = gvUOM.GetRowCellValue(gvUOM.FocusedRowHandle, "gcUOMID").ToString();
                string value = gvUOM.GetRowCellValue(gvUOM.FocusedRowHandle, "gcUOMValue").ToString();
                using (msg = new frmMsg("", $"Are you sure you wish to delete {value}?", GlobalVars.msgState.Question))
                {
                    msg.ShowDialog();
                    if (msg.DialogResult != DialogResult.Yes) return;
                    string deleted = Client.DeleteCMSValue(id); 
                    if (!string.IsNullOrWhiteSpace(deleted))
                    {
                        switch (deleted.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The cms item has been added", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                refreshItems();
                                break;
                            case "0":
                                deleted = deleted.Remove(0, 2);
                                using (msg = new frmMsg("The following server side issue was encountered:", deleted, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            case "-1":
                                deleted = deleted.Remove(0, 3);
                                errMsg = deleted.Split('|')[0];
                                errInfo = deleted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                deleted = deleted.Remove(0, 2);
                                using (msg = new frmMsg("A connection level error has occured", deleted, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retrieving data";
                                errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnRefreshItems_Click(object sender, EventArgs e)
        {
            refreshItems();
        }
    }
}
