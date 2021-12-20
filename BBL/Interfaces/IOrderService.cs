using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Models;

namespace BAL.Interfaces
{
    public interface IOrderService
    {
        //Создает или изменяет существующий заказ
      // bool MakeOrder(OrderModel orderModel);
        bool MakeOrder(OrderModel orderModel, List<int> items);
    }
}
