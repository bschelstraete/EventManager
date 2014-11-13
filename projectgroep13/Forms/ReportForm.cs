using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGroep13
{
    public partial class ReportForm : Form
    {
        private string header;
        private string body = "";

        public ReportForm()
        {
            InitializeComponent();

            header = string.Format("Report created on {0}{1}Query was '{2}'{1}{1}", 
                DateTime.Now, Environment.NewLine, Filters.Instance.FilterText());
            lblHeader.Text = header;
        }

        public void AddLine(string s, object[] rowdata)
        {
            body += s + Environment.NewLine;
            dgvReport.Rows.Add(rowdata);
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(header + body);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataGridViewRow HeaderRow()
        {
            DataGridViewRow dr = new DataGridViewRow();
            string[] headers = {"Start date", "Title", "Creator", "Location", 
                                   "Minimum occupancy", "Participants", "Capacity", "Description"};
            dr.SetValues(headers);
            return dr;
        }

    }
}
