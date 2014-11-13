using System.Windows.Forms;
using System.Drawing;

using ProjectGroep13;

namespace GUI_Bits
{
    class ParticipantFilter : FilterListItem
    {
        private NumericUpDown numValue;
    
        public ParticipantFilter()
        {
            InitializeComponent();

            this.TextAlign = StringAlignment.Near;
            this.Text = "People joined >=";
        }

        public override void UpdateFilters()
        {
            Filters.Instance.ParticipantCount = (int)numValue.Value;
        }

        private void InitializeComponent()
        {
            this.numValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
            this.SuspendLayout();
            // 
            // numValue
            // 
            this.numValue.Location = new System.Drawing.Point(141, 5);
            this.numValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numValue.Name = "numValue";
            this.numValue.Size = new System.Drawing.Size(89, 23);
            this.numValue.TabIndex = 1;
            this.numValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ParticipantFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Controls.Add(this.numValue);
            this.Name = "ParticipantFilter";
            this.Controls.SetChildIndex(this.numValue, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }

    class NotEmptyFilter : FilterListItem
    {
        public NotEmptyFilter(){
            this.Text = "Is not empty";
        }

        public override void UpdateFilters()
        {
            Filters.Instance.ParticipantCount = 1;
        }
    }

    class NotFullFilter : FilterListItem
    {
        public NotFullFilter()
        {
            this.Text = "Is not full";
        }

        public override void UpdateFilters()
        {
            Filters.Instance.NotFull = true;
        }
    }

    class FullFilter : FilterListItem
    {
        public FullFilter()
        {
            this.Text = "Is full";
        }

        public override void UpdateFilters()
        {
            Filters.Instance.Full = true;
        }
    }




}
