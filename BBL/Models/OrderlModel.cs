using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public string Address { get; set; }
        public DateTime? Date { get; set; }

        public decimal? Total { get; set; }
        //   public string OrderedProducts { get; set; }
        //   public List<int> OrderedProductsIds { get; set; }
        public string ViewDate { get; set; }

        public string ViewSum { get; set; }

        public int? Amount { get; set; }

        public int? Order_Status_Id { get; set; }

        

        public string OrderStatus { get; set; }

        public string PickPoint { get; set; }

        public ObservableCollection<OrderLineModel> OrderLines { get; set; }
        public OrderModel() { }
        public OrderModel(Order o)
        {
            Id = o.Id;
            Order_Status_Id = o.StatusId;
            Address = o.Address;
            Date = o.Date;
            Total = o.Sum;

        }
    }
}