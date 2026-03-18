using Catalog.API.Features.Categories.Data.Configurations;
using Catalog.API.Features.Categories.Entities;
using Catalog.API.Features.Items.Data.Configurations;
using Catalog.API.Features.Items.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Shared.Data
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