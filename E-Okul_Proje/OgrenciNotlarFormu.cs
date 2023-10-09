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
using System.Reflection.Emit;

namespace E_Okul_Proje
{
    public partial class OgrenciNotlarFormu : Form
    {
        public OgrenciNotlarFormu()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=root\SQLEXPRESS;Initial Catalog=db_Okul;Integrated Security=True");
        public string numara;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void OgrenciNotlarFormu_Load(object sender, EventArgs e)
        { 
            
            SqlCommand cmd = new SqlCommand("SELECT DersAd,Sinav,Sinav2,Sinav3,Proje,Ortalama,Durum FROM Tbl_Notlar\r\nINNER JOIN Tbl_Dersler ON Tbl_Notlar.DersId=Tbl_Dersler.DersId where OgrenciId =@p1", conn);
            cmd.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*
             * 
             */
            conn.Open();

            SqlCommand komut1 = new SqlCommand("select OgrenciAd,OgrenciSoyad from Tbl_Ogrenci where OgrenciId=@p1", conn);

            komut1.Parameters.AddWithValue("@p1", numara);

            SqlDataReader dr1 = komut1.ExecuteReader();

            while (dr1.Read())

            {

                this.Text = dr1[0] + " " + dr1[1].ToString();

            }

            conn.Close();
        }
    }
}
