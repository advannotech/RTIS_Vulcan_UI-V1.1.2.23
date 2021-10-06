using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace RTIS_Vulcan_UI.Reports
{
    public partial class rptPOReprintrec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPOReprintrec()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
