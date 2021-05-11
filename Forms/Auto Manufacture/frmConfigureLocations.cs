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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    public partial class frmConfigureLocations : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        DataTable dt = new DataTable();
        public frmConfigureLocations()
        {
            InitializeComponent();
        }
        private void frmConfigureLocations_Load(object sender, EventArgs e)
        {
            setUpDataTable();
            getProcesses();
            GetNPLChemicals();
            GetMSManufID();
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ritxtPercentage =
                new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ritxtPercentage});
            //ritxtQty.EditValueChanging += RitxtQty_EditValueChanging;
            ritxtPercentage.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
            ritxtPercentage.EditValueChanged += RitxtPercentage_EditValueChanged;
            ritxtPercentage.EditValueChangedDelay = 500;
            gcPercentage.ColumnEdit = ritxtPercentage;
        }

        #region Manufacture Locations
        public void setUpDataTable()
        {
            dt.Columns.Add("gcProcess", typeof(string));
            dt.Columns.Add("gcSource", typeof(string));
            dt.Columns.Add("gcDest", typeof(string));
        }
        public void getProcesses()
        {
            try
            {
                string itemLines = Client.GetConfigLocs();
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
                            dgItems.MainView.GridControl.DataSource = dt;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            break;
                        case "0":
                            dt.Rows.Clear();
                            dgItems.DataSource = dt;
                            dgItems.MainView.GridControl.DataSource = dt;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();

                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("Powder Manufacture", "No Manufacturing Remaining For Powder...", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            itemLines = itemLines.Remove(0, 3);
                            errMsg = itemLines.Split('|')[0];
                            errInfo = itemLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving Powder Prep Manufacture items";
                            errInfo = "Unexpected error while retreiving  Powder Prep Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
        private void gvItems_DoubleClick(object sender, EventArgs e)
        {
            string process = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcProcess").ToString();
            string src = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcSource").ToString();
            string dest = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDest").ToString();
            frmChangeLoc cl = new frmChangeLoc(process, src, dest);
            cl.ShowDialog();
            if (cl.DialogResult == DialogResult.OK)
            {
                getProcesses();
            }
        }
        #endregion

        #region NPL Percentages
        private void GetNPLChemicals()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string nplChems = Client.GetNPLPercentages();
                if (!string.IsNullOrWhiteSpace(nplChems))
                {
                    string returnCode = nplChems.Split('*')[0];
                    string returnData = nplChems.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllChems = new List<Chemical>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    AllChems.Add(new Chemical(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgChem.DataSource = AllChems;
                            dgChem.MainView.GridControl.DataSource = AllChems;
                            dgChem.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();

                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            AllChems = new List<Chemical>();
                            dgChem.DataSource = AllChems;
                            dgChem.MainView.GridControl.DataSource = AllChems;
                            dgChem.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();
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

        private void btnEditNpl_Click(object sender, EventArgs e)
        {
            try
            {
                gcPercentage.OptionsColumn.ReadOnly = false;
                using (frmMsg msg = new frmMsg("", $"Editing is now enabled.{Environment.NewLine}Please alter the percentage column to edit the npl percentage.", GlobalVars.msgState.Info))
                {
                    msg.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void RitxtPercentage_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Chemical chem = gvChem.GetRow(gvChem.FocusedRowHandle) as Chemical;
                TextEdit realSender = sender as TextEdit;
                if (!string.IsNullOrWhiteSpace(realSender.Text))
                {
                    decimal test = 0;
                    if (Decimal.TryParse(realSender.Text,out test))
                    {
                        using (frmMsg conf = new frmMsg("Please Confirm", $"Are you sure you wish to change the percentage for {chem.Name} from {realSender.OldEditValue.ToString()} to {realSender.Text}?", GlobalVars.msgState.Question))
                        {
                            conf.ShowDialog();
                            if (conf.DialogResult == DialogResult.Yes)
                            {
                                SplashScreenManager.ShowForm(typeof(frmWait));
                                string edited = Client.UpdateNPLPercentage(chem.Name + "|" + realSender.Text);
                                if (!string.IsNullOrWhiteSpace(edited))
                                {
                                    string returnCode = edited.Split('*')[0];
                                    string returnData = edited.Split('*')[1];
                                    switch (returnCode)
                                    {
                                        case "1":
                                            SplashScreenManager.CloseForm();
                                            using (frmMsg succ = new frmMsg("Success", "The NPL value has been changed", GlobalVars.msgState.Success))
                                            {
                                                succ.ShowDialog();
                                                GetNPLChemicals();
                                            }
                                            break;
                                        case "0":
                                            SplashScreenManager.CloseForm();
                                            using (msg = new frmMsg("Auto Manufacture Error", returnData,
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
                            else
                            {
                                gvChem.SetFocusedRowCellValue(gcPercentage.FieldName, realSender.OldEditValue.ToString());
                                gvChem.RefreshData();
                            }
                        }
                    }
                }
                else
                {
                    using (frmMsg msg = new frmMsg("Cannot change percentage", "Please enter a valid NPL percentage", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
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

        private class Chemical
        {
            public Chemical(string[] args)
            {
                Name = args[0];
                Percentage = args[1];
            }

            public string Name { get; set; }
            public string Percentage { get; set; }
        }

        private List<Chemical> AllChems = new List<Chemical>();
        #endregion

        #region MS ID
        private void GetMSManufID()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string nplChems = Client.GetMixedSlurryID();
                if (!string.IsNullOrWhiteSpace(nplChems))
                {
                    string returnCode = nplChems.Split('*')[0];
                    string returnData = nplChems.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            txtID.Text = returnData;
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            msg = new frmMsg("The following server side issue was encountered:", returnData, GlobalVars.msgState.Error);
                            msg.ShowDialog();
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
        private void btnEditMS_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Enabled = true;
                btnSave.BringToFront();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    SplashScreenManager.ShowForm(typeof(frmWait));
                string saved = Client.SaveMixedSlurryID(txtID.Text);
                if (!string.IsNullOrWhiteSpace(saved))
                {
                    string returnCode = saved.Split('*')[0];
                    string returnData = saved.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            txtID.Enabled = false;
                            btnSave.SendToBack();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            msg = new frmMsg("The following server side issue was encountered:", returnData, GlobalVars.msgState.Error);
                            msg.ShowDialog();
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
                else
                {
                    msg = new frmMsg("Cannot Save ID",
                        "Please enter a valid journal ID",
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
    }
}
