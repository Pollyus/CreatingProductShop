namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Sale
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? SaleId { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual User User { get; set; }
        public bool Used { get; set; }
    }
}
