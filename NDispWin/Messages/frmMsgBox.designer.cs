namespace NDispWin
{
    partial class frm_MsgBox
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
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Retry = new System.Windows.Forms.Button();
            this.btn_AlmClr = new System.Windows.Forms.Button();
            this.pbox_Sign = new System.Windows.Forms.PictureBox();
            this.pbox_Image = new System.Windows.Forms.PictureBox();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.lbl_ErrCode = new System.Windows.Forms.Label();
            this.lbl_CAct = new System.Windows.Forms.Label();
            this.lbl_Desc_Alt = new System.Windows.Forms.Label();
            this.lbl_CAct_Alt = new System.Windows.Forms.Label();
            this.pnl_Msg = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Desc = new System.Windows.Forms.Panel();
            this.lbl_ExMessage = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.tmr_BringToFront = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslQue = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Sign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).BeginInit();
            this.pnl_Msg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Desc.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "STOP";
            this.btn_Stop.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Stop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Stop.Location = new System.Drawing.Point(494, 3);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(100, 41);
            this.btn_Stop.TabIndex = 17;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "CANCEL";
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(794, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 41);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.BackColor = System.Drawing.SystemColors.Control;
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_OK.Location = new System.Drawing.Point(94, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 41);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Retry
            // 
            this.btn_Retry.AccessibleDescription = "RETRY";
            this.btn_Retry.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Retry.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Retry.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Retry.Location = new System.Drawing.Point(594, 3);
            this.btn_Retry.Name = "btn_Retry";
            this.btn_Retry.Size = new System.Drawing.Size(100, 41);
            this.btn_Retry.TabIndex = 3;
            this.btn_Retry.Text = "RETRY";
            this.btn_Retry.UseVisualStyleBackColor = false;
            this.btn_Retry.Click += new System.EventHandler(this.btn_Retry_Click);
            // 
            // btn_AlmClr
            // 
            this.btn_AlmClr.AccessibleDescription = "BUZZER MUTE";
            this.btn_AlmClr.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AlmClr.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_AlmClr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_AlmClr.Location = new System.Drawing.Point(3, 3);
            this.btn_AlmClr.Name = "btn_AlmClr";
            this.btn_AlmClr.Size = new System.Drawing.Size(100, 41);
            this.btn_AlmClr.TabIndex = 2;
            this.btn_AlmClr.Text = "BUZZER MUTE";
            this.btn_AlmClr.UseVisualStyleBackColor = false;
            this.btn_AlmClr.Click += new System.EventHandler(this.btn_AlmClr_Click);
            // 
            // pbox_Sign
            // 
            this.pbox_Sign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbox_Sign.Location = new System.Drawing.Point(3, 3);
            this.pbox_Sign.Name = "pbox_Sign";
            this.pbox_Sign.Size = new System.Drawing.Size(40, 40);
            this.pbox_Sign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Sign.TabIndex = 15;
            this.pbox_Sign.TabStop = false;
            // 
            // pbox_Image
            // 
            this.pbox_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox_Image.Location = new System.Drawing.Point(534, 8);
            this.pbox_Image.Name = "pbox_Image";
            this.pbox_Image.Size = new System.Drawing.Size(400, 400);
            this.pbox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox_Image.TabIndex = 16;
            this.pbox_Image.TabStop = false;
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Desc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Desc.Location = new System.Drawing.Point(0, 0);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(58, 17);
            this.lbl_Desc.TabIndex = 18;
            this.lbl_Desc.Text = "lbl_Desc";
            // 
            // lbl_ErrCode
            // 
            this.lbl_ErrCode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ErrCode.Location = new System.Drawing.Point(49, 3);
            this.lbl_ErrCode.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbl_ErrCode.Name = "lbl_ErrCode";
            this.lbl_ErrCode.Size = new System.Drawing.Size(100, 30);
            this.lbl_ErrCode.TabIndex = 19;
            this.lbl_ErrCode.Text = "lbl_ErrCode";
            this.lbl_ErrCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CAct
            // 
            this.lbl_CAct.AutoSize = true;
            this.lbl_CAct.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_CAct.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CAct.Location = new System.Drawing.Point(0, 0);
            this.lbl_CAct.Name = "lbl_CAct";
            this.lbl_CAct.Size = new System.Drawing.Size(57, 17);
            this.lbl_CAct.TabIndex = 20;
            this.lbl_CAct.Text = "lbl_CAct";
            // 
            // lbl_Desc_Alt
            // 
            this.lbl_Desc_Alt.AutoSize = true;
            this.lbl_Desc_Alt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Desc_Alt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Desc_Alt.Location = new System.Drawing.Point(0, 17);
            this.lbl_Desc_Alt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbl_Desc_Alt.Name = "lbl_Desc_Alt";
            this.lbl_Desc_Alt.Size = new System.Drawing.Size(81, 17);
            this.lbl_Desc_Alt.TabIndex = 21;
            this.lbl_Desc_Alt.Text = "lbl_Desc_Alt";
            // 
            // lbl_CAct_Alt
            // 
            this.lbl_CAct_Alt.AutoSize = true;
            this.lbl_CAct_Alt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_CAct_Alt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CAct_Alt.Location = new System.Drawing.Point(0, 17);
            this.lbl_CAct_Alt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lbl_CAct_Alt.Name = "lbl_CAct_Alt";
            this.lbl_CAct_Alt.Size = new System.Drawing.Size(80, 17);
            this.lbl_CAct_Alt.TabIndex = 22;
            this.lbl_CAct_Alt.Text = "lbl_CAct_Alt";
            // 
            // pnl_Msg
            // 
            this.pnl_Msg.AutoSize = true;
            this.pnl_Msg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Msg.BackColor = System.Drawing.Color.White;
            this.pnl_Msg.Controls.Add(this.panel1);
            this.pnl_Msg.Controls.Add(this.pnl_Desc);
            this.pnl_Msg.Controls.Add(this.lbl_ExMessage);
            this.pnl_Msg.Controls.Add(this.pbox_Sign);
            this.pnl_Msg.Controls.Add(this.lbl_ErrCode);
            this.pnl_Msg.Location = new System.Drawing.Point(5, 8);
            this.pnl_Msg.Name = "pnl_Msg";
            this.pnl_Msg.Size = new System.Drawing.Size(524, 342);
            this.pnl_Msg.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_CAct_Alt);
            this.panel1.Controls.Add(this.lbl_CAct);
            this.panel1.Location = new System.Drawing.Point(49, 156);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 112);
            this.panel1.TabIndex = 22;
            // 
            // pnl_Desc
            // 
            this.pnl_Desc.Controls.Add(this.lbl_Desc_Alt);
            this.pnl_Desc.Controls.Add(this.lbl_Desc);
            this.pnl_Desc.Location = new System.Drawing.Point(49, 41);
            this.pnl_Desc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnl_Desc.Name = "pnl_Desc";
            this.pnl_Desc.Size = new System.Drawing.Size(471, 112);
            this.pnl_Desc.TabIndex = 29;
            // 
            // lbl_ExMessage
            // 
            this.lbl_ExMessage.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ExMessage.Location = new System.Drawing.Point(49, 271);
            this.lbl_ExMessage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lbl_ExMessage.Name = "lbl_ExMessage";
            this.lbl_ExMessage.Size = new System.Drawing.Size(471, 68);
            this.lbl_ExMessage.TabIndex = 28;
            this.lbl_ExMessage.Text = "lbl_ExMessage";
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // tmr_BringToFront
            // 
            this.tmr_BringToFront.Interval = 10000;
            this.tmr_BringToFront.Tick += new System.EventHandler(this.tmr_BringToFront_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Controls.Add(this.btnNo);
            this.panel2.Controls.Add(this.btn_AlmClr);
            this.panel2.Controls.Add(this.btnSkip);
            this.panel2.Controls.Add(this.btn_Stop);
            this.panel2.Controls.Add(this.btn_Retry);
            this.panel2.Controls.Add(this.btnContinue);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 420);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(897, 47);
            this.panel2.TabIndex = 30;
            // 
            // btnYes
            // 
            this.btnYes.AccessibleDescription = "YES";
            this.btnYes.BackColor = System.Drawing.SystemColors.Control;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnYes.Location = new System.Drawing.Point(194, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 41);
            this.btnYes.TabIndex = 18;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleDescription = "NO";
            this.btnNo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNo.Location = new System.Drawing.Point(294, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 41);
            this.btnNo.TabIndex = 19;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.AccessibleDescription = "SKIP";
            this.btnSkip.BackColor = System.Drawing.SystemColors.Control;
            this.btnSkip.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSkip.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSkip.Location = new System.Drawing.Point(394, 3);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(100, 41);
            this.btnSkip.TabIndex = 21;
            this.btnSkip.Text = "SKIP";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.AccessibleDescription = "CONTINUE";
            this.btnContinue.BackColor = System.Drawing.SystemColors.Control;
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(694, 3);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(100, 41);
            this.btnContinue.TabIndex = 20;
            this.btnContinue.Text = "CONTINUE";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslVersion,
            this.tsslQue,
            this.tsslDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(5, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslVersion
            // 
            this.tsslVersion.Name = "tsslVersion";
            this.tsslVersion.Size = new System.Drawing.Size(62, 17);
            this.tsslVersion.Text = "tsslVersion";
            // 
            // tsslQue
            // 
            this.tsslQue.Name = "tsslQue";
            this.tsslQue.Size = new System.Drawing.Size(46, 17);
            this.tsslQue.Text = "tsslQue";
            // 
            // tsslDateTime
            // 
            this.tsslDateTime.Name = "tsslDateTime";
            this.tsslDateTime.Size = new System.Drawing.Size(75, 17);
            this.tsslDateTime.Text = "tsslDateTime";
            // 
            // frm_MsgBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(907, 494);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_Msg);
            this.Controls.Add(this.pbox_Image);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(530, 500);
            this.Name = "frm_MsgBox";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.Text = "MsgBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Msg_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Msg_FormClosed);
            this.Load += new System.EventHandler(this.frm_Msg_Load);
            this.Shown += new System.EventHandler(this.frm_Msg_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Sign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Image)).EndInit();
            this.pnl_Msg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Desc.ResumeLayout(false);
            this.pnl_Desc.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AlmClr;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        public System.Windows.Forms.Button btn_Retry;
        private System.Windows.Forms.PictureBox pbox_Sign;
        private System.Windows.Forms.PictureBox pbox_Image;
        public System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Label lbl_ErrCode;
        private System.Windows.Forms.Label lbl_CAct;
        private System.Windows.Forms.Label lbl_Desc_Alt;
        private System.Windows.Forms.Label lbl_CAct_Alt;
        private System.Windows.Forms.Panel pnl_Msg;
        private System.Windows.Forms.Label lbl_ExMessage;
        private System.Windows.Forms.Panel pnl_Desc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Timer tmr_BringToFront;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsslQue;
        private System.Windows.Forms.ToolStripStatusLabel tsslDateTime;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnSkip;
    }
}