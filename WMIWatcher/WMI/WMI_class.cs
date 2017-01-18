using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace WMIWatcher.Engine
{
    abstract class WMI_class
    {
        public string query = "Select * from {0} where {1}";
        public string summary;
        public string name = "Name";
        public string[] stub;
        public string[] fields;

        public string event_condition = "TargetInstance isa \"{0}\" and {1}";
        public int event_index;
        public string[] event_types = new string[] { "__InstanceCreationEvent", "__InstanceModificationEvent", "__InstanceDeletionEvent" };
        public string[] event_stub;
        public string event_name = "Name";
        public string event_time = "Created";

        public string logging_stub;
        public string consumer_name;

        public string det_query(string wmi_class, string conditions)
        {
            return string.Format(query, wmi_class, conditions);
        }

        public string det_condition(string wmi_class, string conditions)
        {
            return string.Format(event_condition, wmi_class, conditions);
        }

        public string det_query(string wmi_class)
        {
            return string.Format(query.Replace(" where {1}", ""), wmi_class);
        }
        public string det_condition(string wmi_class)
        {
            return string.Format(event_condition.Replace(" and {1}", ""), wmi_class);
        }

        public virtual TreeNode form_output(ManagementObjectCollection collection)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            int count = 0;
            foreach (ManagementObject obj in collection)
            {
                if (obj != null)
                {
                    if (obj[name] == null)
                        continue;
                    TreeNode node = new TreeNode(obj[name].ToString());
                    if (fields != null)
                    {
                        for (int i = 0; i < fields.Length; i++)
                        {
                            if (obj[fields[i]] == null)
                                stub[i] = stub[i].Replace(fields[i], "null");
                            else
                                stub[i] = stub[i].Replace(fields[i], obj[fields[i]].ToString());
                            node.Nodes.Add(stub[i]);
                        }
                    }
                    count++;
                    nodes.Add(node);
                }
            }
            TreeNode root = new TreeNode(summary + count.ToString());
            root.Nodes.AddRange(nodes.ToArray());
            return root;
        }

        public virtual string[] form_target_data(ManagementObjectCollection collection)
        {
            string[] vals = new string[fields.Length];
            foreach (ManagementObject obj in collection)
            {
                for (int i = 0; i < fields.Length; i++)
                {
                    if (obj[fields[i]] == null)
                        vals[i] = "null";
                    else
                        vals[i] = obj[fields[i]].ToString();
                }
            }
            return vals;
        }

        public virtual string[] handle_event(ManagementBaseObject obj)
        {
            string name = (string)((ManagementBaseObject)obj["TargetInstance"])[event_name];
            string time = (string)((ManagementBaseObject)obj["TargetInstance"])[event_time];
            if (time == null)
                time = DateTime.Now.ToString();
            else
                time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            return new string[] { null, event_stub[event_index], name, time };
        }
    }
}
