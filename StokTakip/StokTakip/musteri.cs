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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); //veritabanı baglantisi oluştur.

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void musteri_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();//baglanti aç.
            OleDbCommand kaydet = new OleDbCommand("insert into musteri(kimlik,adsoyad,telefon,eposta)values ('"+textBox1.Text+"','"+ textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"')", baglanti);// tB1,tB2,tB3,tB4 kolonlarını sırasıyla musteri tablosundan kimlik,adsoyad,telefon,eposta atamasını yap.
            kaydet.ExecuteNonQuery(); //kaydet komutunu çalıştır.
            baglanti.Close();//baglanti kapat.
            if (textBox1.Text == "") // boş alanları kullanıcının doldurması için if sorgusu başlat.
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
                MessageBox.Show("Müşteri başarıyla oluşturuldu.");
            }
            textBox1.Clear(); //tB1 i temizle.
            textBox2.Clear(); //tB2 yi temizle.
            textBox3.Clear(); //tB3 ü temizle.
            textBox4.Clear(); //tB4 ü temizle.
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
