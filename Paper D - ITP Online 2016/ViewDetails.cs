using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paper_D___ITP_Online_2016
{
    public partial class ViewDetails : Form
    {
        public ViewDetails()
        {
            InitializeComponent();
        }

        public ViewDetails(int student_id, string student_name, DateTime student_dob, string student_gender, string student_address)
        {
            InitializeComponent();
            lblStudentID.Text = student_id.ToString();
            txtStudentName.Text = student_name;
            dtpDOB.Value = student_dob;
            cmbGender.Text = student_gender;
            txtAddress.Text = student_address;
        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchUpdate su = new SearchUpdate();
            su.Show();
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want you to continue?","Delete Record",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (new DBAccess().DeleteStudent(Convert.ToInt32(lblStudentID.Text)))
                    MessageBox.Show("Record deleted!");
                else MessageBox.Show("Error: could not delete record");
            }
        }
    }
}
