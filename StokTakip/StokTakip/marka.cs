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
    public partial class marka : Form
    {
        public marka()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb"); // veritabanı bağlantısı oluştur.
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void marka_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //baglanti aç.
            OleDbCommand kaydet = new OleDbCommand("insert into marka(id,marka) values('"+textBox1.Text+ "','" + textBox2.Text+"')" , baglanti );// tB1 ve tB2 kolonlarını sırasıyla marka tablosundan id,marka atamasını yap.
            kaydet.ExecuteNonQuery(); // kaydet komutunu çalıştır.
            baglanti.Close(); //baglanti kapa.
            if (textBox1.Text == "" || textBox2.Text == "") // tB1 ya da tB2 boş ise aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else // değilse aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Marka başarıyla oluşturuldu.");
            }
            textBox1.Clear(); //tB1 kolonunu temizle.
            textBox2.Clear(); //tB2 kolonunu temizle.
        }
    }
}
