using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductBrand>? ProductBrands { get; set; }
        public DbSet<ProductType>? ProductTypes { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<DeliveryMethod>? DeliveryMethods { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
