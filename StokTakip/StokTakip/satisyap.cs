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
    public partial class satisyap : Form
    {
        public satisyap()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); //veritabanı baglantisi oluştur.

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select *from musteri where kimlik='"+textBox7.Text+"'", baglanti); //tB7 yi musteri tablosundan kimlik e göre seç.
            OleDbDataReader oku = komut.ExecuteReader(); // yukarıdaki işlemi oku.
            while (oku.Read()) // doğruysa aşağıdaki işlemleri döndür.
            {
                textBox7.Text = oku["kimlik"].ToString();
                textBox6.Text = oku["adsoyad"].ToString();
                textBox5.Text = oku["telefon"].ToString();
                textBox4.Text = oku["eposta"].ToString();
            }
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select *from urun where barkodno='" + textBox1.Text + "'", baglanti); //tB1 i urun tablosundan barkodno ya göre seç.
            OleDbDataReader oku2 = komut2.ExecuteReader(); // yukarıdaki işlemi oku.
            while (oku2.Read()) //doğruysa aşağıdaki işlemleri döndür.
            {
                comboBox1.Text = oku2["kategori"].ToString();
                comboBox2.Text = oku2["marka"].ToString();
                comboBox3.Text = oku2["model"].ToString();
                textBox2.Text = oku2["urunadi"].ToString();
            }
            baglanti.Close();
        }
        int a, b, c; //a,b,c adlarında 3 tane int değişken tanımladım.

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void satisyap_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox3.Text); //tB 3 e girilen değeri a ya ata.
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select *from urun where barkodno='" + textBox1.Text + "'", baglanti); // tB1 i urun tablosundan barkodno ya göre seç.
            OleDbDataReader oku2 = komut2.ExecuteReader(); // yukarıdaki işlemi oku.
            while (oku2.Read()) //doğruysa aşağıdaki işlemi yap.
            {
                b = Convert.ToInt32(oku2["adet"].ToString()); // adeti b ye ata.
                c = b - a; // çıkarma işlemi.
            }
            MessageBox.Show("Ürün Satıldı");
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("update urun set adet='" + c + "' where barkodno='" + textBox1.Text + "'", baglanti); //tB1 i urun tablosundan adet c değişkenine göre güncelle.
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into satis(kimlik,adsoyad,telefon,eposta,barkodno,kategori,marka,model,urunadi,adet) values('"+ textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti); //yandaki kolonları sırasıyla satis tablosundan
            komut.ExecuteNonQuery();//komut u çalıştır.                                                                                                                                                                                                                                                                                                                                                                //kimlik,adsoyad,telefon,eposta,barkodno,kategori,marka,model,urunadi,adet atamasını yap.
            baglanti.Close();
        }
    }
}
