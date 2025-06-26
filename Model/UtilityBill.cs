using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class UtilityBill
    {
            private int billID;
            private int roomID;
            private string month;
            private float electricity;
            private float water;
            private float gas;
            private string status;

            public UtilityBill()
            {
                
            }

            public UtilityBill(int billID, int roomID, string month, float electricity, float water, float gas, string status)
            {
                this.billID = billID;
                this.roomID = roomID;
                this.month = month;
                this.electricity = electricity;
                this.water = water;
                this.gas = gas;
                this.status = status;
            }

            public int BillID
            {
                get { return billID; }
                set { billID = value; }
            }

            public int RoomID
            {
                get { return roomID; }
                set { roomID = value; }
            }

            public string Month
            {
                get { return month; }
                set { month = value; }
            }

            public float Electricity
            {
                get { return electricity; }
                set { electricity = value; }
            }

            public float Water
            {
                get { return water; }
                set { water = value; }
            }

            public float Gas
            {
                get { return gas; }
                set { gas = value; }
            }

            public string Status
            {
                get { return status; }
                set { status = value; }
            }
        }
    }

