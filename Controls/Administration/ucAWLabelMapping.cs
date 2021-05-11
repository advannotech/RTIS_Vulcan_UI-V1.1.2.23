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
using System.IO;
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucAWLabelMapping : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public ucAWLabelMapping()
        {
            InitializeComponent();
        }
        private void ucAWLabelMapping_Load(object sender, EventArgs e)
        {
            getAWLabels();
            getSettings();
        }
        public void getAWLabels()
        {
            try
            {
                if (GlobalVars.AWSyncLoc != string.Empty)
                {
                    DirectoryInfo labelList = new DirectoryInfo(GlobalVars.RSCFolder + @"\Labels");
                    FileInfo[] labels = labelList.GetFiles("*.repx");
                    cmbAWLabel.Properties.Items.Clear();
                    foreach (FileInfo label in labels)
                    {
                        if (label != null)
                        {
                            if (label.Name.Contains("_"))
                            {
                                if (label.Name.Split('_')[0] == "AW")
                                {
                                    cmbAWLabel.Properties.Items.Add(label.Name.Split('_')[1].Split('.')[0]);
                                }
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
        public void getSettings()
        {
            try
            {
                txtLocNum.Text = GlobalVars.AWSyncLoc;
                cmbAWLabel.Text = GlobalVars.AWLabel;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string labelFolder = fbd.SelectedPath;
                txtLocNum.Text = labelFolder + @"\";
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
                string updateCommand = "UPDATE [Settings] SET [Value] ='" + txtLocNum.Text + "' WHERE [SettingName] = 'AWLabelSyncLoc';";
                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                switch (updated.Split('*')[0])
                {
                    case "1":
                        GlobalVars.AWSyncLoc = txtLocNum.Text;
                        msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                        msg.ShowDialog();
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
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string tested = Client.TestAWPrint();
                switch (tested.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "A test print has been sent to AW", GlobalVars.msgState.Success);
                        msg.ShowDialog();
                        break;
                    case "0":
                        tested = tested.Remove(0, 3);
                        errMsg = tested.Split('|')[0];
                        errInfo = tested.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-1":
                        tested = tested.Remove(0, 3);
                        errMsg = tested.Split('|')[0];
                        errInfo = tested.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        msg = new frmMsg("A connection level error has occured", tested, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while printing AW label";
                        errInfo = "Unexpected error while printing AW label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tested;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSaveAW_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.AWSyncLoc);
                FileInfo[] labels = labelList.GetFiles();
                foreach (FileInfo label in labels)
                {
                    if (label.Name == "AW.repx")
                    {
                        File.Delete(GlobalVars.AWSyncLoc + label.Name);
                    }
                }
                File.Copy(GlobalVars.RSCFolder + @"\Labels\AW_" + cmbAWLabel.Text + ".repx", GlobalVars.AWSyncLoc + "AW.repx");

                string resync = Client.resynLabels();
                switch (resync.Split('*')[0])
                {
                    case "1":
                        string updateCommand = "UPDATE [Settings] SET [Value] ='" + cmbAWLabel.Text + "' WHERE [SettingName] = 'AWLabel';";
                        string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                GlobalVars.AWLabel = cmbAWLabel.Text;
                                msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                                msg.ShowDialog();
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
                        break;
                    case "0":
                        resync = resync.Remove(0, 3);
                        errMsg = resync.Split('|')[0];
                        errInfo = resync.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-1":
                        resync = resync.Remove(0, 3);
                        errMsg = resync.Split('|')[0];
                        errInfo = resync.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        msg = new frmMsg("A connection level error has occured", resync, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while saving AW label";
                        errInfo = "Unexpected error while saving AW label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + resync;
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
