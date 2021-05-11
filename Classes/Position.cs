using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_UI.Classes
{
    class Position
    {
        public static void Center(Control cntrl)
        {
            CenterHorizontally(cntrl);
            CenterVertically(cntrl);
        }

        public static void CenterHorizontally(Control cntrl)
        {
            Rectangle parentRec = cntrl.Parent.ClientRectangle;
            cntrl.Left = (parentRec.Width - cntrl.Width) / 2;
        }

        public static void CenterVertically(Control cntrl)
        {
            Rectangle parentRec = cntrl.Parent.ClientRectangle;
            cntrl.Top = (parentRec.Height - cntrl.Height) / 2;
        }
    }
}
