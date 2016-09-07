using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Paper_D___ITP_Online_2016
{
    class ConnectionManager
    {
        public static SqlConnection con;
        public static string conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static SqlConnection GetConnection() {
            con = new SqlConnection(conString);
            con.Open();
            return con;
        }
    }
}
