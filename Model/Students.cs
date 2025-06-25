using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Students
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddStudent(Student student)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Students (UserID, Name, Phone, AssignedRoomID) VALUES (@userID, @name, @phone, @roomID);");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userID", student.UserID);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@phone", student.Phone);
            cmd.Parameters.AddWithValue("@roomID", student.AssignedRoomID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateStudent(Student student)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Students SET UserID=@userID, Name=@name, Phone=@phone, AssignedRoomID=@roomID WHERE StudentID=@studentID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", student.StudentID);
            cmd.Parameters.AddWithValue("@userID", student.UserID);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@phone", student.Phone);
            cmd.Parameters.AddWithValue("@roomID", student.AssignedRoomID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteStudent(int studentID)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Students WHERE StudentID=@studentID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public Student SearchStudent(string name)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Students WHERE Name = @name;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);

            List<Student> studentList = GetData(cmd);

            if (studentList.Count > 0)
                return studentList[0];
            else
                return null;
        }

        public List<Student> GetAllStudents()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Students;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        public List<Student> GetData(SqlCommand cmd)
        {
            List<Student> studentList = new List<Student>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Student s = new Student();
                    s.StudentID = reader.GetInt32(0);
                    s.UserID = reader.GetInt32(1);
                    s.Name = reader.GetString(2);
                    s.Phone = reader.GetString(3);
                    s.AssignedRoomID = reader.GetInt32(4);
                   
                    studentList.Add(s); 
                }

                reader.Close();
            }

            cmd.Connection.Close();
            return studentList;
        }


        public Student GetStudentByUserID(int userId)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Students WHERE UserID = @userID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userID", userId);
            List<Student> list = GetData(cmd);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public Student SearchStudentByUserID(int userID)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Students WHERE UserID = @userID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userID", userID);
            List<Student> studentList = GetData(cmd);
            if (studentList.Count > 0)
            {
                return studentList[0];
            }
            else
            {
                return null;
            }
        }

        public void AssignRoom(int studentID, int roomID)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Students SET AssignedRoomID = @roomID WHERE StudentID = @studentID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@roomID", roomID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


    }
}
