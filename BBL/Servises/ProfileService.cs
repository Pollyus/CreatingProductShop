using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Models;
using DAL.Interfaces;
using BBL.Models;
using BBL.Interfaces;
using DAL.Repository;
using System.Collections.ObjectModel;

namespace BBL.Servises
{
    public class ProfileService : IProfileService
    {
        IDbRepos dataBase;
        public ProfileService(IDbRepos dbRepository)
        {
            dataBase = dbRepository;
        }

        public List<SaleModel> GetSale(int UserId, decimal total)
        {
            return dataBase.Services.GetSale(UserId).Where(i => i.Used == false && i.Condition <= total).Select(i => new SaleModel { Background = i.Background, Condition = i.Condition, SaleId = i.Id, SaleName = i.SaleName, UserId = i.Buyer_Id, Id = i.Id, Offer = i.Offer, OrderId = i.Order_Id, Used = i.Used }).ToList();
        }
        public int GetUserId(string login)
        {
            return dataBase.Services.GetUserId(login);
        }
        public bool CheckLogin(string login)
        {
            return dataBase.Services.CheckLogin(login);
        }

        public bool CheckPassword(string login, string password)
        {
            return dataBase.Services.CheckPassword(login, password);
        }

        public List<OrderModel> GetBuyerOrders(int BuyerId, int statusId, DateTime dateStart, DateTime dateEnd)
        {
            var orders = dataBase.Orders.GetList();
            var orderLines = dataBase.OrderLines.GetList();

            List<OrderModel> orderModels = orders.Where(i => BuyerId == i.UserId && dateStart <= i.Date && dateEnd >= i.Date && ((statusId == -1 && (i.StatusId == 1 | i.StatusId == 2 || i.StatusId == 3)) | statusId == 0 | statusId == i.StatusId)).Select(i => new OrderModel { OrderLines = new ObservableCollection<OrderLineModel>(), Id = i.Id, Date = (DateTime)i.Date, Order_Status_Id = i.StatusId,  Total = i.Sum }).ToList();

            foreach (var i in orderModels)
            {
                foreach (var j in orderLines)
                {
                    if (j.OrderId == i.Id)
                    {
                        var prod = dataBase.Products.GetItem(j.ProductId);
                        i.OrderLines.Add(new OrderLineModel { ViewAmount = $"Количество: {j.Amount} шт.", ViewPrice = $"Стоимость: {j.Price:0.#} руб.", Price = j.Price, Amount = j.Amount, Photo = prod.Photo, Name = prod.Name });
                    }
                }
                i.OrderStatus = dataBase.OrderStatuses.GetItem((int)i.Order_Status_Id).Name;
                
            }

            return orderModels;
        }
        public BuyerModel GetBuyerProfile(int BuyerId)
        {
            var Buyer = dataBase.Buyers.GetItem(BuyerId);
            decimal? sum = 0;

            var orders = dataBase.Orders.GetList().Where(i => i.UserId == BuyerId);
            foreach (var i in orders)
            {
                sum += i.Sum;
            }


            return new BuyerModel
            {
                Name = Buyer.Name,
                Address = Buyer.Address,
                Sum = sum,
                Email = Buyer.Email
            };
        }
        public List<decimal> GetStats(int customerId, string year)
        {
            var orders = dataBase.Orders.GetList().Where(i => ((DateTime)i.Date).Year.ToString() == year && customerId == i.UserId).ToList();

            List<decimal> months = new List<decimal>();
            for (int i = 0; i < 12; i++)
            {
                decimal sum = 0;
                foreach (var j in orders)
                {
                    if (((DateTime)j.Date).Month.ToString() == (i + 1).ToString()) sum += (decimal)j.Sum;
                }
                months.Add(sum);
            }

            return months;
        }
    }
}
