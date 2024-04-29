using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;

namespace NDispWin
{
    public partial class frm_DispCore_DispInfo : Form
    {
        public enum EAdjustUnit { ul, ms };
        public EAdjustUnit AdjustUnit = EAdjustUnit.ul;

        public frm_DispCore_DispInfo()
        {
            InitializeComponent();
            GControl.LogForm(this);

            tmr_Display.Enabled = true;
        }

        public static Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> FoundDoRef1 = null;
        public static Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> FoundDoRef2 = null;

        private void UpdateDisplay()
        {
            try
            {
                string Text = DispProg.FoundDoRef1_X.ToString("f3") + "," + DispProg.FoundDoRef1_Y.ToString("f3");
                string Text2 = (DispProg.FoundDoRef1_S * 100).ToString("f1") + "%";

                Color Color = new Color();
                Color = Color.Red;
                if (DispProg.FoundDoRef1_OK) Color = Color.Lime;

                FoundDoRef1 = DispProg.FoundDoRef1.Copy();
                Emgu.CV.CvInvoke.PutText(FoundDoRef1, Text, new Point(5, 5), Emgu.CV.CvEnum.FontFace.HersheyComplex, 0.35, new Emgu.CV.Structure.MCvScalar(Color.B, Color.G, Color.R));
                Emgu.CV.CvInvoke.PutText(FoundDoRef1, Text2, new Point(5, 10), Emgu.CV.CvEnum.FontFace.HersheyComplex, 0.35, new Emgu.CV.Structure.MCvScalar(Color.B, Color.G, Color.R));

                pbox_DoRef1.Image = FoundDoRef1.ToBitmap();
            }
            catch { };
            try
            {
                string Text = DispProg.FoundDoRef2_X.ToString("f3") + "," + DispProg.FoundDoRef2_Y.ToString("f3");
                string Text2 = (DispProg.FoundDoRef2_S*100).ToString("f1") + "%";

                Color Color = new Color();
                Color = Color.Red;
                if (DispProg.FoundDoRef2_OK) Color = Color.Lime;

                FoundDoRef2 = DispProg.FoundDoRef2.Copy();
                Emgu.CV.CvInvoke.PutText(FoundDoRef2, Text, new Point(5, 5), Emgu.CV.CvEnum.FontFace.HersheyComplex, 0.35, new Emgu.CV.Structure.MCvScalar(Color.B, Color.G, Color.R));
                Emgu.CV.CvInvoke.PutText(FoundDoRef2, Text2, new Point(5, 10), Emgu.CV.CvEnum.FontFace.HersheyComplex, 0.35, new Emgu.CV.Structure.MCvScalar(Color.B, Color.G, Color.R));

                pbox_DoRef2.Image = FoundDoRef2.ToBitmap();
            }
            catch { };

            #region Material Life
            int i_LifeTimer_s = (int)TaskDisp.Material_Life_EndTime.Subtract(DateTime.Now).TotalSeconds;
            if (i_LifeTimer_s > 0)
            {
                gbox_Material2.Visible = true;

                if (i_LifeTimer_s <= 0)
                {
                    lbl_MaterialLifeCountDown.Text = "0";
                }
                else
                {
                    int i_LifeTimer_m = i_LifeTimer_s / 60;
                    int i_LifeTimer_h = i_LifeTimer_m / 60;

                    lbl_MaterialLifeCountDown.Text = 
                    i_LifeTimer_h.ToString() + " H " +
                    (i_LifeTimer_m % 60).ToString() + " M " +
                    (i_LifeTimer_s % 60).ToString() + " S";
                }
            
            }
            else
                gbox_Material2.Visible = false;
            #endregion

            lbl_SensMat1Low.Visible = TaskDisp.Option_EnableMaterialLow;
            lbl_SensMat2Low.Visible = TaskDisp.Option_EnableMaterialLow;

            #region PP Disp Vol
            double DispA_BaseVol_ul = DispProg.PP_HeadA_DispBaseVol;
            double DispB_BaseVol_ul = DispProg.PP_HeadB_DispBaseVol;
            lbl_DA_DispBase.Text = DispA_BaseVol_ul.ToString("f3");
            lbl_DB_DispBase.Text = DispB_BaseVol_ul.ToString("f3");

            double DispA_DispAdj_ul = DispProg.PP_HeadA_DispVol_Adj;
            double DispB_DispAdj_ul = DispProg.PP_HeadB_DispVol_Adj;
            lbl_DA_DispAdj.Text = DispA_DispAdj_ul.ToString("f3");
            lbl_DB_DispAdj.Text = DispB_DispAdj_ul.ToString("f3");

            double DispA_VolOfst = DispProg.rt_Head1VolumeOfst;
            double DispB_VolOfst = DispProg.rt_Head2VolumeOfst;
            lbl_DA_DispOfst.Text = DispA_VolOfst.ToString("f3");
            lbl_DB_DispOfst.Text = DispB_VolOfst.ToString("f3");

            lbl_DA_BackSuckVol.Text = DispProg.PP_HeadA_BackSuckVol.ToString("f3");
            lbl_DB_BackSuckVol.Text = DispProg.PP_HeadB_BackSuckVol.ToString("f3");

            lbl_DA_Disp.Text = (DispProg.PP_HeadA_DispBaseVol + DispProg.PP_HeadA_DispVol_Adj + DispProg.rt_Head1VolumeOfst - DispProg.PP_HeadA_BackSuckVol).ToString("f3");
            lbl_DB_Disp.Text = (DispProg.PP_HeadB_DispBaseVol + DispProg.PP_HeadB_DispVol_Adj + DispProg.rt_Head2VolumeOfst - DispProg.PP_HeadB_BackSuckVol).ToString("f3");
            #endregion

            lbl_HeadAUnitCount.Text = Stats.UnitCount[0].ToString();// HeadAShotCount.ToString();
            lbl_HeadBUnitCount.Text = Stats.UnitCount[1].ToString();// HeadBShotCount.ToString();
            lbl_FrameCount.Text = Stats.BoardCount.ToString();
            int t = GDefine.GetTickCount() - Stats.StartTime;
            lbl_Runtime.Text = ((double)t / 60000).ToString("f1");
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void pbox_DoRef2_Click(object sender, EventArgs e)
        {

        }

        private void frm_DispCore_DispInfo_Load(object sender, EventArgs e)
        {
            Text = "Dispense Info";

            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();
        }

        private void frm_DispCore_DispInfo_Shown(object sender, EventArgs e)
        {
            gbox_Para.Visible = (DispProg.Pump_Type == TaskDisp.EPumpType.HM || DispProg.Pump_Type == TaskDisp.EPumpType.PP || DispProg.Pump_Type == TaskDisp.EPumpType.PP2D || DispProg.Pump_Type == TaskDisp.EPumpType.PPD);
            
            if (DispProg.Pump_Type == TaskDisp.EPumpType.HM)
                AdjustUnit = EAdjustUnit.ms;
            else
                AdjustUnit = EAdjustUnit.ul;

            lbl_DispUnit.Text = "(" + AdjustUnit.ToString() + ")";
            lbl_OffsetUnit.Text = "(" + AdjustUnit.ToString() + ")";
            lbl_BackSuckUnit.Text = "(" + AdjustUnit.ToString() + ")";
        }

        private void gbox_Material_Enter(object sender, EventArgs e)
        {

        }

        private void gbox_LiveCapture_Enter(object sender, EventArgs e)
        {

        }

        private void btn_SnapImage_Click(object sender, EventArgs e)
        {

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Stats.ResetDispCount();
            Stats.ResetUnitCount();
            Stats.BoardCount = 0;
            Stats.StartTime = GDefine.GetTickCount();
            UpdateDisplay();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_ForceErrorSet_Click(object sender, EventArgs e)
        {
        }

        private void nud_ErrorCode_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tmr_10sec_Tick(object sender, EventArgs e)
        {
            try
            {
                GDefine.RefreshInput(lbl_SensMat1Low, TaskGantry.SensMat1Low());
                GDefine.RefreshInput(lbl_SensMat2Low, TaskGantry.SensMat2Low());
            }
            catch { };

            if (TaskDisp.VolumeOfst_Protocol == TaskDisp.EVolumeOfstProtocol.AOT_FrontTestCloseLoop )
            {
                NDispWin.AOT_FrontTestCloseLoop.AddLogSummaryByShift();
            }
        }
    }
}
