using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BateEkranDeneme.Forms
{
    public partial class FormInsert : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;

        void CariListele()
        {
            baglanti = new SqlConnection(
            @"Data Source=DESKTOP-V8AD49K\MSSQLSERVER01;
            Initial Catalog=DinamikMikroPlus; 
            Integrated Security=True");
            baglanti.Open();
            da=new SqlDataAdapter("SELECT * FROM Dinamik_Cari", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            
        }
        public FormInsert()
        {
            InitializeComponent();
        }

        private void FormInsert_Load(object sender, EventArgs e)
        {
            CariListele();
        }

     

        
    }
}
