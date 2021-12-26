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
using System.Collections.ObjectModel;

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
        

        public int MakeOrder(int userId, int couponId,  decimal sum, ObservableCollection<CartModel> cart, string address)
        {
            try
            {
                
                DAL.Entities.Order order = new Order();
                order.UserId = userId;
                order.Date = DateTime.Now.Date;
                order.StatusId = 1; //Собирается
                order.Sum = sum;
                //order.Sale = sale;
                order.Address = address;
                dataBase.Orders.Create(order);

                if (dataBase.Save() <= 0)
                    return 0;

                var orders = dataBase.Orders.GetList();
                int key = orders[orders.Count - 1].Id;
                foreach (var i in cart)
                {
                    OrderLines line = new OrderLines();
                    line.ProductId = i.ProductId;
                    line.OrderId = key;
                    line.Amount = i.Amount;
                    line.Price = (decimal)i.FullPrice - (decimal)i.FullSale;
                    Product prod = dataBase.Products.GetItem(i.ProductId);
                    prod.Amount -= i.Amount;
                    if (prod.Amount == 0) prod.Avalibility = false;
                    dataBase.Products.Update(prod);
                    dataBase.OrderLines.Create(line);
                }

                if (couponId != 0)
                {
                    User_Sale coupon = dataBase.UserSales.GetItem(couponId);
                    coupon.Used = true;
                    coupon.OrderId = key;
                    dataBase.UserSales.Create(coupon);

                    if (dataBase.Save() <= 0)
                        return 0;
                }

                
                Buyer buyer = dataBase.Buyers.GetItem(userId);
                buyer.Sum += sum;
               
                

                if (dataBase.Save() <= 0)
                    return 0;

                var carts = dataBase.ShoppingCarts.GetList();
                for (int j = 0; j < carts.Count; j++)
                {
                    if (carts[j].BuyerId == userId)
                    {
                        dataBase.ShoppingCarts.Delete(carts[j].Id);
                    }
                }

                GiveAwayCoupons(sum , userId);

                return 1;
            }
            finally
            {

            }

        }
        private void GiveAwayCoupons(decimal sum, int userId)
        {
            List<Sale> sales = dataBase.Sales.GetList();

            decimal? max = -1;
            int point = 0;
            for (int i = 0; i < sales.Count; i++)
            {
                if (sum > sales[i].GiveAwayCondition && sales[i].GiveAwayCondition != -1 && sales[i].GiveAwayCondition > max)
                {
                    max = sales[i].GiveAwayCondition;
                    point = i;
                }
            }
            if (point != 0)
            {
                User_Sale user_Sale = new User_Sale();
                user_Sale.UserId = sales[point].Id;
                user_Sale.UserId = userId;
                user_Sale.Used = false;
                dataBase.UserSales.Create(user_Sale);
                dataBase.Save();
            }
        }
    }
}