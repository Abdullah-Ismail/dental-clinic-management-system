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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into HasTbl values('" + hastaAdTB.Text + "','" + hastaTeleTB.Text + "','" + hastaAdresTB.Text + "','" + hastadogum.Value.Date + "','" + hastaCinCB.SelectedItem.ToString() + "','" + hastaAlerjTB.Text + "')";
            Hastaclass hastac = new Hastaclass();

            try
            {
                hastac.AddHasta(query);
                MessageBox.Show("hasta başarıyla eklendi");
                populate();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        void populate()
        {
            Hastaclass has = new Hastaclass();
            string query = "select * from HasTbl";
            DataSet ds = has.showhasta(query);
            hastaDGV.DataSource = ds.Tables[0];
        }
        private void Hasta_Load_1(object sender, EventArgs e)
        {
            populate();
        }
        int key = 0;
        private void hastaDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            hastaAdTB.Text = hastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            hastaTeleTB.Text = hastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            hastaAdresTB.Text = hastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            hastaCinCB.SelectedItem = hastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            hastaAlerjTB.Text = hastaDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (hastaAdTB.Text=="")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(hastaAdTB.Text = hastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hastaclass hastac = new Hastaclass();
            if (key == 0)
            {
                MessageBox.Show("Hastayı Seçin");
            }
            else
            {
                try
                {
                    string query = "Delete from HasTbl where Hasid= " + key + "";
                    
                    hastac.deletehasta(query);
                    MessageBox.Show("hasta başarıyla silindi");
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hastaclass hastac = new Hastaclass();
            if (key == 0)
            {
                MessageBox.Show("Hastayı Seçin");
            }
            else
            {
                try
                {
                    string query = "Update HasTbl set Hasadi='" + hastaAdTB.Text + "',Hastelefon='" + hastaTeleTB.Text + "',Hasadres='" + hastaAdresTB.Text + "',Hasdt='"+hastadogum.Value.Date+"',Hascinsiyet='"+hastaCinCB.SelectedItem.ToString()+"',Hasalerji='"+hastaAlerjTB.Text+"' where Hasid="+key+";";

                    hastac.deletehasta(query);
                    MessageBox.Show("hasta başarıyla düzenlendi");
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
