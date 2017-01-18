namespace WMIWatcher.Engine
{
    class WMI_FileInfo : WMI_class
    {
        public WMI_FileInfo(string extension, char drive, string path)
        {
            string conds = "TargetInstance.Extension = '{0}' and TargetInstance.Drive = '{1}:' and TargetInstance.Path = '{2}\\\\'";
            this.query = det_query("CIM_DataFile", conds.Replace("TargetInstance.",""));
            this.query = string.Format(this.query, extension, drive, path.Replace("\\","\\\\"));
            this.summary = "Файлов с расширением {0} в \"{1}:{2}\": ";
            this.summary = string.Format(summary, extension, drive, path.Replace(".", ""));

            this.event_condition = det_condition("CIM_DataFile", conds);
            this.event_condition = string.Format(this.event_condition, extension, drive, path.Replace("\\", "\\\\"));
            this.event_time = "LastModified";
            this.event_stub = new string[] { "Создан", "Изменен", "Удален" };

            this.logging_stub = "[%TargetInstance.CreationDate%]: {0} файл: %TargetInstance.Name%";
            this.consumer_name = "File";

        }

    }
}
