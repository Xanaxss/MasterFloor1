namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialType")]
    public partial class MaterialType
    {
        public int id { get; set; }

        [StringLength(100)]
        public string type { get; set; }

        public decimal? percentag_marriage { get; set; }
    }
}
