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
    public class ToPdf
    {
        public ToPdf(string nameFile, DataGridView data)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DateTime.Now.ToString("yyyyMMdd_HHmmss") + " " + nameFile), FileMode.Create));
            pdfDoc.Open();

           
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 12);

            
            PdfPTable pdfTable = new PdfPTable(data.ColumnCount + 1); 
            pdfTable.WidthPercentage = 100;

            // Добавляем заголовки столбцов
            PdfPCell cell = new PdfPCell(new Phrase("№", font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            pdfTable.AddCell(cell);
            foreach (DataGridViewColumn column in data.Columns)
            {
                cell = new PdfPCell(new Phrase(column.HeaderText, font));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                pdfTable.AddCell(cell);
            }

            
            int rowNumber = 1;
            foreach (DataGridViewRow row in data.Rows)
            {
               
                if (row.IsNewRow) continue;

                
                pdfTable.AddCell(new Phrase(rowNumber.ToString(), font));

                foreach (DataGridViewCell cellData in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cellData.Value?.ToString() ?? string.Empty, font));
                }

                rowNumber++;
            }

            
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();

            MessageBox.Show("Файл успешно создан на рабочем столе!");
        }
    }

}
