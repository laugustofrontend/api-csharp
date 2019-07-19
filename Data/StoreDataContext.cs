using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Maps;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
  public class StoreDataContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=Cd7k6&8IZ");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new ProductMap());
      builder.ApplyConfiguration(new CategoryMap());
    }
  }
}
