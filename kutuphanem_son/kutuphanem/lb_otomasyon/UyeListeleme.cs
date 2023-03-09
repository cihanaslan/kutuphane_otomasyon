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
    public partial class UyeListeleme : Form
    {
        public UyeListeleme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");

        private void uyesil(int kimlik)
        {
            string sorgu = "delete from uye where tc=@p1";
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", kimlik);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uyelistele()
        {
            string sorgu = "select * from uye";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int kimlik = Convert.ToInt32(drow.Cells[0].Value);
                uyesil(kimlik);
            }
            MessageBox.Show("Üye Silme İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            uyelistele();*/

            if (txtTC.Text == "")
            {
                MessageBox.Show("Silincek Kişiyi Seçiniz.");
            }

            else
            {
                double tc = Convert.ToDouble(txtTC.Text);
                baglanti.Open();
                NpgsqlCommand command = new NpgsqlCommand("delete from uye where tc=@p1", baglanti);
                command.Parameters.AddWithValue("@p1", tc);
                command.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Üye Silme İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uyelistele();
            }
        }

        private void txtTcAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnGuncelleme_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "")
            {
                MessageBox.Show("Güncellenecek Üyeyi Seçiniz.", "Uyarı");
            }

            else
            {

                baglanti.Open();
                NpgsqlCommand kmt2 = new NpgsqlCommand("update uye set ad=@p2,soyad=@p3,dogumt=@p4,cinsiyet=@p5,telefon=@p6,adres=@p7,email=@p8,okunankitap=@p9 where tc=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", Convert.ToInt64(txtTC.Text));
                kmt2.Parameters.AddWithValue("@p2", txtAd.Text);
                kmt2.Parameters.AddWithValue("@p3", txtSoyad.Text);
                kmt2.Parameters.AddWithValue("@p4", Convert.ToDateTime(dateDogumT.Text));
                kmt2.Parameters.AddWithValue("@p5", comboCinsiyet.Text);
                kmt2.Parameters.AddWithValue("@p6", txtTel.Text);
                kmt2.Parameters.AddWithValue("@p7", txtAdres.Text);
                kmt2.Parameters.AddWithValue("@p8", txtMail.Text);
                kmt2.Parameters.AddWithValue("@p9", Convert.ToInt16(txtKitapAdet.Text));
                kmt2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme İşlemi Başarılı.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                uyelistele();
            }
        }

        private void UyeListeleme_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            //textbox boş olduğunda hata vermesin diye.
            if (txtTC.Text == "")
            {
                txtTC.Text = "0";
            }//
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select * from uye where tc= '" + txtTC.Text + "' ", baglanti);
            //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAd.Text = read["ad"].ToString();
                txtSoyad.Text = read["soyad"].ToString();
                dateDogumT.Text = read["dogumt"].ToString();
                comboCinsiyet.Text = read["cinsiyet"].ToString();
                txtTel.Text = read["telefon"].ToString();
                txtAdres.Text = read["adres"].ToString();
                txtMail.Text = read["email"].ToString();
                txtKitapAdet.Text = read["okunankitap"].ToString();
            }
            read.Close();
            baglanti.Close();
        }
        DataSet ds = new DataSet();
        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            //arama kısmına boş değer gelince hata veriyor ve aynı arama hatası
            //arama kısmına bi şey girince hata veriyor
            //int tcAra = Convert.ToInt32(txtTcAra.Text);//veritabanında tc bigint o yüzden inte çevirip denedim(çalışmadı).
            if (txtTcAra.Text=="")
            {
                txtTcAra.Text = "0";
            }
            ds.Tables.Clear();
            baglanti.Open();
            NpgsqlDataAdapter dat = new NpgsqlDataAdapter("select * from uye where tc = '" + txtTcAra.Text + "' ", baglanti);
            dat.Fill(ds, "uye");
            dataGridView1.DataSource = ds.Tables["uye"];
            baglanti.Close(); 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTC.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        private void txtKitapAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
