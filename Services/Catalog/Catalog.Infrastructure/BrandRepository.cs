using Catalog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure
{
    public class BrandRepository: DbContext
    {
        public BrandRepository(DbContextOptions<BrandRepository> options) : base(options)
        {
            
        }
        public DbSet<BrandModel> Brands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               base.OnModelCreating(modelBuilder);
        }
    }
}
