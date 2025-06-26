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
    public partial class ServiceRequestForm : Form
    {
        private User loggedInUser;
        private ServiceRequestController controller = new ServiceRequestController();
        public ServiceRequestForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
        }

        private void ServiceRequestForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.AddRange(new string[] { "Electrical", "Plumbing", "Internet", "Other" });
            cmbStatus.Items.AddRange(new string[] { "Pending", "Resolved" });
            cmbStatus.SelectedIndex = 0;

           
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAllRooms();
            cmbRoomID.Items.Clear();
            foreach (Room r in rooms)
            {
                cmbRoomID.Items.Add(r.RoomID);
            }

     
            StudentController studentController = new StudentController();
            List<Student> students = studentController.GetAllStudents();
            cmbStudentID.Items.Clear();
            foreach (Student s in students)
            {
                cmbStudentID.Items.Add(s.StudentID);
            }

            dgvRequest.DataSource = controller.GetAllRequests();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(cmbStudentID.SelectedItem);
            int roomID = Convert.ToInt32(cmbRoomID.SelectedItem);
            string type = cmbType.SelectedItem.ToString();
            string description = txtDescription.Text;
            string status = cmbStatus.SelectedItem.ToString();

            ServiceRequest r = new ServiceRequest(0, studentID, roomID, type, description, status);
            controller.AddRequest(r);

            MessageBox.Show("Request Added");
            dgvRequest.DataSource = controller.GetAllRequests();
            dgvRequest.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32(txtRequestID.Text);
            int studentID = Convert.ToInt32(cmbStudentID.SelectedItem);
            int roomID = Convert.ToInt32(cmbRoomID.SelectedItem);
            string type = cmbType.SelectedItem.ToString();
            string description = txtDescription.Text;
            string status = cmbStatus.SelectedItem.ToString();

            ServiceRequest r = new ServiceRequest(requestID, studentID, roomID, type, description, status);
            controller.UpdateRequest(r);

            MessageBox.Show("Request Updated");
            dgvRequest.DataSource = controller.GetAllRequests();
            dgvRequest.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32(txtRequestID.Text);
            controller.DeleteRequest(requestID);
            MessageBox.Show("Request Deleted");
            dgvRequest.DataSource = controller.GetAllRequests();
            dgvRequest.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32(txtRequestID.Text);
            ServiceRequest r = controller.SearchRequest(requestID);

            if (r != null)
            {
                cmbStudentID.SelectedItem = r.StudentID;
                cmbRoomID.SelectedItem = r.RoomID;
                cmbType.SelectedItem = r.Type;
                txtDescription.Text = r.Description;
                cmbStatus.SelectedItem = r.Status;
                MessageBox.Show("Request Found");
            }
            else
            {
                MessageBox.Show("Request Not Found");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRequestID.Clear();
            txtDescription.Clear();
            cmbStudentID.SelectedIndex = 0;
            cmbRoomID.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDashboardForm a = new StudentDashboardForm(loggedInUser);
            a.Show();
        }

        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is clicked and not the header
            if (e.RowIndex >= 0 && e.RowIndex < dgvRequest.Rows.Count)
            {
                DataGridViewRow row = dgvRequest.Rows[e.RowIndex];

                // Safely set text for TextBox controls
                txtRequestID.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                txtDescription.Text = row.Cells[4].Value?.ToString() ?? string.Empty;

                // For ComboBoxes, use FindStringExact or iterate to find the item
                // It's crucial that the values in the DataGridView match the items in the ComboBoxes.

                // For cmbStudentID:
                if (int.TryParse(row.Cells[1].Value?.ToString(), out int studentId))
                {
                    int index = cmbStudentID.FindStringExact(studentId.ToString());
                    if (index != -1)
                    {
                        cmbStudentID.SelectedIndex = index;
                    }
                    else
                    {
                        // Handle case where studentId is not found in cmbStudentID
                        cmbStudentID.SelectedIndex = -1; // Or set to a default/empty value
                    }
                }
                else
                {
                    cmbStudentID.SelectedIndex = -1; // Or handle invalid data
                }

                // For cmbRoomID:
                if (int.TryParse(row.Cells[2].Value?.ToString(), out int roomId))
                {
                    int index = cmbRoomID.FindStringExact(roomId.ToString());
                    if (index != -1)
                    {
                        cmbRoomID.SelectedIndex = index;
                    }
                    else
                    {
                        // Handle case where roomId is not found in cmbRoomID
                        cmbRoomID.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbRoomID.SelectedIndex = -1;
                }

                // For cmbType:
                string typeValue = row.Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(typeValue))
                {
                    int index = cmbType.FindStringExact(typeValue);
                    if (index != -1)
                    {
                        cmbType.SelectedIndex = index;
                    }
                    else
                    {
                        // Handle case where typeValue is not found in cmbType
                        cmbType.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbType.SelectedIndex = -1;
                }

                // For cmbStatus:
                string statusValue = row.Cells[5].Value?.ToString();
                if (!string.IsNullOrEmpty(statusValue))
                {
                    int index = cmbStatus.FindStringExact(statusValue);
                    if (index != -1)
                    {
                        cmbStatus.SelectedIndex = index;
                    }
                    else
                    {
                        // Handle case where statusValue is not found in cmbStatus
                        cmbStatus.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbStatus.SelectedIndex = -1;
                }
            }
        }
    }
}
