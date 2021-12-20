using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BAL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Date { get; set; }

        public decimal? Total { get; set; }
        //   public string OrderedProducts { get; set; }
        //   public List<int> OrderedProductsIds { get; set; }

        public OrderModel() { }
        public OrderModel(Order o)
        {
            Id = o.Id;
            PhoneNumber = o.PhoneNumber;
            Address = o.Address;
            Date = o.Date;
            Total = o.Sum;

        }
    }
}