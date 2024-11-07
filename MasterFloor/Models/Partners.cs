namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partners()
        {
            Orders = new HashSet<Orders>();
            PartnerProducts = new HashSet<PartnerProducts>();
        }

        public int id { get; set; }

        public int? name_type { get; set; }

        [StringLength(100)]
        public string name_partner { get; set; }

        [StringLength(100)]
        public string director { get; set; }

        [StringLength(100)]
        public string mail { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [StringLength(100)]
        public string legal_address { get; set; }

        [StringLength(50)]
        public string inn { get; set; }

        public int? rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProducts> PartnerProducts { get; set; }

        public virtual TypePartners TypePartners { get; set; }

        [NotMapped]
        public double Discount { get; set; }
    }
}
