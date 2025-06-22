using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Staffs
    {
 
            SqlDbDataAccess sda = new SqlDbDataAccess();

            public void AddStaff(Staff staff)
            {
                SqlCommand cmd = sda.GetQuery("INSERT INTO Staff (UserID, Name, Phone) VALUES (@userID, @name, @phone);");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", staff.UserID);
                cmd.Parameters.AddWithValue("@name", staff.Name);
                cmd.Parameters.AddWithValue("@phone", staff.Phone);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            public void UpdateStaff(Staff staff)
            {
                SqlCommand cmd = sda.GetQuery("UPDATE Staff SET UserID=@userID, Name=@name, Phone=@phone WHERE StaffID=@staffID;");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@staffID", staff.StaffID);
                cmd.Parameters.AddWithValue("@userID", staff.UserID);
                cmd.Parameters.AddWithValue("@name", staff.Name);
                cmd.Parameters.AddWithValue("@phone", staff.Phone);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            public void DeleteStaff(int staffID)
            {
                SqlCommand cmd = sda.GetQuery("DELETE FROM Staff WHERE StaffID=@staffID;");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@staffID", staffID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

        public Staff SearchStaff(int staffID)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Staff WHERE StaffID=@staffID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@staffID", staffID);

            List<Staff> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }


        public List<Staff> GetAllStaff()
            {
                SqlCommand cmd = sda.GetQuery("SELECT * FROM Staff;");
                cmd.CommandType = CommandType.Text;
                return GetData(cmd);
            }

            public List<Staff> GetData(SqlCommand cmd)
            {
                List<Staff> list = new List<Staff>();
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Staff s = new Staff();
                        s.StaffID = reader.GetInt32(0);
                        s.UserID = reader.GetInt32(1);
                        s.Name = reader.GetString(2);
                        s.Phone = reader.GetString(3);
                        list.Add(s);
                    }
                    reader.Close();
                }

                cmd.Connection.Close();
                return list;
            }
        }
    }

