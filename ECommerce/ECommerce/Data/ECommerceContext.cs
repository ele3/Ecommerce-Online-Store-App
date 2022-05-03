using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerce.Data
{
    public partial class ECommerceContext : DbContext
    {
        public ECommerceContext()
        {
        }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Cartproduct> Cartproducts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("Default"), 
                                        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => e.CountryId, "countryId");

                entity.HasIndex(e => e.StateId, "stateId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(255)
                    .HasColumnName("streetAddress");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .HasColumnName("zip");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_ibfk_2");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("address_ibfk_1");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.Property(e => e.CardId).HasColumnName("cardId");

                entity.Property(e => e.CardCcv)
                    .HasMaxLength(4)
                    .HasColumnName("cardCCV");

                entity.Property(e => e.CardExpiration)
                    .HasMaxLength(30)
                    .HasColumnName("cardExpiration");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(30)
                    .HasColumnName("cardNumber");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart_ibfk_1");
            });

            modelBuilder.Entity<Cartproduct>(entity =>
            {
                entity.ToTable("cartproduct");

                entity.HasIndex(e => e.ProductId, "productId");

                entity.HasIndex(e => new { e.CartId, e.ProductId }, "uniquePair")
                    .IsUnique();

                entity.Property(e => e.CartProductId).HasColumnName("cartProductId");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cartproduct_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cartproduct_ibfk_2");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("countryId");

                entity.Property(e => e.Country1)
                    .HasMaxLength(255)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("email");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.EmailId).HasColumnName("emailId");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("email_ibfk_1");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerId");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(255)
                    .HasColumnName("manufacturerName");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.CategoryId, "categoryId");

                entity.HasIndex(e => e.ManufacturerId, "manufacturerId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturerId");

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(255)
                    .HasColumnName("productDesc");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(255)
                    .HasColumnName("productImage");

                entity.Property(e => e.ProductLength).HasColumnName("productLength");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice).HasColumnName("productPrice");

                entity.Property(e => e.ProductRating).HasColumnName("productRating");

                entity.Property(e => e.ProductWeight).HasColumnName("productWeight");

                entity.Property(e => e.ProductWidth).HasColumnName("productWidth");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_ibfk_2");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_ibfk_1");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale");

                entity.HasIndex(e => e.CategoryId, "categoryId");

                entity.HasIndex(e => e.ProductId, "productId");

                entity.Property(e => e.SaleId).HasColumnName("saleId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.SaleEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("saleEnd");

                entity.Property(e => e.SaleName)
                    .HasMaxLength(255)
                    .HasColumnName("saleName");

                entity.Property(e => e.SalePercentDiscount).HasColumnName("salePercentDiscount");

                entity.Property(e => e.SaleStart)
                    .HasColumnType("datetime")
                    .HasColumnName("saleStart");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("sale_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("sale_ibfk_2");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateId).HasColumnName("stateId");

                entity.Property(e => e.State1)
                    .HasMaxLength(255)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.AddressId, "addressId");

                entity.HasIndex(e => e.CardId, "cardId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(10)
                    .HasColumnName("adminId");

                entity.Property(e => e.CardId).HasColumnName("cardId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("userPhoneNumber");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("user_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
