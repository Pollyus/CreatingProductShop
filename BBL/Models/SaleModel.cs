using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Models
{
    public class SaleModel
    {
        public SaleModel() { }

        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? SaleId { get; set; }

        public int? OrderId { get; set; }

        public bool? Used { get; set; }

        public string SaleName { get; set; }

        public decimal? Offer { get; set; }

        public decimal? Condition { get; set; }

        public string Background { get; set; }

        public string ViewText { get; set; }
    }
}
