using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace NDispWin
{
    public partial class frm_MHS2ElevCtrl : Form
    {
        public frm_MHS2ElevCtrl()
        {
            InitializeComponent();
            GControl.LogForm(this);

            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_ElevCtrl_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);
        }

        private void UpdateDisplay()
        {
            gbox_Left.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ;
            gbox_Right.Visible = TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ;
            //pnl_LeftElev.Visible = TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ;
            //pnl_RightElev.Visible = TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ;

            lbl_LMagNo.Text = TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntMagz.ToString();
            lbl_LLvlNo.Text = TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntLevel.ToString();

            lbl_RMagNo.Text = TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntMagz.ToString();
            lbl_RLvlNo.Text = TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntLevel.ToString();

            lbl_LeftElevSt.Text = TaskElev.Left.Status.ToString() + (TaskElev.Left.TransferBusy?" (B)":"");
            lbl_LeftElevSt.BackColor = TaskElev.ElevStatusColor[(int)TaskElev.Left.Status];
            lbl_RightElevSt.Text = TaskElev.Right.Status.ToString() + (TaskElev.Right.TransferBusy ? " (B)" : "");
            lbl_RightElevSt.BackColor = TaskElev.ElevStatusColor[(int)TaskElev.Right.Status];
        }

        private void EnableParent(bool Enable)
        {
            Enabled = Enable;
            try
            {
                if (Parent != null) { Parent.Enabled = Enable; }
                if (Parent.Parent != null) { Parent.Parent.Enabled = Enable; }
                if (Parent.Parent.Parent != null) { Parent.Parent.Parent.Enabled = Enable; }
                if (Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Enabled = Enable; }
                if (Parent.Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Parent.Enabled = Enable; }
                if (Parent.Parent.Parent.Parent.Parent.Parent != null) { Parent.Parent.Parent.Parent.Parent.Parent.Enabled = Enable; }
            }
            catch (NullReferenceException)
            {
                //Do Nothing      
            }
        }
        public bool Enable
        {
            set
            {
                if (value)
                {
                    this.Enable(true);
                }
                else
                {
                    this.Enable(false);
                    btn_LMagzReset.Enable(true);
                    btn_LMagzResetConfirm.Enable(true);
                    btn_RMagzReset.Enable(true);
                    btn_RMagzResetConfirm.Enable(true);
                }
            }
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }

            UpdateDisplay();

            if (TaskConv.LeftMode == TaskConv.ELeftMode.ManualLoad)
            {
            }
            if (TaskConv.LeftMode == TaskConv.ELeftMode.ElevatorZ)
            {
                if (TaskConv.OutLevelQtyFollowIn)
                    gbox_Left.Text = TaskElev.Left.b_MagChanged ? "Left (Next Mag)" : "Left (Same Mag)";
                else
                    gbox_Left.Text = "Left";

                #region Left Elevator Reset
                if (TaskElev.Left.WaitMagChange)
                {
                    if (btn_LMagzReset.BackColor != Color.Orange)
                    {
                        btn_LMagzReset.BackColor = Color.Orange;
                    }
                    else
                    {
                        btn_LMagzReset.BackColor = Color.Red;
                    }
                }
                else
                {
                    btn_LMagzReset.BackColor = this.BackColor;
                }
                #endregion
                #region Mag Psnt
                Color Color1 = this.BackColor;
                if (TaskElev.Left.SensMagPsnt(1)) Color1 = Color.Lime;
                Color Color2 = this.BackColor;
                if (TaskElev.Left.SensMagPsnt(2)) Color2 = Color.Lime;
                Color Color3 = this.BackColor;
                if (TaskElev.Left.SensMagPsnt(3)) Color3 = Color.Lime;
                Color Color4 = this.BackColor;
                if (TaskElev.Left.SensMagPsnt(4)) Color4 = Color.Lime;

                lbl_LMagHighest_Psnt.BackColor = Color4;
                lbl_LMagHigh_Psnt.BackColor = Color3;
                lbl_LMagLow_Psnt.BackColor = Color2;
                lbl_LMagLowest_Psnt.BackColor = Color1;
                #endregion
            }
            if ((TaskConv.RightMode == TaskConv.ERightMode.ProductReturn) || (TaskConv.RightMode == TaskConv.ERightMode.ManualUnload))
            {
            }
            if (TaskConv.RightMode == TaskConv.ERightMode.ElevatorZ)
            {
                #region Right Elevator Reset
                if (TaskElev.Right.WaitMagChange)
                {
                    if (btn_RMagzReset.BackColor != Color.Orange)
                    {
                        btn_RMagzReset.BackColor = Color.Orange;
                    }
                    else
                    {
                        btn_RMagzReset.BackColor = Color.Red;
                    }
                }
                else
                {
                    btn_RMagzReset.BackColor = this.BackColor;
                }
                #endregion
                #region Mag Psnt
                Color Color1 = this.BackColor;
                if (TaskElev.Right.SensMagPsnt(1)) Color1 = Color.Lime;
                Color Color2 = this.BackColor;
                if (TaskElev.Right.SensMagPsnt(2)) Color2 = Color.Lime;
                Color Color3 = this.BackColor;
                if (TaskElev.Right.SensMagPsnt(3)) Color3 = Color.Lime;
                Color Color4 = this.BackColor;
                if (TaskElev.Right.SensMagPsnt(4)) Color4 = Color.Lime;

                lbl_RMagHighest_Psnt.BackColor = Color4;
                lbl_RMagHigh_Psnt.BackColor = Color3;
                lbl_RMagLow_Psnt.BackColor = Color2;
                lbl_RMagLowest_Psnt.BackColor = Color1;
                #endregion
            }
        }

        private void btn_LMagzReset_Click(object sender, EventArgs e)
        {
            btn_LMagzResetConfirm.Visible = !btn_LMagzResetConfirm.Visible;
        }
        private void btn_LMagzResetConfirm_Click(object sender, EventArgs e)
        {
            Event.LEFT_ELEV_RESET.Set();
            TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntLevel = 0;
            TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntMagz = 0;

            TaskElev.Left.WaitMagChange = false;
            TaskElev.Left.ReadyToSend = false;

            if (TaskConv.OutLevelQtyFollowIn)
            {
                TaskElev.Right.WaitMagChange = true;
                TaskElev.Left.b_MagChanged = false;
            }

            btn_LMagzResetConfirm.Visible = false;
        }

        private void btn_RMagzReset_Click(object sender, EventArgs e)
        {
            btn_RMagzResetConfirm.Visible = !btn_RMagzResetConfirm.Visible;
        }
        private void btn_RMagzResetConfirm_Click(object sender, EventArgs e)
        {
            Event.RIGHT_ELEV_RESET.Set();
            TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntLevel = 0;
            TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntMagz = 0;

            TaskElev.Right.WaitMagChange = false;
            TaskElev.Right.ReadyToReceive = false;
            btn_RMagzResetConfirm.Visible = false;
        }

        private async void lbl_LMagNo_Click(object sender, EventArgs e)
        {
            int i_Mag = TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntMagz;
            int i_Lvl = TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntLevel;

            int Max = TaskElev.Setups[(int)TaskElev.TElevator.Left].MagCount;
            if (UC.AdjustExec("Manual, LeftMagNo", ref i_Mag, 1, Max))
            {
                EnableParent(false);

                await Task.Run(() =>
                {
                    if (!TaskElev.Left.DoorIsClosed(true)) goto _End;
                    TaskElev.Left.MoveLevel(i_Mag, i_Lvl);
                    int EIdx = (int)TaskElev.TElevator.Left;
                    if (TaskElev.Left.SensMagNoPsnt(TaskElev.Setups[EIdx].PsntMagz))
                    {
                        TaskElev.Left.ReadyToSend = true;
                    }

                    _End:;
                });

                EnableParent(true);
            }
        }
        private async void lbl_LLvlNo_Click(object sender, EventArgs e)
        {
            int i_Mag = Math.Max(1, TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntMagz);
            int i_Lvl = TaskElev.Setups[(int)TaskElev.TElevator.Left].PsntLevel;

            int Max = TaskElev.Setups[(int)TaskElev.TElevator.Left].MagLevelCount[i_Mag];
            if (UC.AdjustExec("Manual, LeftLevelNo", ref i_Lvl, 1, Max))
            {
                EnableParent(false);

                await Task.Run(() =>
                {
                    if (!TaskElev.Left.DoorIsClosed(true)) goto _End;
                    TaskElev.Left.MoveLevel(i_Mag, i_Lvl);
                    int EIdx = (int)TaskElev.TElevator.Left;
                    if (TaskElev.Left.SensMagNoPsnt(TaskElev.Setups[EIdx].PsntMagz))
                    {
                        TaskElev.Left.ReadyToSend = true;
                    }

                    _End:;
                });
                EnableParent(true);
            }
        }
        private async void btn_LLevelUp_Click(object sender, EventArgs e)
        {
            if (!btn_LLevelUp.Enabled) return;

            EnableParent(false);

            await Task.Run(() =>
            {
                if (!TaskElev.Left.Ready) { goto _Error; }
                if (!TaskElev.Left.SafetyCheck_ElevMove()) { goto _Error; }
                TaskElev.Left.UpLevel();
                _Error:;
            });
            EnableParent(true);
            UpdateDisplay();
        }
        private async void btn_LLevelDn_Click(object sender, EventArgs e)
        {
            if (!btn_LLevelDn.Enabled) return;

            EnableParent(false);

            await Task.Run(() =>
            {
                if (!TaskElev.Left.Ready) { goto _Error; }
                if (!TaskElev.Left.SafetyCheck_ElevMove()) { goto _Error; }

                TaskElev.Left.DnLevel();
                _Error:;
            });
            EnableParent(true);
            UpdateDisplay();
        }

        private async void lbl_RMagNo_Click(object sender, EventArgs e)
        {
            int i_Mag = TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntMagz;
            int i_Lvl = TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntLevel;

            int Max = TaskElev.Setups[(int)TaskElev.TElevator.Right].MagCount;
            if (UC.AdjustExec("Manual, RightMagNo", ref i_Mag, 1, Max))
            {
                EnableParent(false);

                await Task.Run(() =>
                {
                    if (!TaskElev.Right.DoorIsClosed(true)) goto _End;
                    TaskElev.Right.MoveLevel(i_Mag, i_Lvl);
                    int EIdx = (int)TaskElev.TElevator.Right;
                    if (TaskElev.Right.SensMagNoPsnt(TaskElev.Setups[EIdx].PsntMagz))
                    {
                        TaskElev.Right.ReadyToReceive = true;
                    }
                    _End:;
                });
                EnableParent(true);
            }
        }
        private async void lbl_RLvlNo_Click(object sender, EventArgs e)
        {
            int i_Mag = Math.Max(1, TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntMagz);
            int i_Lvl = TaskElev.Setups[(int)TaskElev.TElevator.Right].PsntLevel;

            int Max = TaskElev.Setups[(int)TaskElev.TElevator.Right].MagLevelCount[i_Mag];
            if (UC.AdjustExec("Manual, RightLevelNo", ref i_Lvl, 1, Max))
            {
                EnableParent(false);

                await Task.Run(() =>
                {
                    if (!TaskElev.Right.DoorIsClosed(true)) goto _End;
                    TaskElev.Right.MoveLevel(i_Mag, i_Lvl);
                    int EIdx = (int)TaskElev.TElevator.Right;
                    if (TaskElev.Right.SensMagNoPsnt(TaskElev.Setups[EIdx].PsntMagz))
                    {
                        TaskElev.Right.ReadyToReceive = true;
                    }
                    _End:;
                });
                EnableParent(true);
            }
        }
        private async void btn_RLevelUp_Click(object sender, EventArgs e)
        {
            if (!btn_RLevelUp.Enabled) return;

            EnableParent(false);

            await Task.Run(() =>
            {
                if (!TaskElev.Right.Ready) { goto _Error; }
                if (!TaskElev.Right.SafeCheck_ElevMove()) { goto _Error; }
                TaskElev.Right.MoveUpLevel();
                _Error:;
            });
            EnableParent(true);
            UpdateDisplay();
        }
        private async void btn_RLevelDn_Click(object sender, EventArgs e)
        {
            if (!btn_RLevelDn.Enabled) return;

            EnableParent(false);

            await Task.Run(() =>
            {
                if (!TaskElev.Right.Ready) { goto _Error; }
                if (!TaskElev.Right.SafeCheck_ElevMove()) { goto _Error; }
                TaskElev.Right.MoveDnLevel();
                _Error:;
            });
            EnableParent(true);
            UpdateDisplay();
        }
    }
}
