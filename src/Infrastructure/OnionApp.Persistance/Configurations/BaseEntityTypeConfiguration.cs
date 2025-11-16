using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Persistance.Configurations
{
    public class BaseEntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TId>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id); // Id kolonu primary key

            builder.Property(x => x.Created)
                   .HasColumnType("datetime"); // Created isimli kolonun tipi datetime olsun

            builder.Property(x => x.LastModified)
                   .HasColumnType("datetime");

            builder.Property(x => x.IsDeleted)
                   .HasColumnType("bit");

            builder.Property(x => x.IsActive)
                  .HasColumnType("bit");

        }
    }
}
