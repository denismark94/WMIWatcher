namespace WMIWatcher.Engine
{
    partial class DomainDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DomainDialog));
            this.accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.domain_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(15, 140);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(168, 23);
            this.accept.TabIndex = 3;
            this.accept.Text = "Применить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название домена (группы)";
            // 
            // domain_name
            // 
            this.domain_name.Location = new System.Drawing.Point(15, 25);
            this.domain_name.Name = "domain_name";
            this.domain_name.Size = new System.Drawing.Size(168, 20);
            this.domain_name.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Данные пользователя";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(15, 114);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(168, 20);
            this.password.TabIndex = 2;
            this.password.Text = "Пароль";
            this.password.Enter += new System.EventHandler(this.password_Enter);
            this.password.Leave += new System.EventHandler(this.password_Leave);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(15, 87);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(168, 20);
            this.login.TabIndex = 1;
            this.login.Text = "Логин";
            this.login.Enter += new System.EventHandler(this.login_Enter);
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Домен";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DomainDialog
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 177);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.domain_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(211, 215);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(211, 215);
            this.Name = "DomainDialog";
            this.Text = "Домен/Рабочая группа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox domain_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}