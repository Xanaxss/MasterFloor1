namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public int id { get; set; }

        public int? product_type { get; set; }

        [StringLength(100)]
        public string name_product { get; set; }

        public int? articul_number { get; set; }

        public decimal? min_cost_for_partner { get; set; }

        public virtual ProductType ProductType { get; set; }


    }
}
