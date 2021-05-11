using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Main;
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
    public partial class frmCSVBuilder : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public List<ListViewItem> lstItems = new List<ListViewItem>();
        public bool _layoutSaved = false;
        public string csvFormat { get; set; }
        public frmCSVBuilder(List<ListViewItem> _lstItems)
        {
            InitializeComponent();
            lstItems.Clear();
            lstItems = _lstItems;
        }

        private void frmCSVBuilder_Load(object sender, EventArgs e)
        {
            try
            {
                lstAvailable.Items.Clear();
                lstSelected.Items.Clear();
                foreach (ListViewItem item in lstItems)
                {
                    if (item != null)
                    {                      
                        lstAvailable.Items.Add(item);
                    }
                }
                setDelimeters();
                getExportFormats();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setDelimeters()
        {
            try
            {
                cmbDel.Properties.Items.Add("TAB");
                cmbDel.Properties.Items.Add(",");
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
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
                            exportFormats = exportFormats.Remove(0, 2);
                            string[] allFormats = exportFormats.Split('~');
                            foreach (string format in allFormats)
                            {
                                if (format != string.Empty)
                                {
                                    cmbLayouts.Properties.Items.Add(format);
                                }
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAvailable.SelectedItems.Count > 0)
                {
                    ListViewItem selected = lstAvailable.SelectedItems[0];
                    lstAvailable.Items.Remove(selected);
                    lstSelected.Items.Add(selected);

                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelected.SelectedItems.Count > 0)
                {
                    ListViewItem selected = lstSelected.SelectedItems[0];
                    lstSelected.Items.Remove(selected);
                    lstAvailable.Items.Add(selected);

                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (_layoutSaved == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    msg = new frmMsg("", "No layouts have been saved are you sure you want to close this form?", GlobalVars.msgState.Question);
                    msg.ShowDialog();
                    DialogResult res = msg.DialogResult;
                    if (res == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDel.Text != string.Empty && lstSelected.Items.Count > 0)
                {
                    frmLblName name = new frmLblName();
                    name.ShowDialog();
                    DialogResult res = name.DialogResult;
                    if (res == DialogResult.OK)
                    {
                        string formatName = name._input;
                        string delimiter = cmbDel.Text;
                        string format = string.Empty;
                        foreach (ListViewItem item in lstSelected.Items)
                        {
                            if (item != null)
                            {
                                if (item.Text != string.Empty && item.SubItems[1].Text != string.Empty)
                                {
                                    format = format + item.SubItems[1].Text + "|";
                                }
                            }
                        }
                        format = format.Substring(0, format.Length - 1);
                        string sendString = formatName + "*" + format + "*" + delimiter;
                        string layoutSaved = Client.saveExportFormat(sendString);
                        if (layoutSaved != string.Empty)
                        {
                            switch (layoutSaved.Split('*')[0])
                            {
                                case "1":
                                    msg = new frmMsg("Success", "Layout " + formatName + " has been saved", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    _layoutSaved = true;
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                    break;
                                case "-1":
                                    layoutSaved = layoutSaved.Remove(0, 3);
                                    errMsg = layoutSaved.Split('|')[0];
                                    errInfo = layoutSaved.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    layoutSaved = layoutSaved.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", layoutSaved, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving item tickets";
                                    errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + layoutSaved;
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
                }
                else
                {
                    msg = new frmMsg("Missing fields", "Please choose a delimiter and select atleast one column", GlobalVars.msgState.Error);
                    msg.ShowDialog();                
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void cmbLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Maybe textchanged
            try
            {
                string formatString = Client.getExportFormatString(cmbLayouts.Text);
                if (formatString != string.Empty)
                {
                    switch (formatString.Split('*')[0])
                    {
                        case "1":
                            formatString = formatString.Remove(0, 2);
                            string format = formatString.Split('~')[0];
                            cmbDel.Text = formatString.Split('~')[1].Replace("'", "");
                            string[] formatColumns = format.Split('|');

                            foreach (ListViewItem item in lstSelected.Items)
                            {
                                lstSelected.Items.Remove(item);
                                lstAvailable.Items.Add(item);
                            }

                            foreach (string column in formatColumns)
                            {
                                if (column != string.Empty)
                                {
                                    foreach (ListViewItem item in lstAvailable.Items)
                                    {
                                        if (item.SubItems[1].Text == column)
                                        {
                                            lstAvailable.Items.Remove(item);
                                            lstSelected.Items.Add(item);
                                        }
                                    }
                                }
                            }
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLayouts.Text != string.Empty)
                {
                    if (cmbDel.Text != string.Empty && lstSelected.Items.Count > 0)
                    {
                        string formatName = cmbLayouts.Text;
                        string delimiter = cmbDel.Text;
                        string format = string.Empty;
                        foreach (ListViewItem item in lstSelected.Items)
                        {
                            if (item != null)
                            {
                                if (item.Text != string.Empty && item.SubItems[1].Text != string.Empty)
                                {
                                    format = format + item.SubItems[1].Text + "|";
                                }
                            }
                        }
                        format = format.Substring(0, format.Length - 1);
                        string sendString = formatName + "*" + format + "*" + delimiter;

                        string updated = Client.updateExportFormat(sendString);
                        if (updated != string.Empty)
                        {
                            switch (updated.Split('*')[0])
                            {
                                case "1":
                                    msg = new frmMsg("Success", "Changes to " + cmbLayouts.Text + " have been saved", GlobalVars.msgState.Success);
                                    msg.ShowDialog();
                                    _layoutSaved = true;
                                    this.DialogResult = DialogResult.OK;
                                    break;
                                case "-1":
                                    updated = updated.Remove(0, 3);
                                    errMsg = updated.Split('|')[0];
                                    errInfo = updated.Split('|')[1];
                                    ExHandler.showErrorStr(errMsg, errInfo);
                                    break;
                                case "-2":
                                    updated = updated.Remove(0, 2);
                                    msg = new frmMsg("A connection level error has occured", updated, GlobalVars.msgState.Error);
                                    msg.ShowDialog();
                                    break;
                                default:
                                    st = new StackTrace(0, true);
                                    msgStr = "Unexpected error while retreiving item tickets";
                                    errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + updated;
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
                    else
                    {
                        msg = new frmMsg("Missing fields", "Please choose a delimiter and select atleast one column", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Missing fields", "Please choose a delimiter and select atleast one column", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new frmMsg("", "Are you sure you wish to delete " + cmbLayouts.Text + " ?", GlobalVars.msgState.Question);
                msg.ShowDialog();
                DialogResult res = msg.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string deleted = Client.deleteExportFormat(cmbLayouts.Text);
                    if (deleted != string.Empty)
                    {
                        switch (deleted.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "Layout " + cmbLayouts.Text + " has been deleted", GlobalVars.msgState.Success);
                                msg.ShowDialog();                               
                                _layoutSaved = true;
                                this.DialogResult = DialogResult.OK;
                                break;
                            case "-1":
                                deleted = deleted.Remove(0, 3);
                                errMsg = deleted.Split('|')[0];
                                errInfo = deleted.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                deleted = deleted.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", deleted, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving item tickets";
                                errInfo = "Unexpected error while retreiving item tickets" + Environment.NewLine + "Data Returned:" + Environment.NewLine + deleted;
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
