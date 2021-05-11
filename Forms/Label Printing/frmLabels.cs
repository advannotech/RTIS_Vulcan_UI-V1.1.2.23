using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using RTIS_Vulcan_UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Forms
{   
    public partial class frmLabels : Form
    {
        DataTable dt = new DataTable();
        public void setupTable()
        {
            dt.Columns.Add(new DataColumn("gcName", typeof(string)));
            dt.Columns.Add(new DataColumn("gcType", typeof(string)));
            dt.Columns.Add(new DataColumn("gcSelected", typeof(bool)));
        }
        public void getExistingLabels()
        {
            try
            {
                dt.Rows.Clear();
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.RSCFolder + @"\Labels\");
                FileInfo[] labels = labelList.GetFiles("*.repx");
                foreach (FileInfo label in labels)
                {
                    if (label != null)
                    {
                        if (label.Name.Contains("_"))
                        {
                            string[] labelInfo = new string[3];
                            labelInfo[0] = label.Name.Split('_')[1].Split('.')[0];
                            labelInfo[1] = label.Name.Split('_')[0];
                            labelInfo[2] = "false";
                            dt.Rows.Add(labelInfo);
                        }
                    }
                }
                dgLabels.DataSource = dt;
                dgLabels.MainView.GridControl.DataSource = dt;
                dgLabels.MainView.GridControl.EndUpdate();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public frmLabels()
        {
            InitializeComponent();
        }
        private void frmLabels_Load(object sender, EventArgs e)
        {
            setupTable();
            getExistingLabels();
        }
        private void ribeCbSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedLabel = gvLabels.GetRowCellValue(gvLabels.FocusedRowHandle, "gcName").ToString();
                foreach (DataRow label in dt.Rows)
                {
                    if (label[0].ToString() != selectedLabel)
                    {
                        label[2] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedLabel = gvLabels.GetSelectedRows()[0];
                string selectedLabelName = gvLabels.GetRowCellValue(selectedLabel, "gcName").ToString();
                string selectedLabelCode = gvLabels.GetRowCellValue(selectedLabel, "gcType").ToString();
                string filePath = GlobalVars.RSCFolder + @"\Labels\" + selectedLabelCode + "_" + selectedLabelName + ".repx";

                XRDesignForm desForm = new XRDesignForm();
                desForm.OpenReport(filePath);
                desForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToBoolean(dr[2].ToString()) == true)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you wish to delete " + dr[0].ToString() + "?", "RTIS Hermes - Labels", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string filename = dr[1].ToString()  + "_" + dr[0].ToString() + ".repx";
                            File.Delete(GlobalVars.RSCFolder + @"\Labels\" + filename);
                        }

                    }
                }

                getExistingLabels();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void frmLabels_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (GlobalVars.poLabelName != null)
                {
                    GlobalVars.POLabel = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + GlobalVars.poLabelName, true);
                }
                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
            
        }
    }
}
