using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.Controller
{
    public class UserController
    {
        Users users = new Users();

        public void AddUser(User user)
        {
            users.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            users.DeleteUser(userId);
        }

        public void UpdateUser(User user)
        {
            users.UpdateUser(user);
        }

        public User SearchUser(string username, int password)
        {
            return users.SearchUser(username, password);
        }

        public List<User> GetAlluser()
        {
            return users.GetAllUser();
        }

        public User SearchUserByUsernameAndSecurityAns(string username, string securityAns)
        {
            return users.SearchUserByUsernameAndSecurityAns(username, securityAns);
        }

    }
}
