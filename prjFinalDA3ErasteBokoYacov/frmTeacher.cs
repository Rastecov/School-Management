using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace prjFinalDA3ErasteBokoYacov
{
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }


        //Global variable
        //Global variable
        DataSet myset;
        DataTable tabTeacher;
        OleDbConnection mycon;
        int currentposition;
        string mode;
        OleDbDataAdapter myadp;
        private void frmTeacher_Load(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\prjFinalDA3ErasteBokoYacov\prjFinalDA3ErasteBokoYacov\Database\lasalle.accdb");
            mycon.Open();
            OleDbCommand mycom = new OleDbCommand("Select * From Teachers", mycon);
            myadp = new OleDbDataAdapter(mycom);
            myadp.Fill(myset, "Teachers");
            tabTeacher = myset.Tables["Teachers"];
            currentposition = 0;
            Display();
            ActivateButton(true, false, true);
        }


        private void Display()
        {
            txtFullName.Text = tabTeacher.Rows[currentposition]["FullName"].ToString();
            txtEmail.Text = tabTeacher.Rows[currentposition]["Email"].ToString();
            txtSalary.Text = tabTeacher.Rows[currentposition]["Salary"].ToString();
            lblTeacherInfo.Text = "Teachers " + (currentposition + 1) + " on a total of " + tabTeacher.Rows.Count;
        }
        private void Clear()
        {
            txtFullName.Text = txtEmail.Text = txtSalary.Text = "";
            txtFullName.Focus();
        }

        private void ActivateButton(bool AdEdDel, bool SavCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdDel;
            btnSave.Enabled = btnCancel.Enabled = SavCanc;
            btnFirst.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnLast.Enabled = Navig;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            Clear();
            lblTeacherInfo.Text = "-------ADDING MODE----------";

            ActivateButton(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            lblTeacherInfo.Text = "-------EDITING MODE----------";
            ActivateButton(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this Employee ? ";
            string title = "Warning : Employee deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {



                tabTeacher.Rows[currentposition].Delete();

                //Now we need to update (or synchronize) the Dataset contents -> the database

                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Teachers");

                //Update the contents of the Database -> the Dataset
                myset.Tables.Remove("Teachers");
                OleDbCommand mycom = new OleDbCommand("Select * From Teachers", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Teachers");
                tabTeacher = myset.Tables["Teachers"];

                currentposition = 0;
                Display();

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nam = txtFullName.Text.Trim();
            string eml = txtEmail.Text.Trim();
            decimal sal = Convert.ToDecimal(txtSalary.Text);

            DataRow myrow;
            if (mode == "add")
            {
                myrow = tabTeacher.NewRow();
                myrow["FullName"] = nam;
                myrow["Email"] = eml;
                myrow["Salary"] = sal;


                //New record saved only in the table of the Dataset
                tabTeacher.Rows.Add(myrow);

                //Now we need to update (or synchronize) the Dataset contents -> the database

                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Teachers");

                //Update the contents of the Database -> the Dataset
                myset.Tables.Remove("Teachers");
                OleDbCommand mycom = new OleDbCommand("Select * From Teachers", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Teachers");
                tabTeacher = myset.Tables["Teachers"];

                currentposition = tabTeacher.Rows.Count - 1;

            }

            else if (mode == "edit")
            {
                myrow = tabTeacher.Rows[currentposition];
                myrow["FullName"] = nam;
                myrow["Email"] = eml;
                myrow["Salary"] = sal;

                //record saved only in the table of the Dataset

                //Now we need to update (or synchronize) the Dataset contents -> the database

                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Teachers");

                //Update the contents of the Database -> the Dataset
                myset.Tables.Remove("Teachers");
                OleDbCommand mycom = new OleDbCommand("Select * From Teachers", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Teachers");
                tabTeacher = myset.Tables["Teachers"];


            }


            Display();
            mode = "";

            ActivateButton(true, false, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateButton(true, false, true);
        }

        private void bTNClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

            currentposition = 0;
            Display();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentposition > 0)
            {
                currentposition = currentposition - 1;
            }
            else
            {
                MessageBox.Show("This is the first one!");
            }
            Display();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentposition < myset.Tables["Teachers"].Rows.Count - 1)
            {
                currentposition = currentposition + 1;
            }
            else
            {
                MessageBox.Show("This is the last one!");
            }
            Display();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentposition = myset.Tables["Teachers"].Rows.Count - 1;
            Display();
        }
    }
}
