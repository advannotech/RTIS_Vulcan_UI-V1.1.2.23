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

namespace RTIS_Vulcan_UI.Forms.PGM
{
    public partial class frmEditPGM : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public string code { get; set; }
        public string lot { get; set; }
        public string container { get; set; }
        public string qty { get; set; }
        public string location { get; set; }
        public frmEditPGM(string _code, string _lot, string _container, string _qty, string _location)
        {
            InitializeComponent();
            code = _code;
            lot = _lot;
            container = _container;
            qty = _qty;
            location = _location;
        }

        private void frmEditPGM_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblLotNumber.Text = lot;
            lblContainer.Text = container;
            txtQty.Text = qty;
            txtQty.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQty.Text) && !string.IsNullOrEmpty(meReason.Text))
                {
                    decimal ret;
                    bool isDecimal = decimal.TryParse(txtQty.Text.Replace(",", GlobalVars.sep).Replace(".", GlobalVars.sep), out ret);
                    if (isDecimal && ret > 0)
                    {
                        string edited = Client.EditPGMContainer(container + "|" + code + "|" + lot + "|" + qty + "|" + txtQty.Text + "|" + location + "|" + meReason.Text + "|" + GlobalVars.userName);
                        if (!string.IsNullOrEmpty(edited))
                        {
                            switch (edited.Split('*')[0])
                            {
                                case "1":
                                    this.DialogResult = DialogResult.OK;
                                    msg = new frmMsg("Success", "The container has been edited", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    this.Close();
                                    break;
                                case "-1":
                                    edited = edited.Remove(0, 3);
                                    errMsg = edited.Split('|')[0];
                                    errInfo = edited.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                default:
                                    msgStr = "Unexpected error while editing container";
                                    errInfo = "Unexpected error while editing container" + Environment.NewLine + "Data Returned:" + Environment.NewLine + edited;
                                    ExHandler.showErrorStr(msgStr, errInfo);
                                    break;
                            }
                        }
                        else
                        {
                            msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        msg = new frmMsg("Invalid Quantity", "Please enter a valid quantity", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Missing feilds", "Please enter a valid quantity and a reason for the edit", GlobalVars.msgState.Success);
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
