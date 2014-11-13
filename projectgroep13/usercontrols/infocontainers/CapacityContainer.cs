using System;
using System.Drawing;

namespace GUI_Bits
{
    public class CapacityContainer : InfoContainer
    {
        int cap = 1, occ = 0, min = 1;

        public int Capacity
        {
            get { return cap; }
            set
            {
                cap = value;
                if (cap <= 0) cap = -1;
                if (occ > 0 && occ > cap) throw new Exception("Cannot downsize capacity!");
                UpdateText();
            }
        }
        public int Occupancy
        {
            get { return occ; }
            set
            {
                occ = value;
                UpdateText();
            }
        }
        public int Minimum
        {
            get { return min; }
            set
            {
                min = value;
                if (min < 1) min = 1;
                UpdateText();
            }
        }
        public bool DisplayPercentage { get; set; }

        public CapacityContainer() : this(1, 10, 0) { }
        public CapacityContainer(int max) : this(1, max, 0) { }
        public CapacityContainer(int min, int max) : this(min, max, 0) { }
        public CapacityContainer(int min, int max, int ppl)
        {
            this.min = min;
            this.cap = max;
            Occupancy = ppl;
        }

        private double OccupancyRate()
        {
            if (cap <= 0) return 0.0;
            return (double)occ / (double)cap;
        }

        private void UpdateText()
        {
            int oRate = (int)(OccupancyRate() * 100);

            string o, c;
            if (cap == -1) c = "∞";
            else c = Capacity.ToString();

            if (!DisplayPercentage) o = string.Format("{0}/{1}", Occupancy, c);
            else o = string.Format("{0}%", oRate);

            this.Text = o;

            string s;
            if (occ == 0) {
                s = "No people have joined so far.\nFor shame...";
                Status = InfoContainerStatus.Critical;
            } else if (occ < min) {
                s = "There are not enough people to start this event.";
                Status = InfoContainerStatus.Warning;
            } else if (cap == -1) {
                s = "The more the merrier!";
                Status = InfoContainerStatus.OK;
            } else if (oRate >= 100) {
                s = "All full! We thank all of you for joining!";
                Status = InfoContainerStatus.Error;
            } else if (oRate >= 75) {
                s = "Almost full. Still room for a few more...";
                Status = InfoContainerStatus.Warning;
            } else {
                s = "There are enough people to start this event.\nStill plenty of room for more, though.";
                Status = InfoContainerStatus.OK;
            }
            ToolTipText = string.Format("Minimum: {0}\nJoined: {1}\nCapacity: {2}\n{3}", Minimum, Occupancy, c, s);
            RedrawContents();
        }

        protected override void DrawIcons()
        {
            Graphics gr = Graphics.FromImage(this.BackgroundImage);

            //double o = OccupancyRate();
            //if (o > 0.0) {
            //    int perc = (int)(150.0 * o);
            //    int minX = (int)((double)min / (double)cap * 150.0);

            //    gr.DrawLine(Pens.Red, new Point(minX, 0), new Point(minX, 25));
            //    //gr.FillRectangle(new SolidBrush(OccupancyColor()), 0, 0, perc, 25);
            //}

            for (int i = 0, x = 0, y = 0; i < occ && i < 25; i++, x += 10) {
                if (x > 120) { x -= 125; y++; }
                gr.DrawImage(global::ProjectGroep13.Properties.Resources.iconPerson, new Rectangle(12 + x, 4 + y, 8, 16));
            }
            gr.Dispose();
        }

    }
}