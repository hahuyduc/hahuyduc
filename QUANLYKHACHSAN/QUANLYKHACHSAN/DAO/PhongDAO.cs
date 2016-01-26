using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class PhongDAO:SqlDataProvider
    {
        public DataTable Phong_DanhSach()
        {
            using (var cmd = new SqlCommand("SP_LoaiPhong_Phong_DanhSach", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void Phong_Insert(Phong Ph)
        {
            using (var cmd = new SqlCommand("SP_Phong_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", Ph.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@SDTPhong", Ph.SDTPhong));
                cmd.Parameters.Add(new SqlParameter("@MaLP",Ph.MaLP));
                cmd.ExecuteNonQuery();
            }
        }

        public void Phong_Update(Phong Ph)
        {
            using (var cmd = new SqlCommand("SP_Phong_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", Ph.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@SDTPhong", Ph.SDTPhong));
                cmd.Parameters.Add(new SqlParameter("@MaLP", Ph.MaLP));
                cmd.ExecuteNonQuery();
            }
        }

        public void Phong_Delete(string maDV)
        {
            using (var cmd = new SqlCommand("SP_Phong_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", maDV));
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Phong_GetALL()
        {
            using (var cmd = new SqlCommand("SP_Phong_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public List<string> Phong_SearchMaPhong()
        {
            List<string> ds_MaPhong = new List<string>();
            using (var cmd = new SqlCommand("SP_Phong_SearchMaPhong", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        ds_MaPhong.Add(row[col].ToString());
                    }
                }
                return ds_MaPhong;
            }

        }
        public DataTable Phong_SearchBy(string key, string loaitk)
        {
            using (var cmd = new SqlCommand("SP_Phong_SearchBy" + loaitk, GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@" + loaitk, key));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Phong_UpdateHienTrang(Phong Ph)
        {
            using (var cmd = new SqlCommand("SP_Phong_UpdateHienTrang", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPhong", Ph.MaPhong));
                cmd.Parameters.Add(new SqlParameter("@HienTrang", Ph.HienTrang));
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> Phong_GetPhongByMaPDK(string MaPDK)
        {
            List<string> ds_PDK = new List<string>();
            using (var cmd = new SqlCommand("SP_Phong_GetPhongByMaPDK", GetConnection()))
            {
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                ds_PDK = dt.AsEnumerable().Select(r => r.Field<string>("MaPhong")).ToList();
                return ds_PDK;
            }
        }
    }
}
