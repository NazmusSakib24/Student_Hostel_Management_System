using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Hostel_Management_System.Model;
using Student_Hostel_Management_System.Controller;  


namespace Student_Hostel_Management_System.View
{
    public partial class StudentDashboardForm : Form
    {

        private User loggedInUser;
        private StudentController studentController = new StudentController();
        private RoomController roomController = new RoomController();
        public StudentDashboardForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
        }
        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {loggedInUser.Username}";
            Student student = studentController.GetStudentByUserID(loggedInUser.UserID);
            if (student != null)
            {
                Room room = roomController.SearchRoomByID(student.AssignedRoomID);
                if (room != null)
                {
                    lblRoomNum.Text = $"Room Number: {room.RoomNumber}";
                    lblCapacity.Text = $"Capacity: {room.Capacity}";
                    lblStatus.Text = $"Status: {room.Status}";
                }
            }
        }
        private void btnRequest_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //StudentRequestForm requestForm = new StudentRequestForm(loggedInUser);
            //requestForm.Show();
        }

        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            {
              
            }
        }

        private void btnMyBills_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnRequest_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            ServiceRequestForm x = new ServiceRequestForm(loggedInUser);
            x.Show();
        }
    }
}
