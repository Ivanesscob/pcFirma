using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcFirma
{
    internal class ToPdf
    {
        public ToPdf(string nameFile, DataGridView data) {

            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameFile), FileMode.Create));
            pdfDoc.Open();


            PdfPTable pdfTable = new PdfPTable(data.ColumnCount);
            pdfTable.WidthPercentage = 100;


            foreach (DataGridViewColumn column in data.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(cell);
            }


            foreach (DataGridViewRow row in data.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                }
            }

            MessageBox.Show("File created");
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();

        }
    }
}
