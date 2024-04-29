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
    internal partial class frmMotorDiag : Form
    {
        enum EAxis { GX, GY, GZ, GX2, GY2, GZ2}
        EAxis SelectedAxis = EAxis.GX;

        public frmMotorDiag()
        {
            InitializeComponent();
            GControl.LogForm(this);

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void UpdateDisplay()
        {
            switch (GDefine.GantryConfig)
            {
                case GDefine.EGantryConfig.XY_ZX2Y2_Z2:
                    pnl_GX2.Visible = true;
                    pnl_GY2.Visible = true;
                    pnl_GZ2.Visible = true;
                    break;
            }

            btn_GXAxis.BackColor = SystemColors.Control;
            btn_GYAxis.BackColor = SystemColors.Control;
            btn_GZAxis.BackColor = SystemColors.Control;
            btn_GX2Axis.BackColor = SystemColors.Control;
            btn_GY2Axis.BackColor = SystemColors.Control;
            btn_GZ2Axis.BackColor = SystemColors.Control;
            switch (SelectedAxis)
            {
                case EAxis.GX: btn_GXAxis.BackColor = Color.Lime; break;
                case EAxis.GY: btn_GYAxis.BackColor = Color.Lime;  break;
                case EAxis.GZ: btn_GZAxis.BackColor = Color.Lime;  break;
                case EAxis.GX2: btn_GX2Axis.BackColor = Color.Lime; break;
                case EAxis.GY2: btn_GY2Axis.BackColor = Color.Lime; break;
                case EAxis.GZ2: btn_GZ2Axis.BackColor = Color.Lime; break;
            }

            GDefine.UpdateInfo(lbl_GXInfo, TaskGantry.GXAxis);
            GDefine.UpdateInfo(lbl_GYInfo, TaskGantry.GYAxis);
            GDefine.UpdateInfo(lbl_GZInfo, TaskGantry.GZAxis);
            GDefine.UpdateInfo(lbl_GX2AxisInfo, TaskGantry.GX2Axis);
            GDefine.UpdateInfo(lbl_GY2AxisInfo, TaskGantry.GY2Axis);
            GDefine.UpdateInfo(lbl_GZ2AxisInfo, TaskGantry.GZ2Axis);

            #region Display
            CControl2.TInput Home = new CControl2.TInput();
            CControl2.TInput LmtP = new CControl2.TInput();
            CControl2.TInput LmtN = new CControl2.TInput();
            CControl2.TInput SLmtP = new CControl2.TInput();
            CControl2.TInput SLmtN = new CControl2.TInput();
            CControl2.TInput InPos = new CControl2.TInput();
            CControl2.TInput Alarm = new CControl2.TInput();
            CControl2.TOutput MtrOn = new CControl2.TOutput();
            CControl2.TOutput AlmClr = new CControl2.TOutput();
            switch (SelectedAxis)
            {
                case EAxis.GX:
                    #region
                    Home = TaskGantry._SensGXHome;
                    LmtP = TaskGantry._SensGXLmtP;
                    LmtN = TaskGantry._SensGXLmtN;
                    SLmtP = TaskGantry._GXSLmtP;
                    SLmtN = TaskGantry._GXSLmtN;
                    InPos = TaskGantry._GXInp;
                    Alarm = TaskGantry._GXAlm;
                    MtrOn = TaskGantry._GXMtrOn;
                    AlmClr = TaskGantry._GXAlmClr;
                    break;
                    #endregion
                case EAxis.GY:
                    #region
                    Home = TaskGantry._SensGYHome;
                    LmtP = TaskGantry._SensGYLmtP;
                    LmtN = TaskGantry._SensGYLmtN;
                    SLmtP = TaskGantry._GYSLmtP;
                    SLmtN = TaskGantry._GYSLmtN;
                    InPos = TaskGantry._GYInp;
                    Alarm = TaskGantry._GYAlm;
                    MtrOn = TaskGantry._GYMtrOn;
                    AlmClr = TaskGantry._GYAlmClr;
                    break;
                    #endregion
                case EAxis.GZ:
                    #region
                    Home = TaskGantry._SensGZHome;
                    LmtP = TaskGantry._SensGZLmtP;
                    LmtN = TaskGantry._SensGZLmtN;
                    SLmtP = TaskGantry._GZSLmtP;
                    SLmtN = TaskGantry._GZSLmtN;
                    InPos = TaskGantry._GZInp;
                    Alarm = TaskGantry._GZAlm;
                    MtrOn = TaskGantry._GZMtrOn;
                    AlmClr = TaskGantry._GZAlmClr;
                    break;
                    #endregion
                case EAxis.GX2:
                    #region
                    Home = TaskGantry._SensGX2Home;
                    LmtP = TaskGantry._SensGX2LmtP;
                    LmtN = TaskGantry._SensGX2LmtN;
                    SLmtP = TaskGantry._GX2SLmtP;
                    SLmtN = TaskGantry._GX2SLmtN;
                    InPos = TaskGantry._GX2Inp;
                    Alarm = TaskGantry._GX2Alm;
                    MtrOn = TaskGantry._GX2MtrOn;
                    AlmClr = TaskGantry._GX2AlmClr;
                    break;
                    #endregion
                case EAxis.GY2:
                    #region
                    Home = TaskGantry._SensGY2Home;
                    LmtP = TaskGantry._SensGY2LmtP;
                    LmtN = TaskGantry._SensGY2LmtN;
                    SLmtP = TaskGantry._GY2SLmtP;
                    SLmtN = TaskGantry._GY2SLmtN;
                    InPos = TaskGantry._GY2Inp;
                    Alarm = TaskGantry._GY2Alm;
                    MtrOn = TaskGantry._GY2MtrOn;
                    AlmClr = TaskGantry._GY2AlmClr;
                    break;
                    #endregion
                case EAxis.GZ2:
                    #region
                    Home = TaskGantry._SensGZ2Home;
                    LmtP = TaskGantry._SensGZ2LmtP;
                    LmtN = TaskGantry._SensGZ2LmtN;
                    SLmtP = TaskGantry._GZ2SLmtP;
                    SLmtN = TaskGantry._GZ2SLmtN;
                    InPos = TaskGantry._GZ2Inp;
                    Alarm = TaskGantry._GZ2Alm;
                    MtrOn = TaskGantry._GZ2MtrOn;
                    AlmClr = TaskGantry._GZ2AlmClr;
                    break;
                    #endregion
            }

            try
            {
                TaskGantry.GetInput(ref Home);

                TaskGantry.GetInput(ref LmtP);
                TaskGantry.GetInput(ref LmtN); 
                TaskGantry.GetInput(ref SLmtP);
                TaskGantry.GetInput(ref SLmtN);
                TaskGantry.GetInput(ref InPos);
                TaskGantry.GetInput(ref Alarm);

                GDefine.RefreshInput(lbl_Home, Home.Status);
                GDefine.RefreshInput(lbl_LmtP, LmtP.Status);
                GDefine.RefreshInput(lbl_LmtN, LmtN.Status);
                GDefine.RefreshInput(lbl_SLmtP, SLmtP.Status);
                GDefine.RefreshInput(lbl_SLmtN, SLmtN.Status);
                GDefine.RefreshInput(lbl_Inp, InPos.Status);
                GDefine.RefreshInput(lbl_Alm, Alarm.Status);
                GDefine.RefreshOutput(btn_MtrOn, MtrOn.Status);
                GDefine.RefreshOutput(btn_AlmClr, AlmClr.Status);
            }
            catch { };
            GDefine.UpdateInfo(lbl_HomeInfo, Home);
            GDefine.UpdateInfo(lbl_LmtPInfo, LmtP);
            GDefine.UpdateInfo(lbl_LmtNInfo, LmtN);
            GDefine.UpdateInfo(lbl_SLmtPInfo, SLmtP);
            GDefine.UpdateInfo(lbl_SLmtNInfo, SLmtN);
            GDefine.UpdateInfo(lbl_InPosInfo, InPos);
            GDefine.UpdateInfo(lbl_MtrAlmInfo, Alarm);
            GDefine.UpdateInfo(lbl_MtrOnInfo, MtrOn);
            GDefine.UpdateInfo(lbl_AlmClrInfo, AlmClr);
            #endregion
        }

        private void frm_DispCore_MotorDiag_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            this.Text = "Motor Diagnotics";
            SelectedAxis = EAxis.GX;

            tmr_Display.Enabled = true;

            UpdateDisplay();
        }
        private void frm_DispCore_MotorDiag_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (!Visible) { return; }

            try
            {
                CommonControl.CheckBoardOpened(TaskGantry.GXAxis.Device);
            }
            catch { return; }

            UpdateDisplay();
        }

        private void btn_GXAxis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GX;
            UpdateDisplay();
        }
        private void btn_GYAxis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GY;
            UpdateDisplay();
        }
        private void btn_GZAxis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GZ;
            UpdateDisplay();
        }
        private void btn_GX2Axis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GX2;
            UpdateDisplay();
        }
        private void btn_GY2Axis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GY2;
            UpdateDisplay();
        }
        private void btn_GZ2Axis_Click(object sender, EventArgs e)
        {
            SelectedAxis = EAxis.GZ2;
            UpdateDisplay();
        }

        private void btn_MtrOn_Click(object sender, EventArgs e)
        {
            switch (SelectedAxis)
            {
                case EAxis.GX:
                    if (TaskGantry._GXMtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GXMtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GXMtrOn, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GY:
                    if (TaskGantry._GYMtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GYMtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GYMtrOn, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GZ:
                    if (TaskGantry._GZMtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GZMtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GZMtrOn, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GX2:
                    if (TaskGantry._GX2MtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GX2MtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GX2MtrOn, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GY2:
                    if (TaskGantry._GY2MtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GY2MtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GY2MtrOn, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GZ2:
                    if (TaskGantry._GZ2MtrOn.Status)
                        CommonControl.SetDO(ref TaskGantry._GZ2MtrOn, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GZ2MtrOn, CControl2.EOutputStatus.Hi);
                    break;
            }
            UpdateDisplay();
        }
        private void btn_AlmClr_Click(object sender, EventArgs e)
        {
            switch (SelectedAxis)
            {
                case EAxis.GX:
                    if (TaskGantry._GXAlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GXAlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GXAlmClr, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GY:
                    if (TaskGantry._GYAlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GYAlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GYAlmClr, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GZ:
                    if (TaskGantry._GZAlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GZAlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GZAlmClr, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GX2:
                    if (TaskGantry._GX2AlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GX2AlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GX2AlmClr, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GY2:
                    if (TaskGantry._GY2AlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GY2AlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GY2AlmClr, CControl2.EOutputStatus.Hi);
                    break;
                case EAxis.GZ2:
                    if (TaskGantry._GZ2AlmClr.Status)
                        CommonControl.SetDO(ref TaskGantry._GZ2AlmClr, CControl2.EOutputStatus.Lo);
                    else
                        CommonControl.SetDO(ref TaskGantry._GZ2AlmClr, CControl2.EOutputStatus.Hi);
                    break;
            }
            UpdateDisplay();
        }

        private void lbl_GXInfo_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GXAxis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GXAxis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GXAxis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GXAxis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GXAxis = frm.Axis;
                        break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_GYInfo_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GYAxis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GYAxis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GYAxis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GYAxis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GYAxis = frm.Axis;
                        break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_GZInfo_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GZAxis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GZAxis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GZAxis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GZAxis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GZAxis = frm.Axis;
                        break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_GX2Info_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GX2Axis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GX2Axis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GX2Axis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GX2Axis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GX2Axis = frm.Axis;
                        break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_GY2Info_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GY2Axis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GY2Axis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GY2Axis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GY2Axis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GY2Axis = frm.Axis;
                        break;
                }

            }
            UpdateDisplay();
        }
        private void lbl_GZ2Info_Click(object sender, EventArgs e)
        {
            frmDeviceAxisConfigEditor frm = new frmDeviceAxisConfigEditor(TaskGantry.GZ2Axis);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CControl2.TAxis OldAxis = TaskGantry.GZ2Axis;
                DialogResult dr = MessageBox.Show("Update all IO to same Axis Mask?", "", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        TaskGantry.GZ2Axis = frm.Axis;
                        TaskGantry.UpdateAxisConfig2(OldAxis, TaskGantry.GZ2Axis);
                        break;
                    case DialogResult.No:
                        TaskGantry.GZ2Axis = frm.Axis;
                        break;
                }

            }
            UpdateDisplay();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry.GXHome(); break;
                    case EAxis.GY: TaskGantry.GYHome(); break;
                    case EAxis.GZ: TaskGantry.GZHome(); break;
                    case EAxis.GX2: TaskGantry.GX2Home(); break;
                    case EAxis.GY2: TaskGantry.GY2Home(); break;
                    case EAxis.GZ2: TaskGantry.GZ2Home(); break;
                }
        }

        private void lbl_HomeInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._SensGXHome; break;
                case EAxis.GY: Input = TaskGantry._SensGYHome; break;
                case EAxis.GZ: Input = TaskGantry._SensGZHome; break;
                case EAxis.GX2: Input = TaskGantry._SensGX2Home; break;
                case EAxis.GY2: Input = TaskGantry._SensGY2Home; break;
                case EAxis.GZ2: Input = TaskGantry._SensGZ2Home; break;
            }            
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._SensGXHome = frm.Input; break;
                    case EAxis.GY: TaskGantry._SensGYHome = frm.Input; break;
                    case EAxis.GZ: TaskGantry._SensGZHome = frm.Input; break;
                    case EAxis.GX2: TaskGantry._SensGX2Home = frm.Input; break;
                    case EAxis.GY2: TaskGantry._SensGY2Home = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._SensGZ2Home = frm.Input; break;
                }            
            }
            UpdateDisplay();
        }
        private void lbl_LmtPInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._SensGXLmtP; break;
                case EAxis.GY: Input = TaskGantry._SensGYLmtP; break;
                case EAxis.GZ: Input = TaskGantry._SensGZLmtP; break;
                case EAxis.GX2: Input = TaskGantry._SensGX2LmtP; break;
                case EAxis.GY2: Input = TaskGantry._SensGY2LmtP; break;
                case EAxis.GZ2: Input = TaskGantry._SensGZ2LmtP; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._SensGXLmtP = frm.Input; break;
                    case EAxis.GY: TaskGantry._SensGYLmtP = frm.Input; break;
                    case EAxis.GZ: TaskGantry._SensGZLmtP = frm.Input; break;
                    case EAxis.GX2: TaskGantry._SensGX2LmtP = frm.Input; break;
                    case EAxis.GY2: TaskGantry._SensGY2LmtP = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._SensGZ2LmtP = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_LmtNInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._SensGXLmtN; break;
                case EAxis.GY: Input = TaskGantry._SensGYLmtN; break;
                case EAxis.GZ: Input = TaskGantry._SensGZLmtN; break;
                case EAxis.GX2: Input = TaskGantry._SensGX2LmtN; break;
                case EAxis.GY2: Input = TaskGantry._SensGY2LmtN; break;
                case EAxis.GZ2: Input = TaskGantry._SensGZ2LmtN; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._SensGXLmtN = frm.Input; break;
                    case EAxis.GY: TaskGantry._SensGYLmtN = frm.Input; break;
                    case EAxis.GZ: TaskGantry._SensGZLmtN = frm.Input; break;
                    case EAxis.GX2: TaskGantry._SensGX2LmtN = frm.Input; break;
                    case EAxis.GY2: TaskGantry._SensGY2LmtN = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._SensGZ2LmtN = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_SLmtPInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._GXSLmtP; break;
                case EAxis.GY: Input = TaskGantry._GYSLmtP; break;
                case EAxis.GZ: Input = TaskGantry._GZSLmtP; break;
                case EAxis.GX2: Input = TaskGantry._GX2SLmtP; break;
                case EAxis.GY2: Input = TaskGantry._GY2SLmtP; break;
                case EAxis.GZ2: Input = TaskGantry._GZ2SLmtP; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXSLmtP = frm.Input; break;
                    case EAxis.GY: TaskGantry._GYSLmtP = frm.Input; break;
                    case EAxis.GZ: TaskGantry._GZSLmtP = frm.Input; break;
                    case EAxis.GX2: TaskGantry._GX2SLmtP = frm.Input; break;
                    case EAxis.GY2: TaskGantry._GY2SLmtP = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._GZ2SLmtP = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_SLmtNInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._GXSLmtN; break;
                case EAxis.GY: Input = TaskGantry._GYSLmtN; break;
                case EAxis.GZ: Input = TaskGantry._GZSLmtN; break;
                case EAxis.GX2: Input = TaskGantry._GX2SLmtN; break;
                case EAxis.GY2: Input = TaskGantry._GY2SLmtN; break;
                case EAxis.GZ2: Input = TaskGantry._GZ2SLmtN; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXSLmtN = frm.Input; break;
                    case EAxis.GY: TaskGantry._GYSLmtN = frm.Input; break;
                    case EAxis.GZ: TaskGantry._GZSLmtN = frm.Input; break;
                    case EAxis.GX2: TaskGantry._GX2SLmtN = frm.Input; break;
                    case EAxis.GY2: TaskGantry._GY2SLmtN = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._GZ2SLmtN = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        
        private void lbl_InPosInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._GXInp; break;
                case EAxis.GY: Input = TaskGantry._GYInp; break;
                case EAxis.GZ: Input = TaskGantry._GZInp; break;
                case EAxis.GX2: Input = TaskGantry._GX2Inp; break;
                case EAxis.GY2: Input = TaskGantry._GY2Inp; break;
                case EAxis.GZ2: Input = TaskGantry._GZ2Inp; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXInp = frm.Input; break;
                    case EAxis.GY: TaskGantry._GYInp = frm.Input; break;
                    case EAxis.GZ: TaskGantry._GZInp = frm.Input; break;
                    case EAxis.GX2: TaskGantry._GX2Inp = frm.Input; break;
                    case EAxis.GY2: TaskGantry._GY2Inp = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._GZ2Inp = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_MtrAlmInfo_Click(object sender, EventArgs e)
        {
            CControl2.TInput Input = new CControl2.TInput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Input = TaskGantry._GXAlm; break;
                case EAxis.GY: Input = TaskGantry._GYAlm; break;
                case EAxis.GZ: Input = TaskGantry._GZAlm; break;
                case EAxis.GX2: Input = TaskGantry._GX2Alm; break;
                case EAxis.GY2: Input = TaskGantry._GY2Alm; break;
                case EAxis.GZ2: Input = TaskGantry._GZ2Alm; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Input);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXAlm = frm.Input; break;
                    case EAxis.GY: TaskGantry._GYAlm = frm.Input; break;
                    case EAxis.GZ: TaskGantry._GZAlm = frm.Input; break;
                    case EAxis.GX2: TaskGantry._GX2Alm = frm.Input; break;
                    case EAxis.GY2: TaskGantry._GY2Alm = frm.Input; break;
                    case EAxis.GZ2: TaskGantry._GZ2Alm = frm.Input; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_MtrOnInfo_Click(object sender, EventArgs e)
        {
            CControl2.TOutput Output = new CControl2.TOutput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Output = TaskGantry._GXMtrOn; break;
                case EAxis.GY: Output = TaskGantry._GYMtrOn; break;
                case EAxis.GZ: Output = TaskGantry._GZMtrOn; break;
                case EAxis.GX2: Output = TaskGantry._GX2MtrOn; break;
                case EAxis.GY2: Output = TaskGantry._GY2MtrOn; break;
                case EAxis.GZ2: Output = TaskGantry._GZ2MtrOn; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Output);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXMtrOn = frm.Output; break;
                    case EAxis.GY: TaskGantry._GYMtrOn = frm.Output; break;
                    case EAxis.GZ: TaskGantry._GZMtrOn = frm.Output; break;
                    case EAxis.GX2: TaskGantry._GX2MtrOn = frm.Output; break;
                    case EAxis.GY2: TaskGantry._GY2MtrOn = frm.Output; break;
                    case EAxis.GZ2: TaskGantry._GZ2MtrOn = frm.Output; break;
                }
            }
            UpdateDisplay();
        }
        private void lbl_AlmClrInfo_Click(object sender, EventArgs e)
        {
            CControl2.TOutput Output = new CControl2.TOutput();
            switch (SelectedAxis)
            {
                case EAxis.GX: Output = TaskGantry._GXAlmClr; break;
                case EAxis.GY: Output = TaskGantry._GYAlmClr; break;
                case EAxis.GZ: Output = TaskGantry._GZAlmClr; break;
                case EAxis.GX2: Output = TaskGantry._GX2AlmClr; break;
                case EAxis.GY2: Output = TaskGantry._GY2AlmClr; break;
                case EAxis.GZ2: Output = TaskGantry._GZ2AlmClr; break;
            }
            frmDeviceIOConfigEditor frm = new frmDeviceIOConfigEditor(Output);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (SelectedAxis)
                {
                    case EAxis.GX: TaskGantry._GXAlmClr = frm.Output; break;
                    case EAxis.GY: TaskGantry._GYAlmClr = frm.Output; break;
                    case EAxis.GZ: TaskGantry._GZAlmClr = frm.Output; break;
                    case EAxis.GX2: TaskGantry._GX2AlmClr = frm.Output; break;
                    case EAxis.GY2: TaskGantry._GY2AlmClr = frm.Output; break;
                    case EAxis.GZ2: TaskGantry._GZ2AlmClr = frm.Output; break;
                }
            }
            UpdateDisplay();
        }
    }
}
