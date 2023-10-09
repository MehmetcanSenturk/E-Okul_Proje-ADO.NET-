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
    public partial class DerslerFormu : Form
    {
        public DerslerFormu()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void DerslerFormu_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.DersListesi();  
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            dataGridView1.DataSource = ds.DersListesi();
            MessageBox.Show(txtDersAd.Text + " " + "Dersi Eklenmiştir");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text));
            MessageBox.Show(txtDersAd.Text + " " + "Dersi Silinmiştir");
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtDersAd.Text,byte.Parse (txtDersID.Text));
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                txtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }

        }
    }
}
