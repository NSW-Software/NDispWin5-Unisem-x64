namespace NDispWin
{
    partial class frm_DispCore_DispProg_Dot
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
            this.label3 = new System.Windows.Forms.Label();
            this.gbox_Pos = new System.Windows.Forms.GroupBox();
            this.cbAddNew = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btn_EditXY = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Y1 = new System.Windows.Forms.Label();
            this.lbl_X1 = new System.Windows.Forms.Label();
            this.btn_SetXY = new System.Windows.Forms.Button();
            this.btn_GotoXY = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.lbl_PreMoveZ = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_gbox_Weight = new System.Windows.Forms.GroupBox();
            this.lbl_TrigTime = new System.Windows.Forms.Label();
            this.btn_Trig = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Dispense = new System.Windows.Forms.Label();
            this._lbl_Dispense = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_UnitRC = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Help = new System.Windows.Forms.Button();
            this.gbox_Pos.SuspendLayout();
            this.gbxOptions.SuspendLayout();
            this.l_gbox_Weight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Head No";
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Head No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbox_Pos
            // 
            this.gbox_Pos.AccessibleDescription = "Position";
            this.gbox_Pos.AutoSize = true;
            this.gbox_Pos.Controls.Add(this.cbAddNew);
            this.gbox_Pos.Controls.Add(this.btnAddNew);
            this.gbox_Pos.Controls.Add(this.btn_EditXY);
            this.gbox_Pos.Controls.Add(this.label6);
            this.gbox_Pos.Controls.Add(this.lbl_Y1);
            this.gbox_Pos.Controls.Add(this.lbl_X1);
            this.gbox_Pos.Controls.Add(this.btn_SetXY);
            this.gbox_Pos.Controls.Add(this.btn_GotoXY);
            this.gbox_Pos.Controls.Add(this.label5);
            this.gbox_Pos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbox_Pos.Location = new System.Drawing.Point(5, 96);
            this.gbox_Pos.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Pos.Name = "gbox_Pos";
            this.gbox_Pos.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Pos.Size = new System.Drawing.Size(479, 107);
            this.gbox_Pos.TabIndex = 13;
            this.gbox_Pos.TabStop = false;
            this.gbox_Pos.Text = "Position";
            this.gbox_Pos.Enter += new System.EventHandler(this.gbox_Pos_Enter);
            // 
            // cbAddNew
            // 
            this.cbAddNew.AccessibleDescription = "Add New";
            this.cbAddNew.AutoSize = true;
            this.cbAddNew.Location = new System.Drawing.Point(322, 63);
            this.cbAddNew.Name = "cbAddNew";
            this.cbAddNew.Size = new System.Drawing.Size(88, 22);
            this.cbAddNew.TabIndex = 133;
            this.cbAddNew.Text = "Add New";
            this.cbAddNew.UseVisualStyleBackColor = true;
            this.cbAddNew.Click += new System.EventHandler(this.cbAddNew_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AccessibleDescription = "Add New";
            this.btnAddNew.Location = new System.Drawing.Point(404, 56);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(70, 30);
            this.btnAddNew.TabIndex = 133;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Visible = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btn_EditXY
            // 
            this.btn_EditXY.AccessibleDescription = "";
            this.btn_EditXY.Location = new System.Drawing.Point(299, 22);
            this.btn_EditXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditXY.Name = "btn_EditXY";
            this.btn_EditXY.Size = new System.Drawing.Size(27, 30);
            this.btn_EditXY.TabIndex = 130;
            this.btn_EditXY.Text = "...";
            this.btn_EditXY.UseVisualStyleBackColor = true;
            this.btn_EditXY.Click += new System.EventHandler(this.btn_EditXY_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Position";
            this.label6.Location = new System.Drawing.Point(8, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 133;
            this.label6.Text = "Position";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Y1
            // 
            this.lbl_Y1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y1.Location = new System.Drawing.Point(230, 26);
            this.lbl_Y1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y1.Name = "lbl_Y1";
            this.lbl_Y1.Size = new System.Drawing.Size(65, 23);
            this.lbl_Y1.TabIndex = 110;
            this.lbl_Y1.Text = "-999.999";
            this.lbl_Y1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y1.Click += new System.EventHandler(this.lbl_Y1_Click);
            // 
            // lbl_X1
            // 
            this.lbl_X1.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X1.Location = new System.Drawing.Point(161, 26);
            this.lbl_X1.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X1.Name = "lbl_X1";
            this.lbl_X1.Size = new System.Drawing.Size(65, 23);
            this.lbl_X1.TabIndex = 109;
            this.lbl_X1.Text = "-999.999";
            this.lbl_X1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X1.Click += new System.EventHandler(this.lbl_X1_Click);
            // 
            // btn_SetXY
            // 
            this.btn_SetXY.AccessibleDescription = "Set";
            this.btn_SetXY.Location = new System.Drawing.Point(330, 22);
            this.btn_SetXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetXY.Name = "btn_SetXY";
            this.btn_SetXY.Size = new System.Drawing.Size(70, 30);
            this.btn_SetXY.TabIndex = 7;
            this.btn_SetXY.Text = "Set";
            this.btn_SetXY.UseVisualStyleBackColor = true;
            this.btn_SetXY.Click += new System.EventHandler(this.btn_SetXY_Click);
            // 
            // btn_GotoXY
            // 
            this.btn_GotoXY.AccessibleDescription = "Goto";
            this.btn_GotoXY.Location = new System.Drawing.Point(404, 22);
            this.btn_GotoXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoXY.Name = "btn_GotoXY";
            this.btn_GotoXY.Size = new System.Drawing.Size(70, 30);
            this.btn_GotoXY.TabIndex = 8;
            this.btn_GotoXY.Text = "Goto";
            this.btn_GotoXY.UseVisualStyleBackColor = true;
            this.btn_GotoXY.Click += new System.EventHandler(this.btn_GotoXY_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(117, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "(mm)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(398, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 101;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(319, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 30);
            this.btn_OK.TabIndex = 100;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Model No";
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Model No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(165, 34);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 3;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Mode";
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Mode.Location = new System.Drawing.Point(86, 61);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(75, 23);
            this.lbl_Mode.TabIndex = 112;
            this.lbl_Mode.Text = "lbl_Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Mode.Click += new System.EventHandler(this.lbl_Mode_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(86, 34);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 113;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(86, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 114;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // gbxOptions
            // 
            this.gbxOptions.AccessibleDescription = "Options";
            this.gbxOptions.AutoSize = true;
            this.gbxOptions.Controls.Add(this.lbl_PreMoveZ);
            this.gbxOptions.Controls.Add(this.label7);
            this.gbxOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxOptions.Location = new System.Drawing.Point(5, 203);
            this.gbxOptions.Margin = new System.Windows.Forms.Padding(2);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbxOptions.Size = new System.Drawing.Size(479, 66);
            this.gbxOptions.TabIndex = 115;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // lbl_PreMoveZ
            // 
            this.lbl_PreMoveZ.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_PreMoveZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PreMoveZ.Location = new System.Drawing.Point(161, 22);
            this.lbl_PreMoveZ.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_PreMoveZ.Name = "lbl_PreMoveZ";
            this.lbl_PreMoveZ.Size = new System.Drawing.Size(75, 23);
            this.lbl_PreMoveZ.TabIndex = 111;
            this.lbl_PreMoveZ.Text = "True";
            this.lbl_PreMoveZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PreMoveZ.Click += new System.EventHandler(this.lbl_PreMoveZ_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "PreMove Z";
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 110;
            this.label7.Text = "PreMove Z";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_gbox_Weight
            // 
            this.l_gbox_Weight.AutoSize = true;
            this.l_gbox_Weight.Controls.Add(this.lbl_TrigTime);
            this.l_gbox_Weight.Controls.Add(this.btn_Trig);
            this.l_gbox_Weight.Controls.Add(this.label4);
            this.l_gbox_Weight.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_gbox_Weight.Location = new System.Drawing.Point(5, 269);
            this.l_gbox_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.l_gbox_Weight.Name = "l_gbox_Weight";
            this.l_gbox_Weight.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.l_gbox_Weight.Size = new System.Drawing.Size(479, 69);
            this.l_gbox_Weight.TabIndex = 116;
            this.l_gbox_Weight.TabStop = false;
            // 
            // lbl_TrigTime
            // 
            this.lbl_TrigTime.Location = new System.Drawing.Point(163, 22);
            this.lbl_TrigTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TrigTime.Name = "lbl_TrigTime";
            this.lbl_TrigTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_TrigTime.TabIndex = 127;
            this.lbl_TrigTime.Text = "-";
            this.lbl_TrigTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Trig
            // 
            this.btn_Trig.AccessibleDescription = "Trig";
            this.btn_Trig.Location = new System.Drawing.Point(319, 18);
            this.btn_Trig.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Trig.Name = "btn_Trig";
            this.btn_Trig.Size = new System.Drawing.Size(75, 30);
            this.btn_Trig.TabIndex = 128;
            this.btn_Trig.Text = "Trigger";
            this.btn_Trig.UseVisualStyleBackColor = true;
            this.btn_Trig.Click += new System.EventHandler(this.btn_Trig_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Trig Time (ms)";
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 126;
            this.label4.Text = "Trig Time (ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Dispense
            // 
            this.lbl_Dispense.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Dispense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Dispense.Location = new System.Drawing.Point(397, 7);
            this.lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Dispense.Name = "lbl_Dispense";
            this.lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this.lbl_Dispense.TabIndex = 130;
            this.lbl_Dispense.Text = "TRUE";
            this.lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Dispense.Click += new System.EventHandler(this.lbl_Dispense_Click);
            // 
            // _lbl_Dispense
            // 
            this._lbl_Dispense.AccessibleDescription = "Dispense";
            this._lbl_Dispense.Location = new System.Drawing.Point(318, 7);
            this._lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_Dispense.Name = "_lbl_Dispense";
            this._lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this._lbl_Dispense.TabIndex = 129;
            this._lbl_Dispense.Text = "Dispense";
            this._lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lbl_UnitRC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_Dispense);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._lbl_Dispense);
            this.panel1.Controls.Add(this.btn_EditModel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_Mode);
            this.panel1.Controls.Add(this.lbl_ModelNo);
            this.panel1.Controls.Add(this.lbl_HeadNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(479, 91);
            this.panel1.TabIndex = 131;
            // 
            // lbl_UnitRC
            // 
            this.lbl_UnitRC.AccessibleDescription = "";
            this.lbl_UnitRC.BackColor = System.Drawing.Color.Navy;
            this.lbl_UnitRC.ForeColor = System.Drawing.Color.White;
            this.lbl_UnitRC.Location = new System.Drawing.Point(165, 7);
            this.lbl_UnitRC.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_UnitRC.Name = "lbl_UnitRC";
            this.lbl_UnitRC.Size = new System.Drawing.Size(75, 23);
            this.lbl_UnitRC.TabIndex = 138;
            this.lbl_UnitRC.Text = "C,R = 0,0";
            this.lbl_UnitRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btn_Help);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 388);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(479, 44);
            this.panel2.TabIndex = 132;
            // 
            // btn_Help
            // 
            this.btn_Help.AccessibleDescription = "";
            this.btn_Help.Location = new System.Drawing.Point(7, 7);
            this.btn_Help.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(30, 30);
            this.btn_Help.TabIndex = 102;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // frm_DispCore_DispProg_Dot
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(489, 437);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.l_gbox_Weight);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.gbox_Pos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frm_DispCore_DispProg_Dot";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_Dot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispCore_DispProg_Dot_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Dot_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_Dot_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_Dot_VisibleChanged);
            this.gbox_Pos.ResumeLayout(false);
            this.gbox_Pos.PerformLayout();
            this.gbxOptions.ResumeLayout(false);
            this.l_gbox_Weight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbox_Pos;
        private System.Windows.Forms.Button btn_GotoXY;
        private System.Windows.Forms.Button btn_SetXY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_X1;
        private System.Windows.Forms.Label lbl_Y1;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.Label lbl_HeadNo;
        private System.Windows.Forms.GroupBox gbxOptions;
        private System.Windows.Forms.Label lbl_PreMoveZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox l_gbox_Weight;
        private System.Windows.Forms.Button btn_Trig;
        private System.Windows.Forms.Label lbl_TrigTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Dispense;
        private System.Windows.Forms.Label _lbl_Dispense;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_EditXY;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.Label lbl_UnitRC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbAddNew;
        private System.Windows.Forms.Button btnAddNew;
    }
}