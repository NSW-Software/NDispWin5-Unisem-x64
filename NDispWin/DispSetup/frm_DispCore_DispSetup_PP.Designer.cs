namespace NDispWin
{
    partial class frm_DispCore_DispSetup_PP
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
            this.lbl_RecycleNeedleCount = new System.Windows.Forms.Label();
            this.btn_RecycleNeedle = new System.Windows.Forms.Button();
            this.lbl_RemoveAirTime = new System.Windows.Forms.Label();
            this.btn_RemoveAirTimed = new System.Windows.Forms.Button();
            this.btn_Init = new System.Windows.Forms.Button();
            this.lbl_CleanFillCount = new System.Windows.Forms.Label();
            this.btn_Fill = new System.Windows.Forms.Button();
            this.btn_CleanFill = new System.Windows.Forms.Button();
            this.lbl_PurgeShotCount = new System.Windows.Forms.Label();
            this.btn_RecycleBarrel = new System.Windows.Forms.Button();
            this.btn_HeadAB = new System.Windows.Forms.Button();
            this.lbl_RecycleBarrelCount = new System.Windows.Forms.Label();
            this.btn_HeadB = new System.Windows.Forms.Button();
            this.btn_Purge = new System.Windows.Forms.Button();
            this.btn_HeadA = new System.Windows.Forms.Button();
            this.lbl_BarrelPressTime = new System.Windows.Forms.Label();
            this.btn_BarrelPressTimed = new System.Windows.Forms.Button();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.btn_RecycleMethod = new System.Windows.Forms.Button();
            this.btn_RemoveAir = new System.Windows.Forms.Button();
            this.btn_Dummy = new System.Windows.Forms.Button();
            this.btn_Shot = new System.Windows.Forms.Button();
            this.btn_BarrelPress = new System.Windows.Forms.Button();
            this.btn_Func1 = new System.Windows.Forms.Button();
            this.btn_Func2 = new System.Windows.Forms.Button();
            this.btn_Func3 = new System.Windows.Forms.Button();
            this.btn_TrigA = new System.Windows.Forms.Button();
            this.btn_ModeA = new System.Windows.Forms.Button();
            this.btn_TrigB = new System.Windows.Forms.Button();
            this.btn_ModeB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_RecycleNeedleCount
            // 
            this.lbl_RecycleNeedleCount.BackColor = System.Drawing.Color.White;
            this.lbl_RecycleNeedleCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RecycleNeedleCount.Location = new System.Drawing.Point(536, 131);
            this.lbl_RecycleNeedleCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_RecycleNeedleCount.Name = "lbl_RecycleNeedleCount";
            this.lbl_RecycleNeedleCount.Size = new System.Drawing.Size(100, 30);
            this.lbl_RecycleNeedleCount.TabIndex = 54;
            this.lbl_RecycleNeedleCount.Text = "lbl_RecycleNeedle";
            this.lbl_RecycleNeedleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_RecycleNeedleCount.Click += new System.EventHandler(this.lbl_RecycleNeedleCount_Click);
            // 
            // btn_RecycleNeedle
            // 
            this.btn_RecycleNeedle.AccessibleDescription = "Recycle Needle";
            this.btn_RecycleNeedle.Location = new System.Drawing.Point(536, 167);
            this.btn_RecycleNeedle.Name = "btn_RecycleNeedle";
            this.btn_RecycleNeedle.Size = new System.Drawing.Size(100, 40);
            this.btn_RecycleNeedle.TabIndex = 53;
            this.btn_RecycleNeedle.Text = "Recycle Needle";
            this.btn_RecycleNeedle.UseVisualStyleBackColor = true;
            this.btn_RecycleNeedle.Click += new System.EventHandler(this.btn_RecycleNeedle_Click);
            // 
            // lbl_RemoveAirTime
            // 
            this.lbl_RemoveAirTime.BackColor = System.Drawing.Color.White;
            this.lbl_RemoveAirTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RemoveAirTime.Location = new System.Drawing.Point(6, 131);
            this.lbl_RemoveAirTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_RemoveAirTime.Name = "lbl_RemoveAirTime";
            this.lbl_RemoveAirTime.Size = new System.Drawing.Size(100, 30);
            this.lbl_RemoveAirTime.TabIndex = 51;
            this.lbl_RemoveAirTime.Text = "lbl_RemoveAirTime";
            this.lbl_RemoveAirTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_RemoveAirTime.Click += new System.EventHandler(this.lbl_RemoveAirTime_Click);
            // 
            // btn_RemoveAirTimed
            // 
            this.btn_RemoveAirTimed.AccessibleDescription = "Remove Air (T)";
            this.btn_RemoveAirTimed.Location = new System.Drawing.Point(6, 167);
            this.btn_RemoveAirTimed.Name = "btn_RemoveAirTimed";
            this.btn_RemoveAirTimed.Size = new System.Drawing.Size(100, 40);
            this.btn_RemoveAirTimed.TabIndex = 50;
            this.btn_RemoveAirTimed.Text = "Remove Air (T)";
            this.btn_RemoveAirTimed.UseVisualStyleBackColor = true;
            this.btn_RemoveAirTimed.Click += new System.EventHandler(this.btn_RemoveAirTimed_Click);
            // 
            // btn_Init
            // 
            this.btn_Init.AccessibleDescription = "Init";
            this.btn_Init.Location = new System.Drawing.Point(6, 64);
            this.btn_Init.Name = "btn_Init";
            this.btn_Init.Size = new System.Drawing.Size(100, 40);
            this.btn_Init.TabIndex = 49;
            this.btn_Init.Text = "Init";
            this.btn_Init.UseVisualStyleBackColor = true;
            this.btn_Init.Click += new System.EventHandler(this.btn_Init_Click);
            // 
            // lbl_CleanFillCount
            // 
            this.lbl_CleanFillCount.BackColor = System.Drawing.Color.White;
            this.lbl_CleanFillCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CleanFillCount.Location = new System.Drawing.Point(324, 131);
            this.lbl_CleanFillCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_CleanFillCount.Name = "lbl_CleanFillCount";
            this.lbl_CleanFillCount.Size = new System.Drawing.Size(100, 30);
            this.lbl_CleanFillCount.TabIndex = 44;
            this.lbl_CleanFillCount.Text = "10/10 Count";
            this.lbl_CleanFillCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CleanFillCount.Click += new System.EventHandler(this.lbl_CleanFillCount_Click);
            // 
            // btn_Fill
            // 
            this.btn_Fill.AccessibleDescription = "Fill";
            this.btn_Fill.Location = new System.Drawing.Point(112, 64);
            this.btn_Fill.Name = "btn_Fill";
            this.btn_Fill.Size = new System.Drawing.Size(100, 40);
            this.btn_Fill.TabIndex = 39;
            this.btn_Fill.Text = "Fill";
            this.btn_Fill.UseVisualStyleBackColor = true;
            this.btn_Fill.Click += new System.EventHandler(this.btn_Fill_Click);
            // 
            // btn_CleanFill
            // 
            this.btn_CleanFill.AccessibleDescription = "Clean Fill";
            this.btn_CleanFill.Location = new System.Drawing.Point(324, 167);
            this.btn_CleanFill.Name = "btn_CleanFill";
            this.btn_CleanFill.Size = new System.Drawing.Size(100, 40);
            this.btn_CleanFill.TabIndex = 41;
            this.btn_CleanFill.Text = "Clean Fill";
            this.btn_CleanFill.UseVisualStyleBackColor = true;
            this.btn_CleanFill.Click += new System.EventHandler(this.btn_CleanFill_Click);
            // 
            // lbl_PurgeShotCount
            // 
            this.lbl_PurgeShotCount.BackColor = System.Drawing.Color.White;
            this.lbl_PurgeShotCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PurgeShotCount.Location = new System.Drawing.Point(430, 131);
            this.lbl_PurgeShotCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_PurgeShotCount.Name = "lbl_PurgeShotCount";
            this.lbl_PurgeShotCount.Size = new System.Drawing.Size(100, 30);
            this.lbl_PurgeShotCount.TabIndex = 45;
            this.lbl_PurgeShotCount.Text = "lbl_PurgeShotCount";
            this.lbl_PurgeShotCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PurgeShotCount.Click += new System.EventHandler(this.lbl_PurgeShotCount_Click);
            // 
            // btn_RecycleBarrel
            // 
            this.btn_RecycleBarrel.AccessibleDescription = "Recycle Barrel";
            this.btn_RecycleBarrel.Location = new System.Drawing.Point(218, 167);
            this.btn_RecycleBarrel.Name = "btn_RecycleBarrel";
            this.btn_RecycleBarrel.Size = new System.Drawing.Size(100, 40);
            this.btn_RecycleBarrel.TabIndex = 40;
            this.btn_RecycleBarrel.Text = "Recycle Barrel";
            this.btn_RecycleBarrel.UseVisualStyleBackColor = true;
            this.btn_RecycleBarrel.Click += new System.EventHandler(this.btn_RecycleBarrel_Click);
            // 
            // btn_HeadAB
            // 
            this.btn_HeadAB.AccessibleDescription = "Head AB";
            this.btn_HeadAB.Location = new System.Drawing.Point(218, 6);
            this.btn_HeadAB.Name = "btn_HeadAB";
            this.btn_HeadAB.Size = new System.Drawing.Size(100, 30);
            this.btn_HeadAB.TabIndex = 38;
            this.btn_HeadAB.Text = "Head AB";
            this.btn_HeadAB.UseVisualStyleBackColor = true;
            this.btn_HeadAB.Click += new System.EventHandler(this.btn_HeadAB_Click);
            // 
            // lbl_RecycleBarrelCount
            // 
            this.lbl_RecycleBarrelCount.BackColor = System.Drawing.Color.White;
            this.lbl_RecycleBarrelCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_RecycleBarrelCount.Location = new System.Drawing.Point(218, 131);
            this.lbl_RecycleBarrelCount.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_RecycleBarrelCount.Name = "lbl_RecycleBarrelCount";
            this.lbl_RecycleBarrelCount.Size = new System.Drawing.Size(100, 30);
            this.lbl_RecycleBarrelCount.TabIndex = 47;
            this.lbl_RecycleBarrelCount.Text = "lbl_RecycleBarrelCount";
            this.lbl_RecycleBarrelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_RecycleBarrelCount.Click += new System.EventHandler(this.lbl_RecycleBarrelCount_Click);
            // 
            // btn_HeadB
            // 
            this.btn_HeadB.AccessibleDescription = "Head B";
            this.btn_HeadB.Location = new System.Drawing.Point(112, 6);
            this.btn_HeadB.Name = "btn_HeadB";
            this.btn_HeadB.Size = new System.Drawing.Size(100, 30);
            this.btn_HeadB.TabIndex = 37;
            this.btn_HeadB.Text = "Head B";
            this.btn_HeadB.UseVisualStyleBackColor = true;
            this.btn_HeadB.Click += new System.EventHandler(this.btn_HeadB_Click);
            // 
            // btn_Purge
            // 
            this.btn_Purge.AccessibleDescription = "Purge";
            this.btn_Purge.Location = new System.Drawing.Point(430, 213);
            this.btn_Purge.Name = "btn_Purge";
            this.btn_Purge.Size = new System.Drawing.Size(100, 40);
            this.btn_Purge.TabIndex = 42;
            this.btn_Purge.Text = "Purge";
            this.btn_Purge.UseVisualStyleBackColor = true;
            this.btn_Purge.Click += new System.EventHandler(this.btn_Purge_Click);
            // 
            // btn_HeadA
            // 
            this.btn_HeadA.AccessibleDescription = "Head A";
            this.btn_HeadA.Location = new System.Drawing.Point(6, 6);
            this.btn_HeadA.Name = "btn_HeadA";
            this.btn_HeadA.Size = new System.Drawing.Size(100, 30);
            this.btn_HeadA.TabIndex = 36;
            this.btn_HeadA.Text = "Head A";
            this.btn_HeadA.UseVisualStyleBackColor = true;
            this.btn_HeadA.Click += new System.EventHandler(this.btn_HeadA_Click);
            // 
            // lbl_BarrelPressTime
            // 
            this.lbl_BarrelPressTime.BackColor = System.Drawing.Color.White;
            this.lbl_BarrelPressTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_BarrelPressTime.Location = new System.Drawing.Point(112, 131);
            this.lbl_BarrelPressTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_BarrelPressTime.Name = "lbl_BarrelPressTime";
            this.lbl_BarrelPressTime.Size = new System.Drawing.Size(100, 30);
            this.lbl_BarrelPressTime.TabIndex = 46;
            this.lbl_BarrelPressTime.Text = "lbl_BarrelPressTime";
            this.lbl_BarrelPressTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_BarrelPressTime.Click += new System.EventHandler(this.lbl_BarrelPressTime_Click);
            // 
            // btn_BarrelPressTimed
            // 
            this.btn_BarrelPressTimed.AccessibleDescription = "Barrel Press (T)";
            this.btn_BarrelPressTimed.Location = new System.Drawing.Point(112, 167);
            this.btn_BarrelPressTimed.Name = "btn_BarrelPressTimed";
            this.btn_BarrelPressTimed.Size = new System.Drawing.Size(100, 40);
            this.btn_BarrelPressTimed.TabIndex = 43;
            this.btn_BarrelPressTimed.Text = "Barrel Press (T)";
            this.btn_BarrelPressTimed.UseVisualStyleBackColor = true;
            this.btn_BarrelPressTimed.Click += new System.EventHandler(this.btn_BarrelPress_Click);
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // btn_RecycleMethod
            // 
            this.btn_RecycleMethod.AccessibleDescription = "Method";
            this.btn_RecycleMethod.Location = new System.Drawing.Point(218, 213);
            this.btn_RecycleMethod.Name = "btn_RecycleMethod";
            this.btn_RecycleMethod.Size = new System.Drawing.Size(100, 40);
            this.btn_RecycleMethod.TabIndex = 55;
            this.btn_RecycleMethod.Text = "Method";
            this.btn_RecycleMethod.UseVisualStyleBackColor = true;
            this.btn_RecycleMethod.Click += new System.EventHandler(this.btn_RecycleMethod_Click);
            // 
            // btn_RemoveAir
            // 
            this.btn_RemoveAir.AccessibleDescription = "Remove Air";
            this.btn_RemoveAir.Location = new System.Drawing.Point(6, 213);
            this.btn_RemoveAir.Name = "btn_RemoveAir";
            this.btn_RemoveAir.Size = new System.Drawing.Size(100, 40);
            this.btn_RemoveAir.TabIndex = 56;
            this.btn_RemoveAir.Text = "Remove Air";
            this.btn_RemoveAir.UseVisualStyleBackColor = true;
            this.btn_RemoveAir.Click += new System.EventHandler(this.btn_RemoveAir_Click);
            this.btn_RemoveAir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_RemoveAir_MouseDown);
            this.btn_RemoveAir.MouseLeave += new System.EventHandler(this.btn_RemoveAir_MouseLeave);
            this.btn_RemoveAir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_RemoveAir_MouseUp);
            // 
            // btn_Dummy
            // 
            this.btn_Dummy.Location = new System.Drawing.Point(21, 10);
            this.btn_Dummy.Name = "btn_Dummy";
            this.btn_Dummy.Size = new System.Drawing.Size(75, 23);
            this.btn_Dummy.TabIndex = 57;
            this.btn_Dummy.Text = "Dummy";
            this.btn_Dummy.UseVisualStyleBackColor = true;
            // 
            // btn_Shot
            // 
            this.btn_Shot.AccessibleDescription = "Shot";
            this.btn_Shot.Location = new System.Drawing.Point(430, 167);
            this.btn_Shot.Name = "btn_Shot";
            this.btn_Shot.Size = new System.Drawing.Size(100, 40);
            this.btn_Shot.TabIndex = 58;
            this.btn_Shot.Text = "Shot";
            this.btn_Shot.UseVisualStyleBackColor = true;
            this.btn_Shot.Click += new System.EventHandler(this.btn_Shot_Click);
            // 
            // btn_BarrelPress
            // 
            this.btn_BarrelPress.AccessibleDescription = "Barrel Press";
            this.btn_BarrelPress.Location = new System.Drawing.Point(112, 213);
            this.btn_BarrelPress.Name = "btn_BarrelPress";
            this.btn_BarrelPress.Size = new System.Drawing.Size(100, 40);
            this.btn_BarrelPress.TabIndex = 59;
            this.btn_BarrelPress.Text = "Barrel Press";
            this.btn_BarrelPress.UseVisualStyleBackColor = true;
            this.btn_BarrelPress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_BarrelPress_MouseDown);
            this.btn_BarrelPress.MouseLeave += new System.EventHandler(this.btn_BarrelPress_MouseLeave);
            this.btn_BarrelPress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_BarrelPress_MouseUp);
            // 
            // btn_Func1
            // 
            this.btn_Func1.AccessibleDescription = "";
            this.btn_Func1.Location = new System.Drawing.Point(6, 278);
            this.btn_Func1.Name = "btn_Func1";
            this.btn_Func1.Size = new System.Drawing.Size(100, 40);
            this.btn_Func1.TabIndex = 60;
            this.btn_Func1.Text = "Func1";
            this.btn_Func1.UseVisualStyleBackColor = true;
            this.btn_Func1.Click += new System.EventHandler(this.btn_Func1_Click);
            // 
            // btn_Func2
            // 
            this.btn_Func2.AccessibleDescription = "";
            this.btn_Func2.Location = new System.Drawing.Point(112, 278);
            this.btn_Func2.Name = "btn_Func2";
            this.btn_Func2.Size = new System.Drawing.Size(100, 40);
            this.btn_Func2.TabIndex = 61;
            this.btn_Func2.Text = "Func2";
            this.btn_Func2.UseVisualStyleBackColor = true;
            this.btn_Func2.Click += new System.EventHandler(this.btn_Func2_Click);
            // 
            // btn_Func3
            // 
            this.btn_Func3.AccessibleDescription = "";
            this.btn_Func3.Location = new System.Drawing.Point(218, 278);
            this.btn_Func3.Name = "btn_Func3";
            this.btn_Func3.Size = new System.Drawing.Size(100, 40);
            this.btn_Func3.TabIndex = 62;
            this.btn_Func3.Text = "Func3";
            this.btn_Func3.UseVisualStyleBackColor = true;
            this.btn_Func3.Click += new System.EventHandler(this.btn_Func3_Click);
            // 
            // btn_TrigA
            // 
            this.btn_TrigA.AccessibleDescription = "Trig";
            this.btn_TrigA.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_TrigA.Location = new System.Drawing.Point(530, 62);
            this.btn_TrigA.Name = "btn_TrigA";
            this.btn_TrigA.Size = new System.Drawing.Size(50, 50);
            this.btn_TrigA.TabIndex = 63;
            this.btn_TrigA.Text = "Trig";
            this.btn_TrigA.UseVisualStyleBackColor = false;
            this.btn_TrigA.Click += new System.EventHandler(this.btn_TrigA_Click);
            this.btn_TrigA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_TrigA_MouseDown);
            this.btn_TrigA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_TrigA_MouseUp);
            // 
            // btn_ModeA
            // 
            this.btn_ModeA.AccessibleDescription = "Mode";
            this.btn_ModeA.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_ModeA.Location = new System.Drawing.Point(530, 6);
            this.btn_ModeA.Name = "btn_ModeA";
            this.btn_ModeA.Size = new System.Drawing.Size(50, 50);
            this.btn_ModeA.TabIndex = 64;
            this.btn_ModeA.Text = "Mode";
            this.btn_ModeA.UseVisualStyleBackColor = false;
            this.btn_ModeA.Click += new System.EventHandler(this.btn_ModeA_Click);
            // 
            // btn_TrigB
            // 
            this.btn_TrigB.AccessibleDescription = "Trig";
            this.btn_TrigB.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_TrigB.Location = new System.Drawing.Point(586, 62);
            this.btn_TrigB.Name = "btn_TrigB";
            this.btn_TrigB.Size = new System.Drawing.Size(50, 50);
            this.btn_TrigB.TabIndex = 65;
            this.btn_TrigB.Text = "Trig";
            this.btn_TrigB.UseVisualStyleBackColor = false;
            this.btn_TrigB.Click += new System.EventHandler(this.btn_TrigB_Click);
            this.btn_TrigB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_TrigB_MouseDown);
            this.btn_TrigB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_TrigB_MouseUp);
            // 
            // btn_ModeB
            // 
            this.btn_ModeB.AccessibleDescription = "Mode";
            this.btn_ModeB.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_ModeB.Location = new System.Drawing.Point(586, 6);
            this.btn_ModeB.Name = "btn_ModeB";
            this.btn_ModeB.Size = new System.Drawing.Size(50, 50);
            this.btn_ModeB.TabIndex = 66;
            this.btn_ModeB.Text = "Mode";
            this.btn_ModeB.UseVisualStyleBackColor = false;
            this.btn_ModeB.Click += new System.EventHandler(this.btn_ModeB_Click);
            // 
            // frm_DispCore_DispSetup_PP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(642, 322);
            this.Controls.Add(this.btn_ModeB);
            this.Controls.Add(this.btn_TrigB);
            this.Controls.Add(this.btn_ModeA);
            this.Controls.Add(this.btn_TrigA);
            this.Controls.Add(this.btn_Func3);
            this.Controls.Add(this.btn_Func2);
            this.Controls.Add(this.btn_Func1);
            this.Controls.Add(this.btn_BarrelPress);
            this.Controls.Add(this.btn_Shot);
            this.Controls.Add(this.btn_RemoveAir);
            this.Controls.Add(this.btn_RecycleMethod);
            this.Controls.Add(this.lbl_RecycleNeedleCount);
            this.Controls.Add(this.btn_RecycleNeedle);
            this.Controls.Add(this.lbl_RemoveAirTime);
            this.Controls.Add(this.btn_RemoveAirTimed);
            this.Controls.Add(this.btn_Init);
            this.Controls.Add(this.lbl_CleanFillCount);
            this.Controls.Add(this.btn_Fill);
            this.Controls.Add(this.btn_CleanFill);
            this.Controls.Add(this.lbl_PurgeShotCount);
            this.Controls.Add(this.btn_RecycleBarrel);
            this.Controls.Add(this.btn_HeadAB);
            this.Controls.Add(this.lbl_RecycleBarrelCount);
            this.Controls.Add(this.btn_HeadB);
            this.Controls.Add(this.btn_Purge);
            this.Controls.Add(this.btn_HeadA);
            this.Controls.Add(this.lbl_BarrelPressTime);
            this.Controls.Add(this.btn_BarrelPressTimed);
            this.Controls.Add(this.btn_Dummy);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frm_DispCore_DispSetup_PP";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_DispCore_DispSetup_PP";
            this.Load += new System.EventHandler(this.frm_DispCore_DispSetup_PP_Load);
            this.Shown += new System.EventHandler(this.frm_DispCore_DispSetup_PP_Shown);
            this.VisibleChanged += new System.EventHandler(this.frm_DispCore_DispSetup_PP_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_RecycleNeedleCount;
        private System.Windows.Forms.Button btn_RecycleNeedle;
        private System.Windows.Forms.Label lbl_RemoveAirTime;
        private System.Windows.Forms.Button btn_RemoveAirTimed;
        private System.Windows.Forms.Button btn_Init;
        private System.Windows.Forms.Label lbl_CleanFillCount;
        private System.Windows.Forms.Button btn_Fill;
        private System.Windows.Forms.Button btn_CleanFill;
        private System.Windows.Forms.Label lbl_PurgeShotCount;
        private System.Windows.Forms.Button btn_RecycleBarrel;
        private System.Windows.Forms.Button btn_HeadAB;
        private System.Windows.Forms.Label lbl_RecycleBarrelCount;
        private System.Windows.Forms.Button btn_HeadB;
        private System.Windows.Forms.Button btn_Purge;
        private System.Windows.Forms.Button btn_HeadA;
        private System.Windows.Forms.Label lbl_BarrelPressTime;
        private System.Windows.Forms.Button btn_BarrelPressTimed;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Button btn_RecycleMethod;
        private System.Windows.Forms.Button btn_RemoveAir;
        private System.Windows.Forms.Button btn_Dummy;
        private System.Windows.Forms.Button btn_Shot;
        private System.Windows.Forms.Button btn_BarrelPress;
        private System.Windows.Forms.Button btn_Func1;
        private System.Windows.Forms.Button btn_Func2;
        private System.Windows.Forms.Button btn_Func3;
        private System.Windows.Forms.Button btn_TrigA;
        private System.Windows.Forms.Button btn_ModeA;
        private System.Windows.Forms.Button btn_TrigB;
        private System.Windows.Forms.Button btn_ModeB;
    }
}