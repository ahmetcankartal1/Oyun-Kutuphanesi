using System;
using System.Drawing;
using System.Windows.Forms;

namespace oyunkutuphanesi.kartoyunu
{
    public class Kart
    {
        private int _id;       // Çift kimliği
        private Label _label;    // Görsel kontrol
        private bool _eslesti;  // Eşleştirme durumu

        public Kart(int id, Label label)
        {
            _id = id;
            _label = label;
            _eslesti = false;

            // Label’ı ilk haline getir
            _label.Text = "";
            _label.BackColor = Color.LightGray;
            _label.Cursor = Cursors.Hand;
            _label.Font = new Font("Webdings", 48);
            _label.TextAlign = ContentAlignment.MiddleCenter;
            _label.Tag = this;        // kendisine referans
            _label.Visible = false;
            _label.Click += (s, e) => OnClick?.Invoke(this);
        }

        // Kart tıklanmasını bildiren olay
        public event Action<Kart> OnClick;

        // Kartı aç/kapa
        public void Cevir(bool ac)
        {
            _label.Text = ac ? ((char)('a' + _id)).ToString() : "";
        }

        // Eşleşmeyi işaretle
        public void Eslestir()
        {
            _eslesti = true;
            _label.Enabled = false;
            _label.BackColor = Color.White;
        }

        public bool Eslesti => _eslesti;
        public int Id => _id;
        public Label Label => _label;
    }
}
