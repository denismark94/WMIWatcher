using System;
using System.Drawing;
using System.Windows.Forms;
using WMIWatcher.Forms;

namespace WMIWatcher.Engine
{
    public partial class DomainDialog : Form
    {
        private bool loginEntered = false;
        private bool passwordEntered = false;
        private bool join = true;

        public DomainDialog(bool join)
        {
            this.join = join;
            InitializeComponent();
            if (!join)
                domain_name.ReadOnly = true;
            login.ForeColor = Color.Gray;
            password.ForeColor = Color.Gray;
        }

        private void login_Enter(object sender, EventArgs e)
        {
            if (!loginEntered)
            {
                login.ForeColor = Color.Black;
                login.Text = "";
            }
            loginEntered = true;
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                login.ForeColor = Color.Gray;
                login.Text = "Логин";
                loginEntered = false;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (!passwordEntered)
            {
                password.ForeColor = Color.Black;
                password.Text = "";
                password.UseSystemPasswordChar = true;
            }
            passwordEntered = true;
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.ForeColor = Color.Gray;
                password.Text = "Пароль";
                password.UseSystemPasswordChar = false;
                passwordEntered = false;
            }
        }

        private void accept_Click(object sender, EventArgs e)
        {
            if (domain_name.Text == "" && join)
            {
                MessageBox.Show("Введите название домена(группы)");
                return;
            }
            Main main = this.Owner as Main;
            main.domainName = domain_name.Text;
            main.is_domain = checkBox1.Checked;
            if (login.Text != "" && loginEntered)
            {
                if (password.Text != "" && passwordEntered)
                {
                    main.dcUser = login.Text;
                    main.dcPassword = password.Text;
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                    return;
                }
            }
            else
            {
                if (password.Text != "" && passwordEntered)
                {
                    MessageBox.Show("Введите логин");
                    return;
                }
            }
            Close();
        }



    }
}
