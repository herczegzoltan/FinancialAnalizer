using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAnalizer.Extension
{
    public static class StringToDouble
    {
        public static double StringToDoubleWithReplace(this String str)
        {
            str = str.Replace(",", "");
            str = str.Replace("\"", "");
            return double.Parse(str, CultureInfo.InvariantCulture);
        }
    }
}
