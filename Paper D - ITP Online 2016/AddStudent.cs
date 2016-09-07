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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            DataTable dt = new DBAccess().getCourses();
            cmbCourse.DataSource = dt;
            cmbCourse.DisplayMember = "course_name";
            cmbCourse.ValueMember = "course_id";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DBAccess db = new DBAccess();
            /*if (db.addStudent(txtName.Text, Convert.ToInt32(cmbCourse.SelectedValue.ToString()),
                dtpDOB.Value, cmbGender.Text, txtAddress.Text, Security.Encrypt(txtPhone.Text)))
                MessageBox.Show("New Record added");
            else MessageBox.Show("Error: record could not be added");*/
            for(int i = 00; i < 10000; i++)
            {
                //DBAccess db = new DBAccess();
                db.addStudent(txtName.Text, Convert.ToInt32(cmbCourse.SelectedValue.ToString()),
                    dtpDOB.Value, cmbGender.Text, txtAddress.Text, Security.Encrypt(new Random().Next(12345,8765445).ToString()));
                    
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
