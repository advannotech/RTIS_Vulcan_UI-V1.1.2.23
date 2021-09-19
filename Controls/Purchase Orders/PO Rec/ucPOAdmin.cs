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
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using System.Threading;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using RTIS_Vulcan_UI.Forms.Purchase_Orders.PO_Rec;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucPOAdmin : UserControl
    {
        public string vendorLines = string.Empty;
        public bool vendorsPulled = false;
        DataTable dtVendors = new DataTable();

        public string LinkLines = string.Empty;
        public bool LinksPulled = false;
        DataTable dtLink = new DataTable();

        DevExpress.XtraEditors.Repository.RepositoryItemComboBox ricmbPOs;

        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public void setUpVendorTable()
        {
            dtVendors.Columns.Add(new DataColumn("gcID", typeof(string)));
            dtVendors.Columns.Add(new DataColumn("gcName", typeof(string)));
            dtVendors.Columns.Add(new DataColumn("gcViewable", typeof(bool)));
        }
        public void refreshVendors()
        {
            pplWaitVendors.BringToFront();
            vendorsPulled = false;
            Application.DoEvents();
            tmrVendors.Start();
            Thread thread = new Thread(getPOVendors);
            thread.Start();
        }
        public void getPOVendors()
        {
            try
            {
                vendorLines = Client.GetEvoPOVendors();
                vendorsPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setVendors()
        {
            try
            {
                if (vendorsPulled == true)
                {
                    tmrVendors.Stop();
                    string allVendors = vendorLines;
                    if (allVendors != string.Empty)
                    {
                        switch (allVendors.Split('*')[0])
                        {
                            case "1":
                                dtVendors.Rows.Clear();
                                allVendors = allVendors.Remove(0, 2);
                                string[] vendorArry = allVendors.Split('~');
                                foreach (string vendor in vendorArry)
                                {
                                    if (vendor != "")
                                    {
                                        dtVendors.Rows.Add(vendor.Split('|'));
                                    }
                                }
                                dgVendors.DataSource = dtVendors;
                                dgVendors.MainView.GridControl.DataSource = dtVendors;
                                dgVendors.MainView.GridControl.EndUpdate();
                                pplWaitVendors.SendToBack();
                                tmrVendors.Stop();
                                vendorsPulled = false;
                                break;
                            case "0":
                                allVendors = allVendors.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", allVendors, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                allVendors = allVendors.Remove(0, 3);
                                errMsg = allVendors.Split('|')[0];
                                errInfo = allVendors.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                allVendors = allVendors.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", allVendors, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + allVendors;
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
        public void setUpLinkTable()
        {
            dtLink.Columns.Add(new DataColumn("gcLinkID", typeof(string)));
            dtLink.Columns.Add(new DataColumn("gcSupplier", typeof(string)));
            dtLink.Columns.Add(new DataColumn("gcPO", typeof(string)));
            dtLink.Columns.Add(new DataColumn("gcDate", typeof(string)));
            dtLink.Columns.Add(new DataColumn("gcPOs", typeof(string)));
        }
        public void refreshLinks()
        {
            ppnlWaitLink.BringToFront();
            LinksPulled = false;
            Application.DoEvents();
            tmrLinks.Start();
            Thread thread = new Thread(getLinkLines);
            thread.Start();
        }
        public void getLinkLines()
        {
            try
            {
                LinkLines = Client.GetLinkLines();
                LinksPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setLinkLines()
        {
            if (LinksPulled == true)
            {
                tmrLinks.Stop();
                try
                {
                    string poLinks = LinkLines;
                    if (poLinks != string.Empty)
                    {                        
                        switch (poLinks.Split('*')[0])
                        {
                            case "1":
                                dtLink.Rows.Clear();
                                poLinks = poLinks.Remove(0, 2);
                                
                                string[] LinkArray = poLinks.Split('*');
                                foreach (string link in LinkArray)
                                {
                                    if (link != "")
                                    {
                                        dtLink.Rows.Add(link.Split('|'));
                                    }
                                }

                                gcPO.OptionsColumn.AllowEdit = true;
                                ricmbPOs = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                                dgLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricmbPOs });
                                ricmbPOs.Click += RicmbPOs_Click;
                                gcPO.ColumnEdit = ricmbPOs;

                                dgLink.DataSource = dtLink;
                                dgLink.MainView.GridControl.DataSource = dtLink;
                                dgLink.MainView.GridControl.EndUpdate();
                                ppnlWaitLink.SendToBack();
                                tmrLinks.Stop();
                                LinksPulled = false;
                                break;
                            case "0":
                                ppnlWaitLink.SendToBack();
                                poLinks = poLinks.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", poLinks, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                ppnlWaitLink.SendToBack();
                                poLinks = poLinks.Remove(0, 3);
                                errMsg = poLinks.Split('|')[0];
                                errInfo = poLinks.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWaitLink.SendToBack();
                                poLinks = poLinks.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", poLinks, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWaitLink.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + poLinks;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWaitLink.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    ExHandler.showErrorEx(ex);
                }
            }
        }
        private void RicmbPOs_Click(object sender, EventArgs e)
        {
            ColumnView view = dgLink.FocusedView as ColumnView;
            if (view.UpdateCurrentRow())
            {
                string Pos = Convert.ToString(gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcPOs"));
                this.ricmbPOs.Items.Clear();
                foreach (string item in Pos.Split('~'))
                {
                    if (item != string.Empty)
                    {
                        this.ricmbPOs.Items.Add(item);
                    }
                }
            }
            view.ShowEditor();
            (view.ActiveEditor as ComboBoxEdit).ShowPopup();
        }
        public ucPOAdmin()
        {
            InitializeComponent();
        }

        private void btnLinkPO_Click(object sender, EventArgs e)
        {
            string linkid = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcLinkID").ToString();
            string supplier = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcSupplier").ToString();
            string ponumber = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcPO").ToString();
            string dateupdated = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcDate").ToString();

            try
            {
                if (gvLink.FocusedRowHandle != -1)
                {

                    try
                    {
                       
                       frmLinkPurchaseOrder frmRm = new frmLinkPurchaseOrder(linkid, supplier, ponumber, dateupdated);
                       DialogResult dr = frmRm.ShowDialog();
                       if (dr == DialogResult.OK)
                        {
                            //getPOs();
                        }
                    }
                    catch (Exception ex)
                    {
                        ExHandler.showErrorEx(ex);
                    }

                }
                else
                {
                    msg = new frmMsg("No Supplier Found", "Cannot Link Vendor!", GlobalVars.msgState.Info);
                    msg.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void ucPOAdmin_Load(object sender, EventArgs e)
        {
            setUpVendorTable();
            refreshVendors();
            setUpLinkTable();
            refreshLinks();

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnLinkPO = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            btnLinkPO.Buttons[0].Width = 85;
            dgLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { btnLinkPO });
            btnLinkPO.Click += btnLinkPO_Click;
            gcLinkPO.ColumnEdit = btnLinkPO;
            gcLinkPO.Width = 93;
            gcLinkPO.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            btnLinkPO.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            //DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ricbRec = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //dgLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ricbRec });
            //gcLinkPO.ColumnEdit = ricbRec;

        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            pplWaitVendors.BringToFront();
        }
        private void tmrVendors_Tick(object sender, EventArgs e)
        {
            setVendors();
        }
        private void gvVendors_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ColumnView view = dgVendors.FocusedView as ColumnView;
                if (e.Column.FieldName == "gcViewable")
                {
                    if (view.UpdateCurrentRow())
                    {
                        string id = Convert.ToString(gvVendors.GetRowCellValue(gvVendors.FocusedRowHandle, "gcID"));
                        string name = Convert.ToString(gvVendors.GetRowCellValue(gvVendors.FocusedRowHandle, "gcName"));
                        string viewable = Convert.ToString(gvVendors.GetRowCellValue(gvVendors.FocusedRowHandle, "gcViewable"));
                        string updated = Client.SetVendorLookup(id + "|" + name + "|" + viewable);
                        if (updated != string.Empty)
                        {
                            switch (updated.Split('*')[0])
                            {
                                case "1":
                                    
                                    break;
                                case "0":
                                    updated = updated.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", updated, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    updated = updated.Remove(0, 3);
                                    errMsg = updated.Split('|')[0];
                                    errInfo = updated.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    updated = updated.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", updated, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void gvLink_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ColumnView view = dgLink.FocusedView as ColumnView;
            if (e.Column.FieldName == "gcPO")
            {
                if (view.UpdateCurrentRow())
                {
                    string id = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcLinkID").ToString();
                    string supName = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcSupplier").ToString();
                    string orderNo = gvLink.GetRowCellValue(gvLink.FocusedRowHandle, "gcPO").ToString();
                    if (orderNo != "- Select Order -")
                    {
                        if (orderNo != "No POs found")
                        {
                            string updated = Client.SetVendorPOLick(id + "|" + supName + "|" + orderNo);
                            if (updated != string.Empty)
                            {
                                switch (updated.Split('*')[0])
                                {
                                    case "1":
                                        gvLink.SetRowCellValue(gvLink.FocusedRowHandle, "gcDate", Convert.ToString(DateTime.Now));
                                        break;
                                    case "0":
                                        ppnlWaitLink.SendToBack();
                                        updated = updated.Remove(0, 2);
                                        msg = new frmMsg("The following server side issue was encountered:", updated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    case "-1":
                                        ppnlWaitLink.SendToBack();
                                        updated = updated.Remove(0, 3);
                                        errMsg = updated.Split('|')[0];
                                        errInfo = updated.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    case "-2":
                                        ppnlWaitLink.SendToBack();
                                        updated = updated.Remove(0, 2);
                                        msg = new frmMsg("A connection level error has occured", updated, GlobalVars.msgState.Error);
                                        msg.ShowDialog();
                                        break;
                                    default:
                                        ppnlWaitLink.SendToBack();
                                        st = new StackTrace(0, true);
                                        msgStr = "Unexpected error while retreiving roles";
                                        errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
                                        break;
                                }
                            }
                            else
                            {
                                msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                        else
                        {
                            gvLink.SetRowCellValue(gvLink.FocusedRowHandle, "gcPO", "- Select Order -");
                        }                       
                    }
                   
                }
            }          
        }
        private void tmrLinks_Tick(object sender, EventArgs e)
        {            
            setLinkLines();
        }
        private void gvLink_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string orderNum = gvLink.GetRowCellValue(e.RowHandle, View.Columns["gcPO"]).ToString();
                    string DateEntered = gvLink.GetRowCellValue(e.RowHandle, View.Columns["gcDate"]).ToString();
                    if (orderNum == "- Select Order -")
                    {
                        e.Appearance.BackColor = Color.LightYellow;
                        e.Appearance.BackColor2 = Color.LightYellow;
                    }
                    else
                    {
                        if (DateEntered != string.Empty)
                        {
                            DateTime dt = Convert.ToDateTime(DateEntered);
                            DateTime now = DateTime.Now;
                            double st = (now - dt).TotalDays;
                            if (st > 32)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                                e.Appearance.BackColor2 = Color.Salmon;
                            }
                        }                        
                    }
                }
            }
            catch (Exception)
            { }          
        }
    }
}
