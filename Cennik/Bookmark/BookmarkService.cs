using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Cennik.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Cennik.Bookmark
{
    public class BookmarkService
    {
        public void GenerateDoc(ObservableCollection<Przedmiot> list, string fileName)
        {

            int lp = 1;
            string bmName;
            string stawka;
            string typStawki;

            bool isPrise = list.Any(oItem => oItem.Cena == 0);
            if (isPrise == true)
            {
                typStawki = "Doba zł/Godz. zł";
            }
            else
                typStawki = "Cena zł";

            string source = @"C:\temp\Cennik.docx";
            string destinaton = source.Replace("Cennik", "Cennik " + fileName);

            File.Copy(source, destinaton);

            using (WordprocessingDocument document = WordprocessingDocument.Open(destinaton, true))
            {
                var mainPart = document.MainDocumentPart;
                bmName = "tabela";
                var res = from bm in mainPart.Document.Body.Descendants<BookmarkStart>()
                          where bm.Name == bmName
                          select bm;
                var bookmark = res.SingleOrDefault();
                if (bookmark != null)
                {
                    var parent = bookmark.Parent;


                    Run run = new Run(new RunProperties(new Bold()));
                    Paragraph newParagraph = new Paragraph(run);

                    parent.InsertBeforeSelf(newParagraph);
                    parent.Remove();

                    Table table = new Table();
                    TableProperties props = new TableProperties(
                        new TableStyle() { Val = "TableGrid" },
                        new TableWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto },
                        new TableBorders(
                            new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                            new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                        ),
                        new TableGrid(
                            new GridColumn() { Width = new StringValue("500") },
                            new GridColumn() { Width = new StringValue("5200") },
                            new GridColumn() { Width = new StringValue("700") },
                            new GridColumn() { Width = new StringValue("1000") },
                            new GridColumn() { Width = new StringValue("900") },

                    new TableRow(
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Lp."))
                            )),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Nazwa"))
                            )),
                        new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Kaucja zł"))
                            )),
                         new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text("Wartość"))
                            )),
                          new TableCell(
                            new TableCellProperties(
                                new TableCellWidth() { Width = new StringValue("0"), Type = TableWidthUnitValues.Auto }),
                            new Paragraph(
                                new Run(
                                    new Text(typStawki))))
                        
                        )));
                    table.AppendChild(props);

                    foreach (Przedmiot item in list)
                    {
                        string typStawkiSlownie = string.Empty;
                        if (isPrise == true)
                        {
                            stawka = $"{item.StawkaDzien}/{item.StawkaGodzinowa}";
                        }
                        else
                            stawka = item.Cena.ToString();

                        table.Append(new TableRow(
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(lp.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.Nazwa))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.Wartosc.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(item.Kaucja.ToString()))))),
                            new TableCell(
                                new TableCellProperties(
                                    new Paragraph(
                                        new Run(
                                            new Text(stawka)))))

                                    ));

                        lp++;

                    }
                    newParagraph.InsertBeforeSelf(table);

                    bmName = "Nazwa";
                    bookmark = res.Single();
                        parent = bookmark.Parent;
                        var paragraph =
                            new Paragraph(new Run(new Text(string.Empty)),
                                new Paragraph(
                                    new Run(new Text($"{fileName}")))
                                );
                        parent.InsertBeforeSelf(paragraph);
                        parent.Remove();
                }
                document.Close();
            }
            Process.Start(destinaton);
        }
    }
}
