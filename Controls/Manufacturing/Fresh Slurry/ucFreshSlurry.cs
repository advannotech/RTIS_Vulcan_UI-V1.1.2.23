using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using RTIS_Vulcan_UI.Classes;
using System.Threading;
using RTIS_Vulcan_UI.Forms.Fresh_Slurries;

namespace RTIS_Vulcan_UI.Controls.Manufacturing
{
    public partial class ucFreshSlurry : UserControl
    {
        DataTable dt = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public ucFreshSlurry()
        {
            InitializeComponent();
        }

        private void ucFreshSlurry_Load(object sender, EventArgs e)
        {
            setupDataTable();
            refreshSlurries();

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnView.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnView });
            ribtnView.Click += RibtnView_Click;
            gcView.ColumnEdit = ribtnView;
            gcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }

        private void RibtnView_Click(object sender, EventArgs e)
        {
            try
            {
                string itemCode = Convert.ToString(gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode"));
                string itemDesc = Convert.ToString(gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc"));
                frmFreshSlurryRaws zRaws = new frmFreshSlurryRaws(itemCode, itemDesc);
                zRaws.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        #region Load Slurries
        public void setupDataTable()
        {
            try
            {
                dt.Columns.Add("gcCode", typeof(string));
                dt.Columns.Add("gcDesc", typeof(string));
                dt.Columns.Add("gcDesc2", typeof(string));
                dt.Columns.Add("gcView", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshSlurries()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getSlurryLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getSlurryLines()
        {
            try
            {
                dataLines = Client.GetAllFreshSlurriesForRM();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setSlurryLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setSlurryLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    string itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dt.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);

                                string[] ItemArray = itemLines.Split('~');
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
                                //dgItems.RefreshData();
                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", itemLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 3);
                                errMsg = itemLines.Split('|')[0];
                                errInfo = itemLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving purchase order items";
                                errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        #endregion
    }
}
