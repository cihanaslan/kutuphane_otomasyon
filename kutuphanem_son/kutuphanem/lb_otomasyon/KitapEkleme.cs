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
    public partial class KitapEkleme : Form
    {
        public KitapEkleme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "" || txtKitapAdi.Text == "")
            {
                MessageBox.Show("Gerekli Alanları Doldurunuz.");
            }

            else
            {
                if (VarMi(Convert.ToInt64(txtBarkodNo.Text)) != 0)
                {
                    MessageBox.Show("Kitap Kayıtlı", "Uyarı");
                }

                else
                {
                    baglanti.Open();
                    NpgsqlCommand kmt1 = new NpgsqlCommand("insert into kitap(kitapbarkod,kitapad,yazar,yayinevi,sayfasayi,tur,stoksayi,rafno,aciklama) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
                    kmt1.Parameters.AddWithValue("@p1", Convert.ToInt64(txtBarkodNo.Text));
                    kmt1.Parameters.AddWithValue("@p2", txtKitapAdi.Text);
                    kmt1.Parameters.AddWithValue("@p3", txtYazar.Text);
                    kmt1.Parameters.AddWithValue("@p4", txtYayinEvi.Text);
                    kmt1.Parameters.AddWithValue("@p5", txtSayfaSayisi.Text);
                    kmt1.Parameters.AddWithValue("@p6", comboTur.Text);
                    kmt1.Parameters.AddWithValue("@p7", Convert.ToInt32(txtStok.Text));
                    kmt1.Parameters.AddWithValue("@p8", txtRafNo.Text);
                    kmt1.Parameters.AddWithValue("@p9", txtAciklama.Text);
                    kmt1.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kitap Ekleme İşlemi Başarılı.");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtRafNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBarkodNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public int VarMi(Int64 aranan)
        {
            int sonuc;

            baglanti.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(kitapbarkod) from kitap where kitapbarkod='" + aranan + "'", baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
        }
    }
}
