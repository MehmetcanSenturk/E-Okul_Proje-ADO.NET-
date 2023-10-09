using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul_Proje
{
    public partial class OgretmenFormu : Form
    {
        public OgretmenFormu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgretmenKulupIslemleri fr = new OgretmenKulupIslemleri();
            fr.Show();
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            DerslerFormu fr = new DerslerFormu();
            fr.Show();  
            this.Close();
        }

        private void btnOgrenciIsleri_Click(object sender, EventArgs e)
        {
            OgrenciIslemleriFormu fr     = new OgrenciIslemleriFormu();
            fr.Show();
        }

        private void btnSinavlar_Click(object sender, EventArgs e)
        {
            SinavNotlariFormu fr    = new SinavNotlariFormu();
            fr.Show();
        }
    }
}
