using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BAL.Models;
using BAL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using BBL.Models;

namespace BAL.Servises
{
    public class OrderService : IOrderService
    {
        private IDbRepos dataBase;
        public OrderService(IDbRepos repos)
        {
            dataBase = repos;
        }
        public List<CartModel> GetShoppingCart(int customerId)
        {
            return dataBase.Services.GetShoppingCart(customerId).Select(i => new CartModel { Amount = i.Amount, BuyerId = i.BuyerId, FullPrice = i.FullPrice, FullSale = i.FullSale, Id = i.Id, Photo = i.Photo, ProductId = i.ProductId, ProductName = i.ProductName }).ToList();
        }

        
    }
}