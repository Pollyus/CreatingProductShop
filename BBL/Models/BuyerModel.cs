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
            
            BirthDay = buyer.BirthDay;
            Address = buyer.Address;
            Sum = buyer.Sum;
            Email = buyer.Email;
            Name = buyer.Name;
            Login = buyer.Login;
            Password = buyer.Password;
           // TipeID = buyer.TipeId;
        }

        public int Id { get; set; }
       
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public decimal? Sum { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int TipeID { get; set; }
    }
}
