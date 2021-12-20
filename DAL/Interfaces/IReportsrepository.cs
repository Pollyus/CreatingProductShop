
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IReportsRepository
    {
        List<ReportData_2> ExecuteSP(string name);
        List<ReportData> ReportByCategory(int Category_Id);
        List<ReportData_2> ReportByName(string name);
        List<OrderReport> GetOrders();

    }
}
