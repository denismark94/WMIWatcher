
namespace WMIWatcher.Engine
{
    class WMI_Startup : WMI_class
    {
        public WMI_Startup()
        {
            this.query = det_query("Win32_StartupCommand");
            this.summary = "Объектов автозагрузки: ";
            this.name = "Caption";
            this.stub = new string[] { "Команда: Command", "Расположение: Location" };
            this.fields = new string[] {"Command", "Location"};
        }
    }
}
