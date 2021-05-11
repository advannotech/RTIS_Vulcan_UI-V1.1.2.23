using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucModuleSettings : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion
        public void getPrinters()
        {
            try
            {
                cmbSPPrinter.Properties.Items.Clear();
                cmbFGBoxPrinter.Properties.Items.Clear();
                cmbFGPalletPrinter.Properties.Items.Clear();
                cmbFGBoxPrinterVW.Properties.Items.Clear();
                cmbFGPalletPrinterVW.Properties.Items.Clear();
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    cmbSPPrinter.Properties.Items.Add(printer);
                    cmbFGBoxPrinter.Properties.Items.Add(printer);
                    cmbFGPalletPrinter.Properties.Items.Add(printer);
                    cmbFGBoxPrinterVW.Properties.Items.Add(printer);
                    cmbFGPalletPrinterVW.Properties.Items.Add(printer);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getPermLabels()
        {
            try
            {
                lbSelected.Items.Clear();
                string permName = cmbLabelMods.Text;
                string permLabels = Client.GetPermLabelsNew(permName);
                if (permLabels != string.Empty)
                {
                    switch (permLabels.Split('*')[0])
                    {
                        case "1":
                            permLabels = permLabels.Remove(0, 2);
                            foreach (string label in permLabels.Split('~'))
                            {
                                if (label != string.Empty)
                                {
                                    lbSelected.Items.Add(label);
                                    lbAvailable.Items.Remove(label);
                                }
                            }
                            break;
                        case "0":
                            permLabels = permLabels.Remove(0, 2);
                            lbSelected.Items.Clear();
                            //msg = new frmMsg("The following server side issue was encountered:", permLabels, GlobalVars.msgState.Error);
                            //msg.ShowDialog();
                            break;
                        case "-1":
                            permLabels = permLabels.Remove(0, 3);
                            errMsg = permLabels.Split('|')[0];
                            errInfo = permLabels.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            permLabels = permLabels.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", permLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving information";
                            errInfo = "Unexpected error while retreiving information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + permLabels;
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
        public void getReceivingLabels()
        {
            try
            {
                string permName = "PO Printing";
                string permLabels = Client.GetPermLabelsNew(permName);
                if (permLabels != string.Empty)
                {
                    switch (permLabels.Split('*')[0])
                    {
                        case "1":
                            cmbSPlabel.Properties.Items.Clear();
                            permLabels = permLabels.Remove(0, 2);
                            foreach (string label in permLabels.Split('~'))
                            {
                                if (label != string.Empty)
                                {
                                    cmbSPlabel.Properties.Items.Add(label);
                                }
                            }
                            break;
                        case "0":
                            permLabels = permLabels.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", permLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            permLabels = permLabels.Remove(0, 3);
                            errMsg = permLabels.Split('|')[0];
                            errInfo = permLabels.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            permLabels = permLabels.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", permLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving information";
                            errInfo = "Unexpected error while retreiving information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + permLabels;
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
        public void getFGLabels()
        {
            try
            {
                string permName = "FG Printing";
                string permLabels = Client.GetPermLabelsNew(permName);
                if (permLabels != string.Empty)
                {
                    switch (permLabels.Split('*')[0])
                    {
                        case "1":
                            cmbFGBox.Properties.Items.Clear();
                            cmbFGPallet.Properties.Items.Clear();
                            cmbFGBoxVW.Properties.Items.Clear();
                            cmbFGPalletVW.Properties.Items.Clear();
                            permLabels = permLabels.Remove(0, 2);
                            foreach (string label in permLabels.Split('~'))
                            {
                                if (label != string.Empty)
                                {
                                    cmbFGBox.Properties.Items.Add(label);
                                    cmbFGPallet.Properties.Items.Add(label);
                                    cmbFGBoxVW.Properties.Items.Add(label);
                                    cmbFGPalletVW.Properties.Items.Add(label);
                                }
                            }
                            break;
                        case "0":
                            permLabels = permLabels.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", permLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            permLabels = permLabels.Remove(0, 3);
                            errMsg = permLabels.Split('|')[0];
                            errInfo = permLabels.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            permLabels = permLabels.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", permLabels, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving information";
                            errInfo = "Unexpected error while retreiving information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + permLabels;
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
        public void refreshLabels()
        {
            try
            {
                if (GlobalVars.userPerms.Contains("PO Printing"))
                {
                    getReceivingLabels();
                }

                if (GlobalVars.userPerms.Contains("FG Printing"))
                {
                    getFGLabels();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void resizeComponents()
        {
            //if (flpBack.VerticalScroll.Visible == true)
            //{
            //    foreach (Control cntrl in flpBack.Controls)
            //    {
            //        cntrl.Width = (flpBack.Width) - 15; //7                    
            //    }
            //}
            //else
            //{
            //    foreach (Control cntrl in flpBack.Controls)
            //    {
            //        cntrl.Width = (flpBack.Width) - 7;
            //    }
            //}
        }
        public void getModulesWithLabels()
        {
            try
            {
                cmbLabelMods.Properties.Items.Clear();
                foreach (string permission in GlobalVars.userPerms)
                {
                    string hasLabel = Client.getPermissionsHasLabel(permission);
                    if (hasLabel != string.Empty)
                    {
                        switch (hasLabel.Split('*')[0])
                        {
                            case "1":
                                hasLabel = hasLabel.Remove(0, 2);
                                if (hasLabel != string.Empty)
                                {
                                    if (Convert.ToBoolean(hasLabel) == true)
                                    {
                                        cmbLabelMods.Properties.Items.Add(permission);
                                    }
                                }                                                              
                                break;
                            case "0":
                                hasLabel = hasLabel.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", hasLabel, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                hasLabel = hasLabel.Remove(0, 3);
                                errMsg = hasLabel.Split('|')[0];
                                errInfo = hasLabel.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                hasLabel = hasLabel.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", hasLabel, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving information";
                                errInfo = "Unexpected error while retreiving information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + hasLabel;
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
        public void getViableLabels(string labelType)
        {
            try
            {
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.RSCFolder + @"\Labels\");
                FileInfo[] labels = labelList.GetFiles("*.repx");
                foreach (FileInfo label in labels)
                {
                    if (label != null)
                    {
                        if (label.Name.Contains("_"))
                        {
                            string[] labelInfo = new string[3];
                            string prefix = label.Name.Split('_')[0];
                            if (prefix == labelType)
                            {
                                lbAvailable.Items.Add(label.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getLabelTypes()
        {
            try
            {
                string labelTypes = Client.GetActiveLabels(cmbLabelMods.Text);
                if (labelTypes != string.Empty)
                {
                    switch (labelTypes.Split('*')[0])
                    {
                        case "1":
                            lbAvailable.Items.Clear();
                            labelTypes = labelTypes.Remove(0, 2);
                            string[] allTypes = labelTypes.Split('~');
                            foreach (string type in allTypes)
                            {
                                if (type != string.Empty)
                                {
                                    getViableLabels(type);
                                }
                            }
                            getPermLabels();
                            break;
                        case "0":
                            labelTypes = labelTypes.Remove(0, 2);
                            lbAvailable.Items.Clear();
                            lbSelected.Items.Clear();
                            msg = new frmMsg("The following server side issue was encountered:", labelTypes, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            labelTypes = labelTypes.Remove(0, 3);
                            errMsg = labelTypes.Split('|')[0];
                            errInfo = labelTypes.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            labelTypes = labelTypes.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", labelTypes, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving information";
                            errInfo = "Unexpected error while retreiving information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + labelTypes;
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
        public void checkPermissions()
        {
            if (GlobalVars.userPerms.Contains("PO Printing"))
            {
                getReceivingLabels();
            }
        }
        public ucModuleSettings()
        {
            InitializeComponent();
        }
        private void ucModuleSettings_SizeChanged(object sender, EventArgs e)
        {
            resizeComponents();
        }
        private void ucModuleSettings_Load(object sender, EventArgs e)
        {
            getModulesWithLabels();
            checkPermissions();
            getPrinters();
            cmbSPlabel.Text = GlobalVars.poLabelName;
            cmbSPPrinter.Text = GlobalVars.POPrinter;

            cmbFGBox.Text = GlobalVars.boxLabelName_Toyota;
            cmbFGBoxPrinter.Text = GlobalVars.boxPrinter_Toyota;
            cmbFGPallet.Text = GlobalVars.palletLabelName_Toyota;
            cmbFGPalletPrinter.Text = GlobalVars.palletPrinter_Toyota;

            cmbFGBoxVW.Text = GlobalVars.boxLabelName_VW;
            cmbFGBoxPrinterVW.Text = GlobalVars.boxPrinter_VW;
            cmbFGPalletVW.Text = GlobalVars.palletLabelName_VW;
            cmbFGPalletPrinterVW.Text = GlobalVars.palletPrinter_VW;

            txtPalletLblQty.Text = GlobalVars.palletLabelQty;

            refreshLabels();
            //grpMod.Width = flpBack.Width;
        }
        private void cmbLabelMods_TextChanged(object sender, EventArgs e)
        {
            if (cmbLabelMods.Text != string.Empty)
            {
                getLabelTypes();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string perm = cmbLabelMods.Text;
                string labels = string.Empty;
                foreach (string item in lbSelected.Items)
                {
                    if (item != string.Empty)
                    {
                        labels = labels + item + "|";
                    }
                }
                labels = labels.Substring(0, labels.Length - 1);

                string saved = Client.SavePermLabels(perm + "*" + labels);
                if (saved != string.Empty)
                {
                    switch (saved.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Success", "Module labels have been updated", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            refreshLabels();
                            break;
                        case "0":
                            saved = saved.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", saved, GlobalVars.msgState.Error);
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
                            msgStr = "Unexpected error while saving permission labels";
                            errInfo = "Unexpected error while saving permission labels" + Environment.NewLine + "Data Returned:" + Environment.NewLine + saved;
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
        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            try
            {
                string updateCommand = string.Empty;
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbSPPrinter.Text + "' WHERE [SettingName] = 'POPrinter';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbSPlabel.Text + "' WHERE [SettingName] = 'POLabel';";
                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                switch (updated.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        GlobalVars.poLabelName = cmbSPlabel.Text;
                        GlobalVars.POPrinter = cmbSPPrinter.Text;
                        break;
                    case "-1":
                        updated = updated.Remove(0, 3);
                        errMsg = updated.Split('|')[0];
                        errInfo = updated.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    default:
                        Cursor.Current = Cursors.Default;
                        StackTrace st1 = new StackTrace(0, true);
                        string msgStr1 = "Unexpected saving settings";
                        string infoStr1 = "Unexpected saving setting";
                        ExHandler.showErrorST(st1, msgStr1, infoStr1);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
            
        }
        private void btnAddPerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbAvailable.SelectedItems.Count > 0)
                {
                    object selected = lbAvailable.SelectedItem;
                    lbSelected.Items.Add(selected);
                    lbAvailable.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnRemovePerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSelected.SelectedItems.Count > 0)
                {
                    object selected = lbSelected.SelectedItem;
                    lbAvailable.Items.Add(selected);
                    lbSelected.Items.Remove(selected);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSaveFG_Click(object sender, EventArgs e)
        {
            try
            {
                string updateCommand = string.Empty;
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGBox.Text + "' WHERE [SettingName] = 'ToyBoxLabel';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGBoxPrinter.Text + "' WHERE [SettingName] = 'ToyBoxPrinter';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGPallet.Text + "' WHERE [SettingName] = 'ToyPalletLabel';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGPalletPrinter.Text + "' WHERE [SettingName] = 'ToyPalletPrinter';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGBoxVW.Text + "' WHERE [SettingName] = 'VWBoxLabel';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGBoxPrinterVW.Text + "' WHERE [SettingName] = 'VWBoxPrinter';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGPalletVW.Text + "' WHERE [SettingName] = 'VWPalletLabel';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbFGPalletPrinterVW.Text + "' WHERE [SettingName] = 'VWPalletPrinter';";
                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtPalletLblQty.Text + "' WHERE [SettingName] = 'PalletLabelQty';";

                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                switch (updated.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        GlobalVars.boxLabelName_Toyota = cmbFGBox.Text;
                        GlobalVars.boxPrinter_Toyota = cmbFGBoxPrinter.Text;
                        GlobalVars.palletLabelName_Toyota = cmbFGPallet.Text;
                        GlobalVars.palletPrinter_Toyota = cmbFGPalletPrinter.Text;
                        GlobalVars.boxLabelName_VW = cmbFGBoxVW.Text;
                        GlobalVars.boxPrinter_VW = cmbFGBoxPrinterVW.Text;
                        GlobalVars.palletLabelName_VW = cmbFGPalletVW.Text;
                        GlobalVars.palletPrinter_VW = cmbFGPalletPrinterVW.Text;
                        GlobalVars.palletLabelQty = txtPalletLblQty.Text;
                        break;
                    case "-1":
                        updated = updated.Remove(0, 3);
                        errMsg = updated.Split('|')[0];
                        errInfo = updated.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    default:
                        Cursor.Current = Cursors.Default;
                        StackTrace st1 = new StackTrace(0, true);
                        string msgStr1 = "Unexpected saving settings";
                        string infoStr1 = "Unexpected saving setting";
                        ExHandler.showErrorST(st1, msgStr1, infoStr1);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
