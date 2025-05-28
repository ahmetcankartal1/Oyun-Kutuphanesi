using System.Drawing;

namespace oyunkutuphanesi.labirentoyunu
{
    public class Duvar
    {
        // Labirent üzerindeki engelin konumu ve boyutu
        public Rectangle Alan { get; }

        public Duvar(int x, int y, int genislik, int yukseklik)
        {
            Alan = new Rectangle(x, y, genislik, yukseklik);
        }
    }
}
