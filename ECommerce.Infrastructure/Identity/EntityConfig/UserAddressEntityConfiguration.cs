using ECommerce.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Identity.EntityConfig;
public class UserAddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.AppUserId).IsRequired();

        builder.HasOne(u => u.AppUser)
               .WithOne(s => s.Address)
               .HasForeignKey<Address>(ua => ua.AppUserId);
    }
}
