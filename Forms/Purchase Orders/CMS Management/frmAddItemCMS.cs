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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using RTIS_Vulcan_UI.Classes;

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders
{
    public partial class frmAddItemCMS : Form
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
        private bool handling = false;

        DataTable dtItems = new DataTable();
        public string id { get; set; }
        public string code { get; set; }
        public string desc { get; set; }
        public frmAddItemCMS(string _id, string _code, string _desc)
        {
            InitializeComponent();
            id = _id;
            code = _code;
            desc = _desc;
        }
        private void frmAddItemCMS_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblDesc.Text = desc;
            setupDataTable();
        }
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbUnits;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbType;
        private void setupDataTable()
        {
            dtItems.Columns.Add(new DataColumn("gcItem", typeof(string)));
            dtItems.Columns.Add(new DataColumn("gcUOM", typeof(string)));
            dtItems.Columns.Add(new DataColumn("gcType", typeof(string)));
            dtItems.Columns.Add(new DataColumn("gcVal1", typeof(string)));
            dtItems.Columns.Add(new DataColumn("gcVal2", typeof(string)));
            dtItems.Columns.Add(new DataColumn("gcInspection", typeof(string)));

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

            dgItems.DataSource = dtItems;
            dgItems.MainView.GridControl.DataSource = dtItems;
            dgItems.MainView.GridControl.EndUpdate();
            gvItems.RefreshData();

            refreshItems();
        }
        private void refreshItems()
        {
            try
            {
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getCMSItems);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void getCMSItems()
        {
            try
            {
                dataLines = Client.GetCMSItemsAdd();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setCMSItems();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void setCMSItems()
        {
            try
            {
                string itemLines = dataLines;
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
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("No CMS items found", "No CMS items were found, these can be added through CMS Admin", GlobalVars.msgState.Info))
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
        private void getCMSUOMs()
        {
            try
            {
                dataLines = Client.GetCMSUOMsAdd();
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setCMSUOMs();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void setCMSUOMs()
        {
            try
            {
                string itemLines = dataLines;
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
                            ppnlWait.SendToBack();
                            break;
                        case "0":
                            ricmbItems.Items.Clear();
                            ricmbItems.Items.Add("- No CMS items were found -");
                            ppnlWait.SendToBack();
                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("No CMS items found", "No CMS UOMs were found, these can be added through CMS Admin", GlobalVars.msgState.Info))
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
            }
            catch (Exception ex)
            {
                handling = false;
                ExHandler.showErrorEx(ex);
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    string item = gvItems.GetRowCellValue(i, nameof(gcItem)).ToString();
                    string unit = gvItems.GetRowCellValue(i, nameof(gcUOM)).ToString();
                    string op = gvItems.GetRowCellValue(i, nameof(gcType)).ToString();
                    string val1 = op == "Passes Test" ? "0" : gvItems.GetRowCellValue(i, nameof(gcVal1)).ToString();
                    string val2 =  op == ">" || op == "<" || op == "Passes Test" ? "0" : gvItems.GetRowCellValue(i, nameof(gcVal2)).ToString();
                    string inspec = gvItems.GetRowCellValue(i, nameof(gcInspection)).ToString();
                    lines.Add(item + "|" + unit + "|" + op + "|" + val1 + "|" + val2 + "|" + inspec);
                }

                string saved = Client.CreateCMSDocument(id + "|" + code + "|" + GlobalVars.userName + "*" + string.Join("~", lines));
                if (!string.IsNullOrWhiteSpace(saved))
                    switch (saved.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Success", "The cms document has been added and is awaiting approval",
                                GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case "0":
                            saved = saved.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", saved,
                                GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            saved = saved.Remove(0, 3);
                            errMsg = saved.Split('|')[0];
                            errInfo = saved.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            saved = saved.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", saved, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retrieving roles";
                            errInfo = "Unexpected error while retrieving roles" + Environment.NewLine +
                                      "Data Returned:" + Environment.NewLine + saved;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                else
                {
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error);
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
