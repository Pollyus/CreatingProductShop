namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            User_Sale = new HashSet<User_Sale>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? Offer { get; set; }

        public decimal? GiveAwayCondition { get; set; }

        public decimal? Condition { get; set; }

        [StringLength(1000)]
        public string Background { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Sale> User_Sale { get; set; }
    }
}
