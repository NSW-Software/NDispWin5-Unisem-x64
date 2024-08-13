namespace DispCore
{
    partial class frmDispProg_DoVisMap
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
            this.l_lbl_MapID = new System.Windows.Forms.Label();
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FovC = new System.Windows.Forms.Label();
            this.lbl_FovR = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_SetStartPos = new System.Windows.Forms.Button();
            this.btn_GotoStartPos = new System.Windows.Forms.Button();
            this.lbl_FovStartXY = new System.Windows.Forms.Label();
            this.btn_XFirstUPath = new System.Windows.Forms.Button();
            this.btn_YFirstUPath = new System.Windows.Forms.Button();
            this.btn_XFirstZPath = new System.Windows.Forms.Button();
            this.btn_YFirstZPath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Capture = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lbl_MapID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // l_lbl_MapID
            // 
            this.l_lbl_MapID.Location = new System.Drawing.Point(5, 5);
            this.l_lbl_MapID.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_MapID.Name = "l_lbl_MapID";
            this.l_lbl_MapID.Size = new System.Drawing.Size(100, 23);
            this.l_lbl_MapID.TabIndex = 4;
            this.l_lbl_MapID.Text = "Map ID";
            this.l_lbl_MapID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbox_Image
            // 
            this.pbox_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_Image.Location = new System.Drawing.Point(5, 129);
            this.pbox_Image.Margin = new System.Windows.Forms.Padding(2);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(554, 497);
            this.pbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbox_Image.TabIndex = 7;
            this.pbox_Image.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "FOV Column(s), Row(s)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FovC
            // 
            this.lbl_FovC.BackColor = System.Drawing.Color.White;
            this.lbl_FovC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FovC.Location = new System.Drawing.Point(242, 32);
            this.lbl_FovC.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FovC.Name = "lbl_FovC";
            this.lbl_FovC.Size = new System.Drawing.Size(76, 23);
            this.lbl_FovC.TabIndex = 7;
            this.lbl_FovC.Text = "lbl_FovC";
            this.lbl_FovC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FovC.Click += new System.EventHandler(this.lbl_FovC_Click);
            // 
            // lbl_FovR
            // 
            this.lbl_FovR.BackColor = System.Drawing.Color.White;
            this.lbl_FovR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FovR.Location = new System.Drawing.Point(324, 32);
            this.lbl_FovR.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FovR.Name = "lbl_FovR";
            this.lbl_FovR.Size = new System.Drawing.Size(76, 23);
            this.lbl_FovR.TabIndex = 9;
            this.lbl_FovR.Text = "lbl_FovR";
            this.lbl_FovR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FovR.Click += new System.EventHandler(this.lbl_FovR_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "FOV Start Pos X, Y (mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SetStartPos
            // 
            this.lbl_SetStartPos.Location = new System.Drawing.Point(405, 95);
            this.lbl_SetStartPos.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_SetStartPos.Name = "lbl_SetStartPos";
            this.lbl_SetStartPos.Size = new System.Drawing.Size(75, 30);
            this.lbl_SetStartPos.TabIndex = 14;
            this.lbl_SetStartPos.Text = "Set";
            this.lbl_SetStartPos.UseVisualStyleBackColor = true;
            this.lbl_SetStartPos.Click += new System.EventHandler(this.lbl_SetStartPos_Click);
            // 
            // btn_GotoStartPos
            // 
            this.btn_GotoStartPos.Location = new System.Drawing.Point(484, 95);
            this.btn_GotoStartPos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoStartPos.Name = "btn_GotoStartPos";
            this.btn_GotoStartPos.Size = new System.Drawing.Size(75, 30);
            this.btn_GotoStartPos.TabIndex = 16;
            this.btn_GotoStartPos.Text = "Goto";
            this.btn_GotoStartPos.UseVisualStyleBackColor = true;
            this.btn_GotoStartPos.Click += new System.EventHandler(this.btn_GotoStartPos_Click);
            // 
            // lbl_FovStartXY
            // 
            this.lbl_FovStartXY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FovStartXY.Location = new System.Drawing.Point(241, 99);
            this.lbl_FovStartXY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FovStartXY.Name = "lbl_FovStartXY";
            this.lbl_FovStartXY.Size = new System.Drawing.Size(159, 23);
            this.lbl_FovStartXY.TabIndex = 17;
            this.lbl_FovStartXY.Text = "lbl_FovStartXY";
            this.lbl_FovStartXY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_XFirstUPath
            // 
            this.btn_XFirstUPath.Location = new System.Drawing.Point(403, 60);
            this.btn_XFirstUPath.Name = "btn_XFirstUPath";
            this.btn_XFirstUPath.Size = new System.Drawing.Size(75, 30);
            this.btn_XFirstUPath.TabIndex = 106;
            this.btn_XFirstUPath.Text = "XF U";
            this.btn_XFirstUPath.UseVisualStyleBackColor = true;
            this.btn_XFirstUPath.Click += new System.EventHandler(this.btn_XFirstUPath_Click);
            // 
            // btn_YFirstUPath
            // 
            this.btn_YFirstUPath.Location = new System.Drawing.Point(484, 60);
            this.btn_YFirstUPath.Name = "btn_YFirstUPath";
            this.btn_YFirstUPath.Size = new System.Drawing.Size(75, 30);
            this.btn_YFirstUPath.TabIndex = 107;
            this.btn_YFirstUPath.Text = "YF U";
            this.btn_YFirstUPath.UseVisualStyleBackColor = true;
            this.btn_YFirstUPath.Click += new System.EventHandler(this.btn_YFirstUPath_Click);
            // 
            // btn_XFirstZPath
            // 
            this.btn_XFirstZPath.Location = new System.Drawing.Point(241, 60);
            this.btn_XFirstZPath.Name = "btn_XFirstZPath";
            this.btn_XFirstZPath.Size = new System.Drawing.Size(75, 30);
            this.btn_XFirstZPath.TabIndex = 104;
            this.btn_XFirstZPath.Text = "XF Z";
            this.btn_XFirstZPath.UseVisualStyleBackColor = true;
            this.btn_XFirstZPath.Click += new System.EventHandler(this.btn_XFirstZPath_Click);
            // 
            // btn_YFirstZPath
            // 
            this.btn_YFirstZPath.Location = new System.Drawing.Point(322, 60);
            this.btn_YFirstZPath.Name = "btn_YFirstZPath";
            this.btn_YFirstZPath.Size = new System.Drawing.Size(75, 30);
            this.btn_YFirstZPath.TabIndex = 105;
            this.btn_YFirstZPath.Text = "YF Z";
            this.btn_YFirstZPath.UseVisualStyleBackColor = true;
            this.btn_YFirstZPath.Click += new System.EventHandler(this.btn_YFirstZPath_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 23);
            this.label6.TabIndex = 108;
            this.label6.Text = "FOV Direction";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(484, 631);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 110;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(403, 631);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 109;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(5, 630);
            this.btn_Capture.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(75, 36);
            this.btn_Capture.TabIndex = 111;
            this.btn_Capture.Text = "Capture";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(84, 630);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 36);
            this.button5.TabIndex = 112;
            this.button5.Text = "Teach";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lbl_MapID
            // 
            this.lbl_MapID.BackColor = System.Drawing.Color.White;
            this.lbl_MapID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_MapID.Location = new System.Drawing.Point(241, 5);
            this.lbl_MapID.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_MapID.Name = "lbl_MapID";
            this.lbl_MapID.Size = new System.Drawing.Size(76, 23);
            this.lbl_MapID.TabIndex = 113;
            this.lbl_MapID.Text = "lbl_MapID";
            this.lbl_MapID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_MapID.Click += new System.EventHandler(this.lbl_MapID_Click);
            // 
            // frmDispProg_DoVisMap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(822, 737);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_MapID);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_Capture);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_XFirstUPath);
            this.Controls.Add(this.pbox_Image);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_YFirstUPath);
            this.Controls.Add(this.btn_XFirstZPath);
            this.Controls.Add(this.btn_YFirstZPath);
            this.Controls.Add(this.lbl_FovStartXY);
            this.Controls.Add(this.btn_GotoStartPos);
            this.Controls.Add(this.lbl_SetStartPos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_FovR);
            this.Controls.Add(this.lbl_FovC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_lbl_MapID);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDispProg_DoVisMap";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmDispProg_DoVisMap";
            this.Load += new System.EventHandler(this.frmDispProg_DoVisMap_Load);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_DoVisMap_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_lbl_MapID;
        private System.Windows.Forms.PictureBox pbox_Image;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_FovC;
        private System.Windows.Forms.Label lbl_FovR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button lbl_SetStartPos;
        private System.Windows.Forms.Button btn_GotoStartPos;
        private System.Windows.Forms.Label lbl_FovStartXY;
        private System.Windows.Forms.Button btn_XFirstUPath;
        private System.Windows.Forms.Button btn_YFirstUPath;
        private System.Windows.Forms.Button btn_XFirstZPath;
        private System.Windows.Forms.Button btn_YFirstZPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lbl_MapID;
    }
}