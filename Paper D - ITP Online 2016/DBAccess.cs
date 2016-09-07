using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paper_D___ITP_Online_2016
{
    class DBAccess
    {
        public DataTable getCourses()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("course_id", typeof(int));
            dt.Columns.Add("course_name", typeof(string));
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionManager.GetConnection();
            cmd.CommandText = "select * from course";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr.GetInt32(0), dr.GetString(1));
            }
            return dt;
        }

        public Boolean addStudent(string name, int courseID, DateTime dob, string gender, string address, string phone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionManager.GetConnection();
            cmd.CommandText = @"insert into student("+
                                "student_id, student_name,student_dob,"+
                                "student_gender,student_address,"+
                                "student_phone,course_id)"+
                                "values(@student_id,@student_name,@dob,@gender,@address,@phone,@course_id)";
            cmd.Parameters.Add("student_id", new Random().Next(0, 10000));
            cmd.Parameters.Add(new SqlParameter("student_name",name));
            cmd.Parameters.Add(new SqlParameter("dob", dob));
            cmd.Parameters.Add(new SqlParameter("gender", gender));
            cmd.Parameters.Add(new SqlParameter("address", address));
            cmd.Parameters.Add(new SqlParameter("phone", phone));
            cmd.Parameters.Add(new SqlParameter("course_id", courseID));
            if (cmd.ExecuteNonQuery() != 1) return false;
            return true;
        }

        public DataSet getStudent(int courseID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionManager.GetConnection();
            //cmd.CommandText = "select * from student where course_id=" + courseID;
            cmd.CommandText = "allStudents";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "student");
            return ds;
        }

        public Boolean DeleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionManager.GetConnection();
            cmd.CommandText = "delete from student where student_id =" + id;
            if (cmd.ExecuteNonQuery() != 1) return false;
            return true;
        }
    }
}
