namespace haltest2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.TextBox();
            this.writeFile = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnEnum = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bnSetParam = new System.Windows.Forms.Button();
            this.bnGetParam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFrameRate = new System.Windows.Forms.TextBox();
            this.tbGain = new System.Windows.Forms.TextBox();
            this.tbExposure = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnTriggerExec = new System.Windows.Forms.Button();
            this.cbSoftTrigger = new System.Windows.Forms.CheckBox();
            this.bnStopGrab = new System.Windows.Forms.Button();
            this.bnStartGrab = new System.Windows.Forms.Button();
            this.bnTriggerMode = new System.Windows.Forms.RadioButton();
            this.bnContinuesMode = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bnSaveJpg = new System.Windows.Forms.Button();
            this.bnSaveBmp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deleLVitem = new System.Windows.Forms.Button();
            this.clearListView = new System.Windows.Forms.Button();
            this.seleFolder = new System.Windows.Forms.Button();
            this.dealImg = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bnStopGrab1 = new System.Windows.Forms.Button();
            this.bnStartGrab1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openImg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.writeFile3D = new System.Windows.Forms.Button();
            this.deleLV2select = new System.Windows.Forms.Button();
            this.clearLV2 = new System.Windows.Forms.Button();
            this.seleFolder3D = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.deal3DImg = new System.Windows.Forms.Button();
            this.pictureBoxBW = new System.Windows.Forms.PictureBox();
            this.pictureBoxTL = new System.Windows.Forms.PictureBox();
            this.openBWimg = new System.Windows.Forms.Button();
            this.openTLimg = new System.Windows.Forms.Button();
            this.communicationSetting1 = new LjxaDisp.CommunicationSetting();
            this._button_close_device = new System.Windows.Forms.Button();
            this._button_acquire_stop = new System.Windows.Forms.Button();
            this._button_acquire_start = new System.Windows.Forms.Button();
            this._button_openDevice = new System.Windows.Forms.Button();
            this.ljxaWindows3D1 = new LjxaDisp.LjxaWindows3D();
            this._logBox = new System.Windows.Forms.TextBox();
            this.timerwaitimage = new System.Windows.Forms.Timer(this.components);
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTL)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Font = new System.Drawing.Font("宋体", 9F);
            this.tabControl2.Location = new System.Drawing.Point(12, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1262, 797);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage5.Controls.Add(this.logBox);
            this.tabPage5.Controls.Add(this.writeFile);
            this.tabPage5.Controls.Add(this.listView1);
            this.tabPage5.Controls.Add(this.pictureBox2);
            this.tabPage5.Controls.Add(this.tabPage);
            this.tabPage5.Controls.Add(this.pictureBox1);
            this.tabPage5.Controls.Add(this.cbDeviceList);
            this.tabPage5.Font = new System.Drawing.Font("宋体", 10F);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1254, 771);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "2D处理";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(693, 463);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(538, 217);
            this.logBox.TabIndex = 20;
            // 
            // writeFile
            // 
            this.writeFile.Font = new System.Drawing.Font("宋体", 14F);
            this.writeFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.writeFile.Location = new System.Drawing.Point(693, 686);
            this.writeFile.Name = "writeFile";
            this.writeFile.Size = new System.Drawing.Size(538, 57);
            this.writeFile.TabIndex = 5;
            this.writeFile.Text = "数据链接到文件";
            this.writeFile.UseVisualStyleBackColor = true;
            this.writeFile.Click += new System.EventHandler(this.writeFile_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.Location = new System.Drawing.Point(3, 463);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(685, 280);
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(706, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(453, 399);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Font = new System.Drawing.Font("宋体", 9F);
            this.tabPage.Location = new System.Drawing.Point(473, 11);
            this.tabPage.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(220, 441);
            this.tabPage.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(212, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnClose);
            this.groupBox1.Controls.Add(this.bnOpen);
            this.groupBox1.Controls.Add(this.bnEnum);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 86);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化";
            // 
            // bnClose
            // 
            this.bnClose.Enabled = false;
            this.bnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnClose.Location = new System.Drawing.Point(115, 51);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(64, 25);
            this.bnClose.TabIndex = 2;
            this.bnClose.Text = "关闭设备";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // bnOpen
            // 
            this.bnOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnOpen.Location = new System.Drawing.Point(20, 51);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(70, 25);
            this.bnOpen.TabIndex = 1;
            this.bnOpen.Text = "打开设备";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnEnum
            // 
            this.bnEnum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnEnum.Location = new System.Drawing.Point(20, 20);
            this.bnEnum.Name = "bnEnum";
            this.bnEnum.Size = new System.Drawing.Size(159, 25);
            this.bnEnum.TabIndex = 0;
            this.bnEnum.Text = "查找设备";
            this.bnEnum.UseVisualStyleBackColor = true;
            this.bnEnum.Click += new System.EventHandler(this.bnEnum_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bnSetParam);
            this.groupBox4.Controls.Add(this.bnGetParam);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbFrameRate);
            this.groupBox4.Controls.Add(this.tbGain);
            this.groupBox4.Controls.Add(this.tbExposure);
            this.groupBox4.Location = new System.Drawing.Point(0, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 136);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参数";
            // 
            // bnSetParam
            // 
            this.bnSetParam.Enabled = false;
            this.bnSetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSetParam.Location = new System.Drawing.Point(119, 104);
            this.bnSetParam.Name = "bnSetParam";
            this.bnSetParam.Size = new System.Drawing.Size(68, 21);
            this.bnSetParam.TabIndex = 7;
            this.bnSetParam.Text = "设置参数";
            this.bnSetParam.UseVisualStyleBackColor = true;
            this.bnSetParam.Click += new System.EventHandler(this.bnSetParam_Click);
            // 
            // bnGetParam
            // 
            this.bnGetParam.Enabled = false;
            this.bnGetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnGetParam.Location = new System.Drawing.Point(22, 106);
            this.bnGetParam.Name = "bnGetParam";
            this.bnGetParam.Size = new System.Drawing.Size(73, 19);
            this.bnGetParam.TabIndex = 6;
            this.bnGetParam.Text = "获取参数";
            this.bnGetParam.UseVisualStyleBackColor = true;
            this.bnGetParam.Click += new System.EventHandler(this.bnGetParam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(20, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "帧率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "增益";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "曝光";
            // 
            // tbFrameRate
            // 
            this.tbFrameRate.Enabled = false;
            this.tbFrameRate.Location = new System.Drawing.Point(97, 69);
            this.tbFrameRate.Name = "tbFrameRate";
            this.tbFrameRate.Size = new System.Drawing.Size(93, 21);
            this.tbFrameRate.TabIndex = 2;
            // 
            // tbGain
            // 
            this.tbGain.Enabled = false;
            this.tbGain.Location = new System.Drawing.Point(97, 45);
            this.tbGain.Name = "tbGain";
            this.tbGain.Size = new System.Drawing.Size(93, 21);
            this.tbGain.TabIndex = 1;
            // 
            // tbExposure
            // 
            this.tbExposure.Enabled = false;
            this.tbExposure.Location = new System.Drawing.Point(97, 16);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Size = new System.Drawing.Size(93, 21);
            this.tbExposure.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnTriggerExec);
            this.groupBox2.Controls.Add(this.cbSoftTrigger);
            this.groupBox2.Controls.Add(this.bnStopGrab);
            this.groupBox2.Controls.Add(this.bnStartGrab);
            this.groupBox2.Controls.Add(this.bnTriggerMode);
            this.groupBox2.Controls.Add(this.bnContinuesMode);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox2.Location = new System.Drawing.Point(3, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采集图像";
            // 
            // bnTriggerExec
            // 
            this.bnTriggerExec.Enabled = false;
            this.bnTriggerExec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnTriggerExec.Location = new System.Drawing.Point(107, 80);
            this.bnTriggerExec.Name = "bnTriggerExec";
            this.bnTriggerExec.Size = new System.Drawing.Size(79, 21);
            this.bnTriggerExec.TabIndex = 5;
            this.bnTriggerExec.Text = "软触发一次";
            this.bnTriggerExec.UseVisualStyleBackColor = true;
            this.bnTriggerExec.Click += new System.EventHandler(this.bnTriggerExec_Click);
            // 
            // cbSoftTrigger
            // 
            this.cbSoftTrigger.AutoSize = true;
            this.cbSoftTrigger.Enabled = false;
            this.cbSoftTrigger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSoftTrigger.Location = new System.Drawing.Point(20, 83);
            this.cbSoftTrigger.Name = "cbSoftTrigger";
            this.cbSoftTrigger.Size = new System.Drawing.Size(60, 16);
            this.cbSoftTrigger.TabIndex = 4;
            this.cbSoftTrigger.Text = "软触发";
            this.cbSoftTrigger.UseVisualStyleBackColor = true;
            this.cbSoftTrigger.CheckedChanged += new System.EventHandler(this.cbSoftTrigger_CheckedChanged);
            // 
            // bnStopGrab
            // 
            this.bnStopGrab.Enabled = false;
            this.bnStopGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStopGrab.Location = new System.Drawing.Point(117, 46);
            this.bnStopGrab.Name = "bnStopGrab";
            this.bnStopGrab.Size = new System.Drawing.Size(64, 18);
            this.bnStopGrab.TabIndex = 3;
            this.bnStopGrab.Text = "停止采集";
            this.bnStopGrab.UseVisualStyleBackColor = true;
            this.bnStopGrab.Click += new System.EventHandler(this.bnStopGrab_Click);
            // 
            // bnStartGrab
            // 
            this.bnStartGrab.Enabled = false;
            this.bnStartGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStartGrab.Location = new System.Drawing.Point(20, 46);
            this.bnStartGrab.Name = "bnStartGrab";
            this.bnStartGrab.Size = new System.Drawing.Size(72, 18);
            this.bnStartGrab.TabIndex = 2;
            this.bnStartGrab.Text = "开始采集";
            this.bnStartGrab.UseVisualStyleBackColor = true;
            this.bnStartGrab.Click += new System.EventHandler(this.bnStartGrab_Click);
            // 
            // bnTriggerMode
            // 
            this.bnTriggerMode.AutoSize = true;
            this.bnTriggerMode.Enabled = false;
            this.bnTriggerMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnTriggerMode.Location = new System.Drawing.Point(117, 26);
            this.bnTriggerMode.Name = "bnTriggerMode";
            this.bnTriggerMode.Size = new System.Drawing.Size(71, 16);
            this.bnTriggerMode.TabIndex = 1;
            this.bnTriggerMode.TabStop = true;
            this.bnTriggerMode.Text = "触发模式";
            this.bnTriggerMode.UseMnemonic = false;
            this.bnTriggerMode.UseVisualStyleBackColor = true;
            this.bnTriggerMode.CheckedChanged += new System.EventHandler(this.bnTriggerMode_CheckedChanged);
            // 
            // bnContinuesMode
            // 
            this.bnContinuesMode.AutoSize = true;
            this.bnContinuesMode.Enabled = false;
            this.bnContinuesMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnContinuesMode.Location = new System.Drawing.Point(20, 26);
            this.bnContinuesMode.Name = "bnContinuesMode";
            this.bnContinuesMode.Size = new System.Drawing.Size(71, 16);
            this.bnContinuesMode.TabIndex = 0;
            this.bnContinuesMode.TabStop = true;
            this.bnContinuesMode.Text = "连续模式";
            this.bnContinuesMode.UseVisualStyleBackColor = true;
            this.bnContinuesMode.CheckedChanged += new System.EventHandler(this.bnContinuesMode_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bnSaveJpg);
            this.groupBox3.Controls.Add(this.bnSaveBmp);
            this.groupBox3.Location = new System.Drawing.Point(3, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 61);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保存图片";
            // 
            // bnSaveJpg
            // 
            this.bnSaveJpg.Enabled = false;
            this.bnSaveJpg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSaveJpg.Location = new System.Drawing.Point(117, 25);
            this.bnSaveJpg.Name = "bnSaveJpg";
            this.bnSaveJpg.Size = new System.Drawing.Size(70, 23);
            this.bnSaveJpg.TabIndex = 0;
            this.bnSaveJpg.Text = "保存JPG";
            this.bnSaveJpg.UseVisualStyleBackColor = true;
            this.bnSaveJpg.Click += new System.EventHandler(this.bnSaveJpg_Click);
            // 
            // bnSaveBmp
            // 
            this.bnSaveBmp.Enabled = false;
            this.bnSaveBmp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSaveBmp.Location = new System.Drawing.Point(20, 25);
            this.bnSaveBmp.Name = "bnSaveBmp";
            this.bnSaveBmp.Size = new System.Drawing.Size(72, 23);
            this.bnSaveBmp.TabIndex = 0;
            this.bnSaveBmp.Text = "保存BMP";
            this.bnSaveBmp.UseVisualStyleBackColor = true;
            this.bnSaveBmp.Click += new System.EventHandler(this.bnSaveBmp_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deleLVitem);
            this.tabPage2.Controls.Add(this.clearListView);
            this.tabPage2.Controls.Add(this.seleFolder);
            this.tabPage2.Controls.Add(this.dealImg);
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(212, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图像处理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleLVitem
            // 
            this.deleLVitem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleLVitem.Location = new System.Drawing.Point(23, 356);
            this.deleLVitem.Name = "deleLVitem";
            this.deleLVitem.Size = new System.Drawing.Size(173, 52);
            this.deleLVitem.TabIndex = 4;
            this.deleLVitem.Text = "删除ListView选中行";
            this.deleLVitem.UseVisualStyleBackColor = true;
            this.deleLVitem.Click += new System.EventHandler(this.deleLVitem_Click);
            // 
            // clearListView
            // 
            this.clearListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clearListView.Location = new System.Drawing.Point(23, 280);
            this.clearListView.Name = "clearListView";
            this.clearListView.Size = new System.Drawing.Size(173, 52);
            this.clearListView.TabIndex = 3;
            this.clearListView.Text = "清空ListView";
            this.clearListView.UseVisualStyleBackColor = true;
            this.clearListView.Click += new System.EventHandler(this.clearListView_Click);
            // 
            // seleFolder
            // 
            this.seleFolder.Location = new System.Drawing.Point(23, 204);
            this.seleFolder.Name = "seleFolder";
            this.seleFolder.Size = new System.Drawing.Size(173, 52);
            this.seleFolder.TabIndex = 2;
            this.seleFolder.Text = "选择文件夹并处理";
            this.seleFolder.UseVisualStyleBackColor = true;
            this.seleFolder.Click += new System.EventHandler(this.seleFolder_Click);
            // 
            // dealImg
            // 
            this.dealImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dealImg.Location = new System.Drawing.Point(23, 128);
            this.dealImg.Name = "dealImg";
            this.dealImg.Size = new System.Drawing.Size(173, 52);
            this.dealImg.TabIndex = 1;
            this.dealImg.Text = "处理图片";
            this.dealImg.UseVisualStyleBackColor = true;
            this.dealImg.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(4, 19);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(207, 104);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bnStopGrab1);
            this.tabPage3.Controls.Add(this.bnStartGrab1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(199, 78);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "在线测试";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bnStopGrab1
            // 
            this.bnStopGrab1.Enabled = false;
            this.bnStopGrab1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStopGrab1.Location = new System.Drawing.Point(104, 23);
            this.bnStopGrab1.Name = "bnStopGrab1";
            this.bnStopGrab1.Size = new System.Drawing.Size(84, 31);
            this.bnStopGrab1.TabIndex = 4;
            this.bnStopGrab1.Text = "停止采集";
            this.bnStopGrab1.UseVisualStyleBackColor = true;
            this.bnStopGrab1.Click += new System.EventHandler(this.bnStopGrab1_Click);
            // 
            // bnStartGrab1
            // 
            this.bnStartGrab1.Enabled = false;
            this.bnStartGrab1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStartGrab1.Location = new System.Drawing.Point(15, 23);
            this.bnStartGrab1.Name = "bnStartGrab1";
            this.bnStartGrab1.Size = new System.Drawing.Size(83, 31);
            this.bnStartGrab1.TabIndex = 3;
            this.bnStartGrab1.Text = "开始采集";
            this.bnStartGrab1.UseVisualStyleBackColor = true;
            this.bnStartGrab1.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.openImg);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(199, 78);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "离线测试";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // openImg
            // 
            this.openImg.Location = new System.Drawing.Point(15, 15);
            this.openImg.Name = "openImg";
            this.openImg.Size = new System.Drawing.Size(173, 47);
            this.openImg.TabIndex = 6;
            this.openImg.Text = "打开任意图片";
            this.openImg.UseVisualStyleBackColor = true;
            this.openImg.Click += new System.EventHandler(this.openImg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 399);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(3, 11);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(454, 21);
            this.cbDeviceList.TabIndex = 15;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.writeFile3D);
            this.tabPage6.Controls.Add(this.deleLV2select);
            this.tabPage6.Controls.Add(this.clearLV2);
            this.tabPage6.Controls.Add(this.seleFolder3D);
            this.tabPage6.Controls.Add(this.listView2);
            this.tabPage6.Controls.Add(this.deal3DImg);
            this.tabPage6.Controls.Add(this.pictureBoxBW);
            this.tabPage6.Controls.Add(this.pictureBoxTL);
            this.tabPage6.Controls.Add(this.openBWimg);
            this.tabPage6.Controls.Add(this.openTLimg);
            this.tabPage6.Controls.Add(this.communicationSetting1);
            this.tabPage6.Controls.Add(this._button_close_device);
            this.tabPage6.Controls.Add(this._button_acquire_stop);
            this.tabPage6.Controls.Add(this._button_acquire_start);
            this.tabPage6.Controls.Add(this._button_openDevice);
            this.tabPage6.Controls.Add(this.ljxaWindows3D1);
            this.tabPage6.Controls.Add(this._logBox);
            this.tabPage6.Font = new System.Drawing.Font("宋体", 10F);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1254, 771);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "3D处理";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // writeFile3D
            // 
            this.writeFile3D.Font = new System.Drawing.Font("宋体", 14F);
            this.writeFile3D.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.writeFile3D.Location = new System.Drawing.Point(1097, 540);
            this.writeFile3D.Name = "writeFile3D";
            this.writeFile3D.Size = new System.Drawing.Size(154, 159);
            this.writeFile3D.TabIndex = 16;
            this.writeFile3D.Text = "数据链接到文件";
            this.writeFile3D.UseVisualStyleBackColor = true;
            this.writeFile3D.Click += new System.EventHandler(this.writeFile3D_Click);
            // 
            // deleLV2select
            // 
            this.deleLV2select.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deleLV2select.Location = new System.Drawing.Point(987, 81);
            this.deleLV2select.Name = "deleLV2select";
            this.deleLV2select.Size = new System.Drawing.Size(173, 52);
            this.deleLV2select.TabIndex = 25;
            this.deleLV2select.Text = "删除ListView选中行";
            this.deleLV2select.UseVisualStyleBackColor = true;
            this.deleLV2select.Click += new System.EventHandler(this.deleLV2select_Click);
            // 
            // clearLV2
            // 
            this.clearLV2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clearLV2.Location = new System.Drawing.Point(987, 5);
            this.clearLV2.Name = "clearLV2";
            this.clearLV2.Size = new System.Drawing.Size(173, 52);
            this.clearLV2.TabIndex = 24;
            this.clearLV2.Text = "清空ListView";
            this.clearLV2.UseVisualStyleBackColor = true;
            this.clearLV2.Click += new System.EventHandler(this.clearLV2_Click);
            // 
            // seleFolder3D
            // 
            this.seleFolder3D.Location = new System.Drawing.Point(800, 3);
            this.seleFolder3D.Name = "seleFolder3D";
            this.seleFolder3D.Size = new System.Drawing.Size(165, 52);
            this.seleFolder3D.TabIndex = 23;
            this.seleFolder3D.Text = "选择文件夹并处理";
            this.seleFolder3D.UseVisualStyleBackColor = true;
            this.seleFolder3D.Click += new System.EventHandler(this.seleFolder3D_Click);
            // 
            // listView2
            // 
            this.listView2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView2.Location = new System.Drawing.Point(575, 490);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(519, 274);
            this.listView2.TabIndex = 22;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // deal3DImg
            // 
            this.deal3DImg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deal3DImg.Location = new System.Drawing.Point(800, 61);
            this.deal3DImg.Name = "deal3DImg";
            this.deal3DImg.Size = new System.Drawing.Size(165, 72);
            this.deal3DImg.TabIndex = 21;
            this.deal3DImg.Text = "处理3D图片";
            this.deal3DImg.UseVisualStyleBackColor = true;
            this.deal3DImg.Click += new System.EventHandler(this.deal3DImg_Click);
            // 
            // pictureBoxBW
            // 
            this.pictureBoxBW.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxBW.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxBW.Location = new System.Drawing.Point(927, 139);
            this.pictureBoxBW.Name = "pictureBoxBW";
            this.pictureBoxBW.Size = new System.Drawing.Size(321, 345);
            this.pictureBoxBW.TabIndex = 20;
            this.pictureBoxBW.TabStop = false;
            // 
            // pictureBoxTL
            // 
            this.pictureBoxTL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxTL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxTL.Location = new System.Drawing.Point(575, 139);
            this.pictureBoxTL.Name = "pictureBoxTL";
            this.pictureBoxTL.Size = new System.Drawing.Size(321, 345);
            this.pictureBoxTL.TabIndex = 19;
            this.pictureBoxTL.TabStop = false;
            // 
            // openBWimg
            // 
            this.openBWimg.Location = new System.Drawing.Point(616, 81);
            this.openBWimg.Name = "openBWimg";
            this.openBWimg.Size = new System.Drawing.Size(163, 52);
            this.openBWimg.TabIndex = 18;
            this.openBWimg.Text = "打开BW(背面)图片";
            this.openBWimg.UseVisualStyleBackColor = true;
            this.openBWimg.Click += new System.EventHandler(this.openBWimg_Click);
            // 
            // openTLimg
            // 
            this.openTLimg.Location = new System.Drawing.Point(616, 3);
            this.openTLimg.Name = "openTLimg";
            this.openTLimg.Size = new System.Drawing.Size(163, 54);
            this.openTLimg.TabIndex = 17;
            this.openTLimg.Text = "打开TL(正面)图片";
            this.openTLimg.UseVisualStyleBackColor = true;
            this.openTLimg.Click += new System.EventHandler(this.openTLimg_Click);
            // 
            // communicationSetting1
            // 
            this.communicationSetting1.Location = new System.Drawing.Point(231, 21);
            this.communicationSetting1.Name = "communicationSetting1";
            this.communicationSetting1.Size = new System.Drawing.Size(379, 81);
            this.communicationSetting1.TabIndex = 15;
            // 
            // _button_close_device
            // 
            this._button_close_device.Location = new System.Drawing.Point(14, 63);
            this._button_close_device.Name = "_button_close_device";
            this._button_close_device.Size = new System.Drawing.Size(94, 39);
            this._button_close_device.TabIndex = 14;
            this._button_close_device.Text = "关闭设备 Close_Device";
            this._button_close_device.UseVisualStyleBackColor = true;
            this._button_close_device.Click += new System.EventHandler(this._button_close_device_Click);
            // 
            // _button_acquire_stop
            // 
            this._button_acquire_stop.Location = new System.Drawing.Point(131, 61);
            this._button_acquire_stop.Name = "_button_acquire_stop";
            this._button_acquire_stop.Size = new System.Drawing.Size(94, 42);
            this._button_acquire_stop.TabIndex = 13;
            this._button_acquire_stop.Text = "停止获取 Acquire_Stop";
            this._button_acquire_stop.UseVisualStyleBackColor = true;
            this._button_acquire_stop.Click += new System.EventHandler(this._button_acquire_stop_Click);
            // 
            // _button_acquire_start
            // 
            this._button_acquire_start.Location = new System.Drawing.Point(131, 13);
            this._button_acquire_start.Name = "_button_acquire_start";
            this._button_acquire_start.Size = new System.Drawing.Size(94, 42);
            this._button_acquire_start.TabIndex = 12;
            this._button_acquire_start.Text = "开始获取 Acquire_Start";
            this._button_acquire_start.UseVisualStyleBackColor = true;
            this._button_acquire_start.Click += new System.EventHandler(this._button_acquire_start_Click);
            // 
            // _button_openDevice
            // 
            this._button_openDevice.Location = new System.Drawing.Point(14, 12);
            this._button_openDevice.Name = "_button_openDevice";
            this._button_openDevice.Size = new System.Drawing.Size(94, 42);
            this._button_openDevice.TabIndex = 11;
            this._button_openDevice.Text = "打开设备 Open_Device";
            this._button_openDevice.UseVisualStyleBackColor = true;
            this._button_openDevice.Click += new System.EventHandler(this._button_openDevice_Click);
            // 
            // ljxaWindows3D1
            // 
            this.ljxaWindows3D1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ljxaWindows3D1.BinningSize = 4;
            this.ljxaWindows3D1.ColorHighValue = 65535;
            this.ljxaWindows3D1.ColorLowValue = 0;
            this.ljxaWindows3D1.GrayMixPercent = 0.5D;
            this.ljxaWindows3D1.Location = new System.Drawing.Point(16, 118);
            this.ljxaWindows3D1.Name = "ljxaWindows3D1";
            this.ljxaWindows3D1.Resolution_X = 0.0125D;
            this.ljxaWindows3D1.Resolution_Z = 0.0016D;
            this.ljxaWindows3D1.Size = new System.Drawing.Size(553, 488);
            this.ljxaWindows3D1.TabIndex = 10;
            this.ljxaWindows3D1.ZoomScaleX = 1D;
            this.ljxaWindows3D1.ZoomScaleY = 1D;
            this.ljxaWindows3D1.ZoomScaleZ = 1D;
            // 
            // _logBox
            // 
            this._logBox.Location = new System.Drawing.Point(14, 612);
            this._logBox.Multiline = true;
            this._logBox.Name = "_logBox";
            this._logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._logBox.Size = new System.Drawing.Size(555, 152);
            this._logBox.TabIndex = 16;
            // 
            // timerwaitimage
            // 
            this.timerwaitimage.Enabled = true;
            this.timerwaitimage.Tick += new System.EventHandler(this.timerwaitimage_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1375, 810);
            this.Controls.Add(this.tabControl2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "I40Measure";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnOpen;
        private System.Windows.Forms.Button bnEnum;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bnSetParam;
        private System.Windows.Forms.Button bnGetParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFrameRate;
        private System.Windows.Forms.TextBox tbGain;
        private System.Windows.Forms.TextBox tbExposure;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnTriggerExec;
        private System.Windows.Forms.CheckBox cbSoftTrigger;
        private System.Windows.Forms.Button bnStopGrab;
        private System.Windows.Forms.Button bnStartGrab;
        private System.Windows.Forms.RadioButton bnTriggerMode;
        private System.Windows.Forms.RadioButton bnContinuesMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bnSaveJpg;
        private System.Windows.Forms.Button bnSaveBmp;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button dealImg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bnStopGrab1;
        private System.Windows.Forms.Button bnStartGrab1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button openImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.TabPage tabPage6;
        private LjxaDisp.CommunicationSetting communicationSetting1;
        private System.Windows.Forms.Button _button_close_device;
        private System.Windows.Forms.Button _button_acquire_stop;
        private System.Windows.Forms.Button _button_acquire_start;
        private System.Windows.Forms.Button _button_openDevice;
        private LjxaDisp.LjxaWindows3D ljxaWindows3D1;
        private System.Windows.Forms.TextBox _logBox;
        private System.Windows.Forms.Timer timerwaitimage;
        private System.Windows.Forms.Button openBWimg;
        private System.Windows.Forms.Button openTLimg;
        private System.Windows.Forms.PictureBox pictureBoxTL;
        private System.Windows.Forms.PictureBox pictureBoxBW;
        private System.Windows.Forms.Button deal3DImg;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button seleFolder;
        private System.Windows.Forms.Button seleFolder3D;
        private System.Windows.Forms.Button clearListView;
        private System.Windows.Forms.Button deleLVitem;
        private System.Windows.Forms.Button clearLV2;
        private System.Windows.Forms.Button deleLV2select;
        private System.Windows.Forms.Button writeFile;
        private System.Windows.Forms.Button writeFile3D;
        private System.Windows.Forms.TextBox logBox;
    }
}

