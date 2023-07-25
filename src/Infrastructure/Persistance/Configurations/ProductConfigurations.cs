using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using practice.Domain.Entities;

namespace practice.Infrastructure.Persistance.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").HasDefaultValue(0);
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Count).HasDefaultValue(0);
        builder.Property(x => x.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(x => x.ModifiedDate).HasDefaultValueSql("GETUTCDATE()");

    }
}
