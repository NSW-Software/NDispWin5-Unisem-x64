namespace NDispWin
{
    partial class frm_DispCore_VisionSelectBox
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
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.pnl_Control = new System.Windows.Forms.Panel();
            this.btn_ResetROI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Threshold = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.pnl_Control.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbox_Image
            // 
            this.pbox_Image.Location = new System.Drawing.Point(90, 75);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(524, 302);
            this.pbox_Image.TabIndex = 0;
            this.pbox_Image.TabStop = false;
            this.pbox_Image.Paint += new System.Windows.Forms.PaintEventHandler(this.pbox_Image_Paint);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(764, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 30);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(845, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.AutoSize = true;
            this.lbl_Instruction.Location = new System.Drawing.Point(3, 11);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(84, 14);
            this.lbl_Instruction.TabIndex = 4;
            this.lbl_Instruction.Text = "lbl_Instruction";
            // 
            // pnl_Control
            // 
            this.pnl_Control.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Control.Controls.Add(this.btn_ResetROI);
            this.pnl_Control.Controls.Add(this.label1);
            this.pnl_Control.Controls.Add(this.lbl_Threshold);
            this.pnl_Control.Controls.Add(this.hScrollBar1);
            this.pnl_Control.Controls.Add(this.btn_Cancel);
            this.pnl_Control.Controls.Add(this.lbl_Instruction);
            this.pnl_Control.Controls.Add(this.btn_OK);
            this.pnl_Control.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Control.Location = new System.Drawing.Point(3, 3);
            this.pnl_Control.Name = "pnl_Control";
            this.pnl_Control.Size = new System.Drawing.Size(923, 66);
            this.pnl_Control.TabIndex = 5;
            // 
            // btn_ResetROI
            // 
            this.btn_ResetROI.Location = new System.Drawing.Point(259, 32);
            this.btn_ResetROI.Name = "btn_ResetROI";
            this.btn_ResetROI.Size = new System.Drawing.Size(78, 22);
            this.btn_ResetROI.TabIndex = 8;
            this.btn_ResetROI.Text = "Reset ROI";
            this.btn_ResetROI.UseVisualStyleBackColor = true;
            this.btn_ResetROI.Click += new System.EventHandler(this.btn_ResetROI_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Threshold";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Threshold";
            // 
            // lbl_Threshold
            // 
            this.lbl_Threshold.AutoSize = true;
            this.lbl_Threshold.Location = new System.Drawing.Point(87, 40);
            this.lbl_Threshold.Name = "lbl_Threshold";
            this.lbl_Threshold.Size = new System.Drawing.Size(38, 14);
            this.lbl_Threshold.TabIndex = 7;
            this.lbl_Threshold.Text = "label1";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(128, 32);
            this.hScrollBar1.Maximum = 255;
            this.hScrollBar1.Minimum = -1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(103, 22);
            this.hScrollBar1.TabIndex = 6;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbox_Image);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 563);
            this.panel1.TabIndex = 6;
            // 
            // frm_DispCore_VisionSelectBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(929, 635);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_Control);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frm_DispCore_VisionSelectBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmVisionSelectBox";
            this.Load += new System.EventHandler(this.frmVisionSelectBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.pnl_Control.ResumeLayout(false);
            this.pnl_Control.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_Image;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Panel pnl_Control;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label lbl_Threshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ResetROI;
    }
}