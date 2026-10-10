using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStoreModel.Models.ProductModels;

namespace OnlineStoreRepository;

public class ProductRepository : DbContext
{
        public ProductRepository(DbContextOptions<ProductRepository> options) : base(options)
        {
        }

        public DbSet <ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<ProductModel>().ToTable("Products");
            modelBuilder.Entity<ProductModel>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductDescription).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<ProductModel>().Property(p => p.BrandId).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.TypeId).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.ImageName).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.ImageUrl).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductPrice).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.GST).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
            */

        }
}
