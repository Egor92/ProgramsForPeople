using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaByCompanyCalculator
{
    public class ExportItem<T>
    {
        public ExportItem(string name, Func<T, string> getValue)
        {
            Name = name;
            GetValue = getValue;
        }

        public string Name { get; }

        public Func<T, string> GetValue { get; }
    }

    public abstract class DataExportConverter<T>
        where T : class
    {
        protected abstract IEnumerable<ExportItem<T>> GetExportItems();

        public string[][] Convert(IList<T> items)
        {
            var exportItems = GetExportItems()
                .ToList();

            string[][] converterResult = new string[items.Count + 1][];
            for (int i = 0; i < converterResult.Length; i++)
            {
                converterResult[i] = new string[exportItems.Count];
            }

            for (int i = 0; i < exportItems.Count; i++)
            {
                var exportItem = exportItems[i];
                converterResult[0][i] = exportItem.Name;

                for (var j = 0; j < items.Count; j++)
                {
                    var value = items[j];
                    converterResult[j + 1][i] = exportItem.GetValue(value);
                }
            }

            return converterResult;
        }
    }
}
