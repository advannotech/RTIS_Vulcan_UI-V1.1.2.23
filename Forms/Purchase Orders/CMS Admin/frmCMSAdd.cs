using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Forms;
using RTIS_Vulcan_UI.Classes;

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders
{
    public partial class frmCMSAdd : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        private GlobalVars.cmsType type;

        public frmCMSAdd(GlobalVars.cmsType _type)
        {
            InitializeComponent();
            type = _type;
            if (type == GlobalVars.cmsType.Item)
            {
                this.Text = "Add CMS Item";
            }
            else
            {
                this.Text = "Add CMS UOM";
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtValue.Text))
                {
                    List<int> iTest = new List<int>();
                    foreach (char c in txtValue.Text)
                    {
                        iTest.Add((int)c);
                    }
                    string added = Client.AddCMSValue(txtValue.Text + "|" + type.ToString()); //string.Join("~", test)
                    if (!string.IsNullOrWhiteSpace(added))
                    {
                        switch (added.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The cms item has been added", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                break;
                            case "0":
                                added = added.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", added, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                added = added.Remove(0, 3);
                                errMsg = added.Split('|')[0];
                                errInfo = added.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                added = added.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", added, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + added;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Cannot add item", "Cannot connect to server!" + Environment.NewLine + "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnMicro_Click(object sender, EventArgs e)
        {
            byte[] A = new[] {(byte)194 ,(byte)181};  //194
            txtValue.Text += UTF8Encoding.UTF8.GetString(A);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            byte[] A = new[] {(byte)195, (byte)133};
            txtValue.Text += UTF8Encoding.UTF8.GetString(A);
        }

        private void btnDegree_Click(object sender, EventArgs e)
        {
            txtValue.Text += "°";
        }
    }
}
