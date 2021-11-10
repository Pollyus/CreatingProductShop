namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("Product")]
    public partial class Product //: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Procurement = new HashSet<Procurement>();
        }

  

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public decimal? retail_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? production_date { get; set; }

        public int? expiration_date { get; set; }

        public int? category_code { get; set; }

        public int? storeroom_code { get; set; }

        [StringLength(20)]
        public string brand { get; set; }

        public int? sale { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procurement> Procurement { get; set; }

        public virtual Storeroom Storeroom { get; set; }

        public Product (string name, decimal price)
        {
            this.name = name;
            this.retail_price = price;

        }
        public override string ToString()
        {
            return "Название: " + name  + "Цена: " + retail_price;
        }
    }
}
