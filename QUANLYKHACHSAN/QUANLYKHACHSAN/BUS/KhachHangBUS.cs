using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{ 
    public class KhachHangBUS
    {
        private static readonly KhachHangDAO db = new KhachHangDAO();

        public static DataTable GetAll()
        {
            return db.KhachHang_GetAll();
        }
        public static DataTable SearchByMaKH(string maKH)
        {
            return db.KhachHang_SearchByMaKH(maKH);
        }
        public static string SearchTenKHBYMaKH(string MaKH)
        {
            return db.KhachHang_SearchTenKHByMaKH(MaKH);
        }

        public static string SearchTenKHByCMND(string CMND)
        {
            return db.KhachHang_SearchTenKHByCMND(CMND);
        }
        public static DataTable SearchByTenKH(string tenKH)
        {
            return db.KhachHang_SearchByTenKH(tenKH);
        }
        public static void Insert(KhachHang kh)
        {
            db.KhachHang_Insert(kh);
        }
        public static void Update(KhachHang kh)
        {
            db.KhachHang_Update(kh);
        }
        public static void Delete(string makh)
        {
            db.KhachHang_Delete(makh);
        }

        public static string XuLyMa()
        {
            string ma = "";
            ma = db.KhachHang_Matudong();
            if (ma == null)
            {
                return "KH0001";
            }
            string kyTuDau = ma.Substring(0, 2);
            int soCanTang = Convert.ToInt32(ma.Substring(2)) + 1;
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
