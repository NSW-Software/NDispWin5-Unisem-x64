namespace DispCore
{
    partial class frm_DispCore_DispProg_MoveLine
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
            this.lbl_Y = new System.Windows.Forms.Label();
            this.btn_Goto = new System.Windows.Forms.Button();
            this.lbl_X = new System.Windows.Forms.Label();
            this.btn_Set = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.l_lbl_HeadNo = new System.Windows.Forms.Label();
            this.l_lbl_ModelNo = new System.Windows.Forms.Label();
            this.btn_EditModel = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.l_lbl_Weight = new System.Windows.Forms.Label();
            this.lbl_Weight = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.btn_SetLength = new System.Windows.Forms.Button();
            this.lbl_Length = new System.Windows.Forms.Label();
            this._lbl_Length = new System.Windows.Forms.Label();
            this.lbl_TimeTol = new System.Windows.Forms.Label();
            this.btn_Trig = new System.Windows.Forms.Button();
            this.lbl_TrigTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_GotoStartXY = new System.Windows.Forms.Button();
            this.lbl_StartXY = new System.Windows.Forms.Label();
            this._lbl_StartXY = new System.Windows.Forms.Label();
            this.lbl_HeadNo = new System.Windows.Forms.Label();
            this.lbl_ModelNo = new System.Windows.Forms.Label();
            this.gbox_Options = new System.Windows.Forms.GroupBox();
            this.lbl_ReverseDir = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_PreMoveZ = new System.Windows.Forms.Label();
            this.l_lbl_PreMoveZ = new System.Windows.Forms.Label();
            this.lbl_Head = new System.Windows.Forms.Label();
            this.btn_Measure = new System.Windows.Forms.Button();
            this.lbl_WeightTol = new System.Windows.Forms.Label();
            this.btn_CalWeight = new System.Windows.Forms.Button();
            this.gbox_Calibration = new System.Windows.Forms.GroupBox();
            this.btn_CalSpeedToTime = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Radius = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Smooth = new System.Windows.Forms.Label();
            this.lbl_Radius = new System.Windows.Forms.Label();
            this.lbl_Cont = new System.Windows.Forms.Label();
            this.l_lbl_Cont = new System.Windows.Forms.Label();
            this.lbl_Dispense = new System.Windows.Forms.Label();
            this._lbl_Dispense = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Time2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbox_Options.SuspendLayout();
            this.gbox_Calibration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Radius.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Y
            // 
            this.lbl_Y.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Y.Location = new System.Drawing.Point(209, 60);
            this.lbl_Y.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(75, 23);
            this.lbl_Y.TabIndex = 108;
            this.lbl_Y.Text = "9.999";
            this.lbl_Y.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Y.Click += new System.EventHandler(this.lbl_Y_Click);
            // 
            // btn_Goto
            // 
            this.btn_Goto.AccessibleDescription = "Goto";
            this.btn_Goto.Location = new System.Drawing.Point(367, 54);
            this.btn_Goto.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Goto.Name = "btn_Goto";
            this.btn_Goto.Size = new System.Drawing.Size(75, 36);
            this.btn_Goto.TabIndex = 23;
            this.btn_Goto.Text = "Goto";
            this.btn_Goto.UseVisualStyleBackColor = true;
            this.btn_Goto.Click += new System.EventHandler(this.btn_Goto_Click);
            // 
            // lbl_X
            // 
            this.lbl_X.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_X.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_X.Location = new System.Drawing.Point(130, 60);
            this.lbl_X.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(75, 23);
            this.lbl_X.TabIndex = 107;
            this.lbl_X.Text = "-999.999";
            this.lbl_X.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_X.Click += new System.EventHandler(this.lbl_X_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.AccessibleDescription = "Set";
            this.btn_Set.Location = new System.Drawing.Point(288, 54);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(75, 36);
            this.btn_Set.TabIndex = 5;
            this.btn_Set.Text = "Set";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "End XY (mm)";
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "End XY (mm)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_lbl_HeadNo
            // 
            this.l_lbl_HeadNo.AccessibleDescription = "Head No";
            this.l_lbl_HeadNo.Location = new System.Drawing.Point(7, 7);
            this.l_lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_HeadNo.Name = "l_lbl_HeadNo";
            this.l_lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.l_lbl_HeadNo.TabIndex = 20;
            this.l_lbl_HeadNo.Text = "Head No";
            this.l_lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_lbl_ModelNo
            // 
            this.l_lbl_ModelNo.AccessibleDescription = "Model No";
            this.l_lbl_ModelNo.Location = new System.Drawing.Point(7, 34);
            this.l_lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_ModelNo.Name = "l_lbl_ModelNo";
            this.l_lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.l_lbl_ModelNo.TabIndex = 23;
            this.l_lbl_ModelNo.Text = "Model No";
            this.l_lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_EditModel
            // 
            this.btn_EditModel.AccessibleDescription = "Edit";
            this.btn_EditModel.Location = new System.Drawing.Point(165, 34);
            this.btn_EditModel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_EditModel.Name = "btn_EditModel";
            this.btn_EditModel.Size = new System.Drawing.Size(75, 23);
            this.btn_EditModel.TabIndex = 24;
            this.btn_EditModel.Text = "Edit";
            this.btn_EditModel.UseVisualStyleBackColor = true;
            this.btn_EditModel.Click += new System.EventHandler(this.btn_EditModel_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AccessibleDescription = "Cancel";
            this.btn_Cancel.Location = new System.Drawing.Point(368, 7);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 36);
            this.btn_Cancel.TabIndex = 103;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AccessibleDescription = "OK";
            this.btn_OK.Location = new System.Drawing.Point(289, 7);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 36);
            this.btn_OK.TabIndex = 102;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // l_lbl_Weight
            // 
            this.l_lbl_Weight.AccessibleDescription = "Weight/Tol (mg)";
            this.l_lbl_Weight.Location = new System.Drawing.Point(7, 49);
            this.l_lbl_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_Weight.Name = "l_lbl_Weight";
            this.l_lbl_Weight.Size = new System.Drawing.Size(120, 23);
            this.l_lbl_Weight.TabIndex = 105;
            this.l_lbl_Weight.Text = "Weight/Tol (mg)";
            this.l_lbl_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Weight
            // 
            this.lbl_Weight.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Weight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Weight.Location = new System.Drawing.Point(131, 49);
            this.lbl_Weight.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Weight.Name = "lbl_Weight";
            this.lbl_Weight.Size = new System.Drawing.Size(75, 23);
            this.lbl_Weight.TabIndex = 108;
            this.lbl_Weight.Text = "9.999";
            this.lbl_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Weight.Click += new System.EventHandler(this.lbl_Weight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Information";
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lbl_Time2);
            this.groupBox1.Controls.Add(this.lbl_Time);
            this.groupBox1.Controls.Add(this.btn_SetLength);
            this.groupBox1.Controls.Add(this.lbl_Length);
            this.groupBox1.Controls.Add(this._lbl_Length);
            this.groupBox1.Location = new System.Drawing.Point(7, 241);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(450, 61);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AccessibleDescription = "";
            this.lbl_Time.Location = new System.Drawing.Point(288, 15);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(120, 23);
            this.lbl_Time.TabIndex = 113;
            this.lbl_Time.Text = "-";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SetLength
            // 
            this.btn_SetLength.AccessibleDescription = "Set";
            this.btn_SetLength.Location = new System.Drawing.Point(209, 15);
            this.btn_SetLength.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetLength.Name = "btn_SetLength";
            this.btn_SetLength.Size = new System.Drawing.Size(75, 36);
            this.btn_SetLength.TabIndex = 112;
            this.btn_SetLength.Text = "Set";
            this.btn_SetLength.UseVisualStyleBackColor = true;
            this.btn_SetLength.Click += new System.EventHandler(this.btn_SetLength_Click);
            // 
            // lbl_Length
            // 
            this.lbl_Length.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Length.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Length.Location = new System.Drawing.Point(130, 22);
            this.lbl_Length.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Length.Name = "lbl_Length";
            this.lbl_Length.Size = new System.Drawing.Size(75, 23);
            this.lbl_Length.TabIndex = 111;
            this.lbl_Length.Text = "TRUE";
            this.lbl_Length.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Length.Click += new System.EventHandler(this.lbl_Length_Click);
            // 
            // _lbl_Length
            // 
            this._lbl_Length.AccessibleDescription = "Length (mm)";
            this._lbl_Length.Location = new System.Drawing.Point(7, 22);
            this._lbl_Length.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_Length.Name = "_lbl_Length";
            this._lbl_Length.Size = new System.Drawing.Size(120, 23);
            this._lbl_Length.TabIndex = 5;
            this._lbl_Length.Text = "Length (mm)";
            this._lbl_Length.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lbl_Length.Click += new System.EventHandler(this._lbl_Length_Click);
            // 
            // lbl_TimeTol
            // 
            this.lbl_TimeTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_TimeTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TimeTol.Location = new System.Drawing.Point(210, 89);
            this.lbl_TimeTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TimeTol.Name = "lbl_TimeTol";
            this.lbl_TimeTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_TimeTol.TabIndex = 124;
            this.lbl_TimeTol.Text = "9.999";
            this.lbl_TimeTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TimeTol.Click += new System.EventHandler(this.lbl_TimeTol_Click);
            // 
            // btn_Trig
            // 
            this.btn_Trig.AccessibleDescription = "Trigger";
            this.btn_Trig.Location = new System.Drawing.Point(289, 82);
            this.btn_Trig.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Trig.Name = "btn_Trig";
            this.btn_Trig.Size = new System.Drawing.Size(75, 36);
            this.btn_Trig.TabIndex = 123;
            this.btn_Trig.Text = "Trigger";
            this.btn_Trig.UseVisualStyleBackColor = true;
            this.btn_Trig.Click += new System.EventHandler(this.btn_Trig_Click);
            // 
            // lbl_TrigTime
            // 
            this.lbl_TrigTime.BackColor = System.Drawing.Color.White;
            this.lbl_TrigTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TrigTime.Location = new System.Drawing.Point(131, 89);
            this.lbl_TrigTime.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TrigTime.Name = "lbl_TrigTime";
            this.lbl_TrigTime.Size = new System.Drawing.Size(75, 23);
            this.lbl_TrigTime.TabIndex = 122;
            this.lbl_TrigTime.Text = "-";
            this.lbl_TrigTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_TrigTime.Click += new System.EventHandler(this.lbl_TrigTime_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Time/Tol (ms)";
            this.label6.Location = new System.Drawing.Point(7, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 121;
            this.label6.Text = "Time/Tol (ms)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_GotoStartXY
            // 
            this.btn_GotoStartXY.AccessibleDescription = "Goto";
            this.btn_GotoStartXY.Location = new System.Drawing.Point(367, 14);
            this.btn_GotoStartXY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoStartXY.Name = "btn_GotoStartXY";
            this.btn_GotoStartXY.Size = new System.Drawing.Size(75, 36);
            this.btn_GotoStartXY.TabIndex = 117;
            this.btn_GotoStartXY.Text = "Goto";
            this.btn_GotoStartXY.UseVisualStyleBackColor = true;
            this.btn_GotoStartXY.Click += new System.EventHandler(this.btn_GotoStartXY_Click);
            // 
            // lbl_StartXY
            // 
            this.lbl_StartXY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartXY.Location = new System.Drawing.Point(131, 22);
            this.lbl_StartXY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartXY.Name = "lbl_StartXY";
            this.lbl_StartXY.Size = new System.Drawing.Size(154, 23);
            this.lbl_StartXY.TabIndex = 116;
            this.lbl_StartXY.Text = "lbl_StartXY";
            this.lbl_StartXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_StartXY.Click += new System.EventHandler(this.lbl_StartXY_Click);
            // 
            // _lbl_StartXY
            // 
            this._lbl_StartXY.AccessibleDescription = "Start X, Y (mm)";
            this._lbl_StartXY.Location = new System.Drawing.Point(7, 22);
            this._lbl_StartXY.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_StartXY.Name = "_lbl_StartXY";
            this._lbl_StartXY.Size = new System.Drawing.Size(120, 23);
            this._lbl_StartXY.TabIndex = 115;
            this._lbl_StartXY.Text = "Start X, Y (mm)";
            this._lbl_StartXY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lbl_StartXY.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_HeadNo
            // 
            this.lbl_HeadNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_HeadNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_HeadNo.Location = new System.Drawing.Point(86, 7);
            this.lbl_HeadNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_HeadNo.Name = "lbl_HeadNo";
            this.lbl_HeadNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_HeadNo.TabIndex = 111;
            this.lbl_HeadNo.Text = "lbl_HeadNo";
            this.lbl_HeadNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_HeadNo.Click += new System.EventHandler(this.lbl_HeadNo_Click);
            // 
            // lbl_ModelNo
            // 
            this.lbl_ModelNo.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ModelNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ModelNo.Location = new System.Drawing.Point(86, 34);
            this.lbl_ModelNo.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ModelNo.Name = "lbl_ModelNo";
            this.lbl_ModelNo.Size = new System.Drawing.Size(75, 23);
            this.lbl_ModelNo.TabIndex = 112;
            this.lbl_ModelNo.Text = "lbl_ModelNo";
            this.lbl_ModelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ModelNo.Click += new System.EventHandler(this.lbl_ModelNo_Click);
            // 
            // gbox_Options
            // 
            this.gbox_Options.AccessibleDescription = "Options";
            this.gbox_Options.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Options.Controls.Add(this.lbl_ReverseDir);
            this.gbox_Options.Controls.Add(this.label3);
            this.gbox_Options.Controls.Add(this.lbl_PreMoveZ);
            this.gbox_Options.Controls.Add(this.l_lbl_PreMoveZ);
            this.gbox_Options.Location = new System.Drawing.Point(7, 306);
            this.gbox_Options.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Options.Name = "gbox_Options";
            this.gbox_Options.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Options.Size = new System.Drawing.Size(450, 60);
            this.gbox_Options.TabIndex = 113;
            this.gbox_Options.TabStop = false;
            this.gbox_Options.Text = "Options";
            this.gbox_Options.Enter += new System.EventHandler(this.gbox_Options_Enter);
            // 
            // lbl_ReverseDir
            // 
            this.lbl_ReverseDir.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_ReverseDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_ReverseDir.Location = new System.Drawing.Point(367, 20);
            this.lbl_ReverseDir.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_ReverseDir.Name = "lbl_ReverseDir";
            this.lbl_ReverseDir.Size = new System.Drawing.Size(75, 23);
            this.lbl_ReverseDir.TabIndex = 112;
            this.lbl_ReverseDir.Text = "TRUE";
            this.lbl_ReverseDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ReverseDir.Click += new System.EventHandler(this.lbl_ReverseDir_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "Reverse Dir";
            this.label3.Location = new System.Drawing.Point(243, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 111;
            this.label3.Text = "Reverse Dir";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PreMoveZ
            // 
            this.lbl_PreMoveZ.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_PreMoveZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PreMoveZ.Location = new System.Drawing.Point(131, 20);
            this.lbl_PreMoveZ.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_PreMoveZ.Name = "lbl_PreMoveZ";
            this.lbl_PreMoveZ.Size = new System.Drawing.Size(75, 23);
            this.lbl_PreMoveZ.TabIndex = 110;
            this.lbl_PreMoveZ.Text = "TRUE";
            this.lbl_PreMoveZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PreMoveZ.Click += new System.EventHandler(this.lbl_PreMoveZ_Click);
            // 
            // l_lbl_PreMoveZ
            // 
            this.l_lbl_PreMoveZ.AccessibleDescription = "PreMoveZ";
            this.l_lbl_PreMoveZ.Location = new System.Drawing.Point(7, 20);
            this.l_lbl_PreMoveZ.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_PreMoveZ.Name = "l_lbl_PreMoveZ";
            this.l_lbl_PreMoveZ.Size = new System.Drawing.Size(120, 23);
            this.l_lbl_PreMoveZ.TabIndex = 109;
            this.l_lbl_PreMoveZ.Text = "PreMoveZ";
            this.l_lbl_PreMoveZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Head
            // 
            this.lbl_Head.BackColor = System.Drawing.Color.White;
            this.lbl_Head.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Head.Location = new System.Drawing.Point(7, 22);
            this.lbl_Head.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Head.Name = "lbl_Head";
            this.lbl_Head.Size = new System.Drawing.Size(75, 23);
            this.lbl_Head.TabIndex = 121;
            this.lbl_Head.Text = "Head1";
            this.lbl_Head.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Head.Click += new System.EventHandler(this.lbl_Head_Click);
            // 
            // btn_Measure
            // 
            this.btn_Measure.AccessibleDescription = "Measure";
            this.btn_Measure.Location = new System.Drawing.Point(289, 42);
            this.btn_Measure.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Measure.Name = "btn_Measure";
            this.btn_Measure.Size = new System.Drawing.Size(75, 36);
            this.btn_Measure.TabIndex = 113;
            this.btn_Measure.Text = "Measure";
            this.btn_Measure.UseVisualStyleBackColor = true;
            this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // lbl_WeightTol
            // 
            this.lbl_WeightTol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_WeightTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WeightTol.Location = new System.Drawing.Point(210, 49);
            this.lbl_WeightTol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_WeightTol.Name = "lbl_WeightTol";
            this.lbl_WeightTol.Size = new System.Drawing.Size(75, 23);
            this.lbl_WeightTol.TabIndex = 112;
            this.lbl_WeightTol.Text = "9.999";
            this.lbl_WeightTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_WeightTol.Click += new System.EventHandler(this.lbl_WeightTol_Click);
            // 
            // btn_CalWeight
            // 
            this.btn_CalWeight.AccessibleDescription = "Calibrate";
            this.btn_CalWeight.Location = new System.Drawing.Point(367, 41);
            this.btn_CalWeight.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CalWeight.Name = "btn_CalWeight";
            this.btn_CalWeight.Size = new System.Drawing.Size(75, 36);
            this.btn_CalWeight.TabIndex = 111;
            this.btn_CalWeight.Text = "Calibrate";
            this.btn_CalWeight.UseVisualStyleBackColor = true;
            this.btn_CalWeight.Click += new System.EventHandler(this.btn_CalWeight_Click);
            // 
            // gbox_Calibration
            // 
            this.gbox_Calibration.AccessibleDescription = "Calibration";
            this.gbox_Calibration.AutoSize = true;
            this.gbox_Calibration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_Calibration.Controls.Add(this.lbl_TimeTol);
            this.gbox_Calibration.Controls.Add(this.lbl_TrigTime);
            this.gbox_Calibration.Controls.Add(this.l_lbl_Weight);
            this.gbox_Calibration.Controls.Add(this.label6);
            this.gbox_Calibration.Controls.Add(this.btn_Trig);
            this.gbox_Calibration.Controls.Add(this.btn_CalSpeedToTime);
            this.gbox_Calibration.Controls.Add(this.lbl_Head);
            this.gbox_Calibration.Controls.Add(this.lbl_Weight);
            this.gbox_Calibration.Controls.Add(this.btn_Measure);
            this.gbox_Calibration.Controls.Add(this.btn_CalWeight);
            this.gbox_Calibration.Controls.Add(this.lbl_WeightTol);
            this.gbox_Calibration.Location = new System.Drawing.Point(7, 370);
            this.gbox_Calibration.Margin = new System.Windows.Forms.Padding(2);
            this.gbox_Calibration.Name = "gbox_Calibration";
            this.gbox_Calibration.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.gbox_Calibration.Size = new System.Drawing.Size(450, 136);
            this.gbox_Calibration.TabIndex = 114;
            this.gbox_Calibration.TabStop = false;
            this.gbox_Calibration.Text = "Calibration";
            // 
            // btn_CalSpeedToTime
            // 
            this.btn_CalSpeedToTime.AccessibleDescription = "Calibrate";
            this.btn_CalSpeedToTime.Location = new System.Drawing.Point(367, 82);
            this.btn_CalSpeedToTime.Name = "btn_CalSpeedToTime";
            this.btn_CalSpeedToTime.Size = new System.Drawing.Size(75, 36);
            this.btn_CalSpeedToTime.TabIndex = 123;
            this.btn_CalSpeedToTime.Text = "Calibrate";
            this.btn_CalSpeedToTime.UseVisualStyleBackColor = true;
            this.btn_CalSpeedToTime.Click += new System.EventHandler(this.btn_CalSpeedToTime_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Position";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.lbl_Y);
            this.groupBox2.Controls.Add(this._lbl_StartXY);
            this.groupBox2.Controls.Add(this.btn_Goto);
            this.groupBox2.Controls.Add(this.lbl_X);
            this.groupBox2.Controls.Add(this.btn_GotoStartXY);
            this.groupBox2.Controls.Add(this.btn_Set);
            this.groupBox2.Controls.Add(this.lbl_StartXY);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(7, 129);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox2.Size = new System.Drawing.Size(449, 107);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pnl_Radius);
            this.panel1.Controls.Add(this.lbl_Cont);
            this.panel1.Controls.Add(this.l_lbl_Cont);
            this.panel1.Controls.Add(this.lbl_Dispense);
            this.panel1.Controls.Add(this.l_lbl_HeadNo);
            this.panel1.Controls.Add(this._lbl_Dispense);
            this.panel1.Controls.Add(this.lbl_HeadNo);
            this.panel1.Controls.Add(this.l_lbl_ModelNo);
            this.panel1.Controls.Add(this.lbl_ModelNo);
            this.panel1.Controls.Add(this.btn_EditModel);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(451, 120);
            this.panel1.TabIndex = 124;
            // 
            // pnl_Radius
            // 
            this.pnl_Radius.AutoSize = true;
            this.pnl_Radius.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_Radius.Controls.Add(this.label4);
            this.pnl_Radius.Controls.Add(this.label7);
            this.pnl_Radius.Controls.Add(this.lbl_Smooth);
            this.pnl_Radius.Controls.Add(this.lbl_Radius);
            this.pnl_Radius.Location = new System.Drawing.Point(266, 61);
            this.pnl_Radius.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Radius.Name = "pnl_Radius";
            this.pnl_Radius.Size = new System.Drawing.Size(178, 52);
            this.pnl_Radius.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Radius";
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 129;
            this.label4.Text = "Radius (mm)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Smooth (ms)";
            this.label7.Location = new System.Drawing.Point(2, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 131;
            this.label7.Text = "Smooth (ms)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Smooth
            // 
            this.lbl_Smooth.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Smooth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Smooth.Location = new System.Drawing.Point(101, 27);
            this.lbl_Smooth.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Smooth.Name = "lbl_Smooth";
            this.lbl_Smooth.Size = new System.Drawing.Size(75, 23);
            this.lbl_Smooth.TabIndex = 132;
            this.lbl_Smooth.Text = "TRUE";
            this.lbl_Smooth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Smooth.Click += new System.EventHandler(this.lbl_Smooth_Click);
            // 
            // lbl_Radius
            // 
            this.lbl_Radius.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Radius.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Radius.Location = new System.Drawing.Point(101, 0);
            this.lbl_Radius.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Radius.Name = "lbl_Radius";
            this.lbl_Radius.Size = new System.Drawing.Size(75, 23);
            this.lbl_Radius.TabIndex = 130;
            this.lbl_Radius.Text = "TRUE";
            this.lbl_Radius.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Radius.Click += new System.EventHandler(this.lbl_Radius_Click);
            // 
            // lbl_Cont
            // 
            this.lbl_Cont.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Cont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Cont.Location = new System.Drawing.Point(367, 34);
            this.lbl_Cont.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Cont.Name = "lbl_Cont";
            this.lbl_Cont.Size = new System.Drawing.Size(75, 23);
            this.lbl_Cont.TabIndex = 128;
            this.lbl_Cont.Text = "TRUE";
            this.lbl_Cont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Cont.Click += new System.EventHandler(this.lbl_Cont_Click);
            // 
            // l_lbl_Cont
            // 
            this.l_lbl_Cont.AccessibleDescription = "Continuous";
            this.l_lbl_Cont.Location = new System.Drawing.Point(263, 34);
            this.l_lbl_Cont.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_Cont.Name = "l_lbl_Cont";
            this.l_lbl_Cont.Size = new System.Drawing.Size(100, 23);
            this.l_lbl_Cont.TabIndex = 127;
            this.l_lbl_Cont.Text = "Continuous";
            this.l_lbl_Cont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Dispense
            // 
            this.lbl_Dispense.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Dispense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Dispense.Location = new System.Drawing.Point(367, 7);
            this.lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Dispense.Name = "lbl_Dispense";
            this.lbl_Dispense.Size = new System.Drawing.Size(75, 23);
            this.lbl_Dispense.TabIndex = 126;
            this.lbl_Dispense.Text = "TRUE";
            this.lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Dispense.Click += new System.EventHandler(this.lbl_Dispense_Click);
            // 
            // _lbl_Dispense
            // 
            this._lbl_Dispense.AccessibleDescription = "Dispense";
            this._lbl_Dispense.Location = new System.Drawing.Point(263, 7);
            this._lbl_Dispense.Margin = new System.Windows.Forms.Padding(2);
            this._lbl_Dispense.Name = "_lbl_Dispense";
            this._lbl_Dispense.Size = new System.Drawing.Size(100, 23);
            this._lbl_Dispense.TabIndex = 125;
            this._lbl_Dispense.Text = "Dispense";
            this._lbl_Dispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(6, 510);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(450, 50);
            this.panel2.TabIndex = 125;
            // 
            // lbl_Time2
            // 
            this.lbl_Time2.AccessibleDescription = "";
            this.lbl_Time2.Location = new System.Drawing.Point(288, 36);
            this.lbl_Time2.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Time2.Name = "lbl_Time2";
            this.lbl_Time2.Size = new System.Drawing.Size(120, 23);
            this.lbl_Time2.TabIndex = 114;
            this.lbl_Time2.Text = "-";
            this.lbl_Time2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_DispCore_DispProg_MoveLine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(469, 616);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbox_Calibration);
            this.Controls.Add(this.gbox_Options);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_MoveLine";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_MoveLine";
            this.Load += new System.EventHandler(this.frmDispProg_MoveLine_Load);
            this.Shown += new System.EventHandler(this.frmDispProg_MoveLine_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDispProg_MoveLine_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.gbox_Options.ResumeLayout(false);
            this.gbox_Calibration.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Radius.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Goto;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_lbl_HeadNo;
        private System.Windows.Forms.Label l_lbl_ModelNo;
        private System.Windows.Forms.Button btn_EditModel;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label l_lbl_Weight;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Weight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _lbl_Length;
        private System.Windows.Forms.Button btn_GotoStartXY;
        private System.Windows.Forms.Label lbl_StartXY;
        private System.Windows.Forms.Label _lbl_StartXY;
        private System.Windows.Forms.Label lbl_HeadNo;
        private System.Windows.Forms.Label lbl_ModelNo;
        private System.Windows.Forms.GroupBox gbox_Options;
        private System.Windows.Forms.Label lbl_PreMoveZ;
        private System.Windows.Forms.Label l_lbl_PreMoveZ;
        private System.Windows.Forms.Button btn_Trig;
        private System.Windows.Forms.Label lbl_TrigTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_CalWeight;
        private System.Windows.Forms.Label lbl_WeightTol;
        private System.Windows.Forms.Button btn_Measure;
        private System.Windows.Forms.Label lbl_Head;
        private System.Windows.Forms.GroupBox gbox_Calibration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_TimeTol;
        private System.Windows.Forms.Button btn_CalSpeedToTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Dispense;
        private System.Windows.Forms.Label _lbl_Dispense;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_ReverseDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Length;
        private System.Windows.Forms.Button btn_SetLength;
        private System.Windows.Forms.Label lbl_Cont;
        private System.Windows.Forms.Label l_lbl_Cont;
        private System.Windows.Forms.Label lbl_Smooth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Radius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_Radius;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_Time2;
    }
}