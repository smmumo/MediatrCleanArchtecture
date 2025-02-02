
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Configuration ;

internal class LineItemsConfiguration : IEntityTypeConfiguration<LineItems>
{
    public void Configure(EntityTypeBuilder<LineItems> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(oid => oid.Value ,
                                 value => new LineItemId(value));
        
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(li => li.ProductId);

        builder.Property(x => x.ProductId)
        .HasConversion(o => o.Value, value => new ProductId(value));

    //     builder.Property(x => x.OrderId).HasConversion(
    //       x => x.Value,
    //       value => new OrderId(value)
    //    );
     
        builder.HasOne<Order>()
        .WithMany()
        .HasForeignKey(li => li.OrderId);

        builder.OwnsOne(li => li.Price);
    }
}