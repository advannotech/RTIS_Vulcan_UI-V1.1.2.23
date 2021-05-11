using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms
{
    public partial class frmConfirmPOPrint : Form
    {
        public string _itemCode { get; set; }
        public string _lot { get; set; }
        public string _qty { get; set; }
        public string _per { get; set; }
        public string _last { get; set; }

        public frmConfirmPOPrint(string itemCode, string lot, string qty, string per, string last)
        {
            InitializeComponent();
            _itemCode = itemCode;
            _lot = lot;
            _qty = qty;
            _per = per;
            _last = last;
        }

        private void frmConfirmPOPrint_Load(object sender, EventArgs e)
        {
            lblCode.Text = _itemCode;
            lblLot.Text = _lot;
            lblQty.Text = _qty;
            lblPer.Text = _per;
            if (_last == "0")
            {
                lblLast.Text = _per;
            }
            else
            {
                lblLast.Text = _last;
            }
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
