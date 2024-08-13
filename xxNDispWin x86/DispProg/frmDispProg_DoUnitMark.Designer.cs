namespace NDispWin
{
    partial class frm_DispCore_DispProg_DoUnitMark
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_InvertJudgement = new System.Windows.Forms.Label();
            this.lbl_XYTol = new System.Windows.Forms.Label();
            this.lbl_MinScore = new System.Windows.Forms.Label();
            this.gbox_Pos1 = new System.Windows.Forms.GroupBox();
            this.lbl_X1Y1 = new System.Windows.Forms.Label();
            this.btn_GotoPt1Pos = new System.Windows.Forms.Button();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.btn_Learn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_NoImage = new System.Windows.Forms.Label();
            this.pbox_PatImage = new System.Windows.Forms.PictureBox();
            this.btn_Test = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Score = new System.Windows.Forms.Label();
            this.lbl_OfstXY = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_CameraID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Judgement = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tpage_Options = new System.Windows.Forms.TabPage();
            this.lbl_FailAction = new System.Windows.Forms.Label();
            this.lbl_SkipCount = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl_SettleTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_FocusNo = new System.Windows.Forms.Label();
            this.gbox_Pos1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_PatImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpage_Judgement.SuspendLayout();
            this.tpage_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(429, 399);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 24;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(348, 399);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 23;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_InvertJudgement
            // 
            this.lbl_InvertJudgement.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_InvertJudgement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InvertJudgement.Location = new System.Drawing.Point(163, 61);
            this.lbl_InvertJudgement.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_InvertJudgement.Name = "lbl_InvertJudgement";
            this.lbl_InvertJudgement.Size = new System.Drawing.Size(75, 24);
            this.lbl_InvertJudgement.TabIndex = 28;
            this.lbl_InvertJudgement.Text = "9.999";
            this.lbl_InvertJudgement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_InvertJudgement.Click += new System.EventHandler(this.lbl_InvertJudgement_Click);
            // 
            // lbl_XYTol
            // 
            this.lbl_XYTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_XYTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_XYTol.Location = new System.Drawing.Point(163, 33);
            this.lbl_XYTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_XYTol.Name = "lbl_XYTol";
            this.lbl_XYTol.Size = new System.Drawing.Size(75, 24);
            this.lbl_XYTol.TabIndex = 24;
            this.lbl_XYTol.Text = "9.999";
            this.lbl_XYTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_XYTol.Click += new System.EventHandler(this.lbl_XYTol_Click);
            // 
            // lbl_MinScore
            // 
            this.lbl_MinScore.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MinScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MinScore.Location = new System.Drawing.Point(163, 5);
            this.lbl_MinScore.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MinScore.Name = "lbl_MinScore";
            this.lbl_MinScore.Size = new System.Drawing.Size(75, 24);
            this.lbl_MinScore.TabIndex = 19;
            this.lbl_MinScore.Text = "9.999";
            this.lbl_MinScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MinScore.Click += new System.EventHandler(this.lbl_MinScore_Click);
            // 
            // gbox_Pos1
            // 
            this.gbox_Pos1.AccessibleDescription = "Position";
            this.gbox_Pos1.AutoSize = true;
            this.gbox_Pos1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Pos1.Controls.Add(this.lbl_X1Y1);
            this.gbox_Pos1.Controls.Add(this.btn_GotoPt1Pos);
            this.gbox_Pos1.Controls.Add(this.btn_SetPt1Pos);
            this.gbox_Pos1.Controls.Add(this.btn_Learn);
            this.gbox_Pos1.Controls.Add(this.label1);
            this.gbox_Pos1.Controls.Add(this.lbl_NoImage);
            this.gbox_Pos1.Controls.Add(this.pbox_PatImage);
            this.gbox_Pos1.Controls.Add(this.btn_Test);
            this.gbox_Pos1.Location = new System.Drawing.Point(4, 58);
            this.gbox_Pos1.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pos1.Name = "gbox_Pos1";
            this.gbox_Pos1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Pos1.Size = new System.Drawing.Size(249, 379);
            this.gbox_Pos1.TabIndex = 20;
            this.gbox_Pos1.TabStop = false;
            this.gbox_Pos1.Text = "Position";
            // 
            // lbl_X1Y1
            // 
            this.lbl_X1Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1Y1.Location = new System.Drawing.Point(92, 23);
            this.lbl_X1Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1Y1.Name = "lbl_X1Y1";
            this.lbl_X1Y1.Size = new System.Drawing.Size(150, 23);
            this.lbl_X1Y1.TabIndex = 5;
            this.lbl_X1Y1.Text = "lbl_X1Y1";
            this.lbl_X1Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_GotoPt1Pos
            // 
            this.btn_GotoPt1Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt1Pos.Location = new System.Drawing.Point(167, 50);
            this.btn_GotoPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt1Pos.Name = "btn_GotoPt1Pos";
            this.btn_GotoPt1Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoPt1Pos.TabIndex = 4;
            this.btn_GotoPt1Pos.Text = "Goto";
            this.btn_GotoPt1Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt1Pos.Click += new System.EventHandler(this.btn_GotoPt1Pos_Click);
            // 
            // btn_SetPt1Pos
            // 
            this.btn_SetPt1Pos.AccessibleDescription = "Set";
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(86, 50);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_SetPt1Pos.TabIndex = 3;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // btn_Learn
            // 
            this.btn_Learn.AccessibleDescription = "Learn";
            this.btn_Learn.Location = new System.Drawing.Point(167, 328);
            this.btn_Learn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.btn_Learn.Name = "btn_Learn";
            this.btn_Learn.Size = new System.Drawing.Size(75, 36);
            this.btn_Learn.TabIndex = 10;
            this.btn_Learn.Text = "Learn";
            this.btn_Learn.UseVisualStyleBackColor = true;
            this.btn_Learn.Click += new System.EventHandler(this.btn_Learn_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "XY (mm)";
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "XY (mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_NoImage
            // 
            this.lbl_NoImage.AutoSize = true;
            this.lbl_NoImage.Location = new System.Drawing.Point(94, 206);
            this.lbl_NoImage.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_NoImage.Name = "lbl_NoImage";
            this.lbl_NoImage.Size = new System.Drawing.Size(60, 14);
            this.lbl_NoImage.TabIndex = 9;
            this.lbl_NoImage.Text = "No Image";
            // 
            // pbox_PatImage
            // 
            this.pbox_PatImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_PatImage.Location = new System.Drawing.Point(8, 90);
            this.pbox_PatImage.Margin = new System.Windows.Forms.Padding(2);
            this.pbox_PatImage.Name = "pbox_PatImage";
            this.pbox_PatImage.Size = new System.Drawing.Size(234, 234);
            this.pbox_PatImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox_PatImage.TabIndex = 7;
            this.pbox_PatImage.TabStop = false;
            // 
            // btn_Test
            // 
            this.btn_Test.AccessibleDescription = "Test";
            this.btn_Test.Location = new System.Drawing.Point(8, 328);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 36);
            this.btn_Test.TabIndex = 13;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Test";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_Result);
            this.groupBox1.Controls.Add(this.lbl_Time);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_Score);
            this.groupBox1.Controls.Add(this.lbl_OfstXY);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(257, 190);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(249, 143);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test";
            // 
            // lbl_Result
            // 
            this.lbl_Result.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Result.Location = new System.Drawing.Point(167, 76);
            this.lbl_Result.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(75, 23);
            this.lbl_Result.TabIndex = 31;
            this.lbl_Result.Text = "0";
            this.lbl_Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Time.Location = new System.Drawing.Point(167, 103);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(75, 23);
            this.lbl_Time.TabIndex = 29;
            this.lbl_Time.Text = "0";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Result";
            this.label4.Location = new System.Drawing.Point(7, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Score
            // 
            this.lbl_Score.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Score.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Score.Location = new System.Drawing.Point(167, 49);
            this.lbl_Score.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Score.Name = "lbl_Score";
            this.lbl_Score.Size = new System.Drawing.Size(75, 23);
            this.lbl_Score.TabIndex = 27;
            this.lbl_Score.Text = "0";
            this.lbl_Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_OfstXY
            // 
            this.lbl_OfstXY.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_OfstXY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_OfstXY.Location = new System.Drawing.Point(131, 22);
            this.lbl_OfstXY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_OfstXY.Name = "lbl_OfstXY";
            this.lbl_OfstXY.Size = new System.Drawing.Size(111, 23);
            this.lbl_OfstXY.TabIndex = 26;
            this.lbl_OfstXY.Text = "0";
            this.lbl_OfstXY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Time (ms)";
            this.label10.Location = new System.Drawing.Point(7, 103);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "Time (ms)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Score (%)";
            this.label8.Location = new System.Drawing.Point(7, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Score (%)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "XY Offset (mm)";
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "XY Offset (mm)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CameraID
            // 
            this.lbl_CameraID.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CameraID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CameraID.Location = new System.Drawing.Point(88, 4);
            this.lbl_CameraID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CameraID.Name = "lbl_CameraID";
            this.lbl_CameraID.Size = new System.Drawing.Size(75, 24);
            this.lbl_CameraID.TabIndex = 45;
            this.lbl_CameraID.Text = "lbl_CameraID";
            this.lbl_CameraID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CameraID.Click += new System.EventHandler(this.lbl_CameraID_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Camera ID";
            this.label2.Location = new System.Drawing.Point(9, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Camera ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Judgement);
            this.tabControl1.Controls.Add(this.tpage_Options);
            this.tabControl1.ItemSize = new System.Drawing.Size(74, 25);
            this.tabControl1.Location = new System.Drawing.Point(257, 58);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(249, 128);
            this.tabControl1.TabIndex = 47;
            // 
            // tpage_Judgement
            // 
            this.tpage_Judgement.AccessibleDescription = "Judgement";
            this.tpage_Judgement.Controls.Add(this.label7);
            this.tpage_Judgement.Controls.Add(this.label13);
            this.tpage_Judgement.Controls.Add(this.lbl_InvertJudgement);
            this.tpage_Judgement.Controls.Add(this.label16);
            this.tpage_Judgement.Controls.Add(this.lbl_XYTol);
            this.tpage_Judgement.Controls.Add(this.lbl_MinScore);
            this.tpage_Judgement.Location = new System.Drawing.Point(4, 29);
            this.tpage_Judgement.Name = "tpage_Judgement";
            this.tpage_Judgement.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Judgement.Size = new System.Drawing.Size(241, 95);
            this.tpage_Judgement.TabIndex = 0;
            this.tpage_Judgement.Text = "Judgement";
            this.tpage_Judgement.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Invert Judgement";
            this.label7.Location = new System.Drawing.Point(5, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 24);
            this.label7.TabIndex = 25;
            this.label7.Text = "Invert Judgement";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "Min Score (%)";
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 24);
            this.label13.TabIndex = 18;
            this.label13.Text = "Min Score (%)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "XY Tol (mm)";
            this.label16.Location = new System.Drawing.Point(5, 33);
            this.label16.Margin = new System.Windows.Forms.Padding(2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 24);
            this.label16.TabIndex = 16;
            this.label16.Text = "XY Tol (mm)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpage_Options
            // 
            this.tpage_Options.AccessibleDescription = "Options";
            this.tpage_Options.Controls.Add(this.lbl_FailAction);
            this.tpage_Options.Controls.Add(this.lbl_SkipCount);
            this.tpage_Options.Controls.Add(this.label19);
            this.tpage_Options.Controls.Add(this.label17);
            this.tpage_Options.Controls.Add(this.label18);
            this.tpage_Options.Controls.Add(this.lbl_SettleTime);
            this.tpage_Options.Location = new System.Drawing.Point(4, 29);
            this.tpage_Options.Name = "tpage_Options";
            this.tpage_Options.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Options.Size = new System.Drawing.Size(241, 95);
            this.tpage_Options.TabIndex = 1;
            this.tpage_Options.Text = "Options";
            this.tpage_Options.UseVisualStyleBackColor = true;
            // 
            // lbl_FailAction
            // 
            this.lbl_FailAction.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FailAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FailAction.Location = new System.Drawing.Point(118, 60);
            this.lbl_FailAction.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FailAction.Name = "lbl_FailAction";
            this.lbl_FailAction.Size = new System.Drawing.Size(120, 23);
            this.lbl_FailAction.TabIndex = 144;
            this.lbl_FailAction.Text = "0";
            this.lbl_FailAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_FailAction.Click += new System.EventHandler(this.lbl_FailAction_Click);
            // 
            // lbl_SkipCount
            // 
            this.lbl_SkipCount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SkipCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SkipCount.Location = new System.Drawing.Point(163, 32);
            this.lbl_SkipCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SkipCount.Name = "lbl_SkipCount";
            this.lbl_SkipCount.Size = new System.Drawing.Size(75, 23);
            this.lbl_SkipCount.TabIndex = 49;
            this.lbl_SkipCount.Text = "0";
            this.lbl_SkipCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SkipCount.Click += new System.EventHandler(this.lbl_SkipCount_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Skip Count (Counts)";
            this.label19.Location = new System.Drawing.Point(5, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 23);
            this.label19.TabIndex = 48;
            this.label19.Text = "Skip Count (Counts)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "Fail Action";
            this.label17.Location = new System.Drawing.Point(5, 60);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 23);
            this.label17.TabIndex = 143;
            this.label17.Text = "Fail Action";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "Settle Time (ms)";
            this.label18.Location = new System.Drawing.Point(5, 5);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 23);
            this.label18.TabIndex = 141;
            this.label18.Text = "Settle Time (ms)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SettleTime
            // 
            this.lbl_SettleTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SettleTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SettleTime.Location = new System.Drawing.Point(163, 5);
            this.lbl_SettleTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SettleTime.Name = "lbl_SettleTime";
            this.lbl_SettleTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_SettleTime.TabIndex = 142;
            this.lbl_SettleTime.Text = "0";
            this.lbl_SettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SettleTime.Click += new System.EventHandler(this.lbl_SettleTime_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Focus No";
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 149;
            this.label3.Text = "Focus No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FocusNo
            // 
            this.lbl_FocusNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FocusNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FocusNo.Location = new System.Drawing.Point(88, 31);
            this.lbl_FocusNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FocusNo.Name = "lbl_FocusNo";
            this.lbl_FocusNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_FocusNo.TabIndex = 150;
            this.lbl_FocusNo.Text = "0";
            this.lbl_FocusNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_FocusNo.Click += new System.EventHandler(this.lbl_FocusNo_Click);
            // 
            // frm_DispCore_DispProg_DoUnitMark
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(521, 464);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_FocusNo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbl_CameraID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.gbox_Pos1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_DoUnitMark";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "frmDispProg_DoUnitMark";
            this.Load += new System.EventHandler(this.frmDispProg_DoBadMark_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_DoUnitMark_FormClosed);
            this.gbox_Pos1.ResumeLayout(false);
            this.gbox_Pos1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_PatImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpage_Judgement.ResumeLayout(false);
            this.tpage_Options.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_XYTol;
        private System.Windows.Forms.Label lbl_MinScore;
        private System.Windows.Forms.GroupBox gbox_Pos1;
        private System.Windows.Forms.Label lbl_X1Y1;
        private System.Windows.Forms.Button btn_GotoPt1Pos;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Button btn_Learn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_NoImage;
        private System.Windows.Forms.PictureBox pbox_PatImage;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Label lbl_InvertJudgement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Score;
        private System.Windows.Forms.Label lbl_OfstXY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_CameraID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Judgement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tpage_Options;
        private System.Windows.Forms.Label lbl_FailAction;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl_SettleTime;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_SkipCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_FocusNo;
    }
}