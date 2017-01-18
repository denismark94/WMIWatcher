using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace sandbox
{
    class Program
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

        static string ats(int[]ip)
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

        static void Pinger(Object input)
        {
            string[] hostAdress = (string[])input;
            Ping png = new Ping();
            foreach (string host in hostAdress)
            {
                try
                {
                    PingReply pr = png.Send(host, 5);
                    if(pr.Status.ToString().Equals("Success"))
                        active.Add(host);
                }
                catch (Exception ex)
                {
                }
            }
        }


        static void Main(string[] args)
        {
            ManagementScope scope = new ManagementScope("\\\\.\\Root\\CIMV2");
            scope.Connect();
            string condition = "TargetInstance isa \"CIM_DataFile\" and TargetInstance.Drive=\"D:\""
                                + " and TargetInstance.Path=\"\\\\.\\\\\"";
            WqlEventQuery query = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 5), condition);
            ManagementEventWatcher watcher = new ManagementEventWatcher(scope, query);

            watcher.EventArrived += new EventArrivedEventHandler(HandleFMEvent);//(object sender, EventArrivedEventArgs e) => HandleFMEvent(sender, e, (int)rtype, Output));
            watcher.Start();
            while (!Console.ReadLine().Equals("stop"))
            {
            }
            watcher.Stop();

        }

        public static void HandleFMEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject obj = e.NewEvent;
            string name = (string)((ManagementBaseObject)obj["TargetInstance"])["Name"];
            string time = (string)((ManagementBaseObject)obj["TargetInstance"])["LastModified"];
            time = ManagementDateTimeConverter.ToDateTime(time).ToString();
            Console.WriteLine(string.Format("{0},{1}",name,time));
        }

        public static void remote_shutdown()
        {
            ManagementScope ms = new ManagementScope("\\\\homepc\\Root\\CIMV2");
            ConnectionOptions options = new ConnectionOptions();
            options.Username = "Администратор";
            options.Password = "1";
            ms.Options = options;
            ms.Connect();
            string query = "Select * from Win32_OperatingSystem";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine(obj["Caption"]);
                Console.WriteLine("Installed: " + ManagementDateTimeConverter.ToDateTime(obj["InstallDate"].ToString()));
                Console.WriteLine("Last Boot Up: " + ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString()));
                Console.WriteLine("NumberOfUsers: " +obj["NumberOfUsers"]);
                Console.WriteLine("OS Architecture: " +obj["OSArchitecture"]);
                Console.WriteLine("Serial Number: " +obj["SerialNumber"]);
                Console.WriteLine(obj.InvokeMethod("Win32Shutdown", new object[] {12, 0 }).ToString());
                //out -1191 - other logged users
                //0 - log off
                //2 - reboot
                //8 -power off
                //+4 -force
            }
        }

        public static void rename_host()
        {
            ManagementScope ms = new ManagementScope("\\\\homepc\\Root\\CIMV2");
            ConnectionOptions options = new ConnectionOptions();
            options.Username = "Администратор";
            options.Password = "1";
            options.Authentication = AuthenticationLevel.PacketPrivacy;
            ms.Options = options;
            string query = "Select * from Win32_ComputerSystem";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine(obj["Name"]);
                Console.WriteLine(obj["Manufacturer"]);
                Console.WriteLine(obj["Domain"]);
                Console.WriteLine(obj["Model"]);
                Console.WriteLine(obj["UserName"]);
                Console.WriteLine(obj["TotalPhysicalMemory"]);

                //obj.InvokeMethod("Rename", new string[] { "HomePC", "Администратор", "1" });
                //obj.InvokeMethod("JoinDomainOrWorkgroup", new string[] { "WORKGROUP", "1", "Администратор",null,null });
                obj.InvokeMethod("JoinDomainOrWorkgroup", new string[] { "WORKGROUP", "1", "Администратор","",null });
            }
        }

        public static void deleteApp()
        {
             ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");

            ms.Connect();
            string query = "Select * from Win32_Product where IdentifyingNumber = '{33A420A1-1B47-81A6-A10C-3EA0CF2270DA}'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine(string.Format("\r\nName:{0}\tVersion:{1}\tVendor:{2}",obj["Name"],obj["Version"],obj["Vendor"]));
                obj.InvokeMethod("Uninstall", null);
            }
        }

        public static void terminate_process()
        {
            ManagementScope ms = new ManagementScope("\\\\homepc\\Root\\CIMV2");
            ConnectionOptions options = new ConnectionOptions();
            options.Username = "Администратор";
            options.Password = "1";
            ms.Options = options;
            ms.Connect();
            string query = "Select * from Win32_Process where Name = 'opera.exe'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine(string.Format("\r\nName:{0}\r\nHandle: {1}", obj["Name"], obj["Handle"]));
                obj.InvokeMethod("Terminate", null);
            }
        }

        public static void scipt_execute()
        {
            ManagementScope ms = new ManagementScope("\\\\homepc\\Root\\CIMV2");
            ConnectionOptions options = new ConnectionOptions();
            options.Username = "Администратор";
            options.Password = "1";
            ms.Options = options;
            ms.Connect();
            string query = "Win32_Process";
            ManagementClass mclass = new ManagementClass(query);
            mclass.Scope = ms;
            //mclass.InvokeMethod("Create", new object[] { "c:\\script.bat", null, null, 8888 });
            mclass.InvokeMethod("Create", new object[] { "calc.exe", null, null, 8888 });

        }

        public static void handle_file()
        {
            ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");
            ms.Connect();
            string query = "Select * from CIM_DataFile where Extension = 'bat' and Drive = 'C:' and Path = '\\\\.\\\\'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                //FileSize
                //FileType
                //CreationDate
                //Hidden
                //InstallDate
                //LastAccessed
                //LastModified
                Console.WriteLine(string.Format("\r\nValue:{0}", obj["AccessMask"]));
                //obj.InvokeMethod("Copy", new object[] {"d:\\script.bat"});
                //obj.InvokeMethod("Rename", new object[] { "c:\\aaaaAAaa.bat" });
                //obj.InvokeMethod("Delete",null);
            }
        }

        static void ProcessOwners()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\Root\\CIMV2");
            scope.Connect();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * from Win32_Process");
            ManagementObjectCollection collection = searcher.Get();
            string[] credentials = new string[2];
            string[] sid = new string[1];
            foreach (ManagementObject obj in collection)
            {
                obj.InvokeMethod("GetOwner", credentials);
                obj.InvokeMethod("GetOwnerSid", sid);
                Console.WriteLine(string.Format("Name: {0}\r\nUser: {2}\\{1}\r\nSID: {3}\r\n", obj["Name"], credentials[0], credentials[1], sid[0]));
            }
        }

        static void DateTimeHandle()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\Root\\CIMV2");
            string serverTime = null;
            SelectQuery timeQuery = new SelectQuery(@"select LocalDateTime from Win32_OperatingSystem");
            ManagementObjectSearcher timeQuerySearcher = new ManagementObjectSearcher(timeQuery);
            foreach (ManagementObject mo in timeQuerySearcher.Get())
            {
                serverTime = mo["LocalDateTime"].ToString();
                DateTime dt = ManagementDateTimeConverter.ToDateTime(serverTime);
                Console.WriteLine(dt.ToString());
                DateTime dt2 = DateTime.Now;
                Console.WriteLine(dt2.AddHours(24).ToString());
            }

        }

        static void domain()
        {
            ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");
            string query = "Select * from Win32_ComputerSystem";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            string strErrorDescription = null;
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine(obj["Name"]);
                Console.WriteLine(obj["Manufacturer"]);
                Console.WriteLine(obj["Domain"]);
                Console.WriteLine(obj["Model"]);
                Console.WriteLine(obj["UserName"]);
                Console.WriteLine(obj["TotalPhysicalMemory"]);

                //UInt32 ans = (UInt32)obj.InvokeMethod("UnJoinDomainOrWorkgroup", new string[] { "1", "Администратор" ,0});
                //0 - removes pc from domain
                //4 - disable account, do not delete
                UInt32 ans = (UInt32)obj.InvokeMethod("JoinDomainOrWorkgroup", new string[]{"domain","1","Администратор",/*AccountOU*/null,"1"});
                //1 - join domain
                //2 - acct-create
                //4 - acct-delete
                switch (ans)
                {
                    case 5:
                        strErrorDescription = "Access is denied";
                        break;
                    case 87:
                        strErrorDescription = "The parameter is incorrect";
                        break;
                    case 110:
                        strErrorDescription = "The system cannot open the specified object";
                        break;
                    case 1323:
                        strErrorDescription = "Unable to update the password";
                        break;
                    case 1326:
                        strErrorDescription = "Logon failure: unknown username or bad password";
                        break;
                    case 1355:
                        strErrorDescription = "The specified domain either does not exist or could not be contacted";
                        break;
                    case 2224:
                        strErrorDescription = "The account already exists";
                        break;
                    case 2691:
                        strErrorDescription = "The machine is already joined to the domain";
                        break;
                    case 2692:
                        strErrorDescription = "The machine is not currently joined to a domain";
                        break;
                }
                Console.WriteLine(strErrorDescription);
            }
        }

        static void loggedonuser()
        {
            ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");
            //ConnectionOptions options = new ConnectionOptions();
            //options.Username = "Администратор";
            //options.Password = "1";
            //ms.Options = options;
            ms.Connect();
            string query = "Select * from Win32_LogonSession Where LogonType = 2 OR LogonType = 10";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            ManagementObjectCollection res = searcher.Get();
            foreach (ManagementObject obj in res)
            {
                Console.WriteLine("Start Time: " + ManagementDateTimeConverter.ToDateTime(obj["StartTime"].ToString()));
                Console.WriteLine("ID: " + obj["LogonId"]);
                query = "ASSOCIATORS of {Win32_LogonSession.LogonId=\"" + obj["LogonId"] + "\"} Where AssocClass=Win32_LoggedOnUser Role=Dependent";
                searcher = new ManagementObjectSearcher(ms, new ObjectQuery(query));
                ManagementObjectCollection users = searcher.Get();
                if (users != null)
                {
                    foreach (ManagementObject user in users)
                        Console.WriteLine(user["Caption"]);
                }
            }
        }


        static void tmp()
        {
            string localIP, netmask = null;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
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
            int[] mask = sta(netmask);
            int[] start = new int[4];
            int[] stop = new int[4];
            for (int j = 0; j < 4; j++)
            {
                start[j] = addr[j] & mask[j];
                stop[j] = addr[j] | (255 - mask[j]);
            }
            int[] cur = start;
            Ping ping = new Ping();
            int i;
            List<string> ips = new List<string>();

            while (true)
            {
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
                ips.Add(ats(cur));
            }

            string[] first = new string[ips.Count / 2];
            string[] second = new string[ips.Count / 2 + 1];
            ips.CopyTo(0, first, 0, ips.Count / 2);
            ips.CopyTo(ips.Count / 2, second, 0, ips.Count / 2);
            List<string[]> queue = new List<string[]>();
            List<Thread> threads = new List<Thread>();
            for (int j = 0; j < ips.Count; j += ips.Count / 100)
            {
                string[] b = new string[Math.Min(ips.Count / 100, ips.Count - j)];
                ips.CopyTo(j, b, 0, Math.Min(ips.Count / 100, ips.Count - j));
                Thread thread = new Thread(Pinger);
                thread.Start(b);
                threads.Add(thread);
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            foreach (string a in active)
            {
                Console.WriteLine(a);
            }



            //ManagementScope ms = new ManagementScope("\\\\.\\Root\\CIMV2");
            ////ConnectionOptions options = new ConnectionOptions();
            ////options.Username = "Администратор";
            ////options.Password = "1";
            ////ms.Options = options;
            //ms.Connect();
            //string query = "Select * from Win32_NetworkAdapter Where PhysicalAdapter = true";
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            //searcher.Scope = ms;
            //ManagementObjectCollection settings, res = searcher.Get();
            //int[] ip, mask;
            //string[] buf;
            //List<string> local_ip_addresses = new List<string>();
            //foreach (ManagementObject obj in res)
            //{
            //    query = "ASSOCIATORS of {Win32_NetworkAdapter.DeviceId=\"" + obj["DeviceID"] + "\"} where AssocClass=Win32_NetworkAdapterSetting Role=Element";
            //    searcher = new ManagementObjectSearcher(ms, new ObjectQuery(query));
            //    settings = searcher.Get();
            //    foreach (ManagementBaseObject set in settings)
            //    {
            //        if ((bool)set["IPEnabled"])
            //        {
            //            Console.WriteLine("Name: " + obj["Name"]);
            //            Console.WriteLine("Mac Address: " + obj["MacAddress"]);
            //            Console.WriteLine("Time Of Last Reset: " + ManagementDateTimeConverter.ToDateTime(obj["TimeOfLastReset"].ToString()));

            //            Console.WriteLine("DNS Name: " + set["DNSHostname"]);
            //            buf = (string[])set["IPAddress"];
            //            if (buf != null)
            //            {
            //                local_ip_addresses.Add(buf[0]);
            //                Console.WriteLine("IPAddress: " + buf[0]);
            //            }
            //            if (buf != null)
            //            {
            //                buf = (string[])set["IPSubnet"];
            //                mask = sta(buf[0]);
            //                Console.WriteLine("Mask: " + ats(mask));
            //            }
            //        }
            //    }
            //}
            //int[] start = new int[4];
            //int[] stop = new int[4];
            //for (int j = 0; j < 4; j++)
            //{
            //    start[j] = ip[j] & mask[j];
            //    stop[j] = ip[j] | (255 - mask[j]);
            //}
            //Console.WriteLine("ip: "+ats(ip));
            //Console.WriteLine("netmask: " + ats(mask));
            //Console.WriteLine("start: " + ats(start));
            //Console.WriteLine("stop: " + ats(stop));
            //int[] cur = start;
            //Ping ping = new Ping();
            //int i;
            //LinkedList<string> ips = new LinkedList<string>();
            //while (true)
            //{
            //    if (ge(cur, stop))
            //        break;
            //    i = 3;
            //    while (cur[i] == 255)
            //    {
            //        cur[i] = 0;
            //        i--;
            //        if (i < 0)
            //            break;
            //    }
            //    if (i < 0)
            //        break;
            //    cur[i]++;
            //    PingReply reply = ping.Send(ats(cur),1);
            //    if (reply.Status.ToString().Equals("Success"))
            //        ips.AddLast(ats(cur));
            //}
            //Console.WriteLine(String.Join("\n",ips.ToArray()));
        }
    }
}
