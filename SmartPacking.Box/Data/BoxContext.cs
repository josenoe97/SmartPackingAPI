using Microsoft.EntityFrameworkCore;
using SmartPacking.Box.Model;


namespace SmartPacking.Box.Data
{
    public class BoxContext : DbContext
    {
        public BoxContext(DbContextOptions<BoxContext> options) : base (options) { }
        public DbSet<BoxModel> Boxs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoxModel>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Name).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
