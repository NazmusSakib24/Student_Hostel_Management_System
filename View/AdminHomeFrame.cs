using Student_Hostel_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Hostel_Management_System.View
{
    public partial class AdminHomeFrame : Form
    {
        private User loggedInUser;
        public AdminHomeFrame(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
        }

        private void AdminHomeFrame_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome,{loggedInUser.Username}";
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOperationForm uof = new UserOperationForm(loggedInUser);
            uof.Show();
        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            this.Hide();
            UtilityBillForm billForm = new UtilityBillForm(loggedInUser);
            billForm.Show();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomOperationForm roomForm = new RoomOperationForm(loggedInUser);
            roomForm.Show();
        }

        private void btnServiceRequests_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServiceRequestForm srf = new ServiceRequestForm(loggedInUser);
            srf.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentOperationForm studentForm = new StudentOperationForm(loggedInUser);
            studentForm.Show();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffOperationForm staffForm = new StaffOperationForm(loggedInUser);
            staffForm.Show();
        }
    }
}
