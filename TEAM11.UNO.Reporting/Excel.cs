using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace TEAM11.UNO.Reporting
{
    public static class Excel
    {
        public static void Export(string filename, string[,] dataContents)
        {
			try
			{
				// Initialize the Workbook or // Excel Spreadsheet.

				IXLWorkbook xlWorkBook = new XLWorkbook();
				IXLWorksheet xlWorkSheet = xlWorkBook.AddWorksheet("Data");

				// Grab rows and columns.

				int rows = dataContents.GetLength(0);
				int cols = dataContents.GetLength(1);

				// Showing how to save to a pdf, since pdf isn't a "preset" option. 

				PdfWriter writer = new PdfWriter(filename.Substring(0, filename.Length - 4) + "pdf");

				PdfDocument pdf = new PdfDocument(writer);

				Document document = new Document(pdf);

				// Creating the headers for the Excel spreadsheet page. 

				iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph("Data")
					.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
					.SetFontSize(20);

				document.Add(header);

                iText.Layout.Element.Paragraph subHeader = new iText.Layout.Element.Paragraph("Information")
					.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
					.SetFontSize(15);

                document.Add(subHeader);

				Table table = new Table(cols, false);

				// Adding in the data to the Excel.

				for(int iRow = 1; iRow <= rows; iRow++)
				{
                    for (int iCols = 1; iCols <= cols; iCols++)
                    {
						// Excel
						xlWorkSheet.Cell(iRow, iCols).Value = dataContents[iRow - 1, iCols - 1];

						// Pdf
						Cell cell = new Cell(1,1);
						cell.Add(new Paragraph(dataContents[iRow - 1, iCols - 1]));
						table.AddCell(cell);
                    }
                }

				document.Add(table);

				document.Close();

				xlWorkBook.SaveAs(filename);
            }
			catch (Exception ex)
			{
				throw;
			}
        }
    }
}
