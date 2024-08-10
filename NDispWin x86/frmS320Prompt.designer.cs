namespace NDispWin
{
    partial class frmS320Prompt
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.lbl_DescAlt = new System.Windows.Forms.Label();
            this.tmr_IO = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.AccessibleDescription = "START";
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Start.Location = new System.Drawing.Point(114, 110);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(117, 48);
            this.btn_Start.TabIndex = 21;
            this.btn_Start.Text = "START";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Desc.Location = new System.Drawing.Point(14, 10);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(58, 17);
            this.lbl_Desc.TabIndex = 23;
            this.lbl_Desc.Text = "lbl_Desc";
            // 
            // btn_Stop
            // 
            this.btn_Stop.AccessibleDescription = "STOP";
            this.btn_Stop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Stop.Location = new System.Drawing.Point(281, 110);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(117, 48);
            this.btn_Stop.TabIndex = 22;
            this.btn_Stop.Text = "STOP";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // lbl_DescAlt
            // 
            this.lbl_DescAlt.AutoSize = true;
            this.lbl_DescAlt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_DescAlt.Location = new System.Drawing.Point(14, 56);
            this.lbl_DescAlt.Name = "lbl_DescAlt";
            this.lbl_DescAlt.Size = new System.Drawing.Size(73, 17);
            this.lbl_DescAlt.TabIndex = 24;
            this.lbl_DescAlt.Text = "lbl_DescAlt";
            // 
            // tmr_IO
            // 
            this.tmr_IO.Enabled = true;
            this.tmr_IO.Tick += new System.EventHandler(this.tmr_IO_Tick);
            // 
            // frmS320Prompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 171);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_Desc);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.lbl_DescAlt);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmS320Prompt";
            this.Text = "frmS320Prompt";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmS320Prompt_FormClosed);
            this.Load += new System.EventHandler(this.frmS320Prompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_Desc;
        public System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label lbl_DescAlt;
        private System.Windows.Forms.Timer tmr_IO;
    }
}