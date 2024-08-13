namespace NDispWin
{
    partial class frmImageSelectBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageSelectBox));
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.imgboxEmgu = new Emgu.CV.UI.ImageBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbxImage = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnZM = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZF = new System.Windows.Forms.ToolStripButton();
            this.tsbtnZP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnThreshold = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbResetROI = new System.Windows.Forms.ToolStripButton();
            this.tscbxROI = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOK = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLearnImage = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMatchImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExecute = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnJog = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiLoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tbarThreshold = new System.Windows.Forms.TrackBar();
            this.pnlInstruction = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxEmgu)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarThreshold)).BeginInit();
            this.pnlInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.AutoSize = true;
            this.lbl_Instruction.Location = new System.Drawing.Point(3, 3);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(84, 14);
            this.lbl_Instruction.TabIndex = 4;
            this.lbl_Instruction.Text = "lbl_Instruction";
            // 
            // imgboxEmgu
            // 
            this.imgboxEmgu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgboxEmgu.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgboxEmgu.Location = new System.Drawing.Point(3, 61);
            this.imgboxEmgu.Name = "imgboxEmgu";
            this.imgboxEmgu.Size = new System.Drawing.Size(1036, 759);
            this.imgboxEmgu.TabIndex = 2;
            this.imgboxEmgu.TabStop = false;
            this.imgboxEmgu.SizeChanged += new System.EventHandler(this.imgboxEmgu_SizeChanged);
            this.imgboxEmgu.Paint += new System.Windows.Forms.PaintEventHandler(this.imgboxEmgu_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(3, 820);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1036, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbxImage,
            this.tsbtnUpdate,
            this.toolStripSeparator4,
            this.tsbtnZM,
            this.tsbtnZF,
            this.tsbtnZP,
            this.toolStripSeparator2,
            this.tsbtnThreshold,
            this.toolStripSeparator1,
            this.tsbResetROI,
            this.tscbxROI,
            this.toolStripSeparator3,
            this.tsbtnCancel,
            this.tsbtnOK,
            this.tsbtnLearnImage,
            this.tsbtnMatchImage,
            this.toolStripSeparator5,
            this.tsbtnExecute,
            this.tsbtnJog,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1036, 33);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 30);
            this.toolStripLabel1.Text = "Image";
            // 
            // tscbxImage
            // 
            this.tscbxImage.Name = "tscbxImage";
            this.tscbxImage.Size = new System.Drawing.Size(80, 33);
            this.tscbxImage.Text = "Registered";
            this.tscbxImage.SelectedIndexChanged += new System.EventHandler(this.tscbxImage_SelectedIndexChanged);
            // 
            // tsbtnUpdate
            // 
            this.tsbtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUpdate.Image")));
            this.tsbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpdate.Name = "tsbtnUpdate";
            this.tsbtnUpdate.Size = new System.Drawing.Size(49, 30);
            this.tsbtnUpdate.Text = "Update";
            this.tsbtnUpdate.Click += new System.EventHandler(this.tsbtnUpdate_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbtnZM
            // 
            this.tsbtnZM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnZM.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnZM.Image")));
            this.tsbtnZM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZM.Name = "tsbtnZM";
            this.tsbtnZM.Size = new System.Drawing.Size(23, 30);
            this.tsbtnZM.Text = "Z-";
            this.tsbtnZM.Click += new System.EventHandler(this.tsbtnZM_Click);
            // 
            // tsbtnZF
            // 
            this.tsbtnZF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnZF.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnZF.Image")));
            this.tsbtnZF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZF.Name = "tsbtnZF";
            this.tsbtnZF.Size = new System.Drawing.Size(24, 30);
            this.tsbtnZF.Text = "ZF";
            this.tsbtnZF.Click += new System.EventHandler(this.tsbtnZF_Click);
            // 
            // tsbtnZP
            // 
            this.tsbtnZP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnZP.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnZP.Image")));
            this.tsbtnZP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnZP.Name = "tsbtnZP";
            this.tsbtnZP.Size = new System.Drawing.Size(26, 30);
            this.tsbtnZP.Text = "Z+";
            this.tsbtnZP.Click += new System.EventHandler(this.tsbtnZP_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbtnThreshold
            // 
            this.tsbtnThreshold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnThreshold.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnThreshold.Image")));
            this.tsbtnThreshold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnThreshold.Name = "tsbtnThreshold";
            this.tsbtnThreshold.Size = new System.Drawing.Size(63, 30);
            this.tsbtnThreshold.Text = "Threshold";
            this.tsbtnThreshold.Click += new System.EventHandler(this.tsbtnThreshold_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbResetROI
            // 
            this.tsbResetROI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbResetROI.Image = ((System.Drawing.Image)(resources.GetObject("tsbResetROI.Image")));
            this.tsbResetROI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetROI.Name = "tsbResetROI";
            this.tsbResetROI.Size = new System.Drawing.Size(61, 30);
            this.tsbResetROI.Text = "Reset ROI";
            this.tsbResetROI.Click += new System.EventHandler(this.tsbResetROI_Click);
            // 
            // tscbxROI
            // 
            this.tscbxROI.Name = "tscbxROI";
            this.tscbxROI.Size = new System.Drawing.Size(75, 33);
            this.tscbxROI.Text = "Pattern";
            this.tscbxROI.SelectedIndexChanged += new System.EventHandler(this.tscbxROI_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbtnCancel
            // 
            this.tsbtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnCancel.AutoSize = false;
            this.tsbtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCancel.Image")));
            this.tsbtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCancel.Name = "tsbtnCancel";
            this.tsbtnCancel.Size = new System.Drawing.Size(60, 30);
            this.tsbtnCancel.Text = "Cancel";
            this.tsbtnCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tsbtnOK
            // 
            this.tsbtnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnOK.AutoSize = false;
            this.tsbtnOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnOK.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOK.Image")));
            this.tsbtnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOK.Name = "tsbtnOK";
            this.tsbtnOK.Size = new System.Drawing.Size(60, 30);
            this.tsbtnOK.Text = "OK";
            this.tsbtnOK.Click += new System.EventHandler(this.tsbOK_Click);
            // 
            // tsbtnLearnImage
            // 
            this.tsbtnLearnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLearnImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLearnImage.Image")));
            this.tsbtnLearnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLearnImage.Name = "tsbtnLearnImage";
            this.tsbtnLearnImage.Size = new System.Drawing.Size(40, 30);
            this.tsbtnLearnImage.Text = "Learn";
            this.tsbtnLearnImage.Click += new System.EventHandler(this.tsbtnLearnImage_Click);
            // 
            // tsbtnMatchImage
            // 
            this.tsbtnMatchImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnMatchImage.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMatchImage.Image")));
            this.tsbtnMatchImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMatchImage.Name = "tsbtnMatchImage";
            this.tsbtnMatchImage.Size = new System.Drawing.Size(45, 30);
            this.tsbtnMatchImage.Text = "Match";
            this.tsbtnMatchImage.Click += new System.EventHandler(this.tsbtnMatchImage_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
            // 
            // tsbtnExecute
            // 
            this.tsbtnExecute.Name = "tsbtnExecute";
            this.tsbtnExecute.Size = new System.Drawing.Size(48, 30);
            this.tsbtnExecute.Text = "Execute";
            this.tsbtnExecute.Click += new System.EventHandler(this.tsbtnExecute_Click);
            // 
            // tsbtnJog
            // 
            this.tsbtnJog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnJog.AutoSize = false;
            this.tsbtnJog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnJog.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnJog.Image")));
            this.tsbtnJog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnJog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnJog.Name = "tsbtnJog";
            this.tsbtnJog.Size = new System.Drawing.Size(50, 30);
            this.tsbtnJog.Text = "Jog";
            this.tsbtnJog.Click += new System.EventHandler(this.tsbtnJog_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadImage,
            this.tsmiSaveImage});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(53, 30);
            this.toolStripDropDownButton1.Text = "Image";
            // 
            // tsmiLoadImage
            // 
            this.tsmiLoadImage.Name = "tsmiLoadImage";
            this.tsmiLoadImage.Size = new System.Drawing.Size(136, 22);
            this.tsmiLoadImage.Text = "Load Image";
            this.tsmiLoadImage.Click += new System.EventHandler(this.tsmiLoadImage_Click);
            // 
            // tsmiSaveImage
            // 
            this.tsmiSaveImage.Name = "tsmiSaveImage";
            this.tsmiSaveImage.Size = new System.Drawing.Size(136, 22);
            this.tsmiSaveImage.Text = "Save Image";
            this.tsmiSaveImage.Visible = false;
            this.tsmiSaveImage.Click += new System.EventHandler(this.tsmiSaveImage_Click);
            // 
            // tbarThreshold
            // 
            this.tbarThreshold.AutoSize = false;
            this.tbarThreshold.BackColor = System.Drawing.SystemColors.Control;
            this.tbarThreshold.Location = new System.Drawing.Point(3, 61);
            this.tbarThreshold.Maximum = 255;
            this.tbarThreshold.Minimum = -1;
            this.tbarThreshold.Name = "tbarThreshold";
            this.tbarThreshold.Size = new System.Drawing.Size(323, 30);
            this.tbarThreshold.TabIndex = 7;
            this.tbarThreshold.TickFrequency = 50;
            this.tbarThreshold.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbarThreshold.Value = 127;
            this.tbarThreshold.Visible = false;
            this.tbarThreshold.Scroll += new System.EventHandler(this.tbarThreshold_Scroll);
            // 
            // pnlInstruction
            // 
            this.pnlInstruction.AutoSize = true;
            this.pnlInstruction.Controls.Add(this.lbl_Instruction);
            this.pnlInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInstruction.Location = new System.Drawing.Point(3, 36);
            this.pnlInstruction.MinimumSize = new System.Drawing.Size(0, 25);
            this.pnlInstruction.Name = "pnlInstruction";
            this.pnlInstruction.Size = new System.Drawing.Size(1036, 25);
            this.pnlInstruction.TabIndex = 10;
            // 
            // frmImageSelectBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1042, 845);
            this.ControlBox = false;
            this.Controls.Add(this.tbarThreshold);
            this.Controls.Add(this.imgboxEmgu);
            this.Controls.Add(this.pnlInstruction);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmImageSelectBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmImageSelectBox";
            this.Load += new System.EventHandler(this.frmVisionSelectBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgboxEmgu)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarThreshold)).EndInit();
            this.pnlInstruction.ResumeLayout(false);
            this.pnlInstruction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Instruction;
        private Emgu.CV.UI.ImageBox imgboxEmgu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnThreshold;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbResetROI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TrackBar tbarThreshold;
        private System.Windows.Forms.ToolStripButton tsbtnCancel;
        private System.Windows.Forms.ToolStripButton tsbtnOK;
        private System.Windows.Forms.Panel pnlInstruction;
        private System.Windows.Forms.ToolStripButton tsbtnMatchImage;
        private System.Windows.Forms.ToolStripComboBox tscbxImage;
        private System.Windows.Forms.ToolStripButton tsbtnLearnImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbxROI;
        private System.Windows.Forms.ToolStripButton tsbtnUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tsbtnExecute;
        private System.Windows.Forms.ToolStripButton tsbtnZM;
        private System.Windows.Forms.ToolStripButton tsbtnZF;
        private System.Windows.Forms.ToolStripButton tsbtnZP;
        private System.Windows.Forms.ToolStripButton tsbtnJog;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveImage;
    }
}