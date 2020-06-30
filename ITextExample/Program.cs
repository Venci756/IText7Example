using System.Collections.Generic;
using System.IO;
using System.Linq;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ITextExample
{ 
    class Program
    {
        public static void Main(string[] args)
        {
            // string path = @"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\TextExamples\demo.pdf";
            // string dirPath =@"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\TextExamples";
            //
            //
            //
            // if(File.Exists(path))
            //     File.Delete(path);
            //
            //
            // var directory= Directory.GetFiles(dirPath);
            // foreach (var file in directory)
            // {
            //     File.Delete(file);
            // }

            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(@"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\TextExamples\demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
       
            Document document = new Document(pdf,PageSize.A4,true);
       
            
            //var font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

            #region Creating Cyrillic Font
            //the path to the physical font file TTF on the drive
            string fontPath = 
                $@"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\TextExamples\MAC_C_Times\MCTIME.TTF";
             
            FontProgram fontProgram = FontProgramFactory.CreateFont(fontPath);
            PdfFont font = PdfFontFactory.CreateFont(
                fontProgram, PdfEncodings.WINANSI, true);
           
            #endregion
           
            // var header = new Paragraph("Edine~ni Merki").SetTextAlignment(TextAlignment.CENTER)
            //     .SetFontSize(20).SetFont(font);
            
            var header = new Paragraph("Magacini").SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20).SetFont(font);
           
            Image img = new Image(ImageDataFactory
                    .Create(@"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\logo.jpg"))
                .SetTextAlignment(TextAlignment.CENTER);
            img.Scale(4, 4);
            document.Add(img);
            
            
            document.Add(header);
            // Table
            Table table = new Table(2, false);

            table.SetWidth(400).SetHorizontalAlignment(HorizontalAlignment.CENTER);
            
            
             Cell cell11 = new Cell(1, 1)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .Add(new Paragraph("Broj na magacin")).SetFont(font);
             Cell cell12 = new Cell(1, 1)
                 .SetBackgroundColor(ColorConstants.GRAY)
                 .SetTextAlignment(TextAlignment.CENTER)
                 .Add(new Paragraph("Naziv na magacin")).SetFont(font);
            
            ////Uncomment for Measure Units Example 
            // Cell cell11 = new Cell(1, 1)
            //     .SetBackgroundColor(ColorConstants.YELLOW)
            //     .SetTextAlignment(TextAlignment.CENTER)
            //     .Add(new Paragraph("Edine~na merka")).SetFont(font);
            // Cell cell12 = new Cell(1, 1)
            //     .SetBackgroundColor(ColorConstants.YELLOW)
            //     .SetTextAlignment(TextAlignment.CENTER)
            //     .Add(new Paragraph("Naziv na edine~na merka")).SetFont(font);
            
            
 
            Cell cell21 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("New York"));
            
                    
            
            Cell cell22 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Albany"));
 
            Cell cell31 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("New Jersey"));
            Cell cell32 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Trenton"));
 
            Cell cell41 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("California"));
            Cell cell42 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph("Sacramento"));
 
            
            table.AddCell(cell11);
            table.AddCell(cell12);
            ////Uncomment for Measure Units Example
            // foreach (KeyValuePair<string, string> item in Entities.SampleCollection)
            // {
            //     Cell cellKey = new Cell(1, 1)
            //         .SetTextAlignment(TextAlignment.CENTER)
            //         .Add(new Paragraph(item.Key)).SetFont(font);
            //     
            //     Cell cellValue = new Cell(1, 1)
            //         .SetTextAlignment(TextAlignment.CENTER)
            //         .Add(new Paragraph(item.Value)).SetFont(font);
            //
            //     table.AddCell(cellKey);
            //     table.AddCell(cellValue);
            // }

            foreach (KeyValuePair<string,string> item in Entities.ReadyWarehouses())
            {
                Cell cellKey = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(item.Key)).SetFont(font);
                
                Cell cellValue = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(item.Value)).SetFont(font);

                table.AddCell(cellKey);
                table.AddCell(cellValue);
            }
            // for (int i = 0; i < Coll.words.Count(); i++)
            // {
            //     Cell cell = new Cell(1, 1)
            //         .SetTextAlignment(TextAlignment.CENTER)
            //         .Add(new Paragraph(Coll.words.ElementAt(i)));
            //
            //     table.AddCell(cell);
            // }
            document.Add(table);
            document.Close();
        }

        public static class Coll
        {
            public static void DeleteFile(string path)
            {
                File.Delete(path);
            }
            //string path = @"C:\Users\Intern03.ELIKOSOFT\Desktop\MyProjects\IText7\TextExamples\demo.pdf";
            public static IEnumerable<string> words { get; set; } = new List<string>
            {
                "First",
                "First",
                "First",
                "First",
                "First",
                "Second",
                "Third",
                "Fourth",
                "Fifth",
                "Fifth",
                "Fifth",
                "sixth"
            };
        }
    }
}