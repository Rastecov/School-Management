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
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }


        DataSet myset;
        DataTable tabCourse, tabTeacher, tabStudent;
        OleDbConnection mycon;
        OleDbDataAdapter adpCourse;
        int currentposition;
        string mode;
       

        private void frmCourse_Load(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\prjFinalDA3ErasteBokoYacov\prjFinalDA3ErasteBokoYacov\Database\lasalle.accdb");
            mycon.Open();
            OleDbCommand mycom = new OleDbCommand("Select RefTeacher, FullName From Teachers", mycon);
            OleDbDataAdapter myadp = new OleDbDataAdapter(mycom);
            myadp.Fill(myset, "Teachers");

            //Load table employees in the dataset
            mycom = new OleDbCommand("SELECT * FROM Course", mycon);
            adpCourse = new OleDbDataAdapter(mycom);
            adpCourse.Fill(myset, "Course");

            mycom = new OleDbCommand("SELECT * FROM Students", mycon);
            adpCourse = new OleDbDataAdapter(mycom);
            adpCourse.Fill(myset, "Students");



            tabCourse = myset.Tables["Course"];
            tabTeacher = myset.Tables["Teachers"];
            tabStudent = myset.Tables["Students"];
            currentposition = 0;



            


            Display();

 
            FillComboboxWithTeacher();
            ActivateButton(true, false, true);


        }

        private void FillComboboxWithTeacher()
        {



            //Databinding

            cboTeacher.DisplayMember = "FullName";
            cboTeacher.ValueMember = "RefTeacher";
            cboTeacher.DataSource = tabTeacher;


        }





        private void ActivateButton(bool AdEdDel, bool SavCanc, bool Navig)
        {

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = AdEdDel;
            btnSave.Enabled = btnCancel.Enabled = SavCanc;
            btnFirst.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnLast.Enabled = Navig;

        }
        private void Display()
        {
            txtNumber.Text = tabCourse.Rows[currentposition]["Number"].ToString();
            txtTitle.Text = tabCourse.Rows[currentposition]["Title"].ToString();
            txtDuration.Text = tabCourse.Rows[currentposition]["Duration"].ToString();
            int referteach = Convert.ToInt32(tabCourse.Rows[currentposition]["ReferTeacher"]);

            cboTeacher.SelectedValue = referteach;

            lblCourseInfo.Text = "Course " + (currentposition + 1) + " on a total of " + tabCourse.Rows.Count;


            int refe = Convert.ToInt32(tabCourse.Rows[currentposition]["RefCourse"]);

            var AllCompNames = from DataRow stud in tabStudent.Rows
                               where stud.Field<int>("ReferCourse") == refe

                               select new
                               {
                                   Names = stud.Field<string>("FullName"),
                                   Gender = stud.Field<string>("Gender"),
                                   BirthDates = stud.Field
                                                                    <DateTime>("BirthDate")
                               };

            dataGridView1.DataSource = AllCompNames.ToList();

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            Clear();
            cboTeacher.Text = "Select a Teacher";
            txtNumber.Focus();

            lblCourseInfo.Text = "-------ADDING MODE----------";
            mode = "add";


            ActivateButton(false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtNumber.Focus();
            lblCourseInfo.Text = "-------EDITING MODE----------";
            mode = "edit";


            ActivateButton(false, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string num = txtNumber.Text.Trim();
            string title = txtTitle.Text.Trim();
            int du = Convert.ToInt32(txtDuration.Text.Trim());
            int refteach = Convert.ToInt32(cboTeacher.SelectedValue);


            DataRow myrow = (mode == "add") ? tabCourse.NewRow() : tabCourse.Rows[currentposition];

            myrow["Number"] = num;
            myrow["Title"] = title;
            myrow["Duration"] = du;


            myrow["ReferTeacher"] = refteach;

            if (mode == "add")
            {
                tabCourse.Rows.Add(myrow);
                currentposition = tabCourse.Rows.Count - 1;
            }






            //Now we need to update (or synchronize) the Dataset contents -> the database

            OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpCourse);
            adpCourse.Update(myset, "Course");

            //Update the contents of the Database -> the Dataset
            myset.Tables.Remove("Course");
            OleDbCommand mycom = new OleDbCommand("Select * From Course", mycon);
            adpCourse = new OleDbDataAdapter(mycom);
            adpCourse.Fill(myset, "Course");
            tabCourse = myset.Tables["Course"];

            mode = "";
            Display();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to delete this Employee ? ";
            string title = "Warning : Employee deletion";

            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {



                tabCourse.Rows[currentposition].Delete();

                //Now we need to update (or synchronize) the Dataset contents -> the database

                OleDbCommandBuilder myBuilder = new OleDbCommandBuilder(adpCourse);
                adpCourse.Update(myset, "Course");

                //Update the contents of the Database -> the Dataset
                myset.Tables.Remove("Course");
                OleDbCommand mycom = new OleDbCommand("Select * From Course", mycon);
                adpCourse = new OleDbDataAdapter(mycom);
                adpCourse.Fill(myset, "Employees");
                tabCourse = myset.Tables["Course"];

                currentposition = 0;
                Display();






            }
        }

       

        private void btnLast_Click(object sender, EventArgs e)
        {

            currentposition = myset.Tables["Course"].Rows.Count - 1;
            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentposition < myset.Tables["Course"].Rows.Count - 1)
            {
                currentposition = currentposition + 1;
            }
            else
            {
                MessageBox.Show("This is the last one!");
            }
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

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            Display();
        }

        private void btnNewTeacher_Click_1(object sender, EventArgs e)
        {
            frmTeacher ft = new frmTeacher();
            frmCourse fc = new frmCourse();
            this.Hide();
            ft.Show();
            
        }

        private void Clear()
        {
            txtDuration.Text = txtNumber.Text = txtTitle.Text = "";
            txtNumber.Focus();
        }

    }
}
