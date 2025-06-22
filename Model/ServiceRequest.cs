using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class ServiceRequest
    {
        private int requestID;
        private int studentID;
        private int roomID;
        private string type;
        private string description;
        private string status;

        public ServiceRequest()
        {
        }

        public ServiceRequest(int requestID, int studentID, int roomID, string type, string description, string status)
        {
            this.requestID = requestID;
            this.studentID = studentID;
            this.roomID = roomID;
            this.type = type;
            this.description = description;
            this.status = status;
        }

        public int RequestID { get => requestID; set => requestID = value; }
        public int StudentID { get => studentID; set => studentID = value; }
        public int RoomID { get => roomID; set => roomID = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
    }
}
