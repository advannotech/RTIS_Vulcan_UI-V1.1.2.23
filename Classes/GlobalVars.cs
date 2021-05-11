using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RTIS_Vulcan_UI.Classes
{
    public class GlobalVars
    {       
        public static string RSCFolder = string.Empty;
        public static string SettingsDB = string.Empty;
        public enum msgState { Error, Success, Question, First, Info }

        public static string userName { get; set; }
        public static string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        #region Settings
        public static string ServerIP { get; set; }
        public static string ServerPort { get; set; }
        public static string SQLServer { get; set; }
        public static string RTDB { get; set; }
        public static string EvoDB { get; set; }
        public static string XperDB { get; set; }
        public static string SqlUser { get; set; }
        public static string SqlPass { get; set; }
        public static bool SqlAuth { get; set; }
        public static string RTUser { get; set; }
        public static string RTPass { get; set; }

        public static string zectSyncLoc { get; set; }
        public static string zect1Label { get; set; }
        public static string zect2Label { get; set; }

        public static string AWSyncLoc { get; set; }
        public static string AWLabel { get; set; }

        public static bool RememberPOLot { get; set; }
        public static string LastPOLot { get; set; }

        public static string LastPOLotRemebered { get; set; }
        public static string PGMLineCount { get; set; }
        #endregion

        #region User Tracking
        public static List<string> allUsers { get; set; }
        public static List<string> userPerms = new List<string>();
        #endregion

        #region Label Printing
        public static string labelName { get; set; }
        public static string labelTypeCode { get; set; }
        public static string poLabelName { get; set; }
        public static XtraReport POLabel { get; set; }
        public static string POPrinter { get; set; }

        public static string boxLabelName_Toyota { get; set; }
        public static XtraReport boxLabel_Toyota { get; set; }
        public static string boxPrinter_Toyota { get; set; }

        public static string palletLabelName_Toyota { get; set; }
        public static XtraReport palletLabel_Toyota { get; set; }
        public static string palletPrinter_Toyota { get; set; }

        public static string boxLabelName_VW { get; set; }
        public static XtraReport boxLabel_VW { get; set; }
        public static string boxPrinter_VW { get; set; }

        public static string palletLabelName_VW { get; set; }
        public static XtraReport palletLabel_VW { get; set; }
        public static string palletPrinter_VW { get; set; }

        public static string palletLabelQty { get; set; }
        #endregion

        #region RM Manufacture

        public static string RMProcess = string.Empty;

        #endregion

        #region Purchase Orders
        public enum cmsType { Item, UOM }
        #endregion
    }
}
