namespace NDispWin
{
    partial class frm_DispCore_DispProg_ModelList
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
            this.lv_Model = new System.Windows.Forms.ListView();
            this.btn_Basic = new System.Windows.Forms.Button();
            this.btn_Advance = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lv_No = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FirstGapWait = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PanelGap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Model
            // 
            this.lv_Model.FullRowSelect = true;
            this.lv_Model.GridLines = true;
            this.lv_Model.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_Model.HideSelection = false;
            this.lv_Model.Location = new System.Drawing.Point(43, 50);
            this.lv_Model.Name = "lv_Model";
            this.lv_Model.Size = new System.Drawing.Size(646, 387);
            this.lv_Model.TabIndex = 30;
            this.lv_Model.UseCompatibleStateImageBehavior = false;
            this.lv_Model.View = System.Windows.Forms.View.Details;
            this.lv_Model.SelectedIndexChanged += new System.EventHandler(this.lv_Model_SelectedIndexChanged);
            this.lv_Model.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_Model_MouseClick);
            // 
            // btn_Basic
            // 
            this.btn_Basic.AccessibleDescription = "Basic";
            this.btn_Basic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Basic.Location = new System.Drawing.Point(8, 8);
            this.btn_Basic.Name = "btn_Basic";
            this.btn_Basic.Size = new System.Drawing.Size(100, 36);
            this.btn_Basic.TabIndex = 32;
            this.btn_Basic.Text = "Basic";
            this.btn_Basic.UseVisualStyleBackColor = true;
            this.btn_Basic.Click += new System.EventHandler(this.btn_Basic_Click);
            // 
            // btn_Advance
            // 
            this.btn_Advance.AccessibleDescription = "Advance";
            this.btn_Advance.Location = new System.Drawing.Point(114, 8);
            this.btn_Advance.Name = "btn_Advance";
            this.btn_Advance.Size = new System.Drawing.Size(100, 36);
            this.btn_Advance.TabIndex = 33;
            this.btn_Advance.Text = "Advance";
            this.btn_Advance.UseVisualStyleBackColor = true;
            this.btn_Advance.Click += new System.EventHandler(this.btn_Advance_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(483, 494);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_Cancel.TabIndex = 34;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lv_No
            // 
            this.lv_No.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_No.HideSelection = false;
            this.lv_No.Location = new System.Drawing.Point(8, 50);
            this.lv_No.Name = "lv_No";
            this.lv_No.Size = new System.Drawing.Size(38, 387);
            this.lv_No.TabIndex = 37;
            this.lv_No.UseCompatibleStateImageBehavior = false;
            this.lv_No.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Common";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_FirstGapWait);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_PanelGap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox1.Size = new System.Drawing.Size(244, 91);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Common";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(112, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "(ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(112, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "(mm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FirstGapWait
            // 
            this.lbl_FirstGapWait.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_FirstGapWait.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FirstGapWait.ForeColor = System.Drawing.Color.Navy;
            this.lbl_FirstGapWait.Location = new System.Drawing.Point(166, 47);
            this.lbl_FirstGapWait.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_FirstGapWait.Name = "lbl_FirstGapWait";
            this.lbl_FirstGapWait.Size = new System.Drawing.Size(73, 23);
            this.lbl_FirstGapWait.TabIndex = 4;
            this.lbl_FirstGapWait.Text = "10.000";
            this.lbl_FirstGapWait.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_FirstGapWait.Click += new System.EventHandler(this.lbl_FirstGapWait_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "First Gap Wait (ms)";
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "First Gap Wait";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PanelGap
            // 
            this.lbl_PanelGap.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_PanelGap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PanelGap.ForeColor = System.Drawing.Color.Navy;
            this.lbl_PanelGap.Location = new System.Drawing.Point(166, 20);
            this.lbl_PanelGap.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_PanelGap.Name = "lbl_PanelGap";
            this.lbl_PanelGap.Size = new System.Drawing.Size(73, 23);
            this.lbl_PanelGap.TabIndex = 2;
            this.lbl_PanelGap.Text = "10.000";
            this.lbl_PanelGap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PanelGap.Click += new System.EventHandler(this.lbl_PanelGap_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Cluster Gap";
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cluster Gap";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(377, 494);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 36);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(589, 494);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 36);
            this.btn_Close.TabIndex = 40;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.AccessibleDescription = "Setting";
            this.btn_Setting.Location = new System.Drawing.Point(589, 8);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(100, 36);
            this.btn_Setting.TabIndex = 41;
            this.btn_Setting.Text = "Setting";
            this.btn_Setting.UseVisualStyleBackColor = true;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // frm_DispCore_DispProg_ModelList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(702, 544);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_No);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Advance);
            this.Controls.Add(this.btn_Basic);
            this.Controls.Add(this.lv_Model);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_ModelList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model List ";
            this.Load += new System.EventHandler(this.frmDispProg_Model_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Model;
        private System.Windows.Forms.Button btn_Basic;
        private System.Windows.Forms.Button btn_Advance;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListView lv_No;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_PanelGap;
        private System.Windows.Forms.Button btn_Setting;
        private System.Windows.Forms.Label lbl_FirstGapWait;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}