namespace NDispWin
{
    partial class frm_DispCore_DispProg_VolumeMap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_CurrentRef = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_AdjType = new System.Windows.Forms.Label();
            this.lbl_RefType = new System.Windows.Forms.Label();
            this.lbl_Method = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_RefPoint = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_RefCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Value = new System.Windows.Forms.Label();
            this.lview_Table = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.gbox_Rate = new System.Windows.Forms.GroupBox();
            this.gbox_Trend = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbox_Rate.SuspendLayout();
            this.gbox_Trend.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbl_CurrentRef);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_AdjType);
            this.panel1.Controls.Add(this.lbl_RefType);
            this.panel1.Controls.Add(this.lbl_Method);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(430, 91);
            this.panel1.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Current Ref";
            this.label6.Location = new System.Drawing.Point(244, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 133;
            this.label6.Text = "Current Ref";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CurrentRef
            // 
            this.lbl_CurrentRef.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CurrentRef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentRef.Location = new System.Drawing.Point(348, 7);
            this.lbl_CurrentRef.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrentRef.Name = "lbl_CurrentRef";
            this.lbl_CurrentRef.Size = new System.Drawing.Size(75, 23);
            this.lbl_CurrentRef.TabIndex = 134;
            this.lbl_CurrentRef.Text = "lbl_CurrentRef";
            this.lbl_CurrentRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Method";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Reference";
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Reference";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Adjust Type";
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Adjust Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AdjType
            // 
            this.lbl_AdjType.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_AdjType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_AdjType.Location = new System.Drawing.Point(111, 61);
            this.lbl_AdjType.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_AdjType.Name = "lbl_AdjType";
            this.lbl_AdjType.Size = new System.Drawing.Size(75, 23);
            this.lbl_AdjType.TabIndex = 112;
            this.lbl_AdjType.Text = "lbl_AdjType";
            this.lbl_AdjType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_AdjType.Click += new System.EventHandler(this.lbl_AdjType_Click);
            // 
            // lbl_RefType
            // 
            this.lbl_RefType.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_RefType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RefType.Location = new System.Drawing.Point(111, 34);
            this.lbl_RefType.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_RefType.Name = "lbl_RefType";
            this.lbl_RefType.Size = new System.Drawing.Size(75, 23);
            this.lbl_RefType.TabIndex = 113;
            this.lbl_RefType.Text = "lbl_RefType";
            this.lbl_RefType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_RefType.Click += new System.EventHandler(this.lbl_Reference_Click);
            // 
            // lbl_Method
            // 
            this.lbl_Method.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Method.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Method.Location = new System.Drawing.Point(111, 7);
            this.lbl_Method.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Method.Name = "lbl_Method";
            this.lbl_Method.Size = new System.Drawing.Size(75, 23);
            this.lbl_Method.TabIndex = 114;
            this.lbl_Method.Text = "lbl_Method";
            this.lbl_Method.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Method.Click += new System.EventHandler(this.lbl_Method_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Ref Pt (Count)";
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 135;
            this.label7.Text = "Ref Pt (Count)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_RefPoint
            // 
            this.lbl_RefPoint.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_RefPoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RefPoint.Location = new System.Drawing.Point(111, 20);
            this.lbl_RefPoint.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_RefPoint.Name = "lbl_RefPoint";
            this.lbl_RefPoint.Size = new System.Drawing.Size(75, 23);
            this.lbl_RefPoint.TabIndex = 136;
            this.lbl_RefPoint.Text = "lbl_Point";
            this.lbl_RefPoint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_RefPoint.Click += new System.EventHandler(this.lbl_RefPoint_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Ref (Count)";
            this.label5.Location = new System.Drawing.Point(5, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 133;
            this.label5.Text = "Ref (Count)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_RefCount
            // 
            this.lbl_RefCount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_RefCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RefCount.Location = new System.Drawing.Point(109, 20);
            this.lbl_RefCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_RefCount.Name = "lbl_RefCount";
            this.lbl_RefCount.Size = new System.Drawing.Size(75, 23);
            this.lbl_RefCount.TabIndex = 134;
            this.lbl_RefCount.Text = "lbl_RefCount";
            this.lbl_RefCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_RefCount.Click += new System.EventHandler(this.lbl_RefCount_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Value";
            this.label4.Location = new System.Drawing.Point(244, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 131;
            this.label4.Text = "Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Value
            // 
            this.lbl_Value.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Value.Location = new System.Drawing.Point(348, 20);
            this.lbl_Value.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Value.Name = "lbl_Value";
            this.lbl_Value.Size = new System.Drawing.Size(75, 23);
            this.lbl_Value.TabIndex = 132;
            this.lbl_Value.Text = "lbl_Value";
            this.lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Value.Click += new System.EventHandler(this.lbl_Value_Click);
            // 
            // lview_Table
            // 
            this.lview_Table.ForeColor = System.Drawing.Color.Navy;
            this.lview_Table.GridLines = true;
            this.lview_Table.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lview_Table.HideSelection = false;
            this.lview_Table.Location = new System.Drawing.Point(6, 48);
            this.lview_Table.MultiSelect = false;
            this.lview_Table.Name = "lview_Table";
            this.lview_Table.Size = new System.Drawing.Size(417, 277);
            this.lview_Table.TabIndex = 138;
            this.lview_Table.UseCompatibleStateImageBehavior = false;
            this.lview_Table.View = System.Windows.Forms.View.Details;
            this.lview_Table.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lview_Table_MouseClick);
            this.lview_Table.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lview_Table_MouseDown);
            this.lview_Table.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lview_Table_MouseUp);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(8, 537);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(430, 50);
            this.panel2.TabIndex = 139;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(348, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 101;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(269, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // gbox_Rate
            // 
            this.gbox_Rate.AccessibleDescription = "Volume Map Rate";
            this.gbox_Rate.AutoSize = true;
            this.gbox_Rate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Rate.Controls.Add(this.label5);
            this.gbox_Rate.Controls.Add(this.lbl_RefCount);
            this.gbox_Rate.Controls.Add(this.label4);
            this.gbox_Rate.Controls.Add(this.lbl_Value);
            this.gbox_Rate.Location = new System.Drawing.Point(8, 105);
            this.gbox_Rate.Name = "gbox_Rate";
            this.gbox_Rate.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_Rate.Size = new System.Drawing.Size(428, 60);
            this.gbox_Rate.TabIndex = 140;
            this.gbox_Rate.TabStop = false;
            this.gbox_Rate.Text = "Volume Map Rate";
            // 
            // gbox_Trend
            // 
            this.gbox_Trend.AutoSize = true;
            this.gbox_Trend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Trend.Controls.Add(this.label8);
            this.gbox_Trend.Controls.Add(this.lview_Table);
            this.gbox_Trend.Controls.Add(this.label7);
            this.gbox_Trend.Controls.Add(this.lbl_RefPoint);
            this.gbox_Trend.Location = new System.Drawing.Point(7, 171);
            this.gbox_Trend.Name = "gbox_Trend";
            this.gbox_Trend.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_Trend.Size = new System.Drawing.Size(429, 343);
            this.gbox_Trend.TabIndex = 141;
            this.gbox_Trend.TabStop = false;
            this.gbox_Trend.Text = "Volume Map Trend";
            this.gbox_Trend.Enter += new System.EventHandler(this.gbox_Trend_Enter);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.Location = new System.Drawing.Point(190, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 23);
            this.label8.TabIndex = 139;
            this.label8.Text = "*Value is Absolute Offset";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispProg_VolumeMap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(444, 624);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbox_Trend);
            this.Controls.Add(this.gbox_Rate);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_VolumeMap";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_VolumeMap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_VolumeMap_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_VolumeMap_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbox_Rate.ResumeLayout(false);
            this.gbox_Trend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_AdjType;
        private System.Windows.Forms.Label lbl_RefType;
        private System.Windows.Forms.Label lbl_Method;
        private System.Windows.Forms.ListView lview_Table;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_RefCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_RefPoint;
        private System.Windows.Forms.GroupBox gbox_Rate;
        private System.Windows.Forms.GroupBox gbox_Trend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_CurrentRef;
        private System.Windows.Forms.Label label8;
    }
}