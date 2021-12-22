using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryType> CategoryType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TypeOfPayment> TypeOfPayments { get; set; }
        public virtual DbSet<User_Sale> User_Sales { get; set; }
        public virtual DbSet<Busket> Busket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Sum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Buyer>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Busket)
                .WithRequired(e => e.Buyer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Buyer)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.User_Sale)
                .WithOptional(e => e.Buyer)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<CategoryType>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<CategoryType>()
                .HasMany(e => e.Category)
                .WithOptional(e => e.CategoryType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Order>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Sum)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderLines>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderLines>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderStatus>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.OrderStatus)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Photo)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Sale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Busket)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Sale>()
                .Property(e => e.Offer)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Condition)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Background)
                .IsFixedLength();

            modelBuilder.Entity<ShoppingCart>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TypeOfPayment>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeOfPayment>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.TypeOfPayment)
                .HasForeignKey(e => e.TypeId);
        }
    }
}
