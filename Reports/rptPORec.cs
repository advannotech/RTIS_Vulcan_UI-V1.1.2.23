using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_UI.Reports
{
    public partial class rptPORec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPORec()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
