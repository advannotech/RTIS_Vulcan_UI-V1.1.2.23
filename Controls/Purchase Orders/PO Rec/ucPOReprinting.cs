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
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using RTIS_Vulcan_UI.Reports;
using DevExpress.DataAccess.ConnectionParameters;
using RTIS_Vulcan_UI.Controls.Purchase_Orders.PO_Rec;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.IO;

namespace RTIS_Vulcan_UI.Controls.Purchase_Orders.PO_Rec
{
    public partial class ucPOReprinting : UserControl
    {


        DataTable dtrPOLines = new DataTable();
        public bool dataPulled = false;
        public string dataLines = string.Empty;
        public string poVendor;


        public bool lotPrintItem = false;
        public bool labelsPrinted = false;
        public string labelInfo = string.Empty;
        public string lotNum = string.Empty;
        public string qtyPerLabel = string.Empty;
        public string LastLabelQty = string.Empty;
        public double qty = 0;

        public bool lotReprintItem = false;
        public bool labelsReprinted = false;
        public string labelReprintInfo = string.Empty;
        public string ReprintQty = string.Empty;
        public string ReprintQtyPerLabel = string.Empty;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion


        public void setupDataTable()
        {
            try
            {
                dtrPOLines.Columns.Add("gcCode", typeof(string));
                dtrPOLines.Columns.Add("gcDesc", typeof(string));
                dtrPOLines.Columns.Add("gcDesc2", typeof(string));
                dtrPOLines.Columns.Add("gcLotNum", typeof(string));
                dtrPOLines.Columns.Add("gcOrderQty", typeof(string)); //Evo Order Qty
                dtrPOLines.Columns.Add("gcRecQty", typeof(string));//Evo Received Qty
                dtrPOLines.Columns.Add("gcReceive", typeof(bool));
                dtrPOLines.Columns.Add("gcPrint", typeof(string));
                dtrPOLines.Columns.Add("gcLotLine", typeof(bool));
                dtrPOLines.Columns.Add("gcViewable", typeof(bool));

                dtrPOLines.Columns.Add("gcRTPrintQty", typeof(string)); //Total Printed
                dtrPOLines.Columns.Add("gcValidated", typeof(string));  //Possible to remove?
                dtrPOLines.Columns.Add("gcScanned", typeof(string));

                dtrPOLines.Columns.Add("gcBack1", typeof(string)); //Qty to receive
                dtrPOLines.Columns.Add("gcBack2", typeof(string)); //Running tally of print qty
                dtrPOLines.Columns.Add("gcBack3", typeof(string)); //Spare Column
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public ucPOReprinting()
        {
            InitializeComponent();
        }

        #region Select PO
        public void getSuppliers()
        {
            try
            {
                string linkedSuppliers = Client.GetLinkedVendors();
                if (linkedSuppliers != string.Empty)
                {
                    switch (linkedSuppliers.Split('*')[0])
                    {
                        case "1":
                            linkedSuppliers = linkedSuppliers.Remove(0, 2);
                            cmbSuppliers.Properties.Items.Clear();
                            foreach (string supplier in linkedSuppliers.Split('~'))
                            {
                                if (supplier != "")
                                {
                                    cmbSuppliers.Properties.Items.Add(supplier);
                                }
                            }
                            break;
                        case "0":
                            linkedSuppliers = linkedSuppliers.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", linkedSuppliers, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            linkedSuppliers = linkedSuppliers.Remove(0, 3);
                            errMsg = linkedSuppliers.Split('|')[0];
                            errInfo = linkedSuppliers.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            linkedSuppliers = linkedSuppliers.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", linkedSuppliers, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving linked suppliers";
                            errInfo = "Unexpected error while retreiving linked suppliers" + Environment.NewLine + "Data Returned:" + Environment.NewLine + linkedSuppliers;
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
        public void getPOs()
        {
            try
            {
                string linkedPOs = Client.GetLinkedPOs();
                if (linkedPOs != string.Empty)
                {
                    switch (linkedPOs.Split('*')[0])
                    {
                        case "1":
                            linkedPOs = linkedPOs.Remove(0, 2);
                            cmbPOs.Properties.Items.Clear();
                            foreach (string PO in linkedPOs.Split('~'))
                            {
                                if (PO != string.Empty)
                                {
                                    cmbPOs.Properties.Items.Add(PO);
                                }
                            }
                            break;
                        case "0":
                            linkedPOs = linkedPOs.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", linkedPOs, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            linkedPOs = linkedPOs.Remove(0, 3);
                            errMsg = linkedPOs.Split('|')[0];
                            errInfo = linkedPOs.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            linkedPOs = linkedPOs.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", linkedPOs, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving linked purchase orders";
                            errInfo = "Unexpected error while retreiving linked purchase orders" + Environment.NewLine + "Data Returned:" + Environment.NewLine + linkedPOs;
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
        private void cmbPOs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPOs.Text != string.Empty)
            {
                cmbSuppliers.Text = string.Empty;
            }
        }
        private void cmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuppliers.Text != string.Empty)
            {
                cmbPOs.Text = string.Empty;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSuppliers.Text != string.Empty || cmbPOs.Text != string.Empty)
            {
                refreshPOItems();
            }
            else
            {
                msg = new frmMsg("Unable to Search", "Please select a vendor or a purchase order!", GlobalVars.msgState.Error);
                msg.ShowDialog();
            }

        }
        #endregion

        #region Load PO
        public void refreshPOItems()
        {
            try
            {
                ppnlWait.BringToFront();
                dataPulled = false;
                Application.DoEvents();
                tmrItems.Start();
                Thread thread = new Thread(reprintPOLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void reprintPOLines()
        {
            try
            {
                if (cmbPOs.Text != string.Empty && cmbSuppliers.Text == string.Empty)
                {
                    dataLines = Client.ReprintPOLines(cmbPOs.Text);
                    dataPulled = true;
                }
                else if (cmbSuppliers.Text != string.Empty && cmbPOs.Text == string.Empty)
                {
                    dataLines = Client.ReprintVendorPOLines(cmbSuppliers.Text);
                    dataPulled = true;
                }
            }
            catch (Exception ex)
            {
                tmrItems.Stop();
                ExHandler.showErrorEx(ex);
            }
        }
        public void setPOLines()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrItems.Stop();
                    string itemLines = dataLines;
                    if (itemLines != string.Empty)
                    {
                        switch (itemLines.Split('*')[0])
                        {
                            case "1":
                                dtrPOLines.Rows.Clear();
                                itemLines = itemLines.Remove(0, 2);
                                lblPO.Text = "Evolution Order: " + itemLines.Split('*')[0];
                                poVendor = itemLines.Split('*')[1];
                                string[] ItemArray = itemLines.Split('*')[2].Split('~');
                                foreach (string item in ItemArray)
                                {
                                    if (item != "")
                                    {
                                        string[] itemS = item.Split('|');
                                        dtrPOLines.Rows.Add(item.Split('|'));
                                    }
                                }
                                dgPOItems.DataSource = dtrPOLines;
                                dgPOItems.MainView.GridControl.DataSource = dtrPOLines;
                                dgPOItems.MainView.GridControl.EndUpdate();
                                gvPOItems.RefreshData();
                                ppnlWait.SendToBack();
                                dataPulled = false;
                                break;
                            case "0":
                                ppnlWait.SendToBack();
                                itemLines = itemLines.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", itemLines, GlobalVars.msgState.Error);
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
                                msgStr = "Unexpected error while retreiving purchase order items";
                                errInfo = "Unexpected error while retreiving purchase order items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
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
        private void tmrItems_Tick(object sender, EventArgs e)
        {
            setPOLines();
        }
        #endregion

        #region Print PO Labels
        private void RibtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string poNum = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                string sep = Convert.ToString(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                bool lotLine = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
                double qtyRec = Convert.ToDouble(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcBack1").ToString().Replace(",", sep).Replace(".", sep));
                double orderQty = Convert.ToDouble(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcOrderQty").ToString().Replace(",", sep).Replace(".", sep));
                string itemCode = Convert.ToString(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode"));
                if (qtyRec != 0)
                {
                    if (qtyRec <= orderQty)
                    {
                        if (lotLine == true)
                        {
                            #region Lot Numbers
                            frmPrint print = new frmPrint(Convert.ToString(qtyRec), itemCode, poNum);
                            print.ShowDialog();
                            lotNum = print.lotNum;
                            qtyPerLabel = print.qtyPerLabel;
                            LastLabelQty = print.lastLabelQty;
                            qty = qtyRec;

                            DialogResult res = print.DialogResult;
                            if (res == DialogResult.OK)
                            {
                                lotPrintItem = true;
                                startPrint();
                            }
                            #endregion
                        }
                        else
                        {
                            #region No Lot
                            frmPrintNoLot print = new frmPrintNoLot(Convert.ToString(qtyRec), itemCode);
                            print.ShowDialog();
                            qtyPerLabel = print.qtyPerLabel;
                            LastLabelQty = print.lastLabelQty;
                            qty = qtyRec;
                            DialogResult res = print.DialogResult;
                            if (res == DialogResult.OK)
                            {
                                lotPrintItem = false;
                                startPrint();
                            }
                            #endregion
                        }

                    }
                    else
                    {
                        msg = new frmMsg("Cannot print label", "The quantity entered would exceed the total order qty", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot print label", "Please enter a qty to receive", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void startPrint()
        {
            try
            {
                ppnlPrint.BringToFront();
                labelsPrinted = false;
                Application.DoEvents();
                tmrPrint.Start();
                Thread thread = new Thread(savePrint);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void savePrint()
        {
            try
            {
                string sep = Convert.ToString(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                string itemCode = Convert.ToString(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode"));
                double qtyRec = Convert.ToDouble(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcBack1").ToString().Replace(",", sep).Replace(".", sep));
                if (lotPrintItem == true)
                {
                    labelInfo = Client.printPOLabels(lblPO.Text.Split(':')[1].Replace(" ", string.Empty) + "|" + itemCode + "|" + lotNum + "|" + Convert.ToString(qtyRec) + "|" + GlobalVars.userName + "|" + qtyPerLabel);
                    labelsPrinted = true;
                }
                else
                {
                    labelInfo = Client.printPOLabelsNo(lblPO.Text.Split(':')[1].Replace(" ", string.Empty) + "|" + itemCode + "|" + Convert.ToString(qtyRec) + "|" + GlobalVars.userName + "|" + qtyPerLabel);
                    labelsPrinted = true;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrPrint_Tick(object sender, EventArgs e)
        {
            PrintLabels();
        }
        public void PrintLabels()
        {
            if (labelsPrinted == true)
            {
                string sep = Convert.ToString(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                bool lotLine = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
                double qtyRec = Convert.ToDouble(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcBack1").ToString().Replace(",", sep).Replace(".", sep));
                double orderQty = Convert.ToDouble(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcOrderQty").ToString().Replace(",", sep).Replace(".", sep));
                string itemCode = Convert.ToString(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode"));
                if (lotPrintItem == true)
                {
                    #region Lot Item
                    tmrPrint.Stop();

                    string itemInfo = Client.getLabelPrintInfo(itemCode);
                    switch (itemInfo.Split('*')[0])
                    {
                        case "1":
                            string printed = labelInfo;//+ "|" + lblQty
                            if (printed != string.Empty)
                            {
                                switch (printed.Split('*')[0])
                                {
                                    case "1":
                                        printed = printed.Remove(0, 2);
                                        itemInfo = itemInfo.Remove(0, 2);
                                        string[] allLabels = printed.Split('~');
                                        foreach (string label in allLabels)
                                        {
                                            if (label != string.Empty)
                                            {
                                                XtraReport printLabel = GlobalVars.POLabel;
                                                printLabel.Parameters["_ItemCode"].Value = itemCode;
                                                printLabel.Parameters["_Lot"].Value = lotNum;
                                                printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                                printLabel.Parameters["_RT2D"].Value = label;

                                                printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                                printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                                printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                                printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                                printLabel.Parameters["_OrderNum"].Value = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                                                printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                                printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                                printLabel.Parameters["_Supplier"].Value = poVendor;
                                                printLabel.CreateDocument();
                                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                prtTool.Print(GlobalVars.POPrinter);
                                            }
                                        }

                                        cbAllLines.Checked = true;
                                        int lotNumLine = 0;
                                        int OriLine = 0;
                                        bool lotFound = false;
                                        for (int i = 0; i < dtrPOLines.Rows.Count; i++)
                                        {
                                            string checkCode = gvPOItems.GetRowCellValue(i, "gcCode").ToString();
                                            string lotCheck = gvPOItems.GetRowCellValue(i, "gcLotNum").ToString();
                                            if (lotCheck == lotNum && checkCode == itemCode)
                                            {
                                                lotFound = true;
                                                lotNumLine = i;
                                            }
                                            else if (lotCheck == string.Empty && checkCode == itemCode)
                                            {
                                                OriLine = i;
                                            }

                                        }

                                        if (lotFound == true)
                                        {
                                            #region Lot found
                                            double Lqty = Convert.ToDouble(gvPOItems.GetRowCellValue(lotNumLine, "gcOrderQty").ToString().Replace(",", sep).Replace(".", sep));
                                            double Oqty = Convert.ToDouble(gvPOItems.GetRowCellValue(OriLine, "gcOrderQty").ToString().Replace(",", sep).Replace(".", sep));
                                            double Aqty = qty;
                                            double newQtyLot = Lqty + Aqty;
                                            double newQtyOri = Oqty - Aqty;

                                            double preTotal = Convert.ToDouble(gvPOItems.GetRowCellValue(lotNumLine, "gcBack2"));
                                            double totalRec = preTotal + Aqty;

                                            double totalPrint = Convert.ToDouble(gvPOItems.GetRowCellValue(lotNumLine, "gcRTPrintQty").ToString().Replace(",", sep).Replace(".", sep));
                                            double totalPrinted = totalPrint + Aqty;

                                            gvPOItems.SetRowCellValue(lotNumLine, "gcOrderQty", newQtyLot);
                                            gvPOItems.SetRowCellValue(lotNumLine, "gcBack2", totalRec);
                                            gvPOItems.SetRowCellValue(lotNumLine, "gcRTPrintQty", totalPrinted);
                                            gvPOItems.SetRowCellValue(lotNumLine, "gcViewable", false);


                                            gvPOItems.SetRowCellValue(OriLine, "gcOrderQty", newQtyOri);
                                            gvPOItems.SetRowCellValue(OriLine, "gcBack1", 0);
                                            #endregion
                                        }
                                        else
                                        {
                                            #region Add new line
                                            double Oqty = Convert.ToDouble(gvPOItems.GetRowCellValue(OriLine, "gcOrderQty").ToString().Replace(",", sep).Replace(".", sep));
                                            double Aqty = qty;
                                            double newQtyOri = Oqty - Aqty;

                                            string newCode = itemCode;
                                            string desc = Convert.ToString(gvPOItems.GetRowCellValue(OriLine, "gcDesc"));
                                            string desc2 = Convert.ToString(gvPOItems.GetRowCellValue(OriLine, "gcDesc2"));
                                            string newLot = lotNum;
                                            string rec = "false";
                                            string newQty = Convert.ToString(Aqty);
                                            string recQty = Convert.ToString(0);
                                            string newPrint = string.Empty;
                                            string newlotLine = "true";
                                            string newTempLine = "false";
                                            string newLine = newCode + "|" + desc + "|" + desc2 + "|" + newLot + "|" + rec + "|" + newQty + "|" + recQty + "|" + newPrint + "|" + newlotLine + "|" + newTempLine;

                                            gvPOItems.SetRowCellValue(OriLine, "gcOrderQty", newQtyOri);
                                            gvPOItems.SetRowCellValue(OriLine, "gcRecQty", 0);
                                            gvPOItems.SetRowCellValue(OriLine, "gcBack1", 0);


                                            DataRow newrow = dtrPOLines.NewRow();
                                            newrow["gcCode"] = newCode;
                                            newrow["gcDesc"] = desc;
                                            newrow["gcDesc2"] = desc2;
                                            newrow["gcLotNum"] = newLot;
                                            newrow["gcReceive"] = rec;
                                            newrow["gcOrderQty"] = newQty;
                                            newrow["gcRecQty"] = recQty;
                                            newrow["gcPrint"] = newPrint;
                                            newrow["gcLotLine"] = newlotLine;
                                            newrow["gcViewable"] = newTempLine;
                                            newrow["gcBack1"] = "0";
                                            newrow["gcBack2"] = Aqty;
                                            newrow["gcBack3"] = string.Empty;
                                            newrow["gcRTPrintQty"] = Aqty;
                                            newrow["gcValidated"] = true;
                                            newrow["gcScanned"] = false;
                                            dtrPOLines.Rows.InsertAt(newrow, OriLine + 1);
                                            #endregion
                                        }
                                        cbAllLines.Checked = false;
                                        ppnlPrint.SendToBack();

                                        break;
                                    case "0":
                                        printed = printed.Remove(0, 2);
                                        ppnlPrint.SendToBack();
                                        msg = new frmMsg("The following server side issue was encountered:", printed, GlobalVars.msgState.Error);
                                        msg.ShowDialog();

                                        break;
                                    case "-1":
                                        ppnlPrint.SendToBack();
                                        printed = printed.Remove(0, 3);
                                        errMsg = printed.Split('|')[0];
                                        errInfo = printed.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        ppnlPrint.SendToBack();
                                        printed = printed.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", printed, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        ppnlPrint.SendToBack();
                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while retreiving active permissions";
                                        errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + printed;
                                        break;
                                }
                            }
                            else
                            {
                                ppnlPrint.SendToBack();
                                msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                            break;
                        case "0":
                            ppnlPrint.SendToBack();
                            itemInfo = itemInfo.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", itemInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            ppnlPrint.SendToBack();
                            itemInfo = itemInfo.Remove(0, 3);
                            errMsg = itemInfo.Split('|')[0];
                            errInfo = itemInfo.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            ppnlPrint.SendToBack();
                            itemInfo = itemInfo.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            ppnlPrint.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving print item details";
                            errInfo = "Unexpected error while retreiving print item details" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemInfo;
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region Non Lot Item
                    tmrPrint.Stop();
                    string printed = labelInfo;
                    switch (printed.Split('*')[0])
                    {
                        case "1":
                            printed = printed.Remove(0, 2);

                            string itemInfo = Client.getLabelPrintInfo(itemCode);
                            switch (itemInfo.Split('*')[0])
                            {
                                case "1":
                                    itemInfo = itemInfo.Remove(0, 2);
                                    string[] allLabels = printed.Split('~');
                                    foreach (string label in allLabels)
                                    {
                                        if (label != string.Empty)
                                        {
                                            XtraReport printLabel = GlobalVars.POLabel;
                                            printLabel.Parameters["_ItemCode"].Value = itemCode;
                                            printLabel.Parameters["_Lot"].Value = "No lot";
                                            printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                            printLabel.Parameters["_RT2D"].Value = label;

                                            printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                            printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                            printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                            printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                            printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                            printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                            printLabel.Parameters["_OrderNum"].Value = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                                            printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                            printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                            printLabel.Parameters["_Supplier"].Value = poVendor;
                                            printLabel.CreateDocument();
                                            ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                            prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                            prtTool.Print(GlobalVars.POPrinter);
                                        }
                                    }

                                    cbAllLines.Checked = true;
                                    int OriLine = 0;
                                    for (int i = 0; i < dtrPOLines.Rows.Count; i++)
                                    {
                                        string checkCode = gvPOItems.GetRowCellValue(i, "gcCode").ToString();
                                        string lotCheck = gvPOItems.GetRowCellValue(i, "gcLotNum").ToString();

                                        if (lotCheck == string.Empty && checkCode == itemCode)
                                        {
                                            OriLine = i;
                                        }
                                    }

                                    double Aqty = qty;
                                    double preTotal = Convert.ToDouble(gvPOItems.GetRowCellValue(OriLine, "gcBack2"));
                                    double totalRec = preTotal + Aqty;

                                    double printedQty = Convert.ToDouble(gvPOItems.GetRowCellValue(OriLine, "gcRTPrintQty"));
                                    double totalPrinted = printedQty + Aqty;

                                    gvPOItems.SetRowCellValue(OriLine, "gcRTPrintQty", totalPrinted);
                                    gvPOItems.SetRowCellValue(OriLine, "gcBack2", totalRec);
                                    gvPOItems.SetRowCellValue(OriLine, "gcBack1", 0);
                                    cbAllLines.Checked = false;
                                    ppnlPrint.SendToBack();
                                    break;
                                case "0":
                                    ppnlPrint.SendToBack();
                                    itemInfo = itemInfo.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", itemInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    ppnlPrint.SendToBack();
                                    itemInfo = itemInfo.Remove(0, 3);
                                    errMsg = itemInfo.Split('|')[0];
                                    errInfo = itemInfo.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    ppnlPrint.SendToBack();
                                    itemInfo = itemInfo.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    ppnlPrint.SendToBack();
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving active permissions";
                                    errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + printed;
                                    break;
                            }
                            break;
                        case "0":
                            ppnlPrint.SendToBack();
                            printed = printed.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", printed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            ppnlPrint.SendToBack();
                            printed = printed.Remove(0, 3);
                            errMsg = printed.Split('|')[0];
                            errInfo = printed.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            ppnlPrint.SendToBack();
                            printed = printed.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", printed, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            ppnlPrint.SendToBack();
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving active permissions";
                            errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + printed;
                            break;
                    }
                    #endregion
                }
            }

        }
        #endregion

        #region Reprint
        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPOItems.FocusedRowHandle != -1)
                {
                    string poNumber = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                    string code = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode").ToString();
                    string desc = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcDesc").ToString();
                    string lot = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotNum").ToString();
                    bool isLot = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
                    isLot = true;
                    if (isLot == true && lot != string.Empty)
                    {
                        #region Lot Items
                        frmPOReprint print = new frmPOReprint(code, desc, lot);
                        print.ShowDialog();
                        DialogResult res = print.DialogResult;
                        if (res == DialogResult.OK)
                        {
                            ReprintQty = print.printQty;
                            ReprintQtyPerLabel = print.qtyPerLabel;
                            lotReprintItem = true;
                            startReprint();
                        }
                        #endregion
                    }
                    else if (isLot == true && lot == string.Empty)
                    {
                        #region Non Lot Items
                        frmPOReprint print = new frmPOReprint(code, desc, "NA");
                        print.ShowDialog();
                        DialogResult res = print.DialogResult;
                        if (res == DialogResult.OK)
                        {
                            ReprintQty = print.printQty;
                            ReprintQtyPerLabel = print.qtyPerLabel;
                            lotReprintItem = false;
                            startReprint();
                        }
                        #endregion
                    }
                    else
                    {
                        msg = new frmMsg("Cannot reprint item", "The item you have selected is invalid for reprints!", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }

                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void startReprint()
        {
            try
            {
                ppnlPrint.BringToFront();
                labelsReprinted = false;
                Application.DoEvents();
                tmrReprint.Start();
                Thread thread = new Thread(saveReprint);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void saveReprint()
        {
            string poNumber = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
            string code = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode").ToString();
            string desc = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcDesc").ToString();
            string lot = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotNum").ToString();
            bool isLot = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
            if (lotReprintItem == true)
            {
                string sendString = poNumber + "|" + code + "|" + lot + "|" + ReprintQty + "|" + GlobalVars.userName + "|" + ReprintQtyPerLabel;
                labelReprintInfo = Client.reprintPOLabelLot(sendString);
                labelsReprinted = true;
            }
            else
            {
                string sendString = poNumber + "|" + code + "|" + ReprintQty + "|" + GlobalVars.userName + "|" + ReprintQtyPerLabel;
                labelReprintInfo = Client.reprintPOLabelNoLot(sendString);
                labelsReprinted = true;
            }
        }
        private void tmrReprint_Tick(object sender, EventArgs e)
        {
            reprintLabels();
        }
        public void reprintLabels()
        {
            try
            {
                if (labelsReprinted == true)
                {
                    tmrReprint.Stop();
                    string poNumber = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                    string code = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode").ToString();
                    string desc = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcDesc").ToString();
                    string lot = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotNum").ToString();
                    bool isLot = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));
                    if (lotReprintItem == true)
                    {
                        #region Lot Items
                        string lotPrinted = labelReprintInfo;
                        switch (lotPrinted.Split('*')[0])
                        {
                            case "1":
                                lotPrinted = lotPrinted.Remove(0, 2);
                                string itemInfo = Client.getLabelPrintInfo(code);
                                switch (itemInfo.Split('*')[0])
                                {
                                    case "1":
                                        string[] allLabels = lotPrinted.Split('~');
                                        foreach (string label in allLabels)
                                        {
                                            if (label != string.Empty)
                                            {
                                                XtraReport printLabel = GlobalVars.POLabel;
                                                printLabel.Parameters["_ItemCode"].Value = code;
                                                printLabel.Parameters["_Lot"].Value = lot;
                                                printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                                printLabel.Parameters["_RT2D"].Value = label;

                                                printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                                printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                                printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                                printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                                printLabel.Parameters["_OrderNum"].Value = poNumber;
                                                printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                                printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                                printLabel.Parameters["_Supplier"].Value = poVendor;
                                                printLabel.CreateDocument();
                                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                prtTool.Print(GlobalVars.POPrinter);
                                            }
                                        }
                                        ppnlPrint.SendToBack();
                                        break;
                                    case "-1":
                                        ppnlPrint.SendToBack();
                                        itemInfo = itemInfo.Remove(0, 3);
                                        errMsg = itemInfo.Split('|')[0];
                                        errInfo = itemInfo.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        ppnlPrint.SendToBack();
                                        itemInfo = itemInfo.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        ppnlPrint.SendToBack();
                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while removing invalid labels";
                                        errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemInfo;
                                        break;
                                }
                                break;
                            case "-1":
                                ppnlPrint.SendToBack();
                                lotPrinted = lotPrinted.Remove(0, 3);
                                errMsg = lotPrinted.Split('|')[0];
                                errInfo = lotPrinted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlPrint.SendToBack();
                                lotPrinted = lotPrinted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", lotPrinted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlPrint.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while removing invalid labels";
                                errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lotPrinted;
                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Non Lot Items
                        string lotPrinted = labelReprintInfo;
                        switch (lotPrinted.Split('*')[0])
                        {
                            case "1":
                                lotPrinted = lotPrinted.Remove(0, 2);
                                string itemInfo = Client.getLabelPrintInfo(code);
                                switch (itemInfo.Split('*')[0])
                                {
                                    case "1":
                                        string[] allLabels = lotPrinted.Split('~');
                                        foreach (string label in allLabels)
                                        {
                                            if (label != string.Empty)
                                            {
                                                XtraReport printLabel = GlobalVars.POLabel;
                                                printLabel.Parameters["_ItemCode"].Value = code;
                                                printLabel.Parameters["_Lot"].Value = "NA";
                                                printLabel.Parameters["_Qty"].Value = Barcodes.GetItemQty(label);
                                                printLabel.Parameters["_RT2D"].Value = label;

                                                printLabel.Parameters["_barcode"].Value = itemInfo.Split('|')[0];
                                                printLabel.Parameters["_bin"].Value = itemInfo.Split('|')[2];
                                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                printLabel.Parameters["_Description1"].Value = itemInfo.Split('|')[3];
                                                printLabel.Parameters["_Description2"].Value = itemInfo.Split('|')[4];
                                                printLabel.Parameters["_Description3"].Value = itemInfo.Split('|')[5];
                                                printLabel.Parameters["_OrderNum"].Value = poNumber;
                                                printLabel.Parameters["_Group"].Value = itemInfo.Split('|')[6];
                                                printLabel.Parameters["_SimpleCode"].Value = itemInfo.Split('|')[1];
                                                printLabel.Parameters["_Supplier"].Value = poVendor;
                                                printLabel.CreateDocument();
                                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                prtTool.PrinterSettings.Copies = Convert.ToInt16(1);
                                                prtTool.Print(GlobalVars.POPrinter);
                                            }
                                        }
                                        ppnlPrint.SendToBack();
                                        break;
                                    case "-1":
                                        ppnlPrint.SendToBack();
                                        itemInfo = itemInfo.Remove(0, 3);
                                        errMsg = itemInfo.Split('|')[0];
                                        errInfo = itemInfo.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        ppnlPrint.SendToBack();
                                        itemInfo = itemInfo.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", itemInfo, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        ppnlPrint.SendToBack();
                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while removing invalid labels";
                                        errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemInfo;
                                        break;
                                }
                                break;
                            case "-1":
                                ppnlPrint.SendToBack();
                                lotPrinted = lotPrinted.Remove(0, 3);
                                errMsg = lotPrinted.Split('|')[0];
                                errInfo = lotPrinted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlPrint.SendToBack();
                                lotPrinted = lotPrinted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", lotPrinted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlPrint.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while removing invalid labels";
                                errInfo = "Unexpected error while removing invalid labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lotPrinted;
                                break;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                tmrReprint.Stop();
                ppnlPrint.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        #endregion

        public string orderNum = string.Empty;
        public string query = string.Empty;
        public string allLines = string.Empty;
      



        #region Grid View Styles
        private void gvPOItems_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    bool rec = Convert.ToBoolean(gvPOItems.GetRowCellValue(e.RowHandle, View.Columns["gcReceive"]));
                    string lotNumber = Convert.ToString(gvPOItems.GetRowCellValue(e.RowHandle, View.Columns["gcLotNum"]));
                    bool lotItem = Convert.ToBoolean(gvPOItems.GetRowCellValue(e.RowHandle, View.Columns["gcLotLine"]));

                    if (lotNumber != string.Empty && lotItem == true)
                    {
                        e.Appearance.BackColor = Color.DarkGray;
                        e.Appearance.BackColor2 = Color.DarkGray;
                    }
                    else
                    {
                        if (rec == true)
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.White;
                        }

                        if (rec == false)
                        {
                            e.Appearance.BackColor = Color.LightGray;
                            e.Appearance.BackColor2 = Color.LightGray;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void gvPOItems_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (View.FocusedColumn.FieldName == "gcBack1" || View.FocusedColumn.FieldName == "gcPrint")
                {
                    bool rec = Convert.ToBoolean(gvPOItems.GetRowCellValue(View.FocusedRowHandle, View.Columns["gcReceive"]));
                    if (rec == false)
                    {
                        e.Cancel = true;
                    }
                }

                string lotNum = Convert.ToString(gvPOItems.GetRowCellValue(View.FocusedRowHandle, View.Columns["gcLotNum"]));
                if (lotNum != string.Empty)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
            }
        }
        private void gvPOItems_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                ColumnView View = sender as ColumnView;
                if (cbAllLines.Checked == true)
                {
                    e.Visible = true;
                    e.Handled = true;
                }
                else
                {
                    bool validated = Convert.ToBoolean(gvPOItems.GetRowCellValue(e.ListSourceRow, "gcViewable"));
                    string desc2 = Convert.ToString(gvPOItems.GetRowCellValue(e.ListSourceRow, "gcLotNum"));
                    if (desc2 == string.Empty)
                    {
                        e.Visible = true;
                        e.Handled = true;

                    }
                    else
                    {
                        if (validated == false)
                        {
                            e.Visible = true;
                            e.Handled = true;
                        }
                        else
                        {
                            e.Visible = false;
                            e.Handled = true;
                        }
                    }
                }
                gcRTLastOrderQty.Visible = false;
                gcRTLastPrintQty.Visible = false;
                gcRTLastRecQty.Visible = false;
                gcRTOrderQty.Visible = false;
                gcRTPrintQty.Visible = false;
            }
            catch (Exception)
            {
            }
        }
        private void cbAllLines_CheckedChanged(object sender, EventArgs e)
        {
            gvPOItems.RefreshData();
        }




        #endregion

        private void ucPOReprinting_Load(object sender, EventArgs e)
        {
            setupDataTable();
            getSuppliers();
            getPOs();

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnPrint = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnPrint.Buttons[0].Width = 85;
            dgPOItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnPrint });
            ribtnPrint.Click += RibtnPrint_Click;
            gcPrint.ColumnEdit = ribtnPrint;
            gcPrint.Width = 93;
            gcPrint.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ricbRec = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            dgPOItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricbRec });
            gcReceive.ColumnEdit = ricbRec;
        }

        private void cmbPOs_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbPOs.Text != string.Empty)
            {
                cmbSuppliers.Text = string.Empty;
            }
        }

        private void cmbSuppliers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSuppliers.Text != string.Empty)
            {
                cmbPOs.Text = string.Empty;
            }
        }

        private void ppnlWait_Click(object sender, EventArgs e)
        {

        }


        private void btnReprintReciept_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvPOItems.FocusedRowHandle != -1)
                {
                    DataTable dtrep = new DataTable();
                    dtrep.TableName = "Records";
                    dtrep.Columns.Add("Code");
                    dtrep.Columns.Add("Desc");
                    dtrep.Columns.Add("Lot");
                    dtrep.Columns.Add("Qty");

                    string poNumber = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                    string code = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcCode").ToString();
                    string desc = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcDesc").ToString();
                    string lot = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotNum").ToString();
                    bool isLot = Convert.ToBoolean(gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcLotLine"));

                    string orderQty = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcOrderQty").ToString();
                    string recQty = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcRecQty").ToString();
                    string printQty = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcRTPrintQty").ToString();
                    string validated = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcValidated").ToString();
                    string scanned = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcScanned").ToString();
                    string totalPrinted = gvPOItems.GetRowCellValue(gvPOItems.FocusedRowHandle, "gcBack2").ToString();
                    string userName = GlobalVars.userName;

                    isLot = true;
                    if (isLot == true && lot != string.Empty)
                    {
                        string row = code + "|" + desc + "|" + lot + "|" + orderQty;
                        dtrep.Rows.Add(row.Split('|'));
                        rptPORec poReport = new rptPORec();
                        string connectionString = "Data Source=" + GlobalVars.SQLServer + "; Initial Catalog=" + GlobalVars.RTDB +
                        "; user ID=" + GlobalVars.SqlUser + "; password=" + GlobalVars.SqlPass + ";Max Pool Size=99999;";
                        CustomStringConnectionParameters connectionParams = new CustomStringConnectionParameters(connectionString);
                        poReport.sqlDataSource1.ConnectionParameters = connectionParams;
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dtrep);
                        poReport.DataSource = ds;
                        poReport.DataMember = "Records";
                        poReport.OrderNum.Value = lblPO.Text.Split(':')[1].Replace(" ", string.Empty);
                        poReport.Supplier.Value = poVendor;
                        poReport.CreateDocument();
                        ReportPrintTool printTool = new ReportPrintTool(poReport);
                        string porpath = GlobalVars.RSCFolder + "\\" + System.IO.Directory.CreateDirectory(Path.Combine(GlobalVars.RSCFolder, "PO Reprints"));
                        string poversion = System.DateTime.Now.Year.ToString().Substring(2, 2) + System.DateTime.Now.ToString("MM") + System.DateTime.Now.Day.ToString() + System.DateTime.Now.ToString("HHmmss");
                        poReport.ExportToPdf(porpath + "\\" + System.IO.Directory.CreateDirectory(Path.Combine(porpath, "" + "" + lblPO.Text.Split(':')[1].Replace(" ", string.Empty) + "")) + @"\" + lblPO.Text.Split(':')[1].Replace(" ", string.Empty) + "_v" + poversion + ".pdf");
                        printTool.ShowPreview();
                    }

                    else
                    {
                        msg = new frmMsg("Cannot reprint item", "The item you have selected is invalid for reprints!", GlobalVars.msgState.Info);
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






   