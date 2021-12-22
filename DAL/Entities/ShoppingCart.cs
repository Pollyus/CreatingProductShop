namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BuyerId { get; set; }

        public decimal Amount { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Product Product { get; set; }
    }
}
