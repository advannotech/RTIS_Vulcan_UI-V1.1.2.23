using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UserDesigner;
using RTIS_Vulcan_UI.Classes;
using System.IO;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_UI
{
    class SaveCommandHandler : ICommandHandler { 
    
        XRDesignPanel panel;

        public SaveCommandHandler(XRDesignPanel panel)
        {
            this.panel = panel;
        }

        void Save()
        {
            if (Directory.Exists(GlobalVars.RSCFolder + @"Labels") == false)
            {
                Directory.CreateDirectory(GlobalVars.RSCFolder + @"\Labels");
            }
            panel.Report.SaveLayout(GlobalVars.RSCFolder + @"\Labels\" + GlobalVars.labelTypeCode + "_" + GlobalVars.labelName + ".repx");
            panel.ReportState = ReportState.Saved;            
        }

        public virtual void HandleCommand(ReportCommand command, object[] args)
        {
            Save();
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile ||
                     command == ReportCommand.SaveFileAs);
            return !useNextHandler;
        }
    }
}
