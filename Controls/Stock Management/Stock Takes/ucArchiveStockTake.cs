using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Stock_Take;
using System.Threading;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using System.IO;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_UI.Controls.Stock_Management.Stock_Takes
{
    public partial class ucArchiveStockTake : UserControl
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

        public ucArchiveStockTake()
        {
            InitializeComponent();
        }
        private void ucArchiveStockTake_Load(object sender, EventArgs e)
        {
            SetUpTable();
            getRTStockTakes();
        }
        public void getRTStockTakes()
        {
            try
            {
                string stockTakes = Client.GetArchiveRTStockTakes();
                if (stockTakes != string.Empty)
                {
                    if (stockTakes != "")
                    {
                        switch (stockTakes.Split('*')[0])
                        {
                            case "1":
                                cmbStockTakes.Properties.Items.Clear();
                                stockTakes = stockTakes.Remove(0, 2);
                                string[] allStockTakes = stockTakes.Split('~');
                                foreach (string stockTake in allStockTakes)
                                {
                                    if (stockTake != "")
                                    {
                                        cmbStockTakes.Properties.Items.Add(stockTake);
                                    }
                                }
                                break;
                            case "0":
                                cmbStockTakes.Properties.Items.Clear();
                                break;
                            case "-1":
                                MessageBox.Show("An error has occured: " + Environment.NewLine + Environment.NewLine + stockTakes.Split('*')[1], "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show("An unexpected error has occured", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot connect to server", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot connect to server", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + Environment.NewLine + Environment.NewLine + ex.Message, "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetUpTable()
        {
            dt.Columns.Add(new DataColumn("gcTickets"));
            dt.Columns.Add(new DataColumn("gclineID"));
            dt.Columns.Add(new DataColumn("gcItemCode"));
            dt.Columns.Add(new DataColumn("gcBarcode"));
            dt.Columns.Add(new DataColumn("gcItemDesc"));
            dt.Columns.Add(new DataColumn("gcBin"));
            dt.Columns.Add(new DataColumn("gcLot"));
            dt.Columns.Add(new DataColumn("gcCounted"));
            dt.Columns.Add(new DataColumn("gcCounted2"));
            dt.Columns.Add(new DataColumn("gcSystem"));
            dt.Columns.Add(new DataColumn("gcVarience"));
            dt.Columns.Add(new DataColumn("gcWhseCode"));
            dt.Columns.Add(new DataColumn("gcSerials"));
            dt.Columns.Add(new DataColumn("gcIsCounted"));
            dt.Columns.Add(new DataColumn("gcWhseName"));
            dt.Columns.Add(new DataColumn("gcOnST", typeof(bool)));

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnTickets = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnTickets.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnTickets });
            ribtnTickets.Click += RibtnTickets_Click;
            gcTickets.ColumnEdit = ribtnTickets;
            gcTickets.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnTickets.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        }
        private void RibtnTickets_Click(object sender, EventArgs e)
        {
            try
            {
                string headerID = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gclineID").ToString();
                string itemCode = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcItemCode").ToString();
                string lotNumber = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcLot").ToString();
                frmSTTickets stTickets = new frmSTTickets(headerID, itemCode, lotNumber, true);
                stTickets.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshItems()
        {
            if (cmbStockTakes.Text != "")
            {
                ppnlWait.BringToFront();
                recordsPulled = false;
                Application.DoEvents();
                Thread thread = new Thread(getDataLines);
                thread.Start();
            }
        }
        public void getDataLines()
        {
            try
            {
                dataLines = DirectQueries.UI_GetRTStockTakeArchiveLines(cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1));
                recordsPulled = true;
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setDataLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setDataLines()
        {
            try
            {
                if (recordsPulled == true)
                {
                    if (dataLines != string.Empty)
                    {
                        switch (dataLines.Split('*')[0])
                        {
                            case "1":
                                dt = DirectQueries.stDT;
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                Application.DoEvents();
                                break;
                            case "0":
                                dt.Rows.Clear();
                                bindDataGrid();
                                ppnlWait.SendToBack();
                                Application.DoEvents();
                                break;
                            case "-1":
                                MessageBox.Show("Server error: " + dataLines.Split('*')[1], "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                MessageBox.Show("Cannot connect to server", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot connect to server", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void bindDataGrid()
        {
            dgItems.DataSource = dt;
            dgItems.MainView.GridControl.DataSource = dt;
            dgItems.MainView.GridControl.EndUpdate();
        }
        private void cmbStockTakes_TextChanged(object sender, EventArgs e)
        {
            refreshItems();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshItems();
        }
        private void gvItems_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    decimal counted = Convert.ToDecimal(gvItems.GetRowCellDisplayText(e.RowHandle, View.Columns["gcCounted"]).Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep));
                    decimal counted2 = Convert.ToDecimal(gvItems.GetRowCellDisplayText(e.RowHandle, View.Columns["gcCounted2"]).Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep));
                    decimal system = Convert.ToDecimal(gvItems.GetRowCellDisplayText(e.RowHandle, View.Columns["gcSystem"]).Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep));
                    bool onST = Convert.ToBoolean(gvItems.GetRowCellValue(e.RowHandle, View.Columns["gcOnST"]));
                    if (onST)
                    {
                        if (counted == counted2)
                        {
                            if ((counted > system) && (counted == counted2))
                            {
                                e.Appearance.BackColor = Color.LightBlue;
                                e.Appearance.BackColor2 = Color.LightBlue;
                            }

                            if ((system > counted) && (counted == counted2))
                            {
                                if (counted != 0)
                                {
                                    e.Appearance.BackColor = Color.Salmon;
                                    e.Appearance.BackColor2 = Color.Salmon;
                                }
                            }

                            if ((counted == system) && (counted2 == system))
                            {
                                if (counted != 0)
                                {
                                    e.Appearance.BackColor = Color.LightGreen;
                                    e.Appearance.BackColor2 = Color.LightGreen;
                                }
                            }
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.MediumPurple;
                            e.Appearance.BackColor2 = Color.MediumPurple;
                        }
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.Yellow;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStockTakes.Text != string.Empty)
                {
                    bool found = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string qty1 = Convert.ToString(gvItems.GetRowCellValue(i, "gcCounted")).Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep);
                        string qty2 = Convert.ToString(gvItems.GetRowCellValue(i, "gcCounted2")).Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep);
                        if (qty1 != qty2)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        string exported = buildCSV();
                        if (exported == "1")
                        {
                            Process.Start(@"C:\RTIS\Stock Takes\Stock Take Records\");
                        }
                    }
                    else
                    {
                        msg = new frmMsg("", "There are non matching quantities in the stock take, are you sure you wish to export a csv?", GlobalVars.msgState.Question);
                        msg.ShowDialog();

                        DialogResult result = msg.DialogResult;
                        if (result == DialogResult.Yes)
                        {
                            string exported = buildCSV();
                            if (exported == "1")
                            {
                                Process.Start(@"C:\RTIS\Stock Takes\Stock Take Records\");
                            }
                        }
                    }
                }
                else
                {
                    msg = new frmMsg("No Stock Take Selected", "Please select a stock take!", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public string buildCSV()
        {
            try
            {
                List<ListViewItem> lstItems = new List<ListViewItem>();
                foreach (GridColumn gc in gvItems.Columns)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = gc.Caption;
                    item.SubItems.Add(gc.FieldName);
                    lstItems.Add(item);
                }

                frmExportLayout bob = new frmExportLayout(lstItems);
                DialogResult res = bob.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string _format = bob.csvFormat;
                    string _delimiter = bob.csvDelimiter;
                    if (_delimiter == "TAB")
                    {
                        _delimiter = "\t";
                    }
                    string _name = bob.csvName;

                    if (Directory.Exists(@"C:\RTIS\Stock Takes\Stock Take Records") == false)
                    {
                        Directory.CreateDirectory(@"C:\RTIS\Stock Takes\Stock Take Records");
                    }
                    if (File.Exists(@"C:\RTIS\Stock Takes\Stock Take Records\" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + " - " + _name + ".csv"))
                    {
                        File.Delete(@"C:\RTIS\Stock Takes\Stock Take Records\" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + " - " + _name + ".csv");
                    }

                    gvItems.ApplyFindFilter("");
                    foreach (GridColumn gc in gvItems.Columns)
                    {
                        gc.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                    }
                    Application.DoEvents();

                    string writeLine = string.Empty;
                    var builder = new StringBuilder();
                    builder.Append(writeLine);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bool onST = Convert.ToBoolean(gvItems.GetRowCellValue(i, "gcOnST").ToString());
                        if (onST)
                        {
                            string line = string.Empty;
                            var builder1 = new StringBuilder();
                            builder1.Append(line);
                            foreach (string column in _format.Split('|'))
                            {
                                if (column != string.Empty)
                                {
                                    builder1.Append(gvItems.GetRowCellValue(i, column) + _delimiter.Replace("'", ""));
                                }
                            }
                            line = builder1.ToString();
                            line = line.Substring(0, line.Length - 1);
                            builder.Append(line + "|");
                        }
                    }
                    writeLine = builder.ToString();
                    File.Create(@"C:\RTIS\Stock Takes\Stock Take Records\" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + " - " + _name + ".csv").Close();
                    if (writeLine != string.Empty)
                    {
                        File.WriteAllLines(@"C:\RTIS\Stock Takes\Stock Take Records\" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + " - " + _name + ".csv", writeLine.Split('|'));
                    }
                    msg = new frmMsg("Success", "A csv file has been exported for this stock take", GlobalVars.msgState.Success);
                    msg.ShowDialog();
                    return "1";
                }
                else
                {
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                return "-1";
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStockTakes.Text != string.Empty)
                {
                    frmSTReport frm_stReport = new frmSTReport();
                    DialogResult result = frm_stReport.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string paramInfo = Client.GetSTReportInfoArchive(cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1));
                        switch (paramInfo.Split('*')[0])
                        {
                            case "1":
                                paramInfo = paramInfo.Remove(0, 2);
                                string totalLinesEvo = paramInfo.Split('|')[0];
                                string count1Lines = paramInfo.Split('|')[1];
                                string count2Lines = paramInfo.Split('|')[2];
                                string totalLines = paramInfo.Split('|')[3];

                                rptInvCount stReport = new rptInvCount();
                                string connectionString = "Data Source=" + GlobalVars.SQLServer + "; Initial Catalog=" + GlobalVars.RTDB +
                                "; user ID=" + GlobalVars.SqlUser + "; password=" + GlobalVars.SqlPass + ";Max Pool Size=99999;";
                                CustomStringConnectionParameters connectionParams = new CustomStringConnectionParameters(connectionString);
                                stReport.sqlDataSource1.ConnectionParameters = connectionParams;

                                DevExpress.DataAccess.Sql.CustomSqlQuery query = stReport.sqlDataSource1.Queries[0] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query.Sql = "SELECT s.[Code] AS [ItemCode], s.[Description_1] AS [Desc] ,b.[cBinLocationName] AS Bin ,il.[fCountQty]  AS [Counted], [fCountQty2] AS [Counted2],il.[fSystemQty] AS [System], ABS(il.[fCountQty] - il.[fSystemQty]) AS [Variance] ,w.[Code] AS [WHSE]  ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND il.[fSystemQty] > il.[fCountQty]  AND il.[fCountQty] <> 0 AND il.[fCountQty] = il.[fCountQty2] AND il.[bOnST] = 1 ORDER BY s.[Code]";

                                DevExpress.DataAccess.Sql.CustomSqlQuery query2 = stReport.sqlDataSource1.Queries[1] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query2.Sql = "SELECT s.[Code] AS [ItemCode], s.[Description_1] AS [Desc] , b.[cBinLocationName] AS Bin ,il.[fCountQty]  AS [Counted], [fCountQty2] AS [Counted2] ,il.[fSystemQty] AS [System], ABS(il.[fCountQty] - il.[fSystemQty]) AS [Variance] ,w.[Code] AS [WHSE] ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND il.[fSystemQty] < il.[fCountQty] AND il.[fCountQty] = il.[fCountQty2] AND il.[bOnST] = 1 ORDER BY s.[Code]";

                                DevExpress.DataAccess.Sql.CustomSqlQuery query3 = stReport.sqlDataSource1.Queries[2] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query3.Sql = "SELECT s.[Code] AS [ItemCode] , s.[Description_1] AS [Desc] , b.[cBinLocationName] AS Bin ,'0'  AS [Counted], [fCountQty2] AS [Counted2] ,il.[fSystemQty] AS [System], ABS(il.[fCountQty] - il.[fSystemQty]) AS [Variance] ,w.[Code] AS [WHSE] ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND (il.[fCountQty] = 0 OR il.[fCountQty] IS NULL OR il.[fCountQty] = '') AND (il.[fCountQty2] = 0 OR il.[fCountQty2] IS NULL OR il.[fCountQty2] = '') AND (il.[fCountQty] <> 0 OR il.[fCountQty2] <> 0 OR il.[fSystemQty] <> 0) AND il.[bOnST] = 1 ORDER BY s.[Code]";

                                DevExpress.DataAccess.Sql.CustomSqlQuery query4 = stReport.sqlDataSource1.Queries[3] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query4.Sql = "SELECT s.[Code] AS [ItemCode], s.[Description_1] AS [Desc], b.[cBinLocationName] AS Bin ,il.[fCountQty]  AS [Counted], [fCountQty2] AS [Counted2],il.[fSystemQty] AS [System], ABS(il.[fCountQty] - il.[fSystemQty]) AS [Variance] ,w.[Code] AS [WHSE] ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND il.[fCountQty] = il.[fSystemQty] AND il.[fCountQty] <> 0 AND il.[fSystemQty] <> 0 AND il.[fCountQty] = il.[fCountQty2] AND il.[bOnST] = 1 ORDER BY s.[Code]";

                                DevExpress.DataAccess.Sql.CustomSqlQuery query5 = stReport.sqlDataSource1.Queries[4] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query5.Sql = "SELECT s.[Code] AS [ItemCode], s.[Description_1] AS [Desc] , b.[cBinLocationName] AS Bin ,il.[fCountQty]  AS [Counted], [fCountQty2] AS [Counted2], ABS(il.[fCountQty2] - il.[fCountQty]) AS [Variance] ,il.[fSystemQty] AS [System], w.[Code] AS [WHSE] ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND il.[fCountQty] <> il.[fCountQty2] AND il.[bOnST] = 1 ORDER BY s.[Code]";

                                DevExpress.DataAccess.Sql.CustomSqlQuery query6 = stReport.sqlDataSource1.Queries[5] as DevExpress.DataAccess.Sql.CustomSqlQuery;
                                query6.Sql = "SELECT s.[Code] AS [ItemCode], s.[Description_1] AS [Desc], b.[cBinLocationName] AS Bin ,il.[fCountQty]  AS [Counted], [fCountQty2] AS [Counted2],il.[fSystemQty] AS [System], ABS(il.[fCountQty] - il.[fSystemQty]) AS [Variance] ,w.[Code] AS [WHSE] ,i.[dPrepared] FROM [RTIS_InvCountArchiveLines] il INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID] INNER JOIN [" + GlobalVars.EvoDB + "].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_btblBINLocation] b ON b.[idBinLocation] = il.[iBinLocationId] LEFT JOIN [" + GlobalVars.EvoDB + "].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking] WHERE i.[cInvCountNo] = '" + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "' AND il.[bOnST] = 0 ORDER BY s.[Code]";


                                if (frm_stReport.negativeVars == false)
                                {
                                    stReport.dtlRptNeg.Visible = false;
                                }

                                if (frm_stReport.positiveVars == false)
                                {
                                    stReport.dtlRptPos.Visible = false;
                                }

                                if (frm_stReport.uncounted == false)
                                {
                                    stReport.dtlRptUnc.Visible = false;
                                }

                                if (frm_stReport.matching == false)
                                {
                                    stReport.dtlRptMatch.Visible = false;
                                }

                                if (frm_stReport.unmatching == false)
                                {
                                    stReport.dtlRptNonMatch.Visible = false;
                                }

                                if (frm_stReport.noST == false)
                                {
                                    stReport.dtNonST.Visible = false;
                                }

                                stReport.STNum.Value = cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1);
                                stReport.EvoItems.Value = totalLinesEvo;
                                stReport.TotalItems.Value = totalLines;
                                stReport.Count1.Value = count1Lines;
                                stReport.Count2.Value = count2Lines;
                                ReportPrintTool printTool = new ReportPrintTool(stReport);
                                printTool.ShowPreview();
                                break;
                            case "-1":
                                paramInfo = paramInfo.Remove(0, 3);
                                errMsg = paramInfo.Split('|')[0];
                                errInfo = paramInfo.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                paramInfo = paramInfo.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", paramInfo, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving item tickets";
                                errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + paramInfo;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                }
                else
                {
                    msg = new frmMsg("No Stock Take Selected", "Please select a stock take!", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("", "Are you sure you want to delete: " + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "?", GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string removed = Client.RemoveStockTake(cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1));
                    if (removed != string.Empty)
                    {
                        switch (removed.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "Stock Take " + cmbStockTakes.Text.Split('-')[0].Substring(0, cmbStockTakes.Text.Split('-')[0].Length - 1) + "has been removed", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                dt.Rows.Clear();
                                cmbStockTakes.Text = string.Empty;
                                getRTStockTakes();
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
