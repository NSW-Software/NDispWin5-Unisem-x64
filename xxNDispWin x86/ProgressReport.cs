using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispCore
{
    public class ProgressReport2
    {
        frm_ProgressReport frm = new frm_ProgressReport();
        public void Show()
        {
            if (frm == null) frm = new frm_ProgressReport();

            frm.Show();
        }

        public void Cancel()
        {
            if (frm != null)
            {
                frm.Close();
                frm = null;
            }
        }
    }
}
