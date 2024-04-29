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
    public partial class frm_MHS2Config : Form
    {
        public frm_MHS2Config()
        {
            InitializeComponent();

            combox_LeftLineMode.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskConv.ELeftMode)).Count(); i++)
            {
                combox_LeftLineMode.Items.Add(Enum.GetName(typeof(TaskConv.ELeftMode), i));
            }
            combox_RightLineMode.Items.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(TaskConv.ERightMode)).Count(); i++)
            {
                combox_RightLineMode.Items.Add(Enum.GetName(typeof(TaskConv.ERightMode), i));
            }
            AppLanguage.Func2.WriteLangFile(this);
        }

        private void frm_Config_Load(object sender, EventArgs e)
        {
            GControl.UpdateFormControl(this);
            AppLanguage.Func2.UpdateText(this);

            btn_Save.Visible = this.Modal;
            btn_Close.Visible = this.Modal;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            combox_LeftLineMode.SelectedIndex = (int)TaskConv.LeftMode;
            combox_RightLineMode.SelectedIndex = (int)TaskConv.RightMode;

            cbox_EnableUnloadMsg.Visible = TaskConv.RightMode == TaskConv.ERightMode.ManualUnload;
            cbox_EnableUnloadMsg.Checked = TaskConv.EnableUnloadMsg;

            cbox_EnableBlowSuck.Checked = TaskConv.EnableBlowSuck;
            cbox_OutMagFrameQtyFollowInMag.Checked = TaskConv.OutLevelQtyFollowIn;

            cbInMcReadyFollowInPsntSens.Checked = TaskConv.InMcReadyFollowSensInPsnt;

            cbOutMagLevelFollowInMag.Checked = TaskConv.OutLevelFollowInLevel;

            if (!ZEC3002.Ctrl.BoardOpened(ConvIO.BoardID)) { return; }
        }

        private void combox_LeftLineMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskConv.LeftMode = (TaskConv.ELeftMode)combox_LeftLineMode.SelectedIndex;
            UpdateDisplay();
        }

        private void combox_RightLineMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TaskConv.RightMode = (TaskConv.ERightMode)combox_RightLineMode.SelectedIndex;
            UpdateDisplay();
        }

        private void cbox_EnableUnloadMsg_Click(object sender, EventArgs e)
        {
            TaskConv.EnableUnloadMsg = !TaskConv.EnableUnloadMsg;
            UpdateDisplay();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TaskConv.SaveRecipe();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbox_EnableBlowSuck_Click(object sender, EventArgs e)
        {
            TaskConv.EnableBlowSuck = !TaskConv.EnableBlowSuck;
            UpdateDisplay();
        }

        private void btn_GenDIOAdd_Click(object sender, EventArgs e)
        {
            frmMHS2PromptNewDIO frm = new frmMHS2PromptNewDIO();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

            string BackupFileName = "";
            if (File.Exists(GDefine.MHSDIOAddFile))
            {
                BackupFileName = Path.GetDirectoryName(GDefine.MHSDIOAddFile) + "\\" + Path.GetFileNameWithoutExtension(GDefine.MHSDIOAddFile) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(GDefine.MHSDIOAddFile);
                File.Copy(GDefine.MHSDIOAddFile, BackupFileName, true);
            }

            ConvIO.SaveDIOAdd(GDefine.MHSDIOAddFile);
            ElevIO.SaveDIOAdd(GDefine.MHSDIOAddFile);

            if (BackupFileName.Length > 0)
                MessageBox.Show("Generate DIO Address completed. Backup DIOFile \"" + BackupFileName + "\" was created.");
        }
        private void btn_LoadDIO_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = GDefine.MHSPath;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string BackupFileName = "";
            if (File.Exists(GDefine.MHSDIOAddFile))
            {
                BackupFileName = Path.GetDirectoryName(GDefine.MHSDIOAddFile) + "\\" + Path.GetFileNameWithoutExtension(GDefine.MHSDIOAddFile) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(GDefine.MHSDIOAddFile);
                File.Copy(GDefine.MHSDIOAddFile, BackupFileName, true);
            }

            ConvIO.LoadDIOAdd(ofd.FileName);
            ElevIO.LoadDIOAdd(ofd.FileName);

            if (BackupFileName.Length > 0)
                MessageBox.Show("Generate DIO Address completed. Backup DIOFile \"" + BackupFileName + "\" was created.");
        }

        private void btn_GenerateMotorPara_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Generate default Motor Para. All current data will be overwritten. Continue?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            string BackupFileName = "";
            if (File.Exists(GDefine.MHSMotorParaFile))
            {
                BackupFileName = Path.GetDirectoryName(GDefine.MHSMotorParaFile) + "\\" + Path.GetFileNameWithoutExtension(GDefine.MHSMotorParaFile) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(GDefine.MHSMotorParaFile);
                File.Copy(GDefine.MHSMotorParaFile, BackupFileName, true);
                File.Delete(GDefine.MHSMotorParaFile);
            }

            ElevIO.LoadMotorPara(GDefine.MHSMotorParaFile);

            if (BackupFileName.Length > 0)
                MessageBox.Show("Generate Motor Para completed. Backup Motor Para \"" + BackupFileName + "\" was created.");
        }

        private void btn_LoadMotorPara_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = GDefine.MHSPath;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string BackupFileName = "";
            if (File.Exists(GDefine.MHSMotorParaFile))
            {
                BackupFileName = Path.GetDirectoryName(GDefine.MHSMotorParaFile) + "\\" + Path.GetFileNameWithoutExtension(GDefine.MHSMotorParaFile) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(GDefine.MHSMotorParaFile);
                File.Copy(GDefine.MHSMotorParaFile, BackupFileName, true);
            }

            ElevIO.LoadMotorPara(ofd.FileName);

            if (BackupFileName.Length > 0)
                MessageBox.Show("Generate Motor Para completed. Backup Motor Para \"" + BackupFileName + "\" was created.");
        }

        private void btn_GenerateRecipe_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = GDefine.MHSRecipePath;
            sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            DialogResult dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                TaskMHS.LoadRecipe("invalid");

                GDefine.MHSRecipeName = Path.GetFileNameWithoutExtension(sfd.FileName);
                try
                {
                    TaskMHS.SaveRecipe();
                }
                catch (Exception ex)
                {
                    Msg MsgBox = new Msg();
                    MsgBox.Show(ex.Message.ToString());
                }
            }
        }

        private void cbox_OutMagFrameQtyFollowInMag_Click(object sender, EventArgs e)
        {
            TaskConv.OutLevelQtyFollowIn = !TaskConv.OutLevelQtyFollowIn;
            UpdateDisplay();
        }

        private void cbInMcReadyFollowInPsntSens_Click(object sender, EventArgs e)
        {
            TaskConv.InMcReadyFollowSensInPsnt = !TaskConv.InMcReadyFollowSensInPsnt;
            UpdateDisplay();
        }

        private void cbOutMagLevelFollowInMag_Click(object sender, EventArgs e)
        {
            TaskConv.OutLevelFollowInLevel = !TaskConv.OutLevelFollowInLevel;
            UpdateDisplay();
        }
    }
}
