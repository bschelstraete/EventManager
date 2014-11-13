using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Bits
{
    public partial class InfoContainerList : UserControl
    {
        private List<InfoContainer> items = new List<InfoContainer>();

        public InfoContainerList()
        {
            InitializeComponent();
        }

        public void Add(InfoContainer ic)
        {
            ic.Width = this.Width;
            items.Add(ic);
            ResetItems();
        }

        public void ResetItems()
        {
            int yPos = 0;
            for (int i = 0; i < items.Count; i++) {
                InfoContainer ic = items[i];
                ic.Location = new Point(0, yPos);
                this.Controls.Add(ic);
                yPos += items[i].Height;
            }
            this.Invalidate();
        }

        public void Clear()
        {
            items.Clear();
            this.Controls.Clear();
        }

        private void InfoContainerList_Resize(object sender, EventArgs e)
        {
            foreach (InfoContainer ic in this.Controls) ic.Width = this.Width;
        }
    }
}
