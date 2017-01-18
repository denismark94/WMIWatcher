namespace WMIWatcher
{
    partial class IPadresses
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
            this.IpList = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.BtnFormList = new System.Windows.Forms.Button();
            this.BtnMarkAll = new System.Windows.Forms.Button();
            this.btnUnmarkAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IpList
            // 
            this.IpList.FormattingEnabled = true;
            this.IpList.Items.AddRange(new object[] {
            "192.168.1.1",
            "192.168.1.2",
            "192.168.1.3",
            "192.168.1.4",
            "192.168.1.5",
            "192.168.1.6",
            "192.168.1.7",
            "192.168.1.8",
            "192.168.1.9",
            "192.168.1.37"});
            this.IpList.Location = new System.Drawing.Point(12, 2);
            this.IpList.Name = "IpList";
            this.IpList.Size = new System.Drawing.Size(108, 244);
            this.IpList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(126, 135);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "Удалить";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // BtnFormList
            // 
            this.BtnFormList.Location = new System.Drawing.Point(126, 223);
            this.BtnFormList.Name = "BtnFormList";
            this.BtnFormList.Size = new System.Drawing.Size(87, 23);
            this.BtnFormList.TabIndex = 3;
            this.BtnFormList.Text = "Применить";
            this.BtnFormList.UseVisualStyleBackColor = true;
            this.BtnFormList.Click += new System.EventHandler(this.BtnFormList_Click);
            // 
            // BtnMarkAll
            // 
            this.BtnMarkAll.Location = new System.Drawing.Point(126, 12);
            this.BtnMarkAll.Name = "BtnMarkAll";
            this.BtnMarkAll.Size = new System.Drawing.Size(87, 23);
            this.BtnMarkAll.TabIndex = 4;
            this.BtnMarkAll.Text = "Выбрать все";
            this.BtnMarkAll.UseVisualStyleBackColor = true;
            this.BtnMarkAll.Click += new System.EventHandler(this.BtnMarkAll_Click);
            // 
            // btnUnmarkAll
            // 
            this.btnUnmarkAll.Location = new System.Drawing.Point(126, 41);
            this.btnUnmarkAll.Name = "btnUnmarkAll";
            this.btnUnmarkAll.Size = new System.Drawing.Size(87, 23);
            this.btnUnmarkAll.TabIndex = 5;
            this.btnUnmarkAll.Text = "Снять выбор";
            this.btnUnmarkAll.UseVisualStyleBackColor = true;
            this.btnUnmarkAll.Click += new System.EventHandler(this.btnUnmarkAll_Click);
            // 
            // IPadresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 262);
            this.Controls.Add(this.btnUnmarkAll);
            this.Controls.Add(this.BtnMarkAll);
            this.Controls.Add(this.BtnFormList);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.IpList);
            this.Name = "IPadresses";
            this.Text = "Клиенты";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox IpList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button BtnFormList;
        private System.Windows.Forms.Button BtnMarkAll;
        private System.Windows.Forms.Button btnUnmarkAll;
    }
}