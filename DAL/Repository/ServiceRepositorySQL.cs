using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class ServiceRepositorySQL : IServiceRepository
    {
        private ProductContext dataBase;
        public ServiceRepositorySQL(ProductContext dbcontext)
        {
            dataBase = dbcontext;
        }

        public List<CartData> GetShoppingCart(int UserId)
        {
            ProductContext db = new ProductContext();

            var result = db.ShoppingCarts
                           .Where(i => i.BuyerId == UserId)
                           .Join(db.Product, car => car.ProductId, pr => pr.Id, (car, pr) => new CartData { Id = car.Id, ProductId = car.ProductId, ByuerId = car.BuyerId, Amount = car.Amount, FullPrice = car.Amount * pr.Cost, ProductName = pr.Name, Photo = pr.Photo })
                           .Join(db.BatchOfProduct, car => car.ProductId, batch => batch.ProductCode, (car,batch)=> new CartData { FullSale =  car.Amount * batch.Sale})
                           .ToList();
            return result;
        }

        public List<SaleData> GetSale(int UserId)
        {
            ProductContext db = new ProductContext();

            var result = db.User_Sales.Where(i => i.UserId == UserId)
                           .Join(db.Sales, us => us.Id, sale => sale.Id, (us, sale) => new SaleData
                           {
                               Id = us.Id,
                               SaleName = sale.Name,
                               Background = sale.Background,
                               Condition = sale.Condition,
                               Sale_Id = sale.Id,
                               User_Id = us.UserId,
                               Offer = sale.Offer,
                               Order_Id = us.OrderId,
                               Used = us.Used
                           }).ToList();

            return result;
        }

        public List<ProductCatalogData> GetProductsByCategory(string category)
        {
            ProductContext db = new ProductContext();

            //if (db.Product_Types.Where(i => i.Name == category).Count() != 0)
            //{
            //    var result = db.Product
            //                   .Join(db.Category, pr => pr.CategoryId, cat => cat.Id, (pr, cat) => new { Id = pr.Id, CategName = cat.Name, TypeId = cat.Product_Type_Id, pr.Name, pr.Price, pr.Sale, pr.Photo, pr.Category_Id })
            //                   .Join(db.Product_Types, pr => pr.TypeId, prt => prt.Id, (pr, prt) => new { TypeName = prt.Name, Id = pr.Id, Name = pr.Name, Photo = pr.Photo, Price = pr.Price, Sale = pr.Sale })
            //                   .Where(i => i.TypeName == category)
            //                   .Select(i => new ProductCatalogData { Id = i.Id, Name = i.Name, Photo = i.Photo, Price = i.Price, Sale = i.Sale })
            //                   .ToList();
            //    return result;
            //}
            //else
            //{
                var result = db.Product
                               .Join(db.Category, pr => pr.CategoryId, cat => cat.Id, (pr, cat) => new { Id = pr.Id, CategName = cat.CategoryName, pr.Name, pr.Cost, pr.Photo }) //pr.sale
                               .Where(i => i.CategName == category)
                               .Select(i => new ProductCatalogData { Id = i.Id, Name = i.Name, Photo = i.Photo, Cost = i.Cost })
                               .ToList();
                return result;
           //}

        }

        public bool CheckLogin(string login)
        {
            ProductContext db = new ProductContext();

            if (db.Users.Where(i => login == i.Login).Count() == 0) return false;
            else return true;
        }

        public bool CheckPassword(string login, string password)
        {
            ProductContext db = new ProductContext();

            if (db.Users.Where(i => login == i.Login && password == i.Password).Count() == 0) return false;
            else return true;
        }

        public int GetUserId(string login)
        {
            return dataBase.Users.Where(i => i.Login == login).ToList()[0].Id;
        }
    }
}
