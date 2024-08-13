namespace NDispWin
{
    partial class frm_DispCore_WeightCal
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_WeightCurrentValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_DotsPerSample = new System.Windows.Forms.Label();
            this.lbl_CalTarget = new System.Windows.Forms.Label();
            this.lbl_TargetName = new System.Windows.Forms.Label();
            this.lbox_Result = new System.Windows.Forms.ListBox();
            this.tmr_WeightDisplay = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Head1 = new System.Windows.Forms.Button();
            this.btn_Head2 = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_Result2 = new System.Windows.Forms.Label();
            this.lbl_Result1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Tare = new System.Windows.Forms.Button();
            this.lbl_CurrentCalName = new System.Windows.Forms.Label();
            this.lbl_CurrentCalUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CurrentCal1 = new System.Windows.Forms.Label();
            this.lbl_CurrentCal2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_CalTargetRange = new System.Windows.Forms.Label();
            this.lbl_TargetUnit = new System.Windows.Forms.Label();
            this.lbl_OutputResult = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Ctrl1 = new System.Windows.Forms.Button();
            this.btn_Ctrl2 = new System.Windows.Forms.Button();
            this.tmr_Start = new System.Windows.Forms.Timer(this.components);
            this.lbl_Status = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(620, 5);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 30);
            this.btn_Close.TabIndex = 160;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_WeightCurrentValue
            // 
            this.lbl_WeightCurrentValue.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_WeightCurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WeightCurrentValue.Location = new System.Drawing.Point(227, 20);
            this.lbl_WeightCurrentValue.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_WeightCurrentValue.Name = "lbl_WeightCurrentValue";
            this.lbl_WeightCurrentValue.Size = new System.Drawing.Size(70, 23);
            this.lbl_WeightCurrentValue.TabIndex = 161;
            this.lbl_WeightCurrentValue.Text = "0.0000";
            this.lbl_WeightCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Weight";
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 162;
            this.label4.Text = "Weight";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Start
            // 
            this.btn_Start.AccessibleDescription = "Start";
            this.btn_Start.Location = new System.Drawing.Point(227, 147);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(70, 30);
            this.btn_Start.TabIndex = 168;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // label22
            // 
            this.label22.AccessibleDescription = "";
            this.label22.Location = new System.Drawing.Point(98, 20);
            this.label22.Margin = new System.Windows.Forms.Padding(2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 23);
            this.label22.TabIndex = 199;
            this.label22.Text = "(count)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Dots/Sample";
            this.label11.Location = new System.Drawing.Point(5, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 23);
            this.label11.TabIndex = 195;
            this.label11.Text = "Dots/Sample";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DotsPerSample
            // 
            this.lbl_DotsPerSample.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DotsPerSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DotsPerSample.Location = new System.Drawing.Point(228, 20);
            this.lbl_DotsPerSample.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DotsPerSample.Name = "lbl_DotsPerSample";
            this.lbl_DotsPerSample.Size = new System.Drawing.Size(70, 23);
            this.lbl_DotsPerSample.TabIndex = 196;
            this.lbl_DotsPerSample.Text = "10";
            this.lbl_DotsPerSample.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CalTarget
            // 
            this.lbl_CalTarget.BackColor = System.Drawing.Color.White;
            this.lbl_CalTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CalTarget.Location = new System.Drawing.Point(228, 20);
            this.lbl_CalTarget.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CalTarget.Name = "lbl_CalTarget";
            this.lbl_CalTarget.Size = new System.Drawing.Size(70, 23);
            this.lbl_CalTarget.TabIndex = 186;
            this.lbl_CalTarget.Text = "50";
            this.lbl_CalTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CalTarget.Click += new System.EventHandler(this.lbl_CalTarget_Click);
            // 
            // lbl_TargetName
            // 
            this.lbl_TargetName.AccessibleDescription = "Weight";
            this.lbl_TargetName.Location = new System.Drawing.Point(5, 20);
            this.lbl_TargetName.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TargetName.Name = "lbl_TargetName";
            this.lbl_TargetName.Size = new System.Drawing.Size(70, 23);
            this.lbl_TargetName.TabIndex = 185;
            this.lbl_TargetName.Text = "Weight";
            this.lbl_TargetName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbox_Result
            // 
            this.lbox_Result.FormattingEnabled = true;
            this.lbox_Result.ItemHeight = 14;
            this.lbox_Result.Location = new System.Drawing.Point(314, 40);
            this.lbox_Result.Name = "lbox_Result";
            this.lbox_Result.Size = new System.Drawing.Size(376, 382);
            this.lbox_Result.TabIndex = 0;
            // 
            // tmr_WeightDisplay
            // 
            this.tmr_WeightDisplay.Enabled = true;
            this.tmr_WeightDisplay.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "Head";
            this.label13.Location = new System.Drawing.Point(11, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 30);
            this.label13.TabIndex = 179;
            this.label13.Text = "Head";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Head1
            // 
            this.btn_Head1.AccessibleDescription = "Head 1";
            this.btn_Head1.Location = new System.Drawing.Point(159, 5);
            this.btn_Head1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head1.Name = "btn_Head1";
            this.btn_Head1.Size = new System.Drawing.Size(70, 30);
            this.btn_Head1.TabIndex = 183;
            this.btn_Head1.Text = "Head 1";
            this.btn_Head1.UseVisualStyleBackColor = true;
            this.btn_Head1.Click += new System.EventHandler(this.btn_Head1_Click);
            // 
            // btn_Head2
            // 
            this.btn_Head2.AccessibleDescription = "Head 2";
            this.btn_Head2.Location = new System.Drawing.Point(233, 5);
            this.btn_Head2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head2.Name = "btn_Head2";
            this.btn_Head2.Size = new System.Drawing.Size(70, 30);
            this.btn_Head2.TabIndex = 182;
            this.btn_Head2.Text = "Head 2";
            this.btn_Head2.UseVisualStyleBackColor = true;
            this.btn_Head2.Click += new System.EventHandler(this.btn_Head2_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.AccessibleDescription = "Setting";
            this.btn_Setting.Location = new System.Drawing.Point(546, 5);
            this.btn_Setting.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(70, 30);
            this.btn_Setting.TabIndex = 189;
            this.btn_Setting.Text = "Setting";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lbl_Result2);
            this.groupBox3.Controls.Add(this.lbl_Result1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_Tare);
            this.groupBox3.Controls.Add(this.lbl_CurrentCalName);
            this.groupBox3.Controls.Add(this.lbl_CurrentCalUnit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lbl_CurrentCal1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lbl_CurrentCal2);
            this.groupBox3.Controls.Add(this.lbl_WeightCurrentValue);
            this.groupBox3.Controls.Add(this.btn_Start);
            this.groupBox3.Location = new System.Drawing.Point(6, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 200);
            this.groupBox3.TabIndex = 191;
            this.groupBox3.TabStop = false;
            // 
            // lbl_Result2
            // 
            this.lbl_Result2.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Result2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Result2.Location = new System.Drawing.Point(227, 107);
            this.lbl_Result2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Result2.Name = "lbl_Result2";
            this.lbl_Result2.Size = new System.Drawing.Size(70, 23);
            this.lbl_Result2.TabIndex = 197;
            this.lbl_Result2.Text = "-";
            this.lbl_Result2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Result1
            // 
            this.lbl_Result1.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Result1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Result1.Location = new System.Drawing.Point(153, 107);
            this.lbl_Result1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Result1.Name = "lbl_Result1";
            this.lbl_Result1.Size = new System.Drawing.Size(70, 23);
            this.lbl_Result1.TabIndex = 196;
            this.lbl_Result1.Text = "-";
            this.lbl_Result1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Result";
            this.label1.Location = new System.Drawing.Point(5, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 195;
            this.label1.Text = "Result";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Tare
            // 
            this.btn_Tare.AccessibleDescription = "Tare";
            this.btn_Tare.Location = new System.Drawing.Point(227, 47);
            this.btn_Tare.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tare.Name = "btn_Tare";
            this.btn_Tare.Size = new System.Drawing.Size(70, 23);
            this.btn_Tare.TabIndex = 194;
            this.btn_Tare.Text = "Tare";
            this.btn_Tare.UseVisualStyleBackColor = true;
            this.btn_Tare.Click += new System.EventHandler(this.btn_Tare_Click);
            // 
            // lbl_CurrentCalName
            // 
            this.lbl_CurrentCalName.AccessibleDescription = "Density";
            this.lbl_CurrentCalName.Location = new System.Drawing.Point(5, 80);
            this.lbl_CurrentCalName.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrentCalName.Name = "lbl_CurrentCalName";
            this.lbl_CurrentCalName.Size = new System.Drawing.Size(70, 23);
            this.lbl_CurrentCalName.TabIndex = 190;
            this.lbl_CurrentCalName.Text = "Density";
            this.lbl_CurrentCalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CurrentCalUnit
            // 
            this.lbl_CurrentCalUnit.Location = new System.Drawing.Point(79, 80);
            this.lbl_CurrentCalUnit.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrentCalUnit.Name = "lbl_CurrentCalUnit";
            this.lbl_CurrentCalUnit.Size = new System.Drawing.Size(70, 23);
            this.lbl_CurrentCalUnit.TabIndex = 191;
            this.lbl_CurrentCalUnit.Text = "(mg/ul)";
            this.lbl_CurrentCalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(153, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 23);
            this.label3.TabIndex = 189;
            this.label3.Text = "(mg)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CurrentCal1
            // 
            this.lbl_CurrentCal1.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CurrentCal1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentCal1.Location = new System.Drawing.Point(153, 80);
            this.lbl_CurrentCal1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrentCal1.Name = "lbl_CurrentCal1";
            this.lbl_CurrentCal1.Size = new System.Drawing.Size(70, 23);
            this.lbl_CurrentCal1.TabIndex = 192;
            this.lbl_CurrentCal1.Text = "0.0000";
            this.lbl_CurrentCal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CurrentCal2
            // 
            this.lbl_CurrentCal2.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CurrentCal2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentCal2.Location = new System.Drawing.Point(227, 80);
            this.lbl_CurrentCal2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrentCal2.Name = "lbl_CurrentCal2";
            this.lbl_CurrentCal2.Size = new System.Drawing.Size(70, 23);
            this.lbl_CurrentCal2.TabIndex = 193;
            this.lbl_CurrentCal2.Text = "0.0000";
            this.lbl_CurrentCal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Target";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_CalTargetRange);
            this.groupBox1.Controls.Add(this.lbl_CalTarget);
            this.groupBox1.Controls.Add(this.lbl_TargetName);
            this.groupBox1.Controls.Add(this.lbl_TargetUnit);
            this.groupBox1.Location = new System.Drawing.Point(5, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(303, 87);
            this.groupBox1.TabIndex = 193;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target";
            // 
            // lbl_CalTargetRange
            // 
            this.lbl_CalTargetRange.AccessibleDescription = "";
            this.lbl_CalTargetRange.Location = new System.Drawing.Point(154, 47);
            this.lbl_CalTargetRange.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CalTargetRange.Name = "lbl_CalTargetRange";
            this.lbl_CalTargetRange.Size = new System.Drawing.Size(144, 23);
            this.lbl_CalTargetRange.TabIndex = 191;
            this.lbl_CalTargetRange.Text = "lbl_CalTargetRange";
            this.lbl_CalTargetRange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TargetUnit
            // 
            this.lbl_TargetUnit.Location = new System.Drawing.Point(154, 20);
            this.lbl_TargetUnit.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TargetUnit.Name = "lbl_TargetUnit";
            this.lbl_TargetUnit.Size = new System.Drawing.Size(70, 23);
            this.lbl_TargetUnit.TabIndex = 190;
            this.lbl_TargetUnit.Text = "(mg)";
            this.lbl_TargetUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_OutputResult
            // 
            this.lbl_OutputResult.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_OutputResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_OutputResult.Location = new System.Drawing.Point(228, 47);
            this.lbl_OutputResult.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_OutputResult.Name = "lbl_OutputResult";
            this.lbl_OutputResult.Size = new System.Drawing.Size(70, 23);
            this.lbl_OutputResult.TabIndex = 216;
            this.lbl_OutputResult.Text = "Total";
            this.lbl_OutputResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AccessibleDescription = "Output Result";
            this.label35.Location = new System.Drawing.Point(5, 47);
            this.label35.Margin = new System.Windows.Forms.Padding(2);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(144, 23);
            this.label35.TabIndex = 215;
            this.label35.Text = "Output Result";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Sample/Result";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbl_DotsPerSample);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lbl_OutputResult);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Location = new System.Drawing.Point(5, 339);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 90);
            this.groupBox2.TabIndex = 194;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample/Result";
            // 
            // btn_Ctrl1
            // 
            this.btn_Ctrl1.AccessibleDescription = "";
            this.btn_Ctrl1.Location = new System.Drawing.Point(398, 5);
            this.btn_Ctrl1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Ctrl1.Name = "btn_Ctrl1";
            this.btn_Ctrl1.Size = new System.Drawing.Size(70, 30);
            this.btn_Ctrl1.TabIndex = 195;
            this.btn_Ctrl1.Text = "Ctrl 1";
            this.btn_Ctrl1.UseVisualStyleBackColor = true;
            this.btn_Ctrl1.Click += new System.EventHandler(this.btn_Ctrl1_Click);
            // 
            // btn_Ctrl2
            // 
            this.btn_Ctrl2.AccessibleDescription = "";
            this.btn_Ctrl2.Location = new System.Drawing.Point(472, 5);
            this.btn_Ctrl2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Ctrl2.Name = "btn_Ctrl2";
            this.btn_Ctrl2.Size = new System.Drawing.Size(70, 30);
            this.btn_Ctrl2.TabIndex = 196;
            this.btn_Ctrl2.Text = "Ctrl_2";
            this.btn_Ctrl2.UseVisualStyleBackColor = true;
            this.btn_Ctrl2.Click += new System.EventHandler(this.btn_Ctrl2_Click);
            // 
            // tmr_Start
            // 
            this.tmr_Start.Interval = 500;
            this.tmr_Start.Tick += new System.EventHandler(this.tmr_Start_Tick);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AccessibleDescription = "";
            this.lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Status.Location = new System.Drawing.Point(85, 5);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(70, 30);
            this.lbl_Status.TabIndex = 197;
            this.lbl_Status.Text = "Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 198;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 199;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(314, 428);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 65);
            this.groupBox4.TabIndex = 200;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Debug";
            // 
            // frm_DispCore_WeightCal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(719, 514);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.btn_Ctrl2);
            this.Controls.Add(this.btn_Ctrl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbox_Result);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.btn_Head1);
            this.Controls.Add(this.btn_Head2);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DispCore_WeightCal";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_WeightCal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_WeightCal_FormClosing);
            this.Load += new System.EventHandler(this.frmWeightSetup_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_WeightCurrentValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ListBox lbox_Result;
        private System.Windows.Forms.Timer tmr_WeightDisplay;
        private System.Windows.Forms.Label lbl_CalTarget;
        private System.Windows.Forms.Label lbl_TargetName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Head1;
        private System.Windows.Forms.Button btn_Head2;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_DotsPerSample;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_TargetUnit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_OutputResult;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lbl_CurrentCalUnit;
        private System.Windows.Forms.Label lbl_CurrentCalName;
        private System.Windows.Forms.Label lbl_CurrentCal2;
        private System.Windows.Forms.Label lbl_CurrentCal1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_CalTargetRange;
        private System.Windows.Forms.Button btn_Tare;
        private System.Windows.Forms.Button btn_Ctrl1;
        private System.Windows.Forms.Button btn_Ctrl2;
        private System.Windows.Forms.Label lbl_Result2;
        private System.Windows.Forms.Label lbl_Result1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmr_Start;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}