namespace NDispWin
{
    partial class frmVisionFailMsg2
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
            this.btn_AlmClr = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Accept = new System.Windows.Forms.Button();
            this.btn_Manual = new System.Windows.Forms.Button();
            this.btn_Skip = new System.Windows.Forms.Button();
            this.btn_Retry = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_JogPos = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AlmClr
            // 
            this.btn_AlmClr.AccessibleDescription = "AlmClr";
            this.btn_AlmClr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AlmClr.Location = new System.Drawing.Point(6, 6);
            this.btn_AlmClr.Name = "btn_AlmClr";
            this.btn_AlmClr.Size = new System.Drawing.Size(100, 40);
            this.btn_AlmClr.TabIndex = 26;
            this.btn_AlmClr.Text = "AlmClr";
            this.btn_AlmClr.UseVisualStyleBackColor = true;
            this.btn_AlmClr.Click += new System.EventHandler(this.btn_AlmClr_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "Stop";
            this.btn_Stop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(218, 52);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(100, 40);
            this.btn_Stop.TabIndex = 25;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Accept
            // 
            this.btn_Accept.AccessibleDescription = "Accept";
            this.btn_Accept.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Accept.Location = new System.Drawing.Point(218, 6);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(100, 40);
            this.btn_Accept.TabIndex = 24;
            this.btn_Accept.Text = "Accept";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Visible = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Manual
            // 
            this.btn_Manual.AccessibleDescription = "Manual";
            this.btn_Manual.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manual.Location = new System.Drawing.Point(324, 52);
            this.btn_Manual.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Manual.Name = "btn_Manual";
            this.btn_Manual.Size = new System.Drawing.Size(100, 40);
            this.btn_Manual.TabIndex = 23;
            this.btn_Manual.Text = "Manual";
            this.btn_Manual.UseVisualStyleBackColor = true;
            this.btn_Manual.Click += new System.EventHandler(this.btn_Manual_Click);
            // 
            // btn_Skip
            // 
            this.btn_Skip.AccessibleDescription = "Skip";
            this.btn_Skip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Skip.Location = new System.Drawing.Point(112, 52);
            this.btn_Skip.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Skip.Name = "btn_Skip";
            this.btn_Skip.Size = new System.Drawing.Size(100, 40);
            this.btn_Skip.TabIndex = 22;
            this.btn_Skip.Text = "Skip";
            this.btn_Skip.UseVisualStyleBackColor = true;
            this.btn_Skip.Click += new System.EventHandler(this.btn_Skip_Click);
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "Retry";
            this.btn_Retry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Retry.Location = new System.Drawing.Point(6, 52);
            this.btn_Retry.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(100, 40);
            this.btn_Retry.TabIndex = 21;
            this.btn_Retry.Text = "Retry";
            this.btn_Retry.UseVisualStyleBackColor = true;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.rtbMessage);
            this.panel1.Controls.Add(this.btn_JogPos);
            this.panel1.Controls.Add(this.lbl_Message);
            this.panel1.Controls.Add(this.btn_AlmClr);
            this.panel1.Controls.Add(this.btn_Retry);
            this.panel1.Controls.Add(this.btn_Stop);
            this.panel1.Controls.Add(this.btn_Skip);
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Controls.Add(this.btn_Manual);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Size = new System.Drawing.Size(430, 179);
            this.panel1.TabIndex = 27;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_JogPos
            // 
            this.btn_JogPos.Location = new System.Drawing.Point(349, 6);
            this.btn_JogPos.Name = "btn_JogPos";
            this.btn_JogPos.Size = new System.Drawing.Size(75, 30);
            this.btn_JogPos.TabIndex = 29;
            this.btn_JogPos.Text = "Jog Pos";
            this.btn_JogPos.UseVisualStyleBackColor = true;
            this.btn_JogPos.Click += new System.EventHandler(this.btn_JogPos_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(3, 92);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(0, 18);
            this.lbl_Message.TabIndex = 27;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(6, 95);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(418, 81);
            this.rtbMessage.TabIndex = 30;
            this.rtbMessage.Text = "";
            // 
            // frmVisionFailMsg2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(519, 213);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVisionFailMsg2";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmVisionFailMsg2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisionFailMsg2_FormClosing);
            this.Load += new System.EventHandler(this.frmVisionFailMsg2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AlmClr;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Button btn_Manual;
        private System.Windows.Forms.Button btn_Skip;
        private System.Windows.Forms.Button btn_Retry;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_JogPos;
        private System.Windows.Forms.RichTextBox rtbMessage;
    }
}