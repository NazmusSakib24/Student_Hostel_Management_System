using Student_Hostel_Management_System.Model;
using Student_Hostel_Management_System.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Hostel_Management_System.View;


namespace Student_Hostel_Management_System.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int password;

            if (!int.TryParse(txtPassword.Text, out password))
            {
                MessageBox.Show("Password must be a number.");
                return;
            }

            UserController controller = new UserController();
            User user = controller.SearchUser(username, password);

            if (user != null)
            {
                if (user.Username.Equals(username) && user.Password == password)
                {
                    if (user.Role == RoleType.Admin)
                    {
                        MessageBox.Show("Welcome Admin");
                        AdminHomeFrame adf = new AdminHomeFrame(user);
                        adf.Show();
                        this.Hide();
                    }
                    else if (user.Role == RoleType.Staff)
                    {
                        MessageBox.Show("Welcome Staff");
                        StaffHomeFrom staff = new StaffHomeFrom(user);
                        staff.Show();
                        this.Hide();
                    }
                    else if (user.Role == RoleType.Student)
                    {
                        MessageBox.Show("Welcome Student");
                        StudentDashboardForm student = new StudentDashboardForm(user);
                        student.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //RegistrationForm rf = new RegistrationForm();
           // rf.Show();
        }

        private void btnForget_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ///ForgetPasswordForm fp = new ForgetPasswordForm();
            //fp.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
