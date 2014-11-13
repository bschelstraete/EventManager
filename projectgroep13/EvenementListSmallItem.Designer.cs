namespace Gr13ProjectDemo
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
            this.btnActie = new System.Windows.Forms.Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblBeschrijving = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblDuurtijd = new System.Windows.Forms.Label();
            this.lblLaatsteKans = new System.Windows.Forms.Label();
            this.lblCapaciteit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnActie
            // 
            this.btnActie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActie.Location = new System.Drawing.Point(387, 114);
            this.btnActie.Name = "btnActie";
            this.btnActie.Size = new System.Drawing.Size(138, 23);
            this.btnActie.TabIndex = 0;
            this.btnActie.Text = "Inschrijven";
            this.btnActie.UseVisualStyleBackColor = true;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(17, 17);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(96, 31);
            this.lblTitel.TabIndex = 2;
            this.lblTitel.Text = "<titel>";
            // 
            // lblBeschrijving
            // 
            this.lblBeschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBeschrijving.Location = new System.Drawing.Point(20, 48);
            this.lblBeschrijving.Name = "lblBeschrijving";
            this.lblBeschrijving.Size = new System.Drawing.Size(349, 66);
            this.lblBeschrijving.TabIndex = 3;
            this.lblBeschrijving.Text = "<beschrijving>";
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(384, 17);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(57, 13);
            this.lblDatum.TabIndex = 4;
            this.lblDatum.Text = "xx/xx/xxxx";
            this.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDuurtijd
            // 
            this.lblDuurtijd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuurtijd.AutoSize = true;
            this.lblDuurtijd.Location = new System.Drawing.Point(384, 48);
            this.lblDuurtijd.Name = "lblDuurtijd";
            this.lblDuurtijd.Size = new System.Drawing.Size(42, 13);
            this.lblDuurtijd.TabIndex = 5;
            this.lblDuurtijd.Text = "<x> uur";
            this.lblDuurtijd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDuurtijd.Visible = false;
            // 
            // lblLaatsteKans
            // 
            this.lblLaatsteKans.AutoSize = true;
            this.lblLaatsteKans.ForeColor = System.Drawing.Color.Red;
            this.lblLaatsteKans.Location = new System.Drawing.Point(283, 119);
            this.lblLaatsteKans.Name = "lblLaatsteKans";
            this.lblLaatsteKans.Size = new System.Drawing.Size(71, 13);
            this.lblLaatsteKans.TabIndex = 6;
            this.lblLaatsteKans.Text = "Laatste kans!";
            this.lblLaatsteKans.Visible = false;
            // 
            // lblCapaciteit
            // 
            this.lblCapaciteit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapaciteit.AutoSize = true;
            this.lblCapaciteit.Location = new System.Drawing.Point(384, 84);
            this.lblCapaciteit.Name = "lblCapaciteit";
            this.lblCapaciteit.Size = new System.Drawing.Size(34, 13);
            this.lblCapaciteit.TabIndex = 7;
            this.lblCapaciteit.Text = "<x/y>";
            this.lblCapaciteit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EvenementListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCapaciteit);
            this.Controls.Add(this.lblLaatsteKans);
            this.Controls.Add(this.lblDuurtijd);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblBeschrijving);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.btnActie);
            this.Name = "EvenementListItem";
            this.Size = new System.Drawing.Size(548, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActie;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblBeschrijving;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblDuurtijd;
        private System.Windows.Forms.Label lblLaatsteKans;
        private System.Windows.Forms.Label lblCapaciteit;
    }
}
