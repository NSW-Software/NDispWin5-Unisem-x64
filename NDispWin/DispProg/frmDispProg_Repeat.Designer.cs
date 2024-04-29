namespace NDispWin
{
    partial class frm_DispCore_DispProg_Repeat
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Help = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_CurrRow = new System.Windows.Forms.Label();
            this.lbl_CurrCol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbox_RepeatLayout = new System.Windows.Forms.GroupBox();
            this.lbl_CR = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Last = new System.Windows.Forms.Button();
            this.lbl_StartY = new System.Windows.Forms.Label();
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.lbl_StartX = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SetFirst = new System.Windows.Forms.Button();
            this.btn_GotoFirst = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_URowPY = new System.Windows.Forms.Label();
            this.lbl_URowPX = new System.Windows.Forms.Label();
            this.lbl_URowCount = new System.Windows.Forms.Label();
            this.lbl_UColCount = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btn_SetURowPitch = new System.Windows.Forms.Button();
            this.btn_GotoURowPitch = new System.Windows.Forms.Button();
            this.btn_SetUColPitch = new System.Windows.Forms.Button();
            this.btn_GotoUColPitch = new System.Windows.Forms.Button();
            this.lbl_UColPY = new System.Windows.Forms.Label();
            this.lbl_UColPX = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.lbl_LoopDir = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gbox_RepeatLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btn_Help);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Location = new System.Drawing.Point(8, 248);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(480, 44);
            this.panel2.TabIndex = 133;
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
            this.btn_Help.Visible = false;
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
            // lbl_CurrRow
            // 
            this.lbl_CurrRow.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_CurrRow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrRow.Location = new System.Drawing.Point(187, 217);
            this.lbl_CurrRow.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrRow.Name = "lbl_CurrRow";
            this.lbl_CurrRow.Size = new System.Drawing.Size(40, 23);
            this.lbl_CurrRow.TabIndex = 147;
            this.lbl_CurrRow.Text = "99";
            this.lbl_CurrRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CurrRow.Click += new System.EventHandler(this.lbl_CurrRow_Click);
            // 
            // lbl_CurrCol
            // 
            this.lbl_CurrCol.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_CurrCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrCol.Location = new System.Drawing.Point(143, 217);
            this.lbl_CurrCol.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CurrCol.Name = "lbl_CurrCol";
            this.lbl_CurrCol.Size = new System.Drawing.Size(40, 23);
            this.lbl_CurrCol.TabIndex = 146;
            this.lbl_CurrCol.Text = "99";
            this.lbl_CurrCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_CurrCol.Click += new System.EventHandler(this.lbl_CurrCol_Click);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.Location = new System.Drawing.Point(14, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 23);
            this.label4.TabIndex = 144;
            this.label4.Text = "Current Col, Row";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbox_RepeatLayout
            // 
            this.gbox_RepeatLayout.AccessibleDescription = "Repeat Layout";
            this.gbox_RepeatLayout.AutoSize = true;
            this.gbox_RepeatLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbox_RepeatLayout.Controls.Add(this.lbl_LoopDir);
            this.gbox_RepeatLayout.Controls.Add(this.label5);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_CR);
            this.gbox_RepeatLayout.Controls.Add(this.label2);
            this.gbox_RepeatLayout.Controls.Add(this.btn_Last);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_StartY);
            this.gbox_RepeatLayout.Controls.Add(this.btn_First);
            this.gbox_RepeatLayout.Controls.Add(this.btn_Prev);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_StartX);
            this.gbox_RepeatLayout.Controls.Add(this.btn_Next);
            this.gbox_RepeatLayout.Controls.Add(this.label1);
            this.gbox_RepeatLayout.Controls.Add(this.btn_SetFirst);
            this.gbox_RepeatLayout.Controls.Add(this.btn_GotoFirst);
            this.gbox_RepeatLayout.Controls.Add(this.label31);
            this.gbox_RepeatLayout.Controls.Add(this.label6);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_URowPY);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_URowPX);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_URowCount);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_UColCount);
            this.gbox_RepeatLayout.Controls.Add(this.label28);
            this.gbox_RepeatLayout.Controls.Add(this.label29);
            this.gbox_RepeatLayout.Controls.Add(this.label30);
            this.gbox_RepeatLayout.Controls.Add(this.label26);
            this.gbox_RepeatLayout.Controls.Add(this.btn_SetURowPitch);
            this.gbox_RepeatLayout.Controls.Add(this.btn_GotoURowPitch);
            this.gbox_RepeatLayout.Controls.Add(this.btn_SetUColPitch);
            this.gbox_RepeatLayout.Controls.Add(this.btn_GotoUColPitch);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_UColPY);
            this.gbox_RepeatLayout.Controls.Add(this.lbl_UColPX);
            this.gbox_RepeatLayout.Location = new System.Drawing.Point(8, 8);
            this.gbox_RepeatLayout.Name = "gbox_RepeatLayout";
            this.gbox_RepeatLayout.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbox_RepeatLayout.Size = new System.Drawing.Size(479, 204);
            this.gbox_RepeatLayout.TabIndex = 134;
            this.gbox_RepeatLayout.TabStop = false;
            this.gbox_RepeatLayout.Text = "Repeat Layout";
            // 
            // lbl_CR
            // 
            this.lbl_CR.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_CR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CR.Location = new System.Drawing.Point(153, 161);
            this.lbl_CR.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_CR.Name = "lbl_CR";
            this.lbl_CR.Size = new System.Drawing.Size(65, 23);
            this.lbl_CR.TabIndex = 155;
            this.lbl_CR.Text = "0,0";
            this.lbl_CR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(5, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 23);
            this.label2.TabIndex = 154;
            this.label2.Text = "Current Col, Row";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Last
            // 
            this.btn_Last.AccessibleDescription = "Last";
            this.btn_Last.Location = new System.Drawing.Point(414, 157);
            this.btn_Last.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(60, 30);
            this.btn_Last.TabIndex = 151;
            this.btn_Last.Text = "Last";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // lbl_StartY
            // 
            this.lbl_StartY.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_StartY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartY.Location = new System.Drawing.Point(308, 25);
            this.lbl_StartY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartY.Name = "lbl_StartY";
            this.lbl_StartY.Size = new System.Drawing.Size(70, 23);
            this.lbl_StartY.TabIndex = 153;
            this.lbl_StartY.Text = "-999.999";
            this.lbl_StartY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_StartY.Click += new System.EventHandler(this.lbl_StartY_Click);
            // 
            // btn_First
            // 
            this.btn_First.AccessibleDescription = "First";
            this.btn_First.Location = new System.Drawing.Point(222, 157);
            this.btn_First.Margin = new System.Windows.Forms.Padding(2);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(60, 30);
            this.btn_First.TabIndex = 150;
            this.btn_First.Text = "First";
            this.btn_First.UseVisualStyleBackColor = true;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // btn_Prev
            // 
            this.btn_Prev.AccessibleDescription = "<";
            this.btn_Prev.Location = new System.Drawing.Point(286, 157);
            this.btn_Prev.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(60, 30);
            this.btn_Prev.TabIndex = 149;
            this.btn_Prev.Text = "<";
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // lbl_StartX
            // 
            this.lbl_StartX.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_StartX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_StartX.Location = new System.Drawing.Point(234, 25);
            this.lbl_StartX.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_StartX.Name = "lbl_StartX";
            this.lbl_StartX.Size = new System.Drawing.Size(70, 23);
            this.lbl_StartX.TabIndex = 152;
            this.lbl_StartX.Text = "-999.999";
            this.lbl_StartX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_StartX.Click += new System.EventHandler(this.lbl_StartX_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.AccessibleDescription = ">";
            this.btn_Next.Location = new System.Drawing.Point(350, 157);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(60, 30);
            this.btn_Next.TabIndex = 148;
            this.btn_Next.Text = ">";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Start";
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 151;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SetFirst
            // 
            this.btn_SetFirst.AccessibleDescription = "Set";
            this.btn_SetFirst.Location = new System.Drawing.Point(382, 21);
            this.btn_SetFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetFirst.Name = "btn_SetFirst";
            this.btn_SetFirst.Size = new System.Drawing.Size(36, 30);
            this.btn_SetFirst.TabIndex = 150;
            this.btn_SetFirst.Text = "Set";
            this.btn_SetFirst.UseVisualStyleBackColor = true;
            this.btn_SetFirst.Click += new System.EventHandler(this.btn_SetStart_Click);
            // 
            // btn_GotoFirst
            // 
            this.btn_GotoFirst.AccessibleDescription = "Goto";
            this.btn_GotoFirst.Location = new System.Drawing.Point(422, 21);
            this.btn_GotoFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoFirst.Name = "btn_GotoFirst";
            this.btn_GotoFirst.Size = new System.Drawing.Size(52, 30);
            this.btn_GotoFirst.TabIndex = 149;
            this.btn_GotoFirst.Text = "Goto";
            this.btn_GotoFirst.UseVisualStyleBackColor = true;
            this.btn_GotoFirst.Click += new System.EventHandler(this.btn_GotoStart_Click);
            // 
            // label31
            // 
            this.label31.AccessibleDescription = "Pitch XY (mm)";
            this.label31.Location = new System.Drawing.Point(140, 93);
            this.label31.Margin = new System.Windows.Forms.Padding(2);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 23);
            this.label31.TabIndex = 148;
            this.label31.Text = "Pitch XY (mm)";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Count";
            this.label6.Location = new System.Drawing.Point(52, 93);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 23);
            this.label6.TabIndex = 147;
            this.label6.Text = "Count";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbl_URowPY
            // 
            this.lbl_URowPY.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_URowPY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_URowPY.Location = new System.Drawing.Point(308, 93);
            this.lbl_URowPY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_URowPY.Name = "lbl_URowPY";
            this.lbl_URowPY.Size = new System.Drawing.Size(70, 23);
            this.lbl_URowPY.TabIndex = 146;
            this.lbl_URowPY.Text = "-999.999";
            this.lbl_URowPY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_URowPY.Click += new System.EventHandler(this.lbl_URowPY_Click);
            // 
            // lbl_URowPX
            // 
            this.lbl_URowPX.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_URowPX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_URowPX.Location = new System.Drawing.Point(234, 93);
            this.lbl_URowPX.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_URowPX.Name = "lbl_URowPX";
            this.lbl_URowPX.Size = new System.Drawing.Size(70, 23);
            this.lbl_URowPX.TabIndex = 145;
            this.lbl_URowPX.Text = "-999.999";
            this.lbl_URowPX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_URowPX.Click += new System.EventHandler(this.lbl_URowPX_Click);
            // 
            // lbl_URowCount
            // 
            this.lbl_URowCount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_URowCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_URowCount.Location = new System.Drawing.Point(96, 93);
            this.lbl_URowCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_URowCount.Name = "lbl_URowCount";
            this.lbl_URowCount.Size = new System.Drawing.Size(40, 23);
            this.lbl_URowCount.TabIndex = 143;
            this.lbl_URowCount.Text = "99";
            this.lbl_URowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_URowCount.Click += new System.EventHandler(this.lbl_URowCount_Click);
            // 
            // lbl_UColCount
            // 
            this.lbl_UColCount.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_UColCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_UColCount.Location = new System.Drawing.Point(96, 59);
            this.lbl_UColCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_UColCount.Name = "lbl_UColCount";
            this.lbl_UColCount.Size = new System.Drawing.Size(40, 23);
            this.lbl_UColCount.TabIndex = 141;
            this.lbl_UColCount.Text = "99";
            this.lbl_UColCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_UColCount.Click += new System.EventHandler(this.lbl_UColCount_Click);
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "Count";
            this.label28.Location = new System.Drawing.Point(51, 59);
            this.label28.Margin = new System.Windows.Forms.Padding(2);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 23);
            this.label28.TabIndex = 140;
            this.label28.Text = "Count";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AccessibleDescription = "Row";
            this.label29.Location = new System.Drawing.Point(5, 94);
            this.label29.Margin = new System.Windows.Forms.Padding(2);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 23);
            this.label29.TabIndex = 139;
            this.label29.Text = "Row";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.AccessibleDescription = "Col";
            this.label30.Location = new System.Drawing.Point(5, 59);
            this.label30.Margin = new System.Windows.Forms.Padding(2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 23);
            this.label30.TabIndex = 138;
            this.label30.Text = "Col";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AccessibleDescription = "Pitch XY (mm)";
            this.label26.Location = new System.Drawing.Point(140, 59);
            this.label26.Margin = new System.Windows.Forms.Padding(2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(90, 23);
            this.label26.TabIndex = 130;
            this.label26.Text = "Pitch XY (mm)";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SetURowPitch
            // 
            this.btn_SetURowPitch.AccessibleDescription = "Set";
            this.btn_SetURowPitch.Location = new System.Drawing.Point(382, 89);
            this.btn_SetURowPitch.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetURowPitch.Name = "btn_SetURowPitch";
            this.btn_SetURowPitch.Size = new System.Drawing.Size(36, 30);
            this.btn_SetURowPitch.TabIndex = 129;
            this.btn_SetURowPitch.Text = "Set";
            this.btn_SetURowPitch.UseVisualStyleBackColor = true;
            this.btn_SetURowPitch.Click += new System.EventHandler(this.btn_SetURowPitch_Click);
            // 
            // btn_GotoURowPitch
            // 
            this.btn_GotoURowPitch.AccessibleDescription = "Goto";
            this.btn_GotoURowPitch.Location = new System.Drawing.Point(422, 89);
            this.btn_GotoURowPitch.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoURowPitch.Name = "btn_GotoURowPitch";
            this.btn_GotoURowPitch.Size = new System.Drawing.Size(52, 30);
            this.btn_GotoURowPitch.TabIndex = 128;
            this.btn_GotoURowPitch.Text = "Goto";
            this.btn_GotoURowPitch.UseVisualStyleBackColor = true;
            this.btn_GotoURowPitch.Click += new System.EventHandler(this.btn_GotoURowPitch_Click);
            // 
            // btn_SetUColPitch
            // 
            this.btn_SetUColPitch.AccessibleDescription = "Set";
            this.btn_SetUColPitch.Location = new System.Drawing.Point(382, 55);
            this.btn_SetUColPitch.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetUColPitch.Name = "btn_SetUColPitch";
            this.btn_SetUColPitch.Size = new System.Drawing.Size(36, 30);
            this.btn_SetUColPitch.TabIndex = 127;
            this.btn_SetUColPitch.Text = "Set";
            this.btn_SetUColPitch.UseVisualStyleBackColor = true;
            this.btn_SetUColPitch.Click += new System.EventHandler(this.btn_SetUColPitch_Click);
            // 
            // btn_GotoUColPitch
            // 
            this.btn_GotoUColPitch.AccessibleDescription = "Goto";
            this.btn_GotoUColPitch.Location = new System.Drawing.Point(422, 55);
            this.btn_GotoUColPitch.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GotoUColPitch.Name = "btn_GotoUColPitch";
            this.btn_GotoUColPitch.Size = new System.Drawing.Size(52, 30);
            this.btn_GotoUColPitch.TabIndex = 126;
            this.btn_GotoUColPitch.Text = "Goto";
            this.btn_GotoUColPitch.UseVisualStyleBackColor = true;
            this.btn_GotoUColPitch.Click += new System.EventHandler(this.btn_GotoUColPitch_Click);
            // 
            // lbl_UColPY
            // 
            this.lbl_UColPY.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_UColPY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_UColPY.Location = new System.Drawing.Point(308, 59);
            this.lbl_UColPY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_UColPY.Name = "lbl_UColPY";
            this.lbl_UColPY.Size = new System.Drawing.Size(70, 23);
            this.lbl_UColPY.TabIndex = 125;
            this.lbl_UColPY.Text = "-999.999";
            this.lbl_UColPY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_UColPY.Click += new System.EventHandler(this.lbl_UColPY_Click);
            // 
            // lbl_UColPX
            // 
            this.lbl_UColPX.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_UColPX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_UColPX.Location = new System.Drawing.Point(234, 59);
            this.lbl_UColPX.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_UColPX.Name = "lbl_UColPX";
            this.lbl_UColPX.Size = new System.Drawing.Size(70, 23);
            this.lbl_UColPX.TabIndex = 123;
            this.lbl_UColPX.Text = "-999.999";
            this.lbl_UColPX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_UColPX.Click += new System.EventHandler(this.lbl_UColPX_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.AccessibleDescription = "Update";
            this.btn_Update.Location = new System.Drawing.Point(231, 213);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(60, 30);
            this.btn_Update.TabIndex = 152;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // lbl_LoopDir
            // 
            this.lbl_LoopDir.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_LoopDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_LoopDir.Location = new System.Drawing.Point(96, 127);
            this.lbl_LoopDir.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_LoopDir.Name = "lbl_LoopDir";
            this.lbl_LoopDir.Size = new System.Drawing.Size(77, 23);
            this.lbl_LoopDir.TabIndex = 157;
            this.lbl_LoopDir.Text = "99";
            this.lbl_LoopDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_LoopDir.Click += new System.EventHandler(this.lbl_LoopDir_Click);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Loop Direction";
            this.label5.Location = new System.Drawing.Point(6, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 156;
            this.label5.Text = "Loop Direction";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // frm_DispCore_DispProg_Repeat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(495, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.gbox_RepeatLayout);
            this.Controls.Add(this.lbl_CurrRow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_CurrCol);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_DispProg_Repeat";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmDispProg_Repeat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDispProg_Repeat_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Repeat_Load);
            this.panel2.ResumeLayout(false);
            this.gbox_RepeatLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox gbox_RepeatLayout;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_URowPY;
        private System.Windows.Forms.Label lbl_URowPX;
        private System.Windows.Forms.Label lbl_URowCount;
        private System.Windows.Forms.Label lbl_UColCount;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btn_SetURowPitch;
        private System.Windows.Forms.Button btn_GotoURowPitch;
        private System.Windows.Forms.Button btn_SetUColPitch;
        private System.Windows.Forms.Button btn_GotoUColPitch;
        private System.Windows.Forms.Label lbl_UColPY;
        private System.Windows.Forms.Label lbl_UColPX;
        private System.Windows.Forms.Label lbl_CurrRow;
        private System.Windows.Forms.Label lbl_CurrCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SetFirst;
        private System.Windows.Forms.Button btn_GotoFirst;
        private System.Windows.Forms.Label lbl_StartY;
        private System.Windows.Forms.Label lbl_StartX;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.Button btn_First;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_CR;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label lbl_LoopDir;
        private System.Windows.Forms.Label label5;
    }
}