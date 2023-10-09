using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul_Proje
{
    public partial class SinavNotlariFormu : Form
    {
        public SinavNotlariFormu()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=root\SQLEXPRESS;Initial Catalog=db_Okul;Integrated Security=True");

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter dset = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dset.NotListesi(int.Parse(txtId.Text));
        }

        private void SinavNotlariFormu_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * From  Tbl_Dersler", conn);
            SqlDataAdapter dadapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dadapter.Fill(dt);
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersId";
            cmbDers.DataSource = dt;
            conn.Close();
        }
        int notId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notId  = int.Parse (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav, sinav2, sinav3, proje;
        double ortalama;
        
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
            sinav = Convert.ToInt32(txtSinav.Text);
            sinav2 = Convert.ToInt32(txtSinav.Text);
            sinav3= Convert.ToInt32(txtSinav.Text);
            proje = Convert.ToInt32(txtSinav.Text);
            ortalama = (sinav+sinav2+ sinav3+proje)/ 4;
            txtOrtalama.Text = ortalama.ToString(); 
            if(ortalama >= 50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text="False";   
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            dset.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtId.Text),byte.Parse( txtSinav.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), notId);
        }
    }
}
