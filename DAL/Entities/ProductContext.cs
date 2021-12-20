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

        public virtual DbSet<BatchOfProduct> BatchOfProduct { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Pick_Point> Pick_Point { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TypeOfPayment> TypeOfPayment { get; set; }
        public virtual DbSet<TypeOfUser> TypeOfUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Sale> User_Sales { get; set; }
        public virtual DbSet<Busket> Busket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchOfProduct>()
                .HasMany(e => e.Busket)
                .WithRequired(e => e.BatchOfProduct)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BatchOfProduct>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.BatchOfProduct)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.Name)
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

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

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

            modelBuilder.Entity<Pick_Point>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Pick_Point>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Pick_Point)
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
                .HasMany(e => e.BatchOfProduct)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductCode)
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

            modelBuilder.Entity<TypeOfUser>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<TypeOfUser>()
                .HasMany(e => e.User)
                .WithRequired(e => e.TypeOfUser)
                .HasForeignKey(e => e.TipeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Buyer)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
