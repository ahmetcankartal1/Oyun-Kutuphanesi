using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace oyunkutuphanesi.labirentoyunu
{
    public class Oyuncu
    {
        public Rectangle Konum { get; private set; }
        private readonly int _hiz = 20;

        public Oyuncu(int baslangicX, int baslangicY)
        {
            Konum = new Rectangle(baslangicX, baslangicY, 20, 20);
        }

        public void HareketEt(Keys tus, List<Duvar> duvarlar)
        {
            var yeni = Konum;
            switch (tus)
            {
                case Keys.Up: yeni.Y -= _hiz; break;
                case Keys.Down: yeni.Y += _hiz; break;
                case Keys.Left: yeni.X -= _hiz; break;
                case Keys.Right: yeni.X += _hiz; break;
            }
            // Duvara çarpma kontrolü
            if (!duvarlar.Any(d => d.Alan.IntersectsWith(yeni)))
                Konum = yeni;
        }
    }
}
