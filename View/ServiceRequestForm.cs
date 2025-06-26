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
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvRequest.Rows[e.RowIndex];
                txtRequestID.Text = row.Cells[0].Value.ToString();
                cmbStudentID.SelectedItem = Convert.ToInt32(row.Cells[1].Value);
                cmbRoomID.SelectedItem = Convert.ToInt32(row.Cells[2].Value);
                cmbType.SelectedItem = row.Cells[3].Value.ToString();
                txtDescription.Text = row.Cells[4].Value.ToString();
                cmbStatus.SelectedItem = row.Cells[5].Value.ToString();
            }
        }
    }
}
