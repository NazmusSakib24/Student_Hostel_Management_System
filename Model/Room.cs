using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Room
    {
        private int roomID;
        private string roomNumber;
        private int capacity;
        private string status;

        public Room()
        {
        }

        public Room(int roomID, string roomNumber, int capacity, string status)
        {
            this.RoomID = roomID;
            this.RoomNumber = roomNumber;
            this.Capacity = capacity;
            this.Status = status;
        }

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
