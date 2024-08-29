namespace NDispWin
{
    partial class frm_DispCore_DispProg_DoVision
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
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Align = new System.Windows.Forms.Button();
            this.lbl_X1Y1 = new System.Windows.Forms.Label();
            this.btn_SetPt1Pos = new System.Windows.Forms.Button();
            this.btn_Grab = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_GotoPt1Pos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Test = new System.Windows.Forms.Button();
            this.lbl_VisionID = new System.Windows.Forms.Label();
            this.lbox_Info = new System.Windows.Forms.ListBox();
            this.lbllblAlignType = new System.Windows.Forms.Label();
            this.lbl_AlignType = new System.Windows.Forms.Label();
            this.lbl_CameraID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Position = new System.Windows.Forms.TabPage();
            this.btn_GrabExec = new System.Windows.Forms.Button();
            this.ttPage_Settings = new System.Windows.Forms.TabPage();
            this.lbllblInspectPrior = new System.Windows.Forms.Label();
            this.lblInspPrior = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_SettleTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_StartV = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl_Accel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_DriveV = new System.Windows.Forms.Label();
            this.tpage_Options = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_XYTol = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_AcceptTol = new System.Windows.Forms.Label();
            this.lbl_FailAction = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_SkipCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tpage_Advance = new System.Windows.Forms.TabPage();
            this.cbSaveImages = new System.Windows.Forms.ComboBox();
            this.lbl_SaveDirectory = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.pnl_Tools = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_FocusNo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpage_Position.SuspendLayout();
            this.ttPage_Settings.SuspendLayout();
            this.tpage_Options.SuspendLayout();
            this.tpage_Advance.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Load
            // 
            this.btn_Load.AccessibleDescription = "Load Img";
            this.btn_Load.Location = new System.Drawing.Point(163, 43);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 30);
            this.btn_Load.TabIndex = 15;
            this.btn_Load.Text = "Load Img";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_LoadImg_Click);
            // 
            // btn_Align
            // 
            this.btn_Align.AccessibleDescription = "Align";
            this.btn_Align.Location = new System.Drawing.Point(87, 576);
            this.btn_Align.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Align.Name = "btn_Align";
            this.btn_Align.Size = new System.Drawing.Size(75, 36);
            this.btn_Align.TabIndex = 14;
            this.btn_Align.Text = "Align";
            this.btn_Align.UseVisualStyleBackColor = true;
            this.btn_Align.Click += new System.EventHandler(this.btn_Align_Click);
            // 
            // lbl_X1Y1
            // 
            this.lbl_X1Y1.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_X1Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1Y1.Location = new System.Drawing.Point(89, 13);
            this.lbl_X1Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1Y1.Name = "lbl_X1Y1";
            this.lbl_X1Y1.Size = new System.Drawing.Size(120, 23);
            this.lbl_X1Y1.TabIndex = 5;
            this.lbl_X1Y1.Text = "-999.999, -999.999";
            this.lbl_X1Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SetPt1Pos
            // 
            this.btn_SetPt1Pos.AccessibleDescription = "Set";
            this.btn_SetPt1Pos.Location = new System.Drawing.Point(292, 9);
            this.btn_SetPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetPt1Pos.Name = "btn_SetPt1Pos";
            this.btn_SetPt1Pos.Size = new System.Drawing.Size(75, 30);
            this.btn_SetPt1Pos.TabIndex = 3;
            this.btn_SetPt1Pos.Text = "Set";
            this.btn_SetPt1Pos.UseVisualStyleBackColor = true;
            this.btn_SetPt1Pos.Click += new System.EventHandler(this.btn_SetPt1Pos_Click);
            // 
            // btn_Grab
            // 
            this.btn_Grab.AccessibleDescription = "Grab";
            this.btn_Grab.Location = new System.Drawing.Point(5, 43);
            this.btn_Grab.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Grab.Name = "btn_Grab";
            this.btn_Grab.Size = new System.Drawing.Size(75, 30);
            this.btn_Grab.TabIndex = 10;
            this.btn_Grab.Text = "Grab";
            this.btn_Grab.UseVisualStyleBackColor = true;
            this.btn_Grab.Click += new System.EventHandler(this.btn_Grab_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Pos XY (mm)";
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "XY (mm)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_GotoPt1Pos
            // 
            this.btn_GotoPt1Pos.AccessibleDescription = "Goto";
            this.btn_GotoPt1Pos.Location = new System.Drawing.Point(213, 9);
            this.btn_GotoPt1Pos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoPt1Pos.Name = "btn_GotoPt1Pos";
            this.btn_GotoPt1Pos.Size = new System.Drawing.Size(75, 30);
            this.btn_GotoPt1Pos.TabIndex = 4;
            this.btn_GotoPt1Pos.Text = "Goto";
            this.btn_GotoPt1Pos.UseVisualStyleBackColor = true;
            this.btn_GotoPt1Pos.Click += new System.EventHandler(this.btn_GotoPt1Pos_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Vision ID";
            this.label3.Location = new System.Drawing.Point(8, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vision ID ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(239, 576);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(318, 576);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Test
            // 
            this.btn_Test.AccessibleDescription = "Test";
            this.btn_Test.Location = new System.Drawing.Point(8, 576);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 36);
            this.btn_Test.TabIndex = 14;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // lbl_VisionID
            // 
            this.lbl_VisionID.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_VisionID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_VisionID.Location = new System.Drawing.Point(112, 7);
            this.lbl_VisionID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_VisionID.Name = "lbl_VisionID";
            this.lbl_VisionID.Size = new System.Drawing.Size(75, 24);
            this.lbl_VisionID.TabIndex = 20;
            this.lbl_VisionID.Text = "lbl_VisionID";
            this.lbl_VisionID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_VisionID.Click += new System.EventHandler(this.lbl_RefID_Click);
            // 
            // lbox_Info
            // 
            this.lbox_Info.BackColor = System.Drawing.SystemColors.Control;
            this.lbox_Info.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_Info.ForeColor = System.Drawing.Color.Navy;
            this.lbox_Info.FormattingEnabled = true;
            this.lbox_Info.ItemHeight = 16;
            this.lbox_Info.Location = new System.Drawing.Point(6, 6);
            this.lbox_Info.Name = "lbox_Info";
            this.lbox_Info.Size = new System.Drawing.Size(365, 52);
            this.lbox_Info.TabIndex = 37;
            // 
            // lbllblAlignType
            // 
            this.lbllblAlignType.AccessibleDescription = "Align Type";
            this.lbllblAlignType.Location = new System.Drawing.Point(231, 8);
            this.lbllblAlignType.Margin = new System.Windows.Forms.Padding(2);
            this.lbllblAlignType.Name = "lbllblAlignType";
            this.lbllblAlignType.Size = new System.Drawing.Size(82, 23);
            this.lbllblAlignType.TabIndex = 38;
            this.lbllblAlignType.Text = "Align Type";
            this.lbllblAlignType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_AlignType
            // 
            this.lbl_AlignType.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_AlignType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_AlignType.Location = new System.Drawing.Point(317, 7);
            this.lbl_AlignType.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_AlignType.Name = "lbl_AlignType";
            this.lbl_AlignType.Size = new System.Drawing.Size(75, 24);
            this.lbl_AlignType.TabIndex = 39;
            this.lbl_AlignType.Text = "lbl_AlignType";
            this.lbl_AlignType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_AlignType.Click += new System.EventHandler(this.lbl_AlignType_Click);
            // 
            // lbl_CameraID
            // 
            this.lbl_CameraID.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CameraID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CameraID.Location = new System.Drawing.Point(112, 35);
            this.lbl_CameraID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CameraID.Name = "lbl_CameraID";
            this.lbl_CameraID.Size = new System.Drawing.Size(75, 24);
            this.lbl_CameraID.TabIndex = 41;
            this.lbl_CameraID.Text = "lbl_CameraID";
            this.lbl_CameraID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CameraID.Click += new System.EventHandler(this.lbl_CameraID_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Camera ID";
            this.label6.Location = new System.Drawing.Point(7, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "Camera ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_Position);
            this.tabControl1.Controls.Add(this.ttPage_Settings);
            this.tabControl1.Controls.Add(this.tpage_Options);
            this.tabControl1.Controls.Add(this.tpage_Advance);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.ItemSize = new System.Drawing.Size(74, 25);
            this.tabControl1.Location = new System.Drawing.Point(8, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 121);
            this.tabControl1.TabIndex = 45;
            // 
            // tpage_Position
            // 
            this.tpage_Position.AccessibleDescription = "Position";
            this.tpage_Position.Controls.Add(this.btn_GrabExec);
            this.tpage_Position.Controls.Add(this.btn_Load);
            this.tpage_Position.Controls.Add(this.label1);
            this.tpage_Position.Controls.Add(this.lbl_X1Y1);
            this.tpage_Position.Controls.Add(this.btn_GotoPt1Pos);
            this.tpage_Position.Controls.Add(this.btn_SetPt1Pos);
            this.tpage_Position.Controls.Add(this.btn_Grab);
            this.tpage_Position.Location = new System.Drawing.Point(4, 29);
            this.tpage_Position.Name = "tpage_Position";
            this.tpage_Position.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Position.Size = new System.Drawing.Size(377, 88);
            this.tpage_Position.TabIndex = 0;
            this.tpage_Position.Text = "Position";
            this.tpage_Position.UseVisualStyleBackColor = true;
            // 
            // btn_GrabExec
            // 
            this.btn_GrabExec.AccessibleDescription = "Grab Exec";
            this.btn_GrabExec.Location = new System.Drawing.Point(84, 43);
            this.btn_GrabExec.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GrabExec.Name = "btn_GrabExec";
            this.btn_GrabExec.Size = new System.Drawing.Size(75, 30);
            this.btn_GrabExec.TabIndex = 16;
            this.btn_GrabExec.Text = "Grab Exec";
            this.btn_GrabExec.UseVisualStyleBackColor = true;
            this.btn_GrabExec.Click += new System.EventHandler(this.btn_GrabExec_Click);
            // 
            // ttPage_Settings
            // 
            this.ttPage_Settings.Controls.Add(this.lbllblInspectPrior);
            this.ttPage_Settings.Controls.Add(this.lblInspPrior);
            this.ttPage_Settings.Controls.Add(this.label12);
            this.ttPage_Settings.Controls.Add(this.lbl_SettleTime);
            this.ttPage_Settings.Controls.Add(this.label8);
            this.ttPage_Settings.Controls.Add(this.lbl_StartV);
            this.ttPage_Settings.Controls.Add(this.label18);
            this.ttPage_Settings.Controls.Add(this.lbl_Accel);
            this.ttPage_Settings.Controls.Add(this.label21);
            this.ttPage_Settings.Controls.Add(this.lbl_DriveV);
            this.ttPage_Settings.Location = new System.Drawing.Point(4, 29);
            this.ttPage_Settings.Name = "ttPage_Settings";
            this.ttPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.ttPage_Settings.Size = new System.Drawing.Size(377, 88);
            this.ttPage_Settings.TabIndex = 3;
            this.ttPage_Settings.Text = "Settings";
            this.ttPage_Settings.UseVisualStyleBackColor = true;
            // 
            // lbllblInspectPrior
            // 
            this.lbllblInspectPrior.AccessibleDescription = "";
            this.lbllblInspectPrior.Location = new System.Drawing.Point(195, 32);
            this.lbllblInspectPrior.Margin = new System.Windows.Forms.Padding(2);
            this.lbllblInspectPrior.Name = "lbllblInspectPrior";
            this.lbllblInspectPrior.Size = new System.Drawing.Size(120, 23);
            this.lbllblInspectPrior.TabIndex = 161;
            this.lbllblInspectPrior.Text = "Inspect Prior (units)";
            this.lbllblInspectPrior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInspPrior
            // 
            this.lblInspPrior.BackColor = System.Drawing.SystemColors.Window;
            this.lblInspPrior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInspPrior.Location = new System.Drawing.Point(322, 32);
            this.lblInspPrior.Margin = new System.Windows.Forms.Padding(2);
            this.lblInspPrior.Name = "lblInspPrior";
            this.lblInspPrior.Size = new System.Drawing.Size(50, 23);
            this.lblInspPrior.TabIndex = 162;
            this.lblInspPrior.Text = "0";
            this.lblInspPrior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInspPrior.Click += new System.EventHandler(this.lblInspPrior_Click);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "Settle Time (ms)";
            this.label12.Location = new System.Drawing.Point(195, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 23);
            this.label12.TabIndex = 157;
            this.label12.Text = "Settle Time (ms)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SettleTime
            // 
            this.lbl_SettleTime.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SettleTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SettleTime.Location = new System.Drawing.Point(322, 5);
            this.lbl_SettleTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SettleTime.Name = "lbl_SettleTime";
            this.lbl_SettleTime.Size = new System.Drawing.Size(50, 23);
            this.lbl_SettleTime.TabIndex = 158;
            this.lbl_SettleTime.Text = "0";
            this.lbl_SettleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SettleTime.Click += new System.EventHandler(this.lbl_SettleTime_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Start Speed (mm/s)";
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 155;
            this.label8.Text = "Start Speed (mm/s)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_StartV
            // 
            this.lbl_StartV.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_StartV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartV.Location = new System.Drawing.Point(129, 5);
            this.lbl_StartV.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartV.Name = "lbl_StartV";
            this.lbl_StartV.Size = new System.Drawing.Size(50, 23);
            this.lbl_StartV.TabIndex = 156;
            this.lbl_StartV.Text = "5000";
            this.lbl_StartV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_StartV.Click += new System.EventHandler(this.lbl_StartV_Click);
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "Accel (mm/s2)";
            this.label18.Location = new System.Drawing.Point(5, 59);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 23);
            this.label18.TabIndex = 153;
            this.label18.Text = "Accel (mm/s2)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Accel
            // 
            this.lbl_Accel.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Accel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Accel.Location = new System.Drawing.Point(129, 59);
            this.lbl_Accel.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Accel.Name = "lbl_Accel";
            this.lbl_Accel.Size = new System.Drawing.Size(50, 23);
            this.lbl_Accel.TabIndex = 154;
            this.lbl_Accel.Text = "0";
            this.lbl_Accel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Accel.Click += new System.EventHandler(this.lbl_Accel_Click);
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "Drive Speed (mm/s)";
            this.label21.Location = new System.Drawing.Point(5, 32);
            this.label21.Margin = new System.Windows.Forms.Padding(2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 23);
            this.label21.TabIndex = 151;
            this.label21.Text = "Drive Speed (mm/s)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DriveV
            // 
            this.lbl_DriveV.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_DriveV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DriveV.Location = new System.Drawing.Point(129, 32);
            this.lbl_DriveV.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_DriveV.Name = "lbl_DriveV";
            this.lbl_DriveV.Size = new System.Drawing.Size(50, 23);
            this.lbl_DriveV.TabIndex = 152;
            this.lbl_DriveV.Text = "0";
            this.lbl_DriveV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_DriveV.Click += new System.EventHandler(this.lbl_DriveV_Click);
            // 
            // tpage_Options
            // 
            this.tpage_Options.AccessibleDescription = "Options";
            this.tpage_Options.Controls.Add(this.label9);
            this.tpage_Options.Controls.Add(this.lbl_XYTol);
            this.tpage_Options.Controls.Add(this.label20);
            this.tpage_Options.Controls.Add(this.lbl_AcceptTol);
            this.tpage_Options.Controls.Add(this.lbl_FailAction);
            this.tpage_Options.Controls.Add(this.label16);
            this.tpage_Options.Controls.Add(this.lbl_SkipCount);
            this.tpage_Options.Controls.Add(this.label7);
            this.tpage_Options.Location = new System.Drawing.Point(4, 29);
            this.tpage_Options.Name = "tpage_Options";
            this.tpage_Options.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Options.Size = new System.Drawing.Size(377, 88);
            this.tpage_Options.TabIndex = 1;
            this.tpage_Options.Text = "Options";
            this.tpage_Options.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "XY Tol (mm)";
            this.label9.Location = new System.Drawing.Point(206, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 24);
            this.label9.TabIndex = 147;
            this.label9.Text = "XY Tol (mm)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_XYTol
            // 
            this.lbl_XYTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_XYTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_XYTol.Location = new System.Drawing.Point(297, 59);
            this.lbl_XYTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_XYTol.Name = "lbl_XYTol";
            this.lbl_XYTol.Size = new System.Drawing.Size(75, 24);
            this.lbl_XYTol.TabIndex = 148;
            this.lbl_XYTol.Text = "9.999";
            this.lbl_XYTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_XYTol.Click += new System.EventHandler(this.lblXYTol_Click);
            // 
            // label20
            // 
            this.label20.AccessibleDescription = "Accept Tol (mm)";
            this.label20.Location = new System.Drawing.Point(7, 59);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 24);
            this.label20.TabIndex = 145;
            this.label20.Text = "Accept Tol (mm)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AcceptTol
            // 
            this.lbl_AcceptTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_AcceptTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_AcceptTol.Location = new System.Drawing.Point(129, 59);
            this.lbl_AcceptTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_AcceptTol.Name = "lbl_AcceptTol";
            this.lbl_AcceptTol.Size = new System.Drawing.Size(75, 24);
            this.lbl_AcceptTol.TabIndex = 146;
            this.lbl_AcceptTol.Text = "9.999";
            this.lbl_AcceptTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_AcceptTol.Click += new System.EventHandler(this.lbl_AcceptTol_Click);
            // 
            // lbl_FailAction
            // 
            this.lbl_FailAction.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FailAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FailAction.Location = new System.Drawing.Point(129, 32);
            this.lbl_FailAction.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FailAction.Name = "lbl_FailAction";
            this.lbl_FailAction.Size = new System.Drawing.Size(120, 23);
            this.lbl_FailAction.TabIndex = 144;
            this.lbl_FailAction.Text = "0";
            this.lbl_FailAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_FailAction.Click += new System.EventHandler(this.lbl_FailAction_Click);
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "Fail Action";
            this.label16.Location = new System.Drawing.Point(5, 32);
            this.label16.Margin = new System.Windows.Forms.Padding(2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 23);
            this.label16.TabIndex = 143;
            this.label16.Text = "Fail Action";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SkipCount
            // 
            this.lbl_SkipCount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SkipCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SkipCount.Location = new System.Drawing.Point(129, 5);
            this.lbl_SkipCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SkipCount.Name = "lbl_SkipCount";
            this.lbl_SkipCount.Size = new System.Drawing.Size(50, 23);
            this.lbl_SkipCount.TabIndex = 21;
            this.lbl_SkipCount.Text = "0";
            this.lbl_SkipCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_SkipCount.Click += new System.EventHandler(this.lbl_SkipCount_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Skip Count (Counts)";
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Skip Count (Counts)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpage_Advance
            // 
            this.tpage_Advance.Controls.Add(this.cbSaveImages);
            this.tpage_Advance.Controls.Add(this.lbl_SaveDirectory);
            this.tpage_Advance.Controls.Add(this.label4);
            this.tpage_Advance.Controls.Add(this.label5);
            this.tpage_Advance.Location = new System.Drawing.Point(4, 29);
            this.tpage_Advance.Name = "tpage_Advance";
            this.tpage_Advance.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Advance.Size = new System.Drawing.Size(377, 88);
            this.tpage_Advance.TabIndex = 4;
            this.tpage_Advance.Text = "Advance";
            this.tpage_Advance.UseVisualStyleBackColor = true;
            this.tpage_Advance.Click += new System.EventHandler(this.tpage_Advance_Click);
            // 
            // cbSaveImages
            // 
            this.cbSaveImages.FormattingEnabled = true;
            this.cbSaveImages.Location = new System.Drawing.Point(127, 6);
            this.cbSaveImages.Name = "cbSaveImages";
            this.cbSaveImages.Size = new System.Drawing.Size(121, 26);
            this.cbSaveImages.TabIndex = 0;
            this.cbSaveImages.SelectionChangeCommitted += new System.EventHandler(this.cbSaveImages_SelectionChangeCommitted);
            // 
            // lbl_SaveDirectory
            // 
            this.lbl_SaveDirectory.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_SaveDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_SaveDirectory.Location = new System.Drawing.Point(127, 37);
            this.lbl_SaveDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SaveDirectory.Name = "lbl_SaveDirectory";
            this.lbl_SaveDirectory.Size = new System.Drawing.Size(245, 24);
            this.lbl_SaveDirectory.TabIndex = 157;
            this.lbl_SaveDirectory.Text = "c:\\ImageBuffer";
            this.lbl_SaveDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_SaveDirectory.Click += new System.EventHandler(this.lbl_SaveDirectory_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Save Location";
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 23);
            this.label4.TabIndex = 156;
            this.label4.Text = "Save Location";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Save Images";
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 153;
            this.label5.Text = "Save Images";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbox_Info);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 88);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 18;
            this.lbox_Cond.Location = new System.Drawing.Point(8, 62);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(326, 22);
            this.lbox_Cond.TabIndex = 168;
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(339, 62);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(50, 32);
            this.btn_Cond.TabIndex = 167;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // pnl_Tools
            // 
            this.pnl_Tools.Location = new System.Drawing.Point(8, 227);
            this.pnl_Tools.Name = "pnl_Tools";
            this.pnl_Tools.Size = new System.Drawing.Size(385, 344);
            this.pnl_Tools.TabIndex = 51;
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Focus No";
            this.label19.Location = new System.Drawing.Point(239, 34);
            this.label19.Margin = new System.Windows.Forms.Padding(2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 23);
            this.label19.TabIndex = 149;
            this.label19.Text = "Focus No";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FocusNo
            // 
            this.lbl_FocusNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FocusNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FocusNo.Location = new System.Drawing.Point(317, 35);
            this.lbl_FocusNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FocusNo.Name = "lbl_FocusNo";
            this.lbl_FocusNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_FocusNo.TabIndex = 150;
            this.lbl_FocusNo.Text = "0";
            this.lbl_FocusNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_FocusNo.Click += new System.EventHandler(this.lbl_FocusNo_Click);
            // 
            // frm_DispCore_DispProg_DoVision
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(408, 615);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbl_FocusNo);
            this.Controls.Add(this.pnl_Tools);
            this.Controls.Add(this.btn_Align);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbl_CameraID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_AlignType);
            this.Controls.Add(this.lbllblAlignType);
            this.Controls.Add(this.lbl_VisionID);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_DoVision";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_DoVision_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Vision_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_DoRef_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_DoRef_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.tpage_Position.ResumeLayout(false);
            this.ttPage_Settings.ResumeLayout(false);
            this.tpage_Options.ResumeLayout(false);
            this.tpage_Advance.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_X1Y1;
        private System.Windows.Forms.Button btn_GotoPt1Pos;
        private System.Windows.Forms.Button btn_SetPt1Pos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Grab;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Label lbl_VisionID;
        private System.Windows.Forms.ListBox lbox_Info;
        private System.Windows.Forms.Label lbllblAlignType;
        private System.Windows.Forms.Label lbl_AlignType;
        private System.Windows.Forms.Label lbl_CameraID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Align;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpage_Position;
        private System.Windows.Forms.TabPage tpage_Options;
        private System.Windows.Forms.Label lbl_SkipCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_FailAction;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage ttPage_Settings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_StartV;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl_Accel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl_DriveV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_SettleTime;
        private System.Windows.Forms.Panel pnl_Tools;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_FocusNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tpage_Advance;
        private System.Windows.Forms.Label lbl_SaveDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_GrabExec;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_AcceptTol;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btn_Cond;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_XYTol;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbllblInspectPrior;
        private System.Windows.Forms.Label lblInspPrior;
        private System.Windows.Forms.ComboBox cbSaveImages;
    }
}