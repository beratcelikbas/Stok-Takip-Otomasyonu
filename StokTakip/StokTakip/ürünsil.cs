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
    public partial class urunsil : Form
    {
        public urunsil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); // baglanti adında yeni bir VeriTabanı bağlantısı oluştur.
        private void ürünsil_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open(); //baglanti ac
            OleDbCommand komut = new OleDbCommand("select *from urun where barkodno='" + textBox1.Text + "'", baglanti); //urun tablasundan barkodno ya göre seç
            OleDbDataReader oku = komut.ExecuteReader(); // oku adında okuyucu oluştur.
            while (oku.Read()) // oku doğru olduğu sürece aşağıdaki işlemleri yap.
            {
                textBox2.Text = oku["urunadi"].ToString();
                textBox3.Text = oku["adet"].ToString();
            }
            baglanti.Close(); //baglanti kapa.
        }

        private void button1_Click(object sender, EventArgs e) //sil butonunun altındaki işlemleri yap.
        {
            baglanti.Open(); //baglanti aç
            OleDbCommand sil = new OleDbCommand("delete from urun where barkodno= '" + textBox1.Text + "'", baglanti);//urun tablosundaki verileri barkod numarasına göre silen komut oluştur.
            sil.ExecuteNonQuery(); //sil komutunu çalıştır.
            if (textBox1.Text == "") //tB1 boş ise aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Lütfen Barkod Numarasını Girin.");
            }
            else //değilse aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Ürün Sistemden Kaldırıldı.");
            }
            baglanti.Close();//baglanti kapat.
            textBox1.Clear(); //tB1 i temizle.
            textBox2.Clear(); //tB2 yi temizle.
            textBox3.Clear(); //tB3 ü temizle.
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
