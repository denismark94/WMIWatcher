using System;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class Shutdown_Form : Form
    {
        public Shutdown_Form()
        {
            InitializeComponent();
            type.DropDownStyle = ComboBoxStyle.DropDownList;
            type.SelectedIndex = 0;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            if (type.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Main main = (Main)Owner;
            int type_index = 0;
            switch (type.SelectedIndex)
            {
                case 0:
                    type_index = 0;
                    break;
                case 1:
                    type_index = 2;
                    break;
                case 2:
                    type_index = 4;
                    break;
            }
            if (force.Checked)
                type_index += 4;
            main.control = type_index;
            Close();
        }
    }
}
