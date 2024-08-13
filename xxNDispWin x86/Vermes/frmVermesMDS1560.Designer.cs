namespace NDispWin
{
    partial class frmVermesMDS1560
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpParam = new System.Windows.Forms.TabPage();
            this.lblHeaterValue = new System.Windows.Forms.Label();
            this.lblHeaterTarget = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNP = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Trigger = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnValveOpen = new System.Windows.Forms.Button();
            this.tpMaint = new System.Windows.Forms.TabPage();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.btnRefreshCycles = new System.Windows.Forms.Button();
            this.lblCycles = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tpComm = new System.Windows.Forms.TabPage();
            this.tbxComPort = new System.Windows.Forms.TextBox();
            this.cbLogComm = new System.Windows.Forms.CheckBox();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTrigIO = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_FPressUnit = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_SvFPress = new System.Windows.Forms.Button();
            this.lbl_FPress = new System.Windows.Forms.Label();
            this.tmrHeaterTarget = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tpParam.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tpMaint.SuspendLayout();
            this.tpComm.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpParam);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tpMaint);
            this.tabControl1.Controls.Add(this.tpComm);
            this.tabControl1.ItemSize = new System.Drawing.Size(70, 30);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 220);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tpParam
            // 
            this.tpParam.BackColor = System.Drawing.SystemColors.Control;
            this.tpParam.Controls.Add(this.lblHeaterValue);
            this.tpParam.Controls.Add(this.lblHeaterTarget);
            this.tpParam.Controls.Add(this.label9);
            this.tpParam.Controls.Add(this.label10);
            this.tpParam.Controls.Add(this.lblNP);
            this.tpParam.Controls.Add(this.label14);
            this.tpParam.Controls.Add(this.btn_Trigger);
            this.tpParam.Controls.Add(this.label15);
            this.tpParam.Controls.Add(this.lblCT);
            this.tpParam.Controls.Add(this.label2);
            this.tpParam.Controls.Add(this.label3);
            this.tpParam.Controls.Add(this.lblOT);
            this.tpParam.Controls.Add(this.label5);
            this.tpParam.Controls.Add(this.label6);
            this.tpParam.Location = new System.Drawing.Point(4, 34);
            this.tpParam.Name = "tpParam";
            this.tpParam.Padding = new System.Windows.Forms.Padding(3);
            this.tpParam.Size = new System.Drawing.Size(312, 182);
            this.tpParam.TabIndex = 0;
            this.tpParam.Text = "Param";
            // 
            // lblHeaterValue
            // 
            this.lblHeaterValue.BackColor = System.Drawing.SystemColors.Control;
            this.lblHeaterValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHeaterValue.Location = new System.Drawing.Point(172, 114);
            this.lblHeaterValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeaterValue.Name = "lblHeaterValue";
            this.lblHeaterValue.Size = new System.Drawing.Size(50, 30);
            this.lblHeaterValue.TabIndex = 25;
            this.lblHeaterValue.Text = "23.1";
            this.lblHeaterValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeaterTarget
            // 
            this.lblHeaterTarget.BackColor = System.Drawing.Color.White;
            this.lblHeaterTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHeaterTarget.Location = new System.Drawing.Point(116, 114);
            this.lblHeaterTarget.Margin = new System.Windows.Forms.Padding(3);
            this.lblHeaterTarget.Name = "lblHeaterTarget";
            this.lblHeaterTarget.Size = new System.Drawing.Size(50, 30);
            this.lblHeaterTarget.TabIndex = 23;
            this.lblHeaterTarget.Text = "80.0";
            this.lblHeaterTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeaterTarget.Click += new System.EventHandler(this.lblHeaterTarget_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(228, 120);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "(Deg C)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Heater Target";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNP
            // 
            this.lblNP.BackColor = System.Drawing.Color.White;
            this.lblNP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNP.Location = new System.Drawing.Point(152, 78);
            this.lblNP.Margin = new System.Windows.Forms.Padding(3);
            this.lblNP.Name = "lblNP";
            this.lblNP.Size = new System.Drawing.Size(70, 30);
            this.lblNP.TabIndex = 17;
            this.lblNP.Text = "lblNP";
            this.lblNP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNP.Click += new System.EventHandler(this.lblNP_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(228, 84);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 19);
            this.label14.TabIndex = 16;
            this.label14.Text = "(count)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Trigger
            // 
            this.btn_Trigger.Location = new System.Drawing.Point(235, 149);
            this.btn_Trigger.Name = "btn_Trigger";
            this.btn_Trigger.Size = new System.Drawing.Size(70, 30);
            this.btn_Trigger.TabIndex = 20;
            this.btn_Trigger.Text = "Trig (SW)";
            this.btn_Trigger.UseVisualStyleBackColor = true;
            this.btn_Trigger.Click += new System.EventHandler(this.btn_Trigger_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 83);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "Number of Pulse (NP)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCT
            // 
            this.lblCT.BackColor = System.Drawing.Color.White;
            this.lblCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCT.Location = new System.Drawing.Point(152, 42);
            this.lblCT.Margin = new System.Windows.Forms.Padding(3);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(70, 30);
            this.lblCT.TabIndex = 11;
            this.lblCT.Text = "lblCT";
            this.lblCT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCT.Click += new System.EventHandler(this.lblCT_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "(ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Close Time (CT)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOT
            // 
            this.lblOT.BackColor = System.Drawing.Color.White;
            this.lblOT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOT.Location = new System.Drawing.Point(152, 6);
            this.lblOT.Margin = new System.Windows.Forms.Padding(3);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(70, 30);
            this.lblOT.TabIndex = 8;
            this.lblOT.Text = "lblOT";
            this.lblOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOT.Click += new System.EventHandler(this.lblOT_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(228, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "(ms)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Open Time (OT)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnValveOpen);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(312, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setup";
            // 
            // btnValveOpen
            // 
            this.btnValveOpen.AccessibleDescription = "Valve Open";
            this.btnValveOpen.Location = new System.Drawing.Point(6, 6);
            this.btnValveOpen.Name = "btnValveOpen";
            this.btnValveOpen.Size = new System.Drawing.Size(92, 30);
            this.btnValveOpen.TabIndex = 2;
            this.btnValveOpen.Text = "Valve Open";
            this.btnValveOpen.UseVisualStyleBackColor = true;
            this.btnValveOpen.Click += new System.EventHandler(this.btnValveOpen_Click);
            this.btnValveOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnValveOpen_MouseDown);
            this.btnValveOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnValveOpen_MouseUp);
            // 
            // tpMaint
            // 
            this.tpMaint.BackColor = System.Drawing.SystemColors.Control;
            this.tpMaint.Controls.Add(this.rtbInfo);
            this.tpMaint.Controls.Add(this.btnRefreshCycles);
            this.tpMaint.Controls.Add(this.lblCycles);
            this.tpMaint.Controls.Add(this.label21);
            this.tpMaint.Location = new System.Drawing.Point(4, 34);
            this.tpMaint.Name = "tpMaint";
            this.tpMaint.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaint.Size = new System.Drawing.Size(312, 182);
            this.tpMaint.TabIndex = 2;
            this.tpMaint.Text = "Maint";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Enabled = false;
            this.rtbInfo.Location = new System.Drawing.Point(6, 6);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(298, 128);
            this.rtbInfo.TabIndex = 25;
            this.rtbInfo.Text = "";
            // 
            // btnRefreshCycles
            // 
            this.btnRefreshCycles.AccessibleDescription = "Refresh";
            this.btnRefreshCycles.Location = new System.Drawing.Point(229, 140);
            this.btnRefreshCycles.Name = "btnRefreshCycles";
            this.btnRefreshCycles.Size = new System.Drawing.Size(75, 30);
            this.btnRefreshCycles.TabIndex = 24;
            this.btnRefreshCycles.Text = "Refresh";
            this.btnRefreshCycles.UseVisualStyleBackColor = true;
            this.btnRefreshCycles.Click += new System.EventHandler(this.btnRefreshCycles_Click);
            // 
            // lblCycles
            // 
            this.lblCycles.BackColor = System.Drawing.SystemColors.Control;
            this.lblCycles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCycles.Location = new System.Drawing.Point(77, 145);
            this.lblCycles.Margin = new System.Windows.Forms.Padding(3);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(129, 20);
            this.lblCycles.TabIndex = 23;
            this.lblCycles.Text = "-";
            this.lblCycles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(6, 145);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 20);
            this.label21.TabIndex = 22;
            this.label21.Text = "Cycles";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpComm
            // 
            this.tpComm.BackColor = System.Drawing.SystemColors.Control;
            this.tpComm.Controls.Add(this.tbxComPort);
            this.tpComm.Controls.Add(this.cbLogComm);
            this.tpComm.Controls.Add(this.btnDisconn);
            this.tpComm.Controls.Add(this.label7);
            this.tpComm.Controls.Add(this.btnConnect);
            this.tpComm.Location = new System.Drawing.Point(4, 34);
            this.tpComm.Name = "tpComm";
            this.tpComm.Padding = new System.Windows.Forms.Padding(3);
            this.tpComm.Size = new System.Drawing.Size(312, 182);
            this.tpComm.TabIndex = 3;
            this.tpComm.Text = "Comm";
            // 
            // tbxComPort
            // 
            this.tbxComPort.Location = new System.Drawing.Point(159, 18);
            this.tbxComPort.Name = "tbxComPort";
            this.tbxComPort.Size = new System.Drawing.Size(70, 22);
            this.tbxComPort.TabIndex = 17;
            // 
            // cbLogComm
            // 
            this.cbLogComm.AutoSize = true;
            this.cbLogComm.Location = new System.Drawing.Point(9, 49);
            this.cbLogComm.Name = "cbLogComm";
            this.cbLogComm.Size = new System.Drawing.Size(84, 18);
            this.cbLogComm.TabIndex = 11;
            this.cbLogComm.Text = "Log Comm";
            this.cbLogComm.UseVisualStyleBackColor = true;
            this.cbLogComm.Click += new System.EventHandler(this.cbLogComm_Click);
            // 
            // btnDisconn
            // 
            this.btnDisconn.Location = new System.Drawing.Point(234, 49);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(70, 30);
            this.btnDisconn.TabIndex = 10;
            this.btnDisconn.Text = "Disconn";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "MDS1560 ComPort";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(234, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 30);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssBottom.Location = new System.Drawing.Point(5, 278);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(404, 22);
            this.ssBottom.TabIndex = 21;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(11, 17);
            this.tsslStatus.Text = "-";
            // 
            // btnTrigIO
            // 
            this.btnTrigIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrigIO.Location = new System.Drawing.Point(332, 191);
            this.btnTrigIO.Name = "btnTrigIO";
            this.btnTrigIO.Size = new System.Drawing.Size(70, 30);
            this.btnTrigIO.TabIndex = 58;
            this.btnTrigIO.Text = "Trig (IO)";
            this.btnTrigIO.UseVisualStyleBackColor = true;
            this.btnTrigIO.Click += new System.EventHandler(this.btnTrigIO_Click);
            this.btnTrigIO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTrigIO_MouseDown);
            this.btnTrigIO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTrigIO_MouseUp);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(332, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(70, 30);
            this.btn_Close.TabIndex = 59;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_FPressUnit
            // 
            this.lbl_FPressUnit.AccessibleDescription = "";
            this.lbl_FPressUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_FPressUnit.Location = new System.Drawing.Point(213, 242);
            this.lbl_FPressUnit.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressUnit.Name = "lbl_FPressUnit";
            this.lbl_FPressUnit.Size = new System.Drawing.Size(28, 15);
            this.lbl_FPressUnit.TabIndex = 63;
            this.lbl_FPressUnit.Text = "(ul)";
            this.lbl_FPressUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "F Pressure";
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(18, 242);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 15);
            this.label18.TabIndex = 62;
            this.label18.Text = "F Pressure";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_SvFPress
            // 
            this.btn_SvFPress.Location = new System.Drawing.Point(247, 234);
            this.btn_SvFPress.Name = "btn_SvFPress";
            this.btn_SvFPress.Size = new System.Drawing.Size(70, 30);
            this.btn_SvFPress.TabIndex = 60;
            this.btn_SvFPress.Text = "F Press";
            this.btn_SvFPress.UseVisualStyleBackColor = true;
            this.btn_SvFPress.Click += new System.EventHandler(this.btn_SvFPress_Click);
            // 
            // lbl_FPress
            // 
            this.lbl_FPress.BackColor = System.Drawing.Color.White;
            this.lbl_FPress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FPress.Location = new System.Drawing.Point(147, 234);
            this.lbl_FPress.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPress.Name = "lbl_FPress";
            this.lbl_FPress.Size = new System.Drawing.Size(60, 30);
            this.lbl_FPress.TabIndex = 61;
            this.lbl_FPress.Text = "24.0";
            this.lbl_FPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_FPress.Click += new System.EventHandler(this.lbl_FPress_Click);
            // 
            // tmrHeaterTarget
            // 
            this.tmrHeaterTarget.Enabled = true;
            this.tmrHeaterTarget.Interval = 1000;
            this.tmrHeaterTarget.Tick += new System.EventHandler(this.tmrHeaterTarget_Tick);
            // 
            // frmVermesMDS1560
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(414, 305);
            this.Controls.Add(this.lbl_FPressUnit);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btn_SvFPress);
            this.Controls.Add(this.lbl_FPress);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btnTrigIO);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmVermesMDS1560";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "frmVermesMDS1560";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVermesMDS1560_FormClosing);
            this.Load += new System.EventHandler(this.frmVermesMDS1560_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpParam.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tpMaint.ResumeLayout(false);
            this.tpComm.ResumeLayout(false);
            this.tpComm.PerformLayout();
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpParam;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblNP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnValveOpen;
        private System.Windows.Forms.TabPage tpMaint;
        private System.Windows.Forms.Button btnRefreshCycles;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tpComm;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btn_Trigger;
        private System.Windows.Forms.CheckBox cbLogComm;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Button btnTrigIO;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_FPressUnit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_SvFPress;
        private System.Windows.Forms.Label lbl_FPress;
        private System.Windows.Forms.TextBox tbxComPort;
        private System.Windows.Forms.Label lblHeaterValue;
        private System.Windows.Forms.Label lblHeaterTarget;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer tmrHeaterTarget;
        private System.Windows.Forms.RichTextBox rtbInfo;
    }
}