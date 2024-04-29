namespace DispCore
{
    partial class frm_DispCore_JogGantry
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
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.btn_ZN = new System.Windows.Forms.Button();
            this.btn_ZP = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_LockZ = new System.Windows.Forms.Button();
            this.btn_Speed = new System.Windows.Forms.Button();
            this.btn_PointJog = new System.Windows.Forms.Button();
            this.btn_GXNYN = new System.Windows.Forms.Button();
            this.btn_GXPYN = new System.Windows.Forms.Button();
            this.btn_GXPYP = new System.Windows.Forms.Button();
            this.btn_GXNYP = new System.Windows.Forms.Button();
            this.btn_XN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_YP = new System.Windows.Forms.Button();
            this.btn_GantryMode = new System.Windows.Forms.Button();
            this.btn_YN = new System.Windows.Forms.Button();
            this.lbl_JogStep = new System.Windows.Forms.Label();
            this.btn_XP = new System.Windows.Forms.Button();
            this.pnl_Jog = new System.Windows.Forms.Panel();
            this.pnl_Position = new System.Windows.Forms.Panel();
            this.lbl_MPosD = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_MPosZ = new System.Windows.Forms.Label();
            this.lbl_PosZ = new System.Windows.Forms.Label();
            this.lbl_MPosY = new System.Windows.Forms.Label();
            this.lbl_PosY = new System.Windows.Forms.Label();
            this.lbl_MPosX = new System.Windows.Forms.Label();
            this.lbl_PosX = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnl_Position.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // btn_ZN
            // 
            this.btn_ZN.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ZN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ZN.FlatAppearance.BorderSize = 2;
            this.btn_ZN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ZN.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ZN.Location = new System.Drawing.Point(446, 130);
            this.btn_ZN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ZN.Name = "btn_ZN";
            this.btn_ZN.Size = new System.Drawing.Size(62, 62);
            this.btn_ZN.TabIndex = 27;
            this.btn_ZN.TabStop = false;
            this.btn_ZN.UseVisualStyleBackColor = false;
            this.btn_ZN.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_ZN_Paint);
            this.btn_ZN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZN_MouseDown);
            this.btn_ZN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZN_MouseUp);
            // 
            // btn_ZP
            // 
            this.btn_ZP.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ZP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ZP.FlatAppearance.BorderSize = 2;
            this.btn_ZP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_ZP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ZP.Location = new System.Drawing.Point(446, 2);
            this.btn_ZP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ZP.Name = "btn_ZP";
            this.btn_ZP.Size = new System.Drawing.Size(62, 62);
            this.btn_ZP.TabIndex = 26;
            this.btn_ZP.TabStop = false;
            this.btn_ZP.UseVisualStyleBackColor = false;
            this.btn_ZP.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_ZP_Paint);
            this.btn_ZP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_ZP_MouseDown);
            this.btn_ZP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_ZP_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_LockZ);
            this.panel1.Controls.Add(this.btn_Speed);
            this.panel1.Controls.Add(this.btn_PointJog);
            this.panel1.Controls.Add(this.btn_GXNYN);
            this.panel1.Controls.Add(this.btn_ZN);
            this.panel1.Controls.Add(this.btn_GXPYN);
            this.panel1.Controls.Add(this.btn_GXPYP);
            this.panel1.Controls.Add(this.btn_ZP);
            this.panel1.Controls.Add(this.btn_GXNYP);
            this.panel1.Controls.Add(this.btn_XN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_YP);
            this.panel1.Controls.Add(this.btn_GantryMode);
            this.panel1.Controls.Add(this.btn_YN);
            this.panel1.Controls.Add(this.lbl_JogStep);
            this.panel1.Controls.Add(this.btn_XP);
            this.panel1.Controls.Add(this.pnl_Jog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 231);
            this.panel1.TabIndex = 51;
            // 
            // btn_LockZ
            // 
            this.btn_LockZ.BackColor = System.Drawing.SystemColors.Control;
            this.btn_LockZ.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_LockZ.FlatAppearance.BorderSize = 2;
            this.btn_LockZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_LockZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_LockZ.Location = new System.Drawing.Point(446, 66);
            this.btn_LockZ.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.btn_LockZ.Name = "btn_LockZ";
            this.btn_LockZ.Size = new System.Drawing.Size(62, 62);
            this.btn_LockZ.TabIndex = 43;
            this.btn_LockZ.TabStop = false;
            this.btn_LockZ.Text = "LockZ";
            this.btn_LockZ.UseVisualStyleBackColor = false;
            this.btn_LockZ.Click += new System.EventHandler(this.btn_LockZ_Click);
            // 
            // btn_Speed
            // 
            this.btn_Speed.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Speed.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Speed.FlatAppearance.BorderSize = 2;
            this.btn_Speed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Speed.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Speed.Location = new System.Drawing.Point(316, 66);
            this.btn_Speed.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.btn_Speed.Name = "btn_Speed";
            this.btn_Speed.Size = new System.Drawing.Size(62, 62);
            this.btn_Speed.TabIndex = 42;
            this.btn_Speed.TabStop = false;
            this.btn_Speed.Text = "Speed";
            this.btn_Speed.UseVisualStyleBackColor = false;
            this.btn_Speed.Click += new System.EventHandler(this.btn_Speed_Click);
            // 
            // btn_PointJog
            // 
            this.btn_PointJog.Location = new System.Drawing.Point(0, 198);
            this.btn_PointJog.Name = "btn_PointJog";
            this.btn_PointJog.Size = new System.Drawing.Size(75, 27);
            this.btn_PointJog.TabIndex = 41;
            this.btn_PointJog.Text = "Point Jog";
            this.btn_PointJog.UseVisualStyleBackColor = true;
            this.btn_PointJog.Click += new System.EventHandler(this.btn_PointJog_Click);
            // 
            // btn_GXNYN
            // 
            this.btn_GXNYN.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GXNYN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GXNYN.FlatAppearance.BorderSize = 2;
            this.btn_GXNYN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_GXNYN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GXNYN.Location = new System.Drawing.Point(252, 130);
            this.btn_GXNYN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.btn_GXNYN.Name = "btn_GXNYN";
            this.btn_GXNYN.Size = new System.Drawing.Size(62, 62);
            this.btn_GXNYN.TabIndex = 40;
            this.btn_GXNYN.TabStop = false;
            this.btn_GXNYN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GXNYN.UseVisualStyleBackColor = false;
            this.btn_GXNYN.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_GXNYN_Paint);
            this.btn_GXNYN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_GXNYN_MouseDown);
            this.btn_GXNYN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_GXNYN_MouseUp);
            // 
            // btn_GXPYN
            // 
            this.btn_GXPYN.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GXPYN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GXPYN.FlatAppearance.BorderSize = 2;
            this.btn_GXPYN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_GXPYN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GXPYN.Location = new System.Drawing.Point(380, 130);
            this.btn_GXPYN.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_GXPYN.Name = "btn_GXPYN";
            this.btn_GXPYN.Size = new System.Drawing.Size(62, 62);
            this.btn_GXPYN.TabIndex = 39;
            this.btn_GXPYN.TabStop = false;
            this.btn_GXPYN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GXPYN.UseVisualStyleBackColor = false;
            this.btn_GXPYN.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_GXPYN_Paint);
            this.btn_GXPYN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_GXPYN_MouseDown);
            this.btn_GXPYN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_GXPYN_MouseUp);
            // 
            // btn_GXPYP
            // 
            this.btn_GXPYP.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GXPYP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GXPYP.FlatAppearance.BorderSize = 2;
            this.btn_GXPYP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_GXPYP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GXPYP.Location = new System.Drawing.Point(380, 2);
            this.btn_GXPYP.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.btn_GXPYP.Name = "btn_GXPYP";
            this.btn_GXPYP.Size = new System.Drawing.Size(62, 62);
            this.btn_GXPYP.TabIndex = 38;
            this.btn_GXPYP.TabStop = false;
            this.btn_GXPYP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GXPYP.UseVisualStyleBackColor = false;
            this.btn_GXPYP.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_GXPYP_Paint);
            this.btn_GXPYP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_GXPYP_MouseDown);
            this.btn_GXPYP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_GXPYP_MouseUp);
            // 
            // btn_GXNYP
            // 
            this.btn_GXNYP.BackColor = System.Drawing.SystemColors.Control;
            this.btn_GXNYP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GXNYP.FlatAppearance.BorderSize = 2;
            this.btn_GXNYP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_GXNYP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_GXNYP.Location = new System.Drawing.Point(252, 2);
            this.btn_GXNYP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GXNYP.Name = "btn_GXNYP";
            this.btn_GXNYP.Size = new System.Drawing.Size(62, 62);
            this.btn_GXNYP.TabIndex = 37;
            this.btn_GXNYP.TabStop = false;
            this.btn_GXNYP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_GXNYP.UseVisualStyleBackColor = false;
            this.btn_GXNYP.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_GXNYP_Paint);
            this.btn_GXNYP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_GXNYP_MouseDown);
            this.btn_GXNYP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_GXNYP_MouseUp);
            // 
            // btn_XN
            // 
            this.btn_XN.BackColor = System.Drawing.SystemColors.Control;
            this.btn_XN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_XN.FlatAppearance.BorderSize = 2;
            this.btn_XN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_XN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XN.Location = new System.Drawing.Point(252, 66);
            this.btn_XN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.btn_XN.Name = "btn_XN";
            this.btn_XN.Size = new System.Drawing.Size(62, 62);
            this.btn_XN.TabIndex = 25;
            this.btn_XN.TabStop = false;
            this.btn_XN.UseVisualStyleBackColor = false;
            this.btn_XN.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_XN_Paint);
            this.btn_XN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XN_MouseDown);
            this.btn_XN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XN_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "Step mm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_YP
            // 
            this.btn_YP.BackColor = System.Drawing.SystemColors.Control;
            this.btn_YP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_YP.FlatAppearance.BorderSize = 2;
            this.btn_YP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_YP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_YP.Location = new System.Drawing.Point(316, 2);
            this.btn_YP.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.btn_YP.Name = "btn_YP";
            this.btn_YP.Size = new System.Drawing.Size(62, 62);
            this.btn_YP.TabIndex = 22;
            this.btn_YP.TabStop = false;
            this.btn_YP.UseVisualStyleBackColor = false;
            this.btn_YP.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_YP_Paint);
            this.btn_YP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YP_MouseDown);
            this.btn_YP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YP_MouseUp);
            // 
            // btn_GantryMode
            // 
            this.btn_GantryMode.Location = new System.Drawing.Point(380, 198);
            this.btn_GantryMode.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GantryMode.Name = "btn_GantryMode";
            this.btn_GantryMode.Size = new System.Drawing.Size(128, 27);
            this.btn_GantryMode.TabIndex = 36;
            this.btn_GantryMode.Text = "XYZ X2Y2Z2";
            this.btn_GantryMode.UseVisualStyleBackColor = true;
            this.btn_GantryMode.Click += new System.EventHandler(this.btn_XYZMode_Click);
            // 
            // btn_YN
            // 
            this.btn_YN.BackColor = System.Drawing.SystemColors.Control;
            this.btn_YN.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_YN.FlatAppearance.BorderSize = 2;
            this.btn_YN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_YN.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_YN.Location = new System.Drawing.Point(316, 130);
            this.btn_YN.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_YN.Name = "btn_YN";
            this.btn_YN.Size = new System.Drawing.Size(62, 62);
            this.btn_YN.TabIndex = 23;
            this.btn_YN.TabStop = false;
            this.btn_YN.UseVisualStyleBackColor = false;
            this.btn_YN.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_YN_Paint);
            this.btn_YN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YN_MouseDown);
            this.btn_YN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YN_MouseUp);
            // 
            // lbl_JogStep
            // 
            this.lbl_JogStep.BackColor = System.Drawing.Color.White;
            this.lbl_JogStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_JogStep.Location = new System.Drawing.Point(316, 198);
            this.lbl_JogStep.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_JogStep.Name = "lbl_JogStep";
            this.lbl_JogStep.Size = new System.Drawing.Size(62, 27);
            this.lbl_JogStep.TabIndex = 34;
            this.lbl_JogStep.Text = "0.001";
            this.lbl_JogStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_JogStep.Click += new System.EventHandler(this.lbl_JogStep_Click);
            // 
            // btn_XP
            // 
            this.btn_XP.BackColor = System.Drawing.SystemColors.Control;
            this.btn_XP.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_XP.FlatAppearance.BorderSize = 2;
            this.btn_XP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_XP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XP.Location = new System.Drawing.Point(380, 66);
            this.btn_XP.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btn_XP.Name = "btn_XP";
            this.btn_XP.Size = new System.Drawing.Size(62, 62);
            this.btn_XP.TabIndex = 24;
            this.btn_XP.TabStop = false;
            this.btn_XP.UseVisualStyleBackColor = false;
            this.btn_XP.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_XP_Paint);
            this.btn_XP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XP_MouseDown);
            this.btn_XP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XP_MouseUp);
            // 
            // pnl_Jog
            // 
            this.pnl_Jog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Jog.Location = new System.Drawing.Point(0, 2);
            this.pnl_Jog.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Jog.Name = "pnl_Jog";
            this.pnl_Jog.Size = new System.Drawing.Size(248, 191);
            this.pnl_Jog.TabIndex = 32;
            this.pnl_Jog.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Jog_Paint);
            this.pnl_Jog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Jog_MouseDown);
            // 
            // pnl_Position
            // 
            this.pnl_Position.Controls.Add(this.lbl_MPosD);
            this.pnl_Position.Controls.Add(this.btn_Reset);
            this.pnl_Position.Controls.Add(this.label5);
            this.pnl_Position.Controls.Add(this.label6);
            this.pnl_Position.Controls.Add(this.lbl_MPosZ);
            this.pnl_Position.Controls.Add(this.lbl_PosZ);
            this.pnl_Position.Controls.Add(this.lbl_MPosY);
            this.pnl_Position.Controls.Add(this.lbl_PosY);
            this.pnl_Position.Controls.Add(this.lbl_MPosX);
            this.pnl_Position.Controls.Add(this.lbl_PosX);
            this.pnl_Position.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Position.Location = new System.Drawing.Point(3, 234);
            this.pnl_Position.Name = "pnl_Position";
            this.pnl_Position.Size = new System.Drawing.Size(512, 38);
            this.pnl_Position.TabIndex = 53;
            // 
            // lbl_MPosD
            // 
            this.lbl_MPosD.AutoSize = true;
            this.lbl_MPosD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MPosD.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_MPosD.Location = new System.Drawing.Point(269, 20);
            this.lbl_MPosD.Name = "lbl_MPosD";
            this.lbl_MPosD.Size = new System.Drawing.Size(74, 14);
            this.lbl_MPosD.TabIndex = 9;
            this.lbl_MPosD.Text = "D=-999.000";
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Reset.Location = new System.Drawing.Point(439, 3);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(70, 31);
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ref";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pos";
            // 
            // lbl_MPosZ
            // 
            this.lbl_MPosZ.AutoSize = true;
            this.lbl_MPosZ.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MPosZ.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_MPosZ.Location = new System.Drawing.Point(190, 20);
            this.lbl_MPosZ.Name = "lbl_MPosZ";
            this.lbl_MPosZ.Size = new System.Drawing.Size(73, 14);
            this.lbl_MPosZ.TabIndex = 5;
            this.lbl_MPosZ.Text = "X=-999.000";
            // 
            // lbl_PosZ
            // 
            this.lbl_PosZ.AutoSize = true;
            this.lbl_PosZ.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PosZ.Location = new System.Drawing.Point(190, 3);
            this.lbl_PosZ.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbl_PosZ.Name = "lbl_PosZ";
            this.lbl_PosZ.Size = new System.Drawing.Size(73, 14);
            this.lbl_PosZ.TabIndex = 4;
            this.lbl_PosZ.Text = "X=-999.000";
            // 
            // lbl_MPosY
            // 
            this.lbl_MPosY.AutoSize = true;
            this.lbl_MPosY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MPosY.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_MPosY.Location = new System.Drawing.Point(111, 20);
            this.lbl_MPosY.Name = "lbl_MPosY";
            this.lbl_MPosY.Size = new System.Drawing.Size(73, 14);
            this.lbl_MPosY.TabIndex = 3;
            this.lbl_MPosY.Text = "X=-999.000";
            // 
            // lbl_PosY
            // 
            this.lbl_PosY.AutoSize = true;
            this.lbl_PosY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PosY.Location = new System.Drawing.Point(111, 3);
            this.lbl_PosY.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbl_PosY.Name = "lbl_PosY";
            this.lbl_PosY.Size = new System.Drawing.Size(73, 14);
            this.lbl_PosY.TabIndex = 2;
            this.lbl_PosY.Text = "X=-999.000";
            // 
            // lbl_MPosX
            // 
            this.lbl_MPosX.AutoSize = true;
            this.lbl_MPosX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MPosX.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_MPosX.Location = new System.Drawing.Point(32, 20);
            this.lbl_MPosX.Name = "lbl_MPosX";
            this.lbl_MPosX.Size = new System.Drawing.Size(73, 14);
            this.lbl_MPosX.TabIndex = 1;
            this.lbl_MPosX.Text = "X=-999.000";
            // 
            // lbl_PosX
            // 
            this.lbl_PosX.AutoSize = true;
            this.lbl_PosX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PosX.Location = new System.Drawing.Point(32, 3);
            this.lbl_PosX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbl_PosX.Name = "lbl_PosX";
            this.lbl_PosX.Size = new System.Drawing.Size(73, 14);
            this.lbl_PosX.TabIndex = 0;
            this.lbl_PosX.Text = "X=-999.000";
            // 
            // frm_DispCore_JogGantry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(518, 276);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_Position);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DispCore_JogGantry";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.Text = "JOG";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmJog_Load);
            this.Shown += new System.EventHandler(this.frmJog_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmJog_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Jog_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJog_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Jog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.pnl_Position.ResumeLayout(false);
            this.pnl_Position.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_ZN;
        private System.Windows.Forms.Button btn_ZP;
        private System.Windows.Forms.Button btn_XN;
        private System.Windows.Forms.Button btn_XP;
        private System.Windows.Forms.Button btn_YN;
        private System.Windows.Forms.Button btn_YP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_Jog;
        private System.Windows.Forms.Label lbl_JogStep;
        private System.Windows.Forms.Button btn_GantryMode;
        private System.Windows.Forms.Panel pnl_Position;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_MPosZ;
        private System.Windows.Forms.Label lbl_PosZ;
        private System.Windows.Forms.Label lbl_MPosY;
        private System.Windows.Forms.Label lbl_PosY;
        private System.Windows.Forms.Label lbl_MPosX;
        private System.Windows.Forms.Label lbl_PosX;
        private System.Windows.Forms.Label lbl_MPosD;
        private System.Windows.Forms.Button btn_GXPYP;
        private System.Windows.Forms.Button btn_GXNYP;
        private System.Windows.Forms.Button btn_GXNYN;
        private System.Windows.Forms.Button btn_GXPYN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_PointJog;
        private System.Windows.Forms.Button btn_Speed;
        private System.Windows.Forms.Button btn_LockZ;
    }
}