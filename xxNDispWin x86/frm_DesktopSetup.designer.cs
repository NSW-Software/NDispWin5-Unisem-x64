namespace NDispWin
{
    partial class frm_DesktopSetup
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
            this.cbox_CycleRun = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Jog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.lblLoadPos = new System.Windows.Forms.Label();
            this.combox_NumberOfStations = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbox_CycleRun
            // 
            this.cbox_CycleRun.AccessibleDescription = "CYCLE RUN";
            this.cbox_CycleRun.AutoSize = true;
            this.cbox_CycleRun.Location = new System.Drawing.Point(121, 45);
            this.cbox_CycleRun.Name = "cbox_CycleRun";
            this.cbox_CycleRun.Size = new System.Drawing.Size(88, 18);
            this.cbox_CycleRun.TabIndex = 101;
            this.cbox_CycleRun.Text = "CYCLE RUN";
            this.cbox_CycleRun.UseVisualStyleBackColor = true;
            this.cbox_CycleRun.Visible = false;
            this.cbox_CycleRun.Click += new System.EventHandler(this.cbox_CycleRun_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Number Of Station";
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 31);
            this.label4.TabIndex = 100;
            this.label4.Text = "Number Of Station";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // btn_Jog
            // 
            this.btn_Jog.AccessibleDescription = "Jog";
            this.btn_Jog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Jog.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Jog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Jog.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_Jog.FlatAppearance.BorderSize = 2;
            this.btn_Jog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_Jog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btn_Jog.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Jog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Jog.Location = new System.Drawing.Point(375, 89);
            this.btn_Jog.Name = "btn_Jog";
            this.btn_Jog.Size = new System.Drawing.Size(75, 30);
            this.btn_Jog.TabIndex = 99;
            this.btn_Jog.Text = "Jog";
            this.btn_Jog.UseVisualStyleBackColor = true;
            this.btn_Jog.Click += new System.EventHandler(this.btn_Jog_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Loading Pos";
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 97;
            this.label3.Text = "Loading Pos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoto
            // 
            this.btnGoto.AccessibleDescription = "Goto ";
            this.btnGoto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGoto.BackColor = System.Drawing.SystemColors.Control;
            this.btnGoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGoto.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGoto.FlatAppearance.BorderSize = 2;
            this.btnGoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnGoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnGoto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGoto.Location = new System.Drawing.Point(456, 8);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 30);
            this.btnGoto.TabIndex = 96;
            this.btnGoto.Text = "Goto ";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btn_Goto_Click);
            // 
            // btnSet
            // 
            this.btnSet.AccessibleDescription = "Set";
            this.btnSet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSet.BackColor = System.Drawing.SystemColors.Control;
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSet.FlatAppearance.BorderSize = 2;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSet.Location = new System.Drawing.Point(375, 8);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 30);
            this.btnSet.TabIndex = 95;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // lblLoadPos
            // 
            this.lblLoadPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoadPos.Location = new System.Drawing.Point(114, 8);
            this.lblLoadPos.Margin = new System.Windows.Forms.Padding(3);
            this.lblLoadPos.Name = "lblLoadPos";
            this.lblLoadPos.Size = new System.Drawing.Size(255, 30);
            this.lblLoadPos.TabIndex = 94;
            this.lblLoadPos.Text = "---";
            this.lblLoadPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combox_NumberOfStations
            // 
            this.combox_NumberOfStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_NumberOfStations.FormattingEnabled = true;
            this.combox_NumberOfStations.Location = new System.Drawing.Point(116, 67);
            this.combox_NumberOfStations.Name = "combox_NumberOfStations";
            this.combox_NumberOfStations.Size = new System.Drawing.Size(220, 22);
            this.combox_NumberOfStations.TabIndex = 14;
            this.combox_NumberOfStations.Visible = false;
            this.combox_NumberOfStations.SelectionChangeCommitted += new System.EventHandler(this.combox_NumberOfStations_SelectionChangeCommitted);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "Jog";
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(456, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frm_DesktopSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(540, 128);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_Jog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combox_NumberOfStations);
            this.Controls.Add(this.cbox_CycleRun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLoadPos);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnSet);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_DesktopSetup";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frm_DesktopSetup";
            this.Load += new System.EventHandler(this.frm_DesktopSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbox_CycleRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Jog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label lblLoadPos;
        private System.Windows.Forms.ComboBox combox_NumberOfStations;
        private System.Windows.Forms.Button btnClose;
    }
}