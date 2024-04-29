namespace NDispWin
{
    partial class frm_TeachNeedle_LaserCrosshair
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_End = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Complete = new System.Windows.Forms.Button();
            this.pnl_MoveH2N1 = new System.Windows.Forms.Panel();
            this.btn_MoveH2N1Next = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.pnl_MoveH1N1 = new System.Windows.Forms.Panel();
            this.btn_MoveH1N1Next = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.pnl_MoveCamera = new System.Windows.Forms.Panel();
            this.btn_MoveCameraNext = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.pnl_MoveLaser = new System.Windows.Forms.Panel();
            this.lbl_LaserValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_MoveLaserNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Start = new System.Windows.Forms.Panel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tmr_Laser = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.pnl_End.SuspendLayout();
            this.pnl_MoveH2N1.SuspendLayout();
            this.pnl_MoveH1N1.SuspendLayout();
            this.pnl_MoveCamera.SuspendLayout();
            this.pnl_MoveLaser.SuspendLayout();
            this.pnl_Start.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnl_End);
            this.panel1.Controls.Add(this.pnl_MoveH2N1);
            this.panel1.Controls.Add(this.pnl_MoveH1N1);
            this.panel1.Controls.Add(this.pnl_MoveCamera);
            this.panel1.Controls.Add(this.pnl_MoveLaser);
            this.panel1.Controls.Add(this.pnl_Start);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 732);
            this.panel1.TabIndex = 15;
            // 
            // pnl_End
            // 
            this.pnl_End.AutoSize = true;
            this.pnl_End.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_End.Controls.Add(this.btn_Cancel);
            this.pnl_End.Controls.Add(this.btn_Complete);
            this.pnl_End.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_End.Location = new System.Drawing.Point(0, 260);
            this.pnl_End.Name = "pnl_End";
            this.pnl_End.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_End.Size = new System.Drawing.Size(490, 52);
            this.pnl_End.TabIndex = 21;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(328, 6);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 40);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Complete
            // 
            this.btn_Complete.AccessibleDescription = "Complete";
            this.btn_Complete.Location = new System.Drawing.Point(409, 6);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(75, 40);
            this.btn_Complete.TabIndex = 16;
            this.btn_Complete.Text = "Complete";
            this.btn_Complete.UseVisualStyleBackColor = true;
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // pnl_MoveH2N1
            // 
            this.pnl_MoveH2N1.AutoSize = true;
            this.pnl_MoveH2N1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_MoveH2N1.Controls.Add(this.btn_MoveH2N1Next);
            this.pnl_MoveH2N1.Controls.Add(this.label25);
            this.pnl_MoveH2N1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MoveH2N1.Location = new System.Drawing.Point(0, 208);
            this.pnl_MoveH2N1.Name = "pnl_MoveH2N1";
            this.pnl_MoveH2N1.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_MoveH2N1.Size = new System.Drawing.Size(490, 52);
            this.pnl_MoveH2N1.TabIndex = 20;
            // 
            // btn_MoveH2N1Next
            // 
            this.btn_MoveH2N1Next.AccessibleDescription = "Next";
            this.btn_MoveH2N1Next.Location = new System.Drawing.Point(409, 6);
            this.btn_MoveH2N1Next.Name = "btn_MoveH2N1Next";
            this.btn_MoveH2N1Next.Size = new System.Drawing.Size(75, 40);
            this.btn_MoveH2N1Next.TabIndex = 1;
            this.btn_MoveH2N1Next.Text = "Next";
            this.btn_MoveH2N1Next.UseVisualStyleBackColor = true;
            this.btn_MoveH2N1Next.Click += new System.EventHandler(this.btn_MoveH2N1Next_Click);
            // 
            // label25
            // 
            this.label25.AccessibleDescription = "Adjust Head 2 Needle 1 to Ref Center";
            this.label25.Location = new System.Drawing.Point(6, 6);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(395, 23);
            this.label25.TabIndex = 1;
            this.label25.Text = "Adjust Head 2 Needle 1 to Ref Center";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_MoveH1N1
            // 
            this.pnl_MoveH1N1.AutoSize = true;
            this.pnl_MoveH1N1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_MoveH1N1.Controls.Add(this.btn_MoveH1N1Next);
            this.pnl_MoveH1N1.Controls.Add(this.label26);
            this.pnl_MoveH1N1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MoveH1N1.Location = new System.Drawing.Point(0, 156);
            this.pnl_MoveH1N1.Name = "pnl_MoveH1N1";
            this.pnl_MoveH1N1.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_MoveH1N1.Size = new System.Drawing.Size(490, 52);
            this.pnl_MoveH1N1.TabIndex = 19;
            // 
            // btn_MoveH1N1Next
            // 
            this.btn_MoveH1N1Next.AccessibleDescription = "Next";
            this.btn_MoveH1N1Next.Location = new System.Drawing.Point(409, 6);
            this.btn_MoveH1N1Next.Name = "btn_MoveH1N1Next";
            this.btn_MoveH1N1Next.Size = new System.Drawing.Size(75, 40);
            this.btn_MoveH1N1Next.TabIndex = 1;
            this.btn_MoveH1N1Next.Text = "Next";
            this.btn_MoveH1N1Next.UseVisualStyleBackColor = true;
            this.btn_MoveH1N1Next.Click += new System.EventHandler(this.btn_MoveH1N1Next_Click);
            // 
            // label26
            // 
            this.label26.AccessibleDescription = "Move Head 1 Needle 1 to Ref Center";
            this.label26.Location = new System.Drawing.Point(6, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(395, 23);
            this.label26.TabIndex = 1;
            this.label26.Text = "Move Head 1 Needle 1 to Ref Center";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_MoveCamera
            // 
            this.pnl_MoveCamera.AutoSize = true;
            this.pnl_MoveCamera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_MoveCamera.Controls.Add(this.btn_MoveCameraNext);
            this.pnl_MoveCamera.Controls.Add(this.label24);
            this.pnl_MoveCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MoveCamera.Location = new System.Drawing.Point(0, 104);
            this.pnl_MoveCamera.Name = "pnl_MoveCamera";
            this.pnl_MoveCamera.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_MoveCamera.Size = new System.Drawing.Size(490, 52);
            this.pnl_MoveCamera.TabIndex = 18;
            // 
            // btn_MoveCameraNext
            // 
            this.btn_MoveCameraNext.AccessibleDescription = "Next";
            this.btn_MoveCameraNext.Location = new System.Drawing.Point(409, 6);
            this.btn_MoveCameraNext.Name = "btn_MoveCameraNext";
            this.btn_MoveCameraNext.Size = new System.Drawing.Size(75, 40);
            this.btn_MoveCameraNext.TabIndex = 1;
            this.btn_MoveCameraNext.Text = "Next";
            this.btn_MoveCameraNext.UseVisualStyleBackColor = true;
            this.btn_MoveCameraNext.Click += new System.EventHandler(this.btn_MoveCameraNext_Click);
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Move Main Camera to Ref Center Pos";
            this.label24.Location = new System.Drawing.Point(6, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(395, 23);
            this.label24.TabIndex = 1;
            this.label24.Text = "Move Main Camera to Ref Center Pos";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_MoveLaser
            // 
            this.pnl_MoveLaser.AutoSize = true;
            this.pnl_MoveLaser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_MoveLaser.Controls.Add(this.lbl_LaserValue);
            this.pnl_MoveLaser.Controls.Add(this.label2);
            this.pnl_MoveLaser.Controls.Add(this.btn_MoveLaserNext);
            this.pnl_MoveLaser.Controls.Add(this.label1);
            this.pnl_MoveLaser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_MoveLaser.Location = new System.Drawing.Point(0, 52);
            this.pnl_MoveLaser.Name = "pnl_MoveLaser";
            this.pnl_MoveLaser.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_MoveLaser.Size = new System.Drawing.Size(490, 52);
            this.pnl_MoveLaser.TabIndex = 16;
            // 
            // lbl_LaserValue
            // 
            this.lbl_LaserValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LaserValue.Location = new System.Drawing.Point(325, 23);
            this.lbl_LaserValue.Name = "lbl_LaserValue";
            this.lbl_LaserValue.Size = new System.Drawing.Size(75, 23);
            this.lbl_LaserValue.TabIndex = 3;
            this.lbl_LaserValue.Text = "lbl_LaserValue";
            this.lbl_LaserValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Height";
            this.label2.Location = new System.Drawing.Point(244, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_MoveLaserNext
            // 
            this.btn_MoveLaserNext.AccessibleDescription = "Next";
            this.btn_MoveLaserNext.Location = new System.Drawing.Point(409, 6);
            this.btn_MoveLaserNext.Name = "btn_MoveLaserNext";
            this.btn_MoveLaserNext.Size = new System.Drawing.Size(75, 40);
            this.btn_MoveLaserNext.TabIndex = 1;
            this.btn_MoveLaserNext.Text = "Next";
            this.btn_MoveLaserNext.UseVisualStyleBackColor = true;
            this.btn_MoveLaserNext.Click += new System.EventHandler(this.btn_MoveLaserNext_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Move Laser to Height Sensor";
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move Laser to Height Sensor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnl_Start
            // 
            this.pnl_Start.AutoSize = true;
            this.pnl_Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Start.Controls.Add(this.btn_Start);
            this.pnl_Start.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Start.Location = new System.Drawing.Point(0, 0);
            this.pnl_Start.Name = "pnl_Start";
            this.pnl_Start.Padding = new System.Windows.Forms.Padding(3);
            this.pnl_Start.Size = new System.Drawing.Size(490, 52);
            this.pnl_Start.TabIndex = 15;
            // 
            // btn_Start
            // 
            this.btn_Start.AccessibleDescription = "Start";
            this.btn_Start.Location = new System.Drawing.Point(409, 6);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 40);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tmr_Laser
            // 
            this.tmr_Laser.Tick += new System.EventHandler(this.tmr_Laser_Tick);
            // 
            // frm_TeachNeedle_LaserCrosshair
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(968, 734);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_TeachNeedle_LaserCrosshair";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "TeachNeedle Laser Crosshair";
            this.Load += new System.EventHandler(this.frm_TeachNeedle_LaserCrosshair_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_TeachNeedle_LaserCrosshair_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_End.ResumeLayout(false);
            this.pnl_MoveH2N1.ResumeLayout(false);
            this.pnl_MoveH1N1.ResumeLayout(false);
            this.pnl_MoveCamera.ResumeLayout(false);
            this.pnl_MoveLaser.ResumeLayout(false);
            this.pnl_Start.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_End;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Complete;
        private System.Windows.Forms.Panel pnl_MoveH2N1;
        private System.Windows.Forms.Button btn_MoveH2N1Next;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel pnl_MoveH1N1;
        private System.Windows.Forms.Button btn_MoveH1N1Next;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel pnl_MoveCamera;
        private System.Windows.Forms.Button btn_MoveCameraNext;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnl_MoveLaser;
        private System.Windows.Forms.Label lbl_LaserValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_MoveLaserNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Start;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Timer tmr_Laser;
    }
}