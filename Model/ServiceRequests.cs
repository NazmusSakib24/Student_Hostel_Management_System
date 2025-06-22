using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class ServiceRequests
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddRequest(ServiceRequest request)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO ServiceRequests (StudentID, RoomID, Type, Description, Status) VALUES (@studentID, @roomID, @type, @description, @status);");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", request.StudentID);
            cmd.Parameters.AddWithValue("@roomID", request.RoomID);
            cmd.Parameters.AddWithValue("@type", request.Type);
            cmd.Parameters.AddWithValue("@description", request.Description);
            cmd.Parameters.AddWithValue("@status", request.Status);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateRequest(ServiceRequest request)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE ServiceRequests SET StudentID=@studentID, RoomID=@roomID, Type=@type, Description=@description, Status=@status WHERE RequestID=@requestID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@requestID", request.RequestID);
            cmd.Parameters.AddWithValue("@studentID", request.StudentID);
            cmd.Parameters.AddWithValue("@roomID", request.RoomID);
            cmd.Parameters.AddWithValue("@type", request.Type);
            cmd.Parameters.AddWithValue("@description", request.Description);
            cmd.Parameters.AddWithValue("@status", request.Status);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteRequest(int requestID)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM ServiceRequests WHERE RequestID=@requestID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@requestID", requestID);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public ServiceRequest SearchRequest(int requestID)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM ServiceRequests WHERE RequestID=@requestID;");
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@requestID", requestID);
            List<ServiceRequest> list = GetData(cmd);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public List<ServiceRequest> GetAllRequests()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM ServiceRequests;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        public List<ServiceRequest> GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ServiceRequest> list = new List<ServiceRequest>();

            using (reader)
            {
                while (reader.Read())
                {
                    ServiceRequest r = new ServiceRequest();
                    r.RequestID = reader.GetInt32(0);
                    r.StudentID = reader.GetInt32(1);
                    r.RoomID = reader.GetInt32(2);
                    r.Type = reader.GetString(3);
                    r.Description = reader.GetString(4);
                    r.Status = reader.GetString(5);

                    list.Add(r);
                }
                reader.Close();
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
