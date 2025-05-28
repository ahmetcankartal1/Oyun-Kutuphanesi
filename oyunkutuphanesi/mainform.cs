using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oyunkutuphanesi.labirentoyunu;
using oyunkutuphanesi.kartoyunu;
using oyunkutuphanesi.kelimeoyunu;
using oyunkutuphanesi.ziplayantopoyunu;
using Oyunkutuphanesi;
using OyunKutuphane;       // Yilanoyunu burada tanımlı


namespace oyunkutuphanesi
{
    public partial class mainform : Form
    {
        int userid;
        string kullaniciadi;
        public mainform(int _userid, string _kullaniciadi)
        {
            userid = _userid;
            kullaniciadi = _kullaniciadi;
            InitializeComponent();
            btnyilan.Click += btnyilan_Click;
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            lblhosgeldiniz.Text = $"HOŞGELDİN {kullaniciadi} ({userid})";
        }

        private void btnyilan_Click(object sender, EventArgs e)
        { // FormYilan’ı modal olarak açalım:
            using (var frm = new formyilan(userid))
                frm.ShowDialog();
        }

        private void btnlab_Click(object sender, EventArgs e)
        {
            using (var frm = new formlabirent(userid))
            {
                frm.ShowDialog();
            }
        }

        private void btnkart_Click(object sender, EventArgs e)
        {
            using (var frm = new formkart(userid))
            {
                frm.ShowDialog();
            }
        }

        private void btnkelime_Click(object sender, EventArgs e)
        {
            using (var frm = new formkelime(userid))
            {
                frm.ShowDialog();
            }
        }

        private void btntop_Click(object sender, EventArgs e)
        {
            using (var frm = new formtop(userid))
            {
                frm.ShowDialog();
            }
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            var loginForm = new loginform();
            loginForm.FormClosed += (s, args) =>
            {
                // Eğer LoginForm kapatıldıysa MainForm'u da kapat
                this.Close();
            };
            this.Close();
            loginForm.Show();
        }
    }
}
