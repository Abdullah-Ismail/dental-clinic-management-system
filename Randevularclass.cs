using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diş_kliniği_yönetim_sistemi
{
    internal class Randevularclass
    {
        public void AddHasta(string query)
        {
            ConnectionString myconn = new ConnectionString();
            SqlConnection con = myconn.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void deletehasta(string query)
        {
            ConnectionString myconn = new ConnectionString();
            SqlConnection con = myconn.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Updatehasta(string query)
        {
            ConnectionString myconn = new ConnectionString();
            SqlConnection con = myconn.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet showhasta(string query)
        {
            ConnectionString myconn = new ConnectionString();
            SqlConnection con = myconn.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
