using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_Okul_Proje
{
    public partial class OgrenciIslemleriFormu : Form
    {
        string cinsiyet = "";
        public OgrenciIslemleriFormu()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=root\SQLEXPRESS;Initial Catalog=db_Okul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void OgrenciIslemleriFormu_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.OgrenciListesi();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * From  Tbl_Kulupler", conn);
            SqlDataAdapter dadapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dadapter.Fill(dt);
            cmbKulup.DisplayMember = "KulupAd";
            cmbKulup.ValueMember = "KulupID"; 
            cmbKulup.DataSource = dt;   
            conn.Close();

        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if(rdrKadın.Checked == true )
            {
                cinsiyet = "Kadın";
            }
            if(rdrErkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            ds.OgrenciEkle(txtAd.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),cinsiyet);
            MessageBox.Show(txtAd.Text + txtSoyad + " " + " Eklendi");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            ds.OgrenciSil(int.Parse(txtId.Text));
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (cinsiyet == "Kadın")
            {
                rdrKadın.Checked = true;
                rdrErkek.Checked = false;
            }
            else if (cinsiyet == "Erkek")
            {
                rdrKadın.Checked = false;
                rdrErkek.Checked = true;
            }

        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            ds.OgrenciGuncelle(txtAd.Text, txtSoyad.Text, byte.Parse (cmbKulup.SelectedValue.ToString()), cinsiyet,int.Parse (txtId.Text));
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void rdrKadın_CheckedChanged(object sender, EventArgs e)
        {
            if (rdrKadın.Checked == true)
            {
                cinsiyet = "Kadın";
            }
            
        }

        private void rdrErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdrErkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= ds.OgrenciGetir(txtOgrenciAra.Text);
        }
    }
}
