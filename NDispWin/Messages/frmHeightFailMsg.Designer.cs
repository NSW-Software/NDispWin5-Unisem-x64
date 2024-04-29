namespace NDispWin
{
    partial class frm_DispCore_HeightFailMsg
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
            this.btn_Accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Skip = new System.Windows.Forms.Button();
            this.btn_Retry = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.btn_AlmClr = new System.Windows.Forms.Button();
            this.btn_Reject = new System.Windows.Forms.Button();
            this.lbox_Message = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_Accept
            // 
            this.btn_Accept.AccessibleDescription = "Accept";
            this.btn_Accept.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Accept.Location = new System.Drawing.Point(321, 127);
            this.btn_Accept.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(75, 35);
            this.btn_Accept.TabIndex = 15;
            this.btn_Accept.Text = "Accept";
            this.btn_Accept.UseVisualStyleBackColor = true;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Height Fail ";
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Height Fail ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "Stop";
            this.btn_Stop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(242, 127);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 35);
            this.btn_Stop.TabIndex = 13;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Skip
            // 
            this.btn_Skip.AccessibleDescription = "Skip";
            this.btn_Skip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Skip.Location = new System.Drawing.Point(163, 127);
            this.btn_Skip.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Skip.Name = "btn_Skip";
            this.btn_Skip.Size = new System.Drawing.Size(75, 35);
            this.btn_Skip.TabIndex = 12;
            this.btn_Skip.Text = "Skip";
            this.btn_Skip.UseVisualStyleBackColor = true;
            this.btn_Skip.Click += new System.EventHandler(this.btn_Skip_Click);
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "Retry";
            this.btn_Retry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Retry.Location = new System.Drawing.Point(84, 127);
            this.btn_Retry.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(75, 35);
            this.btn_Retry.TabIndex = 11;
            this.btn_Retry.Text = "Retry";
            this.btn_Retry.UseVisualStyleBackColor = true;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
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
            this.btn_AlmClr.Location = new System.Drawing.Point(5, 127);
            this.btn_AlmClr.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AlmClr.Name = "btn_AlmClr";
            this.btn_AlmClr.Size = new System.Drawing.Size(75, 35);
            this.btn_AlmClr.TabIndex = 21;
            this.btn_AlmClr.Text = "AlmClr";
            this.btn_AlmClr.UseVisualStyleBackColor = true;
            this.btn_AlmClr.Click += new System.EventHandler(this.btn_AlmClr_Click);
            // 
            // btn_Reject
            // 
            this.btn_Reject.AccessibleDescription = "Reject";
            this.btn_Reject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reject.Location = new System.Drawing.Point(321, 166);
            this.btn_Reject.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Reject.Name = "btn_Reject";
            this.btn_Reject.Size = new System.Drawing.Size(75, 35);
            this.btn_Reject.TabIndex = 22;
            this.btn_Reject.Text = "Reject";
            this.btn_Reject.UseVisualStyleBackColor = true;
            this.btn_Reject.Click += new System.EventHandler(this.btn_Reject_Click);
            // 
            // lbox_Message
            // 
            this.lbox_Message.BackColor = System.Drawing.SystemColors.Control;
            this.lbox_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbox_Message.ForeColor = System.Drawing.Color.Navy;
            this.lbox_Message.FormattingEnabled = true;
            this.lbox_Message.ItemHeight = 14;
            this.lbox_Message.Location = new System.Drawing.Point(8, 41);
            this.lbox_Message.Name = "lbox_Message";
            this.lbox_Message.Size = new System.Drawing.Size(388, 70);
            this.lbox_Message.TabIndex = 24;
            // 
            // frm_DispCore_HeightFailMsg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(411, 214);
            this.ControlBox = false;
            this.Controls.Add(this.lbox_Message);
            this.Controls.Add(this.btn_Reject);
            this.Controls.Add(this.btn_AlmClr);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Skip);
            this.Controls.Add(this.btn_Retry);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_HeightFailMsg";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHeightFailMsg";
            this.Load += new System.EventHandler(this.frmHeightFailMsg_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHeightFailMsg_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Skip;
        private System.Windows.Forms.Button btn_Retry;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_AlmClr;
        private System.Windows.Forms.Button btn_Reject;
        private System.Windows.Forms.ListBox lbox_Message;
    }
}