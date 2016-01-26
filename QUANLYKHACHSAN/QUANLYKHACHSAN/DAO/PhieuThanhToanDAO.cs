using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.DAO
{
    public class PhieuThanhToanDAO:SqlDataProvider
    {
        public DataTable PhieuThanhToan_DanhSachChuaTT()
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_DanhSachChuaTT", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public double PhieuThanhToan_TongTienDichVu(string MaPDK)
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_TongTienDichVu", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPDK", MaPDK));
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }
        public void PhieuThanhToan_Insert(PhieuThanhToan ptt)
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_Insert", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPTT", ptt.MaPTT));
                cmd.Parameters.Add(new SqlParameter("@MaPDK", ptt.MaPDK));
                cmd.Parameters.Add(new SqlParameter("@MaNV", ptt.MaNV));
                cmd.Parameters.Add(new SqlParameter("@NgayLap", ptt.NgayLap));
                cmd.Parameters.Add(new SqlParameter("@PhatSinh", ptt.PhatSinh));
                cmd.Parameters.Add(new SqlParameter("@Thue", ptt.Thue));
                cmd.Parameters.Add(new SqlParameter("@TienPhaiTra", ptt.TienPhaiTra));
                
                cmd.ExecuteNonQuery();
            }
        }
        public void PhieuThanhToan_Update(PhieuThanhToan ptt)
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_Update", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPTT", ptt.MaPTT));
                cmd.Parameters.Add(new SqlParameter("@PhatSinh", ptt.PhatSinh));
                cmd.Parameters.Add(new SqlParameter("@Thue", ptt.Thue));
                cmd.Parameters.Add(new SqlParameter("@TienPhaiTra", ptt.TienPhaiTra));
                cmd.ExecuteNonQuery();
            }
        }
        public void PhieuThanhToan_Delete(string MaPTT)
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_Delete", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaPTT", MaPTT));
                cmd.ExecuteNonQuery();
            }
        }
        public string PhieuThanhToan_Matudong()
        {
            using (var cmd = new SqlCommand("SP_PhieuThanhToan_Top1", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (string)cmd.ExecuteScalar();
                
            }
        }
    }
}
