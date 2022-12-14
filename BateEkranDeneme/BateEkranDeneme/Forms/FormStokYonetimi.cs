using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using BateEkranDeneme.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace BateEkranDeneme.Forms
{
    public partial class FormStokYonetimi : Form
    {
        public FormStokYonetimi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
       
        void StoklariListele()
        {
            baglanti = new SqlConnection(
            @"Data Source=DESKTOP-V8AD49K\MSSQLSERVER01;
            Initial Catalog=MikroDB_V16_2022; 
            Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM STOK_DEPO_DETAYLARI", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        void StokMarkalari()
        {
            baglanti = new SqlConnection(
            @"Data Source=DESKTOP-V8AD49K\MSSQLSERVER01;
            Initial Catalog=MikroDB_V16_2022; 
            Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM STOK_MARKALARI", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            StoklariListele();
            StokMarkalari();
         
        }

        bool export_dgw_excel_1(DataGridView dgw)
        {
            //Add Reference Microsoft.Office.Interop.Excel kütüphanesini ekleyin
            //using satırlarına using Excel = Microsoft.Office.Interop.Excel; satırını ekleyin.
            bool durum = false;
            try
            {
                dgw.SelectAll();
                DataObject dataObj = dgw.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                
                //Kodumuz buraya kadar gelip veri aktarımını tamamladı ise durum true yaparak işlemin başarılı
                //Olduğu bilgisini alıyoruz.
                durum = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGrid Verileri Aktarılamadı : " + ex.Message);
            }
            return durum;
        }

        bool export_dgw_excel_2(DataGridView dgw)
        {
            bool durum = false;
            try
            {
                Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Sütun Başlıkları
                for (j = 0; j < dgw.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgw.Columns[j].HeaderText;
                }

                StartRow++;

                //Datagridview İçeriği Yazdırılıyor
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    for (j = 0; j < dgw.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgw[j, i].Value == null ? "" : dgw[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
                //Kodumuz buraya kadar gelip veri aktarımını tamamladı ise durum true yaparak işlemin başarılı
                //Olduğu bilgisini alıyoruz.
                durum = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DataGrid Verileri Aktarılamadı : " + ex.Message);
            }

            return durum;
        }

        private void excel_button_Click(object sender, EventArgs e)
        {
            ExcelFormat.export_dgw_excel_1(dataGridView1);
        }

        private void pdf_button_Click(object sender, EventArgs e)
        {
            PdfFormat.exportGridToPdf(dataGridView1, "Rapor");
        }
      
    }
}
