using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMIWatcher.Engine
{
    class WMI_Process : WMI_class
    {
        public WMI_Process()
        {
            this.query = det_query("Win32_Process");
            this.summary = "Запущенных процессов: ";
            this.stub = new string[] { "ID: Handle", "Время запуска: Time", "Владелец: User" };
            this.fields = new string[] { "Handle" };

            this.event_condition = det_condition("Win32_Process");
            this.event_time = "CreationDate";
            this.event_stub = new string[] { "Запущен", "Изменен", "Завершен" };

            this.logging_stub = "[%TargetInstance.CreationDate%]: {0} Процесс %TargetInstance.Name%";
            this.consumer_name = "Process";
        }

        public override TreeNode form_output(ManagementObjectCollection collection)
        {
            int count = 0;
            string[] credentials = new string[2];
            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode node;
            foreach (ManagementObject obj in collection)
            {
                if (obj != null)
                {
                    node = new TreeNode(obj["Name"].ToString());
                    if (obj["Handle"] == null)
                        node.Nodes.Add("ID: NULL");
                    else
                        node.Nodes.Add("ID: " + obj["Handle"].ToString());
                    if (obj["CreationDate"] == null)
                        node.Nodes.Add("Time: NULL");
                    else
                        node.Nodes.Add("Time: " + ManagementDateTimeConverter.ToDateTime(obj["CreationDate"].ToString()));
                    try
                    {
                        obj.InvokeMethod("GetOwner", credentials);
                    }
                    catch (ManagementException)
                    {
                        node.Nodes.Add("User: NULL");
                    }
                    if (credentials.Contains(null))
                        node.Nodes.Add("User: NULL");
                    else
                        node.Nodes.Add("User: " + credentials[0] + "\\"  +credentials[1]);
                    nodes.Add(node);
                    count++;
                }
            }
            TreeNode root = new TreeNode(summary + count);
            root.Nodes.AddRange(nodes.ToArray());
            return root;
        }

    }
}
