using System;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class RenameDialog : Form
    {
        public RenameDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите NetBIOS-имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TargetData td = Owner as TargetData;
            td.new_name = textBox1.Text;
            Close();
        }
    }
}
