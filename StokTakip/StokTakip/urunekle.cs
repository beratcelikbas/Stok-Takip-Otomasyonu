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
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); //veritabanı baglantisi oluştur.

        private void urunekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select kategori from kategori", baglanti); //kategori tablosundan kategori sütununu seç.
            OleDbDataReader oku = komut.ExecuteReader(); //yukarıdaki işlemi oku.
            while (oku.Read()) // oku işlemi doğruysa aşağıdaki işlemi yap
            {
                comboBox1.Items.Add(oku["kategori"].ToString()); 
            }
            baglanti.Close();

            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select marka from marka", baglanti); //marka tablosundan marka sütununu seç.
            OleDbDataReader oku2 = komut2.ExecuteReader(); //yukarıdaki işlemi oku.
            while (oku2.Read()) // oku2 işlemi doğruysa aşağıdaki işlemi yap
            {
                comboBox2.Items.Add(oku2["marka"].ToString());
            }
            baglanti.Close();
            baglanti.Open();
            OleDbCommand komut3 = new OleDbCommand("select model from model", baglanti); //model tablosundan model sütununu seç.
            OleDbDataReader oku3 = komut3.ExecuteReader(); //yukarıdaki işlemi oku.
            while (oku3.Read()) // oku3 işlemi doğruysa aşağıdaki işlemi yap
            {
                comboBox3.Items.Add(oku3["model"].ToString());
            }
            baglanti.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //baglanti aç.
            OleDbCommand kaydet = new OleDbCommand("insert into urun(barkodno,kategori,marka,model,urunadi,rafno,adet,gtarih) values('"+textBox1.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+dateTimePicker1.Text+"')",baglanti); //kolonları sırasıyla urun tablosundan barkodno,kategori,marka,model,urunadi,rafno,adet,gtarih ataması yap.
            kaydet.ExecuteNonQuery(); //kaydet komutunu çalıştır.
            if (textBox1.Text == "") // kullanıcıya boş alanları doldurması için uyarı veren if sorgusu başlat.
            {
                MessageBox.Show("Lütfen Barkod Numarasını girin.");
            }
            else
            {
                MessageBox.Show("Ürün Başarıyla Eklendi.");       
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            baglanti.Close();
            urunekle_Load(sender, e); // Temizledikten sonra, urunekle_Load da yapılan bütün işlemleri tekrardan yap.
            baglanti.Close(); //baglanti kapat.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
