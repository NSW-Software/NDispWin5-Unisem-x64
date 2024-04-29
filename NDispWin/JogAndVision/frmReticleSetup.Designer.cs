namespace NDispWin
{
    partial class frm_DispCore_ReticleSetup
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
            this.lbox_Reticle = new System.Windows.Forms.ListBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_lbl_Scale = new System.Windows.Forms.Label();
            this.lbl_Scale = new System.Windows.Forms.Label();
            this.l_lbl_Text = new System.Windows.Forms.Label();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combox_ReticleType = new System.Windows.Forms.ComboBox();
            this.l_gbox_Size = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_HP = new System.Windows.Forms.Button();
            this.btn_WP = new System.Windows.Forms.Button();
            this.btn_WN = new System.Windows.Forms.Button();
            this.btn_HN = new System.Windows.Forms.Button();
            this.lbl_WH = new System.Windows.Forms.Label();
            this.l_gbox_Position = new System.Windows.Forms.GroupBox();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_C = new System.Windows.Forms.Button();
            this.btn_YP = new System.Windows.Forms.Button();
            this.btn_XP = new System.Windows.Forms.Button();
            this.btn_XN = new System.Windows.Forms.Button();
            this.btn_YN = new System.Windows.Forms.Button();
            this.lbl_XY = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.l_gbox_Size.SuspendLayout();
            this.l_gbox_Position.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbox_Reticle
            // 
            this.lbox_Reticle.FormattingEnabled = true;
            this.lbox_Reticle.ItemHeight = 14;
            this.lbox_Reticle.Location = new System.Drawing.Point(318, 61);
            this.lbox_Reticle.Margin = new System.Windows.Forms.Padding(2);
            this.lbox_Reticle.Name = "lbox_Reticle";
            this.lbox_Reticle.Size = new System.Drawing.Size(311, 312);
            this.lbox_Reticle.TabIndex = 0;
            this.lbox_Reticle.Click += new System.EventHandler(this.lbox_Reticle_Click);
            // 
            // btn_New
            // 
            this.btn_New.AccessibleDescription = "New";
            this.btn_New.Location = new System.Drawing.Point(239, 61);
            this.btn_New.Margin = new System.Windows.Forms.Padding(2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 36);
            this.btn_New.TabIndex = 1;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AccessibleDescription = "Save";
            this.btn_Save.Location = new System.Drawing.Point(459, 7);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 36);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.AccessibleDescription = "Remove";
            this.btn_Remove.Location = new System.Drawing.Point(239, 343);
            this.btn_Remove.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 36);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Reticle";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.l_lbl_Scale);
            this.groupBox1.Controls.Add(this.lbl_Scale);
            this.groupBox1.Controls.Add(this.l_lbl_Text);
            this.groupBox1.Controls.Add(this.lbl_Text);
            this.groupBox1.Controls.Add(this.lbl_Color);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.combox_ReticleType);
            this.groupBox1.Location = new System.Drawing.Point(7, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.groupBox1.Size = new System.Drawing.Size(228, 149);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reticle";
            // 
            // l_lbl_Scale
            // 
            this.l_lbl_Scale.AccessibleDescription = "Scale";
            this.l_lbl_Scale.AutoSize = true;
            this.l_lbl_Scale.Location = new System.Drawing.Point(7, 113);
            this.l_lbl_Scale.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_Scale.Name = "l_lbl_Scale";
            this.l_lbl_Scale.Size = new System.Drawing.Size(35, 14);
            this.l_lbl_Scale.TabIndex = 19;
            this.l_lbl_Scale.Text = "Scale";
            // 
            // lbl_Scale
            // 
            this.lbl_Scale.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Scale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Scale.Location = new System.Drawing.Point(72, 108);
            this.lbl_Scale.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Scale.Name = "lbl_Scale";
            this.lbl_Scale.Size = new System.Drawing.Size(149, 24);
            this.lbl_Scale.TabIndex = 18;
            this.lbl_Scale.Text = "Scale";
            this.lbl_Scale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Scale.Click += new System.EventHandler(this.lbl_Scale_Click);
            // 
            // l_lbl_Text
            // 
            this.l_lbl_Text.AccessibleDescription = "Text";
            this.l_lbl_Text.AutoSize = true;
            this.l_lbl_Text.Location = new System.Drawing.Point(7, 83);
            this.l_lbl_Text.Margin = new System.Windows.Forms.Padding(2);
            this.l_lbl_Text.Name = "l_lbl_Text";
            this.l_lbl_Text.Size = new System.Drawing.Size(33, 14);
            this.l_lbl_Text.TabIndex = 17;
            this.l_lbl_Text.Text = "Text";
            // 
            // lbl_Text
            // 
            this.lbl_Text.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Text.Location = new System.Drawing.Point(72, 78);
            this.lbl_Text.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(149, 24);
            this.lbl_Text.TabIndex = 16;
            this.lbl_Text.Text = "Text";
            this.lbl_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Text.Click += new System.EventHandler(this.lbl_Text_Click);
            // 
            // lbl_Color
            // 
            this.lbl_Color.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Color.Location = new System.Drawing.Point(72, 48);
            this.lbl_Color.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_Color.Name = "lbl_Color";
            this.lbl_Color.Size = new System.Drawing.Size(149, 24);
            this.lbl_Color.TabIndex = 8;
            this.lbl_Color.Text = "Type";
            this.lbl_Color.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Color.Click += new System.EventHandler(this.lbl_Color_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Color";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Color";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Type";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type";
            // 
            // combox_ReticleType
            // 
            this.combox_ReticleType.FormattingEnabled = true;
            this.combox_ReticleType.Location = new System.Drawing.Point(72, 18);
            this.combox_ReticleType.Margin = new System.Windows.Forms.Padding(2);
            this.combox_ReticleType.Name = "combox_ReticleType";
            this.combox_ReticleType.Size = new System.Drawing.Size(149, 22);
            this.combox_ReticleType.TabIndex = 5;
            this.combox_ReticleType.SelectedIndexChanged += new System.EventHandler(this.combox_ReticleType_SelectedIndexChanged);
            // 
            // l_gbox_Size
            // 
            this.l_gbox_Size.AccessibleDescription = "Size";
            this.l_gbox_Size.AutoSize = true;
            this.l_gbox_Size.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.l_gbox_Size.Controls.Add(this.button1);
            this.l_gbox_Size.Controls.Add(this.btn_HP);
            this.l_gbox_Size.Controls.Add(this.btn_WP);
            this.l_gbox_Size.Controls.Add(this.btn_WN);
            this.l_gbox_Size.Controls.Add(this.btn_HN);
            this.l_gbox_Size.Controls.Add(this.lbl_WH);
            this.l_gbox_Size.Location = new System.Drawing.Point(123, 214);
            this.l_gbox_Size.Margin = new System.Windows.Forms.Padding(2);
            this.l_gbox_Size.Name = "l_gbox_Size";
            this.l_gbox_Size.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.l_gbox_Size.Size = new System.Drawing.Size(112, 165);
            this.l_gbox_Size.TabIndex = 6;
            this.l_gbox_Size.TabStop = false;
            this.l_gbox_Size.Text = "Size";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_HP
            // 
            this.btn_HP.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HP.Location = new System.Drawing.Point(41, 118);
            this.btn_HP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HP.Name = "btn_HP";
            this.btn_HP.Size = new System.Drawing.Size(30, 30);
            this.btn_HP.TabIndex = 19;
            this.btn_HP.Text = "V";
            this.btn_HP.UseVisualStyleBackColor = true;
            this.btn_HP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_HP_MouseDown);
            this.btn_HP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_HP_MouseUp);
            // 
            // btn_WP
            // 
            this.btn_WP.Location = new System.Drawing.Point(75, 84);
            this.btn_WP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WP.Name = "btn_WP";
            this.btn_WP.Size = new System.Drawing.Size(30, 30);
            this.btn_WP.TabIndex = 18;
            this.btn_WP.Text = ">";
            this.btn_WP.UseVisualStyleBackColor = true;
            this.btn_WP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_WP_MouseDown);
            this.btn_WP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_WP_MouseUp);
            // 
            // btn_WN
            // 
            this.btn_WN.Location = new System.Drawing.Point(7, 84);
            this.btn_WN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_WN.Name = "btn_WN";
            this.btn_WN.Size = new System.Drawing.Size(30, 30);
            this.btn_WN.TabIndex = 17;
            this.btn_WN.Text = "<";
            this.btn_WN.UseVisualStyleBackColor = true;
            this.btn_WN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_WN_MouseDown);
            this.btn_WN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_WN_MouseUp);
            // 
            // btn_HN
            // 
            this.btn_HN.Location = new System.Drawing.Point(41, 50);
            this.btn_HN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HN.Name = "btn_HN";
            this.btn_HN.Size = new System.Drawing.Size(30, 30);
            this.btn_HN.TabIndex = 16;
            this.btn_HN.Text = "^";
            this.btn_HN.UseVisualStyleBackColor = true;
            this.btn_HN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_HN_MouseDown);
            this.btn_HN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_HN_MouseUp);
            // 
            // lbl_WH
            // 
            this.lbl_WH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WH.Location = new System.Drawing.Point(7, 22);
            this.lbl_WH.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_WH.Name = "lbl_WH";
            this.lbl_WH.Size = new System.Drawing.Size(98, 24);
            this.lbl_WH.TabIndex = 13;
            this.lbl_WH.Text = "lbl_WH";
            this.lbl_WH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_gbox_Position
            // 
            this.l_gbox_Position.AccessibleDescription = "Position";
            this.l_gbox_Position.AutoSize = true;
            this.l_gbox_Position.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.l_gbox_Position.Controls.Add(this.btn_Step);
            this.l_gbox_Position.Controls.Add(this.btn_C);
            this.l_gbox_Position.Controls.Add(this.btn_YP);
            this.l_gbox_Position.Controls.Add(this.btn_XP);
            this.l_gbox_Position.Controls.Add(this.btn_XN);
            this.l_gbox_Position.Controls.Add(this.btn_YN);
            this.l_gbox_Position.Controls.Add(this.lbl_XY);
            this.l_gbox_Position.Location = new System.Drawing.Point(7, 214);
            this.l_gbox_Position.Margin = new System.Windows.Forms.Padding(2);
            this.l_gbox_Position.Name = "l_gbox_Position";
            this.l_gbox_Position.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.l_gbox_Position.Size = new System.Drawing.Size(112, 165);
            this.l_gbox_Position.TabIndex = 5;
            this.l_gbox_Position.TabStop = false;
            this.l_gbox_Position.Text = "Position";
            // 
            // btn_Step
            // 
            this.btn_Step.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Step.Location = new System.Drawing.Point(75, 118);
            this.btn_Step.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(30, 30);
            this.btn_Step.TabIndex = 6;
            this.btn_Step.Text = "1";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // btn_C
            // 
            this.btn_C.Location = new System.Drawing.Point(41, 84);
            this.btn_C.Margin = new System.Windows.Forms.Padding(2);
            this.btn_C.Name = "btn_C";
            this.btn_C.Size = new System.Drawing.Size(30, 30);
            this.btn_C.TabIndex = 15;
            this.btn_C.Text = "+";
            this.btn_C.UseVisualStyleBackColor = true;
            this.btn_C.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_C_MouseDown);
            // 
            // btn_YP
            // 
            this.btn_YP.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_YP.Location = new System.Drawing.Point(41, 118);
            this.btn_YP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_YP.Name = "btn_YP";
            this.btn_YP.Size = new System.Drawing.Size(30, 30);
            this.btn_YP.TabIndex = 14;
            this.btn_YP.Text = "V";
            this.btn_YP.UseVisualStyleBackColor = true;
            this.btn_YP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YP_MouseDown);
            this.btn_YP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YP_MouseUp);
            // 
            // btn_XP
            // 
            this.btn_XP.Location = new System.Drawing.Point(75, 84);
            this.btn_XP.Margin = new System.Windows.Forms.Padding(2);
            this.btn_XP.Name = "btn_XP";
            this.btn_XP.Size = new System.Drawing.Size(30, 30);
            this.btn_XP.TabIndex = 13;
            this.btn_XP.Text = ">";
            this.btn_XP.UseVisualStyleBackColor = true;
            this.btn_XP.Click += new System.EventHandler(this.btn_XP_Click);
            this.btn_XP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XP_MouseDown);
            this.btn_XP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XP_MouseUp);
            // 
            // btn_XN
            // 
            this.btn_XN.Location = new System.Drawing.Point(7, 84);
            this.btn_XN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_XN.Name = "btn_XN";
            this.btn_XN.Size = new System.Drawing.Size(30, 30);
            this.btn_XN.TabIndex = 12;
            this.btn_XN.Text = "<";
            this.btn_XN.UseVisualStyleBackColor = true;
            this.btn_XN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_XN_MouseDown);
            this.btn_XN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_XN_MouseUp);
            // 
            // btn_YN
            // 
            this.btn_YN.Location = new System.Drawing.Point(41, 50);
            this.btn_YN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_YN.Name = "btn_YN";
            this.btn_YN.Size = new System.Drawing.Size(30, 30);
            this.btn_YN.TabIndex = 5;
            this.btn_YN.Text = "^";
            this.btn_YN.UseVisualStyleBackColor = true;
            this.btn_YN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_YN_MouseDown);
            this.btn_YN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_YN_MouseUp);
            // 
            // lbl_XY
            // 
            this.lbl_XY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_XY.Location = new System.Drawing.Point(7, 22);
            this.lbl_XY.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_XY.Name = "lbl_XY";
            this.lbl_XY.Size = new System.Drawing.Size(98, 24);
            this.lbl_XY.TabIndex = 11;
            this.lbl_XY.Text = "lbl_XY";
            this.lbl_XY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(540, 7);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 36);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(622, 50);
            this.panel1.TabIndex = 6;
            // 
            // frm_DispCore_ReticleSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(654, 394);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.l_gbox_Size);
            this.Controls.Add(this.lbox_Reticle);
            this.Controls.Add(this.l_gbox_Position);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_DispCore_ReticleSetup";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmReticleSetup";
            this.Load += new System.EventHandler(this.frmReticleSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.l_gbox_Size.ResumeLayout(false);
            this.l_gbox_Position.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_Reticle;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combox_ReticleType;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lbl_WH;
        private System.Windows.Forms.Label lbl_XY;
        private System.Windows.Forms.GroupBox l_gbox_Size;
        private System.Windows.Forms.GroupBox l_gbox_Position;
        private System.Windows.Forms.Button btn_HP;
        private System.Windows.Forms.Button btn_WP;
        private System.Windows.Forms.Button btn_WN;
        private System.Windows.Forms.Button btn_HN;
        private System.Windows.Forms.Button btn_C;
        private System.Windows.Forms.Button btn_YP;
        private System.Windows.Forms.Button btn_XP;
        private System.Windows.Forms.Button btn_XN;
        private System.Windows.Forms.Button btn_YN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.Label l_lbl_Text;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.Label l_lbl_Scale;
        private System.Windows.Forms.Label lbl_Scale;
        private System.Windows.Forms.Panel panel1;
    }
}