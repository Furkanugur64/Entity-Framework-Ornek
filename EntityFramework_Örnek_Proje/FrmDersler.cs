using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework_Örnek_Proje
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        Entity_ProjeEntities db = new Entity_ProjeEntities();
        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa ana = new FrmAnaSayfa();
            ana.Show();
            this.Hide();
        }
        void Listele()
        {
            var degerler = from x in db.TBL_DERSLER
                           select new
                           {
                               x.DERSID,
                               x.DERSAD
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_DERSLER d = new TBL_DERSLER();
            d.DERSAD = TxtAd.Text;
            db.TBL_DERSLER.Add(d);
            db.SaveChanges();
            MessageBox.Show("Ders Sisteme Eklendi");
            Listele();
            TxtAd.Text = "";
            Listele();
            Temizle();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            TxtId.Text = dataGridView1.CurrentRow.Cells["DERSID"].Value.ToString();
            TxtAd.Text = dataGridView1.CurrentRow.Cells["DERSAD"].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtId.Text);
            var x = db.TBL_DERSLER.Find(id);
            db.TBL_DERSLER.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Ders Sistemden Silindi");
            Listele();
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtId.Text);
            var tb = db.TBL_DERSLER.Find(id);
            tb.DERSAD = TxtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Ders Başarıyla Güncellendi");
            Listele();
            Temizle();
        }
        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
        }
        private void FrmDersler_Load(object sender, EventArgs e)
        {

        }
    }
}
