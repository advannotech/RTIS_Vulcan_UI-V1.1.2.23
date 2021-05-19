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
using DevExpress.CodeParser;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Forms.PGM;
using DevExpress.XtraTab;
using RTIS_Vulcan_UI.Forms.Auto_Manufacture;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Controls.Manufacturing.PGM
{
    public partial class ucPGMManufacture : UserControl
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

        public ucPGMManufacture()
        {
            InitializeComponent();
        }

        private void ucPGMManufacture_Load(object sender, EventArgs e)
        {
            setupPGMDataTable();
            setupPowderDataTable();
            setupFSDataTable();
            SetupMixedSlurry();
            setupZECTDataTable();
            setupAWDataTable();
            setupcanningDataTable();
            refreshPGMItems();
        }

        #region PGM Manufacture

        DataTable dtPGMLines = new DataTable();

        public void setupPGMDataTable()
        {
            try
            {
                dtPGMLines.Columns.Add("gcCode", typeof(string));
                dtPGMLines.Columns.Add("gcLotNumber", typeof(string));
                dtPGMLines.Columns.Add("gcLocation", typeof(string));
                dtPGMLines.Columns.Add("gcConcentration", typeof(string));
                dtPGMLines.Columns.Add("gcQty", typeof(string));
                dtPGMLines.Columns.Add("gcRemCap", typeof(bool));
                dtPGMLines.Columns.Add("gcRem", typeof(string));
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
                dataLines = Client.GetPGMManufactureLines();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setPGMLines(); });
                }
            }
            catch (Exception ex)
            {
                //tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        public void setPGMLines()
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
                                msg = new frmMsg("PGM Manufacture", "No Manufacturing Remaining For PGM...",
                                    GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving PGM Manufacture items";
                                errInfo = "Unexpected error while retreiving  PGM Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshPGMItems();
        }

        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string itemCode = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                string lotNumber = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLotNumber").ToString();
                string location = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLocation").ToString();
                string concentration = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcConcentration").ToString();
                string total = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcQty").ToString();
                string rem = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRem").ToString();
                bool remCaptured =
                    Convert.ToBoolean(gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRemCap").ToString());
                frmPGMManufacture manuf = new frmPGMManufacture(itemCode, lotNumber, location, concentration, total,
                    rem, remCaptured);
                manuf.ShowDialog();
                if (manuf.changed == true)
                {
                    refreshPGMItems();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Powder Prep

        DataTable dtPowderines = new DataTable();

        public void setupPowderDataTable()
        {
            try
            {
                dtPowderines.Columns.Add("gcID", typeof(string));
                dtPowderines.Columns.Add("gcPCode", typeof(string));
                dtPowderines.Columns.Add("gcPDesc", typeof(string));
                dtPowderines.Columns.Add("gcPLot", typeof(string));
                dtPowderines.Columns.Add("gcPQty", typeof(string));
                dtPowderines.Columns.Add("gcPAdded", typeof(string));
                dtPowderines.Columns.Add("gcPDate", typeof(string));
                dtPowderines.Columns.Add("gcPManuf", typeof(string));
                dtPowderines.Columns.Add("gcPEdit", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnPManuf =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnPManuf.Buttons[0].Width = 85;
                dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnPManuf});
                ribtnPManuf.Click += RibtnPManuf_Click;
                gcPManuf.ColumnEdit = ribtnPManuf;
                gcPManuf.Width = 93;
                gcPManuf.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnPManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnClose =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnClose.Buttons[0].Width = 85;
                dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnClose});
                ribtnClose.Click += RibtnClose_Click1;
                gcPowderClose.ColumnEdit = ribtnClose;
                gcPowderClose.Width = 93;
                gcPowderClose.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnClose.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnPEdit =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnPEdit.Buttons[0].Width = 85;
                dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnPEdit});
                ribtnPEdit.Click += RibtnPEdit_Click;
                gcPEdit.ColumnEdit = ribtnPEdit;
                gcPEdit.Width = 93;
                gcPEdit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnPEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnClose_Click1(object sender, EventArgs e)
        {
            try
            {
                int index = gvPowders.FocusedRowHandle;
                string id = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcID").ToString();
                string code = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPCode").ToString();
                string lot = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPLot").ToString();
                string qty = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPQty").ToString();

                msg = new frmMsg("",
                    $"Are you sure you wish to manually close this slurry?{Environment.NewLine}Item Code : " + code + Environment.NewLine + "Lot Number : " + lot + Environment.NewLine +
                    "Quantity : " + qty, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured =
                        Client.ManuallyClosePowder(id + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The powder has been manufactured",
                                    GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvPowders.DeleteRow(index);
                                break;
                            case "0":
                                msg = new frmMsg("Auto Manufacture Error", manufactured.Remove(0, 2),
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnPEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcID").ToString();
                string code = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPCode").ToString();
                string desc = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPDesc").ToString();
                string lot = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPLot").ToString();
                string qty = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPQty").ToString();
                frmEditPowder editor = new frmEditPowder(id, code, desc, lot, qty);
                editor.ShowDialog();
                if (editor.DialogResult == DialogResult.OK)
                {
                    refreshPowderItems();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnPManuf_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvPowders.FocusedRowHandle;
                string id = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcID").ToString();
                string code = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPCode").ToString();
                string lot = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPLot").ToString();
                string qty = gvPowders.GetRowCellValue(gvPowders.FocusedRowHandle, "gcPQty").ToString();

                msg = new frmMsg("Confirm Manufacture",
                    "Item Code : " + code + Environment.NewLine + "Lot Number : " + lot + Environment.NewLine +
                    "Quantity : " + qty, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured =
                        Client.ManufacturePowder(id + "|" + code + "|" + lot + "|" + qty + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The powder has been manufactured",
                                    GlobalVars.msgState.Info);
                                msg.ShowDialog();
                                gvPowders.DeleteRow(index);
                                break;
                            case "0":
                                msg = new frmMsg("Auto Manufacture Error", manufactured.Remove(0, 2),
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshPowderItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getPowderLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getPowderLines()
        {
            try
            {
                dataLines = Client.GetPowderManufactureLines();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setPowderLines(); });
                }
            }
            catch (Exception ex)
            {
                //tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        public void setPowderLines()
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
                                dtPowderines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtPowderines.Rows.Add(item.Split('|'));
                                    }
                                }

                                dgPowders.DataSource = dtPowderines;
                                dgPowders.MainView.GridControl.DataSource = dtPowderines;
                                dgPowders.MainView.GridControl.EndUpdate();
                                gvPowders.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtPowderines.Rows.Clear();
                                dgPowders.DataSource = dtPowderines;
                                dgPowders.MainView.GridControl.DataSource = dtPowderines;
                                dgPowders.MainView.GridControl.EndUpdate();
                                gvPowders.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("Powder Manufacture", "No Manufacturing Remaining For Powder...",
                                    GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving Powder Prep Manufacture items";
                                errInfo = "Unexpected error while retreiving  Powder Prep Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void btnRefreshP_Click(object sender, EventArgs e)
        {
            refreshPowderItems();
        }

        #endregion

        #region Fresh Slurry

        DataTable dtFSLines = new DataTable();

        public void setupFSDataTable()
        {
            try
            {
                dtFSLines.Columns.Add("gcFSId", typeof(string));
                dtFSLines.Columns.Add("gcFSTrol", typeof(string));
                dtFSLines.Columns.Add("gcFSCode", typeof(string));
                dtFSLines.Columns.Add("gcFSLot", typeof(string));
                dtFSLines.Columns.Add("gcWetWeight", typeof(string));
                dtFSLines.Columns.Add("gcSolidity", typeof(string));
                dtFSLines.Columns.Add("gcDryWeight", typeof(string));
                dtFSLines.Columns.Add("gcFSUser", typeof(string));
                dtFSLines.Columns.Add("gcFSDate", typeof(string));
                dtFSLines.Columns.Add("gcFSManuf", typeof(string));
                dtFSLines.Columns.Add("gcFSEdit", typeof(string));
                dtFSLines.Columns.Add("gcClose", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnFSManuf =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnFSManuf.Buttons[0].Width = 85;
                dgFS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnFSManuf});
                ribtnFSManuf.Click += RibtnFSManuf_Click;
                gcFSManuf.ColumnEdit = ribtnFSManuf;
                gcFSManuf.Width = 93;
                gcFSManuf.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnFSManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnEdit =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnEdit.Buttons[0].Width = 85;
                dgFS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnEdit});
                ribtnEdit.Click += RibtnEdit_Click;
                gcFSEdit.ColumnEdit = ribtnEdit;
                gcFSEdit.Width = 93;
                gcFSEdit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnClose =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnClose.Buttons[0].Width = 85;
                dgFS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnClose});
                ribtnClose.Click += RibtnClose_Click;
                gcClose.ColumnEdit = ribtnClose;
                gcClose.Width = 93;
                gcClose.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnClose.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvFS.FocusedRowHandle;
                string id = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSId").ToString();
                string code = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSCode").ToString();
                string lot = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSLot").ToString();
                string qty = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcDryWeight").ToString();

                msg = new frmMsg("Are you sure this slurry was manufactured manually?",
                    "Are you sure this slurry was manufactured manually?" + Environment.NewLine + "Item Code : " +
                    code + Environment.NewLine + "Lot Number : " + lot + Environment.NewLine + "Dry Weight : " + qty,
                    GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured = Client.CloseFreshSlurry(id + "|" + GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The slurry has been closed", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvFS.DeleteRow(index);
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnFSManuf_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvFS.FocusedRowHandle;
                string id = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSId").ToString();
                string code = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSCode").ToString();
                string lot = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcFSLot").ToString();
                string qty = gvFS.GetRowCellValue(gvFS.FocusedRowHandle, "gcDryWeight").ToString();

                msg = new frmMsg("Confirm Manufacture",
                    "Confirm Manufacture" + Environment.NewLine + "Item Code : " + code + Environment.NewLine +
                    "Lot Number : " + lot + Environment.NewLine + "Dry Weight : " + qty, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured =
                        Client.ManufactureFreshSlurry(id + "|" + code + "|" + lot + "|" + qty + "|" +
                                                      GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The slurry has been manufactured",
                                    GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvFS.DeleteRow(index);
                                break;
                            case "0":
                                msg = new frmMsg("Auto Manufacture Error", manufactured.Remove(0, 2),
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing container";
                                errInfo = "Unexpected error while manufacturing container" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshFSItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getFSLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getFSLines()
        {
            try
            {
                dataLines = Client.GetFSManufactureLines();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setFSLines(); });
                }
            }
            catch (Exception ex)
            {
                //tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        public void setFSLines()
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
                                dtFSLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtFSLines.Rows.Add(item.Split('|'));
                                    }
                                }

                                dgFS.DataSource = dtFSLines;
                                dgFS.MainView.GridControl.DataSource = dtFSLines;
                                dgFS.MainView.GridControl.EndUpdate();
                                gvFS.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtFSLines.Rows.Clear();
                                dgFS.DataSource = dtFSLines;
                                dgFS.MainView.GridControl.DataSource = dtFSLines;
                                dgFS.MainView.GridControl.EndUpdate();
                                gvFS.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("Fresh Slurry Manufacture",
                                    "No Manufacturing Remaining For Fresh Slurry...", GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving Fresh Slurry Manufacture items";
                                errInfo = "Unexpected error while retreiving  Fresh Slurry Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void btnRefreshFS_Click(object sender, EventArgs e)
        {
            refreshFSItems();
        }

        #endregion

        #region Mixed Slurry

        private void SetupMixedSlurry()
        {
            try
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnMSManuf =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnMSManuf.Buttons[0].Width = 85;
                dgMixed.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnMSManuf});
                ribtnMSManuf.Click += RibtnMSManuf_Click;
                gcMSManuf.ColumnEdit = ribtnMSManuf;
                gcMSManuf.Width = 93;
                gcMSManuf.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnMSManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public class MixedSlurry
        {
            public MixedSlurry(string[] args)
            {
                MSID = args[0];
                MSTank = args[1];
                MSItem = args[2];
                MSDesc = args[3];
                MSLot = args[4];
                MSSlurries = args[5];
                MSDate = args[6];
            }

            public string MSID { get; set; }
            public string MSTank { get; set; }
            public string MSItem { get; set; }
            public string MSDesc { get; set; }
            public string MSLot { get; set; }
            public string MSSlurries { get; set; }
            public string MSDate { get; set; }
        }

        private List<MixedSlurry> MixedSulrries;

        private void GetMixedSlurryLines()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string allMixedSlurries = Client.GetMixedSlurriesFormManufacture();
                if (!string.IsNullOrWhiteSpace(allMixedSlurries))
                {
                    string returnCode = allMixedSlurries.Split('*')[0];
                    string returnData = allMixedSlurries.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            MixedSulrries = new List<MixedSlurry>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    MixedSulrries.Add(new MixedSlurry(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgMixed.DataSource = MixedSulrries;
                            dgMixed.MainView.GridControl.DataSource = MixedSulrries;
                            dgMixed.MainView.GridControl.EndUpdate();
                            gvMixed.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("The following server side issue was encountered",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnMSManuf_Click(object sender, EventArgs e)
        {
            try
            {
                MixedSlurry selected = gvMixed.GetRow(gvMixed.FocusedRowHandle) as MixedSlurry;
                if (selected != null)
                {
                    string tankType = selected.MSTank.Split('_')[0];
                    switch (tankType)
                    {
                        case "TNK":
                        {
                            string tankInfo = Client.GetMixedSlurryTankInfoManufacture(selected.MSID);
                            if (!string.IsNullOrWhiteSpace(tankInfo))
                            {
                                string returnCode = tankInfo.Split('*')[0];
                                string returnData = tankInfo.Split('*')[1];
                                switch (returnCode)
                                {
                                    case "1":
                                        string tank = returnData.Split('|')[0];
                                        string slurry = returnData.Split('|')[1];
                                        string description = returnData.Split('|')[2];
                                        string lot = returnData.Split('|')[3];
                                        string amount = returnData.Split('|')[4];
                                        string zac = returnData.Split('|')[5];
                                        string rem = returnData.Split('|')[6];
                                        string rec = returnData.Split('|')[7];
                                        string bClosed = returnData.Split('|')[8];
                                        string userClosed = returnData.Split('|')[9];
                                        string dateClosed = returnData.Split('|')[10];
                                        string reasonClosed = returnData.Split('|')[11];
                                        string wetWeight = returnData.Split('|')[12];
                                        string dryWeight = returnData.Split('|')[13];
                                        string solidity = returnData.Split('|')[14];

                                        Dictionary<string, string> slurryInfo = new Dictionary<string, string>();
                                        slurryInfo.Add("Tank", tank);
                                        slurryInfo.Add("Slurry Code", slurry);
                                        slurryInfo.Add("Description", description);
                                        slurryInfo.Add("Slurry Lot", lot);
                                        slurryInfo.Add("Amount of Slurries", amount);
                                        slurryInfo.Add("Remainder", rem);
                                        slurryInfo.Add("Recovered", rec);
                                        slurryInfo.Add("Wet Weight", wetWeight);
                                        slurryInfo.Add("Dry Weight", dryWeight);
                                        slurryInfo.Add("Solidity", solidity);
                                        using (frmMixedSlurryManuf man = new frmMixedSlurryManuf(selected.MSID, selected.MSID, tank, selected.MSItem, slurryInfo))
                                        {
                                            man.ShowDialog();
                                            if (man.DialogResult == DialogResult.OK)
                                            {
                                                GetMixedSlurryLines();
                                            } 
                                        }
                                        break;
                                    case "0":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("The following server side issue was encountered",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    case "-1":
                                        SplashScreenManager.CloseForm();
                                        errMsg = returnData.Split('|')[0];
                                        errInfo = returnData.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("A client side connection error has occured",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    default:
                                        SplashScreenManager.CloseForm();
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred";
                                        errInfo = "An unexpected error occurred" + Environment.NewLine +
                                                  "Data Returned:" +
                                                  Environment.NewLine + returnData;
                                        ExHandler.showErrorST(st, msgStr, errInfo);
                                        break;
                                }
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                msg = new frmMsg("A connection level error has occured",
                                    "No data was returned from the server",
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                            break;
                        case "BTNK":
                        {
                            string tankInfo = Client.GetMixedSlurryTankInfoManufacture(selected.MSID);
                            if (!string.IsNullOrWhiteSpace(tankInfo))
                            {
                                string returnCode = tankInfo.Split('*')[0];
                                string returnData = tankInfo.Split('*')[1];
                                switch (returnCode)
                                {
                                    case "1":
                                        string tank = returnData.Split('|')[0];
                                        string slurry = returnData.Split('|')[1];
                                        string description = returnData.Split('|')[2];
                                        string lot = returnData.Split('|')[3];
                                        string amount = returnData.Split('|')[4];
                                        string zac = returnData.Split('|')[5];
                                        string rem = returnData.Split('|')[6];
                                        string rec = returnData.Split('|')[7];
                                        string bClosed = returnData.Split('|')[8];
                                        string userClosed = returnData.Split('|')[9];
                                        string dateClosed = returnData.Split('|')[10];
                                        string reasonClosed = returnData.Split('|')[11];
                                        string wetWeight = returnData.Split('|')[12];
                                        string dryWeight = returnData.Split('|')[13];
                                        string solidity = returnData.Split('|')[14];

                                        Dictionary<string, string> slurryInfo = new Dictionary<string, string>();
                                        slurryInfo.Add("Tank", tank);
                                        slurryInfo.Add("Slurry Code", slurry);
                                        slurryInfo.Add("Description", description);
                                        slurryInfo.Add("Slurry Lot", lot);
                                        slurryInfo.Add("Amount of Slurries", amount);
                                        slurryInfo.Add("Remainder", rem);
                                        slurryInfo.Add("Recovered", rec);
                                        slurryInfo.Add("Wet Weight", wetWeight);
                                        slurryInfo.Add("Dry Weight", dryWeight);
                                        slurryInfo.Add("Solidity", solidity);
                                        using (frmMixedSlurryManuf man = new frmMixedSlurryManuf(selected.MSID, selected.MSID, tank, selected.MSItem, slurryInfo))
                                        {
                                            man.ShowDialog();
                                            if (man.DialogResult == DialogResult.OK)
                                            {
                                                GetMixedSlurryLines();
                                            } 
                                        }
                                        break;
                                    case "0":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("The following server side issue was encountered",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    case "-1":
                                        SplashScreenManager.CloseForm();
                                        errMsg = returnData.Split('|')[0];
                                        errInfo = returnData.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("A client side connection error has occured",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    default:
                                        SplashScreenManager.CloseForm();
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred";
                                        errInfo = "An unexpected error occurred" + Environment.NewLine +
                                                  "Data Returned:" +
                                                  Environment.NewLine + returnData;
                                        ExHandler.showErrorST(st, msgStr, errInfo);
                                        break;
                                }
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                msg = new frmMsg("A connection level error has occured",
                                    "No data was returned from the server",
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                            break;
                        case "MTNK":
                        {
                            string tankInfo = Client.GetMixedSlurryMobileTankInfoManufacture(selected.MSID);
                            if (!string.IsNullOrWhiteSpace(tankInfo))
                            {
                                string returnCode = tankInfo.Split('*')[0];
                                string returnData = tankInfo.Split('*')[1];
                                switch (returnCode)
                                {
                                    case "1":
                                        string Hid = returnData.Split('|')[0];
                                        string tank = returnData.Split('|')[1];
                                        string slurry = returnData.Split('|')[2];
                                        string description = returnData.Split('|')[3];
                                        string lot = returnData.Split('|')[4];
                                        string amount = returnData.Split('|')[5];
                                        string zac = returnData.Split('|')[6];
                                        string rem = returnData.Split('|')[7];
                                        string rec = returnData.Split('|')[8];
                                        string bClosed = returnData.Split('|')[9];
                                        string userClosed = returnData.Split('|')[10];
                                        string dateClosed = returnData.Split('|')[11];
                                        string reasonClosed = returnData.Split('|')[12];
                                        string wetWeight = returnData.Split('|')[13];
                                        string dryWeight = returnData.Split('|')[14];
                                        string solidity = returnData.Split('|')[15];

                                        Dictionary<string, string> slurryInfo = new Dictionary<string, string>();
                                        slurryInfo.Add("Tank", tank);
                                        slurryInfo.Add("Slurry Code", slurry);
                                        slurryInfo.Add("Description", description);
                                        slurryInfo.Add("Slurry Lot", lot);
                                        slurryInfo.Add("Amount of Slurries", amount);
                                        slurryInfo.Add("Remainder", rem);
                                        slurryInfo.Add("Recovered", rec);
                                        slurryInfo.Add("Wet Weight", wetWeight);
                                        slurryInfo.Add("Dry Weight", dryWeight);
                                        slurryInfo.Add("Solidity", solidity);
                                        using (frmMixedSlurryManuf man = new frmMixedSlurryManuf(selected.MSID, Hid, tank, selected.MSItem, slurryInfo))
                                        {
                                            man.ShowDialog();
                                            if (man.DialogResult == DialogResult.OK)
                                            {
                                                GetMixedSlurryLines();
                                            }
                                        }
                                        break;
                                    case "0":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("The following server side issue was encountered",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    case "-1":
                                        SplashScreenManager.CloseForm();
                                        errMsg = returnData.Split('|')[0];
                                        errInfo = returnData.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        SplashScreenManager.CloseForm();
                                        using (msg = new frmMsg("A client side connection error has occured",
                                            returnData,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    default:
                                        SplashScreenManager.CloseForm();
                                        st = new StackTrace(0, true);
                                        msgStr = "An unexpected error occurred";
                                        errInfo = "An unexpected error occurred" + Environment.NewLine +
                                                  "Data Returned:" +
                                                  Environment.NewLine + returnData;
                                        ExHandler.showErrorST(st, msgStr, errInfo);
                                        break;
                                }
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                msg = new frmMsg("A connection level error has occured",
                                    "No data was returned from the server",
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Zect

        DataTable dtZectLines = new DataTable();

        public void setupZECTDataTable()
        {
            try
            {
                dtZectLines.Columns.Add("gcZID", typeof(string));
                dtZectLines.Columns.Add("gcJob", typeof(string));
                dtZectLines.Columns.Add("gcZCode", typeof(string));
                dtZectLines.Columns.Add("gcZLot", typeof(string));
                dtZectLines.Columns.Add("gcZQty", typeof(string));
                dtZectLines.Columns.Add("gcZProd", typeof(string));
                dtZectLines.Columns.Add("gcZManuf", typeof(string));
                dtZectLines.Columns.Add("gcCoat", typeof(string));
                dtZectLines.Columns.Add("gcZLine", typeof(string));
                dtZectLines.Columns.Add("gcZRun", typeof(bool));
                dtZectLines.Columns.Add("gcZDate", typeof(string));
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
                Thread thread = new Thread(getZectLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnZRefresh_Click(object sender, EventArgs e)
        {
            refreshZectItems();
        }

        public void getZectLines()
        {
            try
            {
                dataLines = Client.GetZECTManufactureJobs();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setZectLines(); });
                }
            }
            catch (Exception ex)
            {
                //tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }

        public void setZectLines()
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
                                dtZectLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtZectLines.Rows.Add(item.Split('|'));
                                    }
                                }

                                dgZect.DataSource = dtZectLines;
                                dgZect.MainView.GridControl.DataSource = dtZectLines;
                                dgZect.MainView.GridControl.EndUpdate();
                                gvZect.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtZectLines.Rows.Clear();
                                dgZect.DataSource = dtZectLines;
                                dgZect.MainView.GridControl.DataSource = dtZectLines;
                                dgZect.MainView.GridControl.EndUpdate();
                                gvZect.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("ZECT Manufacture", "No Manufacturing Remaining For ZCET...",
                                    GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving PGM Manufacture items";
                                errInfo = "Unexpected error while retreiving  PGM Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void gvZect_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id = gvZect.GetRowCellValue(gvZect.FocusedRowHandle, "gcZID").ToString();
                string code = gvZect.GetRowCellValue(gvZect.FocusedRowHandle, "gcZCode").ToString();
                string lot = gvZect.GetRowCellValue(gvZect.FocusedRowHandle, "gcZLot").ToString();
                string total = gvZect.GetRowCellValue(gvZect.FocusedRowHandle, "gcZManuf").ToString();
                string zLine = gvZect.GetRowCellValue(gvZect.FocusedRowHandle, "gcZLine").ToString();
                frmZectManufacture zManuf = new frmZectManufacture(id, code, lot, total, zLine);
                zManuf.ShowDialog();
                if (zManuf.changed == true)
                {
                    refreshZectItems();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region AW

        DataTable dtAWLines = new DataTable();

        public void setupAWDataTable()
        {
            try
            {
                dtAWLines.Columns.Add("gcAID", typeof(string));
                dtAWLines.Columns.Add("gcAJobCode", typeof(string));
                dtAWLines.Columns.Add("gcACode", typeof(string));
                dtAWLines.Columns.Add("gcALot", typeof(string));
                dtAWLines.Columns.Add("gcAQty", typeof(string));
                dtAWLines.Columns.Add("gcAProc", typeof(string));
                dtAWLines.Columns.Add("gcAManuf", typeof(string));
                dtAWLines.Columns.Add("gcADate", typeof(string));
                dtAWLines.Columns.Add("gcAUserProduced", typeof(string));
                dtAWLines.Columns.Add("gcARun", typeof(bool));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshAWItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                //tmrItems.Start();
                Thread thread = new Thread(getAWLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getAWLines()
        {
            try
            {
                dataLines = Client.GetAWManufactureJobs();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setAWLines(); });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void setAWLines()
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
                                dtAWLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtAWLines.Rows.Add(item.Split('|'));
                                    }
                                }

                                dgAW.DataSource = dtAWLines;
                                dgAW.MainView.GridControl.DataSource = dtAWLines;
                                dgAW.MainView.GridControl.EndUpdate();
                                gvAW.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtAWLines.Rows.Clear();
                                dgAW.DataSource = dtAWLines;
                                dgAW.MainView.GridControl.DataSource = dtAWLines;
                                dgAW.MainView.GridControl.EndUpdate();
                                gvAW.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("AW Manufacture", "No Manufacturing Remaining For AW...",
                                    GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving PGM Manufacture items";
                                errInfo = "Unexpected error while retreiving  PGM Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void gvAW_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id = gvAW.GetRowCellValue(gvAW.FocusedRowHandle, "gcAID").ToString();
                string code = gvAW.GetRowCellValue(gvAW.FocusedRowHandle, "gcACode").ToString();
                string lot = gvAW.GetRowCellValue(gvAW.FocusedRowHandle, "gcALot").ToString();
                string total = gvAW.GetRowCellValue(gvAW.FocusedRowHandle, "gcAManuf").ToString();
                frmAWManufacture zManuf = new frmAWManufacture(id, code, lot, total);
                zManuf.ShowDialog();
                if (zManuf.changed == true)
                {
                    refreshAWItems();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnARefresh_Click(object sender, EventArgs e)
        {
            refreshAWItems();
        }

        #endregion

        #region Canning

        DataTable dtCanningLines = new DataTable();

        public void setupcanningDataTable()
        {
            try
            {
                dtCanningLines.Columns.Add("gcCID", typeof(string));
                dtCanningLines.Columns.Add("gcCCode", typeof(string));
                dtCanningLines.Columns.Add("gcCDesc", typeof(string));
                dtCanningLines.Columns.Add("gcCLot", typeof(string));
                dtCanningLines.Columns.Add("gcCQty", typeof(string));
                dtCanningLines.Columns.Add("gcCUser", typeof(string));
                dtCanningLines.Columns.Add("gcCDate", typeof(string));
                dtCanningLines.Columns.Add("gcCManuf", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnCanningManuf =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnCanningManuf.Buttons[0].Width = 85;
                dgCanning.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[]
                    {ribtnCanningManuf});
                ribtnCanningManuf.Click += RibtnCanningManuf_Click;
                gcCManuf.ColumnEdit = ribtnCanningManuf;
                gcCManuf.Width = 93;
                gcCManuf.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnCanningManuf.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnCanningClose =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnCanningClose.Buttons[0].Width = 85;
                dgCanning.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[]
                    {ribtnCanningClose});
                ribtnCanningClose.Click += RibtnCanningClose_Click;
                gcCanClose.ColumnEdit = ribtnCanningClose;
                gcCanClose.Width = 93;
                gcCanClose.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnCanningClose.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void refreshCanningItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                //tmrItems.Start();
                Thread thread = new Thread(getCanningLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getCanningLines()
        {
            try
            {
                dataLines = Client.GetCanningManufactureLines();
                dataPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setCanningLines(); });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void setCanningLines()
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
                                dtCanningLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                string[] ItemArray = itemLines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtCanningLines.Rows.Add(item.Split('|'));
                                    }
                                }

                                dgCanning.DataSource = dtCanningLines;
                                dgCanning.MainView.GridControl.DataSource = dtCanningLines;
                                dgCanning.MainView.GridControl.EndUpdate();
                                gvCanning.RefreshData();

                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                dtCanningLines.Rows.Clear();
                                dgCanning.DataSource = dtCanningLines;
                                dgCanning.MainView.GridControl.DataSource = dtCanningLines;
                                dgCanning.MainView.GridControl.EndUpdate();
                                gvCanning.RefreshData();

                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("Canning Manufacture", "No Manufacturing Remaining For Canning...",
                                    GlobalVars.msgState.Success);
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
                                msg = new frmMsg("A connection level error has occured", itemLines,
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving PGM Manufacture items";
                                errInfo = "Unexpected error while retreiving  PGM Manufacture items" +
                                          Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
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

        private void btnCRefresh_Click(object sender, EventArgs e)
        {
            refreshCanningItems();
        }

        private void RibtnCanningManuf_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvCanning.FocusedRowHandle;
                string id = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCID").ToString();
                string code = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCCode").ToString();
                string lot = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCLot").ToString();
                string qty = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCQty").ToString();
                msg = new frmMsg("Confirm Manufacture",
                    "Confirm Manufacture" + Environment.NewLine + "Item Code : " + code + Environment.NewLine +
                    "Lot Number : " + lot + Environment.NewLine + "Quantity : " + qty, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured =
                        Client.ManufactureCanningPallet(id + "|" + code + "|" + lot + "|" + qty + "|" +
                                                        GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The pallet has been manufactured",
                                    GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvCanning.DeleteRow(index);
                                break;
                            case "0":
                                msg = new frmMsg("Auto Manufacture Error", manufactured.Remove(0, 2),
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing pallet";
                                errInfo = "Unexpected error while manufacturing pallet" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void RibtnCanningClose_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gvCanning.FocusedRowHandle;
                string id = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCID").ToString();
                string code = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCCode").ToString();
                string lot = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCLot").ToString();
                string qty = gvCanning.GetRowCellValue(gvCanning.FocusedRowHandle, "gcCQty").ToString();
                msg = new frmMsg("Confirm Manual Close",
                    "Are you sure you wish to close this pallet" + Environment.NewLine + "Item Code : " + code + Environment.NewLine +
                    "Lot Number : " + lot + Environment.NewLine + "Quantity : " + qty, GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string manufactured =
                        Client.CloseCanningPallet(id + "|" +
                                                        GlobalVars.userName);
                    if (manufactured != string.Empty)
                    {
                        switch (manufactured.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The pallet has been closed",
                                    GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                gvCanning.DeleteRow(index);
                                break;
                            case "0":
                                msg = new frmMsg("Auto Manufacture Error", manufactured.Remove(0, 2),
                                    GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                manufactured = manufactured.Remove(0, 3);
                                errMsg = manufactured.Split('|')[0];
                                errInfo = manufactured.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            default:
                                msgStr = "Unexpected error while manufacturing pallet";
                                errInfo = "Unexpected error while manufacturing pallet" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + manufactured;
                                ExHandler.showErrorStr(msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        #endregion

        private void xtcManuf_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                XtraTabPage sel = xtcManuf.SelectedTabPage;
                if (sel == xtpPGM)
                {
                    if (dtPGMLines.Rows.Count == 0)
                    {
                        refreshPGMItems();
                    }
                }
                else if (sel == xtpPowder)
                {
                    if (dtPowderines.Rows.Count == 0)
                    {
                        refreshPowderItems();
                    }
                }
                else if (sel == xtpFS)
                {
                    if (dtFSLines.Rows.Count == 0)
                    {
                        refreshFSItems();
                    }
                }
                else if (sel == xtpMS)
                {
                    if (MixedSulrries != null)
                    {
                        if (MixedSulrries.Count == 0)
                        {
                            GetMixedSlurryLines();
                        }
                    }
                    else
                    {
                        GetMixedSlurryLines();
                    }
                }
                else if (sel == xtpZect)
                {
                    if (dtZectLines.Rows.Count == 0)
                    {
                        refreshZectItems();
                    }
                }
                else if (sel == xtpAW)
                {
                    if (dtAWLines.Rows.Count == 0)
                    {
                        refreshAWItems();
                    }
                }
                else if (sel == xtpCanning)
                {
                    if (dtCanningLines.Rows.Count == 0)
                    {
                        refreshCanningItems();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmConfigureLocations loc = new frmConfigureLocations())
                {
                    loc.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string process = Client.ProcessAutoManufactures();
                if (process != string.Empty)
                {
                    switch (process.Split('*')[0])
                    {
                        case "1":
                            process = process.Remove(0, 2);
                            msg = new frmMsg("Manufacture records processed",
                                "Manufacture Message: " + Environment.NewLine + process, GlobalVars.msgState.Info);
                            msg.ShowDialog();
                            break;
                        case "0":
                            process = process.Remove(0, 2);
                            msg = new frmMsg("Server error", process, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            process = process.Remove(0, 3);
                            errMsg = process.Split('|')[0];
                            errInfo = process.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        default:
                            msgStr = "Unexpected error while manufacturing container";
                            errInfo = "Unexpected error while manufacturing container" + Environment.NewLine +
                                      "Data Returned:" + Environment.NewLine + process;
                            ExHandler.showErrorStr(msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}