namespace ProjectGroep13
{
    partial class NewUserDialog
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
            this.iclNewUser = new GUI_Bits.InfoContainerList();
            this.SuspendLayout();
            // 
            // iclNewUser
            // 
            this.iclNewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iclNewUser.Location = new System.Drawing.Point(0, 0);
            this.iclNewUser.Name = "iclNewUser";
            this.iclNewUser.Size = new System.Drawing.Size(284, 125);
            this.iclNewUser.TabIndex = 0;
            // 
            // NewUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 125);
            this.Controls.Add(this.iclNewUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUserDialog";
            this.Text = "Create new user...";
            this.ResumeLayout(false);

        }

        #endregion

        private GUI_Bits.InfoContainerList iclNewUser;
    }
}