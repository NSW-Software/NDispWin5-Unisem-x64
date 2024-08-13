namespace NDispWin
{
    partial class frmCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCamera));
            this.imgBoxEmgu = new Emgu.CV.UI.ImageBox();
            this.pnl_Image = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Cam1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Cam2 = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Cam3 = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Cam4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Capture = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Grab = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ZoomFit = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddb_Image = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddb_Tools = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_SetupReticle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ShowStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.showCamReticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_TriggerSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTriggerNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSoftwareTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHardwareTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.ss_Bottom = new System.Windows.Forms.StatusStrip();
            this.tssl_Pos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_FPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxEmgu)).BeginInit();
            this.pnl_Image.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ss_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBoxEmgu
            // 
            this.imgBoxEmgu.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBoxEmgu.Location = new System.Drawing.Point(53, 39);
            this.imgBoxEmgu.Name = "imgBoxEmgu";
            this.imgBoxEmgu.Size = new System.Drawing.Size(344, 162);
            this.imgBoxEmgu.TabIndex = 2;
            this.imgBoxEmgu.TabStop = false;
            this.imgBoxEmgu.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBoxEmgu_Paint);
            this.imgBoxEmgu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBoxEmgu_MouseDown);
            this.imgBoxEmgu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBoxEmgu_MouseMove);
            this.imgBoxEmgu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBoxEmgu_MouseUp);
            this.imgBoxEmgu.Move += new System.EventHandler(this.imgBoxEmgu_Move);
            this.imgBoxEmgu.Validating += new System.ComponentModel.CancelEventHandler(this.imgBoxEmgu_Validating);
            this.imgBoxEmgu.Validated += new System.EventHandler(this.imgBoxEmgu_Validated);
            // 
            // pnl_Image
            // 
            this.pnl_Image.AutoScroll = true;
            this.pnl_Image.Controls.Add(this.imgBoxEmgu);
            this.pnl_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Image.Location = new System.Drawing.Point(0, 25);
            this.pnl_Image.Name = "pnl_Image";
            this.pnl_Image.Size = new System.Drawing.Size(644, 356);
            this.pnl_Image.TabIndex = 3;
            this.pnl_Image.Resize += new System.EventHandler(this.pnl_Image_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Cam1,
            this.tsbtn_Cam2,
            this.tsbtn_Cam3,
            this.tsbtn_Cam4,
            this.toolStripSeparator1,
            this.tsbtn_Capture,
            this.tsbtn_Grab,
            this.tsbtn_Stop,
            this.toolStripSeparator2,
            this.tsbtn_ZoomOut,
            this.tsbtn_ZoomFit,
            this.tsbtn_ZoomIn,
            this.toolStripSeparator3,
            this.tsddb_Image,
            this.tsddb_Tools});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(644, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Cam1
            // 
            this.tsbtn_Cam1.AutoSize = false;
            this.tsbtn_Cam1.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtn_Cam1.Checked = true;
            this.tsbtn_Cam1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtn_Cam1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Cam1.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cam1.Image")));
            this.tsbtn_Cam1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Cam1.Name = "tsbtn_Cam1";
            this.tsbtn_Cam1.Size = new System.Drawing.Size(30, 22);
            this.tsbtn_Cam1.Text = "1";
            this.tsbtn_Cam1.Click += new System.EventHandler(this.tsbtn_Cam1_Click);
            // 
            // tsbtn_Cam2
            // 
            this.tsbtn_Cam2.AutoSize = false;
            this.tsbtn_Cam2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Cam2.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cam2.Image")));
            this.tsbtn_Cam2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Cam2.Name = "tsbtn_Cam2";
            this.tsbtn_Cam2.Size = new System.Drawing.Size(30, 22);
            this.tsbtn_Cam2.Text = "2";
            this.tsbtn_Cam2.Click += new System.EventHandler(this.tsbtn_Cam2_Click);
            // 
            // tsbtn_Cam3
            // 
            this.tsbtn_Cam3.AutoSize = false;
            this.tsbtn_Cam3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Cam3.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cam3.Image")));
            this.tsbtn_Cam3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Cam3.Name = "tsbtn_Cam3";
            this.tsbtn_Cam3.Size = new System.Drawing.Size(30, 22);
            this.tsbtn_Cam3.Text = "3";
            this.tsbtn_Cam3.Click += new System.EventHandler(this.tsbtn_Cam3_Click);
            // 
            // tsbtn_Cam4
            // 
            this.tsbtn_Cam4.AutoSize = false;
            this.tsbtn_Cam4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Cam4.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cam4.Image")));
            this.tsbtn_Cam4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Cam4.Name = "tsbtn_Cam4";
            this.tsbtn_Cam4.Size = new System.Drawing.Size(30, 22);
            this.tsbtn_Cam4.Text = "4";
            this.tsbtn_Cam4.Click += new System.EventHandler(this.tsbtn_Cam4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_Capture
            // 
            this.tsbtn_Capture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Capture.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Capture.Image")));
            this.tsbtn_Capture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Capture.Name = "tsbtn_Capture";
            this.tsbtn_Capture.Size = new System.Drawing.Size(53, 22);
            this.tsbtn_Capture.Text = "&Capture";
            this.tsbtn_Capture.Click += new System.EventHandler(this.tsbtn_Capture_Click);
            // 
            // tsbtn_Grab
            // 
            this.tsbtn_Grab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Grab.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Grab.Image")));
            this.tsbtn_Grab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Grab.Name = "tsbtn_Grab";
            this.tsbtn_Grab.Size = new System.Drawing.Size(36, 22);
            this.tsbtn_Grab.Text = "&Grab";
            this.tsbtn_Grab.Click += new System.EventHandler(this.tsbtn_Grab_Click);
            // 
            // tsbtn_Stop
            // 
            this.tsbtn_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_Stop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Stop.Image")));
            this.tsbtn_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Stop.Name = "tsbtn_Stop";
            this.tsbtn_Stop.Size = new System.Drawing.Size(35, 22);
            this.tsbtn_Stop.Text = "&Stop";
            this.tsbtn_Stop.Click += new System.EventHandler(this.tsbtn_Stop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtn_ZoomOut
            // 
            this.tsbtn_ZoomOut.AutoSize = false;
            this.tsbtn_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ZoomOut.Image")));
            this.tsbtn_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ZoomOut.Name = "tsbtn_ZoomOut";
            this.tsbtn_ZoomOut.Size = new System.Drawing.Size(40, 22);
            this.tsbtn_ZoomOut.Text = "Z-";
            this.tsbtn_ZoomOut.Click += new System.EventHandler(this.tsbtn_ZoomOut_Click);
            // 
            // tsbtn_ZoomFit
            // 
            this.tsbtn_ZoomFit.AutoSize = false;
            this.tsbtn_ZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_ZoomFit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ZoomFit.Image")));
            this.tsbtn_ZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ZoomFit.Name = "tsbtn_ZoomFit";
            this.tsbtn_ZoomFit.Size = new System.Drawing.Size(40, 22);
            this.tsbtn_ZoomFit.Text = "ZF";
            this.tsbtn_ZoomFit.Click += new System.EventHandler(this.tsbtn_ZoomFit_Click);
            // 
            // tsbtn_ZoomIn
            // 
            this.tsbtn_ZoomIn.AutoSize = false;
            this.tsbtn_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtn_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ZoomIn.Image")));
            this.tsbtn_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ZoomIn.Name = "tsbtn_ZoomIn";
            this.tsbtn_ZoomIn.Size = new System.Drawing.Size(40, 22);
            this.tsbtn_ZoomIn.Text = "Z+";
            this.tsbtn_ZoomIn.Click += new System.EventHandler(this.tsbtn_ZoomIn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsddb_Image
            // 
            this.tsddb_Image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_Image.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.tsddb_Image.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_Image.Image")));
            this.tsddb_Image.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_Image.Name = "tsddb_Image";
            this.tsddb_Image.Size = new System.Drawing.Size(53, 22);
            this.tsddb_Image.Text = "Image";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tsddb_Tools
            // 
            this.tsddb_Tools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SetupReticle,
            this.tsmi_ShowStatusBar,
            this.showCamReticlesToolStripMenuItem,
            this.toolStripSeparator4,
            this.tsmi_TriggerSource,
            this.tsmiTrigger});
            this.tsddb_Tools.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_Tools.Image")));
            this.tsddb_Tools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_Tools.Name = "tsddb_Tools";
            this.tsddb_Tools.Size = new System.Drawing.Size(47, 22);
            this.tsddb_Tools.Text = "Tools";
            // 
            // tsmi_SetupReticle
            // 
            this.tsmi_SetupReticle.Name = "tsmi_SetupReticle";
            this.tsmi_SetupReticle.Size = new System.Drawing.Size(171, 22);
            this.tsmi_SetupReticle.Text = "Setup Reticle";
            this.tsmi_SetupReticle.Click += new System.EventHandler(this.setupReticleToolStripMenuItem_Click);
            // 
            // tsmi_ShowStatusBar
            // 
            this.tsmi_ShowStatusBar.Name = "tsmi_ShowStatusBar";
            this.tsmi_ShowStatusBar.Size = new System.Drawing.Size(171, 22);
            this.tsmi_ShowStatusBar.Text = "Status Bar";
            this.tsmi_ShowStatusBar.Click += new System.EventHandler(this.statusBarToolStripMenuItem_Click);
            // 
            // showCamReticlesToolStripMenuItem
            // 
            this.showCamReticlesToolStripMenuItem.Name = "showCamReticlesToolStripMenuItem";
            this.showCamReticlesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showCamReticlesToolStripMenuItem.Text = "Show CamReticles";
            this.showCamReticlesToolStripMenuItem.Click += new System.EventHandler(this.showCamReticlesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_TriggerSource
            // 
            this.tsmi_TriggerSource.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTriggerNone,
            this.tsmiSoftwareTrigger,
            this.tsmiHardwareTrigger});
            this.tsmi_TriggerSource.Name = "tsmi_TriggerSource";
            this.tsmi_TriggerSource.Size = new System.Drawing.Size(171, 22);
            this.tsmi_TriggerSource.Text = "Trigger Source";
            // 
            // tsmiTriggerNone
            // 
            this.tsmiTriggerNone.Name = "tsmiTriggerNone";
            this.tsmiTriggerNone.Size = new System.Drawing.Size(164, 22);
            this.tsmiTriggerNone.Text = "None";
            this.tsmiTriggerNone.Click += new System.EventHandler(this.tsmiTriggerNone_Click);
            // 
            // tsmiSoftwareTrigger
            // 
            this.tsmiSoftwareTrigger.Name = "tsmiSoftwareTrigger";
            this.tsmiSoftwareTrigger.Size = new System.Drawing.Size(164, 22);
            this.tsmiSoftwareTrigger.Text = "Software Trigger";
            this.tsmiSoftwareTrigger.Click += new System.EventHandler(this.tsmiSoftwareTrigger_Click);
            // 
            // tsmiHardwareTrigger
            // 
            this.tsmiHardwareTrigger.Name = "tsmiHardwareTrigger";
            this.tsmiHardwareTrigger.Size = new System.Drawing.Size(164, 22);
            this.tsmiHardwareTrigger.Text = "Hardware Trigger";
            this.tsmiHardwareTrigger.Click += new System.EventHandler(this.tsmiHardwareTrigger_Click);
            // 
            // tsmiTrigger
            // 
            this.tsmiTrigger.Name = "tsmiTrigger";
            this.tsmiTrigger.Size = new System.Drawing.Size(171, 22);
            this.tsmiTrigger.Text = "Trigger";
            this.tsmiTrigger.Click += new System.EventHandler(this.tsmiTrigger_Click);
            // 
            // ss_Bottom
            // 
            this.ss_Bottom.AutoSize = false;
            this.ss_Bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Pos,
            this.toolStripStatusLabel1,
            this.tssl_FPS,
            this.toolStripStatusLabel2,
            this.tssl_Status});
            this.ss_Bottom.Location = new System.Drawing.Point(0, 330);
            this.ss_Bottom.Name = "ss_Bottom";
            this.ss_Bottom.Size = new System.Drawing.Size(557, 22);
            this.ss_Bottom.TabIndex = 5;
            this.ss_Bottom.Text = "statusStrip1";
            this.ss_Bottom.Visible = false;
            // 
            // tssl_Pos
            // 
            this.tssl_Pos.Name = "tssl_Pos";
            this.tssl_Pos.Size = new System.Drawing.Size(22, 17);
            this.tssl_Pos.Text = "0,0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssl_FPS
            // 
            this.tssl_FPS.Name = "tssl_FPS";
            this.tssl_FPS.Size = new System.Drawing.Size(26, 17);
            this.tssl_FPS.Text = "FPS";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tssl_Status
            // 
            this.tssl_Status.Name = "tssl_Status";
            this.tssl_Status.Size = new System.Drawing.Size(39, 17);
            this.tssl_Status.Text = "Status";
            // 
            // frmCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(644, 381);
            this.Controls.Add(this.pnl_Image);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ss_Bottom);
            this.Name = "frmCamera";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCamera_FormClosing);
            this.Load += new System.EventHandler(this.frmCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxEmgu)).EndInit();
            this.pnl_Image.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ss_Bottom.ResumeLayout(false);
            this.ss_Bottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imgBoxEmgu;
        private System.Windows.Forms.Panel pnl_Image;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Cam1;
        private System.Windows.Forms.ToolStripButton tsbtn_Cam2;
        private System.Windows.Forms.ToolStripButton tsbtn_Cam3;
        private System.Windows.Forms.ToolStripButton tsbtn_Cam4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtn_Capture;
        private System.Windows.Forms.ToolStripButton tsbtn_Grab;
        private System.Windows.Forms.ToolStripButton tsbtn_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtn_ZoomOut;
        private System.Windows.Forms.ToolStripButton tsbtn_ZoomFit;
        private System.Windows.Forms.ToolStripButton tsbtn_ZoomIn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_Image;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_Tools;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SetupReticle;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ShowStatusBar;
        private System.Windows.Forms.StatusStrip ss_Bottom;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Pos;
        private System.Windows.Forms.ToolStripMenuItem showCamReticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Status;
        private System.Windows.Forms.ToolStripMenuItem tsmi_TriggerSource;
        private System.Windows.Forms.ToolStripMenuItem tsmiSoftwareTrigger;
        private System.Windows.Forms.ToolStripMenuItem tsmiHardwareTrigger;
        private System.Windows.Forms.ToolStripMenuItem tsmiTrigger;
        private System.Windows.Forms.ToolStripStatusLabel tssl_FPS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiTriggerNone;
    }
}