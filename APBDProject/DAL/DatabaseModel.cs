namespace APBDProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarOwner> CarOwners { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Review)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<CarOwner>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<CarType>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
