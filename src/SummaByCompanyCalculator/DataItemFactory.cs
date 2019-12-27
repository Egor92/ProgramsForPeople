using System;
using System.Globalization;

namespace SummaByCompanyCalculator
{
    public static class DataItemFactory
    {
        private static readonly CultureInfo CultureInfo;

        static DataItemFactory()
        {
            var cultureInfo = (CultureInfo) CultureInfo.InvariantCulture.Clone();
            cultureInfo.NumberFormat.NumberGroupSeparator = " ";
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo = cultureInfo;
        }

        public static DataItem Create(string str)
        {
            var infos = str.Split('\t');
            return new DataItem
            {
                Date = DateTime.Parse(infos[0]),
                Sum = Convert.ToDecimal(infos[1], CultureInfo),
                CompanyName = infos[2]
                    .Trim(),
            };
        }
    }
}
