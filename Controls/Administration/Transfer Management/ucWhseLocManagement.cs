using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Transfer_Management;

namespace RTIS_Vulcan_UI.Controls.Administration.Transfer_Management
{
    public partial class ucWhseLocManagement : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtTransfers = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;
        public ucWhseLocManagement()
        {
            InitializeComponent();
        }
        public void setUpDatatables()
        {
            dtTransfers.Columns.Add("gcProc", typeof(string));
            dtTransfers.Columns.Add("gcConfig", typeof(string));

            string[] pgm = { "PGM", "" };
            string[] powder = { "Powder Prep", "" };
            string[] fs = { "Fresh Slurry", "" };
            string[] ms = { "Mixed Slurry", "" };
            string[] z1 = { "Zect 1", "" };
            string[] z2 = { "Zect 2", "" };
            string[] aw = { "A&W", "" };
            string[] canning = { "Canning", "" };
            dtTransfers.Rows.Add(pgm);
            dtTransfers.Rows.Add(powder);
            dtTransfers.Rows.Add(fs);
            dtTransfers.Rows.Add(ms);
            dtTransfers.Rows.Add(z1);
            dtTransfers.Rows.Add(z2);
            dtTransfers.Rows.Add(aw);
            dtTransfers.Rows.Add(canning);

            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribtnConfig = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ribtnConfig.Buttons[0].Width = 85;
            dgItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { ribtnConfig });
            ribtnConfig.Click += RibtnConfig_Click;
            gcConfig.ColumnEdit = ribtnConfig;
            gcConfig.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ribtnConfig.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

            dgItems.DataSource = dtTransfers;
            dgItems.MainView.GridControl.DataSource = dtTransfers;
            dgItems.MainView.GridControl.EndUpdate();
            gvItems.RefreshData();
        }
        private void RibtnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string process = gvItems.GetRowCellValue(gvItems.FocusedRowHandle, "gcProc").ToString();
                frmConfigureLocs locs = new frmConfigureLocs(process);
                locs.ShowDialog();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void ucWhseLocManagement_Load(object sender, EventArgs e)
        {
            setUpDatatables();
        }
    }
}
