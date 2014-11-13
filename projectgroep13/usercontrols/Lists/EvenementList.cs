using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectGroep13
{
    public partial class EvenementList : UserControl
    {
        private HashSet<EvenementListItem> items = new HashSet<EvenementListItem>();

        public EvenementList()
        {
            InitializeComponent();

            //this.AdjustFormScrollbars(false);
        }

        public string FilterText
        {
            get { return icFilters.Text; }
            set { icFilters.Text = value; }
        }

        public void UpdateContents()
        {
            Clear();
            Set(Filters.Instance.GetFilteredResults());
            foreach (EvenementListItem eli in items) eli.UpdateContents();
        }

        private void Add(Evenement e)
        {
            EvenementListItem eli = new EvenementListItem(e);
            items.Add(eli);
            eli.LocationUrl.Click += LocationUrl_Click;
            eli.CreatorUrl.Click += CreatorUrl_Click;
            this.Controls.Add(eli);

            Redraw();
        }
        public void Set(List<Evenement> l)
        {
            Clear();
            foreach (Evenement e in l) this.Add(e);
            FilterText = Filters.Instance.FilterText();
        }

        public void Clear()
        {
            items.Clear();
            this.Controls.Clear();
            this.Controls.Add(icFilters);
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void Redraw()
        {
            this.VerticalScroll.Value = 0;
            this.HorizontalScroll.Value = 0;

            if (this.Width > 600) DoubleRowRedraw();
            else SingleRowRedraw();

            this.AdjustFormScrollbars(true);
        }
        private void SingleRowRedraw()
        {
            int y = 2;
            foreach (UserControl uc in this.Controls) {
                uc.Width = this.Width - 24;
                uc.Location = new Point(2, y);
                y += uc.Height + 3;
            }
        }
        private void DoubleRowRedraw()
        {
            int y = 64;
            int xPos = (this.Width / 2)-13;
            for (int x = 1; x < this.Controls.Count; x += 2 ) {
                UserControl uc = (UserControl)this.Controls[x];
                uc.Width = xPos;
                uc.Location = new Point(2, y);
                y += uc.Height + 3;
            }
            y = 64;
            for (int x = 2; x < this.Controls.Count; x += 2) {
                UserControl uc = (UserControl)this.Controls[x];
                uc.Width = xPos;
                uc.Location = new Point(xPos + 5, y);
                y += uc.Height + 3;
            }
        }

        private void EvenementList_SizeChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void CreatorUrl_Click(object sender, EventArgs e)
        {
            string url = ((LinkLabel)sender).Text;
            Clear();
            Filters.Instance.Reset();
            Filters.Instance.Creator = url;
            Set(Filters.Instance.GetFilteredResults());
        }
        private void LocationUrl_Click(object sender, EventArgs e)
        {
            try {
                string url = ((LinkLabel)sender).Text;
                Clear();
                Filters.Instance.Reset();
                Filters.Instance.Location = url;
                Set(Filters.Instance.GetFilteredResults());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void Report()
        {
            ReportForm rf = new ReportForm();
            foreach (EvenementListItem eli in items)
                rf.AddLine(eli.ToString(), eli.ReportData());

            rf.Show();
        }


    }
}
