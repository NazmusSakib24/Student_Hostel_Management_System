using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Hostel_Management_System.Model;

namespace Student_Hostel_Management_System.Controller
{
    public class RoomController
    {
        private Rooms rooms = new Rooms();

        public void AddRoom(Room room)
        {
            rooms.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            rooms.UpdateRoom(room);
        }

        public void DeleteRoom(int roomID)
        {
            rooms.DeleteRoom(roomID);
        }

        public Room SearchRoom(int roomID)
        {
            return rooms.SearchRoom(roomID);
        }

        public Room SearchRoomByID(int roomID)
        {
            Rooms rooms = new Rooms();
            return rooms.SearchRoomByID(roomID);
        }


        public List<Room> GetAllRooms()
        {
            return rooms.GetAllRooms();
        }
    }
}
