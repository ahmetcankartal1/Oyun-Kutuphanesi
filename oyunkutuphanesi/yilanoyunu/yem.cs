using System;
using System.Drawing;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public class Yem
    {
        private readonly Random _rnd = new Random();

        public Point Konum { get; private set; }
        public Color Renk { get; private set; }

        public Yem(Size oyunBoyutu)
        {
            YenidenOlustur(oyunBoyutu);
        }

        public void YenidenOlustur(Size oyunBoyutu)
        {
            int maxX = oyunBoyutu.Width / 20;
            int maxY = oyunBoyutu.Height / 20;
            int x = _rnd.Next(0, maxX) * 20;
            int y = _rnd.Next(0, maxY) * 20;
            Konum = new Point(x, y);
            Renk = Color.FromArgb(_rnd.Next(256), _rnd.Next(256), _rnd.Next(256));
        }
    }
}
