using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispCore
{
    public partial class frm_DispCore_OutputWindow : Form
    {
        public frm_DispCore_OutputWindow()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        int i_Sequence = 0;
        bool Busy = false;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (Busy) return;

            Busy = true;
            
            if (i_Sequence == DispProg.DataOutput.Sequence) goto _End;
            i_Sequence = DispProg.DataOutput.Sequence;

            lbox_Output.Items.Clear();
            for (int Line = 0; Line < TDataOutput.MAX_TEXTLINE; Line++)
            {
                if (Line < 0 || Line > DispProg.DataOutput.TextLine) break;
                string s_Line = DispProg.DataOutput.Text[Line];
                lbox_Output.Items.Add(s_Line);
            }


            for (int Line = 0; Line < TDataOutput.MAX_DATALINE; Line++)
            {
                string s_Line = (Line + 1).ToString() + (char)9;
                if (Line < 0 || Line > DispProg.DataOutput.DataLine) break;
                for (int i = 0; i < TDataOutput.MAX_DATAINDEX; i++)
                {
                    if (!DispProg.DataOutput.DataIndexUsed[i]) continue;

                    s_Line = s_Line + DispProg.DataOutput.Data[Line, i].ToString("F3") + (char)9;
                }
                lbox_Output.Items.Add(s_Line);
            }

            for (int Line = 0; Line < TDataOutput.MAX_DATALINE; Line++)
            {
                string s_Line = DispProg.DataOutput.ComputeDataLabel[Line] + (char)9;
                if (Line < 0 || Line > DispProg.DataOutput.ComputeDataLine) break;
                for (int i = 0; i < TDataOutput.MAX_DATAINDEX; i++)
                {
                    if (!DispProg.DataOutput.DataIndexUsed[i]) continue;

                    s_Line = s_Line + DispProg.DataOutput.ComputeData[Line, i].ToString("F3") + (char)9;
                }
                lbox_Output.Items.Add(s_Line);
            }
            _End:
            Busy = false;
        }
    }
}
