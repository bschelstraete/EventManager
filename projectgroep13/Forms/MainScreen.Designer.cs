namespace ProjectGroep13
{
    partial class MainScreen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scLeftMenu = new System.Windows.Forms.SplitContainer();
            this.elMain = new ProjectGroep13.EvenementList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scLeftMenu)).BeginInit();
            this.scLeftMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scLeftMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.elMain);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(684, 512);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // scLeftMenu
            // 
            this.scLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scLeftMenu.IsSplitterFixed = true;
            this.scLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.scLeftMenu.Margin = new System.Windows.Forms.Padding(0);
            this.scLeftMenu.Name = "scLeftMenu";
            this.scLeftMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.scLeftMenu.Size = new System.Drawing.Size(250, 512);
            this.scLeftMenu.SplitterDistance = 122;
            this.scLeftMenu.SplitterWidth = 1;
            this.scLeftMenu.TabIndex = 0;
            // 
            // elMain
            // 
            this.elMain.AutoScroll = true;
            this.elMain.AutoSize = true;
            this.elMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.elMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.elMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elMain.FilterText = "";
            this.elMain.Location = new System.Drawing.Point(0, 0);
            this.elMain.Margin = new System.Windows.Forms.Padding(0);
            this.elMain.Name = "elMain";
            this.elMain.Size = new System.Drawing.Size(433, 512);
            this.elMain.TabIndex = 0;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainScreen";
            this.Text = "Groep13";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scLeftMenu)).EndInit();
            this.scLeftMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EvenementList elMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer scLeftMenu;
    }
}

