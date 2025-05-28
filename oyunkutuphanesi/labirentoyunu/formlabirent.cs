using OyunKutuphane;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace oyunkutuphanesi.labirentoyunu
{
    public partial class formlabirent : Form
    {
        private List<PictureBox> _duvarlar;   // Tag="Duvar" olan pictureBox’lar
        private int _sure;                    // Kalan süre / puan
        private bool _gameActive;             // Oyun başladı mı?
        private readonly int _currentUserId;  // Giriş yapmış kullanıcı ID
        private string _secilenZorluk;        // Kolay/Orta/Zor

        public formlabirent(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;

            // Event abonelikleri
            this.Load += Formlabirent_Load;
            btnBasla.Click += BtnBasla_Click;
            timer1.Tick += Timer1_Tick;
            btncikis.MouseEnter += BtnCikis_MouseEnter;
            rbKolay.CheckedChanged += Radio_CheckedChanged;
            rbOrta.CheckedChanged += Radio_CheckedChanged;
            rbZor.CheckedChanged += Radio_CheckedChanged;
        }

        private void Formlabirent_Load(object sender, EventArgs e)
        {
            // Başlangıçta timer kapalı
            timer1.Enabled = false;

            // Tag="Duvar" olan tüm duvar PictureBox’larını topla
            _duvarlar = Controls
                .OfType<PictureBox>()
                .Where(pb => (pb.Tag?.ToString() ?? "") == "Duvar")
                .ToList();

            // Her duvara MouseEnter ile olmazsa oyun bitti
            foreach (var duvar in _duvarlar)
                duvar.MouseEnter += Duvar_MouseEnter;

            // Varsayılan seçim ve reset
            rbKolay.Checked = true;
            ResetGame();
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            // Zorluk değiştiğinde yeniden ayarla
            ResetGame();
        }

        private void ResetGame()
        {
            // Seçili zorluğa göre süreyi ayarla
            if (rbKolay.Checked) _sure = 20;
            else if (rbOrta.Checked) _sure = 15;
            else _sure = 10;

            lblSure.Text = _sure.ToString();
            btnBasla.Enabled = true;
            rbKolay.Enabled = rbOrta.Enabled = rbZor.Enabled = true;

            timer1.Stop();
            _gameActive = false;
        }

        private void BtnBasla_Click(object sender, EventArgs e)
        {
            // Zorluk türünü kaydet
            _secilenZorluk = rbKolay.Checked ? "Kolay"
                             : rbOrta.Checked ? "Orta"
                                               : "Zor";

            // Oyun başlasın
            lblSure.Text = _sure.ToString();
            btnBasla.Enabled = false;
            rbKolay.Enabled = rbOrta.Enabled = rbZor.Enabled = false;

            // Fareyi labirentin başlangıcına taşı (örnek 30,30)
            var start = PointToScreen(new Point(30, 30));
            Cursor.Position = start;

            _gameActive = true;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!_gameActive) return;

            _sure--;
            lblSure.Text = _sure.ToString();

            if (_sure <= 0)
            {
                EndGame(won: false);
            }
        }

        private void Duvar_MouseEnter(object sender, EventArgs e)
        {
            if (!_gameActive) return;
            EndGame(won: false);
        }

        private void BtnCikis_MouseEnter(object sender, EventArgs e)
        {
            if (!_gameActive) return;
            EndGame(won: true);
        }

        /// <summary>
        /// Oyunun bittiği an çağrılır. won==true ise kazandı, false ise kaybetti.
        /// </summary>
        private void EndGame(bool won)
        {
            _gameActive = false;
            timer1.Stop();

            int puan = won ? _sure : 0;
            SaveScore(puan);

            // Bir kez gösterilecek mesaj
            string baslik = won ? "Tebrikler!" : "Oyun Bitti";
            string mesaj = won
                ? $"Çıkışı buldunuz! Puanınız: {puan}"
                : "Duvara çarptınız veya süre doldu.";

            MessageBox.Show(this, mesaj, baslik,
                            MessageBoxButtons.OK,
                            won ? MessageBoxIcon.Information
                                : MessageBoxIcon.Stop);

            // Tekrar oynama sorusu
            var cevap = MessageBox.Show(this,
                "Tekrar oynamak ister misiniz?",
                "Yeniden Oyna",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
                ResetGame();
            else
                this.Close();
        }

        /// <summary>
        /// Skoru database'e kaydeder.
        /// </summary>
        private void SaveScore(int puan)
        {
            Skorlar.SkorEkle(
                uyeId: _currentUserId,
                oyunTuru: "Labirent Oyunu",
                zorluk: _secilenZorluk,
                puan: puan
            );
        }

        private void formlabirent_Load_1(object sender, EventArgs e)
        {

        }
    }
}
