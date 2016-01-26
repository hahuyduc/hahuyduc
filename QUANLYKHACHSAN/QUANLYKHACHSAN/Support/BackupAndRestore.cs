using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYKHACHSAN.Support
{
    class BackupAndRestore : SqlDataProvider
    {
        private static void Database()
        {
            using (var conn = new SqlConnection("Data Source=VAIO"))
            {
                using(var cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "Create Database QLKS";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void backup(string filename)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            string query = "Backup database QLKS to disk = '" + filename + ".bak' ";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.CommandType = CommandType.Text;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Restore(string filename)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            string query = "RESTORE DATABASE master FROM DISK ='" + filename + "' WITH REPLACE";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.CommandType = CommandType.Text;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
