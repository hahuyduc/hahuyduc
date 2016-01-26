using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class KhachSanDAO:SqlDataProvider
    {
        public void KhachSan_Update(KhachSan ks)
        {
            using (var cmd = new SqlCommand("SP_kHACHSAN_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenKhachSan", ks.TenKhachSan));
                cmd.Parameters.Add(new SqlParameter("@DiaChi", ks.DiaChi));
                cmd.Parameters.Add(new SqlParameter("@SDT", ks.SDT));
                cmd.Parameters.Add(new SqlParameter("@Email", ks.Email));
                cmd.Parameters.Add(new SqlParameter("@Website", ks.Website));
                cmd.Parameters.Add(new SqlParameter("@ChuThich", ks.ChuThich));
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> KhachSan_GetAll()
        {
            List<string> ThongTinNhanPhong = new List<string>();
            using (var cmd = new SqlCommand("SP_kHACHSAN_GetAll", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
