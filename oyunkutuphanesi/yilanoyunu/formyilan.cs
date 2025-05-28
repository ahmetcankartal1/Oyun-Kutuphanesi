using OyunKutuphane;
using Oyunkutuphanesi.Yilanoyunu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyunkutuphanesi
{
    public partial class formyilan : Form
    {    private OyunAlani _oyun;
        private readonly int currentUserId;    // ← EKLEYİN
        private bool _skorKaydedildi;
        public KeyEventHandler FormYilan_KeyDown { get; }

        public formyilan(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            // 1) Klavye tuşlarını forma al
            this.KeyPreview = true;


            lblSonuc.TextChanged += LblSonuc_TextChanged;

            // 2) Başla butonunu dinle
            btnbasla.Click += btnbasla_Click;

        }
    

    
        private void formyilan_Load(object sender,KeyEventArgs e)
        {
        

        }

        private void btnbasla_Click(object sender, EventArgs e)
        {
            _skorKaydedildi = false;
            lblSonuc.Text = "";   // Sonuç etiketini temizle

            if (rbkolay.Checked)  
                _oyun = new YilanKolay(panelGame, lblPuan, lblSonuc);

            else if (rborta.Checked)

                _oyun = new YilanOrta(panelGame, lblPuan, lblSonuc);

            else if (rbzor.Checked)

                _oyun = new YilanZor(panelGame, lblPuan, lblSonuc);
            else//zaten kolay secili olarak geldigi için gerek yok bu koda
            {
                MessageBox.Show("Lütfen zorluk seçin.", "Uyarı",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rbkolay.Enabled = rborta.Enabled = rbzor.Enabled = false;
            _oyun.Baslat();
     
            // Panel’e odaklan
            panelGame.Focus();
            
        }/// <summary>
         /// Oyun sonucu (lblSonuc) yazısı değiştiğinde bir kez skor kaydeder.
         /// </summary>
        private void LblSonuc_TextChanged(object sender, EventArgs e)
        {  // 1) Sadece ilk kez çalışsın
            if (_skorKaydedildi) return;

            // 2) Boşsa çık
            if (string.IsNullOrEmpty(lblSonuc.Text)) return;

            // 3) Puanı al
            int puan = int.Parse(lblPuan.Text);

            // 4) Zorluk seviyesi
            string zorluk = rbkolay.Checked ? "Kolay"
                           : rborta.Checked ? "Orta"
                                             : "Zor";

            // 5) Veritabanına kaydet
            Skorlar.SkorEkle(
                uyeId: currentUserId,
                oyunTuru: "Yılan Oyunu",
                zorluk: zorluk,
                puan: puan
            );

            // 6) Bir daha kaydetmeyi engelle
            _skorKaydedildi = true;

        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_oyun != null &&
                (keyData == Keys.Right ||
                 keyData == Keys.Left ||
                 keyData == Keys.Up ||
                 keyData == Keys.Down))
            {
                _oyun.OnKeyDown(new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void formyilan_Load(object sender, EventArgs e)
        {

        }
    }
}
