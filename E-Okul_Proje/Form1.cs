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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Giriş.Text))
            {
                MessageBox.Show("Alan Boş Bırakılamaz");
            }
            else
            {
                OgrenciNotlarFormu fr = new OgrenciNotlarFormu();
                fr.numara = Giriş.Text;
                fr.Show();
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Giriş.Text))
            {
                MessageBox.Show("Alan Boş Bırakılamaz");
            }
            else
            {
                OgretmenFormu fr = new OgretmenFormu();
                fr.Show();
            }
          
        }
    }
}
