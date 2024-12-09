namespace NDispWin
{
    partial class frm_DispProg2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DispProg2));
            this.lv_Program = new System.Windows.Forms.ListView();
            this.cms_Command = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_CopyPaste = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCopyPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPastePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPasteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Prog = new System.Windows.Forms.Panel();
            this.rtbAdmin = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbl_PumpType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_HeadOp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_DispATrig = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_DispBTrig = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslbl_ChuckVac = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_RecipeType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmr_Run = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdd_Station = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_Station1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Station8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtn_SetZ = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_SetOrigin = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_CamGoOrigin = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_NeedleGoOrigin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslbl_Status = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_MasterAlign = new System.Windows.Forms.ToolStripButton();
            this.ts_File = new System.Windows.Forms.ToolStrip();
            this.ts_ProgNew = new System.Windows.Forms.ToolStripButton();
            this.ts_ProgOpen = new System.Windows.Forms.ToolStripButton();
            this.ts_ProgSave = new System.Windows.Forms.ToolStripButton();
            this.ts_ProgSaveAs = new System.Windows.Forms.ToolStripButton();
            this.ts_ProgManage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_ProgModel = new System.Windows.Forms.ToolStripButton();
            this.ts_ProgSetting = new System.Windows.Forms.ToolStripButton();
            this.tslbl_ProgName = new System.Windows.Forms.ToolStripLabel();
            this.ts_ProgEdit = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Lock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tscombox_Script = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ProgLineAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ProgLineInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ProgLineDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_ProgLineMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_ProgLineMoveDn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_OffsetAll = new System.Windows.Forms.ToolStripButton();
            this.ts_Bottom = new System.Windows.Forms.ToolStrip();
            this.tsddbtn_RunMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_RunMode_Camera = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RunMode_Normal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_RunMode_Dry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Snail = new System.Windows.Forms.ToolStripButton();
            this.tsddbtn_ForceSingle = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_ForceSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Dual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Run = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Resume = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtn_Cycle = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ts_Function = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tmr_UpdateDisplay = new System.Windows.Forms.Timer(this.components);
            this.cms_CopyPaste.SuspendLayout();
            this.pnl_Prog.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ts_File.SuspendLayout();
            this.ts_ProgEdit.SuspendLayout();
            this.ts_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ts_Function.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Program
            // 
            this.lv_Program.BackColor = System.Drawing.SystemColors.Window;
            this.lv_Program.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Program.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lv_Program.FullRowSelect = true;
            this.lv_Program.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lv_Program.HideSelection = false;
            this.lv_Program.Location = new System.Drawing.Point(0, 0);
            this.lv_Program.Margin = new System.Windows.Forms.Padding(2);
            this.lv_Program.MultiSelect = false;
            this.lv_Program.Name = "lv_Program";
            this.lv_Program.Size = new System.Drawing.Size(529, 239);
            this.lv_Program.TabIndex = 0;
            this.lv_Program.UseCompatibleStateImageBehavior = false;
            this.lv_Program.View = System.Windows.Forms.View.Details;
            this.lv_Program.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lv_Program_MouseDown);
            this.lv_Program.MouseLeave += new System.EventHandler(this.lv_Program_MouseLeave);
            this.lv_Program.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lv_Program_MouseUp);
            // 
            // cms_Command
            // 
            this.cms_Command.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_Command.Name = "cms_Command";
            this.cms_Command.Size = new System.Drawing.Size(61, 4);
            // 
            // cms_CopyPaste
            // 
            this.cms_CopyPaste.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_CopyPaste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCopyPosition,
            this.cmsPastePosition,
            this.cmsCopyGroup,
            this.cmsPasteGroup});
            this.cms_CopyPaste.Name = "cms_CopyPaste";
            this.cms_CopyPaste.Size = new System.Drawing.Size(154, 92);
            // 
            // cmsCopyPosition
            // 
            this.cmsCopyPosition.Name = "cmsCopyPosition";
            this.cmsCopyPosition.Size = new System.Drawing.Size(153, 22);
            this.cmsCopyPosition.Text = "Copy Positions";
            this.cmsCopyPosition.Click += new System.EventHandler(this.tsmi_CopyPosition_Click);
            // 
            // cmsPastePosition
            // 
            this.cmsPastePosition.Name = "cmsPastePosition";
            this.cmsPastePosition.Size = new System.Drawing.Size(153, 22);
            this.cmsPastePosition.Text = "Paste Positions";
            this.cmsPastePosition.Click += new System.EventHandler(this.tsmi_PastePosition_Click);
            // 
            // cmsCopyGroup
            // 
            this.cmsCopyGroup.Name = "cmsCopyGroup";
            this.cmsCopyGroup.Size = new System.Drawing.Size(153, 22);
            this.cmsCopyGroup.Text = "Copy Group";
            this.cmsCopyGroup.Click += new System.EventHandler(this.cmsCopyGroup_Click);
            // 
            // cmsPasteGroup
            // 
            this.cmsPasteGroup.Name = "cmsPasteGroup";
            this.cmsPasteGroup.Size = new System.Drawing.Size(153, 22);
            this.cmsPasteGroup.Text = "Paste Group";
            this.cmsPasteGroup.Click += new System.EventHandler(this.cmsPasteGroup_Click);
            // 
            // pnl_Prog
            // 
            this.pnl_Prog.Controls.Add(this.lv_Program);
            this.pnl_Prog.Controls.Add(this.rtbAdmin);
            this.pnl_Prog.Controls.Add(this.statusStrip1);
            this.pnl_Prog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Prog.Location = new System.Drawing.Point(0, 117);
            this.pnl_Prog.Name = "pnl_Prog";
            this.pnl_Prog.Size = new System.Drawing.Size(529, 333);
            this.pnl_Prog.TabIndex = 65;
            // 
            // rtbAdmin
            // 
            this.rtbAdmin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbAdmin.Location = new System.Drawing.Point(0, 239);
            this.rtbAdmin.Name = "rtbAdmin";
            this.rtbAdmin.Size = new System.Drawing.Size(529, 71);
            this.rtbAdmin.TabIndex = 77;
            this.rtbAdmin.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbl_PumpType,
            this.tsslbl_HeadOp,
            this.tsslbl_DispATrig,
            this.tsslbl_DispBTrig,
            this.tslbl_ChuckVac,
            this.tsslbl_RecipeType});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(529, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 75;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbl_PumpType
            // 
            this.tsslbl_PumpType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslbl_PumpType.Name = "tsslbl_PumpType";
            this.tsslbl_PumpType.Size = new System.Drawing.Size(103, 18);
            this.tsslbl_PumpType.Text = "tsslbl_PumpType";
            // 
            // tsslbl_HeadOp
            // 
            this.tsslbl_HeadOp.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslbl_HeadOp.Name = "tsslbl_HeadOp";
            this.tsslbl_HeadOp.Size = new System.Drawing.Size(88, 18);
            this.tsslbl_HeadOp.Text = "tsslbl_HeadOp";
            // 
            // tsslbl_DispATrig
            // 
            this.tsslbl_DispATrig.AutoSize = false;
            this.tsslbl_DispATrig.BackColor = System.Drawing.Color.Red;
            this.tsslbl_DispATrig.Name = "tsslbl_DispATrig";
            this.tsslbl_DispATrig.Size = new System.Drawing.Size(18, 18);
            this.tsslbl_DispATrig.Text = "A";
            // 
            // tsslbl_DispBTrig
            // 
            this.tsslbl_DispBTrig.AutoSize = false;
            this.tsslbl_DispBTrig.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslbl_DispBTrig.Name = "tsslbl_DispBTrig";
            this.tsslbl_DispBTrig.Size = new System.Drawing.Size(18, 18);
            this.tsslbl_DispBTrig.Text = "B";
            // 
            // tslbl_ChuckVac
            // 
            this.tslbl_ChuckVac.AutoSize = false;
            this.tslbl_ChuckVac.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslbl_ChuckVac.Name = "tslbl_ChuckVac";
            this.tslbl_ChuckVac.Size = new System.Drawing.Size(80, 18);
            this.tslbl_ChuckVac.Text = "Chuck Vac";
            this.tslbl_ChuckVac.Visible = false;
            // 
            // tsslbl_RecipeType
            // 
            this.tsslbl_RecipeType.AutoSize = false;
            this.tsslbl_RecipeType.Name = "tsslbl_RecipeType";
            this.tsslbl_RecipeType.Size = new System.Drawing.Size(30, 14);
            this.tsslbl_RecipeType.Text = "xml";
            // 
            // tmr_Run
            // 
            this.tmr_Run.Enabled = true;
            this.tmr_Run.Interval = 10;
            this.tmr_Run.Tick += new System.EventHandler(this.tmr_Run_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdd_Station,
            this.tsbtn_SetZ,
            this.tsbtn_SetOrigin,
            this.tsbtn_CamGoOrigin,
            this.tsbtn_NeedleGoOrigin,
            this.toolStripSeparator2,
            this.tslbl_Status,
            this.toolStripSeparator8,
            this.tsbtn_MasterAlign});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(529, 39);
            this.toolStrip1.TabIndex = 64;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsdd_Station
            // 
            this.tsdd_Station.AutoSize = false;
            this.tsdd_Station.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsdd_Station.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Station1,
            this.tsmi_Station2,
            this.tsmi_Station3,
            this.tsmi_Station4,
            this.tsmi_Station5,
            this.tsmi_Station6,
            this.tsmi_Station7,
            this.tsmi_Station8});
            this.tsdd_Station.Image = ((System.Drawing.Image)(resources.GetObject("tsdd_Station.Image")));
            this.tsdd_Station.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdd_Station.Name = "tsdd_Station";
            this.tsdd_Station.Size = new System.Drawing.Size(80, 36);
            this.tsdd_Station.Text = "Station 1";
            // 
            // tsmi_Station1
            // 
            this.tsmi_Station1.AccessibleDescription = "Station1";
            this.tsmi_Station1.AutoSize = false;
            this.tsmi_Station1.Name = "tsmi_Station1";
            this.tsmi_Station1.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station1.Text = "Station 1";
            this.tsmi_Station1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station1.Click += new System.EventHandler(this.tsmi_Station1_Click);
            // 
            // tsmi_Station2
            // 
            this.tsmi_Station2.AccessibleDescription = "Station2";
            this.tsmi_Station2.AutoSize = false;
            this.tsmi_Station2.Name = "tsmi_Station2";
            this.tsmi_Station2.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station2.Text = "Station 2";
            this.tsmi_Station2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station2.Click += new System.EventHandler(this.tsmi_Station2_Click);
            // 
            // tsmi_Station3
            // 
            this.tsmi_Station3.AccessibleDescription = "Station3";
            this.tsmi_Station3.AutoSize = false;
            this.tsmi_Station3.Name = "tsmi_Station3";
            this.tsmi_Station3.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station3.Text = "Station 3";
            this.tsmi_Station3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station3.Click += new System.EventHandler(this.tsmi_Station3_Click);
            // 
            // tsmi_Station4
            // 
            this.tsmi_Station4.AccessibleDescription = "Station4";
            this.tsmi_Station4.AutoSize = false;
            this.tsmi_Station4.Name = "tsmi_Station4";
            this.tsmi_Station4.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station4.Text = "Station 4";
            this.tsmi_Station4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station4.Click += new System.EventHandler(this.tsmi_Station4_Click);
            // 
            // tsmi_Station5
            // 
            this.tsmi_Station5.AccessibleDescription = "Station5";
            this.tsmi_Station5.AutoSize = false;
            this.tsmi_Station5.Name = "tsmi_Station5";
            this.tsmi_Station5.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station5.Text = "Station 5";
            this.tsmi_Station5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station5.Click += new System.EventHandler(this.tsmi_Station5_Click);
            // 
            // tsmi_Station6
            // 
            this.tsmi_Station6.AccessibleDescription = "Station6";
            this.tsmi_Station6.AutoSize = false;
            this.tsmi_Station6.Name = "tsmi_Station6";
            this.tsmi_Station6.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station6.Text = "Station 6";
            this.tsmi_Station6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station6.Click += new System.EventHandler(this.tsmi_Station6_Click);
            // 
            // tsmi_Station7
            // 
            this.tsmi_Station7.AccessibleDescription = "Station7";
            this.tsmi_Station7.AutoSize = false;
            this.tsmi_Station7.Name = "tsmi_Station7";
            this.tsmi_Station7.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station7.Text = "Station 7";
            this.tsmi_Station7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station7.Click += new System.EventHandler(this.tsmi_Station7_Click);
            // 
            // tsmi_Station8
            // 
            this.tsmi_Station8.AccessibleDescription = "Station8";
            this.tsmi_Station8.AutoSize = false;
            this.tsmi_Station8.Name = "tsmi_Station8";
            this.tsmi_Station8.Size = new System.Drawing.Size(152, 30);
            this.tsmi_Station8.Text = "Station 8";
            this.tsmi_Station8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsmi_Station8.Click += new System.EventHandler(this.tsmi_Station8_Click);
            // 
            // tsbtn_SetZ
            // 
            this.tsbtn_SetZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_SetZ.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_SetZ.Image")));
            this.tsbtn_SetZ.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_SetZ.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_SetZ.Name = "tsbtn_SetZ";
            this.tsbtn_SetZ.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_SetZ.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_SetZ.Text = "Set Z";
            this.tsbtn_SetZ.Click += new System.EventHandler(this.tsbtn_SetZ_Click);
            // 
            // tsbtn_SetOrigin
            // 
            this.tsbtn_SetOrigin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_SetOrigin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_SetOrigin.Image")));
            this.tsbtn_SetOrigin.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_SetOrigin.Name = "tsbtn_SetOrigin";
            this.tsbtn_SetOrigin.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_SetOrigin.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_SetOrigin.Text = "Set";
            this.tsbtn_SetOrigin.Click += new System.EventHandler(this.tsbtn_SetOrigin_Click);
            // 
            // tsbtn_CamGoOrigin
            // 
            this.tsbtn_CamGoOrigin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_CamGoOrigin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_CamGoOrigin.Image")));
            this.tsbtn_CamGoOrigin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_CamGoOrigin.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_CamGoOrigin.Name = "tsbtn_CamGoOrigin";
            this.tsbtn_CamGoOrigin.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_CamGoOrigin.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_CamGoOrigin.Text = "Camera";
            this.tsbtn_CamGoOrigin.ToolTipText = "Move Camera to Origin";
            this.tsbtn_CamGoOrigin.Click += new System.EventHandler(this.tsbtn_CamGoOrigin_Click);
            // 
            // tsbtn_NeedleGoOrigin
            // 
            this.tsbtn_NeedleGoOrigin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_NeedleGoOrigin.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_NeedleGoOrigin.Image")));
            this.tsbtn_NeedleGoOrigin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_NeedleGoOrigin.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_NeedleGoOrigin.Name = "tsbtn_NeedleGoOrigin";
            this.tsbtn_NeedleGoOrigin.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_NeedleGoOrigin.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_NeedleGoOrigin.Text = "Needle";
            this.tsbtn_NeedleGoOrigin.ToolTipText = "Move Needle to Origin";
            this.tsbtn_NeedleGoOrigin.Click += new System.EventHandler(this.tsbtn_NeedleGoOrigin_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tslbl_Status
            // 
            this.tslbl_Status.AutoSize = false;
            this.tslbl_Status.DoubleClickEnabled = true;
            this.tslbl_Status.ForeColor = System.Drawing.Color.Red;
            this.tslbl_Status.Name = "tslbl_Status";
            this.tslbl_Status.Size = new System.Drawing.Size(100, 36);
            this.tslbl_Status.Text = "Status: Ready";
            this.tslbl_Status.DoubleClick += new System.EventHandler(this.tslbl_Status_DoubleClick);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_MasterAlign
            // 
            this.tsbtn_MasterAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_MasterAlign.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_MasterAlign.Image")));
            this.tsbtn_MasterAlign.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_MasterAlign.Name = "tsbtn_MasterAlign";
            this.tsbtn_MasterAlign.Size = new System.Drawing.Size(34, 36);
            this.tsbtn_MasterAlign.Text = "Master Align";
            this.tsbtn_MasterAlign.Click += new System.EventHandler(this.tsbtn_MasterAlign_Click);
            // 
            // ts_File
            // 
            this.ts_File.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ts_File.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_File.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_ProgNew,
            this.ts_ProgOpen,
            this.ts_ProgSave,
            this.ts_ProgSaveAs,
            this.ts_ProgManage,
            this.toolStripSeparator1,
            this.ts_ProgModel,
            this.ts_ProgSetting,
            this.tslbl_ProgName});
            this.ts_File.Location = new System.Drawing.Point(0, 39);
            this.ts_File.Name = "ts_File";
            this.ts_File.Size = new System.Drawing.Size(529, 39);
            this.ts_File.TabIndex = 66;
            this.ts_File.Text = "toolStrip2";
            // 
            // ts_ProgNew
            // 
            this.ts_ProgNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_ProgNew.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgNew.Image")));
            this.ts_ProgNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgNew.Name = "ts_ProgNew";
            this.ts_ProgNew.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgNew.Size = new System.Drawing.Size(36, 36);
            this.ts_ProgNew.Text = "Program New";
            this.ts_ProgNew.Click += new System.EventHandler(this.ts_ProgNew_Click);
            // 
            // ts_ProgOpen
            // 
            this.ts_ProgOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_ProgOpen.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgOpen.Image")));
            this.ts_ProgOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgOpen.Name = "ts_ProgOpen";
            this.ts_ProgOpen.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgOpen.Size = new System.Drawing.Size(36, 36);
            this.ts_ProgOpen.Text = "Program Open";
            this.ts_ProgOpen.Click += new System.EventHandler(this.ts_ProgOpen_Click);
            // 
            // ts_ProgSave
            // 
            this.ts_ProgSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_ProgSave.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgSave.Image")));
            this.ts_ProgSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgSave.Name = "ts_ProgSave";
            this.ts_ProgSave.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgSave.Size = new System.Drawing.Size(36, 36);
            this.ts_ProgSave.Text = "Program Save";
            this.ts_ProgSave.Click += new System.EventHandler(this.ts_ProgSave_Click);
            // 
            // ts_ProgSaveAs
            // 
            this.ts_ProgSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_ProgSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgSaveAs.Image")));
            this.ts_ProgSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgSaveAs.Name = "ts_ProgSaveAs";
            this.ts_ProgSaveAs.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgSaveAs.Size = new System.Drawing.Size(36, 36);
            this.ts_ProgSaveAs.Text = "Program Save As";
            this.ts_ProgSaveAs.Click += new System.EventHandler(this.ts_ProgSaveAs_Click);
            // 
            // ts_ProgManage
            // 
            this.ts_ProgManage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_ProgManage.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgManage.Image")));
            this.ts_ProgManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgManage.Name = "ts_ProgManage";
            this.ts_ProgManage.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgManage.Size = new System.Drawing.Size(36, 36);
            this.ts_ProgManage.Text = "Program Manage";
            this.ts_ProgManage.Click += new System.EventHandler(this.ts_ProgManage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // ts_ProgModel
            // 
            this.ts_ProgModel.AccessibleDescription = "Model";
            this.ts_ProgModel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_ProgModel.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgModel.Image")));
            this.ts_ProgModel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgModel.Name = "ts_ProgModel";
            this.ts_ProgModel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ts_ProgModel.Padding = new System.Windows.Forms.Padding(1);
            this.ts_ProgModel.Size = new System.Drawing.Size(66, 36);
            this.ts_ProgModel.Text = "Model";
            this.ts_ProgModel.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ts_ProgModel.Click += new System.EventHandler(this.ts_ProgModel_Click);
            // 
            // ts_ProgSetting
            // 
            this.ts_ProgSetting.AccessibleDescription = "Setting";
            this.ts_ProgSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ts_ProgSetting.Image = ((System.Drawing.Image)(resources.GetObject("ts_ProgSetting.Image")));
            this.ts_ProgSetting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ts_ProgSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ProgSetting.Name = "ts_ProgSetting";
            this.ts_ProgSetting.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ts_ProgSetting.Size = new System.Drawing.Size(64, 36);
            this.ts_ProgSetting.Text = "Setting";
            this.ts_ProgSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ts_ProgSetting.Click += new System.EventHandler(this.ts_ProgSetting_Click);
            // 
            // tslbl_ProgName
            // 
            this.tslbl_ProgName.AutoSize = false;
            this.tslbl_ProgName.Name = "tslbl_ProgName";
            this.tslbl_ProgName.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tslbl_ProgName.Size = new System.Drawing.Size(200, 36);
            this.tslbl_ProgName.Text = "tslbl_ProgName [This is to simulate long filename]";
            this.tslbl_ProgName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ts_ProgEdit
            // 
            this.ts_ProgEdit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ts_ProgEdit.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_ProgEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_ProgEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Lock,
            this.toolStripSeparator3,
            this.tscombox_Script,
            this.toolStripSeparator9,
            this.tsbtn_ProgLineAdd,
            this.tsbtn_ProgLineInsert,
            this.tsbtn_ProgLineDel,
            this.toolStripSeparator4,
            this.tsbtn_ProgLineMoveUp,
            this.tsbtn_ProgLineMoveDn,
            this.toolStripSeparator10,
            this.tsbtn_OffsetAll});
            this.ts_ProgEdit.Location = new System.Drawing.Point(0, 78);
            this.ts_ProgEdit.Name = "ts_ProgEdit";
            this.ts_ProgEdit.Size = new System.Drawing.Size(529, 39);
            this.ts_ProgEdit.TabIndex = 69;
            this.ts_ProgEdit.Text = "toolStrip2";
            // 
            // tsbtn_Lock
            // 
            this.tsbtn_Lock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Lock.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Lock.Image")));
            this.tsbtn_Lock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Lock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Lock.Name = "tsbtn_Lock";
            this.tsbtn_Lock.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Lock.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Lock.Text = "Program Lock";
            this.tsbtn_Lock.Click += new System.EventHandler(this.tsbtn_Lock_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tscombox_Script
            // 
            this.tscombox_Script.AutoSize = false;
            this.tscombox_Script.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscombox_Script.Items.AddRange(new object[] {
            "Script: MAIN",
            "Script: SUB1",
            "Script: SUB2",
            "Script: SUB3"});
            this.tscombox_Script.Name = "tscombox_Script";
            this.tscombox_Script.Size = new System.Drawing.Size(120, 23);
            this.tscombox_Script.DropDownClosed += new System.EventHandler(this.tscombox_Script_DropDownClosed);
            this.tscombox_Script.Click += new System.EventHandler(this.tscombox_Script_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_ProgLineAdd
            // 
            this.tsbtn_ProgLineAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProgLineAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProgLineAdd.Image")));
            this.tsbtn_ProgLineAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_ProgLineAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProgLineAdd.Name = "tsbtn_ProgLineAdd";
            this.tsbtn_ProgLineAdd.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_ProgLineAdd.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_ProgLineAdd.Text = "Add Program Line";
            this.tsbtn_ProgLineAdd.Click += new System.EventHandler(this.tsbtn_ProgLineAdd_Click);
            // 
            // tsbtn_ProgLineInsert
            // 
            this.tsbtn_ProgLineInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProgLineInsert.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProgLineInsert.Image")));
            this.tsbtn_ProgLineInsert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_ProgLineInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProgLineInsert.Name = "tsbtn_ProgLineInsert";
            this.tsbtn_ProgLineInsert.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_ProgLineInsert.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_ProgLineInsert.Text = "Insert Program Line";
            this.tsbtn_ProgLineInsert.Click += new System.EventHandler(this.tsbtn_ProgLineInsert_Click);
            // 
            // tsbtn_ProgLineDel
            // 
            this.tsbtn_ProgLineDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProgLineDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProgLineDel.Image")));
            this.tsbtn_ProgLineDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_ProgLineDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProgLineDel.Name = "tsbtn_ProgLineDel";
            this.tsbtn_ProgLineDel.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_ProgLineDel.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_ProgLineDel.Text = "Delete Program Line";
            this.tsbtn_ProgLineDel.Click += new System.EventHandler(this.tsbtn_ProgLineDel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_ProgLineMoveUp
            // 
            this.tsbtn_ProgLineMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProgLineMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProgLineMoveUp.Image")));
            this.tsbtn_ProgLineMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_ProgLineMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProgLineMoveUp.Name = "tsbtn_ProgLineMoveUp";
            this.tsbtn_ProgLineMoveUp.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_ProgLineMoveUp.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_ProgLineMoveUp.Text = "Program Line Move Up";
            this.tsbtn_ProgLineMoveUp.Click += new System.EventHandler(this.tsbtn_ProgLineMoveUp_Click);
            // 
            // tsbtn_ProgLineMoveDn
            // 
            this.tsbtn_ProgLineMoveDn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_ProgLineMoveDn.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_ProgLineMoveDn.Image")));
            this.tsbtn_ProgLineMoveDn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_ProgLineMoveDn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_ProgLineMoveDn.Name = "tsbtn_ProgLineMoveDn";
            this.tsbtn_ProgLineMoveDn.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_ProgLineMoveDn.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_ProgLineMoveDn.Text = "Program Line Move Down";
            this.tsbtn_ProgLineMoveDn.Click += new System.EventHandler(this.tsbtn_ProgLineMoveDn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_OffsetAll
            // 
            this.tsbtn_OffsetAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_OffsetAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_OffsetAll.Image")));
            this.tsbtn_OffsetAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_OffsetAll.Name = "tsbtn_OffsetAll";
            this.tsbtn_OffsetAll.Size = new System.Drawing.Size(24, 36);
            this.tsbtn_OffsetAll.Text = "toolStripButton2";
            this.tsbtn_OffsetAll.ToolTipText = "Offset All Dispense Pattern";
            this.tsbtn_OffsetAll.Click += new System.EventHandler(this.tsbtn_OffsetAll_Click);
            // 
            // ts_Bottom
            // 
            this.ts_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ts_Bottom.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ts_Bottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Bottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_Bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbtn_RunMode,
            this.toolStripSeparator6,
            this.tsbtn_Snail,
            this.tsddbtn_ForceSingle,
            this.toolStripSeparator7,
            this.tsbtn_Run,
            this.tsbtn_Resume,
            this.tsbtn_Cancel,
            this.tsbtn_Stop,
            this.toolStripSeparator5,
            this.tsbtn_Cycle});
            this.ts_Bottom.Location = new System.Drawing.Point(0, 450);
            this.ts_Bottom.Name = "ts_Bottom";
            this.ts_Bottom.Size = new System.Drawing.Size(529, 39);
            this.ts_Bottom.TabIndex = 71;
            this.ts_Bottom.Text = "toolStrip2";
            // 
            // tsddbtn_RunMode
            // 
            this.tsddbtn_RunMode.AutoSize = false;
            this.tsddbtn_RunMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_RunMode_Camera,
            this.tsmi_RunMode_Normal,
            this.tsmi_RunMode_Dry});
            this.tsddbtn_RunMode.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtn_RunMode.Image")));
            this.tsddbtn_RunMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddbtn_RunMode.ImageTransparentColor = System.Drawing.Color.White;
            this.tsddbtn_RunMode.Name = "tsddbtn_RunMode";
            this.tsddbtn_RunMode.Size = new System.Drawing.Size(125, 36);
            this.tsddbtn_RunMode.Text = "Camera";
            this.tsddbtn_RunMode.ToolTipText = "Run Mode";
            // 
            // tsmi_RunMode_Camera
            // 
            this.tsmi_RunMode_Camera.AccessibleDescription = "Camera";
            this.tsmi_RunMode_Camera.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_RunMode_Camera.Image")));
            this.tsmi_RunMode_Camera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_RunMode_Camera.Name = "tsmi_RunMode_Camera";
            this.tsmi_RunMode_Camera.Size = new System.Drawing.Size(128, 36);
            this.tsmi_RunMode_Camera.Text = "Camera";
            this.tsmi_RunMode_Camera.Click += new System.EventHandler(this.tsmi_RunMode_Camera_Click);
            // 
            // tsmi_RunMode_Normal
            // 
            this.tsmi_RunMode_Normal.AccessibleDescription = "Normal";
            this.tsmi_RunMode_Normal.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_RunMode_Normal.Image")));
            this.tsmi_RunMode_Normal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_RunMode_Normal.Name = "tsmi_RunMode_Normal";
            this.tsmi_RunMode_Normal.Size = new System.Drawing.Size(128, 36);
            this.tsmi_RunMode_Normal.Text = "Normal";
            this.tsmi_RunMode_Normal.Click += new System.EventHandler(this.tsmi_RunMode_Normal_Click);
            // 
            // tsmi_RunMode_Dry
            // 
            this.tsmi_RunMode_Dry.AccessibleDescription = "Dry";
            this.tsmi_RunMode_Dry.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_RunMode_Dry.Image")));
            this.tsmi_RunMode_Dry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_RunMode_Dry.Name = "tsmi_RunMode_Dry";
            this.tsmi_RunMode_Dry.Size = new System.Drawing.Size(128, 36);
            this.tsmi_RunMode_Dry.Text = "Dry";
            this.tsmi_RunMode_Dry.Click += new System.EventHandler(this.tsmi_RunMode_Dry_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_Snail
            // 
            this.tsbtn_Snail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Snail.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Snail.Image")));
            this.tsbtn_Snail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Snail.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Snail.Name = "tsbtn_Snail";
            this.tsbtn_Snail.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Snail.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Snail.Text = "Slow Motion";
            this.tsbtn_Snail.Click += new System.EventHandler(this.tsbtn_Snail_Click);
            // 
            // tsddbtn_ForceSingle
            // 
            this.tsddbtn_ForceSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbtn_ForceSingle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ForceSingle,
            this.tsmi_Dual});
            this.tsddbtn_ForceSingle.Image = ((System.Drawing.Image)(resources.GetObject("tsddbtn_ForceSingle.Image")));
            this.tsddbtn_ForceSingle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddbtn_ForceSingle.ImageTransparentColor = System.Drawing.Color.White;
            this.tsddbtn_ForceSingle.Name = "tsddbtn_ForceSingle";
            this.tsddbtn_ForceSingle.Size = new System.Drawing.Size(43, 36);
            this.tsddbtn_ForceSingle.Text = "toolStripDropDownButton1";
            // 
            // tsmi_ForceSingle
            // 
            this.tsmi_ForceSingle.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_ForceSingle.Image")));
            this.tsmi_ForceSingle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_ForceSingle.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmi_ForceSingle.Name = "tsmi_ForceSingle";
            this.tsmi_ForceSingle.Size = new System.Drawing.Size(154, 36);
            this.tsmi_ForceSingle.Text = "Force Single";
            this.tsmi_ForceSingle.Click += new System.EventHandler(this.tsmi_ForceSingle_Click);
            // 
            // tsmi_Dual
            // 
            this.tsmi_Dual.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Dual.Image")));
            this.tsmi_Dual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi_Dual.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmi_Dual.Name = "tsmi_Dual";
            this.tsmi_Dual.Size = new System.Drawing.Size(154, 36);
            this.tsmi_Dual.Text = "Dual";
            this.tsmi_Dual.Click += new System.EventHandler(this.tsmi_Dual_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_Run
            // 
            this.tsbtn_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Run.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Run.Image")));
            this.tsbtn_Run.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Run.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Run.Name = "tsbtn_Run";
            this.tsbtn_Run.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Run.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Run.Text = "Run";
            this.tsbtn_Run.Click += new System.EventHandler(this.tsbtn_Run_Click);
            // 
            // tsbtn_Resume
            // 
            this.tsbtn_Resume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Resume.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Resume.Image")));
            this.tsbtn_Resume.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Resume.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Resume.Name = "tsbtn_Resume";
            this.tsbtn_Resume.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Resume.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Resume.Text = "Resume";
            this.tsbtn_Resume.Click += new System.EventHandler(this.tsbtn_Resume_Click);
            // 
            // tsbtn_Cancel
            // 
            this.tsbtn_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cancel.Image")));
            this.tsbtn_Cancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Cancel.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Cancel.Name = "tsbtn_Cancel";
            this.tsbtn_Cancel.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Cancel.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Cancel.Text = "Cancel";
            this.tsbtn_Cancel.Click += new System.EventHandler(this.tsbtn_Cancel_Click);
            // 
            // tsbtn_Stop
            // 
            this.tsbtn_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Stop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Stop.Image")));
            this.tsbtn_Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Stop.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Stop.Name = "tsbtn_Stop";
            this.tsbtn_Stop.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Stop.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Stop.Text = "Stop";
            this.tsbtn_Stop.Click += new System.EventHandler(this.tsbtn_Stop_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtn_Cycle
            // 
            this.tsbtn_Cycle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtn_Cycle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Cycle.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_Cycle.Image")));
            this.tsbtn_Cycle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtn_Cycle.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtn_Cycle.Name = "tsbtn_Cycle";
            this.tsbtn_Cycle.Padding = new System.Windows.Forms.Padding(1);
            this.tsbtn_Cycle.Size = new System.Drawing.Size(36, 36);
            this.tsbtn_Cycle.Text = "Cycle";
            this.tsbtn_Cycle.Click += new System.EventHandler(this.tsbtn_Cycle_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_Prog);
            this.splitContainer1.Panel1.Controls.Add(this.ts_ProgEdit);
            this.splitContainer1.Panel1.Controls.Add(this.ts_File);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.ts_Bottom);
            this.splitContainer1.Panel1MinSize = 500;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1087, 489);
            this.splitContainer1.SplitterDistance = 529;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 73;
            this.splitContainer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_MouseDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 53);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(552, 436);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 4;
            this.splitContainer2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer2_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ts_Function);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 53);
            this.panel2.TabIndex = 2;
            // 
            // ts_Function
            // 
            this.ts_Function.AllowItemReorder = true;
            this.ts_Function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ts_Function.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ts_Function.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Function.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_Function.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.ts_Function.Location = new System.Drawing.Point(0, 0);
            this.ts_Function.Name = "ts_Function";
            this.ts_Function.Size = new System.Drawing.Size(470, 53);
            this.ts_Function.TabIndex = 1;
            this.ts_Function.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 50);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(470, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(82, 53);
            this.panel3.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.AccessibleDescription = "Close";
            this.btn_Close.Location = new System.Drawing.Point(3, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tmr_UpdateDisplay
            // 
            this.tmr_UpdateDisplay.Enabled = true;
            this.tmr_UpdateDisplay.Interval = 500;
            this.tmr_UpdateDisplay.Tick += new System.EventHandler(this.tmr_UpdateDisplay_Tick);
            // 
            // frm_DispProg2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1089, 491);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Navy;
            this.MinimizeBox = false;
            this.Name = "frm_DispProg2";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.Text = "frmDispProg";
            this.Activated += new System.EventHandler(this.frm_DispCore_DispProg_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDispProg_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_DispProg2_FormClosed);
            this.Load += new System.EventHandler(this.frmDispProg_Load);
            this.Shown += new System.EventHandler(this.frm_DispProg2_Shown);
            this.VisibleChanged += new System.EventHandler(this.frm_DispProg2_VisibleChanged);
            this.Resize += new System.EventHandler(this.frm_DispProg2_Resize);
            this.cms_CopyPaste.ResumeLayout(false);
            this.pnl_Prog.ResumeLayout(false);
            this.pnl_Prog.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ts_File.ResumeLayout(false);
            this.ts_File.PerformLayout();
            this.ts_ProgEdit.ResumeLayout(false);
            this.ts_ProgEdit.PerformLayout();
            this.ts_Bottom.ResumeLayout(false);
            this.ts_Bottom.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ts_Function.ResumeLayout(false);
            this.ts_Function.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_Program;
        private System.Windows.Forms.ContextMenuStrip cms_Command;
        private System.Windows.Forms.ContextMenuStrip cms_CopyPaste;
        private System.Windows.Forms.ToolStripMenuItem cmsCopyPosition;
        private System.Windows.Forms.ToolStripMenuItem cmsPastePosition;
        private System.Windows.Forms.Timer tmr_Run;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_NeedleGoOrigin;
        private System.Windows.Forms.ToolStripButton tsbtn_SetOrigin;
        private System.Windows.Forms.ToolStripButton tsbtn_SetZ;
        private System.Windows.Forms.ToolStripButton tsbtn_CamGoOrigin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnl_Prog;
        private System.Windows.Forms.ToolStrip ts_File;
        private System.Windows.Forms.ToolStripButton ts_ProgNew;
        private System.Windows.Forms.ToolStripButton ts_ProgOpen;
        private System.Windows.Forms.ToolStripButton ts_ProgSave;
        private System.Windows.Forms.ToolStripButton ts_ProgSaveAs;
        private System.Windows.Forms.ToolStripButton ts_ProgManage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ts_ProgModel;
        private System.Windows.Forms.ToolStrip ts_ProgEdit;
        private System.Windows.Forms.ToolStripButton tsbtn_Lock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtn_ProgLineAdd;
        private System.Windows.Forms.ToolStripButton tsbtn_ProgLineDel;
        private System.Windows.Forms.ToolStripButton tsbtn_ProgLineInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtn_ProgLineMoveUp;
        private System.Windows.Forms.ToolStripButton tsbtn_ProgLineMoveDn;
        private System.Windows.Forms.ToolStrip ts_Bottom;
        private System.Windows.Forms.ToolStripButton tsbtn_Snail;
        private System.Windows.Forms.ToolStripButton tsbtn_Run;
        private System.Windows.Forms.ToolStripButton tsbtn_Resume;
        private System.Windows.Forms.ToolStripButton tsbtn_Cancel;
        private System.Windows.Forms.ToolStripButton tsbtn_Stop;
        private System.Windows.Forms.ToolStripButton tsbtn_Cycle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton ts_ProgSetting;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtn_ForceSingle;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ForceSingle;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Dual;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtn_RunMode;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RunMode_Dry;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RunMode_Normal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_RunMode_Camera;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_HeadOp;
        private System.Windows.Forms.ToolStripLabel tslbl_Status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripComboBox tscombox_Script;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_DispATrig;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_DispBTrig;
        private System.Windows.Forms.ToolStripDropDownButton tsdd_Station;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station5;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station6;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Station8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip ts_Function;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ToolStripLabel tslbl_ProgName;
        private System.Windows.Forms.Timer tmr_UpdateDisplay;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_PumpType;
        private System.Windows.Forms.ToolStripButton tsbtn_MasterAlign;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel tslbl_ChuckVac;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_RecipeType;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem cmsCopyGroup;
        private System.Windows.Forms.ToolStripMenuItem cmsPasteGroup;
        private System.Windows.Forms.ToolStripButton tsbtn_OffsetAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.RichTextBox rtbAdmin;
    }
}

