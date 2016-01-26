using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class LoaiPhongDAO:SqlDataProvider
    {
        public void LoaiPhong_Insert(LoaiPhong lp)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaLP", lp.MaLP));
                cmd.Parameters.Add(new SqlParameter("@TenLP", lp.TenLP));
                cmd.Parameters.Add(new SqlParameter("@MoTa", lp.MoTa));
                cmd.Parameters.Add(new SqlParameter("@SoNguoiMax", lp.SoNguoiMax));
                cmd.Parameters.Add(new SqlParameter("@Gia", lp.Gia));
                cmd.ExecuteNonQuery();
            }
        }

        public void LoaiPhong_Update(LoaiPhong lp)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaLP", lp.MaLP));
                cmd.Parameters.Add(new SqlParameter("@TenLP", lp.TenLP));
                cmd.Parameters.Add(new SqlParameter("@MoTa", lp.MoTa));
                cmd.Parameters.Add(new SqlParameter("@SoNguoiMax", lp.SoNguoiMax));
                cmd.Parameters.Add(new SqlParameter("@Gia", lp.Gia));
                cmd.ExecuteNonQuery();
            }
        }

        public void LoaiPhong_Delete(string maLP)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaLP", maLP));
                cmd.ExecuteNonQuery();
            }
        }

        public string LoaiPhong_MaTuDong()
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
            }
        }
        public string LoaiPhong_FindMaLP(string TenLP)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_FindMaLP", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenLP", TenLP));
                return (string)cmd.ExecuteScalar();
            }
        }

        public int LoaiPhong_SoNguoiMax(string MaPhong)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_SoNguoiMax", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", MaPhong));
                return (int)cmd.ExecuteScalar();
            }
        }

        public double LoaiPhong_GetGia(string MaPhong)
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_GetGia", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", MaPhong));
                return (double)cmd.ExecuteScalar();
            }
        }
    }
}
