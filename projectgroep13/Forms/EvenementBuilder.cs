using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectGroep13
{
    public partial class EvenementBuilder : Form
    {
        private bool editmode = false;
        private int id = -1;

        public EvenementBuilder()
        {
            InitializeComponent();
            DateTime dt = DateTime.Today.Date + new TimeSpan(1, DateTime.Now.Hour, 0, 0);
            dtpStartDate.Value = dt;
            dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        public EvenementBuilder(Evenement e)
        {
            InitializeComponent();
            editmode = true;
            btnDelete.Visible = true;
            btnCreate.Text = "Update event";
            this.Text = "Edit existing event...";

            id = e.ID;
            dtpStartDate.Value = e.StartDate; //BUG: gui value won't change
            dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            txtTitle.Text = e.Title;
            txtLocation.Text = e.Location;
            txtDescription.Text = e.Description;
            if (e.Capacity == -1) cbInfinite.Checked = true;
            else numMax.Value = e.Capacity;
            numMin.Value = e.Minimum;

            //musnt tweak participant count to be lower than current amount of participants
            int participants = e.Participants.Count();
            numMin.Minimum = participants;
            numMax.Minimum = participants;
        }

        public Evenement FormEvent
        {
            get
            {
                Evenement e = new Evenement();
                e.ID = id;
                e.CreatorID = Login.Instance.UserID;
                e.CreatorName = Login.Instance.Username;
                e.Title = txtTitle.Text;
                e.Location = txtLocation.Text;
                e.StartDate = dtpStartDate.Value;
                e.Description = txtDescription.Text;
                e.Minimum = (int)numMin.Value;
                if (cbInfinite.Checked) e.Capacity = -1;
                else e.Capacity = (int)numMax.Value;
                return e;
            }
        }

        private void cbInfinite_CheckedChanged(object sender, EventArgs e)
        {
            numMax.ReadOnly = cbInfinite.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (editmode) EditEvent();
            else CreateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete this event. Proceed?", "Warning", 
                MessageBoxButtons.OKCancel) == DialogResult.OK) DeleteEvent();
        }

        private void CreateEvent()
        {
            try {
                ValidateInput();
                if (txtDescription.TextLength == 0)
                    if (MessageBox.Show("You've not entered a description. People may not know what this event is about. Proceed?",
                        "Warning!", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

                if (dtpStartDate.Value.Date == DateTime.Today.Date)
                    if (MessageBox.Show("This event starts today. Proceed?",
                        "Warning!", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

                ValidateInput(); //required; catches error (bypass time checks by keeping dialog active for hours)
                SQL.Instance.AddEvent(FormEvent);

                this.DialogResult = DialogResult.OK;
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidateInput()
        {
            if (txtTitle.TextLength < 4) throw new Exception("Given title is too short.");
            if (txtLocation.TextLength < 4) throw new Exception("Given location is too short.");
            if (dtpStartDate.Value < DateTime.Now + new TimeSpan(0,15,0)) throw new Exception("Start date is too soon.");
            if (dtpStartDate.Value < DateTime.Now) throw new Exception("Start date is expired.");
        }

        private void EditEvent()
        {
            try {
                ValidateInput();
                SQL.Instance.EditEvent(FormEvent);

                this.DialogResult = DialogResult.OK;
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteEvent()
        {
            try {
                if (id > -1) SQL.Instance.RemoveEvent(id);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void numMax_ValueChanged(object sender, EventArgs e)
        {
            if (numMin.Value > numMax.Value) numMin.Value = numMax.Value;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            if (numMax.Value < numMin.Value) numMax.Value = numMin.Value;
        }


    }

}
