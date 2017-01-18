namespace WMIWatcher.Forms
{
    partial class TimeRangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeRangeForm));
            this.track_bar = new System.Windows.Forms.TrackBar();
            this.accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.range = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.range)).BeginInit();
            this.SuspendLayout();
            // 
            // track_bar
            // 
            this.track_bar.Location = new System.Drawing.Point(3, 12);
            this.track_bar.Maximum = 48;
            this.track_bar.Name = "track_bar";
            this.track_bar.Size = new System.Drawing.Size(276, 45);
            this.track_bar.TabIndex = 0;
            this.track_bar.Scroll += new System.EventHandler(this.track_bar_Scroll);
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(169, 44);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(97, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "Применить";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Часов";
            // 
            // range
            // 
            this.range.Location = new System.Drawing.Point(12, 47);
            this.range.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(55, 20);
            this.range.TabIndex = 4;
            this.range.ValueChanged += new System.EventHandler(this.range_ValueChanged);
            // 
            // TimeRangeForm
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 79);
            this.Controls.Add(this.range);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.track_bar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(294, 117);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(294, 117);
            this.Name = "TimeRangeForm";
            this.Text = "Временной диапазон";
            ((System.ComponentModel.ISupportInitialize)(this.track_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.range)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar track_bar;
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown range;
    }
}