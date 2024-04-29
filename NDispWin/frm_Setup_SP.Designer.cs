namespace NDispWin
{
    partial class frm_Setup_SP
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
            this.lbl_PulseOnDelay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_DispTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_FPressA = new System.Windows.Forms.Label();
            this.lbl_PressUnit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_FPress = new System.Windows.Forms.Button();
            this.lbl_FPressB = new System.Windows.Forms.Label();
            this.lbl_Press2Unit = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_PPress = new System.Windows.Forms.Button();
            this.lbl_FPressH = new System.Windows.Forms.Label();
            this.btn_FPressH = new System.Windows.Forms.Button();
            this.btn_Shot = new System.Windows.Forms.Button();
            this.lbl_PulseOffDelay = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPPressOnDelayHelp = new System.Windows.Forms.Button();
            this.rbPOnDelay = new System.Windows.Forms.RadioButton();
            this.rbPOnEarly = new System.Windows.Forms.RadioButton();
            this.rbPOffEarly = new System.Windows.Forms.RadioButton();
            this.rbPOffDelay = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FPress_AdjMin = new System.Windows.Forms.Label();
            this.lbl_FPress_AdjMax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_PPress_AdjMin = new System.Windows.Forms.Label();
            this.lbl_PPress_AdjMax = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.gbAdvance = new System.Windows.Forms.GroupBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblFPressHTimer = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tmr500ms = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbAdvance.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_PulseOnDelay
            // 
            this.lbl_PulseOnDelay.BackColor = System.Drawing.Color.White;
            this.lbl_PulseOnDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PulseOnDelay.Location = new System.Drawing.Point(152, 21);
            this.lbl_PulseOnDelay.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PulseOnDelay.Name = "lbl_PulseOnDelay";
            this.lbl_PulseOnDelay.Size = new System.Drawing.Size(60, 30);
            this.lbl_PulseOnDelay.TabIndex = 87;
            this.lbl_PulseOnDelay.Text = "000.001";
            this.lbl_PulseOnDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PulseOnDelay.Click += new System.EventHandler(this.lbl_PulseOnDelay_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(106, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 30);
            this.label7.TabIndex = 89;
            this.label7.Text = "(ms)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // lbl_DispTime
            // 
            this.lbl_DispTime.BackColor = System.Drawing.Color.White;
            this.lbl_DispTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DispTime.Location = new System.Drawing.Point(160, 137);
            this.lbl_DispTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispTime.Name = "lbl_DispTime";
            this.lbl_DispTime.Size = new System.Drawing.Size(60, 30);
            this.lbl_DispTime.TabIndex = 84;
            this.lbl_DispTime.Text = "000.001";
            this.lbl_DispTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DispTime.Click += new System.EventHandler(this.lbl_DispTime_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(114, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 30);
            this.label3.TabIndex = 86;
            this.label3.Text = "(ms)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Disp Time";
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(8, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.TabIndex = 85;
            this.label4.Text = "Disp Time";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl_FPressA
            // 
            this.lbl_FPressA.BackColor = System.Drawing.Color.White;
            this.lbl_FPressA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressA.Location = new System.Drawing.Point(160, 65);
            this.lbl_FPressA.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressA.Name = "lbl_FPressA";
            this.lbl_FPressA.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressA.TabIndex = 81;
            this.lbl_FPressA.Text = "000.001";
            this.lbl_FPressA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressA.Click += new System.EventHandler(this.lbl_FPressA_Click);
            // 
            // lbl_PressUnit
            // 
            this.lbl_PressUnit.AccessibleDescription = "";
            this.lbl_PressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_PressUnit.Location = new System.Drawing.Point(114, 65);
            this.lbl_PressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PressUnit.Name = "lbl_PressUnit";
            this.lbl_PressUnit.Size = new System.Drawing.Size(40, 30);
            this.lbl_PressUnit.TabIndex = 83;
            this.lbl_PressUnit.Text = "(psi)";
            this.lbl_PressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PressUnit.Click += new System.EventHandler(this.lbl_PressUnit_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "F Pressure";
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 30);
            this.label6.TabIndex = 82;
            this.label6.Text = "F Pressure";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_FPress
            // 
            this.btn_FPress.AccessibleDescription = "F Press";
            this.btn_FPress.Location = new System.Drawing.Point(226, 65);
            this.btn_FPress.Name = "btn_FPress";
            this.btn_FPress.Size = new System.Drawing.Size(75, 30);
            this.btn_FPress.TabIndex = 79;
            this.btn_FPress.Text = "F Press";
            this.btn_FPress.UseVisualStyleBackColor = true;
            this.btn_FPress.Click += new System.EventHandler(this.btn_FPress_Click);
            this.btn_FPress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_FPress_MouseDown);
            this.btn_FPress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_FPress_MouseUp);
            // 
            // lbl_FPressB
            // 
            this.lbl_FPressB.BackColor = System.Drawing.Color.White;
            this.lbl_FPressB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressB.Location = new System.Drawing.Point(160, 101);
            this.lbl_FPressB.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressB.Name = "lbl_FPressB";
            this.lbl_FPressB.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressB.TabIndex = 97;
            this.lbl_FPressB.Text = "000.001";
            this.lbl_FPressB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressB.Click += new System.EventHandler(this.lbl_FPressB_Click);
            // 
            // lbl_Press2Unit
            // 
            this.lbl_Press2Unit.AccessibleDescription = "";
            this.lbl_Press2Unit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Press2Unit.Location = new System.Drawing.Point(114, 101);
            this.lbl_Press2Unit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Press2Unit.Name = "lbl_Press2Unit";
            this.lbl_Press2Unit.Size = new System.Drawing.Size(40, 30);
            this.lbl_Press2Unit.TabIndex = 99;
            this.lbl_Press2Unit.Text = "(psi)";
            this.lbl_Press2Unit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Press2Unit.Click += new System.EventHandler(this.lbl_Press2Unit_Click);
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "P Pressure";
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(8, 101);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 30);
            this.label13.TabIndex = 98;
            this.label13.Text = "P Pressure";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btn_PPress
            // 
            this.btn_PPress.AccessibleDescription = "P Press";
            this.btn_PPress.Location = new System.Drawing.Point(226, 101);
            this.btn_PPress.Name = "btn_PPress";
            this.btn_PPress.Size = new System.Drawing.Size(75, 30);
            this.btn_PPress.TabIndex = 100;
            this.btn_PPress.Text = "P Press";
            this.btn_PPress.UseVisualStyleBackColor = true;
            this.btn_PPress.Click += new System.EventHandler(this.btn_PPress_Click);
            this.btn_PPress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_PPress_MouseDown);
            this.btn_PPress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_PPress_MouseUp);
            // 
            // lbl_FPressH
            // 
            this.lbl_FPressH.BackColor = System.Drawing.Color.White;
            this.lbl_FPressH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressH.Location = new System.Drawing.Point(6, 21);
            this.lbl_FPressH.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressH.Name = "lbl_FPressH";
            this.lbl_FPressH.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPressH.TabIndex = 102;
            this.lbl_FPressH.Text = "000.001";
            this.lbl_FPressH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressH.Click += new System.EventHandler(this.lbl_FPressH_Click);
            // 
            // btn_FPressH
            // 
            this.btn_FPressH.AccessibleDescription = "F Press H";
            this.btn_FPressH.Location = new System.Drawing.Point(72, 21);
            this.btn_FPressH.Name = "btn_FPressH";
            this.btn_FPressH.Size = new System.Drawing.Size(75, 30);
            this.btn_FPressH.TabIndex = 105;
            this.btn_FPressH.Text = "F Press H";
            this.btn_FPressH.UseVisualStyleBackColor = true;
            this.btn_FPressH.Click += new System.EventHandler(this.btn_FPressH_Click);
            this.btn_FPressH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_FPressH_MouseDown);
            this.btn_FPressH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_FPressH_MouseUp);
            // 
            // btn_Shot
            // 
            this.btn_Shot.AccessibleDescription = "Trigger";
            this.btn_Shot.Location = new System.Drawing.Point(401, 251);
            this.btn_Shot.Name = "btn_Shot";
            this.btn_Shot.Size = new System.Drawing.Size(75, 30);
            this.btn_Shot.TabIndex = 90;
            this.btn_Shot.Text = "Shot";
            this.btn_Shot.UseVisualStyleBackColor = true;
            this.btn_Shot.Click += new System.EventHandler(this.btn_Shot_Click);
            // 
            // lbl_PulseOffDelay
            // 
            this.lbl_PulseOffDelay.BackColor = System.Drawing.Color.White;
            this.lbl_PulseOffDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PulseOffDelay.Location = new System.Drawing.Point(152, 57);
            this.lbl_PulseOffDelay.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PulseOffDelay.Name = "lbl_PulseOffDelay";
            this.lbl_PulseOffDelay.Size = new System.Drawing.Size(60, 30);
            this.lbl_PulseOffDelay.TabIndex = 106;
            this.lbl_PulseOffDelay.Text = "000.001";
            this.lbl_PulseOffDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PulseOffDelay.Click += new System.EventHandler(this.lbl_PulseOffDelay_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(393, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 107;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "P Pressure On";
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 108;
            this.label1.Text = "P Pressure On";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "P Pressure Off";
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 109;
            this.label2.Text = "P Pressure Off";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(106, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 30);
            this.label11.TabIndex = 89;
            this.label11.Text = "(ms)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnPPressOnDelayHelp
            // 
            this.btnPPressOnDelayHelp.Location = new System.Drawing.Point(350, 25);
            this.btnPPressOnDelayHelp.Name = "btnPPressOnDelayHelp";
            this.btnPPressOnDelayHelp.Size = new System.Drawing.Size(31, 23);
            this.btnPPressOnDelayHelp.TabIndex = 114;
            this.btnPPressOnDelayHelp.Text = "?";
            this.btnPPressOnDelayHelp.UseVisualStyleBackColor = true;
            this.btnPPressOnDelayHelp.Click += new System.EventHandler(this.btnPPressOnDelayHelp_Click);
            // 
            // rbPOnDelay
            // 
            this.rbPOnDelay.AutoSize = true;
            this.rbPOnDelay.Checked = true;
            this.rbPOnDelay.Location = new System.Drawing.Point(3, 3);
            this.rbPOnDelay.Name = "rbPOnDelay";
            this.rbPOnDelay.Size = new System.Drawing.Size(54, 18);
            this.rbPOnDelay.TabIndex = 117;
            this.rbPOnDelay.TabStop = true;
            this.rbPOnDelay.Text = "Delay";
            this.rbPOnDelay.UseVisualStyleBackColor = true;
            this.rbPOnDelay.Click += new System.EventHandler(this.rbPOnDelay_Click);
            // 
            // rbPOnEarly
            // 
            this.rbPOnEarly.AutoSize = true;
            this.rbPOnEarly.Location = new System.Drawing.Point(63, 3);
            this.rbPOnEarly.Name = "rbPOnEarly";
            this.rbPOnEarly.Size = new System.Drawing.Size(50, 18);
            this.rbPOnEarly.TabIndex = 118;
            this.rbPOnEarly.TabStop = true;
            this.rbPOnEarly.Text = "Early";
            this.rbPOnEarly.UseVisualStyleBackColor = true;
            this.rbPOnEarly.Click += new System.EventHandler(this.rbPOnEarly_Click);
            // 
            // rbPOffEarly
            // 
            this.rbPOffEarly.AutoSize = true;
            this.rbPOffEarly.Location = new System.Drawing.Point(63, 3);
            this.rbPOffEarly.Name = "rbPOffEarly";
            this.rbPOffEarly.Size = new System.Drawing.Size(50, 18);
            this.rbPOffEarly.TabIndex = 120;
            this.rbPOffEarly.Text = "Early";
            this.rbPOffEarly.UseVisualStyleBackColor = true;
            this.rbPOffEarly.Click += new System.EventHandler(this.rbPOffEarly_Click);
            // 
            // rbPOffDelay
            // 
            this.rbPOffDelay.AutoSize = true;
            this.rbPOffDelay.Checked = true;
            this.rbPOffDelay.Location = new System.Drawing.Point(3, 3);
            this.rbPOffDelay.Name = "rbPOffDelay";
            this.rbPOffDelay.Size = new System.Drawing.Size(54, 18);
            this.rbPOffDelay.TabIndex = 119;
            this.rbPOffDelay.TabStop = true;
            this.rbPOffDelay.Text = "Delay";
            this.rbPOffDelay.UseVisualStyleBackColor = true;
            this.rbPOffDelay.Click += new System.EventHandler(this.rbPOffDly_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.rbPOnDelay);
            this.panel1.Controls.Add(this.rbPOnEarly);
            this.panel1.Location = new System.Drawing.Point(218, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 24);
            this.panel1.TabIndex = 121;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.rbPOffDelay);
            this.panel2.Controls.Add(this.rbPOffEarly);
            this.panel2.Location = new System.Drawing.Point(218, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 24);
            this.panel2.TabIndex = 122;
            // 
            // lbl_FPress_AdjMin
            // 
            this.lbl_FPress_AdjMin.BackColor = System.Drawing.Color.White;
            this.lbl_FPress_AdjMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPress_AdjMin.Location = new System.Drawing.Point(9, 58);
            this.lbl_FPress_AdjMin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_FPress_AdjMin.Name = "lbl_FPress_AdjMin";
            this.lbl_FPress_AdjMin.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPress_AdjMin.TabIndex = 123;
            this.lbl_FPress_AdjMin.Text = "0.0001";
            this.lbl_FPress_AdjMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPress_AdjMin.Click += new System.EventHandler(this.lbl_FPress_AdjMin_Click);
            // 
            // lbl_FPress_AdjMax
            // 
            this.lbl_FPress_AdjMax.BackColor = System.Drawing.Color.White;
            this.lbl_FPress_AdjMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPress_AdjMax.Location = new System.Drawing.Point(75, 58);
            this.lbl_FPress_AdjMax.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_FPress_AdjMax.Name = "lbl_FPress_AdjMax";
            this.lbl_FPress_AdjMax.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPress_AdjMax.TabIndex = 124;
            this.lbl_FPress_AdjMax.Text = "0.0001";
            this.lbl_FPress_AdjMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPress_AdjMax.Click += new System.EventHandler(this.lbl_FPress_AdjMax_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Adj Max";
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(72, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 30);
            this.label8.TabIndex = 126;
            this.label8.Text = "Adj Max";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Adj Min";
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 30);
            this.label10.TabIndex = 125;
            this.label10.Text = "Adj Min";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PPress_AdjMin
            // 
            this.lbl_PPress_AdjMin.BackColor = System.Drawing.Color.White;
            this.lbl_PPress_AdjMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PPress_AdjMin.Location = new System.Drawing.Point(9, 94);
            this.lbl_PPress_AdjMin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_PPress_AdjMin.Name = "lbl_PPress_AdjMin";
            this.lbl_PPress_AdjMin.Size = new System.Drawing.Size(60, 30);
            this.lbl_PPress_AdjMin.TabIndex = 127;
            this.lbl_PPress_AdjMin.Text = "0.0001";
            this.lbl_PPress_AdjMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PPress_AdjMin.Click += new System.EventHandler(this.lbl_PPress_AdjMin_Click);
            // 
            // lbl_PPress_AdjMax
            // 
            this.lbl_PPress_AdjMax.BackColor = System.Drawing.Color.White;
            this.lbl_PPress_AdjMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PPress_AdjMax.Location = new System.Drawing.Point(75, 94);
            this.lbl_PPress_AdjMax.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_PPress_AdjMax.Name = "lbl_PPress_AdjMax";
            this.lbl_PPress_AdjMax.Size = new System.Drawing.Size(60, 30);
            this.lbl_PPress_AdjMax.TabIndex = 128;
            this.lbl_PPress_AdjMax.Text = "0.0001";
            this.lbl_PPress_AdjMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PPress_AdjMax.Click += new System.EventHandler(this.lbl_PPress_AdjMax_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.AutoSize = true;
            this.gbSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSettings.Controls.Add(this.label10);
            this.gbSettings.Controls.Add(this.lbl_PPress_AdjMin);
            this.gbSettings.Controls.Add(this.lbl_FPress_AdjMax);
            this.gbSettings.Controls.Add(this.lbl_PPress_AdjMax);
            this.gbSettings.Controls.Add(this.lbl_FPress_AdjMin);
            this.gbSettings.Controls.Add(this.label8);
            this.gbSettings.Location = new System.Drawing.Point(474, 8);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(141, 142);
            this.gbSettings.TabIndex = 129;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            this.gbSettings.Visible = false;
            // 
            // gbAdvance
            // 
            this.gbAdvance.AutoSize = true;
            this.gbAdvance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbAdvance.Controls.Add(this.label1);
            this.gbAdvance.Controls.Add(this.label7);
            this.gbAdvance.Controls.Add(this.panel2);
            this.gbAdvance.Controls.Add(this.lbl_PulseOnDelay);
            this.gbAdvance.Controls.Add(this.panel1);
            this.gbAdvance.Controls.Add(this.label11);
            this.gbAdvance.Controls.Add(this.btnPPressOnDelayHelp);
            this.gbAdvance.Controls.Add(this.lbl_PulseOffDelay);
            this.gbAdvance.Controls.Add(this.label2);
            this.gbAdvance.Location = new System.Drawing.Point(8, 173);
            this.gbAdvance.Name = "gbAdvance";
            this.gbAdvance.Size = new System.Drawing.Size(387, 108);
            this.gbAdvance.TabIndex = 130;
            this.gbAdvance.TabStop = false;
            this.gbAdvance.Text = "Advance";
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleDescription = "Settings";
            this.btnSettings.Location = new System.Drawing.Point(312, 8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 30);
            this.btnSettings.TabIndex = 131;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblFPressHTimer
            // 
            this.lblFPressHTimer.BackColor = System.Drawing.Color.White;
            this.lblFPressHTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFPressHTimer.Location = new System.Drawing.Point(72, 57);
            this.lblFPressHTimer.Margin = new System.Windows.Forms.Padding(3);
            this.lblFPressHTimer.Name = "lblFPressHTimer";
            this.lblFPressHTimer.Size = new System.Drawing.Size(75, 30);
            this.lblFPressHTimer.TabIndex = 132;
            this.lblFPressHTimer.Text = "000.001";
            this.lblFPressHTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFPressHTimer.Click += new System.EventHandler(this.lblFPressHTimer_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "";
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(6, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 30);
            this.label9.TabIndex = 133;
            this.label9.Text = "Timer (s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_FPressH);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btn_FPressH);
            this.groupBox1.Controls.Add(this.lblFPressHTimer);
            this.groupBox1.Location = new System.Drawing.Point(315, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 108);
            this.groupBox1.TabIndex = 134;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "F Press H";
            // 
            // tmr500ms
            // 
            this.tmr500ms.Interval = 500;
            this.tmr500ms.Tick += new System.EventHandler(this.tmr500ms_Tick);
            // 
            // frm_Setup_SP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(638, 299);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.gbAdvance);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_PPress);
            this.Controls.Add(this.lbl_FPressB);
            this.Controls.Add(this.lbl_Press2Unit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_Shot);
            this.Controls.Add(this.lbl_DispTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_FPressA);
            this.Controls.Add(this.lbl_PressUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_FPress);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Setup_SP";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmSetup_SP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Setup_SP_FormClosing);
            this.Load += new System.EventHandler(this.frmSetup_SP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbAdvance.ResumeLayout(false);
            this.gbAdvance.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PulseOnDelay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_DispTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_FPressA;
        private System.Windows.Forms.Label lbl_PressUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_FPress;
        private System.Windows.Forms.Label lbl_FPressB;
        private System.Windows.Forms.Label lbl_Press2Unit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_PPress;
        private System.Windows.Forms.Label lbl_FPressH;
        private System.Windows.Forms.Button btn_FPressH;
        private System.Windows.Forms.Button btn_Shot;
        private System.Windows.Forms.Label lbl_PulseOffDelay;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPPressOnDelayHelp;
        private System.Windows.Forms.RadioButton rbPOnDelay;
        private System.Windows.Forms.RadioButton rbPOnEarly;
        private System.Windows.Forms.RadioButton rbPOffEarly;
        private System.Windows.Forms.RadioButton rbPOffDelay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FPress_AdjMin;
        private System.Windows.Forms.Label lbl_FPress_AdjMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_PPress_AdjMin;
        private System.Windows.Forms.Label lbl_PPress_AdjMax;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbAdvance;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblFPressHTimer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer tmr500ms;
    }
}