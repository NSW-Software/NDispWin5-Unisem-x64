namespace DispCore
{
    partial class frm_DispCore_DispProg_Dot
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
            this.label3 = new System.Windows.Forms.Label();
            this.gbox_Pos = new System.Windows.Forms.GroupBox();
            this.btn_EditXY = new System.Windows.Forms.Button();
            this.lbl_Y1 = new System.Windows.Forms.Label();
            this.btn_GotoXY = new System.Windows.Forms.Button();
            this.lbl_X1 = new System.Windows.Forms.Label();
            this.btn_SetXY = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_PreMoveZ = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_gbox_Weight = new System.Windows.Forms.GroupBox();
            this.lbl_TrigTime = new System.Windows.Forms.Label();
            this.btn_Trig = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_WeightTol = new System.Windows.Forms.Label();
            this.lbl_Head = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Weight = new System.Windows.Forms.Label();
            this.btn_Measure = new System.Windows.Forms.Button();
            this.btn_CalWeight = new System.Windows.Forms.Button();
            this.lbl_Dispense = new System.Windows.Forms.Label();
            this._lbl_Dispense = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbox_Pos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.l_gbox_Weight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Head No";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Head No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // gbox_Pos
            // 
            this.gbox_Pos.AccessibleDescription = "Position";
            this.gbox_Pos.AutoSize = true;
            this.gbox_Pos.Controls.Add(this.btn_EditXY);
            this.gbox_Pos.Controls.Add(this.lbl_Y1);
            this.gbox_Pos.Controls.Add(this.btn_GotoXY);
            this.gbox_Pos.Controls.Add(this.lbl_X1);
            this.gbox_Pos.Controls.Add(this.btn_SetXY);
            this.gbox_Pos.Controls.Add(this.label5);
            this.gbox_Pos.Location = new System.Drawing.Point(7, 104);
            this.gbox_Pos.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pos.Name = "gbox_Pos";
            this.gbox_Pos.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Pos.Size = new System.Drawing.Size(480, 69);
            this.gbox_Pos.TabIndex = 13;
            this.gbox_Pos.TabStop = false;
            this.gbox_Pos.Text = "Position";
            // 
            // btn_EditXY
            // 
            this.btn_EditXY.AccessibleDescription = "Edit";
            this.btn_EditXY.Location = new System.Drawing.Point(398, 22);
            this.btn_EditXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditXY.Name = "btn_EditXY";
            this.btn_EditXY.Size = new System.Drawing.Size(75, 30);
            this.btn_EditXY.TabIndex = 130;
            this.btn_EditXY.Text = "Edit";
            this.btn_EditXY.UseVisualStyleBackColor = true;
            this.btn_EditXY.Click += new System.EventHandler(this.btn_EditXY_Click);
            // 
            // lbl_Y1
            // 
            this.lbl_Y1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y1.Location = new System.Drawing.Point(240, 26);
            this.lbl_Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y1.Name = "lbl_Y1";
            this.lbl_Y1.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y1.TabIndex = 110;
            this.lbl_Y1.Text = "-999.999";
            this.lbl_Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y1.Click += new System.EventHandler(this.lbl_Y1_Click);
            // 
            // btn_GotoXY
            // 
            this.btn_GotoXY.AccessibleDescription = "Pos XY";
            this.btn_GotoXY.Location = new System.Drawing.Point(7, 22);
            this.btn_GotoXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoXY.Name = "btn_GotoXY";
            this.btn_GotoXY.Size = new System.Drawing.Size(106, 30);
            this.btn_GotoXY.TabIndex = 8;
            this.btn_GotoXY.Text = "Pos XY";
            this.btn_GotoXY.UseVisualStyleBackColor = true;
            this.btn_GotoXY.Click += new System.EventHandler(this.btn_GotoXY_Click);
            // 
            // lbl_X1
            // 
            this.lbl_X1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1.Location = new System.Drawing.Point(161, 26);
            this.lbl_X1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1.Name = "lbl_X1";
            this.lbl_X1.Size = new System.Drawing.Size(75, 23);
            this.lbl_X1.TabIndex = 109;
            this.lbl_X1.Text = "-999.999";
            this.lbl_X1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X1.Click += new System.EventHandler(this.lbl_X1_Click);
            // 
            // btn_SetXY
            // 
            this.btn_SetXY.AccessibleDescription = "Set";
            this.btn_SetXY.Location = new System.Drawing.Point(319, 22);
            this.btn_SetXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetXY.Name = "btn_SetXY";
            this.btn_SetXY.Size = new System.Drawing.Size(75, 30);
            this.btn_SetXY.TabIndex = 7;
            this.btn_SetXY.Text = "Set";
            this.btn_SetXY.UseVisualStyleBackColor = true;
            this.btn_SetXY.Click += new System.EventHandler(this.btn_SetXY_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(117, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "(mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(398, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 101;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(319, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 30);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Model No";
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Model No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(165, 34);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 3;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Mode";
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Mode.Location = new System.Drawing.Point(86, 61);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(75, 23);
            this.lbl_Mode.TabIndex = 112;
            this.lbl_Mode.Text = "lbl_Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Mode.Click += new System.EventHandler(this.lbl_Mode_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(86, 34);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 113;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(86, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 114;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Options";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lbl_PreMoveZ);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(7, 177);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(480, 62);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // lbl_PreMoveZ
            // 
            this.lbl_PreMoveZ.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_PreMoveZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PreMoveZ.Location = new System.Drawing.Point(161, 22);
            this.lbl_PreMoveZ.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_PreMoveZ.Name = "lbl_PreMoveZ";
            this.lbl_PreMoveZ.Size = new System.Drawing.Size(75, 23);
            this.lbl_PreMoveZ.TabIndex = 111;
            this.lbl_PreMoveZ.Text = "True";
            this.lbl_PreMoveZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PreMoveZ.Click += new System.EventHandler(this.lbl_PreMoveZ_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "PreMove Z";
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 110;
            this.label7.Text = "PreMove Z";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // l_gbox_Weight
            // 
            this.l_gbox_Weight.AutoSize = true;
            this.l_gbox_Weight.Controls.Add(this.lbl_TrigTime);
            this.l_gbox_Weight.Controls.Add(this.btn_Trig);
            this.l_gbox_Weight.Controls.Add(this.label4);
            this.l_gbox_Weight.Controls.Add(this.lbl_WeightTol);
            this.l_gbox_Weight.Controls.Add(this.lbl_Head);
            this.l_gbox_Weight.Controls.Add(this.label6);
            this.l_gbox_Weight.Controls.Add(this.lbl_Weight);
            this.l_gbox_Weight.Controls.Add(this.btn_Measure);
            this.l_gbox_Weight.Controls.Add(this.btn_CalWeight);
            this.l_gbox_Weight.Location = new System.Drawing.Point(7, 243);
            this.l_gbox_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.l_gbox_Weight.Name = "l_gbox_Weight";
            this.l_gbox_Weight.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.l_gbox_Weight.Size = new System.Drawing.Size(480, 126);
            this.l_gbox_Weight.TabIndex = 116;
            this.l_gbox_Weight.TabStop = false;
            this.l_gbox_Weight.Text = "Calibration";
            // 
            // lbl_TrigTime
            // 
            this.lbl_TrigTime.Location = new System.Drawing.Point(163, 83);
            this.lbl_TrigTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TrigTime.Name = "lbl_TrigTime";
            this.lbl_TrigTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_TrigTime.TabIndex = 127;
            this.lbl_TrigTime.Text = "-";
            this.lbl_TrigTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Trig
            // 
            this.btn_Trig.AccessibleDescription = "Trig";
            this.btn_Trig.Location = new System.Drawing.Point(319, 79);
            this.btn_Trig.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Trig.Name = "btn_Trig";
            this.btn_Trig.Size = new System.Drawing.Size(75, 30);
            this.btn_Trig.TabIndex = 128;
            this.btn_Trig.Text = "Trigger";
            this.btn_Trig.UseVisualStyleBackColor = true;
            this.btn_Trig.Click += new System.EventHandler(this.btn_Trig_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Trig Time (ms)";
            this.label4.Location = new System.Drawing.Point(7, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 126;
            this.label4.Text = "Trig Time (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_WeightTol
            // 
            this.lbl_WeightTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_WeightTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WeightTol.Location = new System.Drawing.Point(240, 49);
            this.lbl_WeightTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_WeightTol.Name = "lbl_WeightTol";
            this.lbl_WeightTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_WeightTol.TabIndex = 132;
            this.lbl_WeightTol.Text = "-999.999";
            this.lbl_WeightTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_WeightTol.Click += new System.EventHandler(this.lbl_WeightTol_Click);
            // 
            // lbl_Head
            // 
            this.lbl_Head.BackColor = System.Drawing.Color.White;
            this.lbl_Head.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Head.Location = new System.Drawing.Point(7, 22);
            this.lbl_Head.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Head.Name = "lbl_Head";
            this.lbl_Head.Size = new System.Drawing.Size(75, 23);
            this.lbl_Head.TabIndex = 130;
            this.lbl_Head.Text = "Head1";
            this.lbl_Head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Head.Click += new System.EventHandler(this.lbl_Head_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Weight/Tol (mg)";
            this.label6.Location = new System.Drawing.Point(7, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 126;
            this.label6.Text = "Weight/Tol (mg)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Weight
            // 
            this.lbl_Weight.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Weight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Weight.Location = new System.Drawing.Point(161, 49);
            this.lbl_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Weight.Name = "lbl_Weight";
            this.lbl_Weight.Size = new System.Drawing.Size(75, 23);
            this.lbl_Weight.TabIndex = 127;
            this.lbl_Weight.Text = "-999.999";
            this.lbl_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Weight.Click += new System.EventHandler(this.lbl_Weight_Click);
            // 
            // btn_Measure
            // 
            this.btn_Measure.AccessibleDescription = "Measure";
            this.btn_Measure.Location = new System.Drawing.Point(319, 45);
            this.btn_Measure.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Measure.Name = "btn_Measure";
            this.btn_Measure.Size = new System.Drawing.Size(75, 30);
            this.btn_Measure.TabIndex = 129;
            this.btn_Measure.Text = "Measure";
            this.btn_Measure.UseVisualStyleBackColor = true;
            this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // btn_CalWeight
            // 
            this.btn_CalWeight.AccessibleDescription = "Calibrate";
            this.btn_CalWeight.Location = new System.Drawing.Point(398, 45);
            this.btn_CalWeight.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalWeight.Name = "btn_CalWeight";
            this.btn_CalWeight.Size = new System.Drawing.Size(75, 30);
            this.btn_CalWeight.TabIndex = 128;
            this.btn_CalWeight.Text = "Cal Weight";
            this.btn_CalWeight.UseVisualStyleBackColor = true;
            this.btn_CalWeight.Click += new System.EventHandler(this.btn_CalWeight_Click);
            // 
            // lbl_Dispense
            // 
            this.lbl_Dispense.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Dispense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Dispense.Location = new System.Drawing.Point(397, 7);
            this.lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Dispense.Name = "lbl_Dispense";
            this.lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this.lbl_Dispense.TabIndex = 130;
            this.lbl_Dispense.Text = "TRUE";
            this.lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Dispense.Click += new System.EventHandler(this.lbl_Dispense_Click);
            // 
            // _lbl_Dispense
            // 
            this._lbl_Dispense.AccessibleDescription = "Dispense";
            this._lbl_Dispense.Location = new System.Drawing.Point(318, 7);
            this._lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_Dispense.Name = "_lbl_Dispense";
            this._lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this._lbl_Dispense.TabIndex = 129;
            this._lbl_Dispense.Text = "Dispense";
            this._lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_Dispense);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._lbl_Dispense);
            this.panel1.Controls.Add(this.btn_EditModel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_Mode);
            this.panel1.Controls.Add(this.lbl_ModelNo);
            this.panel1.Controls.Add(this.lbl_HeadNo);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(479, 91);
            this.panel1.TabIndex = 131;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(7, 374);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(480, 44);
            this.panel2.TabIndex = 132;
            // 
            // frm_DispCore_DispProg_Dot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(501, 438);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.l_gbox_Weight);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbox_Pos);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frm_DispCore_DispProg_Dot";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_Dot";
            this.Load += new System.EventHandler(this.frmDispProg_Dot_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_Dot_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_Dot_VisibleChanged);
            this.Click += new System.EventHandler(this.frmDispProg_Dot_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmDispProg_Dot_KeyPress);
            this.gbox_Pos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.l_gbox_Weight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbox_Pos;
        private System.Windows.Forms.Button btn_GotoXY;
        private System.Windows.Forms.Button btn_SetXY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_X1;
        private System.Windows.Forms.Label lbl_Y1;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.Label lbl_HeadNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_PreMoveZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox l_gbox_Weight;
        private System.Windows.Forms.Label lbl_WeightTol;
        private System.Windows.Forms.Label lbl_Head;
        private System.Windows.Forms.Button btn_Measure;
        private System.Windows.Forms.Button btn_CalWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_Weight;
        private System.Windows.Forms.Button btn_Trig;
        private System.Windows.Forms.Label lbl_TrigTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Dispense;
        private System.Windows.Forms.Label _lbl_Dispense;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_EditXY;
    }
}