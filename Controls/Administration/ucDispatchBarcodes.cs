using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using System.Threading;
using RTIS_Vulcan_UI.Classes;

namespace RTIS_Vulcan_UI.Controls.Administration
{
    public partial class ucDispatchBarcodes : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtItems = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;

        public ucDispatchBarcodes()
        {
            InitializeComponent();
        }

        private void ucDispatchBarcodes_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcSONum", typeof(string));
            dtItems.Columns.Add("gcClear", typeof(string));

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnClear = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnClear.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnClear });
            ribtnClear.Click += RibtnClear_Click;
            gcClear.ColumnEdit = ribtnClear;
            gcClear.Width = 93;
            gcClear.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnClear.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("", "Are you sure you wish to clear the unique barcodes for this Sales Order?", GlobalVars.msgState.Question);
                msg.ShowDialog();
                if (msg.DialogResult == DialogResult.Yes)
                {
                    string soNumber = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcSONum").ToString();
                    string cleared = Client.ClearDispatchUnqs(soNumber);
                    switch (cleared.Split('*')[0])
                    {
                        case "1":
                            refreshItems();
                            break;
                        case "0":
                            cleared = cleared.Remove(0, 2);
                            msg = new frmMsg("Powder Manufacture", "No Manufacturing Remaining For Powder...", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            cleared = cleared.Remove(0, 3);
                            errMsg = cleared.Split('|')[0];
                            errInfo = cleared.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            cleared = cleared.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", cleared, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving Powder Prep Manufacture items";
                            errInfo = "Unexpected error while retreiving  Powder Prep Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + cleared;
                            break;
                    }
                }                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            Thread thread = new Thread(getDispatchLines);
            thread.Start();
        }
        public void getDispatchLines()
        {
            dataLines = Client.GetDispatchUnqs();
            dataPulled = true;
            ppnlWait.Visible = false;
            if (IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    setDispatchLines();
                });
            }
        }
        public void setDispatchLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    string whseTransferLines = dataLines;
                    if (whseTransferLines != string.Empty)
                    {
                        switch (whseTransferLines.Split('*')[0])
                        {
                            case "1":
                                dtItems.Rows.Clear();
                                whseTransferLines = whseTransferLines.Remove(0, 2);
                                string[] allTransferLines = whseTransferLines.Split('~');
                                foreach (string transferLine in allTransferLines)
                                {
                                    if (transferLine != string.Empty)
                                    {
                                        dtItems.Rows.Add(transferLine.Split('|'));
                                    }
                                }

                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtItems.Rows.Clear();
                                ppnlWait.SendToBack();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                whseTransferLines = whseTransferLines.Remove(0, 3);
                                errMsg = whseTransferLines.Split('|')[0];
                                errInfo = whseTransferLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                whseTransferLines = whseTransferLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", whseTransferLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving sales orders";
                                errInfo = "Unexpected error while retreiving sales orders" + Environment.NewLine + "Data Returned:" + Environment.NewLine + whseTransferLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
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
    }
}
