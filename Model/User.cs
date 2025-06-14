using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class User
    {
        private int userID;
        private string username;
        private int password;
        private RoleType role;
        private string securityAns;

        public User()
        {
            
        }

        public User(int userID, string username, int password, RoleType role, string securityAns)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.role = role;
            this.securityAns = securityAns;
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public int Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public RoleType Role
        {
            get { return this.role; }
            set { this.role = value; }
        }


        public string SecurityAns
        {
            get { return this.securityAns; }
            set { this.securityAns = value; }
        }
    }
}
