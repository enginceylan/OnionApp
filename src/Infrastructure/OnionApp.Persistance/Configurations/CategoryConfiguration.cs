using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities;

namespace OnionApp.Persistance.Configurations
{
    public class CategoryConfiguration : BaseEntityTypeConfiguration<Category, int>, IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(75);
            builder.Property(x => x.Description).HasColumnType("ntext");

            builder.HasQueryFilter(x => x.IsActive.Value && !x.IsDeleted.Value);
        }
    }
}
