using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;

namespace QUANLYKHACHSAN.DAO
{
    public class NhanVienDAO:SqlDataProvider
    {
        public DataTable NhanVien_GetAll()
        {
            using (var cmd = new SqlCommand("SP_NhanVien_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void NhanVien_Insert(NhanVien nv)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", nv.MaNV));
                cmd.Parameters.Add(new SqlParameter("@MatKhau", nv.MatKhau));
                cmd.Parameters.Add(new SqlParameter("@TenNV", nv.TenNV));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", nv.NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", nv.GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@MaCV", nv.MaCV));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", nv.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@Email", nv.Email));
                cmd.Parameters.Add(new SqlParameter("@SDT", nv.SDT));
                cmd.ExecuteNonQuery();
            }
        }
        public void NhanVien_Update(NhanVien nv)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", nv.MaNV));
                cmd.Parameters.Add(new SqlParameter("@MatKhau", nv.MatKhau));
                cmd.Parameters.Add(new SqlParameter("@TenNV", nv.TenNV));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", nv.NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", nv.GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@MaCV", nv.MaCV));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", nv.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@Email", nv.Email));
                cmd.Parameters.Add(new SqlParameter("@SDT", nv.SDT));
                cmd.ExecuteNonQuery();
            }
        }
        public void NhanVien_Delete(string maNV)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", maNV));
                cmd.ExecuteNonQuery();
            }
        }
        public string NhanVien_Matudong()
        {
            using (var cmd = new SqlCommand("SP_NhanVien_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();

            }
        }
        public DataTable NhanVien_SearchByMaNV(string manv)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_SearchByMaNV", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", manv));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable NhanVien_SearchByTenNV(string tennv)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_SearchByTenNV", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenNV", tennv));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int NhanVien_DangNhap(string id,string pass)
        {
            using (var cmd = new SqlCommand("SP_NhanVien_DangNhap", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", id));
                cmd.Parameters.Add(new SqlParameter("@MatKhau", pass));
               
                return Convert.ToInt16(cmd.ExecuteScalar());
            }
        }
        public int NhanVien_DoiMatKhau(string id, string passCu, string passMoi)
        {
            using (var cmd = new SqlCommand("SP_DoiMatKhau", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaNV", id));
                cmd.Parameters.Add(new SqlParameter("@MatKhauCu", passCu));
                cmd.Parameters.Add(new SqlParameter("@MatKhauMoi", passMoi));

                return Convert.ToInt16(cmd.ExecuteScalar());
            }
        }
    }
}
