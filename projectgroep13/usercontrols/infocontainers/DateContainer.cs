using System;
using System.Windows.Forms;

namespace GUI_Bits
{
    public class DateContainer : InfoContainer
    {
        private DateTime d;
        private Timer t = new Timer();

        public DateTime Date
        {
            get { return d; }
            set
            {
                d = value;
                UpdateText();
            }
        }

        public DateContainer() : this(DateTime.Now) { }
        public DateContainer(DateTime date)
        {
            Date = date;
            t.Interval = 1000;
            t.Tick += new System.EventHandler(tTick);
            t.Start();
        }

        private int HoursLeft()
        {
            return (int)(Date - DateTime.Now).TotalHours;
        }

        private void UpdateText()
        {
            int h = HoursLeft();
            if (h > 23) {
                Text = string.Format("{0:g}", Date);
                Status = InfoContainerStatus.OK;
                ToolTipText = string.Format("Event starts on {0:d}, at {0:t}.\nThere's still plenty of time to join.", Date);
            } else if (h >= 0) {
                Text = string.Format("{0:hh':'mm':'ss}", DateTime.Now - Date);
                if (h < 2) Status = InfoContainerStatus.Critical;
                else Status = InfoContainerStatus.Warning;
                ToolTipText = string.Format("Event starts today, at {0:t}!", Date);
            } else {
                Text = string.Format("{0:d}", Date);
                Status = InfoContainerStatus.Error;
                ToolTipText = string.Format("Event started on {0:d}, at {0:t}.\nJoining is no longer possible.", Date);
                t.Stop();
            }
            RedrawContents();
        }

        private void tTick(object sender, System.EventArgs e)
        {
            if (HoursLeft() > 23) t.Interval = 10000;
            UpdateText();
        }

    }
}