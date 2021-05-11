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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Management
{
    public partial class frmEditCMS : Form
    {
        #region Error handling
        private frmMsg msg;
        private string errMsg;
        private string errInfo;

        private StackTrace st;
        private string msgStr = string.Empty;
        private string infoStr = string.Empty;
        #endregion

        private bool handling = false;
        private DataTable dtLines;
        private string headerID { get; set; }
        private bool docApproved { get; set; }
        private string code { get; set; }
        private string desc { get; set; }
        private string stockID { get; set; }
        private string version { get; set; }
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbUnits;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbType;

        public frmEditCMS(string _headerID, bool _docApproved, string _code, string _desc, string _stockID, string _version)
        {
            InitializeComponent();
            headerID = _headerID;
            docApproved = _docApproved;
            code = _code;
            desc = _desc;
            stockID = _stockID;
            version = _version;
        }
        private void frmEditCMS_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblDesc.Text = desc;
            setupDataTable();
            getCMSLines();
        }
        private void setupDataTable()
        {
            dtLines = new DataTable(){Columns =
            {
                new DataColumn("gcItem", typeof(string)),
                new DataColumn("gcUOM", typeof(string)),
                new DataColumn("gcType", typeof(string)),
                new DataColumn("gcVal1", typeof(string)),
                new DataColumn("gcVal2", typeof(string)),
                new DataColumn("gcInspection", typeof(string))
            }};
            gvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            gvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            ricmbItems = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricmbItems });
            gcItem.ColumnEdit = ricmbItems;

            ricmbUnits = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricmbUnits });
            gcUOM.ColumnEdit = ricmbUnits;

            ricmbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricmbType });
            //ricmbType.SelectedIndexChanged += RicmbType_SelectedIndexChanged;
            gcType.ColumnEdit = ricmbType;
            ricmbType.Items.Add("<");
            ricmbType.Items.Add(">");
            ricmbType.Items.Add("=<");
            ricmbType.Items.Add("=>");
            ricmbType.Items.Add("Between");
            ricmbType.Items.Add("Passes Test");
            byte[] A = new[] {(byte)194 ,(byte)177}; 
            ricmbType.Items.Add(UTF8Encoding.UTF8.GetString(A));

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnDelete.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnDelete });
            ribtnDelete.Click += RibtnDelete_Click;
            gcDelete.ColumnEdit = ribtnDelete;
            gcDelete.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                gvItems.DeleteRow(gvItems.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void getCMSLines()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string lines = Client.GetCMSApprovalLinesEdit(headerID);
                if (!string.IsNullOrWhiteSpace(lines))
                {
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
                            dgItems.DataSource = dtLines;
                            dgItems.MainView.GridControl.DataSource = dtLines;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            foreach (GridColumn item in gvItems.Columns)
                            {
                                item.BestFit();
                            }

                            getCMStems();
                            //SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            dgItems.DataSource = dtLines;
                            dgItems.MainView.GridControl.DataSource = dtLines;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            dtLines.Rows.Clear();
                            getCMStems();
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
        private void getCMStems()
        {
            try
            {
                string itemLines = Client.GetCMSItemsAdd();
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            //dtItems.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    ricmbItems.Items.Add(item);
                                }
                            }
                            getCMSUOMs();
                            break;
                        case "0":
                            ricmbItems.Items.Clear();
                            ricmbItems.Items.Add("- No CMS items were found -");
                            getCMSUOMs();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            itemLines = itemLines.Remove(0, 3);
                            errMsg = itemLines.Split('|')[0];
                            errInfo = itemLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                catch (Exception )
                {
                    // ignored
                }
                ExHandler.showErrorEx(ex);
            }
        }
        private void getCMSUOMs()
        {
            try
            {
                string itemLines = Client.GetCMSUOMsAdd();
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            //dtItems.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    ricmbUnits.Items.Add(item);
                                }
                            }

                            foreach (GridColumn item in gvItems.Columns)
                            {
                                item.BestFit();                                
                            }
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            ricmbItems.Items.Clear();
                            ricmbItems.Items.Add("- No CMS items were found -");
                            SplashScreenManager.CloseForm();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("FG Transfer requests", "No transfer requests were found for the given date range", GlobalVars.msgState.Info))
                            {
                                msg.ShowDialog();
                            }                            
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            itemLines = itemLines.Remove(0, 3);
                            errMsg = itemLines.Split('|')[0];
                            errInfo = itemLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
                catch (Exception )
                {
                    // ignored
                }
                ExHandler.showErrorEx(ex);
            }
        }
        private void gvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView View = sender as GridView;
            if (View.IsNewItemRow(e.RowHandle))
            {
                View.ClearColumnErrors();
                DevExpress.XtraGrid.Columns.GridColumn cmItemCode = gvItems.Columns[nameof(gcItem)];
                var itemcode = View.GetRowCellValue(e.RowHandle, cmItemCode);
                if (string.IsNullOrWhiteSpace(itemcode.ToString()))
                {
                    e.Valid = false;
                    View.SetColumnError(cmItemCode, "A Item Code Is Required...");
                }

                DevExpress.XtraGrid.Columns.GridColumn cmUOM = gvItems.Columns[nameof(gcUOM)];
                var uom = View.GetRowCellValue(e.RowHandle, cmUOM);
                if (string.IsNullOrWhiteSpace(uom.ToString()))
                {
                    e.Valid = false;
                    View.SetColumnError(cmUOM, "A Item Code Is Required...");
                }

                DevExpress.XtraGrid.Columns.GridColumn cmType = gvItems.Columns[nameof(gcType)];
                var typ = View.GetRowCellValue(e.RowHandle, cmType);
                if (string.IsNullOrWhiteSpace(typ.ToString()))
                {
                    e.Valid = false;
                    View.SetColumnError(cmType, "A Variance Type Is Required...");
                }

                DevExpress.XtraGrid.Columns.GridColumn cmInspec = gvItems.Columns[nameof(gcInspection)];
                var inspec = View.GetRowCellValue(e.RowHandle, cmInspec);
                if (string.IsNullOrWhiteSpace(inspec.ToString()))
                {
                    e.Valid = false;
                    View.SetColumnError(cmInspec, "An inspection type is required...");
                }
            }
        }
        private void gvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //if (!handling)
                //{
                //    handling = true;
                //    string selectedItem = e.Value.ToString();
                //    GridView _view = sender as GridView;
                //    _view.SetRowCellValue(e.RowHandle, e.Column.FieldName, selectedItem);
                //}
                if (!handling)
                {
                    handling = true;
                    string selectedItem = e.Value.ToString();
                    GridView _view = sender as GridView;
                    if (e.Column.Name == nameof(gcType))
                    {
                        if (selectedItem == ">" || selectedItem == "<" || selectedItem == "=<" || selectedItem == "=>")
                        {
                            _view.SetRowCellValue(e.RowHandle, e.Column.FieldName, selectedItem);
                            _view.SetRowCellValue(e.RowHandle, nameof(gcVal2), "NA");
                        }
                        else if (selectedItem == "Passes Test")
                        {
                            //Passes Test
                            _view.SetRowCellValue(e.RowHandle, e.Column.FieldName, selectedItem);
                            _view.SetRowCellValue(e.RowHandle, nameof(gcVal2), "NA");
                            _view.SetRowCellValue(e.RowHandle, nameof(gcVal1), "NA");
                        }
                        else
                        {
                            _view.SetRowCellValue(e.RowHandle, e.Column.FieldName, selectedItem);
                        }
                    }
                    else
                    {
                        _view.SetRowCellValue(e.RowHandle, e.Column.FieldName, selectedItem);
                    }
                   
                }
                handling = false;
                //handling = false;
            }
            catch (Exception ex)
            {
                handling = false;
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();
                for (int i = 0; i < dtLines.Rows.Count; i++)
                {
                    string item = gvItems.GetRowCellValue(i, nameof(gcItem)).ToString();
                    string unit = gvItems.GetRowCellValue(i, nameof(gcUOM)).ToString();
                    string op = gvItems.GetRowCellValue(i, nameof(gcType)).ToString();
                    //string val1 = gvItems.GetRowCellValue(i, nameof(gcVal1)).ToString();
                    //string val2 =  op == ">" || op == "<" ? "0" : gvItems.GetRowCellValue(i, nameof(gcVal2)).ToString();
                    string val1 = op == "Passes Test" ? "0" : gvItems.GetRowCellValue(i, nameof(gcVal1)).ToString();
                    string val2 =  op == ">" || op == "<" || op == "Passes Test" ? "0" : gvItems.GetRowCellValue(i, nameof(gcVal2)).ToString();
                    string inspec = gvItems.GetRowCellValue(i, nameof(gcInspection)).ToString();
                    lines.Add(item + "|" + unit + "|" + op + "|" + val1 + "|" + val2 + "|" + inspec);
                }

                string edited = string.Empty;
                if (docApproved)
                {
                    edited = Client.CreateNewDocVersion(stockID + "|" + code + "|" + GlobalVars.userName + "|" + version + "*" + string.Join("~", lines));
                }
                else
                {
                    edited = Client.EditExistingDocument(headerID + "*" + string.Join("~", lines));
                }

                if (!string.IsNullOrWhiteSpace(edited))
                {
                    switch (edited.Split('*')[0])
                    {
                        case "1":
                            using (msg = new frmMsg("Success", "The cms document has been edited and is awaiting approval", GlobalVars.msgState.Success))
                            {
                                msg.ShowDialog();
                            }
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case "0":
                            edited = edited.Remove(0, 2);
                            using (msg = new frmMsg("The following server side issue was encountered:", edited, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        case "-1":
                            edited = edited.Remove(0, 3);
                            errMsg = edited.Split('|')[0];
                            errInfo = edited.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            edited = edited.Remove(0, 2);
                            using (msg = new frmMsg("A connection level error has occured", edited, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retrieving roles";
                            errInfo = "Unexpected error while retrieving roles" + Environment.NewLine +
                                      "Data Returned:" + Environment.NewLine + edited;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
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

        private void gvItems_RowStyle(object sender, RowStyleEventArgs e)
        {
            
        }

        private void gvItems_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string op = View.GetRowCellValue(e.RowHandle, View.Columns[nameof(gcType)]).ToString();
                    if ((op == ">" || op == "<" || op == "=<" || op == "=>") && e.Column.Name == nameof(gcVal2))
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.BackColor2 = Color.Gray;
                    }

                    if (op == "Passes Test" && (e.Column.Name == nameof(gcVal2) || e.Column.Name == nameof(gcVal1)))
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.BackColor2 = Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void gvItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                GridView veiw = sender as GridView;
                if (veiw.FocusedColumn.Name == nameof(gcVal1))
                {
                    string op = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcType)).ToString();
                    if (op == "Passes Test")
                    {
                        e.Cancel = true;
                    }
                }
                if (veiw.FocusedColumn.Name == nameof(gcVal2))
                {
                    string op = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, nameof(gcType)).ToString();
                    if (op == ">" || op == "<" || op == "=<" || op == "=>" || op == "Passes Test")
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //ExHandler.showErrorEx(ex);
            }
        }
    }
}
