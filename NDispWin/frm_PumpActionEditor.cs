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
    public partial class frm_PumpActionEditor : Form
    {
        public frm_PumpActionEditor()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        List<Pump.EAction> l_Action = new List<Pump.EAction>();
        private void frm_PumpActionEditor_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            this.Text = "Pump Action Editor";

            combox_Group.Items.Clear();
            for (int i = 0; i < Pump.Actions.MAX_GROUP; i++)
            {
                combox_Group.Items.Add("Group " + i.ToString());
            }
            combox_Group.SelectedIndex = 0;
            combox_Group.SelectedItem = 0;

            combox_Action.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                if (Enum.GetName(typeof(Pump.EAction), i) != null)
                {
                    combox_Action.Items.Add(Enum.GetName(typeof(Pump.EAction), i));
                    l_Action.Add((Pump.EAction)i);
                }
            }

            lbox_GroupPumpActionList.Items.Clear();
            for (int i = 0; i < Pump.TActionSeq.MAX_SEQ; i++)
            {
                lbox_GroupPumpActionList.Items.Add(Pump.Action.ActionGroup[i_ActionGroup].Action[i].Action.ToString());
            }

            lbox_GroupPumpActionList.SelectedIndex = 0;
            lbox_GroupPumpActionList.SelectedItem = 0;

            UpdateGroupList();
            UpdateGroupInfo();
        }

        int i_ActionGroup = 0;
        int i_ActionSeq = 0;
        private void UpdateGroupList()
        {
            tbox_Name.Text = Pump.Action.ActionGroup[i_ActionGroup].Name;
            btn_Execute.Visible = Pump.Action.ActionGroup[i_ActionGroup].Name.Length > 0;
 
            for (int i = 0; i < Pump.TActionSeq.MAX_SEQ; i++)
            {
                lbox_GroupPumpActionList.Items[i] = Pump.Action.ActionGroup[i_ActionGroup].Action[i].Action.ToString();
            }
        }
        private void UpdateGroupInfo()
        {
            gbox_ActionInfo.Text = "Group " + i_ActionGroup.ToString();

            combox_Action.Text = Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].Action.ToString();
            tbox_DefDesc.Text = Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].DefDesc;
            tbox_CustomDesc.Text = Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].CustomDesc;
            tbox_AltDesc.Text = Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].AltDesc;
        }

        private void combox_Group_SelectionChangeCommitted(object sender, EventArgs e)
        {
            i_ActionGroup = combox_Group.SelectedIndex;

            UpdateGroupList();
            UpdateGroupInfo();

            i_ActionSeq = 0;
        }
        private void tbox_Name_Leave(object sender, EventArgs e)
        {
            Pump.Action.ActionGroup[i_ActionGroup].Name = tbox_Name.Text;
            UpdateGroupList();
        }

        private void lbox_GroupPumpActionList_Click(object sender, EventArgs e)
        {
            if (lbox_GroupPumpActionList.SelectedIndex < 0) return;

            i_ActionSeq = lbox_GroupPumpActionList.SelectedIndex;

            UpdateGroupInfo();
        }
        private void lbox_GroupPumpActionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox_GroupPumpActionList.SelectedIndex < 0) return;

            //i_ActionSeq = lbox_GroupPumpActionList.SelectedIndex;

            UpdateGroupInfo();
        }

        private void btn_MoveUp_Click(object sender, EventArgs e)
        {
            if (i_ActionSeq == 0) return;

            Pump.Action.ActionGroup[i_ActionGroup].MoveUp(i_ActionSeq);
            i_ActionSeq--;

            UpdateGroupList();
            lbox_GroupPumpActionList.SelectedIndex = i_ActionSeq;
            lbox_GroupPumpActionList.SelectedItem = i_ActionSeq;
        }
        private void btn_MoveDn_Click(object sender, EventArgs e)
        {
            if (i_ActionSeq == Pump.TActionSeq.MAX_SEQ - 1) return;

            Pump.Action.ActionGroup[i_ActionGroup].MoveDn(i_ActionSeq);
            i_ActionSeq++;

            UpdateGroupList();
            lbox_GroupPumpActionList.SelectedIndex = i_ActionSeq;
            lbox_GroupPumpActionList.SelectedItem = i_ActionSeq;
        }
        private void btn_Execute_Click(object sender, EventArgs e)
        {
            if (Pump.Action.ActionGroup[i_ActionGroup].Name.Length < 0) return;

            Pump.Action.ActionGroup[i_ActionGroup].Execute();
        }

        #region Group Info
        private void combox_Action_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (combox_Action.SelectedIndex < 0) return;

            Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].Action = l_Action[combox_Action.SelectedIndex];

            UpdateGroupList();
            UpdateGroupInfo();
        }
        private void tbox_CustomDesc_Leave(object sender, EventArgs e)
        {
            Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].CustomDesc = tbox_CustomDesc.Text;
            UpdateGroupList();
        }
        private void tbox_AltDesc_Leave(object sender, EventArgs e)
        {
            Pump.Action.ActionGroup[i_ActionGroup].Action[i_ActionSeq].AltDesc = tbox_AltDesc.Text;
            UpdateGroupList();
        }
        #endregion

        private void btn_Load_Click(object sender, EventArgs e)
        {
            Pump.Action.Load();
            UpdateGroupList();
            UpdateGroupInfo();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Pump.Action.Save();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_ClearName_Click(object sender, EventArgs e)
        {
            Pump.Action.ActionGroup[i_ActionGroup].Name = "";
            UpdateGroupList();
        }
    }
}
