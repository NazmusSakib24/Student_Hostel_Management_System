using Student_Hostel_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Controller
{
    public class UtilityBillController
    {
        UtilityBills bills = new UtilityBills();

        public void AddBill(UtilityBill bill)
        {
            bills.AddBill(bill);
        }

        public void UpdateBill(UtilityBill bill)
        {
            bills.UpdateBill(bill);
        }

        public void DeleteBill(int billID)
        {
            bills.DeleteBill(billID);
        }

        public UtilityBill SearchBill(int billID)
        {
            return bills.SearchBill(billID);
        }

        public List<UtilityBill> GetAllBills()
        {
            return bills.GetAllBills();
        }
    }
}
