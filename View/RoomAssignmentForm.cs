using Student_Hostel_Management_System.Controller;
using Student_Hostel_Management_System.Model;
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

namespace Student_Hostel_Management_System.View
{
    public partial class RoomAssignmentForm : Form
    {
        private User loggedInUser;
        Students students = new Students(); 
        public RoomAssignmentForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadRooms();
        }

        public RoomAssignmentForm(User user)
        {
            InitializeComponent();
            this.loggedInUser = user;
            LoadStudents();
            LoadRooms();
        }

        void LoadStudents() 
        {
            StudentController studentController = new StudentController();
            List<Student> studentList = studentController.GetAllStudents();

            cmbStudent.DataSource = studentList;
            cmbStudent.DisplayMember = "studentID";
            cmbStudent.ValueMember = "studentID";
        }

        void LoadRooms()
        {
            RoomController roomController = new RoomController();
            List<Room> roomList = roomController.GetAllRooms();

            cmbRoom.DataSource = roomList;
            cmbRoom.DisplayMember = "RoomID";
            cmbRoom.ValueMember = "RoomID";

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

        private void button1_Click(object sender, EventArgs e)
        {
            RoomOperationForm roomOperationForm = new RoomOperationForm(loggedInUser);
            roomOperationForm.Show();
            this.Hide();
        }
    }
}

