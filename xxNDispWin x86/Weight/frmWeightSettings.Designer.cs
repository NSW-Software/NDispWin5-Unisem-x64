namespace NDispWin
{
    partial class frmWeightSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnJog = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btn_GotoNeedleWeightPos = new System.Windows.Forms.Button();
            this.btn_SetNeedle2WeightPos = new System.Windows.Forms.Button();
            this.btn_SetNeedleWeightPos = new System.Windows.Forms.Button();
            this.btn_GotoNeedle2WeightPos = new System.Windows.Forms.Button();
            this.lbl_Needle1WeightPosXYZ = new System.Windows.Forms.Label();
            this.lbl_Needle2WeightPosZ2 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoOfPurge = new System.Windows.Forms.Label();
            this.lblCleanOnStart = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lblMeasPosCount = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lbl_MeasPCD = new System.Windows.Forms.Label();
            this.lblMeasPosPCD = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lblMeasPosMthd = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lblZUpSpeed = new System.Windows.Forms.Label();
            this.lblZUpDist = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblWeightPostWaitTime = new System.Windows.Forms.Label();
            this.lblStartMeasDelay = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblWeightPreWaitTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEndMeasDelay = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = "Save";
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(225, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 32);
            this.btnSave.TabIndex = 207;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "Close";
            this.btnClose.Location = new System.Drawing.Point(398, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 32);
            this.btnClose.TabIndex = 206;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnJog
            // 
            this.btnJog.AccessibleDescription = "Jog";
            this.btnJog.Location = new System.Drawing.Point(311, 5);
            this.btnJog.Margin = new System.Windows.Forms.Padding(2);
            this.btnJog.Name = "btnJog";
            this.btnJog.Size = new System.Drawing.Size(82, 32);
            this.btnJog.TabIndex = 208;
            this.btnJog.Text = "Jog";
            this.btnJog.UseVisualStyleBackColor = true;
            this.btnJog.Click += new System.EventHandler(this.btnJog_Click);
            // 
            // label42
            // 
            this.label42.AccessibleDescription = "Z2 (mm)";
            this.label42.Location = new System.Drawing.Point(5, 89);
            this.label42.Margin = new System.Windows.Forms.Padding(2);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(82, 25);
            this.label42.TabIndex = 222;
            this.label42.Text = "Z2 (mm)";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.AccessibleDescription = "Head 1";
            this.label32.Location = new System.Drawing.Point(5, 5);
            this.label32.Margin = new System.Windows.Forms.Padding(2);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 25);
            this.label32.TabIndex = 213;
            this.label32.Text = "Head 1";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.AccessibleDescription = "XYZ (mm)";
            this.label41.Location = new System.Drawing.Point(5, 34);
            this.label41.Margin = new System.Windows.Forms.Padding(2);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(82, 25);
            this.label41.TabIndex = 221;
            this.label41.Text = "XYZ (mm)";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_GotoNeedleWeightPos
            // 
            this.btn_GotoNeedleWeightPos.AccessibleDescription = "Goto";
            this.btn_GotoNeedleWeightPos.Location = new System.Drawing.Point(264, 34);
            this.btn_GotoNeedleWeightPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoNeedleWeightPos.Name = "btn_GotoNeedleWeightPos";
            this.btn_GotoNeedleWeightPos.Size = new System.Drawing.Size(82, 25);
            this.btn_GotoNeedleWeightPos.TabIndex = 214;
            this.btn_GotoNeedleWeightPos.Text = "Goto";
            this.btn_GotoNeedleWeightPos.UseVisualStyleBackColor = true;
            this.btn_GotoNeedleWeightPos.Click += new System.EventHandler(this.btn_GotoNeedleWeightPos_Click);
            // 
            // btn_SetNeedle2WeightPos
            // 
            this.btn_SetNeedle2WeightPos.AccessibleDescription = "Set";
            this.btn_SetNeedle2WeightPos.Location = new System.Drawing.Point(177, 93);
            this.btn_SetNeedle2WeightPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetNeedle2WeightPos.Name = "btn_SetNeedle2WeightPos";
            this.btn_SetNeedle2WeightPos.Size = new System.Drawing.Size(82, 25);
            this.btn_SetNeedle2WeightPos.TabIndex = 220;
            this.btn_SetNeedle2WeightPos.Text = "Set";
            this.btn_SetNeedle2WeightPos.UseVisualStyleBackColor = true;
            this.btn_SetNeedle2WeightPos.Click += new System.EventHandler(this.btn_SetNeedle2WeightPos_Click);
            // 
            // btn_SetNeedleWeightPos
            // 
            this.btn_SetNeedleWeightPos.AccessibleDescription = "Set";
            this.btn_SetNeedleWeightPos.Location = new System.Drawing.Point(177, 34);
            this.btn_SetNeedleWeightPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetNeedleWeightPos.Name = "btn_SetNeedleWeightPos";
            this.btn_SetNeedleWeightPos.Size = new System.Drawing.Size(82, 25);
            this.btn_SetNeedleWeightPos.TabIndex = 215;
            this.btn_SetNeedleWeightPos.Text = "Set";
            this.btn_SetNeedleWeightPos.UseVisualStyleBackColor = true;
            this.btn_SetNeedleWeightPos.Click += new System.EventHandler(this.btn_SetNeedleWeightPos_Click);
            // 
            // btn_GotoNeedle2WeightPos
            // 
            this.btn_GotoNeedle2WeightPos.AccessibleDescription = "Goto";
            this.btn_GotoNeedle2WeightPos.Location = new System.Drawing.Point(264, 93);
            this.btn_GotoNeedle2WeightPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoNeedle2WeightPos.Name = "btn_GotoNeedle2WeightPos";
            this.btn_GotoNeedle2WeightPos.Size = new System.Drawing.Size(82, 25);
            this.btn_GotoNeedle2WeightPos.TabIndex = 219;
            this.btn_GotoNeedle2WeightPos.Text = "Goto";
            this.btn_GotoNeedle2WeightPos.UseVisualStyleBackColor = true;
            this.btn_GotoNeedle2WeightPos.Click += new System.EventHandler(this.btn_GotoNeedle2WeightPos_Click);
            // 
            // lbl_Needle1WeightPosXYZ
            // 
            this.lbl_Needle1WeightPosXYZ.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Needle1WeightPosXYZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Needle1WeightPosXYZ.Location = new System.Drawing.Point(91, 5);
            this.lbl_Needle1WeightPosXYZ.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Needle1WeightPosXYZ.Name = "lbl_Needle1WeightPosXYZ";
            this.lbl_Needle1WeightPosXYZ.Size = new System.Drawing.Size(254, 25);
            this.lbl_Needle1WeightPosXYZ.TabIndex = 216;
            this.lbl_Needle1WeightPosXYZ.Text = "-999.999,-999.999,-99.999";
            this.lbl_Needle1WeightPosXYZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Needle2WeightPosZ2
            // 
            this.lbl_Needle2WeightPosZ2.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Needle2WeightPosZ2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Needle2WeightPosZ2.Location = new System.Drawing.Point(91, 64);
            this.lbl_Needle2WeightPosZ2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Needle2WeightPosZ2.Name = "lbl_Needle2WeightPosZ2";
            this.lbl_Needle2WeightPosZ2.Size = new System.Drawing.Size(254, 25);
            this.lbl_Needle2WeightPosZ2.TabIndex = 218;
            this.lbl_Needle2WeightPosZ2.Text = "-999.999,-999.999,-99.999";
            this.lbl_Needle2WeightPosZ2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AccessibleDescription = "Head 2";
            this.label31.Location = new System.Drawing.Point(5, 60);
            this.label31.Margin = new System.Windows.Forms.Padding(2);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(82, 25);
            this.label31.TabIndex = 217;
            this.label31.Text = "Head 2";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(6, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 416);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 210;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label42);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.btn_GotoNeedleWeightPos);
            this.tabPage1.Controls.Add(this.btn_SetNeedleWeightPos);
            this.tabPage1.Controls.Add(this.lbl_Needle1WeightPosXYZ);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.lbl_Needle2WeightPosZ2);
            this.tabPage1.Controls.Add(this.btn_GotoNeedle2WeightPos);
            this.tabPage1.Controls.Add(this.btn_SetNeedle2WeightPos);
            this.tabPage1.Controls.Add(this.label41);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(466, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Position";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblNoOfPurge);
            this.tabPage2.Controls.Add(this.lblCleanOnStart);
            this.tabPage2.Controls.Add(this.label38);
            this.tabPage2.Controls.Add(this.label45);
            this.tabPage2.Controls.Add(this.lblMeasPosCount);
            this.tabPage2.Controls.Add(this.label47);
            this.tabPage2.Controls.Add(this.lbl_MeasPCD);
            this.tabPage2.Controls.Add(this.lblMeasPosPCD);
            this.tabPage2.Controls.Add(this.label44);
            this.tabPage2.Controls.Add(this.lblMeasPosMthd);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label39);
            this.tabPage2.Controls.Add(this.lblZUpSpeed);
            this.tabPage2.Controls.Add(this.lblZUpDist);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.lblWeightPostWaitTime);
            this.tabPage2.Controls.Add(this.lblStartMeasDelay);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.lblWeightPreWaitTime);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lblEndMeasDelay);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(466, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(153, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 253;
            this.label4.Text = "(count)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 251;
            this.label1.Text = "No Of Purge";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfPurge
            // 
            this.lblNoOfPurge.BackColor = System.Drawing.SystemColors.Window;
            this.lblNoOfPurge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNoOfPurge.Location = new System.Drawing.Point(227, 43);
            this.lblNoOfPurge.Margin = new System.Windows.Forms.Padding(2);
            this.lblNoOfPurge.Name = "lblNoOfPurge";
            this.lblNoOfPurge.Size = new System.Drawing.Size(70, 23);
            this.lblNoOfPurge.TabIndex = 252;
            this.lblNoOfPurge.Text = "1";
            this.lblNoOfPurge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoOfPurge.Click += new System.EventHandler(this.lblNoOfPurge_Click);
            // 
            // lblCleanOnStart
            // 
            this.lblCleanOnStart.BackColor = System.Drawing.SystemColors.Window;
            this.lblCleanOnStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCleanOnStart.Location = new System.Drawing.Point(227, 5);
            this.lblCleanOnStart.Margin = new System.Windows.Forms.Padding(2);
            this.lblCleanOnStart.Name = "lblCleanOnStart";
            this.lblCleanOnStart.Size = new System.Drawing.Size(70, 23);
            this.lblCleanOnStart.TabIndex = 250;
            this.lblCleanOnStart.Text = "True";
            this.lblCleanOnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCleanOnStart.Click += new System.EventHandler(this.lblCleanOnStart_Click);
            // 
            // label38
            // 
            this.label38.AccessibleDescription = "Clean On Start";
            this.label38.Location = new System.Drawing.Point(5, 5);
            this.label38.Margin = new System.Windows.Forms.Padding(2);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(144, 23);
            this.label38.TabIndex = 249;
            this.label38.Text = "Clean On Start";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.AccessibleDescription = "";
            this.label45.Location = new System.Drawing.Point(153, 345);
            this.label45.Margin = new System.Windows.Forms.Padding(2);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 23);
            this.label45.TabIndex = 248;
            this.label45.Text = "(count)";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMeasPosCount
            // 
            this.lblMeasPosCount.BackColor = System.Drawing.SystemColors.Window;
            this.lblMeasPosCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMeasPosCount.Location = new System.Drawing.Point(227, 345);
            this.lblMeasPosCount.Margin = new System.Windows.Forms.Padding(2);
            this.lblMeasPosCount.Name = "lblMeasPosCount";
            this.lblMeasPosCount.Size = new System.Drawing.Size(70, 23);
            this.lblMeasPosCount.TabIndex = 247;
            this.lblMeasPosCount.Text = "250";
            this.lblMeasPosCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMeasPosCount.Click += new System.EventHandler(this.lblMeasPosCount_Click);
            // 
            // label47
            // 
            this.label47.AccessibleDescription = "Measure Pos Count";
            this.label47.Location = new System.Drawing.Point(5, 345);
            this.label47.Margin = new System.Windows.Forms.Padding(2);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(144, 23);
            this.label47.TabIndex = 246;
            this.label47.Text = "Measure Pos Count";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MeasPCD
            // 
            this.lbl_MeasPCD.AccessibleDescription = "";
            this.lbl_MeasPCD.Location = new System.Drawing.Point(153, 318);
            this.lbl_MeasPCD.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MeasPCD.Name = "lbl_MeasPCD";
            this.lbl_MeasPCD.Size = new System.Drawing.Size(70, 23);
            this.lbl_MeasPCD.TabIndex = 245;
            this.lbl_MeasPCD.Text = "(mm)";
            this.lbl_MeasPCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMeasPosPCD
            // 
            this.lblMeasPosPCD.BackColor = System.Drawing.SystemColors.Window;
            this.lblMeasPosPCD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMeasPosPCD.Location = new System.Drawing.Point(227, 318);
            this.lblMeasPosPCD.Margin = new System.Windows.Forms.Padding(2);
            this.lblMeasPosPCD.Name = "lblMeasPosPCD";
            this.lblMeasPosPCD.Size = new System.Drawing.Size(70, 23);
            this.lblMeasPosPCD.TabIndex = 244;
            this.lblMeasPosPCD.Text = "250";
            this.lblMeasPosPCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMeasPosPCD.Click += new System.EventHandler(this.lblMeasPosPCD_Click);
            // 
            // label44
            // 
            this.label44.AccessibleDescription = "Measure Pos PCD";
            this.label44.Location = new System.Drawing.Point(5, 318);
            this.label44.Margin = new System.Windows.Forms.Padding(2);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(144, 23);
            this.label44.TabIndex = 243;
            this.label44.Text = "Measure Pos PCD";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMeasPosMthd
            // 
            this.lblMeasPosMthd.BackColor = System.Drawing.SystemColors.Window;
            this.lblMeasPosMthd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMeasPosMthd.Location = new System.Drawing.Point(227, 291);
            this.lblMeasPosMthd.Margin = new System.Windows.Forms.Padding(2);
            this.lblMeasPosMthd.Name = "lblMeasPosMthd";
            this.lblMeasPosMthd.Size = new System.Drawing.Size(70, 23);
            this.lblMeasPosMthd.TabIndex = 242;
            this.lblMeasPosMthd.Text = "250";
            this.lblMeasPosMthd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMeasPosMthd.Click += new System.EventHandler(this.lblMeasPosMthd_Click);
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "Speed";
            this.label17.Location = new System.Drawing.Point(5, 80);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 23);
            this.label17.TabIndex = 231;
            this.label17.Text = "Speed";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.AccessibleDescription = "Measure Pos Method";
            this.label39.Location = new System.Drawing.Point(5, 291);
            this.label39.Margin = new System.Windows.Forms.Padding(2);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(144, 23);
            this.label39.TabIndex = 241;
            this.label39.Text = "Measure Pos Method";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblZUpSpeed
            // 
            this.lblZUpSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.lblZUpSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZUpSpeed.Location = new System.Drawing.Point(227, 80);
            this.lblZUpSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.lblZUpSpeed.Name = "lblZUpSpeed";
            this.lblZUpSpeed.Size = new System.Drawing.Size(70, 23);
            this.lblZUpSpeed.TabIndex = 232;
            this.lblZUpSpeed.Text = "100";
            this.lblZUpSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblZUpSpeed.Click += new System.EventHandler(this.lblZUpSpeed_Click);
            // 
            // lblZUpDist
            // 
            this.lblZUpDist.BackColor = System.Drawing.SystemColors.Window;
            this.lblZUpDist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZUpDist.Location = new System.Drawing.Point(227, 185);
            this.lblZUpDist.Margin = new System.Windows.Forms.Padding(2);
            this.lblZUpDist.Name = "lblZUpDist";
            this.lblZUpDist.Size = new System.Drawing.Size(70, 23);
            this.lblZUpDist.TabIndex = 230;
            this.lblZUpDist.Text = "100";
            this.lblZUpDist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblZUpDist.Click += new System.EventHandler(this.lblZUpDist_Click);
            // 
            // label30
            // 
            this.label30.AccessibleDescription = "";
            this.label30.Location = new System.Drawing.Point(153, 80);
            this.label30.Margin = new System.Windows.Forms.Padding(2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 23);
            this.label30.TabIndex = 236;
            this.label30.Text = "(mm/s)";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "Start Measure Delay";
            this.label18.Location = new System.Drawing.Point(5, 120);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 23);
            this.label18.TabIndex = 233;
            this.label18.Text = "Start Measure Delay";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Z Up Dist";
            this.label2.Location = new System.Drawing.Point(5, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 229;
            this.label2.Text = "Z Up Dist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AccessibleDescription = "";
            this.label29.Location = new System.Drawing.Point(153, 185);
            this.label29.Margin = new System.Windows.Forms.Padding(2);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 23);
            this.label29.TabIndex = 240;
            this.label29.Text = "(mm)";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWeightPostWaitTime
            // 
            this.lblWeightPostWaitTime.BackColor = System.Drawing.SystemColors.Window;
            this.lblWeightPostWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeightPostWaitTime.Location = new System.Drawing.Point(227, 225);
            this.lblWeightPostWaitTime.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeightPostWaitTime.Name = "lblWeightPostWaitTime";
            this.lblWeightPostWaitTime.Size = new System.Drawing.Size(70, 23);
            this.lblWeightPostWaitTime.TabIndex = 228;
            this.lblWeightPostWaitTime.Text = "100";
            this.lblWeightPostWaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWeightPostWaitTime.Click += new System.EventHandler(this.lblWeightPostWaitTime_Click);
            // 
            // lblStartMeasDelay
            // 
            this.lblStartMeasDelay.BackColor = System.Drawing.SystemColors.Window;
            this.lblStartMeasDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStartMeasDelay.Location = new System.Drawing.Point(227, 120);
            this.lblStartMeasDelay.Margin = new System.Windows.Forms.Padding(2);
            this.lblStartMeasDelay.Name = "lblStartMeasDelay";
            this.lblStartMeasDelay.Size = new System.Drawing.Size(70, 23);
            this.lblStartMeasDelay.TabIndex = 234;
            this.lblStartMeasDelay.Text = "250";
            this.lblStartMeasDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStartMeasDelay.Click += new System.EventHandler(this.lblStartMeasDelay_Click);
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "";
            this.label28.Location = new System.Drawing.Point(153, 225);
            this.label28.Margin = new System.Windows.Forms.Padding(2);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 23);
            this.label28.TabIndex = 238;
            this.label28.Text = "(ms)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Post Wait Time";
            this.label12.Location = new System.Drawing.Point(5, 225);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 23);
            this.label12.TabIndex = 227;
            this.label12.Text = "Post Wait Time";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightPreWaitTime
            // 
            this.lblWeightPreWaitTime.BackColor = System.Drawing.SystemColors.Window;
            this.lblWeightPreWaitTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeightPreWaitTime.Location = new System.Drawing.Point(227, 147);
            this.lblWeightPreWaitTime.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeightPreWaitTime.Name = "lblWeightPreWaitTime";
            this.lblWeightPreWaitTime.Size = new System.Drawing.Size(70, 23);
            this.lblWeightPreWaitTime.TabIndex = 226;
            this.lblWeightPreWaitTime.Text = "100";
            this.lblWeightPreWaitTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWeightPreWaitTime.Click += new System.EventHandler(this.lblWeightPreWaitTime_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Pre Wait Time";
            this.label8.Location = new System.Drawing.Point(5, 147);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 23);
            this.label8.TabIndex = 225;
            this.label8.Text = "Pre Wait Time";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AccessibleDescription = "";
            this.label26.Location = new System.Drawing.Point(153, 147);
            this.label26.Margin = new System.Windows.Forms.Padding(2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 23);
            this.label26.TabIndex = 237;
            this.label26.Text = "(ms)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "";
            this.label24.Location = new System.Drawing.Point(153, 120);
            this.label24.Margin = new System.Windows.Forms.Padding(2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 23);
            this.label24.TabIndex = 235;
            this.label24.Text = "(ms)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "End Measure Delay";
            this.label9.Location = new System.Drawing.Point(5, 252);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 23);
            this.label9.TabIndex = 223;
            this.label9.Text = "End Measure Delay";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndMeasDelay
            // 
            this.lblEndMeasDelay.BackColor = System.Drawing.SystemColors.Window;
            this.lblEndMeasDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEndMeasDelay.Location = new System.Drawing.Point(227, 252);
            this.lblEndMeasDelay.Margin = new System.Windows.Forms.Padding(2);
            this.lblEndMeasDelay.Name = "lblEndMeasDelay";
            this.lblEndMeasDelay.Size = new System.Drawing.Size(70, 23);
            this.lblEndMeasDelay.TabIndex = 224;
            this.lblEndMeasDelay.Text = "250";
            this.lblEndMeasDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEndMeasDelay.Click += new System.EventHandler(this.lblEndMeasDelay_Click);
            // 
            // label25
            // 
            this.label25.AccessibleDescription = "";
            this.label25.Location = new System.Drawing.Point(153, 252);
            this.label25.Margin = new System.Windows.Forms.Padding(2);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 23);
            this.label25.TabIndex = 239;
            this.label25.Text = "(ms)";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmWeightSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(497, 492);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnJog);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmWeightSettings";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmWeightSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWeightSettings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWeightSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmWeightSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnJog;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btn_GotoNeedleWeightPos;
        private System.Windows.Forms.Button btn_SetNeedle2WeightPos;
        private System.Windows.Forms.Button btn_SetNeedleWeightPos;
        private System.Windows.Forms.Button btn_GotoNeedle2WeightPos;
        private System.Windows.Forms.Label lbl_Needle1WeightPosXYZ;
        private System.Windows.Forms.Label lbl_Needle2WeightPosZ2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblCleanOnStart;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lblMeasPosCount;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lbl_MeasPCD;
        private System.Windows.Forms.Label lblMeasPosPCD;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lblMeasPosMthd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblZUpSpeed;
        private System.Windows.Forms.Label lblZUpDist;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblWeightPostWaitTime;
        private System.Windows.Forms.Label lblStartMeasDelay;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblWeightPreWaitTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEndMeasDelay;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoOfPurge;
    }
}