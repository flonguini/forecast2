using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace SinapiScrapper
{
    class Program
    {
        private static List<Supply> _supplies = new List<Supply>();

        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"D:\excel");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Parallel.ForEach(files, file =>
            {
                if (file.Contains("Insumos"))
                {
                    ReadSupply(file);
                }
                else if (file.Contains("Analitico"))
                {
                    //using (var child = pbar.Spawn(100, "Analitico", childOptions))
                    //{
                    //    ReadAnalityc(pbar, child, file);
                    //}
                }
                else if (file.Contains("Sintetico"))
                {
                    ReadSintetic(file);
                }
                });

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadLine();
        }

        private static void ReadSintetic(string file)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 8; i < rowCount; i++)
            {
                string code = xlRange.Cells[i, 1].Value2.ToString();
                string description = xlRange.Cells[i, 2].Value2.ToString();
                string unit = xlRange.Cells[i, 3].Value2.ToString().Trim();
                string price = xlRange.Cells[i, 4].Value2.ToString();

                //Console.WriteLine(description);
            }

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void ReadAnalityc(IProgressBar overall, IProgressBar child, string file)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 8; i < rowCount; i++)
            {
                string code = xlRange.Cells[i, 1].Value2.ToString();
                string description = xlRange.Cells[i, 2].Value2.ToString();
                string unit = xlRange.Cells[i, 3].Value2.ToString().Trim();
                string price = xlRange.Cells[i, 4].Value2.ToString();
                child.Tick();

                //Console.WriteLine(description);
            }

            overall.Tick();


            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void ReadSupply(string file)
        {
            var isRelieve = (file.Contains("NaoDesonerado")) ? false : true ;
            var state = GetState(file);

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            string monthYear = xlRange.Cells[3, 1].Value2.ToString();
            int.TryParse(monthYear.Substring(15, 2), out int month);
            int.TryParse(monthYear.Substring(18), out int year);

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 8; i < rowCount - 1; i++)
            {
                _supplies.Add(new Supply
                {
                    Code = Convert.ToInt32(xlRange.Cells[i, 1].Value2.ToString()),
                    Description = xlRange.Cells[i, 2].Value2.ToString(),
                    Unit = xlRange.Cells[i, 3].Value2.ToString().Trim()
                });

                decimal price = GetPrice(xlRange.Cells[i, 5].Value2.ToString());
                xlRange.Cells[i, 6].Value2 = price;

                Console.WriteLine($"price: {price} \n \n");
            }

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            xlRange = null;
            xlWorksheet = null;
            xlWorkbook = null;
            xlApp = null;
            
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static decimal GetPrice(string price)
        {
            string convertedPrice = price.Replace(".", string.Empty).Replace(",", ".");

            decimal.TryParse(convertedPrice, out decimal finalPrice);

            return finalPrice;
        }

        private static State GetState(string file)
        {
            if (file.Contains("AC"))
                return State.AC;
            else if (file.Contains("AL"))
                return State.AL;
            else if (file.Contains("AP"))
                return State.AP;
            else if (file.Contains("AM"))
                return State.AM;
            else if (file.Contains("BA"))
                return State.BA;
            else if (file.Contains("CE"))
                return State.CE;
            else if (file.Contains("DF"))
                return State.DF;
            else if (file.Contains("ES"))
                return State.ES;
            else if (file.Contains("GO"))
                return State.GO;
            else if (file.Contains("MA"))
                return State.MA;
            else if (file.Contains("MT"))
                return State.MT;
            else if (file.Contains("MS"))
                return State.MS;
            else if (file.Contains("MG"))
                return State.MG;
            else if (file.Contains("PA"))
                return State.PA;
            else if (file.Contains("PB"))
                return State.PB;
            else if (file.Contains("PR"))
                return State.PR;
            else if (file.Contains("PE"))
                return State.PE;
            else if (file.Contains("PI"))
                return State.PI;
            else if (file.Contains("RJ"))
                return State.RJ;
            else if (file.Contains("RN"))
                return State.RN;
            else if (file.Contains("RS"))
                return State.RS;
            else if (file.Contains("RO"))
                return State.RO;
            else if (file.Contains("RR"))
                return State.RR;
            else if (file.Contains("SC"))
                return State.SC;
            else if (file.Contains("SP"))
                return State.SP;
            else if (file.Contains("SE"))
                return State.SE;
            else
                return State.TO;
        }
    }
}
