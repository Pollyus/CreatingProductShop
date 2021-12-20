using System;
using DAL.Entities;

namespace BBL.Models
{
    public class BuyerModel
    {
        public BuyerModel() { }

        public BuyerModel (Buyer buyer)
        {
            Id = buyer.Id;
            UserId = buyer.UserId;
            BirthDay = buyer.BirthDay;
            Address = buyer.Address;
            Sum = buyer.Sum;
            Email = buyer.Email;

        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public decimal? Sum { get; set; }
        public string Email { get; set; }
    }
}
