using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System.Data;
namespace QUANLYKHACHSAN.BUS
{
    class PhieuDangKyPhongBUS
    {
        private static readonly PhieuDangKyPhongDAO db = new PhieuDangKyPhongDAO();

        public static DataTable GetAll()
        {
            return db.DangKyPhong_GetAll();
        }

        public static void DangKyPhong_Insert(PhieuDangKyPhong dk)
        {
            db.DangKyPhong_Insert(dk);
        }

        public static void DangKyPhong_Update(PhieuDangKyPhong dk)
        {
            db.DangKyPhong_Update(dk);
        }

        public static void UpdateTongTien(PhieuDangKyPhong dk)
        {
            db.DangKyPhong_UpdateTongTien(dk);
        }

        public static void UpdateTongTienNull(string MaPDK)
        {
            db.DangKyPhong_UpdateTongTienNull(MaPDK);
        }

        public static int KiemTraPhongTrong(string MaPhong)
        {
            return db.DangKyPhong_KiemTraPhongTrong(MaPhong);
        }

        public static void DangKyPhong_Delete(string MaPDK)
        {
            db.DangKyPhong_Delete(MaPDK);
        }

        public static int CountPhongDK(string MaPDK)
        {
            return db.DangKyPhong_CoutPhongDK(MaPDK);
        }

        public static int SoLuongPhong(string MaPDK)
        {
            return db.DangKyPhong_SoLuongPhong(MaPDK);
        }
        public static List<string> ListPDK()
        {
            return db.DangKyPhong_ListPDK();
        }

        public static List<string> GetByMaPDK(string MaPDK)
        {
            return db.DangKyPhong_GetByMaPDK(MaPDK);
        }

        public static void UpdatePhuongThuc(PhieuDangKyPhong dk)
        {
            db.DangKyPhong_UpdatePhuongThuc(dk);
        }

        public static List<DateTime> ListNgayNhanPhong(string MaPhong)
        {
            return db.DangKyPhong_ListNgayNhanPhong(MaPhong);
        }

        public static List<DateTime> ListNgayTraPhong(string MaPhong)
        {
            return db.DangKyPhong_ListNgayTraPhong(MaPhong);
        }
        public static string XuLyMa()
        {
            string ma = "";
            ma = db.DangKyPhong_MaTuDong();
            if (ma == null)
            {
                return "PDK0001";
            }
            string kyTuDau = ma.Substring(0, 3);
            int soCanTang = Convert.ToInt32(ma.Substring(3)) + 1;
            string MaPDK = "";
            if (soCanTang >= 0 && soCanTang < 10)
                MaPDK = kyTuDau + "000" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                MaPDK = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                MaPDK = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 1000 && soCanTang < 10000)
                MaPDK = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                MaPDK = "Không thể tăng hơn nữa!";
            return MaPDK;
        }

        public static List<string> GetMaPDK()
        {
            return db.DangKyPhong_GetMaPDK();
        }

        public static List<string> GetNhanPhong(string MaPDK)
        {
            return db.DangKyPhong_GetNhanPhong(MaPDK);
        }

        public static DataTable ThongTinNhanPhong()
        {
            return db.DangKyPhong_GetAllNhanPhong();
        }

        public static DateTime  NgayNhanPhong(string MaPDK)
        {
            return db.DangKyPhong_NgayNhanPhong(MaPDK);
        }
        public static DateTime NgayTraPhong(string MaPDK)
        {
            return db.DangKyPhong_NgayTraPhong(MaPDK);
        }
        
        public static String GetPhuongThuc(string MaPDK)
        {
            return db.DangKyPhong_GetPhuongThuc(MaPDK);
        }
    }
}
