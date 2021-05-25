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
using RTIS_Vulcan_UI.Classes;
using System.Threading;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucPowderPrepRecords : UserControl
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

        public ucPowderPrepRecords()
        {
            InitializeComponent();
        }
        private void ucPowderPrepRecords_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
            refreshItems();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcCode", typeof(string));
            dtItems.Columns.Add("gcDesc", typeof(string));
            dtItems.Columns.Add("gcLot", typeof(string));
            dtItems.Columns.Add("gcQty", typeof(string));
            dtItems.Columns.Add("gcUserAdded", typeof(string));
            dtItems.Columns.Add("gcDateAdded", typeof(string));
            dtItems.Columns.Add("gcManuf", typeof(bool));
            dtItems.Columns.Add("gcDateManuf", typeof(string));
            dtItems.Columns.Add("gcUserManuf", typeof(string));
            dtItems.Columns.Add("gcTransferred", typeof(bool));
            dtItems.Columns.Add("gcDateTransferred", typeof(string));
            dtItems.Columns.Add("gcUserTransferred", typeof(string));
            dtItems.Columns.Add("gcReceived", typeof(bool));
            dtItems.Columns.Add("gcDateReceived", typeof(string));
            dtItems.Columns.Add("gcUserReceived", typeof(string));
            dtItems.Columns.Add("gcUserEdited", typeof(string));
            dtItems.Columns.Add("gcDateEdited", typeof(string));
            dtItems.Columns.Add("gcEditReason", typeof(string));
            dtItems.Columns.Add("gcOldQty", typeof(string));
        }
        public void refreshItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getItemLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getItemLines()
        {
            try
            {
                string StartDate = dtpStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:01";
                string EndDate = dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                dataLines = Client.GetPowderPrepRecordsByDate(StartDate + "|" + EndDate);
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setItemLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setItemLines()
        {
            try
            {
                if (dataPulled == true)
                {
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
                                        string[] itemS = item.Split('|');
                                        dtItems.Rows.Add(item.Split('|'));
                                    }
                                }
                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtItems.Rows.Clear();
                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("PGM Manufacture", "No Manufacturing Remaining For PGM...", GlobalVars.msgState.Success);
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
                                msgStr = "Unexpected error while retreiving PGM Manufacture items";
                                errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshItems();
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGenInfo = new DataTable();
                dtGenInfo.Columns.Add("gcName");
                dtGenInfo.Columns.Add("gcValue");

                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvItems.Columns)
                {
                    string item = column.Caption + "|" + gvItems.GetRowCellValue(gvItems.FocusedRowHandle, column.FieldName).ToString();
                    dtGenInfo.Rows.Add(item.Split('|'));
                }

                frmItemDetails veiwItem = new frmItemDetails(dtGenInfo);
                veiwItem.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public DateTime getEndDate(DateTime minDate)
        {
            return minDate.AddDays(1);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = getEndDate(dtpStartDate.Value);
        }
    }
}
