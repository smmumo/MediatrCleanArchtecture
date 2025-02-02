
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Configuration ;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        // builder.Property(x => x.Id).HasConversion(oid => oid.Value ,
        //                          value => new OrderId(value));        
       
       builder.Property(x => x.ProductId).HasConversion(
          productId => productId.Value,
          value => new ProductId(value)
       );

        builder.Property(x => x.CustomerId).HasConversion(
          customerId => customerId.Value,
          value => new CustomerId(value)
       );
        
        builder.HasOne<Customer>()
        .WithMany()
        .HasForeignKey(x => x.CustomerId)
        .IsRequired();

        builder.OwnsOne(p => p.Price , priceBuilder => {
            priceBuilder.Property(x => x.Currency).HasMaxLength(3);
        });

        builder.HasMany(o => o.LineItemList)
                    .WithOne(o => o.Order) //line item has one orderid
                    .HasForeignKey(li => li.OrderId)
                    .HasPrincipalKey(x => x.Id);
        
    }
}


