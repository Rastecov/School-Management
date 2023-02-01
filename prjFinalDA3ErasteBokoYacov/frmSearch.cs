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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }


        DataSet myset;
        DataTable tabStudents, tabCourse;
        OleDbConnection mycon;
        OleDbDataAdapter sadp, cadp;

        private void frmSearch_Load(object sender, EventArgs e)
        {
            myset = new DataSet();
            mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\prjFinalDA3ErasteBokoYacov\prjFinalDA3ErasteBokoYacov\Database\lasalle.accdb");
            mycon.Open();
            OleDbCommand mycom = new OleDbCommand("Select * From Students", mycon);
            sadp = new OleDbDataAdapter(mycom);
            sadp.Fill(myset, "Students");

            mycom = new OleDbCommand("Select RefCourse,Title From Course", mycon);
            cadp = new OleDbDataAdapter(mycom);
            cadp.Fill(myset, "Course");

            tabCourse = myset.Tables["Course"];
            tabStudents = myset.Tables["Students"];
            fillcombo();

        }
        private void fillcombo()
        {
            cboCourse.DataSource = tabCourse;
            cboCourse.DisplayMember = "Title";
            cboCourse.ValueMember = "RefCourse";

            cboGender.DataSource = tabStudents;
            cboGender.DisplayMember = "Gender";

        }
        private void btnFind_Click(object sender, EventArgs e)
        {

            if (chkGender.Checked == false && chkCourse.Checked == false)
            {

                gridSearch.DataSource = tabStudents;
            }
            else if (chkGender.Checked == true && chkCourse.Checked == true)
            {
                var ccStudents = from DataRow stud in tabStudents.Rows
                                where stud.Field<string>("Gender") == cboGender.Text && stud.Field<int>("ReferCourse") == Convert.ToInt32(cboCourse.SelectedValue)
                                select new { Names = stud.Field<string>("Fullname"), Birthdate = stud.Field<DateTime>("Birthdate"), Genders = stud.Field<string>("Gender") };

                if (ccStudents.Count() > 0)
                {
                    gridSearch.DataSource = ccStudents.ToList();

                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
            else if (chkGender.Checked == false && chkCourse.Checked == true)
            {
                var ccStudents = from DataRow stud in tabStudents.Rows
                                where stud.Field<int>("ReferCourse") == Convert.ToInt32(cboCourse.SelectedValue)
                                select new { Names = stud.Field<string>("Fullname"), Birthdate = stud.Field<DateTime>("Birthdate"), Genders = stud.Field<string>("Gender") };

                if (ccStudents.Count() > 0)
                {
                    gridSearch.DataSource = ccStudents.ToList();

                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
            else if (chkGender.Checked == true && chkCourse.Checked == false)
            {
                var ccStudents = from DataRow stud in tabStudents.Rows
                                where stud.Field<string>("Gender") == cboGender.Text
                                select new { Names = stud.Field<string>("Fullname"), Birthdate = stud.Field<DateTime>("Birthdate"), Genders = stud.Field<string>("Gender") };

                if (ccStudents.Count() > 0)
                {
                    gridSearch.DataSource = ccStudents.ToList();

                }
                else
                {
                    gridSearch.DataSource = null;
                }
            }
        }
    }
}
