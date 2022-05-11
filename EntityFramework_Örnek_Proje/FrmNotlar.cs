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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
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
        void Temizle()
        {
            TxtID.Text = "";
            TxtOrtalama.Text = "";
            TxtSınav1.Text = "";
            TxtSınav2.Text = "";
            TxtSınav3.Text = "";
            CmbDers.SelectedIndex = -1;
            CmbOgrenci.SelectedIndex = -1;
        }
        void DersGetir()
        {
            var deger = from x in db.TBL_DERSLER
                        select new
                        {
                            x.DERSID,
                            x.DERSAD
                        };
            CmbDers.ValueMember = "DERSID";
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.DataSource = deger.ToList();
        }
        void OgrenciGetir()
        {
            var deger = from x in db.TBL_OGRENCILER
                        select new
                        {
                            x.ID,
                            x.AD
                        };
            CmbOgrenci.DisplayMember = "AD";
            CmbOgrenci.ValueMember = "ID";
            CmbOgrenci.DataSource = deger.ToList();
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            DersGetir();
            OgrenciGetir();
            CmbDers.SelectedIndex = -1;
            CmbOgrenci.SelectedIndex = -1;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtSınav1.Text != "" && TxtSınav2.Text != "" && TxtSınav3.Text != "" && TxtOrtalama.Text != "")
            {
                TBL_NOTLAR nt = new TBL_NOTLAR();
                nt.OGR = Convert.ToInt32(CmbOgrenci.SelectedValue);
                nt.DERS = Convert.ToInt32(CmbDers.SelectedValue);
                nt.SINAV1 = short.Parse(TxtSınav1.Text);
                nt.SINAV2 = short.Parse(TxtSınav2.Text);
                nt.SINAV3 = short.Parse(TxtSınav3.Text);
                nt.ORTALAMA = decimal.Parse(TxtOrtalama.Text);
                db.TBL_NOTLAR.Add(nt);
                db.SaveChanges();
                Temizle();
                listele();
            }
            else
                MessageBox.Show("Boş Alan Bırakmayınız !!");
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if (TxtSınav1.Text != "" && TxtSınav2.Text != "" && TxtSınav3.Text != "")
            {
                float s1, s2, s3, ort;
                s1 = float.Parse(TxtSınav1.Text);
                s2 = float.Parse(TxtSınav2.Text);
                s3 = float.Parse(TxtSınav3.Text);
                ort = (s1 + s2 + s3) / 3;
                TxtOrtalama.Text = ort.ToString();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                int id = Convert.ToInt32(TxtID.Text);
                var x = db.TBL_NOTLAR.Find(id);
                db.TBL_NOTLAR.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Not Silindi !!");
                Temizle();
                listele();
            }
            else
                MessageBox.Show("Bir Not Seçin !!");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                int id = Convert.ToInt32(TxtID.Text);
                var deger = db.TBL_NOTLAR.Find(id);
                deger.OGR = Convert.ToInt32(CmbOgrenci.SelectedValue);
                deger.DERS = Convert.ToInt32(CmbDers.SelectedValue);
                deger.SINAV1 = short.Parse(TxtSınav1.Text);
                deger.SINAV2 = short.Parse(TxtSınav2.Text);
                deger.SINAV3 = short.Parse(TxtSınav3.Text);
                deger.ORTALAMA = decimal.Parse(TxtOrtalama.Text);
                db.SaveChanges();
                Temizle();
                
            }
        }
        void listele()
        {
            var deger = from d1 in db.TBL_NOTLAR
                        join d2 in db.TBL_DERSLER
                        on d1.DERS equals d2.DERSID
                        join d3 in db.TBL_OGRENCILER
                        on d1.OGR equals d3.ID
                        select new
                        {
                            ID = d1.NOTID,
                            ÖĞRENCİ = d3.AD,
                            DERS = d2.DERSAD,
                            SINAV1 = d1.SINAV1,
                            SINAV2 = d1.SINAV2,
                            SINAV3 = d1.SINAV3,
                            ORTALAMA = d1.ORTALAMA,
                        };
            dataGridView1.DataSource = deger.ToList();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           TxtID .Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
           CmbOgrenci .Text = dataGridView1.CurrentRow.Cells["ÖĞRENCİ"].Value.ToString();
           CmbDers .Text = dataGridView1.CurrentRow.Cells["DERS"].Value.ToString();
           TxtSınav1 .Text = dataGridView1.CurrentRow.Cells["SINAV1"].Value.ToString();
           TxtSınav2 .Text = dataGridView1.CurrentRow.Cells["SINAV2"].Value.ToString();
           TxtSınav3 .Text = dataGridView1.CurrentRow.Cells["SINAV3"].Value.ToString();
           TxtOrtalama .Text = dataGridView1.CurrentRow.Cells["ORTALAMA"].Value.ToString();
           
            
        }
    }
}
