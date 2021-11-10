namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Procurement")]
    public partial class Procurement
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime date { get; set; }

        [Key]
        [Column("code provider", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_provider { get; set; }

        [Key]
        [Column("code product", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_product { get; set; }

        [Key]
        [Column("code staff", Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_staff { get; set; }

        public virtual Product Product { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
