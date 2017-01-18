namespace WMIWatcher.Engine
{
    class WMI_DriveInfo: WMI_class
    {
        public WMI_DriveInfo()
        {
            this.query = det_query("Win32_DiskDrive");
            this.summary = "Запоминающих устройств: ";
            this.name = "Caption";
            this.stub = new string[] {"Интерфейс: InterfaceType","Тип медиа: MediaType",
                "Количество разделов: Partitions","Серийный номер: SerialNumber","Объем: Size байт" };
            this.fields = new string[] {"InterfaceType", "MediaType", "Partitions", "SerialNumber", "Size" };

            this.event_condition = det_condition("Win32_DiskDrive");
            this.event_name = "Caption";
            this.event_time = "InstallDate";
            this.event_stub = new string[] { "Подлючено", "Изменено","Извлечено" };

            this.logging_stub = "[%TargetInstance.InstallDate%]: {0} запоминающее устройство: %TargetInstance.Caption%";
            this.consumer_name = "Drive";
        }
    }
}
