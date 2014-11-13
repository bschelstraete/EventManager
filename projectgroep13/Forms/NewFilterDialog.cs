using System;
using System.Collections.Generic;
using System.Windows.Forms;

using GUI_Bits;

namespace ProjectGroep13
{
    public partial class NewFilterDialog : Form
    {
        private List<FilterListItem> items = new List<FilterListItem>();
        private int selectedindex;

        public NewFilterDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            this.AddButton("Specified date", new DateFilter());
            if (!Filters.Instance.NotFull && !Filters.Instance.Full) {
                this.AddButton("Not full", new NotFullFilter());
                this.AddButton("Full", new FullFilter());
            }
            if (!(Filters.Instance.ParticipantCount > 0)) {
                this.AddButton("Not empty", new NotEmptyFilter());
                this.AddButton("At least X participants", new ParticipantFilter());
            }
            if (Login.Instance.IsLoggedIn) this.AddButton("I'm participating", new JoinedFilter());
            if (Filters.Instance.Creator.Length == 0) this.AddButton("Created by...", new CreatorFilter());
            this.AddButton("Specified location", new LocationFilter());
            this.AddButton("Contains keyword...", new TextFilter());
        }

        private void AddButton(string s, FilterListItem fli)
        {
            ButtonContainer btn = new ButtonContainer(s);
            items.Add(fli);
            btn.Click += menuclick;
            iclFilters.Add(btn);
        }

        private void menuclick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            selectedindex = ((UserControl)sender).TabIndex;
            this.Close();
        }

        public FilterListItem SelectedItem()
        {
            return items[selectedindex];
        }
    }
}
