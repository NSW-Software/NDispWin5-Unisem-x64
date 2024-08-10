namespace NDispWin
{
    partial class frmSystemConfig
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
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.tpage_Others = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbxVideoLoggerMsg2 = new System.Windows.Forms.TextBox();
            this.tbxVideoLoggerMsg1 = new System.Windows.Forms.TextBox();
            this.rbVideoLoggerMsg2 = new System.Windows.Forms.RadioButton();
            this.rbVideoLoggerMsg1 = new System.Windows.Forms.RadioButton();
            this.btnSendVideoLoggerStopRecord = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.tbxVideoLoggerPort = new System.Windows.Forms.TextBox();
            this.btnSendVideoLoggerTestMsg = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.cbxVideoLoggerType = new System.Windows.Forms.ComboBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.nud_LogLevel = new System.Windows.Forms.NumericUpDown();
            this.btn_Load = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btnTempCtrlUpdate = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.combox_TempCtrl3 = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.combox_TempCtrl2 = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.combox_TempCtrl1 = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.combox_TempCtrl0 = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.combox_TempCtrl_Type = new System.Windows.Forms.ComboBox();
            this.btn_TempCtrl_CtrlDlg = new System.Windows.Forms.Button();
            this.btn_TempCtrl_Connect = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.combox_TempCtrl_PortName = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnTempSensorInfo = new System.Windows.Forms.Button();
            this.btnTempSensorDisconnect = new System.Windows.Forms.Button();
            this.btnTempSensorConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTempSensorComport = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxTempSensorType = new System.Windows.Forms.ComboBox();
            this.tpage_DispControls = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.btnDispHeaterDlg = new System.Windows.Forms.Button();
            this.btnDispHeaterConnect = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.cbxDispHeaterComport = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cbxDispHeaterType = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_ShowCtrl1 = new System.Windows.Forms.Button();
            this.btn_DispCtrl1Connect = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.combox_DispCtrl1Comport = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.combox_DispCtrl1Type = new System.Windows.Forms.ComboBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btn_ShowCtrl2 = new System.Windows.Forms.Button();
            this.btn_DispCtrl2Connect = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.combox_DispCtrl2Comport = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.combox_DispCtrl2Type = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.combox_Pressunit = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.combox_FPressCh = new System.Windows.Forms.ComboBox();
            this.tbox_FPressSet = new System.Windows.Forms.TextBox();
            this.lbl_FPressGet = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lbl_FPress1Connect = new System.Windows.Forms.Button();
            this.btn_FPressSet = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.combox_FPress1Comport = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btn_FPressGet = new System.Windows.Forms.Button();
            this.combox_FPressType = new System.Windows.Forms.ComboBox();
            this.tpage_WeightStation = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_WeightDlg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_WeightConnect = new System.Windows.Forms.Button();
            this.combox_WeightComport = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combox_WeightStType = new System.Windows.Forms.ComboBox();
            this.tpage_HeightSensor = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.tbox_HSensorIPAddress = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_HeightSensorControlDlg = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_HSensorConnect = new System.Windows.Forms.Button();
            this.combox_HSensorComport = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.combox_HSensorType = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.combox_ZSensorType = new System.Windows.Forms.ComboBox();
            this.tpage_Camera = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btn_Echo = new System.Windows.Forms.Button();
            this.btn_SetupMode = new System.Windows.Forms.Button();
            this.btn_RunMode = new System.Windows.Forms.Button();
            this.btn_Trig1 = new System.Windows.Forms.Button();
            this.tbox_ExtVisPort = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.btn_ExtVisConnect = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.tbox_ExtVisIPAddress = new System.Windows.Forms.TextBox();
            this.combox_ExtVisType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Cam1ControlDlg = new System.Windows.Forms.Button();
            this.btn_Camera1Connect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_Camera1IPAdress = new System.Windows.Forms.TextBox();
            this.combox_Camera1Type = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btn_Cam2ControlDlg = new System.Windows.Forms.Button();
            this.btn_Camera2Connect = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbox_Camera2IPAdress = new System.Windows.Forms.TextBox();
            this.combox_Camera2Type = new System.Windows.Forms.ComboBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btn_Cam3ControlDlg = new System.Windows.Forms.Button();
            this.btn_Camera3Connect = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tbox_Camera3IPAdress = new System.Windows.Forms.TextBox();
            this.combox_Camera3Type = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_LCConnect = new System.Windows.Forms.Button();
            this.combox_LCComport = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combox_LCType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combox_BottomCamType = new System.Windows.Forms.ComboBox();
            this.tpage_MotionControls = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.cbxConveyorSystem = new System.Windows.Forms.ComboBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.tbox_EquipmentName = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.combox_HeadConfig = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combox_GantryConfig = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_Device1Info = new System.Windows.Forms.Label();
            this.lbl_Device0Info = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpage_Others.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LogLevel)).BeginInit();
            this.groupBox17.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tpage_DispControls.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tpage_WeightStation.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpage_HeightSensor.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tpage_Camera.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpage_MotionControls.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_Display
            // 
            this.tmr_Display.Enabled = true;
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // tpage_Others
            // 
            this.tpage_Others.Controls.Add(this.groupBox8);
            this.tpage_Others.Controls.Add(this.groupBox22);
            this.tpage_Others.Controls.Add(this.groupBox17);
            this.tpage_Others.Controls.Add(this.groupBox12);
            this.tpage_Others.Location = new System.Drawing.Point(4, 34);
            this.tpage_Others.Name = "tpage_Others";
            this.tpage_Others.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Others.Size = new System.Drawing.Size(588, 481);
            this.tpage_Others.TabIndex = 4;
            this.tpage_Others.Text = "Others";
            this.tpage_Others.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.AccessibleDescription = "Video Logger";
            this.groupBox8.AutoSize = true;
            this.groupBox8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox8.Controls.Add(this.tbxVideoLoggerMsg2);
            this.groupBox8.Controls.Add(this.tbxVideoLoggerMsg1);
            this.groupBox8.Controls.Add(this.rbVideoLoggerMsg2);
            this.groupBox8.Controls.Add(this.rbVideoLoggerMsg1);
            this.groupBox8.Controls.Add(this.btnSendVideoLoggerStopRecord);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.tbxVideoLoggerPort);
            this.groupBox8.Controls.Add(this.btnSendVideoLoggerTestMsg);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Controls.Add(this.cbxVideoLoggerType);
            this.groupBox8.Location = new System.Drawing.Point(6, 259);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(239, 210);
            this.groupBox8.TabIndex = 159;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Video Logger";
            // 
            // tbxVideoLoggerMsg2
            // 
            this.tbxVideoLoggerMsg2.Location = new System.Drawing.Point(22, 137);
            this.tbxVideoLoggerMsg2.Name = "tbxVideoLoggerMsg2";
            this.tbxVideoLoggerMsg2.Size = new System.Drawing.Size(211, 26);
            this.tbxVideoLoggerMsg2.TabIndex = 163;
            this.tbxVideoLoggerMsg2.Text = "CAMALL,SNAP,c:\\Process\\Image\\File1,c:\\Process\\Image\\File2";
            this.tbxVideoLoggerMsg2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxVideoLoggerMsg1
            // 
            this.tbxVideoLoggerMsg1.Location = new System.Drawing.Point(22, 109);
            this.tbxVideoLoggerMsg1.Name = "tbxVideoLoggerMsg1";
            this.tbxVideoLoggerMsg1.Size = new System.Drawing.Size(211, 26);
            this.tbxVideoLoggerMsg1.TabIndex = 160;
            this.tbxVideoLoggerMsg1.Text = "CAMALL,SHORT300,c:\\Process\\Video\\File1,c:\\Process\\Video\\File2";
            this.tbxVideoLoggerMsg1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbVideoLoggerMsg2
            // 
            this.rbVideoLoggerMsg2.AutoSize = true;
            this.rbVideoLoggerMsg2.Location = new System.Drawing.Point(6, 138);
            this.rbVideoLoggerMsg2.Name = "rbVideoLoggerMsg2";
            this.rbVideoLoggerMsg2.Size = new System.Drawing.Size(111, 22);
            this.rbVideoLoggerMsg2.TabIndex = 164;
            this.rbVideoLoggerMsg2.Text = "radioButton2";
            this.rbVideoLoggerMsg2.UseVisualStyleBackColor = true;
            // 
            // rbVideoLoggerMsg1
            // 
            this.rbVideoLoggerMsg1.AutoSize = true;
            this.rbVideoLoggerMsg1.Checked = true;
            this.rbVideoLoggerMsg1.Location = new System.Drawing.Point(6, 109);
            this.rbVideoLoggerMsg1.Name = "rbVideoLoggerMsg1";
            this.rbVideoLoggerMsg1.Size = new System.Drawing.Size(111, 22);
            this.rbVideoLoggerMsg1.TabIndex = 160;
            this.rbVideoLoggerMsg1.TabStop = true;
            this.rbVideoLoggerMsg1.Text = "radioButton1";
            this.rbVideoLoggerMsg1.UseVisualStyleBackColor = true;
            // 
            // btnSendVideoLoggerStopRecord
            // 
            this.btnSendVideoLoggerStopRecord.Location = new System.Drawing.Point(77, 162);
            this.btnSendVideoLoggerStopRecord.Name = "btnSendVideoLoggerStopRecord";
            this.btnSendVideoLoggerStopRecord.Size = new System.Drawing.Size(65, 23);
            this.btnSendVideoLoggerStopRecord.TabIndex = 162;
            this.btnSendVideoLoggerStopRecord.Text = "Stop";
            this.btnSendVideoLoggerStopRecord.UseVisualStyleBackColor = true;
            this.btnSendVideoLoggerStopRecord.Click += new System.EventHandler(this.btnSendVideoLoggerStopRecord_Click);
            // 
            // label51
            // 
            this.label51.AccessibleDescription = "";
            this.label51.Location = new System.Drawing.Point(6, 81);
            this.label51.Margin = new System.Windows.Forms.Padding(3);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(100, 22);
            this.label51.TabIndex = 161;
            this.label51.Text = "Test Message";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxVideoLoggerPort
            // 
            this.tbxVideoLoggerPort.Location = new System.Drawing.Point(112, 49);
            this.tbxVideoLoggerPort.Name = "tbxVideoLoggerPort";
            this.tbxVideoLoggerPort.Size = new System.Drawing.Size(121, 26);
            this.tbxVideoLoggerPort.TabIndex = 159;
            this.tbxVideoLoggerPort.Text = "11000";
            this.tbxVideoLoggerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxVideoLoggerPort.TextChanged += new System.EventHandler(this.tbxVideoLoggerPort_TextChanged);
            // 
            // btnSendVideoLoggerTestMsg
            // 
            this.btnSendVideoLoggerTestMsg.Location = new System.Drawing.Point(6, 162);
            this.btnSendVideoLoggerTestMsg.Name = "btnSendVideoLoggerTestMsg";
            this.btnSendVideoLoggerTestMsg.Size = new System.Drawing.Size(65, 23);
            this.btnSendVideoLoggerTestMsg.TabIndex = 25;
            this.btnSendVideoLoggerTestMsg.Text = "Send";
            this.btnSendVideoLoggerTestMsg.UseVisualStyleBackColor = true;
            this.btnSendVideoLoggerTestMsg.Click += new System.EventHandler(this.btnSendVideoLoggerTestMsg_Click);
            // 
            // label19
            // 
            this.label19.AccessibleDescription = "Port";
            this.label19.Location = new System.Drawing.Point(6, 49);
            this.label19.Margin = new System.Windows.Forms.Padding(3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 22);
            this.label19.TabIndex = 18;
            this.label19.Text = "Port";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.AccessibleDescription = "Type";
            this.label50.Location = new System.Drawing.Point(6, 21);
            this.label50.Margin = new System.Windows.Forms.Padding(3);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(100, 22);
            this.label50.TabIndex = 16;
            this.label50.Text = "Type";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxVideoLoggerType
            // 
            this.cbxVideoLoggerType.FormattingEnabled = true;
            this.cbxVideoLoggerType.Location = new System.Drawing.Point(112, 21);
            this.cbxVideoLoggerType.Name = "cbxVideoLoggerType";
            this.cbxVideoLoggerType.Size = new System.Drawing.Size(121, 26);
            this.cbxVideoLoggerType.TabIndex = 15;
            this.cbxVideoLoggerType.SelectionChangeCommitted += new System.EventHandler(this.cbxVideoLoggerType_SelectionChangeCommitted);
            // 
            // groupBox22
            // 
            this.groupBox22.AccessibleDescription = "XY Sensor";
            this.groupBox22.AutoSize = true;
            this.groupBox22.Controls.Add(this.btn_SaveAs);
            this.groupBox22.Controls.Add(this.label26);
            this.groupBox22.Controls.Add(this.nud_LogLevel);
            this.groupBox22.Controls.Add(this.btn_Load);
            this.groupBox22.Location = new System.Drawing.Point(251, 305);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(240, 114);
            this.groupBox22.TabIndex = 158;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Advance";
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.AccessibleDescription = "SaveAs";
            this.btn_SaveAs.Location = new System.Drawing.Point(87, 21);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(75, 36);
            this.btn_SaveAs.TabIndex = 144;
            this.btn_SaveAs.Text = "SaveAs";
            this.btn_SaveAs.Visible = false;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // label26
            // 
            this.label26.AccessibleDescription = "Log Level";
            this.label26.Location = new System.Drawing.Point(7, 63);
            this.label26.Margin = new System.Windows.Forms.Padding(3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 22);
            this.label26.TabIndex = 154;
            this.label26.Text = "Log Level";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_LogLevel
            // 
            this.nud_LogLevel.Location = new System.Drawing.Point(113, 63);
            this.nud_LogLevel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_LogLevel.Name = "nud_LogLevel";
            this.nud_LogLevel.Size = new System.Drawing.Size(77, 26);
            this.nud_LogLevel.TabIndex = 153;
            this.nud_LogLevel.Click += new System.EventHandler(this.nud_LogLevel_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.AccessibleDescription = "Load";
            this.btn_Load.Location = new System.Drawing.Point(6, 21);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 36);
            this.btn_Load.TabIndex = 143;
            this.btn_Load.Text = "Load";
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.AccessibleDescription = "";
            this.groupBox17.AutoSize = true;
            this.groupBox17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox17.Controls.Add(this.btnTempCtrlUpdate);
            this.groupBox17.Controls.Add(this.label49);
            this.groupBox17.Controls.Add(this.combox_TempCtrl3);
            this.groupBox17.Controls.Add(this.label48);
            this.groupBox17.Controls.Add(this.combox_TempCtrl2);
            this.groupBox17.Controls.Add(this.label47);
            this.groupBox17.Controls.Add(this.combox_TempCtrl1);
            this.groupBox17.Controls.Add(this.label46);
            this.groupBox17.Controls.Add(this.label45);
            this.groupBox17.Controls.Add(this.label44);
            this.groupBox17.Controls.Add(this.combox_TempCtrl0);
            this.groupBox17.Controls.Add(this.label35);
            this.groupBox17.Controls.Add(this.combox_TempCtrl_Type);
            this.groupBox17.Controls.Add(this.btn_TempCtrl_CtrlDlg);
            this.groupBox17.Controls.Add(this.btn_TempCtrl_Connect);
            this.groupBox17.Controls.Add(this.label36);
            this.groupBox17.Controls.Add(this.combox_TempCtrl_PortName);
            this.groupBox17.Location = new System.Drawing.Point(251, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(240, 297);
            this.groupBox17.TabIndex = 157;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Temp Controller";
            // 
            // btnTempCtrlUpdate
            // 
            this.btnTempCtrlUpdate.Location = new System.Drawing.Point(159, 249);
            this.btnTempCtrlUpdate.Name = "btnTempCtrlUpdate";
            this.btnTempCtrlUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnTempCtrlUpdate.TabIndex = 176;
            this.btnTempCtrlUpdate.Text = "Update";
            this.btnTempCtrlUpdate.UseVisualStyleBackColor = true;
            this.btnTempCtrlUpdate.Click += new System.EventHandler(this.btnTempCtrlUpdate_Click);
            // 
            // label49
            // 
            this.label49.AccessibleDescription = "";
            this.label49.Location = new System.Drawing.Point(7, 221);
            this.label49.Margin = new System.Windows.Forms.Padding(3);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(100, 22);
            this.label49.TabIndex = 175;
            this.label49.Text = "4";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl3
            // 
            this.combox_TempCtrl3.FormattingEnabled = true;
            this.combox_TempCtrl3.Location = new System.Drawing.Point(113, 221);
            this.combox_TempCtrl3.Name = "combox_TempCtrl3";
            this.combox_TempCtrl3.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl3.TabIndex = 174;
            this.combox_TempCtrl3.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl0_SelectionChangeCommitted);
            // 
            // label48
            // 
            this.label48.AccessibleDescription = "";
            this.label48.Location = new System.Drawing.Point(7, 193);
            this.label48.Margin = new System.Windows.Forms.Padding(3);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(100, 22);
            this.label48.TabIndex = 173;
            this.label48.Text = "3";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl2
            // 
            this.combox_TempCtrl2.FormattingEnabled = true;
            this.combox_TempCtrl2.Location = new System.Drawing.Point(113, 193);
            this.combox_TempCtrl2.Name = "combox_TempCtrl2";
            this.combox_TempCtrl2.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl2.TabIndex = 172;
            this.combox_TempCtrl2.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl0_SelectionChangeCommitted);
            // 
            // label47
            // 
            this.label47.AccessibleDescription = "";
            this.label47.Location = new System.Drawing.Point(7, 165);
            this.label47.Margin = new System.Windows.Forms.Padding(3);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(100, 22);
            this.label47.TabIndex = 171;
            this.label47.Text = "2";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl1
            // 
            this.combox_TempCtrl1.FormattingEnabled = true;
            this.combox_TempCtrl1.Location = new System.Drawing.Point(113, 165);
            this.combox_TempCtrl1.Name = "combox_TempCtrl1";
            this.combox_TempCtrl1.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl1.TabIndex = 170;
            this.combox_TempCtrl1.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl0_SelectionChangeCommitted);
            // 
            // label46
            // 
            this.label46.AccessibleDescription = "";
            this.label46.Location = new System.Drawing.Point(112, 109);
            this.label46.Margin = new System.Windows.Forms.Padding(3);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(122, 22);
            this.label46.TabIndex = 169;
            this.label46.Text = "Temp Ctrl Module";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.AccessibleDescription = "";
            this.label45.Location = new System.Drawing.Point(6, 109);
            this.label45.Margin = new System.Windows.Forms.Padding(3);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(100, 22);
            this.label45.TabIndex = 168;
            this.label45.Text = "Address";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.AccessibleDescription = "";
            this.label44.Location = new System.Drawing.Point(7, 137);
            this.label44.Margin = new System.Windows.Forms.Padding(3);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(100, 22);
            this.label44.TabIndex = 167;
            this.label44.Text = "1";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl0
            // 
            this.combox_TempCtrl0.FormattingEnabled = true;
            this.combox_TempCtrl0.Location = new System.Drawing.Point(113, 137);
            this.combox_TempCtrl0.Name = "combox_TempCtrl0";
            this.combox_TempCtrl0.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl0.TabIndex = 165;
            this.combox_TempCtrl0.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl0_SelectionChangeCommitted);
            // 
            // label35
            // 
            this.label35.AccessibleDescription = "Type";
            this.label35.Location = new System.Drawing.Point(6, 21);
            this.label35.Margin = new System.Windows.Forms.Padding(3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(100, 22);
            this.label35.TabIndex = 160;
            this.label35.Text = "Type";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl_Type
            // 
            this.combox_TempCtrl_Type.FormattingEnabled = true;
            this.combox_TempCtrl_Type.Location = new System.Drawing.Point(112, 21);
            this.combox_TempCtrl_Type.Name = "combox_TempCtrl_Type";
            this.combox_TempCtrl_Type.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl_Type.TabIndex = 159;
            this.combox_TempCtrl_Type.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl_Type_SelectionChangeCommitted);
            // 
            // btn_TempCtrl_CtrlDlg
            // 
            this.btn_TempCtrl_CtrlDlg.AccessibleDescription = "Control Dlg";
            this.btn_TempCtrl_CtrlDlg.Location = new System.Drawing.Point(6, 80);
            this.btn_TempCtrl_CtrlDlg.Name = "btn_TempCtrl_CtrlDlg";
            this.btn_TempCtrl_CtrlDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_TempCtrl_CtrlDlg.TabIndex = 158;
            this.btn_TempCtrl_CtrlDlg.Text = "Control Dlg";
            this.btn_TempCtrl_CtrlDlg.UseVisualStyleBackColor = true;
            this.btn_TempCtrl_CtrlDlg.Click += new System.EventHandler(this.btn_TempCtrl_CtrlDlg_Click);
            // 
            // btn_TempCtrl_Connect
            // 
            this.btn_TempCtrl_Connect.Location = new System.Drawing.Point(158, 80);
            this.btn_TempCtrl_Connect.Name = "btn_TempCtrl_Connect";
            this.btn_TempCtrl_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_TempCtrl_Connect.TabIndex = 22;
            this.btn_TempCtrl_Connect.Text = "Connect";
            this.btn_TempCtrl_Connect.UseVisualStyleBackColor = true;
            this.btn_TempCtrl_Connect.Click += new System.EventHandler(this.btn_TempCtrl_Connect_Click);
            // 
            // label36
            // 
            this.label36.AccessibleDescription = "Comport";
            this.label36.Location = new System.Drawing.Point(6, 48);
            this.label36.Margin = new System.Windows.Forms.Padding(3);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 22);
            this.label36.TabIndex = 16;
            this.label36.Text = "Comport";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_TempCtrl_PortName
            // 
            this.combox_TempCtrl_PortName.FormattingEnabled = true;
            this.combox_TempCtrl_PortName.Location = new System.Drawing.Point(112, 48);
            this.combox_TempCtrl_PortName.Name = "combox_TempCtrl_PortName";
            this.combox_TempCtrl_PortName.Size = new System.Drawing.Size(121, 26);
            this.combox_TempCtrl_PortName.TabIndex = 15;
            this.combox_TempCtrl_PortName.SelectionChangeCommitted += new System.EventHandler(this.combox_TempCtrl_PortName_SelectionChangeCommitted);
            // 
            // groupBox12
            // 
            this.groupBox12.AccessibleDescription = "Temp Sensor";
            this.groupBox12.AutoSize = true;
            this.groupBox12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox12.Controls.Add(this.btnTempSensorInfo);
            this.groupBox12.Controls.Add(this.btnTempSensorDisconnect);
            this.groupBox12.Controls.Add(this.btnTempSensorConnect);
            this.groupBox12.Controls.Add(this.label1);
            this.groupBox12.Controls.Add(this.cbxTempSensorComport);
            this.groupBox12.Controls.Add(this.label14);
            this.groupBox12.Controls.Add(this.cbxTempSensorType);
            this.groupBox12.Location = new System.Drawing.Point(6, 132);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(239, 125);
            this.groupBox12.TabIndex = 147;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Temp Sensor";
            // 
            // btnTempSensorInfo
            // 
            this.btnTempSensorInfo.Location = new System.Drawing.Point(6, 77);
            this.btnTempSensorInfo.Name = "btnTempSensorInfo";
            this.btnTempSensorInfo.Size = new System.Drawing.Size(65, 23);
            this.btnTempSensorInfo.TabIndex = 25;
            this.btnTempSensorInfo.Text = "Info";
            this.btnTempSensorInfo.UseVisualStyleBackColor = true;
            this.btnTempSensorInfo.Click += new System.EventHandler(this.btnTempSensorInfo_Click);
            // 
            // btnTempSensorDisconnect
            // 
            this.btnTempSensorDisconnect.Location = new System.Drawing.Point(158, 77);
            this.btnTempSensorDisconnect.Name = "btnTempSensorDisconnect";
            this.btnTempSensorDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnTempSensorDisconnect.TabIndex = 24;
            this.btnTempSensorDisconnect.Text = "Disconnect";
            this.btnTempSensorDisconnect.UseVisualStyleBackColor = true;
            this.btnTempSensorDisconnect.Click += new System.EventHandler(this.btnTempSensorDisconnect_Click);
            // 
            // btnTempSensorConnect
            // 
            this.btnTempSensorConnect.Location = new System.Drawing.Point(77, 77);
            this.btnTempSensorConnect.Name = "btnTempSensorConnect";
            this.btnTempSensorConnect.Size = new System.Drawing.Size(75, 23);
            this.btnTempSensorConnect.TabIndex = 23;
            this.btnTempSensorConnect.Text = "Connect";
            this.btnTempSensorConnect.UseVisualStyleBackColor = true;
            this.btnTempSensorConnect.Click += new System.EventHandler(this.btnTempSensorConnect_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Comport";
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Comport";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTempSensorComport
            // 
            this.cbxTempSensorComport.FormattingEnabled = true;
            this.cbxTempSensorComport.Location = new System.Drawing.Point(112, 49);
            this.cbxTempSensorComport.Name = "cbxTempSensorComport";
            this.cbxTempSensorComport.Size = new System.Drawing.Size(121, 26);
            this.cbxTempSensorComport.TabIndex = 17;
            this.cbxTempSensorComport.SelectionChangeCommitted += new System.EventHandler(this.cbxTempSensorComport_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "Type";
            this.label14.Location = new System.Drawing.Point(6, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 22);
            this.label14.TabIndex = 16;
            this.label14.Text = "Type";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTempSensorType
            // 
            this.cbxTempSensorType.FormattingEnabled = true;
            this.cbxTempSensorType.Location = new System.Drawing.Point(112, 21);
            this.cbxTempSensorType.Name = "cbxTempSensorType";
            this.cbxTempSensorType.Size = new System.Drawing.Size(121, 26);
            this.cbxTempSensorType.TabIndex = 15;
            this.cbxTempSensorType.SelectionChangeCommitted += new System.EventHandler(this.cbxTempSensorType_SelectionChangeCommitted);
            // 
            // tpage_DispControls
            // 
            this.tpage_DispControls.AccessibleDescription = "Disp Controls";
            this.tpage_DispControls.Controls.Add(this.groupBox21);
            this.tpage_DispControls.Controls.Add(this.groupBox13);
            this.tpage_DispControls.Controls.Add(this.groupBox14);
            this.tpage_DispControls.Controls.Add(this.groupBox9);
            this.tpage_DispControls.Location = new System.Drawing.Point(4, 34);
            this.tpage_DispControls.Name = "tpage_DispControls";
            this.tpage_DispControls.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_DispControls.Size = new System.Drawing.Size(588, 481);
            this.tpage_DispControls.TabIndex = 2;
            this.tpage_DispControls.Text = "Disp Controls";
            this.tpage_DispControls.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.AccessibleDescription = "Disp Heater";
            this.groupBox21.AutoSize = true;
            this.groupBox21.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox21.Controls.Add(this.btnDispHeaterDlg);
            this.groupBox21.Controls.Add(this.btnDispHeaterConnect);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.cbxDispHeaterComport);
            this.groupBox21.Controls.Add(this.label38);
            this.groupBox21.Controls.Add(this.cbxDispHeaterType);
            this.groupBox21.Location = new System.Drawing.Point(6, 260);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(239, 125);
            this.groupBox21.TabIndex = 156;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Disp Heater";
            // 
            // btnDispHeaterDlg
            // 
            this.btnDispHeaterDlg.AccessibleDescription = "Show";
            this.btnDispHeaterDlg.Location = new System.Drawing.Point(6, 77);
            this.btnDispHeaterDlg.Name = "btnDispHeaterDlg";
            this.btnDispHeaterDlg.Size = new System.Drawing.Size(75, 23);
            this.btnDispHeaterDlg.TabIndex = 28;
            this.btnDispHeaterDlg.Text = "Show";
            this.btnDispHeaterDlg.UseVisualStyleBackColor = true;
            this.btnDispHeaterDlg.Click += new System.EventHandler(this.btnDispHeaterDlg_Click);
            // 
            // btnDispHeaterConnect
            // 
            this.btnDispHeaterConnect.Location = new System.Drawing.Point(158, 77);
            this.btnDispHeaterConnect.Name = "btnDispHeaterConnect";
            this.btnDispHeaterConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDispHeaterConnect.TabIndex = 26;
            this.btnDispHeaterConnect.Text = "Connect";
            this.btnDispHeaterConnect.UseVisualStyleBackColor = true;
            this.btnDispHeaterConnect.Click += new System.EventHandler(this.btnDispHeaterConnect_Click);
            // 
            // label37
            // 
            this.label37.AccessibleDescription = "Comport";
            this.label37.Location = new System.Drawing.Point(6, 50);
            this.label37.Margin = new System.Windows.Forms.Padding(3);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 22);
            this.label37.TabIndex = 25;
            this.label37.Text = "Comport";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDispHeaterComport
            // 
            this.cbxDispHeaterComport.FormattingEnabled = true;
            this.cbxDispHeaterComport.Location = new System.Drawing.Point(112, 49);
            this.cbxDispHeaterComport.Name = "cbxDispHeaterComport";
            this.cbxDispHeaterComport.Size = new System.Drawing.Size(121, 26);
            this.cbxDispHeaterComport.TabIndex = 24;
            this.cbxDispHeaterComport.SelectionChangeCommitted += new System.EventHandler(this.cbxDispHeaterComport_SelectionChangeCommitted);
            // 
            // label38
            // 
            this.label38.AccessibleDescription = "Type";
            this.label38.Location = new System.Drawing.Point(6, 21);
            this.label38.Margin = new System.Windows.Forms.Padding(3);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 22);
            this.label38.TabIndex = 16;
            this.label38.Text = "Type";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDispHeaterType
            // 
            this.cbxDispHeaterType.FormattingEnabled = true;
            this.cbxDispHeaterType.Location = new System.Drawing.Point(112, 21);
            this.cbxDispHeaterType.Name = "cbxDispHeaterType";
            this.cbxDispHeaterType.Size = new System.Drawing.Size(121, 26);
            this.cbxDispHeaterType.TabIndex = 15;
            this.cbxDispHeaterType.SelectionChangeCommitted += new System.EventHandler(this.cbxDispHeaterType_SelectionChangeCommitted);
            // 
            // groupBox13
            // 
            this.groupBox13.AccessibleDescription = "Disp Controller 1";
            this.groupBox13.AutoSize = true;
            this.groupBox13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox13.Controls.Add(this.btn_ShowCtrl1);
            this.groupBox13.Controls.Add(this.btn_DispCtrl1Connect);
            this.groupBox13.Controls.Add(this.label17);
            this.groupBox13.Controls.Add(this.combox_DispCtrl1Comport);
            this.groupBox13.Controls.Add(this.label15);
            this.groupBox13.Controls.Add(this.combox_DispCtrl1Type);
            this.groupBox13.Location = new System.Drawing.Point(6, 6);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(239, 125);
            this.groupBox13.TabIndex = 148;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Disp Controller 1";
            // 
            // btn_ShowCtrl1
            // 
            this.btn_ShowCtrl1.AccessibleDescription = "Show";
            this.btn_ShowCtrl1.Location = new System.Drawing.Point(6, 77);
            this.btn_ShowCtrl1.Name = "btn_ShowCtrl1";
            this.btn_ShowCtrl1.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowCtrl1.TabIndex = 27;
            this.btn_ShowCtrl1.Text = "Show";
            this.btn_ShowCtrl1.UseVisualStyleBackColor = true;
            this.btn_ShowCtrl1.Click += new System.EventHandler(this.btn_ShowCtrl1_Click);
            // 
            // btn_DispCtrl1Connect
            // 
            this.btn_DispCtrl1Connect.Location = new System.Drawing.Point(158, 77);
            this.btn_DispCtrl1Connect.Name = "btn_DispCtrl1Connect";
            this.btn_DispCtrl1Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_DispCtrl1Connect.TabIndex = 26;
            this.btn_DispCtrl1Connect.Text = "Connect";
            this.btn_DispCtrl1Connect.UseVisualStyleBackColor = true;
            this.btn_DispCtrl1Connect.Click += new System.EventHandler(this.btn_DispCtrl1Connect_Click);
            // 
            // label17
            // 
            this.label17.AccessibleDescription = "Comport";
            this.label17.Location = new System.Drawing.Point(6, 50);
            this.label17.Margin = new System.Windows.Forms.Padding(3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 22);
            this.label17.TabIndex = 25;
            this.label17.Text = "Comport";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_DispCtrl1Comport
            // 
            this.combox_DispCtrl1Comport.FormattingEnabled = true;
            this.combox_DispCtrl1Comport.Location = new System.Drawing.Point(112, 49);
            this.combox_DispCtrl1Comport.Name = "combox_DispCtrl1Comport";
            this.combox_DispCtrl1Comport.Size = new System.Drawing.Size(121, 26);
            this.combox_DispCtrl1Comport.TabIndex = 24;
            this.combox_DispCtrl1Comport.SelectionChangeCommitted += new System.EventHandler(this.combox_DispCtrl1Comport_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.AccessibleDescription = "Type";
            this.label15.Location = new System.Drawing.Point(6, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 22);
            this.label15.TabIndex = 16;
            this.label15.Text = "Type";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_DispCtrl1Type
            // 
            this.combox_DispCtrl1Type.FormattingEnabled = true;
            this.combox_DispCtrl1Type.Location = new System.Drawing.Point(112, 21);
            this.combox_DispCtrl1Type.Name = "combox_DispCtrl1Type";
            this.combox_DispCtrl1Type.Size = new System.Drawing.Size(121, 26);
            this.combox_DispCtrl1Type.TabIndex = 15;
            this.combox_DispCtrl1Type.SelectionChangeCommitted += new System.EventHandler(this.combox_DispCtrl1Type_SelectionChangeCommitted);
            // 
            // groupBox14
            // 
            this.groupBox14.AccessibleDescription = "Disp Controller 2";
            this.groupBox14.AutoSize = true;
            this.groupBox14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox14.Controls.Add(this.btn_ShowCtrl2);
            this.groupBox14.Controls.Add(this.btn_DispCtrl2Connect);
            this.groupBox14.Controls.Add(this.label18);
            this.groupBox14.Controls.Add(this.combox_DispCtrl2Comport);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.combox_DispCtrl2Type);
            this.groupBox14.Location = new System.Drawing.Point(6, 133);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(239, 125);
            this.groupBox14.TabIndex = 149;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Disp Controller 2";
            // 
            // btn_ShowCtrl2
            // 
            this.btn_ShowCtrl2.AccessibleDescription = "Show";
            this.btn_ShowCtrl2.Location = new System.Drawing.Point(6, 77);
            this.btn_ShowCtrl2.Name = "btn_ShowCtrl2";
            this.btn_ShowCtrl2.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowCtrl2.TabIndex = 28;
            this.btn_ShowCtrl2.Text = "Show";
            this.btn_ShowCtrl2.UseVisualStyleBackColor = true;
            this.btn_ShowCtrl2.Click += new System.EventHandler(this.btn_ShowCtrl2_Click);
            // 
            // btn_DispCtrl2Connect
            // 
            this.btn_DispCtrl2Connect.Location = new System.Drawing.Point(158, 77);
            this.btn_DispCtrl2Connect.Name = "btn_DispCtrl2Connect";
            this.btn_DispCtrl2Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_DispCtrl2Connect.TabIndex = 26;
            this.btn_DispCtrl2Connect.Text = "Connect";
            this.btn_DispCtrl2Connect.UseVisualStyleBackColor = true;
            this.btn_DispCtrl2Connect.Click += new System.EventHandler(this.btn_DispCtrl2Connect_Click);
            // 
            // label18
            // 
            this.label18.AccessibleDescription = "Comport";
            this.label18.Location = new System.Drawing.Point(6, 50);
            this.label18.Margin = new System.Windows.Forms.Padding(3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 22);
            this.label18.TabIndex = 25;
            this.label18.Text = "Comport";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_DispCtrl2Comport
            // 
            this.combox_DispCtrl2Comport.FormattingEnabled = true;
            this.combox_DispCtrl2Comport.Location = new System.Drawing.Point(112, 49);
            this.combox_DispCtrl2Comport.Name = "combox_DispCtrl2Comport";
            this.combox_DispCtrl2Comport.Size = new System.Drawing.Size(121, 26);
            this.combox_DispCtrl2Comport.TabIndex = 24;
            this.combox_DispCtrl2Comport.SelectionChangeCommitted += new System.EventHandler(this.combox_DispCtrl2Comport_SelectionChangeCommitted);
            // 
            // label20
            // 
            this.label20.AccessibleDescription = "Type";
            this.label20.Location = new System.Drawing.Point(6, 21);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 22);
            this.label20.TabIndex = 16;
            this.label20.Text = "Type";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_DispCtrl2Type
            // 
            this.combox_DispCtrl2Type.FormattingEnabled = true;
            this.combox_DispCtrl2Type.Location = new System.Drawing.Point(112, 21);
            this.combox_DispCtrl2Type.Name = "combox_DispCtrl2Type";
            this.combox_DispCtrl2Type.Size = new System.Drawing.Size(121, 26);
            this.combox_DispCtrl2Type.TabIndex = 15;
            this.combox_DispCtrl2Type.SelectionChangeCommitted += new System.EventHandler(this.combox_DispCtrl2Type_SelectionChangeCommitted);
            // 
            // groupBox9
            // 
            this.groupBox9.AccessibleDescription = "Fluid Pressure";
            this.groupBox9.AutoSize = true;
            this.groupBox9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox9.Controls.Add(this.combox_Pressunit);
            this.groupBox9.Controls.Add(this.label34);
            this.groupBox9.Controls.Add(this.combox_FPressCh);
            this.groupBox9.Controls.Add(this.tbox_FPressSet);
            this.groupBox9.Controls.Add(this.lbl_FPressGet);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.lbl_FPress1Connect);
            this.groupBox9.Controls.Add(this.btn_FPressSet);
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Controls.Add(this.combox_FPress1Comport);
            this.groupBox9.Controls.Add(this.label29);
            this.groupBox9.Controls.Add(this.btn_FPressGet);
            this.groupBox9.Controls.Add(this.combox_FPressType);
            this.groupBox9.Location = new System.Drawing.Point(251, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(239, 240);
            this.groupBox9.TabIndex = 155;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Fluid Pressure";
            // 
            // combox_Pressunit
            // 
            this.combox_Pressunit.FormattingEnabled = true;
            this.combox_Pressunit.Location = new System.Drawing.Point(112, 49);
            this.combox_Pressunit.Name = "combox_Pressunit";
            this.combox_Pressunit.Size = new System.Drawing.Size(121, 26);
            this.combox_Pressunit.TabIndex = 37;
            this.combox_Pressunit.SelectionChangeCommitted += new System.EventHandler(this.combox_Pressunit_SelectionChangeCommitted);
            // 
            // label34
            // 
            this.label34.AccessibleDescription = "Unit";
            this.label34.Location = new System.Drawing.Point(6, 48);
            this.label34.Margin = new System.Windows.Forms.Padding(3);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(100, 22);
            this.label34.TabIndex = 36;
            this.label34.Text = "Unit";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_FPressCh
            // 
            this.combox_FPressCh.FormattingEnabled = true;
            this.combox_FPressCh.Location = new System.Drawing.Point(6, 78);
            this.combox_FPressCh.Name = "combox_FPressCh";
            this.combox_FPressCh.Size = new System.Drawing.Size(121, 26);
            this.combox_FPressCh.TabIndex = 35;
            this.combox_FPressCh.SelectionChangeCommitted += new System.EventHandler(this.combox_FPressCh_SelectionChangeCommitted);
            // 
            // tbox_FPressSet
            // 
            this.tbox_FPressSet.Location = new System.Drawing.Point(6, 165);
            this.tbox_FPressSet.Name = "tbox_FPressSet";
            this.tbox_FPressSet.Size = new System.Drawing.Size(50, 26);
            this.tbox_FPressSet.TabIndex = 29;
            this.tbox_FPressSet.Text = "0.9";
            this.tbox_FPressSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_FPressGet
            // 
            this.lbl_FPressGet.AccessibleDescription = "";
            this.lbl_FPressGet.Location = new System.Drawing.Point(6, 193);
            this.lbl_FPressGet.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_FPressGet.Name = "lbl_FPressGet";
            this.lbl_FPressGet.Size = new System.Drawing.Size(50, 22);
            this.lbl_FPressGet.TabIndex = 34;
            this.lbl_FPressGet.Text = "-";
            this.lbl_FPressGet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AccessibleDescription = "";
            this.label32.Location = new System.Drawing.Point(62, 164);
            this.label32.Margin = new System.Windows.Forms.Padding(3);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 22);
            this.label32.TabIndex = 30;
            this.label32.Text = "(MPa)";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FPress1Connect
            // 
            this.lbl_FPress1Connect.Location = new System.Drawing.Point(158, 133);
            this.lbl_FPress1Connect.Name = "lbl_FPress1Connect";
            this.lbl_FPress1Connect.Size = new System.Drawing.Size(75, 23);
            this.lbl_FPress1Connect.TabIndex = 28;
            this.lbl_FPress1Connect.Text = "Connect";
            this.lbl_FPress1Connect.UseVisualStyleBackColor = true;
            this.lbl_FPress1Connect.Click += new System.EventHandler(this.lbl_FPress1Connect_Click);
            // 
            // btn_FPressSet
            // 
            this.btn_FPressSet.Location = new System.Drawing.Point(118, 165);
            this.btn_FPressSet.Name = "btn_FPressSet";
            this.btn_FPressSet.Size = new System.Drawing.Size(70, 22);
            this.btn_FPressSet.TabIndex = 31;
            this.btn_FPressSet.Text = "Set";
            this.btn_FPressSet.UseVisualStyleBackColor = true;
            this.btn_FPressSet.Click += new System.EventHandler(this.btn_FPressSet_Click);
            // 
            // label31
            // 
            this.label31.AccessibleDescription = "Comport";
            this.label31.Location = new System.Drawing.Point(6, 106);
            this.label31.Margin = new System.Windows.Forms.Padding(3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(100, 22);
            this.label31.TabIndex = 27;
            this.label31.Text = "Comport";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.AccessibleDescription = "";
            this.label33.Location = new System.Drawing.Point(62, 193);
            this.label33.Margin = new System.Windows.Forms.Padding(3);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(50, 22);
            this.label33.TabIndex = 33;
            this.label33.Text = "(MPa)";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_FPress1Comport
            // 
            this.combox_FPress1Comport.FormattingEnabled = true;
            this.combox_FPress1Comport.Location = new System.Drawing.Point(112, 105);
            this.combox_FPress1Comport.Name = "combox_FPress1Comport";
            this.combox_FPress1Comport.Size = new System.Drawing.Size(121, 26);
            this.combox_FPress1Comport.TabIndex = 26;
            this.combox_FPress1Comport.SelectionChangeCommitted += new System.EventHandler(this.combox_FPress1Comport_SelectionChangeCommitted);
            // 
            // label29
            // 
            this.label29.AccessibleDescription = "Type";
            this.label29.Location = new System.Drawing.Point(6, 21);
            this.label29.Margin = new System.Windows.Forms.Padding(3);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 22);
            this.label29.TabIndex = 16;
            this.label29.Text = "Type";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_FPressGet
            // 
            this.btn_FPressGet.Location = new System.Drawing.Point(118, 193);
            this.btn_FPressGet.Name = "btn_FPressGet";
            this.btn_FPressGet.Size = new System.Drawing.Size(70, 22);
            this.btn_FPressGet.TabIndex = 32;
            this.btn_FPressGet.Text = "Get";
            this.btn_FPressGet.UseVisualStyleBackColor = true;
            this.btn_FPressGet.Click += new System.EventHandler(this.btn_FPressGet_Click);
            // 
            // combox_FPressType
            // 
            this.combox_FPressType.FormattingEnabled = true;
            this.combox_FPressType.Location = new System.Drawing.Point(112, 21);
            this.combox_FPressType.Name = "combox_FPressType";
            this.combox_FPressType.Size = new System.Drawing.Size(121, 26);
            this.combox_FPressType.TabIndex = 15;
            this.combox_FPressType.SelectionChangeCommitted += new System.EventHandler(this.combox_FPressType_SelectionChangeCommitted);
            // 
            // tpage_WeightStation
            // 
            this.tpage_WeightStation.Controls.Add(this.groupBox5);
            this.tpage_WeightStation.Location = new System.Drawing.Point(4, 34);
            this.tpage_WeightStation.Name = "tpage_WeightStation";
            this.tpage_WeightStation.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_WeightStation.Size = new System.Drawing.Size(588, 481);
            this.tpage_WeightStation.TabIndex = 3;
            this.tpage_WeightStation.Text = "Weight Station";
            this.tpage_WeightStation.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.AccessibleDescription = "Weight Station";
            this.groupBox5.AutoSize = true;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.btn_WeightDlg);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.btn_WeightConnect);
            this.groupBox5.Controls.Add(this.combox_WeightComport);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.combox_WeightStType);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(239, 125);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Weight Station";
            // 
            // btn_WeightDlg
            // 
            this.btn_WeightDlg.AccessibleDescription = "Control Dlg";
            this.btn_WeightDlg.Location = new System.Drawing.Point(6, 77);
            this.btn_WeightDlg.Name = "btn_WeightDlg";
            this.btn_WeightDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_WeightDlg.TabIndex = 157;
            this.btn_WeightDlg.Text = "Control Dlg";
            this.btn_WeightDlg.Click += new System.EventHandler(this.btn_WeightDlg_Click);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "Comport";
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Comport";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_WeightConnect
            // 
            this.btn_WeightConnect.Location = new System.Drawing.Point(158, 76);
            this.btn_WeightConnect.Name = "btn_WeightConnect";
            this.btn_WeightConnect.Size = new System.Drawing.Size(75, 23);
            this.btn_WeightConnect.TabIndex = 21;
            this.btn_WeightConnect.Text = "Connect";
            this.btn_WeightConnect.Click += new System.EventHandler(this.btn_WeightConnect_Click);
            // 
            // combox_WeightComport
            // 
            this.combox_WeightComport.FormattingEnabled = true;
            this.combox_WeightComport.Location = new System.Drawing.Point(112, 48);
            this.combox_WeightComport.Name = "combox_WeightComport";
            this.combox_WeightComport.Size = new System.Drawing.Size(121, 26);
            this.combox_WeightComport.TabIndex = 22;
            this.combox_WeightComport.SelectionChangeCommitted += new System.EventHandler(this.combox_WeightComport_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "Type";
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 16;
            this.label6.Text = "Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_WeightStType
            // 
            this.combox_WeightStType.FormattingEnabled = true;
            this.combox_WeightStType.Location = new System.Drawing.Point(112, 21);
            this.combox_WeightStType.Name = "combox_WeightStType";
            this.combox_WeightStType.Size = new System.Drawing.Size(121, 26);
            this.combox_WeightStType.TabIndex = 15;
            this.combox_WeightStType.SelectionChangeCommitted += new System.EventHandler(this.combox_WeightStType_SelectionChangeCommitted);
            // 
            // tpage_HeightSensor
            // 
            this.tpage_HeightSensor.AccessibleDescription = "Height and Z Sensor";
            this.tpage_HeightSensor.Controls.Add(this.groupBox4);
            this.tpage_HeightSensor.Controls.Add(this.groupBox7);
            this.tpage_HeightSensor.Location = new System.Drawing.Point(4, 34);
            this.tpage_HeightSensor.Name = "tpage_HeightSensor";
            this.tpage_HeightSensor.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_HeightSensor.Size = new System.Drawing.Size(588, 481);
            this.tpage_HeightSensor.TabIndex = 1;
            this.tpage_HeightSensor.Text = "Height & Z Sensor";
            this.tpage_HeightSensor.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleDescription = "Height Sensor";
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.tbox_HSensorIPAddress);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.btn_HeightSensorControlDlg);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btn_HSensorConnect);
            this.groupBox4.Controls.Add(this.combox_HSensorComport);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.combox_HSensorType);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 181);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Height Sensor";
            // 
            // label52
            // 
            this.label52.AccessibleDescription = "";
            this.label52.Location = new System.Drawing.Point(6, 134);
            this.label52.Margin = new System.Windows.Forms.Padding(3);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(227, 22);
            this.label52.TabIndex = 160;
            this.label52.Text = "IDL Baudrate 115200";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_HSensorIPAddress
            // 
            this.tbox_HSensorIPAddress.Location = new System.Drawing.Point(112, 77);
            this.tbox_HSensorIPAddress.Name = "tbox_HSensorIPAddress";
            this.tbox_HSensorIPAddress.Size = new System.Drawing.Size(121, 26);
            this.tbox_HSensorIPAddress.TabIndex = 159;
            this.tbox_HSensorIPAddress.TextChanged += new System.EventHandler(this.tbox_HSensorIPAddress_TextChanged);
            // 
            // label27
            // 
            this.label27.AccessibleDescription = "";
            this.label27.Location = new System.Drawing.Point(6, 77);
            this.label27.Margin = new System.Windows.Forms.Padding(3);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 22);
            this.label27.TabIndex = 158;
            this.label27.Text = "IP Address";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_HeightSensorControlDlg
            // 
            this.btn_HeightSensorControlDlg.Location = new System.Drawing.Point(6, 105);
            this.btn_HeightSensorControlDlg.Name = "btn_HeightSensorControlDlg";
            this.btn_HeightSensorControlDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_HeightSensorControlDlg.TabIndex = 156;
            this.btn_HeightSensorControlDlg.Text = "Control Dlg";
            this.btn_HeightSensorControlDlg.Click += new System.EventHandler(this.btn_HeightSensorControlDlg_Click);
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "Comport";
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 22);
            this.label8.TabIndex = 26;
            this.label8.Text = "Comport";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_HSensorConnect
            // 
            this.btn_HSensorConnect.Location = new System.Drawing.Point(158, 105);
            this.btn_HSensorConnect.Name = "btn_HSensorConnect";
            this.btn_HSensorConnect.Size = new System.Drawing.Size(75, 23);
            this.btn_HSensorConnect.TabIndex = 24;
            this.btn_HSensorConnect.Text = "Connect";
            this.btn_HSensorConnect.Click += new System.EventHandler(this.btn_HSensorConnect_Click);
            // 
            // combox_HSensorComport
            // 
            this.combox_HSensorComport.FormattingEnabled = true;
            this.combox_HSensorComport.Location = new System.Drawing.Point(112, 49);
            this.combox_HSensorComport.Name = "combox_HSensorComport";
            this.combox_HSensorComport.Size = new System.Drawing.Size(121, 26);
            this.combox_HSensorComport.TabIndex = 25;
            this.combox_HSensorComport.SelectionChangeCommitted += new System.EventHandler(this.combox_HSensorComport_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "Type";
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 16;
            this.label5.Text = "Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_HSensorType
            // 
            this.combox_HSensorType.FormattingEnabled = true;
            this.combox_HSensorType.Location = new System.Drawing.Point(112, 21);
            this.combox_HSensorType.Name = "combox_HSensorType";
            this.combox_HSensorType.Size = new System.Drawing.Size(121, 26);
            this.combox_HSensorType.TabIndex = 15;
            this.combox_HSensorType.SelectionChangeCommitted += new System.EventHandler(this.combox_HSensorType_SelectionChangeCommitted);
            // 
            // groupBox7
            // 
            this.groupBox7.AccessibleDescription = "Z Sensor";
            this.groupBox7.AutoSize = true;
            this.groupBox7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.combox_ZSensorType);
            this.groupBox7.Location = new System.Drawing.Point(6, 193);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(239, 72);
            this.groupBox7.TabIndex = 140;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Z Sensor";
            // 
            // label21
            // 
            this.label21.AccessibleDescription = "Type";
            this.label21.Location = new System.Drawing.Point(6, 21);
            this.label21.Margin = new System.Windows.Forms.Padding(3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 22);
            this.label21.TabIndex = 16;
            this.label21.Text = "Type";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_ZSensorType
            // 
            this.combox_ZSensorType.FormattingEnabled = true;
            this.combox_ZSensorType.Location = new System.Drawing.Point(112, 21);
            this.combox_ZSensorType.Name = "combox_ZSensorType";
            this.combox_ZSensorType.Size = new System.Drawing.Size(121, 26);
            this.combox_ZSensorType.TabIndex = 15;
            this.combox_ZSensorType.SelectionChangeCommitted += new System.EventHandler(this.combox_ZSensorType_SelectionChangeCommitted);
            // 
            // tpage_Camera
            // 
            this.tpage_Camera.AccessibleDescription = "Cameras & Lightings";
            this.tpage_Camera.Controls.Add(this.groupBox18);
            this.tpage_Camera.Controls.Add(this.groupBox2);
            this.tpage_Camera.Controls.Add(this.groupBox15);
            this.tpage_Camera.Controls.Add(this.groupBox16);
            this.tpage_Camera.Controls.Add(this.groupBox3);
            this.tpage_Camera.Controls.Add(this.groupBox1);
            this.tpage_Camera.Location = new System.Drawing.Point(4, 34);
            this.tpage_Camera.Name = "tpage_Camera";
            this.tpage_Camera.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_Camera.Size = new System.Drawing.Size(588, 481);
            this.tpage_Camera.TabIndex = 0;
            this.tpage_Camera.Text = "Cameras & Lightings";
            this.tpage_Camera.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.AccessibleDescription = "External Vision";
            this.groupBox18.AutoSize = true;
            this.groupBox18.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox18.Controls.Add(this.btn_Echo);
            this.groupBox18.Controls.Add(this.btn_SetupMode);
            this.groupBox18.Controls.Add(this.btn_RunMode);
            this.groupBox18.Controls.Add(this.btn_Trig1);
            this.groupBox18.Controls.Add(this.tbox_ExtVisPort);
            this.groupBox18.Controls.Add(this.label41);
            this.groupBox18.Controls.Add(this.btn_ExtVisConnect);
            this.groupBox18.Controls.Add(this.label39);
            this.groupBox18.Controls.Add(this.label40);
            this.groupBox18.Controls.Add(this.tbox_ExtVisIPAddress);
            this.groupBox18.Controls.Add(this.combox_ExtVisType);
            this.groupBox18.Location = new System.Drawing.Point(251, 132);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(239, 235);
            this.groupBox18.TabIndex = 157;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "External Vision";
            // 
            // btn_Echo
            // 
            this.btn_Echo.AccessibleDescription = "Echo";
            this.btn_Echo.Location = new System.Drawing.Point(6, 161);
            this.btn_Echo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Echo.Name = "btn_Echo";
            this.btn_Echo.Size = new System.Drawing.Size(85, 23);
            this.btn_Echo.TabIndex = 162;
            this.btn_Echo.Text = "Echo";
            this.btn_Echo.UseVisualStyleBackColor = true;
            this.btn_Echo.Click += new System.EventHandler(this.btn_Echo_Click);
            // 
            // btn_SetupMode
            // 
            this.btn_SetupMode.AccessibleDescription = "Setup Mode";
            this.btn_SetupMode.Location = new System.Drawing.Point(6, 134);
            this.btn_SetupMode.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SetupMode.Name = "btn_SetupMode";
            this.btn_SetupMode.Size = new System.Drawing.Size(85, 23);
            this.btn_SetupMode.TabIndex = 161;
            this.btn_SetupMode.Text = "Setup Mode";
            this.btn_SetupMode.UseVisualStyleBackColor = true;
            this.btn_SetupMode.Click += new System.EventHandler(this.btn_SetupMode_Click);
            // 
            // btn_RunMode
            // 
            this.btn_RunMode.AccessibleDescription = "Run Mode";
            this.btn_RunMode.Location = new System.Drawing.Point(6, 106);
            this.btn_RunMode.Name = "btn_RunMode";
            this.btn_RunMode.Size = new System.Drawing.Size(85, 23);
            this.btn_RunMode.TabIndex = 160;
            this.btn_RunMode.Text = "Run Mode";
            this.btn_RunMode.UseVisualStyleBackColor = true;
            this.btn_RunMode.Click += new System.EventHandler(this.btn_RunMode_Click);
            // 
            // btn_Trig1
            // 
            this.btn_Trig1.AccessibleDescription = "Trig";
            this.btn_Trig1.Location = new System.Drawing.Point(6, 188);
            this.btn_Trig1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Trig1.Name = "btn_Trig1";
            this.btn_Trig1.Size = new System.Drawing.Size(85, 23);
            this.btn_Trig1.TabIndex = 159;
            this.btn_Trig1.Text = "Trig";
            this.btn_Trig1.UseVisualStyleBackColor = true;
            this.btn_Trig1.Click += new System.EventHandler(this.btn_Trig1_Click);
            // 
            // tbox_ExtVisPort
            // 
            this.tbox_ExtVisPort.Location = new System.Drawing.Point(112, 78);
            this.tbox_ExtVisPort.Name = "tbox_ExtVisPort";
            this.tbox_ExtVisPort.Size = new System.Drawing.Size(121, 26);
            this.tbox_ExtVisPort.TabIndex = 158;
            this.tbox_ExtVisPort.Text = "8502";
            this.tbox_ExtVisPort.TextChanged += new System.EventHandler(this.tbox_ExtVisPort_TextChanged);
            // 
            // label41
            // 
            this.label41.AccessibleDescription = "Port";
            this.label41.Location = new System.Drawing.Point(6, 77);
            this.label41.Margin = new System.Windows.Forms.Padding(3);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(100, 22);
            this.label41.TabIndex = 157;
            this.label41.Text = "Port";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ExtVisConnect
            // 
            this.btn_ExtVisConnect.AccessibleDescription = "Connect";
            this.btn_ExtVisConnect.Location = new System.Drawing.Point(158, 106);
            this.btn_ExtVisConnect.Name = "btn_ExtVisConnect";
            this.btn_ExtVisConnect.Size = new System.Drawing.Size(75, 23);
            this.btn_ExtVisConnect.TabIndex = 21;
            this.btn_ExtVisConnect.Text = "Connect";
            this.btn_ExtVisConnect.UseVisualStyleBackColor = true;
            this.btn_ExtVisConnect.Click += new System.EventHandler(this.btn_ExtVisConnect_Click);
            // 
            // label39
            // 
            this.label39.AccessibleDescription = "Type";
            this.label39.Location = new System.Drawing.Point(6, 21);
            this.label39.Margin = new System.Windows.Forms.Padding(3);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 22);
            this.label39.TabIndex = 16;
            this.label39.Text = "Type";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.AccessibleDescription = "IP Address";
            this.label40.Location = new System.Drawing.Point(6, 49);
            this.label40.Margin = new System.Windows.Forms.Padding(3);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(100, 22);
            this.label40.TabIndex = 16;
            this.label40.Text = "IP Address";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_ExtVisIPAddress
            // 
            this.tbox_ExtVisIPAddress.Location = new System.Drawing.Point(112, 50);
            this.tbox_ExtVisIPAddress.Name = "tbox_ExtVisIPAddress";
            this.tbox_ExtVisIPAddress.Size = new System.Drawing.Size(121, 26);
            this.tbox_ExtVisIPAddress.TabIndex = 15;
            this.tbox_ExtVisIPAddress.Text = "192.168.255.233";
            this.tbox_ExtVisIPAddress.TextChanged += new System.EventHandler(this.tbox_ExtVisIPAddress_TextChanged);
            // 
            // combox_ExtVisType
            // 
            this.combox_ExtVisType.FormattingEnabled = true;
            this.combox_ExtVisType.Location = new System.Drawing.Point(112, 21);
            this.combox_ExtVisType.Name = "combox_ExtVisType";
            this.combox_ExtVisType.Size = new System.Drawing.Size(121, 26);
            this.combox_ExtVisType.TabIndex = 15;
            this.combox_ExtVisType.SelectionChangeCommitted += new System.EventHandler(this.combox_ExtVisType_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = "Camera 1";
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.btn_Cam1ControlDlg);
            this.groupBox2.Controls.Add(this.btn_Camera1Connect);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbox_Camera1IPAdress);
            this.groupBox2.Controls.Add(this.combox_Camera1Type);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 124);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera 1";
            // 
            // btn_Cam1ControlDlg
            // 
            this.btn_Cam1ControlDlg.Location = new System.Drawing.Point(6, 76);
            this.btn_Cam1ControlDlg.Name = "btn_Cam1ControlDlg";
            this.btn_Cam1ControlDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_Cam1ControlDlg.TabIndex = 155;
            this.btn_Cam1ControlDlg.Text = "Control Dlg";
            this.btn_Cam1ControlDlg.UseVisualStyleBackColor = true;
            this.btn_Cam1ControlDlg.Click += new System.EventHandler(this.btn_Cam1ControlDlg_Click);
            // 
            // btn_Camera1Connect
            // 
            this.btn_Camera1Connect.AccessibleDescription = "Connect";
            this.btn_Camera1Connect.Location = new System.Drawing.Point(158, 76);
            this.btn_Camera1Connect.Name = "btn_Camera1Connect";
            this.btn_Camera1Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Camera1Connect.TabIndex = 21;
            this.btn_Camera1Connect.Text = "Connect";
            this.btn_Camera1Connect.Click += new System.EventHandler(this.btn_Camera1Connect_Click);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "Type";
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 22);
            this.label10.TabIndex = 16;
            this.label10.Text = "Type";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "IP Address";
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "IP Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_Camera1IPAdress
            // 
            this.tbox_Camera1IPAdress.Location = new System.Drawing.Point(112, 48);
            this.tbox_Camera1IPAdress.Name = "tbox_Camera1IPAdress";
            this.tbox_Camera1IPAdress.Size = new System.Drawing.Size(121, 26);
            this.tbox_Camera1IPAdress.TabIndex = 15;
            this.tbox_Camera1IPAdress.Text = "192.168.255.233";
            this.tbox_Camera1IPAdress.TextChanged += new System.EventHandler(this.tbox_Camera1IPAdress_TextChanged);
            // 
            // combox_Camera1Type
            // 
            this.combox_Camera1Type.FormattingEnabled = true;
            this.combox_Camera1Type.Location = new System.Drawing.Point(112, 21);
            this.combox_Camera1Type.Name = "combox_Camera1Type";
            this.combox_Camera1Type.Size = new System.Drawing.Size(121, 26);
            this.combox_Camera1Type.TabIndex = 15;
            this.combox_Camera1Type.SelectionChangeCommitted += new System.EventHandler(this.combox_Camera1Type_SelectionChangeCommitted);
            // 
            // groupBox15
            // 
            this.groupBox15.AccessibleDescription = "Camera 2";
            this.groupBox15.AutoSize = true;
            this.groupBox15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox15.Controls.Add(this.btn_Cam2ControlDlg);
            this.groupBox15.Controls.Add(this.btn_Camera2Connect);
            this.groupBox15.Controls.Add(this.label22);
            this.groupBox15.Controls.Add(this.label23);
            this.groupBox15.Controls.Add(this.tbox_Camera2IPAdress);
            this.groupBox15.Controls.Add(this.combox_Camera2Type);
            this.groupBox15.Location = new System.Drawing.Point(6, 132);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(239, 124);
            this.groupBox15.TabIndex = 150;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Camera 2";
            // 
            // btn_Cam2ControlDlg
            // 
            this.btn_Cam2ControlDlg.Location = new System.Drawing.Point(6, 76);
            this.btn_Cam2ControlDlg.Name = "btn_Cam2ControlDlg";
            this.btn_Cam2ControlDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_Cam2ControlDlg.TabIndex = 156;
            this.btn_Cam2ControlDlg.Text = "Control Dlg";
            this.btn_Cam2ControlDlg.UseVisualStyleBackColor = true;
            this.btn_Cam2ControlDlg.Click += new System.EventHandler(this.btn_Cam2ControlDlg_Click);
            // 
            // btn_Camera2Connect
            // 
            this.btn_Camera2Connect.AccessibleDescription = "Connect";
            this.btn_Camera2Connect.Location = new System.Drawing.Point(158, 76);
            this.btn_Camera2Connect.Name = "btn_Camera2Connect";
            this.btn_Camera2Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Camera2Connect.TabIndex = 21;
            this.btn_Camera2Connect.Text = "Connect";
            this.btn_Camera2Connect.UseVisualStyleBackColor = true;
            this.btn_Camera2Connect.Click += new System.EventHandler(this.btn_Camera2Connect_Click);
            // 
            // label22
            // 
            this.label22.AccessibleDescription = "Type";
            this.label22.Location = new System.Drawing.Point(6, 21);
            this.label22.Margin = new System.Windows.Forms.Padding(3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 22);
            this.label22.TabIndex = 16;
            this.label22.Text = "Type";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AccessibleDescription = "IP Address";
            this.label23.Location = new System.Drawing.Point(8, 47);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 22);
            this.label23.TabIndex = 16;
            this.label23.Text = "IP Address";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_Camera2IPAdress
            // 
            this.tbox_Camera2IPAdress.Location = new System.Drawing.Point(112, 48);
            this.tbox_Camera2IPAdress.Name = "tbox_Camera2IPAdress";
            this.tbox_Camera2IPAdress.Size = new System.Drawing.Size(121, 26);
            this.tbox_Camera2IPAdress.TabIndex = 15;
            this.tbox_Camera2IPAdress.Text = "192.168.255.233";
            this.tbox_Camera2IPAdress.TextChanged += new System.EventHandler(this.tbox_Camera2IPAdress_TextChanged);
            // 
            // combox_Camera2Type
            // 
            this.combox_Camera2Type.FormattingEnabled = true;
            this.combox_Camera2Type.Location = new System.Drawing.Point(112, 21);
            this.combox_Camera2Type.Name = "combox_Camera2Type";
            this.combox_Camera2Type.Size = new System.Drawing.Size(121, 26);
            this.combox_Camera2Type.TabIndex = 15;
            this.combox_Camera2Type.SelectionChangeCommitted += new System.EventHandler(this.combox_Camera2Type_SelectionChangeCommitted);
            // 
            // groupBox16
            // 
            this.groupBox16.AccessibleDescription = "Camera 3";
            this.groupBox16.AutoSize = true;
            this.groupBox16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox16.Controls.Add(this.btn_Cam3ControlDlg);
            this.groupBox16.Controls.Add(this.btn_Camera3Connect);
            this.groupBox16.Controls.Add(this.label24);
            this.groupBox16.Controls.Add(this.label25);
            this.groupBox16.Controls.Add(this.tbox_Camera3IPAdress);
            this.groupBox16.Controls.Add(this.combox_Camera3Type);
            this.groupBox16.Location = new System.Drawing.Point(6, 258);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(239, 124);
            this.groupBox16.TabIndex = 151;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Camera 3";
            // 
            // btn_Cam3ControlDlg
            // 
            this.btn_Cam3ControlDlg.Location = new System.Drawing.Point(6, 76);
            this.btn_Cam3ControlDlg.Name = "btn_Cam3ControlDlg";
            this.btn_Cam3ControlDlg.Size = new System.Drawing.Size(75, 23);
            this.btn_Cam3ControlDlg.TabIndex = 157;
            this.btn_Cam3ControlDlg.Text = "Control Dlg";
            this.btn_Cam3ControlDlg.UseVisualStyleBackColor = true;
            this.btn_Cam3ControlDlg.Click += new System.EventHandler(this.btn_Cam3ControlDlg_Click);
            // 
            // btn_Camera3Connect
            // 
            this.btn_Camera3Connect.AccessibleDescription = "Connect";
            this.btn_Camera3Connect.Location = new System.Drawing.Point(158, 76);
            this.btn_Camera3Connect.Name = "btn_Camera3Connect";
            this.btn_Camera3Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Camera3Connect.TabIndex = 21;
            this.btn_Camera3Connect.Text = "Connect";
            this.btn_Camera3Connect.UseVisualStyleBackColor = true;
            this.btn_Camera3Connect.Click += new System.EventHandler(this.btn_Camera3Connect_Click);
            // 
            // label24
            // 
            this.label24.AccessibleDescription = "Type";
            this.label24.Location = new System.Drawing.Point(6, 21);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 22);
            this.label24.TabIndex = 16;
            this.label24.Text = "Type";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AccessibleDescription = "IP Address";
            this.label25.Location = new System.Drawing.Point(8, 47);
            this.label25.Margin = new System.Windows.Forms.Padding(3);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 22);
            this.label25.TabIndex = 16;
            this.label25.Text = "IP Address";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_Camera3IPAdress
            // 
            this.tbox_Camera3IPAdress.Location = new System.Drawing.Point(112, 48);
            this.tbox_Camera3IPAdress.Name = "tbox_Camera3IPAdress";
            this.tbox_Camera3IPAdress.Size = new System.Drawing.Size(121, 26);
            this.tbox_Camera3IPAdress.TabIndex = 15;
            this.tbox_Camera3IPAdress.Text = "192.168.255.233";
            this.tbox_Camera3IPAdress.TextChanged += new System.EventHandler(this.tbox_Camera3IPAdress_TextChanged);
            // 
            // combox_Camera3Type
            // 
            this.combox_Camera3Type.FormattingEnabled = true;
            this.combox_Camera3Type.Location = new System.Drawing.Point(112, 21);
            this.combox_Camera3Type.Name = "combox_Camera3Type";
            this.combox_Camera3Type.Size = new System.Drawing.Size(121, 26);
            this.combox_Camera3Type.TabIndex = 15;
            this.combox_Camera3Type.SelectionChangeCommitted += new System.EventHandler(this.combox_Camera3Type_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "Lighting Controller";
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btn_LCConnect);
            this.groupBox3.Controls.Add(this.combox_LCComport);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.combox_LCType);
            this.groupBox3.Location = new System.Drawing.Point(251, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 124);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ligthing Controller";
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "Comport";
            this.label9.Location = new System.Drawing.Point(6, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 22);
            this.label9.TabIndex = 29;
            this.label9.Text = "Comport";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_LCConnect
            // 
            this.btn_LCConnect.Location = new System.Drawing.Point(158, 76);
            this.btn_LCConnect.Name = "btn_LCConnect";
            this.btn_LCConnect.Size = new System.Drawing.Size(75, 23);
            this.btn_LCConnect.TabIndex = 27;
            this.btn_LCConnect.Text = "Connect";
            this.btn_LCConnect.Click += new System.EventHandler(this.btn_LCConnect_Click);
            // 
            // combox_LCComport
            // 
            this.combox_LCComport.FormattingEnabled = true;
            this.combox_LCComport.Location = new System.Drawing.Point(112, 50);
            this.combox_LCComport.Name = "combox_LCComport";
            this.combox_LCComport.Size = new System.Drawing.Size(121, 26);
            this.combox_LCComport.TabIndex = 28;
            this.combox_LCComport.SelectionChangeCommitted += new System.EventHandler(this.combox_LCComport_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "Type";
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_LCType
            // 
            this.combox_LCType.FormattingEnabled = true;
            this.combox_LCType.Location = new System.Drawing.Point(112, 22);
            this.combox_LCType.Name = "combox_LCType";
            this.combox_LCType.Size = new System.Drawing.Size(121, 26);
            this.combox_LCType.TabIndex = 15;
            this.combox_LCType.SelectionChangeCommitted += new System.EventHandler(this.combox_LCType_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = "Bottom Camera";
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combox_BottomCamType);
            this.groupBox1.Location = new System.Drawing.Point(6, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 72);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bottom Camera";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "Type";
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_BottomCamType
            // 
            this.combox_BottomCamType.FormattingEnabled = true;
            this.combox_BottomCamType.Location = new System.Drawing.Point(112, 21);
            this.combox_BottomCamType.Name = "combox_BottomCamType";
            this.combox_BottomCamType.Size = new System.Drawing.Size(121, 26);
            this.combox_BottomCamType.TabIndex = 15;
            this.combox_BottomCamType.SelectionChangeCommitted += new System.EventHandler(this.combox_BottomCamType_SelectionChangeCommitted);
            // 
            // tpage_MotionControls
            // 
            this.tpage_MotionControls.AccessibleDescription = "Motion Controls";
            this.tpage_MotionControls.Controls.Add(this.groupBox20);
            this.tpage_MotionControls.Controls.Add(this.groupBox19);
            this.tpage_MotionControls.Controls.Add(this.groupBox10);
            this.tpage_MotionControls.Controls.Add(this.groupBox6);
            this.tpage_MotionControls.Location = new System.Drawing.Point(4, 34);
            this.tpage_MotionControls.Name = "tpage_MotionControls";
            this.tpage_MotionControls.Padding = new System.Windows.Forms.Padding(3);
            this.tpage_MotionControls.Size = new System.Drawing.Size(588, 481);
            this.tpage_MotionControls.TabIndex = 5;
            this.tpage_MotionControls.Text = "Motion Controls";
            this.tpage_MotionControls.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.AccessibleDescription = "Gantry System";
            this.groupBox20.AutoSize = true;
            this.groupBox20.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox20.Controls.Add(this.label43);
            this.groupBox20.Controls.Add(this.cbxConveyorSystem);
            this.groupBox20.Location = new System.Drawing.Point(6, 104);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(239, 72);
            this.groupBox20.TabIndex = 144;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Conveyor System";
            // 
            // label43
            // 
            this.label43.AccessibleDescription = "Type";
            this.label43.Location = new System.Drawing.Point(6, 21);
            this.label43.Margin = new System.Windows.Forms.Padding(3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(100, 22);
            this.label43.TabIndex = 16;
            this.label43.Text = "Type";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxConveyorSystem
            // 
            this.cbxConveyorSystem.FormattingEnabled = true;
            this.cbxConveyorSystem.Location = new System.Drawing.Point(112, 21);
            this.cbxConveyorSystem.Name = "cbxConveyorSystem";
            this.cbxConveyorSystem.Size = new System.Drawing.Size(121, 26);
            this.cbxConveyorSystem.TabIndex = 15;
            this.cbxConveyorSystem.SelectionChangeCommitted += new System.EventHandler(this.cbxConveyorSystem_SelectionChangeCommitted);
            // 
            // groupBox19
            // 
            this.groupBox19.AccessibleDescription = "Equipment Info";
            this.groupBox19.Controls.Add(this.tbox_EquipmentName);
            this.groupBox19.Controls.Add(this.label42);
            this.groupBox19.Location = new System.Drawing.Point(251, 6);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(239, 56);
            this.groupBox19.TabIndex = 143;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Equipment Info";
            // 
            // tbox_EquipmentName
            // 
            this.tbox_EquipmentName.Location = new System.Drawing.Point(59, 22);
            this.tbox_EquipmentName.Name = "tbox_EquipmentName";
            this.tbox_EquipmentName.Size = new System.Drawing.Size(174, 26);
            this.tbox_EquipmentName.TabIndex = 18;
            this.tbox_EquipmentName.Text = "NSW";
            this.tbox_EquipmentName.MouseLeave += new System.EventHandler(this.tbox_EquipmentName_MouseLeave);
            // 
            // label42
            // 
            this.label42.AccessibleDescription = "ID";
            this.label42.Location = new System.Drawing.Point(6, 21);
            this.label42.Margin = new System.Windows.Forms.Padding(3);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(47, 22);
            this.label42.TabIndex = 17;
            this.label42.Text = "ID";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox10
            // 
            this.groupBox10.AccessibleDescription = "Gantry System";
            this.groupBox10.AutoSize = true;
            this.groupBox10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.combox_HeadConfig);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.combox_GantryConfig);
            this.groupBox10.Location = new System.Drawing.Point(6, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(239, 100);
            this.groupBox10.TabIndex = 142;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Gantry System";
            // 
            // label16
            // 
            this.label16.AccessibleDescription = "Head Config";
            this.label16.Location = new System.Drawing.Point(6, 49);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 22);
            this.label16.TabIndex = 146;
            this.label16.Text = "Head Config";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_HeadConfig
            // 
            this.combox_HeadConfig.FormattingEnabled = true;
            this.combox_HeadConfig.Location = new System.Drawing.Point(112, 49);
            this.combox_HeadConfig.Name = "combox_HeadConfig";
            this.combox_HeadConfig.Size = new System.Drawing.Size(121, 26);
            this.combox_HeadConfig.TabIndex = 145;
            this.combox_HeadConfig.SelectionChangeCommitted += new System.EventHandler(this.combox_HeadConfig_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AccessibleDescription = "Gantry Config";
            this.label11.Location = new System.Drawing.Point(6, 21);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 22);
            this.label11.TabIndex = 16;
            this.label11.Text = "Gantry Config";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // combox_GantryConfig
            // 
            this.combox_GantryConfig.FormattingEnabled = true;
            this.combox_GantryConfig.Location = new System.Drawing.Point(112, 21);
            this.combox_GantryConfig.Name = "combox_GantryConfig";
            this.combox_GantryConfig.Size = new System.Drawing.Size(121, 26);
            this.combox_GantryConfig.TabIndex = 15;
            this.combox_GantryConfig.SelectionChangeCommitted += new System.EventHandler(this.combox_GantryConfig_SelectionChangeCommitted);
            // 
            // groupBox6
            // 
            this.groupBox6.AccessibleDescription = "Device Config";
            this.groupBox6.AutoSize = true;
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.lbl_Device1Info);
            this.groupBox6.Controls.Add(this.lbl_Device0Info);
            this.groupBox6.Location = new System.Drawing.Point(6, 174);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(239, 113);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Device Config";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 22);
            this.label13.TabIndex = 138;
            this.label13.Text = "Device_1";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 22);
            this.label12.TabIndex = 137;
            this.label12.Text = "Device_0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Device1Info
            // 
            this.lbl_Device1Info.BackColor = System.Drawing.Color.White;
            this.lbl_Device1Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Device1Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Device1Info.Location = new System.Drawing.Point(112, 58);
            this.lbl_Device1Info.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Device1Info.Name = "lbl_Device1Info";
            this.lbl_Device1Info.Size = new System.Drawing.Size(121, 30);
            this.lbl_Device1Info.TabIndex = 135;
            this.lbl_Device1Info.Text = "DI 1";
            this.lbl_Device1Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Device1Info.Click += new System.EventHandler(this.lbl_Device1Info_Click);
            // 
            // lbl_Device0Info
            // 
            this.lbl_Device0Info.BackColor = System.Drawing.Color.White;
            this.lbl_Device0Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Device0Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Device0Info.Location = new System.Drawing.Point(112, 22);
            this.lbl_Device0Info.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Device0Info.Name = "lbl_Device0Info";
            this.lbl_Device0Info.Size = new System.Drawing.Size(121, 30);
            this.lbl_Device0Info.TabIndex = 133;
            this.lbl_Device0Info.Text = "DI 1";
            this.lbl_Device0Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Device0Info.Click += new System.EventHandler(this.lbl_Device0Info_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpage_MotionControls);
            this.tabControl1.Controls.Add(this.tpage_Camera);
            this.tabControl1.Controls.Add(this.tpage_HeightSensor);
            this.tabControl1.Controls.Add(this.tpage_WeightStation);
            this.tabControl1.Controls.Add(this.tpage_DispControls);
            this.tabControl1.Controls.Add(this.tpage_Others);
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 30);
            this.tabControl1.Location = new System.Drawing.Point(8, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(596, 519);
            this.tabControl1.TabIndex = 158;
            // 
            // frmSystemConfig
            // 
            this.AccessibleDescription = "";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(630, 541);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSystemConfig";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "System Config";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSystemConfig_FormClosed);
            this.Load += new System.EventHandler(this.frmGantryConfig_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSystemConfig_KeyDown);
            this.tpage_Others.ResumeLayout(false);
            this.tpage_Others.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_LogLevel)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.tpage_DispControls.ResumeLayout(false);
            this.tpage_DispControls.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tpage_WeightStation.ResumeLayout(false);
            this.tpage_WeightStation.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tpage_HeightSensor.ResumeLayout(false);
            this.tpage_HeightSensor.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tpage_Camera.ResumeLayout(false);
            this.tpage_Camera.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tpage_MotionControls.ResumeLayout(false);
            this.tpage_MotionControls.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.TabPage tpage_Others;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnSendVideoLoggerStopRecord;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox tbxVideoLoggerMsg1;
        private System.Windows.Forms.TextBox tbxVideoLoggerPort;
        private System.Windows.Forms.Button btnSendVideoLoggerTestMsg;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox cbxVideoLoggerType;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nud_LogLevel;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnTempCtrlUpdate;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.ComboBox combox_TempCtrl3;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox combox_TempCtrl2;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox combox_TempCtrl1;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox combox_TempCtrl0;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox combox_TempCtrl_Type;
        private System.Windows.Forms.Button btn_TempCtrl_CtrlDlg;
        private System.Windows.Forms.Button btn_TempCtrl_Connect;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox combox_TempCtrl_PortName;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnTempSensorInfo;
        private System.Windows.Forms.Button btnTempSensorDisconnect;
        private System.Windows.Forms.Button btnTempSensorConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTempSensorComport;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxTempSensorType;
        private System.Windows.Forms.TabPage tpage_DispControls;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button btnDispHeaterDlg;
        private System.Windows.Forms.Button btnDispHeaterConnect;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cbxDispHeaterComport;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cbxDispHeaterType;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btn_ShowCtrl1;
        private System.Windows.Forms.Button btn_DispCtrl1Connect;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox combox_DispCtrl1Comport;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox combox_DispCtrl1Type;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btn_ShowCtrl2;
        private System.Windows.Forms.Button btn_DispCtrl2Connect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox combox_DispCtrl2Comport;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox combox_DispCtrl2Type;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox combox_Pressunit;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox combox_FPressCh;
        private System.Windows.Forms.TextBox tbox_FPressSet;
        private System.Windows.Forms.Label lbl_FPressGet;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button lbl_FPress1Connect;
        private System.Windows.Forms.Button btn_FPressSet;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox combox_FPress1Comport;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btn_FPressGet;
        private System.Windows.Forms.ComboBox combox_FPressType;
        private System.Windows.Forms.TabPage tpage_WeightStation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_WeightDlg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_WeightConnect;
        private System.Windows.Forms.ComboBox combox_WeightComport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combox_WeightStType;
        private System.Windows.Forms.TabPage tpage_HeightSensor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbox_HSensorIPAddress;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btn_HeightSensorControlDlg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_HSensorConnect;
        private System.Windows.Forms.ComboBox combox_HSensorComport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combox_HSensorType;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox combox_ZSensorType;
        private System.Windows.Forms.TabPage tpage_Camera;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btn_Echo;
        private System.Windows.Forms.Button btn_SetupMode;
        private System.Windows.Forms.Button btn_RunMode;
        private System.Windows.Forms.Button btn_Trig1;
        private System.Windows.Forms.TextBox tbox_ExtVisPort;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btn_ExtVisConnect;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox tbox_ExtVisIPAddress;
        private System.Windows.Forms.ComboBox combox_ExtVisType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Cam1ControlDlg;
        private System.Windows.Forms.Button btn_Camera1Connect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_Camera1IPAdress;
        private System.Windows.Forms.ComboBox combox_Camera1Type;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btn_Cam2ControlDlg;
        private System.Windows.Forms.Button btn_Camera2Connect;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbox_Camera2IPAdress;
        private System.Windows.Forms.ComboBox combox_Camera2Type;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btn_Cam3ControlDlg;
        private System.Windows.Forms.Button btn_Camera3Connect;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbox_Camera3IPAdress;
        private System.Windows.Forms.ComboBox combox_Camera3Type;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_LCConnect;
        private System.Windows.Forms.ComboBox combox_LCComport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combox_LCType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combox_BottomCamType;
        private System.Windows.Forms.TabPage tpage_MotionControls;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox cbxConveyorSystem;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.TextBox tbox_EquipmentName;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox combox_HeadConfig;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combox_GantryConfig;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_Device1Info;
        private System.Windows.Forms.Label lbl_Device0Info;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox tbxVideoLoggerMsg2;
        private System.Windows.Forms.RadioButton rbVideoLoggerMsg2;
        private System.Windows.Forms.RadioButton rbVideoLoggerMsg1;
        private System.Windows.Forms.Label label52;
    }
}