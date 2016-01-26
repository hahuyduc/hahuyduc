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
    class LoaiPhongBUS
    {
        private static readonly LoaiPhongDAO LP = new LoaiPhongDAO();
        public static void Insert(LoaiPhong lp)
        {
            LP.LoaiPhong_Insert(lp);
        }

        public static void Update(LoaiPhong lp)
        {
            LP.LoaiPhong_Update(lp);
        }

        public static void Delete(string MaLP)
        {
            LP.LoaiPhong_Delete(MaLP);
        }

        public static string FindMaLP(string TenLP)
        {
            return LP.LoaiPhong_FindMaLP(TenLP);
        }

        public static int SoNguoiMax(string MaPhong)
        {
            return LP.LoaiPhong_SoNguoiMax(MaPhong);
        }

        public static double GetGia(string MaPhong)
        {
            return LP.LoaiPhong_GetGia(MaPhong);
        }
        public static string XuLyMa()
        {
            string ma = "";
            ma = LP.LoaiPhong_MaTuDong();
            if (ma == null)
            {
                return "LP001";
            }
            string kyTuDau = ma.Substring(0, 2);
            int soCanTang = Convert.ToInt32(ma.Substring(2)) + 1;
            string MaLP = "";
            if (soCanTang >= 0 && soCanTang < 10)
                MaLP = kyTuDau + "00" + soCanTang;
            if (soCanTang >= 10 && soCanTang < 100)
                MaLP = kyTuDau + "0" + soCanTang;
            if (soCanTang >= 100 && soCanTang < 1000)
                MaLP = kyTuDau + soCanTang;
            if (soCanTang >= 10000)
                MaLP = "Không thể tăng hơn nữa!";
            return MaLP;

        }        
    }
}
