namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Staff1
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string FIO { get; set; }

        [Key]
        [Column("date of birth", Order = 2, TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        [Key]
        [Column("telephone number", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int telephone_number { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string gender { get; set; }
    }
}
