namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JOB_HISTORY
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        public DateTime? START_DATE { get; set; }

        public DateTime? END_DATE { get; set; }

        public int? JOB_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DEPARTMENT_ID { get; set; }

        public virtual DEPARTMENTS DEPARTMENTS { get; set; }

        public virtual EMPLOYEES EMPLOYEES { get; set; }

        public virtual JOBS JOBS { get; set; }
    }
}
