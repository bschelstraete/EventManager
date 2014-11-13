using System;
using System.Windows.Forms;

using GUI_Bits;

namespace ProjectGroep13
{
    public partial class MainScreen : Form
    {
        private LoginControl lc = new LoginControl();
        private UserOptionControl uoc = new UserOptionControl();
        private FilterList fl = new FilterList();

        public MainScreen()
        {
            InitializeComponent();

            scLeftMenu.Panel2.Controls.Add(fl);

            lc.Dock = DockStyle.Fill;
            uoc.Dock = DockStyle.Fill;
            fl.Dock = DockStyle.Fill;
            elMain.Dock = DockStyle.Fill;

            lc.LoginButton.Click += LoginButton_Click;
            lc.CreateButton.Click += CreateUserButton_Click;
            uoc.LogoutButton.Click += LogoutButton_Click;
            uoc.CreateButton.Click += CreateEventButton_Click;
            uoc.ShowMineButton.Click += ShowMineButton_Click;
            uoc.ShowJoinedButton.Click += ShowJoinedButton_Click;
            fl.FilterButton.Click += FilterButton_Click;
            fl.ReportButton.Click += ReportButton_Click;
            
            UpdateUserOptions();
            DoFilter();
        }

        private void UpdateUserOptions()
        {
            scLeftMenu.Panel1.Controls.Clear();

            if (Login.Instance.IsLoggedIn) scLeftMenu.Panel1.Controls.Add(uoc);
            else scLeftMenu.Panel1.Controls.Add(lc);

            scLeftMenu.Panel1.Controls[0].Dock = DockStyle.Fill;

            string s = "Gr13 Event Manager - ";
            if (Login.Instance.IsLoggedIn) s += "User: " + Login.Instance.Username;
            else s += "Not logged in";
            this.Text = s;

            elMain.UpdateContents();
        }

        void LoginButton_Click(object sender, EventArgs e)
        {
            try {
                Login.Instance.DoLogin(lc.Username, lc.Password);
                UpdateUserOptions();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        void CreateUserButton_Click(object sender, EventArgs e)
        {
            try {
                NewUserDialog nud = new NewUserDialog();
                nud.ShowDialog();
                if (nud.DialogResult == DialogResult.OK) {
                    Login.Instance.CreateNewUser(nud.Username, nud.Password);
                    UpdateUserOptions();
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        void LogoutButton_Click(object sender, EventArgs e)
        {
            Login.Instance.DoLogout();
            UpdateUserOptions();
        }

        void CreateEventButton_Click(object sender, EventArgs e)
        {
            try {
                EvenementBuilder eb = new EvenementBuilder();
                eb.ShowDialog();
                if (eb.DialogResult == DialogResult.OK) elMain.UpdateContents();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        void ShowMineButton_Click(object sender, EventArgs e)
        {
            Filters.Instance.Reset();
            fl.Clear();
            fl.Add(new CreatorFilter(Login.Instance.Username));
            fl.UpdateFilters();
            elMain.Set(Filters.Instance.GetFilteredResults());
        }
        void ShowJoinedButton_Click(object sender, EventArgs e)
        {
            Filters.Instance.Reset();
            fl.Clear();
            fl.Add(new JoinedFilter());
            fl.UpdateFilters();
            elMain.Set(Filters.Instance.GetFilteredResults());
        }

        void FilterButton_Click(object sender, EventArgs e)
        {
            DoFilter();
        }
        private void DoFilter()
        {
            Filters.Instance.Reset();
            fl.UpdateFilters();
            elMain.Set(Filters.Instance.GetFilteredResults());
        }

        void ReportButton_Click(object sender, EventArgs e)
        {
            elMain.Report();
        }

    }
}
