using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Student_Hostel_Management_System.Model;
using Student_Hostel_Management_System.Controller;

namespace Student_Hostel_Management_System.View
{
    public partial class RoomOperationForm : Form
    {
        private RoomController controller;
        private User loggedInUser;

        public RoomOperationForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            controller = new RoomController();
        }

        private void RoomOperationForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Occupied");
            cmbStatus.SelectedIndex = 0;

            txtRoomID.Enabled = false;
            dgvRooms.DataSource = controller.GetAllRooms();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string roomNumber = txtRoomNumber.Text;
                int capacity = Convert.ToInt32(txtCapacity.Text);
                string status = cmbStatus.SelectedItem.ToString();

                Room room = new Room(0, roomNumber, capacity, status);
                controller.AddRoom(room);

                MessageBox.Show("Room Added Successfully");
                dgvRooms.DataSource = controller.GetAllRooms();
                dgvRooms.Refresh();

                txtRoomID.Clear();
                txtRoomNumber.Clear();
                txtCapacity.Clear();
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text))
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            try
            {
                int roomID = Convert.ToInt32(txtRoomID.Text);
                string roomNumber = txtRoomNumber.Text;
                int capacity = Convert.ToInt32(txtCapacity.Text);
                string status = cmbStatus.SelectedItem.ToString();

                Room room = new Room(roomID, roomNumber, capacity, status);
                controller.UpdateRoom(room);

                MessageBox.Show("Room Updated Successfully");
                dgvRooms.DataSource = controller.GetAllRooms();
                dgvRooms.Refresh();

                txtRoomID.Clear();
                txtRoomNumber.Clear();
                txtCapacity.Clear();
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text))
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            try
            {
                int roomID = Convert.ToInt32(txtRoomID.Text);
                controller.DeleteRoom(roomID);

                MessageBox.Show("Room Deleted Successfully");
                dgvRooms.DataSource = controller.GetAllRooms();
                dgvRooms.Refresh();

                txtRoomID.Clear();
                txtRoomNumber.Clear();
                txtCapacity.Clear();
                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRoomID.Clear();
            txtRoomNumber.Clear();
            txtCapacity.Clear();
            cmbStatus.SelectedIndex = 0;
            txtRoomID.Enabled = true;
            txtSearch.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomeFrame admin = new AdminHomeFrame(loggedInUser);
            admin.Show();
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                txtRoomID.Text = row.Cells[0].Value.ToString();         
                txtRoomNumber.Text = row.Cells[1].Value.ToString();     
                txtCapacity.Text = row.Cells[2].Value.ToString();       
                cmbStatus.SelectedItem = row.Cells[3].Value.ToString();
                txtRoomID.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int roomID = Convert.ToInt32(txtSearch.Text);

            Room room = controller.SearchRoom(roomID);

            if (room != null)
            {
                txtRoomID.Text = room.RoomID.ToString();
                txtRoomID.Enabled = false;
                txtRoomNumber.Text = room.RoomNumber;
                txtCapacity.Text = room.Capacity.ToString();
                cmbStatus.SelectedItem = room.Status;

                MessageBox.Show("Room Found");
            }
            else
            {
                MessageBox.Show("Room Not Found");
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomAssignmentForm assignmentForm = new RoomAssignmentForm(loggedInUser);
            assignmentForm.ShowDialog();
        }
    }
}

