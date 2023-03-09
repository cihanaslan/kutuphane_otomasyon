using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb_otomasyon
{
    public partial class EmanetKitapListele : Form
    {
        public EmanetKitapListele()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        DataSet ds = new DataSet();
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void emanetlistele()
        {
            baglanti.Open();
            NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar", baglanti);
            dosya.Fill(ds, "emanetkitaplar");
            dataGridView1.DataSource = ds.Tables["emanetkitaplar"];
            baglanti.Close();
        }

        private void EmanetKitapListele_Load_1(object sender, EventArgs e)
        {
            emanetlistele();
            comboFiltre.SelectedIndex = 0;
        }
        
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Tables["emanetkitaplar"].Clear();
            if(comboFiltre.SelectedIndex == 0 )
            {
                emanetlistele();
            }
            else if(comboFiltre.SelectedIndex==1 )
            {
                baglanti.Open();
                NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar where '"+DateTime.Now.ToShortDateString()+"'>emkitapiadet ", baglanti);
                dosya.Fill(ds, "emanetkitaplar");
                dataGridView1.DataSource = ds.Tables["emanetkitaplar"];
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar where '" + DateTime.Now.ToShortDateString() + "'<= emkitapiadet ", baglanti);
                dosya.Fill(ds, "emanetkitaplar");
                dataGridView1.DataSource = ds.Tables["emanetkitaplar"];
                baglanti.Close();
            }
        }
    }
}
