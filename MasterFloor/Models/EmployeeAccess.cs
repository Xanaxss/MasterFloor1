namespace MasterFloor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeAccess")]
    public partial class EmployeeAccess
    {
        public int id { get; set; }

        public int? employee_id { get; set; }

        [StringLength(100)]
        public string access_type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? access_date { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
