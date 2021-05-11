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
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.PGM
{
    public partial class frmPGMManufacture : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtPGMLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;
        public string itemCode { get; set; }
        public string lotNumber { get; set; }
        public string location { get; set; }
        public string concentration { get; set; }
        public string total { get; set; }
        public string rem { get; set; }
        public bool remCaptured { get; set; }
        public bool changed = false;
        public frmPGMManufacture(string _itemCode, string _lotNumber, string _location, string _concentration, string _total, string _rem, bool _remCaptured)
        {
            InitializeComponent();
            itemCode = _itemCode;
            lotNumber = _lotNumber;
            location = _location;
            concentration = _concentration;
            total = _total;
            rem = _rem;
            remCaptured = _remCaptured;
        }
        private void frmPGMManufacture_Load(object sender, EventArgs e)
        {
            setupPGMDataTable();
            refreshPGMItems();

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnManuf = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnManuf.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnManuf });
            ribtnManuf.Click += RibtnManuf_Click;
            gcManufacture.ColumnEdit = ribtnManuf;
            gcManufacture.Width = 93;
            gcManufacture.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnEdit.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnEdit });
            ribtnEdit.Click += RibtnEdit_Click;
            gcEdit.ColumnEdit = ribtnEdit;
            gcEdit.Width = 93;
            gcEdit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            lblCont.Text = total;
            lblRem.Text = rem;
            lblMan.Text = Convert.ToString(Convert.ToDecimal(total.Replace(".", GlobalVars.sep).Replace(".", GlobalVars.sep)) + Convert.ToDecimal(rem.Replace(".", GlobalVars.sep).Replace(".", GlobalVars.sep)));
        }
        public void setupPGMDataTable()
        {
            try
            {
                dtPGMLines.Columns.Add("gcCont", typeof(string));
                dtPGMLines.Columns.Add("gcWeight", typeof(string));
                dtPGMLines.Columns.Add("gcUserAdded", typeof(string));
                dtPGMLines.Columns.Add("gcDateAdded", typeof(string));
                dtPGMLines.Columns.Add("gcManufacture", typeof(string));
                dtPGMLines.Columns.Add("gcEdit", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshPGMItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                //tmrItems.Start();
                Thread thread = new Thread(getPGMLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getPGMLines()
        {
            try
            {
                dataLines = Client.GetPGMManufactureContainers(itemCode + "|" + lotNumber + "|" + location + "|" + concentration);
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

                    #region PGM

                    itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dtPGMLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtPGMLines.Rows.Add(item.Split('|'));
                                    }
                                }
                                dgItems.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.EndUpdate();
                                gvItems.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtPGMLines.Rows.Clear();
                                dgItems.DataSource = dtPGMLines;
                                dgItems.MainView.GridControl.DataSource = dtPGMLines;
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

                    #endregion

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
            //try
            //{
            //    int index = gvItems.FocusedRowHandle;
            //    string container = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCont").ToString();
            //    string qty = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcWeight").ToString();
            //    msg = new frmMsg("Confirm Manufacture", "Confirm Manufacture" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + qty + Environment.NewLine + "Container : " + container, GlobalVars.msgState.Question);
            //    msg.ShowDialog();
            //    DialogResult res = msg.DialogResult;
            //    if (res == DialogResult.Yes)
            //    {
            //        string manufactured = Client.ManufacturePGMContainer(itemCode + "|" + lotNumber + "|" + location + "|" + concentration + "|" + container + "|" + qty + "|" + GlobalVars.userName);
            //        if (manufactured != string.Empty)
            //        {
            //            switch (manufactured.Split('*')[0])
            //            {
            //                case "1":
            //                    changed = true;
            //                    msg = new frmMsg("Success", "The container has been manufactured", GlobalVars.msgState.Success);
            //                    msg.ShowDialog();
            //                    gvItems.DeleteRow(index);
            //                    total = Convert.ToString(Convert.ToDecimal(total.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)) - Convert.ToDecimal(qty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)));
            //                    break;
            //                case "0":
            //                    changed = true;
            //                    manufactured = manufactured.Remove(0, 2);
            //                    msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error);
            //                    msg.ShowDialog();
            //                    gvItems.DeleteRow(index);
            //                    total = Convert.ToString(Convert.ToDecimal(total.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)) - Convert.ToDecimal(qty.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep)));
            //                    break;
            //                case "-1":
            //                    manufactured = manufactured.Remove(0, 3);
            //                    errMsg = manufactured.Split('|')[0];
            //                    errInfo = manufactured.Split('|')[1];
            //                    ExHandler.showErrorStr(errMsg, errInfo);
            //                    break;
            //                default:
            //                    msgStr = "Unexpected error while manufacturing container";
            //                    errInfo = "Unexpected error while manufacturing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + manufactured;
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
            //            msg.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExHandler.showErrorEx(ex);
            //}
        }
        private void btnManufacture_Click(object sender, EventArgs e)
        {
            try
            {
                if (remCaptured)
                {
                    msg = new frmMsg("Confirm Manufacture", "Confirm Manufacture" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + lblMan.Text, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.ManufacturePGMBatch(itemCode + "|" + lotNumber + "|" + location + "|" + concentration + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                changed = true;
                                msg = new frmMsg("Success", "The batch has been manufactured", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "0":
                                changed = true;
                                manufactured = manufactured.Remove(0, 2);
                                using (msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
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
                else
                {
                    using (msg = new frmMsg("Auto Manufacture Error", "Cannot manufacture the PGM as the remainder has not been captured!", GlobalVars.msgState.Error))
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
        private void RibtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string container = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCont").ToString();
                string qty = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcWeight").ToString();
                frmEditPGM edit = new frmEditPGM(itemCode, lotNumber, container, qty, location);
                edit.ShowDialog();
                if (edit.DialogResult == DialogResult.OK)
                {
                    refreshPGMItems();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (remCaptured)
                {
                    string oldVal = lblRem.Text.Replace(",", ".");
                    using (frmQty qty = new frmQty(oldVal.Split('.')[0], oldVal.Split('.')[1]))
                    {
                        qty.ShowDialog();
                        if (qty.DialogResult != DialogResult.OK) return;
                        string newVal = qty.qty.ToString();
                        string updated = Client.UpdatePGMRemainder(itemCode + "|" + lotNumber + "|" + location + "|" + concentration + "|" + newVal + "|" + GlobalVars.userName);
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                using (msg = new frmMsg("Success", "The remainder has been updated!", GlobalVars.msgState.Success))
                                {
                                    msg.ShowDialog();
                                }
                                changed = true;
                                lblRem.Text = newVal;
                                lblMan.Text = Convert.ToString(Convert.ToDecimal(total.Replace(".", GlobalVars.sep).Replace(".", GlobalVars.sep)) + Convert.ToDecimal(newVal.Replace(".", GlobalVars.sep).Replace(".", GlobalVars.sep)));
                                break;
                            case "0":
                                updated = updated.Remove(0, 2);
                                using (msg = new frmMsg("Auto Manufacture Error", updated, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                                this.Close();
                                break;
                            case "-1":
                                updated = updated.Remove(0, 3);
                                errMsg = updated.Split('|')[0];
                                errInfo = updated.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                }
                else
                {
                    using (msg = new frmMsg("Auto Manufacture Error", "Cannot edit the remainder as it has not yet been captured!", GlobalVars.msgState.Error))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("", "Are you sure you wish to mark this as manufactured?" + Environment.NewLine + "Item Code : " + itemCode + Environment.NewLine + "Lot Number : " + lotNumber + Environment.NewLine + "Quantity : " + lblMan.Text, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.ManufacturePGMBatchManual(itemCode + "|" + lotNumber + "|" + location + "|" + concentration + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                changed = true;
                                msg = new frmMsg("Success", "The batch has been manufactured", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.Close();
                                break;
                            case "0":
                                changed = true;
                                manufactured = manufactured.Remove(0, 2);
                                using (msg = new frmMsg("Auto Manufacture Error", manufactured, GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
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
