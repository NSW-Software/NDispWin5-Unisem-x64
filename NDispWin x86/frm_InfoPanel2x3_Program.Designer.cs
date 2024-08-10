namespace DispCore
{
    partial class frm_InfoPanel2x3_Program
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Flowrate1 = new System.Windows.Forms.Label();
            this.lbl_Flowrate2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flowrate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Flowrate1
            // 
            this.lbl_Flowrate1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Flowrate1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Flowrate1.Location = new System.Drawing.Point(100, 0);
            this.lbl_Flowrate1.Name = "lbl_Flowrate1";
            this.lbl_Flowrate1.Size = new System.Drawing.Size(100, 23);
            this.lbl_Flowrate1.TabIndex = 1;
            this.lbl_Flowrate1.Text = "label2";
            this.lbl_Flowrate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Flowrate2
            // 
            this.lbl_Flowrate2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Flowrate2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Flowrate2.Location = new System.Drawing.Point(100, 23);
            this.lbl_Flowrate2.Name = "lbl_Flowrate2";
            this.lbl_Flowrate2.Size = new System.Drawing.Size(100, 23);
            this.lbl_Flowrate2.TabIndex = 3;
            this.lbl_Flowrate2.Text = "label3";
            this.lbl_Flowrate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Flowrate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Interval = 1000;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // frm_InfoPanel2x3_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 300);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Flowrate2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Flowrate1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_InfoPanel2x3_Program";
            this.Text = "frm_InfoPanel2x3_ProcessPara";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Flowrate1;
        private System.Windows.Forms.Label lbl_Flowrate2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmr_Display;
    }
}