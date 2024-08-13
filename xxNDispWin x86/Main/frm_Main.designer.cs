namespace NDispWin
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslSECSGEMConnect2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmr_EMO = new System.Windows.Forms.Timer(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblUser = new System.Windows.Forms.ToolStripLabel();
            this.tslblDateTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDevice = new System.Windows.Forms.ToolStripButton();
            this.tsbAuto = new System.Windows.Forms.ToolStripButton();
            this.tsbtnProgram = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSetup = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLogin = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMHS = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTable = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitElevators = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitConveyor = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitRight = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitGantry = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInitModule = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInit = new System.Windows.Forms.ToolStripButton();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.tmr_Status = new System.Windows.Forms.Timer(this.components);
            this.tmr_1s = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSECSGEMConnect2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 857);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 30);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tsslSECSGEMConnect2
            // 
            this.tsslSECSGEMConnect2.Name = "tsslSECSGEMConnect2";
            this.tsslSECSGEMConnect2.Size = new System.Drawing.Size(112, 25);
            this.tsslSECSGEMConnect2.Text = "SECSGEMConnect2";
            this.tsslSECSGEMConnect2.Visible = false;
            this.tsslSECSGEMConnect2.Click += new System.EventHandler(this.tsslSECSGEMConnect2_Click);
            // 
            // tmr_EMO
            // 
            this.tmr_EMO.Interval = 500;
            this.tmr_EMO.Tick += new System.EventHandler(this.tmr_EMO_Tick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(156, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 2;
            this.treeView1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1028, 887);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.lbl_Status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(878, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(150, 857);
            this.panel1.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tslblUser,
            this.tslblDateTime,
            this.toolStripSeparator2,
            this.tsbDevice,
            this.tsbAuto,
            this.tsbtnProgram,
            this.tsbtnSetup,
            this.tsbtnExit,
            this.tsbtnInfo,
            this.tsbtnLogin,
            this.tsbtnMHS,
            this.tsbtnTable,
            this.tsbtnSettings,
            this.tsbtnOptions,
            this.tsbtnInitRight,
            this.tsbtnInitLeft,
            this.tsbtnInitElevators,
            this.tsbtnInitConveyor,
            this.tsbtnInitGantry,
            this.tsbtnInitModule,
            this.tsbtnInit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(144, 828);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // tslblUser
            // 
            this.tslblUser.Name = "tslblUser";
            this.tslblUser.Size = new System.Drawing.Size(142, 14);
            this.tslblUser.Text = "[User]";
            // 
            // tslblDateTime
            // 
            this.tslblDateTime.Name = "tslblDateTime";
            this.tslblDateTime.Size = new System.Drawing.Size(142, 14);
            this.tslblDateTime.Text = "DateTime";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // tsbDevice
            // 
            this.tsbDevice.Image = ((System.Drawing.Image)(resources.GetObject("tsbDevice.Image")));
            this.tsbDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbDevice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDevice.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbDevice.Name = "tsbDevice";
            this.tsbDevice.Size = new System.Drawing.Size(142, 34);
            this.tsbDevice.Text = "Device";
            this.tsbDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbDevice.Click += new System.EventHandler(this.tsbDevice_Click);
            // 
            // tsbAuto
            // 
            this.tsbAuto.AccessibleDescription = "Auto";
            this.tsbAuto.Image = ((System.Drawing.Image)(resources.GetObject("tsbAuto.Image")));
            this.tsbAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbAuto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAuto.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbAuto.Name = "tsbAuto";
            this.tsbAuto.Size = new System.Drawing.Size(142, 34);
            this.tsbAuto.Text = "Auto";
            this.tsbAuto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbAuto.Click += new System.EventHandler(this.tsbtnAuto_Click);
            // 
            // tsbtnProgram
            // 
            this.tsbtnProgram.AccessibleDescription = "Program";
            this.tsbtnProgram.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnProgram.Image")));
            this.tsbtnProgram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnProgram.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnProgram.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnProgram.Name = "tsbtnProgram";
            this.tsbtnProgram.Size = new System.Drawing.Size(142, 34);
            this.tsbtnProgram.Text = "Program";
            this.tsbtnProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnProgram.Click += new System.EventHandler(this.tsbtnProgram_Click);
            // 
            // tsbtnSetup
            // 
            this.tsbtnSetup.AutoSize = false;
            this.tsbtnSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSetup.Image")));
            this.tsbtnSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSetup.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnSetup.Name = "tsbtnSetup";
            this.tsbtnSetup.Size = new System.Drawing.Size(142, 34);
            this.tsbtnSetup.Text = "Dispense Setup";
            this.tsbtnSetup.Click += new System.EventHandler(this.tsbtnSetup_Click);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.AccessibleDescription = "Exit";
            this.tsbtnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(142, 34);
            this.tsbtnExit.Text = "Exit";
            this.tsbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // tsbtnInfo
            // 
            this.tsbtnInfo.AccessibleDescription = "Info";
            this.tsbtnInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInfo.Image")));
            this.tsbtnInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInfo.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInfo.Name = "tsbtnInfo";
            this.tsbtnInfo.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInfo.Text = "Info";
            this.tsbtnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInfo.Click += new System.EventHandler(this.tsbtnInfo_Click);
            // 
            // tsbtnLogin
            // 
            this.tsbtnLogin.AccessibleDescription = "Login";
            this.tsbtnLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogin.Image")));
            this.tsbtnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnLogin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnLogin.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnLogin.Name = "tsbtnLogin";
            this.tsbtnLogin.Size = new System.Drawing.Size(142, 34);
            this.tsbtnLogin.Text = "Login";
            this.tsbtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnLogin.Click += new System.EventHandler(this.tsbtnLogin_Click);
            // 
            // tsbtnMHS
            // 
            this.tsbtnMHS.AccessibleDescription = "MHS";
            this.tsbtnMHS.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMHS.Image")));
            this.tsbtnMHS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnMHS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnMHS.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnMHS.Name = "tsbtnMHS";
            this.tsbtnMHS.Size = new System.Drawing.Size(142, 34);
            this.tsbtnMHS.Text = "MHS";
            this.tsbtnMHS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnMHS.Click += new System.EventHandler(this.tsbtnMHS_Click);
            // 
            // tsbtnTable
            // 
            this.tsbtnTable.AccessibleDescription = "Table";
            this.tsbtnTable.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTable.Image")));
            this.tsbtnTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnTable.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnTable.Name = "tsbtnTable";
            this.tsbtnTable.Size = new System.Drawing.Size(142, 34);
            this.tsbtnTable.Text = "Table";
            this.tsbtnTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnTable.Click += new System.EventHandler(this.tsbtnTable_Click);
            // 
            // tsbtnSettings
            // 
            this.tsbtnSettings.AutoSize = false;
            this.tsbtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSettings.Image")));
            this.tsbtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSettings.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnSettings.Name = "tsbtnSettings";
            this.tsbtnSettings.Size = new System.Drawing.Size(142, 34);
            this.tsbtnSettings.Text = "Settings";
            this.tsbtnSettings.Click += new System.EventHandler(this.tsbtnSettings_Click);
            // 
            // tsbtnOptions
            // 
            this.tsbtnOptions.AccessibleDescription = "Options";
            this.tsbtnOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOptions.Image")));
            this.tsbtnOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnOptions.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnOptions.Name = "tsbtnOptions";
            this.tsbtnOptions.Size = new System.Drawing.Size(142, 34);
            this.tsbtnOptions.Text = "Options";
            this.tsbtnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnOptions.Click += new System.EventHandler(this.tsbtnOptions_Click);
            // 
            // tsbtnInitElevators
            // 
            this.tsbtnInitElevators.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitElevators.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitElevators.Image")));
            this.tsbtnInitElevators.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitElevators.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitElevators.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInitElevators.Name = "tsbtnInitElevators";
            this.tsbtnInitElevators.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitElevators.Text = "  Init Elevators";
            this.tsbtnInitElevators.Visible = false;
            this.tsbtnInitElevators.Click += new System.EventHandler(this.tsbtnInitElevators_Click);
            // 
            // tsbtnInitConveyor
            // 
            this.tsbtnInitConveyor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitConveyor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitConveyor.Image")));
            this.tsbtnInitConveyor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitConveyor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitConveyor.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInitConveyor.Name = "tsbtnInitConveyor";
            this.tsbtnInitConveyor.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitConveyor.Text = "  Init Conveyor";
            this.tsbtnInitConveyor.Visible = false;
            this.tsbtnInitConveyor.Click += new System.EventHandler(this.tsbtnInitConveyor_Click);
            // 
            // tsbtnInitLeft
            // 
            this.tsbtnInitLeft.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitLeft.Image")));
            this.tsbtnInitLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInitLeft.Name = "tsbtnInitLeft";
            this.tsbtnInitLeft.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitLeft.Text = "  Init Left Elev";
            this.tsbtnInitLeft.Visible = false;
            this.tsbtnInitLeft.Click += new System.EventHandler(this.tsbtnInitLeft_Click);
            // 
            // tsbtnInitRight
            // 
            this.tsbtnInitRight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitRight.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitRight.Image")));
            this.tsbtnInitRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInitRight.Name = "tsbtnInitRight";
            this.tsbtnInitRight.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitRight.Text = "  Init Right Elev";
            this.tsbtnInitRight.Visible = false;
            this.tsbtnInitRight.Click += new System.EventHandler(this.tsbtnInitRight_Click);
            // 
            // tsbtnInitGantry
            // 
            this.tsbtnInitGantry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitGantry.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitGantry.Image")));
            this.tsbtnInitGantry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitGantry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitGantry.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInitGantry.Name = "tsbtnInitGantry";
            this.tsbtnInitGantry.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitGantry.Text = "  Init Gantry";
            this.tsbtnInitGantry.Visible = false;
            this.tsbtnInitGantry.Click += new System.EventHandler(this.tsbtnInitGantry_Click);
            // 
            // tsbtnInitModule
            // 
            this.tsbtnInitModule.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInitModule.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInitModule.Image")));
            this.tsbtnInitModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInitModule.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInitModule.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInitModule.Name = "tsbtnInitModule";
            this.tsbtnInitModule.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInitModule.Text = "Init Module";
            this.tsbtnInitModule.Click += new System.EventHandler(this.tsbtnInitModule_Click);
            // 
            // tsbtnInit
            // 
            this.tsbtnInit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInit.Image")));
            this.tsbtnInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbtnInit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnInit.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnInit.Name = "tsbtnInit";
            this.tsbtnInit.Size = new System.Drawing.Size(142, 34);
            this.tsbtnInit.Text = "Init All";
            this.tsbtnInit.Click += new System.EventHandler(this.tsbtnInit_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Status.Location = new System.Drawing.Point(3, 3);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(144, 23);
            this.lbl_Status.TabIndex = 7;
            this.lbl_Status.Text = "lbl_Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmr_Status
            // 
            this.tmr_Status.Enabled = true;
            this.tmr_Status.Interval = 500;
            this.tmr_Status.Tick += new System.EventHandler(this.tmr_Status_Tick);
            // 
            // tmr_1s
            // 
            this.tmr_1s.Enabled = true;
            this.tmr_1s.Interval = 1000;
            this.tmr_1s.Tick += new System.EventHandler(this.tmr_1s_Tick);
            // 
            // frm_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1028, 887);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frm_Main";
            this.Text = "frm_Main2";
            this.Activated += new System.EventHandler(this.frm_Main2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_Main2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer tmr_EMO;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Timer tmr_Status;
        private System.Windows.Forms.Timer tmr_1s;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslblUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAuto;
        private System.Windows.Forms.ToolStripButton tsbtnProgram;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.ToolStripButton tsbtnInfo;
        private System.Windows.Forms.ToolStripButton tsbtnLogin;
        private System.Windows.Forms.ToolStripButton tsbtnMHS;
        private System.Windows.Forms.ToolStripButton tsbDevice;
        private System.Windows.Forms.ToolStripButton tsbtnTable;
        private System.Windows.Forms.ToolStripButton tsbtnOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSECSGEMConnect2;
        private System.Windows.Forms.ToolStripButton tsbtnSetup;
        private System.Windows.Forms.ToolStripButton tsbtnSettings;
        private System.Windows.Forms.ToolStripButton tsbtnInit;
        private System.Windows.Forms.ToolStripButton tsbtnInitModule;
        private System.Windows.Forms.ToolStripButton tsbtnInitElevators;
        private System.Windows.Forms.ToolStripButton tsbtnInitConveyor;
        private System.Windows.Forms.ToolStripButton tsbtnInitGantry;
        private System.Windows.Forms.ToolStripLabel tslblDateTime;
        private System.Windows.Forms.ToolStripButton tsbtnInitLeft;
        private System.Windows.Forms.ToolStripButton tsbtnInitRight;
    }
}