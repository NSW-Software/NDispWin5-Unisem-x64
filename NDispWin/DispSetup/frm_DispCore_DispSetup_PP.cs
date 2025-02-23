using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace NDispWin
{
    public partial class frm_DispCore_DispSetup_PP : Form
    {
        public frm_DispCore_DispSetup_PP()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frm_DispCore_DispSetup_PP_Load(object sender, EventArgs e)
        {
            b_HeadB = TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync;
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }

        private void frm_DispCore_DispSetup_PP_Shown(object sender, EventArgs e)
        {
        }


        private void frm_DispCore_DispSetup_PP_VisibleChanged(object sender, EventArgs e)
        {
            UpdateDisplay_CtrlMode();
            AppLanguage.Func2.UpdateText(this);
            //AppLanguage.Func.SetComponent(this);
        }

        private void EnableControls(bool Enable, Button Button1, Button Button2)
        {
            try
            {
                if (this.ParentForm != null) this.ParentForm.Enabled = Enable;
                //if (this.ParentForm.ParentForm != null) this.ParentForm.ParentForm.Enabled = Enable;
                //if (this.ParentForm.ParentForm.ParentForm != null) this.ParentForm.ParentForm.ParentForm.Enabled = Enable;
            }
            catch { };//if (this.Parent.Parent.Parent != null) this.Parent.Parent.Parent.Enabled = Enable;

            for (int i = 0; i <= Controls.Count - 1; i++)
            {
                if (Controls[i] is Button)
                {
                    (Controls[i] as Button).Enabled = Enable;
                }

                if (Controls[i] is GroupBox || Controls[i] is Panel || Controls[i] is TabControl)
                {
                    for (int j = 0; j <= Controls[i].Controls.Count - 1; j++)
                    {
                        if (Controls[i].Controls[j] is TabPage)
                        {
                            for (int k = 0; k <= Controls[i].Controls[j].Controls.Count - 1; k++)
                            {
                                if (Controls[i].Controls[j].Controls[k] is Button)
                                {
                                    (Controls[i].Controls[j].Controls[k] as Button).Enabled = Enable;
                                }
                            }
                        }

                        if (Controls[i].Controls[j] is Button)
                        {
                            (Controls[i].Controls[j] as Button).Enabled = Enable;
                        }
                        if (Controls[i].Controls[j] is Label)
                        {
                            (Controls[i].Controls[j] as Label).Enabled = Enable;
                        }
                    }
                }
            }
            Button1.Enabled = true;
            Button2.Enabled = true;
        }
        private void EnableControls()
        {
            EnableControls(true, btn_Dummy, btn_Dummy);
        }

        bool b_HeadA = true;
        bool b_HeadB = false;
        int CleanFillCounter = -1;
        int PurgeShotCounter = -1;
        double BarrelPressStartTime = -1;
        int RecycleBarrelCounter = -1;
        double RemoveAirStartTime = -1;

        enum ECtrlMode { Timed, Purge };
        ECtrlMode CtrlMode_HeadA = ECtrlMode.Timed;
        ECtrlMode CtrlMode_HeadB = ECtrlMode.Timed;
        private void UpdateDisplay_CtrlMode()
        {
            bool b_PurgeModeA = false;
            bool b_PurgeModeB = false;
            TaskDisp.GetDispCtrlMode(true, true, ref b_PurgeModeA, ref b_PurgeModeB);
            if (b_PurgeModeA) CtrlMode_HeadA = ECtrlMode.Purge;
            else
                CtrlMode_HeadA = ECtrlMode.Timed;
            if (b_PurgeModeB) CtrlMode_HeadB = ECtrlMode.Purge;
            else
                CtrlMode_HeadB = ECtrlMode.Timed;
        }

        private void UpdateDisplay()
        {
            UI_Utils.SetControlSelected(btn_HeadA, b_HeadA && !(b_HeadA && b_HeadB));
            UI_Utils.SetControlSelected(btn_HeadB, b_HeadB && !(b_HeadA && b_HeadB));
            UI_Utils.SetControlSelected(btn_HeadAB, b_HeadA && b_HeadB);

            if (CtrlMode_HeadA == ECtrlMode.Timed) btn_ModeA.BackColor = Color.AntiqueWhite; else btn_ModeA.BackColor = Color.Orange;
            if (CtrlMode_HeadB == ECtrlMode.Timed) btn_ModeB.BackColor = Color.AntiqueWhite; else btn_ModeB.BackColor = Color.Orange;

            string S = "";

            S = TaskDisp.DispTool_CleanFillCount.ToString();
            if (CleanFillCounter >= 0)
                S = CleanFillCounter.ToString() + "/" + TaskDisp.DispTool_CleanFillCount.ToString();
            lbl_CleanFillCount.Text = S + " Count";

            S = TaskDisp.DispTool_PurgeShotCount.ToString();
            if (PurgeShotCounter >= 0)
                S = PurgeShotCounter.ToString() + "/" + TaskDisp.DispTool_PurgeShotCount.ToString();
            lbl_PurgeShotCount.Text = S + " Count";

            S = TaskDisp.DispTool_BarrelPressTime.ToString("f1");
            if (BarrelPressStartTime > 0)
                S = (Math.Round((GDefine.GetTickCount() - BarrelPressStartTime) / 1000, 1)).ToString("f1") + "/" + TaskDisp.DispTool_BarrelPressTime.ToString("f1");
            lbl_BarrelPressTime.Text = S + " s";

            S = TaskDisp.DispTool_RecycleBarrelCount.ToString();
            if (RecycleBarrelCounter >= 0)
                S = RecycleBarrelCounter.ToString() + "/" + TaskDisp.DispTool_RecycleBarrelCount.ToString();
            lbl_RecycleBarrelCount.Text = S + " Count";
            btn_RecycleMethod.Text = Enum.GetName(typeof(TaskDisp.ERecycleMethod), (int)RecycleMethod).ToString();

            S = TaskDisp.DispTool_RemoveAirTime.ToString("f2");
            if (RemoveAirStartTime > 0)
                S = (Math.Round((GDefine.GetTickCount() - RemoveAirStartTime) / 1000, 1)).ToString("f2") + "/" + TaskDisp.DispTool_RemoveAirTime.ToString("f2");
            lbl_RemoveAirTime.Text = S + " s";

            S = TaskDisp.DispTool_RecycleNeedleCount.ToString();
            lbl_RecycleNeedleCount.Text = S + " Count";

            btn_Func1.Visible = TaskDispCtrl.DispFuncs.Group[0].SeqCount > 0;
            btn_Func1.Text = TaskDispCtrl.DispFuncs.Group[0].Name;
            btn_Func2.Visible = TaskDispCtrl.DispFuncs.Group[1].SeqCount > 0;
            btn_Func2.Text = TaskDispCtrl.DispFuncs.Group[1].Name;
            btn_Func3.Visible = TaskDispCtrl.DispFuncs.Group[2].SeqCount > 0;
            btn_Func3.Text = TaskDispCtrl.DispFuncs.Group[2].Name;
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;

            UpdateDisplay();
        }

        private void btn_HeadA_Click(object sender, EventArgs e)
        {
            b_HeadA = true;
            b_HeadB = false;

            UpdateDisplay();
        }

        private void btn_HeadB_Click(object sender, EventArgs e)
        {
            b_HeadA = false;
            b_HeadB = true;

            UpdateDisplay();
        }

        private void btn_HeadAB_Click(object sender, EventArgs e)
        {
            b_HeadA = true;
            b_HeadB = true;

            UpdateDisplay();
        }

        private void btn_Init_Click(object sender, EventArgs e)
        {
            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.DoInitPP(b_HeadA, b_HeadB)) goto _End;
            Thread.Sleep(50);
            TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB);

            _End:
            frm.Close();
            EnableControls();
            //EnableControls(false, btn_Dummy, btn_Dummy);

            //MsgBox.Processing("Init in progress", () =>
            //{
            //    if (!TaskDisp.DoInitPP(b_HeadA, b_HeadB)) return;
            //    Thread.Sleep(50);
            //    TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB);
            //});

            //EnableControls();
        }

        private void btn_Fill_Click(object sender, EventArgs e)
        {
            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.CtrlCheckReady(b_HeadA, b_HeadB)) goto _End;
            if (!TaskDisp.DoFill(b_HeadA, b_HeadB)) goto _End;
            Thread.Sleep(10);
            TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB);
            _End:
            frm.Close();
            EnableControls();
            //EnableControls(false, btn_Dummy, btn_Dummy);

            //MsgBox.Processing("Filling in progress", () =>
            //{
            //    if (!TaskDisp.CtrlCheckReady(b_HeadA, b_HeadB)) return;
            //    if (!TaskDisp.DoFill(b_HeadA, b_HeadB)) return;
            //    Thread.Sleep(10);
            //    TaskDisp.CtrlWaitReady(b_HeadA, b_HeadB);
            //});
            //EnableControls();
        }

        private void lbl_RemoveAirTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Remove Air Time (ms)", ref TaskDisp.DispTool_RemoveAirTime, 0.01, 30);
            UpdateDisplay();
        }
        private void btn_RemoveAirTimed_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            if (!TaskDisp.RemoveAirOn(b_HeadA, b_HeadB)) goto _End;

            RemoveAirStartTime = GDefine.GetTickCount();
            while (GDefine.GetTickCount() <= RemoveAirStartTime + TaskDisp.DispTool_RemoveAirTime * 1000)
            {
                if (frm.Cancel) break;
                Thread.Sleep(5);
            }
            RemoveAirStartTime = 0;

            if (!TaskDisp.RemoveAirOff(b_HeadA, b_HeadB)) goto _End;
            RemoveAirStartTime = -1;
            _End:
            frm.Close();
            RemoveAirStartTime = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }


        bool b_MouseDn = false;
        bool b_RemoveAirBusy = false;
        private async void btn_RemoveAir_MouseDown(object sender, MouseEventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            //b_MouseDn = true;
            //if (b_RemoveAirBusy) return;

            //if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
            //if (!TaskDisp.TaskGotoPMaint()) goto _End;

            //b_RemoveAirBusy = true;
            //if (!TaskDisp.RemoveAirOn(b_HeadA, b_HeadB)) goto _End;

            //while (b_MouseDn)
            //{
            //    Thread.Sleep(5);
            //    //break;
            //}

            //if (!TaskDisp.RemoveAirOff(b_HeadA, b_HeadB)) goto _End;
            //_End:
            //TaskDisp.TaskMoveGZZ2Up();
            //b_RemoveAirBusy = false;

            bool[] bRemoveAirHead = new bool[] { b_HeadA, b_HeadB };

            b_MouseDn = true;
            if (b_RemoveAirBusy) return;

            await Task.Run(() =>
            {

                try
                {
                    if (!TaskDisp.TaskMoveGZUp()) return;
                    if (!TaskDisp.TaskGotoPMaint()) return;

                    b_RemoveAirBusy = true;
                    if (!TaskDisp.RemoveAirOn(bRemoveAirHead[0], bRemoveAirHead[1])) return;

                    while (b_MouseDn)
                    {
                        Thread.Sleep(5);
                    }

                    //_End:
                    //TaskDisp.TaskMoveGZZ2Up();
                    //b_RemoveAirBusy = false;
                    if (!TaskDisp.RemoveAirOff(bRemoveAirHead[0], bRemoveAirHead[1])) return;
                }
                finally
                {
                    TaskDisp.TaskMoveGZUp();
                    b_RemoveAirBusy = false;
                }
            });
        }
        private void btn_RemoveAir_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
            btn_Dummy.Focus();
        }
        private void btn_RemoveAir_MouseLeave(object sender, EventArgs e)
        {
            b_MouseDn = false;
        }
        private void btn_RemoveAir_Click(object sender, EventArgs e)
        {

        }

        private void lbl_BarrelPressTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Barrel Pressure Time (ms)", ref TaskDisp.DispTool_BarrelPressTime, 0, 60);
            UpdateDisplay();
        }
        private void btn_BarrelPres_Click(object sender, EventArgs e)
        {

        }

        bool b_BarrelPressBusy = false;
        private async void btn_BarrelPress_MouseDown(object sender, MouseEventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            bool[] bRemoveAirHead = new bool[] { b_HeadA, b_HeadB };

            //    b_MouseDn = true;
            //    if (b_BarrelPressBusy) return;

            //    if (!TaskDisp.TaskMoveGZZ2Up()) goto _End;
            //    if (!TaskDisp.TaskGotoPMaint()) goto _End;

            //    b_BarrelPressBusy = true;
            //    if (!TaskDisp.BarrelPressOn(b_HeadA, b_HeadB)) goto _End;

            //    while (b_MouseDn)
            //    {
            //        Thread.Sleep(5);
            //    }

            //    if (!TaskDisp.BarrelPressOff(b_HeadA, b_HeadB)) goto _End;
            //_End:
            //    TaskDisp.TaskMoveGZZ2Up();
            //    b_BarrelPressBusy = false;


            if (b_BarrelPressBusy) return;
            await Task.Run(() =>
            {
                try
                {
                    b_MouseDn = true;

                    if (!TaskDisp.TaskMoveGZUp()) return;
                    if (!TaskDisp.TaskGotoPMaint()) return;

                    b_BarrelPressBusy = true;
                    if (!TaskDisp.BarrelPressOn(bRemoveAirHead[0], bRemoveAirHead[1])) return;

                    while (b_MouseDn)
                    {
                        Thread.Sleep(5);
                    }

                    if (!TaskDisp.BarrelPressOff(bRemoveAirHead[0], bRemoveAirHead[1])) return;
                }
                finally
                {
                    TaskDisp.TaskMoveGZUp();
                    b_BarrelPressBusy = false;
                }
            });
        }
        private void btn_BarrelPress_MouseUp(object sender, MouseEventArgs e)
        {
            b_MouseDn = false;
            btn_Dummy.Focus();
        }
        private void btn_BarrelPress_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            if (b_RemoveAirBusy) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            if (!TaskDisp.BarrelPressOn(b_HeadA, b_HeadB)) goto _End;

            BarrelPressStartTime = GDefine.GetTickCount();
            while (GDefine.GetTickCount() <= BarrelPressStartTime + TaskDisp.DispTool_BarrelPressTime * 1000)
            {
                if (frm.Cancel) break;

                //Application.DoEvents();
                Thread.Sleep(5);
            }

            BarrelPressStartTime = 0;

            if (!TaskDisp.BarrelPressOff(b_HeadA, b_HeadB)) goto _End;
            _End:
            frm.Close();
            BarrelPressStartTime = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }
        private void btn_BarrelPress_MouseLeave(object sender, EventArgs e)
        {
            b_MouseDn = false;
        }

        private void lbl_RecycleBarrelCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Recycle Barrel Count", ref TaskDisp.DispTool_RecycleBarrelCount, 1, 60);
            UpdateDisplay();
        }
        TaskDisp.ERecycleMethod RecycleMethod = TaskDisp.ERecycleMethod.Full;
        private void btn_RecycleBarrel_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            RecycleBarrelCounter = 0;

            //if (!TaskDisp.HPCCheckReady(b_HeadA, b_HeadB)) goto _End;

            while (RecycleBarrelCounter < TaskDisp.DispTool_RecycleBarrelCount)
            {
                if (frm.Cancel) break;

                RecycleBarrelCounter++;
                UpdateDisplay();

                //if (!RecycleBarrel(RecycleMethod)) goto _End;
                if (!TaskDisp.RecycleBarrel(b_HeadA, b_HeadB, RecycleMethod)) goto _End;
            }
            RecycleBarrelCounter = -1;

            _End:
            frm.Close();
            RecycleBarrelCounter = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }
        private void btn_RecycleMethod_Click(object sender, EventArgs e)
        {
            if (RecycleMethod < (TaskDisp.ERecycleMethod)Enum.GetNames(typeof(TaskDisp.ERecycleMethod)).Length - 1)
                RecycleMethod++;
            else
                RecycleMethod = (TaskDisp.ERecycleMethod)0;
            UpdateDisplay();
        }

        private void lbl_CleanFillCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Clean Fill Count", ref TaskDisp.DispTool_CleanFillCount, 1, 20);
            UpdateDisplay();
        }
        private void btn_CleanFill_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            CleanFillCounter = 0;

            while (CleanFillCounter < TaskDisp.DispTool_CleanFillCount)
            {
                if (frm.Cancel) break;

                CleanFillCounter++;
                UpdateDisplay();
                if (!TaskDisp.CleanFill(b_HeadA, b_HeadB)) goto _End;
            }
            CleanFillCounter = -1;

            _End:
            frm.Close();
            CleanFillCounter = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }

        private void lbl_PurgeShotCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Purge Shot Count", ref TaskDisp.DispTool_PurgeShotCount, 1, 20);
            UpdateDisplay();
        }
        private void btn_Purge_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            PurgeShotCounter = 0;

            while (PurgeShotCounter < TaskDisp.DispTool_PurgeShotCount)
            {
                if (frm.Cancel) break;

                PurgeShotCounter++;
                UpdateDisplay();

                TaskDisp.FPressOn(new bool[2] { true, TaskDisp.Head_Operation == TaskDisp.EHeadOperation.Sync });
                try
                {
                    if (!TaskDisp.TaskPurgeCleanNeedle(false, TaskDisp.Needle_Maint_Pos, b_HeadA, b_HeadB, false, true, false, TaskDisp.Needle_Purge_Time, TaskDisp.Needle_Purge_Wait, 1, TaskDisp.Needle_Purge_PostVacTime)) goto _End;
                }
                finally
                {
                    TaskDisp.FPressOff();
                }
            }
            PurgeShotCounter = -1;

            _End:
            frm.Close();
            PurgeShotCounter = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }
        private void btn_Shot_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            PurgeShotCounter = 0;

            while (PurgeShotCounter < TaskDisp.DispTool_PurgeShotCount)
            {
                if (frm.Cancel) break;

                PurgeShotCounter++;
                UpdateDisplay();

                if (!TaskDisp.TaskShotNeedle(TaskDisp.Needle_Maint_Pos, b_HeadA, b_HeadB, 500, 1)) goto _End;

                //Application.DoEvents();
            }
            PurgeShotCounter = -1;

        _End:
            frm.Close();
            PurgeShotCounter = -1;
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }
        private void lbl_RecycleNeedleCount_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("PP Recycle Needle Count", ref TaskDisp.DispTool_RecycleNeedleCount, 1, 60);
            UpdateDisplay();
        }
        private void btn_RecycleNeedle_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            
            EnableControls(false, btn_Dummy, btn_Dummy);

            frm_DispCore_Progress frm = new frm_DispCore_Progress();
            frm.Show();

            if (!TaskDisp.TaskMoveGZUp()) goto _End;
            if (!TaskDisp.TaskGotoPMaint()) goto _End;

            if (!TaskDisp.RecycleNeedle(b_HeadA, b_HeadB, TaskDisp.DispTool_RecycleNeedleCount)) goto _End;

        _End:
            frm.Close();
            TaskDisp.TaskMoveGZUp();
            EnableControls();
        }

        private void btn_Func1_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            if (!TaskDispCtrl.DispFuncs.Group[0].Execute(b_HeadA, b_HeadB)) goto _End;
        _End:
            //TaskDisp.TaskMoveGZZ2Up();
            EnableControls();
        }

        private void btn_Func2_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            if (!TaskDispCtrl.DispFuncs.Group[1].Execute(b_HeadA, b_HeadB)) goto _End;
        _End:
            //TaskDisp.TaskMoveGZZ2Up();
            EnableControls();
        }

        private void btn_Func3_Click(object sender, EventArgs e)
        {
            if (!TaskGantry.CheckDoorSw()) return;

            EnableControls(false, btn_Dummy, btn_Dummy);

            if (!TaskDispCtrl.DispFuncs.Group[2].Execute(b_HeadA, b_HeadB)) goto _End;
        _End:
            //TaskDisp.TaskMoveGZZ2Up();
            EnableControls();
        }

        private void btn_ModeA_Click(object sender, EventArgs e)
        {
            if (CtrlMode_HeadA == ECtrlMode.Timed) 
                TaskDisp.SetDispCtrlPurgeMode(true, false);
            else
                TaskDisp.SetDispCtrlTimedMode(true, false);

            UpdateDisplay_CtrlMode();
        }
        private void btn_ModeB_Click(object sender, EventArgs e)
        {
            if (CtrlMode_HeadB == ECtrlMode.Timed)
                TaskDisp.SetDispCtrlPurgeMode(false, true);
            else
                TaskDisp.SetDispCtrlTimedMode(false, true);

            UpdateDisplay_CtrlMode();
        }

        private void btn_TrigA_Click(object sender, EventArgs e)
        {

        }
        private void btn_TrigA_MouseDown(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(true, false);
        }
        private void btn_TrigA_MouseUp(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOff(true, false);
        }

        private void btn_TrigB_Click(object sender, EventArgs e)
        {
        }
        private void btn_TrigB_MouseDown(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOn(false, true);
        }
        private void btn_TrigB_MouseUp(object sender, MouseEventArgs e)
        {
            TaskDisp.TrigOff(false, true);
        }
    }
}
