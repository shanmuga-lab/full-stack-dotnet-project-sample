using System;
using Microsoft.EntityFrameworkCore;
using OnlineStoreModel.Models.TypeModels;

namespace OnlineStoreRepository;

public class TypeRepository: DbContext
{
    public TypeRepository(DbContextOptions<TypeRepository> options) : base(options)
    {
    }

    public DbSet<TypeModel> Types { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /* modelBuilder.Entity<TypeModel>().ToTable("Types");
        modelBuilder.Entity<TypeModel>().HasKey(t => t.Id);
        modelBuilder.Entity<TypeModel>().Property(t => t.Name).IsRequired().HasMaxLength(100);

        modelBuilder.Entity<TypeModel>().HasData(
            new TypeModel { Id = Guid.NewGuid(), Name = "Mobiles" },
            new TypeModel { Id = Guid.NewGuid(), Name = "Accessories" },
            new TypeModel { Id = Guid.NewGuid(), Name = "Books" }
        );*/

    }
}
