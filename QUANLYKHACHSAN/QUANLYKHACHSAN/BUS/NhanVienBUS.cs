using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{
    public class NhanVienBUS
    {
        private static readonly NhanVienDAO db = new NhanVienDAO();

        public static int DangNhap(string id,string pass)
        {
            return db.NhanVien_DangNhap(id, pass);
        }
        public static int DoiMatKhau(string id, string passCu,string passMoi)
        {
            return db.NhanVien_DoiMatKhau(id, passCu, passMoi);
        }
        public static DataTable GetAll()
        {
            return db.NhanVien_GetAll();
        }
        public static DataTable SearchByMaNV(string maNV)
        {
            return db.NhanVien_SearchByMaNV(maNV);
        }
        public static DataTable SearchByTenNV(string tenNV)
        {
            return db.NhanVien_SearchByTenNV(tenNV);
        }
        public static void Insert(NhanVien kh)
        {
            db.NhanVien_Insert(kh);
        }
        public static void Update(NhanVien kh)
        {
            db.NhanVien_Update(kh);
        }
        public static void Delete(string makh)
        {
            db.NhanVien_Delete(makh);
        }
        public static string XuLyMa()
        {
            string ma = "";
            ma = db.NhanVien_Matudong();
            if (ma == null)
            {
                return "NV0001";
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
