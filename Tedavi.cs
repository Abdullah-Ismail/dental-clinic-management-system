using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diş_kliniği_yönetim_sistemi
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into TedTbl values('" + TedAdTB.Text + "'," + TedFiyatTB.Text + ",'" + TedRecTB.Text + "')";
            Hastaclass hastac = new Hastaclass();

            try
            {
                hastac.AddHasta(query);
                MessageBox.Show("Tedavi başarıyla eklendi");
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void populate()
        {
            Hastaclass has = new Hastaclass();
            string query = "select * from TedTbl";
            DataSet ds = has.showhasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        private void Tedavi_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            Hastaclass hastac = new Hastaclass();
            if (key == 0)
            {
                MessageBox.Show("Tedaviyi seçin");
            }
            else
            {
                try
                {
                    string query = "Update TedTbl set Tedadi='" + TedAdTB.Text + "',tedfiyat=" + TedFiyatTB.Text + ",Tedrec='" + TedRecTB.Text + "' where Tedid=" + key + "";

                    hastac.deletehasta(query);
                    MessageBox.Show("Tedavi başarıyla düzenlendi");
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TedAdTB.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            TedFiyatTB.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            TedRecTB.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (TedAdTB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedAdTB.Text = TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hastaclass hastac = new Hastaclass();
            if (key == 0)
            {
                MessageBox.Show("Tedaviyi seçin");
            }
            else
            {
                try
                {
                    string query = "Delete from TedTbl where Tedid= " + key + "";

                    hastac.deletehasta(query);
                    MessageBox.Show("Tedavi başarıyla silindi");
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
