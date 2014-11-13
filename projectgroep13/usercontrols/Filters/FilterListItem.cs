using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Bits
{
    public partial class FilterListItem : InfoContainer
    {
        public Label CloseButton
        {
            get { return lblRemove; }
        }

        public FilterListItem()
        {
            InitializeComponent();

            Status = InfoContainerStatus.Custom;
            CustomColor = Color.FromArgb(180, 180, 200);
        }

        private void lblRemove_MouseEnter(object sender, EventArgs e)
        {
            lblRemove.ForeColor = Color.White;
        }

        private void lblRemove_MouseLeave(object sender, EventArgs e)
        {
            lblRemove.ForeColor = Color.Black;
        }

        public virtual void UpdateFilters(){}

    }
}
