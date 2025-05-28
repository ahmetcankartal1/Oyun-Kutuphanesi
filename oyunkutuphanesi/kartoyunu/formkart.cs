using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OyunKutuphane; // SkorYonetici için
using oyunkutuphanesi.kartoyunu; // Kart ve Zorluk sınıflarınızın bulunduğu namespace

namespace oyunkutuphanesi.kartoyunu
{
    public partial class formkart : Form
    {
        private readonly int _kullaniciId;
        private Zorluk _seciliZorluk;
        private Kart[] _kartlar;
        private Kart _oncekiKart;
        private Timer _kartKapatmaTimer;
        private int _puan;
        private string _secilenZorluk;

        public formkart(int kullaniciId)
        {
            InitializeComponent();
            _kullaniciId = kullaniciId;
            _puan = 0;
            _kartKapatmaTimer = new Timer { Interval = 800 };
            _kartKapatmaTimer.Tick += KartKapatmaTimer_Tick;
            btnbasla.Click += Btnbasla_Click;
        }

        private void Btnbasla_Click(object sender, EventArgs e)
        {
            // Polymorphism: Zorluk nesnesini örnekle
            if (rbkolay.Checked) { _seciliZorluk = new Kolay(); _secilenZorluk = "Kolay"; }
            else if (rborta.Checked) { _seciliZorluk = new Orta(); _secilenZorluk = "Orta"; }
            else if (rbzor.Checked) { _seciliZorluk = new Zor(); _secilenZorluk = "Zor"; }
            else
            {
                MessageBox.Show("Lütfen bir zorluk seviyesi seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _puan = 0;
            Baslat(_seciliZorluk.KartSayisi);
        }

        private void Baslat(int toplamKart)
        {
            _oncekiKart = null;

            // 1) ID dizisi
            var idDizisi = new int[toplamKart];
            for (int i = 0; i < toplamKart; i += 2)
            {
                int pid = i / 2;
                idDizisi[i] = pid;
                idDizisi[i + 1] = pid;
            }

            // 2) Fisher–Yates karıştırma
            var rnd = new Random();
            for (int i = idDizisi.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (idDizisi[i], idDizisi[j]) = (idDizisi[j], idDizisi[i]);
            }

            // 3) Kart nesnelerini oluşturup TableLayoutPanel’e yerleştir
            _kartlar = new Kart[toplamKart];
            for (int i = 0; i < toplamKart; i++)
            {
                int col = i % tableLayoutPanel1.ColumnCount;
                int row = i / tableLayoutPanel1.ColumnCount;
                var lbl = tableLayoutPanel1.GetControlFromPosition(col, row) as Label;

                var kart = new Kart(idDizisi[i], lbl);
                kart.OnClick += Kart_Clicked;
                lbl.Visible = true;

                _kartlar[i] = kart;
            }

            // 4) Kalan hücreleri gizle
            int totalCells = tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
            for (int i = toplamKart; i < totalCells; i++)
            {
                int col = i % tableLayoutPanel1.ColumnCount;
                int row = i / tableLayoutPanel1.ColumnCount;
                var lbl = tableLayoutPanel1.GetControlFromPosition(col, row) as Label;
                lbl.Visible = false;
            }
        }

        private void Kart_Clicked(Kart tiklanan)
        {
            if (tiklanan.Eslesti || _kartKapatmaTimer.Enabled)
                return;

            // Kartı aç
            tiklanan.Cevir(true);

            if (_oncekiKart == null)
            {
                _oncekiKart = tiklanan;
            }
            else
            {
                _puan++;

                if (tiklanan.Id == _oncekiKart.Id)
                {
                    // Eşleşme: kaybolsunlar
                    tiklanan.Eslestir();
                    _oncekiKart.Eslestir();
                }
                else
                {
                    // Kapatma timer’ı
                    _kartKapatmaTimer.Start();
                }
                _oncekiKart = null;

                // Bitiş kontrolü
                if (_kartlar.All(k => k.Eslesti))
                {
                    MessageBox.Show($"Tebrikler! {_secilenZorluk} seviyesini {_puan} hamlede tamamladınız.",
                                    "Kazandınız", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Skoru kaydet
                    Skorlar.SkorEkle(_kullaniciId, "Kart Eşleştirme", _secilenZorluk, _puan);
                    this.Close();
                }
            }
        }

        private void KartKapatmaTimer_Tick(object sender, EventArgs e)
        {
            _kartKapatmaTimer.Stop();
            foreach (var kart in _kartlar)
            {
                if (!kart.Eslesti)
                    kart.Cevir(false);
            }
            _oncekiKart = null;
        }
    }
}
