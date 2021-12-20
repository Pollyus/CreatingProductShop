using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Models;

namespace BBL.Interfaces
{
    public interface IProfileService
    {
        List<SaleModel> GetSale(int customerId, decimal total);
        bool CheckLogin(string login);
        bool CheckPassword(string login, string password);
        int GetUserId(string login);
    }
}
