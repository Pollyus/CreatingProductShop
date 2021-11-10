namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Natural person")]
    public partial class Natural_person
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string name { get; set; }

        [Key]
        [Column("date of birth", Order = 2, TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
