using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDispWin
{
    public partial class frm_DispCore_DispSetup_DispControl : Form
    {
        public frm_DispCore_DispSetup_DispControl()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_DispControl_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
        }
        private void frm_DispCore_DispSetup_DispControl_Shown(object sender, EventArgs e)
        {
        }
        private void frm_DispCore_DispSetup_DispControl_VisibleChanged(object sender, EventArgs e)
        {
            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            switch (TaskDisp.Head1_CtrlNo)
            {
                case 0: lbl_Head1CtrlNo.Text = "1"; break;
                case 1: lbl_Head1CtrlNo.Text = "2"; break;
                default: lbl_Head1CtrlNo.Text = "None"; break;
            }
            switch (TaskDisp.Head1_CtrlHeadNo)
            {
                case 0: lbl_Head1CtrlHeadNo.Text = "A"; break;
                case 1: lbl_Head1CtrlHeadNo.Text = "B"; break;
                default: lbl_Head1CtrlHeadNo.Text = "None"; break;
            }
            switch (TaskDisp.Head2_CtrlNo)
            {
                case 0: lbl_Head2CtrlNo.Text = "1"; break;
                case 1: lbl_Head2CtrlNo.Text = "2"; break;
                default: lbl_Head2CtrlNo.Text = "None"; break;
            }
            switch (TaskDisp.Head2_CtrlHeadNo)
            {
                case 0: lbl_Head2CtrlHeadNo.Text = "A"; break;
                case 1: lbl_Head2CtrlHeadNo.Text = "B"; break;
                default: lbl_Head2CtrlHeadNo.Text = "None"; break;
            }

            if (TaskDisp.DispReady_TimeOut <= 0)
                lbl_DispReadyTimeOut.Text = "Disabled";
            else
                lbl_DispReadyTimeOut.Text = TaskDisp.DispReady_TimeOut.ToString();
            if (TaskDisp.DispResponse_TimeOut <= 0)
                lbl_DispResponseTimeOut.Text = "Disabled";
            else
                lbl_DispResponseTimeOut.Text = TaskDisp.DispResponse_TimeOut.ToString();
            //if (TaskDisp.DispComplete_TimeOut <= 0)
            //    lbl_DispCompleteTimeOut.Text = "Disabled";
            //else
            //    lbl_DispCompleteTimeOut.Text = TaskDisp.DispComplete_TimeOut.ToString();
            lbl_DispCompleteTimeOut.Text = TaskDisp.DispComplete_TimeOut <= 0 ? "Disabled" : TaskDisp.DispComplete_TimeOut.ToString();


            lbl_DispReadyLogic.Text = Enum.GetName(typeof(TaskDisp.EDispIOLogic), TaskDisp.DispReadyLogic).ToString();
            lbl_DispRespLogic.Text = Enum.GetName(typeof(TaskDisp.EDispIOLogic), TaskDisp.DispResponseLogic).ToString();
            lbl_DispCompleteLogic.Text = Enum.GetName(typeof(TaskDisp.EDispIOLogic), TaskDisp.DispCompleteLogic).ToString();
            lbl_DispErrorLogic.Text = Enum.GetName(typeof(TaskDisp.EDispIOLogic), TaskDisp.DispErrorLogic).ToString();

            lbl_HeadOperation.Text = Enum.GetName(typeof(TaskDisp.EHeadOperation), TaskDisp.Head_Operation).ToString();
            lbl_PumpType.Text = Enum.GetName(typeof(TaskDisp.EPumpType), DispProg.Pump_Type).ToString();
            //lbl_MultiHeadPitchX.Text = TaskDisp.MultiHead_PitchX.ToString("f3");
            //lbl_MultiHeadZTol.Text = TaskDisp.MultiHead_ZTol.ToString("f3");

            //lbl_HeadNeedlePitchY.Text = TaskDisp.Pump_NeedlePitchY.ToString();

            lbl_RecycleNeedleVolume.Text = TaskDisp.DispTool_RecycleNeedleVolume.ToString("f3");

            //lbl_FPress1.Text = (DispProg.FPress[0] * 145.038).ToString("f1");
            //lbl_FPress2.Text = (DispProg.FPress[1] * 145.038).ToString("f1");
            lbl_FPress1.Text = FPressCtrl.GetPressStr(DispProg.FPress[0]);
            lbl_FPress2.Text = FPressCtrl.GetPressStr(DispProg.FPress[1]);
            
            lbl_PressUnit.Text = "(" + FPressCtrl.PressUnitStr + ")";
        }

        private void lbl_Head1CtrlNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Head1 Ctrl No", ref TaskDisp.Head1_CtrlNo, -1, 1);
            UpdateDisplay();
        }

        private void lbl_Head1CtrlHeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Head1 Ctrl Head No", ref TaskDisp.Head1_CtrlHeadNo, -1, 1);
            UpdateDisplay();
        }

        private void lbl_Head2CtrlNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Head2 Ctrl No", ref TaskDisp.Head2_CtrlNo, -1, 1);
            UpdateDisplay();
        }

        private void lbl_Head2CtrlHeadNo_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Head2 Ctrl Head No", ref TaskDisp.Head2_CtrlHeadNo, -1, 1);
            UpdateDisplay();
        }

        private void lbl_DispReadyTimeOut_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Disp Ready TimeOut (ms)", ref TaskDisp.DispReady_TimeOut, 0, 60000);
            UpdateDisplay();
        }

        private void lbl_DispResponseTimeOut_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Disp Response TimeOut (ms)", ref TaskDisp.DispResponse_TimeOut, 0, 20000);
            UpdateDisplay();
        }

        private void lbl_DispCompleteTimeOut_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Disp Complete TimeOut (ms)", ref TaskDisp.DispComplete_TimeOut, 0, 60000);
            UpdateDisplay();
        }

        private void lbl_DispReadyLogic_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.DispReadyLogic;
            UC.AdjustExec("Disp Control, Disp Ready Logic", ref i, 0, 2);
            TaskDisp.DispReadyLogic = (TaskDisp.EDispIOLogic)i;
            UpdateDisplay();
        }

        private void lbl_DispRespLogic_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.DispResponseLogic;
            UC.AdjustExec("Disp Control, Disp Response Logic", ref i, 0, 2);
            TaskDisp.DispResponseLogic = (TaskDisp.EDispIOLogic)i;
            UpdateDisplay();
        }

        private void lbl_DispCompleteLogic_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.DispCompleteLogic;
            UC.AdjustExec("Disp Control, Disp Complete Logic", ref i, 0, 2);
            TaskDisp.DispCompleteLogic = (TaskDisp.EDispIOLogic)i;
            UpdateDisplay();
        }

        private void lbl_DispErrorLogic_Click(object sender, EventArgs e)
        {
            int i = (int)TaskDisp.DispErrorLogic;
            UC.AdjustExec("Disp Control, Disp Error Logic", ref i, 0, 2);
            TaskDisp.DispErrorLogic = (TaskDisp.EDispIOLogic)i;
            UpdateDisplay();
        }

        //private void lbl_MultiHeadType_Click(object sender, EventArgs e)
        //{
        //    int i = (int)TaskDisp.MultiHead_Type;
        //    GDefine.uc.UserAdjustExecute("MultiHead Count", ref i, 1, 2);
        //    TaskDisp.MultiHead_Type = (TaskDisp.EMultiHeadType)i;
        //    TaskDisp.MultiHead_OpType = TaskDisp.MultiHead_Type;
        //    UpdateDisplay();
        //}

        //private void lbl_MultiHeadPitchX_Click(object sender, EventArgs e)
        //{
        //    //GDefine.uc.UserAdjustExecute("MultiHead Pitch", ref TaskDisp.MultiHead_PitchX, -100, 100);
        //    //TaskDisp.MultiHead_OpPitchX = TaskDisp.MultiHead_PitchX;
        //    //UpdateDisplay();
        //}

        //private void lbl_HeadType_Click(object sender, EventArgs e)
        //{
        //    int i = (int)TaskDisp.Pump_Type;
        //    GDefine.uc.UserAdjustExecute("Head Type", ref i, 0, 5);
        //    TaskDisp.Pump_Type = (TaskDisp.EPumpType)i;
        //    TaskDisp.Pump_OpType = TaskDisp.Pump_Type;
        //    UpdateDisplay();
        //}

        //private void lbl_HeadNeedlePitchY_Click(object sender, EventArgs e)
        //{
        //    //GDefine.uc.UserAdjustExecute("Head Needle Pitch Y", ref TaskDisp.Pump_NeedlePitchY, -50, 0);
        //    //TaskDisp.Pump_OpNeedlePitchY = TaskDisp.Pump_NeedlePitchY;
        //    //UpdateDisplay();
        //}

        private void lbl_RecycleNeedleVolume_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Control, Recycle Needle Volume (ul)", ref TaskDisp.DispTool_RecycleNeedleVolume, 0, 100);
            UpdateDisplay();
        }

        private void btn_FuncSetup_Click(object sender, EventArgs e)
        {
            frm_DispCore_DispCtrl_FuncSetup frm = new frm_DispCore_DispCtrl_FuncSetup();
            frm.ShowDialog();
        }

        private void btn_CalA_Click(object sender, EventArgs e)
        {
            try
            {
                FPressCtrl.SetMPa(0, DispProg.FPress, false);

                double d = FPressCtrl.GetPress(DispProg.FPress[0]);//* 145.038;
                if (UC.AdjustExec("Disp Control, Cal FPress 1 Gauge Value", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax))
                    FPressCtrl.CalTo(0, FPressCtrl.PressGetMPa(d));
                
                FPressCtrl.SetPress_MPa(DispProg.FPress);
                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void btn_CalB_Click(object sender, EventArgs e)
        {
            try
            {
                FPressCtrl.SetMPa(1, DispProg.FPress, false);
 
                //double d = DispProg.FPress[1] * 145.038;
                double d = FPressCtrl.GetPress(DispProg.FPress[1]);//* 145.038;
                if (UC.AdjustExec("Disp Control, Cal FPress 2 Gauge Value", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax))
                    //FPressCtrl.CalTo(1, d / 145.038);
                    FPressCtrl.CalTo(1, FPressCtrl.PressGetMPa(d));

                FPressCtrl.SetPress_MPa(DispProg.FPress);
                UpdateDisplay();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
            }
        }

        private void lbl_FPress1_Click(object sender, EventArgs e)
        {
            //double d = DispProg.FPress[0] * 145.038;
            //d = Math.Round(d, 3);
            //if (UC.AdjustExec("FPress 1", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax))
            //{
            //    DispProg.FPress[0] = d / 145.038;
            //    UpdateDisplay();

            //    try
            //    {
            //        FPressCtrl.SetMPa(DispProg.FPress);
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(Ex.Message.ToString());
            //    }
            //}
            //double d = FPressCtrl.GetPress(DispProg.FPress[0]);
            FPressCtrl.AdjustPress_MPa(0, ref DispProg.FPress, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            UpdateDisplay();
        }

        private void lbl_FPress2_Click(object sender, EventArgs e)
        {
            //double d = DispProg.FPress[1] * 145.038;
            //d = Math.Round(d, 3);
            //if (UC.AdjustExec("FPress 2", ref d, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax))
            //{
            //    DispProg.FPress[1] = d / 145.038;
            //    UpdateDisplay();

            //    try
            //    {
            //        FPressCtrl.SetMPa(DispProg.FPress);
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(Ex.Message.ToString());
            //    }
            //}
            //double d = FPressCtrl.GetPress(DispProg.FPress[1]);
            FPressCtrl.AdjustPress_MPa(1, ref DispProg.FPress, FPressCtrl.GetPressMin, FPressCtrl.GetPressMax);
            UpdateDisplay();
        }

        private void lbl_FPressLinearFactor_Click(object sender, EventArgs e)
        {

        }
    }
}
