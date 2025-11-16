using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionApp.Domain.Entities;

namespace OnionApp.Persistance.Configurations
{
    public class ProductConfiguration : BaseEntityTypeConfiguration<Product, int>, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasIndex(e => e.CategoryId, "CategoryID");
            //builder.HasIndex(e => e.ProductName, "ProductName");
            //builder.HasIndex(e => e.SupplierId, "SupplierID");

            builder.Property(e => e.ProductName)
                   .HasMaxLength(40);

            builder.Property(e => e.UnitPrice)
                   .HasDefaultValue(0m)
                   .HasColumnType("money");

            builder.Property(e => e.UnitsInStock)
                   .HasDefaultValue((short)0);


            builder.HasOne(d => d.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(d => d.CategoryId)
                   .HasConstraintName("FK_Products_Categories");

            builder.HasOne(d => d.Supplier)
                   .WithMany(p => p.Products)
                   .HasForeignKey(d => d.SupplierId)
                   .HasConstraintName("FK_Products_Suppliers");

            // Global Query Filters Kullanımı
            // https://mennan.medium.com/entity-framework-coreda-global-query-filters-kullan%C4%B1m%C4%B1-a7f3ba48f299
            builder.HasQueryFilter(x => x.IsActive.Value && !x.IsDeleted.Value);
        }
    }
}
