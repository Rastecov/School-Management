using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFinalDA3ErasteBokoYacov
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void dataReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse fc = new frmCourse();
            fc.MdiParent = this;

            fc.Show();
        }

        private void dataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudents fs = new frmStudents();
            fs.MdiParent = this;

            fs.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch fs = new frmSearch();
            fs.MdiParent = this;

            fs.Show();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
