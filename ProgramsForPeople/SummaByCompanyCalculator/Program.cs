using System;

namespace SummaByCompanyCalculator
{
    public class Program
    {
        public static void Main()
        {
            var calculator = new Calculator();
            var warningOccurredSubscription = calculator.WarningOccurred.Subscribe(WriteToConsole);
            try
            {
                calculator.Start("InputData.txt");
            }
            catch (Exception e)
            {
                WriteToConsole(e);
            }
            finally
            {
                warningOccurredSubscription.Dispose();
            }

            Console.WriteLine("Application has finished the execution. Press ENTER to exit");
            Console.ReadLine();
        }

        private static void WriteToConsole(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
