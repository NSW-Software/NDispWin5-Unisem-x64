namespace NDispWin
{
    partial class frmDeviceConfigEditor
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
            this.tbox_IPAddress = new System.Windows.Forms.TextBox();
            this.l_lbl_Label = new System.Windows.Forms.Label();
            this.l_lbl_IPAddress = new System.Windows.Forms.Label();
            this.l_lbl_ID = new System.Windows.Forms.Label();
            this.combox_ID = new System.Windows.Forms.ComboBox();
            this.l_lbl_Type = new System.Windows.Forms.Label();
            this.combox_Type = new System.Windows.Forms.ComboBox();
            this.tbox_Label = new System.Windows.Forms.TextBox();
            this.tbox_Name = new System.Windows.Forms.TextBox();
            this.l_lbl_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_Cancel.Location = new System.Drawing.Point(172, 161);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 46;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.ForeColor = System.Drawing.Color.Navy;
            this.btn_OK.Location = new System.Drawing.Point(91, 161);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 45;
            this.btn_OK.Text = "OK";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tbox_IPAddress
            // 
            this.tbox_IPAddress.Location = new System.Drawing.Point(87, 67);
            this.tbox_IPAddress.Name = "tbox_IPAddress";
            this.tbox_IPAddress.Size = new System.Drawing.Size(160, 22);
            this.tbox_IPAddress.TabIndex = 44;
            // 
            // l_lbl_Label
            // 
            this.l_lbl_Label.AutoSize = true;
            this.l_lbl_Label.ForeColor = System.Drawing.Color.Navy;
            this.l_lbl_Label.Location = new System.Drawing.Point(8, 98);
            this.l_lbl_Label.Name = "l_lbl_Label";
            this.l_lbl_Label.Size = new System.Drawing.Size(39, 14);
            this.l_lbl_Label.TabIndex = 43;
            this.l_lbl_Label.Text = "Label";
            // 
            // l_lbl_IPAddress
            // 
            this.l_lbl_IPAddress.AutoSize = true;
            this.l_lbl_IPAddress.ForeColor = System.Drawing.Color.Navy;
            this.l_lbl_IPAddress.Location = new System.Drawing.Point(8, 70);
            this.l_lbl_IPAddress.Name = "l_lbl_IPAddress";
            this.l_lbl_IPAddress.Size = new System.Drawing.Size(73, 14);
            this.l_lbl_IPAddress.TabIndex = 42;
            this.l_lbl_IPAddress.Text = "IP Address";
            this.l_lbl_IPAddress.Click += new System.EventHandler(this.label3_Click);
            // 
            // l_lbl_ID
            // 
            this.l_lbl_ID.AutoSize = true;
            this.l_lbl_ID.ForeColor = System.Drawing.Color.Navy;
            this.l_lbl_ID.Location = new System.Drawing.Point(8, 42);
            this.l_lbl_ID.Name = "l_lbl_ID";
            this.l_lbl_ID.Size = new System.Drawing.Size(21, 14);
            this.l_lbl_ID.TabIndex = 40;
            this.l_lbl_ID.Text = "ID";
            // 
            // combox_ID
            // 
            this.combox_ID.FormattingEnabled = true;
            this.combox_ID.Location = new System.Drawing.Point(87, 39);
            this.combox_ID.Name = "combox_ID";
            this.combox_ID.Size = new System.Drawing.Size(160, 22);
            this.combox_ID.TabIndex = 39;
            this.combox_ID.SelectedIndexChanged += new System.EventHandler(this.combox_ID_SelectedIndexChanged);
            // 
            // l_lbl_Type
            // 
            this.l_lbl_Type.AutoSize = true;
            this.l_lbl_Type.ForeColor = System.Drawing.Color.Navy;
            this.l_lbl_Type.Location = new System.Drawing.Point(8, 14);
            this.l_lbl_Type.Name = "l_lbl_Type";
            this.l_lbl_Type.Size = new System.Drawing.Size(36, 14);
            this.l_lbl_Type.TabIndex = 38;
            this.l_lbl_Type.Text = "Type";
            // 
            // combox_Type
            // 
            this.combox_Type.FormattingEnabled = true;
            this.combox_Type.Location = new System.Drawing.Point(87, 11);
            this.combox_Type.Name = "combox_Type";
            this.combox_Type.Size = new System.Drawing.Size(160, 22);
            this.combox_Type.TabIndex = 37;
            this.combox_Type.SelectedIndexChanged += new System.EventHandler(this.combox_Type_SelectedIndexChanged);
            // 
            // tbox_Label
            // 
            this.tbox_Label.Location = new System.Drawing.Point(87, 95);
            this.tbox_Label.Name = "tbox_Label";
            this.tbox_Label.Size = new System.Drawing.Size(160, 22);
            this.tbox_Label.TabIndex = 47;
            // 
            // tbox_Name
            // 
            this.tbox_Name.Enabled = false;
            this.tbox_Name.Location = new System.Drawing.Point(87, 123);
            this.tbox_Name.Name = "tbox_Name";
            this.tbox_Name.Size = new System.Drawing.Size(160, 22);
            this.tbox_Name.TabIndex = 49;
            // 
            // l_lbl_Name
            // 
            this.l_lbl_Name.AutoSize = true;
            this.l_lbl_Name.ForeColor = System.Drawing.Color.Navy;
            this.l_lbl_Name.Location = new System.Drawing.Point(8, 126);
            this.l_lbl_Name.Name = "l_lbl_Name";
            this.l_lbl_Name.Size = new System.Drawing.Size(40, 14);
            this.l_lbl_Name.TabIndex = 48;
            this.l_lbl_Name.Text = "Name";
            // 
            // frmDeviceConfigEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.tbox_Name);
            this.Controls.Add(this.l_lbl_Name);
            this.Controls.Add(this.tbox_Label);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tbox_IPAddress);
            this.Controls.Add(this.l_lbl_Label);
            this.Controls.Add(this.l_lbl_IPAddress);
            this.Controls.Add(this.l_lbl_ID);
            this.Controls.Add(this.combox_ID);
            this.Controls.Add(this.l_lbl_Type);
            this.Controls.Add(this.combox_Type);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDeviceConfigEditor";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDeviceConfigEditor";
            this.Load += new System.EventHandler(this.frmDeviceConfigEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tbox_IPAddress;
        private System.Windows.Forms.Label l_lbl_Label;
        private System.Windows.Forms.Label l_lbl_IPAddress;
        private System.Windows.Forms.Label l_lbl_ID;
        private System.Windows.Forms.ComboBox combox_ID;
        private System.Windows.Forms.Label l_lbl_Type;
        private System.Windows.Forms.ComboBox combox_Type;
        private System.Windows.Forms.TextBox tbox_Label;
        private System.Windows.Forms.TextBox tbox_Name;
        private System.Windows.Forms.Label l_lbl_Name;
    }
}