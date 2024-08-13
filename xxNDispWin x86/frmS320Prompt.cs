using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NDispWin
{
    public partial class frmS320Prompt : Form
    {
        public string Desc = "";
        public string Desc_Alt = "";
        
        public frmS320Prompt()
        {
            Define_Run.PromptButtonFocus = true;

            InitializeComponent();
            GControl.LogForm(this);

            this.Text = "Prompt";
            btn_Start.Text = "OK";
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmS320Prompt_Load(object sender, EventArgs e)
        {
            Text = "Prompt";

            TopMost = true;

            lbl_Desc.Text = Desc;
            lbl_DescAlt.Text = Desc_Alt;
        }

        private void frmS320Prompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Define_Run.PromptButtonFocus = false;
        }

        private void tmr_IO_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            if (GDefineN.BtnStartValid())
            {
                if (NDispWin.TaskGantry.BtnStart())
                {
                    int t = GDefine.GetTickCount();
                    while (true)
                    {
                        if (!NDispWin.TaskGantry.BtnStart())
                        {
                            if (GDefine.GetTickCount() < t + 10) return;
                            else
                            {
                                DialogResult = DialogResult.OK;
                                return;
                            }
                        }
                        Thread.Sleep(5);
                        if (GDefine.GetTickCount() > t + 5000) return;
                    }
                }
            }
            if (GDefineN.BtnStopValid())
            {
                if (!NDispWin.TaskGantry.BtnStop())
                {
                    int t = GDefine.GetTickCount();
                    while (true)
                    {
                        if (NDispWin.TaskGantry.BtnStop())
                        {
                            if (GDefine.GetTickCount() < t + 10) return;
                            else
                            {
                                DialogResult = DialogResult.Cancel;
                                return;
                            }
                        }
                        Thread.Sleep(5);
                        if (GDefine.GetTickCount() > t + 5000) return;
                    }
                }
            }
        }

    }
}
