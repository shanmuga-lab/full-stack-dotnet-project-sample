using Microsoft.EntityFrameworkCore;
using OnlineStoreModel.Models.BrandModels;

namespace OnlineStoreRepository;

public class BrandRepository : DbContext
{
    public BrandRepository(DbContextOptions<BrandRepository> options) : base(options)
    {
    }

    public DbSet<BrandModel> Brands { get; set; }

    // Defined it as protected so that it can be accessed only by derived classes, if any.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
        // create a table for BrandModel and set the primary key to Id
        modelBuilder.Entity<BrandModel>().ToTable("Brands");
        modelBuilder.Entity<BrandModel>().HasKey(b => b.Id);
        // set the Name property to be required and have a maximum length of 100 characters
        modelBuilder.Entity<BrandModel>().Property(b => b.Name).IsRequired().HasMaxLength(100);

        modelBuilder.Entity<BrandModel>().HasData(
            new BrandModel { Id = Guid.NewGuid(), Name = "Samsung" },
            new BrandModel { Id = Guid.NewGuid(), Name = "Apple" },
            new BrandModel { Id = Guid.NewGuid(), Name = "Vivo" }
        );*/
    }



}
