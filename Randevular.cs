using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace diş_kliniği_yönetim_sistemi
{
    public partial class Randevular : Form
    {
        public Randevular()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void fillHasta()
        {
            SqlConnection con = MyCon.GetCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Hasadi from HasTbl",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader(); 
            DataTable dt = new DataTable();
            dt.Columns.Add("Hasadi", typeof(string));
            dt.Load(rdr);
            RanhastaCB.ValueMember = "Hasadi";
            RanhastaCB.DataSource = dt;
            con.Close();
        }
        private void fillTedavi()
        {
            SqlConnection con = MyCon.GetCon();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Tedadi from TedTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tedadi", typeof(string));
            dt.Load(rdr);
            RantedaviCB.ValueMember = "Tedadi";
            RantedaviCB.DataSource = dt;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Randevular_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into RendTbl values('" + RanhastaCB.SelectedItem.ToString() + "'," + RantedaviCB.SelectedItem.ToString() + ",'" + Rantarih.Value.Date + "','"+Ranzaman.Value.Date+"')";
            Hastaclass hastac = new Hastaclass();
            try
            {
                hastac.AddHasta(query);
                MessageBox.Show("Tedavi başarıyla eklendi");
                //populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
