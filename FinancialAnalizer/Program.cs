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

            List<Record> Records = new List<Record>(); 
            using (var reader = new StreamReader(@"C:\Users\Herczeg Zoltán\Desktop\testfile.csv"))
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

                    if (values[0] != "date")
                    {
                        if (values[2] == "Salary")
                        {
                            if (values[4]=="EUR")
                            {
                                Records.Add(new Record()
                                {
                                    Year = Int16.Parse(values[0].Substring(6, 4)),
                                    Month = Int16.Parse(values[0].Substring(3, 2)),
                                    Category = values[2],
                                    Amount = values[3].StringToDoubleWithReplace(),
                                    Description = values[7]
                                });
                            }
                            else
                            {
                                Records.Add(new Record()
                                {
                                    Year = Int16.Parse(values[0].Substring(6, 4)),
                                    Month = Int16.Parse(values[0].Substring(3, 2)),
                                    Category = values[2],
                                    Amount = (values[3] + values[4]).StringToDoubleWithReplace(),
                                    Description = values[9]
                                });
                            }
                        }
                        else
                        {
                            Records.Add(new Record()
                            {
                                Year = Int16.Parse(values[0].Substring(6, 4)),
                                Month = Int16.Parse(values[0].Substring(3, 2)),
                                Category = values[2],
                                Amount = values[3].StringToDoubleWithReplace(),
                                Description = values[7]
                            });
                        }
                    }
                }
            }

            foreach (var item in Records)
            {
                Console.Write("Year:" + item.Year + "\t ");
                Console.Write("Month:" + item.Month + "\t ");
                Console.Write("Category:" + item.Category + "\t ");
                Console.Write("Amount:" + item.Amount + "\t ");
                Console.Write("Description:" + item.Description);
                Console.WriteLine("\n---------------------------------------------------------");
            }

            var bar = Records.Select(z => new Record { Year = z.Year, Month = z.Month, Category = z.Category, Amount = z.Amount, Description = z.Description })

             .GroupBy(y => new { y.Year, y.Month, y.Category})

             .Select(x => new Record
             {
                 Year = x.Key.Year
                ,
                 Month = x.Key.Month
                ,
                 Category = x.Key.Category,

                 
                 Amount = x.Sum(a => a.Amount)
             });

            foreach (var i in bar)
            {
                Console.Write(i.Year + ", " + i.Month + ", " + i.Category + ", " + i.Amount.ToString());
                Console.WriteLine("\n--------------------------");
            }
        }

    }
}
