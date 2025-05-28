using System;
using System.Configuration;
using System.Data.SqlClient;

namespace OyunKutuphane
{
    public static class Skorlar
    {
        /// <summary>
        /// Skorlar tablosuna yeni bir kayıt ekler.
        /// </summary> 
       
        public static void SkorEkle(
            int uyeId,
            string oyunTuru,
            string zorluk,
            int puan)
        {
            // App.config içindeki connection string
            string cnnStr = ConfigurationManager
                .ConnectionStrings["OyunKutuphaneDB"]
                .ConnectionString;

            using (var conn = new SqlConnection(cnnStr))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Skorlar
                            (UyeID, OyunTuru, Zorluk, Puan, OynamaTarihi)
                        VALUES
                            (@uyeId, @oyunTuru, @zorluk, @puan, @oynamaTarihi);
                    ";

                    // Parametreler tabloyla tamamen eşleşiyor
                    cmd.Parameters.AddWithValue("@uyeId", uyeId);
                    cmd.Parameters.AddWithValue("@oyunTuru", oyunTuru);
                    cmd.Parameters.AddWithValue("@zorluk", zorluk);
                    cmd.Parameters.AddWithValue("@puan", puan);
                    cmd.Parameters.AddWithValue("@oynamaTarihi", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
