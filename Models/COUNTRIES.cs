namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COUNTRIES
    {
     
        public COUNTRIES()
        {
            LOCATIONS = new HashSet<LOCATIONS>();
        }

        [Key]
        public int COUNTRY_ID { get; set; }

        [StringLength(50)]
        public string COUNTRY_NAME { get; set; }

        public int? REGION_ID { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual REGIONS REGIONS { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<LOCATIONS> LOCATIONS { get; set; }
    }
}
