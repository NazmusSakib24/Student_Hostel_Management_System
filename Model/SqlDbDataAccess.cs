using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student_Hostel_Management_System.Model
{
    public class SqlDbDataAccess
    {
        private const string connectionString = @"Data Source=Nazmus-Sakib\SQLEXPRESS; Initial Catalog=Hostel_Management_System; Integrated Security=True";

        public SqlCommand GetQuery(string query)
        {
            var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}
