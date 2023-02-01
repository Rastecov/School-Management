
namespace prjFinalDA3ErasteBokoYacov
{
    partial class frmMain
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuDatareader = new System.Windows.Forms.MenuStrip();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataNeed1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatareader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuDatareader
            // 
            this.mnuDatareader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuDatareader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.mnuDatareader.Location = new System.Drawing.Point(0, 0);
            this.mnuDatareader.Name = "mnuDatareader";
            this.mnuDatareader.Size = new System.Drawing.Size(800, 28);
            this.mnuDatareader.TabIndex = 3;
            this.mnuDatareader.Text = "menuStrip1";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataNeed1ToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitApplicationToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.aToolStripMenuItem.Text = "Action";
            // 
            // dataNeed1ToolStripMenuItem
            // 
            this.dataNeed1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataReaderToolStripMenuItem,
            this.dataSetToolStripMenuItem});
            this.dataNeed1ToolStripMenuItem.Name = "dataNeed1ToolStripMenuItem";
            this.dataNeed1ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataNeed1ToolStripMenuItem.Text = "Manage";
            // 
            // dataReaderToolStripMenuItem
            // 
            this.dataReaderToolStripMenuItem.Name = "dataReaderToolStripMenuItem";
            this.dataReaderToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataReaderToolStripMenuItem.Text = "Course";
            this.dataReaderToolStripMenuItem.Click += new System.EventHandler(this.dataReaderToolStripMenuItem_Click);
            // 
            // dataSetToolStripMenuItem
            // 
            this.dataSetToolStripMenuItem.Name = "dataSetToolStripMenuItem";
            this.dataSetToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataSetToolStripMenuItem.Text = "Student";
            this.dataSetToolStripMenuItem.Click += new System.EventHandler(this.dataSetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Search";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // exitApplicationToolStripMenuItem
            // 
            this.exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            this.exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitApplicationToolStripMenuItem.Text = "Exit Application";
            this.exitApplicationToolStripMenuItem.Click += new System.EventHandler(this.exitApplicationToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuDatareader);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuDatareader.ResumeLayout(false);
            this.mnuDatareader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuDatareader;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataNeed1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitApplicationToolStripMenuItem;
    }
}