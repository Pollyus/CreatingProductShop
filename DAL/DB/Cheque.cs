namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cheque")]
    public partial class Cheque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column("date of sale")]
        public DateTime date_of_sale { get; set; }

        [Column("employee code")]
        public int? employee_code { get; set; }

        [Column("payment type")]
        [StringLength(10)]
        public string payment_type { get; set; }

        public double? amount { get; set; }

        [Column("loyalty program")]
        [StringLength(10)]
        public string loyalty_program { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
