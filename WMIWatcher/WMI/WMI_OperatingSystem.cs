namespace WMIWatcher.Engine
{
    class WMI_OperatingSystem: WMI_class
    {
        public WMI_OperatingSystem()
        {
            this.query = det_query("Win32_OperatingSystem");
            this.fields = new string[] { "Caption", "InstallDate", "LastBootUpTime",
                "NumberOfUsers", "SerialNumber"};
        }

    }
}
