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
            refreshVendors();
            setCurrentPONumber();
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
                txtSelectedSupplier.Text = supplier;
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

        public void setCurrentPONumber()
        {
            try
            {
                if (ponumbers != string.Empty)
                {
                    foreach (string item in ponumbers.Split(','))
                    {
                        if (item != string.Empty)
                        {
                            lbSelected.Items.Add(item);
                            lbAvailable.Items.Remove(item);
                        }
                    }
                }
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

        private void btnAddAllPOs_Click(object sender, EventArgs e)
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
    }
}
