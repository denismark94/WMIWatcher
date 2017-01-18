namespace WMIWatcher.Forms
{
    partial class SecuritySettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecuritySettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.integrity = new System.Windows.Forms.CheckBox();
            this.authenticationLevel = new System.Windows.Forms.ComboBox();
            this.pktPrivacy = new System.Windows.Forms.CheckBox();
            this.impersonationLevel = new System.Windows.Forms.ComboBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(199, 132);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.password);
            this.tabPage1.Controls.Add(this.login);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(191, 106);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки WMI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(30, 61);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(111, 20);
            this.password.TabIndex = 1;
            this.password.Text = "Пароль";
            this.password.Enter += new System.EventHandler(this.password_Enter);
            this.password.Leave += new System.EventHandler(this.password_Leave);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(30, 34);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(111, 20);
            this.login.TabIndex = 0;
            this.login.Text = "Логин";
            this.login.Enter += new System.EventHandler(this.login_Enter);
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Учетная запись WMI";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.integrity);
            this.tabPage2.Controls.Add(this.authenticationLevel);
            this.tabPage2.Controls.Add(this.pktPrivacy);
            this.tabPage2.Controls.Add(this.impersonationLevel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(191, 106);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки DCOM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // integrity
            // 
            this.integrity.AutoSize = true;
            this.integrity.Location = new System.Drawing.Point(6, 61);
            this.integrity.Name = "integrity";
            this.integrity.Size = new System.Drawing.Size(185, 17);
            this.integrity.TabIndex = 6;
            this.integrity.Text = "Контроль целостности пакетов";
            this.integrity.UseVisualStyleBackColor = true;
            this.integrity.Visible = false;
            this.integrity.CheckedChanged += new System.EventHandler(this.integrity_CheckedChanged);
            // 
            // authenticationLevel
            // 
            this.authenticationLevel.FormattingEnabled = true;
            this.authenticationLevel.Items.AddRange(new object[] {
            "Нет",
            "Подключения",
            "Вызовы",
            "Пакеты"});
            this.authenticationLevel.Location = new System.Drawing.Point(6, 34);
            this.authenticationLevel.Name = "authenticationLevel";
            this.authenticationLevel.Size = new System.Drawing.Size(155, 21);
            this.authenticationLevel.TabIndex = 5;
            this.authenticationLevel.Text = "Уровень аутентификации";
            this.authenticationLevel.SelectedIndexChanged += new System.EventHandler(this.authenticationLevel_SelectedIndexChanged);
            // 
            // pktPrivacy
            // 
            this.pktPrivacy.AutoSize = true;
            this.pktPrivacy.Location = new System.Drawing.Point(6, 83);
            this.pktPrivacy.Name = "pktPrivacy";
            this.pktPrivacy.Size = new System.Drawing.Size(135, 17);
            this.pktPrivacy.TabIndex = 7;
            this.pktPrivacy.Text = "Шифрование пакетов";
            this.pktPrivacy.UseVisualStyleBackColor = true;
            this.pktPrivacy.Visible = false;
            // 
            // impersonationLevel
            // 
            this.impersonationLevel.FormattingEnabled = true;
            this.impersonationLevel.Items.AddRange(new object[] {
            "Анонимный доступ",
            "Идентификация",
            "Олицетворение",
            "Делегирование"});
            this.impersonationLevel.Location = new System.Drawing.Point(6, 7);
            this.impersonationLevel.Name = "impersonationLevel";
            this.impersonationLevel.Size = new System.Drawing.Size(155, 21);
            this.impersonationLevel.TabIndex = 4;
            this.impersonationLevel.Text = "Уровень олицетворения";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(132, 146);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "Применить";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // SecuritySettingsForm
            // 
            this.AcceptButton = this.applyBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 175);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(231, 213);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(231, 213);
            this.Name = "SecuritySettingsForm";
            this.Text = "Настройки подключения";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.ComboBox impersonationLevel;
        private System.Windows.Forms.ComboBox authenticationLevel;
        private System.Windows.Forms.CheckBox pktPrivacy;
        private System.Windows.Forms.CheckBox integrity;
        private System.Windows.Forms.Button applyBtn;


    }
}