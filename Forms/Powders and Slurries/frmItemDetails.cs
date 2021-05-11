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
    public partial class frmItemDetails : Form
    {
        DataTable dtItems = new DataTable();
        DataTable record { get; set; }
        public frmItemDetails(DataTable _record)
        {
            InitializeComponent();
            record = _record;
        }

        private void frmPowderPrepItem_Load(object sender, EventArgs e)
        {
            setUpDatatable();
            dgItems.DataSource = record;
            dgItems.MainView.GridControl.DataSource = record;
            dgItems.MainView.GridControl.EndUpdate();
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcName", typeof(string));
            dtItems.Columns.Add("gcValue", typeof(string));
        }
    }
}
