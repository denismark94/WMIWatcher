namespace WMIWatcher
{
    partial class AddIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIP));
            this.octet1 = new System.Windows.Forms.TextBox();
            this.octet2 = new System.Windows.Forms.TextBox();
            this.octet3 = new System.Windows.Forms.TextBox();
            this.octet4 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.f_oct_4 = new System.Windows.Forms.TextBox();
            this.f_oct_2 = new System.Windows.Forms.TextBox();
            this.f_oct_1 = new System.Windows.Forms.TextBox();
            this.f_oct_3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.s_oct_4 = new System.Windows.Forms.TextBox();
            this.s_oct_2 = new System.Windows.Forms.TextBox();
            this.s_oct_1 = new System.Windows.Forms.TextBox();
            this.s_oct_3 = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // octet1
            // 
            this.octet1.Location = new System.Drawing.Point(9, 45);
            this.octet1.MaxLength = 3;
            this.octet1.Name = "octet1";
            this.octet1.Size = new System.Drawing.Size(31, 20);
            this.octet1.TabIndex = 1;
            this.octet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.octet1.TextChanged += new System.EventHandler(this.octet1_TextChanged);
            // 
            // octet2
            // 
            this.octet2.Location = new System.Drawing.Point(41, 45);
            this.octet2.MaxLength = 3;
            this.octet2.Name = "octet2";
            this.octet2.Size = new System.Drawing.Size(31, 20);
            this.octet2.TabIndex = 2;
            this.octet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.octet2.TextChanged += new System.EventHandler(this.octet2_TextChanged);
            // 
            // octet3
            // 
            this.octet3.Location = new System.Drawing.Point(73, 45);
            this.octet3.MaxLength = 3;
            this.octet3.Name = "octet3";
            this.octet3.Size = new System.Drawing.Size(31, 20);
            this.octet3.TabIndex = 3;
            this.octet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.octet3.TextChanged += new System.EventHandler(this.octet3_TextChanged);
            // 
            // octet4
            // 
            this.octet4.Location = new System.Drawing.Point(105, 45);
            this.octet4.MaxLength = 3;
            this.octet4.Name = "octet4";
            this.octet4.Size = new System.Drawing.Size(31, 20);
            this.octet4.TabIndex = 4;
            this.octet4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(154, 108);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.octet4);
            this.tabPage1.Controls.Add(this.octet1);
            this.tabPage1.Controls.Add(this.octet3);
            this.tabPage1.Controls.Add(this.octet2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(146, 82);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Один адрес";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "IPv4 адрес цели";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.f_oct_4);
            this.tabPage2.Controls.Add(this.f_oct_2);
            this.tabPage2.Controls.Add(this.f_oct_1);
            this.tabPage2.Controls.Add(this.f_oct_3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.s_oct_4);
            this.tabPage2.Controls.Add(this.s_oct_2);
            this.tabPage2.Controls.Add(this.s_oct_1);
            this.tabPage2.Controls.Add(this.s_oct_3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(146, 82);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Диапазон";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Конечный адрес";
            // 
            // f_oct_4
            // 
            this.f_oct_4.Location = new System.Drawing.Point(106, 54);
            this.f_oct_4.MaxLength = 3;
            this.f_oct_4.Name = "f_oct_4";
            this.f_oct_4.Size = new System.Drawing.Size(31, 20);
            this.f_oct_4.TabIndex = 8;
            this.f_oct_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // f_oct_2
            // 
            this.f_oct_2.Location = new System.Drawing.Point(42, 54);
            this.f_oct_2.MaxLength = 3;
            this.f_oct_2.Name = "f_oct_2";
            this.f_oct_2.Size = new System.Drawing.Size(31, 20);
            this.f_oct_2.TabIndex = 6;
            this.f_oct_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.f_oct_2.TextChanged += new System.EventHandler(this.f_oct_2_TextChanged);
            // 
            // f_oct_1
            // 
            this.f_oct_1.Location = new System.Drawing.Point(10, 54);
            this.f_oct_1.MaxLength = 3;
            this.f_oct_1.Name = "f_oct_1";
            this.f_oct_1.Size = new System.Drawing.Size(31, 20);
            this.f_oct_1.TabIndex = 5;
            this.f_oct_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.f_oct_1.TextChanged += new System.EventHandler(this.f_oct_1_TextChanged);
            // 
            // f_oct_3
            // 
            this.f_oct_3.Location = new System.Drawing.Point(74, 54);
            this.f_oct_3.MaxLength = 3;
            this.f_oct_3.Name = "f_oct_3";
            this.f_oct_3.Size = new System.Drawing.Size(31, 20);
            this.f_oct_3.TabIndex = 7;
            this.f_oct_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.f_oct_3.TextChanged += new System.EventHandler(this.f_oct_3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Начальный адрес";
            // 
            // s_oct_4
            // 
            this.s_oct_4.Location = new System.Drawing.Point(106, 18);
            this.s_oct_4.MaxLength = 3;
            this.s_oct_4.Name = "s_oct_4";
            this.s_oct_4.Size = new System.Drawing.Size(31, 20);
            this.s_oct_4.TabIndex = 4;
            this.s_oct_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_oct_4.TextChanged += new System.EventHandler(this.s_oct_4_TextChanged);
            // 
            // s_oct_2
            // 
            this.s_oct_2.Location = new System.Drawing.Point(42, 18);
            this.s_oct_2.MaxLength = 3;
            this.s_oct_2.Name = "s_oct_2";
            this.s_oct_2.Size = new System.Drawing.Size(31, 20);
            this.s_oct_2.TabIndex = 2;
            this.s_oct_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_oct_2.TextChanged += new System.EventHandler(this.s_oct_2_TextChanged);
            // 
            // s_oct_1
            // 
            this.s_oct_1.Location = new System.Drawing.Point(10, 18);
            this.s_oct_1.MaxLength = 3;
            this.s_oct_1.Name = "s_oct_1";
            this.s_oct_1.Size = new System.Drawing.Size(31, 20);
            this.s_oct_1.TabIndex = 1;
            this.s_oct_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_oct_1.TextChanged += new System.EventHandler(this.s_oct_1_TextChanged);
            // 
            // s_oct_3
            // 
            this.s_oct_3.Location = new System.Drawing.Point(74, 18);
            this.s_oct_3.MaxLength = 3;
            this.s_oct_3.Name = "s_oct_3";
            this.s_oct_3.Size = new System.Drawing.Size(31, 20);
            this.s_oct_3.TabIndex = 3;
            this.s_oct_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.s_oct_3.TextChanged += new System.EventHandler(this.s_oct_3_TextChanged);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 155);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 23);
            this.btnScan.TabIndex = 10;
            this.btnScan.Text = "Сканировать подсеть";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddIp_Click);
            // 
            // AddIP
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 184);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddIP";
            this.Text = "IP-адрес";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox octet1;
        private System.Windows.Forms.TextBox octet2;
        private System.Windows.Forms.TextBox octet3;
        private System.Windows.Forms.TextBox octet4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox f_oct_4;
        private System.Windows.Forms.TextBox f_oct_2;
        private System.Windows.Forms.TextBox f_oct_1;
        private System.Windows.Forms.TextBox f_oct_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox s_oct_4;
        private System.Windows.Forms.TextBox s_oct_2;
        private System.Windows.Forms.TextBox s_oct_1;
        private System.Windows.Forms.TextBox s_oct_3;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
    }
}