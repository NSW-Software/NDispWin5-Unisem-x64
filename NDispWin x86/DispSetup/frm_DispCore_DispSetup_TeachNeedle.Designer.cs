namespace NDispWin
{
    partial class frm_DispCore_DispSetup_TeachNeedle
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
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_ZTouchDetectMethod = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbox_PromptLaserClean = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_LaserChangeRate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_DotVol = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_NeedleGap = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_DotTime = new System.Windows.Forms.Label();
            this.gbox_ZSensorMarkSet = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_TeachNeedleDownTime = new System.Windows.Forms.Label();
            this.lbl_TeachNeedleZOfst = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_MultiHeadXYTol = new System.Windows.Forms.Label();
            this.cbox_RequireOnLotStart = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_CleanStagePos = new System.Windows.Forms.Label();
            this.btn_Goto = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.cbox_PromptCleanStage = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_MultiHeadZTol = new System.Windows.Forms.Label();
            this.lbl_TeachNeedleMethod = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox13.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbox_ZSensorMarkSet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox13
            // 
            this.groupBox13.AccessibleDescription = "Teach Needle";
            this.groupBox13.AutoSize = true;
            this.groupBox13.Controls.Add(this.groupBox3);
            this.groupBox13.Controls.Add(this.groupBox2);
            this.groupBox13.Controls.Add(this.groupBox1);
            this.groupBox13.Controls.Add(this.gbox_ZSensorMarkSet);
            this.groupBox13.Controls.Add(this.panel1);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(594, 509);
            this.groupBox13.TabIndex = 150;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Teach Needle";
            this.groupBox13.Enter += new System.EventHandler(this.groupBox13_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lbl_ZTouchDetectMethod);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox3.Size = new System.Drawing.Size(588, 64);
            this.groupBox3.TabIndex = 175;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Z Touch";
            // 
            // lbl_ZTouchDetectMethod
            // 
            this.lbl_ZTouchDetectMethod.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ZTouchDetectMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ZTouchDetectMethod.Location = new System.Drawing.Point(207, 20);
            this.lbl_ZTouchDetectMethod.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ZTouchDetectMethod.Name = "lbl_ZTouchDetectMethod";
            this.lbl_ZTouchDetectMethod.Size = new System.Drawing.Size(75, 23);
            this.lbl_ZTouchDetectMethod.TabIndex = 176;
            this.lbl_ZTouchDetectMethod.Text = "0";
            this.lbl_ZTouchDetectMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ZTouchDetectMethod.Click += new System.EventHandler(this.lbl_ZTouchDetectMethod_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "Detect Method";
            this.label15.Location = new System.Drawing.Point(5, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(180, 23);
            this.label15.TabIndex = 175;
            this.label15.Text = "Detect Method";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Laser";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.cbox_PromptLaserClean);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lbl_LaserChangeRate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 353);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox2.Size = new System.Drawing.Size(588, 89);
            this.groupBox2.TabIndex = 174;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Laser";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "";
            this.label17.Location = new System.Drawing.Point(153, 44);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 23);
            this.label17.TabIndex = 179;
            this.label17.Text = "(mm)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbox_PromptLaserClean
            // 
            this.cbox_PromptLaserClean.AutoSize = true;
            this.cbox_PromptLaserClean.Location = new System.Drawing.Point(8, 21);
            this.cbox_PromptLaserClean.Name = "cbox_PromptLaserClean";
            this.cbox_PromptLaserClean.Size = new System.Drawing.Size(157, 22);
            this.cbox_PromptLaserClean.TabIndex = 178;
            this.cbox_PromptLaserClean.Text = "Prompt Laser Clean";
            this.cbox_PromptLaserClean.UseVisualStyleBackColor = true;
            this.cbox_PromptLaserClean.Click += new System.EventHandler(this.cbox_PromptLaserClean_Click);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Change Rate";
            this.label14.Location = new System.Drawing.Point(5, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(180, 23);
            this.label14.TabIndex = 166;
            this.label14.Text = "Change Rate";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LaserChangeRate
            // 
            this.lbl_LaserChangeRate.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_LaserChangeRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LaserChangeRate.Location = new System.Drawing.Point(208, 44);
            this.lbl_LaserChangeRate.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_LaserChangeRate.Name = "lbl_LaserChangeRate";
            this.lbl_LaserChangeRate.Size = new System.Drawing.Size(75, 23);
            this.lbl_LaserChangeRate.TabIndex = 167;
            this.lbl_LaserChangeRate.Text = "999";
            this.lbl_LaserChangeRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_LaserChangeRate.Click += new System.EventHandler(this.lbl_LaserHeightChangeRate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Touch Dot";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_DotVol);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_NeedleGap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_DotTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 233);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(588, 120);
            this.groupBox1.TabIndex = 173;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Touch Dot";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(152, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 177;
            this.label6.Text = "(ul)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Dot Volume";
            this.label9.Location = new System.Drawing.Point(5, 75);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 23);
            this.label9.TabIndex = 175;
            this.label9.Text = "Dot Volume";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DotVol
            // 
            this.lbl_DotVol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_DotVol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DotVol.Location = new System.Drawing.Point(207, 75);
            this.lbl_DotVol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DotVol.Name = "lbl_DotVol";
            this.lbl_DotVol.Size = new System.Drawing.Size(75, 23);
            this.lbl_DotVol.TabIndex = 176;
            this.lbl_DotVol.Text = "999";
            this.lbl_DotVol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_DotVol.Click += new System.EventHandler(this.lbl_DotVol_Click);
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.Location = new System.Drawing.Point(152, 48);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 23);
            this.label11.TabIndex = 174;
            this.label11.Text = "(ms)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.Location = new System.Drawing.Point(152, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 23);
            this.label10.TabIndex = 173;
            this.label10.Text = "(mm)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_NeedleGap
            // 
            this.lbl_NeedleGap.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_NeedleGap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_NeedleGap.Location = new System.Drawing.Point(207, 21);
            this.lbl_NeedleGap.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_NeedleGap.Name = "lbl_NeedleGap";
            this.lbl_NeedleGap.Size = new System.Drawing.Size(75, 23);
            this.lbl_NeedleGap.TabIndex = 172;
            this.lbl_NeedleGap.Text = "1";
            this.lbl_NeedleGap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_NeedleGap.Click += new System.EventHandler(this.lbl_NeedleGap_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Dot Time";
            this.label7.Location = new System.Drawing.Point(5, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 23);
            this.label7.TabIndex = 166;
            this.label7.Text = "Dot Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Needle Gap";
            this.label8.Location = new System.Drawing.Point(5, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 23);
            this.label8.TabIndex = 171;
            this.label8.Text = "Needle Gap";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DotTime
            // 
            this.lbl_DotTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_DotTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DotTime.Location = new System.Drawing.Point(207, 48);
            this.lbl_DotTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DotTime.Name = "lbl_DotTime";
            this.lbl_DotTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_DotTime.TabIndex = 167;
            this.lbl_DotTime.Text = "999";
            this.lbl_DotTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_DotTime.Click += new System.EventHandler(this.lbl_DotTime_Click);
            // 
            // gbox_ZSensorMarkSet
            // 
            this.gbox_ZSensorMarkSet.AccessibleDescription = "Z Sensor Mark Set";
            this.gbox_ZSensorMarkSet.AutoSize = true;
            this.gbox_ZSensorMarkSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_ZSensorMarkSet.Controls.Add(this.label5);
            this.gbox_ZSensorMarkSet.Controls.Add(this.label4);
            this.gbox_ZSensorMarkSet.Controls.Add(this.label18);
            this.gbox_ZSensorMarkSet.Controls.Add(this.label22);
            this.gbox_ZSensorMarkSet.Controls.Add(this.lbl_TeachNeedleDownTime);
            this.gbox_ZSensorMarkSet.Controls.Add(this.lbl_TeachNeedleZOfst);
            this.gbox_ZSensorMarkSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox_ZSensorMarkSet.Location = new System.Drawing.Point(3, 141);
            this.gbox_ZSensorMarkSet.Margin = new System.Windows.Forms.Padding(0);
            this.gbox_ZSensorMarkSet.Name = "gbox_ZSensorMarkSet";
            this.gbox_ZSensorMarkSet.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_ZSensorMarkSet.Size = new System.Drawing.Size(588, 92);
            this.gbox_ZSensorMarkSet.TabIndex = 164;
            this.gbox_ZSensorMarkSet.TabStop = false;
            this.gbox_ZSensorMarkSet.Text = "Z Sensor Mark Set";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.Location = new System.Drawing.Point(153, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 23);
            this.label5.TabIndex = 171;
            this.label5.Text = "(ms)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(153, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 171;
            this.label4.Text = "(mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "Z Offset";
            this.label18.Location = new System.Drawing.Point(5, 20);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 23);
            this.label18.TabIndex = 166;
            this.label18.Text = "Z Offset";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AccessibleDescription = "Down Time";
            this.label22.Location = new System.Drawing.Point(5, 47);
            this.label22.Margin = new System.Windows.Forms.Padding(2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(180, 23);
            this.label22.TabIndex = 168;
            this.label22.Text = "Down Time";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_TeachNeedleDownTime
            // 
            this.lbl_TeachNeedleDownTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_TeachNeedleDownTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TeachNeedleDownTime.Location = new System.Drawing.Point(207, 47);
            this.lbl_TeachNeedleDownTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TeachNeedleDownTime.Name = "lbl_TeachNeedleDownTime";
            this.lbl_TeachNeedleDownTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_TeachNeedleDownTime.TabIndex = 169;
            this.lbl_TeachNeedleDownTime.Text = "999";
            this.lbl_TeachNeedleDownTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TeachNeedleDownTime.Click += new System.EventHandler(this.lbl_TeachNeedleDownTime_Click);
            // 
            // lbl_TeachNeedleZOfst
            // 
            this.lbl_TeachNeedleZOfst.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_TeachNeedleZOfst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TeachNeedleZOfst.Location = new System.Drawing.Point(207, 20);
            this.lbl_TeachNeedleZOfst.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TeachNeedleZOfst.Name = "lbl_TeachNeedleZOfst";
            this.lbl_TeachNeedleZOfst.Size = new System.Drawing.Size(75, 23);
            this.lbl_TeachNeedleZOfst.TabIndex = 167;
            this.lbl_TeachNeedleZOfst.Text = "999";
            this.lbl_TeachNeedleZOfst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TeachNeedleZOfst.Click += new System.EventHandler(this.lbl_TeachNeedleZOfst_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lbl_MultiHeadXYTol);
            this.panel1.Controls.Add(this.cbox_RequireOnLotStart);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.lbl_CleanStagePos);
            this.panel1.Controls.Add(this.btn_Goto);
            this.panel1.Controls.Add(this.btn_Set);
            this.panel1.Controls.Add(this.cbox_PromptCleanStage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbl_MultiHeadZTol);
            this.panel1.Controls.Add(this.lbl_TeachNeedleMethod);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panel1.Size = new System.Drawing.Size(588, 119);
            this.panel1.TabIndex = 171;
            // 
            // lbl_MultiHeadXYTol
            // 
            this.lbl_MultiHeadXYTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MultiHeadXYTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MultiHeadXYTol.Location = new System.Drawing.Point(208, 32);
            this.lbl_MultiHeadXYTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MultiHeadXYTol.Name = "lbl_MultiHeadXYTol";
            this.lbl_MultiHeadXYTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_MultiHeadXYTol.TabIndex = 186;
            this.lbl_MultiHeadXYTol.Text = "1";
            this.lbl_MultiHeadXYTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MultiHeadXYTol.Click += new System.EventHandler(this.lbl_MultiHeadXYTol_Click);
            // 
            // cbox_RequireOnLotStart
            // 
            this.cbox_RequireOnLotStart.AutoSize = true;
            this.cbox_RequireOnLotStart.Location = new System.Drawing.Point(289, 8);
            this.cbox_RequireOnLotStart.Name = "cbox_RequireOnLotStart";
            this.cbox_RequireOnLotStart.Size = new System.Drawing.Size(153, 22);
            this.cbox_RequireOnLotStart.TabIndex = 185;
            this.cbox_RequireOnLotStart.Text = "Require OnLotStart";
            this.cbox_RequireOnLotStart.UseVisualStyleBackColor = true;
            this.cbox_RequireOnLotStart.Click += new System.EventHandler(this.cbox_RequireOnLotStart_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Clean";
            this.label19.Location = new System.Drawing.Point(5, 85);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 184;
            this.label19.Text = "Clean Stage Pos";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CleanStagePos
            // 
            this.lbl_CleanStagePos.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CleanStagePos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CleanStagePos.Location = new System.Drawing.Point(129, 85);
            this.lbl_CleanStagePos.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_CleanStagePos.Name = "lbl_CleanStagePos";
            this.lbl_CleanStagePos.Size = new System.Drawing.Size(154, 23);
            this.lbl_CleanStagePos.TabIndex = 182;
            this.lbl_CleanStagePos.Text = "-100";
            this.lbl_CleanStagePos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Goto
            // 
            this.btn_Goto.AccessibleDescription = "Goto";
            this.btn_Goto.Location = new System.Drawing.Point(370, 81);
            this.btn_Goto.Name = "btn_Goto";
            this.btn_Goto.Size = new System.Drawing.Size(75, 30);
            this.btn_Goto.TabIndex = 180;
            this.btn_Goto.Text = "Goto";
            this.btn_Goto.UseVisualStyleBackColor = true;
            this.btn_Goto.Click += new System.EventHandler(this.btn_Goto_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.AccessibleDescription = "Set";
            this.btn_Set.Location = new System.Drawing.Point(289, 81);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(75, 30);
            this.btn_Set.TabIndex = 181;
            this.btn_Set.Text = "Set";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // cbox_PromptCleanStage
            // 
            this.cbox_PromptCleanStage.AutoSize = true;
            this.cbox_PromptCleanStage.Location = new System.Drawing.Point(8, 61);
            this.cbox_PromptCleanStage.Name = "cbox_PromptCleanStage";
            this.cbox_PromptCleanStage.Size = new System.Drawing.Size(159, 22);
            this.cbox_PromptCleanStage.TabIndex = 179;
            this.cbox_PromptCleanStage.Text = "Prompt Clean Stage";
            this.cbox_PromptCleanStage.UseVisualStyleBackColor = true;
            this.cbox_PromptCleanStage.CheckedChanged += new System.EventHandler(this.cbox_PromptCleanStage_CheckedChanged);
            this.cbox_PromptCleanStage.Click += new System.EventHandler(this.cbox_PromptCleanStage_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(153, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 171;
            this.label2.Text = "(mm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Method";
            this.label12.Location = new System.Drawing.Point(5, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 23);
            this.label12.TabIndex = 16;
            this.label12.Text = "Method";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MultiHeadZTol
            // 
            this.lbl_MultiHeadZTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MultiHeadZTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MultiHeadZTol.Location = new System.Drawing.Point(287, 32);
            this.lbl_MultiHeadZTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MultiHeadZTol.Name = "lbl_MultiHeadZTol";
            this.lbl_MultiHeadZTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_MultiHeadZTol.TabIndex = 163;
            this.lbl_MultiHeadZTol.Text = "1";
            this.lbl_MultiHeadZTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MultiHeadZTol.Click += new System.EventHandler(this.lbl_MultiHeadZTol_Click);
            // 
            // lbl_TeachNeedleMethod
            // 
            this.lbl_TeachNeedleMethod.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_TeachNeedleMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TeachNeedleMethod.Location = new System.Drawing.Point(129, 5);
            this.lbl_TeachNeedleMethod.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TeachNeedleMethod.Name = "lbl_TeachNeedleMethod";
            this.lbl_TeachNeedleMethod.Size = new System.Drawing.Size(154, 23);
            this.lbl_TeachNeedleMethod.TabIndex = 170;
            this.lbl_TeachNeedleMethod.Text = "999";
            this.lbl_TeachNeedleMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TeachNeedleMethod.Click += new System.EventHandler(this.lbl_TeachNeedleMethod_Click);
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "MultiHead Z Tol";
            this.label28.Location = new System.Drawing.Point(5, 32);
            this.label28.Margin = new System.Windows.Forms.Padding(3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(180, 23);
            this.label28.TabIndex = 162;
            this.label28.Text = "MultiHead Tol XY,Z";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispSetup_TeachNeedle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.groupBox13);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DispCore_DispSetup_TeachNeedle";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_DispSetup_TeachNeedle";
            this.Load += new System.EventHandler(this.frm_DispCore_DispSetup_TeachNeedle_Load);
            this.Shown += new System.EventHandler(this.frm_DispCore_DispSetup_TeachNeedle_Shown);
            this.VisibleChanged += new System.EventHandler(this.frm_DispCore_DispSetup_TeachNeedle_VisibleChanged);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbox_ZSensorMarkSet.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label lbl_TeachNeedleMethod;
        private System.Windows.Forms.Label lbl_TeachNeedleDownTime;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_TeachNeedleZOfst;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_MultiHeadZTol;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox gbox_ZSensorMarkSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_NeedleGap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_DotTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_DotVol;
        private System.Windows.Forms.CheckBox cbox_PromptLaserClean;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_LaserChangeRate;
        private System.Windows.Forms.CheckBox cbox_PromptCleanStage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_CleanStagePos;
        private System.Windows.Forms.Button btn_Goto;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.CheckBox cbox_RequireOnLotStart;
        private System.Windows.Forms.Label lbl_MultiHeadXYTol;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_ZTouchDetectMethod;
        private System.Windows.Forms.Label label15;
    }
}