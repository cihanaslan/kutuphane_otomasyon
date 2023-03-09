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
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
            
        }

        private void kitapliste()
        {
            string sorgu = "select * from kitap";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void kitapsil(int barkod)
        {
            string sorgu = "delete from kitap where kitapbarkod=@p1";
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", barkod);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                MessageBox.Show("Silinecek Kitabı Seçiniz.");
            }

            else
            {
                double kitapBarkod = Convert.ToDouble(txtBarkodNo.Text);
                baglanti.Open();
                NpgsqlCommand command = new NpgsqlCommand("delete from kitap where kitapbarkod=@p1", baglanti);
                command.Parameters.AddWithValue("@p1", kitapBarkod);
                command.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitap Silme İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kitapliste();

                /*foreach(DataGridViewRow drow in dataGridView1.SelectedRows )
                {
                    int barkod = Convert.ToInt32(drow.Cells[0].Value);
                    kitapsil(barkod);
                }
                MessageBox.Show("Kitap Silme İşlemi Gerçekleşti :(","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kitapliste();*/
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KitapListele_Load(object sender, EventArgs e)
        {
            kitapliste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                MessageBox.Show("Güncellenecek Kitabı Seçin.");
            }

            else
            {



                baglanti.Open();
                NpgsqlCommand kmt2 = new NpgsqlCommand("update kitap set kitapad=@p2,yazar=@p3,yayinevi=@p4,sayfasayi=@p5,tur=@p6,stoksayi=@p7,rafno=@p8,aciklama=@p9 where kitapbarkod=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", Convert.ToInt64(txtBarkodNo.Text));
                kmt2.Parameters.AddWithValue("@p2", txtKitapAdi.Text);
                kmt2.Parameters.AddWithValue("@p3", txtYazar.Text);
                kmt2.Parameters.AddWithValue("@p4", txtYayinEvi.Text);
                kmt2.Parameters.AddWithValue("@p5", txtSayfaSayisi.Text);
                kmt2.Parameters.AddWithValue("@p6", comboTur.Text);
                kmt2.Parameters.AddWithValue("@p7", Convert.ToInt32(txtStok.Text));
                kmt2.Parameters.AddWithValue("@p8", txtRafNo.Text);
                kmt2.Parameters.AddWithValue("@p9", txtAciklama.Text);
                kmt2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme İşlemi Başarılı.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                kitapliste();
            }

        }


        DataSet ds = new DataSet();
        private void txtBarkodAra_TextChanged(object sender, EventArgs e)
        {
            //arama kısmına boş değer gelince hata veriyor  
            if (txtBarkodAra.Text == "")
            {
                txtBarkodAra.Text = "0";
            }
            baglanti.Open();
            NpgsqlDataAdapter dat = new NpgsqlDataAdapter("select * from kitap where kitapbarkod= '" + txtBarkodAra.Text + "' ", baglanti);
            dat.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                txtBarkodNo.Text = "0";
            }
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select * from kitap where kitapbarkod= '" + txtBarkodNo.Text + "' ", baglanti);
            //select * from kitap where kitapbarkod like '"+ txtbarkodNo.Text +"', baglanti);
            NpgsqlDataReader okuma = komut.ExecuteReader();
            while (okuma.Read())
            {
                txtKitapAdi.Text = okuma["kitapad"].ToString();
                txtYazar.Text = okuma["yazar"].ToString();
                txtYayinEvi.Text = okuma["yayinevi"].ToString();
                txtSayfaSayisi.Text = okuma["sayfasayi"].ToString();
                comboTur.Text = okuma["tur"].ToString();
                txtStok.Text = okuma["stoksayi"].ToString();
                txtRafNo.Text = okuma["rafno"].ToString();
                txtAciklama.Text = okuma["aciklama"].ToString();

            }
            okuma.Close();
            baglanti.Close();
            

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBarkodNo.Text = dataGridView1.CurrentRow.Cells["kitapbarkod"].Value.ToString();
        }

        private void txtBarkodNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBarkodAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSayfaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
