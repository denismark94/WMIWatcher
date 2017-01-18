namespace WMIWatcher.Forms
{
    partial class FileSearchDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSearchDialog));
            this.Extension = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Extension
            // 
            this.Extension.Location = new System.Drawing.Point(15, 61);
            this.Extension.Name = "Extension";
            this.Extension.Size = new System.Drawing.Size(154, 20);
            this.Extension.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Расширение";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(15, 22);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(154, 20);
            this.Path.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Путь к отслеживаемой папке";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(15, 88);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(154, 23);
            this.confirm.TabIndex = 21;
            this.confirm.Text = "Подтвердить";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // FileSearchDialog
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 132);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.Extension);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(200, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 170);
            this.Name = "FileSearchDialog";
            this.Text = "Директория";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Extension;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button confirm;
    }
}