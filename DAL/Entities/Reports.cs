using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductCatalogData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Cost { get; set; }
        public decimal Sale { get; set; }
    }

    public class CartData
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        //public int Amount { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal? FullSale { get; set; }
    }

    public class SaleData
    {
        public int Id { get; set; }

        public int? Buyer_Id { get; set; }

        public int? Sale_Id { get; set; }

        public int? Order_Id { get; set; }

        public bool Used { get; set; }

        public string SaleName { get; set; }

        public decimal? Offer { get; set; }

        public decimal? Condition { get; set; }

        public string Background { get; set; }
    }

    public class CategoryData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Product_Type_Id { get; set; }
    }

    public class ReportData_2
    {
        public string Наименование { get; set; }
        public decimal Стоимость { get; set; }
        public string Категория { get; set; }
    }

    public class ReportData
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

