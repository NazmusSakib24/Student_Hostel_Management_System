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

        public int RequestID 
        {   get { return this.requestID; }
            set { this.requestID = value; }
        }  
        public int StudentID 
        {
            get { return this.studentID; }
            set { this.studentID = value; }
        }

        public int RoomID
        {
            get { return this.roomID; }
            set { this.roomID = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
