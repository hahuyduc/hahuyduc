using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.BUS
{
    public class PhieuDichVuBUS
    {
        private static readonly PhieuDichVuDAO db = new PhieuDichVuDAO();

        public static DataTable GetAll()
        {
            return db.PhieuDichVu_GetAll();
        }
        public static DataTable ThongTinPhong(string maphong)
        {
            return db.PhieuDichVu_ThongTinPhong(maphong);
        }
        public static DataTable SearchByMaPDK(string maPDK,string maPhong)
        {
            return db.PhieuDichVu_SearchByMaPDK(maPDK,maPhong);
        }
        
        public static void Insert(PhieuDichVu kh)
        {
            db.PhieuDichVu_Insert(kh);
        }
        public static void Update(PhieuDichVu kh)
        {
            db.PhieuDichVu_Update(kh);
        }
        public static void Delete(string mapdv)
        {
            db.PhieuDichVu_Delete(mapdv);
        }
        public static string XuLyMa()
        {
            string ma = "";
            ma = db.PhieuDichVu_Matudong();
            if (ma == null)
            {
                return "PDV0001";
            }
            string kyTuDau = ma.Substring(0, 3);
            int soCanTang = Convert.ToInt32(ma.Substring(3)) + 1;
            string makh = "";
            if (soCanTang >= 0 && soCanTang < 10)
                makh = kyTuDau + "000" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                makh = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                makh = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 1000 && soCanTang < 10000)
                makh = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                makh = "Không thể tăng hơn nữa!";
            return makh;
        }
    }
}
