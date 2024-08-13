namespace NDispWin
{
    partial class frm_DispCore_VisionFailMsg
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
            this.btn_Retry = new System.Windows.Forms.Button();
            this.btn_Skip = new System.Windows.Forms.Button();
            this.btn_Manual = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbox_Ref = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_FoundXYOffset = new System.Windows.Forms.Label();
            this.lbl_FoundScore = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbox_Found = new System.Windows.Forms.PictureBox();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.lbl_MaxXYOffset = new System.Windows.Forms.Label();
            this.lbl_MinScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.lbl_MaxAngle = new System.Windows.Forms.Label();
            this.lbl_FoundAngle = new System.Windows.Forms.Label();
            this.l_lbl_Angle = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.btn_AlmClr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Ref)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Found)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "Retry";
            this.btn_Retry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Retry.Location = new System.Drawing.Point(5, 403);
            this.btn_Retry.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(75, 35);
            this.btn_Retry.TabIndex = 0;
            this.btn_Retry.Text = "Retry";
            this.btn_Retry.UseVisualStyleBackColor = true;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
            // 
            // btn_Skip
            // 
            this.btn_Skip.AccessibleDescription = "Skip";
            this.btn_Skip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Skip.Location = new System.Drawing.Point(84, 403);
            this.btn_Skip.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Skip.Name = "btn_Skip";
            this.btn_Skip.Size = new System.Drawing.Size(75, 35);
            this.btn_Skip.TabIndex = 1;
            this.btn_Skip.Text = "Skip";
            this.btn_Skip.UseVisualStyleBackColor = true;
            this.btn_Skip.Click += new System.EventHandler(this.btn_Skip_Click);
            // 
            // btn_Manual
            // 
            this.btn_Manual.AccessibleDescription = "Manual";
            this.btn_Manual.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manual.Location = new System.Drawing.Point(321, 403);
            this.btn_Manual.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Manual.Name = "btn_Manual";
            this.btn_Manual.Size = new System.Drawing.Size(75, 35);
            this.btn_Manual.TabIndex = 2;
            this.btn_Manual.Text = "Manual";
            this.btn_Manual.UseVisualStyleBackColor = true;
            this.btn_Manual.Click += new System.EventHandler(this.btn_Manual_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Ref Pattern";
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.pbox_Ref);
            this.groupBox1.Location = new System.Drawing.Point(6, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(197, 217);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ref Pattern";
            // 
            // pbox_Ref
            // 
            this.pbox_Ref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_Ref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_Ref.Location = new System.Drawing.Point(5, 20);
            this.pbox_Ref.Name = "pbox_Ref";
            this.pbox_Ref.Size = new System.Drawing.Size(187, 192);
            this.pbox_Ref.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox_Ref.TabIndex = 8;
            this.pbox_Ref.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Vision Fail ";
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vision Fail ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Score (%)";
            this.label2.Location = new System.Drawing.Point(13, 306);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Score (%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "XY Offset (mm)";
            this.label3.Location = new System.Drawing.Point(13, 335);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "XY Offset (mm)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FoundXYOffset
            // 
            this.lbl_FoundXYOffset.Location = new System.Drawing.Point(114, 335);
            this.lbl_FoundXYOffset.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FoundXYOffset.Name = "lbl_FoundXYOffset";
            this.lbl_FoundXYOffset.Size = new System.Drawing.Size(150, 23);
            this.lbl_FoundXYOffset.TabIndex = 6;
            this.lbl_FoundXYOffset.Text = "lbl_XYOffset";
            this.lbl_FoundXYOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FoundScore
            // 
            this.lbl_FoundScore.Location = new System.Drawing.Point(114, 306);
            this.lbl_FoundScore.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FoundScore.Name = "lbl_FoundScore";
            this.lbl_FoundScore.Size = new System.Drawing.Size(150, 23);
            this.lbl_FoundScore.TabIndex = 5;
            this.lbl_FoundScore.Text = "lbl_Score";
            this.lbl_FoundScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Found Pattern";
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.pbox_Found);
            this.groupBox2.Location = new System.Drawing.Point(209, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(197, 217);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Found Pattern";
            // 
            // pbox_Found
            // 
            this.pbox_Found.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_Found.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_Found.Location = new System.Drawing.Point(5, 20);
            this.pbox_Found.Name = "pbox_Found";
            this.pbox_Found.Size = new System.Drawing.Size(187, 192);
            this.pbox_Found.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox_Found.TabIndex = 8;
            this.pbox_Found.TabStop = false;
            // 
            // btn_Accept
            // 
            this.btn_Accept.AccessibleDescription = "Accept";
            this.btn_Accept.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Accept.Location = new System.Drawing.Point(242, 403);
            this.btn_Accept.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 35);
            this.btn_Accept.TabIndex = 10;
            this.btn_Accept.Text = "Accept";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Visible = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // lbl_MaxXYOffset
            // 
            this.lbl_MaxXYOffset.Location = new System.Drawing.Point(270, 335);
            this.lbl_MaxXYOffset.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaxXYOffset.Name = "lbl_MaxXYOffset";
            this.lbl_MaxXYOffset.Size = new System.Drawing.Size(150, 23);
            this.lbl_MaxXYOffset.TabIndex = 12;
            this.lbl_MaxXYOffset.Text = "lbl_MaxXYOffset";
            this.lbl_MaxXYOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_MinScore
            // 
            this.lbl_MinScore.Location = new System.Drawing.Point(270, 306);
            this.lbl_MinScore.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MinScore.Name = "lbl_MinScore";
            this.lbl_MinScore.Size = new System.Drawing.Size(150, 23);
            this.lbl_MinScore.TabIndex = 11;
            this.lbl_MinScore.Text = "lbl_MinScore";
            this.lbl_MinScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Spec";
            this.label4.Location = new System.Drawing.Point(271, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Spec";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Found";
            this.label5.Location = new System.Drawing.Point(115, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Found";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "Stop";
            this.btn_Stop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(163, 403);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 35);
            this.btn_Stop.TabIndex = 16;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // lbl_MaxAngle
            // 
            this.lbl_MaxAngle.Location = new System.Drawing.Point(270, 364);
            this.lbl_MaxAngle.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_MaxAngle.Name = "lbl_MaxAngle";
            this.lbl_MaxAngle.Size = new System.Drawing.Size(150, 23);
            this.lbl_MaxAngle.TabIndex = 19;
            this.lbl_MaxAngle.Text = "lbl_MaxAngle";
            this.lbl_MaxAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FoundAngle
            // 
            this.lbl_FoundAngle.Location = new System.Drawing.Point(114, 364);
            this.lbl_FoundAngle.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FoundAngle.Name = "lbl_FoundAngle";
            this.lbl_FoundAngle.Size = new System.Drawing.Size(150, 23);
            this.lbl_FoundAngle.TabIndex = 18;
            this.lbl_FoundAngle.Text = "lbl_FoundAngle";
            this.lbl_FoundAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_lbl_Angle
            // 
            this.l_lbl_Angle.AccessibleDescription = "Angle (degree)";
            this.l_lbl_Angle.Location = new System.Drawing.Point(13, 364);
            this.l_lbl_Angle.Margin = new System.Windows.Forms.Padding(3);
            this.l_lbl_Angle.Name = "l_lbl_Angle";
            this.l_lbl_Angle.Size = new System.Drawing.Size(95, 23);
            this.l_lbl_Angle.TabIndex = 17;
            this.l_lbl_Angle.Text = "Angle (degree)";
            this.l_lbl_Angle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // btn_AlmClr
            // 
            this.btn_AlmClr.AccessibleDescription = "AlmClr";
            this.btn_AlmClr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AlmClr.Location = new System.Drawing.Point(5, 442);
            this.btn_AlmClr.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AlmClr.Name = "btn_AlmClr";
            this.btn_AlmClr.Size = new System.Drawing.Size(75, 35);
            this.btn_AlmClr.TabIndex = 20;
            this.btn_AlmClr.Text = "AlmClr";
            this.btn_AlmClr.UseVisualStyleBackColor = true;
            this.btn_AlmClr.Click += new System.EventHandler(this.btn_AlmClr_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "Reject";
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(321, 442);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 21;
            this.button1.Text = "Reject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frm_DispCore_VisionFailMsg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(420, 499);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_AlmClr);
            this.Controls.Add(this.lbl_MaxAngle);
            this.Controls.Add(this.lbl_FoundAngle);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_MaxXYOffset);
            this.Controls.Add(this.lbl_MinScore);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_FoundXYOffset);
            this.Controls.Add(this.lbl_FoundScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Manual);
            this.Controls.Add(this.btn_Skip);
            this.Controls.Add(this.btn_Retry);
            this.Controls.Add(this.l_lbl_Angle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_VisionFailMsg";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisionFailMsg";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVisionFailMsg_FormClosed);
            this.Load += new System.EventHandler(this.frmVisionFailMsg_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Ref)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Found)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Retry;
        private System.Windows.Forms.Button btn_Skip;
        private System.Windows.Forms.Button btn_Manual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbox_Ref;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_FoundXYOffset;
        private System.Windows.Forms.Label lbl_FoundScore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbox_Found;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Label lbl_MaxXYOffset;
        private System.Windows.Forms.Label lbl_MinScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label lbl_MaxAngle;
        private System.Windows.Forms.Label lbl_FoundAngle;
        private System.Windows.Forms.Label l_lbl_Angle;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_AlmClr;
        private System.Windows.Forms.Button button1;
    }
}