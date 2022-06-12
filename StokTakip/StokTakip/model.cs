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
    public partial class model : Form
    {
        public model()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\StokTakip.mdb");  // veritabanı baglantisi oluştur.

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); //baglanti ac.
            OleDbCommand kaydet = new OleDbCommand("insert into model(id,model) values ('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);// tB1 ve tB2 kolonlarını sırasıyla model tablosundan id,model atamasını yap.
            kaydet.ExecuteNonQuery(); //kaydet komutunu çalıştır.
            baglanti.Close();// baglanti kapat.
            if (textBox1.Text == "" || textBox2.Text == "") //tB1 ya da tB2 boş ise aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Lütfen boş alanları doldurun.");
            }
            else //değilse aşağıdaki uyarıyı ver.
            {
                MessageBox.Show("Model başarıyla oluşturuldu.");
            }
            textBox1.Clear(); //tB1 i temizle.
            textBox2.Clear(); //tB2 yi temizle
        }

        private void model_Load(object sender, EventArgs e)
        {

        }
    }
}
