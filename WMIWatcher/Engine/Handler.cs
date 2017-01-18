using System;
using System.Management;
using System.Security;
using System.Windows.Forms;
using WMIWatcher.Engine;

namespace WMIWatcher
{
    class Handler
    {
        private static ConnectionOptions options;

        public static void setUser(string login, SecureString pass, int imp, int auth)
        {
            options = new ConnectionOptions();
            options.Username = login;
            options.SecurePassword = pass;
            switch (imp)
            {
                case 0:
                    options.Impersonation = ImpersonationLevel.Anonymous;
                    break;
                case 1:
                    options.Impersonation = ImpersonationLevel.Identify;
                    break;
                case 2:
                    options.Impersonation = ImpersonationLevel.Impersonate;
                    break;
                case 3:
                    options.Impersonation = ImpersonationLevel.Delegate;
                    break;
            }
            switch (auth)
            {
                case 0:
                    options.Authentication = AuthenticationLevel.None;
                    break;
                case 1:
                    options.Authentication = AuthenticationLevel.Call;
                    break;
                case 2:
                    options.Authentication = AuthenticationLevel.Connect;
                    break;
                case 3:
                    options.Authentication = AuthenticationLevel.Packet;
                    break;
                case 4:
                    options.Authentication = AuthenticationLevel.PacketIntegrity;
                    break;
                case 5:
                    options.Authentication = AuthenticationLevel.PacketPrivacy;
                    break;
            }

        }

        private static ManagementScope getScope(string target, bool subscription)
        {
            ManagementScope scope;
            if (subscription)
                scope = new ManagementScope("\\\\" + target + "\\Root\\subscription", options);
            else
                scope = new ManagementScope("\\\\" + target + "\\Root\\CIMV2", options);
            try
            {
                scope.Connect();
            }
            //user credentials cannot be used in local connections
            catch (ManagementException)
            {
                scope.Options = new ConnectionOptions();
                scope.Connect();
            }
            catch (UnauthorizedAccessException)
            {
                //scope refers to local ip. If credential in options a different from current user credentials,
                //it will cause an 'access denied' exception
                if (IPHandler.get_local_ip().Equals(target) || target.Equals("127.0.0.1"))
                {
                    scope.Options = new ConnectionOptions();
                    scope.Connect();
                }
                else
                {
                    //access denied (wrong credentials)
                    return null;
                }
            }
            //RPC server is unavaliable
            catch (System.Runtime.InteropServices.COMException e)
            {
                return null;
            }

            return scope;
        }

        public static TreeNode collect(WMI_class wmicl, string target)
        {
            ManagementScope ms = getScope(target,false);
            if (ms == null)
                return null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmicl.query);
            searcher.Scope = ms;
            return wmicl.form_output(searcher.Get());
        }

        public static string[] collect_target_info(WMI_class wmicl, string target)
        {
            ManagementScope ms = getScope(target, false);
            if (ms == null)
                return null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmicl.query);
            searcher.Scope = ms;
            return wmicl.form_target_data(searcher.Get());
        }

        public static string[] handle(string target, WMI_class wmicl, EventArrivedEventArgs args)
        {
            ManagementBaseObject obj = (ManagementBaseObject)args.NewEvent["TargetInstance"];
            string[] evt = new string[3];
            evt[0] = target;
            evt[1] = obj["Name"].ToString();
            evt[2] = ManagementDateTimeConverter.ToDateTime(obj["LastModified"].ToString()).ToString();
            return evt;
        }

        public static void terminate_process(string target, string name, string id)
        {
            ManagementScope ms = getScope(target,false);
            if (ms == null)
                return;
            string query = "select * from Win32_Process where ";
            if (!id.Contains("NULL"))
                query += "handle = " + id + " and ";
            query += "name = '" + name + "'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;

            foreach (ManagementObject obj in searcher.Get())
            {
                obj.InvokeMethod("Terminate", null);
            }
        }

        public static object exec_by_object(string target, string query, string method, object[] args)
        {
            ManagementScope ms = getScope(target,false);
            if (ms == null)
                return null;
            query = "Select * from " + query;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            searcher.Scope = ms;
            object respond = null;
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                    respond = obj.InvokeMethod(method, args);
            }
            catch (ManagementException)
            {
                respond = 0xfff;
            }
            return respond;
        }

        public static object create_obj(string target, string query, object[] args)
        {
            ManagementScope ms = getScope(target,false);
            if (ms == null)
                return null;
            ManagementClass mclass = new ManagementClass(query);
            mclass.Scope = ms;
            return mclass.InvokeMethod("Create", args);
        }

        public static ManagementEventWatcher configure_watcher(string target, WMI_class resource, int event_type)
        {
            string operation = "";
            switch (event_type)
            {
                case 0:
                    operation = "__InstanceCreationEvent";
                    break;
                case 1:
                    operation = "__InstanceModificationEvent";
                    break;
                case 2:
                    operation = "__InstanceDeletionEvent";
                    break;
            }
            ManagementScope ms = getScope(target,false);
            if (ms == null)
                return null;
            WqlEventQuery query = new WqlEventQuery(operation, new TimeSpan(0, 0, 5), resource.event_condition);
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            watcher.Query = query;
            watcher.Scope = ms;
            return watcher;
        }

        public static string[] create_consumer(string target, WMI_class resource, string logfile, int event_type)
        {
            ManagementScope ms = getScope(target,true);
            if (ms == null)
                return null;
            ManagementClass wmiEventFilter = new ManagementClass(ms, new ManagementPath("__EventFilter"), null);
            string condition = resource.event_condition;
            string operation = resource.event_types[resource.event_index];
            switch (event_type)
            {
                case 0:
                    operation = "Creation";
                    break;
                case 1:
                    operation = "Modification";
                    break;
                case 2:
                    operation = "Deletion";
                    break;
            }
            Random rand = new Random();
            int id = rand.Next(1024);
            string name = operation + resource.consumer_name;
            WqlEventQuery eventQuery = new WqlEventQuery("Select * FROM __Instance" + operation + "Event WITHIN 5 Where " + condition);
            ManagementObject filter = wmiEventFilter.CreateInstance();
            filter["Name"] = id + ":" + name + "Filter";
            filter["Query"] = eventQuery.QueryString;
            filter["QueryLanguage"] = eventQuery.QueryLanguage;
            filter["EventNameSpace"] = "\\root\\cimv2";
            filter.Put();

            ManagementClass wmiEventConsumer = new ManagementClass(ms, new ManagementPath("LogFileEventConsumer"), null);
            ManagementObject consumer = wmiEventConsumer.CreateInstance();
            consumer["Name"] = id + ":" + name + "Consumer";
            consumer["FileName"] = logfile;
            consumer["Text"] = string.Format(resource.logging_stub, resource.event_stub[resource.event_index]);
            consumer.Put();

            ManagementObject binding = new ManagementClass(ms, new ManagementPath("__FilterToConsumerBinding"), null).CreateInstance();
            binding["Filter"] = filter.Path.RelativePath;
            binding["Consumer"] = consumer.Path.RelativePath;
            binding.Put();
            return new string[] { target, id.ToString(), name + "Consumer" };
        }

        public static void delete_consumer(string target, string consumerName)
        {
            ManagementScope scope = getScope(target,true);
            ManagementClass wmiEventFilter = new ManagementClass(scope, new
            ManagementPath("__EventFilter"), null);
            ManagementObject filter = wmiEventFilter.CreateInstance();
            filter["Name"] = consumerName + "Filter";
            filter.Delete();
            ManagementObject consumer = new ManagementClass(scope, new ManagementPath("LogFileEventConsumer"), null).CreateInstance();
            consumer["Name"] = consumerName + "Consumer";
            consumer.Delete();
        }
 
    }
}
