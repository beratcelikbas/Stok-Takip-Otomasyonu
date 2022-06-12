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
    public partial class urunduzenle : Form
    {
        public urunduzenle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); //veritabanı bağlantısı oluştur.
        private void urunduzenle_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update urun set barkodno='" + textBox1.Text + "', kategori='" + comboBox1.Text + "', marka='" + comboBox2.Text + "', model='" + comboBox3.Text + "', urunadi='" + textBox2.Text + "',rafno='" + textBox3.Text + "',adet='" + textBox4.Text + "',gtarih='" + dateTimePicker1.Text + "' where barkodno='" + textBox1.Text + "'", baglanti); //urun tablosundan barkodno ya göre yandaki işlemleri güncelle.
            komut.ExecuteNonQuery(); // komutu çalıştır.
            if (textBox1.Text == "") //tB1 boş ise aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Lütfen Barkod Numarasını Girin.");
            }
            else //değilse aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Ürün Düzenlendi.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from urun where barkodno='" + textBox1.Text + "'", baglanti); // tB1 kolonunu urun tablosundan barkodno ya göre seç.
            OleDbDataReader oku = komut.ExecuteReader(); //yukarıdaki işlemi oku.
            while (oku.Read()) // doruysa aşağıdaki işlemleri yap.
            {
                comboBox1.Text = oku["kategori"].ToString();
                comboBox2.Text = oku["marka"].ToString();
                comboBox3.Text = oku["model"].ToString();
                textBox2.Text = oku["urunadi"].ToString();
                textBox3.Text = oku["rafno"].ToString();
                textBox4.Text = oku["adet"].ToString();
                dateTimePicker1.Text = oku["gtarih"].ToString();
            }
            baglanti.Close();
        }
    }
}
