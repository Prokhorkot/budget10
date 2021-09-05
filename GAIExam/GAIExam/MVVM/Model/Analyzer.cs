using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace GAIExam.MVVM.Model
{
    class Program
    {

        public static void readInfo(string path)
        {

            String year = "2010";
            while (true)
            {
                var app = new Excel.Application();
                app.DisplayAlerts = false;

                var dataFrame = new Excel.Application();
                dataFrame.DisplayAlerts = false;

                Excel.Workbook dataWorkbook;
                Excel.Workbook document;

                String pathDirectory = path;
                if (pathDirectory == "") break;



                List<String> parameters = new List<string>();
                parameters.Add("000 1 01 00000 00 0000 000");
                parameters.Add("000 1 13 00000 00 0000 000");
                parameters.Add("000 1 01 02000 01 0000 110");
                parameters.Add("000 1 06 02000 02 0000 110");

                parameters.Add("1 13 01000 00 0000 130");
                parameters.Add("1 01 00000 00 0000 000");
                parameters.Add("1 06 02000 02 0000 110");
                parameters.Add("1 01 02000 01 0000 110");

                parameters.Add("11301000000000130");
                parameters.Add("10100000000000000");
                parameters.Add("10602000020000110");
                parameters.Add("10102000010000110");

                parameters.Add(@" 000 1010000000 0000 000");
                parameters.Add(@" 000 1130100000 0000 130");
                parameters.Add(@" 000 1060200002 0000 110");
                parameters.Add(@" 000 1010200001 0000 110");



                try
                {


                    String pathWrite = pathDirectory + @"\" + year + "_res.xlsx";

                    String pathRead = pathDirectory + @"\" + year + ".xlsx";

                    if (!File.Exists(pathRead))
                    {
                        if (!File.Exists(pathDirectory + @"\" + year + ".xls"))
                        {
                            throw new FileNotFoundException("Файл не найден, попробуйте снова");
                        }
                        else
                        {
                            pathRead = pathDirectory + @"\" + year + ".xls";
                        }
                    }

                    if (File.Exists(pathWrite))
                    {
                        dataWorkbook = dataFrame.Workbooks.Open(pathWrite);
                    }
                    else
                    {
                        dataWorkbook = dataFrame.Workbooks.Add();
                        Excel.Worksheet sh = dataWorkbook.Worksheets.Add();
                        dataWorkbook.SaveAs(pathWrite);

                    }

                    document = app.Workbooks.Open(pathRead);
                    dataWorkbook = dataFrame.Workbooks.Open(pathWrite);

                    Excel.Worksheet sheet = app.ActiveSheet;
                    Excel.Worksheet dataSheet = dataFrame.ActiveSheet;

                    dataSheet.Cells[1, 1] = "Наименование показателя";
                    dataSheet.Cells[1, 2] = "Код дохода по бюджетной классификации, Классификация доходов";
                    dataSheet.Cells[1, 3] = "Величина дохода";

                    dataSheet.Columns[1].ColumnWidth = 40;
                    dataSheet.Columns[2].ColumnWidth = 40;
                    dataSheet.Columns[3].ColumnWidth = 40;

                    dataSheet.Rows.RowHeight = 20;
                    dataSheet.Rows[1].WrapText = true;
                    dataSheet.Rows[1].RowHeight = 50;
                    dataSheet.Cells.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    dataSheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    int row = 2;



                    for (int i = 4; ; i++)
                    {


                        if (sheet.Cells[i, 1].Value == null)
                            break;


                        if (parameters.Contains(sheet.Cells[i, 2].Value.ToString()))
                        {
                            dataSheet.Cells[row, 1] = sheet.Cells[i, 1];
                            dataSheet.Cells[row, 2] = sheet.Cells[i, 2];
                            dataSheet.Cells[row, 3] = sheet.Cells[i, 3];
                            row++;
                        }
                    }



                    dataFrame.ActiveWorkbook.Save();

                    document.Close();
                    dataWorkbook.Close();


                    year = (Int32.Parse(year) + 1).ToString();
                    if (Int32.Parse(year) <= 2020) continue;

                    break;
                }
                catch (FileNotFoundException e)
                {
                    break;
                }
                finally
                {
                    app.Quit();
                    dataFrame.Quit();
                }

            }
        }

        static int tryFind(Excel.Worksheet worksheet)
        {
            String var1 = "консолидированныйбюджетсубъектароссийскойфедерации";
            String var2 = "(6)утвержденныебюджетныеназначения,конс.бюджетсубъектарф";
            for (int i = 3; i < 6; i++)
            {
                if (worksheet.Cells[2, i].Value == null) continue;

                String fact = worksheet.Cells[2, i].Value.ToString().ToLower().Replace(" ", String.Empty);
                if (fact == var1 || fact == var2)
                {
                    return i;
                }
            }
            throw new FileNotFoundException("Не найдены подходящие параметры");
        }

        public static void analyzeInfo(string path)
        {
            var app = new Excel.Application();
            app.DisplayAlerts = false;

            var dataFrame = new Excel.Application();
            dataFrame.DisplayAlerts = false;

            Excel.Workbook entry;
            Excel.Workbook output;


            String pathReadDirectory = path;
            if (pathReadDirectory == "") throw new FileNotFoundException("Введите, пожалуйста, путь");

            String pathWriteDirectory = path;

            String pathWrite = pathWriteDirectory + @"\resultOfAnalysis.xlsx";

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
            outSheet.Range["B1", "L1"].Merge();
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
