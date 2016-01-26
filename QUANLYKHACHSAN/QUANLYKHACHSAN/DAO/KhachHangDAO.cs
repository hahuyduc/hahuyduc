using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    public class KhachHangDAO:SqlDataProvider
    {
        public DataTable KhachHang_GetAll()
        {
            using (var cmd = new SqlCommand("SP_KhachHang_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void KhachHang_Insert(KhachHang kh)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", kh.MaKH));
                cmd.Parameters.Add(new SqlParameter("@TenKH", kh.TenKH));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", kh.GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", kh.NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@QuocTich", kh.QuocTich));
                cmd.Parameters.Add(new SqlParameter("@CMND", kh.CMND));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", kh.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@Email", kh.Email));
                cmd.Parameters.Add(new SqlParameter("@SDT", kh.SDT));
                cmd.ExecuteNonQuery();
            }
        }
        public void KhachHang_Update(KhachHang kh)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", kh.MaKH));
                cmd.Parameters.Add(new SqlParameter("@TenKH", kh.TenKH));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", kh.GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", kh.NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@QuocTich", kh.QuocTich));
                cmd.Parameters.Add(new SqlParameter("@CMND", kh.CMND));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", kh.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@Email", kh.Email));
                cmd.Parameters.Add(new SqlParameter("@SDT", kh.SDT));
                cmd.ExecuteNonQuery();
            }
        }
        public void KhachHang_Delete(string maKh)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", maKh));
                cmd.ExecuteNonQuery();
            }
        }
        public string KhachHang_Matudong()
        {
            using (var cmd = new SqlCommand("SP_KhachHang_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
                
            }
        }
        public DataTable KhachHang_SearchByMaKH(string makh)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_SearchByMaKH", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", makh));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public string KhachHang_SearchTenKHByMaKH(string MaKH)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_SearchTenKHByMaKH", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaKH", MaKH));
                return (string)cmd.ExecuteScalar();
            }
        }

        public string KhachHang_SearchTenKHByCMND(string CMND)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_SearchTenKHByCMND", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
                return (string)cmd.ExecuteScalar();
            }
        }
        public DataTable KhachHang_SearchByTenKH(string tenkh)
        {
            using (var cmd = new SqlCommand("SP_KhachHang_SearchByTenKH", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenKH", tenkh));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
