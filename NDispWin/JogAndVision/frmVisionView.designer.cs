namespace NDispWin
{
    partial class frmVisionView
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
            this.pnl_Menu2 = new System.Windows.Forms.Panel();
            this.btn_Reticle = new System.Windows.Forms.Button();
            this.btn_Menu2 = new System.Windows.Forms.Button();
            this.btn_Cam1 = new System.Windows.Forms.Button();
            this.btn_Cam2 = new System.Windows.Forms.Button();
            this.btn_Cam3 = new System.Windows.Forms.Button();
            this.pnl_Menu1 = new System.Windows.Forms.Panel();
            this.btn_LightingAdjust = new System.Windows.Forms.Button();
            this.lbl_Pos = new System.Windows.Forms.Label();
            this.btn_Menu1 = new System.Windows.Forms.Button();
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            this.pnl_Menu3 = new System.Windows.Forms.Panel();
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Live = new System.Windows.Forms.Button();
            this.btn_Grab = new System.Windows.Forms.Button();
            this.btn_Menu3 = new System.Windows.Forms.Button();
            this.pnl_Menu2.SuspendLayout();
            this.pnl_Menu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.pnl_Menu3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // pnl_Menu2
            // 
            this.pnl_Menu2.Controls.Add(this.btn_Reticle);
            this.pnl_Menu2.Controls.Add(this.btn_Menu2);
            this.pnl_Menu2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Menu2.Location = new System.Drawing.Point(3, 387);
            this.pnl_Menu2.Name = "pnl_Menu2";
            this.pnl_Menu2.Size = new System.Drawing.Size(515, 34);
            this.pnl_Menu2.TabIndex = 1;
            this.pnl_Menu2.Visible = false;
            // 
            // btn_Reticle
            // 
            this.btn_Reticle.AccessibleDescription = "Reticle";
            this.btn_Reticle.Location = new System.Drawing.Point(406, 3);
            this.btn_Reticle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Reticle.Name = "btn_Reticle";
            this.btn_Reticle.Size = new System.Drawing.Size(62, 30);
            this.btn_Reticle.TabIndex = 1;
            this.btn_Reticle.Text = "Reticle";
            this.btn_Reticle.UseVisualStyleBackColor = true;
            this.btn_Reticle.Click += new System.EventHandler(this.btn_ReticleSetup_Click);
            // 
            // btn_Menu2
            // 
            this.btn_Menu2.Location = new System.Drawing.Point(474, 3);
            this.btn_Menu2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Menu2.Name = "btn_Menu2";
            this.btn_Menu2.Size = new System.Drawing.Size(36, 30);
            this.btn_Menu2.TabIndex = 0;
            this.btn_Menu2.Text = "M2";
            this.btn_Menu2.UseVisualStyleBackColor = true;
            this.btn_Menu2.Click += new System.EventHandler(this.btn_Menu2_Click);
            // 
            // btn_Cam1
            // 
            this.btn_Cam1.AccessibleDescription = "Cam 1";
            this.btn_Cam1.Location = new System.Drawing.Point(150, 3);
            this.btn_Cam1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Cam1.Name = "btn_Cam1";
            this.btn_Cam1.Size = new System.Drawing.Size(50, 30);
            this.btn_Cam1.TabIndex = 3;
            this.btn_Cam1.Text = "Cam 1";
            this.btn_Cam1.UseVisualStyleBackColor = true;
            this.btn_Cam1.Click += new System.EventHandler(this.btn_Cam1_Click);
            // 
            // btn_Cam2
            // 
            this.btn_Cam2.AccessibleDescription = "Cam 2";
            this.btn_Cam2.Location = new System.Drawing.Point(206, 3);
            this.btn_Cam2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Cam2.Name = "btn_Cam2";
            this.btn_Cam2.Size = new System.Drawing.Size(50, 30);
            this.btn_Cam2.TabIndex = 4;
            this.btn_Cam2.Text = "Cam 2";
            this.btn_Cam2.UseVisualStyleBackColor = true;
            this.btn_Cam2.Click += new System.EventHandler(this.btn_Cam2_Click);
            // 
            // btn_Cam3
            // 
            this.btn_Cam3.AccessibleDescription = "Cam 3";
            this.btn_Cam3.Location = new System.Drawing.Point(262, 3);
            this.btn_Cam3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Cam3.Name = "btn_Cam3";
            this.btn_Cam3.Size = new System.Drawing.Size(50, 30);
            this.btn_Cam3.TabIndex = 5;
            this.btn_Cam3.Text = "Cam 3";
            this.btn_Cam3.UseVisualStyleBackColor = true;
            this.btn_Cam3.Click += new System.EventHandler(this.btn_Cam3_Click);
            // 
            // pnl_Menu1
            // 
            this.pnl_Menu1.Controls.Add(this.btn_Cam1);
            this.pnl_Menu1.Controls.Add(this.btn_LightingAdjust);
            this.pnl_Menu1.Controls.Add(this.btn_Cam2);
            this.pnl_Menu1.Controls.Add(this.btn_Cam3);
            this.pnl_Menu1.Controls.Add(this.lbl_Pos);
            this.pnl_Menu1.Controls.Add(this.btn_Menu1);
            this.pnl_Menu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Menu1.Location = new System.Drawing.Point(3, 455);
            this.pnl_Menu1.Name = "pnl_Menu1";
            this.pnl_Menu1.Size = new System.Drawing.Size(515, 34);
            this.pnl_Menu1.TabIndex = 0;
            // 
            // btn_LightingAdjust
            // 
            this.btn_LightingAdjust.Location = new System.Drawing.Point(318, 3);
            this.btn_LightingAdjust.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_LightingAdjust.Name = "btn_LightingAdjust";
            this.btn_LightingAdjust.Size = new System.Drawing.Size(150, 30);
            this.btn_LightingAdjust.TabIndex = 0;
            this.btn_LightingAdjust.Text = "LED [100,100,100,100]";
            this.btn_LightingAdjust.UseVisualStyleBackColor = true;
            this.btn_LightingAdjust.Click += new System.EventHandler(this.btn_LightingAdjust_Click);
            // 
            // lbl_Pos
            // 
            this.lbl_Pos.Location = new System.Drawing.Point(3, 3);
            this.lbl_Pos.Name = "lbl_Pos";
            this.lbl_Pos.Size = new System.Drawing.Size(100, 28);
            this.lbl_Pos.TabIndex = 2;
            this.lbl_Pos.Text = "lbl_Pos";
            this.lbl_Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Menu1
            // 
            this.btn_Menu1.Location = new System.Drawing.Point(474, 3);
            this.btn_Menu1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Menu1.Name = "btn_Menu1";
            this.btn_Menu1.Size = new System.Drawing.Size(36, 30);
            this.btn_Menu1.TabIndex = 1;
            this.btn_Menu1.Text = "M1";
            this.btn_Menu1.UseVisualStyleBackColor = true;
            this.btn_Menu1.Click += new System.EventHandler(this.btn_Menu1_Click);
            // 
            // pbox_Image
            // 
            this.pbox_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_Image.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbox_Image.InitialImage = null;
            this.pbox_Image.Location = new System.Drawing.Point(3, 3);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(515, 384);
            this.pbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_Image.TabIndex = 0;
            this.pbox_Image.TabStop = false;
            this.pbox_Image.MouseCaptureChanged += new System.EventHandler(this.pbox_Image_MouseCaptureChanged);
            this.pbox_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbox_Image_MouseDown);
            this.pbox_Image.MouseLeave += new System.EventHandler(this.pbox_Image_MouseLeave);
            this.pbox_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_Image_MouseMove);
            this.pbox_Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbox_Image_MouseUp);
            this.pbox_Image.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pbox_Image_PreviewKeyDown);
            // 
            // pnl_Menu3
            // 
            this.pnl_Menu3.Controls.Add(this.btn_Load);
            this.pnl_Menu3.Controls.Add(this.btn_Save);
            this.pnl_Menu3.Controls.Add(this.btn_Live);
            this.pnl_Menu3.Controls.Add(this.btn_Grab);
            this.pnl_Menu3.Controls.Add(this.btn_Menu3);
            this.pnl_Menu3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Menu3.Location = new System.Drawing.Point(3, 421);
            this.pnl_Menu3.Name = "pnl_Menu3";
            this.pnl_Menu3.Size = new System.Drawing.Size(515, 34);
            this.pnl_Menu3.TabIndex = 2;
            this.pnl_Menu3.Visible = false;
            // 
            // btn_Load
            // 
            this.btn_Load.AccessibleDescription = "Load";
            this.btn_Load.Location = new System.Drawing.Point(207, 3);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(62, 30);
            this.btn_Load.TabIndex = 4;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(275, 3);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(62, 30);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Live
            // 
            this.btn_Live.AccessibleDescription = "Live";
            this.btn_Live.Location = new System.Drawing.Point(3, 3);
            this.btn_Live.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Live.Name = "btn_Live";
            this.btn_Live.Size = new System.Drawing.Size(62, 30);
            this.btn_Live.TabIndex = 2;
            this.btn_Live.Text = "Live";
            this.btn_Live.UseVisualStyleBackColor = true;
            this.btn_Live.Click += new System.EventHandler(this.btn_Live_Click);
            // 
            // btn_Grab
            // 
            this.btn_Grab.AccessibleDescription = "Grab";
            this.btn_Grab.Location = new System.Drawing.Point(71, 3);
            this.btn_Grab.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Grab.Name = "btn_Grab";
            this.btn_Grab.Size = new System.Drawing.Size(62, 30);
            this.btn_Grab.TabIndex = 0;
            this.btn_Grab.Text = "Grab";
            this.btn_Grab.UseVisualStyleBackColor = true;
            this.btn_Grab.Click += new System.EventHandler(this.btn_Grab_Click);
            // 
            // btn_Menu3
            // 
            this.btn_Menu3.Location = new System.Drawing.Point(474, 3);
            this.btn_Menu3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btn_Menu3.Name = "btn_Menu3";
            this.btn_Menu3.Size = new System.Drawing.Size(36, 30);
            this.btn_Menu3.TabIndex = 1;
            this.btn_Menu3.Text = "M3";
            this.btn_Menu3.UseVisualStyleBackColor = true;
            this.btn_Menu3.Click += new System.EventHandler(this.btn_Menu3_Click);
            // 
            // frmVisionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(521, 495);
            this.Controls.Add(this.pnl_Menu1);
            this.Controls.Add(this.pnl_Menu3);
            this.Controls.Add(this.pnl_Menu2);
            this.Controls.Add(this.pbox_Image);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVisionView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmVisionView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisionView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVisionView_FormClosed);
            this.Load += new System.EventHandler(this.frmVisionView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVisionView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmVisionView_KeyUp);
            this.pnl_Menu2.ResumeLayout(false);
            this.pnl_Menu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.pnl_Menu3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox_Image;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Panel pnl_Menu2;
        private System.Windows.Forms.Panel pnl_Menu1;
        private System.Windows.Forms.Label lbl_Pos;
        private System.Windows.Forms.Button btn_Menu1;
        private System.Windows.Forms.Button btn_Menu2;
        private System.Windows.Forms.Button btn_Reticle;
        private System.Windows.Forms.Button btn_LightingAdjust;
        private System.Windows.Forms.Button btn_Cam1;
        private System.Windows.Forms.Button btn_Cam2;
        private System.Windows.Forms.Button btn_Cam3;
        private System.Windows.Forms.Panel pnl_Menu3;
        private System.Windows.Forms.Button btn_Grab;
        private System.Windows.Forms.Button btn_Menu3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Live;
        private System.Windows.Forms.Button btn_Load;
    }
}