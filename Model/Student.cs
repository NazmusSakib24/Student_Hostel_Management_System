using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Student
    {
        public int studentID;
        public int userID;
        public string name;
        public string phone;
        public int assignedRoomID;

        public int StudentID
        {
            get { return this.studentID; }
            set { this.studentID = value; }
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public int AssignedRoomID
        {
            get { return this.assignedRoomID; }
            set { this.assignedRoomID = value; }
        }


        public Student()
        {

        }

        public Student(int studentID, int userID, string name, string phone, int assignedRoomID)
        {
            StudentID = studentID;
            UserID = userID;
            Name = name;
            Phone = phone;
            AssignedRoomID = assignedRoomID;

        }


    }
}

