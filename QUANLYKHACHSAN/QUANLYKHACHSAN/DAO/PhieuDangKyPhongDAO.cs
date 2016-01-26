using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class PhieuDangKyPhongDAO:SqlDataProvider
    {
        public DataTable DangKyPhong_GetAll()
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void DangKyPhong_Insert(PhieuDangKyPhong dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@MaKH", dk.MaKH));
                cmd.Parameters.Add(new SqlParameter("@MaNV", dk.MaNV));
                cmd.Parameters.Add(new SqlParameter("@SoLuongPhong", dk.SoLuongphong));
                cmd.Parameters.Add(new SqlParameter("@NgayDangKy", dk.NgayDangKy));
                cmd.Parameters.Add(new SqlParameter("@NgayNhanPhong", dk.NgayNhanPhong));
                cmd.Parameters.Add(new SqlParameter("@NgayTraPhong", dk.NgayTraPhong));
                cmd.ExecuteNonQuery();
            }
        }

        public void DangKyPhong_Update(PhieuDangKyPhong dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@MaKH", dk.MaKH));
                cmd.Parameters.Add(new SqlParameter("@MaNV", dk.MaNV));
                cmd.Parameters.Add(new SqlParameter("@SoLuongPhong", dk.SoLuongphong));
                cmd.Parameters.Add(new SqlParameter("@NgayDangKy", dk.NgayDangKy));
                cmd.Parameters.Add(new SqlParameter("@NgayNhanPhong", dk.NgayNhanPhong));
                cmd.Parameters.Add(new SqlParameter("@NgayTraPhong", dk.NgayTraPhong));
                cmd.ExecuteNonQuery();
            }
        }

        public void DangKyPhong_UpdateTongTien(PhieuDangKyPhong dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_UpdateTongTien", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@TongTien", dk.TongTien));
                cmd.ExecuteNonQuery();
            }
        }

        public void DangKyPhong_UpdateTongTienNull(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_UpdateTongTienNull", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                cmd.ExecuteNonQuery();
            }
        }

        public int DangKyPhong_KiemTraPhongTrong(string MaPhong)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_KiemTraPhongTrong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", MaPhong));
                return (int)cmd.ExecuteNonQuery();
            }
        }

        
        public void DangKyPhong_Delete(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                cmd.ExecuteNonQuery();
            }
        }

        public string DangKyPhong_MaTuDong()
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
            }
        }

        public int DangKyPhong_CoutPhongDK(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_PhongDK", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                return (int)cmd.ExecuteScalar();
            }
        }

        public int DangKyPhong_SoLuongPhong(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_SoLuongPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                return (int)cmd.ExecuteScalar();
            }
        }
        
        public List<string> DangKyPhong_ListPDK()
        {
            List<string> ds_PDK = new List<string>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_ListPDK", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                ds_PDK = dt.AsEnumerable().Select(r => r.Field<string>("MaPDK")).ToList();
                return ds_PDK;
            }
        }


        public List<string> DangKyPhong_GetByMaPDK(string MaPDK)
        {
            List<string> ds_PDK = new List<string>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_GetByMaPDK", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow row in dt.Rows)
                {
                    foreach(DataColumn col in dt.Columns)
                    {
                        ds_PDK.Add(row[col].ToString());
                    }
                }
                return ds_PDK;
            }
        }

        public void DangKyPhong_UpdatePhuongThuc(PhieuDangKyPhong dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_UpdatePhuongThuc", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@PhuongThuc", dk.PhuongThucTinhTien));
                cmd.ExecuteNonQuery();
            }
        }

        public List<DateTime> DangKyPhong_ListNgayNhanPhong(string MaPhong)
        {
            List<DateTime> ds_Time = new List<DateTime>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_ListNgayNhanPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", MaPhong));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        ds_Time.Add((DateTime)row[col]);
                    }
                }
                return ds_Time;
            }
        }

        public List<DateTime> DangKyPhong_ListNgayTraPhong(string MaPhong)
        {
            List<DateTime> ds_Time = new List<DateTime>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_ListNgayTraPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", MaPhong));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        ds_Time.Add((DateTime)row[col]);
                    }
                }
                return ds_Time;
            }
        }

        public List<string> DangKyPhong_GetMaPDK()
        {
            List<string> ds_PDK = new List<string>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_GetMaPDK", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                ds_PDK = dt.AsEnumerable().Select(r => r.Field<string>("MaPDK")).ToList();
                return ds_PDK;
            }
        }

        public List<string> DangKyPhong_GetNhanPhong(string MaPDK)
        {
            List<string> ThongTinNhanPhong = new List<string>();
            using (var cmd = new SqlCommand("SP_DangKyPhong_GetNhanPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        ThongTinNhanPhong.Add(row[col].ToString());
                    }
                }
                return ThongTinNhanPhong;
            }
        }

        public DataTable DangKyPhong_GetAllNhanPhong()
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_GetAllNhanPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DateTime DangKyPhong_NgayNhanPhong(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_NgayNhanPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));

                return (DateTime)cmd.ExecuteScalar();
            }
        }

        public DateTime DangKyPhong_NgayTraPhong(string MaPDK)
        {

            using (var cmd = new SqlCommand("SP_DangKyPhong_NgayTraPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));

                return (DateTime)cmd.ExecuteScalar();
            }
        }

        public string DangKyPhong_GetPhuongThuc(string MaPDK)
        {

            using (var cmd = new SqlCommand("SP_DangKyPhong_GetPhuongThuc", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));

                return (string)cmd.ExecuteScalar();
            }
        }

        public void DangKyPhongCT_UpdateTongTien(PhieuDangKyPhong dk)
        {
            using (var cmd = new SqlCommand("SP_DangKyPhong_UpdateTongTien", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", dk.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@TongTien", dk.TongTien));   
                cmd.ExecuteNonQuery();
            }
        }
    }
}
