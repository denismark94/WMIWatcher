using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMIWatcher.Engine
{
    class WMI_Device: WMI_class
    {
        public WMI_Device()
        {
            this.query = det_query("CIM_LogicalDevice");
            this.summary = "Обнаружено устройств: ";
            this.stub = new string[] {"ID: DeviceID" };
            this.fields = new string[] {"DeviceID"};
        }
    }
}
