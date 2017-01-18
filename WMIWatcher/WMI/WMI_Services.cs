using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIWatcher.Engine
{
    class WMI_Services : WMI_class
    {
        public WMI_Services(int type)
        {
            switch (type)
            {
                case 0:
                    this.query = det_query("Win32_Service");
                    this.summary = "Всего";
                    this.stub = new string[] { "Статус: State" };
                    this.fields = new string[] { "State" };
                    break;
                case 1:
                    this.query = det_query("Win32_Service", "State = \"{0}\"");
                    this.query = string.Format(this.query, "Running");
                    this.summary = "Активных";
                    break;
                case 2:
                    this.query = det_query("Win32_Service", "State = \"{0}\"");
                    this.query = string.Format(this.query, "Stopped");
                    this.summary = "Приостановленных";
                    break;
            }
            this.summary += " служб: ";
            this.event_condition = det_condition("Win32_Service");

            this.consumer_name = "Service";
            this.event_stub = new string[] {"Создана", "Изменена","Удалена"};
            this.logging_stub = "[%TargetInstance.State%]: {0} служба %TargetInstance.Name%";

        }

        public override string[] handle_event(ManagementBaseObject obj)
        {
            string es = "";
            switch (event_index)
            {
                case 0:
                    es = "Создана";
                    break;

                case 2:
                    es = "Удалена";
                    break;
            }

            string name = (string)((ManagementBaseObject)obj["TargetInstance"])[event_name];
            string time = time = DateTime.Now.ToString(); ;
            bool started = (bool)((ManagementBaseObject)obj["TargetInstance"])["Started"];
            if (event_index == 1)
                if (started)
                    es = "Запущена";
                else
                    es = "Приостановлена";
            return new string[] { null, es, name, time };
        }
    }
}
