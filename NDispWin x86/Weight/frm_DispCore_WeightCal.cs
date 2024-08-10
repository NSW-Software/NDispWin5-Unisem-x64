using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NDispWin
{
    using ZedGraph;
    
    internal partial class frm_DispCore_WeightCal : Form
    {
        public enum ECalMode { Manual, Auto };
        public ECalMode CalMode = ECalMode.Manual;
        public List<TaskWeight.EHeadNo> HeadToCal = new List<TaskWeight.EHeadNo>();
        
        public frm_DispCore_WeightCal()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmWeightSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            groupBox4.Visible = File.Exists(GDefine.AppPath + "\\WeightEmulate.txt");
            groupBox4.Text = "..\\WeightEmulate.txt";

            AppLanguage.Func2.UpdateText(this);

            if (CalMode == ECalMode.Auto)
            {
                btn_Tare.Visible = false;
                btn_Start.Visible = false;
                btn_Head1.Enabled = false;
                btn_Head2.Enabled = false;
                lbl_CalTarget.Enabled = false;
            }

            this.BringToFront();
            this.TopMost = true;

            lbox_Result.Items.Clear();

            TaskWeight.Cal_Meas_Weight = DispProg.Cal_Meas_Weight == 0 ? DispProg.Target_Weight : DispProg.Cal_Meas_Weight;
            if (DispProg.Cal_Weight_Tol != 0) TaskWeight.CalTol = DispProg.Cal_Weight_Tol;


            switch (DispProg.Pump_Type)
            {
                case TaskDisp.EPumpType.PP:
                case TaskDisp.EPumpType.PP2D:
                case TaskDisp.EPumpType.PPD:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.Density;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Volume;

                    if (DispProg.Target_Weight > 0)
                        TaskDisp.PP_SetWeight(new double[2] { TaskWeight.Cal_Meas_Weight, TaskWeight.Cal_Meas_Weight }, false, true);
                    break;
                case TaskDisp.EPumpType.HM:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_s;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Speed;
                    break;
                case TaskDisp.EPumpType.Vermes:
                case TaskDisp.EPumpType.Vermes1560:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_dot;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Pressure;
                    break;
                case TaskDisp.EPumpType.SP:
                    TaskWeight.CalMeasType = TaskWeight.ECalMeasType.FR_mg_s;
                    TaskWeight.CalAdjustType = TaskWeight.ECalAdjustType.Pressure;
                    break;
                default:
                    MessageBox.Show("Pump Type " + DispProg.Pump_Type.ToString() + " not supported.");
                    break;
            }

            if (!TaskWeight.WeightIsOpen)
            {
                TaskWeight.WeightOpen();
            }

            if (CalMode == ECalMode.Auto)
            {
                tmr_Start.Enabled = true;
            }

            UpdateDisplay();
        }
        private void frm_DispCore_WeightCal_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskDisp.FPressOff();

            TaskWeight.SoftZeroReset();
            try
            {
                TaskDisp.TaskMoveGZZ2Up();
            }
            catch { };
        }

        readonly string dp3 = "f3";
        readonly string dp4 = "f4";

        private void UpdateDisplay()
        {
            Text = "Weight Calibration [" + DispProg.Pump_Type.ToString() + "]";

            if (HeadToCal.Contains(TaskWeight.EHeadNo.One))
                btn_Head1.BackColor = Color.Lime;
            else
                btn_Head1.BackColor = this.BackColor;

            if (HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                btn_Head2.BackColor = Color.Lime;
            else
                btn_Head2.BackColor = this.BackColor;

            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    lbl_CurrentCalName.Text = "Density";
                    lbl_CurrentCalUnit.Text = "(" + TaskWeight.WEIGHT_UNIT + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    lbl_CurrentCalName.Text = "FlowRate";
                    lbl_CurrentCalUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    lbl_CurrentCalName.Text = "FlowRate";
                    lbl_CurrentCalUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
            }
            lbl_CurrentCal1.Text = TaskWeight.CurrentCal[0].ToString(dp4);
            lbl_CurrentCal2.Text = TaskWeight.CurrentCal[1].ToString(dp4);

            #region Target
            lbl_CalTarget.Text = TaskWeight.Cal_Meas_Weight.ToString(dp4);
            lbl_CalTargetRange.Text = (TaskWeight.Cal_Meas_Weight - TaskWeight.CalTol).ToString(dp4) + " ~ " + (TaskWeight.Cal_Meas_Weight + TaskWeight.CalTol).ToString(dp4);

            switch (TaskWeight.CalMeasType)
            {
                case TaskWeight.ECalMeasType.Density:
                    lbl_TargetName.Text = "Weight";
                    lbl_TargetUnit.Text = "(" + TaskWeight.WEIGHT_UNIT + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_s:
                    lbl_TargetName.Text = "FlowRate";
                    lbl_TargetUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
                case TaskWeight.ECalMeasType.FR_mg_dot:
                    lbl_TargetName.Text = "FlowRate";
                    lbl_TargetUnit.Text = "(" + TaskWeight.CalMeasUnit + ")";
                    break;
            }
            #endregion

            lbl_DotsPerSample.Text = (DispProg.DotsPerSample_Meas > 0 ? "P|" : "") + TaskWeight.iDotsPerSample(TaskWeight.EMeasType.Cal).ToString();
            lbl_OutputResult.Text = (DispProg.DotsPerSample_Meas > 0 ? "P|" : "") + TaskWeight.eOutputResult(TaskWeight.EMeasType.Cal).ToString();
        }

        bool bErr = false;
        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            lbl_Status.Text = TaskWeight.Cal_Status.ToString();

            if ((int)GDefine.WeightStType == 0)
            {
                lbl_WeightCurrentValue.Text = "------";
                return;
            }
            if (!TaskWeight.WeightIsOpen)
            {
                lbl_WeightCurrentValue.Text = "ERR";
                return;
            }

            tmr_WeightDisplay.Enabled = false;
            double d_mg = 0;

            if (bErr) return;
            bErr = !TaskWeight.WeightValue(ref d_mg);
            lbl_WeightCurrentValue.Text = d_mg.ToString(dp3);
            tmr_WeightDisplay.Enabled = true;

        }

        private void btn_Ctrl1_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.DispCtrlOpened(0)) return;
            TaskDisp.ShowDispCtrl(0);
        }
        private void btn_Ctrl2_Click(object sender, EventArgs e)
        {
            if (!TaskDisp.DispCtrlOpened(1)) return;
            TaskDisp.ShowDispCtrl(1);
        }
        private void btn_Tare_Click(object sender, EventArgs e)
        {
            TaskWeight.SoftZero();
        }
        public void AddHead(TaskWeight.EHeadNo Head)
        {
            if (!HeadToCal.Contains(Head))
            {
                HeadToCal.Add(Head);
                HeadToCal.Sort();
            }
        }
        public void RemoveHead(TaskWeight.EHeadNo Head)
        {
            HeadToCal.Remove(Head);
        }
        private void btn_Head1_Click(object sender, EventArgs e)
        {
            if (!HeadToCal.Contains(TaskWeight.EHeadNo.One))
                AddHead(TaskWeight.EHeadNo.One);
            else
                RemoveHead(TaskWeight.EHeadNo.One);

            UpdateDisplay();
        }
        private void btn_Head2_Click(object sender, EventArgs e)
        {
            if (!HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                AddHead(TaskWeight.EHeadNo.Two);
            else
                RemoveHead(TaskWeight.EHeadNo.Two);

            UpdateDisplay();
        }

        private void lbl_CalTarget_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Weight Cal, Target (mg)", ref TaskWeight.Cal_Meas_Weight, 0.001, 1000);
            UpdateDisplay();
        }
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            frm_DispCore_WeightSetting frm = new frm_DispCore_WeightSetting
            {
                TopMost = true
            };
            frm.BringToFront();
            frm.ShowDialog();

            UpdateDisplay();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (DispProg.Target_Weight > 0) TaskDisp.PP_SetWeight(DispProg.Disp_Weight, true, true);

            if (CalMode == ECalMode.Auto) DialogResult = DialogResult.Cancel;

            Close();
        }

        private bool CalStart()
        {
            lbl_Result1.BackColor = this.BackColor;
            lbl_Result1.Text = "-";
            lbl_Result2.BackColor = this.BackColor;
            lbl_Result2.Text = "-";

            lbox_Result.Items.Clear();

            if (HeadToCal.Count == 0) return true;

            if (DispProg.Head_Operation == TaskDisp.EHeadOperation.Single)
            {
                if (HeadToCal.Contains(TaskWeight.EHeadNo.Two))
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ErrCode.WEIGHT_PROG_HEAD_OP_SINGLE_SELECTED);
                    return false;
                }
            }

            foreach (TaskWeight.EHeadNo Head in HeadToCal)
            {
                #region Check Ready
                if (Head == TaskWeight.EHeadNo.One)
                    if (!TaskDisp.CtrlCheckReady(true, false))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL1_NOT_READY);
                        return false;
                    }
                if (Head == TaskWeight.EHeadNo.Two)
                    if (!TaskDisp.CtrlCheckReady(false, true))
                    {
                        Msg MsgBox = new Msg();
                        MsgBox.Show(ErrCode.DISPCTRL2_NOT_READY);
                        return false;
                    }
                #endregion

                this.Enable(false);
                try
                {
                    TaskWeight.WeightCal_Reset();

                    bool Res = TaskWeight.WeightCal_Execute(TaskWeight.Cal_Meas_Weight, lbox_Result, (int)Head + 1);

                    if (Res)
                    {
                        TaskWeight.Cal_Status = TaskWeight.EWeightCalStatus.Calibrated;

                        if (Head == TaskWeight.EHeadNo.One)
                        {
                            lbl_Result1.BackColor = Color.Lime;
                            lbl_Result1.Text = "Pass";
                        }
                        if (Head == TaskWeight.EHeadNo.Two)
                        {
                            lbl_Result2.BackColor = Color.Lime;
                            lbl_Result2.Text = "Pass";
                        }
                    }
                    else
                    {
                        if (Head == TaskWeight.EHeadNo.One)
                        {
                            lbl_Result1.BackColor = Color.Red;
                            lbl_Result1.Text = "Fail";
                        }
                        if (Head == TaskWeight.EHeadNo.Two)
                        {
                            lbl_Result2.BackColor = Color.Red;
                            lbl_Result2.Text = "Fail";
                        }
                        if (CalMode == ECalMode.Auto) DialogResult = DialogResult.Cancel;
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    this.Enable(true);
                }
            }

            UpdateDisplay();
            if (CalMode == ECalMode.Auto) DialogResult = DialogResult.OK;

            return true;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;
            DefineSafety.DoorLock = true;

            if (HeadToCal.Count == 0)
            {
                Msg MsgBox = new Msg();
                EMsgRes MsgRes = MsgBox.Show("No Head is selected.", EMcState.Notice, EMsgBtn.smbOK, false);
            }

            CalStart();
            
            Event.OP_WEIGHT_CALIBRATION.Set();

            DefineSafety.DoorLock = false;

            UpdateDisplay();
        }

        private void tmr_Start_Tick(object sender, EventArgs e) 
        {
            if (CalMode == ECalMode.Auto)
            {
                tmr_Start.Enabled = false;
             
                if (!File.Exists(GDefine.AppPath + "\\WeightEmulate.txt")) CalStart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskWeight.Cal_Status = TaskWeight.EWeightCalStatus.Calibrated;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
