using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Bits
{
    public partial class InfoContainer : UserControl
    {
        protected ToolTip tt = new ToolTip();
        private bool hl = false;

        public InfoContainer() : this(""){}
        public InfoContainer(string s)
        {
            InitializeComponent();

            this.Text = s;
            this.DoubleBuffered = true;
            this.TextChanged += new EventHandler(OnTextChanged);
            this.TextAlign = StringAlignment.Center;
        }

        public InfoContainerStatus Status { get; set; }
        public bool Highlit {
            get { return hl; }
            set { hl = value; RedrawContents(); }
        }
        public Color CustomColor { get; set; }
        public StringAlignment TextAlign { get; set; }

        private void OnTextChanged(object sender, EventArgs e)
        {
            RedrawContents();
        }

        public string ToolTipText {
            get { return tt.GetToolTip(this); }
            set { tt.SetToolTip(this, value); }
        }

        public Color DefaultColour()
        {
            switch (Status) {
                case InfoContainerStatus.OK: return Color.FromArgb(50, 180, 50);
                case InfoContainerStatus.Custom: return CustomColor;
                case InfoContainerStatus.Warning: return Color.FromArgb(230, 230, 0);
                case InfoContainerStatus.Critical: return Color.FromArgb(230, 80, 20);
                case InfoContainerStatus.Error: return Color.FromArgb(200, 20, 20);
            }
            return Color.Gray;
        }

        public Color HighlightColour()
        {
            Color c = DefaultColour();
            double r,g,b;
            r = c.R * 1.5; if (r > 255) r = 255;
            g = c.G * 1.5; if (g > 255) g = 255;
            b = c.B * 1.5; if (b > 255) b = 255;
            return Color.FromArgb((byte)r, (byte)g, (byte)b);
        }

        public bool RequiresAttention()
        {
            if (Status == InfoContainerStatus.Error) return true;
            //else if (Status == InfoContainerStatus.Critical) return true;
            //else if (Status == InfoContainerStatus.Warning) return true;
            return false;
        }

        public void RedrawContents()
        {
            DrawBackground();
            DrawIcons();
            DrawText();
        }

        private void DrawBackground()
        {
            Color c;
            if (Highlit) c = HighlightColour();
            else c = DefaultColour();
            this.BackgroundImage = FancyRectangle.Create(this.Width, this.Height, c);
        }

        protected virtual void DrawIcons() { }

        protected virtual void DrawText()
        {
            Graphics gr = Graphics.FromImage(this.BackgroundImage);
            Rectangle r = new Rectangle(10, 0, this.Width-10, this.Height);
            StringFormat sf = new StringFormat();
            sf.Alignment = TextAlign;
            sf.LineAlignment = StringAlignment.Center;
            gr.DrawString(this.Text, this.Font, Brushes.White, r, sf);
            gr.Dispose();
        }

        private void InfoContainer_SizeChanged(object sender, EventArgs e)
        {
            RedrawContents();
        }

    }

    public enum InfoContainerStatus
    {
        Default,
        Custom,
        OK,
        Warning,
        Critical,
        Error
    }

}
