using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using QUANLYKHACHSAN.DAO;
using System.Data;

namespace QUANLYKHACHSAN.BUS
{
    class KhachSanBUS
    {
        private static readonly KhachSanDAO ks = new KhachSanDAO();
        
        public static void Update(KhachSan khachsan)
        {
            ks.KhachSan_Update(khachsan);
        }
        public static List<string> GetAll()
        {
            return ks.KhachSan_GetAll();
        }
    }
}
