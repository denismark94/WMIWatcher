using System;
using System.Data;
using System.IO;
using System.Management;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using WMIWatcher.Engine;

namespace WMIWatcher.Forms
{
    public partial class Main : Form
    {

        delegate void SetTextCallback(string[] value);

        int ALL = 0;
        int ACTIVE = 1;
        int PAUSED = 2;

        private string login;
        private SecureString password;
        private int impLevel;
        private int authLevel;

        private int service_type;
        private int info_type;
        private int event_type;

        public string ext;
        public string path;
        public char drive;

        public int control;
        public string domainName;
        public string dcUser;
        public string dcPassword;
        public bool is_domain;
        public int time_range;

        Thread[] watchers;
        WMI_class wmicl;
        public TreeNode current_node;
        string current_target;
        bool is_interrupted = false;

        FileSearchDialog fsd;
        ScriptSelDialog ssd;
        LogFileSelDialog lfsd;
        public string scipt;
        public string logfile;

        public Main()
        {
            InitializeComponent();
            targets.ContextMenuStrip = select_context;
            fsd = new FileSearchDialog();
            fsd.Owner = this;
            ssd = new ScriptSelDialog();
            ssd.Owner = this;
            lfsd = new LogFileSelDialog();
            lfsd.Owner = this;
            deserialize();
            consumers.ContextMenuStrip = select_consumers;
        }

        private void sec_settings_click(object sender, EventArgs e)
        {
            SecuritySettingsForm secset = new SecuritySettingsForm();
            secset.Owner = this;
            secset.ShowDialog();
        }

        private bool check()
        {
            if (targets.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну цель", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (login == null)
            {
                MessageBox.Show("Необходимо ввести учетные данные пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void setCredentials(string login, SecureString password, int impLevel, int authLevel)
        {
            this.login = login;
            this.password = password;
            this.impLevel = impLevel;
            this.authLevel = authLevel;
        }

        private void add_target_Click(object sender, EventArgs e)
        {
            AddIP addipform = new AddIP();
            addipform.ShowDialog();
            if (addipform.ips.Count != 0)
                foreach (string target in addipform.ips)
                    targets.Items.Add(target);
        }

        private void del_selected_Click(object sender, EventArgs e)
        {
            for (int i = targets.Items.Count - 1; i >= 0; i--)
                if (targets.GetItemChecked(i))
                    targets.Items.RemoveAt(i);
        }

        private void select_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < targets.Items.Count; i++)
                targets.SetItemChecked(i, true);
        }

        private void unselect_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < targets.Items.Count; i++)
                targets.SetItemChecked(i, false);
        }

        private void get_info()
        {
            tabControl1.SelectedIndex = 0;
            if (!check())
                return;
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            WMI_class result_info = null;
            switch (info_type)
            {
                case 0:
                    result_info = new WMI_FileInfo(ext, drive, path);
                    break;
                case 1:
                    result_info = new WMI_Process();
                    break;
                case 2:
                    result_info = new WMI_Services(service_type);
                    break;
                case 3:
                    result_info = new WMI_LogonInfo(time_range);
                    break;
                case 4:
                    result_info = new WMI_NetworkInfo();
                    break;
                case 5:
                    result_info = new WMI_Device();
                    break;
                case 6:
                    result_info = new WMI_DriveInfo();
                    break;
                case 7:
                    result_info = new WMI_Startup();
                    break;
                case 8:
                    result_info = new WMI_Apps();
                    break;
            }
            output.Nodes.Clear();
            TreeNode result;
            for (int i = 0; i < tts.Length; i++)
            {
                TreeNode node = new TreeNode(tts[i]);
                Handler.setUser(login, password, impLevel, authLevel);
                result = Handler.collect(result_info, tts[i]);
                if (result == null)
                    node.Nodes.Add("Ошибка");
                else
                {
                    foreach (TreeNode n in result.Nodes)
                    {
                        switch (info_type)
                        {
                            case 0:
                                n.ContextMenuStrip = file_context;
                                break;
                            case 1:
                                n.ContextMenuStrip = process_context;
                                break;
                        }
                    }
                    node.Nodes.Add(result);
                }
                node.ContextMenuStrip = target_settings;
                output.Nodes.Add(node);
            }
        }

        private void get_info_storages_click(object sender, EventArgs e)
        {
            info_type = 6;
            get_info();
        }

        private void get_info_network_adapters_click(object sender, EventArgs e)
        {
            info_type = 4;
            get_info();
        }

        private void get_info_devices_click(object sender, EventArgs e)
        {
            info_type = 5;
            get_info();
        }

        private void get_info_autorun_click(object sender, EventArgs e)
        {
            info_type = 7;
            get_info();
        }

        private void get_info_apps_click(object sender, EventArgs e)
        {
            info_type = 8;
            get_info();
        }

        private void get_info_files_click(object sender, EventArgs e)
        {
            fsd.ShowDialog();
            info_type = 0;
            get_info();
        }

        private void get_info_processes_click(object sender, EventArgs e)
        {
            info_type = 1;
            get_info();
        }

        private void get_info_services_all_click(object sender, EventArgs e)
        {
            info_type = 2;
            service_type = ALL;
            get_info();
        }

        private void get_info_services_active_click(object sender, EventArgs e)
        {
            info_type = 2;
            service_type = ACTIVE;
            get_info();
        }

        private void get_info_services_paused_click(object sender, EventArgs e)
        {
            info_type = 2;
            service_type = PAUSED;
            get_info();
        }

        private void get_info_logons_click(object sender, EventArgs e)
        {
            TimeRangeForm time = new TimeRangeForm();
            time.ShowDialog();
            time_range = time.time_range;
            info_type = 3;
            get_info();
        }

        private void watch_files_cr_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 0;
            configure_watchers();
        }

        private void watch_files_mod_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 1;
            configure_watchers();
        }

        private void watch_files_del_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 2;
            configure_watchers();
        }

        private void watch_processes_cr_click(object sender, EventArgs e)
        {
            info_type = 1;
            event_type = 0;
            configure_watchers();
        }

        private void watch_processes_del_click(object sender, EventArgs e)
        {
            info_type = 1;
            event_type = 2;
            configure_watchers();
        }

        private void watch_services_mod_click(object sender, EventArgs e)
        {
            info_type = 2;
            event_type = 1;
            configure_watchers();
        }

        private void watch_drives_cr_click(object sender, EventArgs e)
        {
            info_type = 6;
            event_type = 0;
            configure_watchers();
        }

        private void watch_drives_del_click(object sender, EventArgs e)
        {
            info_type = 6;
            event_type = 2;
            configure_watchers();
        }

        private void watch_logons_click(object sender, EventArgs e)
        {
            info_type = 3;
            event_type = 0;
            configure_watchers();
        }

        private void configure_watchers()
        {
            tabControl1.SelectedIndex = 1;
            if (!check())
                return;
            events.Rows.Clear();
            if (watchers != null)
                foreach (Thread watcher in watchers)
                    watcher.Abort();
            is_interrupted = false;
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            Handler.setUser(login, password, impLevel, authLevel);
            watchers = new Thread[tts.Length];
            switch (info_type)
            {
                case 0:
                    fsd.ShowDialog();
                    if (path == null)
                        return;
                    wmicl = new WMI_FileInfo(ext, drive, path);
                    break;
                case 1:
                    wmicl = new WMI_Process();
                    break;
                case 2:
                    wmicl = new WMI_Services(0);
                    break;
                case 3:
                    wmicl = new WMI_LogonInfo(0);
                    break;
                case 6:
                    wmicl = new WMI_DriveInfo();
                    break;
            }
            wmicl.event_index = event_type;
            for (int i = 0; i < tts.Length; i++)
            {
                watchers[i] = new Thread(watch);
                watchers[i].Start(tts[i]);
            }
        }

        protected void watch(Object target)
        {
            ManagementEventWatcher watcher = Handler.configure_watcher((string)target, wmicl, event_type);
            while (!is_interrupted)
            {
                ManagementBaseObject obj = watcher.WaitForNextEvent();
                string[] evt = wmicl.handle_event(obj);
                if (evt != null)
                {
                    evt[0] = (string)target;
                    SetText(evt);
                }
            }

        }

        protected void SetText(string[] value)
        {
            if (events.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { value });
            }
            else
                events.Rows.Add(value);
        }

        private void stop_watching(object sender, EventArgs e)
        {
            is_interrupted = true;
            Thread.Sleep(10);
            for (int i = 0; i < watchers.Length; i++)
                watchers[i].Abort();
            is_interrupted = false;
        }

        private void log_files_cr_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 0;
            start_logging();
        }

        private void log_files_mod_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 1;
            start_logging();
        }

        private void log_files_del_click(object sender, EventArgs e)
        {
            info_type = 0;
            event_type = 2;
            start_logging();
        }

        private void log_processes_cr_click(object sender, EventArgs e)
        {
            info_type = 1;
            event_type = 0;
            start_logging();
        }

        private void log_processes_del_click(object sender, EventArgs e)
        {
            info_type = 1;
            event_type = 2;
            start_logging();
        }

        private void log_services_mod_click(object sender, EventArgs e)
        {
            info_type = 2;
            event_type = 1;
            start_logging();
        }

        private void log_drives_cr_click(object sender, EventArgs e)
        {
            info_type = 6;
            event_type = 0;
            start_logging();
        }

        private void log_drives_del_click(object sender, EventArgs e)
        {
            info_type = 6;
            event_type = 2;
            start_logging();
        }

        private void start_logging()
        {
            tabControl1.SelectedIndex = 2;
            if (!check())
                return;
            lfsd.ShowDialog();
            if (logfile == null)
                return;
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            Handler.setUser(login, password, impLevel, authLevel);

            switch (info_type)
            {
                case 0:
                    fsd.ShowDialog();
                    if (path == null)
                        return;
                    wmicl = new WMI_FileInfo(ext, drive, path);
                    break;
                case 1:
                    wmicl = new WMI_Process();
                    break;
                case 2:
                    wmicl = new WMI_Services(0);
                    break;
                case 6:
                    wmicl = new WMI_DriveInfo();
                    break;
            }
            wmicl.event_index = event_type;
            foreach (string target in tts)
                consumers.Rows.Add(Handler.create_consumer(target, wmicl, logfile, event_type));
            serialize();
        }

        private void remove_all_consumers(object sender, EventArgs e)
        {
            if (login == null)
            {
                MessageBox.Show("Необходимо ввести учетные данные пользователя", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string cons_name = "";
            Handler.setUser(login, password, impLevel, authLevel);
            foreach (DataGridViewRow consumer in consumers.Rows)
            {
                cons_name = consumer.Cells[1].Value.ToString() + ":" + consumer.Cells[2].Value.ToString().Replace("Consumer", "");
                Handler.delete_consumer(consumer.Cells[0].Value.ToString(), cons_name);
            }
            consumers.Rows.Clear();
            serialize();
        }

        private void terminate_process(object sender, EventArgs e)
        {
            string id = current_node.Nodes[0].Text.Replace("ID: ", "");
            string name = current_node.Text;
            Handler.setUser(login, password, impLevel, authLevel);
            Handler.terminate_process(current_target, name, id);
            get_info_processes_click(sender, e);

        }

        private void shutdown(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            if (!check())
                return;
            if (impLevel < 2 || authLevel < 4)
            {
                MessageBox.Show("Для управления целью необходимы следующие права:\r\nУровень олицетворения: Не ниже \"Олицетворение\"" +
                    "\r\nУровень аутентификации: Не ниже \"Целостность пакетов\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Handler.setUser(login, password, impLevel, authLevel);
            Shutdown_Form shtdwn = new Shutdown_Form();
            shtdwn.Owner = this;
            shtdwn.ShowDialog();
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            output.Nodes.Clear();
            string respond;
            TreeNode tt;
            foreach (string target in tts)
            {
                respond = "Результат: ";
                object res = Handler.exec_by_object(target, "Win32_OperatingSystem", "Win32Shutdown", new object[] { control });
                if (res == null)
                    respond += "Цель недоступна";
                else
                {
                    try
                    {
                        switch ((UInt32)res)
                        {
                            case 0:
                                respond += "Успешно";
                                break;
                            case 0x4a7:
                                respond += "На целевом компьютере остались активные пользователи";
                                break;
                            case 0x4F7:
                                respond += "Цель заблокирована";
                                break;
                            default:
                                respond += res;
                                break;
                        }
                    }
                    catch (InvalidCastException)
                    {
                        respond += "Выход из системы уже произведен";
                    }
                    tt = new TreeNode(target);
                    tt.Nodes.Add(respond);
                    output.Nodes.Add(tt);
                }
            }
        }

        private void execute(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            if (!check())
                return;
            if (impLevel < 2 || authLevel < 4)
            {
                MessageBox.Show("Для управления целью необходимы следующие права:\r\nУровень олицетворения: Не ниже \"Олицетворение\"" +
                    "\r\nУровень аутентификации: Не ниже \"Целостность пакетов\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Handler.setUser(login, password, impLevel, authLevel);
            ssd.ShowDialog();
            if (scipt == null)
                return;
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            output.Nodes.Clear();
            string respond;
            TreeNode tt;
            foreach (string target in tts)
            {
                respond = "Результат: ";
                object res = Handler.create_obj(target, "Win32_Process", new object[] { scipt });
                if (res == null)
                    respond += "Цель недоступна";
                else
                    switch ((UInt32)res)
                    {
                        case 0:
                            respond += "Успешно";
                            break;
                        case 9:
                            respond += "Запускаемый файл недоступен на целевой машине";
                            break;
                        default:
                            respond += res.ToString();
                            break;
                    }
                tt = new TreeNode(target);
                tt.Nodes.Add(respond);
                output.Nodes.Add(tt);
            }
        }

        private void join_domain(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            if (!check())
                return;
            if (impLevel < 2 || authLevel < 4)
            {
                MessageBox.Show("Для управления целью необходимы следующие права:\r\nУровень олицетворения: Не ниже \"Олицетворение\"" +
                    "\r\nУровень аутентификации: Не ниже \"Целостность пакетов\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Handler.setUser(login, password, impLevel, authLevel);
            DomainDialog domain = new DomainDialog(true);
            domain.Owner = this;
            domain.ShowDialog();
            if (domainName == null)
                return;
            string[] tts = new string[targets.CheckedItems.Count];
            for (int i = 0; i < targets.CheckedItems.Count; i++)
                tts[i] = targets.CheckedItems[i].ToString();
            output.Nodes.Clear();
            string respond;
            TreeNode tt;
            string ou = null;
            string join_flag = null;
            if (is_domain)
            {
                ou = "OU=Workstation;";
                string[] spld = domainName.Split('.');
                foreach (string domain_part in spld)
                    ou += " DC=" + domain_part;
                join_flag = "1";
            }
            foreach (string target in tts)
            {
                respond = "Результат: ";
                object res = Handler.exec_by_object(target, "Win32_ComputerSystem", "JoinDomainOrWorkgroup", new object[] { domainName, dcUser, dcPassword, ou, join_flag });
                if (res == null)
                    respond += "Цель недоступна";
                else
                    switch ((UInt32)res)
                    {
                        case 0:
                            respond += "Успешно";
                            break;
                        case 0x54b:
                            respond += "Домен не найден (недоступен)";
                            break;
                        case 0x54e:
                            respond += "Неверный логин и (или) пароль ";
                            break;
                        default:
                            respond += res;
                            break;
                    }
                tt = new TreeNode(target);
                tt.Nodes.Add(respond);
                output.Nodes.Add(tt);
            }
        }

        private void unjoin_domain(object sender, EventArgs e)
        {
            {
                if (impLevel < 2 || authLevel < 4)
                {
                    MessageBox.Show("Для управления целью необходимы следующие права:\r\nУровень олицетворения: Не ниже \"Олицетворение\"" +
                        "\r\nУровень аутентификации: Не ниже \"Целостность пакетов\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                tabControl1.SelectedIndex = 0;
                if (!check())
                    return;
                Handler.setUser(login, password, impLevel, authLevel);
                DomainDialog domain = new DomainDialog(false);
                domain.Owner = this;
                domain.ShowDialog();
                string[] tts = new string[targets.CheckedItems.Count];
                for (int i = 0; i < targets.CheckedItems.Count; i++)
                    tts[i] = targets.CheckedItems[i].ToString();
                output.Nodes.Clear();
                string respond;
                TreeNode tt;
                foreach (string target in tts)
                {
                    respond = "Результат: ";
                    object res = Handler.exec_by_object(target, "Win32_ComputerSystem", "UnJoinDomainOrWorkgroup", new object[] { dcUser, dcPassword });
                    if (res == null)
                        respond += "Цель недоступна";
                    else
                        switch ((UInt32)res)
                        {
                            case 0:
                                respond += "Успешно";
                                break;
                            case 0xa84:
                                respond += "Цель не в домене";
                                break;
                            default:
                                respond += res;
                                break;
                        }
                    tt = new TreeNode(target);
                    tt.Nodes.Add(respond);
                    output.Nodes.Add(tt);
                }
            }
        }

        private void output_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            current_node = e.Node;
            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Parent != null)
                    current_target = e.Node.Parent.Parent.Text;
            }
            else
                current_target = e.Node.Text;
        }

        private void serialize()
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataTable));
            DataTable dt = new DataTable("consumers");
            dt.Columns.Add("target");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            object[] cellValues = new object[consumers.Columns.Count];
            foreach (DataGridViewRow row in consumers.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                    cellValues[i] = row.Cells[i].Value;
                dt.Rows.Add(cellValues);
            }
            TextWriter writer = new StreamWriter(Application.StartupPath + "\\database.xml");
            ser.Serialize(writer, dt);
            writer.Close();
        }

        private void deserialize()
        {
            string file = Application.StartupPath + "\\database.xml";
            if (File.Exists(file))
            {
                XmlSerializer ser = new XmlSerializer(typeof(DataTable));
                DataTable dt = new DataTable("data");
                TextReader reader = new StreamReader(file);
                dt = (DataTable)ser.Deserialize(reader);
                reader.Close();
                string[] row = new string[3];
                foreach (DataRow data in dt.Rows)
                    consumers.Rows.Add(data.ItemArray);
            }
        }

        private void remove_selected_consumers(object sender, EventArgs e)
        {
            if (login == null)
            {
                MessageBox.Show("Необходимо ввести учетные данные пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string cons_name;
            foreach (DataGridViewRow consumer in consumers.SelectedRows)
            {
                cons_name = consumer.Cells[1].Value.ToString() + ":" + consumer.Cells[2].Value.ToString().Replace("Consumer", "");
                Handler.delete_consumer(consumer.Cells[0].Value.ToString(), cons_name);
                consumers.Rows.Remove(consumer);
            }
            serialize();
        }

        private void show_target_data(object sender, EventArgs e)
        {
            if (login == null)
            {
                MessageBox.Show("Необходимо ввести учетные данные пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Handler.setUser(login, password, impLevel, authLevel);
            TargetData td = new TargetData(current_target);
            td.ShowDialog();
        }
    }
}
