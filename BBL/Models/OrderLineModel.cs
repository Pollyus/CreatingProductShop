using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BAL.Models
{
    public class OrderLineModel
    {
        public OrderLineModel() { }

        public OrderLineModel(OrderLines o_line)
        {
            Product_Id = o_line.Id;
            Order_Id = o_line.Id;
            Price = o_line.Price;
            Amount = o_line.Amount;
        }

        public int Id { get; set; }

        public int Product_Id { get; set; }

        public int Order_Id { get; set; }

        public decimal? Price { get; set; }

        public decimal? Amount { get; set; }
    }
}
