using Catalog.API.Configurations;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API
{
    public class CatalogContext(DbContextOptions<CatalogContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
        }
    }
}