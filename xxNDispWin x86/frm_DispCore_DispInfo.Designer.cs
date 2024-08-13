namespace NDispWin
{
    partial class frm_DispCore_DispInfo
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
            this.pbox_DoRef1 = new System.Windows.Forms.PictureBox();
            this.gbox_DoRefImage = new System.Windows.Forms.GroupBox();
            this.pbox_DoRef2 = new System.Windows.Forms.PictureBox();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbox_InteruptCapture = new System.Windows.Forms.GroupBox();
            this.lbl_LiveCapture = new System.Windows.Forms.Label();
            this.btn_CaptureImage = new System.Windows.Forms.Button();
            this.gbox_Material2 = new System.Windows.Forms.GroupBox();
            this.lbl_SensMat2Low = new System.Windows.Forms.Label();
            this.lbl_SensMat1Low = new System.Windows.Forms.Label();
            this.lbl_MaterialLifeCountDown = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbox_Para = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_DB_Disp = new System.Windows.Forms.Label();
            this.lbl_DA_Disp = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_DB_DispAdj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_DA_DispAdj = new System.Windows.Forms.Label();
            this.lbl_BackSuckUnit = new System.Windows.Forms.Label();
            this.lbl_OffsetUnit = new System.Windows.Forms.Label();
            this.lbl_DispUnit = new System.Windows.Forms.Label();
            this.lbl_DB_DispOfst = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_DA_DispOfst = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_DB_BackSuckVol = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_DA_BackSuckVol = new System.Windows.Forms.Label();
            this.lbl_DB_DispBase = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_DA_DispBase = new System.Windows.Forms.Label();
            this.lbl_HeadAUnitCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_FrameCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_HeadBUnitCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Runtime = new System.Windows.Forms.Label();
            this.tmr_10sec = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_DoRef1)).BeginInit();
            this.gbox_DoRefImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_DoRef2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbox_InteruptCapture.SuspendLayout();
            this.gbox_Material2.SuspendLayout();
            this.gbox_Para.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbox_DoRef1
            // 
            this.pbox_DoRef1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_DoRef1.Location = new System.Drawing.Point(6, 21);
            this.pbox_DoRef1.Name = "pbox_DoRef1";
            this.pbox_DoRef1.Size = new System.Drawing.Size(160, 160);
            this.pbox_DoRef1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_DoRef1.TabIndex = 0;
            this.pbox_DoRef1.TabStop = false;
            // 
            // gbox_DoRefImage
            // 
            this.gbox_DoRefImage.AccessibleDescription = "DoRef Image";
            this.gbox_DoRefImage.AutoSize = true;
            this.gbox_DoRefImage.Controls.Add(this.pbox_DoRef2);
            this.gbox_DoRefImage.Controls.Add(this.pbox_DoRef1);
            this.gbox_DoRefImage.Location = new System.Drawing.Point(4, 4);
            this.gbox_DoRefImage.Name = "gbox_DoRefImage";
            this.gbox_DoRefImage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_DoRefImage.Size = new System.Drawing.Size(338, 199);
            this.gbox_DoRefImage.TabIndex = 1;
            this.gbox_DoRefImage.TabStop = false;
            this.gbox_DoRefImage.Text = "DoRef Image";
            // 
            // pbox_DoRef2
            // 
            this.pbox_DoRef2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_DoRef2.Location = new System.Drawing.Point(172, 21);
            this.pbox_DoRef2.Name = "pbox_DoRef2";
            this.pbox_DoRef2.Size = new System.Drawing.Size(160, 160);
            this.pbox_DoRef2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_DoRef2.TabIndex = 1;
            this.pbox_DoRef2.TabStop = false;
            this.pbox_DoRef2.Click += new System.EventHandler(this.pbox_DoRef2_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 244);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // gbox_InteruptCapture
            // 
            this.gbox_InteruptCapture.AccessibleDescription = "Interupt Capture";
            this.gbox_InteruptCapture.AutoSize = true;
            this.gbox_InteruptCapture.Controls.Add(this.lbl_LiveCapture);
            this.gbox_InteruptCapture.Controls.Add(this.btn_CaptureImage);
            this.gbox_InteruptCapture.Controls.Add(this.pictureBox1);
            this.gbox_InteruptCapture.Location = new System.Drawing.Point(4, 209);
            this.gbox_InteruptCapture.Name = "gbox_InteruptCapture";
            this.gbox_InteruptCapture.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_InteruptCapture.Size = new System.Drawing.Size(338, 324);
            this.gbox_InteruptCapture.TabIndex = 3;
            this.gbox_InteruptCapture.TabStop = false;
            this.gbox_InteruptCapture.Text = "Interupt Capture";
            this.gbox_InteruptCapture.Visible = false;
            this.gbox_InteruptCapture.Enter += new System.EventHandler(this.gbox_LiveCapture_Enter);
            // 
            // lbl_LiveCapture
            // 
            this.lbl_LiveCapture.AutoSize = true;
            this.lbl_LiveCapture.Location = new System.Drawing.Point(87, 279);
            this.lbl_LiveCapture.Name = "lbl_LiveCapture";
            this.lbl_LiveCapture.Size = new System.Drawing.Size(89, 14);
            this.lbl_LiveCapture.TabIndex = 4;
            this.lbl_LiveCapture.Text = "lbl_LiveCapture";
            // 
            // btn_CaptureImage
            // 
            this.btn_CaptureImage.AccessibleDescription = "Capture";
            this.btn_CaptureImage.Location = new System.Drawing.Point(0, 279);
            this.btn_CaptureImage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_CaptureImage.Name = "btn_CaptureImage";
            this.btn_CaptureImage.Size = new System.Drawing.Size(75, 30);
            this.btn_CaptureImage.TabIndex = 3;
            this.btn_CaptureImage.Text = "Capture";
            this.btn_CaptureImage.UseVisualStyleBackColor = true;
            this.btn_CaptureImage.Click += new System.EventHandler(this.btn_SnapImage_Click);
            // 
            // gbox_Material2
            // 
            this.gbox_Material2.AccessibleDescription = "";
            this.gbox_Material2.AutoSize = true;
            this.gbox_Material2.Controls.Add(this.lbl_MaterialLifeCountDown);
            this.gbox_Material2.Controls.Add(this.label7);
            this.gbox_Material2.Location = new System.Drawing.Point(348, 4);
            this.gbox_Material2.Name = "gbox_Material2";
            this.gbox_Material2.Size = new System.Drawing.Size(292, 62);
            this.gbox_Material2.TabIndex = 5;
            this.gbox_Material2.TabStop = false;
            // 
            // lbl_SensMat2Low
            // 
            this.lbl_SensMat2Low.AccessibleDescription = "Sens Mat2 Low";
            this.lbl_SensMat2Low.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SensMat2Low.Location = new System.Drawing.Point(564, 72);
            this.lbl_SensMat2Low.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_SensMat2Low.Name = "lbl_SensMat2Low";
            this.lbl_SensMat2Low.Size = new System.Drawing.Size(70, 30);
            this.lbl_SensMat2Low.TabIndex = 4;
            this.lbl_SensMat2Low.Text = "Sens Mat2 Low";
            this.lbl_SensMat2Low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SensMat1Low
            // 
            this.lbl_SensMat1Low.AccessibleDescription = "Sens Mat1 Low";
            this.lbl_SensMat1Low.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SensMat1Low.Location = new System.Drawing.Point(488, 72);
            this.lbl_SensMat1Low.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.lbl_SensMat1Low.Name = "lbl_SensMat1Low";
            this.lbl_SensMat1Low.Size = new System.Drawing.Size(70, 30);
            this.lbl_SensMat1Low.TabIndex = 3;
            this.lbl_SensMat1Low.Text = "Sens Mat1 Low";
            this.lbl_SensMat1Low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MaterialLifeCountDown
            // 
            this.lbl_MaterialLifeCountDown.AccessibleDescription = "";
            this.lbl_MaterialLifeCountDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MaterialLifeCountDown.Location = new System.Drawing.Point(140, 18);
            this.lbl_MaterialLifeCountDown.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaterialLifeCountDown.Name = "lbl_MaterialLifeCountDown";
            this.lbl_MaterialLifeCountDown.Size = new System.Drawing.Size(146, 23);
            this.lbl_MaterialLifeCountDown.TabIndex = 2;
            this.lbl_MaterialLifeCountDown.Text = "0 H 0 M 0 S";
            this.lbl_MaterialLifeCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Material Life";
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Material Life";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbox_Para
            // 
            this.gbox_Para.AutoSize = true;
            this.gbox_Para.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Para.Controls.Add(this.label15);
            this.gbox_Para.Controls.Add(this.lbl_DB_Disp);
            this.gbox_Para.Controls.Add(this.lbl_DA_Disp);
            this.gbox_Para.Controls.Add(this.label9);
            this.gbox_Para.Controls.Add(this.lbl_DB_DispAdj);
            this.gbox_Para.Controls.Add(this.label14);
            this.gbox_Para.Controls.Add(this.lbl_DA_DispAdj);
            this.gbox_Para.Controls.Add(this.lbl_BackSuckUnit);
            this.gbox_Para.Controls.Add(this.lbl_OffsetUnit);
            this.gbox_Para.Controls.Add(this.lbl_DispUnit);
            this.gbox_Para.Controls.Add(this.lbl_DB_DispOfst);
            this.gbox_Para.Controls.Add(this.label8);
            this.gbox_Para.Controls.Add(this.lbl_DA_DispOfst);
            this.gbox_Para.Controls.Add(this.label13);
            this.gbox_Para.Controls.Add(this.label12);
            this.gbox_Para.Controls.Add(this.lbl_DB_BackSuckVol);
            this.gbox_Para.Controls.Add(this.label3);
            this.gbox_Para.Controls.Add(this.lbl_DA_BackSuckVol);
            this.gbox_Para.Controls.Add(this.lbl_DB_DispBase);
            this.gbox_Para.Controls.Add(this.label11);
            this.gbox_Para.Controls.Add(this.label2);
            this.gbox_Para.Controls.Add(this.lbl_DA_DispBase);
            this.gbox_Para.Location = new System.Drawing.Point(348, 108);
            this.gbox_Para.Name = "gbox_Para";
            this.gbox_Para.Size = new System.Drawing.Size(292, 207);
            this.gbox_Para.TabIndex = 6;
            this.gbox_Para.TabStop = false;
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(94, 163);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 23);
            this.label15.TabIndex = 79;
            this.label15.Text = "(ul)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DB_Disp
            // 
            this.lbl_DB_Disp.AccessibleDescription = "";
            this.lbl_DB_Disp.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DB_Disp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DB_Disp.Location = new System.Drawing.Point(216, 163);
            this.lbl_DB_Disp.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DB_Disp.Name = "lbl_DB_Disp";
            this.lbl_DB_Disp.Size = new System.Drawing.Size(70, 23);
            this.lbl_DB_Disp.TabIndex = 78;
            this.lbl_DB_Disp.Text = "000.001";
            this.lbl_DB_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DA_Disp
            // 
            this.lbl_DA_Disp.AccessibleDescription = "";
            this.lbl_DA_Disp.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DA_Disp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DA_Disp.Location = new System.Drawing.Point(140, 163);
            this.lbl_DA_Disp.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DA_Disp.Name = "lbl_DA_Disp";
            this.lbl_DA_Disp.Size = new System.Drawing.Size(70, 23);
            this.lbl_DA_Disp.TabIndex = 77;
            this.lbl_DA_Disp.Text = "000.001";
            this.lbl_DA_Disp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "";
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(94, 76);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 76;
            this.label9.Text = "(ul)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DB_DispAdj
            // 
            this.lbl_DB_DispAdj.AccessibleDescription = "";
            this.lbl_DB_DispAdj.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DB_DispAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DB_DispAdj.Location = new System.Drawing.Point(216, 76);
            this.lbl_DB_DispAdj.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DB_DispAdj.Name = "lbl_DB_DispAdj";
            this.lbl_DB_DispAdj.Size = new System.Drawing.Size(70, 23);
            this.lbl_DB_DispAdj.TabIndex = 75;
            this.lbl_DB_DispAdj.Text = "000.001";
            this.lbl_DB_DispAdj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Adjust";
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(6, 76);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 23);
            this.label14.TabIndex = 74;
            this.label14.Text = "Adjust";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DA_DispAdj
            // 
            this.lbl_DA_DispAdj.AccessibleDescription = "";
            this.lbl_DA_DispAdj.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DA_DispAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DA_DispAdj.Location = new System.Drawing.Point(140, 76);
            this.lbl_DA_DispAdj.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DA_DispAdj.Name = "lbl_DA_DispAdj";
            this.lbl_DA_DispAdj.Size = new System.Drawing.Size(70, 23);
            this.lbl_DA_DispAdj.TabIndex = 73;
            this.lbl_DA_DispAdj.Text = "000.001";
            this.lbl_DA_DispAdj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_BackSuckUnit
            // 
            this.lbl_BackSuckUnit.AccessibleDescription = "";
            this.lbl_BackSuckUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_BackSuckUnit.Location = new System.Drawing.Point(94, 134);
            this.lbl_BackSuckUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_BackSuckUnit.Name = "lbl_BackSuckUnit";
            this.lbl_BackSuckUnit.Size = new System.Drawing.Size(40, 23);
            this.lbl_BackSuckUnit.TabIndex = 72;
            this.lbl_BackSuckUnit.Text = "(ul)";
            this.lbl_BackSuckUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_OffsetUnit
            // 
            this.lbl_OffsetUnit.AccessibleDescription = "";
            this.lbl_OffsetUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_OffsetUnit.Location = new System.Drawing.Point(94, 105);
            this.lbl_OffsetUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_OffsetUnit.Name = "lbl_OffsetUnit";
            this.lbl_OffsetUnit.Size = new System.Drawing.Size(40, 23);
            this.lbl_OffsetUnit.TabIndex = 71;
            this.lbl_OffsetUnit.Text = "(ul)";
            this.lbl_OffsetUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DispUnit
            // 
            this.lbl_DispUnit.AccessibleDescription = "";
            this.lbl_DispUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DispUnit.Location = new System.Drawing.Point(94, 47);
            this.lbl_DispUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DispUnit.Name = "lbl_DispUnit";
            this.lbl_DispUnit.Size = new System.Drawing.Size(40, 23);
            this.lbl_DispUnit.TabIndex = 70;
            this.lbl_DispUnit.Text = "(ul)";
            this.lbl_DispUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DB_DispOfst
            // 
            this.lbl_DB_DispOfst.AccessibleDescription = "";
            this.lbl_DB_DispOfst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DB_DispOfst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DB_DispOfst.Location = new System.Drawing.Point(216, 105);
            this.lbl_DB_DispOfst.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DB_DispOfst.Name = "lbl_DB_DispOfst";
            this.lbl_DB_DispOfst.Size = new System.Drawing.Size(70, 23);
            this.lbl_DB_DispOfst.TabIndex = 69;
            this.lbl_DB_DispOfst.Text = "000.001";
            this.lbl_DB_DispOfst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Offset";
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 23);
            this.label8.TabIndex = 68;
            this.label8.Text = "Offset";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DA_DispOfst
            // 
            this.lbl_DA_DispOfst.AccessibleDescription = "";
            this.lbl_DA_DispOfst.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DA_DispOfst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DA_DispOfst.Location = new System.Drawing.Point(140, 105);
            this.lbl_DA_DispOfst.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DA_DispOfst.Name = "lbl_DA_DispOfst";
            this.lbl_DA_DispOfst.Size = new System.Drawing.Size(70, 23);
            this.lbl_DA_DispOfst.TabIndex = 67;
            this.lbl_DA_DispOfst.Text = "000.001";
            this.lbl_DA_DispOfst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "Head B";
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(216, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 20);
            this.label13.TabIndex = 66;
            this.label13.Text = "Head B";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Head A";
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(140, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 20);
            this.label12.TabIndex = 65;
            this.label12.Text = "Head A";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DB_BackSuckVol
            // 
            this.lbl_DB_BackSuckVol.AccessibleDescription = "";
            this.lbl_DB_BackSuckVol.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DB_BackSuckVol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DB_BackSuckVol.Location = new System.Drawing.Point(216, 134);
            this.lbl_DB_BackSuckVol.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DB_BackSuckVol.Name = "lbl_DB_BackSuckVol";
            this.lbl_DB_BackSuckVol.Size = new System.Drawing.Size(70, 23);
            this.lbl_DB_BackSuckVol.TabIndex = 64;
            this.lbl_DB_BackSuckVol.Text = "000.001";
            this.lbl_DB_BackSuckVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "BackSuck Volume (ul)";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "BackSuck";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DA_BackSuckVol
            // 
            this.lbl_DA_BackSuckVol.AccessibleDescription = "";
            this.lbl_DA_BackSuckVol.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DA_BackSuckVol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DA_BackSuckVol.Location = new System.Drawing.Point(140, 134);
            this.lbl_DA_BackSuckVol.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DA_BackSuckVol.Name = "lbl_DA_BackSuckVol";
            this.lbl_DA_BackSuckVol.Size = new System.Drawing.Size(70, 23);
            this.lbl_DA_BackSuckVol.TabIndex = 62;
            this.lbl_DA_BackSuckVol.Text = "000.001";
            this.lbl_DA_BackSuckVol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DB_DispBase
            // 
            this.lbl_DB_DispBase.AccessibleDescription = "";
            this.lbl_DB_DispBase.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DB_DispBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DB_DispBase.Location = new System.Drawing.Point(216, 47);
            this.lbl_DB_DispBase.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DB_DispBase.Name = "lbl_DB_DispBase";
            this.lbl_DB_DispBase.Size = new System.Drawing.Size(70, 23);
            this.lbl_DB_DispBase.TabIndex = 61;
            this.lbl_DB_DispBase.Text = "000.001";
            this.lbl_DB_DispBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Base";
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 23);
            this.label11.TabIndex = 60;
            this.label11.Text = "Base";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Disp Total";
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 60;
            this.label2.Text = "Disp Total";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DA_DispBase
            // 
            this.lbl_DA_DispBase.AccessibleDescription = "";
            this.lbl_DA_DispBase.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_DA_DispBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DA_DispBase.Location = new System.Drawing.Point(140, 47);
            this.lbl_DA_DispBase.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_DA_DispBase.Name = "lbl_DA_DispBase";
            this.lbl_DA_DispBase.Size = new System.Drawing.Size(70, 23);
            this.lbl_DA_DispBase.TabIndex = 59;
            this.lbl_DA_DispBase.Text = "000.001";
            this.lbl_DA_DispBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HeadAUnitCount
            // 
            this.lbl_HeadAUnitCount.AccessibleDescription = "";
            this.lbl_HeadAUnitCount.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadAUnitCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadAUnitCount.Location = new System.Drawing.Point(140, 21);
            this.lbl_HeadAUnitCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadAUnitCount.Name = "lbl_HeadAUnitCount";
            this.lbl_HeadAUnitCount.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadAUnitCount.TabIndex = 59;
            this.lbl_HeadAUnitCount.Text = "1000000";
            this.lbl_HeadAUnitCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Head Shots (count)";
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 30);
            this.label10.TabIndex = 60;
            this.label10.Text = "Head Shots (count)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lbl_FrameCount
            // 
            this.lbl_FrameCount.AccessibleDescription = "";
            this.lbl_FrameCount.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_FrameCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FrameCount.Location = new System.Drawing.Point(140, 57);
            this.lbl_FrameCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FrameCount.Name = "lbl_FrameCount";
            this.lbl_FrameCount.Size = new System.Drawing.Size(70, 30);
            this.lbl_FrameCount.TabIndex = 62;
            this.lbl_FrameCount.Text = "40";
            this.lbl_FrameCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Frame (count)";
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 30);
            this.label6.TabIndex = 63;
            this.label6.Text = "Frame (count)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Reset
            // 
            this.btn_Reset.AccessibleDescription = "Reset";
            this.btn_Reset.Location = new System.Drawing.Point(211, 132);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(75, 35);
            this.btn_Reset.TabIndex = 65;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lbl_HeadBUnitCount
            // 
            this.lbl_HeadBUnitCount.AccessibleDescription = "";
            this.lbl_HeadBUnitCount.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadBUnitCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBUnitCount.Location = new System.Drawing.Point(216, 21);
            this.lbl_HeadBUnitCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadBUnitCount.Name = "lbl_HeadBUnitCount";
            this.lbl_HeadBUnitCount.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadBUnitCount.TabIndex = 66;
            this.lbl_HeadBUnitCount.Text = "1000000";
            this.lbl_HeadBUnitCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_Runtime);
            this.groupBox1.Controls.Add(this.lbl_HeadBUnitCount);
            this.groupBox1.Controls.Add(this.btn_Reset);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbl_FrameCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbl_HeadAUnitCount);
            this.groupBox1.Location = new System.Drawing.Point(348, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 188);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Runtime (min)";
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 68;
            this.label1.Text = "Runtime (min)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Runtime
            // 
            this.lbl_Runtime.AccessibleDescription = "";
            this.lbl_Runtime.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Runtime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Runtime.Location = new System.Drawing.Point(140, 93);
            this.lbl_Runtime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Runtime.Name = "lbl_Runtime";
            this.lbl_Runtime.Size = new System.Drawing.Size(70, 30);
            this.lbl_Runtime.TabIndex = 67;
            this.lbl_Runtime.Text = "40";
            this.lbl_Runtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_10sec
            // 
            this.tmr_10sec.Enabled = true;
            this.tmr_10sec.Interval = 10000;
            this.tmr_10sec.Tick += new System.EventHandler(this.tmr_10sec_Tick);
            // 
            // frm_DispCore_DispInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(654, 550);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_SensMat2Low);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbox_Para);
            this.Controls.Add(this.lbl_SensMat1Low);
            this.Controls.Add(this.gbox_Material2);
            this.Controls.Add(this.gbox_InteruptCapture);
            this.Controls.Add(this.gbox_DoRefImage);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_DispCore_DispInfo";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "frmDispInfo";
            this.Load += new System.EventHandler(this.frm_DispCore_DispInfo_Load);
            this.Shown += new System.EventHandler(this.frm_DispCore_DispInfo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_DoRef1)).EndInit();
            this.gbox_DoRefImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_DoRef2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbox_InteruptCapture.ResumeLayout(false);
            this.gbox_InteruptCapture.PerformLayout();
            this.gbox_Material2.ResumeLayout(false);
            this.gbox_Para.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_DoRef1;
        private System.Windows.Forms.GroupBox gbox_DoRefImage;
        private System.Windows.Forms.PictureBox pbox_DoRef2;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbox_InteruptCapture;
        private System.Windows.Forms.Label lbl_LiveCapture;
        private System.Windows.Forms.Button btn_CaptureImage;
        private System.Windows.Forms.GroupBox gbox_Material2;
        private System.Windows.Forms.Label lbl_MaterialLifeCountDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbox_Para;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_DA_DispBase;
        private System.Windows.Forms.Label lbl_DB_DispBase;
        private System.Windows.Forms.Label lbl_DB_BackSuckVol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DA_BackSuckVol;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_DB_DispOfst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_DA_DispOfst;
        private System.Windows.Forms.Label lbl_HeadAUnitCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_FrameCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_HeadBUnitCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_BackSuckUnit;
        private System.Windows.Forms.Label lbl_OffsetUnit;
        private System.Windows.Forms.Label lbl_DispUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Runtime;
        private System.Windows.Forms.Timer tmr_10sec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_DB_DispAdj;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_DA_DispAdj;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_DB_Disp;
        private System.Windows.Forms.Label lbl_DA_Disp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_SensMat1Low;
        private System.Windows.Forms.Label lbl_SensMat2Low;
    }
}