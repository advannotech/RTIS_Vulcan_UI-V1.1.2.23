using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Forms.Purchase_Orders.CMS_Approval;

namespace RTIS_Vulcan_UI.Forms.Purchase_Orders
{
    public partial class frmApproveCMS : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        private Panel animPanel;
        private List<Panel> otherPanels = new List<Panel>();
        private int _startLeft = -200;  // start position of the panel
        private int _endLeft = 10;      // end position of the panel
        private int _stepSize = 10;     // pixels to move

        private string id { get; set; }
        private string code { get; set; }
        private string desc { get; set; }
        private string lineID { get; set; }
        private string stockLink { get; set; }
        private string version { get; set; }
        private string dataLines = string.Empty;
        private bool dataPulled = false;
        private DataTable dtItems = new DataTable();

        public frmApproveCMS(string _id, string _code, string _desc, string _lineID, string _stockLink, string _version)
        {
            InitializeComponent();
            id = _id;
            code = _code;
            desc = _desc;
            lineID = _lineID;
            stockLink = _stockLink;
            version = _version;
        }
        private void frmApproveCMS_Load(object sender, EventArgs e)
        {
            lblCode.Text = code;
            lblDesc.Text = desc;

            lblRejCode.Text = code;
            lblRejDesc.Text = desc;

            lblAprCode.Text = code;
            lblAprDesc.Text = desc;

            setupDataTable();
            refreshRecords();
            pnlVeiw.BringToFront();
            pnlReg.SendToBack();
        }
        private void setupDataTable()
        {
            try
            {
                dtItems.Columns.Add("gcItem", typeof(string));
                dtItems.Columns.Add("gcUnit", typeof(string));
                dtItems.Columns.Add("gcVarType", typeof(string));
                dtItems.Columns.Add("gcVal1", typeof(string));
                dtItems.Columns.Add("gcVal2", typeof(string));
                dtItems.Columns.Add("gcInspec", typeof(string));
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void refreshRecords()
        {
            try
            {
                ppnlWait.Visible = true;
                ppnlWait.BringToFront();
                Application.DoEvents();
                Thread thread = new Thread(getCMSLines);
                thread.Start();
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void getCMSLines()
        {
            try
            {
                dataLines = Client.GetCMSApprovalLines(id);
                if (IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        setCMSLines();
                    });
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void setCMSLines()
        {
            try
            {
                string itemLines = dataLines;
                if (itemLines != string.Empty)
                {
                    switch (itemLines.Split('*')[0])
                    {
                        case "1":
                            dtItems.Rows.Clear();
                            itemLines = itemLines.Remove(0, 2);
                            string[] ItemArray = itemLines.Split('~');
                            foreach (string item in ItemArray)
                            {
                                if (item != "")
                                {
                                    string[] itemS = item.Split('|');
                                    dtItems.Rows.Add(item.Split('|'));
                                }
                            }
                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();

                            dgReject.DataSource = dtItems;
                            dgReject.MainView.GridControl.DataSource = dtItems;
                            dgReject.MainView.GridControl.EndUpdate();
                            gvReject.RefreshData();

                            dgApprove.DataSource = dtItems;
                            dgApprove.MainView.GridControl.DataSource = dtItems;
                            dgApprove.MainView.GridControl.EndUpdate();
                            gvApprove.RefreshData();

                            foreach (GridColumn item in gvItems.Columns)
                            {
                                item.BestFit();                                
                            }
                            foreach (GridColumn item in gvReject.Columns)
                            {
                                item.BestFit();                                
                            }
                            foreach (GridColumn item in gvApprove.Columns)
                            {
                                item.BestFit();                                
                            }

                            ppnlWait.SendToBack();
                            ppnlWait.Visible = false;
                            break;
                        case "0":
                            dtItems.Rows.Clear();

                            dgItems.DataSource = dtItems;
                            dgItems.MainView.GridControl.DataSource = dtItems;
                            dgItems.MainView.GridControl.EndUpdate();
                            gvItems.RefreshData();

                            dgReject.DataSource = dtItems;
                            dgReject.MainView.GridControl.DataSource = dtItems;
                            dgReject.MainView.GridControl.EndUpdate();
                            gvReject.RefreshData();

                            dgApprove.DataSource = dtItems;
                            dgApprove.MainView.GridControl.DataSource = dtItems;
                            dgApprove.MainView.GridControl.EndUpdate();
                            gvApprove.RefreshData();

                            ppnlWait.SendToBack();
                            ppnlWait.Visible = false;

                            itemLines = itemLines.Remove(0, 2);
                            using (msg = new frmMsg("No data was found", "No data was found for the selected CMS document", GlobalVars.msgState.Info))
                            {
                                msg.ShowDialog();
                            }                            
                            break;
                        case "-1":
                            ppnlWait.SendToBack();
                            ppnlWait.Visible = false;
                            itemLines = itemLines.Remove(0, 3);
                            errMsg = itemLines.Split('|')[0];
                            errInfo = itemLines.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            ppnlWait.SendToBack();
                            ppnlWait.Visible = false;
                            itemLines = itemLines.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemLines, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            ppnlWait.SendToBack();
                            ppnlWait.Visible = false;
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retrieving data";
                            errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemLines;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    ppnlWait.SendToBack();
                    ppnlWait.Visible = false;
                    using (msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }                    
                    
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ppnlWait.Visible = false;
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            animPanel = pnlReg;
            otherPanels.Clear();
            otherPanels.Add(pnlVeiw);
            otherPanels.Add(pnlApprove);
            animationTimer.Enabled = true;
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                wgssSTU.UsbDevices usbDevices = new wgssSTU.UsbDevices();
                if (usbDevices.Count != 0)
                {
                    try
                    {
                        wgssSTU.IUsbDevice usbDevice = usbDevices[0]; // select a device

                        frmCMSSign demo = new frmCMSSign(this, usbDevice);
                        DialogResult res = demo.ShowDialog();
                        //print("SignatureForm returned: " + res.ToString());
                        if (res == DialogResult.OK)
                        {
                            DisplaySignature(demo);
                            animPanel = pnlApprove;
                            animationTimer.Enabled = true;
                            otherPanels.Clear();
                            otherPanels.Add(pnlReg);
                            otherPanels.Add(pnlVeiw);
                        }
                        demo.Dispose();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    using (msg = new frmMsg("Device not found", "No signature pad was detected!", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }   
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void DisplaySignature(frmCMSSign demo)
        {
            Bitmap bitmap;

            bitmap = demo.GetSigImage();
            // resize the image to fit the screen
            int scale = 2;       // halve or quarter the image size
            if( bitmap.Width > 400 )
                scale = 4;
            pbxSign.Size = new Size(bitmap.Width / scale, bitmap.Height / scale);
            pbxSign.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxSign.Image = bitmap;
            //pbxSign.Parent = this;
            //centre the image in the panel

            int x, y;
            x = (this.Width - pbxSign.Width) / 2;//panel1.Location.X + ((panel1.Width - pbxSign.Width) / 2);
            y = panel1.Location.Y + ((panel1.Height - pbxSign.Height) / 2);
            pbxSign.Location = new Point(x, y); 
            pbxSign.BringToFront();
            bitmap.Save("C:\\temp\\" + code + ".png", System.Drawing.Imaging.ImageFormat.Png); //to save the image to disk
        }
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (!animPanel.Visible)
            {
                animPanel.BorderStyle = BorderStyle.FixedSingle;
                animPanel.BringToFront();
                animPanel.Left = _startLeft;
                animPanel.Visible = true;
            }

            // incrementally move
            animPanel.Left += _stepSize;
            // make sure we didn't over shoot
            if (animPanel.Left > _endLeft) animPanel.Left = _endLeft;

            // have we arrived?
            if (animPanel.Left >= _endLeft)
            {
                animationTimer.Enabled = false;
                animPanel.BorderStyle = BorderStyle.None;
                foreach (Panel other in otherPanels)
                {
                    other.Visible = false;
                }
            }         
        }
        private void btnRejBack_Click(object sender, EventArgs e)
        {
            animPanel = pnlVeiw;
            animationTimer.Enabled = true;
            otherPanels.Clear();
            otherPanels.Add(pnlReg);
            otherPanels.Add(pnlApprove);
        }
        private void btnRejDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtReasons.Text))
                {
                    string rejceted = Client.RejectCMSDocument(lineID + "|" + txtReasons.Text + "|" + GlobalVars.userName);
                    switch (rejceted.Split('*')[0])
                    {
                        case "1":
                            using (msg = new frmMsg("Success", "CMS document has been rejected", GlobalVars.msgState.Success))
                            {
                                msg.ShowDialog();
                            }

                            this.DialogResult = DialogResult.OK;
                            break;
                        case "0":
                            rejceted = rejceted.Remove(0, 2);
                            using (msg = new frmMsg("CMS Document error", rejceted, GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            this.Close();
                            break;
                        case "-1":
                            rejceted = rejceted.Remove(0, 3);
                            errMsg = rejceted.Split('|')[0];
                            errInfo = rejceted.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        default:
                            msgStr = "Unexpected error while retrieving data";
                            errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + rejceted;
                            ExHandler.showErrorStr(msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    using (msg = new frmMsg("Unable to reject CMS", "Cannot reject the cms document without reasons being supplied!", GlobalVars.msgState.Error))
                    {
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAprBack_Click(object sender, EventArgs e)
        {
            animPanel = pnlVeiw;
            animationTimer.Enabled = true;
            otherPanels.Clear();
            otherPanels.Add(pnlReg);
            otherPanels.Add(pnlApprove);
        }
        private void btnAprSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sent = Client.ApproveCMSDoc("C:\\temp\\" + code + ".png",  code + ".png", code, GlobalVars.userName, lineID, stockLink, version);
                switch (sent.Split('*')[0])
                {
                    case "1":
                        using (msg = new frmMsg("Success", "CMS document has been approved", GlobalVars.msgState.Success))
                        {
                            msg.ShowDialog();
                        }
                        this.DialogResult = DialogResult.OK;
                        break;
                    case "0":
                        sent = sent.Remove(0, 2);
                        using (msg = new frmMsg("CMS Document error", sent, GlobalVars.msgState.Error))
                        {
                            msg.ShowDialog();
                        }
                        this.Close();
                        break;
                    case "-1":
                        sent = sent.Remove(0, 3);
                        errMsg = sent.Split('|')[0];
                        errInfo = sent.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    default:
                        msgStr = "Unexpected error while retrieving data";
                        errInfo = "Unexpected error while retrieving data" + Environment.NewLine + "Data Returned:" + Environment.NewLine + sent;
                        ExHandler.showErrorStr(msgStr, errInfo);
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
