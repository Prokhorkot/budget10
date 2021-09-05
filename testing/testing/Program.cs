using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Excel.Application();
            app.DisplayAlerts = false;

            var dataFrame = new Excel.Application();
            dataFrame.DisplayAlerts = false;

            Excel.Workbook entry;
            Excel.Workbook output;

            Console.WriteLine("Вставьте путь к папке с исходными данными");
            String pathReadDirectory = Console.ReadLine();

            Console.WriteLine("Вставьте путь к папке для сохранения нового файла");
            String pathWriteDirectory = Console.ReadLine();

            String pathWrite = pathWriteDirectory + @"\result.xlsx";

            if (File.Exists(pathWrite))
            {
                output = dataFrame.Workbooks.Open(pathWrite);
            }
            else
            {
                output = dataFrame.Workbooks.Add();
                Excel.Worksheet sh = output.Worksheets.Add();
                output.SaveAs(pathWrite);
            }

            output = dataFrame.Workbooks.Open(pathWrite);
            dataFrame.Visible = true;
            Excel.Worksheet outSheet = dataFrame.ActiveSheet;
            Excel.Worksheet entrySheet;

            outSheet.Cells[2, 1] = "Наименование показателя";
            outSheet.Range["B1", "M1"].Merge();
            outSheet.Cells[1, 2] = "Величина дохода";
            outSheet.Cells[3, 1] = "Налоги на прибыль, доходы";
            outSheet.Cells[4, 1] = "НДФЛ";
            outSheet.Cells[5, 1] = "Налог на имущество организаций";
            outSheet.Cells[6, 1] = "Доходы от оказания платных услуг";

            outSheet.Rows[1].RowHeight = 50;
            outSheet.Rows[2].RowHeight = 40;
            outSheet.Rows.RowHeight = 20;
            outSheet.Columns.ColumnWidth = 30;
            outSheet.Columns[1].ColumnWidth = 40;
            outSheet.Cells.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            outSheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            for (int year = 2010; year < 2021; year++)
            {

                entry = app.Workbooks.Open(pathReadDirectory + @"\" + year.ToString() + "_res.xlsx");
                

                entrySheet = app.ActiveSheet;

                outSheet.Cells[2, year - 2008] = year.ToString();

                for (int i = 2; i < 6; i++)
                {
                    outSheet.Cells[i + 1, year - 2008] = entrySheet.Cells[i, 3];
                }

                entry.Close();
            }

            outSheet.Cells[2, 13] = "2021 вер.";

            Double[,] k = new Double[4, 9];

            Double[] coef = new Double[4];
            for (int y = 3; y < 7; y++)
            {
                for (int x = 4; x < 13; x++)
                {
                    string a = outSheet.Cells[y, x].Value.ToString();
                    string b = outSheet.Cells[y, x - 1].Value.ToString();
                    k[y - 3, x - 4] = Double.Parse(a) / Double.Parse(b); 
                }
            }

            for (int y = 0; y < 4; y++)
            {
                double temp = 0;
                for (int x = 0; x < 9; x++)
                {
                    temp += k[y, x];
                }
                coef[y] = temp / k.GetLength(1);

                outSheet.Cells[3 + y, 13] = (Double.Parse(outSheet.Cells[3 + y, 12].Value.ToString()) * coef[y]).ToString();
            }

            dataFrame.ActiveWorkbook.Save();

            output.Close();

            app.Quit();
            dataFrame.Quit();
        }
    }
}
