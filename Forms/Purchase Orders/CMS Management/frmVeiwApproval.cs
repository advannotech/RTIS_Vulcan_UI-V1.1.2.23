using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Management
{
    public partial class frmVeiwApproval : Form
    {
        private Image sign { get; set; }
        private string code { get; set; }
        private string desc { get; set; }
        private string uCreated { get; set; }
        private string dtCreated { get; set; }
        private string uProcessed { get; set; }
        private string dtProcessed { get; set; }
        private string reasons { get; set; }
        private bool approved { get; set; }
        private DataTable data { get; set;}

        public frmVeiwApproval(Image _sign, string _code, string _desc, string _uCreated, string _dtCreated, string _uApproved, string _dtApproved, DataTable _data, bool _approved)
        {
            InitializeComponent();
            sign = _sign;
            code = _code;
            desc = _desc;
            uCreated = _uCreated;
            dtCreated = _dtCreated;
            uProcessed = _uApproved;
            dtProcessed = _dtApproved;
            data = _data;
            approved = _approved;
        }

        public frmVeiwApproval(string _code, string _desc, string _uCreated, string _dtCreated, string _uApproved, string _dtApproved, DataTable _data, string _reasons, bool _approved)
        {
            InitializeComponent();
            code = _code;
            desc = _desc;
            uCreated = _uCreated;
            dtCreated = _dtCreated;
            uProcessed = _uApproved;
            dtProcessed = _dtApproved;
            data = _data;
            reasons = _reasons;
            approved = _approved;
        }
        private void frmVeiwApproval_Load(object sender, EventArgs e)
        {
            if (approved)
            {
                peSignature.Image = sign;
                lblCode.Text = code;
                lblDesc.Text = desc;
                lblApproved.Text = uProcessed;
                lblDTApproved.Text = dtProcessed;
                pnlRejected.SendToBack();

                dgItems.DataSource = data;
                dgItems.MainView.GridControl.DataSource = data;
                dgItems.MainView.GridControl.EndUpdate();
                gvItems.RefreshData();
            }
            else
            {
                lblCode.Text = code;
                lblDesc.Text = desc;
                lblRejected.Text = uProcessed;
                lblDtRejected.Text = dtProcessed;
                meRejected.Text = reasons;
                pnlRejected.BringToFront();

                dgItems.DataSource = data;
                dgItems.MainView.GridControl.DataSource = data;
                dgItems.MainView.GridControl.EndUpdate();
                gvItems.RefreshData();
            }
            
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
