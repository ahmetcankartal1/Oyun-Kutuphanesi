using System;
using System.Collections.Generic;

namespace oyunkutuphanesi.kelimeoyunu
{
    public class Kelime
    {
        private readonly string[] kelimeler5 = {
            "KİTAP", "BİLGİ", "MUTLU", "ASLAN", "HAYAT","YATAK","KALEM"
        };

        private readonly string[] kelimeler7 = {
            "MERHABA", "PROGRAM", "TUVALET", "YAZILIM", "TÜRKİYE"
        };

        private readonly string[] kelimeler10 = {
            "BİLGİSAYAR", "RADYOAKTİF", "OBSESİFLİK", "RADYOGRAFİ", "VERİTABANİ","ZİNCİRLEME","ÜNİVERSİTE"
        };

        private readonly Random rnd = new Random();

        // İstenen uzunluğa göre dizi seçip rastgele kelime döner
        public string KelimeSec(int uzunluk)
        {
            string[] havuz;
            if (uzunluk == 5)
                havuz = kelimeler5;
            else if (uzunluk == 7)
                havuz = kelimeler7;
            else // 10
                havuz = kelimeler10;

            int a = rnd.Next(havuz.Length);
            return havuz[a];
        }
    }
}

