namespace NDispWin
{
    partial class frm_MHS2ElevSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MHS2ElevSetup));
            this.lbl_LZStatus = new System.Windows.Forms.Label();
            this.btn_RightElev = new System.Windows.Forms.Button();
            this.btn_LeftElev = new System.Windows.Forms.Button();
            this.lbl_LevelDir = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Init = new System.Windows.Forms.Button();
            this.btn_Mag4 = new System.Windows.Forms.Button();
            this.btn_Mag3 = new System.Windows.Forms.Button();
            this.btn_Mag2 = new System.Windows.Forms.Button();
            this.btn_Mag1 = new System.Windows.Forms.Button();
            this.lbl_LevelPitch = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_GotoLastLevel1stMagzPos = new System.Windows.Forms.Button();
            this.btn_SetMagLastLevelPos = new System.Windows.Forms.Button();
            this.lbl_LastLevel1stMagzPos = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_LevelCount = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_PusherExt = new System.Windows.Forms.Button();
            this.lbl_MagzCount = new System.Windows.Forms.Label();
            this.btn_PusherRet = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_LoadMagPos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_GotoLoadMagzPos = new System.Windows.Forms.Button();
            this.btn_SetLoadMagzPos = new System.Windows.Forms.Button();
            this.btn_MeasureJog = new System.Windows.Forms.Button();
            this.lbl_Step = new System.Windows.Forms.Label();
            this.btn_Step = new System.Windows.Forms.Button();
            this.lbl_LULPos = new System.Windows.Forms.Label();
            this.btn_OEZN = new System.Windows.Forms.Button();
            this.btn_OEZP = new System.Windows.Forms.Button();
            this.btn_Speed = new System.Windows.Forms.Button();
            this.lbl_1stLevelPos = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_Goto1stlevelMagzPos = new System.Windows.Forms.Button();
            this.btn_Srt1sleveltMagzPos = new System.Windows.Forms.Button();
            this.lbl_BoardID = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.tmr_Measure = new System.Windows.Forms.Timer(this.components);
            this.Magazine = new System.Windows.Forms.GroupBox();
            this.gbox_Pusher = new System.Windows.Forms.GroupBox();
            this.lbl_PusherRunConv = new System.Windows.Forms.Label();
            this.lbl_PusherRetry = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_PusherTimeout = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_PusherRetDelay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_PusherExtDelay = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_PusherType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_EnableDoorSens = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.lbl_RZStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_FwdSlow = new System.Windows.Forms.Button();
            this.btn_RevSlow = new System.Windows.Forms.Button();
            this.btn_Rev = new System.Windows.Forms.Button();
            this.btn_Fwd = new System.Windows.Forms.Button();
            this.Magazine.SuspendLayout();
            this.gbox_Pusher.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_LZStatus
            // 
            this.lbl_LZStatus.AccessibleDescription = "";
            this.lbl_LZStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LZStatus.Location = new System.Drawing.Point(210, 9);
            this.lbl_LZStatus.Name = "lbl_LZStatus";
            this.lbl_LZStatus.Size = new System.Drawing.Size(120, 25);
            this.lbl_LZStatus.TabIndex = 351;
            this.lbl_LZStatus.Text = "Status";
            this.lbl_LZStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_RightElev
            // 
            this.btn_RightElev.AccessibleDescription = "Right Elev";
            this.btn_RightElev.BackColor = System.Drawing.SystemColors.Control;
            this.btn_RightElev.Location = new System.Drawing.Point(336, 37);
            this.btn_RightElev.Name = "btn_RightElev";
            this.btn_RightElev.Size = new System.Drawing.Size(120, 30);
            this.btn_RightElev.TabIndex = 350;
            this.btn_RightElev.Text = "Right Elev";
            this.btn_RightElev.UseVisualStyleBackColor = true;
            this.btn_RightElev.Click += new System.EventHandler(this.btn_RightElev_Click);
            // 
            // btn_LeftElev
            // 
            this.btn_LeftElev.AccessibleDescription = "Left Elev";
            this.btn_LeftElev.Location = new System.Drawing.Point(210, 37);
            this.btn_LeftElev.Name = "btn_LeftElev";
            this.btn_LeftElev.Size = new System.Drawing.Size(120, 30);
            this.btn_LeftElev.TabIndex = 349;
            this.btn_LeftElev.Text = "Left Elev";
            this.btn_LeftElev.UseVisualStyleBackColor = true;
            this.btn_LeftElev.Click += new System.EventHandler(this.btn_LeftElev_Click);
            // 
            // lbl_LevelDir
            // 
            this.lbl_LevelDir.BackColor = System.Drawing.Color.White;
            this.lbl_LevelDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LevelDir.Location = new System.Drawing.Point(162, 114);
            this.lbl_LevelDir.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LevelDir.Name = "lbl_LevelDir";
            this.lbl_LevelDir.Size = new System.Drawing.Size(120, 25);
            this.lbl_LevelDir.TabIndex = 361;
            this.lbl_LevelDir.Text = "---";
            this.lbl_LevelDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LevelDir.Click += new System.EventHandler(this.lbl_LevelDir_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Level Dir (mm)";
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 360;
            this.label3.Text = "Level Dir (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Init
            // 
            this.btn_Init.AccessibleDescription = "Init";
            this.btn_Init.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Init.Location = new System.Drawing.Point(462, 37);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(120, 30);
            this.btn_Init.TabIndex = 358;
            this.btn_Init.Text = "Init";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // btn_Mag4
            // 
            this.btn_Mag4.AccessibleDescription = "Magazine 4";
            this.btn_Mag4.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Mag4.Location = new System.Drawing.Point(324, 185);
            this.btn_Mag4.Name = "btn_Mag4";
            this.btn_Mag4.Size = new System.Drawing.Size(100, 40);
            this.btn_Mag4.TabIndex = 357;
            this.btn_Mag4.Text = "Magazine 4";
            this.btn_Mag4.UseVisualStyleBackColor = true;
            this.btn_Mag4.Click += new System.EventHandler(this.btn_Mag4_Click);
            // 
            // btn_Mag3
            // 
            this.btn_Mag3.AccessibleDescription = "Magazine 3";
            this.btn_Mag3.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Mag3.Location = new System.Drawing.Point(218, 185);
            this.btn_Mag3.Name = "btn_Mag3";
            this.btn_Mag3.Size = new System.Drawing.Size(100, 40);
            this.btn_Mag3.TabIndex = 356;
            this.btn_Mag3.Text = "Magazine 3";
            this.btn_Mag3.UseVisualStyleBackColor = true;
            this.btn_Mag3.Click += new System.EventHandler(this.btn_Mag3_Click);
            // 
            // btn_Mag2
            // 
            this.btn_Mag2.AccessibleDescription = "Magazine 2";
            this.btn_Mag2.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Mag2.Location = new System.Drawing.Point(112, 185);
            this.btn_Mag2.Name = "btn_Mag2";
            this.btn_Mag2.Size = new System.Drawing.Size(100, 40);
            this.btn_Mag2.TabIndex = 355;
            this.btn_Mag2.Text = "Magazine 2";
            this.btn_Mag2.UseVisualStyleBackColor = true;
            this.btn_Mag2.Click += new System.EventHandler(this.btn_Mag2_Click);
            // 
            // btn_Mag1
            // 
            this.btn_Mag1.AccessibleDescription = "Magazine 1";
            this.btn_Mag1.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Mag1.Location = new System.Drawing.Point(6, 185);
            this.btn_Mag1.Name = "btn_Mag1";
            this.btn_Mag1.Size = new System.Drawing.Size(100, 40);
            this.btn_Mag1.TabIndex = 354;
            this.btn_Mag1.Text = "Magazine 1";
            this.btn_Mag1.UseVisualStyleBackColor = true;
            this.btn_Mag1.Click += new System.EventHandler(this.btn_Mag1_Click);
            // 
            // lbl_LevelPitch
            // 
            this.lbl_LevelPitch.BackColor = System.Drawing.Color.White;
            this.lbl_LevelPitch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LevelPitch.Location = new System.Drawing.Point(162, 83);
            this.lbl_LevelPitch.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LevelPitch.Name = "lbl_LevelPitch";
            this.lbl_LevelPitch.Size = new System.Drawing.Size(120, 25);
            this.lbl_LevelPitch.TabIndex = 353;
            this.lbl_LevelPitch.Text = "---";
            this.lbl_LevelPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LevelPitch.Click += new System.EventHandler(this.lbl_LevelPitch_Click);
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "Level Pitch (mm)";
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(6, 83);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 25);
            this.label16.TabIndex = 352;
            this.label16.Text = "Level Pitch (mm)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GotoLastLevel1stMagzPos
            // 
            this.btn_GotoLastLevel1stMagzPos.AccessibleDescription = "Goto";
            this.btn_GotoLastLevel1stMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GotoLastLevel1stMagzPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GotoLastLevel1stMagzPos.Location = new System.Drawing.Point(381, 273);
            this.btn_GotoLastLevel1stMagzPos.Name = "btn_GotoLastLevel1stMagzPos";
            this.btn_GotoLastLevel1stMagzPos.Size = new System.Drawing.Size(87, 33);
            this.btn_GotoLastLevel1stMagzPos.TabIndex = 351;
            this.btn_GotoLastLevel1stMagzPos.Text = "Goto";
            this.btn_GotoLastLevel1stMagzPos.UseVisualStyleBackColor = true;
            this.btn_GotoLastLevel1stMagzPos.Click += new System.EventHandler(this.btn_GotoMagLastLevelPos_Click);
            // 
            // btn_SetMagLastLevelPos
            // 
            this.btn_SetMagLastLevelPos.AccessibleDescription = "Set";
            this.btn_SetMagLastLevelPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SetMagLastLevelPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_SetMagLastLevelPos.Location = new System.Drawing.Point(288, 273);
            this.btn_SetMagLastLevelPos.Name = "btn_SetMagLastLevelPos";
            this.btn_SetMagLastLevelPos.Size = new System.Drawing.Size(87, 33);
            this.btn_SetMagLastLevelPos.TabIndex = 350;
            this.btn_SetMagLastLevelPos.Text = "Set";
            this.btn_SetMagLastLevelPos.UseVisualStyleBackColor = true;
            this.btn_SetMagLastLevelPos.Click += new System.EventHandler(this.btn_SetMagLastLevelPos_Click);
            // 
            // lbl_LastLevel1stMagzPos
            // 
            this.lbl_LastLevel1stMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_LastLevel1stMagzPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LastLevel1stMagzPos.Location = new System.Drawing.Point(162, 277);
            this.lbl_LastLevel1stMagzPos.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LastLevel1stMagzPos.Name = "lbl_LastLevel1stMagzPos";
            this.lbl_LastLevel1stMagzPos.Size = new System.Drawing.Size(120, 25);
            this.lbl_LastLevel1stMagzPos.TabIndex = 349;
            this.lbl_LastLevel1stMagzPos.Text = "---";
            this.lbl_LastLevel1stMagzPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "Last Level";
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(6, 277);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 25);
            this.label17.TabIndex = 348;
            this.label17.Text = "Last Level";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_LevelCount
            // 
            this.lbl_LevelCount.BackColor = System.Drawing.Color.White;
            this.lbl_LevelCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LevelCount.Location = new System.Drawing.Point(162, 52);
            this.lbl_LevelCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LevelCount.Name = "lbl_LevelCount";
            this.lbl_LevelCount.Size = new System.Drawing.Size(120, 25);
            this.lbl_LevelCount.TabIndex = 334;
            this.lbl_LevelCount.Text = "---";
            this.lbl_LevelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LevelCount.Click += new System.EventHandler(this.lbl_LevelCount_Click);
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "Level Count";
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Location = new System.Drawing.Point(6, 52);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(150, 25);
            this.label21.TabIndex = 333;
            this.label21.Text = "Level Count";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_PusherExt
            // 
            this.btn_PusherExt.AccessibleDescription = "Pusher >>";
            this.btn_PusherExt.BackColor = System.Drawing.SystemColors.Control;
            this.btn_PusherExt.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_PusherExt.Location = new System.Drawing.Point(102, 216);
            this.btn_PusherExt.Name = "btn_PusherExt";
            this.btn_PusherExt.Size = new System.Drawing.Size(90, 43);
            this.btn_PusherExt.TabIndex = 338;
            this.btn_PusherExt.Text = "Pusher >>";
            this.btn_PusherExt.UseVisualStyleBackColor = true;
            this.btn_PusherExt.Click += new System.EventHandler(this.btn_PusherExt_Click);
            // 
            // lbl_MagzCount
            // 
            this.lbl_MagzCount.BackColor = System.Drawing.Color.White;
            this.lbl_MagzCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MagzCount.Location = new System.Drawing.Point(162, 21);
            this.lbl_MagzCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MagzCount.Name = "lbl_MagzCount";
            this.lbl_MagzCount.Size = new System.Drawing.Size(120, 25);
            this.lbl_MagzCount.TabIndex = 332;
            this.lbl_MagzCount.Text = "---";
            this.lbl_MagzCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MagzCount.Click += new System.EventHandler(this.lbl_MagzCount_Click);
            // 
            // btn_PusherRet
            // 
            this.btn_PusherRet.AccessibleDescription = "<< Pusher";
            this.btn_PusherRet.BackColor = System.Drawing.SystemColors.Control;
            this.btn_PusherRet.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_PusherRet.Location = new System.Drawing.Point(6, 216);
            this.btn_PusherRet.Name = "btn_PusherRet";
            this.btn_PusherRet.Size = new System.Drawing.Size(90, 43);
            this.btn_PusherRet.TabIndex = 337;
            this.btn_PusherRet.Text = "<< Pusher";
            this.btn_PusherRet.UseVisualStyleBackColor = true;
            this.btn_PusherRet.Click += new System.EventHandler(this.btn_PusherRet_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Magazine Count";
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(6, 21);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 25);
            this.label19.TabIndex = 331;
            this.label19.Text = "Magazine Count";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_LoadMagPos
            // 
            this.lbl_LoadMagPos.BackColor = System.Drawing.Color.White;
            this.lbl_LoadMagPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LoadMagPos.Location = new System.Drawing.Point(162, 145);
            this.lbl_LoadMagPos.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_LoadMagPos.Name = "lbl_LoadMagPos";
            this.lbl_LoadMagPos.Size = new System.Drawing.Size(120, 25);
            this.lbl_LoadMagPos.TabIndex = 347;
            this.lbl_LoadMagPos.Text = "---";
            this.lbl_LoadMagPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LoadMagPos.Click += new System.EventHandler(this.lbl_LoadMagzPos_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Mag Load Pos (mm)";
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(6, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 346;
            this.label7.Text = "Mag Load Pos (mm)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GotoLoadMagzPos
            // 
            this.btn_GotoLoadMagzPos.AccessibleDescription = "Goto";
            this.btn_GotoLoadMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GotoLoadMagzPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GotoLoadMagzPos.Location = new System.Drawing.Point(381, 141);
            this.btn_GotoLoadMagzPos.Name = "btn_GotoLoadMagzPos";
            this.btn_GotoLoadMagzPos.Size = new System.Drawing.Size(87, 33);
            this.btn_GotoLoadMagzPos.TabIndex = 345;
            this.btn_GotoLoadMagzPos.Text = "Goto";
            this.btn_GotoLoadMagzPos.UseVisualStyleBackColor = true;
            this.btn_GotoLoadMagzPos.Click += new System.EventHandler(this.btn_GotoLoadMagzPos_Click);
            // 
            // btn_SetLoadMagzPos
            // 
            this.btn_SetLoadMagzPos.AccessibleDescription = "Set";
            this.btn_SetLoadMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SetLoadMagzPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_SetLoadMagzPos.Location = new System.Drawing.Point(288, 141);
            this.btn_SetLoadMagzPos.Name = "btn_SetLoadMagzPos";
            this.btn_SetLoadMagzPos.Size = new System.Drawing.Size(87, 33);
            this.btn_SetLoadMagzPos.TabIndex = 344;
            this.btn_SetLoadMagzPos.Text = "Set";
            this.btn_SetLoadMagzPos.UseVisualStyleBackColor = true;
            this.btn_SetLoadMagzPos.Click += new System.EventHandler(this.btn_SetLoadMagzPos_Click);
            // 
            // btn_MeasureJog
            // 
            this.btn_MeasureJog.AccessibleDescription = "Measure";
            this.btn_MeasureJog.Location = new System.Drawing.Point(6, 49);
            this.btn_MeasureJog.Name = "btn_MeasureJog";
            this.btn_MeasureJog.Size = new System.Drawing.Size(120, 33);
            this.btn_MeasureJog.TabIndex = 337;
            this.btn_MeasureJog.Text = "MEASURE";
            this.btn_MeasureJog.UseVisualStyleBackColor = true;
            this.btn_MeasureJog.Click += new System.EventHandler(this.btn_MeasureJog_Click);
            // 
            // lbl_Step
            // 
            this.lbl_Step.BackColor = System.Drawing.Color.White;
            this.lbl_Step.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Step.Location = new System.Drawing.Point(68, 85);
            this.lbl_Step.Name = "lbl_Step";
            this.lbl_Step.Size = new System.Drawing.Size(58, 33);
            this.lbl_Step.TabIndex = 336;
            this.lbl_Step.Text = "---";
            this.lbl_Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Step.Click += new System.EventHandler(this.lbl_Step_Click);
            // 
            // btn_Step
            // 
            this.btn_Step.AccessibleDescription = "Step";
            this.btn_Step.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Step.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Step.Location = new System.Drawing.Point(6, 85);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(56, 33);
            this.btn_Step.TabIndex = 335;
            this.btn_Step.Text = "Step";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // lbl_LULPos
            // 
            this.lbl_LULPos.BackColor = System.Drawing.Color.Black;
            this.lbl_LULPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LULPos.Location = new System.Drawing.Point(6, 18);
            this.lbl_LULPos.Name = "lbl_LULPos";
            this.lbl_LULPos.Size = new System.Drawing.Size(120, 33);
            this.lbl_LULPos.TabIndex = 333;
            this.lbl_LULPos.Text = "-";
            this.lbl_LULPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OEZN
            // 
            this.btn_OEZN.BackColor = System.Drawing.Color.White;
            this.btn_OEZN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_OEZN.FlatAppearance.BorderSize = 2;
            this.btn_OEZN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_OEZN.Image = ((System.Drawing.Image)(resources.GetObject("btn_OEZN.Image")));
            this.btn_OEZN.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_OEZN.Location = new System.Drawing.Point(132, 150);
            this.btn_OEZN.Name = "btn_OEZN";
            this.btn_OEZN.Size = new System.Drawing.Size(60, 60);
            this.btn_OEZN.TabIndex = 323;
            this.btn_OEZN.Text = "RZ";
            this.btn_OEZN.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_OEZN.UseVisualStyleBackColor = true;
            this.btn_OEZN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_OEZN_MouseDown);
            this.btn_OEZN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_OEZN_MouseUp);
            // 
            // btn_OEZP
            // 
            this.btn_OEZP.BackColor = System.Drawing.Color.White;
            this.btn_OEZP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_OEZP.FlatAppearance.BorderSize = 2;
            this.btn_OEZP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_OEZP.Image = ((System.Drawing.Image)(resources.GetObject("btn_OEZP.Image")));
            this.btn_OEZP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_OEZP.Location = new System.Drawing.Point(132, 18);
            this.btn_OEZP.Name = "btn_OEZP";
            this.btn_OEZP.Size = new System.Drawing.Size(60, 60);
            this.btn_OEZP.TabIndex = 322;
            this.btn_OEZP.Text = "RZ";
            this.btn_OEZP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_OEZP.UseVisualStyleBackColor = true;
            this.btn_OEZP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_OEZP_MouseDown);
            this.btn_OEZP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_OEZP_MouseUp);
            // 
            // btn_Speed
            // 
            this.btn_Speed.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Speed.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Speed.Location = new System.Drawing.Point(132, 84);
            this.btn_Speed.Name = "btn_Speed";
            this.btn_Speed.Size = new System.Drawing.Size(60, 60);
            this.btn_Speed.TabIndex = 321;
            this.btn_Speed.Text = "Slow";
            this.btn_Speed.UseVisualStyleBackColor = true;
            this.btn_Speed.Click += new System.EventHandler(this.btn_Speed_Click);
            // 
            // lbl_1stLevelPos
            // 
            this.lbl_1stLevelPos.BackColor = System.Drawing.Color.White;
            this.lbl_1stLevelPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_1stLevelPos.Location = new System.Drawing.Point(162, 238);
            this.lbl_1stLevelPos.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_1stLevelPos.Name = "lbl_1stLevelPos";
            this.lbl_1stLevelPos.Size = new System.Drawing.Size(120, 25);
            this.lbl_1stLevelPos.TabIndex = 302;
            this.lbl_1stLevelPos.Text = "---";
            this.lbl_1stLevelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_1stLevelPos.Click += new System.EventHandler(this.lbl_1stLevelPos_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "1st Level";
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(6, 238);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 25);
            this.label15.TabIndex = 301;
            this.label15.Text = "1st Level";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Goto1stlevelMagzPos
            // 
            this.btn_Goto1stlevelMagzPos.AccessibleDescription = "Goto";
            this.btn_Goto1stlevelMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Goto1stlevelMagzPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Goto1stlevelMagzPos.Location = new System.Drawing.Point(381, 234);
            this.btn_Goto1stlevelMagzPos.Name = "btn_Goto1stlevelMagzPos";
            this.btn_Goto1stlevelMagzPos.Size = new System.Drawing.Size(87, 33);
            this.btn_Goto1stlevelMagzPos.TabIndex = 320;
            this.btn_Goto1stlevelMagzPos.Text = "Goto";
            this.btn_Goto1stlevelMagzPos.UseVisualStyleBackColor = true;
            this.btn_Goto1stlevelMagzPos.Click += new System.EventHandler(this.btn_GotoMagFirstLevelPos_Click);
            // 
            // btn_Srt1sleveltMagzPos
            // 
            this.btn_Srt1sleveltMagzPos.AccessibleDescription = "Set";
            this.btn_Srt1sleveltMagzPos.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Srt1sleveltMagzPos.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Srt1sleveltMagzPos.Location = new System.Drawing.Point(288, 234);
            this.btn_Srt1sleveltMagzPos.Name = "btn_Srt1sleveltMagzPos";
            this.btn_Srt1sleveltMagzPos.Size = new System.Drawing.Size(87, 33);
            this.btn_Srt1sleveltMagzPos.TabIndex = 319;
            this.btn_Srt1sleveltMagzPos.Text = "Set";
            this.btn_Srt1sleveltMagzPos.UseVisualStyleBackColor = true;
            this.btn_Srt1sleveltMagzPos.Click += new System.EventHandler(this.btn_SetMagFirstLevelPos_Click);
            // 
            // lbl_BoardID
            // 
            this.lbl_BoardID.AccessibleDescription = "";
            this.lbl_BoardID.BackColor = System.Drawing.Color.Red;
            this.lbl_BoardID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_BoardID.Location = new System.Drawing.Point(8, 8);
            this.lbl_BoardID.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_BoardID.Name = "lbl_BoardID";
            this.lbl_BoardID.Size = new System.Drawing.Size(120, 26);
            this.lbl_BoardID.TabIndex = 140;
            this.lbl_BoardID.Text = "Board ID0";
            this.lbl_BoardID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Location = new System.Drawing.Point(630, 8);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(70, 30);
            this.btn_Save.TabIndex = 363;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.Location = new System.Drawing.Point(706, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 30);
            this.btn_Close.TabIndex = 362;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // tmr_Measure
            // 
            this.tmr_Measure.Enabled = true;
            this.tmr_Measure.Tick += new System.EventHandler(this.tmr_Measure_Tick);
            // 
            // Magazine
            // 
            this.Magazine.AccessibleDescription = "Magazine";
            this.Magazine.AutoSize = true;
            this.Magazine.Controls.Add(this.btn_Mag1);
            this.Magazine.Controls.Add(this.btn_Mag2);
            this.Magazine.Controls.Add(this.btn_Mag3);
            this.Magazine.Controls.Add(this.btn_Mag4);
            this.Magazine.Controls.Add(this.btn_Srt1sleveltMagzPos);
            this.Magazine.Controls.Add(this.btn_GotoLastLevel1stMagzPos);
            this.Magazine.Controls.Add(this.lbl_LevelDir);
            this.Magazine.Controls.Add(this.lbl_LastLevel1stMagzPos);
            this.Magazine.Controls.Add(this.lbl_1stLevelPos);
            this.Magazine.Controls.Add(this.label15);
            this.Magazine.Controls.Add(this.btn_SetMagLastLevelPos);
            this.Magazine.Controls.Add(this.label3);
            this.Magazine.Controls.Add(this.lbl_LevelCount);
            this.Magazine.Controls.Add(this.label17);
            this.Magazine.Controls.Add(this.btn_Goto1stlevelMagzPos);
            this.Magazine.Controls.Add(this.label7);
            this.Magazine.Controls.Add(this.lbl_LoadMagPos);
            this.Magazine.Controls.Add(this.btn_GotoLoadMagzPos);
            this.Magazine.Controls.Add(this.label21);
            this.Magazine.Controls.Add(this.btn_SetLoadMagzPos);
            this.Magazine.Controls.Add(this.label16);
            this.Magazine.Controls.Add(this.label19);
            this.Magazine.Controls.Add(this.lbl_LevelPitch);
            this.Magazine.Controls.Add(this.lbl_MagzCount);
            this.Magazine.Location = new System.Drawing.Point(8, 73);
            this.Magazine.Name = "Magazine";
            this.Magazine.Size = new System.Drawing.Size(484, 327);
            this.Magazine.TabIndex = 365;
            this.Magazine.TabStop = false;
            this.Magazine.Text = "Magazine";
            // 
            // gbox_Pusher
            // 
            this.gbox_Pusher.AccessibleDescription = "Pusher";
            this.gbox_Pusher.AutoSize = true;
            this.gbox_Pusher.Controls.Add(this.lbl_PusherRunConv);
            this.gbox_Pusher.Controls.Add(this.lbl_PusherRetry);
            this.gbox_Pusher.Controls.Add(this.label8);
            this.gbox_Pusher.Controls.Add(this.label11);
            this.gbox_Pusher.Controls.Add(this.lbl_PusherTimeout);
            this.gbox_Pusher.Controls.Add(this.label9);
            this.gbox_Pusher.Controls.Add(this.lbl_PusherRetDelay);
            this.gbox_Pusher.Controls.Add(this.label6);
            this.gbox_Pusher.Controls.Add(this.lbl_PusherExtDelay);
            this.gbox_Pusher.Controls.Add(this.label4);
            this.gbox_Pusher.Controls.Add(this.lbl_PusherType);
            this.gbox_Pusher.Controls.Add(this.label2);
            this.gbox_Pusher.Location = new System.Drawing.Point(8, 406);
            this.gbox_Pusher.Name = "gbox_Pusher";
            this.gbox_Pusher.Size = new System.Drawing.Size(484, 138);
            this.gbox_Pusher.TabIndex = 366;
            this.gbox_Pusher.TabStop = false;
            this.gbox_Pusher.Text = "Pusher";
            // 
            // lbl_PusherRunConv
            // 
            this.lbl_PusherRunConv.BackColor = System.Drawing.Color.White;
            this.lbl_PusherRunConv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherRunConv.Location = new System.Drawing.Point(399, 83);
            this.lbl_PusherRunConv.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherRunConv.Name = "lbl_PusherRunConv";
            this.lbl_PusherRunConv.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherRunConv.TabIndex = 367;
            this.lbl_PusherRunConv.Text = "---";
            this.lbl_PusherRunConv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherRunConv.Click += new System.EventHandler(this.lbl_RunConveyor_Click);
            // 
            // lbl_PusherRetry
            // 
            this.lbl_PusherRetry.BackColor = System.Drawing.Color.White;
            this.lbl_PusherRetry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherRetry.Location = new System.Drawing.Point(399, 52);
            this.lbl_PusherRetry.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherRetry.Name = "lbl_PusherRetry";
            this.lbl_PusherRetry.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherRetry.TabIndex = 371;
            this.lbl_PusherRetry.Text = "---";
            this.lbl_PusherRetry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherRetry.Click += new System.EventHandler(this.lbl_PusherRetry_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Pusher Run Conv";
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(243, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 25);
            this.label8.TabIndex = 366;
            this.label8.Text = "Pusher Run Conv";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Pusher Retry";
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(243, 52);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 25);
            this.label11.TabIndex = 370;
            this.label11.Text = "Pusher Retry";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PusherTimeout
            // 
            this.lbl_PusherTimeout.BackColor = System.Drawing.Color.White;
            this.lbl_PusherTimeout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherTimeout.Location = new System.Drawing.Point(399, 21);
            this.lbl_PusherTimeout.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherTimeout.Name = "lbl_PusherTimeout";
            this.lbl_PusherTimeout.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherTimeout.TabIndex = 369;
            this.lbl_PusherTimeout.Text = "---";
            this.lbl_PusherTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherTimeout.Click += new System.EventHandler(this.lbl_PusherTimeout_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Pusher Timeout (ms)";
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(243, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 25);
            this.label9.TabIndex = 368;
            this.label9.Text = "Pusher Timeout (ms)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PusherRetDelay
            // 
            this.lbl_PusherRetDelay.BackColor = System.Drawing.Color.White;
            this.lbl_PusherRetDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherRetDelay.Location = new System.Drawing.Point(162, 83);
            this.lbl_PusherRetDelay.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherRetDelay.Name = "lbl_PusherRetDelay";
            this.lbl_PusherRetDelay.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherRetDelay.TabIndex = 367;
            this.lbl_PusherRetDelay.Text = "---";
            this.lbl_PusherRetDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherRetDelay.Click += new System.EventHandler(this.lbl_PusherRetDelay_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Pusher Ret Delay (ms)";
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 25);
            this.label6.TabIndex = 366;
            this.label6.Text = "Pusher Ret Delay (ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PusherExtDelay
            // 
            this.lbl_PusherExtDelay.BackColor = System.Drawing.Color.White;
            this.lbl_PusherExtDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherExtDelay.Location = new System.Drawing.Point(162, 52);
            this.lbl_PusherExtDelay.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherExtDelay.Name = "lbl_PusherExtDelay";
            this.lbl_PusherExtDelay.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherExtDelay.TabIndex = 365;
            this.lbl_PusherExtDelay.Text = "---";
            this.lbl_PusherExtDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherExtDelay.Click += new System.EventHandler(this.lbl_PusherExtDelay_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Pusher Ext Delay (ms)";
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 364;
            this.label4.Text = "Pusher Ext Delay (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PusherType
            // 
            this.lbl_PusherType.BackColor = System.Drawing.Color.White;
            this.lbl_PusherType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PusherType.Location = new System.Drawing.Point(162, 21);
            this.lbl_PusherType.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PusherType.Name = "lbl_PusherType";
            this.lbl_PusherType.Size = new System.Drawing.Size(75, 25);
            this.lbl_PusherType.TabIndex = 363;
            this.lbl_PusherType.Text = "---";
            this.lbl_PusherType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PusherType.Click += new System.EventHandler(this.lbl_PusherType_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Pusher Type";
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 362;
            this.label2.Text = "Pusher Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Options";
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.lbl_EnableDoorSens);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(498, 438);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 106);
            this.groupBox2.TabIndex = 367;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // lbl_EnableDoorSens
            // 
            this.lbl_EnableDoorSens.BackColor = System.Drawing.Color.White;
            this.lbl_EnableDoorSens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_EnableDoorSens.Location = new System.Drawing.Point(162, 21);
            this.lbl_EnableDoorSens.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_EnableDoorSens.Name = "lbl_EnableDoorSens";
            this.lbl_EnableDoorSens.Size = new System.Drawing.Size(75, 25);
            this.lbl_EnableDoorSens.TabIndex = 365;
            this.lbl_EnableDoorSens.Text = "---";
            this.lbl_EnableDoorSens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_EnableDoorSens.Click += new System.EventHandler(this.lbl_EnableDoorSens_Click);
            this.lbl_EnableDoorSens.MouseHover += new System.EventHandler(this.lbl_EnableDoorSens_MouseHover);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Enable Door Sens";
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 364;
            this.label5.Text = "Enable Door Sens";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Open
            // 
            this.btn_Open.AccessibleDescription = "Open";
            this.btn_Open.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Open.Location = new System.Drawing.Point(134, 6);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(70, 30);
            this.btn_Open.TabIndex = 368;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // lbl_RZStatus
            // 
            this.lbl_RZStatus.AccessibleDescription = "";
            this.lbl_RZStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RZStatus.Location = new System.Drawing.Point(336, 8);
            this.lbl_RZStatus.Name = "lbl_RZStatus";
            this.lbl_RZStatus.Size = new System.Drawing.Size(120, 25);
            this.lbl_RZStatus.TabIndex = 369;
            this.lbl_RZStatus.Text = "Status";
            this.lbl_RZStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lbl_LULPos);
            this.groupBox3.Controls.Add(this.lbl_Step);
            this.groupBox3.Controls.Add(this.btn_MeasureJog);
            this.groupBox3.Controls.Add(this.btn_PusherExt);
            this.groupBox3.Controls.Add(this.btn_Step);
            this.groupBox3.Controls.Add(this.btn_PusherRet);
            this.groupBox3.Controls.Add(this.btn_OEZN);
            this.groupBox3.Controls.Add(this.btn_OEZP);
            this.groupBox3.Controls.Add(this.btn_Speed);
            this.groupBox3.Location = new System.Drawing.Point(498, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 280);
            this.groupBox3.TabIndex = 370;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Jog";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Conveyor";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btn_FwdSlow);
            this.groupBox1.Controls.Add(this.btn_RevSlow);
            this.groupBox1.Controls.Add(this.btn_Rev);
            this.groupBox1.Controls.Add(this.btn_Fwd);
            this.groupBox1.Location = new System.Drawing.Point(500, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 72);
            this.groupBox1.TabIndex = 339;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conveyor";
            // 
            // btn_FwdSlow
            // 
            this.btn_FwdSlow.AccessibleDescription = "";
            this.btn_FwdSlow.Location = new System.Drawing.Point(128, 20);
            this.btn_FwdSlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_FwdSlow.Name = "btn_FwdSlow";
            this.btn_FwdSlow.Size = new System.Drawing.Size(55, 32);
            this.btn_FwdSlow.TabIndex = 373;
            this.btn_FwdSlow.Text = ">";
            this.btn_FwdSlow.UseVisualStyleBackColor = true;
            this.btn_FwdSlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_FwdSlow_MouseDown);
            this.btn_FwdSlow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_FwdSlow_MouseUp);
            // 
            // btn_RevSlow
            // 
            this.btn_RevSlow.AccessibleDescription = "";
            this.btn_RevSlow.Location = new System.Drawing.Point(67, 20);
            this.btn_RevSlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_RevSlow.Name = "btn_RevSlow";
            this.btn_RevSlow.Size = new System.Drawing.Size(55, 32);
            this.btn_RevSlow.TabIndex = 372;
            this.btn_RevSlow.Text = "<";
            this.btn_RevSlow.UseVisualStyleBackColor = true;
            this.btn_RevSlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_RevSlow_MouseDown);
            this.btn_RevSlow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_RevSlow_MouseUp);
            // 
            // btn_Rev
            // 
            this.btn_Rev.AccessibleDescription = "";
            this.btn_Rev.Location = new System.Drawing.Point(6, 20);
            this.btn_Rev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Rev.Name = "btn_Rev";
            this.btn_Rev.Size = new System.Drawing.Size(55, 32);
            this.btn_Rev.TabIndex = 371;
            this.btn_Rev.Text = "<<<";
            this.btn_Rev.UseVisualStyleBackColor = true;
            this.btn_Rev.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Rev_MouseDown);
            this.btn_Rev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Rev_MouseUp);
            // 
            // btn_Fwd
            // 
            this.btn_Fwd.AccessibleDescription = "";
            this.btn_Fwd.Location = new System.Drawing.Point(189, 20);
            this.btn_Fwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Fwd.Name = "btn_Fwd";
            this.btn_Fwd.Size = new System.Drawing.Size(55, 32);
            this.btn_Fwd.TabIndex = 370;
            this.btn_Fwd.Text = ">>>";
            this.btn_Fwd.UseVisualStyleBackColor = true;
            this.btn_Fwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Fwd_MouseDown);
            this.btn_Fwd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Fwd_MouseUp);
            // 
            // frm_MHS2ElevSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_RZStatus);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbox_Pusher);
            this.Controls.Add(this.Magazine);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_BoardID);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.lbl_LZStatus);
            this.Controls.Add(this.btn_LeftElev);
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.btn_RightElev);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_MHS2ElevSetup";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_MHS2ElevSetup";
            this.Load += new System.EventHandler(this.frm_ElevSetup_Load);
            this.Magazine.ResumeLayout(false);
            this.gbox_Pusher.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LZStatus;
        private System.Windows.Forms.Button btn_RightElev;
        private System.Windows.Forms.Button btn_LeftElev;
        private System.Windows.Forms.Label lbl_LevelDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.Button btn_Mag4;
        private System.Windows.Forms.Button btn_Mag3;
        private System.Windows.Forms.Button btn_Mag2;
        private System.Windows.Forms.Button btn_Mag1;
        private System.Windows.Forms.Label lbl_LevelPitch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_GotoLastLevel1stMagzPos;
        private System.Windows.Forms.Button btn_SetMagLastLevelPos;
        private System.Windows.Forms.Label lbl_LastLevel1stMagzPos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_LevelCount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_PusherExt;
        private System.Windows.Forms.Label lbl_MagzCount;
        private System.Windows.Forms.Button btn_PusherRet;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_LoadMagPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_GotoLoadMagzPos;
        private System.Windows.Forms.Button btn_SetLoadMagzPos;
        private System.Windows.Forms.Button btn_MeasureJog;
        private System.Windows.Forms.Label lbl_Step;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.Label lbl_LULPos;
        private System.Windows.Forms.Button btn_OEZN;
        private System.Windows.Forms.Button btn_OEZP;
        private System.Windows.Forms.Button btn_Speed;
        private System.Windows.Forms.Label lbl_1stLevelPos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_Goto1stlevelMagzPos;
        private System.Windows.Forms.Button btn_Srt1sleveltMagzPos;
        private System.Windows.Forms.Label lbl_BoardID;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Timer tmr_Measure;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox Magazine;
        private System.Windows.Forms.GroupBox gbox_Pusher;
        private System.Windows.Forms.Label lbl_PusherType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_PusherRetry;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_PusherTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_PusherRetDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_PusherExtDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_EnableDoorSens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Label lbl_RZStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_FwdSlow;
        private System.Windows.Forms.Button btn_RevSlow;
        private System.Windows.Forms.Button btn_Rev;
        private System.Windows.Forms.Button btn_Fwd;
        private System.Windows.Forms.Label lbl_PusherRunConv;
        private System.Windows.Forms.Label label8;
    }
}