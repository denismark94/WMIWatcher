namespace WMIWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.range = new System.Windows.Forms.NumericUpDown();
            this.serviceType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.genButton = new System.Windows.Forms.Button();
            this.Extension = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.l_events = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.stopWatch = new System.Windows.Forms.Button();
            this.startWatch = new System.Windows.Forms.Button();
            this.rtext = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rtpath = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rtdisk = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.eventType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.delCons = new System.Windows.Forms.Button();
            this.createCons = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.consumers = new System.Windows.Forms.ComboBox();
            this.ps_ext = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ps_path = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ps_disk = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.logfile = new System.Windows.Forms.TextBox();
            this.ps_ev_type = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ps_ev = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnShowIpList = new System.Windows.Forms.Button();
            this.SftyStngsBtn = new System.Windows.Forms.Button();
            this.is_local = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.range)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 222);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.range);
            this.tabPage1.Controls.Add(this.serviceType);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.genButton);
            this.tabPage1.Controls.Add(this.Extension);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.Path);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.l_events);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сбор информации";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(194, 158);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Диапазон(часы)";
            // 
            // range
            // 
            this.range.Location = new System.Drawing.Point(289, 156);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(57, 20);
            this.range.TabIndex = 17;
            // 
            // serviceType
            // 
            this.serviceType.FormattingEnabled = true;
            this.serviceType.Items.AddRange(new object[] {
            "Все",
            "Активные",
            "Приостановленные"});
            this.serviceType.Location = new System.Drawing.Point(192, 129);
            this.serviceType.Name = "serviceType";
            this.serviceType.Size = new System.Drawing.Size(154, 21);
            this.serviceType.TabIndex = 18;
            this.serviceType.Text = "Все";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Тип служб";
            // 
            // genButton
            // 
            this.genButton.Location = new System.Drawing.Point(9, 147);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(154, 34);
            this.genButton.TabIndex = 14;
            this.genButton.Text = "Вывести информацию";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // Extension
            // 
            this.Extension.Location = new System.Drawing.Point(192, 91);
            this.Extension.Name = "Extension";
            this.Extension.Size = new System.Drawing.Size(154, 20);
            this.Extension.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Расширение";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(192, 52);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(154, 20);
            this.Path.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Путь к отслеживаемой папке";
            // 
            // l_events
            // 
            this.l_events.FormattingEnabled = true;
            this.l_events.Items.AddRange(new object[] {
            "Файлы",
            "Процессы",
            "Службы",
            "Сетевая конфигурация",
            "Конфигурация компьютера",
            "Попытки авторизации",
            "Запоминающие устройства"});
            this.l_events.Location = new System.Drawing.Point(9, 19);
            this.l_events.Name = "l_events";
            this.l_events.Size = new System.Drawing.Size(154, 121);
            this.l_events.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тип данных";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stopWatch);
            this.tabPage2.Controls.Add(this.startWatch);
            this.tabPage2.Controls.Add(this.rtext);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.rtpath);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.rtdisk);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.eventType);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(364, 196);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Слежение в реальном времени";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stopWatch
            // 
            this.stopWatch.Location = new System.Drawing.Point(175, 141);
            this.stopWatch.Name = "stopWatch";
            this.stopWatch.Size = new System.Drawing.Size(141, 34);
            this.stopWatch.TabIndex = 21;
            this.stopWatch.Text = "Остановить слежение";
            this.stopWatch.UseVisualStyleBackColor = true;
            this.stopWatch.Click += new System.EventHandler(this.stopWatch_Click);
            // 
            // startWatch
            // 
            this.startWatch.Location = new System.Drawing.Point(9, 141);
            this.startWatch.Name = "startWatch";
            this.startWatch.Size = new System.Drawing.Size(141, 34);
            this.startWatch.TabIndex = 20;
            this.startWatch.Text = "Начать слежение";
            this.startWatch.UseVisualStyleBackColor = true;
            this.startWatch.Click += new System.EventHandler(this.startWatch_Click);
            // 
            // rtext
            // 
            this.rtext.Location = new System.Drawing.Point(175, 113);
            this.rtext.Name = "rtext";
            this.rtext.Size = new System.Drawing.Size(154, 20);
            this.rtext.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(172, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Расширение";
            // 
            // rtpath
            // 
            this.rtpath.Location = new System.Drawing.Point(175, 58);
            this.rtpath.Name = "rtpath";
            this.rtpath.Size = new System.Drawing.Size(154, 20);
            this.rtpath.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(172, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Путь к отслеживаемой папке";
            // 
            // rtdisk
            // 
            this.rtdisk.Location = new System.Drawing.Point(175, 19);
            this.rtdisk.Name = "rtdisk";
            this.rtdisk.Size = new System.Drawing.Size(154, 20);
            this.rtdisk.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(172, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Логический диск";
            // 
            // eventType
            // 
            this.eventType.FormattingEnabled = true;
            this.eventType.Items.AddRange(new object[] {
            "Создание",
            "Изменение",
            "Удаление"});
            this.eventType.Location = new System.Drawing.Point(9, 113);
            this.eventType.Name = "eventType";
            this.eventType.Size = new System.Drawing.Size(121, 21);
            this.eventType.TabIndex = 3;
            this.eventType.Text = "Создание";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Тип события";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Изменение файлов",
            "Изменение процессов",
            "Изменение служб",
            "Попытки входа в систему",
            "Изменение приводов"});
            this.listBox2.Location = new System.Drawing.Point(9, 19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(141, 69);
            this.listBox2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Событие";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.delCons);
            this.tabPage3.Controls.Add(this.createCons);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.consumers);
            this.tabPage3.Controls.Add(this.ps_ext);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.ps_path);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.ps_disk);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.logfile);
            this.tabPage3.Controls.Add(this.ps_ev_type);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.ps_ev);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(364, 196);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Логирование";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // delCons
            // 
            this.delCons.Location = new System.Drawing.Point(169, 167);
            this.delCons.Name = "delCons";
            this.delCons.Size = new System.Drawing.Size(154, 23);
            this.delCons.TabIndex = 23;
            this.delCons.Text = "Удалить потребителя";
            this.delCons.UseVisualStyleBackColor = true;
            this.delCons.Click += new System.EventHandler(this.delCons_Click);
            // 
            // createCons
            // 
            this.createCons.Location = new System.Drawing.Point(11, 167);
            this.createCons.Name = "createCons";
            this.createCons.Size = new System.Drawing.Size(141, 23);
            this.createCons.TabIndex = 22;
            this.createCons.Text = "Начать слежение";
            this.createCons.UseVisualStyleBackColor = true;
            this.createCons.Click += new System.EventHandler(this.createCons_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "Созданные потребители";
            // 
            // consumers
            // 
            this.consumers.FormattingEnabled = true;
            this.consumers.Location = new System.Drawing.Point(169, 136);
            this.consumers.Name = "consumers";
            this.consumers.Size = new System.Drawing.Size(154, 21);
            this.consumers.TabIndex = 20;
            // 
            // ps_ext
            // 
            this.ps_ext.Location = new System.Drawing.Point(169, 97);
            this.ps_ext.Name = "ps_ext";
            this.ps_ext.Size = new System.Drawing.Size(154, 20);
            this.ps_ext.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(166, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Расширение";
            // 
            // ps_path
            // 
            this.ps_path.Location = new System.Drawing.Point(169, 58);
            this.ps_path.Name = "ps_path";
            this.ps_path.Size = new System.Drawing.Size(154, 20);
            this.ps_path.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(166, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Путь к отслеживаемой папке";
            // 
            // ps_disk
            // 
            this.ps_disk.Location = new System.Drawing.Point(169, 19);
            this.ps_disk.Name = "ps_disk";
            this.ps_disk.Size = new System.Drawing.Size(154, 20);
            this.ps_disk.TabIndex = 15;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(166, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "Логический диск";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Журнал";
            // 
            // logfile
            // 
            this.logfile.Location = new System.Drawing.Point(13, 137);
            this.logfile.Name = "logfile";
            this.logfile.Size = new System.Drawing.Size(139, 20);
            this.logfile.TabIndex = 6;
            // 
            // ps_ev_type
            // 
            this.ps_ev_type.FormattingEnabled = true;
            this.ps_ev_type.Items.AddRange(new object[] {
            "Создание",
            "Изменение",
            "Удаление"});
            this.ps_ev_type.Location = new System.Drawing.Point(11, 97);
            this.ps_ev_type.Name = "ps_ev_type";
            this.ps_ev_type.Size = new System.Drawing.Size(141, 21);
            this.ps_ev_type.TabIndex = 5;
            this.ps_ev_type.Text = "Создание";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Тип события";
            // 
            // ps_ev
            // 
            this.ps_ev.FormattingEnabled = true;
            this.ps_ev.Items.AddRange(new object[] {
            "Изменение файлов",
            "Изменение процессов",
            "Изменение служб",
            "Попытки входа в систему",
            "Изменение приводов"});
            this.ps_ev.Location = new System.Drawing.Point(9, 19);
            this.ps_ev.Name = "ps_ev";
            this.ps_ev.Size = new System.Drawing.Size(141, 56);
            this.ps_ev.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Событие";
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(603, 25);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(110, 244);
            this.Output.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Вывод";
            // 
            // BtnShowIpList
            // 
            this.BtnShowIpList.Location = new System.Drawing.Point(5, 252);
            this.BtnShowIpList.Name = "BtnShowIpList";
            this.BtnShowIpList.Size = new System.Drawing.Size(167, 36);
            this.BtnShowIpList.TabIndex = 17;
            this.BtnShowIpList.Text = "Клиенты";
            this.BtnShowIpList.UseVisualStyleBackColor = true;
            this.BtnShowIpList.Click += new System.EventHandler(this.BtnShowIpList_Click);
            // 
            // SftyStngsBtn
            // 
            this.SftyStngsBtn.Location = new System.Drawing.Point(201, 252);
            this.SftyStngsBtn.Name = "SftyStngsBtn";
            this.SftyStngsBtn.Size = new System.Drawing.Size(167, 36);
            this.SftyStngsBtn.TabIndex = 18;
            this.SftyStngsBtn.Text = "Настройки безопасности";
            this.SftyStngsBtn.UseVisualStyleBackColor = true;
            this.SftyStngsBtn.Click += new System.EventHandler(this.SftyStngsBtn_Click);
            // 
            // is_local
            // 
            this.is_local.AutoSize = true;
            this.is_local.Location = new System.Drawing.Point(5, 229);
            this.is_local.Name = "is_local";
            this.is_local.Size = new System.Drawing.Size(138, 17);
            this.is_local.TabIndex = 19;
            this.is_local.Text = "Локальный комьютер";
            this.is_local.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(402, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(164, 229);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(520, 46);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 21;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(725, 292);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.is_local);
            this.Controls.Add(this.SftyStngsBtn);
            this.Controls.Add(this.BtnShowIpList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(741, 330);
            this.MinimumSize = new System.Drawing.Size(741, 330);
            this.Name = "MainForm";
            this.Text = "WMI Watcher";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.range)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox l_events;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button genButton;
        private System.Windows.Forms.TextBox Extension;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox serviceType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ComboBox eventType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox rtext;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox rtpath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox rtdisk;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox ps_ext;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox ps_path;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox ps_disk;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox logfile;
        private System.Windows.Forms.ComboBox ps_ev_type;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox ps_ev;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button stopWatch;
        private System.Windows.Forms.Button startWatch;
        private System.Windows.Forms.Button delCons;
        private System.Windows.Forms.Button createCons;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox consumers;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown range;
        private System.Windows.Forms.Button BtnShowIpList;
        private System.Windows.Forms.Button SftyStngsBtn;
        private System.Windows.Forms.CheckBox is_local;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

