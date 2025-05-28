using OyunKutuphane;
using oyunkutuphanesi.kelimeoyunu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace oyunkutuphanesi.ziplayantopoyunu
{
    public partial class formtop : Form
    {
        
        private readonly int currentUserId;
        private string connectionString =
      @"Data Source=AHMET-CAN\SQLEXPRESS;
          Initial Catalog=OyunKutuphaneDB;
          Integrated Security=True";
        private Top top;
        private Platform platform;
        private Engel[] engeller;
        private int skor;
        private Random rnd = new Random();
        private int currentUyeId = 1;
        public formtop(int userId)
        {
            InitializeComponent();
            currentUserId = userId;

            // Olay bağlamaları
            this.Load += formtop_Load;
            this.KeyDown += formtop_KeyDown;
            this.MouseMove += formtop_MouseMove; // ← sadece BİR KERE
            btnbasla.Click += BtnBasla_Click;
            timer1.Tick += Timer1_Tick;
        }
   
        private void formtop_MouseMove(object sender, MouseEventArgs e)
        {
            int yeniX = e.X - btnkontrol.Width / 2;
            yeniX = Math.Max(lblsol.Right, Math.Min(yeniX, lblsag.Left - btnkontrol.Width));
            btnkontrol.Left = yeniX;

        }
        private void formtop_Load(object sender, EventArgs e)
        {
     

            engeller = new Engel[]
            {
                new StaticEngel(lblengel1),
                new StaticEngel(lblengel2),
                new StaticEngel(lblengel3),
                new StaticEngel(lblengel4),
                new StaticEngel(lblengel5),
                new StaticEngel(lblengel6),
            };
            timer1.Stop();
        }

        private void BtnBasla_Click(object sender, EventArgs e)
        {
            int adet, topHiz, platHiz;
            if (rbkolaay.Checked) { adet = 3; topHiz = 4; platHiz = 8; }
            else if (rborta.Checked) { adet = 4; topHiz = 6; platHiz = 10; }
            else { adet = 6; topHiz = 8; platHiz = 12; }

            top = new Top(btntop, topHiz, -topHiz);
            platform = new Platform(btnkontrol, platHiz, lblsol.Right, lblsag.Left);

            skor = 0;
            lblskor.Text = "Skor: 0";

            for (int i = 0; i < engeller.Length; i++)
            {
                var eLbl = engeller[i].Label;
                bool aktif = i < adet;
                eLbl.Visible = aktif;
                if (aktif)
                {
                    int x = rnd.Next(lblsol.Right + 10, lblsag.Left - eLbl.Width - 10);
                    int y = rnd.Next(lblust.Bottom + 10, this.ClientSize.Height - 100);
                    eLbl.Location = new Point(x, y);
                }
            }

            timer1.Start();
        }
        private void SaveScore(int uyeId, string oyunTuru, string zorluk, int puan)
        {
            const string sql = @"
        INSERT INTO Skorlar
            (UyeID, OyunTuru, Zorluk, Puan, OynamaTarihi)
        VALUES
            (@UyeID, @OyunTuru, @Zorluk, @Puan, @OynamaTarihi)";

            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UyeID", uyeId);
                    cmd.Parameters.AddWithValue("@OyunTuru", oyunTuru);
                    cmd.Parameters.AddWithValue("@Zorluk", zorluk);
                    cmd.Parameters.AddWithValue("@Puan", puan);
                    cmd.Parameters.AddWithValue("@OynamaTarihi", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Hata olması durumunda kullanıcıyı bilgilendirin
                MessageBox.Show(
                    "Skor kaydedilirken bir hata oluştu:\n" + ex.Message,
                    "Veritabanı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 1) Önce topun eski alt (Bottom) değerini al
            int oncekiBottom = top.Button.Bottom;

            // 2) Topu hareket ettir
            top.Move();

            // 3) Duvar çarpışmaları
            if (top.HitsTop(lblust.Bottom))
                top.BounceVertical();
            if (top.HitsSide(lblsol.Right, lblsag.Left))
                top.BounceHorizontal();

            // 4) Engel çarpışmaları (skor yok)
            foreach (var eng in engeller)
            {
                if (!eng.Label.Visible) continue;
                if (top.Button.Bounds.IntersectsWith(eng.Label.Bounds))
                {
                    top.BounceVertical();
                    break;
                }
            }

            // 5) Platform çarpışması: eski alt ile yeni alt arasında platformun tepe Y değerini geçişi kontrol et
            int platTop = btnkontrol.Top;
            bool yatayKesisim =
                top.Button.Right > btnkontrol.Left && top.Button.Left < btnkontrol.Right;
            bool dikeyKesisim =
                oncekiBottom <= platTop && top.Button.Bottom >= platTop;

            if (dikeyKesisim && yatayKesisim)
            {
                // Çarpışma anında mutlaka topu platformun üstüne oturt:
                top.Button.Top = platTop - top.Button.Height;

                // Yönü ters çevir
                top.BounceVertical();

                // Puan
                skor += 5;
                lblskor.Text = "Skor: " + skor;
            }

            // 6) Oyun bitti mi?
            if (top.Button.Bottom >= this.ClientSize.Height)
            {
                timer1.Stop();
                string zorluk = rbkolaay.Checked ? "Kolay"
                               : rborta.Checked ? "Orta"
                                                 : "Zor";
                Skorlar.SkorEkle(currentUserId, "Zıplayan Top", zorluk, skor);
                MessageBox.Show($"Oyun bitti!\nSkorunuz: {skor}",
                                "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void formtop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) platform.MoveLeft();
            if (e.KeyCode == Keys.Right) platform.MoveRight();
        }

        private void btnkontrol_Click(object sender, EventArgs e)
        {
        }

        private void btnkontrol_MouseMove(object sender, MouseEventArgs e)
        {
            btnkontrol.Left = e.X;
        }
    }
}

