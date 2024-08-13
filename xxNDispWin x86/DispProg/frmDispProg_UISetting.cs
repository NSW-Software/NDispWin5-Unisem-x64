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
    internal partial class frm_DispCore_DispProg_UISetting : Form
    {
        public frm_DispCore_DispProg_UISetting()
        {
            InitializeComponent();
            GControl.LogForm(this);

            lbox_CommandList.Items.Clear();
            foreach (int i in DispProgUI.CommandList)
            {
                string S = Enum.GetName(typeof(DispProg.ECmd), i);
                if (S != null)
                    lbox_CommandList.Items.Add(S);
            }
 
            lbox_FunctionList.Items.Clear();
            foreach (int i in DispProgUI.FunctionList)
            {
                string S = Enum.GetName(typeof(DispProgUI.EFunction), i);
                if (S != null)
                    lbox_FunctionList.Items.Add(S);
            }

            //AppLanguage.Func.SetComponent(this);
        }

        private void UpdateDisplay()
        {
            lbox_Command.Items.Clear();
            foreach (int i in DispProgUI.Command)
            {
                string S = Enum.GetName(typeof(DispProg.ECmd), i);
                if (S != null)
                    lbox_Command.Items.Add(S);
            }
            
            lbox_Function.Items.Clear();
            foreach (int i in DispProgUI.Function)
            {
                string S = Enum.GetName(typeof(DispProgUI.EFunction), i);
                if (S != null)
                    lbox_Function.Items.Add(S);
            }
        }

        private void frmDispProg_UISetting_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            UpdateDisplay();
        }

        private void btn_AddCommand_Click(object sender, EventArgs e)
        {
            int i = lbox_CommandList.SelectedIndex;

            if (i >= 0)
            {
                if (DispProgUI.CommandList[i] == 0) return;

                if (!DispProgUI.Command.Contains(DispProgUI.CommandList[i]))
                    DispProgUI.Command.Add(DispProgUI.CommandList[i]);
            }
            UpdateDisplay();
        }
        private void btn_AddAll_Click(object sender, EventArgs e)
        {
            DispProgUI.Command.Clear();
            foreach (int i in DispProgUI.CommandList)
            {
                if (i != 0) DispProgUI.Command.Add(i);
            }
            UpdateDisplay();
        }
        private void btn_RemoveCommand_Click(object sender, EventArgs e)
        {
            int i = lbox_Command.SelectedIndex;

            if (i >= 0)
            {
                DispProgUI.Command.RemoveAt(i);
            }
            UpdateDisplay();
        }
        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            DispProgUI.AddDefault();
            UpdateDisplay();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            int i = lbox_FunctionList.SelectedIndex;

            if (i >= 0)
            {
                if (!DispProgUI.Function.Contains(DispProgUI.FunctionList[i]))
                DispProgUI.Function.Add(DispProgUI.FunctionList[i]);
            }
            UpdateDisplay();
        }

        private void btn_MoveUp_Click(object sender, EventArgs e)
        {
            int i = lbox_Function.SelectedIndex;
            if (i <= 0) return;

            int temp = DispProgUI.Function[i - 1];
            DispProgUI.Function[i - 1] = DispProgUI.Function[i];
            DispProgUI.Function[i] = temp;

            UpdateDisplay();

            lbox_Function.SelectedIndex = i - 1;
        }

        private void btn_MoveDn_Click(object sender, EventArgs e)
        {
            int i = lbox_Function.SelectedIndex;
            if (i < 0) return;
            if (i >= lbox_Function.Items.Count - 1) return;

            int temp = DispProgUI.Function[i + 1];
            DispProgUI.Function[i + 1] = DispProgUI.Function[i];
            DispProgUI.Function[i] = temp;

            UpdateDisplay();

            lbox_Function.SelectedIndex = i + 1;
        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            int i = lbox_Function.SelectedIndex;

            if (i >= 0)
            {
                DispProgUI.Function.RemoveAt(i);
            }
            UpdateDisplay();
        }

        private void btn_TRRemoveAll_Click(object sender, EventArgs e)
        {
            DispProgUI.Function.Clear();
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DispProgUI.Save();
            Close();
        }

    }
}
