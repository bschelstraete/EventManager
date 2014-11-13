namespace GUI_Bits
{
    partial class FilterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterList));
            this.pFilters = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new ButtonContainer("Export current results");
            this.btnFilter = new ButtonContainer("FILTER");
            this.SuspendLayout();
            // 
            // pFilters
            // 
            this.pFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pFilters.Location = new System.Drawing.Point(0, 16);
            this.pFilters.Name = "pFilters";
            this.pFilters.Size = new System.Drawing.Size(221, 305);
            this.pFilters.TabIndex = 0;
            this.pFilters.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pFilters_ControlAdded);
            this.pFilters.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pFilters_ControlRemoved);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filters:";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReport.BackgroundImage")));
            this.btnReport.Clickable = true;
            this.btnReport.CustomColor = System.Drawing.Color.Empty;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReport.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnReport.Highlit = false;
            this.btnReport.Location = new System.Drawing.Point(0, 356);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(221, 29);
            this.btnReport.Status = GUI_Bits.InfoContainerStatus.Default;
            this.btnReport.TabIndex = 2;
            this.btnReport.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnReport.ToolTipText = "";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.Clickable = true;
            this.btnFilter.CustomColor = System.Drawing.Color.Empty;
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFilter.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFilter.Highlit = false;
            this.btnFilter.Location = new System.Drawing.Point(0, 327);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(221, 29);
            this.btnFilter.Status = GUI_Bits.InfoContainerStatus.Default;
            this.btnFilter.TabIndex = 3;
            this.btnFilter.TextAlign = System.Drawing.StringAlignment.Center;
            this.btnFilter.ToolTipText = "";
            // 
            // FilterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pFilters);
            this.Name = "FilterList";
            this.Size = new System.Drawing.Size(221, 385);
            this.SizeChanged += new System.EventHandler(this.FilterList_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pFilters;
        private System.Windows.Forms.Label label1;
        private GUI_Bits.ButtonContainer btnReport;
        private GUI_Bits.ButtonContainer btnFilter;
    }
}
