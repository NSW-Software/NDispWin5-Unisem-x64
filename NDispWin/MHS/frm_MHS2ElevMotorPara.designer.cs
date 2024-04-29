namespace NDispWin
{
    partial class frm_MHS2ElevMotorPara
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Init = new System.Windows.Forms.Button();
            this.btn_LPAxis = new System.Windows.Forms.Button();
            this.btn_RZAxis = new System.Windows.Forms.Button();
            this.btn_CWAxis = new System.Windows.Forms.Button();
            this.btn_LZAxis = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_HomeDir = new System.Windows.Forms.Label();
            this.lbl_SLmtNC = new System.Windows.Forms.Label();
            this.lbl_SLmtN = new System.Windows.Forms.Label();
            this.lbl_SLmtPC = new System.Windows.Forms.Label();
            this.lbl_SLmtP = new System.Windows.Forms.Label();
            this.lbl_Resulotion = new System.Windows.Forms.Label();
            this.lbl_DistPerPulse = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl_MtrAlmLogic = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lbl_InvertMtrOn = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lbl_InvertDir = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lbl_HomeTimeOut = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lbl_HomeFastV = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lbl_HomeSlowV = new System.Windows.Forms.Label();
            this.Jog = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.lbl_JogFastV = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lbl_JogMedV = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lbl_JogSlowV = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.lbl_FastV = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lbl_SlowV = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lbl_StartV = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lbl_Accel = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_BoardID = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Jog.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Axis";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btn_Init);
            this.groupBox1.Controls.Add(this.btn_LPAxis);
            this.groupBox1.Controls.Add(this.btn_RZAxis);
            this.groupBox1.Controls.Add(this.btn_CWAxis);
            this.groupBox1.Controls.Add(this.btn_LZAxis);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Axis";
            // 
            // btn_Init
            // 
            this.btn_Init.AccessibleDescription = "Init";
            this.btn_Init.Location = new System.Drawing.Point(6, 325);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(100, 30);
            this.btn_Init.TabIndex = 151;
            this.btn_Init.Text = "Init";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // btn_LPAxis
            // 
            this.btn_LPAxis.AccessibleDescription = "";
            this.btn_LPAxis.Location = new System.Drawing.Point(6, 129);
            this.btn_LPAxis.Name = "btn_LPAxis";
            this.btn_LPAxis.Size = new System.Drawing.Size(100, 30);
            this.btn_LPAxis.TabIndex = 353;
            this.btn_LPAxis.Text = "LP Axis";
            this.btn_LPAxis.UseVisualStyleBackColor = true;
            this.btn_LPAxis.Click += new System.EventHandler(this.btn_LPAxis_Click);
            // 
            // btn_RZAxis
            // 
            this.btn_RZAxis.AccessibleDescription = "";
            this.btn_RZAxis.Location = new System.Drawing.Point(6, 93);
            this.btn_RZAxis.Name = "btn_RZAxis";
            this.btn_RZAxis.Size = new System.Drawing.Size(100, 30);
            this.btn_RZAxis.TabIndex = 352;
            this.btn_RZAxis.Text = "RZ Axis";
            this.btn_RZAxis.UseVisualStyleBackColor = true;
            this.btn_RZAxis.Click += new System.EventHandler(this.btn_RZAxis_Click);
            // 
            // btn_CWAxis
            // 
            this.btn_CWAxis.AccessibleDescription = "";
            this.btn_CWAxis.Location = new System.Drawing.Point(6, 57);
            this.btn_CWAxis.Name = "btn_CWAxis";
            this.btn_CWAxis.Size = new System.Drawing.Size(100, 30);
            this.btn_CWAxis.TabIndex = 351;
            this.btn_CWAxis.Text = "CW Axis";
            this.btn_CWAxis.UseVisualStyleBackColor = true;
            this.btn_CWAxis.Click += new System.EventHandler(this.btn_CWAxis_Click);
            // 
            // btn_LZAxis
            // 
            this.btn_LZAxis.AccessibleDescription = "";
            this.btn_LZAxis.Location = new System.Drawing.Point(6, 21);
            this.btn_LZAxis.Name = "btn_LZAxis";
            this.btn_LZAxis.Size = new System.Drawing.Size(100, 30);
            this.btn_LZAxis.TabIndex = 350;
            this.btn_LZAxis.Text = "LZ Axis";
            this.btn_LZAxis.UseVisualStyleBackColor = true;
            this.btn_LZAxis.Click += new System.EventHandler(this.btn_LZAxis_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Setup";
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lbl_HomeDir);
            this.groupBox2.Controls.Add(this.lbl_SLmtNC);
            this.groupBox2.Controls.Add(this.lbl_SLmtN);
            this.groupBox2.Controls.Add(this.lbl_SLmtPC);
            this.groupBox2.Controls.Add(this.lbl_SLmtP);
            this.groupBox2.Controls.Add(this.lbl_Resulotion);
            this.groupBox2.Controls.Add(this.lbl_DistPerPulse);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.lbl_MtrAlmLogic);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.lbl_InvertMtrOn);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.lbl_InvertDir);
            this.groupBox2.Location = new System.Drawing.Point(126, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 399);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setup";
            // 
            // label22
            // 
            this.label22.AccessibleDescription = "Home Direction ";
            this.label22.AutoEllipsis = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(6, 138);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 23);
            this.label22.TabIndex = 150;
            this.label22.Text = "Home Direction ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HomeDir
            // 
            this.lbl_HomeDir.BackColor = System.Drawing.Color.White;
            this.lbl_HomeDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HomeDir.Location = new System.Drawing.Point(161, 138);
            this.lbl_HomeDir.Name = "lbl_HomeDir";
            this.lbl_HomeDir.Size = new System.Drawing.Size(150, 23);
            this.lbl_HomeDir.TabIndex = 149;
            this.lbl_HomeDir.Text = "-";
            this.lbl_HomeDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HomeDir.Click += new System.EventHandler(this.lbl_HomeDir_Click);
            // 
            // lbl_SLmtNC
            // 
            this.lbl_SLmtNC.AccessibleDescription = "Soft Limit N";
            this.lbl_SLmtNC.AutoEllipsis = true;
            this.lbl_SLmtNC.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_SLmtNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_SLmtNC.Location = new System.Drawing.Point(6, 198);
            this.lbl_SLmtNC.Name = "lbl_SLmtNC";
            this.lbl_SLmtNC.Size = new System.Drawing.Size(150, 23);
            this.lbl_SLmtNC.TabIndex = 148;
            this.lbl_SLmtNC.Text = "Soft Limit N";
            this.lbl_SLmtNC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SLmtN
            // 
            this.lbl_SLmtN.BackColor = System.Drawing.Color.White;
            this.lbl_SLmtN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SLmtN.Location = new System.Drawing.Point(161, 198);
            this.lbl_SLmtN.Name = "lbl_SLmtN";
            this.lbl_SLmtN.Size = new System.Drawing.Size(150, 23);
            this.lbl_SLmtN.TabIndex = 147;
            this.lbl_SLmtN.Text = "-";
            this.lbl_SLmtN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SLmtN.Click += new System.EventHandler(this.lbl_SLmtN_Click);
            // 
            // lbl_SLmtPC
            // 
            this.lbl_SLmtPC.AccessibleDescription = "Soft Limit P";
            this.lbl_SLmtPC.AutoEllipsis = true;
            this.lbl_SLmtPC.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_SLmtPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_SLmtPC.Location = new System.Drawing.Point(6, 168);
            this.lbl_SLmtPC.Name = "lbl_SLmtPC";
            this.lbl_SLmtPC.Size = new System.Drawing.Size(150, 23);
            this.lbl_SLmtPC.TabIndex = 146;
            this.lbl_SLmtPC.Text = "Soft Limit P";
            this.lbl_SLmtPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SLmtP
            // 
            this.lbl_SLmtP.BackColor = System.Drawing.Color.White;
            this.lbl_SLmtP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SLmtP.Location = new System.Drawing.Point(161, 168);
            this.lbl_SLmtP.Name = "lbl_SLmtP";
            this.lbl_SLmtP.Size = new System.Drawing.Size(150, 23);
            this.lbl_SLmtP.TabIndex = 145;
            this.lbl_SLmtP.Text = "-";
            this.lbl_SLmtP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SLmtP.Click += new System.EventHandler(this.lbl_SLmtP_Click);
            // 
            // lbl_Resulotion
            // 
            this.lbl_Resulotion.AccessibleDescription = "Dist Per Pulse (mm)";
            this.lbl_Resulotion.AutoEllipsis = true;
            this.lbl_Resulotion.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Resulotion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Resulotion.Location = new System.Drawing.Point(6, 18);
            this.lbl_Resulotion.Name = "lbl_Resulotion";
            this.lbl_Resulotion.Size = new System.Drawing.Size(150, 23);
            this.lbl_Resulotion.TabIndex = 144;
            this.lbl_Resulotion.Text = "Dist Per Pulse (mm)";
            this.lbl_Resulotion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DistPerPulse
            // 
            this.lbl_DistPerPulse.BackColor = System.Drawing.Color.White;
            this.lbl_DistPerPulse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DistPerPulse.Location = new System.Drawing.Point(161, 18);
            this.lbl_DistPerPulse.Name = "lbl_DistPerPulse";
            this.lbl_DistPerPulse.Size = new System.Drawing.Size(150, 23);
            this.lbl_DistPerPulse.TabIndex = 143;
            this.lbl_DistPerPulse.Text = "-";
            this.lbl_DistPerPulse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_DistPerPulse.Click += new System.EventHandler(this.lbl_DistPerPulse_Click);
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Motor Alarm Logic";
            this.label24.AutoEllipsis = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(6, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(150, 23);
            this.label24.TabIndex = 142;
            this.label24.Text = "Motor Alarm Logic";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MtrAlmLogic
            // 
            this.lbl_MtrAlmLogic.BackColor = System.Drawing.Color.White;
            this.lbl_MtrAlmLogic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MtrAlmLogic.Location = new System.Drawing.Point(161, 78);
            this.lbl_MtrAlmLogic.Name = "lbl_MtrAlmLogic";
            this.lbl_MtrAlmLogic.Size = new System.Drawing.Size(150, 23);
            this.lbl_MtrAlmLogic.TabIndex = 141;
            this.lbl_MtrAlmLogic.Text = "-";
            this.lbl_MtrAlmLogic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MtrAlmLogic.Click += new System.EventHandler(this.lbl_MtrAlmLogic_Click);
            // 
            // label27
            // 
            this.label27.AccessibleDescription = "Invert Motor On";
            this.label27.AutoEllipsis = true;
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label27.Location = new System.Drawing.Point(6, 108);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(150, 23);
            this.label27.TabIndex = 140;
            this.label27.Text = "Invert Motor On";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_InvertMtrOn
            // 
            this.lbl_InvertMtrOn.BackColor = System.Drawing.Color.White;
            this.lbl_InvertMtrOn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InvertMtrOn.Location = new System.Drawing.Point(161, 108);
            this.lbl_InvertMtrOn.Name = "lbl_InvertMtrOn";
            this.lbl_InvertMtrOn.Size = new System.Drawing.Size(150, 23);
            this.lbl_InvertMtrOn.TabIndex = 139;
            this.lbl_InvertMtrOn.Text = "-";
            this.lbl_InvertMtrOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_InvertMtrOn.Click += new System.EventHandler(this.lbl_InvertMtrOn_Click);
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "Invert Direction";
            this.label28.AutoEllipsis = true;
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(6, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(150, 23);
            this.label28.TabIndex = 138;
            this.label28.Text = "Invert Direction";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_InvertDir
            // 
            this.lbl_InvertDir.BackColor = System.Drawing.Color.White;
            this.lbl_InvertDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_InvertDir.Location = new System.Drawing.Point(161, 48);
            this.lbl_InvertDir.Name = "lbl_InvertDir";
            this.lbl_InvertDir.Size = new System.Drawing.Size(150, 23);
            this.lbl_InvertDir.TabIndex = 137;
            this.lbl_InvertDir.Text = "-";
            this.lbl_InvertDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_InvertDir.Click += new System.EventHandler(this.lbl_InvertDir_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "Home";
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.lbl_HomeTimeOut);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.lbl_HomeFastV);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.lbl_HomeSlowV);
            this.groupBox3.Location = new System.Drawing.Point(450, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 119);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Home";
            // 
            // label30
            // 
            this.label30.AccessibleDescription = "Time Out (ms)";
            this.label30.AutoEllipsis = true;
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Location = new System.Drawing.Point(6, 78);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(150, 23);
            this.label30.TabIndex = 127;
            this.label30.Text = "Time Out (ms)";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HomeTimeOut
            // 
            this.lbl_HomeTimeOut.BackColor = System.Drawing.Color.White;
            this.lbl_HomeTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HomeTimeOut.Location = new System.Drawing.Point(162, 78);
            this.lbl_HomeTimeOut.Name = "lbl_HomeTimeOut";
            this.lbl_HomeTimeOut.Size = new System.Drawing.Size(150, 23);
            this.lbl_HomeTimeOut.TabIndex = 126;
            this.lbl_HomeTimeOut.Text = "-";
            this.lbl_HomeTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HomeTimeOut.Click += new System.EventHandler(this.lbl_HomeTimeOut_Click);
            // 
            // label32
            // 
            this.label32.AccessibleDescription = "Fast Speed (mm/s)";
            this.label32.AutoEllipsis = true;
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Location = new System.Drawing.Point(6, 48);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(150, 23);
            this.label32.TabIndex = 125;
            this.label32.Text = "Fast Speed (mm/s)";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HomeFastV
            // 
            this.lbl_HomeFastV.BackColor = System.Drawing.Color.White;
            this.lbl_HomeFastV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HomeFastV.Location = new System.Drawing.Point(162, 48);
            this.lbl_HomeFastV.Name = "lbl_HomeFastV";
            this.lbl_HomeFastV.Size = new System.Drawing.Size(150, 23);
            this.lbl_HomeFastV.TabIndex = 124;
            this.lbl_HomeFastV.Text = "-";
            this.lbl_HomeFastV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HomeFastV.Click += new System.EventHandler(this.lbl_HomeFastV_Click);
            // 
            // label33
            // 
            this.label33.AccessibleDescription = "Slow Speed (mm/s)";
            this.label33.AutoEllipsis = true;
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Location = new System.Drawing.Point(6, 18);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(150, 23);
            this.label33.TabIndex = 123;
            this.label33.Text = "Slow Speed (mm/s)";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HomeSlowV
            // 
            this.lbl_HomeSlowV.BackColor = System.Drawing.Color.White;
            this.lbl_HomeSlowV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HomeSlowV.Location = new System.Drawing.Point(162, 18);
            this.lbl_HomeSlowV.Name = "lbl_HomeSlowV";
            this.lbl_HomeSlowV.Size = new System.Drawing.Size(150, 23);
            this.lbl_HomeSlowV.TabIndex = 122;
            this.lbl_HomeSlowV.Text = "-";
            this.lbl_HomeSlowV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HomeSlowV.Click += new System.EventHandler(this.lbl_HomeSlowV_Click);
            // 
            // Jog
            // 
            this.Jog.AutoSize = true;
            this.Jog.Controls.Add(this.label34);
            this.Jog.Controls.Add(this.lbl_JogFastV);
            this.Jog.Controls.Add(this.label35);
            this.Jog.Controls.Add(this.lbl_JogMedV);
            this.Jog.Controls.Add(this.label37);
            this.Jog.Controls.Add(this.lbl_JogSlowV);
            this.Jog.Location = new System.Drawing.Point(450, 169);
            this.Jog.Name = "Jog";
            this.Jog.Size = new System.Drawing.Size(318, 119);
            this.Jog.TabIndex = 3;
            this.Jog.TabStop = false;
            this.Jog.Text = "Jog";
            // 
            // label34
            // 
            this.label34.AccessibleDescription = "Fast Speed (mm/s)";
            this.label34.AutoEllipsis = true;
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Location = new System.Drawing.Point(6, 78);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(150, 23);
            this.label34.TabIndex = 117;
            this.label34.Text = "Fast Speed (mm/s)";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_JogFastV
            // 
            this.lbl_JogFastV.BackColor = System.Drawing.Color.White;
            this.lbl_JogFastV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_JogFastV.Location = new System.Drawing.Point(162, 78);
            this.lbl_JogFastV.Name = "lbl_JogFastV";
            this.lbl_JogFastV.Size = new System.Drawing.Size(150, 23);
            this.lbl_JogFastV.TabIndex = 116;
            this.lbl_JogFastV.Text = "-";
            this.lbl_JogFastV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_JogFastV.Click += new System.EventHandler(this.lbl_JogFastV_Click);
            // 
            // label35
            // 
            this.label35.AccessibleDescription = " Med Speed (mm/s)";
            this.label35.AutoEllipsis = true;
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label35.Location = new System.Drawing.Point(6, 48);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(150, 23);
            this.label35.TabIndex = 115;
            this.label35.Text = "Med Speed (mm/s)";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_JogMedV
            // 
            this.lbl_JogMedV.BackColor = System.Drawing.Color.White;
            this.lbl_JogMedV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_JogMedV.Location = new System.Drawing.Point(162, 48);
            this.lbl_JogMedV.Name = "lbl_JogMedV";
            this.lbl_JogMedV.Size = new System.Drawing.Size(150, 23);
            this.lbl_JogMedV.TabIndex = 114;
            this.lbl_JogMedV.Text = "-";
            this.lbl_JogMedV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_JogMedV.Click += new System.EventHandler(this.lbl_JogMedV_Click);
            // 
            // label37
            // 
            this.label37.AccessibleDescription = "Slow Speed (mm/s)";
            this.label37.AutoEllipsis = true;
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Location = new System.Drawing.Point(6, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(150, 23);
            this.label37.TabIndex = 113;
            this.label37.Text = "Slow Speed (mm/s)";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_JogSlowV
            // 
            this.lbl_JogSlowV.BackColor = System.Drawing.Color.White;
            this.lbl_JogSlowV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_JogSlowV.Location = new System.Drawing.Point(162, 18);
            this.lbl_JogSlowV.Name = "lbl_JogSlowV";
            this.lbl_JogSlowV.Size = new System.Drawing.Size(150, 23);
            this.lbl_JogSlowV.TabIndex = 112;
            this.lbl_JogSlowV.Text = "-";
            this.lbl_JogSlowV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_JogSlowV.Click += new System.EventHandler(this.lbl_JogSlowV_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.AccessibleDescription = "Operation";
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.lbl_FastV);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Controls.Add(this.lbl_SlowV);
            this.groupBox5.Controls.Add(this.label40);
            this.groupBox5.Controls.Add(this.lbl_StartV);
            this.groupBox5.Controls.Add(this.label41);
            this.groupBox5.Controls.Add(this.lbl_Accel);
            this.groupBox5.Location = new System.Drawing.Point(450, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 149);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Operation";
            // 
            // label38
            // 
            this.label38.AccessibleDescription = "Fast Speed (mm/s)";
            this.label38.AutoEllipsis = true;
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(6, 108);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(150, 23);
            this.label38.TabIndex = 115;
            this.label38.Text = "Fast Speed (mm/s)";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_FastV
            // 
            this.lbl_FastV.BackColor = System.Drawing.Color.White;
            this.lbl_FastV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FastV.Location = new System.Drawing.Point(162, 108);
            this.lbl_FastV.Name = "lbl_FastV";
            this.lbl_FastV.Size = new System.Drawing.Size(150, 23);
            this.lbl_FastV.TabIndex = 114;
            this.lbl_FastV.Text = "-";
            this.lbl_FastV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FastV.Click += new System.EventHandler(this.lbl_FastV_Click);
            // 
            // label39
            // 
            this.label39.AccessibleDescription = "Slow Speed (mm/s)";
            this.label39.AutoEllipsis = true;
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Location = new System.Drawing.Point(6, 78);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(150, 23);
            this.label39.TabIndex = 113;
            this.label39.Text = "Slow Speed (mm/s)";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SlowV
            // 
            this.lbl_SlowV.BackColor = System.Drawing.Color.White;
            this.lbl_SlowV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SlowV.Location = new System.Drawing.Point(162, 78);
            this.lbl_SlowV.Name = "lbl_SlowV";
            this.lbl_SlowV.Size = new System.Drawing.Size(150, 23);
            this.lbl_SlowV.TabIndex = 112;
            this.lbl_SlowV.Text = "-";
            this.lbl_SlowV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SlowV.Click += new System.EventHandler(this.lbl_SlowV_Click);
            // 
            // label40
            // 
            this.label40.AccessibleDescription = "Start Speed (mm/s)";
            this.label40.AutoEllipsis = true;
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Location = new System.Drawing.Point(6, 48);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(150, 23);
            this.label40.TabIndex = 111;
            this.label40.Text = "Start Speed (mm/s)";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_StartV
            // 
            this.lbl_StartV.BackColor = System.Drawing.Color.White;
            this.lbl_StartV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartV.Location = new System.Drawing.Point(162, 48);
            this.lbl_StartV.Name = "lbl_StartV";
            this.lbl_StartV.Size = new System.Drawing.Size(150, 23);
            this.lbl_StartV.TabIndex = 110;
            this.lbl_StartV.Text = "-";
            this.lbl_StartV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_StartV.Click += new System.EventHandler(this.lbl_StartV_Click);
            // 
            // label41
            // 
            this.label41.AccessibleDescription = "Accel (mm/s2)";
            this.label41.AutoEllipsis = true;
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Location = new System.Drawing.Point(6, 18);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(150, 23);
            this.label41.TabIndex = 109;
            this.label41.Text = "Accel (mm/s2)";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Accel
            // 
            this.lbl_Accel.BackColor = System.Drawing.Color.White;
            this.lbl_Accel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Accel.Location = new System.Drawing.Point(162, 18);
            this.lbl_Accel.Name = "lbl_Accel";
            this.lbl_Accel.Size = new System.Drawing.Size(150, 23);
            this.lbl_Accel.TabIndex = 108;
            this.lbl_Accel.Text = "-";
            this.lbl_Accel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Accel.Click += new System.EventHandler(this.lbl_Accel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Save.Location = new System.Drawing.Point(612, 8);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 30);
            this.btn_Save.TabIndex = 366;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Close.Location = new System.Drawing.Point(693, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 365;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_BoardID
            // 
            this.lbl_BoardID.AccessibleDescription = "";
            this.lbl_BoardID.BackColor = System.Drawing.Color.Red;
            this.lbl_BoardID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_BoardID.Location = new System.Drawing.Point(8, 8);
            this.lbl_BoardID.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_BoardID.Name = "lbl_BoardID";
            this.lbl_BoardID.Size = new System.Drawing.Size(120, 26);
            this.lbl_BoardID.TabIndex = 367;
            this.lbl_BoardID.Text = "Board ID0";
            this.lbl_BoardID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // frm_MHS2ElevMotorPara
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lbl_BoardID);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Jog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_MHS2ElevMotorPara";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_MHS2ElevMotorPara";
            this.Load += new System.EventHandler(this.frm_ElevMotorPara_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.Jog.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_HomeDir;
        private System.Windows.Forms.Label lbl_SLmtNC;
        private System.Windows.Forms.Label lbl_SLmtN;
        private System.Windows.Forms.Label lbl_SLmtPC;
        private System.Windows.Forms.Label lbl_SLmtP;
        private System.Windows.Forms.Label lbl_Resulotion;
        private System.Windows.Forms.Label lbl_DistPerPulse;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl_MtrAlmLogic;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbl_InvertMtrOn;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lbl_InvertDir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lbl_HomeTimeOut;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lbl_HomeFastV;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lbl_HomeSlowV;
        private System.Windows.Forms.GroupBox Jog;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lbl_JogFastV;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lbl_JogMedV;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lbl_JogSlowV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lbl_FastV;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lbl_SlowV;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lbl_StartV;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lbl_Accel;
        private System.Windows.Forms.Button btn_LPAxis;
        private System.Windows.Forms.Button btn_RZAxis;
        private System.Windows.Forms.Button btn_CWAxis;
        private System.Windows.Forms.Button btn_LZAxis;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_BoardID;
        private System.Windows.Forms.Timer tmr_Display;
    }
}