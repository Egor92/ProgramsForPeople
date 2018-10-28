using System.Linq;

namespace SummaByCompanyCalculator
{
    public class DealInfo
    {
        public string CompanyName { get; set; }

        public decimal?[] SumByMonthIndex { get; set; } = new decimal?[12];

        public int DealCount { get; set; }

        public decimal GetSum()
        {
            return SumByMonthIndex.Sum(x => x.GetValueOrDefault());
        }
    }
}
