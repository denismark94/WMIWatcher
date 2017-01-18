using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMIWatcher.Engine
{
    class WMI_LogonInfo: WMI_class
    {
        public WMI_LogonInfo(int time)
        {
            this.query = det_query("Win32_NtLogEvent", "Logfile = 'Security' and TimeWritten >= '{0}' and TimeWritten < '{1}'");
            string end = ManagementDateTimeConverter.ToDmtfDateTime(DateTime.Now);
            string start = ManagementDateTimeConverter.ToDmtfDateTime(DateTime.Now.AddHours(-time));
            this.query = string.Format(this.query, start, end);
            this.summary = "Попыток входа в систему: ";

            this.event_condition = det_condition("Win32_NtLogEvent", "TargetInstance.Logfile = 'Security' ");
        }

        public override TreeNode form_output(ManagementObjectCollection collection)
        {
            int evt_code,count = 0;
            string time, raw, user, type;
            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode node;
            foreach (ManagementObject evt in collection)
            {
                evt_code = int.Parse(evt["EventCode"].ToString());
                switch (evt_code)
                {
                    case 4625:
                        node = new TreeNode("Неудачная попытка входа");
                        time = ManagementDateTimeConverter.ToDateTime((string)evt["TimeWritten"]).ToString();
                        raw = (string)evt["Message"];
                        user = raw.Split('\r')[12].Replace("Имя учетной записи:", "").Trim();
                        node.Nodes.Add("Пользователь: " + user);
                        node.Nodes.Add("Время: " + time);
                        nodes.Add(node);
                        count++;
                        break;
                    case 4624:
                        node = new TreeNode("Удачная попытка входа");
                        time = ManagementDateTimeConverter.ToDateTime((string)evt["TimeWritten"]).ToString();
                        raw = (string)evt["Message"];
                        type = raw.Split('\r')[8].Replace("Тип входа:", "").Trim();
                        user = raw.Split('\r')[12].Replace("Имя учетной записи:", "").Trim();
                        if (type.Equals("2"))
                        {
                            node.Nodes.Add("Пользователь: " + user);
                            node.Nodes.Add("Время: " + time);
                            nodes.Add(node);
                            count++;
                        }
                        break;
                }
                
            }
            TreeNode root = new TreeNode(summary + count.ToString());
            root.Nodes.AddRange(nodes.ToArray());
            return root;
        }

        public override string[] handle_event(ManagementBaseObject obj)
        {
            int log_evt_code = int.Parse(((ManagementBaseObject)obj["TargetInstance"])["EventCode"].ToString());
            if (log_evt_code != 4624 && log_evt_code != 4625)
                return null;
            string time = (string)((ManagementBaseObject)obj["TargetInstance"])["TimeWritten"];
            time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            string raw = (string)((ManagementBaseObject)obj["TargetInstance"])["Message"];
            string user = raw.Split('\r')[12].Replace("Имя учетной записи:", "").Trim();
            string stub = "";
            switch (log_evt_code)
            {
                case 4624:
                    stub = "Успех";
                    break;
                case 4625:
                    stub = "Неудача";
                    break;
            }
            return new string[] { null, stub, user, time };
        }
    }
}
