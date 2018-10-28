using System.Collections.Generic;

namespace SummaByCompanyCalculator
{
    public class DealInfoExportConverter : DataExportConverter<DealInfo>
    {
        #region Overrides of DataExportConverter<DealInfo>

        protected override IEnumerable<ExportItem<DealInfo>> GetExportItems()
        {
            yield return new ExportItem<DealInfo>("Наименование контрагента", x => x.CompanyName);
            yield return new ExportItem<DealInfo>("Январь", x => Format(x.SumByMonthIndex[0]));
            yield return new ExportItem<DealInfo>("Февраль", x => Format(x.SumByMonthIndex[1]));
            yield return new ExportItem<DealInfo>("Март", x => Format(x.SumByMonthIndex[2]));
            yield return new ExportItem<DealInfo>("Апрель", x => Format(x.SumByMonthIndex[3]));
            yield return new ExportItem<DealInfo>("Май", x => Format(x.SumByMonthIndex[4]));
            yield return new ExportItem<DealInfo>("Июнь", x => Format(x.SumByMonthIndex[5]));
            yield return new ExportItem<DealInfo>("Июль", x => Format(x.SumByMonthIndex[6]));
            yield return new ExportItem<DealInfo>("Август", x => Format(x.SumByMonthIndex[7]));
            yield return new ExportItem<DealInfo>("Сентябрь", x => Format(x.SumByMonthIndex[8]));
            yield return new ExportItem<DealInfo>("Октябрь", x => Format(x.SumByMonthIndex[9]));
            yield return new ExportItem<DealInfo>("Ноябрь", x => Format(x.SumByMonthIndex[10]));
            yield return new ExportItem<DealInfo>("Декабрь", x => Format(x.SumByMonthIndex[11]));
            yield return new ExportItem<DealInfo>("Кол-во заказов", x => Format(x.DealCount));
            yield return new ExportItem<DealInfo>("Итоговая сумма", x => Format(x.GetSum()));
        }

        #endregion

        private static string Format(decimal? value)
        {
            return value?.ToString("F2");
        }

        private static string Format(int value)
        {
            return value.ToString();
        }
    }
}
