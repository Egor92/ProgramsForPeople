using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace SummaByCompanyCalculator
{
    public class ExcelReporter
    {
        private readonly string _fileName;

        public ExcelReporter(string fileName)
        {
            _fileName = fileName;
        }

        public void Write(IEnumerable<object[]> values)
        {
            using (var p = new ExcelPackage())
            {
                var worksheet = p.Workbook.Worksheets.Add("MySheet");
                var cell = worksheet.Cells["A1"];
                cell.LoadFromArrays(values);
                p.SaveAs(new FileInfo(_fileName));
            }
        }
    }
}
