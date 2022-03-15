using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.EntityConfig
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> productBuilder)
        {
            productBuilder.Property(p => p.Id).IsRequired();
            productBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            productBuilder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            productBuilder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            productBuilder.Property(p => p.PictureUrl).IsRequired();

            productBuilder.HasOne(p => p.ProductBrand)
                          .WithMany()
                          .HasForeignKey(p => p.ProductBrandId);
            productBuilder.HasOne(p => p.ProductType)
                          .WithMany()
                          .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
