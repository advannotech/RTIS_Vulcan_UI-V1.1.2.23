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
    public partial class frmTransferView : Form
    {
        string code = string.Empty;
        string lot = string.Empty;
        string qty = string.Empty;
        string from = string.Empty;
        string to = string.Empty;
        string date = string.Empty;
        string user = string.Empty;
        string status = string.Empty;
        string proccess = string.Empty;
        string dtFailed = string.Empty;
        string reason = string.Empty;

        public frmTransferView(string _code, string _lot, string _qty, string _From, string _To, string _Date, string _User, string _Status, string _Process, string _dtFailed, string _Reason)
        {
            InitializeComponent();
            code = _code;
            lot = _lot;
            qty = _qty;
            from = _From;
            to = _To;
            date = _Date;
            user = _User;
            status = _Status;
            proccess = _Process;
            dtFailed = _dtFailed;
            reason = _Reason;
        }

        private void frmTransferView_Load(object sender, EventArgs e)
        {
            if (status.ToUpper() == "FAILED")
            {
                xtpFailed.PageVisible = true;
            }
            else
            {
                xtpFailed.PageVisible = false;
            }

            lblCode.Text = code;
            lblLot.Text = lot;
            lblQty.Text = qty;
            lblFrom.Text = from;
            lblTo.Text = to;
            lblDate.Text = date;
            lblUser.Text = user;
            lblStatus.Text = status;
            lblProcess.Text = proccess;
            lblFailed.Text = dtFailed;
            meFailure.Text = reason;
        }
    }
}
