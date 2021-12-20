using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BBL.Models
{
    public class CartModel
    {
        public CartModel() { }
        public CartModel(ShoppingCart shoppingCart)
        {
            Id = shoppingCart.Id;
            Amount = shoppingCart.Amount;
            BuyerId = shoppingCart.BuyerId;
            ProductId = shoppingCart.ProductId;
        }

        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public decimal? Amount { get; set; }
        public string ProductName { get; set; }
        public string ViewPrice { get; set; }
        public string ViewSale { get; set; }
        public string ViewTotal { get; set; }
        public string Photo { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal? FullSale { get; set; }
        public bool MinusEnabled { get; set; }
        public bool PlusEnabled { get; set; }
    }
}
