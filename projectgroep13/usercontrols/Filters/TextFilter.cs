using System.Drawing;
using System.Windows.Forms;

using ProjectGroep13;

namespace GUI_Bits
{
    class TextFilter : FilterListItem
    {
        private TextBox txtValue;
    
        public TextFilter() : this(""){}
        public TextFilter(string s)
        {
            InitializeComponent();

            this.TextAlign = StringAlignment.Near;
            this.Text = "Keyword(s)";
            this.txtValue.Text = s;
        }

        public string Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        public override void UpdateFilters()
        {
            Filters.Instance.Text = Value;
        }

        private void InitializeComponent()
        {
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(121, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(124, 23);
            this.txtValue.TabIndex = 2;
            // 
            // TextFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.Controls.Add(this.txtValue);
            this.Name = "TextFilter";
            this.Controls.SetChildIndex(this.txtValue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}