using System;
using System.Windows.Forms;

namespace WMIWatcher.Forms
{
    public partial class TimeRangeForm : Form
    {
        public int time_range = 0;
        public TimeRangeForm()
        {
            InitializeComponent();
            range.Text = track_bar.Value.ToString();
        }

        private void accept_Click(object sender, EventArgs e)
        {
            time_range = int.Parse(range.Text);
            Close();
        }

        private void track_bar_Scroll(object sender, EventArgs e)
        {
            range.Text = track_bar.Value.ToString();
        }

        private void range_ValueChanged(object sender, EventArgs e)
        {
            track_bar.Value = int.Parse(range.Text);
        }
    }
}
