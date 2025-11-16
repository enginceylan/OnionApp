using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities;

namespace OnionApp.Persistance.Configurations
{
    public class SupplierConfiguration : BaseEntityTypeConfiguration<Supplier, int>, IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.ContactName).HasMaxLength(50);
            builder.Property(x => x.Country).HasMaxLength(50);

            builder.HasQueryFilter(x => x.IsActive.Value && !x.IsDeleted.Value);
        }
    }
}
