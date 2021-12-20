using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models.ReportModels;
using BAL.Models;

namespace BAL.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// выполнить ХП - отчет по заказам за месяц
        /// </summary>
        List<ReportData2> ExecuteSP(string name);

        List<ReportData1> ReportByCategory(int Category_Id);
        /// <summary>
        /// Количество заказов
        /// </summary>
        //List<ReportData2> ReportByName(string name);
        List<OrderReport> GetOrders();
    }
}
