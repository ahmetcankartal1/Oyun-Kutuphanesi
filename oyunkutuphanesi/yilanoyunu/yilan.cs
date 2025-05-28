using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Oyunkutuphanesi.Yilanoyunu
{
    public enum Yon
    {
        Sag = 1,
        Sol = -1,
        Yukari = 2,
        Asagi = -2
    }

    public class Yilan
    {
        // Gövde parçaları
        private readonly List<Point> _parcalar = new List<Point>();
        public IReadOnlyList<Point> Parcalar
        {
            get { return _parcalar; }
        }

        public Yon MevcutYon { get; private set; }

        public Yilan(Point baslangic)
        {
            _parcalar.Add(baslangic);
            MevcutYon = Yon.Sag;
        }

        public void YonDegistir(Yon yeniYon)
        {
            // Geriye 180° dönüşü engelle
            if ((int)yeniYon + (int)MevcutYon == 0)
                return;
            MevcutYon = yeniYon;
        }

        public void HareketEt()
        {
            // Baş ekle, kuyruk çıkar
            Point bas = _parcalar[0];
            Point sonraki = NoktaEklentiler.Tasi(bas, MevcutYon, 20);
            _parcalar.Insert(0, sonraki);
            _parcalar.RemoveAt(_parcalar.Count - 1);
        }

        public void Buyut()
        {
            // Sadece baş ekle
            Point bas = _parcalar[0];
            Point sonraki = NoktaEklentiler.Tasi(bas, MevcutYon, 20);
            _parcalar.Insert(0, sonraki);
        }

        public bool KendiyleCarptiMi()
        {
            return _parcalar.Skip(1).Contains(_parcalar[0]);
        }

        // Wrap-around sonrası başı düzeltmek için
        public void SetHead(Point p)
        {
            _parcalar[0] = p;
        }
    }

    public static class NoktaEklentiler
    {
        public static Point Tasi(Point nokta, Yon yon, int mesafe)
        {
            switch (yon)
            {
                case Yon.Sag:
                    return new Point(nokta.X + mesafe, nokta.Y);
                case Yon.Sol:
                    return new Point(nokta.X - mesafe, nokta.Y);
                case Yon.Yukari:
                    return new Point(nokta.X, nokta.Y - mesafe);
                case Yon.Asagi:
                    return new Point(nokta.X, nokta.Y + mesafe);
                default:
                    return nokta;
            }
        }
    }
}
