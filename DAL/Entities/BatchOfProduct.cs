namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BatchOfProduct")]
    public partial class BatchOfProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BatchOfProduct()
        {
            Busket = new HashSet<Busket>();
            OrderLines = new HashSet<OrderLines>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateProduction { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateExpiration { get; set; }

        public int? Quantity { get; set; }

        public int ProductCode { get; set; }

        public decimal? Sale { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Busket> Busket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
