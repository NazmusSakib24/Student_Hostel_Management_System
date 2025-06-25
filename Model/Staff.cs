using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Staff
    {


        public int staffID;
        public int userID;
        public string name;
        public string phone;

        public Staff() { }

        public Staff(int staffID, int userID, string name, string phone)
            {
              this.staffID = staffID;
              this.userID = userID;
              this.name = name;
              this.phone = phone;
            }

        public int StaffID
        {
            get { return this.staffID; }
            set { this.staffID = value; }

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
       
        }
    }


