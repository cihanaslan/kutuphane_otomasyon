using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb_otomasyon
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "" || txtAd.Text == "")
            {
                MessageBox.Show("Gerekli Alanları Doldurun.","Uyarı");
            }

            else
            {
                if (VarMi(Convert.ToInt64(txtTC.Text)) != 0)
                {
                    MessageBox.Show("Üye Kayıtlı", "Uyarı");
                }
                else
                {
                    baglanti.Open();
                    NpgsqlCommand kmt1 = new NpgsqlCommand("insert into uye(tc,ad,soyad,dogumt,cinsiyet,telefon,adres,email,okunankitap) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
                    kmt1.Parameters.AddWithValue("@p1", Convert.ToInt64(txtTC.Text));
                    kmt1.Parameters.AddWithValue("@p2", txtAd.Text);
                    kmt1.Parameters.AddWithValue("@p3", txtSoyad.Text);
                    kmt1.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateDogumT.Text));
                    kmt1.Parameters.AddWithValue("@p5", comboCinsiyet.Text);
                    kmt1.Parameters.AddWithValue("@p6", txtTel.Text);
                    kmt1.Parameters.AddWithValue("@p7", txtAdres.Text);
                    kmt1.Parameters.AddWithValue("@p8", txtMail.Text);
                    kmt1.Parameters.AddWithValue("@p9", Convert.ToInt16(txtKitapAdet.Text));
                    kmt1.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Uye Ekleme İşlemi Başarılı.");
                }
            }
        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void txtKitapAdet_KeyPress(object sender, KeyPressEventArgs e)
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
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(tc) from uye where tc='" + aranan + "'",baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
        }
    }
}
