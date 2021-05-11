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

namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    public partial class frmZectManufacture : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtZECTLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;

        public string id { get; set; }
        public string itemCode { get; set; }
        public string lotNumber { get; set; }
        public string total { get; set; }
        public string zLine { get; set; }
        public bool changed { get; set; }
        public frmZectManufacture(string _id, string _itemCode, string _lotNumber, string _total, string _zLine)
        {
            InitializeComponent();
            id = _id;
            itemCode = _itemCode;
            lotNumber = _lotNumber;
            total = _total;
            zLine = _zLine;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnManuf = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnManuf.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnManuf });
            ribtnManuf.Click += RibtnManuf_Click;
            gcManuf.ColumnEdit = ribtnManuf;
            gcManuf.Width = 93;
            gcManuf.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void frmZectManufacture_Load(object sender, EventArgs e)
        {
            setupZECTDataTable();
            refreshZectItems();
        }
        public void setupZECTDataTable()
        {
            try
            {
                dtZECTLines.Columns.Add("gcID", typeof(string));
                dtZECTLines.Columns.Add("gcPalletCode", typeof(string));
                dtZECTLines.Columns.Add("gcPalletNo", typeof(string));
                dtZECTLines.Columns.Add("gcQty", typeof(string));
                dtZECTLines.Columns.Add("gcDate", typeof(string));
                dtZECTLines.Columns.Add("gcUserAdded", typeof(string));
                dtZECTLines.Columns.Add("gcManuf", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshZectItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                //tmrItems.Start();
                Thread thread = new Thread(getZECtLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getZECtLines()
        {
            try
            {
                dataLines = Client.GetZECTManufacturePallets(id);
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setLines();
                    });
                }
            }
            catch (Exception ex)
            {
                //tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }
        public void setLines()
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
                                dtZECTLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtZECTLines.Rows.Add(item.Split('|'));
                                    }
                                }
                                dgItems.DataSource = dtZECTLines;
                                dgItems.MainView.GridControl.DataSource = dtZECTLines;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtZECTLines.Rows.Clear();
                                dgItems.DataSource = dtZECTLines;
                                dgItems.MainView.GridControl.DataSource = dtZECTLines;
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
        private void RibtnManuf_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvItems.FocusedRowHandle;
                string lineID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcID").ToString();
                string pallet = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcPalletNo").ToString();
                string qty = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcQty").ToString();
                msg = new frmMsg("Confirm Manufacture", "Confirm Manufacture" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + qty + Environment.NewLine + "Pallet : " + pallet, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.ManufactureZectPallet(id + "|" + lineID + "|" + itemCode + "|" + lotNumber + "|" + qty  + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The pallet has been manufactured", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvItems.DeleteRow(index);
                                changed = true;
                                total = Convert.ToString(Convert.ToDecimal(total.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)) - Convert.ToDecimal(qty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)));
                                break;
                            case "0":
                                manufactured = manufactured.Remove(0, 2);
                                msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                gvItems.DeleteRow(index);
                                changed = true;
                                total = Convert.ToString(Convert.ToDecimal(total.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)) - Convert.ToDecimal(qty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)));
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + manufactured;
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
        private void btnManufacture_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("Confirm Manufacture", "Confirm Manufacture" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + total, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.ManufactureZectBatch(id + "|" + itemCode + "|" + lotNumber + "|" + GlobalVars.userName + "|" + zLine);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                changed = true;
                                msg = new frmMsg("Success", "The pallet has been manufactured", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "0":
                                changed = true;
                                manufactured = manufactured.Remove(0, 2);
                                msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("Confirm Manual Close", "Are you sure you want to manually close this job?" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + total, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.CloseZectBatch(id + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                changed = true;
                                msg = new frmMsg("Success", "The job has been closed", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "0":
                                changed = true;
                                manufactured = manufactured.Remove(0, 2);
                                msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
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
    }
}
