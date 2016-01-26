using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.BUS
{
    public class PhieuThanhToanBUS
    {
        private static readonly PhieuThanhToanDAO db = new PhieuThanhToanDAO();

        public static DataTable DanhSachChuaTT()
        {
            return db.PhieuThanhToan_DanhSachChuaTT();
        }
        public static double TongTienDichVu(string MaPDK)
        {
            return db.PhieuThanhToan_TongTienDichVu(MaPDK);
        }
        
        public static void Insert(PhieuThanhToan ptt)
        {
            db.PhieuThanhToan_Insert(ptt);
        }
        public static void Update(PhieuThanhToan ptt)
        {
            db.PhieuThanhToan_Update(ptt);
        }
        public static void Delete(string maptt)
        {
            db.PhieuThanhToan_Delete(maptt);
        }

        public static string XuLyMa()
        {
            string ma = "";
            ma = db.PhieuThanhToan_Matudong();
            if (ma == null)
            {
                return "PTT0001";
            }
            string kyTuDau = ma.Substring(0, 3);
            int soCanTang = Convert.ToInt32(ma.Substring(3)) + 1;
            string maptt = "";
            if (soCanTang >= 0 && soCanTang < 10)
                maptt = kyTuDau + "000" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                maptt = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                maptt = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 1000 && soCanTang < 10000)
                maptt = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                maptt = "Không thể tăng hơn nữa!";
            return maptt;
        }
    }
}
