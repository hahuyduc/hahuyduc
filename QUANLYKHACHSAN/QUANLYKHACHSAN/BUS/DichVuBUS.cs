using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using QUANLYKHACHSAN.DAO;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{
    class DichVuBUS
    {
        private static readonly DichVuDAO db = new DichVuDAO();

        public static DataTable SearchBy(string key, string loaitk)
        {
            return db.DichVu_SearchBy(key, loaitk);
        }
        public static void Insert(DichVu dv)
        {
            db.DichVu_Insert(dv);
        }

        public static void Update(DichVu dv)
        {
            db.DichVu_Update(dv);
        }

        public static void Delete(string MaDV)
        {
            db.DichVu_Delete(MaDV);
        }

        public static string XuLyMa()
        {

            string ma = "";
            ma = db.DichVu_MaTuDong();
            if (ma == null)
            {
                return "DV001";
            }
            string kyTuDau = ma.Substring(0, 2);
            int soCanTang = Convert.ToInt32(ma.Substring(2)) + 1;
            string maDV = "";
            if (soCanTang >= 0 && soCanTang < 10)
                maDV = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                maDV = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                maDV = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                maDV = "Không thể tăng hơn nữa!";
            return maDV;

        }
    }
}
