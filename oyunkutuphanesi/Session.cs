using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunKutuphane
{
    /// <summary>
    /// Oturum açmış kullanıcının bilgilerini tutan statik helper sınıfı.
    /// </summary>
    public static class Session
    {
        /// <summary>
        /// Giriş yapan kullanıcının veritabanındaki UyeID değeri.
        /// Login formunda doldurun.
        /// </summary>
        public static int CurrentUserId { get; set; }
    }
}

