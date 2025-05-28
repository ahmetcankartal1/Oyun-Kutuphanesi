using OyunKutuphane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunkutuphanesi.kelimeoyunu
{
    public partial class formkelime : Form
    {
        // Sınıf düzeyi değişkenler
        private OyunModu aktifMod;
        private string gizliKelime;
        private char[] gosterim;     // char[] dizi kullanımı
        private int yanlisSayisi;
        private readonly int currentUserId;
        private string _secilenZorluk;
        private int skor;
        public formkelime(int userid)
        {
            InitializeComponent();
            currentUserId = userid;
            // Mod butonlarına tıklama olayları
            btnKolay.Click += (s, e) => ModuSecVeBaslat(new Kolay());
            btnOrta.Click += (s, e) => ModuSecVeBaslat(new Orta());
            btnZor.Click += (s, e) => ModuSecVeBaslat(new Zor());

            // Tahmin et butonu
            btnTahmin.Click += BtnTahmin_Click;
            txtTahmin.MaxLength = 1;  // Tek karakter
        }

        // Seçilen mod ile oyunu başlatır
        private void ModuSecVeBaslat(OyunModu mod)
        {
            aktifMod = mod;
            // ← BURAYA ekleyin: seçilen zorluku saklayın
            if (mod is Kolay) _secilenZorluk = "Kolay";
            else if (mod is Orta) _secilenZorluk = "Orta";
            else _secilenZorluk = "Zor";
            gizliKelime = aktifMod.OyunuBaslat();
            gosterim = Enumerable.Repeat('_', gizliKelime.Length).ToArray();
            yanlisSayisi = 0;
            // ← BURAYA ekleyin: skor sıfırlama
            skor = 0;
            lblSkor.Text = skor.ToString();

            txtTahmin.Enabled = true;
            btnTahmin.Enabled = true;
            lblDurum.Text = "Bir harf tahmin edin.";
            GuncelleUI();
        }

        // "Tahmin Et" butonuna basıldığında
        private void BtnTahmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTahmin.Text))
            {
                MessageBox.Show("Lütfen bir harf girin.");
                return;
            }

            char tahmin = char.ToUpper(txtTahmin.Text[0]);
            txtTahmin.Clear();

            if (gizliKelime.Contains(tahmin))
            {
                for (int i = 0; i < gizliKelime.Length; i++)
                {
                    if (gizliKelime[i] == tahmin)
                        gosterim[i] = tahmin;
                }
            }
            else
            {
                yanlisSayisi++;
            }
      
            txtTahmin.Clear();

            if (gizliKelime.Contains(tahmin))
            {
                // Doğru tahmin → +10 puan
                skor += 10;

                for (int i = 0; i < gizliKelime.Length; i++)
                    if (gizliKelime[i] == tahmin)
                        gosterim[i] = tahmin;
            }
            else
            {
                // Yanlış tahmin → –5 puan (skor en az 0)
                skor = Math.Max(0, skor - 5);
                yanlisSayisi++;
            }

            // SKOR LABEL’I GÜNCELLE
            lblSkor.Text = skor.ToString();

            GuncelleUI();
            BitisKontrolu();
        }

        // Ekranı günceller
        private void GuncelleUI()
        {
            lblKelime.Text = string.Join(" ", gosterim);
            lblHak.Text = $"Hak: {yanlisSayisi}/{aktifMod.MaksYanlisHak}";
        }

        // Oyun bitiş koşullarını kontrol eder
        private void BitisKontrolu()
        {
            // 1) Kazanma durumu
            if (!gosterim.Contains('_'))
            {
                // Skoru hesapla (örneğin kalan hak ×10)
                skor = (aktifMod.MaksYanlisHak - yanlisSayisi) * 10;

                // Veritabanına kaydet
                Skorlar.SkorEkle(
                    uyeId: currentUserId,
                    oyunTuru: "Kelime Oyunu",
                    zorluk: _secilenZorluk,
                    puan: skor
                );

                MessageBox.Show("Tebrikler, kazandınız!");
                OyunBitir();
            }
            // 2) Kaybetme durumu
            else if (yanlisSayisi >= aktifMod.MaksYanlisHak)
            {
                skor = 0;  // puan 0

                Skorlar.SkorEkle(
                    uyeId: currentUserId,
                    oyunTuru: "Kelime Oyunu",
                    zorluk: _secilenZorluk,
                    puan: skor
                );

                MessageBox.Show($"Kaybettiniz! Doğru kelime: {gizliKelime}");
                OyunBitir();
            }

        }

        // Oyun bittiğinde girdiyi kapatır
        private void OyunBitir()
        {
            txtTahmin.Enabled = false;
            btnTahmin.Enabled = false;
        }

        private void formkelime_Load(object sender, EventArgs e)
        {

        }
    }
}
