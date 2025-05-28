using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartPacking.Model;
using System.Text.Json;

namespace SmartPacking.Data.Map
{
    public class OrderMap : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
        .Property(x => x.listProduct)
        .HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            v => JsonSerializer.Deserialize<List<ProductModel>>(v, (JsonSerializerOptions)null))
        .HasColumnType("nvarchar(max)");
        }
    }
}
