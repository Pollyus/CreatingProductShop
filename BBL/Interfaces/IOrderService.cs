using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;
using BBL.Models;

namespace BAL.Interfaces
{
    public interface IOrderService
    {
        

        List<CartModel> GetShoppingCart(int customerId);
    }
}
