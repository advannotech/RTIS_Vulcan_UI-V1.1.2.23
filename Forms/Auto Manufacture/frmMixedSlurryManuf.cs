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
using DevExpress.XtraSplashScreen;
using RTIS_Vulcan_UI.Classes;
using RTIS_Vulcan_UI.Controls.Manufacturing.PGM;
using RTIS_Vulcan_UI.Forms.Main;

namespace RTIS_Vulcan_UI.Forms.Auto_Manufacture
{
    public partial class frmMixedSlurryManuf : Form
    {
        #region Error handling

        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;

        #endregion

        private string ID;
        private string HeaderID;
        private string Tank;
        private string ItemCode;
        #region On Load

        public frmMixedSlurryManuf(string _id, string _hId, string _tank, string _itemCode, Dictionary<string, string> _slurryInfo)
        {
            InitializeComponent();
            ID = _id;
            HeaderID = _hId;
            Tank = _tank;
            ItemCode = _itemCode;
            AllSlurryInfo = new List<SlurryInfo>();
            foreach (string key in _slurryInfo.Keys)
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    AllSlurryInfo.Add(new SlurryInfo(key, _slurryInfo[key]));
                }
            }

            dgInfo.DataSource = AllSlurryInfo;
            dgInfo.MainView.GridControl.DataSource = AllSlurryInfo;
            dgInfo.MainView.GridControl.EndUpdate();
            gvInfo.RefreshData();
        }

        private void frmMixedSlurryManuf_Load(object sender, EventArgs e)
        {
            GetMixedSlurryInputs();
            switch (Tank.Split('_')[0])
            {
                case "TNK":
                    grpZAC.BringToFront();
                    GetMixedSlurryChemicals();
                    break;
                case "BTNK":
                    grpDecant.BringToFront();
                    GetMixedSlurryDecants();
                    break;
            }
            
        }

        #endregion

        #region Fresh Slurry Inputs

        private void GetMixedSlurryInputs()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string allMixedSlurries = Client.GetMixedSlurryInputsManuf(HeaderID);
                if (!string.IsNullOrWhiteSpace(allMixedSlurries))
                {
                    string returnCode = allMixedSlurries.Split('*')[0];
                    string returnData = allMixedSlurries.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllFreshSlurries = new List<FreshSlurry>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    AllFreshSlurries.Add(new FreshSlurry(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgInput.DataSource = AllFreshSlurries;
                            dgInput.MainView.GridControl.DataSource = AllFreshSlurries;
                            dgInput.MainView.GridControl.EndUpdate();
                            gvInput.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            AllFreshSlurries = new List<FreshSlurry>();
                            dgInput.DataSource = AllFreshSlurries;
                            dgInput.MainView.GridControl.DataSource = AllFreshSlurries;
                            dgInput.MainView.GridControl.EndUpdate();
                            gvInput.RefreshData();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Zonen and Charging

        private void GetMixedSlurryChemicals()
        {
            try
            {
                string chemLines = string.Empty;
                SplashScreenManager.ShowForm(typeof(frmWait));
                switch (Tank.Split('_')[0])
                {
                    case "TNK":
                        chemLines = Client.GetMixedSlurryChemicalsManuf(HeaderID + "|" + Tank.Split('_')[0]);
                        break;
                    case "MTNK":
                        chemLines = Client.GetMixedSlurryChemicalsManuf(ID + "|" + Tank.Split('_')[0]);
                        break;
                }

                if (!string.IsNullOrWhiteSpace(chemLines))
                {
                    string returnCode = chemLines.Split('*')[0];
                    string returnData = chemLines.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllChemicals = new List<Chemical>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    AllChemicals.Add(new Chemical(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgChem.DataSource = AllChemicals;
                            dgChem.MainView.GridControl.DataSource = AllChemicals;
                            dgChem.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            AllChemicals = new List<Chemical>();
                            dgChem.DataSource = AllFreshSlurries;
                            dgChem.MainView.GridControl.DataSource = AllFreshSlurries;
                            dgChem.MainView.GridControl.EndUpdate();
                            gvChem.RefreshData();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Decants

        private void GetMixedSlurryDecants()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string decants = Client.GetMixedSlurryDecantManuf(HeaderID);
                if (!string.IsNullOrWhiteSpace(decants))
                {
                    string returnCode = decants.Split('*')[0];
                    string returnData = decants.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            AllDecants = new List<DecantedSlurry>();
                            string[] mixedSlurryRecords = returnData.Split('~');
                            foreach (string mixedSlurryRecord in mixedSlurryRecords)
                            {
                                if (!string.IsNullOrWhiteSpace(mixedSlurryRecord))
                                {
                                    AllDecants.Add(new DecantedSlurry(mixedSlurryRecord.Split('|')));
                                }
                            }

                            dgDecant.DataSource = AllDecants;
                            dgDecant.MainView.GridControl.DataSource = AllDecants;
                            dgDecant.MainView.GridControl.EndUpdate();
                            gvDecant.RefreshData();
                            SplashScreenManager.CloseForm();
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            AllDecants = new List<DecantedSlurry>();
                            dgDecant.DataSource = AllFreshSlurries;
                            dgDecant.MainView.GridControl.DataSource = AllFreshSlurries;
                            dgDecant.MainView.GridControl.EndUpdate();
                            gvDecant.RefreshData();
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }

                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Manufacture / Close

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmMsg conf = new frmMsg("Please Confirm",
                    "Are you sure you wish to manually close this mixed slurry", GlobalVars.msgState.Question))
                {
                    conf.ShowDialog();
                    if (conf.DialogResult != DialogResult.Yes) return;
                    SplashScreenManager.ShowForm(typeof(frmWait));
                    string closed = string.Empty;
                    switch (Tank.Split('_')[0])
                    {
                        case "TNK":
                            closed = Client.CloseTankManuf(HeaderID + "|" + GlobalVars.userName);
                            break;
                        case "BTNK":
                            closed = Client.CloseBuffTankManuf(HeaderID + "|" + GlobalVars.userName);
                            break;
                        case "MTNK":
                            closed = Client.CloseMobileTankManuf(ID + "|" + GlobalVars.userName);
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(closed))
                    {
                        string returnCode = closed.Split('*')[0];
                        string returnData = closed.Split('*')[1];
                        switch (returnCode)
                        {
                            case "1":
                                SplashScreenManager.CloseForm();
                                using (frmMsg Succ = new frmMsg("Success", "The mixed slurry has been closed",
                                    GlobalVars.msgState.Success))
                                {
                                    Succ.ShowDialog();
                                    this.DialogResult = DialogResult.OK;
                                }

                                break;
                            case "0":
                                SplashScreenManager.CloseForm();
                                using (msg = new frmMsg("Auto Manufacture Error", closed.Remove(0, 2),
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }

                                break;
                            case "-1":
                                SplashScreenManager.CloseForm();
                                errMsg = returnData.Split('|')[0];
                                errInfo = returnData.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                SplashScreenManager.CloseForm();
                                using (msg = new frmMsg("A client side connection error has occured",
                                    returnData,
                                    GlobalVars.msgState.Error))
                                {
                                    msg.ShowDialog();
                                }

                                break;
                            default:
                                SplashScreenManager.CloseForm();
                                st = new StackTrace(0, true);
                                msgStr = "An unexpected error occurred";
                                errInfo = "An unexpected error occurred" + Environment.NewLine +
                                          "Data Returned:" +
                                          Environment.NewLine + returnData;
                                ExHandler.showErrorST(st, msgStr, errInfo);
                                break;
                        }
                    }
                    else
                    {
                        SplashScreenManager.CloseForm();
                        msg = new frmMsg("A connection level error has occured",
                            "No data was returned from the server",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }

        #endregion

        #region Collections

        public class SlurryInfo
        {
            public SlurryInfo(string _name, string _value)
            {
                InfoName = _name;
                InfoValue = _value;
            }

            public string InfoName { get; set; }
            public string InfoValue { get; set; }
        }

        private List<SlurryInfo> AllSlurryInfo = new List<SlurryInfo>();

        public class FreshSlurry
        {
            public FreshSlurry(string[] args)
            {
                TrolleyCode = args[0];
                ItemCode = args[1];
                ItemDesc = args[2];
                LotNumber = args[3];
                Weight = args[4];
            }

            public string TrolleyCode { get; set; }
            public string ItemCode { get; set; }
            public string ItemDesc { get; set; }
            public string LotNumber { get; set; }
            public string Weight { get; set; }
        }

        private List<FreshSlurry> AllFreshSlurries = new List<FreshSlurry>();

        public class Chemical
        {
            public Chemical(string[] args)
            {
                ID = args[0];
                ChemName = args[1];
                Qty = args[2];
            }

            public string ID { get; set; }
            public string ChemName { get; set; }
            public string Qty { get; set; }
        }

        private List<Chemical> AllChemicals = new List<Chemical>();
        public class DecantedSlurry
        {
            public class Chem
            {
                public Chem(string[] args)
                {
                    ID = args[0];
                    ChemName = args[1];
                    Qty = args[2];
                }

                [DisplayName("ID")]
                [ReadOnly(true)]
                public string ID { get; set; }
                [DisplayName("Chemical")]
                [ReadOnly(true)]
                public string ChemName { get; set; }
                [DisplayName("Qty")]
                [ReadOnly(true)]
                public string Qty { get; set; }
            }

            public DecantedSlurry(string[] args)
            {
                TankNumber = args[0];
                WetWeight = args[1];
                Solidity = args[2];
                DryWeight = args[3];
                string chemInfoString = args[4];
                if (!string.IsNullOrWhiteSpace(chemInfoString))
                {
                    string[] chemInfo = chemInfoString.Split(',');
                    Chems = new List<Chem>();
                    foreach (string chem in chemInfo)
                    {
                        Chems.Add(new Chem(chem.Split('#')));
                    }
                }
                //Chems = _chems;
            }
            public string TankNumber { get; set; }
            public string WetWeight { get; set; }
            public string Solidity { get; set; }
            public string DryWeight { get; set; }
            [DisplayName("Chemicals")]
            public List<Chem> Chems { get; set; }
        }
        private List<DecantedSlurry> AllDecants = new List<DecantedSlurry>();
        #endregion

        private void btnManufacture_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(frmWait));
                string decants = Client.ManufactureMixedSlurry(ID + "|" + ItemCode + "|" + GlobalVars.userName);
                if (!string.IsNullOrWhiteSpace(decants))
                {
                    string returnCode = decants.Split('*')[0];
                    string returnData = decants.Split('*')[1];
                    switch (returnCode)
                    {
                        case "1":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("Success",
                                "The mixed slurry journal has been created",
                                GlobalVars.msgState.Success))
                            {
                                msg.ShowDialog();
                                this.DialogResult = DialogResult.OK;
                            }
                            break;
                        case "0":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        case "-1":
                            SplashScreenManager.CloseForm();
                            errMsg = returnData.Split('|')[0];
                            errInfo = returnData.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            SplashScreenManager.CloseForm();
                            using (msg = new frmMsg("A client side connection error has occured",
                                returnData,
                                GlobalVars.msgState.Error))
                            {
                                msg.ShowDialog();
                            }
                            break;
                        default:
                            SplashScreenManager.CloseForm();
                            st = new StackTrace(0, true);
                            msgStr = "An unexpected error occurred";
                            errInfo = "An unexpected error occurred" + Environment.NewLine +
                                      "Data Returned:" +
                                      Environment.NewLine + returnData;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    msg = new frmMsg("A connection level error has occured",
                        "No data was returned from the server",
                        GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SplashScreenManager.CloseForm();
                }
                catch (Exception)
                {
                    // ignored
                }

                ExHandler.showErrorEx(ex);
            }
        }
    }
}