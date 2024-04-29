namespace NDispWin
{
    partial class frm_DispCore_DispProg_WeightCal
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Exec = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.lbox_Cond = new System.Windows.Forms.ListBox();
            this.btn_Cond = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(170, 144);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 30);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(94, 144);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(70, 30);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Exec
            // 
            this.btn_Exec.AccessibleDescription = "Exec";
            this.btn_Exec.Location = new System.Drawing.Point(6, 144);
            this.btn_Exec.Name = "btn_Exec";
            this.btn_Exec.Size = new System.Drawing.Size(70, 30);
            this.btn_Exec.TabIndex = 13;
            this.btn_Exec.Text = "Exec";
            this.btn_Exec.UseVisualStyleBackColor = true;
            this.btn_Exec.Click += new System.EventHandler(this.btn_Exec_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.AccessibleDescription = "Setting";
            this.btn_Setting.Location = new System.Drawing.Point(6, 108);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(70, 30);
            this.btn_Setting.TabIndex = 14;
            this.btn_Setting.Text = "Setting";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // lbox_Cond
            // 
            this.lbox_Cond.FormattingEnabled = true;
            this.lbox_Cond.ItemHeight = 14;
            this.lbox_Cond.Location = new System.Drawing.Point(6, 6);
            this.lbox_Cond.Name = "lbox_Cond";
            this.lbox_Cond.Size = new System.Drawing.Size(234, 46);
            this.lbox_Cond.TabIndex = 46;
            // 
            // btn_Cond
            // 
            this.btn_Cond.AccessibleDescription = "Cond";
            this.btn_Cond.Location = new System.Drawing.Point(165, 57);
            this.btn_Cond.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cond.Name = "btn_Cond";
            this.btn_Cond.Size = new System.Drawing.Size(75, 36);
            this.btn_Cond.TabIndex = 45;
            this.btn_Cond.Text = "Cond";
            this.btn_Cond.UseVisualStyleBackColor = true;
            this.btn_Cond.Click += new System.EventHandler(this.btn_Cond_Click);
            // 
            // frm_DispCore_DispProg_WeightCal
            // 
            this.AccessibleDescription = "";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(258, 191);
            this.ControlBox = false;
            this.Controls.Add(this.lbox_Cond);
            this.Controls.Add(this.btn_Cond);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.btn_Exec);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_WeightCal";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispProg_WeightCal";
            this.Load += new System.EventHandler(this.frm_DispProg_WeightCal_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Exec;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.ListBox lbox_Cond;
        private System.Windows.Forms.Button btn_Cond;
    }
}