using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WMIWatcher
{
    public partial class AddIP : Form
    {
        string rgx = @"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                    + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                    + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                    + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?\.))";
        public List<string> ips = new List<string>();
        public AddIP()
        {
            InitializeComponent();
            octet1.Focus();
        }

        private void btnAddIp_Click(object sender, EventArgs e)
        {
            ips.Clear();
            string ip_1, ip_2;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    ip_1 = octet1.Text + "." + octet2.Text + "." + octet3.Text + "." + octet4.Text;
                    Match match = Regex.Match(ip_1 + ".", rgx);
                    if (match.Success)
                    {
                        ips.Add(ip_1);
                        Close();
                    }
                    else
                        MessageBox.Show("Некорректный IP-адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    ip_1 = s_oct_1.Text + "." + s_oct_2.Text + "." + s_oct_3.Text + "." + s_oct_4.Text;
                    ip_2 = f_oct_1.Text + "." + f_oct_2.Text + "." + f_oct_3.Text + "." + f_oct_4.Text;
                    Match match_1 = Regex.Match(ip_1 + ".", rgx);
                    Match match_2 = Regex.Match(ip_2 + ".", rgx);
                    if (!match_1.Success)
                    {
                        MessageBox.Show("Некорректный стартовый IP-адрес","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }
                    if (!match_2.Success)
                    {
                        MessageBox.Show("Некорректный конечный IP-адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    ips = Engine.IPHandler.get_ip_range(ip_1, ip_2);
                    Close();
                    break;

            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            ips = Engine.IPHandler.scan();
            if (ips == null)
            {
                MessageBox.Show("Не обнаружено активных сетевых адаптеров\r\n"+
                    "Проверьте подключение по локальной сети","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            ips.Sort();
            Close();
        }

        private void octet1_TextChanged(object sender, EventArgs e)
        {
            if (octet1.TextLength == octet1.MaxLength)
                octet2.Focus();
        }
        private void octet2_TextChanged(object sender, EventArgs e)
        {
            if (octet2.TextLength == octet2.MaxLength)
                octet3.Focus();
        }
        private void octet3_TextChanged(object sender, EventArgs e)
        {
            if (octet3.TextLength == octet3.MaxLength)
                octet4.Focus();
        }

        private void s_oct_1_TextChanged(object sender, EventArgs e)
        {
            if (s_oct_1.TextLength == s_oct_1.MaxLength)
                s_oct_2.Focus();
        }
        private void s_oct_2_TextChanged(object sender, EventArgs e)
        {
            if (s_oct_2.TextLength == s_oct_2.MaxLength)
                s_oct_3.Focus();
        }
        private void s_oct_3_TextChanged(object sender, EventArgs e)
        {
            if (s_oct_3.TextLength == octet3.MaxLength)
                s_oct_4.Focus();
        }
        private void s_oct_4_TextChanged(object sender, EventArgs e)
        {
            if (s_oct_4.TextLength == octet3.MaxLength)
                f_oct_1.Focus();
        }

        private void f_oct_1_TextChanged(object sender, EventArgs e)
        {
            if (f_oct_1.TextLength == octet1.MaxLength)
                f_oct_2.Focus();
        }
        private void f_oct_2_TextChanged(object sender, EventArgs e)
        {
            if (f_oct_2.TextLength == octet2.MaxLength)
                f_oct_3.Focus();
        }
        private void f_oct_3_TextChanged(object sender, EventArgs e)
        {
            if (f_oct_3.TextLength == octet3.MaxLength)
                f_oct_4.Focus();
        }


    }
}
