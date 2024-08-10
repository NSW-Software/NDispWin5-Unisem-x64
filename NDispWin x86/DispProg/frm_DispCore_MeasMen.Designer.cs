namespace NDispWin
{
    partial class frm_DispCore_MeasMen
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
            this.lbl_MeasID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbox_Positions = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_X3Y3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_X2Y2 = new System.Windows.Forms.Label();
            this.lbl_X1Y1 = new System.Windows.Forms.Label();
            this.btn_SetPt2Pos = new System.Windows.Forms.Button();
            this.btn_GotoPt1Pos = new System.Windows.Forms.Button();
            this.btn_GotoPt2Pos = new System.Windows.Forms.Button();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.lbox_Data = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_StartDelay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_MeniscusTol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_MeniscusSpec = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_SettleTime = new System.Windows.Forms.Label();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblContError = new System.Windows.Forms.Label();
            this.gbox_Positions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_MeasID
            // 
            this.lbl_MeasID.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MeasID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MeasID.Location = new System.Drawing.Point(90, 11);
            this.lbl_MeasID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MeasID.Name = "lbl_MeasID";
            this.lbl_MeasID.Size = new System.Drawing.Size(75, 23);
            this.lbl_MeasID.TabIndex = 27;
            this.lbl_MeasID.Text = "lbl_MeasID";
            this.lbl_MeasID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MeasID.Click += new System.EventHandler(this.lbl_MeasID_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Meas ID";
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Meas ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbox_Positions
            // 
            this.gbox_Positions.AccessibleDescription = "Positions";
            this.gbox_Positions.AutoSize = true;
            this.gbox_Positions.Controls.Add(this.button1);
            this.gbox_Positions.Controls.Add(this.button2);
            this.gbox_Positions.Controls.Add(this.label13);
            this.gbox_Positions.Controls.Add(this.label14);
            this.gbox_Positions.Controls.Add(this.lbl_X3Y3);
            this.gbox_Positions.Controls.Add(this.label21);
            this.gbox_Positions.Controls.Add(this.label20);
            this.gbox_Positions.Controls.Add(this.label5);
            this.gbox_Positions.Controls.Add(this.lbl_X2Y2);
            this.gbox_Positions.Controls.Add(this.lbl_X1Y1);
            this.gbox_Positions.Controls.Add(this.btn_SetPt2Pos);
            this.gbox_Positions.Controls.Add(this.btn_GotoPt1Pos);
            this.gbox_Positions.Controls.Add(this.btn_GotoPt2Pos);
            this.gbox_Positions.Controls.Add(this.btn_SetPt1Pos);
            this.gbox_Positions.Controls.Add(this.label1);
            this.gbox_Positions.Location = new System.Drawing.Point(10, 145);
            this.gbox_Positions.Name = "gbox_Positions";
            this.gbox_Positions.Size = new System.Drawing.Size(440, 130);
            this.gbox_Positions.TabIndex = 25;
            this.gbox_Positions.TabStop = false;
            this.gbox_Positions.Text = "Positions";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "Set";
            this.button1.Location = new System.Drawing.Point(281, 74);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 155;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_SetPt3Pos_Click);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "Goto";
            this.button2.Location = new System.Drawing.Point(360, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 156;
            this.button2.Text = "Goto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_GotoPt3Pos_Click);
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "";
            this.label13.Location = new System.Drawing.Point(87, 74);
            this.label13.Margin = new System.Windows.Forms.Padding(2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 23);
            this.label13.TabIndex = 154;
            this.label13.Text = "(mm)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Point Meas XY";
            this.label14.Location = new System.Drawing.Point(5, 74);
            this.label14.Margin = new System.Windows.Forms.Padding(2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 152;
            this.label14.Text = "Point Meas XY";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_X3Y3
            // 
            this.lbl_X3Y3.BackColor = System.Drawing.Color.White;
            this.lbl_X3Y3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X3Y3.Location = new System.Drawing.Point(138, 74);
            this.lbl_X3Y3.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X3Y3.Name = "lbl_X3Y3";
            this.lbl_X3Y3.Size = new System.Drawing.Size(120, 23);
            this.lbl_X3Y3.TabIndex = 153;
            this.lbl_X3Y3.Text = "lbl_X3Y3";
            this.lbl_X3Y3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_X3Y3.Click += new System.EventHandler(this.lbl_X3Y3_Click);
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "";
            this.label21.Location = new System.Drawing.Point(83, 47);
            this.label21.Margin = new System.Windows.Forms.Padding(2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 23);
            this.label21.TabIndex = 151;
            this.label21.Text = "(mm)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AccessibleDescription = "";
            this.label20.Location = new System.Drawing.Point(83, 20);
            this.label20.Margin = new System.Windows.Forms.Padding(2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 23);
            this.label20.TabIndex = 150;
            this.label20.Text = "(mm)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Point 2 XY";
            this.label5.Location = new System.Drawing.Point(5, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Point 2 XY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_X2Y2
            // 
            this.lbl_X2Y2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X2Y2.Location = new System.Drawing.Point(138, 47);
            this.lbl_X2Y2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X2Y2.Name = "lbl_X2Y2";
            this.lbl_X2Y2.Size = new System.Drawing.Size(120, 23);
            this.lbl_X2Y2.TabIndex = 5;
            this.lbl_X2Y2.Text = "lbl_X2Y2";
            this.lbl_X2Y2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_X1Y1
            // 
            this.lbl_X1Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1Y1.Location = new System.Drawing.Point(138, 20);
            this.lbl_X1Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1Y1.Name = "lbl_X1Y1";
            this.lbl_X1Y1.Size = new System.Drawing.Size(120, 23);
            this.lbl_X1Y1.TabIndex = 5;
            this.lbl_X1Y1.Text = "-999.999, -999.999";
            this.lbl_X1Y1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SetPt2Pos
            // 
            this.btn_SetPt2Pos.AccessibleDescription = "Set";
            this.btn_SetPt2Pos.Location = new System.Drawing.Point(281, 47);
            this.btn_SetPt2Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt2Pos.Name = "btn_SetPt2Pos";
            this.btn_SetPt2Pos.Size = new System.Drawing.Size(75, 23);
            this.btn_SetPt2Pos.TabIndex = 3;
            this.btn_SetPt2Pos.Text = "Set";
            this.btn_SetPt2Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt2Pos.Click += new System.EventHandler(this.btn_SetPt2Pos_Click);
            // 
            // btn_GotoPt1Pos
            // 
            this.btn_GotoPt1Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt1Pos.Location = new System.Drawing.Point(360, 20);
            this.btn_GotoPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt1Pos.Name = "btn_GotoPt1Pos";
            this.btn_GotoPt1Pos.Size = new System.Drawing.Size(75, 23);
            this.btn_GotoPt1Pos.TabIndex = 4;
            this.btn_GotoPt1Pos.Text = "Goto";
            this.btn_GotoPt1Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt1Pos.Click += new System.EventHandler(this.btn_GotoPt1Pos_Click);
            // 
            // btn_GotoPt2Pos
            // 
            this.btn_GotoPt2Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt2Pos.Location = new System.Drawing.Point(360, 47);
            this.btn_GotoPt2Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt2Pos.Name = "btn_GotoPt2Pos";
            this.btn_GotoPt2Pos.Size = new System.Drawing.Size(75, 23);
            this.btn_GotoPt2Pos.TabIndex = 4;
            this.btn_GotoPt2Pos.Text = "Goto";
            this.btn_GotoPt2Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt2Pos.Click += new System.EventHandler(this.btn_GotoPt2Pos_Click);
            // 
            // btn_SetPt1Pos
            // 
            this.btn_SetPt1Pos.AccessibleDescription = "Set";
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(281, 20);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(75, 23);
            this.btn_SetPt1Pos.TabIndex = 3;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Point 1 XY";
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Point 1 XY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Model No";
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 115;
            this.label2.Text = "Model No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(169, 38);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 114;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(90, 38);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 116;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // lbox_Data
            // 
            this.lbox_Data.BackColor = System.Drawing.SystemColors.Control;
            this.lbox_Data.FormattingEnabled = true;
            this.lbox_Data.ItemHeight = 14;
            this.lbox_Data.Location = new System.Drawing.Point(10, 403);
            this.lbox_Data.Margin = new System.Windows.Forms.Padding(2);
            this.lbox_Data.Name = "lbox_Data";
            this.lbox_Data.Size = new System.Drawing.Size(440, 116);
            this.lbox_Data.TabIndex = 117;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Test);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Location = new System.Drawing.Point(9, 523);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(441, 51);
            this.panel1.TabIndex = 163;
            // 
            // btn_Test
            // 
            this.btn_Test.AccessibleDescription = "Test";
            this.btn_Test.Location = new System.Drawing.Point(4, 4);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 36);
            this.btn_Test.TabIndex = 39;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(362, 4);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(283, 4);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 19;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Setting";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblContError);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lbl_StartDelay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_MeniscusTol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbl_MeniscusSpec);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_SettleTime);
            this.groupBox1.Location = new System.Drawing.Point(10, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 117);
            this.groupBox1.TabIndex = 164;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.Location = new System.Drawing.Point(84, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 23);
            this.label11.TabIndex = 161;
            this.label11.Text = "(ms)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Start Wait";
            this.label12.Location = new System.Drawing.Point(5, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 23);
            this.label12.TabIndex = 159;
            this.label12.Text = "Start Wait";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_StartDelay
            // 
            this.lbl_StartDelay.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_StartDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartDelay.Location = new System.Drawing.Point(138, 20);
            this.lbl_StartDelay.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartDelay.Name = "lbl_StartDelay";
            this.lbl_StartDelay.Size = new System.Drawing.Size(75, 23);
            this.lbl_StartDelay.TabIndex = 160;
            this.lbl_StartDelay.Text = "0";
            this.lbl_StartDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_StartDelay.Click += new System.EventHandler(this.lbl_StartDelay_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "";
            this.label9.Location = new System.Drawing.Point(306, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 23);
            this.label9.TabIndex = 158;
            this.label9.Text = "(mm)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Tol";
            this.label10.Location = new System.Drawing.Point(227, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 23);
            this.label10.TabIndex = 156;
            this.label10.Text = "Tol";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MeniscusTol
            // 
            this.lbl_MeniscusTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MeniscusTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MeniscusTol.Location = new System.Drawing.Point(360, 47);
            this.lbl_MeniscusTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MeniscusTol.Name = "lbl_MeniscusTol";
            this.lbl_MeniscusTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_MeniscusTol.TabIndex = 157;
            this.lbl_MeniscusTol.Text = "0";
            this.lbl_MeniscusTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MeniscusTol.Click += new System.EventHandler(this.lbl_MeniscusTol_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(306, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 155;
            this.label4.Text = "(mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Target";
            this.label7.Location = new System.Drawing.Point(227, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 153;
            this.label7.Text = "Target";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MeniscusSpec
            // 
            this.lbl_MeniscusSpec.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_MeniscusSpec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MeniscusSpec.Location = new System.Drawing.Point(360, 20);
            this.lbl_MeniscusSpec.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MeniscusSpec.Name = "lbl_MeniscusSpec";
            this.lbl_MeniscusSpec.Size = new System.Drawing.Size(75, 23);
            this.lbl_MeniscusSpec.TabIndex = 154;
            this.lbl_MeniscusSpec.Text = "0";
            this.lbl_MeniscusSpec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MeniscusSpec.Click += new System.EventHandler(this.lbl_MeniscusSpec_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(84, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 23);
            this.label6.TabIndex = 152;
            this.label6.Text = "(ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Settle Time";
            this.label8.Location = new System.Drawing.Point(5, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 23);
            this.label8.TabIndex = 141;
            this.label8.Text = "Settle Time";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SettleTime
            // 
            this.lbl_SettleTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SettleTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SettleTime.Location = new System.Drawing.Point(138, 47);
            this.lbl_SettleTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SettleTime.Name = "lbl_SettleTime";
            this.lbl_SettleTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_SettleTime.TabIndex = 142;
            this.lbl_SettleTime.Text = "0";
            this.lbl_SettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SettleTime.Click += new System.EventHandler(this.lbl_SettleTime_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(6, 21);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(349, 32);
            this.lbox_Cond.TabIndex = 166;
            this.lbox_Cond.SelectedIndexChanged += new System.EventHandler(this.lbox_Cond_SelectedIndexChanged);
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(360, 17);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 165;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.lbox_Cond);
            this.groupBox2.Controls.Add(this.btn_Cond);
            this.groupBox2.Location = new System.Drawing.Point(10, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 74);
            this.groupBox2.TabIndex = 167;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condition";
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.Location = new System.Drawing.Point(84, 74);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 23);
            this.label15.TabIndex = 164;
            this.label15.Text = "(count)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "Cont Error";
            this.label16.Location = new System.Drawing.Point(5, 74);
            this.label16.Margin = new System.Windows.Forms.Padding(2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 23);
            this.label16.TabIndex = 162;
            this.label16.Text = "Cont Error";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContError
            // 
            this.lblContError.BackColor = System.Drawing.SystemColors.Window;
            this.lblContError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContError.Location = new System.Drawing.Point(138, 74);
            this.lblContError.Margin = new System.Windows.Forms.Padding(2);
            this.lblContError.Name = "lblContError";
            this.lblContError.Size = new System.Drawing.Size(75, 23);
            this.lblContError.TabIndex = 163;
            this.lblContError.Text = "0";
            this.lblContError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblContError.Click += new System.EventHandler(this.lblContError_Click);
            // 
            // frm_DispCore_MeasMen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbox_Data);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_EditModel);
            this.Controls.Add(this.lbl_ModelNo);
            this.Controls.Add(this.lbl_MeasID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbox_Positions);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frm_DispCore_MeasMen";
            this.Text = "frm_DispCore_MeasMen";
            this.Load += new System.EventHandler(this.frm_DispCore_MeasMen_Load);
            this.gbox_Positions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MeasID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbox_Positions;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_X2Y2;
        private System.Windows.Forms.Label lbl_X1Y1;
        private System.Windows.Forms.Button btn_SetPt2Pos;
        private System.Windows.Forms.Button btn_GotoPt1Pos;
        private System.Windows.Forms.Button btn_GotoPt2Pos;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.ListBox lbox_Data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_SettleTime;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_MeniscusSpec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_MeniscusTol;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_StartDelay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_X3Y3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblContError;
    }
}