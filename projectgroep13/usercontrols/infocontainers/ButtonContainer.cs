using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Bits
{
    public class ButtonContainer : InfoContainer
    {
        private bool canclick = true;

        public bool Clickable {
            get { return canclick; }
            set {
                canclick = value;
                if (canclick) CustomColor = Color.FromArgb(140, 140, 140);
                else CustomColor = Color.FromArgb(100, 80, 80);
                RedrawContents();
            } 
        }

        public ButtonContainer(string s)
        {
            Status = InfoContainerStatus.Custom;
            CustomColor = Color.FromArgb(140, 140, 140);

            tt.RemoveAll();

            //this.Height = 40;
            this.Text = s;

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StopHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StartHover);
            this.MouseLeave += new System.EventHandler(this.StopHover);
            //this.MouseEnter += new System.EventHandler(this.StartHover);
        }

        private void StartHover()
        {
            if (!Clickable) return;
            Highlit = true;
            Cursor = Cursors.Hand;
        }
        private void StartHover(object sender, EventArgs e) { StartHover(); }
        private void StartHover(object sender, System.Windows.Forms.MouseEventArgs e) { StartHover(); }

        private void StopHover()
        {
            if (!Clickable) return;
            Highlit = false;
        }
        private void StopHover(object sender, EventArgs e) { StopHover(); }
        private void StopHover(object sender, System.Windows.Forms.MouseEventArgs e) { StopHover(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ButtonContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Name = "ButtonContainer";
            this.ResumeLayout(false);

        }

    }
}
