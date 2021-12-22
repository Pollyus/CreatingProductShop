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
    }
}
