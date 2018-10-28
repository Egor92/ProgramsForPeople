using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace SummaByCompanyCalculator
{
    public class Calculator
    {
        #region WarningOccurred

        private readonly Subject<string> _warningOccurred = new Subject<string>();

        public IObservable<string> WarningOccurred
        {
            get { return _warningOccurred.AsObservable(); }
        }

        #endregion

        public void Start(string inputFile)
        {
            var inputLines = File.ReadAllLines(inputFile);
            var dataItemsByCompanyName = inputLines.Select(CreateDataItem)
                                                   .Where(x => x != null)
                                                   .GroupBy(x => x.CompanyName)
                                                   .ToDictionary(x => x.Key, x => x.ToArray())
                                                   .ToList();

            for (int year = 2017; year <= 2018; year++)
            {
                var dealInfos = GetDealInfosByYear(dataItemsByCompanyName, year);
                var exportConverter = new DealInfoExportConverter();
                var values = exportConverter.Convert(dealInfos.ToArray());
                var excelReporter = new ExcelReporter($"Report {year}.xlsx");
                excelReporter.Write(values);
            }
        }

        private DataItem CreateDataItem(string str, int index)
        {
            try
            {
                return DataItemFactory.Create(str);
            }
            catch (Exception e)
            {
                _warningOccurred.OnNext($"Error occurred while parsing line {index}\n{e}");
                return null;
            }
        }

        private IEnumerable<DealInfo> GetDealInfosByYear(IEnumerable<KeyValuePair<string, DataItem[]>> dataItemsByCompanyName, int year)
        {
            if (dataItemsByCompanyName == null)
                throw new ArgumentNullException(nameof(dataItemsByCompanyName));

            return GetDealInfosByYearInternal();

            IEnumerable<DealInfo> GetDealInfosByYearInternal()
            {
                foreach (var pair in dataItemsByCompanyName)
                {
                    var companyName = pair.Key;
                    var dataItems = pair.Value;

                    var currentYearDataItems = dataItems.Where(x => x.Date.Year == year)
                                                        .ToArray();
                    if (currentYearDataItems.Length == 0)
                        continue;

                    var dealInfo = new DealInfo
                    {
                        CompanyName = companyName,
                        DealCount = currentYearDataItems.Length,
                    };
                    foreach (var dataItem in currentYearDataItems)
                    {
                        if (dealInfo.SumByMonthIndex[dataItem.Date.Month - 1] == null)
                        {
                            dealInfo.SumByMonthIndex[dataItem.Date.Month - 1] = dataItem.Sum;
                        }
                        else
                        {
                            dealInfo.SumByMonthIndex[dataItem.Date.Month - 1] += dataItem.Sum;
                        }
                    }

                    yield return dealInfo;
                }
            }
        }
    }
}
