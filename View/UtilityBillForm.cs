using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Student_Hostel_Management_System.Model;
using Student_Hostel_Management_System.Controller;

namespace Student_Hostel_Management_System.View
{
    public partial class UtilityBillForm : Form
    {
        private UtilityBillController controller;
        private User loggedInUser;

        public UtilityBillForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            controller = new UtilityBillController();
        }

        private void UtilityBillForm_Load(object sender, EventArgs e)
        {
            cmbMonth.Items.AddRange(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            cmbMonth.SelectedIndex = 0;

            cmbStatus.Items.Add("Paid");
            cmbStatus.Items.Add("Unpaid");
            cmbStatus.SelectedIndex = 0;

            // Populate Room IDs
            RoomController roomController = new RoomController();
            List<Room> rooms = roomController.GetAllRooms();
            cmbRoomID.Items.Clear();
            foreach (Room r in rooms)
            {
                cmbRoomID.Items.Add(r.RoomID);
            }

            dgvBills.DataSource = controller.GetAllBills();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBillID.Clear();
            txtElectricity.Clear();
            txtWater.Clear();
            txtGas.Clear();
            cmbMonth.SelectedIndex = 0;
            cmbRoomID.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomeFrame admin = new AdminHomeFrame(loggedInUser);
            admin.Show();
        }

        private void dgvBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBills.Rows[e.RowIndex];
                txtBillID.Text = row.Cells[0].Value.ToString();
                cmbRoomID.SelectedItem = Convert.ToInt32(row.Cells[1].Value);
                cmbMonth.SelectedItem = row.Cells[2].Value.ToString();
                txtElectricity.Text = row.Cells[3].Value.ToString();
                txtWater.Text = row.Cells[4].Value.ToString();
                txtGas.Text = row.Cells[5].Value.ToString();
                cmbStatus.SelectedItem = row.Cells[6].Value.ToString();
            }
        }
    }
}
