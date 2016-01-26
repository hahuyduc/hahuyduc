using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.DAO;
using QUANLYKHACHSAN.Object;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{
    class ThamSoBUS
    {
        private static readonly ThamSoDAO db = new ThamSoDAO();

        public static int ThamSo_SoPhongMax()
        {
            return db.ThamSo_SoPhongMax();
        }

        public static double TienNgay()
        {
            return db.ThamSo_TienNgay();
        }

        public static double TienGio()
        {
            return db.ThamSo_TienGio();
        }
    }
}
