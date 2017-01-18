using System;
using System.Drawing;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class SecuritySettingsForm : Form
    {
        private bool loginEntered = false;
        private bool passwordEntered = false;

        public SecuritySettingsForm()
        {
            InitializeComponent();
            login.ForeColor = Color.Gray;
            password.ForeColor = Color.Gray;
            impersonationLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            impersonationLevel.SelectedIndex = 2;
            authenticationLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            authenticationLevel.SelectedIndex = 3;

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
            if (password.Text=="")
            {
                password.ForeColor = Color.Gray;
                password.Text = "Пароль";
                password.UseSystemPasswordChar = false;
                passwordEntered = false;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (login.Text == "" || !loginEntered)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (password.Text == "" || !passwordEntered)
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            Main main = this.Owner as Main;
            int imp = 2,
                auth = 3;
            if (impersonationLevel.SelectedIndex != -1)
                imp = impersonationLevel.SelectedIndex;
            if (authenticationLevel.SelectedIndex != -1)
                auth = authenticationLevel.SelectedIndex;
            if (integrity.Checked)
                auth++;
            if (pktPrivacy.Checked)
                auth++;
            System.Security.SecureString secpass = new System.Security.SecureString();
            foreach (char i in password.Text)
                secpass.AppendChar(i);
            main.setCredentials(login.Text, secpass,imp,auth);
            this.Close();
        }

        private void authenticationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            integrity.Visible = (authenticationLevel.SelectedIndex == 3);
            if (authenticationLevel.SelectedIndex != 3)
                integrity.Checked = false;
        }

        private void integrity_CheckedChanged(object sender, EventArgs e)
        {
            pktPrivacy.Visible = integrity.Checked;
            if (!integrity.Checked)
                pktPrivacy.Checked = false;
        }

    }
}
