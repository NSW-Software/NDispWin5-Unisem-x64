namespace NDispWin
{
    partial class frm_DispTool_VolumeAdjust
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
            this.lbl_HeadABase = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_HeadA_AdjVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_HeadA_AdjPcnt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_HeadACurrent = new System.Windows.Forms.Label();
            this.gbox_HeadA = new System.Windows.Forms.GroupBox();
            this.pnl_FPress = new System.Windows.Forms.Panel();
            this.lbl_FPressUnit = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.pnl_VolCompA = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lbl_l_HeadAVolCompUnit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_l_HeadABackSuckUnit = new System.Windows.Forms.Label();
            this.lbl_l_BackSuck = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FPressA = new System.Windows.Forms.Label();
            this.lbl_FPressB = new System.Windows.Forms.Label();
            this.lbl_HeadB_VolComp = new System.Windows.Forms.Label();
            this.lbl_HeadBBase = new System.Windows.Forms.Label();
            this.lbl_HeadBOffset = new System.Windows.Forms.Label();
            this.lbl_HeadB_AdjPcnt = new System.Windows.Forms.Label();
            this.lbl_HeadB_BackSuck = new System.Windows.Forms.Label();
            this.lbl_HeadB_AdjVal = new System.Windows.Forms.Label();
            this.btn_HeadB_M = new System.Windows.Forms.Button();
            this.lbl_HeadBCurrent = new System.Windows.Forms.Label();
            this.btn_HeadB_P = new System.Windows.Forms.Button();
            this.btn_CopyA = new System.Windows.Forms.Button();
            this.lbl_HeadA_VolComp = new System.Windows.Forms.Label();
            this.lbl_HeadAOffset = new System.Windows.Forms.Label();
            this.btn_HeadA_M = new System.Windows.Forms.Button();
            this.btn_HeadA_P = new System.Windows.Forms.Button();
            this.lbl_HeadA_BackSuck = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.gbox_Settings = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_HeadA_Ratio = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_HeadB_Ratio = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_AdjustReso = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_AdjustTol = new System.Windows.Forms.Label();
            this.lbl_RefType = new System.Windows.Forms.Label();
            this.lbl_Runtime = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_FrameCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.lbl_Online = new System.Windows.Forms.Label();
            this.gbox_VolumeOfst = new System.Windows.Forms.GroupBox();
            this.btn_Info = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tmr_Second = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_HeadABaseAdjust = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_HeadBBaseAdjust = new System.Windows.Forms.Label();
            this.gbox_HeadA.SuspendLayout();
            this.pnl_FPress.SuspendLayout();
            this.pnl_VolCompA.SuspendLayout();
            this.gbox_Settings.SuspendLayout();
            this.gbox_VolumeOfst.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_HeadABase
            // 
            this.lbl_HeadABase.BackColor = System.Drawing.Color.White;
            this.lbl_HeadABase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadABase.Location = new System.Drawing.Point(6, 21);
            this.lbl_HeadABase.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadABase.Name = "lbl_HeadABase";
            this.lbl_HeadABase.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadABase.TabIndex = 19;
            this.lbl_HeadABase.Text = "000.001";
            this.lbl_HeadABase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadABase.Click += new System.EventHandler(this.lbl_HeadABase_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Base";
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Base";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadA_AdjVal
            // 
            this.lbl_HeadA_AdjVal.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_AdjVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_AdjVal.Location = new System.Drawing.Point(6, 57);
            this.lbl_HeadA_AdjVal.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_AdjVal.Name = "lbl_HeadA_AdjVal";
            this.lbl_HeadA_AdjVal.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadA_AdjVal.TabIndex = 24;
            this.lbl_HeadA_AdjVal.Text = "0.001";
            this.lbl_HeadA_AdjVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_AdjVal.Click += new System.EventHandler(this.lbl_HeadAAdjVal_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Adjust";
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Adjust";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadA_AdjPcnt
            // 
            this.lbl_HeadA_AdjPcnt.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_AdjPcnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_AdjPcnt.Location = new System.Drawing.Point(6, 93);
            this.lbl_HeadA_AdjPcnt.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_AdjPcnt.Name = "lbl_HeadA_AdjPcnt";
            this.lbl_HeadA_AdjPcnt.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadA_AdjPcnt.TabIndex = 26;
            this.lbl_HeadA_AdjPcnt.Text = "1";
            this.lbl_HeadA_AdjPcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_AdjPcnt.Click += new System.EventHandler(this.lbl_HeadAAdjPcnt_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Current";
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(6, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Current";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadACurrent
            // 
            this.lbl_HeadACurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadACurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadACurrent.Location = new System.Drawing.Point(6, 201);
            this.lbl_HeadACurrent.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadACurrent.Name = "lbl_HeadACurrent";
            this.lbl_HeadACurrent.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadACurrent.TabIndex = 27;
            this.lbl_HeadACurrent.Text = "0.001";
            this.lbl_HeadACurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbox_HeadA
            // 
            this.gbox_HeadA.AccessibleDescription = "";
            this.gbox_HeadA.AutoSize = true;
            this.gbox_HeadA.Controls.Add(this.pnl_FPress);
            this.gbox_HeadA.Controls.Add(this.label30);
            this.gbox_HeadA.Controls.Add(this.label29);
            this.gbox_HeadA.Controls.Add(this.label28);
            this.gbox_HeadA.Controls.Add(this.label27);
            this.gbox_HeadA.Controls.Add(this.label23);
            this.gbox_HeadA.Controls.Add(this.pnl_VolCompA);
            this.gbox_HeadA.Controls.Add(this.label7);
            this.gbox_HeadA.Controls.Add(this.lbl_l_HeadABackSuckUnit);
            this.gbox_HeadA.Controls.Add(this.lbl_l_BackSuck);
            this.gbox_HeadA.Controls.Add(this.label2);
            this.gbox_HeadA.Controls.Add(this.label4);
            this.gbox_HeadA.Controls.Add(this.label8);
            this.gbox_HeadA.Controls.Add(this.label6);
            this.gbox_HeadA.Location = new System.Drawing.Point(7, 89);
            this.gbox_HeadA.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_HeadA.Name = "gbox_HeadA";
            this.gbox_HeadA.Size = new System.Drawing.Size(174, 322);
            this.gbox_HeadA.TabIndex = 29;
            this.gbox_HeadA.TabStop = false;
            this.gbox_HeadA.Enter += new System.EventHandler(this.gbox_HeadA_Enter);
            // 
            // pnl_FPress
            // 
            this.pnl_FPress.AutoSize = true;
            this.pnl_FPress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_FPress.Controls.Add(this.lbl_FPressUnit);
            this.pnl_FPress.Controls.Add(this.label18);
            this.pnl_FPress.Location = new System.Drawing.Point(6, 272);
            this.pnl_FPress.Name = "pnl_FPress";
            this.pnl_FPress.Size = new System.Drawing.Size(162, 26);
            this.pnl_FPress.TabIndex = 48;
            // 
            // lbl_FPressUnit
            // 
            this.lbl_FPressUnit.AccessibleDescription = "";
            this.lbl_FPressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_FPressUnit.Location = new System.Drawing.Point(109, 8);
            this.lbl_FPressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressUnit.Name = "lbl_FPressUnit";
            this.lbl_FPressUnit.Size = new System.Drawing.Size(50, 15);
            this.lbl_FPressUnit.TabIndex = 53;
            this.lbl_FPressUnit.Text = "(ul)";
            this.lbl_FPressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "F Pressure";
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(0, 8);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 15);
            this.label18.TabIndex = 52;
            this.label18.Text = "F Pressure";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.AccessibleDescription = "";
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.Location = new System.Drawing.Point(116, 174);
            this.label30.Margin = new System.Windows.Forms.Padding(3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 15);
            this.label30.TabIndex = 49;
            this.label30.Text = "(ul)";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AccessibleDescription = "";
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.Location = new System.Drawing.Point(116, 210);
            this.label29.Margin = new System.Windows.Forms.Padding(3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 15);
            this.label29.TabIndex = 48;
            this.label29.Text = "(ul)";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "";
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Location = new System.Drawing.Point(116, 138);
            this.label28.Margin = new System.Windows.Forms.Padding(3);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 15);
            this.label28.TabIndex = 47;
            this.label28.Text = "(ul)";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.AccessibleDescription = "Adjust";
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.Location = new System.Drawing.Point(6, 102);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 15);
            this.label27.TabIndex = 46;
            this.label27.Text = "Adjust";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AccessibleDescription = "";
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Location = new System.Drawing.Point(116, 66);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 15);
            this.label23.TabIndex = 45;
            this.label23.Text = "(ul)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_VolCompA
            // 
            this.pnl_VolCompA.AutoSize = true;
            this.pnl_VolCompA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_VolCompA.Controls.Add(this.label24);
            this.pnl_VolCompA.Controls.Add(this.lbl_l_HeadAVolCompUnit);
            this.pnl_VolCompA.Location = new System.Drawing.Point(6, 237);
            this.pnl_VolCompA.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_VolCompA.Name = "pnl_VolCompA";
            this.pnl_VolCompA.Size = new System.Drawing.Size(163, 26);
            this.pnl_VolCompA.TabIndex = 44;
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Vol Comp";
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Location = new System.Drawing.Point(-1, 8);
            this.label24.Margin = new System.Windows.Forms.Padding(2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 15);
            this.label24.TabIndex = 42;
            this.label24.Text = "Vol Comp";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_l_HeadAVolCompUnit
            // 
            this.lbl_l_HeadAVolCompUnit.AccessibleDescription = "";
            this.lbl_l_HeadAVolCompUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_l_HeadAVolCompUnit.Location = new System.Drawing.Point(110, 8);
            this.lbl_l_HeadAVolCompUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_l_HeadAVolCompUnit.Name = "lbl_l_HeadAVolCompUnit";
            this.lbl_l_HeadAVolCompUnit.Size = new System.Drawing.Size(50, 15);
            this.lbl_l_HeadAVolCompUnit.TabIndex = 43;
            this.lbl_l_HeadAVolCompUnit.Text = "(ul)";
            this.lbl_l_HeadAVolCompUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Offset";
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(6, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "Offset";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_l_HeadABackSuckUnit
            // 
            this.lbl_l_HeadABackSuckUnit.AccessibleDescription = "";
            this.lbl_l_HeadABackSuckUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_l_HeadABackSuckUnit.Location = new System.Drawing.Point(116, 30);
            this.lbl_l_HeadABackSuckUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_l_HeadABackSuckUnit.Name = "lbl_l_HeadABackSuckUnit";
            this.lbl_l_HeadABackSuckUnit.Size = new System.Drawing.Size(50, 15);
            this.lbl_l_HeadABackSuckUnit.TabIndex = 40;
            this.lbl_l_HeadABackSuckUnit.Text = "(ul)";
            this.lbl_l_HeadABackSuckUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_l_BackSuck
            // 
            this.lbl_l_BackSuck.AccessibleDescription = "BackSuck";
            this.lbl_l_BackSuck.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_l_BackSuck.Location = new System.Drawing.Point(6, 174);
            this.lbl_l_BackSuck.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_l_BackSuck.Name = "lbl_l_BackSuck";
            this.lbl_l_BackSuck.Size = new System.Drawing.Size(70, 15);
            this.lbl_l_BackSuck.TabIndex = 32;
            this.lbl_l_BackSuck.Text = "BackSuck";
            this.lbl_l_BackSuck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(116, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "(%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FPressA
            // 
            this.lbl_FPressA.BackColor = System.Drawing.Color.White;
            this.lbl_FPressA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressA.Location = new System.Drawing.Point(6, 271);
            this.lbl_FPressA.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressA.Name = "lbl_FPressA";
            this.lbl_FPressA.Size = new System.Drawing.Size(70, 30);
            this.lbl_FPressA.TabIndex = 51;
            this.lbl_FPressA.Text = "24.0";
            this.lbl_FPressA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressA.Click += new System.EventHandler(this.lbl_FPressA_Click);
            // 
            // lbl_FPressB
            // 
            this.lbl_FPressB.BackColor = System.Drawing.Color.White;
            this.lbl_FPressB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPressB.Location = new System.Drawing.Point(6, 271);
            this.lbl_FPressB.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressB.Name = "lbl_FPressB";
            this.lbl_FPressB.Size = new System.Drawing.Size(70, 30);
            this.lbl_FPressB.TabIndex = 50;
            this.lbl_FPressB.Text = "24.0";
            this.lbl_FPressB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPressB.Click += new System.EventHandler(this.lbl_FPressB_Click);
            // 
            // lbl_HeadB_VolComp
            // 
            this.lbl_HeadB_VolComp.BackColor = System.Drawing.Color.White;
            this.lbl_HeadB_VolComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadB_VolComp.Location = new System.Drawing.Point(6, 236);
            this.lbl_HeadB_VolComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadB_VolComp.Name = "lbl_HeadB_VolComp";
            this.lbl_HeadB_VolComp.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadB_VolComp.TabIndex = 41;
            this.lbl_HeadB_VolComp.Text = "0.000001";
            this.lbl_HeadB_VolComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadB_VolComp.Click += new System.EventHandler(this.lbl_HeadB_VolComp_Click);
            // 
            // lbl_HeadBBase
            // 
            this.lbl_HeadBBase.BackColor = System.Drawing.Color.White;
            this.lbl_HeadBBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBBase.Location = new System.Drawing.Point(6, 21);
            this.lbl_HeadBBase.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadBBase.Name = "lbl_HeadBBase";
            this.lbl_HeadBBase.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadBBase.TabIndex = 19;
            this.lbl_HeadBBase.Text = "0.001";
            this.lbl_HeadBBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadBBase.Click += new System.EventHandler(this.lbl_HeadBBase_Click);
            // 
            // lbl_HeadBOffset
            // 
            this.lbl_HeadBOffset.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadBOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBOffset.Location = new System.Drawing.Point(6, 129);
            this.lbl_HeadBOffset.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadBOffset.Name = "lbl_HeadBOffset";
            this.lbl_HeadBOffset.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadBOffset.TabIndex = 38;
            this.lbl_HeadBOffset.Text = "0.001";
            this.lbl_HeadBOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_HeadB_AdjPcnt
            // 
            this.lbl_HeadB_AdjPcnt.BackColor = System.Drawing.Color.White;
            this.lbl_HeadB_AdjPcnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadB_AdjPcnt.Location = new System.Drawing.Point(6, 93);
            this.lbl_HeadB_AdjPcnt.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadB_AdjPcnt.Name = "lbl_HeadB_AdjPcnt";
            this.lbl_HeadB_AdjPcnt.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadB_AdjPcnt.TabIndex = 26;
            this.lbl_HeadB_AdjPcnt.Text = "1";
            this.lbl_HeadB_AdjPcnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadB_AdjPcnt.Click += new System.EventHandler(this.lbl_HeadBAdjPcnt_Click);
            // 
            // lbl_HeadB_BackSuck
            // 
            this.lbl_HeadB_BackSuck.BackColor = System.Drawing.Color.White;
            this.lbl_HeadB_BackSuck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadB_BackSuck.Location = new System.Drawing.Point(6, 165);
            this.lbl_HeadB_BackSuck.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadB_BackSuck.Name = "lbl_HeadB_BackSuck";
            this.lbl_HeadB_BackSuck.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadB_BackSuck.TabIndex = 21;
            this.lbl_HeadB_BackSuck.Text = "0.000001";
            this.lbl_HeadB_BackSuck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadB_BackSuck.Click += new System.EventHandler(this.lbl_HeadB_BackSuck_Click);
            // 
            // lbl_HeadB_AdjVal
            // 
            this.lbl_HeadB_AdjVal.BackColor = System.Drawing.Color.White;
            this.lbl_HeadB_AdjVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadB_AdjVal.Location = new System.Drawing.Point(6, 57);
            this.lbl_HeadB_AdjVal.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadB_AdjVal.Name = "lbl_HeadB_AdjVal";
            this.lbl_HeadB_AdjVal.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadB_AdjVal.TabIndex = 24;
            this.lbl_HeadB_AdjVal.Text = "0.001";
            this.lbl_HeadB_AdjVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadB_AdjVal.Click += new System.EventHandler(this.lbl_HeadBAdjVal_Click);
            // 
            // btn_HeadB_M
            // 
            this.btn_HeadB_M.AccessibleDescription = "";
            this.btn_HeadB_M.Location = new System.Drawing.Point(82, 57);
            this.btn_HeadB_M.Name = "btn_HeadB_M";
            this.btn_HeadB_M.Size = new System.Drawing.Size(30, 30);
            this.btn_HeadB_M.TabIndex = 37;
            this.btn_HeadB_M.Text = "-";
            this.btn_HeadB_M.UseVisualStyleBackColor = true;
            this.btn_HeadB_M.Click += new System.EventHandler(this.btn_HB_M_Click);
            // 
            // lbl_HeadBCurrent
            // 
            this.lbl_HeadBCurrent.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadBCurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBCurrent.Location = new System.Drawing.Point(6, 201);
            this.lbl_HeadBCurrent.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadBCurrent.Name = "lbl_HeadBCurrent";
            this.lbl_HeadBCurrent.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadBCurrent.TabIndex = 27;
            this.lbl_HeadBCurrent.Text = "0.001";
            this.lbl_HeadBCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_HeadB_P
            // 
            this.btn_HeadB_P.AccessibleDescription = "";
            this.btn_HeadB_P.Location = new System.Drawing.Point(122, 57);
            this.btn_HeadB_P.Name = "btn_HeadB_P";
            this.btn_HeadB_P.Size = new System.Drawing.Size(30, 30);
            this.btn_HeadB_P.TabIndex = 36;
            this.btn_HeadB_P.Text = "+";
            this.btn_HeadB_P.UseVisualStyleBackColor = true;
            this.btn_HeadB_P.Click += new System.EventHandler(this.btn_HB_P_Click);
            // 
            // btn_CopyA
            // 
            this.btn_CopyA.AccessibleDescription = "Copy A";
            this.btn_CopyA.Location = new System.Drawing.Point(82, 201);
            this.btn_CopyA.Name = "btn_CopyA";
            this.btn_CopyA.Size = new System.Drawing.Size(70, 30);
            this.btn_CopyA.TabIndex = 32;
            this.btn_CopyA.Text = "Copy A";
            this.btn_CopyA.UseVisualStyleBackColor = true;
            this.btn_CopyA.Click += new System.EventHandler(this.btn_CopyA_Click);
            // 
            // lbl_HeadA_VolComp
            // 
            this.lbl_HeadA_VolComp.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_VolComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_VolComp.Location = new System.Drawing.Point(6, 236);
            this.lbl_HeadA_VolComp.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadA_VolComp.Name = "lbl_HeadA_VolComp";
            this.lbl_HeadA_VolComp.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadA_VolComp.TabIndex = 41;
            this.lbl_HeadA_VolComp.Text = "0.000001";
            this.lbl_HeadA_VolComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_VolComp.Click += new System.EventHandler(this.lbl_HeadA_VolComp_Click);
            // 
            // lbl_HeadAOffset
            // 
            this.lbl_HeadAOffset.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadAOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadAOffset.Location = new System.Drawing.Point(6, 129);
            this.lbl_HeadAOffset.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadAOffset.Name = "lbl_HeadAOffset";
            this.lbl_HeadAOffset.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadAOffset.TabIndex = 36;
            this.lbl_HeadAOffset.Text = "0.001";
            this.lbl_HeadAOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_HeadA_M
            // 
            this.btn_HeadA_M.AccessibleDescription = "";
            this.btn_HeadA_M.Location = new System.Drawing.Point(82, 57);
            this.btn_HeadA_M.Name = "btn_HeadA_M";
            this.btn_HeadA_M.Size = new System.Drawing.Size(30, 30);
            this.btn_HeadA_M.TabIndex = 35;
            this.btn_HeadA_M.Text = "-";
            this.btn_HeadA_M.UseVisualStyleBackColor = true;
            this.btn_HeadA_M.Click += new System.EventHandler(this.btn_HA_M_Click);
            // 
            // btn_HeadA_P
            // 
            this.btn_HeadA_P.AccessibleDescription = "";
            this.btn_HeadA_P.Location = new System.Drawing.Point(122, 57);
            this.btn_HeadA_P.Name = "btn_HeadA_P";
            this.btn_HeadA_P.Size = new System.Drawing.Size(30, 30);
            this.btn_HeadA_P.TabIndex = 34;
            this.btn_HeadA_P.Text = "+";
            this.btn_HeadA_P.UseVisualStyleBackColor = true;
            this.btn_HeadA_P.Click += new System.EventHandler(this.btn_HA_P_Click);
            // 
            // lbl_HeadA_BackSuck
            // 
            this.lbl_HeadA_BackSuck.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_BackSuck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_BackSuck.Location = new System.Drawing.Point(6, 165);
            this.lbl_HeadA_BackSuck.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_BackSuck.Name = "lbl_HeadA_BackSuck";
            this.lbl_HeadA_BackSuck.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadA_BackSuck.TabIndex = 20;
            this.lbl_HeadA_BackSuck.Text = "0.000001";
            this.lbl_HeadA_BackSuck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_BackSuck.Click += new System.EventHandler(this.lbl_HeadA_BackSuck_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(459, 5);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 40);
            this.btn_Close.TabIndex = 31;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // gbox_Settings
            // 
            this.gbox_Settings.AccessibleDescription = "Settings";
            this.gbox_Settings.AutoSize = true;
            this.gbox_Settings.Controls.Add(this.label11);
            this.gbox_Settings.Controls.Add(this.lbl_HeadA_Ratio);
            this.gbox_Settings.Controls.Add(this.label16);
            this.gbox_Settings.Controls.Add(this.lbl_HeadB_Ratio);
            this.gbox_Settings.Controls.Add(this.label14);
            this.gbox_Settings.Controls.Add(this.label5);
            this.gbox_Settings.Controls.Add(this.label1);
            this.gbox_Settings.Controls.Add(this.lbl_AdjustReso);
            this.gbox_Settings.Controls.Add(this.label9);
            this.gbox_Settings.Controls.Add(this.lbl_AdjustTol);
            this.gbox_Settings.Location = new System.Drawing.Point(7, 415);
            this.gbox_Settings.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Settings.Name = "gbox_Settings";
            this.gbox_Settings.Size = new System.Drawing.Size(501, 144);
            this.gbox_Settings.TabIndex = 37;
            this.gbox_Settings.TabStop = false;
            this.gbox_Settings.Text = "Settings";
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "";
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(123, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 30);
            this.label11.TabIndex = 48;
            this.label11.Text = "(x)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_HeadA_Ratio
            // 
            this.lbl_HeadA_Ratio.BackColor = System.Drawing.Color.White;
            this.lbl_HeadA_Ratio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadA_Ratio.Location = new System.Drawing.Point(185, 21);
            this.lbl_HeadA_Ratio.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadA_Ratio.Name = "lbl_HeadA_Ratio";
            this.lbl_HeadA_Ratio.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadA_Ratio.TabIndex = 42;
            this.lbl_HeadA_Ratio.Text = "1.000";
            this.lbl_HeadA_Ratio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadA_Ratio.Click += new System.EventHandler(this.lbl_HeadA_Ratio_Click);
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "Volume Ratio";
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(6, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 30);
            this.label16.TabIndex = 43;
            this.label16.Text = "Volume Ratio";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_HeadB_Ratio
            // 
            this.lbl_HeadB_Ratio.BackColor = System.Drawing.Color.White;
            this.lbl_HeadB_Ratio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadB_Ratio.Location = new System.Drawing.Point(349, 21);
            this.lbl_HeadB_Ratio.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadB_Ratio.Name = "lbl_HeadB_Ratio";
            this.lbl_HeadB_Ratio.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadB_Ratio.TabIndex = 41;
            this.lbl_HeadB_Ratio.Text = "1.000";
            this.lbl_HeadB_Ratio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_HeadB_Ratio.Click += new System.EventHandler(this.lbl_HeadB_Ratio_Click);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "";
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(122, 93);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 30);
            this.label14.TabIndex = 40;
            this.label14.Text = "(mm)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(122, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 30);
            this.label5.TabIndex = 39;
            this.label5.Text = "(%)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Adjust Resolution";
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 30);
            this.label1.TabIndex = 37;
            this.label1.Text = "Adjust Resolution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AdjustReso
            // 
            this.lbl_AdjustReso.BackColor = System.Drawing.Color.White;
            this.lbl_AdjustReso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_AdjustReso.Location = new System.Drawing.Point(185, 93);
            this.lbl_AdjustReso.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_AdjustReso.Name = "lbl_AdjustReso";
            this.lbl_AdjustReso.Size = new System.Drawing.Size(70, 30);
            this.lbl_AdjustReso.TabIndex = 38;
            this.lbl_AdjustReso.Text = "0.000001";
            this.lbl_AdjustReso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_AdjustReso.Click += new System.EventHandler(this.lbl_AdjustReso_Click);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Adjust Tol";
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(6, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 30);
            this.label9.TabIndex = 35;
            this.label9.Text = "Adjust Tol";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AdjustTol
            // 
            this.lbl_AdjustTol.BackColor = System.Drawing.Color.White;
            this.lbl_AdjustTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_AdjustTol.Location = new System.Drawing.Point(185, 57);
            this.lbl_AdjustTol.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_AdjustTol.Name = "lbl_AdjustTol";
            this.lbl_AdjustTol.Size = new System.Drawing.Size(70, 30);
            this.lbl_AdjustTol.TabIndex = 36;
            this.lbl_AdjustTol.Text = "0.000001";
            this.lbl_AdjustTol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_AdjustTol.Click += new System.EventHandler(this.lbl_AdjustTol_Click);
            // 
            // lbl_RefType
            // 
            this.lbl_RefType.AccessibleDescription = "Runtime";
            this.lbl_RefType.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_RefType.Location = new System.Drawing.Point(4, 4);
            this.lbl_RefType.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_RefType.Name = "lbl_RefType";
            this.lbl_RefType.Size = new System.Drawing.Size(70, 15);
            this.lbl_RefType.TabIndex = 36;
            this.lbl_RefType.Text = "Runtime";
            this.lbl_RefType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Runtime
            // 
            this.lbl_Runtime.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Runtime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Runtime.Location = new System.Drawing.Point(84, 4);
            this.lbl_Runtime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Runtime.Name = "lbl_Runtime";
            this.lbl_Runtime.Size = new System.Drawing.Size(60, 30);
            this.lbl_Runtime.TabIndex = 37;
            this.lbl_Runtime.Text = "0.001";
            this.lbl_Runtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Reset
            // 
            this.btn_Reset.AccessibleDescription = "Reset";
            this.btn_Reset.Location = new System.Drawing.Point(387, 5);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(70, 40);
            this.btn_Reset.TabIndex = 38;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lbl_FrameCount
            // 
            this.lbl_FrameCount.BackColor = System.Drawing.Color.White;
            this.lbl_FrameCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FrameCount.Location = new System.Drawing.Point(84, 38);
            this.lbl_FrameCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FrameCount.Name = "lbl_FrameCount";
            this.lbl_FrameCount.Size = new System.Drawing.Size(60, 30);
            this.lbl_FrameCount.TabIndex = 42;
            this.lbl_FrameCount.Text = "0.001";
            this.lbl_FrameCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FrameCount.Click += new System.EventHandler(this.lbl_FrameCount_Click);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Frame";
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(4, 38);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 15);
            this.label12.TabIndex = 41;
            this.label12.Text = "Frame";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Update
            // 
            this.btn_Update.AccessibleDescription = "Update";
            this.btn_Update.Location = new System.Drawing.Point(82, 21);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(70, 40);
            this.btn_Update.TabIndex = 43;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 250;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AccessibleDescription = "Mode";
            this.lbl_Mode.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Mode.Location = new System.Drawing.Point(6, 42);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(70, 20);
            this.lbl_Mode.TabIndex = 45;
            this.lbl_Mode.Text = "Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Online
            // 
            this.lbl_Online.AccessibleDescription = "Online";
            this.lbl_Online.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Online.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Online.Location = new System.Drawing.Point(6, 21);
            this.lbl_Online.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_Online.Name = "lbl_Online";
            this.lbl_Online.Size = new System.Drawing.Size(70, 19);
            this.lbl_Online.TabIndex = 44;
            this.lbl_Online.Text = "Online";
            this.lbl_Online.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbox_VolumeOfst
            // 
            this.gbox_VolumeOfst.AutoSize = true;
            this.gbox_VolumeOfst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_VolumeOfst.Controls.Add(this.btn_Info);
            this.gbox_VolumeOfst.Controls.Add(this.lbl_Mode);
            this.gbox_VolumeOfst.Controls.Add(this.lbl_Online);
            this.gbox_VolumeOfst.Controls.Add(this.btn_Update);
            this.gbox_VolumeOfst.Location = new System.Drawing.Point(148, 4);
            this.gbox_VolumeOfst.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_VolumeOfst.Name = "gbox_VolumeOfst";
            this.gbox_VolumeOfst.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.gbox_VolumeOfst.Size = new System.Drawing.Size(234, 80);
            this.gbox_VolumeOfst.TabIndex = 46;
            this.gbox_VolumeOfst.TabStop = false;
            this.gbox_VolumeOfst.Text = "Offset";
            // 
            // btn_Info
            // 
            this.btn_Info.AccessibleDescription = "Info";
            this.btn_Info.Location = new System.Drawing.Point(158, 21);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(70, 40);
            this.btn_Info.TabIndex = 46;
            this.btn_Info.Text = "Info";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(4, 53);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 15);
            this.label15.TabIndex = 41;
            this.label15.Text = "(count)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "";
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(4, 19);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 15);
            this.label17.TabIndex = 47;
            this.label17.Text = "(min)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmr_Second
            // 
            this.tmr_Second.Enabled = true;
            this.tmr_Second.Interval = 1000;
            this.tmr_Second.Tick += new System.EventHandler(this.tmr_Second_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Head A";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_HeadABaseAdjust);
            this.groupBox1.Controls.Add(this.lbl_HeadABase);
            this.groupBox1.Controls.Add(this.lbl_HeadA_VolComp);
            this.groupBox1.Controls.Add(this.lbl_FPressA);
            this.groupBox1.Controls.Add(this.lbl_HeadA_AdjPcnt);
            this.groupBox1.Controls.Add(this.lbl_HeadA_AdjVal);
            this.groupBox1.Controls.Add(this.lbl_HeadACurrent);
            this.groupBox1.Controls.Add(this.lbl_HeadA_BackSuck);
            this.groupBox1.Controls.Add(this.btn_HeadA_P);
            this.groupBox1.Controls.Add(this.btn_HeadA_M);
            this.groupBox1.Controls.Add(this.lbl_HeadAOffset);
            this.groupBox1.Location = new System.Drawing.Point(186, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 322);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head A";
            // 
            // lbl_HeadABaseAdjust
            // 
            this.lbl_HeadABaseAdjust.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadABaseAdjust.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadABaseAdjust.Location = new System.Drawing.Point(82, 21);
            this.lbl_HeadABaseAdjust.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadABaseAdjust.Name = "lbl_HeadABaseAdjust";
            this.lbl_HeadABaseAdjust.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadABaseAdjust.TabIndex = 52;
            this.lbl_HeadABaseAdjust.Text = "000.001";
            this.lbl_HeadABaseAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Head B";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lbl_HeadBBaseAdjust);
            this.groupBox2.Controls.Add(this.lbl_FPressB);
            this.groupBox2.Controls.Add(this.lbl_HeadBBase);
            this.groupBox2.Controls.Add(this.lbl_HeadB_VolComp);
            this.groupBox2.Controls.Add(this.btn_CopyA);
            this.groupBox2.Controls.Add(this.btn_HeadB_P);
            this.groupBox2.Controls.Add(this.lbl_HeadBCurrent);
            this.groupBox2.Controls.Add(this.lbl_HeadBOffset);
            this.groupBox2.Controls.Add(this.btn_HeadB_M);
            this.groupBox2.Controls.Add(this.lbl_HeadB_AdjPcnt);
            this.groupBox2.Controls.Add(this.lbl_HeadB_AdjVal);
            this.groupBox2.Controls.Add(this.lbl_HeadB_BackSuck);
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(350, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 322);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Head B";
            // 
            // lbl_HeadBBaseAdjust
            // 
            this.lbl_HeadBBaseAdjust.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_HeadBBaseAdjust.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadBBaseAdjust.Location = new System.Drawing.Point(82, 21);
            this.lbl_HeadBBaseAdjust.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_HeadBBaseAdjust.Name = "lbl_HeadBBaseAdjust";
            this.lbl_HeadBBaseAdjust.Size = new System.Drawing.Size(70, 30);
            this.lbl_HeadBBaseAdjust.TabIndex = 50;
            this.lbl_HeadBBaseAdjust.Text = "0.001";
            this.lbl_HeadBBaseAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_DispTool_VolumeAdjust
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(562, 595);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_RefType);
            this.Controls.Add(this.gbox_VolumeOfst);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.gbox_Settings);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_Runtime);
            this.Controls.Add(this.gbox_HeadA);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbl_FrameCount);
            this.Controls.Add(this.label17);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispTool_VolumeAdjust";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "frm_DispTool_VolumeAdjust";
            this.Load += new System.EventHandler(this.frm_DispTool_VolumeAdjust_Load);
            this.gbox_HeadA.ResumeLayout(false);
            this.gbox_HeadA.PerformLayout();
            this.pnl_FPress.ResumeLayout(false);
            this.pnl_VolCompA.ResumeLayout(false);
            this.gbox_Settings.ResumeLayout(false);
            this.gbox_VolumeOfst.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_HeadABase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_HeadA_AdjVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_HeadA_AdjPcnt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_HeadACurrent;
        private System.Windows.Forms.GroupBox gbox_HeadA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_HeadBBase;
        private System.Windows.Forms.Label lbl_HeadBCurrent;
        private System.Windows.Forms.Label lbl_HeadB_AdjVal;
        private System.Windows.Forms.Label lbl_HeadB_AdjPcnt;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_CopyA;
        private System.Windows.Forms.Button btn_HeadA_M;
        private System.Windows.Forms.Button btn_HeadA_P;
        private System.Windows.Forms.Button btn_HeadB_M;
        private System.Windows.Forms.Button btn_HeadB_P;
        private System.Windows.Forms.Label lbl_l_BackSuck;
        private System.Windows.Forms.Label lbl_HeadA_BackSuck;
        private System.Windows.Forms.Label lbl_HeadB_BackSuck;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_AdjustTol;
        private System.Windows.Forms.GroupBox gbox_Settings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_HeadAOffset;
        private System.Windows.Forms.Label lbl_HeadBOffset;
        private System.Windows.Forms.Label lbl_RefType;
        private System.Windows.Forms.Label lbl_Runtime;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_l_HeadABackSuckUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_AdjustReso;
        private System.Windows.Forms.Label lbl_FrameCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_Online;
        private System.Windows.Forms.GroupBox gbox_VolumeOfst;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pnl_VolCompA;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl_HeadA_VolComp;
        private System.Windows.Forms.Label lbl_l_HeadAVolCompUnit;
        private System.Windows.Forms.Label lbl_HeadB_VolComp;
        private System.Windows.Forms.Timer tmr_Second;
        private System.Windows.Forms.Button btn_Info;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lbl_FPressB;
        private System.Windows.Forms.Label lbl_HeadA_Ratio;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_HeadB_Ratio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_FPressA;
        private System.Windows.Forms.Label lbl_FPressUnit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel pnl_FPress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_HeadABaseAdjust;
        private System.Windows.Forms.Label lbl_HeadBBaseAdjust;
    }
}