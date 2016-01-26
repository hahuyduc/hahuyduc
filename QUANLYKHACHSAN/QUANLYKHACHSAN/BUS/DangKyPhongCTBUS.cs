using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{
    class DangKyPhongCTBUS
    {
        private static readonly DangKyPhongCTDAO db = new DangKyPhongCTDAO();

        public static void DangKyPhongCT_Insert(DangKyPhongCT dk)
        {
            db.DangKyPhongCT_Insert(dk);
        }

        public static void DangKyPhongCT_Update(DangKyPhongCT dk)
        {
            db.DangKyPhongCT_Update(dk);
        }

        public static void Delete(string MaCTPDK)
        {
            db.DangKyPhongCT_Delete(MaCTPDK);
        }

        public static List<string> NhanPhong(string MaPDK)
        {
            return db.DangKyPhongCT_NhanPhong(MaPDK);
        }

        public static string XuLyMa()
        {
            string ma = "";
            ma = db.DangKyPhongCT_MaTuDong();
            if (ma == null)
            {
                return "CTDK0001";
            }
            string kyTuDau = ma.Substring(0, 4);
            int soCanTang = Convert.ToInt32(ma.Substring(4)) + 1;
            string MaCTPDK = "";
            if (soCanTang >= 0 && soCanTang < 10)
                MaCTPDK = kyTuDau + "000" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                MaCTPDK = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                MaCTPDK = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 1000 && soCanTang < 10000)
                MaCTPDK = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                MaCTPDK = "Không thể tăng hơn nữa!";
            return MaCTPDK;
        }
    }
}
