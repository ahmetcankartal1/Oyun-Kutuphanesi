using oyunkutuphanesi;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OyunKutuphane
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }


        private int EnsureUser(string fullName)
        {
            int id = 0;

            var connString = "Server=AHMET-CAN\\SQLEXPRESS;Database=OyunKutuphaneDB;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                // 1) Mevcut kullanıcıyı ara
                using (var cmd = new SqlCommand(
                    "SELECT UyeID FROM Uyeler WHERE AdSoyad = @AdSoyad", conn))
                {
                    cmd.Parameters.Add("@AdSoyad", SqlDbType.NVarChar, 150)
                       .Value = fullName;

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                // 2) Yoksa ekle ve SCOPE_IDENTITY() ile yeni ID al
                using (var cmd = new SqlCommand(
                    "INSERT INTO Uyeler (AdSoyad) VALUES (@AdSoyad); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                {
                    cmd.Parameters.Add("@AdSoyad", SqlDbType.NVarChar, 150)
                       .Value = fullName;

                    object newId = cmd.ExecuteScalar();
                    id = (newId != null) ? Convert.ToInt32(newId) : 0;
                }
            }

            return id;
        }

        private void btngir_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtkadi.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Lütfen ad ve soyad alanlarını eksiksiz doldurun.",
                                "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = EnsureUser(kullaniciAdi);
            if (userId <= 0)
            {
                MessageBox.Show("Kullanıcı işlemi sırasında hata oluştu.",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcı başarıyla alındı/oluşturuldu → ana formu aç
            var mainForm = new mainform(userId, $"{kullaniciAdi}");
            this.Hide();
            mainForm.Show();
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }
    }
}
