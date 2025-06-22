using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class Rooms
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddRoom(Room room)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Rooms (RoomNumber, Capacity, Status) VALUES (@roomNumber, @capacity, @status);");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
            cmd.Parameters.AddWithValue("@capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@status", room.Status);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateRoom(Room room)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Rooms SET RoomNumber=@roomNumber, Capacity=@capacity, Status=@status WHERE RoomID=@roomID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roomID", room.RoomID);
            cmd.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
            cmd.Parameters.AddWithValue("@capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@status", room.Status);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteRoom(int roomID)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Rooms WHERE RoomID=@roomID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roomID", roomID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public Room SearchRoom(int roomID)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Rooms WHERE RoomID = @roomID");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roomID", roomID);

            List<Room> roomList = GetData(cmd);

            if (roomList.Count > 0)
                return roomList[0];
            else
                return null;
        }

        public List<Room> GetAllRooms()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Rooms;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        private List<Room> GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            List<Room> roomList = new List<Room>();

            using (sdr)
            {
                while (sdr.Read())
                {
                    Room room = new Room();
                    room.RoomID = sdr.GetInt32(0);
                    room.RoomNumber = sdr.GetString(1);
                    room.Capacity = sdr.GetInt32(2);
                    room.Status = sdr.GetString(3);
                    roomList.Add(room);
                }
                sdr.Close();
            }

            cmd.Connection.Close();
            return roomList;
        }

        public Room SearchRoomByID(int roomID)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Rooms WHERE RoomID = @roomID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@roomID", roomID);
            List<Room> roomList = GetData(cmd);
            if (roomList.Count > 0)
            {
                return roomList[0];
            }
            else
            {
                return null;
            }
        }
    }
}
