using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyunkutuphanesi.kelimeoyunu
{
    public class Kolay : OyunModu
    {
        public Kolay()
        {
            MaksYanlisHak = 5;
            IstenenUzunluk = 5;
        }
    }

    public class Orta : OyunModu
    {
        public Orta()
        {
            MaksYanlisHak = 7;
            IstenenUzunluk = 7;
        }
    }

    public class Zor : OyunModu
    {
        public Zor()
        {
            MaksYanlisHak = 10;
            IstenenUzunluk = 10;
        }
    }
}

