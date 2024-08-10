using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NDispWin
{
    public partial class frm_DispCore_DispProg_ManageProgram : Form
    {
        public frm_DispCore_DispProg_ManageProgram()
        {
            InitializeComponent();
            GControl.LogForm(this);
        }

        private void frmManageProgram_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            if (TaskDisp.EnableRecipeFile) Text = "Manage Recipe";

                RefreshProgramList();
        }

        private void RefreshProgramList()
        {
            lbox_Program.Items.Clear();

            string[] ProgList = Directory.GetFiles(GDefine.ProgPath, "*." + GDefine.ProgExt);

            if (TaskDisp.EnableRecipeFile)
                ProgList = Directory.GetFiles(GDefine.RecipeDir.FullName, "*" + GDefine.RecipeExt);

            foreach (string s in ProgList)
            {
                lbox_Program.Items.Add(Path.GetFileNameWithoutExtension(s));
            }
        }

        private void DeleteProgram(string ProgName)
        {
            if (TaskDisp.EnableRecipeFile)
            {
                File.Delete(GDefine.RecipeDir.FullName + ProgName + GDefine.RecipeExt);
                return;
            }

            File.Delete(GDefine.ProgPath + "\\" + ProgName + "." + GDefine.ProgExt);

            string[] ProgFiles = Directory.GetFiles(GDefine.ProgPath, ProgName + ".*");
            foreach (string s in ProgFiles)
            {
                File.Delete(s);
            }

            ProgFiles = Directory.GetFiles(GDefine.ProgPath, ProgName + "_*.*");
            int count = 0;
            foreach (char c in ProgName)
            {
                if (c.Equals("_")) count++;
            }
            int count_max = count + 1;
            foreach (string s in ProgFiles)
            {
                int counts = 0;
                foreach (char c in s)
                {
                    if (c.Equals("_")) counts++;
                }
                if (counts == count_max)
                    File.Delete(s);
            }

            string HPCPath = "c:\\Program Files\\NSWAutomation\\HPC";

            if (Directory.Exists(HPCPath))
            {
                string[] Files = Directory.GetFiles(HPCPath, ProgName + ".*");
                foreach (string s in Files)
                {
                    File.Delete(s);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (SelectedProgName.Length == 0) return;

            if (SelectedProgName == GDefine.ProgRecipeName)
            {
                Msg Msg = new Msg();
                Msg.Show(ErrCode.PROGRAM_CANNOT_DELETE_ACTIVE, "", EMcState.Notice, EMsgBtn.smbOK, false);
                return;
            }

            {
                Msg Msg = new Msg();
                    EMsgRes MsgRes = Msg.Show(ErrCode.PROGRAM_CONFIRM_DELETE, "", EMcState.Notice, EMsgBtn.smbOK_Cancel, false);// == EMsgRes.smrOK) return;
                if (MsgRes == EMsgRes.smrCancel) return;
            }
 
            DeleteProgram(SelectedProgName);
            Log.OnAction("Delete Prog", SelectedProgName);

            RefreshProgramList();
        }

        private void lbox_Program_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        string SelectedProgName = "";
        private void lbox_Program_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbox_Program.SelectedIndex == -1)
            {
                SelectedProgName = "";
                return;
            }
            SelectedProgName = (string)lbox_Program.Items[lbox_Program.SelectedIndex];
        }
    }
}
