
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Configuration ;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
       builder.HasKey(x => x.Id);
       
       builder.Property(x => x.Id).HasConversion(
          productId => productId.Value,
          value => new ProductId(value)
       );

       builder.Property(x => x.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!);

       builder.OwnsOne(p => p.Price , priceBuilder =>
       {
            priceBuilder.Property(x => x.Currency).HasMaxLength(3);
       });

    }
}