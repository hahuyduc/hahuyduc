using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYKHACHSAN
{
    public class SqlDataProvider
    {
        public static string connectionstring;
        public static SqlConnection connection;
        public SqlDataProvider()
        {
            if (connection == null)
            {

                connectionstring =
                    ConfigurationManager.ConnectionStrings["QUANLYKHACHSAN.Properties.Settings.QLKSConnectionString2"].ToString();
                

                connection = new SqlConnection(connectionstring);
            }
        }
        public SqlConnection GetConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    return connection;
                }
                else
                {
                    return connection;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return connection;
            
        }
    }
}
