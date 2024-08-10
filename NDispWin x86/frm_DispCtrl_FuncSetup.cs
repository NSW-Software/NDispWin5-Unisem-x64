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
    public partial class frm_DispCore_DispCtrl_FuncSetup : Form
    {
        public frm_DispCore_DispCtrl_FuncSetup()
        {
            InitializeComponent();
            GControl.LogForm(this);

            combox_Func.Items.Clear();
            for (int i = 0; i < TaskDispCtrl.MAX_FUNC_CODE; i++)
            {
                string s = Enum.GetName(typeof(TaskDispCtrl.EDispFunc), i);
                if (s != null)
                    combox_Func.Items.Add(s);
            }
        }

        private void EnableControls(bool Enable, Button Button1, Button Button2)
        {
            try
            {
                if (this.ParentForm != null) this.ParentForm.Enabled = Enable;
            }
            catch { };

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

        private void frm_DispCtrl_FuncSetup_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            Text = "Function Setup";
            gbox_Editor.Visible = false;

            UpdateListView(lbox_Func1, 0);
            UpdateListView(lbox_Func2, 1);
            UpdateListView(lbox_Func3, 2);

            UpdateDisplay();
        }

        private void UpdateListView(ListBox ListBox, int Group)
        {
            ListBox.Items.Clear();
            for (int i = 0; i < TaskDispCtrl.DispFuncs.Group[Group].SeqCount; i++)
            {
                string s = "Seq " + i.ToString() + (char)9;
                s = s + TaskDispCtrl.GetStringPara(TaskDispCtrl.DispFuncs.Group[Group].Funcs[i]);
                ListBox.Items.Add(s);
            }
        }

        private void UpdateDisplay()
        {
            UI_Utils.SetControlSelected(btn_HeadA, b_HeadA && !(b_HeadA && b_HeadB));
            UI_Utils.SetControlSelected(btn_HeadB, b_HeadB && !(b_HeadA && b_HeadB));
            UI_Utils.SetControlSelected(btn_HeadAB, b_HeadA && b_HeadB);

            tbox_Name1.Text = TaskDispCtrl.DispFuncs.Group[0].Name;
            tbox_Name2.Text = TaskDispCtrl.DispFuncs.Group[1].Name;
            tbox_Name3.Text = TaskDispCtrl.DispFuncs.Group[2].Name;

            btn_MoveDn1.Enabled = (SelectedGroup == 0 && SelectedIndex >= 0);
            btn_MoveUp1.Enabled = (SelectedGroup == 0 && SelectedIndex >= 0);
            btn_Remove1.Enabled = (SelectedGroup == 0 && SelectedIndex >= 0);

            btn_MoveDn2.Enabled = (SelectedGroup == 1 && SelectedIndex >= 0);
            btn_MoveUp2.Enabled = (SelectedGroup == 1 && SelectedIndex >= 0);
            btn_Remove2.Enabled = (SelectedGroup == 1 && SelectedIndex >= 0);

            btn_MoveDn3.Enabled = (SelectedGroup == 2 && SelectedIndex >= 0);
            btn_MoveUp3.Enabled = (SelectedGroup == 2 && SelectedIndex >= 0);
            btn_Remove3.Enabled = (SelectedGroup == 2 && SelectedIndex >= 0);
        }

        bool b_HeadA = true;
        bool b_HeadB = false;
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

        TaskDispCtrl.TFunc TempFunc = new TaskDispCtrl.TFunc();
        int SelectedGroup = -1;
        int SelectedIndex = -1;
        #region Editor
        private void UpdateFuncEditor()
        {
            combox_Func.SelectedIndex = TaskDispCtrl.GetIndex((TaskDispCtrl.EDispFunc)TempFunc.DispFunc);
            if (TempFunc.Count == 0)
            {
                lbl_Count.Text = "Auto";
                lbl_Time.Text = "Auto";
                lbl_Wait.Text = "Auto";
                lbl_PostVacTime.Text = "Auto";
            }
            else
            {
                lbl_Count.Text = TempFunc.Count.ToString();
                lbl_Time.Text = TempFunc.Time.ToString();
                lbl_Wait.Text = TempFunc.Wait.ToString();
                lbl_PostVacTime.Text = TempFunc.PostVacTime.ToString();
            }

            switch (TempFunc.DispFunc)
            {
                case TaskDispCtrl.EDispFunc.None:
                case TaskDispCtrl.EDispFunc.GoMMaint:
                case TaskDispCtrl.EDispFunc.GoPMaint:
                    lbl_Time.Visible = false;
                    lbl_Wait.Visible = false;
                    lbl_Count.Visible = false;
                    lbl_PostVacTime.Visible = false;
                    break;
                case TaskDispCtrl.EDispFunc.Delay:
                    lbl_Time.Visible = true;
                    lbl_Wait.Visible = false;
                    lbl_Count.Visible = false;
                    lbl_PostVacTime.Visible = false;
                    break;
                case TaskDispCtrl.EDispFunc.DoClean:
                case TaskDispCtrl.EDispFunc.DoPurge:
                    lbl_Time.Visible = true;
                    lbl_Wait.Visible = true;
                    lbl_Count.Visible = true;
                    lbl_PostVacTime.Visible = true;
                    break;
                case TaskDispCtrl.EDispFunc.CleanFill:
                case TaskDispCtrl.EDispFunc.RecycleBarrelF:
                case TaskDispCtrl.EDispFunc.RecycleBarrel5S:
                case TaskDispCtrl.EDispFunc.RecycleNeedle:
                    lbl_Time.Visible = false;
                    lbl_Wait.Visible = false;
                    lbl_Count.Visible = true;
                    lbl_PostVacTime.Visible = false;
                    break;
                case TaskDispCtrl.EDispFunc.Shot:
                    lbl_Time.Visible = false;
                    lbl_Wait.Visible = true;
                    lbl_Count.Visible = true;
                    lbl_PostVacTime.Visible = false;
                    break;
            }
        }
        private void combox_Func_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = combox_Func.SelectedIndex;
            if (Index < 0) return;

            TempFunc.DispFunc = TaskDispCtrl.IndexGetFunction(combox_Func.SelectedIndex);
            UpdateFuncEditor();
        }
        private void lbl_Time_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Ctrl Func Setup, Time", ref TempFunc.Time, 0, 1000);
            UpdateFuncEditor();
        }
        private void lbl_Wait_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Ctrl Func Setup, Wait", ref TempFunc.Wait, 0, 1000);
            UpdateFuncEditor();
        }
        private void lbl_Count_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Ctrl Func Setup, Count", ref TempFunc.Count, 0, 10);
            UpdateFuncEditor();
        }
        private void lbl_PostVacTime_Click(object sender, EventArgs e)
        {
            UC.AdjustExec("Disp Ctrl Func Setup, PostVacTime", ref TempFunc.PostVacTime, 0, 5000);
            UpdateFuncEditor();
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            TaskDispCtrl.DispFuncs.Group[SelectedGroup].Funcs[SelectedIndex].Copy(TempFunc);
            UpdateFuncEditor();

            UpdateListView(lbox_Func1, 0);
            UpdateListView(lbox_Func2, 1);
            UpdateListView(lbox_Func3, 2);

            SelectedGroup = -1;
            SelectedIndex = -1;

            UpdateDisplay();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            SelectedGroup = -1;
            SelectedIndex = -1;

            UpdateDisplay();
        }
        #endregion

        private void MoveUp(ListBox ListBox, int Index)
        {
            if (Index <= 0) return;

            TaskDispCtrl.MoveUp(SelectedGroup, Index);
            UpdateListView(ListBox, SelectedGroup);
            ListBox.SetSelected(Index - 1, true);
        }
        private void MoveDn(ListBox ListBox, int Index)
        {
            if (Index < 0) return;
            if (Index >= TaskDispCtrl.DispFuncs.Group[SelectedGroup].SeqCount - 1) return;

            TaskDispCtrl.MoveDn(SelectedGroup, Index);
            UpdateListView(ListBox, SelectedGroup);
            ListBox.SetSelected(Index + 1, true);
        }

        private void lbox_Func1_Click(object sender, EventArgs e)
        {
            int Index = lbox_Func1.SelectedIndex;
            if (Index < 0) return;

            SelectedGroup = 0;
            SelectedIndex = Index;

            gbox_Editor.Visible = true;

            TempFunc.Copy(TaskDispCtrl.DispFuncs.Group[SelectedGroup].Funcs[lbox_Func1.SelectedIndex]);
            UpdateFuncEditor();
            UpdateDisplay();
        }
        private void btn_MoveUp1_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func1.SelectedIndex;
            if (Index <= 0) return;

            MoveUp(lbox_Func1, Index);
        }
        private void btn_MoveDn1_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func1.SelectedIndex;
            if (Index < 0) return;
            if (Index >= TaskDispCtrl.DispFuncs.Group[0].SeqCount - 1) return;

            MoveDn(lbox_Func1, Index);
        }
        private void btn_Test1_Click(object sender, EventArgs e)
        {
            EnableControls(false, btn_Dummy, btn_Dummy);

            TaskDispCtrl.DispFuncs.Group[0].Execute(b_HeadA, b_HeadB);

            EnableControls();
        }
        private void btn_Add1_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            TaskDispCtrl.AddFunc(0);
            UpdateListView(lbox_Func1, 0);
        }
        private void btn_Remove1_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func1.SelectedIndex;
            if (Index < 0) return;

            TaskDispCtrl.DeleteFunc(0, Index);
            UpdateListView(lbox_Func1, 0);
            UpdateDisplay();
        }

        private void lbox_Func2_Click(object sender, EventArgs e)
        {
            int Index = lbox_Func2.SelectedIndex;
            if (Index < 0) return;

            SelectedGroup = 1;
            SelectedIndex = Index;

            gbox_Editor.Visible = true;

            TempFunc.Copy(TaskDispCtrl.DispFuncs.Group[SelectedGroup].Funcs[lbox_Func2.SelectedIndex]);
            UpdateFuncEditor();
            UpdateDisplay();
        }
        private void btn_MoveUp2_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func2.SelectedIndex;
            if (Index <= 0) return;

            MoveUp(lbox_Func2, Index);
        }
        private void btn_MoveDn2_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func2.SelectedIndex;
            if (Index < 0) return;
            if (Index >= TaskDispCtrl.DispFuncs.Group[1].SeqCount - 1) return;

            MoveDn(lbox_Func2, Index);
        }
        private void btn_Test2_Click(object sender, EventArgs e)
        {
            EnableControls(false, btn_Dummy, btn_Dummy);

            TaskDispCtrl.DispFuncs.Group[1].Execute(b_HeadA, b_HeadB);

            EnableControls();

        }
        private void btn_Add2_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            TaskDispCtrl.AddFunc(1);
            UpdateListView(lbox_Func2, 1);
        }
        private void btn_Remove2_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func2.SelectedIndex;
            if (Index < 0) return;

            TaskDispCtrl.DeleteFunc(1, Index);
            UpdateListView(lbox_Func2, 1);
        }

        private void lbox_Func3_Click(object sender, EventArgs e)
        {
            int Index = lbox_Func3.SelectedIndex;
            if (Index < 0) return;

            SelectedGroup = 2;
            SelectedIndex = Index;

            gbox_Editor.Visible = true;

            TempFunc.Copy(TaskDispCtrl.DispFuncs.Group[SelectedGroup].Funcs[lbox_Func3.SelectedIndex]);
            UpdateFuncEditor();
            UpdateDisplay();
        }
        private void btn_MoveUp3_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func3.SelectedIndex;
            if (Index <= 0) return;

            MoveUp(lbox_Func3, Index);
        }
        private void btn_MoveDn3_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func3.SelectedIndex;
            if (Index < 0) return;
            if (Index >= TaskDispCtrl.DispFuncs.Group[2].SeqCount - 1) return;

            MoveDn(lbox_Func3, Index);
        }
        private void btn_Test3_Click(object sender, EventArgs e)
        {
            EnableControls(false, btn_Dummy, btn_Dummy);

            TaskDispCtrl.DispFuncs.Group[2].Execute(b_HeadA, b_HeadB);

            EnableControls();

        }
        private void btn_Add3_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            TaskDispCtrl.AddFunc(2);
            UpdateListView(lbox_Func3, 2);
        }
        private void btn_Remove3_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            int Index = lbox_Func3.SelectedIndex;
            if (Index < 0) return;

            TaskDispCtrl.DeleteFunc(2, Index);
            UpdateListView(lbox_Func3, 2);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;

            TaskDispCtrl.DispFuncs.Group[0].Name = tbox_Name1.Text;
            TaskDispCtrl.DispFuncs.Group[1].Name = tbox_Name2.Text;
            TaskDispCtrl.DispFuncs.Group[2].Name = tbox_Name3.Text;

            TaskDispCtrl.DispFuncs.Save();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            gbox_Editor.Visible = false;
            Close();
        }

        private void gbox_Editor_Enter(object sender, EventArgs e)
        {

        }

    }
}
