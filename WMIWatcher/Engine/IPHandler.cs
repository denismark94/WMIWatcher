using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace WMIWatcher.Engine
{
    class IPHandler
    {
        static volatile List<string> active = new List<string>();
        static bool ge(int[] a, int[] b)
        {
            int i = 0;
            while (a[i] == b[i])
            {
                i++;
                if (i == a.Length)
                    return true;
            }
            return (a[i] > b[i]);
        }

        static string ats(int[] ip)
        {
            string result = ip[0].ToString();
            for (int i = 1; i < ip.Length; i++)
                result += "." + ip[i];
            return result;
        }

        static int[] sta(string ip)
        {
            string[] raw = ip.Split('.');
            int[] res = new int[raw.Length];
            for (int i = 0; i < raw.Length; i++)
                res[i] = int.Parse(raw[i]);
            return res;
        }

        public static List<string> get_ip_range(string s_ip, string f_ip)
        {
            int[] start = sta(s_ip);
            int[] stop = sta(f_ip);
            int[] cur = start;
            Ping ping = new Ping();
            int i;
            List<string> ips = new List<string>();
            while (true)
            {
                ips.Add(ats(cur));
                if (ge(cur, stop))
                    break;
                i = 3;
                while (cur[i] == 255)
                {
                    cur[i] = 0;
                    i--;
                    if (i < 0)
                        break;
                }
                if (i < 0)
                    break;
                cur[i]++;
            }
            return ips;
        }

        public static List<string> scan()
        {
            string localIP = get_local_ip();
            if (localIP == null)
                return null;
            string netmask = null;
            int[] addr = sta(localIP);
            ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");
            ms.Connect();
            string query = @"Select * from Win32_NetworkAdapterConfiguration Where IPEnabled = true";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementBaseObject adapter in searcher.Get())
            {
                if (((string[])adapter["IPAddress"])[0].Equals(localIP))
                    netmask = ((string[])adapter["IPSubnet"])[0];
            }
            if (netmask == null)
                return null;
            int[] mask = sta(netmask);
            int[] start = new int[4];
            int[] stop = new int[4];
            for (int j = 0; j < 4; j++)
            {
                start[j] = addr[j] & mask[j];
                stop[j] = addr[j] | (255 - mask[j]);
            }
            List<string> ips = get_ip_range(ats(start), ats(stop));
            List<Thread> threads = new List<Thread>();
            active.Clear();
            for (int j = 0; j < ips.Count; j += ips.Count / 100)
            {
                string[] b = new string[Math.Min(ips.Count / 100, ips.Count - j)];
                ips.CopyTo(j, b, 0, Math.Min(ips.Count / 100, ips.Count - j));
                Thread thread = new Thread(Pinger);
                thread.Start(b);
                threads.Add(thread);
            }
            foreach (Thread t in threads)
                t.Join();
            return active;
        }

        static void Pinger(Object input)
        {
            string[] hostAdress = (string[])input;
            Ping png = new Ping();
            foreach (string host in hostAdress)
            {
                try
                {
                    PingReply pr = png.Send(host, 5);
                    if (pr.Status.ToString().Equals("Success"))
                        active.Add(host);
                }
                catch (Exception) { }
            }
        }

        public static string get_local_ip()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
    }
}
