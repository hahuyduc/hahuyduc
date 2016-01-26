using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using QUANLYKHACHSAN.DAO;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.BUS
{
    class PhongBUS
    {
        private static readonly PhongDAO ph = new PhongDAO();

        public static DataTable DanhSach()
        {
            return ph.Phong_DanhSach();
        }
        public static DataTable SearchBy(string key, string loaitk)
        {
            return ph.Phong_SearchBy(key, loaitk);
        }
        public static void Insert(Phong phong)
        {
            ph.Phong_Insert(phong);
        }

        public static void Update(Phong phong)
        {
            ph.Phong_Update(phong);
        }

        public static void Delete(string MaPhong)
        {
            ph.Phong_Delete(MaPhong);
        }

        public static DataTable GetAll()
        {
            return ph.Phong_GetALL();
        }

        public static List<string> GetPhongTrong()
        {
            return ph.Phong_SearchMaPhong();
        }

        public static void UpdateHienTrang(Phong phong)
        {
            ph.Phong_UpdateHienTrang(phong);
        }

        public static List<string> GetPhongByMaPDK(string MaPDK)
        {
            return ph.Phong_GetPhongByMaPDK(MaPDK);
        }

    }
}
