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

namespace RTIS_Vulcan_UI.Forms
{  
    public partial class frmLabelInit : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public string _name { get; set; }
        public string _width { get; set; }
        public string _height { get; set; }
        public frmLabelInit()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != string.Empty && txtWidth.Text != string.Empty && txtHeight.Text != string.Empty)
                {
                    _name = txtName.Text;
                    _width = txtWidth.Text;
                    _height = txtHeight.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string blanks = string.Empty;
                    if (txtName.Text == string.Empty)
                    {
                        blanks = blanks + " - No name was supplied" + Environment.NewLine;
                    }
                    if (txtWidth.Text == string.Empty)
                    {
                        blanks = blanks + " - No width was supplied" + Environment.NewLine;
                    }
                    if (txtHeight.Text == string.Empty)
                    {
                        blanks = blanks + " - No height was supplied" + Environment.NewLine;
                    }
                    msg = new frmMsg("The label cannot created for the following reasons:", blanks, GlobalVars.msgState.Error);
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
