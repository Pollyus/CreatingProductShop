using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models.ReportModels
{

    public class ReportData2
    {
        public string Наименование { get; set; }
        public decimal Стоимость { get; set; }
        public string Категория { get; set; }
    }

    public class ReportData1
    {
        public string Товар { get; set; }
        public decimal? Стоимость { get; set; }

    }

    public class OrderReport
    {
        public int Код { get; set; }
        public DateTime? Дата { get; set; }
        public string Адрес { get; set; }
        public string Телефон { get; set; }
        public decimal? Сумма { get; set; }

        public string Товар { get; set; }
    }

}
