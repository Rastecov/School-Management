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
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
        }

        //Global variable
        DataSet myset;
        DataTable tabStudent, tabCourse;
        OleDbConnection mycon;
         int currentposition;
         string mode;
         OleDbDataAdapter myadp, adpCourse;


        private void frmStudents_Load(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\prjFinalDA3ErasteBokoYacov\prjFinalDA3ErasteBokoYacov\Database\lasalle.accdb");
            mycon.Open();
            OleDbCommand mycom = new OleDbCommand("Select * From Students", mycon);
            myadp = new OleDbDataAdapter(mycom);
            myadp.Fill(myset, "Students");

            mycom = new OleDbCommand("Select RefCourse,Title From Course", mycon);
            adpCourse = new OleDbDataAdapter(mycom);
            adpCourse.Fill(myset, "Course");

            tabCourse = myset.Tables["Course"];
            tabStudent = myset.Tables["Students"];
            currentposition = 0;
            Display();
            fillcombo();
            ActivateButton(true, false, true);
        }

        private void ActivateButton(bool AdEdDel, bool SavCanc, bool Navig)
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdDel;
            btnSave.Enabled = btnCancel.Enabled = SavCanc;
            btnFirst.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnLast.Enabled = Navig;

        }
        private void Display()
        {
            txtFullName.Text = tabStudent.Rows[currentposition]["FullName"].ToString();
            txtBirthdate.Text = tabStudent.Rows[currentposition]["Birthdate"].ToString();
            txtGender.Text = tabStudent.Rows[currentposition]["Gender"].ToString();
            lblStudentInfo.Text = "Student " + (currentposition + 1) + " on a total of " + tabStudent.Rows.Count;
            int r = Convert.ToInt32(tabStudent.Rows[currentposition]["ReferCourse"]);
            cboCourse.SelectedValue = r;
        }

        private void fillcombo()
        {

            cboCourse.DataSource = tabCourse;
            cboCourse.DisplayMember = "Title";
            cboCourse.ValueMember = "RefCourse";

        }


        private void Clear()
        {
            txtFullName.Text = txtBirthdate.Text = txtGender.Text = "";
            txtFullName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            mode = "add";
            Clear();
            cboCourse.Text = "Select a Course";

            lblStudentInfo.Text = "-------ADDING MODE----------";

            ActivateButton(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            lblStudentInfo.Text = "-------EDITING MODE----------";
            ActivateButton(false, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to delete this student?";
            string title = "Waring : Student Deletion";
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabStudent.Rows[currentposition].Delete();

                OleDbCommandBuilder mybday = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Students");
                //Update the content of the database -> DATASET
                myset.Tables.Remove("Students");
                OleDbCommand mycom = new OleDbCommand("Select * From Student", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Students");
                tabStudent = myset.Tables["Students"];

                currentposition = 0;
                Display();


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fn = txtFullName.Text.Trim();
            DateTime bday = Convert.ToDateTime(txtBirthdate.Text.Trim());
            string gen = txtGender.Text.Trim();
            int refCourse = Convert.ToInt32(cboCourse.SelectedValue);
            DataRow myrow;
            if (mode == "add")
            {
                myrow = tabStudent.NewRow();
                myrow["FullName"] = fn;
                myrow["Birthdate"] = bday;
                myrow["Gender"] = gen;
                myrow["ReferCourse"] = refCourse;
                //New record saved only in the table DATASET

                tabStudent.Rows.Add(myrow);
                //Now We need to update or synchronize the content of dataset -> database
                OleDbCommandBuilder mybday = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Students");
                //Update the content of the database -> DATASET
                myset.Tables.Remove("Students");
                OleDbCommand mycom = new OleDbCommand("Select * From Students", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Students");
                tabStudent = myset.Tables["Students"];

                currentposition = tabStudent.Rows.Count - 1;



            }
            else if (mode == "edit")
            {
                myrow = tabStudent.Rows[currentposition];
                myrow["FullName"] = fn;
                myrow["Birthdate"] = bday;
                myrow["Gender"] = gen;
                myrow["ReferCourse"] = refCourse;
                //record saved only in the table DATASET

                //Now We need to update or synchronize the content of dataset -> database
                OleDbCommandBuilder mybday = new OleDbCommandBuilder(myadp);
                myadp.Update(myset, "Students");
                //Update the content of the database -> DATASET
                myset.Tables.Remove("Students");
                OleDbCommand mycom = new OleDbCommand("Select * From Students", mycon);
                myadp = new OleDbDataAdapter(mycom);
                myadp.Fill(myset, "Students");
                tabStudent = myset.Tables["Students"];



            }
            Display();
            ActivateButton(true, false, true);
            mode = "";
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
            if (currentposition < myset.Tables["Students"].Rows.Count - 1)
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
            currentposition = myset.Tables["Students"].Rows.Count - 1;
            Display();

        }

    }
}
