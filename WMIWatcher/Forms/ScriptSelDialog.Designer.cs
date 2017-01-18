namespace WMIWatcher.Forms
{
    partial class ScriptSelDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptSelDialog));
            this.Path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(15, 25);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(165, 20);
            this.Path.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Путь к exe/cmd/bat файлу";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScriptSelDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 85);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(207, 123);
            this.MinimumSize = new System.Drawing.Size(207, 123);
            this.Name = "ScriptSelDialog";
            this.Text = "Скрипт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}