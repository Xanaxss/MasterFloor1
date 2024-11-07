namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int id { get; set; }

        public int? partner_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? order_date { get; set; }

        public decimal? total_cost { get; set; }

        public decimal? prepayment { get; set; }

        [StringLength(50)]
        public string delivery_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? completion_date { get; set; }

        public virtual Partners Partners { get; set; }
    }
}
