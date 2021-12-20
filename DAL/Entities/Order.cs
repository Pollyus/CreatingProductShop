namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderLines = new HashSet<OrderLines>();
            User_Sale = new HashSet<User_Sale>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public decimal? Sum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? UserId { get; set; }

        public int? TypeId { get; set; }

        public int? StatusId { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Pick_Point Pick_Point { get; set; }

        public virtual TypeOfPayment TypeOfPayment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Sale> User_Sale { get; set; }
    }
}
