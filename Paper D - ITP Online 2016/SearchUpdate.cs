using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paper_D___ITP_Online_2016
{
    public partial class SearchUpdate : Form
    {
        public SearchUpdate()
        {
            InitializeComponent();
        }

        private void SearchUpdate_Load(object sender, EventArgs e)
        {
            DataTable dt = new DBAccess().getCourses();
            cmdCourse.DataSource = dt;
            cmdCourse.DisplayMember = "course_name";
            cmdCourse.ValueMember = "course_id";

            DBAccess db = new DBAccess();
            DataSet ds = db.getStudent(Convert.ToInt32(cmdCourse.SelectedValue.ToString()));
            dgvStudent.DataSource = ds.Tables["student"].DefaultView;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBAccess db = new DBAccess();
            DataSet ds = db.getStudent(Convert.ToInt32(cmdCourse.SelectedValue.ToString()));
            dgvStudent.DataSource = ds.Tables["student"].DefaultView;
        }

        private void dgvStudent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvStudent.Rows[e.RowIndex].Cells["student_id"].Value.ToString());
            string name = dgvStudent.Rows[e.RowIndex].Cells["student_name"].Value.ToString();
            DateTime dob = Convert.ToDateTime(dgvStudent.Rows[e.RowIndex].Cells["student_dob"].Value.ToString());
            string gender = dgvStudent.Rows[e.RowIndex].Cells["student_gender"].Value.ToString();
            string address = dgvStudent.Rows[e.RowIndex].Cells["student_address"].Value.ToString();
            Console.WriteLine(id);
            ViewDetails vd = new ViewDetails(id,name,dob,gender,address);
            vd.Show();
            this.Dispose();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
