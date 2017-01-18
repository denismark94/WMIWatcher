namespace WMIWatcher.Forms
{
    partial class Shutdown_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shutdown_Form));
            this.accept = new System.Windows.Forms.Button();
            this.force = new System.Windows.Forms.CheckBox();
            this.type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(12, 75);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(142, 23);
            this.accept.TabIndex = 7;
            this.accept.Text = "Применить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // force
            // 
            this.force.AutoSize = true;
            this.force.Location = new System.Drawing.Point(12, 52);
            this.force.Name = "force";
            this.force.Size = new System.Drawing.Size(104, 17);
            this.force.TabIndex = 6;
            this.force.Text = "Принудительно";
            this.force.UseVisualStyleBackColor = true;
            // 
            // type
            // 
            this.type.FormattingEnabled = true;
            this.type.Items.AddRange(new object[] {
            "Выход из системы",
            "Перезагрузка",
            "Выключение"});
            this.type.Location = new System.Drawing.Point(12, 25);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(142, 21);
            this.type.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Тип операции";
            // 
            // Shutdown_Form
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 105);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.force);
            this.Controls.Add(this.type);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(175, 143);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(175, 143);
            this.Name = "Shutdown_Form";
            this.Text = "Выключение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.CheckBox force;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label1;
    }
}