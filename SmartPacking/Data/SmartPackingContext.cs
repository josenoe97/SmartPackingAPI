using Microsoft.EntityFrameworkCore;
using SmartPacking.Model;

namespace SmartPacking.Data
{
    public class SmartPackingContext : DbContext
    {
        public SmartPackingContext(DbContextOptions<SmartPackingContext> options) : base (options) { }

        public DbSet<OrderModel> Orders { get; set; } 
        public DbSet<BoxModel> Boxs { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
