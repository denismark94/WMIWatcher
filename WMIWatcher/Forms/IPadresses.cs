using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMIWatcher
{
    public partial class IPadresses : Form
    {
        public IPadresses()
        {
            InitializeComponent();
            IpList.CheckOnClick = true;
            List<string> ips = new List<string>();
            for (int i = 0; i < IpList.Items.Count; i++)
                if (IpList.GetItemChecked(i))
                    ips.Add(IpList.Items[i].ToString());
            MainForm main = this.Owner as MainForm;
            if (main != null)
                main.clients = ips;
        }

        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < IpList.Items.Count; i++)
            IpList.SetItemChecked(i, true);
        }

        private void btnUnmarkAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < IpList.Items.Count; i++)
                IpList.SetItemChecked(i, false);
        }

        private void BtnFormList_Click(object sender, EventArgs e)
        {
            List<string> ips = new List<string>();
            for (int i = 0; i < IpList.Items.Count; i++)
                if (IpList.GetItemChecked(i))
                    ips.Add(IpList.Items[i].ToString());
            MainForm main = this.Owner as MainForm;
            if (main != null)
                main.clients = ips;
            this.Close();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            for (int i = IpList.Items.Count - 1; i >= 0; i--)
                if (IpList.GetItemChecked(i))
                    IpList.Items.RemoveAt(i);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //AddIP addipform = new AddIP();
            //addipform.ShowDialog();
            //if (addipform.ipaddress != null)
            //    IpList.Items.Add(addipform.ipaddress);
        }

        private List<string> getActiveIps (string[] all, bool[] active)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < all.Length; i++)
                if (active[i])
                    output.Add(all[i]);
            return output;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
