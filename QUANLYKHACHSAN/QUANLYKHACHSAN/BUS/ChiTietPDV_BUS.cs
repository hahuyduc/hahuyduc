using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QUANLYKHACHSAN.BUS
{
    public class ChiTietPDV_BUS
    {
        private static readonly ChiTietPDV_DAO db = new ChiTietPDV_DAO();

        public static DataTable GetAll()
        {
            return db.ChiTietPDV_GetAll();
        }

        public static void Insert(ChiTietPDV kh)
        {
            db.ChiTietPDV_Insert(kh);
        }
        public static void Update(ChiTietPDV kh)
        {
            db.ChiTietPDV_Update(kh);
        }
        public static void Delete(string mapdv)
        {
            db.ChiTietPDV_Delete(mapdv);
        }
        public static string XuLyMa()
        {
            string ma = "";
            ma = db.ChiTietPDV_Matudong();
            if (ma == null)
            {
                return "CTPDV0001";
            }
            string kyTuDau = ma.Substring(0, 5);
            int soCanTang = Convert.ToInt32(ma.Substring(5)) + 1;
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
