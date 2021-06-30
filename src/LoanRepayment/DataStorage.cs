using System;
using System.IO;
using LoanRepayment.Domain;
using Newtonsoft.Json;

namespace LoanRepayment
{
    public class DataStorage
    {
        private readonly Options _options;

        public DataStorage(Options options)
        {
            _options = options;
        }

        public CreditInfos GetCreditInfos()
        {
            var inputText = File.ReadAllText(_options.InputFile);
            var creditInfos = JsonConvert.DeserializeObject<CreditInfos>(inputText);
            if (creditInfos == null)
            {
                throw new InvalidOperationException();
            }

            return creditInfos;
        }

        public void SaveRepaymentResult(RepaymentResult repaymentResult)
        {
            var text = JsonConvert.SerializeObject(repaymentResult, Formatting.Indented);
            File.WriteAllText(_options.OutputFile, text);
        }
    }
}