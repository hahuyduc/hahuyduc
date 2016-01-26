using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class DichVuDAO:SqlDataProvider
    {
        public DataTable DichVu_SearchBy(string key,string loaitk)
        {
            using (var cmd = new SqlCommand("SP_DichVu_SearchBy"+loaitk, GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@"+loaitk, key));
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void DichVu_Insert(DichVu dv)
        {
            using (var cmd = new SqlCommand("SP_DichVu_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDV", dv.MaDV));
                cmd.Parameters.Add(new SqlParameter("@TenDV", dv.TenDV));
                cmd.Parameters.Add(new SqlParameter("@GiaDV", dv.GiaDV));
                cmd.Parameters.Add(new SqlParameter("@MoTa", dv.MoTa));
                cmd.ExecuteNonQuery();
            }
        }

        public void DichVu_Update(DichVu dv)
        {
            using (var cmd = new SqlCommand("SP_DichVu_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDV", dv.MaDV));
                cmd.Parameters.Add(new SqlParameter("@TenDV", dv.TenDV));
                cmd.Parameters.Add(new SqlParameter("@GiaDV", dv.GiaDV));
                cmd.Parameters.Add(new SqlParameter("@MoTa", dv.MoTa));
                cmd.ExecuteNonQuery();
            }
        }

        public void DichVu_Delete(string maDV)
        {
            using (var cmd = new SqlCommand("SP_DichVu_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaDV", maDV));
                cmd.ExecuteNonQuery();
            }
        }

        public string DichVu_MaTuDong()
        {
            using (var cmd = new SqlCommand("SP_DichVu_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}
