using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void satışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aramaYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form satis = new satisyap();
            satis.Show();
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form cık = new Form1();
            cık.Show();
        }

        private void kategoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kat = new kategori(); 
            kat.Show();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {

        }

        private void markaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form mar = new marka();
            mar.Show();
        }

        private void modelOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form mod = new model();
            mod.Show();
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kullanici = new kullaniciekle();
            kullanici.Show();

        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form mst = new musteri();
            mst.Show();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form u_ekle = new urunekle();
            u_ekle.Show();
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form u_sil = new urunsil();
            u_sil.Show();
        }

        private void ürünDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form u_duzenle = new urunduzenle();
            u_duzenle.Show();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form arama = new aramayap();
            arama.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
 