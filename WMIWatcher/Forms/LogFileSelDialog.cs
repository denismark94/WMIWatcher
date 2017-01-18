using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class LogFileSelDialog : Form
    {

        string rgx = "^([a-zA-Z]:|)((\\\\[^\\\\/\\:\\?\"\\<\\>\\|]+)+|\\\\).(txt|log|dat)$";
        public LogFileSelDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!Regex.IsMatch(Path.Text, rgx))
            {
                MessageBox.Show("Неправильно введен путь\nПример: C:\\log.txt", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Main main = (Main)Owner;
            main.logfile = Path.Text;
            Close();
        }
    }
}
