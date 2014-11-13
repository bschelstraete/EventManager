namespace ProjectGroep13
{
    partial class NewFilterDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iclFilters = new GUI_Bits.InfoContainerList();
            this.SuspendLayout();
            // 
            // iclFilters
            // 
            this.iclFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclFilters.Location = new System.Drawing.Point(0, 0);
            this.iclFilters.Name = "iclFilters";
            this.iclFilters.Size = new System.Drawing.Size(216, 389);
            this.iclFilters.TabIndex = 0;
            // 
            // NewFilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 389);
            this.Controls.Add(this.iclFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFilterDialog";
            this.Text = "Add filter";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI_Bits.InfoContainerList iclFilters;
    }
}