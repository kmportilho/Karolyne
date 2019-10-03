namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOCATIONS
    {
       
        public LOCATIONS()
        {
            DEPARTMENTS = new HashSet<DEPARTMENTS>();
        }

        [Key]
        public int LOCATION_ID { get; set; }

        [StringLength(50)]
        public string STREET_ADDRESS { get; set; }

        [StringLength(50)]
        public string POSTAL_CODE { get; set; }

        [StringLength(50)]
        public string CITY { get; set; }

        [StringLength(50)]
        public string STATE_PROVINCE { get; set; }

        public int? COUNTRY_ID { get; set; }

        public virtual COUNTRIES COUNTRIES { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DEPARTMENTS> DEPARTMENTS { get; set; }
    }
}
