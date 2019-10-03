namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class REGIONS
    {
       
        public REGIONS()
        {
            COUNTRIES = new HashSet<COUNTRIES>();
        }

        [Key]
        public int REGION_ID { get; set; }

        [StringLength(255)]
        public string REGION_NAME { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<COUNTRIES> COUNTRIES { get; set; }
    }
}
