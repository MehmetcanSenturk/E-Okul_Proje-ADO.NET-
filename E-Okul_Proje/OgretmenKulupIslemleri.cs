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
    public partial class OgretmenKulupIslemleri : Form
    {
        public OgretmenKulupIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=root\SQLEXPRESS;Initial Catalog=db_Okul;Integrated Security=True");
        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tbl_Kulupler", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void OgretmenKulupIslemleri_Load(object sender, EventArgs e)
        {
           list();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Kulupler (KulupAd) values (@p1)", conn);
            cmd.Parameters.AddWithValue("p1",txtKulupAd.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(txtKulupAd.Text +" "+ "Kulübü Eklenmiştir");
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Kulupler Where KulupID=@p2", conn);
            cmd.Parameters.AddWithValue("@p2", txtKulupID.Text); 
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(txtKulupAd.Text + " " + "Kulübü Silinmiştir");
            list();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Tbl_Kulupler set KulupAd=@p3  where KulupID=@p4", conn);
            cmd.Parameters.AddWithValue("@p3", txtKulupAd.Text);
            cmd.Parameters.AddWithValue("@p4", txtKulupID.Text);
            cmd.ExecuteNonQuery();
            conn.Close();        
            list();
        }
    }
}
