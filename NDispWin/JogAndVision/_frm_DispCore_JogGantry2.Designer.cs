namespace NDispWin
{
    partial class frm_DispCore_JogGantry2
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.uctrl_JogGantry1 = new NDispWin.uctrl_JogGantry();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.btn_Close.Location = new System.Drawing.Point(427, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // uctrl_JogGantry1
            // 
            this.uctrl_JogGantry1.AutoSize = true;
            this.uctrl_JogGantry1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctrl_JogGantry1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uctrl_JogGantry1.ForeColor = System.Drawing.Color.Navy;
            this.uctrl_JogGantry1.Location = new System.Drawing.Point(6, 42);
            this.uctrl_JogGantry1.Name = "uctrl_JogGantry1";
            this.uctrl_JogGantry1.Size = new System.Drawing.Size(503, 224);
            this.uctrl_JogGantry1.TabIndex = 0;
            this.uctrl_JogGantry1.Load += new System.EventHandler(this.uctrl_JogGantry1_Load);
            // 
            // frm_DispCore_JogGantry2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(508, 264);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.uctrl_JogGantry1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DispCore_JogGantry2";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Jog Gantry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DispCore_JogGantry2_FormClosing);
            this.Load += new System.EventHandler(this.frm_DispCore_JogGantry2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrl_JogGantry uctrl_JogGantry1;
        private System.Windows.Forms.Button btn_Close;
    }
}