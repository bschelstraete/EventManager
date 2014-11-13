using System;
using System.Windows.Forms;

using ProjectGroep13;

namespace GUI_Bits
{
    class DateFilter : FilterListItem
    {
        private DateTimePicker dtDate;
        private ComboBox cbOperator;

        public DateFilter()
        {
            InitializeComponent();

            cbOperator.SelectedIndex = 1;
        }
        public DateFilter(DateTime start)
        {
            InitializeComponent();

            dtDate.Value = start;
            cbOperator.SelectedIndex = 2;
        }

        public override void UpdateFilters()
        {
            switch (cbOperator.SelectedIndex) {
                case 0: Filters.Instance.AddSpecificDate(dtDate.Value); break;  //on
                case 1: Filters.Instance.StartDate = dtDate.Value; break;       //after
                case 2: Filters.Instance.EndDate = dtDate.Value; break;         //prior to
            }
        }

        private void InitializeComponent()
        {
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(121, 5);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(108, 23);
            this.dtDate.TabIndex = 1;
            // 
            // cbOperator
            // 
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "On",
            "From",
            "Until"});
            this.cbOperator.Location = new System.Drawing.Point(13, 5);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(102, 23);
            this.cbOperator.TabIndex = 0;
            // 
            // DateFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Controls.Add(this.cbOperator);
            this.Controls.Add(this.dtDate);
            this.Name = "DateFilter";
            this.Controls.SetChildIndex(this.dtDate, 0);
            this.Controls.SetChildIndex(this.cbOperator, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
