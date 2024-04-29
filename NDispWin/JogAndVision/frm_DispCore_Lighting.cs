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
    public partial class frm_DispCore_Lighting : Form
    {
        public frm_DispCore_Lighting()
        {
            InitializeComponent();
            //AppLanguage.Func.SetComponent(this);

            Text = "Lighting Adjust";
       }

        private void frmVisionView_Lighting_Load(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

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
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.R = tbar_R.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_G_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.G = tbar_G.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_B_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.B = tbar_B.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void tbar_A_Scroll(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA.A = tbar_A.Value;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            TaskVision.LightingOn(RGBA);
            UpdateDisplay();
        }

        private void lbl_R_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.R;

            if (UC.AdjustExec("LED, R", ref i, 0, 100))
            {
                RGBA.R = i;
                TaskVision.LightingOn(RGBA);
                UpdateDisplay();
            }
        }

        private void lbl_G_Click(object sender, EventArgs e)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            int i = RGBA.G;

            if (UC.AdjustExec("LED, G", ref i, 0, 100))
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

            if (UC.AdjustExec("LED, B", ref i, 0, 100))
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

            if (UC.AdjustExec("LED, A", ref i, 0, 100))
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
            //TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
            //int ChValue = 0;
            //switch (Ch)
            //{
            //    case 2: ChValue = RGBA.G; break;
            //    case 3: ChValue = RGBA.B; break;
            //    case 4: ChValue = RGBA.A; break;
            //    default: ChValue = RGBA.R; break;
            //}

            //int t = GDefine.GetTickCount();
            //while (b_MouseDn)
            //{
            //    if (Adjust == EAdjust.Dn)
            //    {
            //        if (ChValue <= 0) b_MouseDn = false;
            //    }
            //    else
            //    {
            //        if (ChValue >= 100) b_MouseDn = false;
            //    }
            //    if (Adjust == EAdjust.Dn)
            //    {
            //        ChValue = ChValue - 1;
            //        if (ChValue < 0) ChValue = 0;
            //    }
            //    else
            //    {
            //        ChValue = ChValue + 1;
            //        if (ChValue > 100) ChValue = 100;
            //    }
            //    switch (Ch)
            //    {
            //        case 2: RGBA.G = ChValue; break;
            //        case 3: RGBA.B = ChValue; break;
            //        case 4: RGBA.A = ChValue; break;
            //        default: RGBA.R = ChValue; break;
            //    }
            //    TaskVision.LightingOn(RGBA);
            //    UpdateDisplay();

            //    if (GDefine.GetTickCount() < t + 100)
            //    {
            //        int t2 = GDefine.GetTickCount() + 200;
            //        while (GDefine.GetTickCount() < t2)
            //        {
            //            Application.DoEvents();
            //            Thread.Sleep(10);
            //        }
            //    }
            //    else
            //        if (GDefine.GetTickCount() < t + 1500)
            //        {
            //            int t2 = GDefine.GetTickCount() + 50;
            //            while (GDefine.GetTickCount() < t2)
            //            {
            //                Application.DoEvents();
            //                Thread.Sleep(10);
            //            }
            //        }
            //        else
            //        {
            //            int t2 = GDefine.GetTickCount() + 10;
            //            while (GDefine.GetTickCount() < t2)
            //            {
            //                Application.DoEvents();
            //                Thread.Sleep(10);
            //            }
            //        }
            //}
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

        private void frm_DispCore_Lighting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Modal)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void MouseDn(int Ch, EAdjust Adjust)
        {
            TLightRGBA RGBA = TaskVision.CurrentLightRGBA;

            string s = "{" + TaskVision.CurrentLightRGBA.R.ToString() + "," + TaskVision.CurrentLightRGBA.G.ToString() + "," + TaskVision.CurrentLightRGBA.B.ToString() + "," + TaskVision.CurrentLightRGBA.A.ToString() + "}";

            int ChValue = 0;
            switch (Ch)
            {
                case 2: ChValue = RGBA.G; break;
                case 3: ChValue = RGBA.B; break;
                case 4: ChValue = RGBA.A; break;
                default: ChValue = RGBA.R; break;
            }

            switch (Adjust)
            {
                case EAdjust.Dn:
                    if (ChValue > 0) ChValue--; break;
                case EAdjust.Up:
                    if (ChValue < 100) ChValue++; break;
            }

            switch (Ch)
            {
                case 2: RGBA.G = ChValue; break;
                case 3: RGBA.B = ChValue; break;
                case 4: RGBA.A = ChValue; break;
                default: RGBA.R = ChValue; break;
            }
            TaskVision.LightingOn(RGBA);
            string ns = "{" + TaskVision.CurrentLightRGBA.R.ToString() + "," + TaskVision.CurrentLightRGBA.G.ToString() + "," + TaskVision.CurrentLightRGBA.B.ToString() + "," + TaskVision.CurrentLightRGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            UpdateDisplay();
        }
        private void btn_Ch1M_Click(object sender, EventArgs e)
        {
            MouseDn(1, EAdjust.Dn);
        }
        private void btn_Ch1P_Click(object sender, EventArgs e)
        {
            MouseDn(1, EAdjust.Up);
        }
        private void btn_Ch2M_Click(object sender, EventArgs e)
        {
            MouseDn(2, EAdjust.Dn);
        }
        private void btn_Ch2P_Click(object sender, EventArgs e)
        {
            MouseDn(2, EAdjust.Up);
        }
        private void btn_Ch3M_Click(object sender, EventArgs e)
        {
            MouseDn(3, EAdjust.Dn);
        }
        private void btn_Ch3P_Click(object sender, EventArgs e)
        {
            MouseDn(3, EAdjust.Up);
        }
        private void btn_Ch4M_Click(object sender, EventArgs e)
        {
            MouseDn(4, EAdjust.Dn);
        }
        private void btn_Ch4P_Click(object sender, EventArgs e)
        {
            MouseDn(4, EAdjust.Up);
        }

        TLightRGBA RGBA = TaskVision.CurrentLightRGBA;
        private void tbar_R_MouseDown(object sender, MouseEventArgs e)
        {
            RGBA = TaskVision.CurrentLightRGBA;
        }
        private void tbar_R_MouseUp(object sender, MouseEventArgs e)
        {
            string s = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            RGBA = TaskVision.CurrentLightRGBA;
            string ns = "{" + RGBA.R.ToString() + "," + RGBA.G.ToString() + "," + RGBA.B.ToString() + "," + RGBA.A.ToString() + "}";
            Log.OnAction("Led Adjust", "Led Value", s, ns);
            UpdateDisplay();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
