using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.DAO
{
    public class PhieuDichVuDAO:SqlDataProvider
    {
        public DataTable PhieuDichVu_ThongTinPhong(string maphong)
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_ThongTinPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong",maphong));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable PhieuDichVu_SearchByMaPDK(string mapdk,string maphong)
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_SearchByMaPDK", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", mapdk));
                cmd.Parameters.Add(new SqlParameter("@MaPhong", maphong));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable PhieuDichVu_GetAll()
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void PhieuDichVu_Insert(PhieuDichVu pdv)
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", pdv.MaNV));
                cmd.Parameters.Add(new SqlParameter("@MaPDV", pdv.MaPDV));
                cmd.Parameters.Add(new SqlParameter("@MaPhong", pdv.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@MaPDK", pdv.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@TongTien", pdv.TongTien));
               
                cmd.ExecuteNonQuery();
            }
        }
        public void PhieuDichVu_Update(PhieuDichVu pdv)
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", pdv.MaNV));
                cmd.Parameters.Add(new SqlParameter("@MaPDV", pdv.MaPDV));
                cmd.Parameters.Add(new SqlParameter("@MaPhong", pdv.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@MaPDK", pdv.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@TongTien", pdv.TongTien));
                cmd.ExecuteNonQuery();
            }
        }
        public void PhieuDichVu_Delete(string maPDV)
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDV", maPDV));
                cmd.ExecuteNonQuery();
            }
        }
        public string PhieuDichVu_Matudong()
        {
            using (var cmd = new SqlCommand("SP_PhieuDichVu_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();

            }
        }
    }
}
