using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IServiceRepository
    {
        List<ProductCatalogData> GetProductsByCategory(string category);
        List<CartData> GetShoppingCart(int userId);

        List<SaleData> GetSale(int userId);
        bool CheckLogin(string login);
        bool CheckPassword(string login, string password);
        int GetUserId(string login);
    }
}
