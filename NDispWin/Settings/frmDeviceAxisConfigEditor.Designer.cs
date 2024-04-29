namespace NDispWin
{
    partial class frmDeviceAxisConfigEditor
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
            this.tbox_Label = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combox_Mask = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combox_Device = new System.Windows.Forms.ComboBox();
            this.combox_MotorNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_Cancel.Location = new System.Drawing.Point(168, 134);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 46;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.ForeColor = System.Drawing.Color.Navy;
            this.btn_OK.Location = new System.Drawing.Point(87, 134);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 45;
            this.btn_OK.Text = "OK";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tbox_Label
            // 
            this.tbox_Label.Location = new System.Drawing.Point(83, 96);
            this.tbox_Label.Name = "tbox_Label";
            this.tbox_Label.Size = new System.Drawing.Size(160, 22);
            this.tbox_Label.TabIndex = 44;
            this.tbox_Label.TextChanged += new System.EventHandler(this.tbox_Label_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(8, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 43;
            this.label4.Text = "Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "Mask";
            // 
            // combox_Mask
            // 
            this.combox_Mask.FormattingEnabled = true;
            this.combox_Mask.Location = new System.Drawing.Point(83, 68);
            this.combox_Mask.Name = "combox_Mask";
            this.combox_Mask.Size = new System.Drawing.Size(160, 22);
            this.combox_Mask.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "Device";
            // 
            // combox_Device
            // 
            this.combox_Device.FormattingEnabled = true;
            this.combox_Device.Location = new System.Drawing.Point(83, 12);
            this.combox_Device.Name = "combox_Device";
            this.combox_Device.Size = new System.Drawing.Size(160, 22);
            this.combox_Device.TabIndex = 37;
            this.combox_Device.SelectedIndexChanged += new System.EventHandler(this.combox_Device_SelectedIndexChanged);
            // 
            // combox_MotorNo
            // 
            this.combox_MotorNo.FormattingEnabled = true;
            this.combox_MotorNo.Location = new System.Drawing.Point(83, 40);
            this.combox_MotorNo.Name = "combox_MotorNo";
            this.combox_MotorNo.Size = new System.Drawing.Size(160, 22);
            this.combox_MotorNo.TabIndex = 47;
            this.combox_MotorNo.SelectionChangeCommitted += new System.EventHandler(this.combox_MotorNo_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(8, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 14);
            this.label6.TabIndex = 48;
            this.label6.Text = "Motor No";
            // 
            // frmDeviceAxisConfigEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(287, 191);
            this.ControlBox = false;
            this.Controls.Add(this.combox_MotorNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tbox_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combox_Mask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combox_Device);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDeviceAxisConfigEditor";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDeviceAxisConfigEditor";
            this.Load += new System.EventHandler(this.frmDeviceAxisConfigEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tbox_Label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combox_Mask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combox_Device;
        private System.Windows.Forms.ComboBox combox_MotorNo;
        private System.Windows.Forms.Label label6;
    }
}