using RTIS_Vulcan_UI.Classes;
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
    public partial class frmMixedSlurryViewer : Form
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        DataTable dtItems = new DataTable();
        string dataLines = string.Empty;
        bool dataPulled = false;

        DataTable dtChem = new DataTable();
        string chemLines = string.Empty;
        bool chemsPulled = false;

        public string lineID { get; set; }
        public string headerID { get; set; }
        public string tank { get; set; }
        public string slurry { get; set; }
        public string desc { get; set; }
        public string lot { get; set; }
        public string amount { get; set; }
        public string zac { get; set; }
        public string rem { get; set; }
        public string rec { get; set; }

        public string closed { get; set; }
        public string userClosed { get; set; }
        public string dateClosed { get; set; }
        public string reasonClosed { get; set; }
        public string tankType { get; set; }

        public string wetWeight { get; set; }
        public string dryWeight { get; set; }
        public string solitidty { get; set; }

        public frmMixedSlurryViewer(string _lineID, string _headerID, string _tank, string _slurry, string _desc, string _lot, string _amount, string _zac, string _rem, string _rec, string _closed, string _userClosed, string _dateClosed, string _reasonClosed, string _tankType, string _wetWeight, string _dryWeight, string _solidity)
        {
            InitializeComponent();
            lineID = _lineID;
            headerID = _headerID;
            tank = _tank;
            slurry = _slurry;
            desc = _desc;
            lot = _lot;
            amount = _amount;
            zac = _zac;
            rem = _rem;
            rec = _rec;

            closed = _closed;
            userClosed = _userClosed;
            dateClosed = _dateClosed;
            reasonClosed = _reasonClosed;
            tankType = _tankType;

            wetWeight = _wetWeight;
            dryWeight = _dryWeight;
            solitidty = _solidity;
        }
        private void frmMixedSlurryViewer_Load(object sender, EventArgs e)
        {
            lblTank.Text = tank;
            lblSlurry.Text = slurry;
            lblDescription.Text = desc;
            lblLot.Text = lot;
            lblAmount.Text = amount;
            lblRem.Text = rem;
            lblRec.Text = rec;
            lblWet.Text = wetWeight;
            lblDry.Text = dryWeight;
            lblSol.Text = solitidty;

            setUpDatatable();
            refreshItems();

            if (Convert.ToBoolean(closed))
            {
                xtcManual.PageVisible = true;
                btnCloseMix.Visible = false;
                lblClosedBy.Text = userClosed;
                lblDateClosed.Text = dateClosed;
                meCloseReason.Text = reasonClosed;
            }
            else
            {
                xtcManual.PageVisible = false;
                btnCloseMix.Visible = true;
            }
        }
        public void setUpDatatable()
        {
            dtItems.Columns.Add("gcTrolley", typeof(string));
            dtItems.Columns.Add("gcSlurryCode", typeof(string));
            dtItems.Columns.Add("gcSlurryDesc", typeof(string));
            dtItems.Columns.Add("gcSlurryLot", typeof(string));
            dtItems.Columns.Add("gcWeight", typeof(string));

            dtChem.Columns.Add("gcID", typeof(string));
            dtChem.Columns.Add("gcChem", typeof(string));
            dtChem.Columns.Add("gcQty", typeof(string));
        }

        #region Get Slurries
        public void refreshItems()
        {
            ppnlWait.BringToFront();
            dataPulled = false;
            Application.DoEvents();
            tmritems.Start();
            Thread thread = new Thread(getTankSlurries);
            thread.Start();
        }
        public void getTankSlurries()
        {
            try
            {
                dataLines = Client.getMixedSlurryInputs(headerID);
                dataPulled = true;
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setTankSlurries()
        {
            try
            {
                if (dataPulled == true)
                {
                    tmritems.Stop();
                    string slurryLines = dataLines;
                    if (slurryLines != string.Empty)
                    {
                        switch (slurryLines.Split('*')[0])
                        {
                            case "1":
                                dtItems.Rows.Clear();
                                slurryLines = slurryLines.Remove(0, 2);
                                string[] allSlurryLines = slurryLines.Split('~');
                                foreach (string slurryLine in allSlurryLines)
                                {
                                    if (slurryLine != string.Empty)
                                    {
                                        dtItems.Rows.Add(slurryLine.Split('|'));
                                    }
                                }

                                dgItems.DataSource = dtItems;
                                dgItems.MainView.GridControl.DataSource = dtItems;
                                dgItems.MainView.GridControl.EndUpdate();
                                refreshChemicals();
                                break;
                            case "0":
                                dtItems.Rows.Clear();
                                refreshChemicals();
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
        private void tmritems_Tick(object sender, EventArgs e)
        {
            setTankSlurries();
        }
        #endregion

        #region Get Chemicals
        public void refreshChemicals()
        {
            ppnlWait.BringToFront();
            chemsPulled = false;
            Application.DoEvents();
            tmrChems.Start();
            Thread thread = new Thread(getTankChems);
            thread.Start();
        }
        public void getTankChems()
        {
            try
            {
                switch (tank.Split('_')[0])
                {
                    case "TNK":
                        chemLines = Client.getMixedSlurryChemicals(headerID + "|" + tank.Split('_')[0]);
                        chemsPulled = true;
                        break;
                    case "MTNK":
                        chemLines = Client.getMixedSlurryChemicals(lineID + "|" + tank.Split('_')[0]);
                        chemsPulled = true;
                        break;
                }
                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void setTankChems()
        {
            try
            {
                if (chemsPulled == true)
                {
                    tmrChems.Stop();
                    string slurryLines = chemLines;
                    if (slurryLines != string.Empty)
                    {
                        switch (slurryLines.Split('*')[0])
                        {
                            case "1":
                                dtChem.Rows.Clear();
                                slurryLines = slurryLines.Remove(0, 2);
                                string[] allSlurryLines = slurryLines.Split('~');
                                foreach (string slurryLine in allSlurryLines)
                                {
                                    if (slurryLine != string.Empty)
                                    {
                                        dtChem.Rows.Add(slurryLine.Split('|'));
                                    }
                                }

                                dgChems.DataSource = dtChem;
                                dgChems.MainView.GridControl.DataSource = dtChem;
                                dgChems.MainView.GridControl.EndUpdate();
                                ppnlWait.SendToBack();
                                break;
                            case "0":
                                dtChem.Rows.Clear();
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
        private void tmrChems_Tick(object sender, EventArgs e)
        {
            setTankChems();
        }
        #endregion

        private void xtpChems_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnCloseMix_Click(object sender, EventArgs e)
        {
            try
            {
                frmCloseMix cm = new frmCloseMix(tankType, lineID);
                cm.ShowDialog();
                DialogResult res = cm.DialogResult;
                if (res == DialogResult.OK)
                {
                    this.Close();
                }             
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
