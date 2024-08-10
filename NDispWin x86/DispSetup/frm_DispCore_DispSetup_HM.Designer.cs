namespace NDispWin
{
    partial class frm_DispCore_DispSetup_HM
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
            this.btn_ModeB = new System.Windows.Forms.Button();
            this.btn_TrigB = new System.Windows.Forms.Button();
            this.btn_ModeA = new System.Windows.Forms.Button();
            this.btn_TrigA = new System.Windows.Forms.Button();
            this.tmt_Display = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_ModeB
            // 
            this.btn_ModeB.AccessibleDescription = "Mode";
            this.btn_ModeB.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_ModeB.Location = new System.Drawing.Point(586, 6);
            this.btn_ModeB.Name = "btn_ModeB";
            this.btn_ModeB.Size = new System.Drawing.Size(50, 50);
            this.btn_ModeB.TabIndex = 70;
            this.btn_ModeB.Text = "Mode";
            this.btn_ModeB.UseVisualStyleBackColor = false;
            this.btn_ModeB.Click += new System.EventHandler(this.btn_ModeB_Click);
            // 
            // btn_TrigB
            // 
            this.btn_TrigB.AccessibleDescription = "Trig";
            this.btn_TrigB.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_TrigB.Location = new System.Drawing.Point(586, 62);
            this.btn_TrigB.Name = "btn_TrigB";
            this.btn_TrigB.Size = new System.Drawing.Size(50, 50);
            this.btn_TrigB.TabIndex = 69;
            this.btn_TrigB.Text = "Trig";
            this.btn_TrigB.UseVisualStyleBackColor = false;
            this.btn_TrigB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_TrigB_MouseDown);
            this.btn_TrigB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_TrigB_MouseUp);
            // 
            // btn_ModeA
            // 
            this.btn_ModeA.AccessibleDescription = "Mode";
            this.btn_ModeA.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_ModeA.Location = new System.Drawing.Point(530, 6);
            this.btn_ModeA.Name = "btn_ModeA";
            this.btn_ModeA.Size = new System.Drawing.Size(50, 50);
            this.btn_ModeA.TabIndex = 68;
            this.btn_ModeA.Text = "Mode";
            this.btn_ModeA.UseVisualStyleBackColor = false;
            this.btn_ModeA.Click += new System.EventHandler(this.btn_ModeA_Click);
            // 
            // btn_TrigA
            // 
            this.btn_TrigA.AccessibleDescription = "Trig";
            this.btn_TrigA.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_TrigA.Location = new System.Drawing.Point(530, 62);
            this.btn_TrigA.Name = "btn_TrigA";
            this.btn_TrigA.Size = new System.Drawing.Size(50, 50);
            this.btn_TrigA.TabIndex = 67;
            this.btn_TrigA.Text = "Trig";
            this.btn_TrigA.UseVisualStyleBackColor = false;
            this.btn_TrigA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_TrigA_MouseDown);
            this.btn_TrigA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_TrigA_MouseUp);
            // 
            // tmt_Display
            // 
            this.tmt_Display.Enabled = true;
            this.tmt_Display.Tick += new System.EventHandler(this.tmt_Display_Tick);
            // 
            // frm_DispCore_DispSetup_HM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(642, 322);
            this.Controls.Add(this.btn_ModeB);
            this.Controls.Add(this.btn_TrigB);
            this.Controls.Add(this.btn_ModeA);
            this.Controls.Add(this.btn_TrigA);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_DispCore_DispSetup_HM";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_DispSetup_HM";
            this.Load += new System.EventHandler(this.frm_DispCore_DispSetup_HM_Load);
            this.VisibleChanged += new System.EventHandler(this.frm_DispCore_DispSetup_HM_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ModeB;
        private System.Windows.Forms.Button btn_TrigB;
        private System.Windows.Forms.Button btn_ModeA;
        private System.Windows.Forms.Button btn_TrigA;
        private System.Windows.Forms.Timer tmt_Display;
    }
}