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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); // baglanti adında VeriTabanı bağlantısı oluşturma.
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // button2 ye tıklandığında çıkış yap.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" && textBox2.Text=="") // 1 ve 2 . kutular boş ise alttaki uyarıyı ver.
            {
                MessageBox.Show("Lütfen boş alan bırakmayın !");
            }
            else if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen ID girişi yapın !"); //1. kutu boş ise alttaki uyarıyı ver.
            }
            else if (textBox2.Text=="")
            {
                MessageBox.Show("Lütfen ŞİFRE girişi yapın !");//2. kutu boş ise alttaki uyarıyı ver.
            }
            else // yukarıdakilerin hiçbiri değilse aşağıdaki işlemleri yap.
            {
                baglanti.Open(); // yukarıda tanımlanan VeriTabanı bağlantısını aç.
                OleDbCommand komut = new OleDbCommand("Select * from kullanicibilgi where id = '" + textBox1.Text + "'", baglanti); // veritabanındaki verilerin sorgulanması
                OleDbDataReader oku = komut.ExecuteReader(); 
                if (oku.Read() == true)
                {
                    if (textBox1.Text == oku["id"].ToString() && textBox2.Text == oku["sifre"].ToString()) // giriş yapılan veriler ile tablodaki verilerin eşleşmesi durumunda aşağıdaki işlemleri yap.
                    {
                        MessageBox.Show("Hoşgeldin Sayın " + oku["adsoyad"].ToString());
                        Form frm1 = new anamenu();
                        frm1.Show();
                        this.Hide();
                    }
                    else // bilgilerin eksiksiz girildiği fakat veritabanındaki bilgilerle eşleşmediği durumlarda aşağıdaki işlemleri yap.
                    {
                        MessageBox.Show("Lütfen girdiğiniz bilgileri kontrol edin...");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen girdiğiniz bilgileri kontrol edin...");
                }
                baglanti.Close(); //bağlantıyı kapat.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
