using Domain.Entities.ProductEntity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductBrand> ProductBrand => Set<ProductBrand>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<ProductBrand>().HasQueryFilter(x => x.IsDelete == false);
            modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
