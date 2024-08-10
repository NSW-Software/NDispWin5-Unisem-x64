namespace NDispWin
{
    partial class frmDispProgGroupDisp
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
            this.l_lbl_HeadNo = new System.Windows.Forms.Label();
            this.lblHeadNo = new System.Windows.Forms.Label();
            this.l_lbl_ModelNo = new System.Windows.Forms.Label();
            this.lblModelNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.cbEnableWeight = new System.Windows.Forms.CheckBox();
            this.lvCmdList = new System.Windows.Forms.ListView();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCutTailType = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCutTailHeight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCutTailSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCutTailLength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEditModel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_lbl_HeadNo
            // 
            this.l_lbl_HeadNo.AccessibleDescription = "Head No";
            this.l_lbl_HeadNo.Location = new System.Drawing.Point(7, 7);
            this.l_lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_HeadNo.Name = "l_lbl_HeadNo";
            this.l_lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.l_lbl_HeadNo.TabIndex = 112;
            this.l_lbl_HeadNo.Text = "Head No";
            this.l_lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeadNo
            // 
            this.lblHeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lblHeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHeadNo.Location = new System.Drawing.Point(86, 7);
            this.lblHeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblHeadNo.Name = "lblHeadNo";
            this.lblHeadNo.Size = new System.Drawing.Size(75, 23);
            this.lblHeadNo.TabIndex = 113;
            this.lblHeadNo.Text = "lblHeadNo";
            this.lblHeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeadNo.Click += new System.EventHandler(this.lblHeadNo_Click);
            // 
            // l_lbl_ModelNo
            // 
            this.l_lbl_ModelNo.AccessibleDescription = "Model No";
            this.l_lbl_ModelNo.Location = new System.Drawing.Point(7, 34);
            this.l_lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_ModelNo.Name = "l_lbl_ModelNo";
            this.l_lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.l_lbl_ModelNo.TabIndex = 114;
            this.l_lbl_ModelNo.Text = "Model No";
            this.l_lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelNo
            // 
            this.lblModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lblModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblModelNo.Location = new System.Drawing.Point(86, 34);
            this.lblModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblModelNo.Name = "lblModelNo";
            this.lblModelNo.Size = new System.Drawing.Size(75, 23);
            this.lblModelNo.TabIndex = 115;
            this.lblModelNo.Text = "lblModelNo";
            this.lblModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblModelNo.Click += new System.EventHandler(this.lblModelNo_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Location = new System.Drawing.Point(266, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 121;
            this.label1.Text = "(mg)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWeight
            // 
            this.lblWeight.BackColor = System.Drawing.SystemColors.Window;
            this.lblWeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeight.Location = new System.Drawing.Point(345, 7);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(75, 23);
            this.lblWeight.TabIndex = 122;
            this.lblWeight.Text = "Weight";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWeight.Click += new System.EventHandler(this.lblWeight_Click);
            // 
            // cbEnableWeight
            // 
            this.cbEnableWeight.AutoSize = true;
            this.cbEnableWeight.Location = new System.Drawing.Point(196, 10);
            this.cbEnableWeight.Name = "cbEnableWeight";
            this.cbEnableWeight.Size = new System.Drawing.Size(90, 18);
            this.cbEnableWeight.TabIndex = 123;
            this.cbEnableWeight.Text = "Use Weight";
            this.cbEnableWeight.UseVisualStyleBackColor = true;
            this.cbEnableWeight.Click += new System.EventHandler(this.cbTotalWeight_Click);
            this.cbEnableWeight.MouseHover += new System.EventHandler(this.cbEnableWeight_MouseHover);
            // 
            // lvCmdList
            // 
            this.lvCmdList.FullRowSelect = true;
            this.lvCmdList.GridLines = true;
            this.lvCmdList.HideSelection = false;
            this.lvCmdList.Location = new System.Drawing.Point(8, 104);
            this.lvCmdList.Name = "lvCmdList";
            this.lvCmdList.Size = new System.Drawing.Size(412, 321);
            this.lvCmdList.TabIndex = 124;
            this.lvCmdList.UseCompatibleStateImageBehavior = false;
            this.lvCmdList.View = System.Windows.Forms.View.Details;
            this.lvCmdList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCmdList_MouseDown);
            this.lvCmdList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvCmdList_MouseUp);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(264, 75);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 125;
            this.btnMoveUp.Text = "Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDn
            // 
            this.btnMoveDn.Location = new System.Drawing.Point(345, 75);
            this.btnMoveDn.Name = "btnMoveDn";
            this.btnMoveDn.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDn.TabIndex = 126;
            this.btnMoveDn.Text = "Dn";
            this.btnMoveDn.UseVisualStyleBackColor = true;
            this.btnMoveDn.Click += new System.EventHandler(this.btnMoveDn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lblCutTailType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblCutTailHeight);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblCutTailSpeed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCutTailLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 90);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CutTail";
            // 
            // lblCutTailType
            // 
            this.lblCutTailType.BackColor = System.Drawing.SystemColors.Window;
            this.lblCutTailType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutTailType.Location = new System.Drawing.Point(332, 47);
            this.lblCutTailType.Margin = new System.Windows.Forms.Padding(2);
            this.lblCutTailType.Name = "lblCutTailType";
            this.lblCutTailType.Size = new System.Drawing.Size(75, 23);
            this.lblCutTailType.TabIndex = 135;
            this.lblCutTailType.Text = "-999.999";
            this.lblCutTailType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCutTailType.Click += new System.EventHandler(this.lblCutTailType_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.Location = new System.Drawing.Point(208, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 23);
            this.label10.TabIndex = 134;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCutTailHeight
            // 
            this.lblCutTailHeight.BackColor = System.Drawing.SystemColors.Window;
            this.lblCutTailHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutTailHeight.Location = new System.Drawing.Point(332, 20);
            this.lblCutTailHeight.Margin = new System.Windows.Forms.Padding(2);
            this.lblCutTailHeight.Name = "lblCutTailHeight";
            this.lblCutTailHeight.Size = new System.Drawing.Size(75, 23);
            this.lblCutTailHeight.TabIndex = 133;
            this.lblCutTailHeight.Text = "-999.999";
            this.lblCutTailHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCutTailHeight.Click += new System.EventHandler(this.lblCutTailHeight_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.Location = new System.Drawing.Point(208, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 132;
            this.label8.Text = "Height (mm)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCutTailSpeed
            // 
            this.lblCutTailSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.lblCutTailSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutTailSpeed.Location = new System.Drawing.Point(129, 47);
            this.lblCutTailSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.lblCutTailSpeed.Name = "lblCutTailSpeed";
            this.lblCutTailSpeed.Size = new System.Drawing.Size(75, 23);
            this.lblCutTailSpeed.TabIndex = 131;
            this.lblCutTailSpeed.Text = "-999.999";
            this.lblCutTailSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCutTailSpeed.Click += new System.EventHandler(this.lblCutTailSpeed_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(5, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 130;
            this.label6.Text = "Speed (mm/2)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCutTailLength
            // 
            this.lblCutTailLength.BackColor = System.Drawing.SystemColors.Window;
            this.lblCutTailLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutTailLength.Location = new System.Drawing.Point(129, 20);
            this.lblCutTailLength.Margin = new System.Windows.Forms.Padding(2);
            this.lblCutTailLength.Name = "lblCutTailLength";
            this.lblCutTailLength.Size = new System.Drawing.Size(75, 23);
            this.lblCutTailLength.TabIndex = 129;
            this.lblCutTailLength.Text = "-999.999";
            this.lblCutTailLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCutTailLength.Click += new System.EventHandler(this.lblCutTailLength_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 128;
            this.label4.Text = "Length (mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(345, 526);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 129;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(266, 526);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 128;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 130;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditModel
            // 
            this.btnEditModel.AccessibleDescription = "Edit";
            this.btnEditModel.Location = new System.Drawing.Point(165, 34);
            this.btnEditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditModel.Name = "btnEditModel";
            this.btnEditModel.Size = new System.Drawing.Size(75, 23);
            this.btnEditModel.TabIndex = 131;
            this.btnEditModel.Text = "Edit";
            this.btnEditModel.UseVisualStyleBackColor = true;
            this.btnEditModel.Click += new System.EventHandler(this.btnEditModel_Click);
            // 
            // frmDispProgGroupDisp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(439, 582);
            this.ControlBox = false;
            this.Controls.Add(this.btnEditModel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveDn);
            this.Controls.Add(this.lvCmdList);
            this.Controls.Add(this.cbEnableWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.l_lbl_ModelNo);
            this.Controls.Add(this.lblModelNo);
            this.Controls.Add(this.l_lbl_HeadNo);
            this.Controls.Add(this.lblHeadNo);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDispProgGroupDisp";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProgGroupDisp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDispProgGroupDisp_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDispProgGroupDisp_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProgGroupDisp_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_lbl_HeadNo;
        private System.Windows.Forms.Label lblHeadNo;
        private System.Windows.Forms.Label l_lbl_ModelNo;
        private System.Windows.Forms.Label lblModelNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.CheckBox cbEnableWeight;
        private System.Windows.Forms.ListView lvCmdList;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCutTailType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCutTailHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCutTailSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCutTailLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditModel;
    }
}