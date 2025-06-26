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
            UtilityBill bill = new UtilityBill();
            bill.RoomID = Convert.ToInt32(cmbRoomID.SelectedItem);
            bill.Month = cmbMonth.SelectedItem.ToString();
            bill.Electricity = (float)Convert.ToDouble(txtElectricity.Text);
            bill.Water = (float)Convert.ToDouble(txtWater.Text);
            bill.Gas = (float)Convert.ToDouble(txtGas.Text);
            bill.Status = cmbStatus.SelectedItem.ToString();

            controller.AddBill(bill);
            MessageBox.Show("Bill added successfully.");
            dgvBills.DataSource = controller.GetAllBills();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBillID.Text == "")
            {
                MessageBox.Show("Please select a bill to update.");
                return;
            }

            UtilityBill bill = new UtilityBill();
            bill.BillID = Convert.ToInt32(txtBillID.Text);
            bill.RoomID = Convert.ToInt32(cmbRoomID.SelectedItem);
            bill.Month = cmbMonth.SelectedItem.ToString();
            bill.Electricity = (float)Convert.ToDouble(txtElectricity.Text);
            bill.Water = (float)Convert.ToDouble(txtWater.Text);
            bill.Gas = (float)Convert.ToDouble(txtGas.Text);
            bill.Status = cmbStatus.SelectedItem.ToString();

            controller.UpdateBill(bill);
            MessageBox.Show("Bill updated successfully.");
            dgvBills.DataSource = controller.GetAllBills();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBillID.Text == "")
            {
                MessageBox.Show("Please select a bill to delete.");
                return;
            }

            int billId = Convert.ToInt32(txtBillID.Text);
            controller.DeleteBill(billId);
            MessageBox.Show("Bill deleted successfully.");
            dgvBills.DataSource = controller.GetAllBills();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBillID.Text == "")
            {
                MessageBox.Show("Please enter a Bill ID to search.");
                return;
            }

            int billId = Convert.ToInt32(txtBillID.Text);
            UtilityBill bill = controller.SearchBill(billId);

            if (bill != null)
            {
                cmbRoomID.SelectedItem = bill.RoomID;
                cmbMonth.SelectedItem = bill.Month;
                txtElectricity.Text = bill.Electricity.ToString();
                txtWater.Text = bill.Water.ToString();
                txtGas.Text = bill.Gas.ToString();
                cmbStatus.SelectedItem = bill.Status;
                MessageBox.Show("Bill found.");
            }
            else
            {
                MessageBox.Show("Bill not found.");
            }
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

        private void btnCllear_Click(object sender, EventArgs e)
        {
            txtBillID.Clear();
            txtElectricity.Clear();
            txtWater.Clear();
            txtGas.Clear();
            cmbMonth.SelectedIndex = 0;
            cmbRoomID.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

        }
    }
}
