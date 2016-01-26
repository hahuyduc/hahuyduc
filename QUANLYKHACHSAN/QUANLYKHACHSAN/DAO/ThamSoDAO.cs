using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUANLYKHACHSAN.Object;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.DAO
{
    class ThamSoDAO:SqlDataProvider
    {
        public int ThamSo_SoPhongMax()
        {
            using (var cmd = new SqlCommand("SP_ThamSo_SoPhongMax", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (int)cmd.ExecuteScalar();

            }
        }

        public double ThamSo_TienNgay()
        {
            using (var cmd = new SqlCommand("SP_ThamSo_TienNgay", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (double)cmd.ExecuteScalar();

            }
        }

        public double ThamSo_TienGio()
        {
            using (var cmd = new SqlCommand("SP_ThamSo_TienGio", GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return (double)cmd.ExecuteScalar();

            }
        }

    }
}
