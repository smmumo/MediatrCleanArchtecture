
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Domain.Entities;

namespace StockApp.Infrastracture.Persistence.Configuration ;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
       builder.HasKey(x => x.Id);
       builder.Property(x => x.Id).HasConversion(id => id.Value ,
                                 value => new CustomerId(value));

        builder.Property(x => x.Name).HasMaxLength(255);
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.HasIndex(x => x.Email).IsUnique();       
    }
}