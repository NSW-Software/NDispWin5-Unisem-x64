namespace NDispWin
{
    partial class frm_DispCore_DispProg_SpiralFill
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
            this.btn_GotoStartXY = new System.Windows.Forms.Button();
            this.lbl_StartY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_StartX = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_Pitch = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbl_Diameter = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_SetXYC = new System.Windows.Forms.Button();
            this.lbl_CenterY = new System.Windows.Forms.Label();
            this.lbl_CenterX = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Dispense = new System.Windows.Forms.Label();
            this._lbl_Dispense = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbox_ = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Pattern = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Angle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpage_Pattern.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_GotoStartXY
            // 
            this.btn_GotoStartXY.AccessibleDescription = "Goto";
            this.btn_GotoStartXY.Location = new System.Drawing.Point(397, 5);
            this.btn_GotoStartXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoStartXY.Name = "btn_GotoStartXY";
            this.btn_GotoStartXY.Size = new System.Drawing.Size(75, 30);
            this.btn_GotoStartXY.TabIndex = 4;
            this.btn_GotoStartXY.Text = "Goto";
            this.btn_GotoStartXY.UseVisualStyleBackColor = true;
            this.btn_GotoStartXY.Click += new System.EventHandler(this.btn_GotoStartPos_Click);
            // 
            // lbl_StartY
            // 
            this.lbl_StartY.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_StartY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartY.Location = new System.Drawing.Point(238, 9);
            this.lbl_StartY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartY.Name = "lbl_StartY";
            this.lbl_StartY.Size = new System.Drawing.Size(75, 23);
            this.lbl_StartY.TabIndex = 122;
            this.lbl_StartY.Text = "9.999";
            this.lbl_StartY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Location = new System.Drawing.Point(115, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "(mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_StartX
            // 
            this.lbl_StartX.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_StartX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartX.Location = new System.Drawing.Point(160, 9);
            this.lbl_StartX.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartX.Name = "lbl_StartX";
            this.lbl_StartX.Size = new System.Drawing.Size(75, 23);
            this.lbl_StartX.TabIndex = 121;
            this.lbl_StartX.Text = "9.999";
            this.lbl_StartX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(397, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(318, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 11;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(164, 34);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 29;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Model No";
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Model No";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Head No";
            this.label7.Location = new System.Drawing.Point(6, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "Head No";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(85, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 118;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(85, 34);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 119;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // label20
            // 
            this.label20.AccessibleDescription = "Pitch";
            this.label20.Location = new System.Drawing.Point(5, 124);
            this.label20.Margin = new System.Windows.Forms.Padding(2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 23);
            this.label20.TabIndex = 132;
            this.label20.Text = "Pitch";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "";
            this.label21.Location = new System.Drawing.Point(119, 124);
            this.label21.Margin = new System.Windows.Forms.Padding(2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 23);
            this.label21.TabIndex = 131;
            this.label21.Text = "(mm)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Pitch
            // 
            this.lbl_Pitch.BackColor = System.Drawing.Color.White;
            this.lbl_Pitch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Pitch.Location = new System.Drawing.Point(160, 124);
            this.lbl_Pitch.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Pitch.Name = "lbl_Pitch";
            this.lbl_Pitch.Size = new System.Drawing.Size(75, 23);
            this.lbl_Pitch.TabIndex = 121;
            this.lbl_Pitch.Text = "9.999";
            this.lbl_Pitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Pitch.Click += new System.EventHandler(this.lbl_Pitch_Click);
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Diameter";
            this.label24.Location = new System.Drawing.Point(5, 70);
            this.label24.Margin = new System.Windows.Forms.Padding(2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 23);
            this.label24.TabIndex = 132;
            this.label24.Text = "Diameter";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AccessibleDescription = "";
            this.label25.Location = new System.Drawing.Point(119, 70);
            this.label25.Margin = new System.Windows.Forms.Padding(2);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 23);
            this.label25.TabIndex = 131;
            this.label25.Text = "(mm)";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Diameter
            // 
            this.lbl_Diameter.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Diameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Diameter.Location = new System.Drawing.Point(160, 70);
            this.lbl_Diameter.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Diameter.Name = "lbl_Diameter";
            this.lbl_Diameter.Size = new System.Drawing.Size(75, 23);
            this.lbl_Diameter.TabIndex = 121;
            this.lbl_Diameter.Text = "9.999";
            this.lbl_Diameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Diameter.Click += new System.EventHandler(this.lbl_Diameter_Click);
            // 
            // button4
            // 
            this.button4.AccessibleDescription = "Goto";
            this.button4.Location = new System.Drawing.Point(397, 39);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 131;
            this.button4.Text = "Goto";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_GotoCenterPos_Click);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "";
            this.label12.Location = new System.Drawing.Point(116, 43);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 23);
            this.label12.TabIndex = 130;
            this.label12.Text = "(mm)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SetXYC
            // 
            this.btn_SetXYC.AccessibleDescription = "Set";
            this.btn_SetXYC.Location = new System.Drawing.Point(318, 39);
            this.btn_SetXYC.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetXYC.Name = "btn_SetXYC";
            this.btn_SetXYC.Size = new System.Drawing.Size(75, 30);
            this.btn_SetXYC.TabIndex = 126;
            this.btn_SetXYC.Text = "Set";
            this.btn_SetXYC.UseVisualStyleBackColor = true;
            this.btn_SetXYC.Click += new System.EventHandler(this.btn_SetCenterPos_Click);
            // 
            // lbl_CenterY
            // 
            this.lbl_CenterY.BackColor = System.Drawing.Color.White;
            this.lbl_CenterY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CenterY.Location = new System.Drawing.Point(239, 43);
            this.lbl_CenterY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CenterY.Name = "lbl_CenterY";
            this.lbl_CenterY.Size = new System.Drawing.Size(75, 23);
            this.lbl_CenterY.TabIndex = 129;
            this.lbl_CenterY.Text = "9.999";
            this.lbl_CenterY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CenterY.Click += new System.EventHandler(this.lbl_CenterY_Click);
            // 
            // lbl_CenterX
            // 
            this.lbl_CenterX.BackColor = System.Drawing.Color.White;
            this.lbl_CenterX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CenterX.Location = new System.Drawing.Point(160, 43);
            this.lbl_CenterX.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CenterX.Name = "lbl_CenterX";
            this.lbl_CenterX.Size = new System.Drawing.Size(75, 23);
            this.lbl_CenterX.TabIndex = 128;
            this.lbl_CenterX.Text = "9.999";
            this.lbl_CenterX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CenterX.Click += new System.EventHandler(this.lbl_CenterX_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lbl_Dispense);
            this.panel1.Controls.Add(this._lbl_Dispense);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_EditModel);
            this.panel1.Controls.Add(this.lbl_ModelNo);
            this.panel1.Controls.Add(this.lbl_HeadNo);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(479, 64);
            this.panel1.TabIndex = 122;
            // 
            // lbl_Dispense
            // 
            this.lbl_Dispense.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Dispense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Dispense.Location = new System.Drawing.Point(397, 7);
            this.lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Dispense.Name = "lbl_Dispense";
            this.lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this.lbl_Dispense.TabIndex = 128;
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
            this._lbl_Dispense.TabIndex = 127;
            this._lbl_Dispense.Text = "Dispense";
            this._lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(8, 270);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(479, 50);
            this.panel2.TabIndex = 123;
            // 
            // pbox_
            // 
            this.pbox_.Location = new System.Drawing.Point(8, 326);
            this.pbox_.Name = "pbox_";
            this.pbox_.Size = new System.Drawing.Size(479, 339);
            this.pbox_.TabIndex = 136;
            this.pbox_.TabStop = false;
            this.pbox_.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Pattern);
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 23);
            this.tabControl1.Location = new System.Drawing.Point(8, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(485, 190);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 138;
            // 
            // tpage_Pattern
            // 
            this.tpage_Pattern.AccessibleDescription = "Pattern";
            this.tpage_Pattern.Controls.Add(this.label8);
            this.tpage_Pattern.Controls.Add(this.label5);
            this.tpage_Pattern.Controls.Add(this.label4);
            this.tpage_Pattern.Controls.Add(this.label9);
            this.tpage_Pattern.Controls.Add(this.lbl_Angle);
            this.tpage_Pattern.Controls.Add(this.label20);
            this.tpage_Pattern.Controls.Add(this.label21);
            this.tpage_Pattern.Controls.Add(this.label24);
            this.tpage_Pattern.Controls.Add(this.lbl_Pitch);
            this.tpage_Pattern.Controls.Add(this.label25);
            this.tpage_Pattern.Controls.Add(this.button4);
            this.tpage_Pattern.Controls.Add(this.lbl_Diameter);
            this.tpage_Pattern.Controls.Add(this.label12);
            this.tpage_Pattern.Controls.Add(this.btn_SetXYC);
            this.tpage_Pattern.Controls.Add(this.lbl_CenterY);
            this.tpage_Pattern.Controls.Add(this.label1);
            this.tpage_Pattern.Controls.Add(this.lbl_CenterX);
            this.tpage_Pattern.Controls.Add(this.lbl_StartX);
            this.tpage_Pattern.Controls.Add(this.lbl_StartY);
            this.tpage_Pattern.Controls.Add(this.btn_GotoStartXY);
            this.tpage_Pattern.Location = new System.Drawing.Point(4, 27);
            this.tpage_Pattern.Name = "tpage_Pattern";
            this.tpage_Pattern.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Pattern.Size = new System.Drawing.Size(477, 159);
            this.tpage_Pattern.TabIndex = 1;
            this.tpage_Pattern.Text = "Pattern";
            this.tpage_Pattern.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.Location = new System.Drawing.Point(109, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 147;
            this.label8.Text = "(deg)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Center XY";
            this.label5.Location = new System.Drawing.Point(5, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 23);
            this.label5.TabIndex = 146;
            this.label5.Text = "Center XY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Start XY";
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 145;
            this.label4.Text = "Start XY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Sweep Angle";
            this.label9.Location = new System.Drawing.Point(5, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 23);
            this.label9.TabIndex = 144;
            this.label9.Text = "Sweep Angle";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Angle
            // 
            this.lbl_Angle.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Angle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Angle.Location = new System.Drawing.Point(160, 97);
            this.lbl_Angle.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Angle.Name = "lbl_Angle";
            this.lbl_Angle.Size = new System.Drawing.Size(75, 23);
            this.lbl_Angle.TabIndex = 143;
            this.lbl_Angle.Text = "0";
            this.lbl_Angle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Angle.Click += new System.EventHandler(this.lbl_Angle_Click);
            // 
            // frm_DispCore_DispProg_SpiralFill
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(499, 678);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pbox_);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_SpiralFill";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_SpiralFill";
            this.Activated += new System.EventHandler(this.frmDispProg_Arc_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_Arc_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Arc_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_Arc_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpage_Pattern.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_GotoStartXY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_HeadNo;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.Label lbl_StartX;
        private System.Windows.Forms.Label lbl_StartY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Dispense;
        private System.Windows.Forms.Label _lbl_Dispense;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_CenterY;
        private System.Windows.Forms.Label lbl_CenterX;
        private System.Windows.Forms.Button btn_SetXYC;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl_Pitch;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbl_Diameter;
        private System.Windows.Forms.PictureBox pbox_;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Pattern;
        private System.Windows.Forms.Label lbl_Angle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
    }
}