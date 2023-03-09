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
    public partial class Siralama : Form
    {
        public Siralama()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        DataSet ds = new DataSet();


        private void Siralama_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from uye order by okunankitap desc ", baglanti);
            dosya.Fill(ds, "uye");
            dataGridView1.DataSource = ds.Tables["uye"];
            baglanti.Close();

            label3.Text = "";
            label4.Text = "";

            label3.Text = ds.Tables["uye"].Rows[0]["ad"].ToString() + " ";
            label3.Text += ds.Tables["uye"].Rows[0]["soyad"].ToString() + ":";
            label3.Text += ds.Tables["uye"].Rows[0]["okunankitap"].ToString();

            label4.Text = ds.Tables["uye"].Rows[dataGridView1.Rows.Count - 2]["ad"].ToString() + " ";
            label4.Text += ds.Tables["uye"].Rows[dataGridView1.Rows.Count - 2]["soyad"].ToString() + ":";
            label4.Text += ds.Tables["uye"].Rows[dataGridView1.Rows.Count - 2]["okunankitap"].ToString();
        }
    }
}
