using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public abstract class OyunAlani
    {
        protected readonly Panel PanelOyun;
        protected readonly Label LabelPuan;
        protected readonly Label LabelSonuc;
        private readonly Timer _zamanlayici;

        protected Yilan _yilan;
        protected Yem _yem;
        protected int _puan;

        protected OyunAlani(Panel panelOyun, Label labelPuan, Label labelSonuc)
        {
            PanelOyun = panelOyun;
            LabelPuan = labelPuan;
            LabelSonuc = labelSonuc;
            _zamanlayici = new Timer();
            _zamanlayici.Tick += Zamanlayici_Tick;
        }

        protected abstract int GetInterval();
        protected abstract Yilan CreateYilan();

        public void Baslat()
        {
            IlkAyarlar();
            _zamanlayici.Interval = GetInterval();
            _zamanlayici.Start();
        }

        private void IlkAyarlar()
        {
            _zamanlayici.Stop();
            PanelOyun.Controls.Clear();
            _puan = 0;
            LabelPuan.Text = "0";
            LabelSonuc.Visible = false;

            _yilan = CreateYilan();
            _yem = new Yem(PanelOyun.Size);
            CizimYap();
        }

        private void Zamanlayici_Tick(object sender, EventArgs e)
        {
            _yilan.HareketEt();

            // --- DUVAR KONTROLÜ: wrap-around yerine çarpma ve ölme ---
            Point bas = _yilan.Parcalar[0];
            int x = bas.X;
            int y = bas.Y;
            if (x < 0 || x > PanelOyun.Width - 20 ||
                y < 0 || y > PanelOyun.Height - 20)
            {
                Bitir("KAYBETTİNİZ");
                return;
            }

            _yilan.SetHead(new Point(x, y));

            // Kendine çarpma
            if (_yilan.KendiyleCarptiMi())
            {
                Bitir("KAYBETTİNİZ");
                return;
            }

            // Yem kontrolü
            if (_yilan.Parcalar.First().Equals(_yem.Konum))
            {
                _yilan.Buyut();
                _puan += 50;
                LabelPuan.Text = _puan.ToString();

                if (_puan >= 5000)
                {
                    Bitir("KAZANDINIZ");
                    return;
                }

                _yem.YenidenOlustur(PanelOyun.Size);
            }

            CizimYap();
        }

        
        protected void Bitir(string mesaj)
        {
            _zamanlayici.Stop();
            LabelSonuc.Text = mesaj;
            LabelSonuc.Visible = true;
        }

        private void CizimYap()
        {
            PanelOyun.Controls.Clear();

            // Yılan parçaları
            foreach (Point pt in _yilan.Parcalar)
            {
                var seg = new Panel
                {
                    Size = new Size(20, 20),
                    Location = pt,
                    BackColor = Color.Gray
                };
                PanelOyun.Controls.Add(seg);
            }

            // Yem
            var yemPanel = new Panel
            {
                Size = new Size(20, 20),
                Location = _yem.Konum,
                BackColor = _yem.Renk
            };
            PanelOyun.Controls.Add(yemPanel);
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) _yilan.YonDegistir(Yon.Sag);
            else if (e.KeyCode == Keys.Left) _yilan.YonDegistir(Yon.Sol);
            else if (e.KeyCode == Keys.Up)  _yilan.YonDegistir(Yon.Yukari);
            else if (e.KeyCode == Keys.Down)  _yilan.YonDegistir(Yon.Asagi);
        }
    }
}
