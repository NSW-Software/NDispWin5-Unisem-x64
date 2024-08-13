namespace NDispWin
{
    partial class frmFlowRateCal
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
            this.btn_Head1 = new System.Windows.Forms.Button();
            this.btn_Head2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentFlowRate2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblCurrentFlowRate = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Tare = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_WeightCurrentValue = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrWeightDisplay = new System.Windows.Forms.Timer(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_TargetUnit = new System.Windows.Forms.Label();
            this.lblNoToAverage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMinPressure = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMaxPressure = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTargetFlowRate = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTargetFlowRateTol = new System.Windows.Forms.Label();
            this.cbAutoCalibrateFrame = new System.Windows.Forms.CheckBox();
            this.lblAutoCalFrameInterval = new System.Windows.Forms.Label();
            this.lblAutoCalUnitInterval = new System.Windows.Forms.Label();
            this.cbAutoCalibrateUnit = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlTargetFlowRate = new System.Windows.Forms.Panel();
            this.cbEnableTargetFlowrate = new System.Windows.Forms.CheckBox();
            this.btnResetInteval = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTimeCompensate = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAutoFit = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblIntercept = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblSlope = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlTargetFlowRate.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Head1
            // 
            this.btn_Head1.AccessibleDescription = "Head 1";
            this.btn_Head1.Location = new System.Drawing.Point(140, 5);
            this.btn_Head1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head1.Name = "btn_Head1";
            this.btn_Head1.Size = new System.Drawing.Size(82, 32);
            this.btn_Head1.TabIndex = 200;
            this.btn_Head1.Text = "Head 1";
            this.btn_Head1.UseVisualStyleBackColor = true;
            this.btn_Head1.Click += new System.EventHandler(this.btn_Head1_Click);
            // 
            // btn_Head2
            // 
            this.btn_Head2.AccessibleDescription = "Head 2";
            this.btn_Head2.Location = new System.Drawing.Point(226, 5);
            this.btn_Head2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head2.Name = "btn_Head2";
            this.btn_Head2.Size = new System.Drawing.Size(82, 32);
            this.btn_Head2.TabIndex = 199;
            this.btn_Head2.Text = "Head 2";
            this.btn_Head2.UseVisualStyleBackColor = true;
            this.btn_Head2.Click += new System.EventHandler(this.btn_Head2_Click);
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "Head";
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 32);
            this.label13.TabIndex = 198;
            this.label13.Text = "Head";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "Close";
            this.btnClose.Location = new System.Drawing.Point(641, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 32);
            this.btnClose.TabIndex = 202;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lblCurrentFlowRate2);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblCurrentFlowRate);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_Tare);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lbl_WeightCurrentValue);
            this.groupBox3.Location = new System.Drawing.Point(6, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox3.Size = new System.Drawing.Size(302, 141);
            this.groupBox3.TabIndex = 203;
            this.groupBox3.TabStop = false;
            // 
            // lblCurrentFlowRate2
            // 
            this.lblCurrentFlowRate2.BackColor = System.Drawing.Color.White;
            this.lblCurrentFlowRate2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentFlowRate2.Enabled = false;
            this.lblCurrentFlowRate2.Location = new System.Drawing.Point(227, 101);
            this.lblCurrentFlowRate2.Margin = new System.Windows.Forms.Padding(2);
            this.lblCurrentFlowRate2.Name = "lblCurrentFlowRate2";
            this.lblCurrentFlowRate2.Size = new System.Drawing.Size(70, 23);
            this.lblCurrentFlowRate2.TabIndex = 213;
            this.lblCurrentFlowRate2.Text = "3";
            this.lblCurrentFlowRate2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(153, 101);
            this.label20.Margin = new System.Windows.Forms.Padding(2);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 23);
            this.label20.TabIndex = 214;
            this.label20.Text = "(mg/s)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "Weight";
            this.label21.Location = new System.Drawing.Point(5, 101);
            this.label21.Margin = new System.Windows.Forms.Padding(2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(170, 23);
            this.label21.TabIndex = 212;
            this.label21.Text = "Current FlowRate Head 2";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentFlowRate
            // 
            this.lblCurrentFlowRate.BackColor = System.Drawing.Color.White;
            this.lblCurrentFlowRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentFlowRate.Enabled = false;
            this.lblCurrentFlowRate.Location = new System.Drawing.Point(227, 74);
            this.lblCurrentFlowRate.Margin = new System.Windows.Forms.Padding(2);
            this.lblCurrentFlowRate.Name = "lblCurrentFlowRate";
            this.lblCurrentFlowRate.Size = new System.Drawing.Size(70, 23);
            this.lblCurrentFlowRate.TabIndex = 210;
            this.lblCurrentFlowRate.Text = "3";
            this.lblCurrentFlowRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(153, 74);
            this.label19.Margin = new System.Windows.Forms.Padding(2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 23);
            this.label19.TabIndex = 211;
            this.label19.Text = "(mg/s)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Weight";
            this.label1.Location = new System.Drawing.Point(5, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 195;
            this.label1.Text = "Current FlowRate Head 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Tare
            // 
            this.btn_Tare.AccessibleDescription = "Tare";
            this.btn_Tare.Location = new System.Drawing.Point(227, 47);
            this.btn_Tare.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Tare.Name = "btn_Tare";
            this.btn_Tare.Size = new System.Drawing.Size(70, 23);
            this.btn_Tare.TabIndex = 194;
            this.btn_Tare.Text = "Tare";
            this.btn_Tare.UseVisualStyleBackColor = true;
            this.btn_Tare.Click += new System.EventHandler(this.btn_Tare_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(153, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 23);
            this.label3.TabIndex = 189;
            this.label3.Text = "(mg)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Weight";
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 162;
            this.label4.Text = "Weight";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_WeightCurrentValue
            // 
            this.lbl_WeightCurrentValue.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_WeightCurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_WeightCurrentValue.Location = new System.Drawing.Point(227, 20);
            this.lbl_WeightCurrentValue.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_WeightCurrentValue.Name = "lbl_WeightCurrentValue";
            this.lbl_WeightCurrentValue.Size = new System.Drawing.Size(70, 23);
            this.lbl_WeightCurrentValue.TabIndex = 161;
            this.lbl_WeightCurrentValue.Text = "0.0000";
            this.lbl_WeightCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStart
            // 
            this.btnStart.AccessibleDescription = "Start";
            this.btnStart.Location = new System.Drawing.Point(313, 93);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(70, 30);
            this.btnStart.TabIndex = 168;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrWeightDisplay
            // 
            this.tmrWeightDisplay.Enabled = true;
            this.tmrWeightDisplay.Tick += new System.EventHandler(this.tmrWeightDisplay_Tick);
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleDescription = "Close";
            this.btnSettings.Location = new System.Drawing.Point(388, 4);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 32);
            this.btnSettings.TabIndex = 206;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 14;
            this.lbxLog.Location = new System.Drawing.Point(388, 41);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(323, 438);
            this.lbxLog.TabIndex = 207;
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "";
            this.label16.Location = new System.Drawing.Point(5, 41);
            this.label16.Margin = new System.Windows.Forms.Padding(2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 23);
            this.label16.TabIndex = 208;
            this.label16.Text = "Result";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResult2
            // 
            this.lblResult2.BackColor = System.Drawing.SystemColors.Control;
            this.lblResult2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult2.Location = new System.Drawing.Point(226, 41);
            this.lblResult2.Margin = new System.Windows.Forms.Padding(2);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(82, 23);
            this.lblResult2.TabIndex = 210;
            this.lblResult2.Text = "-";
            this.lblResult2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult1
            // 
            this.lblResult1.BackColor = System.Drawing.SystemColors.Control;
            this.lblResult1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult1.Location = new System.Drawing.Point(140, 41);
            this.lblResult1.Margin = new System.Windows.Forms.Padding(2);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(82, 23);
            this.lblResult1.TabIndex = 209;
            this.lblResult1.Text = "-";
            this.lblResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = "";
            this.btnSave.Location = new System.Drawing.Point(567, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 32);
            this.btnSave.TabIndex = 211;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(313, 188);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 212;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl_TargetUnit
            // 
            this.lbl_TargetUnit.Location = new System.Drawing.Point(153, 12);
            this.lbl_TargetUnit.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TargetUnit.Name = "lbl_TargetUnit";
            this.lbl_TargetUnit.Size = new System.Drawing.Size(70, 23);
            this.lbl_TargetUnit.TabIndex = 193;
            this.lbl_TargetUnit.Text = "(frames)";
            this.lbl_TargetUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoToAverage
            // 
            this.lblNoToAverage.BackColor = System.Drawing.Color.White;
            this.lblNoToAverage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNoToAverage.Location = new System.Drawing.Point(227, 84);
            this.lblNoToAverage.Margin = new System.Windows.Forms.Padding(2);
            this.lblNoToAverage.Name = "lblNoToAverage";
            this.lblNoToAverage.Size = new System.Drawing.Size(70, 23);
            this.lblNoToAverage.TabIndex = 192;
            this.lblNoToAverage.Text = "3";
            this.lblNoToAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoToAverage.Click += new System.EventHandler(this.lblNoToAverage_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(153, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 196;
            this.label5.Text = "(s)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Weight";
            this.label2.Location = new System.Drawing.Point(5, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 194;
            this.label2.Text = "No To Average";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.White;
            this.lblDuration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDuration.Location = new System.Drawing.Point(227, 111);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(2);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(70, 23);
            this.lblDuration.TabIndex = 195;
            this.lblDuration.Text = "2";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDuration.Click += new System.EventHandler(this.lblDuration_Click);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.Location = new System.Drawing.Point(5, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 23);
            this.label6.TabIndex = 197;
            this.label6.Text = "Duration";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.Location = new System.Drawing.Point(5, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 23);
            this.label7.TabIndex = 198;
            this.label7.Text = "Delay";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(153, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 23);
            this.label9.TabIndex = 200;
            this.label9.Text = "(s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDelay
            // 
            this.lblDelay.BackColor = System.Drawing.Color.White;
            this.lblDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDelay.Location = new System.Drawing.Point(227, 138);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(2);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(70, 23);
            this.lblDelay.TabIndex = 199;
            this.lblDelay.Text = "1";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDelay.Click += new System.EventHandler(this.lblDelay_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.Location = new System.Drawing.Point(5, 184);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 23);
            this.label10.TabIndex = 201;
            this.label10.Text = "Min Pressure";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(153, 184);
            this.label8.Margin = new System.Windows.Forms.Padding(2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 203;
            this.label8.Text = "(mPa)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMinPressure
            // 
            this.lblMinPressure.BackColor = System.Drawing.Color.White;
            this.lblMinPressure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinPressure.Location = new System.Drawing.Point(227, 184);
            this.lblMinPressure.Margin = new System.Windows.Forms.Padding(2);
            this.lblMinPressure.Name = "lblMinPressure";
            this.lblMinPressure.Size = new System.Drawing.Size(70, 23);
            this.lblMinPressure.TabIndex = 202;
            this.lblMinPressure.Text = "1";
            this.lblMinPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMinPressure.Click += new System.EventHandler(this.lblMinPressure_Click);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "";
            this.label14.Location = new System.Drawing.Point(5, 211);
            this.label14.Margin = new System.Windows.Forms.Padding(2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 23);
            this.label14.TabIndex = 204;
            this.label14.Text = "Max Pressure";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(153, 211);
            this.label12.Margin = new System.Windows.Forms.Padding(2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 23);
            this.label12.TabIndex = 206;
            this.label12.Text = "(mPa)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaxPressure
            // 
            this.lblMaxPressure.BackColor = System.Drawing.Color.White;
            this.lblMaxPressure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaxPressure.Location = new System.Drawing.Point(227, 211);
            this.lblMaxPressure.Margin = new System.Windows.Forms.Padding(2);
            this.lblMaxPressure.Name = "lblMaxPressure";
            this.lblMaxPressure.Size = new System.Drawing.Size(70, 23);
            this.lblMaxPressure.TabIndex = 205;
            this.lblMaxPressure.Text = "3";
            this.lblMaxPressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMaxPressure.Click += new System.EventHandler(this.lblMaxPressure_Click);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "";
            this.label15.Location = new System.Drawing.Point(11, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 23);
            this.label15.TabIndex = 207;
            this.label15.Text = "Target Flow Rate";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(147, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 23);
            this.label11.TabIndex = 209;
            this.label11.Text = "(mg/s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTargetFlowRate
            // 
            this.lblTargetFlowRate.BackColor = System.Drawing.Color.White;
            this.lblTargetFlowRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetFlowRate.Location = new System.Drawing.Point(221, 0);
            this.lblTargetFlowRate.Margin = new System.Windows.Forms.Padding(2);
            this.lblTargetFlowRate.Name = "lblTargetFlowRate";
            this.lblTargetFlowRate.Size = new System.Drawing.Size(70, 23);
            this.lblTargetFlowRate.TabIndex = 208;
            this.lblTargetFlowRate.Text = "3";
            this.lblTargetFlowRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTargetFlowRate.Click += new System.EventHandler(this.lblTargetFlowRate_Click);
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "";
            this.label18.Location = new System.Drawing.Point(11, 27);
            this.label18.Margin = new System.Windows.Forms.Padding(2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(154, 23);
            this.label18.TabIndex = 210;
            this.label18.Text = "Tolerance";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(147, 27);
            this.label17.Margin = new System.Windows.Forms.Padding(2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 23);
            this.label17.TabIndex = 212;
            this.label17.Text = "(mg/s)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTargetFlowRateTol
            // 
            this.lblTargetFlowRateTol.BackColor = System.Drawing.Color.White;
            this.lblTargetFlowRateTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetFlowRateTol.Location = new System.Drawing.Point(221, 27);
            this.lblTargetFlowRateTol.Margin = new System.Windows.Forms.Padding(2);
            this.lblTargetFlowRateTol.Name = "lblTargetFlowRateTol";
            this.lblTargetFlowRateTol.Size = new System.Drawing.Size(70, 23);
            this.lblTargetFlowRateTol.TabIndex = 211;
            this.lblTargetFlowRateTol.Text = "0.1";
            this.lblTargetFlowRateTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTargetFlowRateTol.Click += new System.EventHandler(this.lblTargetFlowRateTol_Click);
            // 
            // cbAutoCalibrateFrame
            // 
            this.cbAutoCalibrateFrame.AutoSize = true;
            this.cbAutoCalibrateFrame.Location = new System.Drawing.Point(6, 15);
            this.cbAutoCalibrateFrame.Name = "cbAutoCalibrateFrame";
            this.cbAutoCalibrateFrame.Size = new System.Drawing.Size(152, 18);
            this.cbAutoCalibrateFrame.TabIndex = 213;
            this.cbAutoCalibrateFrame.Text = "Auto Calibrate Interval ";
            this.cbAutoCalibrateFrame.UseVisualStyleBackColor = true;
            this.cbAutoCalibrateFrame.Click += new System.EventHandler(this.cbAutoCalibrateFrame_Click);
            // 
            // lblAutoCalFrameInterval
            // 
            this.lblAutoCalFrameInterval.BackColor = System.Drawing.Color.White;
            this.lblAutoCalFrameInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAutoCalFrameInterval.Location = new System.Drawing.Point(227, 12);
            this.lblAutoCalFrameInterval.Margin = new System.Windows.Forms.Padding(2);
            this.lblAutoCalFrameInterval.Name = "lblAutoCalFrameInterval";
            this.lblAutoCalFrameInterval.Size = new System.Drawing.Size(70, 23);
            this.lblAutoCalFrameInterval.TabIndex = 214;
            this.lblAutoCalFrameInterval.Text = "10";
            this.lblAutoCalFrameInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAutoCalFrameInterval.Click += new System.EventHandler(this.lblAutoCalFrameInterval_Click);
            // 
            // lblAutoCalUnitInterval
            // 
            this.lblAutoCalUnitInterval.BackColor = System.Drawing.Color.White;
            this.lblAutoCalUnitInterval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAutoCalUnitInterval.Location = new System.Drawing.Point(227, 39);
            this.lblAutoCalUnitInterval.Margin = new System.Windows.Forms.Padding(2);
            this.lblAutoCalUnitInterval.Name = "lblAutoCalUnitInterval";
            this.lblAutoCalUnitInterval.Size = new System.Drawing.Size(70, 23);
            this.lblAutoCalUnitInterval.TabIndex = 217;
            this.lblAutoCalUnitInterval.Text = "10";
            this.lblAutoCalUnitInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAutoCalUnitInterval.Click += new System.EventHandler(this.lblAutoCalUnitInterval_Click);
            // 
            // cbAutoCalibrateUnit
            // 
            this.cbAutoCalibrateUnit.AutoSize = true;
            this.cbAutoCalibrateUnit.Location = new System.Drawing.Point(6, 42);
            this.cbAutoCalibrateUnit.Name = "cbAutoCalibrateUnit";
            this.cbAutoCalibrateUnit.Size = new System.Drawing.Size(152, 18);
            this.cbAutoCalibrateUnit.TabIndex = 216;
            this.cbAutoCalibrateUnit.Text = "Auto Calibrate Interval ";
            this.cbAutoCalibrateUnit.UseVisualStyleBackColor = true;
            this.cbAutoCalibrateUnit.Click += new System.EventHandler(this.cbAutoCalibrateUnit_Click);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(153, 39);
            this.label23.Margin = new System.Windows.Forms.Padding(2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 23);
            this.label23.TabIndex = 215;
            this.label23.Text = "(units)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 30);
            this.tabControl1.Location = new System.Drawing.Point(6, 227);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 379);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 213;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlTargetFlowRate);
            this.tabPage1.Controls.Add(this.cbEnableTargetFlowrate);
            this.tabPage1.Controls.Add(this.btnResetInteval);
            this.tabPage1.Controls.Add(this.lblAutoCalUnitInterval);
            this.tabPage1.Controls.Add(this.cbAutoCalibrateFrame);
            this.tabPage1.Controls.Add(this.cbAutoCalibrateUnit);
            this.tabPage1.Controls.Add(this.lbl_TargetUnit);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.lblNoToAverage);
            this.tabPage1.Controls.Add(this.lblAutoCalFrameInterval);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblDuration);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lblDelay);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lblMaxPressure);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.lblMinPressure);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            // 
            // pnlTargetFlowRate
            // 
            this.pnlTargetFlowRate.AutoSize = true;
            this.pnlTargetFlowRate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTargetFlowRate.Controls.Add(this.lblTargetFlowRate);
            this.pnlTargetFlowRate.Controls.Add(this.label11);
            this.pnlTargetFlowRate.Controls.Add(this.label17);
            this.pnlTargetFlowRate.Controls.Add(this.lblTargetFlowRateTol);
            this.pnlTargetFlowRate.Controls.Add(this.label15);
            this.pnlTargetFlowRate.Controls.Add(this.label18);
            this.pnlTargetFlowRate.Location = new System.Drawing.Point(6, 282);
            this.pnlTargetFlowRate.Name = "pnlTargetFlowRate";
            this.pnlTargetFlowRate.Size = new System.Drawing.Size(293, 52);
            this.pnlTargetFlowRate.TabIndex = 220;
            // 
            // cbEnableTargetFlowrate
            // 
            this.cbEnableTargetFlowrate.Location = new System.Drawing.Point(6, 257);
            this.cbEnableTargetFlowrate.Name = "cbEnableTargetFlowrate";
            this.cbEnableTargetFlowrate.Size = new System.Drawing.Size(192, 19);
            this.cbEnableTargetFlowrate.TabIndex = 219;
            this.cbEnableTargetFlowrate.Text = "Enable Target Flowrate";
            this.cbEnableTargetFlowrate.UseVisualStyleBackColor = true;
            this.cbEnableTargetFlowrate.Click += new System.EventHandler(this.cbEnableTargetFlowrate_Click);
            // 
            // btnResetInteval
            // 
            this.btnResetInteval.AccessibleDescription = "";
            this.btnResetInteval.Location = new System.Drawing.Point(303, 12);
            this.btnResetInteval.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetInteval.Name = "btnResetInteval";
            this.btnResetInteval.Size = new System.Drawing.Size(61, 50);
            this.btnResetInteval.TabIndex = 218;
            this.btnResetInteval.Text = "Reset";
            this.btnResetInteval.UseVisualStyleBackColor = true;
            this.btnResetInteval.Click += new System.EventHandler(this.btnResetInteval_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.lblTimeCompensate);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.btnAutoFit);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.lblIntercept);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.lblSlope);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(368, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advance";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(153, 135);
            this.label22.Margin = new System.Windows.Forms.Padding(2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 23);
            this.label22.TabIndex = 210;
            this.label22.Text = "(%)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeCompensate
            // 
            this.lblTimeCompensate.BackColor = System.Drawing.Color.White;
            this.lblTimeCompensate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimeCompensate.Location = new System.Drawing.Point(227, 135);
            this.lblTimeCompensate.Margin = new System.Windows.Forms.Padding(2);
            this.lblTimeCompensate.Name = "lblTimeCompensate";
            this.lblTimeCompensate.Size = new System.Drawing.Size(70, 23);
            this.lblTimeCompensate.TabIndex = 209;
            this.lblTimeCompensate.Text = "2";
            this.lblTimeCompensate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimeCompensate.Click += new System.EventHandler(this.lblTimeCompensate_Click);
            // 
            // label30
            // 
            this.label30.AccessibleDescription = "";
            this.label30.Location = new System.Drawing.Point(5, 135);
            this.label30.Margin = new System.Windows.Forms.Padding(2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(154, 23);
            this.label30.TabIndex = 211;
            this.label30.Text = "Time Compensate";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReset
            // 
            this.btnReset.AccessibleDescription = "";
            this.btnReset.Location = new System.Drawing.Point(220, 82);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 30);
            this.btnReset.TabIndex = 208;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAutoFit
            // 
            this.btnAutoFit.AccessibleDescription = "";
            this.btnAutoFit.Location = new System.Drawing.Point(294, 82);
            this.btnAutoFit.Margin = new System.Windows.Forms.Padding(2);
            this.btnAutoFit.Name = "btnAutoFit";
            this.btnAutoFit.Size = new System.Drawing.Size(70, 30);
            this.btnAutoFit.TabIndex = 207;
            this.btnAutoFit.Text = "Auto";
            this.btnAutoFit.UseVisualStyleBackColor = true;
            this.btnAutoFit.Click += new System.EventHandler(this.btnAutoFit_Click);
            // 
            // label27
            // 
            this.label27.AccessibleDescription = "Weight";
            this.label27.Location = new System.Drawing.Point(102, 86);
            this.label27.Margin = new System.Windows.Forms.Padding(2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 23);
            this.label27.TabIndex = 206;
            this.label27.Text = "c = ";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.AccessibleDescription = "Weight";
            this.label29.Location = new System.Drawing.Point(102, 32);
            this.label29.Margin = new System.Windows.Forms.Padding(2);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 23);
            this.label29.TabIndex = 205;
            this.label29.Text = "where";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AccessibleDescription = "Weight";
            this.label25.Location = new System.Drawing.Point(102, 59);
            this.label25.Margin = new System.Windows.Forms.Padding(2);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 23);
            this.label25.TabIndex = 204;
            this.label25.Text = "m = ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Weight";
            this.label24.Location = new System.Drawing.Point(102, 5);
            this.label24.Margin = new System.Windows.Forms.Padding(2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(160, 23);
            this.label24.TabIndex = 203;
            this.label24.Text = "Weight = m*Pressure + c";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntercept
            // 
            this.lblIntercept.BackColor = System.Drawing.Color.White;
            this.lblIntercept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIntercept.Location = new System.Drawing.Point(146, 86);
            this.lblIntercept.Margin = new System.Windows.Forms.Padding(2);
            this.lblIntercept.Name = "lblIntercept";
            this.lblIntercept.Size = new System.Drawing.Size(70, 23);
            this.lblIntercept.TabIndex = 198;
            this.lblIntercept.Text = "0";
            this.lblIntercept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblIntercept.Click += new System.EventHandler(this.lblIntercept_Click);
            // 
            // label28
            // 
            this.label28.AccessibleDescription = "Weight";
            this.label28.Location = new System.Drawing.Point(5, 5);
            this.label28.Margin = new System.Windows.Forms.Padding(2);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(110, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Approximate Fit";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSlope
            // 
            this.lblSlope.BackColor = System.Drawing.Color.White;
            this.lblSlope.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSlope.Location = new System.Drawing.Point(146, 59);
            this.lblSlope.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlope.Name = "lblSlope";
            this.lblSlope.Size = new System.Drawing.Size(70, 23);
            this.lblSlope.TabIndex = 200;
            this.lblSlope.Text = "0";
            this.lblSlope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSlope.Click += new System.EventHandler(this.lblSlope_Click);
            // 
            // frmFlowRateCal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(747, 620);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_Head1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btn_Head2);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFlowRateCal";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmFlowRateCal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFlowRateCal_FormClosing);
            this.Load += new System.EventHandler(this.frmFlowRateCal_Load);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlTargetFlowRate.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Head1;
        private System.Windows.Forms.Button btn_Head2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Tare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_WeightCurrentValue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrWeightDisplay;
        private System.Windows.Forms.Label lblCurrentFlowRate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentFlowRate2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_TargetUnit;
        private System.Windows.Forms.Label lblNoToAverage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMinPressure;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMaxPressure;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTargetFlowRate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTargetFlowRateTol;
        private System.Windows.Forms.CheckBox cbAutoCalibrateFrame;
        private System.Windows.Forms.Label lblAutoCalFrameInterval;
        private System.Windows.Forms.Label lblAutoCalUnitInterval;
        private System.Windows.Forms.CheckBox cbAutoCalibrateUnit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblIntercept;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblSlope;
        private System.Windows.Forms.Button btnAutoFit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnResetInteval;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTimeCompensate;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel pnlTargetFlowRate;
        private System.Windows.Forms.CheckBox cbEnableTargetFlowrate;
    }
}