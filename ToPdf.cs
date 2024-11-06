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
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DateTime.Now.ToString("yyyyMMdd_HHmmss")+" " + nameFile), FileMode.Create));
            pdfDoc.Open();

            

            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 12); 

            PdfPTable pdfTable = new PdfPTable(data.ColumnCount);
            pdfTable.WidthPercentage = 100;

            foreach (DataGridViewColumn column in data.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in data.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty, font)); 
                }
            }

            MessageBox.Show("File created!");
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();

        }
    }
}
