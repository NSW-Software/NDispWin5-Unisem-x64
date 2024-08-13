namespace NDispWin
{
    partial class frm_MHS2Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.cbox_EnableUnloadMsg = new System.Windows.Forms.CheckBox();
            this.combox_RightLineMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.combox_LeftLineMode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.cbox_EnableBlowSuck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_GenerateRecipe = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_LoadMotorPara = new System.Windows.Forms.Button();
            this.btn_GenerateMotorPara = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btb_LoadDIO = new System.Windows.Forms.Button();
            this.btn_GenDIOAdd = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbOutMagLevelFollowInMag = new System.Windows.Forms.CheckBox();
            this.cbInMcReadyFollowInPsntSens = new System.Windows.Forms.CheckBox();
            this.cbox_OutMagFrameQtyFollowInMag = new System.Windows.Forms.CheckBox();
            this.groupBox21.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox21
            // 
            this.groupBox21.AccessibleDescription = "Setup";
            this.groupBox21.AutoSize = true;
            this.groupBox21.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox21.Controls.Add(this.cbox_EnableUnloadMsg);
            this.groupBox21.Controls.Add(this.combox_RightLineMode);
            this.groupBox21.Controls.Add(this.label14);
            this.groupBox21.Controls.Add(this.combox_LeftLineMode);
            this.groupBox21.Controls.Add(this.label12);
            this.groupBox21.Location = new System.Drawing.Point(8, 49);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(509, 110);
            this.groupBox21.TabIndex = 359;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Setup";
            // 
            // cbox_EnableUnloadMsg
            // 
            this.cbox_EnableUnloadMsg.AccessibleDescription = "Enable Unload Msg";
            this.cbox_EnableUnloadMsg.AutoSize = true;
            this.cbox_EnableUnloadMsg.Location = new System.Drawing.Point(211, 71);
            this.cbox_EnableUnloadMsg.Name = "cbox_EnableUnloadMsg";
            this.cbox_EnableUnloadMsg.Size = new System.Drawing.Size(128, 18);
            this.cbox_EnableUnloadMsg.TabIndex = 355;
            this.cbox_EnableUnloadMsg.Text = "Enable Unload Msg";
            this.cbox_EnableUnloadMsg.UseVisualStyleBackColor = true;
            this.cbox_EnableUnloadMsg.Click += new System.EventHandler(this.cbox_EnableUnloadMsg_Click);
            // 
            // combox_RightLineMode
            // 
            this.combox_RightLineMode.FormattingEnabled = true;
            this.combox_RightLineMode.Location = new System.Drawing.Point(211, 43);
            this.combox_RightLineMode.Name = "combox_RightLineMode";
            this.combox_RightLineMode.Size = new System.Drawing.Size(292, 22);
            this.combox_RightLineMode.TabIndex = 335;
            this.combox_RightLineMode.SelectionChangeCommitted += new System.EventHandler(this.combox_RightLineMode_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Right Line Mode";
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 14);
            this.label14.TabIndex = 336;
            this.label14.Text = "Right Line Mode";
            // 
            // combox_LeftLineMode
            // 
            this.combox_LeftLineMode.FormattingEnabled = true;
            this.combox_LeftLineMode.Location = new System.Drawing.Point(211, 15);
            this.combox_LeftLineMode.Name = "combox_LeftLineMode";
            this.combox_LeftLineMode.Size = new System.Drawing.Size(292, 22);
            this.combox_LeftLineMode.TabIndex = 333;
            this.combox_LeftLineMode.SelectionChangeCommitted += new System.EventHandler(this.combox_LeftLineMode_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Left Line Mode";
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 14);
            this.label12.TabIndex = 334;
            this.label12.Text = "Left Line Mode";
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(733, 7);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 365;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(652, 7);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 30);
            this.btn_Save.TabIndex = 364;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cbox_EnableBlowSuck
            // 
            this.cbox_EnableBlowSuck.AccessibleDescription = "Enable Blow Suck";
            this.cbox_EnableBlowSuck.AutoSize = true;
            this.cbox_EnableBlowSuck.Location = new System.Drawing.Point(6, 22);
            this.cbox_EnableBlowSuck.Name = "cbox_EnableBlowSuck";
            this.cbox_EnableBlowSuck.Size = new System.Drawing.Size(122, 18);
            this.cbox_EnableBlowSuck.TabIndex = 366;
            this.cbox_EnableBlowSuck.Text = "Enable Blow Suck";
            this.cbox_EnableBlowSuck.UseVisualStyleBackColor = true;
            this.cbox_EnableBlowSuck.Click += new System.EventHandler(this.cbox_EnableBlowSuck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Advance";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btn_GenerateRecipe);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(247, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 231);
            this.groupBox1.TabIndex = 367;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advance";
            // 
            // btn_GenerateRecipe
            // 
            this.btn_GenerateRecipe.AccessibleDescription = "Generate Default Recipe";
            this.btn_GenerateRecipe.Location = new System.Drawing.Point(12, 21);
            this.btn_GenerateRecipe.Name = "btn_GenerateRecipe";
            this.btn_GenerateRecipe.Size = new System.Drawing.Size(120, 23);
            this.btn_GenerateRecipe.TabIndex = 3;
            this.btn_GenerateRecipe.Text = "Generate Recipe";
            this.btn_GenerateRecipe.UseVisualStyleBackColor = true;
            this.btn_GenerateRecipe.Click += new System.EventHandler(this.btn_GenerateRecipe_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "Motor Para";
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.btn_LoadMotorPara);
            this.groupBox3.Controls.Add(this.btn_GenerateMotorPara);
            this.groupBox3.Location = new System.Drawing.Point(6, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Motor Para";
            // 
            // btn_LoadMotorPara
            // 
            this.btn_LoadMotorPara.AccessibleDescription = "Load M Para";
            this.btn_LoadMotorPara.Location = new System.Drawing.Point(132, 21);
            this.btn_LoadMotorPara.Name = "btn_LoadMotorPara";
            this.btn_LoadMotorPara.Size = new System.Drawing.Size(120, 23);
            this.btn_LoadMotorPara.TabIndex = 3;
            this.btn_LoadMotorPara.Text = "Load M Para";
            this.btn_LoadMotorPara.UseVisualStyleBackColor = true;
            this.btn_LoadMotorPara.Click += new System.EventHandler(this.btn_LoadMotorPara_Click);
            // 
            // btn_GenerateMotorPara
            // 
            this.btn_GenerateMotorPara.AccessibleDescription = "Generate M Para";
            this.btn_GenerateMotorPara.Location = new System.Drawing.Point(6, 21);
            this.btn_GenerateMotorPara.Name = "btn_GenerateMotorPara";
            this.btn_GenerateMotorPara.Size = new System.Drawing.Size(120, 23);
            this.btn_GenerateMotorPara.TabIndex = 2;
            this.btn_GenerateMotorPara.Text = "Generate M Para";
            this.btn_GenerateMotorPara.UseVisualStyleBackColor = true;
            this.btn_GenerateMotorPara.Click += new System.EventHandler(this.btn_GenerateMotorPara_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "DIO Address";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.btb_LoadDIO);
            this.groupBox2.Controls.Add(this.btn_GenDIOAdd);
            this.groupBox2.Location = new System.Drawing.Point(6, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DIO Address";
            // 
            // btb_LoadDIO
            // 
            this.btb_LoadDIO.AccessibleDescription = "Load DIOAdd";
            this.btb_LoadDIO.Location = new System.Drawing.Point(132, 21);
            this.btb_LoadDIO.Name = "btb_LoadDIO";
            this.btb_LoadDIO.Size = new System.Drawing.Size(120, 23);
            this.btb_LoadDIO.TabIndex = 1;
            this.btb_LoadDIO.Text = "Load DIOAdd";
            this.btb_LoadDIO.UseVisualStyleBackColor = true;
            this.btb_LoadDIO.Click += new System.EventHandler(this.btn_LoadDIO_Click);
            // 
            // btn_GenDIOAdd
            // 
            this.btn_GenDIOAdd.AccessibleDescription = "Generate DIOAdd";
            this.btn_GenDIOAdd.Location = new System.Drawing.Point(6, 21);
            this.btn_GenDIOAdd.Name = "btn_GenDIOAdd";
            this.btn_GenDIOAdd.Size = new System.Drawing.Size(120, 23);
            this.btn_GenDIOAdd.TabIndex = 0;
            this.btn_GenDIOAdd.Text = "Generate DIOAdd";
            this.btn_GenDIOAdd.UseVisualStyleBackColor = true;
            this.btn_GenDIOAdd.Click += new System.EventHandler(this.btn_GenDIOAdd_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleDescription = "Options";
            this.groupBox4.Controls.Add(this.cbOutMagLevelFollowInMag);
            this.groupBox4.Controls.Add(this.cbInMcReadyFollowInPsntSens);
            this.groupBox4.Controls.Add(this.cbox_OutMagFrameQtyFollowInMag);
            this.groupBox4.Controls.Add(this.cbox_EnableBlowSuck);
            this.groupBox4.Location = new System.Drawing.Point(8, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 231);
            this.groupBox4.TabIndex = 368;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // cbOutMagLevelFollowInMag
            // 
            this.cbOutMagLevelFollowInMag.AccessibleDescription = "";
            this.cbOutMagLevelFollowInMag.AutoSize = true;
            this.cbOutMagLevelFollowInMag.Location = new System.Drawing.Point(6, 126);
            this.cbOutMagLevelFollowInMag.Name = "cbOutMagLevelFollowInMag";
            this.cbOutMagLevelFollowInMag.Size = new System.Drawing.Size(184, 18);
            this.cbOutMagLevelFollowInMag.TabIndex = 371;
            this.cbOutMagLevelFollowInMag.Text = "Out Mag Follow In Mag Level";
            this.cbOutMagLevelFollowInMag.UseVisualStyleBackColor = true;
            this.cbOutMagLevelFollowInMag.Click += new System.EventHandler(this.cbOutMagLevelFollowInMag_Click);
            // 
            // cbInMcReadyFollowInPsntSens
            // 
            this.cbInMcReadyFollowInPsntSens.AccessibleDescription = "";
            this.cbInMcReadyFollowInPsntSens.AutoSize = true;
            this.cbInMcReadyFollowInPsntSens.Location = new System.Drawing.Point(6, 98);
            this.cbInMcReadyFollowInPsntSens.Name = "cbInMcReadyFollowInPsntSens";
            this.cbInMcReadyFollowInPsntSens.Size = new System.Drawing.Size(192, 18);
            this.cbInMcReadyFollowInPsntSens.TabIndex = 370;
            this.cbInMcReadyFollowInPsntSens.Text = "In McReady Follow InPsntSens";
            this.cbInMcReadyFollowInPsntSens.UseVisualStyleBackColor = true;
            this.cbInMcReadyFollowInPsntSens.Click += new System.EventHandler(this.cbInMcReadyFollowInPsntSens_Click);
            // 
            // cbox_OutMagFrameQtyFollowInMag
            // 
            this.cbox_OutMagFrameQtyFollowInMag.AccessibleDescription = "Out Mag Frame Qty Follow In Mag";
            this.cbox_OutMagFrameQtyFollowInMag.AutoSize = true;
            this.cbox_OutMagFrameQtyFollowInMag.Location = new System.Drawing.Point(6, 50);
            this.cbox_OutMagFrameQtyFollowInMag.Name = "cbox_OutMagFrameQtyFollowInMag";
            this.cbox_OutMagFrameQtyFollowInMag.Size = new System.Drawing.Size(213, 18);
            this.cbox_OutMagFrameQtyFollowInMag.TabIndex = 367;
            this.cbox_OutMagFrameQtyFollowInMag.Text = "Out Mag Frame Qty Follow In Mag";
            this.cbox_OutMagFrameQtyFollowInMag.UseVisualStyleBackColor = true;
            this.cbox_OutMagFrameQtyFollowInMag.Click += new System.EventHandler(this.cbox_OutMagFrameQtyFollowInMag_Click);
            // 
            // frm_MHS2Config
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 567);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox21);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_MHS2Config";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_MHS2Config";
            this.Load += new System.EventHandler(this.frm_Config_Load);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.CheckBox cbox_EnableUnloadMsg;
        private System.Windows.Forms.ComboBox combox_RightLineMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combox_LeftLineMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.CheckBox cbox_EnableBlowSuck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GenDIOAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btb_LoadDIO;
        private System.Windows.Forms.Button btn_LoadMotorPara;
        private System.Windows.Forms.Button btn_GenerateMotorPara;
        private System.Windows.Forms.Button btn_GenerateRecipe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbox_OutMagFrameQtyFollowInMag;
        private System.Windows.Forms.CheckBox cbInMcReadyFollowInPsntSens;
        private System.Windows.Forms.CheckBox cbOutMagLevelFollowInMag;
    }
}