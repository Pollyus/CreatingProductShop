namespace Дизайн
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Groups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Faculty { get; set; }
    }
}
