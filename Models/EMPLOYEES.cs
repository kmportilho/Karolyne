namespace HumanResources.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EMPLOYEES
    {
      
        public EMPLOYEES()
        {
            DEPARTMENTS = new HashSet<DEPARTMENTS>();
            EMPLOYEES_MANAGER = new HashSet<EMPLOYEES>();
            JOB_HISTORY = new HashSet<JOB_HISTORY>();
        }

        [Key]
        public int EMPLOYEE_ID { get; set; }

        public int? MANAGER_ID { get; set; }

        [Required(ErrorMessage = "Escolha o departamento!")]
        public int DEPARTMENT_ID { get; set; }

        [Required(ErrorMessage = "Digite o nome!")]
        [StringLength(50)]
        public string FIRST_NAME { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome!")]
        [StringLength(50)]
        public string LAST_NAME { get; set; }

        [Required(ErrorMessage = "Digite o E-mail!")]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Digite o telefone!")]
        [StringLength(50)]
        public string PHONE_NUMBER { get; set; }

        public DateTime? HIRE_DATE { get; set; }

        [Required(ErrorMessage = "Escolha o cargo!")]
        public int JOB_ID { get; set; }

        [Required(ErrorMessage = "Digite o salário!")] 
        public decimal SALARY { get; set; }

        public decimal? COMMISSION_PCT { get; set; }


        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<DEPARTMENTS> DEPARTMENTS { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual DEPARTMENTS DEPARTMENTS1 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<EMPLOYEES> EMPLOYEES_MANAGER { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual EMPLOYEES MANAGER { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual JOBS JOBS { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<JOB_HISTORY> JOB_HISTORY { get; set; }
    }
}
