using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;

namespace BateEkranDeneme.Common
{
    public static class PdfFormat
    {
        public static void exportGridToPdf(DataGridView dg, string fileName) 
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dg.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf,10,iTextSharp.text.Font.NORMAL);
            //add header
            foreach (DataGridViewColumn column in dg.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText,text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //add datarow
            foreach (DataGridViewRow row in dg.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells) 
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));

                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = fileName;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(pdf, stream);
                    pdf.Open();
                    pdf.Add(pdfTable);
                    pdf.Close();
                    stream.Close();

                }
            }

        }

    }
}
