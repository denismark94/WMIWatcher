namespace WMIWatcher.Engine
{
    class WMI_ComputerSystem: WMI_class
    {
        public WMI_ComputerSystem()
        {
            this.query = det_query("Win32_ComputerSystem");
            this.fields = new string[] { "Name", "Manufacturer",
                "Domain", "Model", "UserName", "TotalPhysicalMemory" };
        }
    }
}
