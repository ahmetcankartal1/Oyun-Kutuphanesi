using System.Collections.Generic;
using System.Drawing;

namespace oyunkutuphanesi.labirentoyunu
{
    public abstract class Labirent
    {
        public List<Duvar> Duvarlar { get; protected set; }
        public Rectangle Cikis { get; protected set; }
        public abstract void Olustur();
    }

    public class KolayLabirent : Labirent
    {
        public override void Olustur()
        {
            Duvarlar = new List<Duvar>
            {
                new Duvar(0,   0, 800, 20),
                new Duvar(0,   0, 20, 600),
                new Duvar(0, 580, 800, 20),
                new Duvar(780, 0, 20, 600),
                new Duvar(200,   0, 20, 400),
                new Duvar(400, 200, 20, 400)
            };
            Cikis = new Rectangle(760, 540, 40, 40);
        }
    }

    public class OrtaLabirent : Labirent
    {
        public override void Olustur()
        {
            Duvarlar = new List<Duvar>
            {
                new Duvar(0,   0, 800, 20),
                new Duvar(0,   0, 20, 600),
                new Duvar(0, 580, 800, 20),
                new Duvar(780, 0, 20, 600),
                new Duvar(100,100,600, 20),
                new Duvar(100,100, 20,400),
                new Duvar(300,200,400, 20),
                new Duvar(300,200, 20,300)
            };
            Cikis = new Rectangle(760, 540, 40, 40);
        }
    }

    public class ZorLabirent : Labirent
    {
        public override void Olustur()
        {
            Duvarlar = new List<Duvar>
            {
                new Duvar(0,   0, 800, 20),
                new Duvar(0,   0, 20, 600),
                new Duvar(0, 580, 800, 20),
                new Duvar(780, 0, 20, 600),
                new Duvar(50,  50,700, 20),
                new Duvar(50,  50, 20,500),
                new Duvar(50, 530,700, 20),
                new Duvar(730, 50, 20,500),
                new Duvar(200,100, 20,400),
                new Duvar(400,  0, 20,300),
                new Duvar(600,200, 20,400)
            };
            Cikis = new Rectangle(760, 540, 40, 40);
        }
    }
}