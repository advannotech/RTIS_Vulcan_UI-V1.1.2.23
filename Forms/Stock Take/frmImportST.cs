using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms.Stock_Take
{
    public partial class frmImportST : Form
    {
        public string stNum { get; set; }
        public frmImportST()
        {
            InitializeComponent();
        }

        private void frmImportST_Load(object sender, EventArgs e)
        {
            getStockTakes();
        }
        public void getStockTakes()
        {
            try
            {
                string stockTakes = Client.GetEvoStockTakes();
                switch (stockTakes.Split('*')[0])
                {
                    case "1":
                        stockTakes = stockTakes.Remove(0, 2);
                        string[] allStockTakes = stockTakes.Split('~');
                        foreach (string stockTake in allStockTakes)
                        {
                            if (stockTake != "")
                            {
                                cmbEvoST.Properties.Items.Add(stockTake);
                            }
                        }
                        break;
                    case "0":
                        MessageBox.Show("No Stock Takes were pulled please check Evolution", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case "-1":
                        MessageBox.Show("An unexpected server side error has occured: " + Environment.NewLine + Environment.NewLine + stockTakes.Split('*')[1], "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("An unexpected error has occured", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + Environment.NewLine + Environment.NewLine + ex.Message, "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEvoST.Text != "")
                {
                    string imported = Client.ImportEvoStockTake(cmbEvoST.Text.Split('-')[0].Substring(0, cmbEvoST.Text.Split('-')[0].Length - 1));
                    switch (imported.Split('*')[0])
                    {
                        case "1":
                            stNum = cmbEvoST.Text;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case "-1":
                            MessageBox.Show(imported.Split('*')[1], "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show("An unexpected error has occured", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a stock take to import!", "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + Environment.NewLine + Environment.NewLine + ex.Message, "RTIS Vulcan - Stock Take", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
