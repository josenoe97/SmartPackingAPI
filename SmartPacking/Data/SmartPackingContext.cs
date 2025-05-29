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

            // Configuração de ProductModel
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Height).IsRequired();
                entity.Property(p => p.Width).IsRequired();
                entity.Property(p => p.Length).IsRequired();
                entity.Ignore(p => p.Volume); 
            });

            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.HasMany<ProductModel>("listProduct")
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(o => o.listProduct).UsePropertyAccessMode(PropertyAccessMode.Property);
            });
        }
    }
}
