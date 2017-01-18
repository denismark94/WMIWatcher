using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WMIWatcher.Forms
{
    public partial class FileSearchDialog : Form
    {
        public FileSearchDialog()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            string rgx = "^[a-zA-Z]:((\\\\[^\\\\/\\:\\?\"\\<\\>\\|]+)+|\\\\)$";
            if (Path.Text == "")
            {
                MessageBox.Show("Введите путь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(Path.Text, rgx))
            {
                MessageBox.Show("Неправильно введен путь\nПример: C:\\Users\\admin", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            char drive = Path.Text[0];
            string path = Path.Text.Substring(2);
            if (path == "\\")
                path += '.';
            string extension = Extension.Text.Replace(".", "");
            Main main = this.Owner as Main;
            if (main != null)
            {
                main.ext = extension;
                main.path = path;
                main.drive = drive;
            }
            this.Close();
        }
    }
}
