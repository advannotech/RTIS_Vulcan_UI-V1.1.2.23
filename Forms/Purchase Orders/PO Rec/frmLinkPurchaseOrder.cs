using RTIS_Vulcan_UI.Classes;
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

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.PO_Rec
{

    public partial class frmLinkPurchaseOrder : Form
    {
        public string vendorLines = string.Empty;
        public bool vendorsPulled = false;
        string availablepo = String.Empty;


        public string LinkLines = string.Empty;
        public bool LinksPulled = false;


        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public string linkid = string.Empty;
        public string supplier = string.Empty;
        public string ponumbers = string.Empty;
        public string dateupdated = string.Empty;
        public frmLinkPurchaseOrder(string _linkid, string _supplier, string _ponumbers, string _dateupdated)
        {
            InitializeComponent();
            linkid = _linkid;
            supplier = _supplier;
            ponumbers = _ponumbers;
            dateupdated = _dateupdated;
        }

        private void frmLinkPurchaseOrder_Load(object sender, EventArgs e)
        {

            refreshPage();
            lblSupplier.Text = supplier;
            setCurrentPOs();
        }

        public void refreshVendors()
        {
            Application.DoEvents();
            Thread thread = new Thread(getPOVendorinfo);
            thread.Start();
        }
        public void getPOVendorinfo()
        {
            try
            {
                lblSupplier.Text = supplier;
                txtsupplier.Text = supplier;
                if (ponumbers != string.Empty)
                {
                    foreach (string item in ponumbers.Split(','))
                    {
                        if (item != string.Empty)
                        {
                            listLinkedPOs.Items.Add(item);
                        }
                    }
                }
                vendorsPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnRemovePO_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSelected.SelectedItems.Count > 0)
                {
                    object selected = lbSelected.SelectedItem;
                    lbAvailable.Items.Add(selected);
                    lbSelected.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbAvailable.SelectedItems.Count > 0)
                {
                    object selected = lbAvailable.SelectedItem;
                    lbSelected.Items.Add(selected);
                    lbAvailable.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnAddAllPO_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> itemList = new List<string>();
                foreach (string item in lbAvailable.Items)
                {
                    itemList.Add(item);
                }

                foreach (string item in itemList)
                {
                    lbSelected.Items.Add(item);
                    lbAvailable.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        public void getAvailableLinkedOP()
        {
            try
            {
                string availablepo = Client.GetAvailablePOs();
                if (availablepo != string.Empty)
                {
                    switch (availablepo.Split('*')[0])
                    {
                        case "1":
                            lbAvailable.Items.Clear();
                          
                            availablepo = availablepo.Remove(0, 2);
                            string[] arrPOs = availablepo.Split('~');
                            foreach (string po in arrPOs)
                            {
                                if (po != "")
                                {
                                    lbAvailable.Items.Add(po);
                                }
                            }
                            break;
                        case "0":
                            availablepo = availablepo.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", availablepo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            availablepo = availablepo.Remove(0, 3);
                            errMsg = availablepo.Split('|')[0];
                            errInfo = availablepo.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            availablepo = availablepo.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", availablepo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving active permissions";
                            errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + availablepo;
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
        public void setCurrentPOs()
        {
            try
            {
                txtsupplier.Text = supplier;


   
                string selectedpos = Client.GetSelectedPO(supplier);
                if (selectedpos != string.Empty)
                {
                    switch (selectedpos.Split('*')[0])
                    {
                        case "1":
                            listLinkedPOs.Items.Clear();

                            selectedpos = selectedpos.Remove(0, 2);
                            string[] arrPOs = selectedpos.Split('~');
                            foreach (string po in arrPOs)
                            {
                                if (po != "")
                                {
                                    listLinkedPOs.Items.Add(po);
                                    lbAvailable.Items.Remove(po);
                                }
                            }
                            break;
                        case "0":
                            selectedpos = selectedpos.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", selectedpos, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            selectedpos = selectedpos.Remove(0, 3);
                            errMsg = selectedpos.Split('|')[0];
                            errInfo = selectedpos.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            selectedpos = selectedpos.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", selectedpos, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving active permissions";
                            errInfo = "Unexpected error while retreiving active permissions" + Environment.NewLine + "Data Returned:" + Environment.NewLine + selectedpos;
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
        public void refreshPage()
        {
            txtsupplier.Text = string.Empty;
            listLinkedPOs.Text = string.Empty;
            getAvailableLinkedOP();
            lbSelected.Items.Clear();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (lbSelected.Text != "")
            {
                try
                {
                    foreach(string po in lbSelected.Items)
                    {
                        string linked = Client.LinkPONtoVendor(linkid + "|" + supplier + "|" + po);
                        if (linked != string.Empty)
                        {
                            switch (linked.Split('*')[0])
                            {
                                case "1":
                                    dateupdated = Convert.ToString(DateTime.Now);
                                    msg = new frmMsg("Link PO", "Link Success!",
                                    GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    this.Close();
                                    break;
                                case "0":
                                    linked = linked.Remove(0, 2);
                                    msg = new frmMsg("The following server side issue was encountered:", linked, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                case "-1":
                                    linked = linked.Remove(0, 3);
                                    errMsg = linked.Split('|')[0];
                                    errInfo = linked.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    linked = linked.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", linked, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving roles";
                                    errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + linked;
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
                catch(Exception ex)
                {
                    ExHandler.showErrorEx(ex);
                }
            }
        }
    }
}
