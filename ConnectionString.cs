using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace diş_kliniği_yönetim_sistemi
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AbOoDy\Documents\DisDb.mdf;Integrated Security=True;Connect Timeout=30";
            return con;
        }
        
    }
}
