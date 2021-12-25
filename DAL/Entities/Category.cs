namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string CategoryName { get; set; }

        public int? TypeId { get; set; }

        public virtual CategoryType CategoryType { get; set; }
    }
}
