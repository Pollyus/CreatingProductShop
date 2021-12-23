using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BBL.Models;

namespace BBL.Interfaces
{
    public interface IProfileService
    {
        List<SaleModel> GetSale(int customerId, decimal total);
        bool CheckLogin(string login);
        bool CheckPassword(string login, string password);
        int GetUserId(string login);
        List<OrderModel> GetBuyerOrders(int customerId, int statusId, DateTime dateStart, DateTime dateEnd);
        BuyerModel GetCutomerProfile(int customerId);
    }
}
