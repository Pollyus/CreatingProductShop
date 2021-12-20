using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DAL.Entities;

namespace BBL.Models
{
    public class ButchOfProductModel
    {
        public int Id { get; set; }
        public DateTime DateProduction { get; set; }
        public DateTime DateExpiration { get; set; }
        public int? Quantity { get; set; }
        public int ProductCode { get; set; }
        public decimal? Sale { get; set; }

        public ButchOfProductModel (BatchOfProduct batch)
        {
            Id = batch.Id;
            DateExpiration = batch.DateExpiration;
            DateProduction = batch.DateProduction;
            Quantity = batch.Quantity;
            Sale = batch.Sale;
        }
    }
}
