using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RTIS_Vulcan_UI.Classes;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace RTIS_Vulcan_UI.Controls.Transfer_Management
{
    public partial class ucTransferRequests : UserControl
    {
        DataTable dtTransfers = new DataTable();
        string dataLines = string.Empty;
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public ucTransferRequests()
        {
            InitializeComponent();
        }
        private void ucTransferRequests_Load(object sender, EventArgs e)
        {
            setUpDatatables();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(1);
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }
        public void setUpDatatables()
        {
            dtTransfers.Columns.Add("gcID", typeof(string));
            dtTransfers.Columns.Add("gcCode", typeof(string));
            dtTransfers.Columns.Add("gcLot", typeof(string));
            dtTransfers.Columns.Add("gcFrom", typeof(string));
            dtTransfers.Columns.Add("gcTo", typeof(string));
            dtTransfers.Columns.Add("gcQty", typeof(string));
            dtTransfers.Columns.Add("gcQtyOnHand", typeof(string));
            dtTransfers.Columns.Add("gcUsername", typeof(string));
            dtTransfers.Columns.Add("gcProcess", typeof(string));
            dtTransfers.Columns.Add("gcDateTrans", typeof(string));
            dtTransfers.Columns.Add("gcWarnings", typeof(string));
            dtTransfers.Columns.Add("gcSave", typeof(string));

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnSave = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnSave.Buttons[0].Width = 85;
            dgTransfers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnSave });
            ribtnSave.Click += RibtnSave_Click;
            gcSave.ColumnEdit = ribtnSave;
            gcSave.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnSave.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }

        private void RibtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string id = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcID").ToString();
                string warnings = gvTransfers.GetRowCellValue(gvTransfers.FocusedRowHandle, "gcWarnings").ToString();
                if (warnings == string.Empty)
                {
                    attemptTransfer(id);
                }
                else
                {
                    using (msg = new frmMsg("", "Due to the listed warnings this transfer will most likely fail, are you sure you wish to continue?", GlobalVars.msgState.Question)) 
                    {
                        msg.ShowDialog();
                        if (msg.DialogResult == DialogResult.Yes)
                        {
                            attemptTransfer(id);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void attemptTransfer(string id)
        {
            try
            {
                string transferred = Client.transferFGItem(id + "|" + GlobalVars.userName);
                if (transferred != string.Empty)
                {
                    switch (transferred.Split('*')[0])
                    {
                        case "1":
                            using (msg = new frmMsg("FG Transfer requests", "The item has been sucessfully transferred", GlobalVars.msgState.Success))
                            {
                                msg.ShowDialog();
                                refreshRecords();
                            }
                            break;
                        case "0":
                            transferred = transferred.Remove(0, 2);
                            using (msg = new frmMsg("FG Transfer requests", transferred, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        case "-1":
                            ppnlWait.SendToBack();
                            transferred = transferred.Remove(0, 3);
                            errMsg = transferred.Split('|')[0];
                            errInfo = transferred.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            ppnlWait.SendToBack();
                            transferred = transferred.Remove(0, 2);
                            using (msg = new frmMsg("A connection level error has occured", transferred, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }                            
                            break;
                        default:
                            ppnlWait.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + transferred;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    ppnlWait.SendToBack();
                    using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }
                }              
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshRecords()
        {
            try
            {
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getWhseTransferLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getWhseTransferLines()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01";
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                dataLines = Client.getFGtransferRequestLines(StartDate + "|" + EndDate);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setWhseTransferLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void  setWhseTransferLines()
        {
            try
            {
                string itemLines = dataLines;
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            dtTransfers.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtTransfers.Rows.Add(item.Split('|'));
                                }
                            }
                            dgTransfers.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.EndUpdate();
                            gvTransfers.RefreshData();


                            foreach (GridColumn item in gvTransfers.Columns)
                            {
                                item.BestFit();                                
                            }

                            ppnlWait.SendToBack();
                            break;
                        case "0":
                            dtTransfers.Rows.Clear();
                            dgTransfers.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.DataSource = dtTransfers;
                            dgTransfers.MainView.GridControl.EndUpdate();
                            gvTransfers.RefreshData();
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("FG Transfer requests", "No transfer requests were found for the given date range", GlobalVars.msgState.Info))
                            {
                                msg.ShowDialog();
                            }                            
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
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    ppnlWait.SendToBack();
                    using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }                    
                    
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshRecords();
        }

        private void gvTransfers_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string warning = gvTransfers.GetRowCellDisplayText(e.RowHandle, View.Columns["gcWarnings"]).ToString();
                    if (warning == string.Empty)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.BackColor2 = Color.LightGreen;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Salmon;
                        e.Appearance.BackColor2 = Color.Salmon;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }
    }
}
