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

namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    public partial class frmChangeLoc : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public string proc { get; set; }
        public string src { get; set; }
        public string dest { get; set; }

        public frmChangeLoc(string _proc, string _src, string _dest)
        {
            InitializeComponent();
            proc = _proc;
            src = _src;
            dest = _dest;
        }

        private void frmChangeLoc_Load(object sender, EventArgs e)
        {
            lblProcess.Text = proc;
            getWarehouses();
            cmbSrc.Text = src;
            cmbDest.Text = dest;
        }

        public void getWarehouses()
        {
            try
            {
                string warehouses = Client.GetManufWhses();
                switch (warehouses.Split('*')[0])
                {
                    case "1":
                        warehouses = warehouses.Remove(0, 2);
                        string[] allWarehouses = warehouses.Split('~');
                        foreach (string whse in allWarehouses)
                        {
                            if (whse != string.Empty)
                            {
                                cmbDest.Properties.Items.Add(whse);
                                cmbSrc.Properties.Items.Add(whse);
                            }
                        }    
                        break;
                    case "0":
                        warehouses = warehouses.Remove(0, 2);
                        msg = new frmMsg("Location Config", "No warehouses were found!", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        warehouses = warehouses.Remove(0, 3);
                        errMsg = warehouses.Split('|')[0];
                        errInfo = warehouses.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        warehouses = warehouses.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", warehouses, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving Powder Prep Manufacture items";
                        errInfo = "Unexpected error while retreiving  Powder Prep Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + warehouses;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSrc.Text != string.Empty && cmbDest.Text != string.Empty)
                {
                    string saved = Client.SaveManufWhses(proc + "|" + cmbSrc.Text + "|" + cmbDest.Text);
                    switch (saved.Split('*')[0])
                    {
                        case "1":
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        case "0":
                            saved = saved.Remove(0, 2);
                            msg = new frmMsg("Location Config", "No warehouses were found!", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            saved = saved.Remove(0, 3);
                            errMsg = saved.Split('|')[0];
                            errInfo = saved.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            saved = saved.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", saved, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving Powder Prep Manufacture items";
                            errInfo = "Unexpected error while retreiving  Powder Prep Manufacture items" + Environment.NewLine + "Data Returned:" + Environment.NewLine + saved;
                            break;
                    }
                }  
                else
                {
                    msg = new frmMsg("Missing Information", "Please select a source and a destination warehouse", GlobalVars.msgState.Error);
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
