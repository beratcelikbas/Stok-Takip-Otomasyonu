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
    public partial class aramayap : Form
    {
        public aramayap()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); // veritabanı bağlantısı oluştur.
        DataTable tablo = new DataTable();  // tablo adında datatable nesnesi oluştur.
        DataTable tablo2 = new DataTable(); // tablo2 adında datatable nesnesi oluştur.
        DataTable tablo3 = new DataTable(); // tablo3 adında datatable nesnesi oluştur.
        private void aramayap_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Müşteri") //eğer combobox da Müşteri yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open(); // baglanti ac
                tablo.Clear(); 
                OleDbDataAdapter m = new OleDbDataAdapter("select *from musteri", baglanti); //m nesnesi veri tabanının urun tablosundan kullanır.
                m.Fill(tablo); // dataadapterin fill metodu ile musteriyi tablo ile doldur.
                dataGridView1.DataSource = tablo; //"tablo" yu göster.
                baglanti.Close();
            }
            else if (comboBox1.Text == "Ürün") //eğer combobox da Müşteri yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open();
                tablo2.Clear();
                OleDbDataAdapter u = new OleDbDataAdapter("select *from urun", baglanti); // u nesnesi veri tabanının urun tablosundan kullanır.
                u.Fill(tablo2); // dataadapterin fill metodu ile urunu tablo ile doldur.
                dataGridView1.DataSource = tablo2; //"tablo2" yi göster.
                baglanti.Close();
            }
            else if (comboBox1.Text == "Satış") //eğer combobox da Müşteri yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open();
                tablo3.Clear();
                OleDbDataAdapter s = new OleDbDataAdapter("select *from satis", baglanti); //s nesnesi veri tabanının urun tablosundan kullanır.
                 s.Fill(tablo3); //dataadapterin fill metodu ile satisi tablo ile doldur.
                dataGridView1.DataSource = tablo3;//"tablo3" u göster.
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e) // arama butonunun altındaki işlemeler.
        {
            if (textBox1.Text=="") //boş ise aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Geçersiz arama!");
            }
            else if (comboBox1.Text=="Müşteri") //Müşteri yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open();//baglanti aç
                tablo.Clear();
                OleDbDataAdapter m = new OleDbDataAdapter("select *from musteri where kimlik like '"+textBox1.Text+"'", baglanti);//musteri tablosundan kimlik e göre arama yap.
                m.Fill(tablo); //"tablo" yu yukarıdaki işleme göre doldur.
                dataGridView1.DataSource = tablo; //"tablo" yu yukarıdaki işleme göre göster.
                baglanti.Close();//baglanti kapat.
            }
            else if (comboBox1.Text == "Ürün") //Ürün yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open();//baglanti aç
                tablo2.Clear();
                OleDbDataAdapter u = new OleDbDataAdapter("select *from urun where barkodno like '"+textBox1.Text+"'", baglanti); //urun tablosundan barkodno ya göre arama yap.
                u.Fill(tablo2); //"tablo2" yi yukarıdaki işleme göre doldur.
                dataGridView1.DataSource = tablo2; //"tablo2" yi yukarıdaki işleme göre göster.
                baglanti.Close();//baglanti kapat.
            }
            else if (comboBox1.Text == "Satış") // Satış yazıyorsa aşağıdaki işlemleri yap.
            {
                baglanti.Open();//baglanti aç
                tablo3.Clear();
                OleDbDataAdapter s = new OleDbDataAdapter("select *from satis where barkodno like '" + textBox1.Text + "'", baglanti); //satis tablosundan barkodno ya göre arama yap
                s.Fill(tablo3); //"tablo3" ü yukarıdaki işleme göre doldur.
                dataGridView1.DataSource = tablo3; //"tablo3" u yukarıdaki işleme göre göster.
                baglanti.Close();//baglanti kapat.
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
