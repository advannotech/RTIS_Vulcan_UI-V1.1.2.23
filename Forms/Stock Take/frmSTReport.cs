using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI
{
    public partial class frmSTReport : Form
    {
        public bool negativeVars { get; set; }
        public bool positiveVars { get; set; }
        public bool uncounted { get; set; }
        public bool matching { get; set; }
        public bool unmatching { get; set; }
        public bool noST { get; set; }
        public frmSTReport()
        {
            InitializeComponent();
        }
        private void cbNeg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNeg.Checked == true)
            {
                negativeVars = true;
            }
            else
            {
                negativeVars = false;
            }
        }
        private void cbPos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPos.Checked == true)
            {
                positiveVars = true;
            }
            else
            {
                positiveVars = false;
            }
        }
        private void cbUnc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnc.Checked == true)
            {
                uncounted = true;
            }
            else
            {
                uncounted = false;
            }
        }
        private void cbMatch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMatch.Checked == true)
            {
                matching = true;
            }
            else
            {
                matching = false;
            }
        }
        private void cbNonMatch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNonMatch.Checked == true)
            {
                unmatching = true;
            }
            else
            {
                unmatching = false;
            }
        }
        private void cbNonST_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNonST.Checked == true)
            {
                noST = true;
            }
            else
            {
                noST = false;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
