using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using WMIWatcher.Engine;
using System.Text.RegularExpressions;


namespace WMIWatcher
{

    public partial class MainForm : Form
    {
        private static Thread watching = null;
        private volatile bool __shouldStop = false;

        string rgx = "^[a-zA-Z]:((\\\\[^\\\\/\\:\\?\"\\<\\>\\|]+)+|\\\\)$";

        public List<string> clients;
        private string user;
        private string password;
        private int impLevel;
        private int authLevel;

        private bool is_localhost;

        private IPadresses ipListForm;
        private Forms.SecuritySettingsForm secsettings;

        public void setCredentials(string login, string password, int impLevel, int authLevel)
        {
            this.user = login;
            this.password = password;
            this.impLevel = impLevel;
            this.authLevel = authLevel;
        }

        public MainForm()
        {
            InitializeComponent();
            ipListForm = new IPadresses();
            secsettings = new Forms.SecuritySettingsForm();
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            is_localhost = is_local.Checked;
            if (l_events.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран тип данных", "Ошибка");
                return;
            }


            if (!is_localhost)
            {
                if (user == null)
                {
                    MessageBox.Show("Необходимо ввести учетные данные пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (clients == null)
                {
                    MessageBox.Show("Не выбран ни один клиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Handler.setUser(user, password, impLevel, authLevel);
            }
            else { clients = new List<string>() { "localhost" }; }

            Output.Text = "";
            string result = null;

            foreach (string serverName in clients)
            {
                switch (l_events.SelectedIndex)
                {
                    case 0://files
                        if (Path.Text == "")
                        {
                            MessageBox.Show("Введите путь", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                        if (!Regex.IsMatch(Path.Text, rgx))
                        {
                            MessageBox.Show("Неправильно введен путь\nПример: C:\\Users\\admin", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        char drive = Path.Text[0];
                        string path = Path.Text.Substring(2);
                        if (path == "\\")
                            path += '.';
                        string extension = Extension.Text.Replace(".", "");
                        WMI_FileInfo fi = new WMI_FileInfo(extension, drive, path);
                        result = Handler.collect(fi, serverName);
                        break;

                    case 1://processes
                        result = Handler.collect(new WMI_Process(), serverName);
                        break;

                    case 2://services
                        result = Handler.collect(new WMI_Services(serviceType.SelectedIndex),serverName);
                        break;
                    case 3://network
                        result = Handler.collect(new WMI_NetworkInfo(), serverName);
                        break;
                    case 4://devices
                        result = Handler.collect(new WMI_Device(), serverName);
                        break;
                    case 5://logons
                        if ((int)range.Value <= 0)
                        {
                            MessageBox.Show("Введите корректный диапазон времени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        result = Handler.collect(new WMI_LogonInfo((int)range.Value), serverName);
                        break;
                    case 6://drives
                        result = Handler.collect(new WMI_DriveInfo(), serverName);
                        break;
                }
                TreeNode[] node = treeView1.Nodes.Find(serverName,false);
                MessageBox.Show(node.ToString());
                Output.Text = "\r\n=====================================";
                if (result != null)
                {
                    Output.Text = result + Output.Text+"\r\nЗапрос успешно завершен\r\n";
                }
                else
                {
                    Output.Text += "\r\nЗапрос не выдал результатов\r\n";
                    continue;
                }
            }
        }





        private void startWatch_Click(object sender, EventArgs e)
        {
            if (clients == null)
            {
                MessageBox.Show("В списке клиентов нет ни одного IP-адреса!");
            }
            ManagementEventWatcher watcher = null;
            Output.Text = "";
            string serverName = "localhost";
            if (!serverName.ToLower().Equals("localhost") && !serverName.Equals("."))
                Handler.setUser(user, password, impLevel, authLevel);
            int evt = listBox2.SelectedIndex;
            int type = eventType.SelectedIndex;
            switch (evt)
            {
                case 0://files
                    string disk = rtdisk.Text;
                    string path = rtpath.Text;
                    string ext = rtext.Text;
                    watcher = Handler.ts_files(serverName, ext, disk, path, type);
                    break;
                case 1://processes
                    watcher = Handler.ts_processes(serverName, type);
                    break;
                case 2://services
                    watcher = Handler.ts_services(serverName, type);
                    break;
                case 3://logons
                    watcher = Handler.ts_logons(serverName);
                    break;
                case 4://drives
                    watcher = Handler.ts_drives(serverName, type);
                    break;
            }
            watching = new Thread(() => watch(watcher, Output, evt, type));
            watching.Start();
        }

        private void stopWatch_Click(object sender, EventArgs e)
        {
            if (watching != null)
            {
                __shouldStop = true;
                while (watching.IsAlive)
                    Output.Text += "...\r\n";

            }
            watching = null;
            __shouldStop = false;
            Output.Text += "Слежение окончено\r\n";

        }


        public void watch(Object rwatcher, object routput, object evt, object rtype)
        {
            ManagementEventWatcher watcher = (ManagementEventWatcher)rwatcher;
            TextBox Output = (TextBox)routput;
            SetText(Output, "Слежение начато\r\n");
            switch ((int)evt)
            {
                case 0:
                    watcher.EventArrived += new EventArrivedEventHandler((object sender, EventArrivedEventArgs e) => HandleFMEvent(sender, e, (int)rtype, Output));
                    break;
                case 1:
                    watcher.EventArrived += new EventArrivedEventHandler((object sender, EventArrivedEventArgs e) => HandlePEvent(sender, e, (int)rtype, Output));
                    break;
                case 2:
                    watcher.EventArrived += new EventArrivedEventHandler((object sender, EventArrivedEventArgs e) => HandleSEvent(sender, e, (int)rtype, Output));
                    break;
                case 3:
                    watcher.EventArrived += new EventArrivedEventHandler((object sender, EventArrivedEventArgs e) => HandleLEvent(sender, e, Output));
                    break;
                case 4:
                    watcher.EventArrived += new EventArrivedEventHandler((object sender, EventArrivedEventArgs e) => HandleDEvent(sender, e, (int)rtype, Output));
                    break;

            }
            watcher.Start();
            while (!__shouldStop)
            {
            }
            watcher.Stop();
        }





        private void HandleFMEvent(object sender, EventArrivedEventArgs e, int evtype, TextBox Output)
        {
            string stub = "";
            switch (evtype)
            {
                case 0:
                    stub = "создан";
                    break;
                case 1:
                    stub = "изменен";
                    break;
                case 2:
                    stub = "удален";
                    break;
            }
            ManagementBaseObject obj = e.NewEvent;
            string name = (string)((ManagementBaseObject)obj["TargetInstance"])["Name"];
            string time = (string)((ManagementBaseObject)obj["TargetInstance"])["LastModified"];
            time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            SetText(Output, string.Format("[{0}] Следующий файл был {1}: {2}\r\n", time, stub, name));
        }

        private void HandlePEvent(object sender, EventArrivedEventArgs e, int evtype, TextBox Output)
        {
            string stub = "";
            switch (evtype)
            {
                case 0:
                    stub = "запущен";
                    break;
                case 1:
                    stub = "изменен";
                    break;
                case 2:
                    stub = "завершен";
                    break;
            }
            ManagementBaseObject obj = e.NewEvent;
            string name = (string)((ManagementBaseObject)obj["TargetInstance"])["Name"];
            string time = (string)((ManagementBaseObject)obj["TargetInstance"])["CreationDate"];
            if (time == null)
                time = DateTime.Now.ToString();
            else
                time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            SetText(Output, string.Format("[{0}] Следующий процесс был {1}: {2}\r\n", time, stub, name));
        }

        private void HandleSEvent(object sender, EventArrivedEventArgs e, int evtype, TextBox Output)
        {
            string stub = "";
            switch (evtype)
            {
                case 0:
                    stub = "создана";
                    break;

                case 2:
                    stub = "удалена";
                    break;
            }
            ManagementBaseObject obj = e.NewEvent;
            string name = (string)((ManagementBaseObject)obj["TargetInstance"])["Name"];
            string time = System.DateTime.Now.ToString();
            bool started = (bool)((ManagementBaseObject)obj["TargetInstance"])["Started"];
            if (evtype == 1)
                if (started)
                    stub = "запущена";
                else
                    stub = "приостановлена";
            SetText(Output, string.Format("[{0}] Следующая служба была {1}: {2}\r\n", time, stub, name));
        }

        private void HandleLEvent(object sender, EventArrivedEventArgs e, TextBox Output)
        {
            string time, raw, user;
            ManagementBaseObject obj = e.NewEvent;
            time = (string)((ManagementBaseObject)obj["TargetInstance"])["TimeWritten"];
            time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            raw = (string)((ManagementBaseObject)obj["TargetInstance"])["Message"];
            user = raw.Split('\r')[12].Replace("Имя учетной записи:", "").Trim();
            SetText(Output, string.Format("[{0}] Неудачная попытка входа. Пользователь: {1}\r\n", time, user));
        }

        private void HandleDEvent(object sender, EventArrivedEventArgs e, int evtype, TextBox Output)
        {
            string stub = "";
            switch (evtype)
            {
                case 0:
                    stub = "Обнаружено новое запоминающее устройство";
                    break;
                case 1:
                    stub = "Состояние устройства изменено";
                    break;
                case 2:
                    stub = "Устройство извлечено";
                    break;
            }
            string time, name, interfaceType, mediaType, sn;
            ManagementBaseObject obj = e.NewEvent;
            time = DateTime.Now.ToString(); ;
            name = (string)((ManagementBaseObject)obj["TargetInstance"])["Caption"];
            interfaceType = (string)((ManagementBaseObject)obj["TargetInstance"])["InterfaceType"];
            mediaType = (string)((ManagementBaseObject)obj["TargetInstance"])["MediaType"];
            sn = (string)((ManagementBaseObject)obj["TargetInstance"])["SerialNumber"];
            SetText(Output, string.Format("[{0}] {1}\r\nИмя: {2}\nИнтерфейс: {3}\r\nТип медиа: {4}\r\n"
            + "Серийный номер: {5}\r\n", time, stub, name, interfaceType, mediaType, sn));
        }


        private void createCons_Click(object sender, EventArgs e)
        {
            Output.Text = "";
            string serverName = "localhost";
            if (!serverName.ToLower().Equals("localhost") && !serverName.Equals("."))
                Handler.setUser(user, password, impLevel, authLevel);
            int evt = ps_ev.SelectedIndex;
            int evtype = ps_ev_type.SelectedIndex;
            string log = logfile.Text;
            int count = consumers.Items.Count + 1;
            Output.Text += "Выполняется подписка...\r\n";
            string consName = "";
            switch (evt)
            {
                case 0://files
                    string disk = ps_disk.Text;
                    string path = ps_path.Text;
                    string ext = ps_ext.Text;
                    consName = Handler.ps_files(serverName, ext, disk, path, evtype, log, count);
                    break;
                case 1://processes
                    consName = Handler.ps_processes(serverName, evtype, log, count);
                    break;
                case 2://services
                    consName = Handler.ps_services(serverName, evtype, log, count);
                    break;
                case 3://logons
                    consName = Handler.ps_logons(serverName, log, count);
                    break;
                case 4://drives
                    consName = Handler.ps_drives(serverName, evtype, log, count);
                    break;
            }
            consumers.Items.Add(consName);
            Output.Text += "Подписка на событие произведена успешно\r\n";
        }

        private void delCons_Click(object sender, EventArgs e)
        {
            Output.Text += "Удаление выбранного подписчика...\r\n";
            string consumer = consumers.SelectedItem.ToString();
            string serverName = "localhost";
            string filter = consumer.Replace("Consumer", "Filter");
            Handler.delete_consumer(filter, consumer, serverName);
            consumers.Items.RemoveAt(consumers.SelectedIndex);
            consumers.Update();
            Output.Text += "Удаление завершено\r\n";

        }

        private void SetText(TextBox txt, string text)
        {
            if (txt.InvokeRequired)
            {
                Invoke((MethodInvoker)(() => txt.Text += text));
            }
            else
            {
                txt.Text += text;
            }
        }

        private void BtnShowIpList_Click(object sender, EventArgs e)
        {
            ipListForm.Owner = this;
            ipListForm.ShowDialog();
            listView1.Clear();
            foreach (string target in clients)
            {
                TreeNode node = new TreeNode(target);
                node.Nodes.Add("Общее");
                node.Nodes.Add("Сеть");
                node.Nodes.Add("Процессы");
                treeView1.Nodes.Add(node);
                
            }
        }

        private void SftyStngsBtn_Click(object sender, EventArgs e)
        {
            secsettings.Owner = this;
            secsettings.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent == null)
            MessageBox.Show(treeView1.SelectedNode.Text);
        }
    }
}
