

namespace WMIWatcher.Engine
{
    class WMI_Apps : WMI_class
    {
        public WMI_Apps()
        {
            this.query = det_query("Win32_Product");
            this.summary = "Установленных приложений: ";
            this.stub = new string[] {"Версия: Version", "Производитель: Vendor" };
            this.fields = new string[] {"Version", "Vendor" };
        }
    }
}
