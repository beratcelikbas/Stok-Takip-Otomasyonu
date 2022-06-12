using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace StokTakip
{
    public partial class kullaniciekle : Form
    {
        public kullaniciekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); //veritabanı baglantisi oluştur.

        private void kullaniciekle_Load(object sender, EventArgs e)
        {

        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();//baglantiyi ac.
            OleDbCommand kaydet = new OleDbCommand("Insert into kullanicibilgi(id,sifre,adsoyad,gorevi) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);// tB1,tB2,tB3,tB4 kolonlarını sırasıyla kullanicibilgi tablosundan id,sifre,adsoyad,gorevi atamasını yap.
            kaydet.ExecuteNonQuery();//kaydet komutunu çalıştır.
            baglanti.Close();//baglanti yi kapat.
            if (textBox1.Text == "") // boş alanları doldurması için if sorgusu.
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else
            {
                MessageBox.Show("Kullanıcı Başarıyla Oluşturuldu.");
            }
            textBox1.Clear(); //tB1 kolonunu temizle.
            textBox2.Clear(); //tB2 kolonunu temizle.
            textBox3.Clear(); //tB3 kolonunu temizle.
            textBox4.Clear(); //tB4 kolonunu temizle.
        }
    }
}
