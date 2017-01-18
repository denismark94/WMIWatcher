using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class ScriptSelDialog : Form
    {

        string rgx = "^([a-zA-Z]:|)((\\\\[^\\\\/\\:\\?\"\\<\\>\\|]+)+|\\\\).(bat|exe|cmd)$";
        public ScriptSelDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (!Regex.IsMatch(Path.Text, rgx))
            {
                MessageBox.Show("Неправильно введен путь\nПример: C:\\text.bat", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Main main = (Main)Owner;
            main.scipt = Path.Text;
            Close();
        }
    }
}
