using System;
using System.Collections.Generic;
using CommandLine;

namespace LoanRepayment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }

        private static void Run(Options options)
        {
            var dataStorage = new DataStorage(options);
            var creditInfos = dataStorage.GetCreditInfos();
            var calculator = new LoanRepaymentCalculator(creditInfos);
            var repaymentResult = calculator.Calculate();
            dataStorage.SaveRepaymentResult(repaymentResult);
        }

        private static void HandleParseError(IEnumerable<Error> errors)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var error in errors)
            {
                Console.WriteLine(error.Tag);
            }
        }
    }
}