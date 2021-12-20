using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportsRepository
    {
        private ProductContext db;
        public class SPResult
        {
            public string Наименование { get; set; }
            public decimal Стоимость { get; set; }

        }
        public ReportRepositorySQL(ProductContext dbcontext)

        {
            this.db = dbcontext;
        }

        public List<ReportData_2> ExecuteSP(string name)
        {

            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name1", name);

            //ProductContext db = new ProductContext();
            //var result = db.Database.SqlQuery<SPResult>("dbo.FindByName @name1", new object[] { param }).ToList();

            //var data = result
            //    .OrderBy(prod => prod.Стоимость)
            //    .Select(prod => new ReportData_2
            //    {
            //        Наименование = prod.Наименование,
            //        Стоимость = prod.Стоимость,


            //    }).ToList();

            //return data;
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@name", name);

            ProductContext db = new ProductContext();
            var result = db.Database.SqlQuery<ReportData_2>("dbo.FindByName @name", new object[] { param1 }).ToList();

            return result;
        }

        public List<ReportData> ReportByCategory(int Category_Id)
        {
            ProductContext dataBase = new ProductContext();
            var request = dataBase.Product
                .Join(dataBase.Category, prod => prod.CategoryId, categ => categ.Id, (prod, categ) => new { Categ_Name = categ.CategoryName, prod.CategoryId, prod.Cost, prod.Name })
                .Where(prod => prod.CategoryId == Category_Id)
                .Select(prod => new ReportData { Товар = prod.Name, Стоимость = prod.Cost })
                .ToList();
            return request;
        }

        public List<ReportData_2> ReportByName(string name)
        {
            ProductContext dataBase = new ProductContext();
            var request = dataBase.Product
                //.Join(dataBase.Category, prod => prod.CategoryId, categ => categ.Id, (prod, categ) => new { Categ_Name = categ.CategoryName, prod.CategoryId, prod.Cost, prod.Name })
                //.Where(prod => prod.CategoryId == Category_Id)
                .Select(prod => new ReportData_2 { Наименование = prod.Name, Стоимость = prod.Cost })
                .ToList();
            //    .Where(prod => prod.Name == '%'+@name+'%')
            //    .Select(prod => new ReportData_2 { Наименование = prod.Name, Стоимость = prod.Cost })
            //    .ToList();
            return request;
        }

        public List<OrderReport> GetOrders()
        {
            ProductContext dataBase = new ProductContext();
            return dataBase.Order
                                 .Select(i => new OrderReport
                                 {
                                     Код = i.Id,
                                     Дата = i.Date,
                                     Сумма = i.Sum,
                                     Телефон = i.PhoneNumber,
                                     Адрес = i.Address
                                 }).ToList();
        }

    }
}
