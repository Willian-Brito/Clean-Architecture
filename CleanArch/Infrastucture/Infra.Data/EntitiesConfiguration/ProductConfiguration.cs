using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.IdProduct);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();

        builder.Property(p => p.Price).HasPrecision(10, 2);

        builder.HasOne(e => e.Category).WithMany(e => e.Products)
            .HasForeignKey(e => e.IdCategory);
    }
}
