﻿using RTIS_Vulcan_UI.Classes;
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

namespace RTIS_Vulcan_UI.Forms
{
    public partial class frmZECTJobInfo : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        #region Variables
        DataTable dtInputs = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;

        DataTable dtOutputs = new DataTable();
        string outLines = string.Empty;
        bool outPulled = false;

        public string id { get; set; }
        public string jobNo { get; set; }

        public DataTable genInfo { get; set; }
        //public string itemCode { get; set; }
        //public string lotNumber { get; set; }
        //public string jobQty { get; set; }
        //public string manufQty { get; set; }
        //public string line { get; set; }
        //public string running { get; set; }
        //public string started { get; set; }
        //public string userStarted { get; set; }
        //public string stopped { get; set; }
        //public string userStopped { get; set; }
        //public string reopened { get; set; }
        //public string userReopened { get; set; }
        #endregion

        public frmZECTJobInfo(string _id, string _jobNo, DataTable _genInfo) 
        {
            //string _itemCode, string _lotNumber, string _jobQty, string _manufQty, string _line, string _running, string _started, string _userStarted, string _stopped,
            //string _userStopped, string _reopened, string _userReopened

            InitializeComponent();
            id = _id;
            jobNo = _jobNo;
            genInfo = _genInfo;
            //itemCode = _itemCode;
            //lotNumber = _lotNumber;
            //jobQty = _jobQty;
            //manufQty = _manufQty;
            //line = _line;
            //running = _running;
            //started = _started;
            //userStarted = _userStarted;
            //stopped = _stopped;
            //userStopped = _userStopped;
            //reopened = _reopened;
            //userReopened = _userReopened;
        }
        private void frmZECTJobInfo_Load(object sender, EventArgs e)
        {
            //lblJob.Text = jobNo;
            //lblItem.Text = itemCode;
            //lblLot.Text = lotNumber;
            //lblJobQty.Text = jobQty;
            //lblManuf.Text = manufQty;
            //lblLine.Text = line;
            //lblJonRunning.Text = running;
            //lblStarted.Text = started;
            //lblUserStarted.Text = userStarted;
            //lblStopped.Text = stopped;
            //lblUserStopped.Text = userStopped;
            //lblReOpened.Text = reopened;
            //lblUserReOpen.Text = userReopened;
            dgInfo.DataSource = genInfo;
            dgInfo.MainView.GridControl.DataSource = genInfo;
            dgInfo.MainView.GridControl.EndUpdate();
            setUpDatatables();
            refreshInputs();
        }
        public void setUpDatatables()
        {
            dtInputs.Columns.Add("gcSlurry", typeof(string));
            dtInputs.Columns.Add("gcSlurryLot", typeof(string));
            dtInputs.Columns.Add("gcQty", typeof(string));
            dtInputs.Columns.Add("gcDate", typeof(string));
            dtInputs.Columns.Add("gcUser", typeof(string));

            dtOutputs.Columns.Add("gcPalletNumber", typeof(string));
            dtOutputs.Columns.Add("gcPalletQty", typeof(string));
            dtOutputs.Columns.Add("gcPalletUser", typeof(string));
            dtOutputs.Columns.Add("gcPalletDate", typeof(string));
            dtOutputs.Columns.Add("gcManuf", typeof(bool));
            dtOutputs.Columns.Add("gcDateManuf", typeof(string));
            dtOutputs.Columns.Add("gcUserManuf", typeof(string));
        }

        #region Get Inputs
        public void refreshInputs()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmrInputs.Start();
            Thread thread = new Thread(getZectInputs);
            thread.Start();
        }
        public void getZectInputs()
        {
            try
            {
                dataLines = Client.getZectJobInputs(id);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setZectInputs()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmrInputs.Stop();
                    string slurryLines = dataLines;
                    if (slurryLines != string.Empty)
                    {
                        switch (slurryLines.Split('*')[0])
                        {
                            case "1":
                                dtInputs.Rows.Clear();
                                slurryLines = slurryLines.Remove(0, 2);
                                string[] allSlurryLines = slurryLines.Split('~');
                                foreach (string slurryLine in allSlurryLines)
                                {
                                    if (slurryLine != string.Empty)
                                    {
                                        dtInputs.Rows.Add(slurryLine.Split('|'));
                                    }
                                }

                                dgInputs.DataSource = dtInputs;
                                dgInputs.MainView.GridControl.DataSource = dtInputs;
                                dgInputs.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                refreshOutputs();
                                break;
                            case "0":
                                dtInputs.Rows.Clear();
                                refreshOutputs();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                slurryLines = slurryLines.Remove(0, 3);
                                errMsg = slurryLines.Split('|')[0];
                                errInfo = slurryLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                slurryLines = slurryLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", slurryLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + slurryLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrInputs_Tick(object sender, EventArgs e)
        {
            setZectInputs();
        }
        #endregion

        #region Get Outputs
        public void refreshOutputs()
        {
            ppnlWait.BringToFront();
            outPulled = false;
            Application.DoEvents();
            tmrOutPuts.Start();
            Thread thread = new Thread(getZectOutPuts);
            thread.Start();
        }
        public void getZectOutPuts()
        {
            try
            {
                outLines = Client.getZectJobOutputs(id);
                outPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setZectOutputs()
        {
            try
            {
                if (outPulled == true)
                {
                    tmrOutPuts.Stop();
                    string slurryLines = outLines;
                    if (slurryLines != string.Empty)
                    {
                        switch (slurryLines.Split('*')[0])
                        {
                            case "1":
                                dtOutputs.Rows.Clear();
                                slurryLines = slurryLines.Remove(0, 2);
                                string[] allSlurryLines = slurryLines.Split('~');
                                foreach (string slurryLine in allSlurryLines)
                                {
                                    if (slurryLine != string.Empty)
                                    {
                                        dtOutputs.Rows.Add(slurryLine.Split('|'));
                                    }
                                }

                                dgOutputs.DataSource = dtOutputs;
                                dgOutputs.MainView.GridControl.DataSource = dtOutputs;
                                dgOutputs.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtOutputs.Rows.Clear();
                                ppnlWait.SendToBack();
                                break;
                            case "-1":
                                ppnlWait.SendToBack();
                                slurryLines = slurryLines.Remove(0, 3);
                                errMsg = slurryLines.Split('|')[0];
                                errInfo = slurryLines.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                ppnlWait.SendToBack();
                                slurryLines = slurryLines.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", slurryLines, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                ppnlWait.SendToBack();
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while retreiving roles";
                                errInfo = "Unexpected error while retreiving roles" + Environment.NewLine + "Data Returned:" + Environment.NewLine + slurryLines;
                                break;
                        }
                    }
                    else
                    {
                        ppnlWait.SendToBack();
                        msg = new frmMsg("A connection level error has occured", "Cannot connect to server!" + Environment.NewLine + "NO data was returned from the server", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ppnlWait.SendToBack();
                ExHandler.showErrorEx(ex);
            }
        }
        private void tmrOutPuts_Tick(object sender, EventArgs e)
        {
            setZectOutputs();
        }
        #endregion
    }
}
