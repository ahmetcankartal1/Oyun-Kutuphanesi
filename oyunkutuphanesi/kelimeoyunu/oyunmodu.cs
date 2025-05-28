using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oyunkutuphanesi.kelimeoyunu
{
    public abstract class OyunModu
    {

        public int MaksYanlisHak { get; protected set; }
        public int IstenenUzunluk { get; protected set; }

        protected Kelime bankasi= new Kelime();

        public virtual string OyunuBaslat()
        {
            return bankasi.KelimeSec(IstenenUzunluk);
        }
    }
}
