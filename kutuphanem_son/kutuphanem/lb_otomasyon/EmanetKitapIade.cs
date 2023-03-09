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
    public partial class EmanetKitapIade : Form
    {
        public EmanetKitapIade()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        DataSet ds = new DataSet();

        private void emanetlistele()
        {
            baglanti.Open();
            NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar", baglanti);
            dosya.Fill(ds, "emanetkitaplar");
            dataGridView1.DataSource = ds.Tables["emanetkitaplar"];
            baglanti.Close();
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTcyegore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void EmanetKitapIade_Load(object sender, EventArgs e)
        {
            emanetlistele();
        }

        private void txtTcyegore_TextChanged(object sender, EventArgs e)
        {
            //textbox boş olduğunda hata vermesin diye.
            if (txtTcyegore.Text == "")
            {
                txtTcyegore.Text = "0";
            }//
            ds.Tables["emanetkitaplar"].Clear();
            baglanti.Open();
            NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar where uyetc='"+ txtTcyegore.Text + "'",baglanti);
            dosya.Fill(ds, "emanetkitaplar");
            baglanti.Close();

            if(txtTcyegore.Text=="")
            {
                ds.Tables["emanetkitaplar"].Clear();
                emanetlistele();
            }
        }

        private void txtBarkodagore_TextChanged(object sender, EventArgs e)
        {
            //textbox boş olduğunda hata vermesin diye.
            if (txtBarkodagore.Text == "")
            {
                txtBarkodagore.Text = "0";
            }//
            ds.Tables["emanetkitaplar"].Clear();
            baglanti.Open();
            NpgsqlDataAdapter dosya = new NpgsqlDataAdapter("select * from emanetkitaplar where emkitapbar='" + txtBarkodagore.Text + "'", baglanti);
            dosya.Fill(ds, "emanetkitaplar");
            baglanti.Close();

            if (txtBarkodagore.Text =="")
            {
                ds.Tables["emanetkitaplar"].Clear();
                emanetlistele();
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            if (txtTcyegore.Text == "" || txtBarkodagore.Text == "")
            {
                MessageBox.Show("İade alınacak kitabı seçiniz.", "Uyarı");
            }
            
            else
            {
                baglanti.Open();

                NpgsqlCommand komut = new NpgsqlCommand("delete from emanetkitaplar where uyetc=@p1 and emkitapbar=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", Convert.ToInt64(txtTcyegore.Text) /*dataGridView1.CurrentRow.Cells["uyetc"].Value.ToString()*/);
                komut.Parameters.AddWithValue("@p2", Convert.ToInt64(txtBarkodagore.Text)/*dataGridView1.CurrentRow.Cells["emkitapbar"].Value.ToString()*/);
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("update kitap set stoksayi=stoksayi+'" + dataGridView1.CurrentRow.Cells["emkitapsayi"].Value.ToString() + "' where kitapbarkod=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", Convert.ToInt64(txtBarkodagore.Text) /*dataGridView1.CurrentRow.Cells["kitapbarkod"].Value.ToString()*/);
                komut2.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kitap/Kitaplar İade Edildi. Zamanında Teslim Ettiğiniz İçin Teşekkürler. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ds.Tables["emanetkitaplar"].Clear();
                emanetlistele();
            }
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTcyegore.Text = dataGridView1.CurrentRow.Cells["uyetc"].Value.ToString();
            txtBarkodagore.Text = dataGridView1.CurrentRow.Cells["emkitapbar"].Value.ToString();
        }

        private void txtBarkodagore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
