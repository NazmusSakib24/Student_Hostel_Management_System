using Student_Hostel_Management_System.Controller;
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
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void ForgetPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string securityAns = txtSecurityAns.Text;
            int newPassword;

            if (!int.TryParse(txtNewPassword.Text, out newPassword))
            {
                MessageBox.Show("Password must be a number.");
                return;
            }

            UserController controller = new UserController();
            User user = controller.SearchUserByUsernameAndSecurityAns(username, securityAns);

            if (user != null)
            {
                user.Password = newPassword;
                controller.UpdateUser(user);
                MessageBox.Show("Password reset successfully!");
                this.Hide();
                LoginForm lf = new LoginForm();
                lf.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Security Answer.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
    }
}
