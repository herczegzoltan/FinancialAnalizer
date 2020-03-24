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

            using (var reader = new StreamReader(@"C:\Users\Herczeg Zoltán\Google Drive\input.csv"))
            {
                //List<string> listA = new List<string>();
                //List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Console.WriteLine(values[0]);
                    //listA.Add(values[0]);
                    //listB.Add(values[1]);
                }
            }
        }
    }
}
