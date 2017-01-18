using System;
using System.Management;
using System.Windows.Forms;
using WMIWatcher.Engine;

namespace WMIWatcher.Forms
{
    public partial class TargetData : Form
    {
        public string new_name;
        public string target;
        public TargetData(string target)
        {
            this.target = target;
            InitializeComponent();
            string[] os_data = Handler.collect_target_info(new WMI_OperatingSystem(), target);
            string[] cs_data = Handler.collect_target_info(new WMI_ComputerSystem(), target);
            dataGridView1.Rows.Add(new string[] { "NetBIOS-имя", cs_data[0] });
            dataGridView1.Rows.Add(new string[] { "Производитель", cs_data[1] });
            dataGridView1.Rows.Add(new string[] { "Домен", cs_data[2] });
            dataGridView1.Rows.Add(new string[] { "Модель", cs_data[3] });
            dataGridView1.Rows.Add(new string[] { "Активный пользователь", cs_data[4] });
            dataGridView1.Rows.Add(new string[] { "Объем RAM", cs_data[5] });
            dataGridView1.Rows.Add(new string[] { "Операционная система", os_data[0] });
            dataGridView1.Rows.Add(new string[] { "Дата установки", ManagementDateTimeConverter.ToDateTime(os_data[1]).ToString() });
            dataGridView1.Rows.Add(new string[] { "Время последней загрузки", ManagementDateTimeConverter.ToDateTime(os_data[2]).ToString() });
            dataGridView1.Rows.Add(new string[] { "Количество пользователей", os_data[3] });
            dataGridView1.Rows.Add(new string[] { "Серийный номер ОС", os_data[4] });

        }

        private void rename(object sender, EventArgs e)
        {
            RenameDialog rd = new RenameDialog();
            rd.Owner = this;
            rd.ShowDialog();
            if (new_name == null)
                return;
            object obj = Handler.exec_by_object(target, "Win32_ComputerSystem", "Rename", new object[] { new_name, "Администратор", "1" });
            if (obj == null)
            {
                MessageBox.Show("Цель недоступна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch ((UInt32)obj)
            {
                case 0:
                    dataGridView1.Rows.RemoveAt(0);
                    dataGridView1.Rows.Insert(0, new string[] { "NetBIOS-имя", new_name.ToUpper() });
                    break;
                default:
                    MessageBox.Show(((UInt32)obj).ToString());
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}