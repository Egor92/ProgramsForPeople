using CommandLine;

namespace LoanRepayment
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input data file")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output result file")]
        public string OutputFile { get; set; }
    }
}