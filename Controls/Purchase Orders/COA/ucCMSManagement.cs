using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Main;
using RTIS_Vulcan_UI.Forms.Purchase_Orders;
using RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Management;

namespace RTIS_Vulcan_UI.Controls.Purchase_Orders
{
    public partial class ucCMSManagement : UserControl
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
        DataTable dtItems = new DataTable();

        public ucCMSManagement()
        {
            InitializeComponent();
        }

        private void ucCMSManagement_Load(object sender, EventArgs e)
        {
            setupItemDataTable();
            refreshRecords();
        }

        private void setupItemDataTable()
        {
            try
            {
                dtItems.Columns.Add("gcCode", typeof(string));
                dtItems.Columns.Add("gcDesc", typeof(string));
                dtItems.Columns.Add("gcCaptured", typeof(string));
                dtItems.Columns.Add("gcStatus", typeof(string));
                dtItems.Columns.Add("gcStockLink", typeof(string));

                dtItems.Columns.Add("gcUserCaptured", typeof(string));
                dtItems.Columns.Add("gcDateCaptured", typeof(string));
                dtItems.Columns.Add("gcUserApproved", typeof(string));
                dtItems.Columns.Add("gcDateApproved", typeof(string));
                dtItems.Columns.Add("gcCMSId", typeof(string));
                dtItems.Columns.Add("gcVersion", typeof(string));
                dtItems.Columns.Add("gcUserRejected", typeof(string));
                dtItems.Columns.Add("gcDateRejected", typeof(string));
                dtItems.Columns.Add("gcRejectReason", typeof(string));

                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnVeiw =
                    new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                ribtnVeiw.Buttons[0].Width = 85;
                dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {ribtnVeiw});
                ribtnVeiw.Click += RibtnVeiw_Click;
                gcVeiw.ColumnEdit = ribtnVeiw;
                gcVeiw.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                ribtnVeiw.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void RibtnVeiw_Click(object sender, EventArgs e)
        {
            try
            {
                string status = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStatus").ToString();
                if (status == "Approved" || status == "Rejected")
                {
                    SplashScreenManager.ShowForm(typeof(frmWait));
                    string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCMSId").ToString();
                    string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                    string desc = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc").ToString();
                    string created = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserCaptured").ToString();
                    string dtCreated = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDateCaptured").ToString();
                    string approved = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserApproved").ToString();
                    string dtApproved = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDateApproved").ToString();

                    string rejected = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserRejected").ToString();
                    string dtRejected = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDateRejected").ToString();
                    string reasons = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcRejectReason").ToString();
                    string imagePulled = Client.GetCMSApprovalImage(code);
                    if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                                    @"\RSC\Signatures\" + code + ".png"))
                    {
                        Image img = null;
                        if (status == "Approved")
                        {
                            img = Image.FromFile(
                                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                                @"\RSC\Signatures\" + code + ".png");
                        }

                        DataTable dtLines = new DataTable()
                        {
                            Columns =
                            {
                                new DataColumn("gcItem", typeof(string)),
                                new DataColumn("gcUnit", typeof(string)),
                                new DataColumn("gcVarType", typeof(string)),
                                new DataColumn("gcVal1", typeof(string)),
                                new DataColumn("gcVal2", typeof(string)),
                                new DataColumn("gcInspec", typeof(string))
                            }
                        };

                        string lines = Client.GetCMSApprovalLinesVeiw(id);
                        switch (lines.Split('*')[0])
                        {
                            case "1":
                                dtLines.Rows.Clear();
                                lines = lines.Remove(0, 2);
                                string[] ItemArray = lines.Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtLines.Rows.Add(item.Split('|'));
                                    }
                                }

                                SplashScreenManager.CloseForm();
                                if (status == "Approved")
                                {
                                    using (frmVeiwApproval veiw = new frmVeiwApproval(img, code, desc, created,
                                        dtCreated, approved, dtApproved, dtLines, true))
                                    {
                                        veiw.ShowDialog();
                                    }
                                }
                                else if (status == "Rejected")
                                {
                                    using (frmVeiwApproval veiw = new frmVeiwApproval(code, desc, created, dtCreated,
                                        rejected, dtRejected, dtLines, reasons, false))
                                    {
                                        veiw.ShowDialog();
                                    }
                                }

                                if (img != null)
                                {
                                    img.Dispose();
                                }

                                break;
                            case "0":
                                dtLines.Rows.Clear();
                                using (msg = new frmMsg("No information was found",
                                    "No information for the selected CMS document could be found",
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }

                                break;
                            case "-1":
                                SplashScreenManager.CloseForm();
                                lines = lines.Remove(0, 3);
                                errMsg = lines.Split('|')[0];
                                errInfo = lines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                SplashScreenManager.CloseForm();
                                lines = lines.Remove(0, 2);
                                using (msg = new frmMsg("A connection level error has occured", lines,
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }

                                break;
                            default:
                                SplashScreenManager.CloseForm();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retrieving data";
                                errInfo = "Unexpected error while retrieving data" + Environment.NewLine +
                                          "Data Returned:" + Environment.NewLine + lines;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm();
                        using (msg = new frmMsg("A connection level error has occured",
                            "The image was not able to be retrieved", GlobalVars.msgState.Error))
                        {
                            msg.ShowDialog();
                        }
                    }
                }
                else
                {
                    using (msg = new frmMsg("No approval information",
                        "Cannot view approval information for an unprocessed CMS document", GlobalVars.msgState.Error))
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

        public void refreshRecords()
        {
            try
            {
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getCMSHeaders);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void getCMSHeaders()
        {
            try
            {
                dataLines = Client.GetCMSHeaders();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker) delegate { setCMSHeaders(); });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void setCMSHeaders()
        {
            try
            {
                string itemLines = dataLines;
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


                            foreach (GridColumn item in gvItems.Columns)
                            {
                                item.BestFit();
                            }

                            ppnlWait.SendToBack();
                            break;
                        case "0":
                            dtItems.Rows.Clear();
                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);

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
                            msgStr = "Unexpected error while retrieving PGM Manufacture items";
                            errInfo = "Unexpected error while retrieving  PGM Manufacture items" + Environment.NewLine +
                                      "Data Returned:" + Environment.NewLine + itemLines;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    ppnlWait.SendToBack();
                    using (msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server", GlobalVars.msgState.Error))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshRecords();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStockLink").ToString();
            string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
            string desc = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc").ToString();
            try
            {
                using (frmAddItemCMS add = new frmAddItemCMS(id, code, desc))
                {
                    add.ShowDialog();
                    if (add.DialogResult == DialogResult.OK)
                    {
                        refreshRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void gvItems_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string specCaptured = gvItems.GetRowCellValue(e.RowHandle, nameof(gcCaptured)).ToString();
                    string status = gvItems.GetRowCellValue(e.RowHandle, nameof(gcStatus)).ToString();
                    if (specCaptured.ToUpper() == "YES")
                    {
                        if (status.ToUpper() == "APPROVED")
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                            e.Appearance.BackColor2 = Color.LightGreen;
                        }
                        else if (status == "Waiting Approval")
                        {
                            e.Appearance.BackColor = Color.LightBlue;
                            e.Appearance.BackColor2 = Color.LightBlue;
                        }
                        else if (status == "Rejected")
                        {
                            e.Appearance.BackColor = Color.Salmon;
                            e.Appearance.BackColor2 = Color.Salmon;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.MediumPurple;
                            e.Appearance.BackColor2 = Color.MediumPurple;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                        e.Appearance.BackColor2 = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool approved = false;
                string status = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStatus").ToString();
                string hID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCMSId").ToString();
                string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStockLink").ToString();
                string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                string desc = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc").ToString();

                string stockLink = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStockLink").ToString();
                string version = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcVersion").ToString();

                if (status == "Approved")
                {
                    approved = true;
                }

                using (frmEditCMS edit = new frmEditCMS(hID, approved, code, desc, stockLink, version))
                {
                    edit.ShowDialog();
                    if (edit.DialogResult == DialogResult.OK)
                    {
                        refreshRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string hID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCMSId").ToString();
                string status = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcStatus").ToString();
                if (status != "Approved")
                {
                    using (msg = new frmMsg("", "Are you sure you wish to delete the selected CMS document PERMANENTLY",
                        GlobalVars.msgState.Question))
                    {
                        msg.ShowDialog();
                        if (msg.DialogResult == DialogResult.Yes)
                        {
                            string deleted = Client.DeleteCMSDocument(hID);
                            if (deleted != string.Empty)
                            {
                                switch (deleted.Split('*')[0])
                                {
                                    case "1":
                                        using (msg = new frmMsg("Success", "CMS document has been deleted",
                                            GlobalVars.msgState.Success))
                                        {
                                            msg.ShowDialog();
                                        }

                                        refreshRecords();
                                        break;
                                    case "0":
                                        deleted = deleted.Remove(0, 2);
                                        using (msg = new frmMsg("CMS Document error", deleted,
                                            GlobalVars.msgState.Error))
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
                                        using (msg = new frmMsg("A connection level error has occured", deleted,
                                            GlobalVars.msgState.Error))
                                        {
                                            msg.ShowDialog();
                                        }

                                        break;
                                    default:
                                        msgStr = "Unexpected error while retrieving data";
                                        errInfo = "Unexpected error while retrieving data" + Environment.NewLine +
                                                  "Data Returned:" + Environment.NewLine + deleted;
                                        ExHandler.showErrorStr(msgStr, errInfo);
                                        break;
                                }
                            }
                            else
                            {
                                using (msg = new frmMsg("A connection level error has occured",
                                    "No data was returned from the server", GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (msg = new frmMsg("Unable to delete document",
                        "The system cannot delete an approved document, if changes to the document are required please use the edit functionality",
                        GlobalVars.msgState.Error))
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
    }
}