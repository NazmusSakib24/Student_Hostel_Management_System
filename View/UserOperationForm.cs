using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Student_Hostel_Management_System.Model;
using Student_Hostel_Management_System.Controller;

namespace Student_Hostel_Management_System.View
{
    public partial class UserOperationForm : Form
    {
        private UserController controller;
        private User loggedInUser;

        public UserOperationForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            controller = new UserController();
        }

        private void UserOperationForm_Load(object sender, EventArgs e)
        {
            // Role dropdown filtering
            if (loggedInUser.Role == RoleType.Admin)
            {
                cmbRole.DataSource = Enum.GetValues(typeof(RoleType));
            }
            else
            {
                cmbRole.DataSource = new RoleType[] { RoleType.Staff, RoleType.Student };
            }

            txtUserID.Enabled = false;

            // Filter Admins from grid if logged-in user is not Admin
            var users = controller.GetAlluser();
            if (loggedInUser.Role != RoleType.Admin)
            {
                users = users.Where(u => u.Role != RoleType.Admin).ToList();
            }
            dgvUsers.DataSource = users;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                int password = Convert.ToInt32(txtPassword.Text);
                RoleType role = (RoleType)cmbRole.SelectedItem;
                string securityAns = txtSecurityAns.Text;

                if (role == RoleType.Admin && loggedInUser.Role != RoleType.Admin)
                {
                    MessageBox.Show("You are not allowed to create Admin users.");
                    return;
                }

                User user = new User(0, username, password, role, securityAns);
                controller.AddUser(user);
                MessageBox.Show("User Added Successfully");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            if ((RoleType)cmbRole.SelectedItem == RoleType.Admin && loggedInUser.Role != RoleType.Admin)
            {
                MessageBox.Show("You are not allowed to modify Admin users.");
                return;
            }

            try
            {
                int userId = Convert.ToInt32(txtUserID.Text);
                string username = txtUsername.Text;
                int password = Convert.ToInt32(txtPassword.Text);
                RoleType role = (RoleType)cmbRole.SelectedItem;
                string securityAns = txtSecurityAns.Text;

                User user = new User(userId, username, password, role, securityAns);
                controller.UpdateUser(user);
                MessageBox.Show("User Updated Successfully");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            if ((RoleType)cmbRole.SelectedItem == RoleType.Admin && loggedInUser.Role != RoleType.Admin)
            {
                MessageBox.Show("You are not allowed to delete Admin users.");
                return;
            }

            try
            {
                int userId = Convert.ToInt32(txtUserID.Text);
                controller.DeleteUser(userId);
                MessageBox.Show("User Deleted Successfully");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            int password = Convert.ToInt32(txtPassword.Text);

            User user = controller.SearchUser(username, password);
            if (user != null)
            {
                if (user.Role == RoleType.Admin && loggedInUser.Role != RoleType.Admin)
                {
                    MessageBox.Show("You are not allowed to search Admin users.");
                    return;
                }

                txtUserID.Text = user.UserID.ToString();
                txtUserID.Enabled = false;
                txtUsername.Text = user.Username;
                txtPassword.Text = user.Password.ToString();
                cmbRole.SelectedItem = user.Role;
                txtSecurityAns.Text = user.SecurityAns;

                MessageBox.Show("User Found");
            }
            else
            {
                MessageBox.Show("User Not Found");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtUserID.Clear();
            txtUserID.Enabled = true;
            txtUsername.Clear();
            txtPassword.Clear();
            txtSecurityAns.Clear();
            cmbRole.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            var users = controller.GetAlluser();
            if (loggedInUser.Role != RoleType.Admin)
            {
                users = users.Where(u => u.Role != RoleType.Admin).ToList();
            }
            dgvUsers.DataSource = users;
            dgvUsers.Refresh();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (loggedInUser.Role == RoleType.Admin)
            {
                AdminHomeFrame ah = new AdminHomeFrame(loggedInUser);
                ah.Show();
            }
            else
            {
                StaffHomeFrom sh = new StaffHomeFrom(loggedInUser);
                sh.Show();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                txtUserID.Text = row.Cells[0].Value.ToString();
                txtUserID.Enabled = false;
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                cmbRole.SelectedItem = Enum.Parse(typeof(RoleType), row.Cells[3].Value.ToString());
                txtSecurityAns.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
