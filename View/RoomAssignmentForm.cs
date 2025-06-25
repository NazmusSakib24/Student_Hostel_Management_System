using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.View
{
    public partial class RoomAssignmentForm : Form
    {
        Students students = new Students(); 
        public RoomAssignmentForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadRooms();
        }

        void LoadStudents() 
        {
            SqlDbDataAccess sda = new SqlDbDataAccess();
            SqlCommand cmd = sda.GetQuery("Select StudentID FROM Students;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbStudent.Items.Add(reader["StudenID"].ToString());
            }

            reader.Close();
            cmd.Connection.Close();

        }

        void LoadRooms()
        {
            SqlDbDataAccess sda = new SqlDbDataAccess();
            SqlCommand cmd = sda.GetQuery("Select RoomID From Rooms Where Status 'Availabl';");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbRoom.Items.Add(reader["RoomID"].ToString());
            }

            reader.Close();
            cmd.Connection.Close();
            
        }
      


        private void RoomAssignmentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbStudent.Text == "" || cmbRoom.Text == "")
            {
                MessageBox.Show("Please select both student and room.");
                return;
            }

            int studentId = Convert.ToInt32(cmbStudent.Text);
            int roomId = Convert.ToInt32(cmbRoom.Text);

            students.AssignRoom(studentId, roomId);

            MessageBox.Show("Room assigned successfully!");
            cmbStudent.Text = "";
            cmbRoom.Text = "";
        }
    }
}

