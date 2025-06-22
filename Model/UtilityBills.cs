using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Hostel_Management_System.Model
{
    public class UtilityBills
    {
            SqlDbDataAccess sda = new SqlDbDataAccess();

            public void AddBill(UtilityBill bill)
            {
                SqlCommand cmd = sda.GetQuery("INSERT INTO UtilityBills(RoomID, Month, Electricity, Water, Gas, Status) VALUES (@roomID, @month, @electricity, @water, @gas, @status)");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@roomID", bill.RoomID);
                cmd.Parameters.AddWithValue("@month", bill.Month);
                cmd.Parameters.AddWithValue("@electricity", bill.Electricity);
                cmd.Parameters.AddWithValue("@water", bill.Water);
                cmd.Parameters.AddWithValue("@gas", bill.Gas);
                cmd.Parameters.AddWithValue("@status", bill.Status);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            public void UpdateBill(UtilityBill bill)
            {
                SqlCommand cmd = sda.GetQuery("UPDATE UtilityBills SET RoomID=@roomID, Month=@month, Electricity=@electricity, Water=@water, Gas=@gas, Status=@status WHERE BillID=@billID");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@billID", bill.BillID);
                cmd.Parameters.AddWithValue("@roomID", bill.RoomID);
                cmd.Parameters.AddWithValue("@month", bill.Month);
                cmd.Parameters.AddWithValue("@electricity", bill.Electricity);
                cmd.Parameters.AddWithValue("@water", bill.Water);
                cmd.Parameters.AddWithValue("@gas", bill.Gas);
                cmd.Parameters.AddWithValue("@status", bill.Status);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            public void DeleteBill(int billID)
            {
                SqlCommand cmd = sda.GetQuery("DELETE FROM UtilityBills WHERE BillID=@billID");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@billID", billID);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            public UtilityBill SearchBill(int billID)
            {
                SqlCommand cmd = sda.GetQuery("SELECT * FROM UtilityBills WHERE BillID=@billID");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@billID", billID);
                List<UtilityBill> list = GetData(cmd);
                if (list.Count > 0)
                {
                    return list[0];
                }
                else
                {
                    return null;
                }
            }

            public List<UtilityBill> GetAllBills()
            {
                SqlCommand cmd = sda.GetQuery("SELECT * FROM UtilityBills");
                cmd.CommandType = CommandType.Text;
                return GetData(cmd);
            }

            public List<UtilityBill> GetData(SqlCommand cmd)
            {
                List<UtilityBill> list = new List<UtilityBill>();
                cmd.Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UtilityBill bill = new UtilityBill();
                    bill.BillID = sdr.GetInt32(0);
                    bill.RoomID = sdr.GetInt32(1);
                    bill.Month = sdr.GetString(2);
                    bill.Electricity = (float)sdr.GetDouble(3);
                    bill.Water = (float)sdr.GetDouble(4);
                    bill.Gas = (float)sdr.GetDouble(5);
                    bill.Status = sdr.GetString(6);
                    list.Add(bill);
                }
                sdr.Close();
                cmd.Connection.Close();
                return list;
            }
        }
    }
