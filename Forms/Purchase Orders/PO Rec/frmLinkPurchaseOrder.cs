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
        public string ponumber = string.Empty;
        public string dateupdated = string.Empty;


        public frmLinkPurchaseOrder(string _linkid, string _supplier, string _ponumber, string _dateupdated)
        {
            InitializeComponent();
            linkid = _linkid;
            supplier = _supplier;
            ponumber = _ponumber;
            dateupdated = _dateupdated;
        }

        private void frmLinkPurchaseOrder_Load(object sender, EventArgs e)
        {
            refreshVendors();
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
                txtLinkedPOs.Text = ponumber;
                vendorsPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
