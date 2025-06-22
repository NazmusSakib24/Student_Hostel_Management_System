using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Staff
    {
      
        
            public int StaffID { get; set; }
            public int UserID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }

            public Staff() { }

            public Staff(int staffID, int userID, string name, string phone)
            {
                this.StaffID = staffID;
                this.UserID = userID;
                this.Name = name;
                this.Phone = phone;
            }
        }
    }


