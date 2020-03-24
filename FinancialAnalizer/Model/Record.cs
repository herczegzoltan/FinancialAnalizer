using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAnalizer.Model
{
    public class Record
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }
    }
}
