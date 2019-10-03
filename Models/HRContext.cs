namespace HumanResources.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRContext : DbContext
    {
        public HRContext()
            : base("name=HRContext")
        {
        }

        public virtual DbSet<COUNTRIES> COUNTRIES { get; set; }
        public virtual DbSet<DEPARTMENTS> DEPARTMENTS { get; set; }
        public virtual DbSet<EMPLOYEES> EMPLOYEES { get; set; }
        public virtual DbSet<JOB_HISTORY> JOB_HISTORY { get; set; }
        public virtual DbSet<JOBS> JOBS { get; set; }
        public virtual DbSet<LOCATIONS> LOCATIONS { get; set; }
        public virtual DbSet<REGIONS> REGIONS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPARTMENTS>()
                .HasMany(e => e.EMPLOYEES1)
                .WithRequired(e => e.DEPARTMENTS1)
                .HasForeignKey(e => e.DEPARTMENT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENTS>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.DEPARTMENTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.SALARY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EMPLOYEES>()
                .Property(e => e.COMMISSION_PCT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EMPLOYEES>()
                .HasMany(e => e.DEPARTMENTS)
                .WithOptional(e => e.EMPLOYEES)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEES>()
                .HasMany(e => e.EMPLOYEES_MANAGER)
                .WithOptional(e => e.MANAGER)
                .HasForeignKey(e => e.MANAGER_ID);

            modelBuilder.Entity<EMPLOYEES>()
                .HasMany(e => e.JOB_HISTORY)
                .WithRequired(e => e.EMPLOYEES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JOBS>()
                .Property(e => e.MIN_SALARY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JOBS>()
                .Property(e => e.MAX_SALARY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<JOBS>()
                .HasMany(e => e.EMPLOYEES)
                .WithRequired(e => e.JOBS)
                .WillCascadeOnDelete(false);
        }
    }
}
