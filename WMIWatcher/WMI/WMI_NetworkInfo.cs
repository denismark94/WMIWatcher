using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace WMIWatcher.Engine
{
    class WMI_NetworkInfo: WMI_class
    {
        public WMI_NetworkInfo()
        {
            this.query = det_query("Win32_NetworkAdapterConfiguration");
            this.summary = "Сетевых адаптеров: ";
        }

        public override TreeNode form_output(ManagementObjectCollection collection)
        {
            int count = 0;
            string name, mac;
            string[] ip;
            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode node;
            foreach (ManagementObject obj in collection)
            {
                if (obj != null)
                {
                    if (obj["IPAddress"] == null || obj["MACAddress"] == null)
                        continue;
                    ip = (string[])obj["IPAddress"];
                    name = obj["Caption"].ToString();
                    name = name.Substring(11, name.Length - 11);
                    mac = obj["MACAddress"].ToString();
                    node = new TreeNode(name);
                    node.Nodes.Add("MAC-адрес: " + mac);
                    node.Nodes.Add("IPv4-адрес: " + ip[0]);
                    node.Nodes.Add("IPv6-адрес: " + ip[1]);
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
