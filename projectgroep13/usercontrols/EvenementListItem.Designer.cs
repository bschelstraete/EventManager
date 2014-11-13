namespace ProjectGroep13
{
    partial class EvenementListItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblBeschrijving = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.urlCreator = new System.Windows.Forms.LinkLabel();
            this.urlLocation = new System.Windows.Forms.LinkLabel();
            this.iclInfo = new GUI_Bits.InfoContainerList();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.BackColor = System.Drawing.Color.Transparent;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(3, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(115, 29);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "<TITLE>";
            // 
            // lblBeschrijving
            // 
            this.lblBeschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeschrijving.BackColor = System.Drawing.Color.Transparent;
            this.lblBeschrijving.Location = new System.Drawing.Point(3, 68);
            this.lblBeschrijving.Name = "lblBeschrijving";
            this.lblBeschrijving.Size = new System.Drawing.Size(243, 112);
            this.lblBeschrijving.TabIndex = 3;
            this.lblBeschrijving.Text = "No description.";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreator.Location = new System.Drawing.Point(3, 29);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(56, 13);
            this.lblCreator.TabIndex = 5;
            this.lblCreator.Text = "Creator: ";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(3, 48);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(64, 13);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.Text = "Location: ";
            // 
            // urlCreator
            // 
            this.urlCreator.AutoSize = true;
            this.urlCreator.BackColor = System.Drawing.Color.Transparent;
            this.urlCreator.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.urlCreator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.urlCreator.Location = new System.Drawing.Point(67, 29);
            this.urlCreator.Name = "urlCreator";
            this.urlCreator.Size = new System.Drawing.Size(51, 13);
            this.urlCreator.TabIndex = 7;
            this.urlCreator.TabStop = true;
            this.urlCreator.Text = "unknown";
            // 
            // urlLocation
            // 
            this.urlLocation.AutoSize = true;
            this.urlLocation.BackColor = System.Drawing.Color.Transparent;
            this.urlLocation.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.urlLocation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.urlLocation.Location = new System.Drawing.Point(67, 48);
            this.urlLocation.Name = "urlLocation";
            this.urlLocation.Size = new System.Drawing.Size(51, 13);
            this.urlLocation.TabIndex = 8;
            this.urlLocation.TabStop = true;
            this.urlLocation.Text = "unknown";
            // 
            // iclInfo
            // 
            this.iclInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.iclInfo.Location = new System.Drawing.Point(252, 0);
            this.iclInfo.Name = "iclInfo";
            this.iclInfo.Size = new System.Drawing.Size(150, 180);
            this.iclInfo.TabIndex = 4;
            // 
            // EvenementListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.urlLocation);
            this.Controls.Add(this.urlCreator);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.iclInfo);
            this.Controls.Add(this.lblBeschrijving);
            this.Controls.Add(this.lblTitel);
            this.DoubleBuffered = true;
            this.Name = "EvenementListItem";
            this.Size = new System.Drawing.Size(402, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblBeschrijving;
        private GUI_Bits.InfoContainerList iclInfo;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.LinkLabel urlCreator;
        private System.Windows.Forms.LinkLabel urlLocation;
    }
}
