using FinancialAnalizer.Extension;
using FinancialAnalizer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAnalizer
{
    class Program
    {
        static void Main(string[] args)
        {

            //string str = "04/06/2018";
            //int ystr = DateTime.Parse(str).Year;

            //int mstr = DateTime.Parse(str).Day;


            List<Record> Records = new List<Record>(); 
            using (var reader = new StreamReader(@"C:\Users\Herczeg Zoltán\Google Drive\input.csv"))
            {

                //values[0] -> date "04/06/2018";
                //values[1] -> account
                //values[2] -> category
                //values[3] -> amount
                //values[4] -> currency
                //values[5] -> converted
                //values[6] -> currencys
                //values[7] -> description

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Records.Add(new Record()
                    {
                        Year = DateTime.Parse(values[0]).Year,
                        Month = DateTime.Parse(values[0]).Day,
                        Category = values[2],
                        Amount = values[3].StringToDoubleWithReplace(),



                    });
                    //Console.WriteLine(values[0]);
                    //listA.Add(values[0]);
                    //listB.Add(values[1]);
                }
            }

            foreach (var item in Records)
            {
                Console.WriteLine();
            }
        }
    }
}
