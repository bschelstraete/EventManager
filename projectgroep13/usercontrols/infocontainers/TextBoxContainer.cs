using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_Bits
{
    public class TextBoxContainer : InfoContainer
    {
        private TextBox txtEmbedded;

        public TextBoxContainer() : this(""){}
        public TextBoxContainer(string caption)
        {
            InitializeComponent();

            Status = InfoContainerStatus.Custom;
            CustomColor = Color.FromArgb(180, 180, 200);
            tt.RemoveAll();

            this.TextAlign = StringAlignment.Near;
            this.Text = caption;
        }
        public TextBoxContainer(string caption, bool isPwd) : this(caption)
        {
            this.txtEmbedded.UseSystemPasswordChar = isPwd;
        }

        public string Value
        {
            get { return txtEmbedded.Text; }
            set { txtEmbedded.Text = value; }
        }

        //protected override void DrawText()
        //{
        //    Graphics gr = Graphics.FromImage(this.BackgroundImage);
        //    Rectangle r = new Rectangle(10, 0, this.Width, this.Height);
        //    StringFormat sf = new StringFormat();
        //    sf.Alignment = StringAlignment.Near;
        //    sf.LineAlignment = StringAlignment.Center;
        //    gr.DrawString(this.Text, this.Font, Brushes.White, r, sf);
        //    gr.Dispose();
        //}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxContainer));
            this.txtEmbedded = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEmbedded
            // 
            this.txtEmbedded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmbedded.Location = new System.Drawing.Point(81, 3);
            this.txtEmbedded.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmbedded.Name = "txtEmbedded";
            this.txtEmbedded.Size = new System.Drawing.Size(59, 23);
            this.txtEmbedded.TabIndex = 0;
            // 
            // TextBoxContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.txtEmbedded);
            this.Name = "TextBoxContainer";
            this.Click += new System.EventHandler(this.TextBoxContainer_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextBoxContainer_Click(object sender, EventArgs e)
        {
            txtEmbedded.Focus();
        }

    }
}
