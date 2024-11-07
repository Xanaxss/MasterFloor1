namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PartnerProducts
    {
        public int id { get; set; }

        public int? parnter_id { get; set; }

        public int? number_products { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_sales { get; set; }

        public virtual Partners Partners { get; set; }
    }
}
