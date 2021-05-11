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
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using RTIS_Vulcan_UI.Forms.Main;
using RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Management;

namespace RTIS_Vulcan_UI.Controls.Purchase_Orders.COA
{
    public partial class ucCMSArchive : UserControl
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
        public ucCMSArchive()
        {
            InitializeComponent();
        }
        private void ucCMSArchive_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            getCMSArchives();
        }
        private void getCMSArchives()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                SetupDatatable();
                string archiveHeaders = Client.GetCMSArchiveHeaders();
                if (archiveHeaders != string.Empty)
                {
                    switch (archiveHeaders.Split('*')[0])
                    {
                        case "1":
                            dtItems.Rows.Clear();
                            archiveHeaders = archiveHeaders.Remove(0, 2);
                            string[] ItemArray = archiveHeaders.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtItems.Rows.Add(itemS);
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
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            dtItems.Rows.Clear();
                            SplashScreenManager.CloseForm();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            archiveHeaders = archiveHeaders.Remove(0, 3);
                            errMsg = archiveHeaders.Split('|')[0];
                            errInfo = archiveHeaders.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            archiveHeaders = archiveHeaders.Remove(0, 2);
                            using (msg = new frmMsg("A connection level error has occured", archiveHeaders, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retrieving data";
                            errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + archiveHeaders;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
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
                catch 
                {
                   //Ignore
                }
                ExHandler.showErrorEx(ex);
            }
        }
        public void SetupDatatable()
        {
            dtItems = new DataTable(){Columns =
            {
                new DataColumn("gcCode", typeof(string)),
                new DataColumn("gcDesc", typeof(string)),
                new DataColumn("gcCaptured", typeof(string)),
                new DataColumn("gcStatus", typeof(string)),
                new DataColumn("gcStockLink", typeof(string)),
                new DataColumn("gcUserCaptured", typeof(string)),
                new DataColumn("gcDateCaptured", typeof(string)),
                new DataColumn("gcUserApproved", typeof(string)),
                new DataColumn("gcDateApproved", typeof(string)),
                new DataColumn("gcCMSId", typeof(string)),
                new DataColumn("gcVersion", typeof(string))
            }};

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnVeiw = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnVeiw.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnVeiw });
            ribtnVeiw.Click += RibtnVeiw_Click;
            gcVeiw.ColumnEdit = ribtnVeiw;
            gcVeiw.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnVeiw.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }

        private async void RibtnVeiw_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                    string id = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCMSId").ToString();
                    string code = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCode").ToString();
                    string desc = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDesc").ToString();
                    string created = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserCaptured").ToString();
                    string dtCreated = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDateCaptured").ToString();
                    string approved = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcUserApproved").ToString();
                    string dtApproved = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcDateApproved").ToString();
                    string zack = await Client.GetCMSArchiveImage(id ,code);
                    if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png"))
                    {
                        Image img = Image.FromFile(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png");
                        DataTable dtLines = new DataTable(){Columns =
                        {
                            new DataColumn("gcItem", typeof(string)),
                            new DataColumn("gcUnit", typeof(string)),
                            new DataColumn("gcVarType", typeof(string)),
                            new DataColumn("gcVal1", typeof(string)),
                            new DataColumn("gcVal2", typeof(string)),
                            new DataColumn("gcInspec", typeof(string))
                        }};

                        string lines = Client.GetCMSArchiveLines(id);
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
                            using (frmVeiwApproval veiw = new frmVeiwApproval(img, code, desc, created, dtCreated, approved, dtApproved, dtLines, true))
                            {
                                veiw.ShowDialog();
                            }
                            img.Dispose();
                            break;
                        case "0":
                            dtLines.Rows.Clear();

                            SplashScreenManager.CloseForm();
                            using (frmVeiwApproval veiw = new frmVeiwApproval(img, code, desc, created, dtCreated, approved, dtApproved, dtLines, true))
                            {
                                veiw.ShowDialog();
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
                            using (msg = new frmMsg("A connection level error has occured", lines, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retrieving data";
                            errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lines;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm();
                        using (msg = new frmMsg("A connection level error has occured", "The image was not able to be retrieved", GlobalVars.msgState.Error))
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
                catch (Exception )
                {
                    // ignored
                }
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getCMSArchives();
        }
    }
}
