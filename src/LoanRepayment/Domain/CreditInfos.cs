namespace LoanRepayment.Domain
{
    public class CreditInfos
    {
        public float MonthlyPayment { get; set; }

        public Date ActualDate { get; set; }

        public CreditInfo[] Credits { get; set; }
    }
}