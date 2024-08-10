namespace NDispWin
{
    partial class frm_DispCore_DispProg_MeasL_WH
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
            this.lbl_MeasNo = new System.Windows.Forms.Label();
            this.btn_GotoPt2Pos = new System.Windows.Forms.Button();
            this.lbl_X2Y2 = new System.Windows.Forms.Label();
            this.btn_SetPt2Pos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbox_Position = new System.Windows.Forms.GroupBox();
            this.btn_GotoPt1Pos = new System.Windows.Forms.Button();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.lbl_StartPos = new System.Windows.Forms.Label();
            this.lbl_X1Y1 = new System.Windows.Forms.Label();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_MSpeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_MInterval = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_SampleTimes = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_DataPts = new System.Windows.Forms.Label();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_LoadProfile = new System.Windows.Forms.Button();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.btn_SaveProfile = new System.Windows.Forms.Button();
            this.btn_Data = new System.Windows.Forms.Button();
            this.gbox_Data = new System.Windows.Forms.GroupBox();
            this.lbox_Data = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_RunAtPos = new System.Windows.Forms.Button();
            this.btn_Analyze2 = new System.Windows.Forms.Button();
            this.btn_Analyze1 = new System.Windows.Forms.Button();
            this.lbox_Result = new System.Windows.Forms.ListBox();
            this.gbox_Position.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbox_Data.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_MeasNo
            // 
            this.lbl_MeasNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MeasNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MeasNo.Location = new System.Drawing.Point(92, 5);
            this.lbl_MeasNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MeasNo.Name = "lbl_MeasNo";
            this.lbl_MeasNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_MeasNo.TabIndex = 123;
            this.lbl_MeasNo.Text = "lbl_ModelNo";
            this.lbl_MeasNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_MeasNo.Click += new System.EventHandler(this.lbl_MeasNo_Click);
            // 
            // btn_GotoPt2Pos
            // 
            this.btn_GotoPt2Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt2Pos.Location = new System.Drawing.Point(368, 55);
            this.btn_GotoPt2Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt2Pos.Name = "btn_GotoPt2Pos";
            this.btn_GotoPt2Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoPt2Pos.TabIndex = 4;
            this.btn_GotoPt2Pos.Text = "Goto";
            this.btn_GotoPt2Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt2Pos.Click += new System.EventHandler(this.btn_GotoPt2Pos_Click);
            // 
            // lbl_X2Y2
            // 
            this.lbl_X2Y2.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_X2Y2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X2Y2.Location = new System.Drawing.Point(131, 62);
            this.lbl_X2Y2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X2Y2.Name = "lbl_X2Y2";
            this.lbl_X2Y2.Size = new System.Drawing.Size(154, 23);
            this.lbl_X2Y2.TabIndex = 123;
            this.lbl_X2Y2.Text = "9.999";
            this.lbl_X2Y2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SetPt2Pos
            // 
            this.btn_SetPt2Pos.AccessibleDescription = "Set";
            this.btn_SetPt2Pos.Location = new System.Drawing.Point(289, 55);
            this.btn_SetPt2Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt2Pos.Name = "btn_SetPt2Pos";
            this.btn_SetPt2Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_SetPt2Pos.TabIndex = 3;
            this.btn_SetPt2Pos.Text = "Set";
            this.btn_SetPt2Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt2Pos.Click += new System.EventHandler(this.btn_SetPt2Pos_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "End XY (mm)";
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "End XY (mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 122;
            this.label6.Text = "Meas No";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbox_Position
            // 
            this.gbox_Position.AccessibleDescription = "Position";
            this.gbox_Position.AutoSize = true;
            this.gbox_Position.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Position.Controls.Add(this.btn_GotoPt2Pos);
            this.gbox_Position.Controls.Add(this.lbl_X2Y2);
            this.gbox_Position.Controls.Add(this.btn_GotoPt1Pos);
            this.gbox_Position.Controls.Add(this.btn_SetPt2Pos);
            this.gbox_Position.Controls.Add(this.btn_SetPt1Pos);
            this.gbox_Position.Controls.Add(this.label5);
            this.gbox_Position.Controls.Add(this.lbl_StartPos);
            this.gbox_Position.Controls.Add(this.lbl_X1Y1);
            this.gbox_Position.Location = new System.Drawing.Point(2, 2);
            this.gbox_Position.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Position.Name = "gbox_Position";
            this.gbox_Position.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Position.Size = new System.Drawing.Size(450, 108);
            this.gbox_Position.TabIndex = 120;
            this.gbox_Position.TabStop = false;
            this.gbox_Position.Text = "Start Position";
            // 
            // btn_GotoPt1Pos
            // 
            this.btn_GotoPt1Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt1Pos.Location = new System.Drawing.Point(368, 15);
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
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(289, 15);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(75, 36);
            this.btn_SetPt1Pos.TabIndex = 3;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // lbl_StartPos
            // 
            this.lbl_StartPos.AccessibleDescription = "Start XY (mm)";
            this.lbl_StartPos.Location = new System.Drawing.Point(7, 22);
            this.lbl_StartPos.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartPos.Name = "lbl_StartPos";
            this.lbl_StartPos.Size = new System.Drawing.Size(120, 23);
            this.lbl_StartPos.TabIndex = 2;
            this.lbl_StartPos.Text = "Start XY (mm)";
            this.lbl_StartPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_X1Y1
            // 
            this.lbl_X1Y1.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_X1Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1Y1.Location = new System.Drawing.Point(131, 21);
            this.lbl_X1Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1Y1.Name = "lbl_X1Y1";
            this.lbl_X1Y1.Size = new System.Drawing.Size(154, 23);
            this.lbl_X1Y1.TabIndex = 121;
            this.lbl_X1Y1.Text = "9.999";
            this.lbl_X1Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Test
            // 
            this.btn_Test.AccessibleDescription = "Test";
            this.btn_Test.Location = new System.Drawing.Point(7, 7);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 36);
            this.btn_Test.TabIndex = 124;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(372, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 126;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(291, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 125;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_MSpeed
            // 
            this.lbl_MSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MSpeed.Location = new System.Drawing.Point(131, 22);
            this.lbl_MSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MSpeed.Name = "lbl_MSpeed";
            this.lbl_MSpeed.Size = new System.Drawing.Size(75, 23);
            this.lbl_MSpeed.TabIndex = 128;
            this.lbl_MSpeed.Text = "9.999";
            this.lbl_MSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MSpeed.Click += new System.EventHandler(this.lbl_MSpeed_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Travel Speed (mm/s)";
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 127;
            this.label2.Text = "Travel Speed (mm/s)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MInterval
            // 
            this.lbl_MInterval.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MInterval.Location = new System.Drawing.Point(131, 49);
            this.lbl_MInterval.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MInterval.Name = "lbl_MInterval";
            this.lbl_MInterval.Size = new System.Drawing.Size(75, 23);
            this.lbl_MInterval.TabIndex = 130;
            this.lbl_MInterval.Text = "9.999";
            this.lbl_MInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MInterval.Visible = false;
            this.lbl_MInterval.Click += new System.EventHandler(this.lbl_MInterval_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Interval (mm)";
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 23);
            this.label3.TabIndex = 129;
            this.label3.Text = "Interval (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Measurement";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_SampleTimes);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_MSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_MInterval);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(2, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(213, 116);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement";
            // 
            // lbl_SampleTimes
            // 
            this.lbl_SampleTimes.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SampleTimes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SampleTimes.Location = new System.Drawing.Point(131, 76);
            this.lbl_SampleTimes.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SampleTimes.Name = "lbl_SampleTimes";
            this.lbl_SampleTimes.Size = new System.Drawing.Size(75, 23);
            this.lbl_SampleTimes.TabIndex = 132;
            this.lbl_SampleTimes.Text = "9.999";
            this.lbl_SampleTimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SampleTimes.Click += new System.EventHandler(this.lbl_Sample_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Sample (times)";
            this.label9.Location = new System.Drawing.Point(7, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 23);
            this.label9.TabIndex = 131;
            this.label9.Text = "Sample (times)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Result";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lbl_DataPts);
            this.groupBox2.Controls.Add(this.lbl_Width);
            this.groupBox2.Controls.Add(this.lbl_Height);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(2, 234);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox2.Size = new System.Drawing.Size(213, 116);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            this.groupBox2.Visible = false;
            // 
            // lbl_DataPts
            // 
            this.lbl_DataPts.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DataPts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DataPts.Location = new System.Drawing.Point(131, 76);
            this.lbl_DataPts.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DataPts.Name = "lbl_DataPts";
            this.lbl_DataPts.Size = new System.Drawing.Size(75, 23);
            this.lbl_DataPts.TabIndex = 27;
            this.lbl_DataPts.Text = "0";
            this.lbl_DataPts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Width
            // 
            this.lbl_Width.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Width.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Width.Location = new System.Drawing.Point(131, 22);
            this.lbl_Width.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(75, 23);
            this.lbl_Width.TabIndex = 26;
            this.lbl_Width.Text = "0";
            this.lbl_Width.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Height
            // 
            this.lbl_Height.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Height.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Height.Location = new System.Drawing.Point(131, 49);
            this.lbl_Height.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(75, 23);
            this.lbl_Height.TabIndex = 25;
            this.lbl_Height.Text = "0";
            this.lbl_Height.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Data Pts (count)";
            this.label8.Location = new System.Drawing.Point(7, 76);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Data Pts (count)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Height (mm)";
            this.label7.Location = new System.Drawing.Point(7, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Height (mm)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Width (mm)";
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Width (mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_LoadProfile
            // 
            this.btn_LoadProfile.AccessibleDescription = "Load";
            this.btn_LoadProfile.Location = new System.Drawing.Point(295, 354);
            this.btn_LoadProfile.Name = "btn_LoadProfile";
            this.btn_LoadProfile.Size = new System.Drawing.Size(75, 25);
            this.btn_LoadProfile.TabIndex = 28;
            this.btn_LoadProfile.Text = "Load";
            this.btn_LoadProfile.UseVisualStyleBackColor = true;
            this.btn_LoadProfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(220, 115);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0;
            this.zg1.ScrollMaxX = 0;
            this.zg1.ScrollMaxY = 0;
            this.zg1.ScrollMaxY2 = 0;
            this.zg1.ScrollMinX = 0;
            this.zg1.ScrollMinY = 0;
            this.zg1.ScrollMinY2 = 0;
            this.zg1.Size = new System.Drawing.Size(231, 235);
            this.zg1.TabIndex = 133;
            this.zg1.Load += new System.EventHandler(this.zg1_Load);
            this.zg1.DoubleClick += new System.EventHandler(this.zg1_DoubleClick);
            this.zg1.Click += new System.EventHandler(this.zg1_Click);
            // 
            // btn_SaveProfile
            // 
            this.btn_SaveProfile.AccessibleDescription = "Save";
            this.btn_SaveProfile.Location = new System.Drawing.Point(376, 354);
            this.btn_SaveProfile.Name = "btn_SaveProfile";
            this.btn_SaveProfile.Size = new System.Drawing.Size(75, 25);
            this.btn_SaveProfile.TabIndex = 134;
            this.btn_SaveProfile.Text = "Save";
            this.btn_SaveProfile.UseVisualStyleBackColor = true;
            this.btn_SaveProfile.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Data
            // 
            this.btn_Data.AccessibleDescription = "Data";
            this.btn_Data.Location = new System.Drawing.Point(372, 7);
            this.btn_Data.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Data.Name = "btn_Data";
            this.btn_Data.Size = new System.Drawing.Size(75, 36);
            this.btn_Data.TabIndex = 135;
            this.btn_Data.Text = "Data";
            this.btn_Data.UseVisualStyleBackColor = true;
            this.btn_Data.Click += new System.EventHandler(this.button3_Click);
            // 
            // gbox_Data
            // 
            this.gbox_Data.AccessibleDescription = "Data";
            this.gbox_Data.Controls.Add(this.lbox_Data);
            this.gbox_Data.Location = new System.Drawing.Point(461, 4);
            this.gbox_Data.Name = "gbox_Data";
            this.gbox_Data.Size = new System.Drawing.Size(237, 609);
            this.gbox_Data.TabIndex = 136;
            this.gbox_Data.TabStop = false;
            this.gbox_Data.Text = "Data";
            // 
            // lbox_Data
            // 
            this.lbox_Data.FormattingEnabled = true;
            this.lbox_Data.ItemHeight = 14;
            this.lbox_Data.Location = new System.Drawing.Point(6, 21);
            this.lbox_Data.Name = "lbox_Data";
            this.lbox_Data.Size = new System.Drawing.Size(225, 578);
            this.lbox_Data.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_Data);
            this.panel1.Controls.Add(this.lbl_MeasNo);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(454, 50);
            this.panel1.TabIndex = 137;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.zg1);
            this.panel2.Controls.Add(this.gbox_Position);
            this.panel2.Controls.Add(this.btn_SaveProfile);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btn_LoadProfile);
            this.panel2.Location = new System.Drawing.Point(4, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 391);
            this.panel2.TabIndex = 138;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.btn_RunAtPos);
            this.panel3.Controls.Add(this.btn_Test);
            this.panel3.Controls.Add(this.btn_Cancel);
            this.panel3.Controls.Add(this.btn_OK);
            this.panel3.Location = new System.Drawing.Point(4, 547);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(454, 50);
            this.panel3.TabIndex = 139;
            // 
            // btn_RunAtPos
            // 
            this.btn_RunAtPos.AccessibleDescription = "Test At Pos";
            this.btn_RunAtPos.Location = new System.Drawing.Point(86, 7);
            this.btn_RunAtPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RunAtPos.Name = "btn_RunAtPos";
            this.btn_RunAtPos.Size = new System.Drawing.Size(75, 36);
            this.btn_RunAtPos.TabIndex = 127;
            this.btn_RunAtPos.Text = "Test At Pos";
            this.btn_RunAtPos.UseVisualStyleBackColor = true;
            this.btn_RunAtPos.Click += new System.EventHandler(this.btn_RunAtPos_Click);
            // 
            // btn_Analyze2
            // 
            this.btn_Analyze2.Location = new System.Drawing.Point(383, 496);
            this.btn_Analyze2.Name = "btn_Analyze2";
            this.btn_Analyze2.Size = new System.Drawing.Size(75, 36);
            this.btn_Analyze2.TabIndex = 136;
            this.btn_Analyze2.Text = "Analyze 2";
            this.btn_Analyze2.UseVisualStyleBackColor = true;
            this.btn_Analyze2.Click += new System.EventHandler(this.btn_Analyze2_Click);
            // 
            // btn_Analyze1
            // 
            this.btn_Analyze1.Location = new System.Drawing.Point(383, 454);
            this.btn_Analyze1.Name = "btn_Analyze1";
            this.btn_Analyze1.Size = new System.Drawing.Size(75, 36);
            this.btn_Analyze1.TabIndex = 135;
            this.btn_Analyze1.Text = "Analyze 1";
            this.btn_Analyze1.UseVisualStyleBackColor = true;
            this.btn_Analyze1.Click += new System.EventHandler(this.btn_Analyze1_Click);
            // 
            // lbox_Result
            // 
            this.lbox_Result.FormattingEnabled = true;
            this.lbox_Result.ItemHeight = 14;
            this.lbox_Result.Location = new System.Drawing.Point(4, 454);
            this.lbox_Result.Name = "lbox_Result";
            this.lbox_Result.Size = new System.Drawing.Size(373, 88);
            this.lbox_Result.TabIndex = 140;
            this.lbox_Result.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // frm_DispCore_DispProg_MeasL_WH
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(763, 681);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Analyze2);
            this.Controls.Add(this.lbox_Result);
            this.Controls.Add(this.btn_Analyze1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbox_Data);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_MeasL_WH";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "frmDispProg_MeasL_WH";
            this.Load += new System.EventHandler(this.frmDispProg_ML_WH_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_MeasL_WH_FormClosed);
            this.gbox_Position.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbox_Data.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MeasNo;
        private System.Windows.Forms.Button btn_GotoPt2Pos;
        private System.Windows.Forms.Label lbl_X2Y2;
        private System.Windows.Forms.Button btn_SetPt2Pos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbox_Position;
        private System.Windows.Forms.Button btn_GotoPt1Pos;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Label lbl_StartPos;
        private System.Windows.Forms.Label lbl_X1Y1;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_MSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_MInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_DataPts;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LoadProfile;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Button btn_SaveProfile;
        private System.Windows.Forms.Label lbl_SampleTimes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Data;
        private System.Windows.Forms.GroupBox gbox_Data;
        private System.Windows.Forms.ListBox lbox_Data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_RunAtPos;
        private System.Windows.Forms.Button btn_Analyze2;
        private System.Windows.Forms.Button btn_Analyze1;
        private System.Windows.Forms.ListBox lbox_Result;
    }
}