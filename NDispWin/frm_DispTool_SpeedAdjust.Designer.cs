namespace NDispWin
{
    partial class frm_DispTool_SpeedAdjust
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_PressUnit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_l_Disp = new System.Windows.Forms.Label();
            this.lbl_l_HeadADispUnit = new System.Windows.Forms.Label();
            this.lbl_HeadA_BSuckTime = new System.Windows.Forms.Label();
            this.lbl_HeadA_BSuckSpeed = new System.Windows.Forms.Label();
            this.lbl_HeadA_DispTime = new System.Windows.Forms.Label();
            this.lbl_FPressA = new System.Windows.Forms.Label();
            this.lbl_HeadA_DispSpeed = new System.Windows.Forms.Label();
            this.gboxSettings = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_FPress_AdjMin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FPress_AdjMax = new System.Windows.Forms.Label();
            this.lbl_DispSpeed_AdjMax = new System.Windows.Forms.Label();
            this.lbl_DispTime_AdjMax = new System.Windows.Forms.Label();
            this.lbl_DispSpeed_AdjMin = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_DispTime_AdjMin = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimerTrig = new System.Windows.Forms.Button();
            this.lblTrigTimer = new System.Windows.Forms.Label();
            this.btnTrig = new System.Windows.Forms.Button();
            this.gboxSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(342, 4);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 30);
            this.btn_Close.TabIndex = 39;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(91, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 30);
            this.label4.TabIndex = 56;
            this.label4.Text = "(ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "BSuck Time";
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(5, 113);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 30);
            this.label9.TabIndex = 47;
            this.label9.Text = "BSuck Time";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "BSuck Speed";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 30);
            this.label3.TabIndex = 44;
            this.label3.Text = "BSuck Speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(91, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 30);
            this.label5.TabIndex = 57;
            this.label5.Text = "(rpm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(91, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 30);
            this.label11.TabIndex = 60;
            this.label11.Text = "(ms)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Disp Time";
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(5, 41);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 30);
            this.label12.TabIndex = 59;
            this.label12.Text = "Disp Time";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PressUnit
            // 
            this.lbl_PressUnit.AccessibleDescription = "";
            this.lbl_PressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_PressUnit.Location = new System.Drawing.Point(91, 149);
            this.lbl_PressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PressUnit.Name = "lbl_PressUnit";
            this.lbl_PressUnit.Size = new System.Drawing.Size(60, 30);
            this.lbl_PressUnit.TabIndex = 60;
            this.lbl_PressUnit.Text = "(Psi)";
            this.lbl_PressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "F Pressure";
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(5, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 30);
            this.label6.TabIndex = 59;
            this.label6.Text = "F Pressure";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_l_Disp
            // 
            this.lbl_l_Disp.AccessibleDescription = "Disp Speed";
            this.lbl_l_Disp.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_l_Disp.Location = new System.Drawing.Point(5, 5);
            this.lbl_l_Disp.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_l_Disp.Name = "lbl_l_Disp";
            this.lbl_l_Disp.Size = new System.Drawing.Size(80, 30);
            this.lbl_l_Disp.TabIndex = 20;
            this.lbl_l_Disp.Text = "Disp Speed";
            this.lbl_l_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_l_HeadADispUnit
            // 
            this.lbl_l_HeadADispUnit.AccessibleDescription = "";
            this.lbl_l_HeadADispUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_l_HeadADispUnit.Location = new System.Drawing.Point(91, 5);
            this.lbl_l_HeadADispUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_l_HeadADispUnit.Name = "lbl_l_HeadADispUnit";
            this.lbl_l_HeadADispUnit.Size = new System.Drawing.Size(60, 30);
            this.lbl_l_HeadADispUnit.TabIndex = 39;
            this.lbl_l_HeadADispUnit.Text = "(rpm)";
            this.lbl_l_HeadADispUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_HeadA_BSuckTime
            // 
            this.lbl_HeadA_BSuckTime.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_BSuckTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_BSuckTime.Location = new System.Drawing.Point(157, 113);
            this.lbl_HeadA_BSuckTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_BSuckTime.Name = "lbl_HeadA_BSuckTime";
            this.lbl_HeadA_BSuckTime.Size = new System.Drawing.Size(60, 30);
            this.lbl_HeadA_BSuckTime.TabIndex = 46;
            this.lbl_HeadA_BSuckTime.Text = "000.001";
            this.lbl_HeadA_BSuckTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_BSuckTime.Click += new System.EventHandler(this.lbl_HeadA_BSuckTime_Click);
            // 
            // lbl_HeadA_BSuckSpeed
            // 
            this.lbl_HeadA_BSuckSpeed.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_BSuckSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_BSuckSpeed.Location = new System.Drawing.Point(157, 77);
            this.lbl_HeadA_BSuckSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_BSuckSpeed.Name = "lbl_HeadA_BSuckSpeed";
            this.lbl_HeadA_BSuckSpeed.Size = new System.Drawing.Size(60, 30);
            this.lbl_HeadA_BSuckSpeed.TabIndex = 43;
            this.lbl_HeadA_BSuckSpeed.Text = "000.001";
            this.lbl_HeadA_BSuckSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_BSuckSpeed.Click += new System.EventHandler(this.lbl_HeadA_BSuckSpeed_Click);
            // 
            // lbl_HeadA_DispTime
            // 
            this.lbl_HeadA_DispTime.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_DispTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_DispTime.Location = new System.Drawing.Point(157, 41);
            this.lbl_HeadA_DispTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_DispTime.Name = "lbl_HeadA_DispTime";
            this.lbl_HeadA_DispTime.Size = new System.Drawing.Size(60, 30);
            this.lbl_HeadA_DispTime.TabIndex = 58;
            this.lbl_HeadA_DispTime.Text = "000.001";
            this.lbl_HeadA_DispTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_DispTime.Click += new System.EventHandler(this.lbl_HeadA_DispTime_Click);
            // 
            // lbl_FPressA
            // 
            this.lbl_FPressA.BackColor = System.Drawing.Color.White;
            this.lbl_FPressA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressA.Location = new System.Drawing.Point(157, 149);
            this.lbl_FPressA.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressA.Name = "lbl_FPressA";
            this.lbl_FPressA.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressA.TabIndex = 58;
            this.lbl_FPressA.Text = "000.001";
            this.lbl_FPressA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressA.Click += new System.EventHandler(this.lbl_FPressA_Click);
            // 
            // lbl_HeadA_DispSpeed
            // 
            this.lbl_HeadA_DispSpeed.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_DispSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_DispSpeed.Location = new System.Drawing.Point(157, 5);
            this.lbl_HeadA_DispSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_DispSpeed.Name = "lbl_HeadA_DispSpeed";
            this.lbl_HeadA_DispSpeed.Size = new System.Drawing.Size(60, 30);
            this.lbl_HeadA_DispSpeed.TabIndex = 19;
            this.lbl_HeadA_DispSpeed.Text = "000.001";
            this.lbl_HeadA_DispSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_DispSpeed.Click += new System.EventHandler(this.lbl_HeadASpeed_Click);
            // 
            // gboxSettings
            // 
            this.gboxSettings.AccessibleDescription = "Settings";
            this.gboxSettings.AutoSize = true;
            this.gboxSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gboxSettings.Controls.Add(this.label7);
            this.gboxSettings.Controls.Add(this.lbl_FPress_AdjMin);
            this.gboxSettings.Controls.Add(this.label2);
            this.gboxSettings.Controls.Add(this.lbl_FPress_AdjMax);
            this.gboxSettings.Controls.Add(this.lbl_DispSpeed_AdjMax);
            this.gboxSettings.Controls.Add(this.lbl_DispTime_AdjMax);
            this.gboxSettings.Controls.Add(this.lbl_DispSpeed_AdjMin);
            this.gboxSettings.Controls.Add(this.label10);
            this.gboxSettings.Controls.Add(this.lbl_DispTime_AdjMin);
            this.gboxSettings.Location = new System.Drawing.Point(8, 188);
            this.gboxSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gboxSettings.Name = "gboxSettings";
            this.gboxSettings.Size = new System.Drawing.Size(277, 144);
            this.gboxSettings.TabIndex = 57;
            this.gboxSettings.TabStop = false;
            this.gboxSettings.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "FPress Min Max";
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 30);
            this.label7.TabIndex = 51;
            this.label7.Text = "FPress Min Max";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FPress_AdjMin
            // 
            this.lbl_FPress_AdjMin.BackColor = System.Drawing.Color.White;
            this.lbl_FPress_AdjMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPress_AdjMin.Location = new System.Drawing.Point(145, 93);
            this.lbl_FPress_AdjMin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_FPress_AdjMin.Name = "lbl_FPress_AdjMin";
            this.lbl_FPress_AdjMin.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPress_AdjMin.TabIndex = 44;
            this.lbl_FPress_AdjMin.Text = "0.0001";
            this.lbl_FPress_AdjMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPress_AdjMin.Click += new System.EventHandler(this.lbl_FPress_AdjMin_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Disp Time Min Max";
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 30);
            this.label2.TabIndex = 50;
            this.label2.Text = "Disp Time Min Max";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FPress_AdjMax
            // 
            this.lbl_FPress_AdjMax.BackColor = System.Drawing.Color.White;
            this.lbl_FPress_AdjMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPress_AdjMax.Location = new System.Drawing.Point(211, 93);
            this.lbl_FPress_AdjMax.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_FPress_AdjMax.Name = "lbl_FPress_AdjMax";
            this.lbl_FPress_AdjMax.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPress_AdjMax.TabIndex = 48;
            this.lbl_FPress_AdjMax.Text = "0.0001";
            this.lbl_FPress_AdjMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPress_AdjMax.Click += new System.EventHandler(this.lbl_FPress_AdjMax_Click);
            // 
            // lbl_DispSpeed_AdjMax
            // 
            this.lbl_DispSpeed_AdjMax.BackColor = System.Drawing.Color.White;
            this.lbl_DispSpeed_AdjMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DispSpeed_AdjMax.Location = new System.Drawing.Point(211, 21);
            this.lbl_DispSpeed_AdjMax.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispSpeed_AdjMax.Name = "lbl_DispSpeed_AdjMax";
            this.lbl_DispSpeed_AdjMax.Size = new System.Drawing.Size(60, 30);
            this.lbl_DispSpeed_AdjMax.TabIndex = 47;
            this.lbl_DispSpeed_AdjMax.Text = "0.0001";
            this.lbl_DispSpeed_AdjMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispSpeed_AdjMax.Click += new System.EventHandler(this.lbl_DispSpeed_AdjMax_Click);
            // 
            // lbl_DispTime_AdjMax
            // 
            this.lbl_DispTime_AdjMax.BackColor = System.Drawing.Color.White;
            this.lbl_DispTime_AdjMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DispTime_AdjMax.Location = new System.Drawing.Point(211, 57);
            this.lbl_DispTime_AdjMax.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispTime_AdjMax.Name = "lbl_DispTime_AdjMax";
            this.lbl_DispTime_AdjMax.Size = new System.Drawing.Size(60, 30);
            this.lbl_DispTime_AdjMax.TabIndex = 45;
            this.lbl_DispTime_AdjMax.Text = "0.0001";
            this.lbl_DispTime_AdjMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispTime_AdjMax.Click += new System.EventHandler(this.lbl_DispTime_AdjMax_Click);
            // 
            // lbl_DispSpeed_AdjMin
            // 
            this.lbl_DispSpeed_AdjMin.BackColor = System.Drawing.Color.White;
            this.lbl_DispSpeed_AdjMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DispSpeed_AdjMin.Location = new System.Drawing.Point(145, 21);
            this.lbl_DispSpeed_AdjMin.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispSpeed_AdjMin.Name = "lbl_DispSpeed_AdjMin";
            this.lbl_DispSpeed_AdjMin.Size = new System.Drawing.Size(60, 30);
            this.lbl_DispSpeed_AdjMin.TabIndex = 43;
            this.lbl_DispSpeed_AdjMin.Text = "0.0001";
            this.lbl_DispSpeed_AdjMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispSpeed_AdjMin.Click += new System.EventHandler(this.lbl_DispSpeed_AdjMin_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Disp Speed Min Max";
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 30);
            this.label10.TabIndex = 41;
            this.label10.Text = "Disp Speed Min Max";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DispTime_AdjMin
            // 
            this.lbl_DispTime_AdjMin.BackColor = System.Drawing.Color.White;
            this.lbl_DispTime_AdjMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DispTime_AdjMin.Location = new System.Drawing.Point(145, 57);
            this.lbl_DispTime_AdjMin.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispTime_AdjMin.Name = "lbl_DispTime_AdjMin";
            this.lbl_DispTime_AdjMin.Size = new System.Drawing.Size(60, 30);
            this.lbl_DispTime_AdjMin.TabIndex = 36;
            this.lbl_DispTime_AdjMin.Text = "0.0001";
            this.lbl_DispTime_AdjMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispTime_AdjMin.Click += new System.EventHandler(this.lbl_DispTime_AdjMin_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleDescription = "Settings";
            this.btnSettings.Location = new System.Drawing.Point(342, 39);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 30);
            this.btnSettings.TabIndex = 132;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTimerTrig);
            this.groupBox1.Controls.Add(this.lblTrigTimer);
            this.groupBox1.Location = new System.Drawing.Point(223, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 144);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 30);
            this.label1.TabIndex = 133;
            this.label1.Text = "Timer (s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTimerTrig
            // 
            this.btnTimerTrig.AccessibleDescription = "Timer Trig";
            this.btnTimerTrig.Location = new System.Drawing.Point(6, 93);
            this.btnTimerTrig.Name = "btnTimerTrig";
            this.btnTimerTrig.Size = new System.Drawing.Size(75, 30);
            this.btnTimerTrig.TabIndex = 105;
            this.btnTimerTrig.Text = "Timer Trig";
            this.btnTimerTrig.UseVisualStyleBackColor = true;
            this.btnTimerTrig.Click += new System.EventHandler(this.btnTimerTrig_Click);
            // 
            // lblTrigTimer
            // 
            this.lblTrigTimer.BackColor = System.Drawing.Color.White;
            this.lblTrigTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTrigTimer.Location = new System.Drawing.Point(6, 57);
            this.lblTrigTimer.Margin = new System.Windows.Forms.Padding(3);
            this.lblTrigTimer.Name = "lblTrigTimer";
            this.lblTrigTimer.Size = new System.Drawing.Size(75, 30);
            this.lblTrigTimer.TabIndex = 132;
            this.lblTrigTimer.Text = "000.001";
            this.lblTrigTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrigTimer.Click += new System.EventHandler(this.lblHMTimer_Click);
            // 
            // btnTrig
            // 
            this.btnTrig.AccessibleDescription = "Trig";
            this.btnTrig.Location = new System.Drawing.Point(229, 4);
            this.btnTrig.Name = "btnTrig";
            this.btnTrig.Size = new System.Drawing.Size(75, 30);
            this.btnTrig.TabIndex = 134;
            this.btnTrig.Text = "Trig";
            this.btnTrig.UseVisualStyleBackColor = true;
            this.btnTrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTrig_MouseDown);
            this.btnTrig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTrig_MouseUp);
            // 
            // frm_DispTool_SpeedAdjust
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(424, 345);
            this.ControlBox = false;
            this.Controls.Add(this.btnTrig);
            this.Controls.Add(this.lbl_PressUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_FPressA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_HeadA_BSuckTime);
            this.Controls.Add(this.lbl_HeadA_BSuckSpeed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_HeadA_DispTime);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lbl_HeadA_DispSpeed);
            this.Controls.Add(this.lbl_l_Disp);
            this.Controls.Add(this.lbl_l_HeadADispUnit);
            this.Controls.Add(this.gboxSettings);
            this.Controls.Add(this.btn_Close);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispTool_SpeedAdjust";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = " ";
            this.Load += new System.EventHandler(this.frm_DispTool_SpeedAdjust_Load);
            this.gboxSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_l_Disp;
        private System.Windows.Forms.Label lbl_l_HeadADispUnit;
        private System.Windows.Forms.Label lbl_HeadA_DispSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_HeadA_BSuckTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_HeadA_BSuckSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_PressUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_FPressA;
        private System.Windows.Forms.GroupBox gboxSettings;
        private System.Windows.Forms.Label lbl_HeadA_DispTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_DispTime_AdjMin;
        private System.Windows.Forms.Label lbl_DispSpeed_AdjMin;
        private System.Windows.Forms.Label lbl_FPress_AdjMin;
        private System.Windows.Forms.Label lbl_FPress_AdjMax;
        private System.Windows.Forms.Label lbl_DispSpeed_AdjMax;
        private System.Windows.Forms.Label lbl_DispTime_AdjMax;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimerTrig;
        private System.Windows.Forms.Label lblTrigTimer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrig;
    }
}