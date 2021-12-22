using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BAL.Interfaces;
using BAL.Models.ReportModels;
using DAL.Interfaces;

namespace BAL.Servises
{
    public class ReportService : IReportService
    {

        private IDbRepos db;
        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        //выполнить Хранимые процедуры

        //public List<ReportData2> ExecuteSP(string name)
        //{

        //    return db.Reports.ExecuteSP(name).Select(i => new ReportData2 { Категория = i.Категория, Наименование = i.Наименование, Стоимость = i.Стоимость }).ToList();
        //}

        //public List<ReportData1> ReportByCategory(int Category_Id)
        //{
        //    var request = db.Reports.ReportByCategory(Category_Id)

        //         .Select(prod => new ReportData1 { Товар = prod.Товар, Стоимость = prod.Стоимость })
        //         .ToList();
        //    return request;
        //}

        //public List<ReportData1> ReportByName(string name)
        //{
        //    var request = db.Reports.ReportByName(name)

        //         .Select(prod => new ReportData1 { Товар = prod.Наименование, Стоимость = prod.Стоимость })
        //         .ToList();
        //    return request;
        //}

        //public List<BAL.Models.ReportModels.OrderReport> GetOrders()
        //{
        //    return db.Reports.GetOrders().Select(i => new BAL.Models.ReportModels.OrderReport { Код = i.Код, Адрес = i.Адрес, Дата = i.Дата, Сумма = i.Сумма, Телефон = i.Телефон, Товар = i.Товар }).ToList();
        //}

    }
}

