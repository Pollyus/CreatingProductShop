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
            return dataBase.Services.GetShoppingCart(customerId).Select(i => new CartModel { Amount = i.Amount, BuyerId = i.ByuerId, FullPrice = i.FullPrice, FullSale = i.FullSale, Id = i.Id, Photo = i.Photo, ProductId = i.ProductId, ProductName = i.ProductName }).ToList();
        }

        public bool MakeOrder(OrderModel orderModel, List<int> items)
        {
            List<Product> orderedProducts = new List<Product>();

            decimal sum = 0;
            foreach (var pId in items)
            {
                Product product = dataBase.Products.GetItem(pId);

                sum += product.Cost;

                orderedProducts.Add(product);
            }

            sum = new Discount(0.05m).MakeDiscount(sum);

            Order order = new Order
            {
                //Id = 4,
                //Date = DateTime.Now,    
                //Sum = sum,
                //Address = orderModel.Address,          
                //PhoneNumber = orderModel.PhoneNumber
                //order = dataBase.Orders.GetItem(orderModel.Id);
                Date = DateTime.Now,
                Address = orderModel.Address,
                Sum = sum,
                PhoneNumber = orderModel.PhoneNumber,

                //order.Products = orderedphones;
                //dataBase.Orders.Update(order),
            };
            dataBase.Orders.Create(order);

            foreach (var pId in items)
            {
                Product product = dataBase.Products.GetItem(pId);

                OrderLines order_Line = new OrderLines()
                {

                    ProductId = pId,
                    OrderId = order.Id,
                    Price = (decimal)product.Cost,
                    Quantity = 1,

                };
                dataBase.OrderLines.Create(order_Line);
            }

            if (dataBase.Save() > 0)
                return true;
            return false;

        }

    }
}