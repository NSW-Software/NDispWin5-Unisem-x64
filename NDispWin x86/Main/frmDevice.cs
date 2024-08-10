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
    public partial class frmDevice : Form
    {
        public frmDevice()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            
            AppLanguage.Func2.WriteLangFile(this);
        }

        public void UpdateDisplay()
        {
            lbl_Program.Text = GDefine.ProgRecipeName;

            lbl_Recipe.Text = GDefine.DeviceRecipe;
            lbl_Handler.Text = GDefine.MHSRecipeName;
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            Text = "Device Recipe";

            AppLanguage.Func2.UpdateText(this);
 
            UpdateDisplay();
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Delete Device";
            ofd.InitialDirectory = GDefine.DevicePath;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string selectedDevice = Path.GetFileNameWithoutExtension(ofd.FileName);

            if (selectedDevice == GDefine.DeviceRecipe)
            {
                Msg MsgBox = new Msg();
                MsgBox.Show("Cannot Delete Active Program.", EMcState.Notice, EMsgBtn.smbOK, false);
            }
            else
            {
                Msg MsgBox = new Msg();
                if (MsgBox.Show("Confirm Delete " + selectedDevice + "?", EMcState.Notice, EMsgBtn.smbOK_Cancel, false) == EMsgRes.smrOK)
                {
                    File.Delete(GDefine.DevicePath + "\\" + selectedDevice + "." + GDefine.DeviceRecipeExt);
                }
            }

            UpdateDisplay();
        }

        private void btnLoadDevice_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load Device";
            ofd.InitialDirectory = GDefine.DevicePath;
            ofd.Filter = "Device File|*.device";
            ofd.FileName = GDefine.DevicePath;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            Enabled = false;
            GDefine.DeviceRecipe = Path.GetFileNameWithoutExtension(ofd.FileName);
            GDefine.LoadDevice(GDefine.DeviceRecipe);
            Enabled = true;

            UpdateDisplay();
        }
        private void btnSaveDevice_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Device";
            sfd.InitialDirectory = GDefine.DevicePath;
            sfd.Filter = "Device File|*.device";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            Enabled = false;
            //GDefine.SaveDevice(GDefine.DeviceRecipe, true);
            GDefine.DeviceRecipe = Path.GetFileNameWithoutExtension(sfd.FileName);

            GDefine.SaveDevice(GDefine.DeviceRecipe, true);


            Enabled = true;

            UpdateDisplay();
        }

        private void btnLoadHandler_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load Handler";
            ofd.InitialDirectory = NDispWin.TaskMHS.RecipePath;
            ofd.Filter = "Handler File|*" + GDefine.MHSRecipeExt;
            ofd.FileName = GDefine.MHSRecipeName;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string handlerRecipe = Path.GetFileNameWithoutExtension(ofd.FileName);

            Enabled = false;
            NDispWin.TaskMHS.LoadRecipe(handlerRecipe);
            Enabled = true;
            UpdateDisplay();
        }

        private void btn_LoadProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (TaskDisp.EnableRecipeFile)
            {
                ofd.Title = "Load Recipe";
                ofd.InitialDirectory = GDefine.RecipeDir.FullName;
                ofd.Filter = "Recipe File|*.xml";
            }
            else
            {
                ofd.Title = "Load Program";
                ofd.InitialDirectory = GDefine.ProgPath;
                ofd.Filter = "Program File|*.prg";
            }
            ofd.FileName = GDefine.ProgRecipeName;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string progName = Path.GetFileNameWithoutExtension(ofd.FileName);

            Enabled = false;
            try
            {
                DispProg.LoadProgName(progName);
            }
            catch
            {
            }
            Enabled = true;
            UpdateDisplay();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
