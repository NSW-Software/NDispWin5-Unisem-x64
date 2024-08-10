namespace NDispWin
{
    partial class frmWeightMeasure
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
            this.btnSettings = new System.Windows.Forms.Button();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.cbEnableTargetWeight = new System.Windows.Forms.CheckBox();
            this.lbl_TargetUnit = new System.Windows.Forms.Label();
            this.lblTargetWeight = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSampleCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlDuration = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWeightSpecTol = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vsbar_Zoom = new System.Windows.Forms.VScrollBar();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tmrWeightDisplay = new System.Windows.Forms.Timer(this.components);
            this.lbxLog = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Head1
            // 
            this.btn_Head1.AccessibleDescription = "Head 1";
            this.btn_Head1.Location = new System.Drawing.Point(140, 6);
            this.btn_Head1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head1.Name = "btn_Head1";
            this.btn_Head1.Size = new System.Drawing.Size(82, 32);
            this.btn_Head1.TabIndex = 203;
            this.btn_Head1.Text = "Head 1";
            this.btn_Head1.UseVisualStyleBackColor = true;
            this.btn_Head1.Click += new System.EventHandler(this.btn_Head1_Click);
            // 
            // btn_Head2
            // 
            this.btn_Head2.AccessibleDescription = "Head 2";
            this.btn_Head2.Location = new System.Drawing.Point(226, 6);
            this.btn_Head2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Head2.Name = "btn_Head2";
            this.btn_Head2.Size = new System.Drawing.Size(82, 32);
            this.btn_Head2.TabIndex = 202;
            this.btn_Head2.Text = "Head 2";
            this.btn_Head2.UseVisualStyleBackColor = true;
            this.btn_Head2.Click += new System.EventHandler(this.btn_Head2_Click);
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "Head";
            this.label13.Location = new System.Drawing.Point(6, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 32);
            this.label13.TabIndex = 201;
            this.label13.Text = "Head";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSettings
            // 
            this.btnSettings.AccessibleDescription = "Close";
            this.btnSettings.Location = new System.Drawing.Point(641, 5);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 32);
            this.btnSettings.TabIndex = 213;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "Close";
            this.btnClose.Location = new System.Drawing.Point(877, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 32);
            this.btnClose.TabIndex = 212;
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
            this.groupBox3.Location = new System.Drawing.Point(6, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBox3.Size = new System.Drawing.Size(302, 172);
            this.groupBox3.TabIndex = 215;
            this.groupBox3.TabStop = false;
            // 
            // lblCurrentFlowRate2
            // 
            this.lblCurrentFlowRate2.BackColor = System.Drawing.SystemColors.Control;
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
            this.lblCurrentFlowRate.BackColor = System.Drawing.SystemColors.Control;
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
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(620, 184);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 32);
            this.btnCancel.TabIndex = 217;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.AccessibleDescription = "Start";
            this.btnStart.Location = new System.Drawing.Point(620, 52);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(70, 32);
            this.btnStart.TabIndex = 216;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(146, -2);
            this.label5.Margin = new System.Windows.Forms.Padding(2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 220;
            this.label5.Text = "(s)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.White;
            this.lblDuration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDuration.Location = new System.Drawing.Point(220, 0);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(2);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(70, 23);
            this.lblDuration.TabIndex = 219;
            this.lblDuration.Text = "2";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDuration.Click += new System.EventHandler(this.lblDuration_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 23);
            this.label7.TabIndex = 222;
            this.label7.Text = "Delay";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(152, 100);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 23);
            this.label9.TabIndex = 224;
            this.label9.Text = "(s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDelay
            // 
            this.lblDelay.BackColor = System.Drawing.Color.White;
            this.lblDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDelay.Location = new System.Drawing.Point(226, 102);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(2);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(70, 23);
            this.lblDelay.TabIndex = 223;
            this.lblDelay.Text = "1";
            this.lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDelay.Click += new System.EventHandler(this.lblDelay_Click);
            // 
            // cbEnableTargetWeight
            // 
            this.cbEnableTargetWeight.AutoSize = true;
            this.cbEnableTargetWeight.Location = new System.Drawing.Point(6, 23);
            this.cbEnableTargetWeight.Name = "cbEnableTargetWeight";
            this.cbEnableTargetWeight.Size = new System.Drawing.Size(107, 18);
            this.cbEnableTargetWeight.TabIndex = 225;
            this.cbEnableTargetWeight.Text = "Target Weight";
            this.cbEnableTargetWeight.UseVisualStyleBackColor = true;
            this.cbEnableTargetWeight.Click += new System.EventHandler(this.cbEnableTargetWeight_Click);
            // 
            // lbl_TargetUnit
            // 
            this.lbl_TargetUnit.Location = new System.Drawing.Point(152, 20);
            this.lbl_TargetUnit.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_TargetUnit.Name = "lbl_TargetUnit";
            this.lbl_TargetUnit.Size = new System.Drawing.Size(70, 23);
            this.lbl_TargetUnit.TabIndex = 226;
            this.lbl_TargetUnit.Text = "(mg)";
            this.lbl_TargetUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTargetWeight
            // 
            this.lblTargetWeight.BackColor = System.Drawing.Color.White;
            this.lblTargetWeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTargetWeight.Location = new System.Drawing.Point(226, 20);
            this.lblTargetWeight.Margin = new System.Windows.Forms.Padding(2);
            this.lblTargetWeight.Name = "lblTargetWeight";
            this.lblTargetWeight.Size = new System.Drawing.Size(70, 23);
            this.lblTargetWeight.TabIndex = 227;
            this.lblTargetWeight.Text = "10";
            this.lblTargetWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTargetWeight.Click += new System.EventHandler(this.lblTargetWeight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lblSampleCount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.pnlDuration);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblWeightSpecTol);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbEnableTargetWeight);
            this.groupBox1.Controls.Add(this.lbl_TargetUnit);
            this.groupBox1.Controls.Add(this.lblDelay);
            this.groupBox1.Controls.Add(this.lblTargetWeight);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(314, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 172);
            this.groupBox1.TabIndex = 228;
            this.groupBox1.TabStop = false;
            // 
            // lblSampleCount
            // 
            this.lblSampleCount.BackColor = System.Drawing.Color.White;
            this.lblSampleCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSampleCount.Location = new System.Drawing.Point(226, 129);
            this.lblSampleCount.Margin = new System.Windows.Forms.Padding(2);
            this.lblSampleCount.Name = "lblSampleCount";
            this.lblSampleCount.Size = new System.Drawing.Size(70, 23);
            this.lblSampleCount.TabIndex = 233;
            this.lblSampleCount.Text = "1";
            this.lblSampleCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSampleCount.Click += new System.EventHandler(this.lblSampleCount_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(152, 127);
            this.label11.Margin = new System.Windows.Forms.Padding(2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 23);
            this.label11.TabIndex = 234;
            this.label11.Text = "(count)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "";
            this.label12.Location = new System.Drawing.Point(3, 127);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 23);
            this.label12.TabIndex = 232;
            this.label12.Text = "Sample Count";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDuration
            // 
            this.pnlDuration.AutoSize = true;
            this.pnlDuration.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDuration.Controls.Add(this.label2);
            this.pnlDuration.Controls.Add(this.lblDuration);
            this.pnlDuration.Controls.Add(this.label5);
            this.pnlDuration.Location = new System.Drawing.Point(6, 75);
            this.pnlDuration.Name = "pnlDuration";
            this.pnlDuration.Size = new System.Drawing.Size(292, 26);
            this.pnlDuration.TabIndex = 231;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 228;
            this.label2.Text = "Duration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(152, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 23);
            this.label6.TabIndex = 229;
            this.label6.Text = "(mg)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWeightSpecTol
            // 
            this.lblWeightSpecTol.BackColor = System.Drawing.Color.White;
            this.lblWeightSpecTol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeightSpecTol.Location = new System.Drawing.Point(226, 47);
            this.lblWeightSpecTol.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeightSpecTol.Name = "lblWeightSpecTol";
            this.lblWeightSpecTol.Size = new System.Drawing.Size(70, 23);
            this.lblWeightSpecTol.TabIndex = 230;
            this.lblWeightSpecTol.Text = "+/- 1";
            this.lblWeightSpecTol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWeightSpecTol.Click += new System.EventHandler(this.lblWeightSpecTol_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.Location = new System.Drawing.Point(84, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 23);
            this.label10.TabIndex = 228;
            this.label10.Text = "Spec Tol";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vsbar_Zoom
            // 
            this.vsbar_Zoom.Location = new System.Drawing.Point(666, 222);
            this.vsbar_Zoom.Minimum = 1;
            this.vsbar_Zoom.Name = "vsbar_Zoom";
            this.vsbar_Zoom.Size = new System.Drawing.Size(26, 314);
            this.vsbar_Zoom.TabIndex = 230;
            this.vsbar_Zoom.Value = 50;
            this.vsbar_Zoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbar_Zoom_Scroll);
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(6, 222);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(654, 314);
            this.zg1.TabIndex = 229;
            // 
            // tmrWeightDisplay
            // 
            this.tmrWeightDisplay.Enabled = true;
            this.tmrWeightDisplay.Tick += new System.EventHandler(this.tmrWeightDisplay_Tick_1);
            // 
            // lbxLog
            // 
            this.lbxLog.FormattingEnabled = true;
            this.lbxLog.ItemHeight = 14;
            this.lbxLog.Location = new System.Drawing.Point(695, 42);
            this.lbxLog.Name = "lbxLog";
            this.lbxLog.Size = new System.Drawing.Size(252, 494);
            this.lbxLog.TabIndex = 218;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = "";
            this.btnSave.Location = new System.Drawing.Point(620, 88);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 32);
            this.btnSave.TabIndex = 231;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmWeightMeasure
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(988, 604);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.vsbar_Zoom);
            this.Controls.Add(this.zg1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbxLog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_Head1);
            this.Controls.Add(this.btn_Head2);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWeightMeasure";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmWeightMeasure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWeightMeasure_FormClosing);
            this.Load += new System.EventHandler(this.frmWeightMeasure_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDuration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Head1;
        private System.Windows.Forms.Button btn_Head2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCurrentFlowRate2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblCurrentFlowRate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Tare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_WeightCurrentValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.CheckBox cbEnableTargetWeight;
        private System.Windows.Forms.Label lbl_TargetUnit;
        private System.Windows.Forms.Label lblTargetWeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vsbar_Zoom;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Timer tmrWeightDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWeightSpecTol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlDuration;
        private System.Windows.Forms.ListBox lbxLog;
        private System.Windows.Forms.Label lblSampleCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
    }
}