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
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa ana = new FrmAnaSayfa();
            ana.Show();
            this.Hide();
        }
        Entity_ProjeEntities db = new Entity_ProjeEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var deger = from x in db.TBL_OGRENCILER
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            x.NUMARA
                        };
            dataGridView1.DataSource = deger.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtSoyad.Text != "" && TxtNumara.Text != "")
            {
                TBL_OGRENCILER t = new TBL_OGRENCILER();
                t.AD = TxtAd.Text;
                t.SOYAD = TxtSoyad.Text;
                t.NUMARA = TxtNumara.Text;
                db.TBL_OGRENCILER.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Başarıyla Eklendi");
                Temizle();
            }
            else
                MessageBox.Show("Boş Alan Bırakmayınız !!");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            TxtId.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            TxtAd.Text = dataGridView1.CurrentRow.Cells["AD"].Value.ToString();
            TxtSoyad.Text = dataGridView1.CurrentRow.Cells["SOYAD"].Value.ToString();
            TxtNumara.Text = dataGridView1.CurrentRow.Cells["NUMARA"].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtId.Text != "")
            {
                int id = Convert.ToInt32(TxtId.Text);
                var x = db.TBL_OGRENCILER.Find(id);
                x.AD = TxtAd.Text;
                x.SOYAD = TxtSoyad.Text;
                x.NUMARA = TxtNumara.Text;
                db.SaveChanges();
                Temizle();
            }
            else
                MessageBox.Show("Bir Öğrenci Seçiniz !");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtId.Text!="")
            {
                int id = Convert.ToInt32(TxtId.Text);
                var sil = db.TBL_OGRENCILER.Find(id);
                db.TBL_OGRENCILER.Remove(sil);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Sistemden Silindi");
                Temizle();
            }
            else
                MessageBox.Show("Bir Öğrenci Seçiniz !");
            
        }
        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtNumara.Text = "";
            TxtSoyad.Text = "";
        }
        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {

        }
    }
}
