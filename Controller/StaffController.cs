using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.Controller
{
    public class StaffController
    {
        Staffs staffs;

        public StaffController()
        {
            staffs = new Staffs();
        }

        public void AddStaff(Staff s)
        {
            staffs.AddStaff(s);
        }

        public void UpdateStaff(Staff s)
        {
            staffs.UpdateStaff(s);
        }

        public void DeleteStaff(int staffID)
        {
            staffs.DeleteStaff(staffID);
        }

        public Staff SearchStaff(int staffID)
        {
            Staff s = staffs.SearchStaff(staffID);
            return s;
        }

        public List<Staff> GetAllStaff()
        {
            List<Staff> staffList = staffs.GetAllStaff();
            return staffList;
        }
    }
}
