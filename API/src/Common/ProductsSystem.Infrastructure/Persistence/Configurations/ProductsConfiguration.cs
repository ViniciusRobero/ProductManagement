using ProductsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductsSystem.Infrastructure.Persistence.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Brand)
                        .HasMaxLength(100)
                        .IsRequired();

            builder.Property(t => t.ProductCode)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Discription)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Value)
                .IsRequired();
        }
    }
}
