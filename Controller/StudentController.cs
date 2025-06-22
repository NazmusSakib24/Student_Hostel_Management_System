using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.Controller
{
    public class StudentController
    {

        Students students = new Students();

        public void AddStudent(Student s)
        {
            students.AddStudent(s);
        }

        public void UpdateStudent(Student s)
        {
            students.UpdateStudent(s);
        }

        public void DeleteStudent(int studentID)
        {
            students.DeleteStudent(studentID);
        }

        public Student SearchStudent(string name)
        {
            return students.SearchStudent(name);
        }


        public List<Student> GetAllStudents()
        {
            return students.GetAllStudents();
        }

        public Student GetStudentByUserID(int userId)
        {
            return students.GetStudentByUserID(userId);
        }

        public Student SearchStudentByUserID(int userID)
        {
            Student student = students.SearchStudentByUserID(userID);
            return student;
        }
    }
}

