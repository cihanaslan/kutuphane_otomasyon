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
    public partial class EmanetKitapVerme : Form
    {
        public EmanetKitapVerme()
        {
            InitializeComponent();
        }


        private void sepetliste()
        {
            string sorgu = "select * from sepet";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close(); 
        }

        private void emanetsil(int emanet)
        {
            string sorgu = "delete from sepet where emkitapbno=@p1";
            NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", emanet);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Kutuphane_son3; user ID=postgres; password=1234");
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTcAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                MessageBox.Show("Eklenecek Kitabı Seçin.", "Uyarı");
            }

            else
            {

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("insert into sepet (emkitapbar,emkitapadi,emkitapyazar,emkitapyayinevi,emkitapsf,emkitapsayi,emkitapteslimt,emkitapiadet) " +
                    "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);

                komut.Parameters.AddWithValue("@p1", Convert.ToInt64(txtBarkodNo.Text));
                komut.Parameters.AddWithValue("@p2", txtKitapAdi.Text);
                komut.Parameters.AddWithValue("@p3", txtYazar.Text);
                komut.Parameters.AddWithValue("@p4", txtYayinEvi.Text);
                komut.Parameters.AddWithValue("@p5", txtSayfaS.Text);
                komut.Parameters.AddWithValue("@p6", Convert.ToInt32(txtKitapS.Text));
                komut.Parameters.AddWithValue("@p7", Convert.ToDateTime(dateTeslimT.Text));
                komut.Parameters.AddWithValue("@p8", Convert.ToDateTime(dateIadeT.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitapların Kaydı Oluşturuldu. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblKitapSayisi.Text = "";
                kitapsayi();

                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapS)
                        {
                            item.Text = "";
                        }
                    }
                }
                sepetliste();
            }

        }

        private void kitapsayi()
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select sum(emkitapsayi) from sepet",baglanti);
            lblKitapSayisi.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void EmanetKitapVerme_Load(object sender, EventArgs e)
        {
            kitapsayi();
            sepetliste();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Kayıttan Öge Kaldırılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(sil ==DialogResult.Yes)
            {
                /*foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
                {
                    int emanet = Convert.ToInt32(drow.Cells[0].Value);
                    emanetsil(emanet);
                }*/
                if (txtBarkodNo.Text == "")
                {
                    MessageBox.Show("Silinecek Kitabı Seçiniz.");
                }

                else
                {



                    double barkodNo = Convert.ToDouble(txtBarkodNo.Text);
                    baglanti.Open();
                    NpgsqlCommand command = new NpgsqlCommand("delete from sepet where emkitapbar=@p1", baglanti);
                    command.Parameters.AddWithValue("@p1", barkodNo);
                    command.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Öge Kaldırma İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sepetliste();

                    MessageBox.Show("Öge Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


            sepetliste();
            lblKitapSayisi.Text = "";
            kitapsayi();
        }

        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            if(txtBarkodNo.Text !="")
            {
                if(lblKayıtlıKitap.Text =="" && int.Parse(lblKitapSayisi.Text)<=3 || lblKitapSayisi.Text !="" && int.Parse(lblKayıtlıKitap.Text) + int.Parse(lblKitapSayisi.Text)<= 3)
                {
                    if(txtTcAra.Text != "" && txtAd.Text !="" && txtSoyad.Text !="" && txtTel.Text !="")
                    {

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            baglanti.Open();
                            NpgsqlCommand komut = new NpgsqlCommand("insert into emanetkitaplar(uyetc,uyead,uyesoyad,uyedogumt,uyetel,emkitapbar,emkitapadi,emkitapyazar,emkitapyayinevi,emkitapsf,emkitapsayi,emkitapteslimt,emkitapiadet) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", baglanti);
                            komut.Parameters.AddWithValue("@p1", Convert.ToInt64(txtTcAra.Text));
                            komut.Parameters.AddWithValue("@p2", txtAd.Text);
                            komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
                            komut.Parameters.AddWithValue("@p4", Convert.ToDateTime(txtdogumt.Text));
                            komut.Parameters.AddWithValue("@p5", txtTel.Text);
                            komut.Parameters.AddWithValue("@p6", Convert.ToInt64(dataGridView1.Rows[i].Cells["emkitapbar"].Value.ToString()));//Convert.ToInt64(txtBarkodNo.Text));
                            komut.Parameters.AddWithValue("@p7", dataGridView1.Rows[i].Cells["emkitapadi"].Value.ToString());//txtKitapAdi.Text);
                            komut.Parameters.AddWithValue("@p8", dataGridView1.Rows[i].Cells["emkitapyazar"].Value.ToString());//txtYazar.Text);
                            komut.Parameters.AddWithValue("@p9", dataGridView1.Rows[i].Cells["emkitapyayinevi"].Value.ToString());//txtYayinEvi.Text);
                            komut.Parameters.AddWithValue("@p10", dataGridView1.Rows[i].Cells["emkitapsf"].Value.ToString());//txtSayfaS.Text);
                            komut.Parameters.AddWithValue("@p11", Convert.ToInt32(dataGridView1.Rows[i].Cells["emkitapsayi"].Value.ToString()));//Convert.ToInt32(txtKitapS.Text));
                            komut.Parameters.AddWithValue("@p12", Convert.ToDateTime(dataGridView1.Rows[i].Cells["emkitapteslimt"].Value.ToString()));//Convert.ToDateTime(dateTeslimT.Text));
                            komut.Parameters.AddWithValue("@p13", Convert.ToDateTime(dataGridView1.Rows[i].Cells["emkitapiadet"].Value.ToString())); //Convert.ToDateTime(dateIadeT.Text));

                            /*
                            komut.Parameters.AddWithValue("@p9", dataGridView1.Rows[i].Cells["emkitapsf"].Value.ToString());
                            komut.Parameters.AddWithValue("@p10",int.Parse(dataGridView1.Rows[i].Cells["emkitapsayi"].Value.ToString()));
                            komut.Parameters.AddWithValue("@p11", dataGridView1.Rows[i].Cells["emkitapteslimt"].Value.ToString());
                            komut.Parameters.AddWithValue("@p12", dataGridView1.Rows[i].Cells["emkitapiadet"].Value.ToString());
                            */

                            komut.ExecuteNonQuery();

                            //NpgsqlCommand ekle = new NpgsqlCommand("update uye okunankitap=okunankitap+ '" + int.Parse(dataGridView1.Rows[i].Cells["emkitapsayi"].Value.ToString()) + "' where tc='" + txtTcAra.Text + "'", baglanti);
                            NpgsqlCommand ekle = new NpgsqlCommand("update uye set okunankitap=okunankitap+ '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["emkitapsayi"].Value.ToString()) + "' where tc='" + Convert.ToInt64(txtTcAra.Text) + "'", baglanti);
                            ekle.ExecuteNonQuery();
                            //NpgsqlCommand ekle2 = new NpgsqlCommand("update kitap stoksayi=stoksayi- '" + int.Parse(dataGridView1.Rows[i].Cells["emkitapsayi"].Value.ToString()) + "' where kitapbarkod='" + dataGridView1.Rows[i].Cells["kitapbarkod"].Value.ToString() + "'", baglanti);
                            NpgsqlCommand ekle2 = new NpgsqlCommand("update kitap set stoksayi=stoksayi- '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells["emkitapsayi"].Value.ToString()) + "' where kitapbarkod='" + Convert.ToInt64(txtBarkodNo.Text) + "'", baglanti);
                            ekle2.ExecuteNonQuery();

                            NpgsqlCommand komut4 = new NpgsqlCommand("delete from sepet", baglanti);
                            komut4.ExecuteNonQuery();

                            baglanti.Close();
                            //}

                            

                            MessageBox.Show("Kitap/Kitaplar Teslim Edildi.");
                            sepetliste();

                            txtTcAra.Text = "";
                            lblKayıtlıKitap.Text = "";

                            lblKitapSayisi.Text = "";
                            kitapsayi();
                        }
                        



                    }
                    else
                    {
                        MessageBox.Show("Lütfen Üye Girin","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    
                }
                
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3'ten Fazla Olamaz!","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen Sepete Kitap Ekleyin","Bilgi", MessageBoxButtons.OK ,MessageBoxIcon.Information);
            }



            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            //textbox boş olduğunda hata vermesin diye.
            if (txtTcAra.Text == "")
            {
                txtTcAra.Text = "0";
            }//
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select * from uye where tc='" + txtTcAra.Text + "'", baglanti);
            NpgsqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtAd.Text = oku["ad"].ToString();
                txtSoyad.Text = oku["soyad"].ToString();
                txtdogumt.Text = oku["dogumt"].ToString();
                txtTel.Text = oku["telefon"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("select sum(emkitapsayi) from emanetkitaplar where uyetc='"+ txtTcAra.Text+"'",baglanti);
            lblKayıtlıKitap.Text = komut2.ExecuteScalar().ToString();
            baglanti.Close();
            if (txtTcAra.Text == "")
            {
                foreach(Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        lblKayıtlıKitap.Text = "";
                    } 
                }
            }
            
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            //textbox boş olduğunda hata vermesin diye.
            if (txtBarkodNo.Text == "")
            {
                txtBarkodNo.Text = "0";
            }//

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("select * from kitap where kitapbarkod='" + txtBarkodNo.Text + "'", baglanti);
            NpgsqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtKitapAdi.Text = oku["kitapad"].ToString();
                txtYazar.Text = oku["yazar"].ToString();
                txtYayinEvi.Text = oku["yayinevi"].ToString();
                txtSayfaS.Text = oku["sayfasayi"].ToString();

            }
            baglanti.Close();
            if (txtBarkodNo.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapS)
                        {
                            item.Text = "";
                        }
                    }
                }
            }




        }

        private void txtKitapS_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBarkodNo.Text = dataGridView1.CurrentRow.Cells["emkitapbar"].Value.ToString();
        }

        private void txtKitapS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtSayfaS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBarkodNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
