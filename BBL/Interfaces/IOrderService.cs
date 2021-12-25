using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BBL.Models;

namespace BAL.Interfaces
{
    public interface IOrderService
    {
       
        int MakeOrder(int userId, int couponId, decimal sum, ObservableCollection<CartModel> cart);

        List<CartModel> GetShoppingCart(int customerId);
    }
}
