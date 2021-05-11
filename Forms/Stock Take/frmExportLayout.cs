using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms.Stock_Take
{
    public partial class frmExportLayout : Form
    {
        public string csvName { get; set; }
        public string csvFormat { get; set; }
        public string csvDelimiter { get; set; }
        public List<ListViewItem> lstItems = new List<ListViewItem>();
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public frmExportLayout(List<ListViewItem> _lstItems)
        {
            InitializeComponent();
            lstItems = _lstItems;
        }
        private void frmExportLayout_Load(object sender, EventArgs e)
        {
            getExportFormats();
        }
        public void getExportFormats()
        {
            try
            {
                string exportFormats = Client.getExportFormats();
                if (exportFormats != string.Empty)
                {
                    switch (exportFormats.Split('*')[0])
                    {
                        case "1":
                            cmbLayouts.Properties.Items.Clear();
                            exportFormats = exportFormats.Remove(0, 2);
                            string[] allFormats = exportFormats.Split('~');
                            foreach (string format in allFormats)
                            {
                                if (format != string.Empty)
                                {
                                    cmbLayouts.Properties.Items.Add(format);
                                }
                            }
                            if (cmbLayouts.Properties.Items.Count != 0)
                            {
                                cmbLayouts.Text = cmbLayouts.Properties.Items[0].ToString();
                            }
                            break;
                        case "0":
                            cmbLayouts.Properties.Items.Clear();
                            break;
                        case "-1":
                            exportFormats = exportFormats.Remove(0, 3);
                            errMsg = exportFormats.Split('|')[0];
                            errInfo = exportFormats.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            exportFormats = exportFormats.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", exportFormats, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving item tickets";
                            errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + exportFormats;
                            ExHandler.showErrorST(st, msgStr, errInfo);
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCSVBuilder bob = new frmCSVBuilder(lstItems))
                {
                    bob.ShowDialog();
                    DialogResult res = bob.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        getExportFormats();
                    }
                }             
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string formatString = Client.getExportFormatString(cmbLayouts.Text);
                if (formatString != string.Empty)
                {
                    switch (formatString.Split('*')[0])
                    {
                        case "1":
                            formatString = formatString.Remove(0, 2);
                            csvFormat = formatString.Split('~')[0];
                            csvDelimiter = formatString.Split('~')[1];
                            csvName = cmbLayouts.Text;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case "-1":
                            formatString = formatString.Remove(0, 3);
                            errMsg = formatString.Split('|')[0];
                            errInfo = formatString.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            formatString = formatString.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", formatString, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving item tickets";
                            errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + formatString;
                            ExHandler.showErrorST(st, msgStr, errInfo);
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
    }
}
