using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms.Stock_Take
{
    public partial class frmSTTickets : Form
    {
        DataTable dt = new DataTable();
        bool recordsPulled = false;
        string dataLines = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        string headerID { get; set; }
        string itemCode { get; set; }
        string lotNumber { get; set; }
        bool isArchive { get; set; }

        public frmSTTickets(string _headerId, string _itemcode, string _lotnumber, bool _isArchive)
        {
            InitializeComponent();        
            headerID = _headerId;
            itemCode = _itemcode;
            lotNumber = _lotnumber;
            isArchive = _isArchive;
        }
        private void frmSTTickets_Load(object sender, EventArgs e)
        {
            lblItemCode.Text = itemCode;
            lblLotNumber.Text = lotNumber;
            SetUpTable();
            refreshItems();
        }
        public void SetUpTable()
        {
            dt.Columns.Add(new DataColumn("gcID"));
            dt.Columns.Add(new DataColumn("gcTicket"));
            dt.Columns.Add(new DataColumn("gcQty1"));
            dt.Columns.Add(new DataColumn("gcUser1"));
            dt.Columns.Add(new DataColumn("gcDate1"));
            dt.Columns.Add(new DataColumn("gcQty2"));
            dt.Columns.Add(new DataColumn("gcUser2"));
            dt.Columns.Add(new DataColumn("gcDate2"));
            dt.Columns.Add(new DataColumn("gcBarcodeType"));
            dt.Columns.Add(new DataColumn("gcValid", typeof(bool)));
            dt.Columns.Add(new DataColumn("gcRecount", typeof(bool)));
            dt.Columns.Add(new DataColumn("gcRemoveTicket"));

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnremoveTicket = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnremoveTicket.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnremoveTicket });
            ribtnremoveTicket.Click += RibtnremoveTicket_Click;
            gcRemoveTicket.ColumnEdit = ribtnremoveTicket;
            gcRemoveTicket.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnremoveTicket.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnremoveTicket_Click(object sender, EventArgs e)
        {
            try
            {
                string barcodeType = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcBarcodeType").ToString();
                switch (barcodeType)
                {
                    case "RT2D":
                        reverseTicketRT2D();
                        break;
                    case "FG Pallet":
                        reverseTicketPallet();
                        break;
                    case "RM Pallet":
                        reverseTicketRMPallet();
                        break;
                    default:
                        reverseTicket();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void reverseTicketRT2D()
        {
            string ticketNo = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcTicket").ToString();
            string removed = Client.ReverseTicketRT2D(headerID + "|" + ticketNo);
            if (removed != string.Empty)
            {
                switch (removed.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Succes!", "The ticket has been reversed", GlobalVars.msgState.Success);
                        refreshItems();
                        break;
                    case "0":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", removed, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        removed = removed.Remove(0, 3);
                        errMsg = removed.Split('|')[0];
                        errInfo = removed.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        removed = removed.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving item tickets";
                        errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
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
        public void reverseTicketPallet()
        {
            try
            {
                string ticketNo = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcTicket").ToString();
                string removed = Client.ReverseTicketPallet(headerID + "|" + ticketNo);
                if (removed != string.Empty)
                {
                    switch (removed.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Succes!", "The ticket has been reversed", GlobalVars.msgState.Success);
                            refreshItems();
                            break;
                        case "0":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            removed = removed.Remove(0, 3);
                            errMsg = removed.Split('|')[0];
                            errInfo = removed.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving item tickets";
                            errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
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
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void reverseTicketRMPallet()
        {
            try
            {
                string ticketNo = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcTicket").ToString();
                string removed = Client.ReverseTicketRMPallet(ticketNo);
                if (removed != string.Empty)
                {
                    switch (removed.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Succes!", "The ticket has been reversed", GlobalVars.msgState.Success);
                            refreshItems();
                            break;
                        case "0":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            removed = removed.Remove(0, 3);
                            errMsg = removed.Split('|')[0];
                            errInfo = removed.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving item tickets";
                            errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
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
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void reverseTicket()
        {
            try
            {
                string ticketNo = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcTicket").ToString();
                string removed = Client.ReverseTicket(headerID + "|" + ticketNo);
                if (removed != string.Empty)
                {
                    switch (removed.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Succes!", "The ticket has been reversed", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            refreshItems();
                            break;
                        case "0":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            removed = removed.Remove(0, 3);
                            errMsg = removed.Split('|')[0];
                            errInfo = removed.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            removed = removed.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", removed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving item tickets";
                            errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + removed;
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
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }           
        }
        public void refreshItems()
        {
            try
            {
                ppnlWait.BringToFront();
                recordsPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getItemLineTickets);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void getItemLineTickets()
        {
            try
            {
                if (!isArchive)
                {
                    dataLines = Client.GetSTLineTickets(headerID);
                }
                else
                {
                    dataLines = Client.GetSTLineTicketsArchive(headerID);
                    gcRemoveTicket.Visible = false;
                }
                
                recordsPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setItemLineTickets();
                    });
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ExHandler.showErrorEx(ex);
                });          
            }
        }
        private void setItemLineTickets()
        {
            try
            {
                if (recordsPulled == true)
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
                                ppnlWait.SendToBack();
                                recordsPulled = false;
                                break;
                            case "0":
                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                //msg = new frmMsg("The following server side issue was encountered:", itemLines, GlobalVars.msgState.Info);
                                //msg.ShowDialog();
                                dt.Rows.Clear();
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
                                msgStr = "Unexpected error while retreiving item tickets";
                                errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
    }
}
