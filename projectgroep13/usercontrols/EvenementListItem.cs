using System;
using System.Drawing;
using System.Windows.Forms;
using GUI_Bits;

namespace ProjectGroep13
{
    public partial class EvenementListItem : UserControl
    {
        private Evenement ev;
        private ButtonContainer bc;

        public EvenementListItem()
        {
            InitializeComponent();
        }
        public EvenementListItem(Evenement e)
        {
            InitializeComponent();
            SetEvenement(e);
        }

        public LinkLabel LocationUrl
        {
            get { return urlLocation; }
        }

        public LinkLabel CreatorUrl
        {
            get { return urlCreator; }
        }

        public void SetEvenement(Evenement e)
        {
            ev = e;

            bc = new ButtonContainer("JOIN");
            bc.MouseEnter += new EventHandler(HighlightCriteria);
            bc.MouseLeave += new EventHandler(StopHighlight);
            bc.Click += bc_Click;

            Setup();
        }

        private void Setup()
        {
            lblTitel.Text = ev.Title;
            lblBeschrijving.Text = ev.Description;

            urlCreator.Text = ev.CreatorName;
            urlLocation.Text = ev.Location;

            iclInfo.Clear();
            iclInfo.Add(new DateContainer(ev.StartDate));
            iclInfo.Add(new CapacityContainer(ev.Minimum, ev.Capacity, ev.Participants.Count));

            if (Login.Instance.IsLoggedIn) {
                if (UserOwnsEvent()) {
                    bc.Text = "EDIT";
                    this.BackColor = Color.FromArgb(240, 230, 240);
                } else if (UserIsParticipating()) {
                    if (!HasExpired()) bc.Text = "LEAVE";
                    else bc.Text = "JOINED";
                    this.BackColor = Color.FromArgb(230, 240, 230);
                } else {
                    bc.Text = "JOIN";
                    this.BackColor = Color.FromArgb(230, 230, 240);
                }

                bc.Clickable = AllOK();
                iclInfo.Add(bc);
            }

        }

        public void UpdateContents()
        {
            Setup();
        }

        private void JoinEvent()
        {
            if (!Login.Instance.IsLoggedIn) throw new Exception("Unauthorized action! Please log in.");
            if (UserOwnsEvent()) throw new Exception("You're in charge of this event!");
            if (UserIsParticipating()) throw new Exception("You've already joined this event!");
            if (HasExpired()) throw new Exception("Event has expired. Further changes are not allowed.");

            SQL.Instance.JoinEvent(Login.Instance.UserID, ev.ID);
        }

        private void LeaveEvent()
        {
            if (!Login.Instance.IsLoggedIn) throw new Exception("Unauthorized action! Please log in.");
            if (!UserIsParticipating()) throw new Exception("Can't leave if you haven't joined...");
            if (HasExpired()) throw new Exception("Event has expired. Further changes are not allowed.");

            SQL.Instance.LeaveEvent(Login.Instance.UserID, ev.ID);
        }

        private bool AllOK()
        {
            if (Login.Instance.IsLoggedIn) {
                if (HasExpired()) return false;
                if (UserOwnsEvent() || UserIsParticipating()) return true;
            }

            foreach (InfoContainer ic in iclInfo.Controls) {
                if (ic.RequiresAttention()) return false;
            }
            return true;
        }

        private bool HasExpired()
        {
            return (ev.StartDate < DateTime.Now);
        }
        private bool UserOwnsEvent()
        {
            return (Login.Instance.UserID == ev.CreatorID);
        }
        private bool UserIsParticipating()
        {
            return ev.Participants.Contains(Login.Instance.UserID);
        }

        private void bc_Click(object sender, EventArgs e)
        {
            try {
                if (!bc.Clickable) return;
                
                if (UserOwnsEvent()) {
                    EvenementBuilder eb = new EvenementBuilder(ev);
                    eb.ShowDialog();
                    if (eb.DialogResult == DialogResult.Abort) return;
                }
                else if (!HasExpired() && UserIsParticipating()) LeaveEvent();
                else if (!UserIsParticipating()) JoinEvent();

                SetEvenement(SQL.Instance.RetrieveSpecificEvent(ev.ID));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        private void HighlightCriteria(Object sender, EventArgs e)
        {
            foreach (InfoContainer ic in iclInfo.Controls)
                if (ic.RequiresAttention()) 
                    ic.Highlit = true;

            bc.Clickable = AllOK();
        }
        private void StopHighlight(Object sender, EventArgs e)
        {
            foreach (InfoContainer ic in iclInfo.Controls) ic.Highlit = false;
        }

        public object[] ReportData()
        {
            object[] values = {ev.StartDate, ev.Title, ev.CreatorName, ev.Location, 
                                   ev.Minimum, ev.Participants.Count, 
                                   ev.Capacity, ev.Description};
            return values;
        }

        public override string ToString()
        {
            string s = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                ev.StartDate, ev.Title, ev.CreatorName, ev.Location,
                ev.Minimum, ev.Participants.Count, ev.Capacity, ev.Description);
            return s;
        }

    }
}
