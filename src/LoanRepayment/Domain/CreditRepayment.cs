using System.Collections.Generic;

namespace LoanRepayment.Domain
{
    public class CreditRepayment
    {
        public string Name { get; set; } = string.Empty;

        public Dictionary<Date, float> Balance { get; set; } = new();
    }
}