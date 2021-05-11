using DevExpress.XtraGrid.Views.Grid;
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

namespace RTIS_Vulcan_UI.Forms
{
    public partial class frmPGMContainers : Form
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
        public frmPGMContainers(string _itemCode, string _lotNumber)
        {
            InitializeComponent();
            itemCode = _itemCode;
            lotNumber = _lotNumber;
        }
        private void frmPGMContainers_Load(object sender, EventArgs e)
        {
            setupDataTable();
            getPGMContainers();

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEvoManu = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { chkEvoManu });
            chkEvoManu.CheckedChanged += ChkEvoManu_CheckedChanged;
            gcManufactured.ColumnEdit = chkEvoManu;
        }
        private void ChkEvoManu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string container = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcCont").ToString();
                string updated = Client.UpdatePGMContainerManufacture(itemCode + "|" + lotNumber + "|" + container);
                if (updated != string.Empty)
                {
                    switch (updated.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("PGM Manufacture", "Item marked as manufactured", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            lblHeader.Focus();
                            break;
                        case "0":
                            container = container.Remove(0, 2);
                            msg = new frmMsg("PGM Manufacture", container, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            container = container.Remove(0, 3);
                            errMsg = container.Split('|')[0];
                            errInfo = container.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            container = container.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", container, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + container;
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
        public void setupDataTable()
        {
            try
            {
                dtPGMLines.Columns.Add("gcCont", typeof(string));
                dtPGMLines.Columns.Add("gcWeight", typeof(string));
                dtPGMLines.Columns.Add("gcUserAdded", typeof(string));
                dtPGMLines.Columns.Add("gcDateAdded", typeof(string));
                dtPGMLines.Columns.Add("gcManufactured", typeof(bool));
                dtPGMLines.Columns.Add("gcDateManuf", typeof(string));
                dtPGMLines.Columns.Add("gcUserManufactured", typeof(string));
                dtPGMLines.Columns.Add("gcUserEdited", typeof(string));
                dtPGMLines.Columns.Add("gcDateEdited", typeof(string));
                dtPGMLines.Columns.Add("gcReason", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getPGMContainers()
        {
            try
            {
                string containers = Client.GetPGMContainers(itemCode + "|" + lotNumber);
                if (containers != string.Empty)
                {
                    switch (containers.Split('*')[0])
                    {
                        case "1":
                            dtPGMLines.Rows.Clear();
                            containers = containers.Remove(0, 2);
                            string[] ItemArray = containers.Split('~');
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
                            dataPulled = false;                           
                            break;
                        case "0":
                            dtPGMLines.Rows.Clear();
                            dgItems.DataSource = dtPGMLines;
                            dgItems.MainView.GridControl.DataSource = dtPGMLines;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();
                            containers = containers.Remove(0, 2);
                            msg = new frmMsg("PGM Manufacture", "No containers found for PGM...", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            containers = containers.Remove(0, 3);
                            errMsg = containers.Split('|')[0];
                            errInfo = containers.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            containers = containers.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", containers, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:

                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving PGM Manufacture items";
                            errInfo = "Unexpected error while retreiving  PGM Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + containers;
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
        private void gvItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                //View.FocusedColumn.FieldName
                GridView View = sender as GridView;
                if (View.FocusedColumn.FieldName == "gcManufactured")
                {
                    bool manuf = Convert.ToBoolean(gvItems.GetRowCellValue(View.FocusedRowHandle, View.Columns["gcManufactured"]));
                    if (manuf == true)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
