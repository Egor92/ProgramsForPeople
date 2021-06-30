using System;
using LoanRepayment.Domain;

namespace LoanRepayment
{
    public class LoanRepaymentCalculator
    {
        private readonly CreditInfos _creditInfos;

        public LoanRepaymentCalculator(CreditInfos creditInfos)
        {
            _creditInfos = creditInfos ?? throw new ArgumentNullException(nameof(creditInfos));
        }

        public RepaymentResult Calculate()
        {
            return new RepaymentResult();
        }
    }
}