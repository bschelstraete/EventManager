namespace ProjectGroep13
{
    partial class EvenementList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvenementList));
            this.icFilters = new GUI_Bits.InfoContainer();
            this.SuspendLayout();
            // 
            // icFilters
            // 
            this.icFilters.BackColor = System.Drawing.Color.Transparent;
            this.icFilters.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icFilters.BackgroundImage")));
            this.icFilters.CustomColor = System.Drawing.Color.Empty;
            this.icFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.icFilters.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.icFilters.Highlit = false;
            this.icFilters.Location = new System.Drawing.Point(0, 0);
            this.icFilters.Name = "icFilters";
            this.icFilters.Size = new System.Drawing.Size(434, 59);
            this.icFilters.Status = GUI_Bits.InfoContainerStatus.Default;
            this.icFilters.TabIndex = 0;
            this.icFilters.ToolTipText = "";
            // 
            // EvenementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.Controls.Add(this.icFilters);
            this.DoubleBuffered = true;
            this.Name = "EvenementList";
            this.Size = new System.Drawing.Size(434, 150);
            this.SizeChanged += new System.EventHandler(this.EvenementList_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI_Bits.InfoContainer icFilters;
    }
}
