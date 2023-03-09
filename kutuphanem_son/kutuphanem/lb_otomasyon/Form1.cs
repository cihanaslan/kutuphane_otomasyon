using System.Media;
namespace lb_otomasyon
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

private void btnUyeEkleme_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            UyeEkle uyeEkle = new UyeEkle();
            uyeEkle.Show();
        }

        private void AnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["UyeEkle"] != null || Application.OpenForms["UyeListeleme"] != null || Application.OpenForms["KitapEkleme"] != null || Application.OpenForms["KitapListele"] != null || Application.OpenForms["EmanetKitapVerme"] != null || Application.OpenForms["EmanetKitapListele"] != null || Application.OpenForms["EmanetKitapIade"] != null || Application.OpenForms["Siralama"] != null) 
            {
                e.Cancel = true;
            }
        }

        private void btnUyeList_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            UyeListeleme uyeListeleme =new UyeListeleme();
            uyeListeleme.Show();
        }

        private void btnKitapEkleme_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            KitapEkleme kitapEkleme = new KitapEkleme();
            kitapEkleme.Show();
        }

        private void btnKitapList_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            KitapListele kitapListele = new KitapListele();
            kitapListele.Show();
        }

        private void btnEKitapVerme_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            EmanetKitapVerme emanetKitapVerme = new EmanetKitapVerme();
            emanetKitapVerme.Show();
        }

        private void btnEKitapList_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            EmanetKitapListele emanetKitapListele = new EmanetKitapListele();
            emanetKitapListele.Show();
        }

        private void btnEKitapIade_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            EmanetKitapIade emanetKitapIade =new EmanetKitapIade();
            emanetKitapIade.Show();
        }

        private void btnSýralama_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //

            Siralama siralama =new Siralama();
            siralama.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            //butona click sesi.
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\mouseSes.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            //
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}