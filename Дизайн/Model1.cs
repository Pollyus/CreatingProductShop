using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Дизайн
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ProsuctStore")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cheque> Cheque { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Storeroom> Storeroom { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Natural_person> Natural_person { get; set; }
        public virtual DbSet<Procurement> Procurement { get; set; }
        public virtual DbSet<Staff1> Staff1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.category_name)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.category_code);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.payment_type)
                .IsFixedLength();

            modelBuilder.Entity<Cheque>()
                .Property(e => e.loyalty_program)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.retail_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.brand)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Procurement)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.code_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Entity)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Natural_person)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Procurement)
                .WithRequired(e => e.Provider)
                .HasForeignKey(e => e.code_provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.FIO)
                .IsFixedLength();

            modelBuilder.Entity<Staff>()
                .Property(e => e.gender)
                .IsFixedLength();

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Cheque)
                .WithOptional(e => e.Staff)
                .HasForeignKey(e => e.employee_code);

            modelBuilder.Entity<Storeroom>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Storeroom)
                .HasForeignKey(e => e.storeroom_code);

            modelBuilder.Entity<Entity>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Natural_person>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Staff1>()
                .Property(e => e.FIO)
                .IsFixedLength();

            modelBuilder.Entity<Staff1>()
                .Property(e => e.gender)
                .IsFixedLength();
        }
    }
}
