using System;
using System.Drawing;
using System.Windows.Forms;

using ProjectGroep13;

namespace GUI_Bits
{
    public partial class FilterList : UserControl
    {
        private ButtonContainer addnewfilter;
        private const int maxcount = 8;

        public FilterList()
        {
            InitializeComponent();

            addnewfilter = new ButtonContainer("ADD FILTER");
            addnewfilter.Click += AddFilterButtonClick;

            this.Add(new NotFullFilter());
            this.Add(new DateFilter());
            pFilters.Controls.Add(addnewfilter);
        }

        public ButtonContainer FilterButton
        {
            get { return btnFilter; }
        }

        public ButtonContainer ReportButton
        {
            get { return btnReport; }
        }

        public void Add(FilterListItem fli)
        {
            fli.Width = this.Width;
            fli.CloseButton.Click += RemoveItem;
            pFilters.Controls.Add(fli);
        }

        public void Clear()
        {
            pFilters.Controls.Clear();
            pFilters.Controls.Add(addnewfilter);
        }

        public void UpdateFilters()
        {
            Filters.Instance.Reset();
            foreach (InfoContainer fli in pFilters.Controls) {
                if (fli is ButtonContainer) continue;
                ((FilterListItem)fli).UpdateFilters();
            }
        }

        private void DoCountCheck()
        {
            addnewfilter.Visible = (pFilters.Controls.Count < maxcount);
        }

        private void RedrawItems()
        {
            addnewfilter.SendToBack();
            int yPos = 0;
            int count = pFilters.Controls.Count;
            for (int i = 0; i < count; i++) {
                InfoContainer fli = (InfoContainer)pFilters.Controls[i];
                fli.Location = new Point(0, yPos);
                fli.Width = this.Width;
                yPos += fli.Height;
            }
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            FilterListItem fli = (FilterListItem)(l.Parent);
            pFilters.Controls.Remove(fli);
        }

        private void AddFilterButtonClick(object sender, EventArgs e)
        {
            NewFilterDialog nfd = new NewFilterDialog();
            nfd.ShowDialog();
            if (nfd.DialogResult == DialogResult.OK) Add(nfd.SelectedItem());
        }

        private void FilterList_SizeChanged(object sender, EventArgs e)
        {
            RedrawItems();
        }

        private void pFilters_ControlAdded(object sender, ControlEventArgs e)
        {
            DoCountCheck();
            RedrawItems();
            UpdateFilters();
        }

        private void pFilters_ControlRemoved(object sender, ControlEventArgs e)
        {
            DoCountCheck();
            RedrawItems();
            UpdateFilters();
        }

    }

}
