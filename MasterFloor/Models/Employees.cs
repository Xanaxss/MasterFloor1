namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            EmployeeAccess = new HashSet<EmployeeAccess>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string full_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        [StringLength(100)]
        public string passport_data { get; set; }

        [StringLength(100)]
        public string bank_details { get; set; }

        [StringLength(50)]
        public string family_status { get; set; }

        [Column(TypeName = "text")]
        public string health_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeAccess> EmployeeAccess { get; set; }
    }
}
