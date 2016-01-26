using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class DangKyPhongCTDAO:SqlDataProvider
    {

        public void DangKyPhongCT_Insert(DangKyPhongCT dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhongCT_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDK", dk.MaCTPDK));
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@MaPhong", dk.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@SoLuongNguoi", dk.SoLuongNguoi));
                cmd.ExecuteNonQuery();
            }
        }

        public void DangKyPhongCT_Update(DangKyPhongCT dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhongCT_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDK", dk.MaCTPDK));
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@MaPhong", dk.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@SoLuongNguoi", dk.SoLuongNguoi));
                cmd.ExecuteNonQuery();
            }
        }
        public void DangKyPhongCT_Delete(string MaCTPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhongCT_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaCTPDK", MaCTPDK));
                cmd.ExecuteNonQuery();
            }
        }

        public string DangKyPhongCT_MaTuDong()
        {
            using (var cmd = new SqlCommand("SP_DangKyPhongCT_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
            }
        }

        public List<string> DangKyPhongCT_NhanPhong(string MaPDK)
        {
            List<string> ds_PDK = new List<string>();
            using (var cmd = new SqlCommand("SP_DangKyPhongCT_NhanPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                ds_PDK = dt.AsEnumerable().Select(r => r.Field<string>("MaPhong")).ToList();
                return ds_PDK;
            }
        }
    }
}
