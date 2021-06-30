using System.Collections.Generic;
using Newtonsoft.Json;

namespace LoanRepayment.Domain
{
    public class CreditInfo
    {
        public string Name { get; set; } = string.Empty;
        
        public float MonthlyPayment { get; set; }

        [JsonProperty(nameof(LastPaymentDate))]
        public string LastPaymentDateText { get; set; }

        [JsonIgnore]
        public string LastPaymentDate { get; set; }

        [JsonProperty(nameof(CreditPaymentByDate))]
        public Dictionary<string, float> CreditPaymentByDateProperty { get; set; } = new();

        [JsonIgnore]
        public Dictionary<Date, float> CreditPaymentByDate { get; set; } = new();
    }
}