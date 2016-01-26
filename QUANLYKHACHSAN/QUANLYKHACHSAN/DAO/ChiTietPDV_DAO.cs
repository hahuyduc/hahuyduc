using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.DAO
{
    public class ChiTietPDV_DAO:SqlDataProvider
    {
        public DataTable ChiTietPDV_GetAll()
        {
            using (var cmd = new SqlCommand("SP_ChiTietPDV_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void ChiTietPDV_Insert(ChiTietPDV ctpdv)
        {
            using (var cmd = new SqlCommand("SP_ChiTietPDV_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDV", ctpdv.MaCTPDV));
                cmd.Parameters.Add(new SqlParameter("@MaPDV", ctpdv.MaPDV));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", ctpdv.SoLuong));
                cmd.Parameters.Add(new SqlParameter("@MaDV", ctpdv.MaDV));
                cmd.ExecuteNonQuery();
            }
        }
        public void ChiTietPDV_Update(ChiTietPDV ctpdv)
        {
            using (var cmd = new SqlCommand("SP_ChiTietPDV_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDV", ctpdv.MaCTPDV));
                cmd.Parameters.Add(new SqlParameter("@MaPDV", ctpdv.MaPDV));
                cmd.Parameters.Add(new SqlParameter("@SoLuong", ctpdv.SoLuong));
                cmd.Parameters.Add(new SqlParameter("@MaDV", ctpdv.MaDV));
                cmd.ExecuteNonQuery();
            }
        }
        public void ChiTietPDV_Delete(string mact)
        {
            using (var cmd = new SqlCommand("SP_ChiTietPDV_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDV", mact));
                cmd.ExecuteNonQuery();
            }
        }
        public string ChiTietPDV_Matudong()
        {
            using (var cmd = new SqlCommand("SP_ChiTietPDV_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();

            }
        }
    }
}
