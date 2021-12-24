namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderLines = new HashSet<OrderLines>();
            Busket = new HashSet<Busket>();
            ShoppingCart = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? Cost { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool Avalibility { get; set; }

        public int? BrandId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateProduction { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateExpiration { get; set; }

        public int? Amount { get; set; }

        public decimal? Sale { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Busket> Busket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
