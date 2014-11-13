using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr13ProjectDemo
{
    public partial class EvenementListItem : UserControl
    {
        private Evenement ev;

        public EvenementListItem()
        {
            InitializeComponent();

            //SetupLabels();
        }
        public void SetEvenement(Evenement e)
        {
            ev = e;
            SetupLabels();
        }
        private void SetupLabels()
        {
            lblTitel.Text = ev.Titel;
            lblBeschrijving.Text = ev.Beschrijving;
            lblDatum.Text = string.Format("Datum: {0:dd/MM/yyyy - hh:mm}",ev.StartDatum);
            lblCapaciteit.Text = "Inschrijvingen: 0/" + ev.Capaciteit;

            if (ev.Duurtijd.Hours>0) lblDuurtijd.Text = "Duurtijd: " + ev.Duurtijd + " uur";
            else lblDuurtijd.Visible = false;

            if (IsLastMinute(ev.StartDatum)) lblLaatsteKans.Visible = true;
        }

        private bool IsLastMinute(DateTime dt)
        {
            //TODO
            return false;
        }


    }
}
