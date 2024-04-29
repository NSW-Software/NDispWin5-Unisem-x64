using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DispCore
{
    public partial class frm_DispCore_Lighting : Form
    {
        public frm_DispCore_Lighting()
        {
            InitializeComponent();
            AppLanguage.Func.SetComponent(this);

            Text = "Lighting Adjust";
       }

        private void frmVisionView_Lighting_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lbl_R.Text = TaskVision.CurrentLightRGBA.R.ToString();
            lbl_G.Text = TaskVision.CurrentLightRGBA.G.ToString();
            lbl_B.Text = TaskVision.CurrentLightRGBA.B.ToString();
            lbl_A.Text = TaskVision.CurrentLightRGBA.A.ToString();

            if (tbar_R.Value != TaskVision.CurrentLightRGBA.R) tbar_R.Value = TaskVision.CurrentLightRGBA.R;
            if (tbar_G.Value != TaskVision.CurrentLightRGBA.G) tbar_G.Value = TaskVision.CurrentLightRGBA.G;
            if (tbar_B.Value != TaskVision.CurrentLightRGBA.B) tbar_B.Value = TaskVision.CurrentLightRGBA.B;
            if (tbar_A.Value != TaskVision.CurrentLightRGBA.A) tbar_A.Value = TaskVision.CurrentLightRGBA.A;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Visible = false;
            //Close();
        }

        private void tbar_R_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            RGBA.R = tbar_R.Value;
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_G_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            RGBA.G = tbar_G.Value;
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_B_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            RGBA.B = tbar_B.Value;
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_A_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            RGBA.A = tbar_A.Value;
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void lbl_R_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.R;

            if (GDefine.uc.UserAdjustExecute(ref i, 0, 100))
            {
                RGBA.R = i;
                //int t = GDefine.GetTickCount();
                TaskVision.LightingOn(RGBA);
                //MessageBox.Show((GDefine.GetTickCount() - t).ToString());
                UpdateDisplay();
            }
        }

        private void lbl_G_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.G;

            if (GDefine.uc.UserAdjustExecute(ref i, 0, 100))
            {
                RGBA.G = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }

        private void lbl_B_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.B;

            if (GDefine.uc.UserAdjustExecute(ref i, 0, 100))
            {
                RGBA.B = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }

        private void lbl_A_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.A;

            if (GDefine.uc.UserAdjustExecute(ref i, 0, 100))
            {
                RGBA.A = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }

        private void btn_Off_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOff();
            UpdateDisplay();
        }

        private void btn_On_Click(object sender, EventArgs e)
        {
            TaskVision.LightingOn(TaskVision.DefLightRGB);
            UpdateDisplay();
        }

        private void btn_SetDef_Click(object sender, EventArgs e)
        {
            TaskVision.DefLightRGB = TaskVision.CurrentLightRGBA;
        }

        enum EAdjust { Dn, Up }
        private void OnMouseDn(int Ch, EAdjust Adjust)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int ChValue = 0;
            switch (Ch)
            {
                case 2: ChValue = RGBA.G; break;
                case 3: ChValue = RGBA.B; break;
                case 4: ChValue = RGBA.A; break;
                default: ChValue = RGBA.R; break;
            }

            int t = GDefine.GetTickCount();
            while (b_MouseDn)
            {
                if (Adjust == EAdjust.Dn)
                {
                    if (ChValue <= 0) b_MouseDn = false;
                }
                else
                {
                    if (ChValue >= 100) b_MouseDn = false;
                }
                if (Adjust == EAdjust.Dn)
                {
                    ChValue = ChValue - 1;
                    if (ChValue < 0) ChValue = 0;
                }
                else
                {
                    ChValue = ChValue + 1;
                    if (ChValue > 100) ChValue = 100;
                }
                switch (Ch)
                {
                    case 2: RGBA.G = ChValue; break;
                    case 3: RGBA.B = ChValue; break;
                    case 4: RGBA.A = ChValue; break;
                    default: RGBA.R = ChValue; break;
                }
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();

                if (GDefine.GetTickCount() < t + 100)
                {
                    int t2 = GDefine.GetTickCount() + 200;
                    while (GDefine.GetTickCount() < t2)
                    {
                        Application.DoEvents();
                        Thread.Sleep(5);
                    }
                }
                else
                    if (GDefine.GetTickCount() < t + 1500)
                    {
                        int t2 = GDefine.GetTickCount() + 50;
                        while (GDefine.GetTickCount() < t2)
                        {
                            Application.DoEvents();
                            Thread.Sleep(5);
                        }
                    }
                    else
                    {
                        int t2 = GDefine.GetTickCount() + 10;
                        while (GDefine.GetTickCount() < t2)
                        {
                            Application.DoEvents();
                            Thread.Sleep(5);
                        }
                    }
            }
        }

        bool b_MouseDn = false;
        private void btn_Ch1M_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(1, EAdjust.Dn);
        }

        private void btn_Ch1M_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch1P_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(1, EAdjust.Up);
        }

        private void btn_Ch1P_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch2M_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(2, EAdjust.Dn);
        }

        private void btn_Ch2M_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch2P_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(2, EAdjust.Up);
        }

        private void btn_Ch2P_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch3M_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(3, EAdjust.Dn);
        }

        private void btn_Ch3M_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch3P_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(3, EAdjust.Up);
        }

        private void btn_Ch3P_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch4M_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(4, EAdjust.Dn);
        }

        private void btn_Ch4M_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch4P_MouseDown(object sender, MouseEventArgs e)
        {
            b_MouseDn = true;
            OnMouseDn(4, EAdjust.Up);
        }

        private void btn_Ch4P_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
        }

        private void btn_Ch1M_Click(object sender, EventArgs e)
        {

        }
    }
}
