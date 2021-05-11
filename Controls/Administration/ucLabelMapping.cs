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
using System.Diagnostics;
using RTIS_Vulcan_UI.Forms;
using System.IO;

namespace RTIS_Vulcan_UI.Controls
{
    public partial class ucLabelMapping : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public ucLabelMapping()
        {
            InitializeComponent();
        }
        private void ucLabelMapping_Load(object sender, EventArgs e)
        {
            getZectLabels();
            getSettings();
        }
        public void getZectLabels()
        {
            try
            {
                if (GlobalVars.zectSyncLoc != string.Empty)
                {
                    DirectoryInfo labelList = new DirectoryInfo(GlobalVars.RSCFolder + @"\Labels");
                    FileInfo[] labels = labelList.GetFiles("*.repx");
                    cmbZect1.Properties.Items.Clear();
                    cmbZect2.Properties.Items.Clear();
                    foreach (FileInfo label in labels)
                    {
                        if (label != null)
                        {
                            if (label.Name.Contains("_"))
                            {
                                if (label.Name.Split('_')[0] == "Zect")
                                {
                                    cmbZect1.Properties.Items.Add(label.Name.Split('_')[1].Split('.')[0]);
                                    cmbZect2.Properties.Items.Add(label.Name.Split('_')[1].Split('.')[0]);
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
                txtLocNum.Text = GlobalVars.zectSyncLoc;
                cmbZect1.Text = GlobalVars.zect1Label;
                cmbZect2.Text = GlobalVars.zect2Label;
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
                string  updateCommand = "UPDATE [Settings] SET [Value] ='" + txtLocNum.Text + "' WHERE [SettingName] = 'ZectLabelSyncLoc';";
                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                switch (updated.Split('*')[0])
                {
                    case "1":
                        GlobalVars.zectSyncLoc = txtLocNum.Text;
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
        private void btnSaveZect1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.zectSyncLoc);
                FileInfo[] labels = labelList.GetFiles();
                foreach (FileInfo label in labels)
                {
                    if (label.Name == "Zect 1.repx")
                    {
                        File.Delete(GlobalVars.zectSyncLoc + label.Name);
                    }
                }
                File.Copy(GlobalVars.RSCFolder + @"\Labels\Zect_" + cmbZect1.Text + ".repx", GlobalVars.zectSyncLoc + "Zect 1.repx");

                string resync = Client.resynLabels();
                switch (resync.Split('*')[0])
                {
                    case "1":
                        string updateCommand = "UPDATE [Settings] SET [Value] ='" + cmbZect1.Text + "' WHERE [SettingName] = 'Zect1Label';";
                        string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                GlobalVars.zect1Label = cmbZect1.Text;
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
                        msgStr = "Unexpected error while saving zect 1 label";
                        errInfo = "Unexpected error while saving zect 1 label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + resync;
                        break;
                }

                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnSaveZect2_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo labelList = new DirectoryInfo(GlobalVars.zectSyncLoc);
                FileInfo[] labels = labelList.GetFiles();
                foreach (FileInfo label in labels)
                {
                    if (label.Name == "Zect 2.repx")
                    {
                        File.Delete(GlobalVars.zectSyncLoc + label.Name);
                    }
                }
                File.Copy(GlobalVars.RSCFolder + @"\Labels\Zect_" + cmbZect2.Text + ".repx", GlobalVars.zectSyncLoc + "Zect 2.repx");

                string resync = Client.resynLabels();
                switch (resync.Split('*')[0])
                {
                    case "1":
                        string updateCommand = "UPDATE [Settings] SET [Value] ='" + cmbZect2.Text + "' WHERE [SettingName] = 'Zect2Label';";
                        string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                        switch (updated.Split('*')[0])
                        {
                            case "1":
                                GlobalVars.zect2Label = cmbZect2.Text;
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
                        msgStr = "Unexpected error while saving zect 2 label";
                        errInfo = "Unexpected error while saving zect 2 label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + resync;
                        break;
                }

                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnTest1_Click(object sender, EventArgs e)
        {
            try
            {
                string tested = Client.TestZectPrint("Zect 1");
                switch (tested.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "A test print has been sent to zect 1", GlobalVars.msgState.Success);
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
                        msgStr = "Unexpected error while printing zect 1 label";
                        errInfo = "Unexpected error while printing zect 1 label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tested;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            try
            {
                string tested = Client.TestZectPrint("Zect 2");
                switch (tested.Split('*')[0])
                {
                    case "1":
                        msg = new frmMsg("Success", "A test print has been sent to zect 2", GlobalVars.msgState.Success);
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
                        msgStr = "Unexpected error while printing zect 1 label";
                        errInfo = "Unexpected error while printing zect 1 label" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tested;
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
